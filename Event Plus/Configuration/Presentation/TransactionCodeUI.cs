/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public class TransactionCodeUI : Jinisys.Hotel.UIFramework.Maintenance2UI, ClassMaintenanceInterface
    {

        #region " Windows Form Designer generated code "

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.Container components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        internal System.Windows.Forms.GroupBox gbxCommands;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.GroupBox GroupBox1;
		public System.Windows.Forms.TextBox txtTranCode;
		public System.Windows.Forms.TextBox txtMemo;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Label Label15;
        public System.Windows.Forms.TextBox txtLedger;
        internal System.Windows.Forms.Label Label17;
        public System.Windows.Forms.TextBox txtDepartmentId;
        internal Panel pnlSearch;
        private Label label14;
        internal Label picClose;
        internal Label Label16;
        internal Label label18;
        internal Button btnCloseSearch;
        internal Button btnFind;
		internal TextBox txtSearch;
        private NumericUpDown nudLocalTax;
        private NumericUpDown nudWarningAmount;
        private NumericUpDown nudGovtTax;
		private NumericUpDown nudDefaultAmount;
        public TextBox txtCreditSide;
        public Label label20;
        public TextBox txtDebitSide;
        public Label label19;
        internal Button btnClose;
		private CheckBox chkServiceChargeInclusive;
		private ComboBox cboTranTypeId;
		private ComboBox cboAcctSide;
		private GroupBox groupBox2;
		public Label label3;
		private GroupBox groupBox4;
		public Label label13;
		private CheckBox chkLocalTaxInclusive;
		private GroupBox groupBox3;
		public Label label5;
		private CheckBox chkGovtTaxInclusive;
		private GroupBox groupBox5;
		private ComboBox cboDefaultTransactionSource;
		public Label label12;
		private GroupBox groupBox6;
		private NumericUpDown nudServiceCharge;
		private GroupBox groupBox7;
		private ListView lvwSubAccounts;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ComboBox cboTranTypeDescription;
        private Panel panel1;
        private Panel panel2;
        private Label label21;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdTransactionCodes;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionCodeUI));
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.panel1 = new System.Windows.Forms.Panel();
this.groupBox2 = new System.Windows.Forms.GroupBox();
this.nudServiceCharge = new System.Windows.Forms.NumericUpDown();
this.label3 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.chkServiceChargeInclusive = new System.Windows.Forms.CheckBox();
this.groupBox4 = new System.Windows.Forms.GroupBox();
this.label13 = new System.Windows.Forms.Label();
this.chkLocalTaxInclusive = new System.Windows.Forms.CheckBox();
this.nudLocalTax = new System.Windows.Forms.NumericUpDown();
this.Label7 = new System.Windows.Forms.Label();
this.cboTranTypeDescription = new System.Windows.Forms.ComboBox();
this.groupBox7 = new System.Windows.Forms.GroupBox();
this.lvwSubAccounts = new System.Windows.Forms.ListView();
this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
this.groupBox6 = new System.Windows.Forms.GroupBox();
this.txtLedger = new System.Windows.Forms.TextBox();
this.Label15 = new System.Windows.Forms.Label();
this.label19 = new System.Windows.Forms.Label();
this.txtDebitSide = new System.Windows.Forms.TextBox();
this.label20 = new System.Windows.Forms.Label();
this.txtCreditSide = new System.Windows.Forms.TextBox();
this.groupBox5 = new System.Windows.Forms.GroupBox();
this.cboDefaultTransactionSource = new System.Windows.Forms.ComboBox();
this.label12 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.nudDefaultAmount = new System.Windows.Forms.NumericUpDown();
this.nudWarningAmount = new System.Windows.Forms.NumericUpDown();
this.Label11 = new System.Windows.Forms.Label();
this.groupBox3 = new System.Windows.Forms.GroupBox();
this.label5 = new System.Windows.Forms.Label();
this.chkGovtTaxInclusive = new System.Windows.Forms.CheckBox();
this.Label4 = new System.Windows.Forms.Label();
this.nudGovtTax = new System.Windows.Forms.NumericUpDown();
this.cboAcctSide = new System.Windows.Forms.ComboBox();
this.cboTranTypeId = new System.Windows.Forms.ComboBox();
this.txtTranCode = new System.Windows.Forms.TextBox();
this.txtMemo = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.Label8 = new System.Windows.Forms.Label();
this.Label10 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.txtDepartmentId = new System.Windows.Forms.TextBox();
this.Label17 = new System.Windows.Forms.Label();
this.grdTransactionCodes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label14 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.label18 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.panel2 = new System.Windows.Forms.Panel();
this.label21 = new System.Windows.Forms.Label();
this.gbxCommands.SuspendLayout();
this.GroupBox1.SuspendLayout();
this.panel1.SuspendLayout();
this.groupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudServiceCharge)).BeginInit();
this.groupBox4.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudLocalTax)).BeginInit();
this.groupBox7.SuspendLayout();
this.groupBox6.SuspendLayout();
this.groupBox5.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudDefaultAmount)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudWarningAmount)).BeginInit();
this.groupBox3.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudGovtTax)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.grdTransactionCodes)).BeginInit();
this.pnlSearch.SuspendLayout();
this.panel2.SuspendLayout();
this.SuspendLayout();
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(7, 530);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(683, 48);
this.gbxCommands.TabIndex = 121;
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
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(335, 11);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 18;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
// GroupBox1
// 
this.GroupBox1.Controls.Add(this.panel2);
this.GroupBox1.Controls.Add(this.panel1);
this.GroupBox1.Controls.Add(this.cboTranTypeDescription);
this.GroupBox1.Controls.Add(this.groupBox7);
this.GroupBox1.Controls.Add(this.groupBox6);
this.GroupBox1.Controls.Add(this.groupBox5);
this.GroupBox1.Controls.Add(this.groupBox3);
this.GroupBox1.Controls.Add(this.cboAcctSide);
this.GroupBox1.Controls.Add(this.cboTranTypeId);
this.GroupBox1.Controls.Add(this.txtTranCode);
this.GroupBox1.Controls.Add(this.txtMemo);
this.GroupBox1.Controls.Add(this.Label2);
this.GroupBox1.Controls.Add(this.Label8);
this.GroupBox1.Controls.Add(this.Label10);
this.GroupBox1.Controls.Add(this.Label9);
this.GroupBox1.Controls.Add(this.txtDepartmentId);
this.GroupBox1.Controls.Add(this.Label17);
this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.GroupBox1.Location = new System.Drawing.Point(237, 2);
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.Size = new System.Drawing.Size(453, 526);
this.GroupBox1.TabIndex = 138;
this.GroupBox1.TabStop = false;
// 
// panel1
// 
this.panel1.Controls.Add(this.groupBox2);
this.panel1.Controls.Add(this.groupBox4);
this.panel1.Location = new System.Drawing.Point(151, 245);
this.panel1.Name = "panel1";
this.panel1.Size = new System.Drawing.Size(287, 269);
this.panel1.TabIndex = 189;
// 
// groupBox2
// 
this.groupBox2.Controls.Add(this.nudServiceCharge);
this.groupBox2.Controls.Add(this.label3);
this.groupBox2.Controls.Add(this.Label1);
this.groupBox2.Controls.Add(this.chkServiceChargeInclusive);
this.groupBox2.Location = new System.Drawing.Point(150, 4);
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
// groupBox4
// 
this.groupBox4.Controls.Add(this.label13);
this.groupBox4.Controls.Add(this.chkLocalTaxInclusive);
this.groupBox4.Controls.Add(this.nudLocalTax);
this.groupBox4.Controls.Add(this.Label7);
this.groupBox4.Location = new System.Drawing.Point(8, 3);
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
// cboTranTypeDescription
// 
this.cboTranTypeDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboTranTypeDescription.FormattingEnabled = true;
this.cboTranTypeDescription.Location = new System.Drawing.Point(139, 93);
this.cboTranTypeDescription.Name = "cboTranTypeDescription";
this.cboTranTypeDescription.Size = new System.Drawing.Size(154, 22);
this.cboTranTypeDescription.TabIndex = 188;
// 
// groupBox7
// 
this.groupBox7.Controls.Add(this.lvwSubAccounts);
this.groupBox7.Location = new System.Drawing.Point(153, 353);
this.groupBox7.Name = "groupBox7";
this.groupBox7.Size = new System.Drawing.Size(285, 161);
this.groupBox7.TabIndex = 187;
this.groupBox7.TabStop = false;
this.groupBox7.Text = "Sub Accounts";
// 
// lvwSubAccounts
// 
this.lvwSubAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
this.lvwSubAccounts.FullRowSelect = true;
this.lvwSubAccounts.Location = new System.Drawing.Point(6, 19);
this.lvwSubAccounts.Name = "lvwSubAccounts";
this.lvwSubAccounts.Size = new System.Drawing.Size(272, 134);
this.lvwSubAccounts.TabIndex = 0;
this.lvwSubAccounts.UseCompatibleStateImageBehavior = false;
this.lvwSubAccounts.View = System.Windows.Forms.View.Details;
// 
// columnHeader1
// 
this.columnHeader1.Text = "Account";
this.columnHeader1.Width = 90;
// 
// columnHeader2
// 
this.columnHeader2.Text = "Gov\'t Tax";
this.columnHeader2.Width = 58;
// 
// columnHeader3
// 
this.columnHeader3.Text = "Local Tax";
// 
// columnHeader4
// 
this.columnHeader4.Text = "S. Charge";
// 
// groupBox6
// 
this.groupBox6.Controls.Add(this.txtLedger);
this.groupBox6.Controls.Add(this.Label15);
this.groupBox6.Controls.Add(this.label19);
this.groupBox6.Controls.Add(this.txtDebitSide);
this.groupBox6.Controls.Add(this.label20);
this.groupBox6.Controls.Add(this.txtCreditSide);
this.groupBox6.Location = new System.Drawing.Point(153, 241);
this.groupBox6.Name = "groupBox6";
this.groupBox6.Size = new System.Drawing.Size(285, 109);
this.groupBox6.TabIndex = 186;
this.groupBox6.TabStop = false;
// 
// txtLedger
// 
this.txtLedger.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtLedger.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtLedger.Location = new System.Drawing.Point(116, 19);
this.txtLedger.MaxLength = 12;
this.txtLedger.Name = "txtLedger";
this.txtLedger.Size = new System.Drawing.Size(127, 20);
this.txtLedger.TabIndex = 164;
// 
// Label15
// 
this.Label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label15.Location = new System.Drawing.Point(16, 21);
this.Label15.Name = "Label15";
this.Label15.Size = new System.Drawing.Size(88, 17);
this.Label15.TabIndex = 165;
this.Label15.Text = "Ledger";
// 
// label19
// 
this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label19.Location = new System.Drawing.Point(16, 48);
this.label19.Name = "label19";
this.label19.Size = new System.Drawing.Size(88, 17);
this.label19.TabIndex = 176;
this.label19.Text = "Debit Side";
// 
// txtDebitSide
// 
this.txtDebitSide.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDebitSide.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDebitSide.Location = new System.Drawing.Point(116, 46);
this.txtDebitSide.MaxLength = 50;
this.txtDebitSide.Name = "txtDebitSide";
this.txtDebitSide.Size = new System.Drawing.Size(127, 20);
this.txtDebitSide.TabIndex = 175;
// 
// label20
// 
this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label20.Location = new System.Drawing.Point(16, 75);
this.label20.Name = "label20";
this.label20.Size = new System.Drawing.Size(88, 17);
this.label20.TabIndex = 178;
this.label20.Text = "Credit Side";
// 
// txtCreditSide
// 
this.txtCreditSide.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCreditSide.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCreditSide.Location = new System.Drawing.Point(116, 73);
this.txtCreditSide.MaxLength = 50;
this.txtCreditSide.Name = "txtCreditSide";
this.txtCreditSide.Size = new System.Drawing.Size(127, 20);
this.txtCreditSide.TabIndex = 177;
// 
// groupBox5
// 
this.groupBox5.Controls.Add(this.cboDefaultTransactionSource);
this.groupBox5.Controls.Add(this.label12);
this.groupBox5.Controls.Add(this.Label6);
this.groupBox5.Controls.Add(this.nudDefaultAmount);
this.groupBox5.Controls.Add(this.nudWarningAmount);
this.groupBox5.Controls.Add(this.Label11);
this.groupBox5.Location = new System.Drawing.Point(18, 130);
this.groupBox5.Name = "groupBox5";
this.groupBox5.Size = new System.Drawing.Size(410, 109);
this.groupBox5.TabIndex = 185;
this.groupBox5.TabStop = false;
// 
// cboDefaultTransactionSource
// 
this.cboDefaultTransactionSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboDefaultTransactionSource.FormattingEnabled = true;
this.cboDefaultTransactionSource.Location = new System.Drawing.Point(131, 73);
this.cboDefaultTransactionSource.Name = "cboDefaultTransactionSource";
this.cboDefaultTransactionSource.Size = new System.Drawing.Size(144, 22);
this.cboDefaultTransactionSource.TabIndex = 182;
// 
// label12
// 
this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label12.Location = new System.Drawing.Point(16, 76);
this.label12.Name = "label12";
this.label12.Size = new System.Drawing.Size(106, 17);
this.label12.TabIndex = 171;
this.label12.Text = "Default Source doc.";
// 
// Label6
// 
this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label6.Location = new System.Drawing.Point(16, 49);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(106, 17);
this.Label6.TabIndex = 157;
this.Label6.Text = "Default Amount";
// 
// nudDefaultAmount
// 
this.nudDefaultAmount.DecimalPlaces = 2;
this.nudDefaultAmount.Location = new System.Drawing.Point(131, 47);
this.nudDefaultAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
this.nudDefaultAmount.Name = "nudDefaultAmount";
this.nudDefaultAmount.Size = new System.Drawing.Size(65, 20);
this.nudDefaultAmount.TabIndex = 167;
// 
// nudWarningAmount
// 
this.nudWarningAmount.DecimalPlaces = 2;
this.nudWarningAmount.Location = new System.Drawing.Point(131, 21);
this.nudWarningAmount.Name = "nudWarningAmount";
this.nudWarningAmount.Size = new System.Drawing.Size(65, 20);
this.nudWarningAmount.TabIndex = 169;
// 
// Label11
// 
this.Label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label11.Location = new System.Drawing.Point(16, 23);
this.Label11.Name = "Label11";
this.Label11.Size = new System.Drawing.Size(106, 17);
this.Label11.TabIndex = 159;
this.Label11.Text = "Warning Amount";
// 
// groupBox3
// 
this.groupBox3.Controls.Add(this.label5);
this.groupBox3.Controls.Add(this.chkGovtTaxInclusive);
this.groupBox3.Controls.Add(this.Label4);
this.groupBox3.Controls.Add(this.nudGovtTax);
this.groupBox3.Location = new System.Drawing.Point(18, 245);
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
// cboAcctSide
// 
this.cboAcctSide.BackColor = System.Drawing.SystemColors.Info;
this.cboAcctSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboAcctSide.FormattingEnabled = true;
this.cboAcctSide.Items.AddRange(new object[] {
            "DEBIT",
            "CREDIT"});
