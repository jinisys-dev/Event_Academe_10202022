namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	partial class TransactionCodeSubAccountUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionCodeSubAccountUI));
this.grdSubAccounts = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.txtAcctSide = new System.Windows.Forms.TextBox();
this.groupBox4 = new System.Windows.Forms.GroupBox();
this.label13 = new System.Windows.Forms.Label();
this.chkLocalTaxInclusive = new System.Windows.Forms.CheckBox();
this.nudLocalTax = new System.Windows.Forms.NumericUpDown();
this.Label7 = new System.Windows.Forms.Label();
this.groupBox3 = new System.Windows.Forms.GroupBox();
this.label5 = new System.Windows.Forms.Label();
this.chkGovtTaxInclusive = new System.Windows.Forms.CheckBox();
this.Label4 = new System.Windows.Forms.Label();
this.nudGovtTax = new System.Windows.Forms.NumericUpDown();
this.groupBox2 = new System.Windows.Forms.GroupBox();
this.nudServiceCharge = new System.Windows.Forms.NumericUpDown();
this.label3 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.chkServiceChargeInclusive = new System.Windows.Forms.CheckBox();
this.cboTransactionCode = new System.Windows.Forms.ComboBox();
this.Label2 = new System.Windows.Forms.Label();
this.Label8 = new System.Windows.Forms.Label();
this.Label10 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.txtSubAccountCode = new System.Windows.Forms.TextBox();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.cboMemo = new System.Windows.Forms.ComboBox();
((System.ComponentModel.ISupportInitialize)(this.grdSubAccounts)).BeginInit();
this.GroupBox1.SuspendLayout();
this.groupBox4.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudLocalTax)).BeginInit();
this.groupBox3.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudGovtTax)).BeginInit();
this.groupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudServiceCharge)).BeginInit();
this.gbxCommands.SuspendLayout();
this.SuspendLayout();
// 
// grdSubAccounts
// 
this.grdSubAccounts.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdSubAccounts.BackColorSel = System.Drawing.SystemColors.Info;
this.grdSubAccounts.Cols = 2;
this.grdSubAccounts.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:52;Caption:\"Code\";TextAlign:LeftCenter;TextAlignFixe" +
    "d:CenterCenter;}\t1{Width:95;Caption:\"Sub-Account\";TextAlign:LeftCenter;TextAlign" +
    "Fixed:CenterCenter;}\t";
