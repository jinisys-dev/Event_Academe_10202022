namespace Jinisys.Hotel.Cashier.Presentation
{
	partial class BrowseDriverUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtgDrivers = new System.Windows.Forms.DataGridView();
            this.colDriverId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLicenseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSearchCriteria = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(560, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(490, 507);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 33);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(63, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(16, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 17);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Search";
            // 
            // dtgDrivers
            // 
            this.dtgDrivers.AllowUserToAddRows = false;
            this.dtgDrivers.AllowUserToDeleteRows = false;
            this.dtgDrivers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgDrivers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDriverId,
            this.colLicenseNumber,
            this.colLastName,
            this.colFirstName,
            this.colCommission});
            this.dtgDrivers.Location = new System.Drawing.Point(17, 65);
            this.dtgDrivers.MultiSelect = false;
            this.dtgDrivers.Name = "dtgDrivers";
            this.dtgDrivers.ReadOnly = true;
            this.dtgDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDrivers.Size = new System.Drawing.Size(609, 429);
            this.dtgDrivers.TabIndex = 3;
            this.dtgDrivers.DoubleClick += new System.EventHandler(this.dtgDrivers_DoubleClick);
            this.dtgDrivers.SelectionChanged += new System.EventHandler(this.dtgDrivers_SelectionChanged);
            this.dtgDrivers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgDrivers_KeyPress);
            // 
            // colDriverId
            // 
            this.colDriverId.Frozen = true;
            this.colDriverId.HeaderText = "Driver Id";
            this.colDriverId.Name = "colDriverId";
            this.colDriverId.ReadOnly = true;
            // 
            // colLicenseNumber
            // 
            this.colLicenseNumber.HeaderText = "License No.";
            this.colLicenseNumber.Name = "colLicenseNumber";
            this.colLicenseNumber.ReadOnly = true;
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "Last Name";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            // 
            // colFirstName
            // 
            this.colFirstName.HeaderText = "First Name";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colCommission
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colCommission.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCommission.HeaderText = "Total Commission";
            this.colCommission.Name = "colCommission";
            this.colCommission.ReadOnly = true;
            this.colCommission.Width = 150;
            // 
            // cboSearchCriteria
            // 
            this.cboSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchCriteria.FormattingEnabled = true;
            this.cboSearchCriteria.Items.AddRange(new object[] {
            "Driver Id",
            "License No.",
            "Last Name",
            "First Name"});
            this.cboSearchCriteria.Location = new System.Drawing.Point(414, 28);
            this.cboSearchCriteria.Name = "cboSearchCriteria";
            this.cboSearchCriteria.Size = new System.Drawing.Size(142, 22);
            this.cboSearchCriteria.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(568, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // BrowseDriverUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(643, 553);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboSearchCriteria);
            this.Controls.Add(this.dtgDrivers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BrowseDriverUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Driver";
            this.Load += new System.EventHandler(this.BrowseDriverUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.Label Label1;
		private System.Windows.Forms.DataGridView dtgDrivers;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDriverId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLicenseNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCommission;
		private System.Windows.Forms.ComboBox cboSearchCriteria;
		internal System.Windows.Forms.Button btnSearch;
	}
}