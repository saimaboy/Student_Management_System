namespace student_management_system
{
    partial class Clubs
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblClubId;
        private System.Windows.Forms.TextBox txtClubId;

        private System.Windows.Forms.Label lblClubName;
        private System.Windows.Forms.TextBox txtClubName;

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.DataGridView dgvClubs;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clubs));
            this.lblClubId = new System.Windows.Forms.Label();
            this.txtClubId = new System.Windows.Forms.TextBox();
            this.lblClubName = new System.Windows.Forms.Label();
            this.txtClubName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dgvClubs = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClubId
            // 
            this.lblClubId.AutoSize = true;
            this.lblClubId.Location = new System.Drawing.Point(23, 42);
            this.lblClubId.Name = "lblClubId";
            this.lblClubId.Size = new System.Drawing.Size(50, 16);
            this.lblClubId.TabIndex = 0;
            this.lblClubId.Text = "Club ID";
            // 
            // txtClubId
            // 
            this.txtClubId.Location = new System.Drawing.Point(123, 39);
            this.txtClubId.Name = "txtClubId";
            this.txtClubId.ReadOnly = true;
            this.txtClubId.Size = new System.Drawing.Size(200, 22);
            this.txtClubId.TabIndex = 1;
            // 
            // lblClubName
            // 
            this.lblClubName.AutoSize = true;
            this.lblClubName.Location = new System.Drawing.Point(23, 82);
            this.lblClubName.Name = "lblClubName";
            this.lblClubName.Size = new System.Drawing.Size(74, 16);
            this.lblClubName.TabIndex = 2;
            this.lblClubName.Text = "Club Name";
            // 
            // txtClubName
            // 
            this.txtClubName.Location = new System.Drawing.Point(123, 79);
            this.txtClubName.Name = "txtClubName";
            this.txtClubName.Size = new System.Drawing.Size(200, 22);
            this.txtClubName.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 122);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(123, 119);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // dgvClubs
            // 
            this.dgvClubs.AllowUserToAddRows = false;
            this.dgvClubs.AllowUserToDeleteRows = false;
            this.dgvClubs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClubs.Location = new System.Drawing.Point(350, 12);
            this.dgvClubs.Name = "dgvClubs";
            this.dgvClubs.ReadOnly = true;
            this.dgvClubs.RowHeadersWidth = 51;
            this.dgvClubs.RowTemplate.Height = 24;
            this.dgvClubs.Size = new System.Drawing.Size(500, 210);
            this.dgvClubs.TabIndex = 6;
            this.dgvClubs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClubs_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.Location = new System.Drawing.Point(258, 192);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.Location = new System.Drawing.Point(177, 192);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(96, 192);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Yellow;
            this.btnClear.Location = new System.Drawing.Point(15, 192);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Clubs
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(870, 243);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvClubs);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtClubName);
            this.Controls.Add(this.lblClubName);
            this.Controls.Add(this.txtClubId);
            this.Controls.Add(this.lblClubId);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Clubs";
            this.Text = "Club Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
