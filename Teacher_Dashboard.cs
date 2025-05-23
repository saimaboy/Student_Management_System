using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Teacher_Dashboard : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Teacher_Dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            UpdateStudentCount();
            UpdateSubjectCount();
            UpdateAttendanceCount();
            LoadTimetable();
        }

        private void UpdateStudentCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                lblTotalStudentsCount.Text = count.ToString();
            }
        }

        private void UpdateSubjectCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Subjects";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                lblTotalSubjectsCount.Text = count.ToString();
            }
        }

        private void UpdateAttendanceCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Count students marked Present today
                string query = "SELECT COUNT(*) FROM Attendance WHERE Status = 'Present' AND AttendanceDate = CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                lblTotalAttendanceCount.Text = count.ToString();
            }
        }

        private void LoadTimetable()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Period, Day, Subject FROM TimeTable";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Prepare DataTable for DataGridView
                DataTable dtGrid = new DataTable();
                dtGrid.Columns.Add("Period");

                string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
                foreach (string day in days)
                {
                    dtGrid.Columns.Add(day);
                }

                for (int i = 1; i <= 8; i++)
                {
                    DataRow newRow = dtGrid.NewRow();
                    newRow["Period"] = $"Period {i}";
                    dtGrid.Rows.Add(newRow);
                }

                // Fill timetable subjects into dtGrid
                foreach (DataRow row in dt.Rows)
                {
                    int period = Convert.ToInt32(row["Period"]);
                    string day = row["Day"].ToString();
                    string subject = row["Subject"].ToString();

                    if (period >= 1 && period <= 8 && dtGrid.Columns.Contains(day))
                    {
                        dtGrid.Rows[period - 1][day] = subject;
                    }
                }

                dgvTimetable.DataSource = dtGrid;

                dgvTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTimetable.ReadOnly = true;
                dgvTimetable.RowHeadersVisible = false;
                dgvTimetable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        // Sidebar navigation label click handlers:
        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Already on Dashboard");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Students students = new Students();
            students.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Parents parents = new Parents();
            parents.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Teachers teachers = new Teachers();
            teachers.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Subjects subjects = new Subjects();
            subjects.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Marks marks = new Marks();
            marks.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Clubs clubs = new Clubs();
            clubs.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Rewards rewards = new Rewards();
            rewards.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Time_Table timeTable = new Time_Table();
            timeTable.Show();
        }

        private void lblTotalStudentsCount_Click(object sender, EventArgs e)
        {
            UpdateStudentCount();
            MessageBox.Show($"Total Students: {lblTotalStudentsCount.Text}");
        }

        private void lblTotalSubjectsCount_Click(object sender, EventArgs e)
        {
            UpdateSubjectCount();
            MessageBox.Show($"Total Subjects: {lblTotalSubjectsCount.Text}");
        }

        private void lblTotalAttendanceCount_Click(object sender, EventArgs e)
        {
            UpdateAttendanceCount();
            MessageBox.Show($"Today's Present Students: {lblTotalAttendanceCount.Text}");
        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Implement cell click action if needed
        }



        private void btnChat_Click(object sender, EventArgs e)
        {
            Email email = new Email();
            email.Show();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom paint code
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Optional calendar date changed handling
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Optional label click if needed
        }
    }
}
