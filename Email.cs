using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Email : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30";

        public Email()
        {
            InitializeComponent();
            LoadSentEmails();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string recipientEmail = txtRecipient.Text;
            string subject = txtSubject.Text;
            string message = txtMessage.Text;
            string subjectType = cmbSubjectType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(recipientEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            // Send the email
            SendEmail(recipientEmail, subject, message);

            // Save sent email to database
            SaveSentEmail(recipientEmail, subject, message);
        }

        private void SendEmail(string recipientEmail, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage("dhanukanuwan2001@gmail.com", recipientEmail);
                mail.Subject = subject;
                mail.Body = message;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("dhanukanuwan2001@gmail.com", "cjby bjva xccl ncjl"),
                    EnableSsl = true,
                };

                smtpClient.Send(mail);
                MessageBox.Show("Email Sent Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }

        private void SaveSentEmail(string recipientEmail, string subject, string message)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SentEmails (RecipientEmail, Subject, Message) VALUES (@RecipientEmail, @Subject, @Message)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RecipientEmail", recipientEmail);
                cmd.Parameters.AddWithValue("@Subject", subject);
                cmd.Parameters.AddWithValue("@Message", message);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadSentEmails(); // Refresh sent emails grid
            }
        }

        private void LoadSentEmails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EmailId, RecipientEmail, Subject, DateSent FROM SentEmails";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvSentEmails.DataSource = dt;
            }
        }
    }
}
