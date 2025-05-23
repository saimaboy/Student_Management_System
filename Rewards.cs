using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Rewards: Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Rewards()
        {
            InitializeComponent();
            LoadRewards();
            dtpDateTime.Value = DateTime.Now;
        }

        private void LoadRewards()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT RewardId, StudentId, Reward, Description, DateTime FROM Rewards";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvRewards.DataSource = dt;
            }
        }

        private void ClearFields()
        {
            txtRewardId.Text = "";
            txtStudentId.Text = "";
            txtReward.Text = "";
            txtDescription.Text = "";
            dtpDateTime.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) || string.IsNullOrWhiteSpace(txtReward.Text))
            {
                MessageBox.Show("Please enter Student ID and Reward.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Rewards (StudentId, Reward, Description, DateTime)
                                 VALUES (@StudentId, @Reward, @Description, @DateTime)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(txtStudentId.Text.Trim()));
                cmd.Parameters.AddWithValue("@Reward", txtReward.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@DateTime", dtpDateTime.Value);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error adding reward: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            LoadRewards();
            ClearFields();
            MessageBox.Show("Reward added successfully.");
        }

        private void dgvRewards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRewards.Rows[e.RowIndex];
                txtRewardId.Text = row.Cells["RewardId"].Value.ToString();
                txtStudentId.Text = row.Cells["StudentId"].Value.ToString();
                txtReward.Text = row.Cells["Reward"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                dtpDateTime.Value = Convert.ToDateTime(row.Cells["DateTime"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRewardId.Text))
            {
                MessageBox.Show("Please select a reward to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) || string.IsNullOrWhiteSpace(txtReward.Text))
            {
                MessageBox.Show("Please enter Student ID and Reward.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Rewards SET StudentId=@StudentId, Reward=@Reward, Description=@Description, DateTime=@DateTime
                                 WHERE RewardId=@RewardId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(txtStudentId.Text.Trim()));
                cmd.Parameters.AddWithValue("@Reward", txtReward.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@DateTime", dtpDateTime.Value);
                cmd.Parameters.AddWithValue("@RewardId", Convert.ToInt32(txtRewardId.Text));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating reward: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            LoadRewards();
            ClearFields();
            MessageBox.Show("Reward updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRewardId.Text))
            {
                MessageBox.Show("Please select a reward to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this reward?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Rewards WHERE RewardId=@RewardId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RewardId", Convert.ToInt32(txtRewardId.Text));

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting reward: " + ex.Message);
                        return;
                    }
                    conn.Close();
                }
                LoadRewards();
                ClearFields();
                MessageBox.Show("Reward deleted successfully.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Students studentsForm = new Students();
            studentsForm.Show();
            this.Close();
        }

        private void dgvRewards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
