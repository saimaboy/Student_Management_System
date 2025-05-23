namespace student_management_system
{
    partial class Rewards
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblRewardId;
        private System.Windows.Forms.TextBox txtRewardId;

        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;

        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.TextBox txtReward;

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.DateTimePicker dtpDateTime;

        private System.Windows.Forms.DataGridView dgvRewards;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblRewardId = new System.Windows.Forms.Label();
            this.txtRewardId = new System.Windows.Forms.TextBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblReward = new System.Windows.Forms.Label();
            this.txtReward = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.dgvRewards = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRewards)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRewardId
            // 
            this.lblRewardId.AutoSize = true;
            this.lblRewardId.Location = new System.Drawing.Point(20, 50);
            this.lblRewardId.Name = "lblRewardId";
            this.lblRewardId.Size = new System.Drawing.Size(70, 16);
            this.lblRewardId.TabIndex = 0;
            this.lblRewardId.Text = "Reward ID";
            // 
            // txtRewardId
            // 
            this.txtRewardId.Location = new System.Drawing.Point(130, 47);
            this.txtRewardId.Name = "txtRewardId";
            this.txtRewardId.ReadOnly = true;
            this.txtRewardId.Size = new System.Drawing.Size(210, 22);
            this.txtRewardId.TabIndex = 1;
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(20, 90);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(68, 16);
            this.lblStudentId.TabIndex = 2;
            this.lblStudentId.Text = "Student ID";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(130, 87);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(210, 22);
            this.txtStudentId.TabIndex = 3;
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.Location = new System.Drawing.Point(20, 130);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(54, 16);
            this.lblReward.TabIndex = 4;
            this.lblReward.Text = "Reward";
            // 
            // txtReward
            // 
            this.txtReward.Location = new System.Drawing.Point(130, 127);
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(210, 22);
            this.txtReward.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 170);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 167);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(210, 60);
            this.txtDescription.TabIndex = 7;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(20, 240);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(67, 16);
            this.lblDateTime.TabIndex = 8;
            this.lblDateTime.Text = "DateTime";
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTime.Location = new System.Drawing.Point(130, 235);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(210, 22);
            this.dtpDateTime.TabIndex = 9;
            // 
            // dgvRewards
            // 
            this.dgvRewards.AllowUserToAddRows = false;
            this.dgvRewards.AllowUserToDeleteRows = false;
            this.dgvRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRewards.Location = new System.Drawing.Point(360, 10);
            this.dgvRewards.Name = "dgvRewards";
            this.dgvRewards.ReadOnly = true;
            this.dgvRewards.RowHeadersWidth = 51;
            this.dgvRewards.RowTemplate.Height = 24;
            this.dgvRewards.Size = new System.Drawing.Size(600, 420);
            this.dgvRewards.TabIndex = 10;
            this.dgvRewards.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRewards_CellClick);
            this.dgvRewards.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRewards_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(255, 270);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(174, 270);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 270);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Rewards
            // 
            this.ClientSize = new System.Drawing.Size(980, 445);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvRewards);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtReward);
            this.Controls.Add(this.lblReward);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.txtRewardId);
            this.Controls.Add(this.lblRewardId);
            this.Name = "Rewards";
            this.Text = "Reward Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRewards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