this.cboAcctSide.Location = new System.Drawing.Point(337, 31);
this.cboAcctSide.MaxDropDownItems = 2;
this.cboAcctSide.Name = "cboAcctSide";
this.cboAcctSide.Size = new System.Drawing.Size(94, 22);
this.cboAcctSide.TabIndex = 181;
// 
// cboTranTypeId
// 
this.cboTranTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboTranTypeId.FormattingEnabled = true;
this.cboTranTypeId.Location = new System.Drawing.Point(93, 93);
this.cboTranTypeId.Name = "cboTranTypeId";
this.cboTranTypeId.Size = new System.Drawing.Size(43, 22);
this.cboTranTypeId.TabIndex = 180;
// 
// txtTranCode
// 
this.txtTranCode.BackColor = System.Drawing.SystemColors.Info;
this.txtTranCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtTranCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtTranCode.Location = new System.Drawing.Point(93, 32);
this.txtTranCode.MaxLength = 10;
this.txtTranCode.Name = "txtTranCode";
this.txtTranCode.Size = new System.Drawing.Size(82, 20);
this.txtTranCode.TabIndex = 1;
this.txtTranCode.TextChanged += new System.EventHandler(this.txtTranCode_TextChanged);
// 
// txtMemo
// 
this.txtMemo.BackColor = System.Drawing.SystemColors.Info;
this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtMemo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtMemo.Location = new System.Drawing.Point(93, 63);
this.txtMemo.MaxLength = 100;
this.txtMemo.Name = "txtMemo";
this.txtMemo.Size = new System.Drawing.Size(338, 20);
this.txtMemo.TabIndex = 4;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(28, 34);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(36, 17);
this.Label2.TabIndex = 147;
this.Label2.Text = "Code";
// 
// Label8
// 
this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label8.Location = new System.Drawing.Point(28, 96);
this.Label8.Name = "Label8";
this.Label8.Size = new System.Drawing.Size(72, 17);
this.Label8.TabIndex = 142;
this.Label8.Text = "TranType";
// 
// Label10
// 
this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label10.Location = new System.Drawing.Point(272, 34);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(59, 17);
this.Label10.TabIndex = 145;
this.Label10.Text = "Acct Side";
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.Location = new System.Drawing.Point(28, 66);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(40, 17);
this.Label9.TabIndex = 144;
this.Label9.Text = "Memo";
// 
// txtDepartmentId
// 
this.txtDepartmentId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDepartmentId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDepartmentId.Location = new System.Drawing.Point(353, 94);
this.txtDepartmentId.MaxLength = 12;
this.txtDepartmentId.Name = "txtDepartmentId";
this.txtDepartmentId.Size = new System.Drawing.Size(78, 20);
this.txtDepartmentId.TabIndex = 88;
// 
// Label17
// 
this.Label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label17.Location = new System.Drawing.Point(299, 96);
this.Label17.Name = "Label17";
this.Label17.Size = new System.Drawing.Size(48, 17);
this.Label17.TabIndex = 157;
this.Label17.Text = "Dept. ID";
// 
// grdTransactionCodes
// 
this.grdTransactionCodes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdTransactionCodes.BackColorSel = System.Drawing.SystemColors.Info;
this.grdTransactionCodes.Cols = 2;
this.grdTransactionCodes.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:52;Caption:\"Code\";TextAlign:LeftCenter;TextAlignFixe" +
    "d:CenterCenter;}\t1{Width:95;Caption:\"Memo\";TextAlign:LeftCenter;TextAlignFixed:C" +
    "enterCenter;}\t";

