using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Parents : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Parents()
        {
            InitializeComponent();
            LoadParents();
        }

        private void LoadParents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ParentIndexNo, FirstName, LastName, Gender, Telephone, Email, Address, Occupation, StudentId FROM Parents";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvParents.DataSource = dt;
            }
        }

        private void ClearFields()
        {
            txtParentIndexNo.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            comboGender.SelectedIndex = -1;
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtOccupation.Text = "";
            txtStudentId.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please enter at least First Name and Student ID.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Parents (FirstName, LastName, Gender, Telephone, Email, Address, Occupation, StudentId)
                                 VALUES (@FirstName, @LastName, @Gender, @Telephone, @Email, @Address, @Occupation, @StudentId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text.Trim());
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(txtStudentId.Text.Trim()));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error adding parent: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            LoadParents();
            ClearFields();
            MessageBox.Show("Parent added successfully.");
        }

        private void dgvParents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvParents.Rows[e.RowIndex];
                txtParentIndexNo.Text = row.Cells["ParentIndexNo"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                comboGender.SelectedItem = row.Cells["Gender"].Value.ToString();
                txtTelephone.Text = row.Cells["Telephone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtOccupation.Text = row.Cells["Occupation"].Value.ToString();
                txtStudentId.Text = row.Cells["StudentId"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParentIndexNo.Text))
            {
                MessageBox.Show("Please select a parent to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please enter at least First Name and Student ID.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Parents SET
                                 FirstName=@FirstName, LastName=@LastName, Gender=@Gender,
                                 Telephone=@Telephone, Email=@Email, Address=@Address,
                                 Occupation=@Occupation, StudentId=@StudentId
                                 WHERE ParentIndexNo=@ParentIndexNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text.Trim());
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(txtStudentId.Text.Trim()));
                cmd.Parameters.AddWithValue("@ParentIndexNo", Convert.ToInt32(txtParentIndexNo.Text));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating parent: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            LoadParents();
            ClearFields();
            MessageBox.Show("Parent updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParentIndexNo.Text))
            {
                MessageBox.Show("Please select a parent to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this parent?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Parents WHERE ParentIndexNo=@ParentIndexNo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ParentIndexNo", Convert.ToInt32(txtParentIndexNo.Text));

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting parent: " + ex.Message);
                        return;
                    }
                    conn.Close();
                }
                LoadParents();
                ClearFields();
                MessageBox.Show("Parent deleted successfully.");
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
    }
}
