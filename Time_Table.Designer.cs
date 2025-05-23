namespace student_management_system
{
    partial class Time_Table
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTimeTable;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvTimeTable = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimeTable
            // 
            this.dgvTimeTable.AllowUserToAddRows = false;
            this.dgvTimeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeTable.Location = new System.Drawing.Point(12, 12);
            this.dgvTimeTable.Name = "dgvTimeTable";
            this.dgvTimeTable.RowHeadersWidth = 60;
            this.dgvTimeTable.RowTemplate.Height = 28;
            this.dgvTimeTable.Size = new System.Drawing.Size(760, 320);
            this.dgvTimeTable.TabIndex = 0;
            this.dgvTimeTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeTable_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(799, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Timetable";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(799, 108);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 40);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load Timetable";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Time_Table
            // 
            this.ClientSize = new System.Drawing.Size(940, 350);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvTimeTable);
            this.Name = "Time_Table";
            this.Text = "School Timetable";
            this.Load += new System.EventHandler(this.TimeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
