using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Attendance : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Attendance()
        {
            InitializeComponent();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        s.StudentId, s.FirstName, s.LastName, s.Email,
                        ISNULL(a.Status, 'Not Marked') AS AttendanceStatus,
                        ISNULL(CONVERT(varchar, a.AttendanceDate, 23), '') AS AttendanceDate
                    FROM Students s
                    LEFT JOIN Attendance a ON s.StudentId = a.StudentId AND a.AttendanceDate = CAST(GETDATE() AS DATE)
                    ORDER BY s.LastName, s.FirstName
                ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvStudents.DataSource = dt;

                if (dgvStudents.Columns["AttendanceStatus"] != null)
                    dgvStudents.Columns["AttendanceStatus"].HeaderText = "Attendance";
                if (dgvStudents.Columns["AttendanceDate"] != null)
                    dgvStudents.Columns["AttendanceDate"].HeaderText = "Date";
            }
        }

        private int? GetSelectedStudentId()
        {
            if (dgvStudents.SelectedRows.Count == 0) return null;
            return Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentId"].Value);
        }

        private string GetSelectedStudentFullName()
        {
            if (dgvStudents.SelectedRows.Count == 0) return "";
            var row = dgvStudents.SelectedRows[0];
            return $"{row.Cells["FirstName"].Value} {row.Cells["LastName"].Value}";
        }

        private string GetSelectedStudentEmail()
        {
            if (dgvStudents.SelectedRows.Count == 0) return "";
            return dgvStudents.SelectedRows[0].Cells["Email"].Value.ToString();
        }

        private void btnAttend_Click(object sender, EventArgs e)
        {
            var studentId = GetSelectedStudentId();
            if (studentId == null)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            if (RecordAttendance(studentId.Value, "Present"))
            {
                MessageBox.Show("Attendance marked as Present.");
                LoadStudents(); // Refresh to show updated attendance
            }
        }

        private void btnNotAttend_Click(object sender, EventArgs e)
        {
            var studentId = GetSelectedStudentId();
            if (studentId == null)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            if (RecordAttendance(studentId.Value, "Absent"))
            {
                MessageBox.Show("Attendance marked as Absent.");
                LoadStudents(); // Refresh grid
                SendAbsentEmail(studentId.Value);
            }
        }

        private bool RecordAttendance(int studentId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    IF NOT EXISTS (SELECT 1 FROM Attendance WHERE StudentId = @StudentId AND AttendanceDate = CAST(GETDATE() AS DATE))
                    BEGIN
                        INSERT INTO Attendance (StudentId, Status, AttendanceDate) 
                        VALUES (@StudentId, @Status, CAST(GETDATE() AS DATE))
                    END
                    ELSE
                    BEGIN
                        UPDATE Attendance SET Status = @Status WHERE StudentId = @StudentId AND AttendanceDate = CAST(GETDATE() AS DATE)
                    END";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                conn.Close();

                return affected > 0;
            }
        }

        private void SendAbsentEmail(int studentId)
        {
            string parentEmail = "";
            string studentName = "";
            string parentName = "";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT s.FirstName, s.LastName, p.Email, p.FirstName as ParentFirstName
                    FROM Students s
                    LEFT JOIN Parents p ON s.StudentId = p.StudentId
                    WHERE s.StudentId = @StudentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        studentName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        parentEmail = reader["Email"]?.ToString();
                        parentName = reader["ParentFirstName"]?.ToString() ?? "Parent";
                    }
                }
                conn.Close();
            }

            if (string.IsNullOrWhiteSpace(parentEmail))
            {
                MessageBox.Show("Parent email not found. Cannot send email.");
                return;
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dhanukanuwan2001@gmail.com"); // Put your sender email here
                mail.To.Add(parentEmail);
                mail.Subject = "Student Absence Notification";
                mail.Body = $"Dear {parentName},\n\nThis is to inform you that your child, {studentName}, was absent from school today ({DateTime.Now:yyyy-MM-dd}).\n\nRegards,\nSchool Administration";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("dhanukanuwan2001@gmail.com", "cjby bjva xccl ncjl"), // Replace with your credentials
                    EnableSsl = true,
                };
                smtpClient.Send(mail);

                MessageBox.Show("Absence notification email sent to parent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle clicks if needed
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Example: Close this form and open dashboard if needed
            this.Close();
        }
    }
}
