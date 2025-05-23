using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Clubs : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Clubs()
        {
            InitializeComponent();
            LoadClubs();
        }

        private void LoadClubs()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ClubId, ClubName, Description FROM Clubs";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvClubs.DataSource = dt;
            }
        }

        private void ClearFields()
        {
            txtClubId.Text = "";
            txtClubName.Text = "";
            txtDescription.Text = "";
        }

        private void dgvClubs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvClubs.Rows[e.RowIndex];
            txtClubId.Text = row.Cells["ClubId"].Value.ToString();
            txtClubName.Text = row.Cells["ClubName"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClubName.Text))
            {
                MessageBox.Show("Please enter club name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clubs (ClubName, Description) VALUES (@ClubName, @Description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClubName", txtClubName.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            LoadClubs();
            ClearFields();
            MessageBox.Show("Club added successfully.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClubId.Text))
            {
                MessageBox.Show("Please select a club to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClubName.Text))
            {
                MessageBox.Show("Please enter club name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Clubs SET ClubName=@ClubName, Description=@Description WHERE ClubId=@ClubId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClubName", txtClubName.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@ClubId", Convert.ToInt32(txtClubId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            LoadClubs();
            ClearFields();
            MessageBox.Show("Club updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClubId.Text))
            {
                MessageBox.Show("Please select a club to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this club?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Clubs WHERE ClubId=@ClubId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClubId", Convert.ToInt32(txtClubId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            LoadClubs();
            ClearFields();
            MessageBox.Show("Club deleted successfully.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Example: Close this form and open dashboard if needed
            this.Close();
        }
    }
}