this.grdTransactionCodes.ExtendLastCol = true;
this.grdTransactionCodes.FixedCols = 0;
this.grdTransactionCodes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdTransactionCodes.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdTransactionCodes.ForeColorSel = System.Drawing.Color.Black;
this.grdTransactionCodes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdTransactionCodes.Location = new System.Drawing.Point(8, 7);
this.grdTransactionCodes.Name = "grdTransactionCodes";
this.grdTransactionCodes.NodeClosedPicture = null;
this.grdTransactionCodes.NodeOpenPicture = null;
this.grdTransactionCodes.OutlineCol = -1;
this.grdTransactionCodes.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdTransactionCodes.Size = new System.Drawing.Size(223, 521);
this.grdTransactionCodes.StyleInfo = resources.GetString("grdTransactionCodes.StyleInfo");
this.grdTransactionCodes.TabIndex = 191;
this.grdTransactionCodes.TreeColor = System.Drawing.Color.DarkGray;
this.grdTransactionCodes.Click += new System.EventHandler(this.grdTransactionCodes_Click);
this.grdTransactionCodes.RowColChange += new System.EventHandler(this.grdTransactionCodes_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label14);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.label18);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(-245, 89);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 192;
this.pnlSearch.Visible = false;
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
// 
// label14
// 
this.label14.BackColor = System.Drawing.Color.Transparent;
this.label14.Enabled = false;
this.label14.Image = ((System.Drawing.Image)(resources.GetObject("label14.Image")));
this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label14.Location = new System.Drawing.Point(200, 99);
this.label14.Name = "label14";
this.label14.Size = new System.Drawing.Size(48, 47);
this.label14.TabIndex = 6;
// 
// picClose
// 
this.picClose.BackColor = System.Drawing.Color.SteelBlue;
this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.picClose.Location = new System.Drawing.Point(229, 3);
this.picClose.Name = "picClose";
this.picClose.Size = new System.Drawing.Size(18, 16);
this.picClose.TabIndex = 5;
this.picClose.Click += new System.EventHandler(this.picClose_Click);
// 
// Label16
// 
this.Label16.BackColor = System.Drawing.Color.SteelBlue;
this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label16.Location = new System.Drawing.Point(1, 1);
this.Label16.Name = "Label16";
this.Label16.Size = new System.Drawing.Size(247, 21);
this.Label16.TabIndex = 0;
this.Label16.Text = " Search";
this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label18
// 
this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label18.Location = new System.Drawing.Point(16, 42);
this.label18.Name = "label18";
this.label18.Size = new System.Drawing.Size(141, 15);
this.label18.TabIndex = 4;
this.label18.Text = "Input Search string here";
// 
// btnCloseSearch
// 
this.btnCloseSearch.BackColor = System.Drawing.SystemColors.Control;
this.btnCloseSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCloseSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCloseSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnCloseSearch.Location = new System.Drawing.Point(118, 97);
this.btnCloseSearch.Name = "btnCloseSearch";
this.btnCloseSearch.Size = new System.Drawing.Size(63, 30);
this.btnCloseSearch.TabIndex = 188;
this.btnCloseSearch.Text = "&Close";
this.btnCloseSearch.UseVisualStyleBackColor = false;
this.btnCloseSearch.Click += new System.EventHandler(this.btnCloseSearch_Click);
// 
// btnFind
// 
this.btnFind.BackColor = System.Drawing.SystemColors.Control;
this.btnFind.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnFind.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnFind.Location = new System.Drawing.Point(50, 97);
this.btnFind.Name = "btnFind";
this.btnFind.Size = new System.Drawing.Size(63, 30);
this.btnFind.TabIndex = 187;
this.btnFind.Text = "&Find";
this.btnFind.UseVisualStyleBackColor = false;
this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
// 
// txtSearch
// 
this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
this.txtSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.txtSearch.Location = new System.Drawing.Point(16, 63);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 20);
this.txtSearch.TabIndex = 3;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// panel2
// 
this.panel2.Controls.Add(this.label21);
this.panel2.Location = new System.Drawing.Point(147, 241);
this.panel2.Name = "panel2";
this.panel2.Size = new System.Drawing.Size(296, 281);
this.panel2.TabIndex = 190;
// 
// label21
// 
this.label21.AutoSize = true;
this.label21.ForeColor = System.Drawing.Color.Red;
this.label21.Location = new System.Drawing.Point(53, 131);
this.label21.Name = "label21";
this.label21.Size = new System.Drawing.Size(117, 14);
this.label21.TabIndex = 191;
this.label21.Text = "objects are under here";
this.label21.Visible = false;
// 
// TransactionCodeUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(699, 584);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.grdTransactionCodes);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.gbxCommands);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "TransactionCodeUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Transaction Code";
this.Closing += new System.ComponentModel.CancelEventHandler(this.TransactionCodeUI_Closing);
this.TextChanged += new System.EventHandler(this.TransactionCodeUI_TextChanged);
this.Load += new System.EventHandler(this.TransactionCodeUI_Load);
this.gbxCommands.ResumeLayout(false);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.panel1.ResumeLayout(false);
this.groupBox2.ResumeLayout(false);
this.groupBox2.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudServiceCharge)).EndInit();
this.groupBox4.ResumeLayout(false);
this.groupBox4.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudLocalTax)).EndInit();
this.groupBox7.ResumeLayout(false);
this.groupBox6.ResumeLayout(false);
this.groupBox6.PerformLayout();
this.groupBox5.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.nudDefaultAmount)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudWarningAmount)).EndInit();
this.groupBox3.ResumeLayout(false);
this.groupBox3.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudGovtTax)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.grdTransactionCodes)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.panel2.ResumeLayout(false);
this.panel2.PerformLayout();
this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Local Variables are Camel Casing ( ex. camelCasing )
        /// Variables prefixed by "o" is an Object Instance ( ex. oCurrencyCode )
        /// </summary>     

        #region " VARIABLES "

        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;

        private ControlListener oControlListener;
        private DatasetBinder oDatasetBinder;
        
        private TransactionCode oTransactionCode;
        private TransactionCodeFacade oTransactionCodeFacade;

        #endregion

        #region " CONSTRUCTORS "

        public TransactionCodeUI()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
            oControlListener = new ControlListener();
            oDatasetBinder = new DatasetBinder();

        }

        #endregion

        #region   " MaintenanceUIInterface Members "

        /********************************************************
        * Purpose: Retrieve data from the database
        *********************************************************/
        public bool load()
        {
            try
            {
                oTransactionCodeFacade = new TransactionCodeFacade();
                oTransactionCode = new TransactionCode();
                oTransactionCode = (TransactionCode)oTransactionCodeFacade.loadObject();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /********************************************************
        * Purpose: Insert new item into the database
        *********************************************************/
        public int insert()
        {
            try
            {
                int rowsAdded = 0;
                oTransactionCodeFacade = new TransactionCodeFacade();
                rowsAdded = oTransactionCodeFacade.insertObject(ref oTransactionCode);
                return rowsAdded;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /********************************************************
        * Purpose: Update existing item 
        *********************************************************/
        public int update()
        {
            try
            {
                int rowsAffected = 0;
                oTransactionCodeFacade = new TransactionCodeFacade();
                rowsAffected = oTransactionCodeFacade.updateObject(ref oTransactionCode);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
        public int delete()
        {
            try
            {
                int rowsAffected = 0;
                oTransactionCodeFacade = new TransactionCodeFacade();

                rowsAffected = oTransactionCodeFacade.deleteObject(ref oTransactionCode);
                return rowsAffected;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region " METHODS "

        private bool isRequiredEntriesFilled()
        {
            if (this.txtTranCode.Text.Trim().Length > 0 &&
                this.txtMemo.Text.Trim().Length > 0
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool loadDataInGrid()
        {
            int i;
            this.grdTransactionCodes.Rows = 1;

            foreach (DataRow dRow in oTransactionCode.Tables[0].Rows)
            {
                i = this.grdTransactionCodes.Rows;
                this.grdTransactionCodes.Rows++;

                this.grdTransactionCodes.set_TextMatrix(i, 0, dRow["TranCode"].ToString());
                this.grdTransactionCodes.set_TextMatrix(i, 1, dRow["Memo"].ToString());
            }

            return true;
        }

        private bool hasChanges()
        {
            if (this.Text.IndexOf("*") > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool bindRowToControls()
        {
            try
            {
                if (hasChanges())
                {
                    if (MessageBox.Show("Save changes made to Transaction Code '" + this.txtTranCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (isRequiredEntriesFilled())
                        {
                            assignEntityValues();
                            update(); 
                        }
                        else
                        {
                            MessageBox.Show("Some required fields are empty.", "Update Cancelled");  
                        }
                    }
                    else
                    {
                        this.BindingContext[oTransactionCode.Tables[0]].CancelCurrentEdit();
                        this.Text = "Transaction Codes";
                    }
                }

                oControlListener.StopListen(this);

                this.BindingContext[oTransactionCode.Tables[0]].Position = findItemDataSet(this.grdTransactionCodes.get_TextMatrix(this.grdTransactionCodes.Row, 0));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (this.pnlSearch.Visible == false)
                {
                    oControlListener.Listen(this);
                }
            }
        }

        private void assignEntityValues()
        {
            oTransactionCode.TranCode = this.txtTranCode.Text;
			 oTransactionCode.TranTypeId = this.cboTranTypeId.SelectedValue.ToString();
            oTransactionCode.Memo = this.txtMemo.Text;
			oTransactionCode.AcctSide = this.cboAcctSide.Text;
            oTransactionCode.ServiceCharge = this.nudServiceCharge.Value;
			oTransactionCode.ServiceChargeInclusive = this.chkServiceChargeInclusive.Checked ? 1 : 0;

			oTransactionCode.GovtTax = this.nudGovtTax.Value;
			oTransactionCode.GovtTaxInclusive = this.chkGovtTaxInclusive.Checked ? 1 : 0;

			oTransactionCode.LocalTax = this.nudLocalTax.Value;
			oTransactionCode.LocalTaxInclusive = this.chkLocalTaxInclusive.Checked ? 1 : 0;

			oTransactionCode.DefaultTransactionSource = this.cboDefaultTransactionSource.Text;

            oTransactionCode.DefaultAmount = this.nudDefaultAmount.Value;
            oTransactionCode.WarningAmount = this.nudWarningAmount.Value;
            oTransactionCode.DepartmentId = this.txtDepartmentId.Text;
           
            oTransactionCode.Ledger = this.txtLedger.Text;
			oTransactionCode.DebitSide = this.txtDebitSide.Text;
			oTransactionCode.CreditSide = this.txtCreditSide.Text;

            oTransactionCode.HotelID = GlobalVariables.gHotelId;
            oTransactionCode.CreatedBy = GlobalVariables.gLoggedOnUser;
            oTransactionCode.UpdatedBy = GlobalVariables.gLoggedOnUser;
        }

        /********************************************************
        * Purpose: Set the state of the button
        *********************************************************/
        private void setActionButtonStates(bool state)
        {
            this.btnSearch.Enabled = state;
            this.btnNew.Enabled = state;
            this.btnDelete.Enabled = state;
            this.btnSave.Enabled = !state;
            this.btnCancel.Enabled = !state;
        }

        /// <summary>
        /// Searches the Item-Key in the Dataset and returns the Index of the Item...
        /// </summary>
        /// <param name="key"> string "key" usually the unique index </param>
        /// <returns> integer (index) </returns>
        private void searchItem()
        {
            bool isFound = false;

            if (!this.txtSearch.Text.Equals(""))
            {
                int i = 0;
                for (i = this.grdTransactionCodes.Row + 1; i <= this.grdTransactionCodes.Rows - 1; i++)
                {
                    if (this.grdTransactionCodes.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdTransactionCodes.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                    {

                        this.grdTransactionCodes.Row = i;
                        isFound = true;
                        return;
                    }
                }

                if (!isFound)
                {
                    for (i = 1; i <= this.grdTransactionCodes.Rows - 1; i++)
                    {
                        if (this.grdTransactionCodes.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper())
                        ||
                        this.grdTransactionCodes.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdTransactionCodes.Row = i;
                            isFound = true;
                            return;
                        }

                    }
                }

                MessageBox.Show("No matching record found.");
            }

        }

        /*********************************************************
        * Purpose: Populate record to Grid Control
        *********************************************************/
        public bool populateDataGrid(DataTable a_TransactionCode)
        {
            int i = 0;
            try
            {
                this.grdTransactionCodes.Rows = 1;

                foreach (DataRow dRow in a_TransactionCode.Rows)
                {
                    i = this.grdTransactionCodes.Rows;
                    this.grdTransactionCodes.Rows++;

                    this.grdTransactionCodes.set_TextMatrix(i, 0, dRow[0].ToString());
                    this.grdTransactionCodes.set_TextMatrix(i, 1, dRow["Memo"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                return false;
            }
        }

        /*********************************************************
             * Purpose: Ready for new transaction
             *********************************************************/
        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }


        #endregion

        #region " EVENTS "

        private void TransactionCodeUI_Load(System.Object sender, System.EventArgs e)
        {
			try
			{
				// load TRANSACTION TYPES in cboTranTypeId
				TransactionType _oTransactionType = new TransactionType();
				TransactionTypeFacade _oTransactionTypeFacade = new TransactionTypeFacade();
				_oTransactionType = (TransactionType)_oTransactionTypeFacade.loadObject();

				DataTable dtTranTypes = _oTransactionType.Tables[0];
				this.cboTranTypeId.DataSource = dtTranTypes;
				this.cboTranTypeId.DisplayMember = "trantypeId";
				this.cboTranTypeId.ValueMember = "trantypeId";
				this.cboTranTypeDescription.DataSource = dtTranTypes;
				this.cboTranTypeDescription.DisplayMember = "trantype";

			}
			catch {
				this.cboTranTypeId.Items.Add("1");
			}
	
			// show TRANSACTION SOURCES
			IList<TransactionSourceDocument> _oTransactionSourceList = new List<TransactionSourceDocument>();
			TransactionSourceDocumentFacade oTransactionSourceDocumentFacade = new TransactionSourceDocumentFacade();

			_oTransactionSourceList = oTransactionSourceDocumentFacade.getTransactionSourceDocuments();
			this.cboDefaultTransactionSource.DataSource = _oTransactionSourceList;
			this.cboDefaultTransactionSource.DisplayMember = "Abbreviation";
			
            if (load() == true)
            {
                if ( oTransactionCode != null )
                {
                    object obj = (object)oTransactionCode;
                    oDatasetBinder.BindControls(this, ref obj, new ArrayList());

                    populateDataGrid(oTransactionCode.Tables[0]);
                }

                this.txtTranCode.Enabled = false;
                oControlListener.Listen(this);

            }

			setActionButtonStates(true);
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            // Set operation mode to ADD
            setOperationMode(OperationMode.ADD);

            // Disable control listeners for all controls in the form
            oControlListener.StopListen(this);

			// added to FIX NUMERIC UPDOWN bug
			this.nudServiceCharge.Value = 1;
			this.nudDefaultAmount.Value = 1;
			this.nudGovtTax.Value = 1;
			this.nudWarningAmount.Value = 1;
			this.nudLocalTax.Value = 1;
			// end added
		
            // Suspend binding context for all controls
            this.BindingContext[oTransactionCode.Tables[0]].SuspendBinding();



			this.nudServiceCharge.Value = 0;
			this.nudDefaultAmount.Value = 0;
			this.nudGovtTax.Value = 0;
			this.nudWarningAmount.Value = 0;
			this.nudLocalTax.Value = 0;

			this.cboAcctSide.SelectedIndex = 0;
            this.cboTranTypeId.SelectedIndex = 0;
            

            // Set action button states
            setActionButtonStates(false);

            // Enable Transaction code textbox
            this.txtTranCode.Enabled = true;

            // Set focus to Transaction code textbox
            this.txtTranCode.Focus();

        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {
            if (isRequiredEntriesFilled())
            {
                assignEntityValues(); 

                switch (mOperationMode)
                {
                    case OperationMode.ADD:
                        if (insert() > 0)
                        {
                            MessageBox.Show("Item successfully added.", "Transaction Code", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdTransactionCodes.Rows++;
                            this.grdTransactionCodes.set_TextMatrix(this.grdTransactionCodes.Rows - 1, 0, oTransactionCode.TranCode);
                            this.grdTransactionCodes.set_TextMatrix(this.grdTransactionCodes.Rows - 1, 1, oTransactionCode.Memo);

                            // >> Resume Binding
                            this.BindingContext[oTransactionCode.Tables[0]].ResumeBinding();
                            this.Text = "Transaction Codes";

                            //mode = "";
                            this.txtTranCode.Enabled = false;

                            setActionButtonStates(true);
                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows added", "Database Insert Error");
                        }
                        break;
                    case OperationMode.EDIT:
                        if (update() > 0)
                        {
                            MessageBox.Show("Item successfully updated.", "Transaction Codes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.grdTransactionCodes.set_TextMatrix(this.grdTransactionCodes.Row, 1, oTransactionCode.Memo);

                            this.BindingContext[oTransactionCode.Tables[0]].ResumeBinding();
                            this.Text = "Transaction Codes";
                            this.txtTranCode.Enabled = false;
                            setActionButtonStates(true);
                            oControlListener.Listen(this);
                        }
                        else
                        {
                            MessageBox.Show("No rows updated", "Database Update Error");
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid operation mode", "Abort operation");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please input necessary information!", "Save Error");
                this.txtTranCode.Focus();
                return;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                if (this.grdTransactionCodes.Rows > 1)
                {
                    this.grdTransactionCodes.Row = 1;
                }
            }
            else
            {
                this.BindingContext[oTransactionCode.Tables[0]].CancelCurrentEdit();
            }

            this.BindingContext[oTransactionCode.Tables[0]].ResumeBinding();

            this.Text = "Transaction Codes";
            this.txtTranCode.Enabled = false;

            setActionButtonStates(true);
            oControlListener.Listen(this);
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            this.oControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove Transaction Code '" + this.grdTransactionCodes.get_TextMatrix(this.grdTransactionCodes.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                assignEntityValues();

                if (delete() > 0)
                {
                    this.grdTransactionCodes.RemoveItem(this.grdTransactionCodes.Row);
                }
                else
                {
                    MessageBox.Show("No rows deleted", "Database Update Error");
                }
            }
            this.oControlListener.Listen(this);
        }

        private void TransactionCodeUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanges())
            {
                if (MessageBox.Show("Save changes made to Transaction Code '" + this.txtTranCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isRequiredEntriesFilled())
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        MessageBox.Show("Some required fields are empty.", "Update Cancelled");
                    }
                }
                else
                {
                    this.BindingContext[oTransactionCode.Tables[0]].CancelCurrentEdit();
                    this.Text = "Transaction Codes";
                }
            }
        }

        private void TransactionCodeUI_TextChanged(object sender, System.EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.EDIT);
                setActionButtonStates(false);
            }
            else
            {
                setActionButtonStates(true);
            }
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            this.pnlSearch.Visible = true;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
        }

        private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private int findItemDataSet(string key)
        {
            int i = 0;

            foreach (DataRow drTranCode in oTransactionCode.Tables[0].Rows)
            {
                if (drTranCode["TranCode"].ToString() == key)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return 0;
        }

        private void grdTransactionCodes_Click(System.Object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void grdTransactionCodes_RowColChange(object sender, System.EventArgs e)
        {
            bindRowToControls();
        }

        private void pnlSearch_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSearch.Visible)
            {
                this.oControlListener.StopListen(this);
                this.gbxCommands.Enabled = false;
            }
            else
            {
                this.oControlListener.Listen(this);
                this.gbxCommands.Enabled = true;
            }

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchItem();
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void txtTranCode_TextChanged(object sender, EventArgs e)
		{
			// show Sub-Accounts
			string _tranCode = this.txtTranCode.Text;
			this.lvwSubAccounts.Items.Clear();

			TransactionCode_SubAccountFacade oTransactionCodeSubAccount = new TransactionCode_SubAccountFacade();

			IList<TransactionCode_SubAccount> _oSubAccountList = oTransactionCodeSubAccount.loadTransactionCodeSubAccounts(_tranCode);
			foreach (TransactionCode_SubAccount _oSubAccount in _oSubAccountList)
			{
				ListViewItem lvwItem = new ListViewItem(_oSubAccount.SubAccountCode);
				lvwItem.SubItems.Add(_oSubAccount.GovernmentTax.ToString("N"));
				lvwItem.SubItems.Add(_oSubAccount.LocalTax.ToString("N"));
				lvwItem.SubItems.Add(_oSubAccount.ServiceCharge.ToString("N"));

				this.lvwSubAccounts.Items.Add(lvwItem);
			}

		}

		

    }
}
