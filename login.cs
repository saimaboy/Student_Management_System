using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class login : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public login()
        {
            InitializeComponent();
        }

        // Validate user by email
        private bool ValidateUser(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Teachers WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int userCount = (int)cmd.ExecuteScalar();
                conn.Close();

                return userCount > 0;
            }
        }

        // Handle Login Button click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;  // Assuming txtEmail is the TextBox for email input

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            // Check login credentials
            if (ValidateUser(email))
            {
                // Determine the role of the user and redirect
                RedirectUserBasedOnRole(email);
            }
            else
            {
                MessageBox.Show("Invalid email.");
            }
        }

        // Redirect based on user role (Admin/Teacher)
        private void RedirectUserBasedOnRole(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserRole FROM Teachers WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    string role = result.ToString();

                    // Redirect based on role
                    if (role == "Admin")
                    {
                        // Redirect to Admin Dashboard
                        dashboard dashboard = new dashboard();
                        dashboard.Show();
                    }
                    else if (role == "Teacher")
                    {
                        // Redirect to Teacher Dashboard
                        Teacher_Dashboard teacherDashboard = new Teacher_Dashboard();
                        teacherDashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unknown role. Please contact the administrator.");
                        return;
                    }

                    this.Hide(); // Hide login form after successful login
                }
                else
                {
                    MessageBox.Show("Role not found for this user.");
                }
            }
        }
    }
}
