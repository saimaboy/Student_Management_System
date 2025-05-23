namespace student_management_system
{
    partial class Email
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.ComboBox cmbSubjectType;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridView dgvSentEmails;
        private System.Windows.Forms.Label lblRecipient;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblSubjectType;
        private System.Windows.Forms.Label lblSentEmails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cmbSubjectType = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.dgvSentEmails = new System.Windows.Forms.DataGridView();
            this.lblRecipient = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblSubjectType = new System.Windows.Forms.Label();
            this.lblSentEmails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSentEmails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(150, 30);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(300, 22);
            this.txtRecipient.TabIndex = 0;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(150, 70);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(300, 22);
            this.txtSubject.TabIndex = 1;
            // 
            // cmbSubjectType
            // 
            this.cmbSubjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjectType.FormattingEnabled = true;
            this.cmbSubjectType.Items.AddRange(new object[] {
            "Event",
            "Meeting",
            "Emergency",
            "Other"});
            this.cmbSubjectType.Location = new System.Drawing.Point(150, 110);
            this.cmbSubjectType.Name = "cmbSubjectType";
            this.cmbSubjectType.Size = new System.Drawing.Size(300, 24);
            this.cmbSubjectType.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(150, 150);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(300, 100);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(150, 270);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 40);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // dgvSentEmails
            // 
            this.dgvSentEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSentEmails.Location = new System.Drawing.Point(30, 320);
            this.dgvSentEmails.Name = "dgvSentEmails";
            this.dgvSentEmails.RowHeadersWidth = 51;
            this.dgvSentEmails.RowTemplate.Height = 28;
            this.dgvSentEmails.Size = new System.Drawing.Size(600, 200);
            this.dgvSentEmails.TabIndex = 5;
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Location = new System.Drawing.Point(30, 30);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(104, 16);
            this.lblRecipient.TabIndex = 6;
            this.lblRecipient.Text = "Recipient Email:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(30, 70);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(55, 16);
            this.lblSubject.TabIndex = 7;
            this.lblSubject.Text = "Subject:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(30, 150);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(67, 16);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.Text = "Message:";
            // 
            // lblSubjectType
            // 
            this.lblSubjectType.AutoSize = true;
            this.lblSubjectType.Location = new System.Drawing.Point(30, 110);
            this.lblSubjectType.Name = "lblSubjectType";
            this.lblSubjectType.Size = new System.Drawing.Size(90, 16);
            this.lblSubjectType.TabIndex = 9;
            this.lblSubjectType.Text = "Subject Type:";
            // 
            // lblSentEmails
            // 
            this.lblSentEmails.AutoSize = true;
            this.lblSentEmails.Location = new System.Drawing.Point(30, 290);
            this.lblSentEmails.Name = "lblSentEmails";
            this.lblSentEmails.Size = new System.Drawing.Size(111, 16);
            this.lblSentEmails.TabIndex = 10;
            this.lblSentEmails.Text = "Past Sent Emails:";
            // 
            // Email
            // 
            this.ClientSize = new System.Drawing.Size(650, 550);
            this.Controls.Add(this.lblSentEmails);
            this.Controls.Add(this.lblSubjectType);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblRecipient);
            this.Controls.Add(this.dgvSentEmails);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cmbSubjectType);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtRecipient);
            this.Name = "Email";
            this.Text = "Send Email";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSentEmails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}
