namespace student_management_system
{
    partial class Attendance
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAttend;
        private System.Windows.Forms.Button btnNotAttend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance));
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnAttend = new System.Windows.Forms.Button();
            this.btnNotAttend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeight = 29;
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(600, 350);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            // 
            // btnAttend
            // 
            this.btnAttend.BackColor = System.Drawing.Color.LightGreen;
            this.btnAttend.Location = new System.Drawing.Point(630, 50);
            this.btnAttend.Name = "btnAttend";
            this.btnAttend.Size = new System.Drawing.Size(120, 40);
            this.btnAttend.TabIndex = 1;
            this.btnAttend.Text = "Attend";
            this.btnAttend.UseVisualStyleBackColor = false;
            this.btnAttend.Click += new System.EventHandler(this.btnAttend_Click);
            // 
            // btnNotAttend
            // 
            this.btnNotAttend.BackColor = System.Drawing.Color.Red;
            this.btnNotAttend.Location = new System.Drawing.Point(630, 96);
            this.btnNotAttend.Name = "btnNotAttend";
            this.btnNotAttend.Size = new System.Drawing.Size(120, 40);
            this.btnNotAttend.TabIndex = 2;
            this.btnNotAttend.Text = "Not Attend";
            this.btnNotAttend.UseVisualStyleBackColor = false;
            this.btnNotAttend.Click += new System.EventHandler(this.btnNotAttend_Click);
            // 
            // Attendance
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(770, 380);
            this.Controls.Add(this.btnNotAttend);
            this.Controls.Add(this.btnAttend);
            this.Controls.Add(this.dgvStudents);
            this.Name = "Attendance";
            this.Text = "Attendance Management";
            this.Load += new System.EventHandler(this.Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
