using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Subjects : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Subjects()
        {
            InitializeComponent();
            LoadTeachersForCombo();
            LoadSubjects();
        }

        private void LoadTeachersForCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TeacherId, FirstName + ' ' + LastName AS FullName FROM Teachers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboTeacher.DisplayMember = "FullName";
                comboTeacher.ValueMember = "TeacherId";
                comboTeacher.DataSource = dt;
                comboTeacher.SelectedIndex = -1; // no default selection
            }
        }

        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SubjectId, SubjectName, Category, TeacherId, Description,
                           (SELECT FirstName + ' ' + LastName FROM Teachers WHERE TeacherId = Subjects.TeacherId) AS TeacherName
                    FROM Subjects";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvSubjects.DataSource = dt;

                // Optionally hide TeacherId column and show TeacherName instead
                if (dgvSubjects.Columns["TeacherId"] != null)
                    dgvSubjects.Columns["TeacherId"].Visible = false;

                if (dgvSubjects.Columns["TeacherName"] != null)
                    dgvSubjects.Columns["TeacherName"].HeaderText = "Teacher";
            }
        }

        private void ClearFields()
        {
            txtSubjectId.Text = "";
            txtSubjectName.Text = "";
            comboCategory.SelectedIndex = -1;
            comboTeacher.SelectedIndex = -1;
            txtDescription.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO Subjects (SubjectName, Category, TeacherId, Description)
                    VALUES (@SubjectName, @Category, @TeacherId, @Description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", comboCategory.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@TeacherId", comboTeacher.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding subject: " + ex.Message);
                    return;
                }
                conn.Close();
            }

            LoadSubjects();
            ClearFields();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Please enter the subject name.");
                return false;
            }
            if (comboCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a category.");
                return false;
            }
            if (comboTeacher.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a teacher.");
                return false;
            }
            return true;
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSubjects.Rows[e.RowIndex];
            txtSubjectId.Text = row.Cells["SubjectId"].Value.ToString();
            txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
            comboCategory.SelectedItem = row.Cells["Category"].Value.ToString();

            // TeacherId can be null, so handle that:
            if (row.Cells["TeacherId"].Value != DBNull.Value)
            {
                int teacherId = Convert.ToInt32(row.Cells["TeacherId"].Value);
                comboTeacher.SelectedValue = teacherId;
            }
            else
            {
                comboTeacher.SelectedIndex = -1;
            }

            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectId.Text))
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            if (!ValidateInput())
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Subjects SET 
                        SubjectName=@SubjectName, 
                        Category=@Category, 
                        TeacherId=@TeacherId, 
                        Description=@Description
                    WHERE SubjectId=@SubjectId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", comboCategory.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@TeacherId", comboTeacher.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@SubjectId", Convert.ToInt32(txtSubjectId.Text));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating subject: " + ex.Message);
                    return;
                }
                conn.Close();
            }

            LoadSubjects();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubjectId.Text))
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Subjects WHERE SubjectId=@SubjectId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectId", Convert.ToInt32(txtSubjectId.Text));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting subject: " + ex.Message);
                    return;
                }
                conn.Close();
            }

            LoadSubjects();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Example: close current form, or open main form
            this.Close();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {

        }
    }
}
