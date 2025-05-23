namespace student_management_system
{
    partial class Reports
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAttendanceReport;
        private System.Windows.Forms.Button btnMarksReport;
        private System.Windows.Forms.Button btnParentsReport;
        private System.Windows.Forms.Button btnStudentsReport;
        private System.Windows.Forms.Button btnRewardsReport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnAttendanceReport = new System.Windows.Forms.Button();
            this.btnMarksReport = new System.Windows.Forms.Button();
            this.btnParentsReport = new System.Windows.Forms.Button();
            this.btnStudentsReport = new System.Windows.Forms.Button();
            this.btnRewardsReport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();

            this.SuspendLayout();

            // 
            // btnAttendanceReport
            // 
            this.btnAttendanceReport.Location = new System.Drawing.Point(40, 30);
            this.btnAttendanceReport.Name = "btnAttendanceReport";
            this.btnAttendanceReport.Size = new System.Drawing.Size(200, 40);
            this.btnAttendanceReport.TabIndex = 0;
            this.btnAttendanceReport.Text = "Export Attendance Report";
            this.btnAttendanceReport.UseVisualStyleBackColor = true;
            this.btnAttendanceReport.Click += new System.EventHandler(this.btnAttendanceReport_Click);

            // 
            // btnMarksReport
            // 
            this.btnMarksReport.Location = new System.Drawing.Point(40, 90);
            this.btnMarksReport.Name = "btnMarksReport";
            this.btnMarksReport.Size = new System.Drawing.Size(200, 40);
            this.btnMarksReport.TabIndex = 1;
            this.btnMarksReport.Text = "Export Full Marks Report";
            this.btnMarksReport.UseVisualStyleBackColor = true;
            this.btnMarksReport.Click += new System.EventHandler(this.btnMarksReport_Click);

            // 
            // btnParentsReport
            // 
            this.btnParentsReport.Location = new System.Drawing.Point(40, 150);
            this.btnParentsReport.Name = "btnParentsReport";
            this.btnParentsReport.Size = new System.Drawing.Size(200, 40);
            this.btnParentsReport.TabIndex = 2;
            this.btnParentsReport.Text = "Export Parents Report";
            this.btnParentsReport.UseVisualStyleBackColor = true;
            this.btnParentsReport.Click += new System.EventHandler(this.btnParentsReport_Click);

            // 
            // btnStudentsReport
            // 
            this.btnStudentsReport.Location = new System.Drawing.Point(40, 210);
            this.btnStudentsReport.Name = "btnStudentsReport";
            this.btnStudentsReport.Size = new System.Drawing.Size(200, 40);
            this.btnStudentsReport.TabIndex = 3;
            this.btnStudentsReport.Text = "Export Students Report";
            this.btnStudentsReport.UseVisualStyleBackColor = true;
            this.btnStudentsReport.Click += new System.EventHandler(this.btnStudentsReport_Click);

            // 
            // btnRewardsReport
            // 
            this.btnRewardsReport.Location = new System.Drawing.Point(40, 270);
            this.btnRewardsReport.Name = "btnRewardsReport";
            this.btnRewardsReport.Size = new System.Drawing.Size(200, 40);
            this.btnRewardsReport.TabIndex = 4;
            this.btnRewardsReport.Text = "Export Rewards Report";
            this.btnRewardsReport.UseVisualStyleBackColor = true;
            this.btnRewardsReport.Click += new System.EventHandler(this.btnRewardsReport_Click);

            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(40, 330);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 40);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // Reports form
            // 
            this.ClientSize = new System.Drawing.Size(280, 400);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRewardsReport);
            this.Controls.Add(this.btnStudentsReport);
            this.Controls.Add(this.btnParentsReport);
            this.Controls.Add(this.btnMarksReport);
            this.Controls.Add(this.btnAttendanceReport);
            this.Name = "Reports";
            this.Text = "Reports Export";

            this.ResumeLayout(false);
        }

        #endregion
    }
}
