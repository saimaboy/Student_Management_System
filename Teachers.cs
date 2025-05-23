using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Teachers : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Teachers()
        {
            InitializeComponent();
            LoadTeachers();
            dtpHireDate.Value = DateTime.Now;

            // Default UserRole selection to "Teacher"
            comboUserRole.SelectedItem = "Teacher";
        }

        private void LoadTeachers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TeacherId, FirstName, LastName, Email, Gender, Phone, Address, Subject, HireDate, UserRole FROM Teachers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTeachers.DataSource = dt;
            }
        }

        private void ClearFields()
        {
            txtTeacherId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            comboGender.SelectedIndex = -1;
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSubject.Text = "";
            dtpHireDate.Value = DateTime.Now;

            // Reset UserRole to default "Teacher"
            comboUserRole.SelectedItem = "Teacher";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter at least First Name and Last Name.");
                return;
            }
            if (comboUserRole.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user role.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Teachers (FirstName, LastName, Email, Gender, Phone, Address, Subject, HireDate, UserRole)
                                 VALUES (@FirstName, @LastName, @Email, @Gender, @Phone, @Address, @Subject, @HireDate, @UserRole)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@HireDate", dtpHireDate.Value.Date);
                cmd.Parameters.AddWithValue("@UserRole", comboUserRole.SelectedItem.ToString());

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error adding teacher: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            LoadTeachers();
            ClearFields();
            MessageBox.Show("Teacher added successfully.");
        }

        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTeachers.Rows[e.RowIndex];
                txtTeacherId.Text = row.Cells["TeacherId"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                comboGender.SelectedItem = row.Cells["Gender"].Value?.ToString() ?? null;
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtSubject.Text = row.Cells["Subject"].Value.ToString();
                dtpHireDate.Value = row.Cells["HireDate"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["HireDate"].Value) : DateTime.Now;
                comboUserRole.SelectedItem = row.Cells["UserRole"].Value?.ToString() ?? "Teacher";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTeacherId.Text))
            {
                MessageBox.Show("Please select a teacher to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter at least First Name and Last Name.");
                return;
            }
            if (comboUserRole.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user role.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Teachers SET
                                 FirstName=@FirstName, LastName=@LastName, Email=@Email,
                                 Gender=@Gender, Phone=@Phone, Address=@Address,
                                 Subject=@Subject, HireDate=@HireDate, UserRole=@UserRole
                                 WHERE TeacherId=@TeacherId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@HireDate", dtpHireDate.Value.Date);
                cmd.Parameters.AddWithValue("@UserRole", comboUserRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@TeacherId", Convert.ToInt32(txtTeacherId.Text));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error updating teacher: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            LoadTeachers();
            ClearFields();
            MessageBox.Show("Teacher updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTeacherId.Text))
            {
                MessageBox.Show("Please select a teacher to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this teacher?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Teachers WHERE TeacherId=@TeacherId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TeacherId", Convert.ToInt32(txtTeacherId.Text));

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting teacher: " + ex.Message);
                        return;
                    }
                    conn.Close();
                }
                LoadTeachers();
                ClearFields();
                MessageBox.Show("Teacher deleted successfully.");
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

        private void dgvTeachers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