this.grdSubAccounts.ExtendLastCol = true;
this.grdSubAccounts.FixedCols = 0;
this.grdSubAccounts.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdSubAccounts.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdSubAccounts.ForeColorSel = System.Drawing.Color.Black;
this.grdSubAccounts.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdSubAccounts.Location = new System.Drawing.Point(9, 11);
this.grdSubAccounts.Name = "grdSubAccounts";
this.grdSubAccounts.NodeClosedPicture = null;
this.grdSubAccounts.NodeOpenPicture = null;
this.grdSubAccounts.OutlineCol = -1;
this.grdSubAccounts.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdSubAccounts.Size = new System.Drawing.Size(223, 474);
this.grdSubAccounts.StyleInfo = resources.GetString("grdSubAccounts.StyleInfo");
this.grdSubAccounts.TabIndex = 194;
this.grdSubAccounts.TreeColor = System.Drawing.Color.DarkGray;
this.grdSubAccounts.RowColChange += new System.EventHandler(this.grdSubAccounts_RowColChange);
// 
// GroupBox1
// 
this.GroupBox1.Controls.Add(this.cboMemo);
this.GroupBox1.Controls.Add(this.txtAcctSide);
this.GroupBox1.Controls.Add(this.groupBox4);
this.GroupBox1.Controls.Add(this.groupBox3);
this.GroupBox1.Controls.Add(this.groupBox2);
this.GroupBox1.Controls.Add(this.cboTransactionCode);
this.GroupBox1.Controls.Add(this.Label2);
this.GroupBox1.Controls.Add(this.Label8);
this.GroupBox1.Controls.Add(this.Label10);
this.GroupBox1.Controls.Add(this.Label9);
this.GroupBox1.Controls.Add(this.txtSubAccountCode);
this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox1.Location = new System.Drawing.Point(238, 6);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(453, 479);
this.GroupBox1.TabIndex = 193;
this.GroupBox1.TabStop = false;
// 
// txtAcctSide
// 
this.txtAcctSide.BackColor = System.Drawing.SystemColors.Control;
this.txtAcctSide.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAcctSide.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtAcctSide.Location = new System.Drawing.Point(297, 30);
this.txtAcctSide.MaxLength = 12;
this.txtAcctSide.Name = "txtAcctSide";
this.txtAcctSide.ReadOnly = true;
this.txtAcctSide.Size = new System.Drawing.Size(84, 20);
this.txtAcctSide.TabIndex = 185;
// 
// groupBox4
// 
this.groupBox4.Controls.Add(this.label13);
this.groupBox4.Controls.Add(this.chkLocalTaxInclusive);
this.groupBox4.Controls.Add(this.nudLocalTax);
this.groupBox4.Controls.Add(this.Label7);
this.groupBox4.Location = new System.Drawing.Point(18, 183);
this.groupBox4.Name = "groupBox4";
this.groupBox4.Size = new System.Drawing.Size(127, 109);
this.groupBox4.TabIndex = 184;
this.groupBox4.TabStop = false;
// 
// label13
// 
this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label13.Location = new System.Drawing.Point(89, 48);
this.label13.Name = "label13";
this.label13.Size = new System.Drawing.Size(16, 17);
this.label13.TabIndex = 180;
this.label13.Text = "%";
// 
// chkLocalTaxInclusive
// 
this.chkLocalTaxInclusive.AutoSize = true;
this.chkLocalTaxInclusive.Location = new System.Drawing.Point(17, 78);
this.chkLocalTaxInclusive.Name = "chkLocalTaxInclusive";
this.chkLocalTaxInclusive.Size = new System.Drawing.Size(68, 18);
this.chkLocalTaxInclusive.TabIndex = 179;
this.chkLocalTaxInclusive.Text = "Inclusive";
this.chkLocalTaxInclusive.UseVisualStyleBackColor = true;
// 
// nudLocalTax
// 
this.nudLocalTax.DecimalPlaces = 2;
this.nudLocalTax.Location = new System.Drawing.Point(17, 46);
this.nudLocalTax.Name = "nudLocalTax";
this.nudLocalTax.Size = new System.Drawing.Size(65, 20);
this.nudLocalTax.TabIndex = 170;
// 
// Label7
// 
this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label7.Location = new System.Drawing.Point(14, 18);
this.Label7.Name = "Label7";
this.Label7.Size = new System.Drawing.Size(88, 17);
this.Label7.TabIndex = 155;
this.Label7.Text = "Local Tax";
// 
// groupBox3
// 
this.groupBox3.Controls.Add(this.label5);
this.groupBox3.Controls.Add(this.chkGovtTaxInclusive);
this.groupBox3.Controls.Add(this.Label4);
this.groupBox3.Controls.Add(this.nudGovtTax);
this.groupBox3.Location = new System.Drawing.Point(156, 183);
this.groupBox3.Name = "groupBox3";
this.groupBox3.Size = new System.Drawing.Size(127, 109);
this.groupBox3.TabIndex = 183;
this.groupBox3.TabStop = false;
// 
// label5
// 
this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label5.Location = new System.Drawing.Point(89, 48);
this.label5.Name = "label5";
this.label5.Size = new System.Drawing.Size(16, 17);
this.label5.TabIndex = 180;
this.label5.Text = "%";
// 
// chkGovtTaxInclusive
// 
this.chkGovtTaxInclusive.AutoSize = true;
this.chkGovtTaxInclusive.Location = new System.Drawing.Point(17, 78);
this.chkGovtTaxInclusive.Name = "chkGovtTaxInclusive";
this.chkGovtTaxInclusive.Size = new System.Drawing.Size(68, 18);
this.chkGovtTaxInclusive.TabIndex = 179;
this.chkGovtTaxInclusive.Text = "Inclusive";
this.chkGovtTaxInclusive.UseVisualStyleBackColor = true;
// 
// Label4
// 
this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label4.Location = new System.Drawing.Point(17, 18);
this.Label4.Name = "Label4";
this.Label4.Size = new System.Drawing.Size(88, 17);
this.Label4.TabIndex = 153;
this.Label4.Text = "Gov\'t Tax";
// 
// nudGovtTax
// 
this.nudGovtTax.DecimalPlaces = 2;
this.nudGovtTax.Location = new System.Drawing.Point(17, 46);
this.nudGovtTax.Name = "nudGovtTax";
this.nudGovtTax.Size = new System.Drawing.Size(65, 20);
this.nudGovtTax.TabIndex = 168;
// 
// groupBox2
// 
this.groupBox2.Controls.Add(this.nudServiceCharge);
this.groupBox2.Controls.Add(this.label3);
this.groupBox2.Controls.Add(this.Label1);
this.groupBox2.Controls.Add(this.chkServiceChargeInclusive);
this.groupBox2.Location = new System.Drawing.Point(18, 298);
this.groupBox2.Name = "groupBox2";
this.groupBox2.Size = new System.Drawing.Size(127, 109);
this.groupBox2.TabIndex = 182;
this.groupBox2.TabStop = false;
// 
// nudServiceCharge
// 
this.nudServiceCharge.DecimalPlaces = 2;
this.nudServiceCharge.Location = new System.Drawing.Point(17, 48);
this.nudServiceCharge.Name = "nudServiceCharge";
this.nudServiceCharge.Size = new System.Drawing.Size(65, 20);
this.nudServiceCharge.TabIndex = 181;
// 
// label3
// 
this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label3.Location = new System.Drawing.Point(89, 48);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(16, 17);
this.label3.TabIndex = 180;
this.label3.Text = "%";
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(14, 18);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(94, 17);
this.Label1.TabIndex = 151;
this.Label1.Text = "Service Charge";
// 
// chkServiceChargeInclusive
// 
this.chkServiceChargeInclusive.AutoSize = true;
this.chkServiceChargeInclusive.Location = new System.Drawing.Point(17, 78);
this.chkServiceChargeInclusive.Name = "chkServiceChargeInclusive";
this.chkServiceChargeInclusive.Size = new System.Drawing.Size(68, 18);
this.chkServiceChargeInclusive.TabIndex = 179;
this.chkServiceChargeInclusive.Text = "Inclusive";
this.chkServiceChargeInclusive.UseVisualStyleBackColor = true;
// 
// cboTransactionCode
// 
this.cboTransactionCode.BackColor = System.Drawing.SystemColors.Info;
this.cboTransactionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboTransactionCode.FormattingEnabled = true;
this.cboTransactionCode.Location = new System.Drawing.Point(102, 29);
this.cboTransactionCode.Name = "cboTransactionCode";
this.cboTransactionCode.Size = new System.Drawing.Size(87, 22);
this.cboTransactionCode.TabIndex = 180;
this.cboTransactionCode.SelectedIndexChanged += new System.EventHandler(this.cboTransactionCode_SelectedIndexChanged);
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(20, 32);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(36, 17);
this.Label2.TabIndex = 147;
this.Label2.Text = "Code";
// 
// Label8
// 
this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label8.Location = new System.Drawing.Point(20, 103);
this.Label8.Name = "Label8";
this.Label8.Size = new System.Drawing.Size(72, 17);
this.Label8.TabIndex = 142;
this.Label8.Text = "Sub-Account";
// 
// Label10
// 
this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label10.Location = new System.Drawing.Point(232, 32);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(59, 17);
this.Label10.TabIndex = 145;
this.Label10.Text = "Acct Side";
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.Location = new System.Drawing.Point(20, 68);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(40, 17);
this.Label9.TabIndex = 144;
this.Label9.Text = "Memo";
// 
// txtSubAccountCode
// 
this.txtSubAccountCode.BackColor = System.Drawing.SystemColors.Info;
this.txtSubAccountCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtSubAccountCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtSubAccountCode.Location = new System.Drawing.Point(101, 100);
this.txtSubAccountCode.MaxLength = 20;
this.txtSubAccountCode.Name = "txtSubAccountCode";
this.txtSubAccountCode.Size = new System.Drawing.Size(280, 20);
this.txtSubAccountCode.TabIndex = 88;
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(8, 488);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(683, 48);
this.gbxCommands.TabIndex = 192;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(607, 11);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 190;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(7, 11);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 17;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(471, 11);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 15;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(403, 11);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 14;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(539, 11);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 16;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// cboMemo
// 
this.cboMemo.BackColor = System.Drawing.SystemColors.Info;
this.cboMemo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboMemo.FormattingEnabled = true;
this.cboMemo.Location = new System.Drawing.Point(101, 65);
this.cboMemo.Name = "cboMemo";
this.cboMemo.Size = new System.Drawing.Size(280, 22);
this.cboMemo.TabIndex = 186;
// 
// TransactionCodeSubAccountUI
// 
this.ClientSize = new System.Drawing.Size(699, 543);
this.Controls.Add(this.grdSubAccounts);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.gbxCommands);
this.Name = "TransactionCodeSubAccountUI";
this.Text = "Transaction Code Sub-Account";
this.TextChanged += new System.EventHandler(this.TransactionCodeSubAccountUI_TextChanged);
this.Load += new System.EventHandler(this.TransactionCodeSubAccountUI_Load);
((System.ComponentModel.ISupportInitialize)(this.grdSubAccounts)).EndInit();
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.groupBox4.ResumeLayout(false);
this.groupBox4.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudLocalTax)).EndInit();
this.groupBox3.ResumeLayout(false);
this.groupBox3.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudGovtTax)).EndInit();
this.groupBox2.ResumeLayout(false);
this.groupBox2.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudServiceCharge)).EndInit();
this.gbxCommands.ResumeLayout(false);
this.ResumeLayout(false);

		}

		#endregion

		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdSubAccounts;
		internal System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		public System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox chkLocalTaxInclusive;
		private System.Windows.Forms.NumericUpDown nudLocalTax;
		public System.Windows.Forms.Label Label7;
		private System.Windows.Forms.GroupBox groupBox3;
		public System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkGovtTaxInclusive;
		public System.Windows.Forms.Label Label4;
		private System.Windows.Forms.NumericUpDown nudGovtTax;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown nudServiceCharge;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.CheckBox chkServiceChargeInclusive;
		private System.Windows.Forms.ComboBox cboTransactionCode;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.TextBox txtSubAccountCode;
		internal System.Windows.Forms.GroupBox gbxCommands;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnDelete;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnNew;
		internal System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.TextBox txtAcctSide;
		private System.Windows.Forms.ComboBox cboMemo;
	}
}
