namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	partial class Exact_GLchartOfAccounts
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
		/// 
		private void InitializeComponent()
		{
			this.lvwGLaccounts = new System.Windows.Forms.ListView();
			this.colAccountID = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.colCostCenterCode = new System.Windows.Forms.ColumnHeader();
			this.colAccountNature = new System.Windows.Forms.ColumnHeader();
			this.lblAccountID = new System.Windows.Forms.Label();
			this.txtAccountID = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblCostCenterCode = new System.Windows.Forms.Label();
			this.lblAccountNature = new System.Windows.Forms.Label();
			this.lblStatusFlag = new System.Windows.Forms.Label();
			this.txtStatusFlag = new System.Windows.Forms.TextBox();
			this.lblCreatedDate = new System.Windows.Forms.Label();
			this.txtCreatedDate = new System.Windows.Forms.TextBox();
			this.lblCreatedBy = new System.Windows.Forms.Label();
			this.txtCreatedBy = new System.Windows.Forms.TextBox();
			this.lblUpdatedDate = new System.Windows.Forms.Label();
			this.txtUpdatedDate = new System.Windows.Forms.TextBox();
			this.lblUpdatedBy = new System.Windows.Forms.Label();
			this.txtUpdatedBy = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboAccountNature = new System.Windows.Forms.ComboBox();
			this.cboCostCenterCode = new System.Windows.Forms.ComboBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSetActive = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwGLaccounts
			// 
			this.lvwGLaccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAccountID,
            this.colDescription,
            this.colCostCenterCode,
            this.colAccountNature});
			this.lvwGLaccounts.FullRowSelect = true;
			this.lvwGLaccounts.GridLines = true;
			this.lvwGLaccounts.Location = new System.Drawing.Point(6, 25);
			this.lvwGLaccounts.Name = "lvwGLaccounts";
			this.lvwGLaccounts.Size = new System.Drawing.Size(686, 216);
			this.lvwGLaccounts.TabIndex = 18;
			this.lvwGLaccounts.UseCompatibleStateImageBehavior = false;
			this.lvwGLaccounts.View = System.Windows.Forms.View.Details;
			this.lvwGLaccounts.SelectedIndexChanged += new System.EventHandler(this.lvwGLaccounts_SelectedIndexChanged);
			// 
			// colAccountID
			// 
			this.colAccountID.Text = "Account ID";
			this.colAccountID.Width = 80;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 386;
			// 
			// colCostCenterCode
			// 
			this.colCostCenterCode.Text = "Cost Center";
			this.colCostCenterCode.Width = 96;
			// 
			// colAccountNature
			// 
			this.colAccountNature.Text = "Account Nature";
			this.colAccountNature.Width = 101;
			// 
			// lblAccountID
			// 
			this.lblAccountID.AutoSize = true;
			this.lblAccountID.Location = new System.Drawing.Point(18, 27);
			this.lblAccountID.Name = "lblAccountID";
			this.lblAccountID.Size = new System.Drawing.Size(61, 13);
			this.lblAccountID.TabIndex = 1;
			this.lblAccountID.Text = "Account ID";
			// 
			// txtAccountID
			// 
			this.txtAccountID.Location = new System.Drawing.Point(119, 23);
			this.txtAccountID.Name = "txtAccountID";
			this.txtAccountID.Size = new System.Drawing.Size(127, 20);
			this.txtAccountID.TabIndex = 19;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(18, 53);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 3;
			this.lblDescription.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(119, 49);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(391, 20);
			this.txtDescription.TabIndex = 20;
			// 
			// lblCostCenterCode
			// 
			this.lblCostCenterCode.AutoSize = true;
			this.lblCostCenterCode.Location = new System.Drawing.Point(18, 79);
			this.lblCostCenterCode.Name = "lblCostCenterCode";
			this.lblCostCenterCode.Size = new System.Drawing.Size(90, 13);
			this.lblCostCenterCode.TabIndex = 5;
			this.lblCostCenterCode.Text = "Cost Center Code";
			// 
			// lblAccountNature
			// 
			this.lblAccountNature.AutoSize = true;
			this.lblAccountNature.Location = new System.Drawing.Point(314, 27);
			this.lblAccountNature.Name = "lblAccountNature";
			this.lblAccountNature.Size = new System.Drawing.Size(82, 13);
			this.lblAccountNature.TabIndex = 7;
			this.lblAccountNature.Text = "Account Nature";
			// 
			// lblStatusFlag
			// 
			this.lblStatusFlag.AutoSize = true;
			this.lblStatusFlag.Location = new System.Drawing.Point(18, 108);
			this.lblStatusFlag.Name = "lblStatusFlag";
			this.lblStatusFlag.Size = new System.Drawing.Size(60, 13);
			this.lblStatusFlag.TabIndex = 9;
			this.lblStatusFlag.Text = "Status Flag";
			// 
			// txtStatusFlag
			// 
			this.txtStatusFlag.Location = new System.Drawing.Point(119, 104);
			this.txtStatusFlag.Name = "txtStatusFlag";
			this.txtStatusFlag.ReadOnly = true;
			this.txtStatusFlag.Size = new System.Drawing.Size(127, 20);
			this.txtStatusFlag.TabIndex = 23;
			this.txtStatusFlag.TextChanged += new System.EventHandler(this.txtStatusFlag_TextChanged);
			// 
			// lblCreatedDate
			// 
			this.lblCreatedDate.AutoSize = true;
			this.lblCreatedDate.Location = new System.Drawing.Point(18, 134);
			this.lblCreatedDate.Name = "lblCreatedDate";
			this.lblCreatedDate.Size = new System.Drawing.Size(70, 13);
			this.lblCreatedDate.TabIndex = 11;
			this.lblCreatedDate.Text = "Created Date";
			// 
			// txtCreatedDate
			// 
			this.txtCreatedDate.Location = new System.Drawing.Point(119, 130);
			this.txtCreatedDate.Name = "txtCreatedDate";
			this.txtCreatedDate.ReadOnly = true;
			this.txtCreatedDate.Size = new System.Drawing.Size(127, 20);
			this.txtCreatedDate.TabIndex = 24;
			// 
			// lblCreatedBy
			// 
			this.lblCreatedBy.AutoSize = true;
			this.lblCreatedBy.Location = new System.Drawing.Point(18, 160);
			this.lblCreatedBy.Name = "lblCreatedBy";
			this.lblCreatedBy.Size = new System.Drawing.Size(59, 13);
			this.lblCreatedBy.TabIndex = 13;
			this.lblCreatedBy.Text = "Created By";
			// 
			// txtCreatedBy
			// 
			this.txtCreatedBy.Location = new System.Drawing.Point(119, 156);
			this.txtCreatedBy.Name = "txtCreatedBy";
			this.txtCreatedBy.ReadOnly = true;
			this.txtCreatedBy.Size = new System.Drawing.Size(127, 20);
			this.txtCreatedBy.TabIndex = 25;
			// 
			// lblUpdatedDate
			// 
			this.lblUpdatedDate.AutoSize = true;
			this.lblUpdatedDate.Location = new System.Drawing.Point(18, 186);
			this.lblUpdatedDate.Name = "lblUpdatedDate";
			this.lblUpdatedDate.Size = new System.Drawing.Size(74, 13);
			this.lblUpdatedDate.TabIndex = 15;
			this.lblUpdatedDate.Text = "Updated Date";
			// 
			// txtUpdatedDate
			// 
			this.txtUpdatedDate.Location = new System.Drawing.Point(119, 182);
			this.txtUpdatedDate.Name = "txtUpdatedDate";
			this.txtUpdatedDate.ReadOnly = true;
			this.txtUpdatedDate.Size = new System.Drawing.Size(127, 20);
			this.txtUpdatedDate.TabIndex = 26;
			// 
			// lblUpdatedBy
			// 
			this.lblUpdatedBy.AutoSize = true;
			this.lblUpdatedBy.Location = new System.Drawing.Point(18, 212);
			this.lblUpdatedBy.Name = "lblUpdatedBy";
			this.lblUpdatedBy.Size = new System.Drawing.Size(63, 13);
			this.lblUpdatedBy.TabIndex = 17;
			this.lblUpdatedBy.Text = "Updated By";
			// 
			// txtUpdatedBy
			// 
			this.txtUpdatedBy.Location = new System.Drawing.Point(119, 208);
			this.txtUpdatedBy.Name = "txtUpdatedBy";
			this.txtUpdatedBy.ReadOnly = true;
			this.txtUpdatedBy.Size = new System.Drawing.Size(127, 20);
			this.txtUpdatedBy.TabIndex = 27;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvwGLaccounts);
			this.groupBox1.Location = new System.Drawing.Point(20, 238);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(698, 251);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chart Of Accounts";
			// 
			// cboAccountNature
			// 
			this.cboAccountNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAccountNature.FormattingEnabled = true;
			this.cboAccountNature.Items.AddRange(new object[] {
            "DEBIT",
            "CREDIT"});
			this.cboAccountNature.Location = new System.Drawing.Point(402, 23);
			this.cboAccountNature.Name = "cboAccountNature";
			this.cboAccountNature.Size = new System.Drawing.Size(108, 21);
			this.cboAccountNature.TabIndex = 29;
			// 
			// cboCostCenterCode
			// 
			this.cboCostCenterCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCostCenterCode.FormattingEnabled = true;
			this.cboCostCenterCode.Location = new System.Drawing.Point(119, 75);
			this.cboCostCenterCode.Name = "cboCostCenterCode";
			this.cboCostCenterCode.Size = new System.Drawing.Size(127, 21);
			this.cboCostCenterCode.TabIndex = 30;
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(429, 507);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(66, 31);
			this.btnNew.TabIndex = 35;
			this.btnNew.Text = "&New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(504, 507);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 31);
			this.btnSave.TabIndex = 34;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(576, 507);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 31);
			this.btnCancel.TabIndex = 33;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(648, 507);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 32;
			this.btnClose.Text = "Cl&ose";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.Location = new System.Drawing.Point(20, 507);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(66, 31);
			this.btnDelete.TabIndex = 31;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSetActive
			// 
			this.btnSetActive.Location = new System.Drawing.Point(252, 103);
			this.btnSetActive.Name = "btnSetActive";
			this.btnSetActive.Size = new System.Drawing.Size(70, 21);
			this.btnSetActive.TabIndex = 36;
			this.btnSetActive.Text = "Set Active";
			this.btnSetActive.UseVisualStyleBackColor = true;
			this.btnSetActive.Visible = false;
			this.btnSetActive.Click += new System.EventHandler(this.btnSetActive_Click);
			// 
			// GLchartOfAccounts_ExactGlobe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(740, 561);
			this.Controls.Add(this.btnSetActive);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.cboCostCenterCode);
			this.Controls.Add(this.cboAccountNature);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblAccountID);
			this.Controls.Add(this.txtAccountID);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.lblCostCenterCode);
			this.Controls.Add(this.lblAccountNature);
			this.Controls.Add(this.lblStatusFlag);
			this.Controls.Add(this.txtStatusFlag);
			this.Controls.Add(this.lblCreatedDate);
			this.Controls.Add(this.txtCreatedDate);
			this.Controls.Add(this.lblCreatedBy);
			this.Controls.Add(this.txtCreatedBy);
			this.Controls.Add(this.lblUpdatedDate);
			this.Controls.Add(this.txtUpdatedDate);
			this.Controls.Add(this.lblUpdatedBy);
			this.Controls.Add(this.txtUpdatedBy);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GLchartOfAccounts_ExactGlobe";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GL - Chart Of Accounts - ExactGlobe";
			this.TextChanged += new System.EventHandler(this.GLchartOfAccounts_ExactGlobe_TextChanged);
			this.Load += new System.EventHandler(this.GLchartOfAccounts_ExactGlobe_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label lblAccountID;
		private System.Windows.Forms.TextBox txtAccountID;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblCostCenterCode;
		private System.Windows.Forms.Label lblAccountNature;
		private System.Windows.Forms.Label lblStatusFlag;
		private System.Windows.Forms.TextBox txtStatusFlag;
		private System.Windows.Forms.Label lblCreatedDate;
		private System.Windows.Forms.TextBox txtCreatedDate;
		private System.Windows.Forms.Label lblCreatedBy;
		private System.Windows.Forms.TextBox txtCreatedBy;
		private System.Windows.Forms.Label lblUpdatedDate;
		private System.Windows.Forms.TextBox txtUpdatedDate;
		private System.Windows.Forms.Label lblUpdatedBy;
		private System.Windows.Forms.TextBox txtUpdatedBy;
		private System.Windows.Forms.ListView lvwGLaccounts;
		private System.Windows.Forms.ColumnHeader colAccountID;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader colCostCenterCode;
		private System.Windows.Forms.ColumnHeader colAccountNature;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cboAccountNature;
		private System.Windows.Forms.ComboBox cboCostCenterCode;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnSetActive;

		//private void InitializeComponent()
		//{
		//    this.SuspendLayout();
		//    // 
		//    // GLchartOfAccounts_ExactGlobe
		//    // 
		//    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		//    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		//    this.ClientSize = new System.Drawing.Size(615, 443);
		//    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		//    this.MaximizeBox = false;
		//    this.MinimizeBox = false;
		//    this.Name = "GLchartOfAccounts_ExactGlobe";
		//    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		//    this.Text = "GL - Chart Of Accounts - ExactGlobe";
		//    this.ResumeLayout(false);

		//}

		#endregion
	}
}