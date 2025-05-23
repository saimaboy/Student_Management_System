using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Students : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Students()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentId, FirstName, LastName, Email, Gender, DOB, Address, Grade FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvStudents.DataSource = dt;
            }
        }

        private void ClearFields()
        {
            txtStudentId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            comboGender.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            txtAddress.Text = "";
            txtGrade.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Students (FirstName, LastName, Email, Gender, DOB, Address, Grade)
                                 VALUES (@FirstName, @LastName, @Email, @Gender, @DOB, @Address, @Grade)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Grade", txtGrade.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadStudents();
            ClearFields();
            MessageBox.Show("Student added successfully.");
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtStudentId.Text = row.Cells["StudentId"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                comboGender.SelectedItem = row.Cells["Gender"].Value.ToString();
                dtpDOB.Value = Convert.ToDateTime(row.Cells["DOB"].Value);
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtGrade.Text = row.Cells["Grade"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Students SET
                                 FirstName=@FirstName, LastName=@LastName, Email=@Email, Gender=@Gender,
                                 DOB=@DOB, Address=@Address, Grade=@Grade
                                 WHERE StudentId=@StudentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", comboGender.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Grade", txtGrade.Text.Trim());
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(txtStudentId.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadStudents();
            ClearFields();
            MessageBox.Show("Student updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE StudentId=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(txtStudentId.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                LoadStudents();
                ClearFields();
                MessageBox.Show("Student deleted successfully.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Close();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
