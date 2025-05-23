using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Marks : Form
    {
        // Connection string to the database
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        private DataTable dtMarks;    // Holds marks and student info
        private DataTable dtSubjects; // Holds subjects info

        public Marks()
        {
            InitializeComponent();
            LoadSubjects();
            LoadMarks();
        }

        // Load all subjects from database into dtSubjects
        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SubjectId, SubjectName FROM Subjects ORDER BY SubjectName";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dtSubjects = new DataTable();
                adapter.Fill(dtSubjects);
            }
        }

        // Load marks for all students and subjects into dtMarks and bind to DataGridView
        private void LoadMarks()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Load students with full name concatenated
                string studentsQuery = "SELECT StudentId, FirstName + ' ' + LastName AS StudentName FROM Students ORDER BY LastName, FirstName";
                SqlDataAdapter studentsAdapter = new SqlDataAdapter(studentsQuery, conn);
                DataTable dtStudents = new DataTable();
                studentsAdapter.Fill(dtStudents);

                // Setup dtMarks columns
                dtMarks = new DataTable();
                dtMarks.Columns.Add("StudentId", typeof(int));
                dtMarks.Columns.Add("StudentName", typeof(string));

                // Add columns for each subject dynamically
                foreach (DataRow subject in dtSubjects.Rows)
                {
                    dtMarks.Columns.Add(subject["SubjectName"].ToString(), typeof(double));
                }

                dtMarks.Columns.Add("Mean", typeof(double));
                dtMarks.Columns.Add("Place", typeof(string));

                // Fill marks for each student and subject
                foreach (DataRow student in dtStudents.Rows)
                {
                    DataRow row = dtMarks.NewRow();
                    row["StudentId"] = student["StudentId"];
                    row["StudentName"] = student["StudentName"];

                    foreach (DataRow subject in dtSubjects.Rows)
                    {
                        string markQuery = "SELECT Mark FROM Marks WHERE StudentId = @StudentId AND SubjectId = @SubjectId";
                        SqlCommand cmd = new SqlCommand(markQuery, conn);
                        cmd.Parameters.AddWithValue("@StudentId", student["StudentId"]);
                        cmd.Parameters.AddWithValue("@SubjectId", subject["SubjectId"]);

                        conn.Open();
                        object markObj = cmd.ExecuteScalar();
                        conn.Close();

                        if (markObj != null && double.TryParse(markObj.ToString(), out double mark))
                            row[subject["SubjectName"].ToString()] = mark;
                        else
                            row[subject["SubjectName"].ToString()] = DBNull.Value;
                    }

                    // Mean and place will be calculated later
                    row["Mean"] = DBNull.Value;
                    row["Place"] = "";

                    dtMarks.Rows.Add(row);
                }

                dgvMarks.DataSource = dtMarks;

                // Make columns read-only as needed
                dgvMarks.Columns["StudentId"].ReadOnly = true;
                dgvMarks.Columns["StudentName"].ReadOnly = true;
                dgvMarks.Columns["Mean"].ReadOnly = true;
                dgvMarks.Columns["Place"].ReadOnly = true;
            }
        }

        // Save marks and update mean and place rankings in DB
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (DataRow row in dtMarks.Rows)
                {
                    int studentId = (int)row["StudentId"];

                    double sumMarks = 0;
                    int countMarks = 0;

                    foreach (DataRow subject in dtSubjects.Rows)
                    {
                        string subjectName = subject["SubjectName"].ToString();
                        int subjectId = (int)subject["SubjectId"];
                        double mark = 0;
                        bool markExists = false;

                        if (row[subjectName] != DBNull.Value)
                        {
                            mark = Convert.ToDouble(row[subjectName]);
                            sumMarks += mark;
                            countMarks++;
                            markExists = true;
                        }

                        string queryCheck = "SELECT COUNT(*) FROM Marks WHERE StudentId=@StudentId AND SubjectId=@SubjectId";
                        SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                        cmdCheck.Parameters.AddWithValue("@StudentId", studentId);
                        cmdCheck.Parameters.AddWithValue("@SubjectId", subjectId);
                        int count = (int)cmdCheck.ExecuteScalar();

                        if (markExists)
                        {
                            if (count > 0)
                            {
                                string queryUpdate = "UPDATE Marks SET Mark=@Mark WHERE StudentId=@StudentId AND SubjectId=@SubjectId";
                                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                                cmdUpdate.Parameters.AddWithValue("@Mark", mark);
                                cmdUpdate.Parameters.AddWithValue("@StudentId", studentId);
                                cmdUpdate.Parameters.AddWithValue("@SubjectId", subjectId);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            else
                            {
                                string queryInsert = "INSERT INTO Marks (StudentId, SubjectId, Mark) VALUES (@StudentId, @SubjectId, @Mark)";
                                SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                                cmdInsert.Parameters.AddWithValue("@StudentId", studentId);
                                cmdInsert.Parameters.AddWithValue("@SubjectId", subjectId);
                                cmdInsert.Parameters.AddWithValue("@Mark", mark);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if (count > 0)
                            {
                                string queryDelete = "DELETE FROM Marks WHERE StudentId=@StudentId AND SubjectId=@SubjectId";
                                SqlCommand cmdDelete = new SqlCommand(queryDelete, conn);
                                cmdDelete.Parameters.AddWithValue("@StudentId", studentId);
                                cmdDelete.Parameters.AddWithValue("@SubjectId", subjectId);
                                cmdDelete.ExecuteNonQuery();
                            }
                        }
                    }

                    // Calculate mean for student
                    double mean = countMarks > 0 ? sumMarks / countMarks : 0;
                    row["Mean"] = mean;
                }

                // Assign places by descending mean
                DataView dv = new DataView(dtMarks);
                dv.Sort = "Mean DESC";

                int place = 1;
                double? lastMean = null;
                int actualPlace = 1;

                foreach (DataRowView drv in dv)
                {
                    double meanVal = drv.Row.Field<double>("Mean");

                    if (lastMean != meanVal)
                    {
                        actualPlace = place;
                        lastMean = meanVal;
                    }
                    drv.Row["Place"] = actualPlace + GetOrdinal(actualPlace);
                    place++;
                }

                // Update StudentMeanPlaces table with mean and place
                foreach (DataRow row in dtMarks.Rows)
                {
                    int studentId = (int)row["StudentId"];
                    double mean = row["Mean"] == DBNull.Value ? 0 : Convert.ToDouble(row["Mean"]);
                    string placeStr = row["Place"].ToString();

                    string queryCheck = "SELECT COUNT(*) FROM StudentMeanPlaces WHERE StudentId=@StudentId";
                    SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@StudentId", studentId);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        string queryUpdate = "UPDATE StudentMeanPlaces SET MeanMark=@MeanMark, Place=@Place WHERE StudentId=@StudentId";
                        SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                        cmdUpdate.Parameters.AddWithValue("@MeanMark", mean);
                        cmdUpdate.Parameters.AddWithValue("@Place", placeStr);
                        cmdUpdate.Parameters.AddWithValue("@StudentId", studentId);
                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        string queryInsert = "INSERT INTO StudentMeanPlaces (StudentId, MeanMark, Place) VALUES (@StudentId, @MeanMark, @Place)";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                        cmdInsert.Parameters.AddWithValue("@StudentId", studentId);
                        cmdInsert.Parameters.AddWithValue("@MeanMark", mean);
                        cmdInsert.Parameters.AddWithValue("@Place", placeStr);
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }

            MessageBox.Show("Marks saved and rankings updated.");
            dgvMarks.Refresh();
        }

        // Reload subjects and marks from DB
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadMarks();
        }

        // Returns suffix for ranking: 1st, 2nd, 3rd, etc.
        private static string GetOrdinal(int number)
        {
            if (number <= 0) return "";
            int rem = number % 100;
            if (rem >= 11 && rem <= 13) return "th";

            switch (number % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

        // Close the form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Placeholder for DataGridView cell click event
        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: add any needed logic here
        }

        // === NEW: Send Report Button Handler ===
        private void btnSendReport_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (DataRow row in dtMarks.Rows)
                {
                    int studentId = (int)row["StudentId"];
                    string studentName = row["StudentName"].ToString();
                    string place = row["Place"].ToString();
                    double mean = row["Mean"] == DBNull.Value ? 0 : Convert.ToDouble(row["Mean"]);

                    // Build the marks report
                    string marksReport = "";
                    foreach (DataRow subject in dtSubjects.Rows)
                    {
                        string subjectName = subject["SubjectName"].ToString();
                        string markStr = row[subjectName] == DBNull.Value ? "N/A" : row[subjectName].ToString();
                        marksReport += $"{subjectName}: {markStr}\n";
                    }

                    string emailBody = $"Dear Parent,\n\n" +
                        $"Here is the academic report for your child, {studentName}:\n\n" +
                        $"{marksReport}\n" +
                        $"Mean Score: {mean:F2}\n" +
                        $"Place: {place}\n\n" +
                        $"Best regards,\nSchool Administration";

                    // Get parent email
                    string parentEmail = GetParentEmail(conn, studentId);
                    if (string.IsNullOrEmpty(parentEmail))
                    {
                        MessageBox.Show($"Parent email not found for {studentName}, skipping.");
                        continue;
                    }

                    try
                    {
                        SendEmail(parentEmail, "Academic Report", emailBody);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to send email to {parentEmail}: {ex.Message}");
                    }
                }

                conn.Close();
            }

            MessageBox.Show("Report emails sent.");
        }

        // Query to get parent's email for a student
        private string GetParentEmail(SqlConnection conn, int studentId)
        {
            string query = "SELECT TOP 1 Email FROM Parents WHERE StudentId = @StudentId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        // Send email using SMTP
        private void SendEmail(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("dhanukanuwan2001@gmail.com"); // Replace with your email
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com") // Change SMTP server if needed
            {
                Port = 587,
                Credentials = new NetworkCredential("dhanukanuwan2001@gmail.com", "cjby bjva xccl ncjl"), // Replace with your credentials
                EnableSsl = true,
            };

            smtp.Send(mail);
        }
    }
}
