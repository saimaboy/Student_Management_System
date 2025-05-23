using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Reports : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Reports()
        {
            InitializeComponent();
        }

        // Utility: Export DataTable to CSV file
        private void ExportToCsv(DataTable dt, string defaultFileName)
        {
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FileName = defaultFileName;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            StringBuilder sb = new StringBuilder();

            // Column headers
            string[] columnNames = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                columnNames[i] = dt.Columns[i].ColumnName;
            sb.AppendLine(string.Join(",", columnNames));

            // Rows
            foreach (DataRow row in dt.Rows)
            {
                string[] fields = new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string val = row[i]?.ToString() ?? "";
                    // Escape quotes in fields
                    val = val.Replace("\"", "\"\"");
                    if (val.Contains(",") || val.Contains("\"") || val.Contains("\n"))
                        val = $"\"{val}\"";
                    fields[i] = val;
                }
                sb.AppendLine(string.Join(",", fields));
            }

            try
            {
                File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Report exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT s.StudentId, s.FirstName, s.LastName, a.Status, a.AttendanceDate
                    FROM Attendance a
                    INNER JOIN Students s ON a.StudentId = s.StudentId
                    ORDER BY a.AttendanceDate DESC, s.LastName, s.FirstName";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            ExportToCsv(dt, "AttendanceReport.csv");
        }

        private void btnMarksReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT s.StudentId, s.FirstName, s.LastName, sub.SubjectName, m.Mark
                    FROM Marks m
                    INNER JOIN Students s ON m.StudentId = s.StudentId
                    INNER JOIN Subjects sub ON m.SubjectId = sub.SubjectId
                    ORDER BY s.LastName, s.FirstName, sub.SubjectName";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            ExportToCsv(dt, "FullMarksReport.csv");
        }

        private void btnParentsReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.ParentIndexNo, p.FirstName AS ParentFirstName, p.LastName AS ParentLastName, p.Email AS ParentEmail,
                           s.StudentId, s.FirstName AS StudentFirstName, s.LastName AS StudentLastName
                    FROM Parents p
                    INNER JOIN Students s ON p.StudentId = s.StudentId
                    ORDER BY p.LastName, p.FirstName";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            ExportToCsv(dt, "ParentsReport.csv");
        }

        private void btnStudentsReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentId, FirstName, LastName, Email, Gender, DOB, Address, Grade FROM Students ORDER BY LastName, FirstName";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            ExportToCsv(dt, "StudentsReport.csv");
        }

        private void btnRewardsReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT r.RewardId, s.StudentId, s.FirstName, s.LastName, r.Reward, r.Description, r.DateTime
                    FROM Rewards r
                    INNER JOIN Students s ON r.StudentId = s.StudentId
                    ORDER BY r.DateTime DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            ExportToCsv(dt, "RewardsReport.csv");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
