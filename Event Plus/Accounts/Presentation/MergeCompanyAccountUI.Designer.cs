namespace Jinisys.Hotel.Accounts.Presentation
{
	partial class MergeCompanyAccountUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeCompanyAccountUI));
this.grdAccounts = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnCancel = new System.Windows.Forms.Button();
this.btnMerge = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.groupBox2 = new System.Windows.Forms.GroupBox();
this.groupBox1 = new System.Windows.Forms.GroupBox();
this.Label7 = new System.Windows.Forms.Label();
this.txtCompanyId = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.txtCompanyName = new System.Windows.Forms.TextBox();
this.Label43 = new System.Windows.Forms.Label();
this.txtCompanyCode = new System.Windows.Forms.TextBox();
((System.ComponentModel.ISupportInitialize)(this.grdAccounts)).BeginInit();
this.groupBox2.SuspendLayout();
this.groupBox1.SuspendLayout();
this.SuspendLayout();
// 
// grdAccounts
// 
this.grdAccounts.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdAccounts.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.grdAccounts.BackColorSel = System.Drawing.SystemColors.Info;
this.grdAccounts.Cols = 6;
this.grdAccounts.ColumnInfo = resources.GetString("grdAccounts.ColumnInfo");
this.grdAccounts.ExtendLastCol = true;
this.grdAccounts.FixedCols = 0;
this.grdAccounts.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdAccounts.ForeColorSel = System.Drawing.Color.Black;
this.grdAccounts.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdAccounts.Location = new System.Drawing.Point(6, 24);
this.grdAccounts.Name = "grdAccounts";
this.grdAccounts.NodeClosedPicture = null;
this.grdAccounts.NodeOpenPicture = null;
this.grdAccounts.OutlineCol = -1;
this.grdAccounts.Rows = 9;
this.grdAccounts.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdAccounts.Size = new System.Drawing.Size(567, 247);
this.grdAccounts.StyleInfo = resources.GetString("grdAccounts.StyleInfo");
this.grdAccounts.TabIndex = 6;
this.grdAccounts.TreeColor = System.Drawing.Color.DarkGray;
this.grdAccounts.Click += new System.EventHandler(this.grdGuest_Click);
this.grdAccounts.DoubleClick += new System.EventHandler(this.grdGuest_DoubleClick);
// 
// btnCancel
// 
this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnCancel.Location = new System.Drawing.Point(450, 475);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 14;
this.btnCancel.Text = "&Cancel";
this.btnCancel.UseVisualStyleBackColor = true;
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// btnMerge
// 
this.btnMerge.Location = new System.Drawing.Point(378, 475);
this.btnMerge.Name = "btnMerge";
this.btnMerge.Size = new System.Drawing.Size(66, 31);
this.btnMerge.TabIndex = 12;
this.btnMerge.Text = "&Merge";
this.btnMerge.UseVisualStyleBackColor = true;
this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Location = new System.Drawing.Point(522, 475);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 13;
this.btnClose.Text = "Cl&ose";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// groupBox2
// 
this.groupBox2.Controls.Add(this.grdAccounts);
this.groupBox2.Location = new System.Drawing.Point(9, 181);
this.groupBox2.Name = "groupBox2";
this.groupBox2.Size = new System.Drawing.Size(579, 281);
this.groupBox2.TabIndex = 11;
this.groupBox2.TabStop = false;
this.groupBox2.Text = "Accounts to be deleted (Please put a check mark)";
// 
// groupBox1
// 
this.groupBox1.Controls.Add(this.Label7);
this.groupBox1.Controls.Add(this.txtCompanyId);
this.groupBox1.Controls.Add(this.Label2);
this.groupBox1.Controls.Add(this.txtCompanyName);
this.groupBox1.Controls.Add(this.Label43);
this.groupBox1.Controls.Add(this.txtCompanyCode);
this.groupBox1.Location = new System.Drawing.Point(9, 10);
this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new System.Drawing.Size(579, 161);
this.groupBox1.TabIndex = 10;
this.groupBox1.TabStop = false;
this.groupBox1.Text = "Account to Retain :                (Please select an account below and double-cli" +
    "ck)";
// 
// Label7
// 
this.Label7.BackColor = System.Drawing.Color.Transparent;
this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label7.ForeColor = System.Drawing.Color.Black;
this.Label7.Location = new System.Drawing.Point(28, 114);
this.Label7.Name = "Label7";
this.Label7.Size = new System.Drawing.Size(111, 16);
this.Label7.TabIndex = 142;
this.Label7.Text = "Company Name";
// 
// txtCompanyId
// 
this.txtCompanyId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
this.txtCompanyId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtCompanyId.BackColor = System.Drawing.SystemColors.Info;
this.txtCompanyId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyId.Location = new System.Drawing.Point(28, 42);
this.txtCompanyId.MaxLength = 10;
this.txtCompanyId.Name = "txtCompanyId";
this.txtCompanyId.ReadOnly = true;
this.txtCompanyId.Size = new System.Drawing.Size(140, 20);
this.txtCompanyId.TabIndex = 1;
// 
// Label2
// 
this.Label2.BackColor = System.Drawing.Color.Transparent;
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.ForeColor = System.Drawing.Color.Black;
this.Label2.Location = new System.Drawing.Point(28, 65);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(139, 17);
this.Label2.TabIndex = 141;
this.Label2.Text = "Company Code";
// 
// txtCompanyName
// 
this.txtCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
this.txtCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtCompanyName.BackColor = System.Drawing.SystemColors.Info;
this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCompanyName.Location = new System.Drawing.Point(28, 131);
this.txtCompanyName.MaxLength = 30;
this.txtCompanyName.Name = "txtCompanyName";
this.txtCompanyName.ReadOnly = true;
this.txtCompanyName.Size = new System.Drawing.Size(528, 20);
this.txtCompanyName.TabIndex = 3;
// 
// Label43
// 
this.Label43.Location = new System.Drawing.Point(28, 25);
this.Label43.Name = "Label43";
this.Label43.Size = new System.Drawing.Size(72, 14);
this.Label43.TabIndex = 140;
this.Label43.Text = "Company Id";
// 
// txtCompanyCode
// 
this.txtCompanyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
this.txtCompanyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtCompanyCode.BackColor = System.Drawing.SystemColors.Info;
this.txtCompanyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCompanyCode.Location = new System.Drawing.Point(28, 83);
this.txtCompanyCode.MaxLength = 30;
this.txtCompanyCode.Name = "txtCompanyCode";
this.txtCompanyCode.ReadOnly = true;
this.txtCompanyCode.Size = new System.Drawing.Size(235, 20);
this.txtCompanyCode.TabIndex = 2;
// 
// MergeCompanyAccountUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(596, 520);
this.Controls.Add(this.btnCancel);
this.Controls.Add(this.btnMerge);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.groupBox2);
this.Controls.Add(this.groupBox1);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "MergeCompanyAccountUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Merge Company Account";
this.Load += new System.EventHandler(this.MergeCompanyAccountUI_Load);
((System.ComponentModel.ISupportInitialize)(this.grdAccounts)).EndInit();
this.groupBox2.ResumeLayout(false);
this.groupBox1.ResumeLayout(false);
this.groupBox1.PerformLayout();
this.ResumeLayout(false);

		}

		#endregion

		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdAccounts;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnMerge;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.TextBox txtCompanyId;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.TextBox txtCompanyName;
		public System.Windows.Forms.Label Label43;
		public System.Windows.Forms.TextBox txtCompanyCode;
	}
}