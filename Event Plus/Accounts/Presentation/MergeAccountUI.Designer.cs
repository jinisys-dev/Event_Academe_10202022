namespace Jinisys.Hotel.Accounts.Presentation
{
	partial class MergeAccountUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeAccountUI));
this.txtCitizenship = new System.Windows.Forms.TextBox();
this.txtAccountId = new System.Windows.Forms.TextBox();
this.txtFirstName = new System.Windows.Forms.TextBox();
this.txtLastName = new System.Windows.Forms.TextBox();
this.Label6 = new System.Windows.Forms.Label();
this.Label43 = new System.Windows.Forms.Label();
this.Label2 = new System.Windows.Forms.Label();
this.Label7 = new System.Windows.Forms.Label();
this.groupBox1 = new System.Windows.Forms.GroupBox();
this.groupBox2 = new System.Windows.Forms.GroupBox();
this.grdGuest = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnClose = new System.Windows.Forms.Button();
this.btnMerge = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.groupBox1.SuspendLayout();
this.groupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdGuest)).BeginInit();
this.SuspendLayout();
// 
// txtCitizenship
// 
this.txtCitizenship.BackColor = System.Drawing.SystemColors.Info;
this.txtCitizenship.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCitizenship.Location = new System.Drawing.Point(327, 87);
this.txtCitizenship.MaxLength = 100;
this.txtCitizenship.Name = "txtCitizenship";
this.txtCitizenship.ReadOnly = true;
this.txtCitizenship.Size = new System.Drawing.Size(141, 20);
this.txtCitizenship.TabIndex = 4;
// 
// txtAccountId
// 
this.txtAccountId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
this.txtAccountId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtAccountId.BackColor = System.Drawing.SystemColors.Info;
this.txtAccountId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAccountId.Location = new System.Drawing.Point(33, 46);
this.txtAccountId.MaxLength = 10;
this.txtAccountId.Name = "txtAccountId";
this.txtAccountId.ReadOnly = true;
this.txtAccountId.Size = new System.Drawing.Size(140, 20);
this.txtAccountId.TabIndex = 1;
// 
// txtFirstName
// 
this.txtFirstName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
this.txtFirstName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtFirstName.BackColor = System.Drawing.SystemColors.Info;
this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtFirstName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtFirstName.Location = new System.Drawing.Point(181, 87);
this.txtFirstName.MaxLength = 30;
this.txtFirstName.Name = "txtFirstName";
this.txtFirstName.ReadOnly = true;
this.txtFirstName.Size = new System.Drawing.Size(140, 20);
this.txtFirstName.TabIndex = 3;
// 
// txtLastName
// 
this.txtLastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
this.txtLastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtLastName.BackColor = System.Drawing.SystemColors.Info;
this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtLastName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtLastName.Location = new System.Drawing.Point(33, 87);
this.txtLastName.MaxLength = 30;
this.txtLastName.Name = "txtLastName";
this.txtLastName.ReadOnly = true;
this.txtLastName.Size = new System.Drawing.Size(140, 20);
this.txtLastName.TabIndex = 2;
// 
// Label6
// 
this.Label6.BackColor = System.Drawing.Color.Transparent;
this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label6.ForeColor = System.Drawing.Color.Black;
this.Label6.Location = new System.Drawing.Point(327, 70);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(62, 14);
this.Label6.TabIndex = 143;
this.Label6.Text = "Citizenship";
// 
// Label43
// 
this.Label43.Location = new System.Drawing.Point(33, 29);
this.Label43.Name = "Label43";
this.Label43.Size = new System.Drawing.Size(64, 14);
this.Label43.TabIndex = 140;
this.Label43.Text = "Account ID";
// 
// Label2
// 
this.Label2.BackColor = System.Drawing.Color.Transparent;
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.ForeColor = System.Drawing.Color.Black;
this.Label2.Location = new System.Drawing.Point(33, 69);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(68, 15);
this.Label2.TabIndex = 141;
this.Label2.Text = "Last Name";
// 
// Label7
// 
this.Label7.BackColor = System.Drawing.Color.Transparent;
this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label7.ForeColor = System.Drawing.Color.Black;
this.Label7.Location = new System.Drawing.Point(178, 70);
this.Label7.Name = "Label7";
this.Label7.Size = new System.Drawing.Size(80, 12);
this.Label7.TabIndex = 142;
this.Label7.Text = "First Name";
// 
// groupBox1
// 
this.groupBox1.Controls.Add(this.txtCitizenship);
this.groupBox1.Controls.Add(this.Label7);
this.groupBox1.Controls.Add(this.txtAccountId);
this.groupBox1.Controls.Add(this.Label2);
this.groupBox1.Controls.Add(this.txtFirstName);
this.groupBox1.Controls.Add(this.Label43);
this.groupBox1.Controls.Add(this.txtLastName);
this.groupBox1.Controls.Add(this.Label6);
this.groupBox1.Location = new System.Drawing.Point(12, 23);
this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new System.Drawing.Size(579, 125);
this.groupBox1.TabIndex = 0;
this.groupBox1.TabStop = false;
this.groupBox1.Text = "Account to Retain :         (Please select from the list below and double-click)";
// 
// groupBox2
// 
this.groupBox2.Controls.Add(this.grdGuest);
this.groupBox2.Location = new System.Drawing.Point(12, 158);
this.groupBox2.Name = "groupBox2";
this.groupBox2.Size = new System.Drawing.Size(579, 304);
this.groupBox2.TabIndex = 5;
this.groupBox2.TabStop = false;
this.groupBox2.Text = "Accounts to be deleted (Please put a check mark)";
// 
// grdGuest
// 
this.grdGuest.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdGuest.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.grdGuest.BackColorSel = System.Drawing.SystemColors.Info;
this.grdGuest.Cols = 7;
this.grdGuest.ColumnInfo = resources.GetString("grdGuest.ColumnInfo");
this.grdGuest.ExtendLastCol = true;
this.grdGuest.FixedCols = 0;
this.grdGuest.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdGuest.ForeColorSel = System.Drawing.Color.Black;
this.grdGuest.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdGuest.Location = new System.Drawing.Point(6, 24);
this.grdGuest.Name = "grdGuest";
this.grdGuest.NodeClosedPicture = null;
this.grdGuest.NodeOpenPicture = null;
this.grdGuest.OutlineCol = -1;
this.grdGuest.Rows = 9;
this.grdGuest.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdGuest.Size = new System.Drawing.Size(567, 271);
this.grdGuest.StyleInfo = resources.GetString("grdGuest.StyleInfo");
this.grdGuest.TabIndex = 6;
this.grdGuest.TreeColor = System.Drawing.Color.DarkGray;
this.grdGuest.Click += new System.EventHandler(this.grdGuest_Click);
this.grdGuest.DoubleClick += new System.EventHandler(this.grdGuest_DoubleClick);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Location = new System.Drawing.Point(525, 475);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 8;
this.btnClose.Text = "Cl&ose";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnMerge
// 
this.btnMerge.Location = new System.Drawing.Point(381, 475);
this.btnMerge.Name = "btnMerge";
this.btnMerge.Size = new System.Drawing.Size(66, 31);
this.btnMerge.TabIndex = 7;
this.btnMerge.Text = "&Merge";
this.btnMerge.UseVisualStyleBackColor = true;
this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
// 
// btnCancel
// 
this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnCancel.Location = new System.Drawing.Point(453, 475);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 9;
this.btnCancel.Text = "&Cancel";
this.btnCancel.UseVisualStyleBackColor = true;
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// MergeAccountUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(608, 518);
this.Controls.Add(this.btnCancel);
this.Controls.Add(this.btnMerge);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.groupBox2);
this.Controls.Add(this.groupBox1);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "MergeAccountUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Merge Account";
this.Load += new System.EventHandler(this.MergeAccountUI_Load);
this.groupBox1.ResumeLayout(false);
this.groupBox1.PerformLayout();
this.groupBox2.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdGuest)).EndInit();
this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.TextBox txtCitizenship;
		public System.Windows.Forms.TextBox txtAccountId;
		public System.Windows.Forms.TextBox txtFirstName;
		public System.Windows.Forms.TextBox txtLastName;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label43;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnMerge;
		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdGuest;
		private System.Windows.Forms.Button btnCancel;
	}
}