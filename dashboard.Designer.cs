namespace student_management_system
{
    partial class dashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTopbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTotalStudents;
        private System.Windows.Forms.Label lblTotalStudentsCount;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.GroupBox groupBoxTotalSubjects;
        private System.Windows.Forms.Label lblTotalSubjectsCount;
        private System.Windows.Forms.GroupBox groupBoxTotalAttendance;
        private System.Windows.Forms.Label lblTotalAttendanceCount;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.DataGridView dgvTimetable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnChat;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTopbar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChat = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTotalStudents = new System.Windows.Forms.GroupBox();
            this.lblTotalStudentsCount = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.groupBoxTotalSubjects = new System.Windows.Forms.GroupBox();
            this.lblTotalSubjectsCount = new System.Windows.Forms.Label();
            this.groupBoxTotalAttendance = new System.Windows.Forms.GroupBox();
            this.lblTotalAttendanceCount = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dgvTimetable = new System.Windows.Forms.DataGridView();
            this.panelSidebar.SuspendLayout();
            this.panelTopbar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxTotalStudents.SuspendLayout();
            this.groupBoxTotalSubjects.SuspendLayout();
            this.groupBoxTotalAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelSidebar.Controls.Add(this.label13);
            this.panelSidebar.Controls.Add(this.label12);
            this.panelSidebar.Controls.Add(this.label11);
            this.panelSidebar.Controls.Add(this.label10);
            this.panelSidebar.Controls.Add(this.label9);
            this.panelSidebar.Controls.Add(this.label8);
            this.panelSidebar.Controls.Add(this.label7);
            this.panelSidebar.Controls.Add(this.label6);
            this.panelSidebar.Controls.Add(this.label5);
            this.panelSidebar.Controls.Add(this.label4);
            this.panelSidebar.Controls.Add(this.label3);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.panelSidebar.Size = new System.Drawing.Size(225, 456);
            this.panelSidebar.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(35, 336);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 23);
            this.label13.TabIndex = 18;
            this.label13.Text = "Time Table";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(38, 365);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 23);
            this.label12.TabIndex = 17;
            this.label12.Text = "Reports";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(37, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 23);
            this.label11.TabIndex = 16;
            this.label11.Text = "Rewards";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(38, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 23);
            this.label10.TabIndex = 15;
            this.label10.Text = "Clubs";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(37, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Marks";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(39, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Subjects";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Teachers";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(38, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Parents";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(38, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Attendance";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(38, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Students";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dashboard";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panelTopbar
            // 
            this.panelTopbar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTopbar.Controls.Add(this.label2);
            this.panelTopbar.Controls.Add(this.btnChat);
            this.panelTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopbar.Location = new System.Drawing.Point(225, 0);
            this.panelTopbar.Name = "panelTopbar";
            this.panelTopbar.Padding = new System.Windows.Forms.Padding(10);
            this.panelTopbar.Size = new System.Drawing.Size(758, 63);
            this.panelTopbar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(189, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Student Management System";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.LightGray;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Location = new System.Drawing.Point(668, 11);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(73, 40);
            this.btnChat.TabIndex = 0;
            this.btnChat.Text = "Email";
            this.btnChat.UseVisualStyleBackColor = false;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.groupBoxTotalStudents);
            this.panelMain.Controls.Add(this.monthCalendar);
            this.panelMain.Controls.Add(this.groupBoxTotalSubjects);
            this.panelMain.Controls.Add(this.groupBoxTotalAttendance);
            this.panelMain.Controls.Add(this.lblDateTime);
            this.panelMain.Controls.Add(this.dgvTimetable);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(225, 63);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(758, 393);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(484, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Calendar";
            // 
            // groupBoxTotalStudents
            // 
            this.groupBoxTotalStudents.Controls.Add(this.lblTotalStudentsCount);
            this.groupBoxTotalStudents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTotalStudents.Location = new System.Drawing.Point(25, 20);
            this.groupBoxTotalStudents.Name = "groupBoxTotalStudents";
            this.groupBoxTotalStudents.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTotalStudents.TabIndex = 0;
            this.groupBoxTotalStudents.TabStop = false;
            this.groupBoxTotalStudents.Text = "Total Students";
            // 
            // lblTotalStudentsCount
            // 
            this.lblTotalStudentsCount.AutoSize = true;
            this.lblTotalStudentsCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudentsCount.Location = new System.Drawing.Point(20, 40);
            this.lblTotalStudentsCount.Name = "lblTotalStudentsCount";
            this.lblTotalStudentsCount.Size = new System.Drawing.Size(35, 41);
            this.lblTotalStudentsCount.TabIndex = 0;
            this.lblTotalStudentsCount.Text = "0";
            this.lblTotalStudentsCount.Click += new System.EventHandler(this.lblTotalStudentsCount_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(482, 177);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 3;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // groupBoxTotalSubjects
            // 
            this.groupBoxTotalSubjects.Controls.Add(this.lblTotalSubjectsCount);
            this.groupBoxTotalSubjects.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTotalSubjects.Location = new System.Drawing.Point(284, 20);
            this.groupBoxTotalSubjects.Name = "groupBoxTotalSubjects";
            this.groupBoxTotalSubjects.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTotalSubjects.TabIndex = 1;
            this.groupBoxTotalSubjects.TabStop = false;
            this.groupBoxTotalSubjects.Text = "Total Subjects";
            // 
            // lblTotalSubjectsCount
            // 
            this.lblTotalSubjectsCount.AutoSize = true;
            this.lblTotalSubjectsCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalSubjectsCount.Location = new System.Drawing.Point(20, 40);
            this.lblTotalSubjectsCount.Name = "lblTotalSubjectsCount";
            this.lblTotalSubjectsCount.Size = new System.Drawing.Size(35, 41);
            this.lblTotalSubjectsCount.TabIndex = 0;
            this.lblTotalSubjectsCount.Text = "0";
            this.lblTotalSubjectsCount.Click += new System.EventHandler(this.lblTotalSubjectsCount_Click);
            // 
            // groupBoxTotalAttendance
            // 
            this.groupBoxTotalAttendance.Controls.Add(this.lblTotalAttendanceCount);
            this.groupBoxTotalAttendance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxTotalAttendance.Location = new System.Drawing.Point(540, 20);
            this.groupBoxTotalAttendance.Name = "groupBoxTotalAttendance";
            this.groupBoxTotalAttendance.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTotalAttendance.TabIndex = 2;
            this.groupBoxTotalAttendance.TabStop = false;
            this.groupBoxTotalAttendance.Text = "Total Attendance";
            // 
            // lblTotalAttendanceCount
            // 
            this.lblTotalAttendanceCount.AutoSize = true;
            this.lblTotalAttendanceCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalAttendanceCount.Location = new System.Drawing.Point(20, 40);
            this.lblTotalAttendanceCount.Name = "lblTotalAttendanceCount";
            this.lblTotalAttendanceCount.Size = new System.Drawing.Size(35, 41);
            this.lblTotalAttendanceCount.TabIndex = 0;
            this.lblTotalAttendanceCount.Text = "0";
            this.lblTotalAttendanceCount.Click += new System.EventHandler(this.lblTotalAttendanceCount_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.Location = new System.Drawing.Point(23, 140);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(98, 23);
            this.lblDateTime.TabIndex = 4;
            this.lblDateTime.Text = "Time Table";
            // 
            // dgvTimetable
            // 
            this.dgvTimetable.AllowUserToAddRows = false;
            this.dgvTimetable.AllowUserToDeleteRows = false;
            this.dgvTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetable.Location = new System.Drawing.Point(23, 175);
            this.dgvTimetable.Name = "dgvTimetable";
            this.dgvTimetable.ReadOnly = true;
            this.dgvTimetable.RowHeadersVisible = false;
            this.dgvTimetable.RowHeadersWidth = 51;
            this.dgvTimetable.Size = new System.Drawing.Size(447, 207);
            this.dgvTimetable.TabIndex = 5;
            this.dgvTimetable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimetable_CellContentClick);
            // 
            // dashboard
            // 
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(983, 456);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTopbar);
            this.Controls.Add(this.panelSidebar);
            this.Name = "dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Management Dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelTopbar.ResumeLayout(false);
            this.panelTopbar.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxTotalStudents.ResumeLayout(false);
            this.groupBoxTotalStudents.PerformLayout();
            this.groupBoxTotalSubjects.ResumeLayout(false);
            this.groupBoxTotalSubjects.PerformLayout();
            this.groupBoxTotalAttendance.ResumeLayout(false);
            this.groupBoxTotalAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
