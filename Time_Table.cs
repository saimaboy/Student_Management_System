using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Time_Table : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Time_Table()
        {
            InitializeComponent();
            InitializeGrid();
        }

        // Setup DataGridView columns and rows (periods 1-8)
        private void InitializeGrid()
        {
            dgvTimeTable.Columns.Clear();
            dgvTimeTable.Rows.Clear();

            // Add columns for days Monday to Friday
            dgvTimeTable.Columns.Add("Monday", "Monday");
            dgvTimeTable.Columns.Add("Tuesday", "Tuesday");
            dgvTimeTable.Columns.Add("Wednesday", "Wednesday");
            dgvTimeTable.Columns.Add("Thursday", "Thursday");
            dgvTimeTable.Columns.Add("Friday", "Friday");

            // Add 8 rows for periods 1-8
            for (int i = 1; i <= 8; i++)
            {
                dgvTimeTable.Rows.Add();
                dgvTimeTable.Rows[i - 1].HeaderCell.Value = $"Period {i}";
            }

            dgvTimeTable.RowHeadersWidth = 80;
            dgvTimeTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTimeTable.AllowUserToAddRows = false;
        }

        // Load timetable data from database into grid
        private void btnLoad_Click(object sender, EventArgs e)
        {
            InitializeGrid();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Period, Day, Subject FROM TimeTable";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int period = (int)reader["Period"];
                    string day = reader["Day"].ToString();
                    string subject = reader["Subject"]?.ToString() ?? "";

                    int rowIndex = period - 1;
                    int colIndex = GetDayColumnIndex(day);

                    if (rowIndex >= 0 && colIndex >= 0)
                    {
                        dgvTimeTable.Rows[rowIndex].Cells[colIndex].Value = subject;
                    }
                }

                conn.Close();
            }
        }

        // Save timetable data from grid to database
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Delete existing timetable to overwrite
                string deleteQuery = "DELETE FROM TimeTable";
                SqlCommand delCmd = new SqlCommand(deleteQuery, conn);
                delCmd.ExecuteNonQuery();

                // Insert new timetable
                string insertQuery = "INSERT INTO TimeTable (Period, Day, Subject) VALUES (@Period, @Day, @Subject)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);

                insertCmd.Parameters.Add("@Period", System.Data.SqlDbType.Int);
                insertCmd.Parameters.Add("@Day", System.Data.SqlDbType.NVarChar, 10);
                insertCmd.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar, 100);

                for (int period = 1; period <= 8; period++)
                {
                    for (int col = 0; col < dgvTimeTable.Columns.Count; col++)
                    {
                        object val = dgvTimeTable.Rows[period - 1].Cells[col].Value;
                        string subject = val?.ToString() ?? "";

                        insertCmd.Parameters["@Period"].Value = period;
                        insertCmd.Parameters["@Day"].Value = dgvTimeTable.Columns[col].Name;
                        insertCmd.Parameters["@Subject"].Value = subject;

                        insertCmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }

            MessageBox.Show("Timetable saved successfully.");
        }

        // Utility: Map day name to column index
        private int GetDayColumnIndex(string day)
        {
            switch (day)
            {
                case "Monday": return 0;
                case "Tuesday": return 1;
                case "Wednesday": return 2;
                case "Thursday": return 3;
                case "Friday": return 4;
                default: return -1;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimeTable_Load(object sender, EventArgs e)
        {

        }

        private void dgvTimeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
