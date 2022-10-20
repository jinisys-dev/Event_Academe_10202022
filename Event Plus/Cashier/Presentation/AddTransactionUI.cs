using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Cashier.BusinessLayer;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using System.Collections.Specialized;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;

using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class AddTransactionUI : System.Windows.Forms.Form
		{


			#region " Windows Form Designer generated code "

			public AddTransactionUI()
			{

				//This call is required by the Windows Form Designer.
				InitializeComponent();

				//Add any initialization after the InitializeComponent() call

			}

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

			private System.ComponentModel.IContainer components;

			//Required by the Windows Form Designer

			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			public System.Windows.Forms.Label Label42;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label4;
			public System.Windows.Forms.Label Label6;
			public System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.GroupBox GroupBox1;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnOk;
			public System.Windows.Forms.TextBox txtTransactionCode;
			public System.Windows.Forms.TextBox txtReferenceNo;
			public System.Windows.Forms.TextBox txtMemo;
			public System.Windows.Forms.Label Label9;
			internal System.Windows.Forms.ColumnHeader colTransactionCode;
			internal System.Windows.Forms.ColumnHeader colMemo;
			internal System.Windows.Forms.ListView lvwCodes;
			internal System.Windows.Forms.TextBox txtServiceCharge;
			internal System.Windows.Forms.TextBox txtGovTax;
			public System.Windows.Forms.Label Label10;
			public System.Windows.Forms.Label Label11;
			public System.Windows.Forms.Label Label12;
			internal System.Windows.Forms.TextBox txtLocalTax;
			internal System.Windows.Forms.ColumnHeader colServiceCharge;
			internal System.Windows.Forms.ColumnHeader colGovtTax;
			internal System.Windows.Forms.ColumnHeader colLocalTax;
			internal System.Windows.Forms.ColumnHeader colAcctSide;
			internal System.Windows.Forms.ComboBox cboCurrencyCode;
			public System.Windows.Forms.TextBox txtBaseAmount;
			public System.Windows.Forms.TextBox txtCurAmount;
			public System.Windows.Forms.Label Label3;
			internal System.Windows.Forms.ComboBox cboCurrencyRate;
			internal System.Windows.Forms.CheckBox chkAppyRouting;
			internal System.Windows.Forms.CheckBox chkApplyPackage;
			internal System.Windows.Forms.CheckBox chkApplyPrivileges;
			internal ComboBox cboTransSource;
			public Label label8;
			private DateTimePicker dtpTransactionDate;
			public Label label13;
			private GroupBox grbPrivileges;
			private GroupBox groupBox2;
			public TextBox txtGuestName;
			public Label label14;
			public TextBox txtFolioId;
			public Label label5;
			internal ComboBox cboSubFolio;
			public Label label15;
			private GroupBox grbPayment;
			public TextBox txtGroupName;
			public Label label16;
			public TextBox txtDiscountPercent;
			public Label label17;
			public Label label21;
			public TextBox txtAllFolioOutstandingBalance;
			public TextBox txtPayment_Cheque;
			public Label label24;
			public TextBox txtPayment_CardNo;
			public Label label22;
			public TextBox txtPayment_ORNo;
			public Label lblPayment_DocSource;
			public TextBox txtPayment_Amount;
			public Label label28;
			private FlowLayoutPanel flowLayoutPanel1;
			private Panel pnlOrNo;
			private Panel pnlCardNo;
			private Panel pnlAmount;
			private Panel pnlChequeNo;
			private Panel pnlAccount;
			public TextBox txtPayment_Account;
			public Label label26;
			private Panel pnlBank;
			public TextBox txtPayment_Bank;
			public Label label27;
			private Panel pnlDate;
			public Label label25;
			private DateTimePicker dtpPayment_Date;
			private ListView lvwPrivileges;
			private ColumnHeader columnHeader3;
			private ColumnHeader columnHeader7;
			private ColumnHeader columnHeader9;
			private ColumnHeader columnHeader10;
			private ColumnHeader columnHeader11;
			private Panel pnlGrantedBy;
			public TextBox txtGrantedBy;
			public Label label29;
			private Panel pnlCardType;
			public TextBox txtCardType;
			public Label label30;
			private Panel pnlCardExpires;
			public Label label31;
			private DateTimePicker dtpCardExpires;
			private Panel pnlCardApproval;
			public TextBox txtCardApproval;
			public Label label32;
			internal ComboBox cboSubAccount;
			public Label label33;
			private Panel pnlSubAccount;
			private Panel pnlPaymentType;
			public Label label34;
			internal ComboBox cboPaymentTypes;
			internal ComboBox cboAcctSide;
			public TextBox txtNetBaseAmount;
			public Label label35;
			public Label label37;
			public TextBox txtRoomId;
			public Label label38;
			private GroupBox groupBox3;
			public TextBox txtCurrentFolioOutstandingBalance;
			public TextBox txtCurrentFolioRunningBalance;
			private GroupBox groupBox4;
			public TextBox txtAllFolioRunningBalance;
			public Label label39;
			public Label label40;
			private ColumnHeader colServiceChargeInclusive;
			private ColumnHeader colGovtTaxInclusive;
			private ColumnHeader colLocalTaxInclusive;
			private ColumnHeader colDefaultSource;
			public TextBox txtDiscountAmount;
			public Label label41;
			public Label label20;
			public Label label19;
			public Label label18;
			private Panel pnlPaymentTransSource;
			internal ComboBox cboPaymentTransSource;
			public Label label23;
			private ColumnHeader columnHeader1;
            private Panel pnlPaymentSubAccount;
            public Label label36;
            internal ComboBox cboPaymentSubAccount;
            private ColumnHeader columnHeader2;
            private ColumnHeader columnHeader4;
            private CheckBox chkAdjustment;
            internal ComboBox cboRoomID;
            public Label label43;
			internal System.Windows.Forms.Button btnViewCodes;
			[System.Diagnostics.DebuggerStepThrough()]
			private void InitializeComponent()
			{
                this.Label42 = new System.Windows.Forms.Label();
                this.txtReferenceNo = new System.Windows.Forms.TextBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.txtTransactionCode = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.txtMemo = new System.Windows.Forms.TextBox();
                this.Label4 = new System.Windows.Forms.Label();
                this.Label6 = new System.Windows.Forms.Label();
                this.txtBaseAmount = new System.Windows.Forms.TextBox();
                this.Label7 = new System.Windows.Forms.Label();
                this.txtCurAmount = new System.Windows.Forms.TextBox();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnOk = new System.Windows.Forms.Button();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.cboRoomID = new System.Windows.Forms.ComboBox();
                this.label43 = new System.Windows.Forms.Label();
                this.chkAdjustment = new System.Windows.Forms.CheckBox();
                this.label20 = new System.Windows.Forms.Label();
                this.label19 = new System.Windows.Forms.Label();
                this.label18 = new System.Windows.Forms.Label();
                this.txtDiscountAmount = new System.Windows.Forms.TextBox();
                this.label41 = new System.Windows.Forms.Label();
                this.txtNetBaseAmount = new System.Windows.Forms.TextBox();
                this.label35 = new System.Windows.Forms.Label();
                this.cboAcctSide = new System.Windows.Forms.ComboBox();
                this.pnlSubAccount = new System.Windows.Forms.Panel();
                this.label33 = new System.Windows.Forms.Label();
                this.cboSubAccount = new System.Windows.Forms.ComboBox();
                this.txtDiscountPercent = new System.Windows.Forms.TextBox();
                this.label17 = new System.Windows.Forms.Label();
                this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
                this.label13 = new System.Windows.Forms.Label();
                this.cboSubFolio = new System.Windows.Forms.ComboBox();
                this.label15 = new System.Windows.Forms.Label();
                this.cboTransSource = new System.Windows.Forms.ComboBox();
                this.label8 = new System.Windows.Forms.Label();
                this.btnViewCodes = new System.Windows.Forms.Button();
                this.cboCurrencyRate = new System.Windows.Forms.ComboBox();
                this.Label3 = new System.Windows.Forms.Label();
                this.cboCurrencyCode = new System.Windows.Forms.ComboBox();
                this.txtServiceCharge = new System.Windows.Forms.TextBox();
                this.txtLocalTax = new System.Windows.Forms.TextBox();
                this.txtGovTax = new System.Windows.Forms.TextBox();
                this.Label9 = new System.Windows.Forms.Label();
                this.Label12 = new System.Windows.Forms.Label();
                this.Label11 = new System.Windows.Forms.Label();
                this.Label10 = new System.Windows.Forms.Label();
                this.chkApplyPackage = new System.Windows.Forms.CheckBox();
                this.chkApplyPrivileges = new System.Windows.Forms.CheckBox();
                this.chkAppyRouting = new System.Windows.Forms.CheckBox();
                this.lvwCodes = new System.Windows.Forms.ListView();
                this.colTransactionCode = new System.Windows.Forms.ColumnHeader();
                this.colMemo = new System.Windows.Forms.ColumnHeader();
                this.colAcctSide = new System.Windows.Forms.ColumnHeader();
                this.colServiceCharge = new System.Windows.Forms.ColumnHeader();
                this.colGovtTax = new System.Windows.Forms.ColumnHeader();
                this.colLocalTax = new System.Windows.Forms.ColumnHeader();
                this.colServiceChargeInclusive = new System.Windows.Forms.ColumnHeader();
                this.colGovtTaxInclusive = new System.Windows.Forms.ColumnHeader();
                this.colLocalTaxInclusive = new System.Windows.Forms.ColumnHeader();
                this.colDefaultSource = new System.Windows.Forms.ColumnHeader();
                this.grbPrivileges = new System.Windows.Forms.GroupBox();
                this.lvwPrivileges = new System.Windows.Forms.ListView();
                this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.groupBox4 = new System.Windows.Forms.GroupBox();
                this.txtAllFolioRunningBalance = new System.Windows.Forms.TextBox();
                this.txtAllFolioOutstandingBalance = new System.Windows.Forms.TextBox();
                this.label39 = new System.Windows.Forms.Label();
                this.label40 = new System.Windows.Forms.Label();
                this.txtRoomId = new System.Windows.Forms.TextBox();
                this.label38 = new System.Windows.Forms.Label();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.txtCurrentFolioRunningBalance = new System.Windows.Forms.TextBox();
                this.txtCurrentFolioOutstandingBalance = new System.Windows.Forms.TextBox();
                this.label37 = new System.Windows.Forms.Label();
                this.label21 = new System.Windows.Forms.Label();
                this.txtGroupName = new System.Windows.Forms.TextBox();
                this.label16 = new System.Windows.Forms.Label();
                this.txtGuestName = new System.Windows.Forms.TextBox();
                this.label14 = new System.Windows.Forms.Label();
                this.txtFolioId = new System.Windows.Forms.TextBox();
                this.label5 = new System.Windows.Forms.Label();
                this.grbPayment = new System.Windows.Forms.GroupBox();
                this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
                this.pnlPaymentType = new System.Windows.Forms.Panel();
                this.label34 = new System.Windows.Forms.Label();
                this.cboPaymentTypes = new System.Windows.Forms.ComboBox();
                this.pnlPaymentSubAccount = new System.Windows.Forms.Panel();
                this.label36 = new System.Windows.Forms.Label();
                this.cboPaymentSubAccount = new System.Windows.Forms.ComboBox();
                this.pnlOrNo = new System.Windows.Forms.Panel();
                this.txtPayment_ORNo = new System.Windows.Forms.TextBox();
                this.lblPayment_DocSource = new System.Windows.Forms.Label();
                this.pnlPaymentTransSource = new System.Windows.Forms.Panel();
                this.cboPaymentTransSource = new System.Windows.Forms.ComboBox();
                this.label23 = new System.Windows.Forms.Label();
                this.pnlAmount = new System.Windows.Forms.Panel();
                this.txtPayment_Amount = new System.Windows.Forms.TextBox();
                this.label28 = new System.Windows.Forms.Label();
                this.pnlCardNo = new System.Windows.Forms.Panel();
                this.txtPayment_CardNo = new System.Windows.Forms.TextBox();
                this.label22 = new System.Windows.Forms.Label();
                this.pnlChequeNo = new System.Windows.Forms.Panel();
                this.txtPayment_Cheque = new System.Windows.Forms.TextBox();
                this.label24 = new System.Windows.Forms.Label();
                this.pnlAccount = new System.Windows.Forms.Panel();
                this.txtPayment_Account = new System.Windows.Forms.TextBox();
                this.label26 = new System.Windows.Forms.Label();
                this.pnlBank = new System.Windows.Forms.Panel();
                this.txtPayment_Bank = new System.Windows.Forms.TextBox();
                this.label27 = new System.Windows.Forms.Label();
                this.pnlDate = new System.Windows.Forms.Panel();
                this.dtpPayment_Date = new System.Windows.Forms.DateTimePicker();
                this.label25 = new System.Windows.Forms.Label();
                this.pnlGrantedBy = new System.Windows.Forms.Panel();
                this.txtGrantedBy = new System.Windows.Forms.TextBox();
                this.label29 = new System.Windows.Forms.Label();
                this.pnlCardType = new System.Windows.Forms.Panel();
                this.txtCardType = new System.Windows.Forms.TextBox();
                this.label30 = new System.Windows.Forms.Label();
                this.pnlCardApproval = new System.Windows.Forms.Panel();
                this.txtCardApproval = new System.Windows.Forms.TextBox();
                this.label32 = new System.Windows.Forms.Label();
                this.pnlCardExpires = new System.Windows.Forms.Panel();
                this.dtpCardExpires = new System.Windows.Forms.DateTimePicker();
                this.label31 = new System.Windows.Forms.Label();
                this.GroupBox1.SuspendLayout();
                this.pnlSubAccount.SuspendLayout();
                this.grbPrivileges.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.groupBox4.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.grbPayment.SuspendLayout();
                this.flowLayoutPanel1.SuspendLayout();
                this.pnlPaymentType.SuspendLayout();
                this.pnlPaymentSubAccount.SuspendLayout();
                this.pnlOrNo.SuspendLayout();
                this.pnlPaymentTransSource.SuspendLayout();
                this.pnlAmount.SuspendLayout();
                this.pnlCardNo.SuspendLayout();
                this.pnlChequeNo.SuspendLayout();
                this.pnlAccount.SuspendLayout();
                this.pnlBank.SuspendLayout();
                this.pnlDate.SuspendLayout();
                this.pnlGrantedBy.SuspendLayout();
                this.pnlCardType.SuspendLayout();
                this.pnlCardApproval.SuspendLayout();
                this.pnlCardExpires.SuspendLayout();
                this.SuspendLayout();
                // 
                // Label42
                // 
                this.Label42.BackColor = System.Drawing.SystemColors.Control;
                this.Label42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label42.ForeColor = System.Drawing.Color.Black;
                this.Label42.Location = new System.Drawing.Point(21, 333);
                this.Label42.Name = "Label42";
                this.Label42.Size = new System.Drawing.Size(79, 16);
                this.Label42.TabIndex = 87;
                this.Label42.Text = "Reference # :";
                // 
                // txtReferenceNo
                // 
                this.txtReferenceNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtReferenceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtReferenceNo.Location = new System.Drawing.Point(119, 329);
                this.txtReferenceNo.MaxLength = 100;
                this.txtReferenceNo.Name = "txtReferenceNo";
                this.txtReferenceNo.Size = new System.Drawing.Size(174, 20);
                this.txtReferenceNo.TabIndex = 18;
                this.txtReferenceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferenceNo_KeyPress);
                // 
                // Label1
                // 
                this.Label1.BackColor = System.Drawing.SystemColors.Control;
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.ForeColor = System.Drawing.Color.Black;
                this.Label1.Location = new System.Drawing.Point(21, 98);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(72, 16);
                this.Label1.TabIndex = 89;
                this.Label1.Text = "Trans Code :";
                // 
                // txtTransactionCode
                // 
                this.txtTransactionCode.BackColor = System.Drawing.SystemColors.Info;
                this.txtTransactionCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtTransactionCode.Location = new System.Drawing.Point(119, 96);
                this.txtTransactionCode.MaxLength = 20;
                this.txtTransactionCode.Name = "txtTransactionCode";
                this.txtTransactionCode.Size = new System.Drawing.Size(80, 20);
                this.txtTransactionCode.TabIndex = 2;
                this.txtTransactionCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransactionCode_KeyPress);
                this.txtTransactionCode.LostFocus += new System.EventHandler(this.txtTransactionCode_LostFocus);
                // 
                // Label2
                // 
                this.Label2.BackColor = System.Drawing.SystemColors.Control;
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.ForeColor = System.Drawing.Color.Black;
                this.Label2.Location = new System.Drawing.Point(21, 129);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(48, 16);
                this.Label2.TabIndex = 91;
                this.Label2.Text = "Memo :";
                // 
                // txtMemo
                // 
                this.txtMemo.BackColor = System.Drawing.SystemColors.Info;
                this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtMemo.Location = new System.Drawing.Point(119, 124);
                this.txtMemo.MaxLength = 500;
                this.txtMemo.Name = "txtMemo";
                this.txtMemo.Size = new System.Drawing.Size(327, 20);
                this.txtMemo.TabIndex = 7;
                this.txtMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemo_KeyPress);
                // 
                // Label4
                // 
                this.Label4.BackColor = System.Drawing.SystemColors.Control;
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.ForeColor = System.Drawing.Color.Black;
                this.Label4.Location = new System.Drawing.Point(251, 158);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(79, 16);
                this.Label4.TabIndex = 97;
                this.Label4.Text = "Currency :";
                // 
                // Label6
                // 
                this.Label6.BackColor = System.Drawing.SystemColors.Control;
                this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label6.ForeColor = System.Drawing.Color.Black;
                this.Label6.Location = new System.Drawing.Point(21, 188);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(86, 16);
                this.Label6.TabIndex = 101;
                this.Label6.Text = "Gross Amount :";
                // 
                // txtBaseAmount
                // 
                this.txtBaseAmount.BackColor = System.Drawing.SystemColors.Control;
                this.txtBaseAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtBaseAmount.Location = new System.Drawing.Point(119, 186);
                this.txtBaseAmount.Name = "txtBaseAmount";
                this.txtBaseAmount.ReadOnly = true;
                this.txtBaseAmount.Size = new System.Drawing.Size(108, 20);
                this.txtBaseAmount.TabIndex = 10;
                this.txtBaseAmount.Text = "0.00";
                this.txtBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtBaseAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseAmount_KeyPress);
                // 
                // Label7
                // 
                this.Label7.BackColor = System.Drawing.SystemColors.Control;
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label7.ForeColor = System.Drawing.Color.Black;
                this.Label7.Location = new System.Drawing.Point(21, 158);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(99, 16);
                this.Label7.TabIndex = 103;
                this.Label7.Text = "Amount :";
                // 
                // txtCurAmount
                // 
                this.txtCurAmount.BackColor = System.Drawing.SystemColors.Info;
                this.txtCurAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtCurAmount.Location = new System.Drawing.Point(119, 156);
                this.txtCurAmount.MaxLength = 15;
                this.txtCurAmount.Name = "txtCurAmount";
                this.txtCurAmount.Size = new System.Drawing.Size(108, 20);
                this.txtCurAmount.TabIndex = 8;
                this.txtCurAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtCurAmount.TextChanged += new System.EventHandler(this.txtCurAmount_TextChanged);
                this.txtCurAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurAmount_KeyPress);
                // 
                // btnCancel
                // 
                this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnCancel.Location = new System.Drawing.Point(652, 578);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(66, 31);
                this.btnCancel.TabIndex = 38;
                this.btnCancel.Text = "&Close";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnOk
                // 
                this.btnOk.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnOk.Location = new System.Drawing.Point(580, 578);
                this.btnOk.Name = "btnOk";
                this.btnOk.Size = new System.Drawing.Size(66, 31);
                this.btnOk.TabIndex = 37;
                this.btnOk.Text = "&Insert";
                this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
                // 
                // GroupBox1
                // 
                this.GroupBox1.Controls.Add(this.cboRoomID);
                this.GroupBox1.Controls.Add(this.label43);
                this.GroupBox1.Controls.Add(this.chkAdjustment);
                this.GroupBox1.Controls.Add(this.label20);
                this.GroupBox1.Controls.Add(this.label19);
                this.GroupBox1.Controls.Add(this.label18);
                this.GroupBox1.Controls.Add(this.txtDiscountAmount);
                this.GroupBox1.Controls.Add(this.label41);
                this.GroupBox1.Controls.Add(this.txtNetBaseAmount);
                this.GroupBox1.Controls.Add(this.label35);
                this.GroupBox1.Controls.Add(this.cboAcctSide);
                this.GroupBox1.Controls.Add(this.pnlSubAccount);
                this.GroupBox1.Controls.Add(this.txtDiscountPercent);
                this.GroupBox1.Controls.Add(this.label17);
                this.GroupBox1.Controls.Add(this.dtpTransactionDate);
                this.GroupBox1.Controls.Add(this.label13);
                this.GroupBox1.Controls.Add(this.cboSubFolio);
                this.GroupBox1.Controls.Add(this.label15);
                this.GroupBox1.Controls.Add(this.cboTransSource);
                this.GroupBox1.Controls.Add(this.label8);
                this.GroupBox1.Controls.Add(this.btnViewCodes);
                this.GroupBox1.Controls.Add(this.cboCurrencyRate);
                this.GroupBox1.Controls.Add(this.Label3);
                this.GroupBox1.Controls.Add(this.cboCurrencyCode);
                this.GroupBox1.Controls.Add(this.txtTransactionCode);
                this.GroupBox1.Controls.Add(this.txtBaseAmount);
                this.GroupBox1.Controls.Add(this.txtCurAmount);
                this.GroupBox1.Controls.Add(this.txtReferenceNo);
                this.GroupBox1.Controls.Add(this.txtMemo);
                this.GroupBox1.Controls.Add(this.txtServiceCharge);
                this.GroupBox1.Controls.Add(this.txtLocalTax);
                this.GroupBox1.Controls.Add(this.txtGovTax);
                this.GroupBox1.Controls.Add(this.Label9);
                this.GroupBox1.Controls.Add(this.Label12);
                this.GroupBox1.Controls.Add(this.Label11);
                this.GroupBox1.Controls.Add(this.Label10);
                this.GroupBox1.Controls.Add(this.Label6);
                this.GroupBox1.Controls.Add(this.Label4);
                this.GroupBox1.Controls.Add(this.Label7);
                this.GroupBox1.Controls.Add(this.Label42);
                this.GroupBox1.Controls.Add(this.Label1);
                this.GroupBox1.Controls.Add(this.Label2);
                this.GroupBox1.Location = new System.Drawing.Point(11, 220);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(461, 402);
                this.GroupBox1.TabIndex = 0;
                this.GroupBox1.TabStop = false;
                this.GroupBox1.Text = "Post Transaction";
                // 
                // cboRoomID
                // 
                this.cboRoomID.BackColor = System.Drawing.Color.White;
                this.cboRoomID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboRoomID.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboRoomID.Location = new System.Drawing.Point(313, 31);
                this.cboRoomID.Name = "cboRoomID";
                this.cboRoomID.Size = new System.Drawing.Size(133, 22);
                this.cboRoomID.TabIndex = 153;
                this.cboRoomID.SelectedIndexChanged += new System.EventHandler(this.cboRoomID_SelectedIndexChanged);
                // 
                // label43
                // 
                this.label43.BackColor = System.Drawing.SystemColors.Control;
                this.label43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label43.ForeColor = System.Drawing.Color.Black;
                this.label43.Location = new System.Drawing.Point(240, 34);
                this.label43.Name = "label43";
                this.label43.Size = new System.Drawing.Size(55, 16);
                this.label43.TabIndex = 154;
                this.label43.Text = "Room ID :";
                // 
                // chkAdjustment
                // 
                this.chkAdjustment.AutoSize = true;
                this.chkAdjustment.Location = new System.Drawing.Point(407, 63);
                this.chkAdjustment.Name = "chkAdjustment";
                this.chkAdjustment.Size = new System.Drawing.Size(45, 18);
                this.chkAdjustment.TabIndex = 152;
                this.chkAdjustment.Text = "Adj.";
                this.chkAdjustment.UseVisualStyleBackColor = true;
                this.chkAdjustment.VisibleChanged += new System.EventHandler(this.chkAdjustment_VisibleChanged);
                this.chkAdjustment.CheckedChanged += new System.EventHandler(this.chkAdjustment_CheckedChanged);
                // 
                // label20
                // 
                this.label20.BackColor = System.Drawing.SystemColors.Control;
                this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label20.ForeColor = System.Drawing.Color.Black;
                this.label20.Location = new System.Drawing.Point(417, 277);
                this.label20.Name = "label20";
                this.label20.Size = new System.Drawing.Size(18, 16);
                this.label20.TabIndex = 151;
                this.label20.Text = "%";
                // 
                // label19
                // 
                this.label19.BackColor = System.Drawing.SystemColors.Control;
                this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label19.ForeColor = System.Drawing.Color.Black;
                this.label19.Location = new System.Drawing.Point(417, 249);
                this.label19.Name = "label19";
                this.label19.Size = new System.Drawing.Size(18, 16);
                this.label19.TabIndex = 150;
                this.label19.Text = "%";
                // 
                // label18
                // 
                this.label18.BackColor = System.Drawing.SystemColors.Control;
                this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label18.ForeColor = System.Drawing.Color.Black;
                this.label18.Location = new System.Drawing.Point(417, 219);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(18, 16);
                this.label18.TabIndex = 149;
                this.label18.Text = "%";
                // 
                // txtDiscountAmount
                // 
                this.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control;
                this.txtDiscountAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtDiscountAmount.Location = new System.Drawing.Point(119, 245);
                this.txtDiscountAmount.MaxLength = 15;
                this.txtDiscountAmount.Name = "txtDiscountAmount";
                this.txtDiscountAmount.ReadOnly = true;
                this.txtDiscountAmount.Size = new System.Drawing.Size(108, 20);
                this.txtDiscountAmount.TabIndex = 14;
                this.txtDiscountAmount.Text = "0.00";
                this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label41
                // 
                this.label41.BackColor = System.Drawing.SystemColors.Control;
                this.label41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label41.ForeColor = System.Drawing.Color.Black;
                this.label41.Location = new System.Drawing.Point(21, 247);
                this.label41.Name = "label41";
                this.label41.Size = new System.Drawing.Size(78, 16);
                this.label41.TabIndex = 148;
                this.label41.Text = "Discount Amt :";
                // 
                // txtNetBaseAmount
                // 
                this.txtNetBaseAmount.BackColor = System.Drawing.SystemColors.Control;
                this.txtNetBaseAmount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtNetBaseAmount.Location = new System.Drawing.Point(119, 275);
                this.txtNetBaseAmount.MaxLength = 15;
                this.txtNetBaseAmount.Name = "txtNetBaseAmount";
                this.txtNetBaseAmount.ReadOnly = true;
                this.txtNetBaseAmount.Size = new System.Drawing.Size(108, 29);
                this.txtNetBaseAmount.TabIndex = 16;
                this.txtNetBaseAmount.Text = "0.00";
                this.txtNetBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtNetBaseAmount.TextChanged += new System.EventHandler(this.txtNetBaseAmount_TextChanged);
                // 
                // label35
                // 
                this.label35.BackColor = System.Drawing.SystemColors.Control;
                this.label35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label35.ForeColor = System.Drawing.Color.Black;
                this.label35.Location = new System.Drawing.Point(21, 281);
                this.label35.Name = "label35";
                this.label35.Size = new System.Drawing.Size(78, 16);
                this.label35.TabIndex = 144;
                this.label35.Text = "Net Amount :";
                // 
                // cboAcctSide
                // 
                this.cboAcctSide.BackColor = System.Drawing.Color.White;
                this.cboAcctSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboAcctSide.Items.AddRange(new object[] {
            "DEBIT",
            "CREDIT"});
                this.cboAcctSide.Location = new System.Drawing.Point(313, 61);
                this.cboAcctSide.Name = "cboAcctSide";
                this.cboAcctSide.Size = new System.Drawing.Size(91, 22);
                this.cboAcctSide.TabIndex = 4;
                this.cboAcctSide.SelectedIndexChanged += new System.EventHandler(this.cboAcctSide_SelectedIndexChanged);
                // 
                // pnlSubAccount
                // 
                this.pnlSubAccount.Controls.Add(this.label33);
                this.pnlSubAccount.Controls.Add(this.cboSubAccount);
                this.pnlSubAccount.Location = new System.Drawing.Point(233, 93);
                this.pnlSubAccount.Name = "pnlSubAccount";
                this.pnlSubAccount.Size = new System.Drawing.Size(222, 27);
                this.pnlSubAccount.TabIndex = 5;
                this.pnlSubAccount.Visible = false;
                // 
                // label33
                // 
                this.label33.BackColor = System.Drawing.SystemColors.Control;
                this.label33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label33.ForeColor = System.Drawing.Color.Black;
                this.label33.Location = new System.Drawing.Point(7, 5);
                this.label33.Name = "label33";
                this.label33.Size = new System.Drawing.Size(70, 16);
                this.label33.TabIndex = 144;
                this.label33.Text = "Sub Account";
                // 
                // cboSubAccount
                // 
                this.cboSubAccount.BackColor = System.Drawing.Color.White;
                this.cboSubAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboSubAccount.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboSubAccount.Location = new System.Drawing.Point(80, 2);
                this.cboSubAccount.Name = "cboSubAccount";
                this.cboSubAccount.Size = new System.Drawing.Size(133, 22);
                this.cboSubAccount.TabIndex = 6;
                this.cboSubAccount.SelectedIndexChanged += new System.EventHandler(this.cboSubAccount_SelectedIndexChanged);
                // 
                // txtDiscountPercent
                // 
                this.txtDiscountPercent.BackColor = System.Drawing.Color.White;
                this.txtDiscountPercent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtDiscountPercent.Location = new System.Drawing.Point(119, 216);
                this.txtDiscountPercent.MaxLength = 15;
                this.txtDiscountPercent.Name = "txtDiscountPercent";
                this.txtDiscountPercent.Size = new System.Drawing.Size(108, 20);
                this.txtDiscountPercent.TabIndex = 12;
                this.txtDiscountPercent.Text = "0.00";
                this.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtDiscountPercent.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
                this.txtDiscountPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
                // 
                // label17
                // 
                this.label17.BackColor = System.Drawing.SystemColors.Control;
                this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label17.ForeColor = System.Drawing.Color.Black;
                this.label17.Location = new System.Drawing.Point(21, 218);
                this.label17.Name = "label17";
                this.label17.Size = new System.Drawing.Size(78, 16);
                this.label17.TabIndex = 139;
                this.label17.Text = "Discount (%) :";
                // 
                // dtpTransactionDate
                // 
                this.dtpTransactionDate.CalendarMonthBackground = System.Drawing.Color.White;
                this.dtpTransactionDate.CalendarTitleForeColor = System.Drawing.Color.White;
                this.dtpTransactionDate.CustomFormat = "MMM. dd, yyyy";
                this.dtpTransactionDate.Enabled = false;
                this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                this.dtpTransactionDate.Location = new System.Drawing.Point(119, 64);
                this.dtpTransactionDate.Name = "dtpTransactionDate";
                this.dtpTransactionDate.Size = new System.Drawing.Size(80, 20);
                this.dtpTransactionDate.TabIndex = 1;
                // 
                // label13
                // 
                this.label13.BackColor = System.Drawing.SystemColors.Control;
                this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label13.ForeColor = System.Drawing.Color.Black;
                this.label13.Location = new System.Drawing.Point(21, 67);
                this.label13.Name = "label13";
                this.label13.Size = new System.Drawing.Size(72, 16);
                this.label13.TabIndex = 136;
                this.label13.Text = "Trans. Date :";
                // 
                // cboSubFolio
                // 
                this.cboSubFolio.BackColor = System.Drawing.Color.White;
                this.cboSubFolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboSubFolio.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboSubFolio.Location = new System.Drawing.Point(119, 32);
                this.cboSubFolio.Name = "cboSubFolio";
                this.cboSubFolio.Size = new System.Drawing.Size(80, 22);
                this.cboSubFolio.TabIndex = 0;
                this.cboSubFolio.SelectedIndexChanged += new System.EventHandler(this.cboSubFolio_SelectedIndexChanged);
                // 
                // label15
                // 
                this.label15.BackColor = System.Drawing.SystemColors.Control;
                this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label15.ForeColor = System.Drawing.Color.Black;
                this.label15.Location = new System.Drawing.Point(21, 34);
                this.label15.Name = "label15";
                this.label15.Size = new System.Drawing.Size(79, 18);
                this.label15.TabIndex = 118;
                this.label15.Text = "Sub Accnt. :";
                // 
                // cboTransSource
                // 
                this.cboTransSource.BackColor = System.Drawing.Color.White;
                this.cboTransSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboTransSource.Items.AddRange(new object[] {
            "ORDER SLIP",
            "CHARGE INVOICE",
            "SALES INVOICE"});
                this.cboTransSource.Location = new System.Drawing.Point(119, 359);
                this.cboTransSource.Name = "cboTransSource";
                this.cboTransSource.Size = new System.Drawing.Size(174, 22);
                this.cboTransSource.TabIndex = 19;
                this.cboTransSource.SelectedIndexChanged += new System.EventHandler(this.cboTransSource_SelectedIndexChanged);
                this.cboTransSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTransSource_KeyPress);
                // 
                // label8
                // 
                this.label8.BackColor = System.Drawing.SystemColors.Control;
                this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label8.ForeColor = System.Drawing.Color.Black;
                this.label8.Location = new System.Drawing.Point(21, 363);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(84, 16);
                this.label8.TabIndex = 134;
                this.label8.Text = "Trans Source :";
                // 
                // btnViewCodes
                // 
                this.btnViewCodes.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnViewCodes.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnViewCodes.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
                this.btnViewCodes.Location = new System.Drawing.Point(203, 93);
                this.btnViewCodes.Name = "btnViewCodes";
                this.btnViewCodes.Size = new System.Drawing.Size(27, 26);
                this.btnViewCodes.TabIndex = 3;
                this.btnViewCodes.Click += new System.EventHandler(this.btnViewCodes_Click);
                // 
                // cboCurrencyRate
                // 
                this.cboCurrencyRate.BackColor = System.Drawing.Color.White;
                this.cboCurrencyRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboCurrencyRate.Location = new System.Drawing.Point(336, 185);
                this.cboCurrencyRate.Name = "cboCurrencyRate";
                this.cboCurrencyRate.Size = new System.Drawing.Size(80, 22);
                this.cboCurrencyRate.TabIndex = 11;
                this.cboCurrencyRate.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyRate_SelectedIndexChanged);
                // 
                // Label3
                // 
                this.Label3.BackColor = System.Drawing.SystemColors.Control;
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.ForeColor = System.Drawing.Color.Black;
                this.Label3.Location = new System.Drawing.Point(251, 188);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(79, 16);
                this.Label3.TabIndex = 127;
                this.Label3.Text = "Rate :";
                // 
                // cboCurrencyCode
                // 
                this.cboCurrencyCode.BackColor = System.Drawing.Color.White;
                this.cboCurrencyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboCurrencyCode.Location = new System.Drawing.Point(336, 155);
                this.cboCurrencyCode.Name = "cboCurrencyCode";
                this.cboCurrencyCode.Size = new System.Drawing.Size(80, 22);
                this.cboCurrencyCode.TabIndex = 9;
                this.cboCurrencyCode.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyCode_SelectedIndexChanged);
                // 
                // txtServiceCharge
                // 
                this.txtServiceCharge.BackColor = System.Drawing.SystemColors.Control;
                this.txtServiceCharge.Location = new System.Drawing.Point(336, 216);
                this.txtServiceCharge.Name = "txtServiceCharge";
                this.txtServiceCharge.Size = new System.Drawing.Size(80, 20);
                this.txtServiceCharge.TabIndex = 13;
                this.txtServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtServiceCharge.TextChanged += new System.EventHandler(this.txtServiceCharge_TextChanged);
                // 
                // txtLocalTax
                // 
                this.txtLocalTax.BackColor = System.Drawing.SystemColors.Control;
                this.txtLocalTax.Location = new System.Drawing.Point(336, 275);
                this.txtLocalTax.Name = "txtLocalTax";
                this.txtLocalTax.ReadOnly = true;
                this.txtLocalTax.Size = new System.Drawing.Size(80, 20);
                this.txtLocalTax.TabIndex = 17;
                this.txtLocalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtLocalTax.TextChanged += new System.EventHandler(this.txtLocalTax_TextChanged);
                // 
                // txtGovTax
                // 
                this.txtGovTax.BackColor = System.Drawing.SystemColors.Control;
                this.txtGovTax.Location = new System.Drawing.Point(336, 245);
                this.txtGovTax.Name = "txtGovTax";
                this.txtGovTax.ReadOnly = true;
                this.txtGovTax.Size = new System.Drawing.Size(80, 20);
                this.txtGovTax.TabIndex = 15;
                this.txtGovTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtGovTax.TextChanged += new System.EventHandler(this.txtGovTax_TextChanged);
                // 
                // Label9
                // 
                this.Label9.BackColor = System.Drawing.SystemColors.Control;
                this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label9.ForeColor = System.Drawing.Color.Black;
                this.Label9.Location = new System.Drawing.Point(240, 67);
                this.Label9.Name = "Label9";
                this.Label9.Size = new System.Drawing.Size(73, 16);
                this.Label9.TabIndex = 112;
                this.Label9.Text = "Acctng Side :";
                // 
                // Label12
                // 
                this.Label12.BackColor = System.Drawing.SystemColors.Control;
                this.Label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label12.ForeColor = System.Drawing.Color.Black;
                this.Label12.Location = new System.Drawing.Point(251, 277);
                this.Label12.Name = "Label12";
                this.Label12.Size = new System.Drawing.Size(79, 16);
                this.Label12.TabIndex = 122;
                this.Label12.Text = "Local Tax :";
                // 
                // Label11
                // 
                this.Label11.BackColor = System.Drawing.SystemColors.Control;
                this.Label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label11.ForeColor = System.Drawing.Color.Black;
                this.Label11.Location = new System.Drawing.Point(251, 247);
                this.Label11.Name = "Label11";
                this.Label11.Size = new System.Drawing.Size(79, 16);
                this.Label11.TabIndex = 121;
                this.Label11.Text = "Gov\'t Tax :";
                // 
                // Label10
                // 
                this.Label10.BackColor = System.Drawing.SystemColors.Control;
                this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label10.ForeColor = System.Drawing.Color.Black;
                this.Label10.Location = new System.Drawing.Point(251, 218);
                this.Label10.Name = "Label10";
                this.Label10.Size = new System.Drawing.Size(79, 16);
                this.Label10.TabIndex = 120;
                this.Label10.Text = "Service Chrg :";
                // 
                // chkApplyPackage
                // 
                this.chkApplyPackage.Checked = true;
                this.chkApplyPackage.CheckState = System.Windows.Forms.CheckState.Checked;
                this.chkApplyPackage.Location = new System.Drawing.Point(128, 172);
                this.chkApplyPackage.Name = "chkApplyPackage";
                this.chkApplyPackage.Size = new System.Drawing.Size(99, 18);
                this.chkApplyPackage.TabIndex = 2;
                this.chkApplyPackage.Text = "Apply Package";
                this.chkApplyPackage.Visible = false;
                // 
                // chkApplyPrivileges
                // 
                this.chkApplyPrivileges.Checked = true;
                this.chkApplyPrivileges.CheckState = System.Windows.Forms.CheckState.Checked;
                this.chkApplyPrivileges.Location = new System.Drawing.Point(17, 172);
                this.chkApplyPrivileges.Name = "chkApplyPrivileges";
                this.chkApplyPrivileges.Size = new System.Drawing.Size(105, 18);
                this.chkApplyPrivileges.TabIndex = 1;
                this.chkApplyPrivileges.Text = "Apply Privileges";
                this.chkApplyPrivileges.Visible = false;
                // 
                // chkAppyRouting
                // 
                this.chkAppyRouting.Checked = true;
                this.chkAppyRouting.CheckState = System.Windows.Forms.CheckState.Checked;
                this.chkAppyRouting.Location = new System.Drawing.Point(233, 172);
                this.chkAppyRouting.Name = "chkAppyRouting";
                this.chkAppyRouting.Size = new System.Drawing.Size(99, 18);
                this.chkAppyRouting.TabIndex = 3;
                this.chkAppyRouting.Text = "Apply Routing";
                this.chkAppyRouting.Visible = false;
                // 
                // lvwCodes
                // 
                this.lvwCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTransactionCode,
            this.colMemo,
            this.colAcctSide,
            this.colServiceCharge,
            this.colGovtTax,
            this.colLocalTax,
            this.colServiceChargeInclusive,
            this.colGovtTaxInclusive,
            this.colLocalTaxInclusive,
            this.colDefaultSource});
                this.lvwCodes.FullRowSelect = true;
                this.lvwCodes.GridLines = true;
                this.lvwCodes.Location = new System.Drawing.Point(11, 220);
                this.lvwCodes.MultiSelect = false;
                this.lvwCodes.Name = "lvwCodes";
                this.lvwCodes.Size = new System.Drawing.Size(730, 402);
                this.lvwCodes.TabIndex = 113;
                this.lvwCodes.UseCompatibleStateImageBehavior = false;
                this.lvwCodes.View = System.Windows.Forms.View.Details;
                this.lvwCodes.Visible = false;
                this.lvwCodes.DoubleClick += new System.EventHandler(this.lvwCodes_DoubleClick);
                this.lvwCodes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwCodes_KeyPress);
                // 
                // colTransactionCode
                // 
                this.colTransactionCode.Text = "Code";
                // 
                // colMemo
                // 
                this.colMemo.Text = "Memo";
                this.colMemo.Width = 239;
                // 
                // colAcctSide
                // 
                this.colAcctSide.Text = "Acct. Side";
                this.colAcctSide.Width = 69;
                // 
                // colServiceCharge
                // 
                this.colServiceCharge.Text = "Serv. Charge";
                this.colServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colServiceCharge.Width = 79;
                // 
                // colGovtTax
                // 
                this.colGovtTax.Text = "Gov. Tax";
                this.colGovtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colGovtTax.Width = 72;
                // 
                // colLocalTax
                // 
                this.colLocalTax.Text = "Local Tax";
                this.colLocalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colLocalTax.Width = 71;
                // 
                // colServiceChargeInclusive
                // 
                this.colServiceChargeInclusive.Width = 0;
                // 
                // colGovtTaxInclusive
                // 
                this.colGovtTaxInclusive.Width = 0;
                // 
                // colLocalTaxInclusive
                // 
                this.colLocalTaxInclusive.Width = 0;
                // 
                // colDefaultSource
                // 
                this.colDefaultSource.Text = "Default Source";
                this.colDefaultSource.Width = 119;
                // 
                // grbPrivileges
                // 
                this.grbPrivileges.Controls.Add(this.lvwPrivileges);
                this.grbPrivileges.Controls.Add(this.chkApplyPackage);
                this.grbPrivileges.Controls.Add(this.chkApplyPrivileges);
                this.grbPrivileges.Controls.Add(this.chkAppyRouting);
                this.grbPrivileges.Location = new System.Drawing.Point(401, 12);
                this.grbPrivileges.Name = "grbPrivileges";
                this.grbPrivileges.Size = new System.Drawing.Size(340, 200);
                this.grbPrivileges.TabIndex = 50;
                this.grbPrivileges.TabStop = false;
                this.grbPrivileges.Text = "Privilege / Promo";
                // 
                // lvwPrivileges
                // 
                this.lvwPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
                this.lvwPrivileges.FullRowSelect = true;
                this.lvwPrivileges.Location = new System.Drawing.Point(10, 29);
                this.lvwPrivileges.Name = "lvwPrivileges";
                this.lvwPrivileges.Size = new System.Drawing.Size(322, 159);
                this.lvwPrivileges.TabIndex = 51;
                this.lvwPrivileges.UseCompatibleStateImageBehavior = false;
                this.lvwPrivileges.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader3
                // 
                this.columnHeader3.Text = "Code";
                this.columnHeader3.Width = 38;
                // 
                // columnHeader7
                // 
                this.columnHeader7.Text = "Memo";
                this.columnHeader7.Width = 120;
                // 
                // columnHeader9
                // 
                this.columnHeader9.Text = "Basis";
                this.columnHeader9.Width = 39;
                // 
                // columnHeader10
                // 
                this.columnHeader10.Text = "% Off";
                this.columnHeader10.Width = 41;
                // 
                // columnHeader11
                // 
                this.columnHeader11.Text = "Amount";
                this.columnHeader11.Width = 49;
                // 
                // columnHeader1
                // 
                this.columnHeader1.Text = "Type";
                // 
                // columnHeader2
                // 
                this.columnHeader2.Text = "From";
                this.columnHeader2.Width = 70;
                // 
                // columnHeader4
                // 
                this.columnHeader4.Text = "To";
                this.columnHeader4.Width = 70;
                // 
                // groupBox2
                // 
                this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox2.Controls.Add(this.groupBox4);
                this.groupBox2.Controls.Add(this.txtRoomId);
                this.groupBox2.Controls.Add(this.label38);
                this.groupBox2.Controls.Add(this.groupBox3);
                this.groupBox2.Controls.Add(this.txtGroupName);
                this.groupBox2.Controls.Add(this.label16);
                this.groupBox2.Controls.Add(this.txtGuestName);
                this.groupBox2.Controls.Add(this.label14);
                this.groupBox2.Controls.Add(this.txtFolioId);
                this.groupBox2.Controls.Add(this.label5);
                this.groupBox2.Location = new System.Drawing.Point(12, 12);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(729, 200);
                this.groupBox2.TabIndex = 39;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "Folio Information";
                // 
                // groupBox4
                // 
                this.groupBox4.Controls.Add(this.txtAllFolioRunningBalance);
                this.groupBox4.Controls.Add(this.txtAllFolioOutstandingBalance);
                this.groupBox4.Controls.Add(this.label39);
                this.groupBox4.Controls.Add(this.label40);
                this.groupBox4.Location = new System.Drawing.Point(202, 109);
                this.groupBox4.Name = "groupBox4";
                this.groupBox4.Size = new System.Drawing.Size(177, 80);
                this.groupBox4.TabIndex = 47;
                this.groupBox4.TabStop = false;
                this.groupBox4.Text = "All Balance";
                // 
                // txtAllFolioRunningBalance
                // 
                this.txtAllFolioRunningBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtAllFolioRunningBalance.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtAllFolioRunningBalance.Location = new System.Drawing.Point(87, 50);
                this.txtAllFolioRunningBalance.Name = "txtAllFolioRunningBalance";
                this.txtAllFolioRunningBalance.ReadOnly = true;
                this.txtAllFolioRunningBalance.Size = new System.Drawing.Size(81, 20);
                this.txtAllFolioRunningBalance.TabIndex = 49;
                this.txtAllFolioRunningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtAllFolioOutstandingBalance
                // 
                this.txtAllFolioOutstandingBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtAllFolioOutstandingBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtAllFolioOutstandingBalance.Location = new System.Drawing.Point(87, 24);
                this.txtAllFolioOutstandingBalance.Name = "txtAllFolioOutstandingBalance";
                this.txtAllFolioOutstandingBalance.ReadOnly = true;
                this.txtAllFolioOutstandingBalance.Size = new System.Drawing.Size(81, 20);
                this.txtAllFolioOutstandingBalance.TabIndex = 48;
                this.txtAllFolioOutstandingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label39
                // 
                this.label39.BackColor = System.Drawing.SystemColors.Control;
                this.label39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label39.ForeColor = System.Drawing.Color.Black;
                this.label39.Location = new System.Drawing.Point(13, 25);
                this.label39.Name = "label39";
                this.label39.Size = new System.Drawing.Size(75, 18);
                this.label39.TabIndex = 123;
                this.label39.Text = "Outstanding";
                // 
                // label40
                // 
                this.label40.BackColor = System.Drawing.SystemColors.Control;
                this.label40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label40.ForeColor = System.Drawing.Color.Black;
                this.label40.Location = new System.Drawing.Point(13, 52);
                this.label40.Name = "label40";
                this.label40.Size = new System.Drawing.Size(75, 16);
                this.label40.TabIndex = 121;
                this.label40.Text = "Running";
                // 
                // txtRoomId
                // 
                this.txtRoomId.BackColor = System.Drawing.SystemColors.Control;
                this.txtRoomId.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtRoomId.Location = new System.Drawing.Point(114, 26);
                this.txtRoomId.Name = "txtRoomId";
                this.txtRoomId.ReadOnly = true;
                this.txtRoomId.Size = new System.Drawing.Size(76, 20);
                this.txtRoomId.TabIndex = 40;
                // 
                // label38
                // 
                this.label38.BackColor = System.Drawing.SystemColors.Control;
                this.label38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label38.ForeColor = System.Drawing.Color.Black;
                this.label38.Location = new System.Drawing.Point(21, 28);
                this.label38.Name = "label38";
                this.label38.Size = new System.Drawing.Size(75, 16);
                this.label38.TabIndex = 126;
                this.label38.Text = "Room No.";
                // 
                // groupBox3
                // 
                this.groupBox3.Controls.Add(this.txtCurrentFolioRunningBalance);
                this.groupBox3.Controls.Add(this.txtCurrentFolioOutstandingBalance);
                this.groupBox3.Controls.Add(this.label37);
                this.groupBox3.Controls.Add(this.label21);
                this.groupBox3.Location = new System.Drawing.Point(10, 109);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(177, 80);
                this.groupBox3.TabIndex = 44;
                this.groupBox3.TabStop = false;
                this.groupBox3.Text = "Current Balance";
                // 
                // txtCurrentFolioRunningBalance
                // 
                this.txtCurrentFolioRunningBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtCurrentFolioRunningBalance.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtCurrentFolioRunningBalance.Location = new System.Drawing.Point(86, 50);
                this.txtCurrentFolioRunningBalance.Name = "txtCurrentFolioRunningBalance";
                this.txtCurrentFolioRunningBalance.ReadOnly = true;
                this.txtCurrentFolioRunningBalance.Size = new System.Drawing.Size(81, 20);
                this.txtCurrentFolioRunningBalance.TabIndex = 46;
                this.txtCurrentFolioRunningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtCurrentFolioOutstandingBalance
                // 
                this.txtCurrentFolioOutstandingBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtCurrentFolioOutstandingBalance.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtCurrentFolioOutstandingBalance.Location = new System.Drawing.Point(86, 24);
                this.txtCurrentFolioOutstandingBalance.Name = "txtCurrentFolioOutstandingBalance";
                this.txtCurrentFolioOutstandingBalance.ReadOnly = true;
                this.txtCurrentFolioOutstandingBalance.Size = new System.Drawing.Size(81, 20);
                this.txtCurrentFolioOutstandingBalance.TabIndex = 45;
                this.txtCurrentFolioOutstandingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label37
                // 
                this.label37.BackColor = System.Drawing.SystemColors.Control;
                this.label37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label37.ForeColor = System.Drawing.Color.Black;
                this.label37.Location = new System.Drawing.Point(17, 25);
                this.label37.Name = "label37";
                this.label37.Size = new System.Drawing.Size(68, 18);
                this.label37.TabIndex = 123;
                this.label37.Text = "Outstanding";
                // 
                // label21
                // 
                this.label21.BackColor = System.Drawing.SystemColors.Control;
                this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label21.ForeColor = System.Drawing.Color.Black;
                this.label21.Location = new System.Drawing.Point(17, 52);
                this.label21.Name = "label21";
                this.label21.Size = new System.Drawing.Size(68, 16);
                this.label21.TabIndex = 121;
                this.label21.Text = "Running";
                // 
                // txtGroupName
                // 
                this.txtGroupName.BackColor = System.Drawing.SystemColors.Control;
                this.txtGroupName.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtGroupName.Location = new System.Drawing.Point(114, 74);
                this.txtGroupName.Name = "txtGroupName";
                this.txtGroupName.ReadOnly = true;
                this.txtGroupName.Size = new System.Drawing.Size(265, 20);
                this.txtGroupName.TabIndex = 43;
                // 
                // label16
                // 
                this.label16.BackColor = System.Drawing.SystemColors.Control;
                this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label16.ForeColor = System.Drawing.Color.Black;
                this.label16.Location = new System.Drawing.Point(19, 76);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(75, 16);
                this.label16.TabIndex = 120;
                this.label16.Text = "Group Name :";
                // 
                // txtGuestName
                // 
                this.txtGuestName.BackColor = System.Drawing.SystemColors.Control;
                this.txtGuestName.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtGuestName.Location = new System.Drawing.Point(114, 50);
                this.txtGuestName.Name = "txtGuestName";
                this.txtGuestName.ReadOnly = true;
                this.txtGuestName.Size = new System.Drawing.Size(265, 20);
                this.txtGuestName.TabIndex = 42;
                // 
                // label14
                // 
                this.label14.BackColor = System.Drawing.SystemColors.Control;
                this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label14.ForeColor = System.Drawing.Color.Black;
                this.label14.Location = new System.Drawing.Point(19, 52);
                this.label14.Name = "label14";
                this.label14.Size = new System.Drawing.Size(75, 16);
                this.label14.TabIndex = 116;
                this.label14.Text = "Guest Name :";
                // 
                // txtFolioId
                // 
                this.txtFolioId.BackColor = System.Drawing.SystemColors.Control;
                this.txtFolioId.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtFolioId.Location = new System.Drawing.Point(268, 25);
                this.txtFolioId.Name = "txtFolioId";
                this.txtFolioId.ReadOnly = true;
                this.txtFolioId.Size = new System.Drawing.Size(111, 20);
                this.txtFolioId.TabIndex = 41;
                // 
                // label5
                // 
                this.label5.BackColor = System.Drawing.SystemColors.Control;
                this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label5.ForeColor = System.Drawing.Color.Black;
                this.label5.Location = new System.Drawing.Point(197, 28);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(65, 16);
                this.label5.TabIndex = 114;
                this.label5.Text = "Control No :";
                // 
                // grbPayment
                // 
                this.grbPayment.Controls.Add(this.flowLayoutPanel1);
                this.grbPayment.Location = new System.Drawing.Point(476, 220);
                this.grbPayment.Name = "grbPayment";
                this.grbPayment.Size = new System.Drawing.Size(265, 402);
                this.grbPayment.TabIndex = 20;
                this.grbPayment.TabStop = false;
                this.grbPayment.Text = "Payment";
                // 
                // flowLayoutPanel1
                // 
                this.flowLayoutPanel1.Controls.Add(this.pnlPaymentType);
                this.flowLayoutPanel1.Controls.Add(this.pnlPaymentSubAccount);
                this.flowLayoutPanel1.Controls.Add(this.pnlOrNo);
                this.flowLayoutPanel1.Controls.Add(this.pnlPaymentTransSource);
                this.flowLayoutPanel1.Controls.Add(this.pnlAmount);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardNo);
                this.flowLayoutPanel1.Controls.Add(this.pnlChequeNo);
                this.flowLayoutPanel1.Controls.Add(this.pnlAccount);
                this.flowLayoutPanel1.Controls.Add(this.pnlBank);
                this.flowLayoutPanel1.Controls.Add(this.pnlDate);
                this.flowLayoutPanel1.Controls.Add(this.pnlGrantedBy);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardType);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardApproval);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardExpires);
                this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 18);
                this.flowLayoutPanel1.Name = "flowLayoutPanel1";
                this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 331);
                this.flowLayoutPanel1.TabIndex = 20;
                // 
                // pnlPaymentType
                // 
                this.pnlPaymentType.Controls.Add(this.label34);
                this.pnlPaymentType.Controls.Add(this.cboPaymentTypes);
                this.pnlPaymentType.Location = new System.Drawing.Point(3, 3);
                this.pnlPaymentType.Name = "pnlPaymentType";
                this.pnlPaymentType.Size = new System.Drawing.Size(244, 27);
                this.pnlPaymentType.TabIndex = 21;
                this.pnlPaymentType.Visible = false;
                // 
                // label34
                // 
                this.label34.BackColor = System.Drawing.SystemColors.Control;
                this.label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label34.ForeColor = System.Drawing.Color.Black;
                this.label34.Location = new System.Drawing.Point(2, 6);
                this.label34.Name = "label34";
                this.label34.Size = new System.Drawing.Size(71, 16);
                this.label34.TabIndex = 146;
                this.label34.Text = "Type";
                // 
                // cboPaymentTypes
                // 
                this.cboPaymentTypes.BackColor = System.Drawing.Color.White;
                this.cboPaymentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboPaymentTypes.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboPaymentTypes.Location = new System.Drawing.Point(87, 2);
                this.cboPaymentTypes.Name = "cboPaymentTypes";
                this.cboPaymentTypes.Size = new System.Drawing.Size(156, 22);
                this.cboPaymentTypes.TabIndex = 21;
                this.cboPaymentTypes.SelectedIndexChanged += new System.EventHandler(this.cboPaymentTypes_SelectedIndexChanged);
                // 
                // pnlPaymentSubAccount
                // 
                this.pnlPaymentSubAccount.Controls.Add(this.label36);
                this.pnlPaymentSubAccount.Controls.Add(this.cboPaymentSubAccount);
                this.pnlPaymentSubAccount.Location = new System.Drawing.Point(3, 36);
                this.pnlPaymentSubAccount.Name = "pnlPaymentSubAccount";
                this.pnlPaymentSubAccount.Size = new System.Drawing.Size(244, 27);
                this.pnlPaymentSubAccount.TabIndex = 34;
                this.pnlPaymentSubAccount.Visible = false;
                // 
                // label36
                // 
                this.label36.BackColor = System.Drawing.SystemColors.Control;
                this.label36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label36.ForeColor = System.Drawing.Color.Black;
                this.label36.Location = new System.Drawing.Point(2, 5);
                this.label36.Name = "label36";
                this.label36.Size = new System.Drawing.Size(71, 16);
                this.label36.TabIndex = 144;
                this.label36.Text = "Sub Account";
                // 
                // cboPaymentSubAccount
                // 
                this.cboPaymentSubAccount.BackColor = System.Drawing.Color.White;
                this.cboPaymentSubAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboPaymentSubAccount.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboPaymentSubAccount.Location = new System.Drawing.Point(87, 2);
                this.cboPaymentSubAccount.Name = "cboPaymentSubAccount";
                this.cboPaymentSubAccount.Size = new System.Drawing.Size(156, 22);
                this.cboPaymentSubAccount.TabIndex = 6;
                // 
                // pnlOrNo
                // 
                this.pnlOrNo.Controls.Add(this.txtPayment_ORNo);
                this.pnlOrNo.Controls.Add(this.lblPayment_DocSource);
                this.pnlOrNo.Location = new System.Drawing.Point(3, 69);
                this.pnlOrNo.Name = "pnlOrNo";
                this.pnlOrNo.Size = new System.Drawing.Size(244, 27);
                this.pnlOrNo.TabIndex = 22;
                this.pnlOrNo.Visible = false;
                // 
                // txtPayment_ORNo
                // 
                this.txtPayment_ORNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_ORNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_ORNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_ORNo.Location = new System.Drawing.Point(87, 3);
                this.txtPayment_ORNo.MaxLength = 100;
                this.txtPayment_ORNo.Name = "txtPayment_ORNo";
                this.txtPayment_ORNo.Size = new System.Drawing.Size(154, 20);
                this.txtPayment_ORNo.TabIndex = 22;
                this.txtPayment_ORNo.TextChanged += new System.EventHandler(this.txtNetBaseAmount_TextChanged);
                this.txtPayment_ORNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayment_ORNo_KeyPress);
                // 
                // lblPayment_DocSource
                // 
                this.lblPayment_DocSource.BackColor = System.Drawing.SystemColors.Control;
                this.lblPayment_DocSource.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblPayment_DocSource.ForeColor = System.Drawing.Color.Black;
                this.lblPayment_DocSource.Location = new System.Drawing.Point(3, 6);
                this.lblPayment_DocSource.Name = "lblPayment_DocSource";
                this.lblPayment_DocSource.Size = new System.Drawing.Size(74, 16);
                this.lblPayment_DocSource.TabIndex = 130;
                this.lblPayment_DocSource.Text = "Ref. No. :";
                // 
                // pnlPaymentTransSource
                // 
                this.pnlPaymentTransSource.Controls.Add(this.cboPaymentTransSource);
                this.pnlPaymentTransSource.Controls.Add(this.label23);
                this.pnlPaymentTransSource.Location = new System.Drawing.Point(3, 102);
                this.pnlPaymentTransSource.Name = "pnlPaymentTransSource";
                this.pnlPaymentTransSource.Size = new System.Drawing.Size(244, 27);
                this.pnlPaymentTransSource.TabIndex = 23;
                this.pnlPaymentTransSource.Visible = false;
                // 
                // cboPaymentTransSource
                // 
                this.cboPaymentTransSource.BackColor = System.Drawing.Color.White;
                this.cboPaymentTransSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboPaymentTransSource.Items.AddRange(new object[] {
            "ORDER SLIP",
            "CHARGE INVOICE",
            "SALES INVOICE"});
                this.cboPaymentTransSource.Location = new System.Drawing.Point(87, 4);
                this.cboPaymentTransSource.Name = "cboPaymentTransSource";
                this.cboPaymentTransSource.Size = new System.Drawing.Size(154, 22);
                this.cboPaymentTransSource.TabIndex = 23;
                this.cboPaymentTransSource.SelectedIndexChanged += new System.EventHandler(this.cboPaymentTransSource_SelectedIndexChanged);
                // 
                // label23
                // 
                this.label23.BackColor = System.Drawing.SystemColors.Control;
                this.label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label23.ForeColor = System.Drawing.Color.Black;
                this.label23.Location = new System.Drawing.Point(3, 6);
                this.label23.Name = "label23";
                this.label23.Size = new System.Drawing.Size(77, 16);
                this.label23.TabIndex = 124;
                this.label23.Text = "Source :";
                // 
                // pnlAmount
                // 
                this.pnlAmount.Controls.Add(this.txtPayment_Amount);
                this.pnlAmount.Controls.Add(this.label28);
                this.pnlAmount.Location = new System.Drawing.Point(3, 135);
                this.pnlAmount.Name = "pnlAmount";
                this.pnlAmount.Size = new System.Drawing.Size(244, 27);
                this.pnlAmount.TabIndex = 24;
                this.pnlAmount.Visible = false;
                // 
                // txtPayment_Amount
                // 
                this.txtPayment_Amount.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Amount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Amount.Location = new System.Drawing.Point(87, 5);
                this.txtPayment_Amount.MaxLength = 15;
                this.txtPayment_Amount.Name = "txtPayment_Amount";
                this.txtPayment_Amount.Size = new System.Drawing.Size(106, 20);
                this.txtPayment_Amount.TabIndex = 24;
                this.txtPayment_Amount.Text = "0.00";
                this.txtPayment_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtPayment_Amount.TextChanged += new System.EventHandler(this.txtNetBaseAmount_TextChanged);
                this.txtPayment_Amount.Leave += new System.EventHandler(this.txtPayment_Amount_Leave);
                this.txtPayment_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayment_Amount_KeyPress);
                // 
                // label28
                // 
                this.label28.BackColor = System.Drawing.SystemColors.Control;
                this.label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label28.ForeColor = System.Drawing.Color.Black;
                this.label28.Location = new System.Drawing.Point(3, 7);
                this.label28.Name = "label28";
                this.label28.Size = new System.Drawing.Size(74, 16);
                this.label28.TabIndex = 132;
                this.label28.Text = "Amount :";
                // 
                // pnlCardNo
                // 
                this.pnlCardNo.Controls.Add(this.txtPayment_CardNo);
                this.pnlCardNo.Controls.Add(this.label22);
                this.pnlCardNo.Location = new System.Drawing.Point(3, 168);
                this.pnlCardNo.Name = "pnlCardNo";
                this.pnlCardNo.Size = new System.Drawing.Size(244, 27);
                this.pnlCardNo.TabIndex = 25;
                this.pnlCardNo.Visible = false;
                // 
                // txtPayment_CardNo
                // 
                this.txtPayment_CardNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_CardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_CardNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_CardNo.Location = new System.Drawing.Point(87, 4);
                this.txtPayment_CardNo.MaxLength = 16;
                this.txtPayment_CardNo.Name = "txtPayment_CardNo";
                this.txtPayment_CardNo.Size = new System.Drawing.Size(154, 20);
                this.txtPayment_CardNo.TabIndex = 25;
                // 
                // label22
                // 
                this.label22.BackColor = System.Drawing.SystemColors.Control;
                this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label22.ForeColor = System.Drawing.Color.Black;
                this.label22.Location = new System.Drawing.Point(3, 7);
                this.label22.Name = "label22";
                this.label22.Size = new System.Drawing.Size(74, 16);
                this.label22.TabIndex = 114;
                this.label22.Text = "Card # :";
                // 
                // pnlChequeNo
                // 
                this.pnlChequeNo.Controls.Add(this.txtPayment_Cheque);
                this.pnlChequeNo.Controls.Add(this.label24);
                this.pnlChequeNo.Location = new System.Drawing.Point(3, 201);
                this.pnlChequeNo.Name = "pnlChequeNo";
                this.pnlChequeNo.Size = new System.Drawing.Size(244, 27);
                this.pnlChequeNo.TabIndex = 26;
                this.pnlChequeNo.Visible = false;
                // 
                // txtPayment_Cheque
                // 
                this.txtPayment_Cheque.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Cheque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Cheque.Location = new System.Drawing.Point(87, 4);
                this.txtPayment_Cheque.MaxLength = 100;
                this.txtPayment_Cheque.Name = "txtPayment_Cheque";
                this.txtPayment_Cheque.Size = new System.Drawing.Size(154, 20);
                this.txtPayment_Cheque.TabIndex = 26;
                // 
                // label24
                // 
                this.label24.BackColor = System.Drawing.SystemColors.Control;
                this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label24.ForeColor = System.Drawing.Color.Black;
                this.label24.Location = new System.Drawing.Point(3, 7);
                this.label24.Name = "label24";
                this.label24.Size = new System.Drawing.Size(74, 16);
                this.label24.TabIndex = 122;
                this.label24.Text = "Cheque # :";
                // 
                // pnlAccount
                // 
                this.pnlAccount.Controls.Add(this.txtPayment_Account);
                this.pnlAccount.Controls.Add(this.label26);
                this.pnlAccount.Location = new System.Drawing.Point(3, 234);
                this.pnlAccount.Name = "pnlAccount";
                this.pnlAccount.Size = new System.Drawing.Size(244, 27);
                this.pnlAccount.TabIndex = 27;
                this.pnlAccount.Visible = false;
                // 
                // txtPayment_Account
                // 
                this.txtPayment_Account.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Account.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Account.Location = new System.Drawing.Point(87, 3);
                this.txtPayment_Account.MaxLength = 100;
                this.txtPayment_Account.Name = "txtPayment_Account";
                this.txtPayment_Account.Size = new System.Drawing.Size(154, 20);
                this.txtPayment_Account.TabIndex = 27;
                // 
                // label26
                // 
                this.label26.BackColor = System.Drawing.SystemColors.Control;
                this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label26.ForeColor = System.Drawing.Color.Black;
                this.label26.Location = new System.Drawing.Point(3, 7);
                this.label26.Name = "label26";
                this.label26.Size = new System.Drawing.Size(74, 16);
                this.label26.TabIndex = 126;
                this.label26.Text = "Account :";
                // 
                // pnlBank
                // 
                this.pnlBank.Controls.Add(this.txtPayment_Bank);
                this.pnlBank.Controls.Add(this.label27);
                this.pnlBank.Location = new System.Drawing.Point(3, 267);
                this.pnlBank.Name = "pnlBank";
                this.pnlBank.Size = new System.Drawing.Size(244, 27);
                this.pnlBank.TabIndex = 28;
                this.pnlBank.Visible = false;
                // 
                // txtPayment_Bank
                // 
                this.txtPayment_Bank.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Bank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Bank.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Bank.Location = new System.Drawing.Point(87, 4);
                this.txtPayment_Bank.MaxLength = 100;
                this.txtPayment_Bank.Name = "txtPayment_Bank";
                this.txtPayment_Bank.Size = new System.Drawing.Size(154, 20);
                this.txtPayment_Bank.TabIndex = 28;
                // 
                // label27
                // 
                this.label27.BackColor = System.Drawing.SystemColors.Control;
                this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label27.ForeColor = System.Drawing.Color.Black;
                this.label27.Location = new System.Drawing.Point(3, 7);
                this.label27.Name = "label27";
                this.label27.Size = new System.Drawing.Size(74, 16);
                this.label27.TabIndex = 128;
                this.label27.Text = "Bank :";
                // 
                // pnlDate
                // 
                this.pnlDate.Controls.Add(this.dtpPayment_Date);
                this.pnlDate.Controls.Add(this.label25);
                this.pnlDate.Location = new System.Drawing.Point(3, 300);
                this.pnlDate.Name = "pnlDate";
                this.pnlDate.Size = new System.Drawing.Size(244, 27);
                this.pnlDate.TabIndex = 29;
                this.pnlDate.Visible = false;
                // 
                // dtpPayment_Date
                // 
                this.dtpPayment_Date.CalendarMonthBackground = System.Drawing.Color.White;
                this.dtpPayment_Date.CalendarTitleForeColor = System.Drawing.Color.White;
                this.dtpPayment_Date.CustomFormat = "MMM. dd, yyyy";
                this.dtpPayment_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                this.dtpPayment_Date.Location = new System.Drawing.Point(87, 3);
                this.dtpPayment_Date.Name = "dtpPayment_Date";
                this.dtpPayment_Date.Size = new System.Drawing.Size(82, 20);
                this.dtpPayment_Date.TabIndex = 29;
                // 
                // label25
                // 
                this.label25.BackColor = System.Drawing.SystemColors.Control;
                this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label25.ForeColor = System.Drawing.Color.Black;
                this.label25.Location = new System.Drawing.Point(3, 6);
                this.label25.Name = "label25";
                this.label25.Size = new System.Drawing.Size(77, 16);
                this.label25.TabIndex = 124;
                this.label25.Text = "Cheque Date :";
                // 
                // pnlGrantedBy
                // 
                this.pnlGrantedBy.Controls.Add(this.txtGrantedBy);
                this.pnlGrantedBy.Controls.Add(this.label29);
                this.pnlGrantedBy.Location = new System.Drawing.Point(3, 333);
                this.pnlGrantedBy.Name = "pnlGrantedBy";
                this.pnlGrantedBy.Size = new System.Drawing.Size(244, 27);
                this.pnlGrantedBy.TabIndex = 30;
                this.pnlGrantedBy.Visible = false;
                // 
                // txtGrantedBy
                // 
                this.txtGrantedBy.BackColor = System.Drawing.SystemColors.Info;
                this.txtGrantedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtGrantedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtGrantedBy.Location = new System.Drawing.Point(87, 3);
                this.txtGrantedBy.MaxLength = 100;
                this.txtGrantedBy.Name = "txtGrantedBy";
                this.txtGrantedBy.Size = new System.Drawing.Size(154, 20);
                this.txtGrantedBy.TabIndex = 30;
                // 
                // label29
                // 
                this.label29.BackColor = System.Drawing.SystemColors.Control;
                this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label29.ForeColor = System.Drawing.Color.Black;
                this.label29.Location = new System.Drawing.Point(3, 6);
                this.label29.Name = "label29";
                this.label29.Size = new System.Drawing.Size(77, 16);
                this.label29.TabIndex = 124;
                this.label29.Text = "Granted by :";
                // 
                // pnlCardType
                // 
                this.pnlCardType.Controls.Add(this.txtCardType);
                this.pnlCardType.Controls.Add(this.label30);
                this.pnlCardType.Location = new System.Drawing.Point(3, 366);
                this.pnlCardType.Name = "pnlCardType";
                this.pnlCardType.Size = new System.Drawing.Size(244, 27);
                this.pnlCardType.TabIndex = 31;
                this.pnlCardType.Visible = false;
                // 
                // txtCardType
                // 
                this.txtCardType.AutoCompleteCustomSource.AddRange(new string[] {
            "VISA",
            "MASTERCARD",
            "AMERICAN EXPRESS",
            "DINERS CLUB",
            "JCB",
            "CARTE BLANCHE",
            "AUSTRALIAN BANKCARD",
            "DISCOVER",
            "SWITCH",
            "SOLO",
            "ENROUTE"});
                this.txtCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                this.txtCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                this.txtCardType.BackColor = System.Drawing.SystemColors.Info;
                this.txtCardType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtCardType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtCardType.Location = new System.Drawing.Point(87, 3);
                this.txtCardType.MaxLength = 100;
                this.txtCardType.Name = "txtCardType";
                this.txtCardType.Size = new System.Drawing.Size(154, 20);
                this.txtCardType.TabIndex = 30;
                // 
                // label30
                // 
                this.label30.BackColor = System.Drawing.SystemColors.Control;
                this.label30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label30.ForeColor = System.Drawing.Color.Black;
                this.label30.Location = new System.Drawing.Point(3, 6);
                this.label30.Name = "label30";
                this.label30.Size = new System.Drawing.Size(77, 16);
                this.label30.TabIndex = 124;
                this.label30.Text = "Card Type :";
                // 
                // pnlCardApproval
                // 
                this.pnlCardApproval.Controls.Add(this.txtCardApproval);
                this.pnlCardApproval.Controls.Add(this.label32);
                this.pnlCardApproval.Location = new System.Drawing.Point(3, 399);
                this.pnlCardApproval.Name = "pnlCardApproval";
                this.pnlCardApproval.Size = new System.Drawing.Size(244, 27);
                this.pnlCardApproval.TabIndex = 32;
                this.pnlCardApproval.Visible = false;
                // 
                // txtCardApproval
                // 
                this.txtCardApproval.BackColor = System.Drawing.SystemColors.Info;
                this.txtCardApproval.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtCardApproval.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtCardApproval.Location = new System.Drawing.Point(87, 3);
                this.txtCardApproval.MaxLength = 100;
                this.txtCardApproval.Name = "txtCardApproval";
                this.txtCardApproval.Size = new System.Drawing.Size(154, 20);
                this.txtCardApproval.TabIndex = 32;
                // 
                // label32
                // 
                this.label32.BackColor = System.Drawing.SystemColors.Control;
                this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label32.ForeColor = System.Drawing.Color.Black;
                this.label32.Location = new System.Drawing.Point(1, 6);
                this.label32.Name = "label32";
                this.label32.Size = new System.Drawing.Size(84, 16);
                this.label32.TabIndex = 124;
                this.label32.Text = "Approval/Slip #:";
                // 
                // pnlCardExpires
                // 
                this.pnlCardExpires.Controls.Add(this.dtpCardExpires);
                this.pnlCardExpires.Controls.Add(this.label31);
                this.pnlCardExpires.Location = new System.Drawing.Point(3, 432);
                this.pnlCardExpires.Name = "pnlCardExpires";
                this.pnlCardExpires.Size = new System.Drawing.Size(244, 27);
                this.pnlCardExpires.TabIndex = 33;
                this.pnlCardExpires.Visible = false;
                // 
                // dtpCardExpires
                // 
                this.dtpCardExpires.CalendarMonthBackground = System.Drawing.Color.White;
                this.dtpCardExpires.CalendarTitleForeColor = System.Drawing.Color.White;
                this.dtpCardExpires.CustomFormat = "MMM. dd, yyyy";
                this.dtpCardExpires.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                this.dtpCardExpires.Location = new System.Drawing.Point(87, 3);
                this.dtpCardExpires.Name = "dtpCardExpires";
                this.dtpCardExpires.Size = new System.Drawing.Size(82, 20);
                this.dtpCardExpires.TabIndex = 33;
                this.dtpCardExpires.Value = new System.DateTime(2008, 7, 2, 0, 0, 0, 0);
                // 
                // label31
                // 
                this.label31.BackColor = System.Drawing.SystemColors.Control;
                this.label31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label31.ForeColor = System.Drawing.Color.Black;
                this.label31.Location = new System.Drawing.Point(3, 6);
                this.label31.Name = "label31";
                this.label31.Size = new System.Drawing.Size(77, 16);
                this.label31.TabIndex = 124;
                this.label31.Text = "Expires :";
                // 
                // AddTransactionUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(752, 647);
                this.Controls.Add(this.btnOk);
                this.Controls.Add(this.btnCancel);
                this.Controls.Add(this.grbPayment);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.grbPrivileges);
                this.Controls.Add(this.GroupBox1);
                this.Controls.Add(this.lvwCodes);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "AddTransactionUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Add Transaction";
                this.Load += new System.EventHandler(this.AddTransactionUI_Load);
                this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddTransactionUI_KeyPress);
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.pnlSubAccount.ResumeLayout(false);
                this.grbPrivileges.ResumeLayout(false);
                this.groupBox2.ResumeLayout(false);
                this.groupBox2.PerformLayout();
                this.groupBox4.ResumeLayout(false);
                this.groupBox4.PerformLayout();
                this.groupBox3.ResumeLayout(false);
                this.groupBox3.PerformLayout();
                this.grbPayment.ResumeLayout(false);
                this.flowLayoutPanel1.ResumeLayout(false);
                this.pnlPaymentType.ResumeLayout(false);
                this.pnlPaymentSubAccount.ResumeLayout(false);
                this.pnlOrNo.ResumeLayout(false);
                this.pnlOrNo.PerformLayout();
                this.pnlPaymentTransSource.ResumeLayout(false);
                this.pnlAmount.ResumeLayout(false);
                this.pnlAmount.PerformLayout();
                this.pnlCardNo.ResumeLayout(false);
                this.pnlCardNo.PerformLayout();
                this.pnlChequeNo.ResumeLayout(false);
                this.pnlChequeNo.PerformLayout();
                this.pnlAccount.ResumeLayout(false);
                this.pnlAccount.PerformLayout();
                this.pnlBank.ResumeLayout(false);
                this.pnlBank.PerformLayout();
                this.pnlDate.ResumeLayout(false);
                this.pnlGrantedBy.ResumeLayout(false);
                this.pnlGrantedBy.PerformLayout();
                this.pnlCardType.ResumeLayout(false);
                this.pnlCardType.PerformLayout();
                this.pnlCardApproval.ResumeLayout(false);
                this.pnlCardApproval.PerformLayout();
                this.pnlCardExpires.ResumeLayout(false);
                this.ResumeLayout(false);

			}

			#endregion

            string _decimalFormat = ConfigVariables.gDecimalFormat;

            private void AddTransactionUI_Load(object sender, System.EventArgs e)
            {
                IList<TransactionSourceDocument> _oTransactionSourceList = new List<TransactionSourceDocument>();

                TransactionSourceDocumentFacade _oTransactionSourceFacade = new TransactionSourceDocumentFacade();

                _oTransactionSourceList = _oTransactionSourceFacade.getTransactionSourceDocuments();
                TransactionSourceDocument[] _oTransactionSourcePaymentList = new TransactionSourceDocument[_oTransactionSourceList.Count];
                _oTransactionSourceList.CopyTo(_oTransactionSourcePaymentList, 0);

                this.cboTransSource.DataSource = _oTransactionSourceList;
                this.cboTransSource.DisplayMember = "Abbreviation";

                this.cboPaymentTransSource.DataSource = _oTransactionSourcePaymentList;
                this.cboPaymentTransSource.DisplayMember = "Abbreviation";

                txtGovTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(LockTextBox);
                txtLocalTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(LockTextBox);
                //txtServiceCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(LockTextBox);
                this.cboTransSource.SelectedIndex = 0;

                this.dtpTransactionDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);

                //check if user is allowed to post on previous days
                bool _allowPreviousDatePosting = false;
                bool.TryParse(ConfigVariables.gAllowPreviousDatePosting, out _allowPreviousDatePosting);

                dtpTransactionDate.Enabled = _allowPreviousDatePosting;

                // to focus on TRANSACTION CODE TEXT BOX
                SendKeys.Send("\t");
                //SendKeys.Send("\t");

                //added for inserting transactions with roomid
                this.cboRoomID.DataSource = loFolio.Schedule;
                this.cboRoomID.DisplayMember = "RoomID" + " - " + "FromDate";
                this.cboRoomID.ValueMember = "RoomID";
            }

            private string _additionalMemo = "";
			private void btnOk_Click(System.Object sender, System.EventArgs e)
			            {
				try
				{
                    _additionalMemo = "";
					// this is to trace all folio transactions
                    if (ConfigVariables.gCashieringEnabled == "true")
                    {
                        if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
                        {
                            MessageBox.Show("No Shift/Cash drawer open.\r\nCan't proceed transaction.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
					// checks CREDIT CARD field
					if (this.pnlCardNo.Visible)
					{
						if (this.txtPayment_CardNo.Text.Trim().Length <= 0)
						{
							this.txtPayment_CardNo.Focus();
							return;
						}
					}
					if (this.pnlCardType.Visible)
					{
						if (this.txtCardType.Text.Trim().Length <= 0)
						{
							this.txtCardType.Focus();
							return;
						}
                        _additionalMemo += " " + txtCardType.Text;
					}

					if (this.pnlCardApproval.Visible)
					{
						if (this.txtCardApproval.Text.Trim().Length <= 0)
						{
							this.txtCardApproval.Focus();
							return;
						}
                        _additionalMemo += " SL #" + txtCardApproval.Text;
					}

					if (this.pnlCardExpires.Visible)
					{
						long diff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(GlobalVariables.gAuditDate), this.dtpCardExpires.Value);

						if (diff < 0)
						{
							this.dtpCardExpires.Focus();
							return;
						}
					}

                    // checks BANK NAME field
                    if (this.pnlBank.Visible)
                    {
                        if (this.txtPayment_Bank.Text.Trim().Length <= 0)
                        {
                            this.txtPayment_Bank.Focus();
                            return;
                        }
                        _additionalMemo += " " + txtPayment_Bank.Text;
                    }
                    
                    // checks if CHEQUE NO Field
					if (this.pnlChequeNo.Visible)
					{
						if (this.txtPayment_Cheque.Text.Trim().Length <= 0)
						{
							this.txtPayment_Cheque.Focus();
							return;
						}
                        _additionalMemo += " #" + txtPayment_Cheque.Text;
					}
					// checks ACCOUNT NO field
					if (this.pnlAccount.Visible)
					{
						if (this.txtPayment_Account.Text.Trim().Length <= 0)
						{
							this.txtPayment_Account.Focus();
							return;
						}
					}

					// checks for GRANTED BY field
					if (this.pnlGrantedBy.Visible)
					{
						if (this.txtGrantedBy.Text.Trim().Length <= 0)
						{
							this.txtGrantedBy.Focus();
							return;
						}
					}


					if (this.txtReferenceNo.Text.Trim().Length <= 0)
					{
						this.txtReferenceNo.Focus();
						return;
					}


					bool _exemptedRefNo = isExemptedReferenceNo(this.txtReferenceNo.Text);

					//bool _exNoOr = this.txtReferenceNo.Text.ToUpper().Contains("NO OR");
					//bool _exNoOs = this.txtReferenceNo.Text.ToUpper().Contains("NO OS");
					//bool _exAutoPost = this.txtReferenceNo.Text.ToUpper().Contains("AUTO-POST");
					//bool _exAutoPost1 =this.txtReferenceNo.Text.ToUpper().Contains("AUTO POST");
					//_exemptedRefNo = _exNoOr || _exAutoPost || _exAutoPost1 || _exNoOs;

					if (!_exemptedRefNo)
					{
						FolioTransactionFacade _oFolioTranFacade = new FolioTransactionFacade();
						if (txtReferenceNo.Text != "AUTO" && _oFolioTranFacade.RefNoIfExist(this.cboTransSource.Text, this.txtReferenceNo.Text))
						{
							MessageBox.Show("Ref # " + this.txtReferenceNo.Text + " for this transaction source already exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							this.txtReferenceNo.Focus();
							return;
						}

						if (this.txtPayment_ORNo.Text.Trim().Length > 0 && txtPayment_ORNo.Text != "AUTO")
						{
							if (_oFolioTranFacade.RefNoIfExist(cboPaymentTransSource.Text, this.txtPayment_ORNo.Text) || (cboPaymentTransSource.Text == cboTransSource.Text && txtPayment_ORNo.Text == txtReferenceNo.Text))
							{
								MessageBox.Show("Ref # " + this.txtPayment_ORNo.Text + " for this type of transaction is already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								this.txtPayment_ORNo.Focus();
								return;
							}
						}
					}


					// check if reference no is valid (one referenceNo per transaction)
					string _refNoStr = this.txtReferenceNo.Text.Trim();
					string _tranCodeStr = this.txtTransactionCode.Text.Trim();

					//if (invalidReferenceNo(_refNoStr, _tranCodeStr))
					//{

					insertFolioTransaction();
					lAmountPaid = System.Convert.ToDecimal(this.txtBaseAmount.Text);
					//}
					//else
					//{
					//    MessageBox.Show("Duplicate reference number detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//}


				}
				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			private bool isExemptedReferenceNo(string pRefNo)
			{
				string[] exemptedRefNo = { "NO OR", "NO OS", "AUTO-POST", "AUTO POST", "AUTO" };

				foreach (string str in exemptedRefNo)
				{
					if (str == pRefNo.ToUpper())
					{
						return true;
					}
				}

				return false;
			}


			//private bool invalidReferenceNo(string pRefNoStr, string pTranCodeStr)
			//{
			//    return true;
			//}

			private void txtCurAmount_TextChanged(System.Object sender, System.EventArgs e)
			{
				ComputeBaseAmount();
			}

			#region " M E T H O D S "

			private Folio loFolio = new Folio();
			private ListView lListviewA = new ListView();
			private ListView lListviewB = new ListView();
			private ListView lListviewC = new ListView();
			private ListView lListviewD = new ListView();

			// >> Constructor for AddFolioTrans in FOLIO LEDGERS from payments
			private System.Windows.Forms.Control lControl;
			private string lMode;
			private string lTranCode;
			private decimal lAmount;
			private decimal lAmountPaid;
			//private string subFolioTab;
			public AddTransactionUI(Folio poFolio, Control pControl, string pSubFolio, string pMode)
			{
				InitializeComponent();
				loFolio = poFolio;
				lControl = pControl;

				lMode = pMode;
				LoadTransactionCodes();
				loadTransactionCodeSubAccount();
				LoadCurrencyCodes();

				this.cboSubFolio.Text = pSubFolio;
				this.txtFolioId.Text = loFolio.FolioID;
				if (poFolio.FolioType == "GROUP")
				{
					this.cboSubFolio.Items.Clear();
					this.cboSubFolio.Items.Add("A");
					this.cboSubFolio.Text = "A";
				}

				decimal _balance = 0;
				try
				{
					_balance += loFolio.SubFolios.Item(0).Ledger.BalanceNet;
					_balance += loFolio.SubFolios.Item(1).Ledger.BalanceNet;
					_balance += loFolio.SubFolios.Item(2).Ledger.BalanceNet;
					_balance += loFolio.SubFolios.Item(3).Ledger.BalanceNet;
				}
				catch
				{ }

				//get current room occupied
				try
				{
                    //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                    //used a constant parameter to avoid possible error/dependencies, no time to check
					string _roomNo = loFolioFacade.GetCurrentRoomOccupied(loFolio.FolioID, "INDIVIDUAL");

					this.txtRoomId.Text = _roomNo;
				}
				catch
				{
					this.txtRoomId.Text = "";
				}

				this.txtAllFolioOutstandingBalance.Text = _balance.ToString(_decimalFormat);
				this.txtAllFolioRunningBalance.Text = _balance.ToString(_decimalFormat);

				GuestFacade _oGuestFacade = new GuestFacade();
				Guest _oGuest = _oGuestFacade.getGuestRecord(loFolio.AccountID);


				CompanyFacade _oCompanyFacade = new CompanyFacade();
				Company _oCompany = _oCompanyFacade.getCompanyAccount(loFolio.CompanyID);

                if (poFolio.FolioType == "GROUP" && poFolio.CompanyID.StartsWith("G"))
                {
                    this.txtGuestName.Text = _oCompany.CompanyName;
                    this.txtGroupName.Text = loFolio.GroupName;
                }
                else if (poFolio.FolioType == "GROUP" && !poFolio.CompanyID.StartsWith("G"))
                {
                    _oGuest = _oGuestFacade.getGuestRecord(poFolio.CompanyID);
                    this.txtGuestName.Text = _oGuest.LastName + ", " + _oGuest.FirstName;
                    this.txtGroupName.Text = loFolio.GroupName;
                }
                else if (poFolio.FolioType == "DEPENDENT")
                {
                    this.txtGuestName.Text = _oGuest.LastName + ", " + _oGuest.FirstName;
                    this.txtGroupName.Text = loFolio.GroupName;
                }
                else
                {
                    this.txtGuestName.Text = _oGuest.LastName + ", " + _oGuest.FirstName;
                    this.txtGroupName.Text = _oCompany.CompanyName;
                }

				this.lvwPrivileges.Items.Clear();
				foreach (Privilege _privilege in loFolio.Privileges)
				{
					ListViewItem _lvwItem = new ListViewItem(_privilege.TransactionCode);
					_lvwItem.SubItems.Add(_privilege.Memo);
					_lvwItem.SubItems.Add(_privilege.Basis);
					_lvwItem.SubItems.Add(_privilege.Percentoff.ToString(_decimalFormat));
					_lvwItem.SubItems.Add(_privilege.AmountOff.ToString(_decimalFormat));
					_lvwItem.SubItems.Add("Privilege");


					this.lvwPrivileges.Items.Add(_lvwItem);
				}

				foreach (FolioPackage _privilege in loFolio.Package)
				{
					ListViewItem _lvwItem = new ListViewItem(_privilege.TransactionCode);
					_lvwItem.SubItems.Add(_privilege.Memo);
					_lvwItem.SubItems.Add(_privilege.Basis);
					_lvwItem.SubItems.Add(_privilege.PercentOff.ToString(_decimalFormat));
					_lvwItem.SubItems.Add(_privilege.AmountOff.ToString(_decimalFormat));
					_lvwItem.SubItems.Add("Promo");
                    _lvwItem.SubItems.Add(_privilege.DateFrom.ToString("dd-MMM-yy"));
                    _lvwItem.SubItems.Add(_privilege.DateTo.ToString("dd-MMM-yy"));

					this.lvwPrivileges.Items.Add(_lvwItem);
				}

			}

			public AddTransactionUI(MySqlConnection poConnection, Folio poFolio, Control pControl, string pMode, string pTCode, decimal pAmount)
			{
				InitializeComponent();
				loFolio = poFolio;
				lControl = pControl;
				lMode = pMode;
				LoadTransactionCodes();
				loadTransactionCodeSubAccount();
				LoadCurrencyCodes();
				lTranCode = pTCode;
				lAmount = pAmount;

				//for group types
				if (poFolio.FolioType == "GROUP")
				{
					this.cboSubFolio.Items.Clear();
					this.cboSubFolio.Items.Add("A");
					this.cboSubFolio.Text = "A";
				}

				this.txtTransactionCode.Text = lTranCode;
				this.txtCurAmount.Text = lAmount.ToString();
				this.txtTransactionCode_KeyPress(txtTransactionCode, new KeyPressEventArgs('\r'));

			}

			public decimal AmtPaid
			{
				get
				{
					return lAmountPaid;
				}

			}

			private CurrencyCode loCurrencyCode = new CurrencyCode();
			private CurrencyCodeFacade loCurrencyCodeFacade = new CurrencyCodeFacade();
			public void LoadCurrencyCodes()
			{
				loCurrencyCode = new CurrencyCode();
				loCurrencyCodeFacade = new CurrencyCodeFacade();
				loCurrencyCode = (CurrencyCode)loCurrencyCodeFacade.loadObject();

				ArrayList[] _arrList = new ArrayList[2];
				_arrList[0] = new ArrayList();
				_arrList[1] = new ArrayList();

				DataRow _dataRow;
				foreach (DataRow _tempLoopVar_dt in loCurrencyCode.Tables[0].Rows)
				{
					_dataRow = _tempLoopVar_dt;
					_arrList[0].Add(_dataRow["CurrencyCode"]);
					_arrList[1].Add(_dataRow["ConversionRate"]);
				}

				this.cboCurrencyCode.DataSource = _arrList[0];
				this.cboCurrencyRate.DataSource = _arrList[1];

			}

			private TransactionCode loTransactionCode = new TransactionCode();
			private TransactionCodeFacade loTransactionCodeFacade;
			private DataTable lPaymentTypes = new DataTable();
			public void LoadTransactionCodes()
			{
				loTransactionCode = new TransactionCode();
				loTransactionCodeFacade = new TransactionCodeFacade();

				loTransactionCode = (TransactionCode)loTransactionCodeFacade.loadObject();

				DataTable _dtTemp = loTransactionCode.Tables[0];


				foreach (DataRow _dRow in _dtTemp.Rows)
				{
                    //jumps to next loop if contingency
                    if (_dRow["TranCode"].ToString() == ConfigVariables.gContingencyCode)
                    {
                        continue;
                    }

					ListViewItem _listViewItem = new ListViewItem(_dRow["TranCode"].ToString());    

					_listViewItem.SubItems.Add(_dRow["Memo"].ToString());
					_listViewItem.SubItems.Add(_dRow["AcctSide"].ToString());
					_listViewItem.SubItems.Add(double.Parse(_dRow["ServiceCharge"].ToString()).ToString(_decimalFormat));
					_listViewItem.SubItems.Add(double.Parse(_dRow["GovtTax"].ToString()).ToString(_decimalFormat));
					_listViewItem.SubItems.Add(double.Parse(_dRow["LocalTax"].ToString()).ToString(_decimalFormat));

					_listViewItem.SubItems.Add(_dRow["ServiceChargeInclusive"].ToString());
					_listViewItem.SubItems.Add(_dRow["GovtTaxInclusive"].ToString());
					_listViewItem.SubItems.Add(_dRow["LocalTaxInclusive"].ToString());
					_listViewItem.SubItems.Add(_dRow["defaultTransactionSource"].ToString());

					if (lMode.ToUpper() == "PAYMENTS")
					{
						this.Text = "PAYMENTS";
						if ((_dRow["AcctSide"].ToString().ToUpper() == "CREDIT" || _dRow["Memo"].ToString().ToUpper() == "REFUND") && _dRow["TranCode"].ToString().ToUpper() != "4100")
						{
							this.lvwCodes.Items.Add(_listViewItem);
						}
					}
					else if (lMode.ToUpper() == "CHARGES")
					{
						this.Text = "CHARGES";
						if ((_dRow["AcctSide"].ToString().ToUpper() == "DEBIT") &&
							_dRow["TranCode"].ToString().ToUpper() != "3300" && // refund
							_dRow["TranCode"].ToString().ToUpper() != "6000") // paid out
						{
							this.lvwCodes.Items.Add(_listViewItem);
						}
					}
                        //>> to not display transfer debit and paid outs
                    else if (_dRow["TranCode"].ToString() != "4100" && _dRow["TranCode"].ToString() != "6000")
                    {
                        this.Text = "ADD TRANSACTION";
                        this.lvwCodes.Items.Add(_listViewItem);
                    }
                    //else
                    //{
                    //    this.Text = "ADD FOLIO TRANSACTION";
                    //    this.lvwCodes.Items.Add(_listViewItem);
                    //}


					//this.mnuVoid.Enabled = false;
					//this.btnVoid.Enabled = false;
					//string _debitMemo = ConfigVariables.gDebitMemo;
					//string _creditMemo = ConfigVariables.gCreditMemo;

					//if (_listViewItem.Text == _debitMemo || _listViewItem.Text == _creditMemo )
					//{
					//    User _oUser = new User();
					//    _oUser = (User)GlobalVariables.goUser;

					//    foreach (Role _oRole in _oUser.Roles)
					//    {
					//        if (_oRole.RoleName.ToUpper() == "ACCOUNTING")
					//        {
					//            return;
					//        }
					//    }

					//    this.lvwCodes.Items.Remove(_listViewItem);
					//}



				}

			}

			private TransactionCode_SubAccountFacade loTransactionCode_SubAccountFacade;
			private IList<TransactionCode_SubAccount> lSubAccountsList;
			public void loadTransactionCodeSubAccount()
			{
				try
				{
					loTransactionCode_SubAccountFacade = new TransactionCode_SubAccountFacade();

					lSubAccountsList = loTransactionCode_SubAccountFacade.loadTransactionCodeSubAccounts();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			private void loadPaymentTypes()
			{
				//this.cboPaymentTypes.DataSource = null;
				lPaymentTypes = new DataTable();

				lPaymentTypes = loTransactionCode.Tables[0];

				DataView _dtView = lPaymentTypes.DefaultView;
				_dtView.RowStateFilter = DataViewRowState.OriginalRows;

				_dtView.RowFilter = "tranTypeId = '2' or tranTypeId = '3' or tranTypeId = '4' or tranTypeId = '5' or (tranCode = '7" + this.txtTransactionCode.Text + "')";


				//// setup combobox payment type
				//lPaymentTypes.Columns.Add("TransactionCode", typeof(System.String));
				//lPaymentTypes.Columns.Add("Memo", typeof(System.String));
				//DataRow newRow = lPaymentTypes.NewRow();
				//newRow["TransactionCode"] = "2000";
				//newRow["Memo"] = "CASH";
				//this.lPaymentTypes.Rows.Add(newRow);
				//newRow = lPaymentTypes.NewRow();
				//newRow["TransactionCode"] = "2100";
				//newRow["Memo"] = "CREDIT CARD";
				//this.lPaymentTypes.Rows.Add(newRow);

				//newRow = lPaymentTypes.NewRow();
				//newRow["TransactionCode"] = "2200";
				//newRow["Memo"] = "CHEQUE";
				//this.lPaymentTypes.Rows.Add(newRow);

				//newRow = lPaymentTypes.NewRow();
				//newRow["TransactionCode"] = "2201";
				//newRow["Memo"] = "GIFT CHEQUE";
				//this.lPaymentTypes.Rows.Add(newRow);

				this.cboPaymentTypes.DataSource = lPaymentTypes;
				this.cboPaymentTypes.DisplayMember = "Memo";
				this.cboPaymentTypes.ValueMember = "tranCode";
			}

			private bool isFormReady()
			{

				if (this.txtTransactionCode.Text.Trim().Length == 0)
				{
					MessageBox.Show("Please select transaction code.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.txtTransactionCode.Focus();
					return false;
				}

				if (this.txtMemo.Text.Trim().Length == 0)
				{
					MessageBox.Show("Please input description of transaction.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.txtMemo.Focus();
					return false;

				}
				if (this.txtCurAmount.Text.Trim().Length == 0)
				{
					MessageBox.Show("Please input amount.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.txtCurAmount.Focus();
					return false;
				}

				if (double.Parse(this.txtCurAmount.Text.Trim()) <= 0)
				{
					MessageBox.Show("Please input amount.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.txtCurAmount.Focus();
					return false;
				}

				// checks CREDIT CARD field
				if (this.pnlCardNo.Visible)
				{
					if (this.txtPayment_CardNo.Text.Trim().Length <= 0)
					{
						this.txtPayment_CardNo.Focus();
						return false;
					}
				}

				if (this.pnlCardType.Visible)
				{
					if (this.txtCardType.Text.Trim().Length <= 0)
					{
						this.txtCardType.Focus();
						return false;
					}
				}

				if (this.pnlCardApproval.Visible)
				{
					if (this.txtCardApproval.Text.Trim().Length <= 0)
					{
						this.txtCardApproval.Focus();
						return false;
					}
				}

				if (this.pnlCardExpires.Visible)
				{
					long diff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(GlobalVariables.gAuditDate), this.dtpCardExpires.Value);

					if (diff < 0)
					{
						this.dtpCardExpires.Focus();
						return false;
					}
				}

				// checks if CHEQUE NO Field
				if (this.pnlChequeNo.Visible)
				{
					if (this.txtPayment_Cheque.Text.Trim().Length <= 0)
					{
						this.txtPayment_Cheque.Focus();
						return false;
					}
				}
				// checks ACCOUNT NO field
				if (this.pnlAccount.Visible)
				{
					if (this.txtPayment_Account.Text.Trim().Length <= 0)
					{
						this.txtPayment_Account.Focus();
						return false;
					}
				}
				// checks BANK NAME field
				if (this.pnlBank.Visible)
				{
					if (this.txtPayment_Bank.Text.Trim().Length <= 0)
					{
						this.txtPayment_Bank.Focus();
						return false;
					}
				}

				// checks for GRANTED BY field
				if (this.pnlGrantedBy.Visible)
				{
					if (this.txtGrantedBy.Text.Trim().Length <= 0)
					{
						this.txtGrantedBy.Focus();
						return false;
					}
				}

				if (this.txtReferenceNo.Text.Trim().Length <= 0)
				{
					this.txtReferenceNo.Focus();
					return false;
				}


				return true;
			}

			private FolioFacade loFolioFacade = new FolioFacade();
			private FolioTransaction loFolioTransaction;
			private FolioTransactionFacade loFolioTransactionFacade;
			private FolioTransactions loFolioTransCollection;
			private TransactionCode loTranCode;

			private void insertFolioTransaction()
			{
				if (!isFormReady())
				{
					return;
				}

				loFolioTransCollection = new FolioTransactions();
				loFolioTransaction = new FolioTransaction();
				loTranCode = new TransactionCode();

				AssignFolioTransValues(loFolioTransaction);

				loFolioFacade = new FolioFacade();
				//if (this.chkApplyPackage.CheckState == CheckState.Checked)
				//{
				//    //oFolioFacade.ApplyFolioPackage(oFolioTransaction, oTranCode, Me.txtBaseAmount.Text)
				//    ApplyPackage(loFolioTransaction.FolioID, loFolioTransaction);
				//}

				if (this.chkAppyRouting.CheckState == CheckState.Checked)
				{
					//oFolioTransCollection = oFolioFacade.ApplyFolioRouting(oFolioTransaction, oFolio)
					ApplyRouting(loFolioTransaction.FolioID, loFolioTransaction);
				}

				// NO NEED to apply discount since already Applied while encoding transaction
				////if (this.chkApplyPrivileges.CheckState == CheckState.Checked)
				////{
				////    //' Apply Folio Privilege here''
				////    //oFolioFacade.ApplyFolioPrivileges(oFolioTransaction, oFolioTransCollection, oTranCode)
				////    //ApplyPrivileges(loFolioTransaction);
				////}



				if (loFolioTransCollection.Count <= 0)
				{
					loFolioTransCollection.Add(loFolioTransaction);
				}

				// FOR PAYMENT --------------------------------------------
				if (this.cboAcctSide.Text == "DEBIT")
				{
					decimal amountPaid = 0;
					try
					{
						switch (this.cboPaymentTypes.SelectedValue.ToString())
						{
							case "2100": // if credit card
							case "2800": // if gift cheque
								amountPaid = decimal.Parse(this.txtBaseAmount.Text);
								break;

							default:
								amountPaid = decimal.Parse(this.txtPayment_Amount.Text);
								break;
						}
					}
					catch
					{ }

					int _ORLength = this.txtPayment_ORNo.Text.Trim().Length;

					if (_ORLength == 0 && amountPaid > 0)
					{
						this.txtPayment_ORNo.Focus();
						return;
					}

					if (_ORLength > 0 && amountPaid == 0 && this.pnlAmount.Visible)
					{
						this.txtPayment_Amount.Focus();
						return;
					}


					if (amountPaid > 0)
					{

						FolioTransaction _oPaymentFolioTrans = new FolioTransaction();
						AssignFolioTransValuesPayment(_oPaymentFolioTrans);

						// assign subfolio to payment transaction
						if (loFolioTransCollection.Count > 0)
						{
							_oPaymentFolioTrans.SubFolio = loFolioTransCollection.Item(0).SubFolio;
						}
						else
						{
							_oPaymentFolioTrans.SubFolio = loFolioTransaction.SubFolio;

						}

						loFolioTransCollection.Add(_oPaymentFolioTrans);

					}
				}

				// > saves in database

				MySqlTransaction _myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
				loFolioTransactionFacade = new FolioTransactionFacade();

				if (loFolioTransactionFacade.InsertFolioTransaction(loFolioTransCollection, ref _myTransaction))
				{

					//// trap if POSTED ROOM CHARGE
					//// if so, set PostedFlag = 1 on RoomEvents table
					////bool hasRoomChargeTrans = false;
                    foreach (FolioTransaction oFolioTrans in loFolioTransCollection)
                    {
                        if (oFolioTrans.TransactionCode == "1000" && oFolioTrans.AcctSide == "DEBIT" && oFolioTrans.AdjustmentFlag == "0")
                        {
                            try
                            {

                                RoomEventFacade oRoomEventFacade = new RoomEventFacade();
                                oRoomEventFacade.setRoomEventPosted(oFolioTrans.FolioID, this.txtRoomId.Text, oFolioTrans.TransactionDate, ref _myTransaction);

                            }
                            catch { }

                            break;
                        }
                    }

					_myTransaction.Commit();


					// SET Folio Status to desired status after PAYMENT
					if (loTranCode.TranTypeId == "2" ||
						loTranCode.TranTypeId == "3" ||
						loTranCode.TranTypeId == "4" ||
						loTranCode.TranTypeId == "5" ||
						(loTranCode.TranCode == "3100" && this.cboAcctSide.Text == "CREDIT") ||
						(loTranCode.TranCode == "4000" && this.cboAcctSide.Text == "CREDIT") 
					   )
					{
						string _configVarStatus = ConfigVariables.gNewReservationStatusAfterPayment;

						if (_configVarStatus != "")
						{
							if (loFolio.Status == "CONFIRMED" || loFolio.Status == "TENTATIVE")
							{
								if (_configVarStatus != loFolio.Status)
								{
									//update folio status after payment
									switch (_configVarStatus)
									{
										case "CONFIRMED":
											MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

											try
											{
                                                //KEVIN L. Oliveros
                                                loFolioFacade.setReferencNo(loFolio.FolioID, loFolio.FromDate.Month, loFolio.FromDate.Year, GlobalVariables.gHotelId);
												loFolioFacade.confirmFolio(loFolio.FolioID, ref trans);
												trans.Commit();

												MessageBox.Show("Folio status is now Confirmed.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
											}
											catch
											{
												trans.Rollback();
											}

											break;
										default:

											MessageBox.Show("Error updating folio status.\r\nConfig Variable for gNewReservationStatusAfterPayment = '" + _configVarStatus + "' is not supported.\r\n\r\nPlease contact system administrator.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
											break;
									}

								}
							}
						}
					}
					
				}
				else
				{
					_myTransaction.Rollback();
				}

				// this IS TO REFRESH the CALLING-FORM after successful insert
				// of transaction
				if (lControl != null)
				{
					if (lControl.Text == "")
					{
						string temp = lControl.Text;
						lControl.Text = "FILLER";
						lControl.Text = temp;
					}
					else
					{
						string temp = lControl.Text;
						lControl.Text = "";
						lControl.Text = temp;
					}
				}

				this.Hide();

			}


			private void  AssignFolioTransValues(FolioTransaction poFolioTransaction)
			{
				string _strTransactionCode = this.txtTransactionCode.Text;
				TransactionCode _oTranCode;
				_oTranCode = loTransactionCodeFacade.getTransactionCode(_strTransactionCode);

				loTranCode = _oTranCode;

				// set mealAmount if ROOM CHARGE
				decimal _mealAmount = 0;
				// to get Folio Information(esp No. Of Pax, VatExempt)
				//oFolioFacade = new FolioFacade();
				//oFolio = oFolioFacade.GetFolio(oFolio.FolioID);

				if (_oTranCode.TranCode == "1000" && cboAcctSide.Text == cboAcctSide.Tag.ToString())
				{

					// get Schedule Info(esp rate type and breakfast component
					ScheduleFacade oScheduleFacade = new ScheduleFacade();
					Schedule oSched = oScheduleFacade.GetSchedule(loFolio.FolioID);

					RateTypeFacade oRateTypeFacade = new RateTypeFacade();
					RateType oMyRate = oRateTypeFacade.getRateType(oSched.RoomType, oSched.RateType);

					if (oMyRate != null)
					{
						if (oSched.BreakFast == "Y" && chkAdjustment.Checked != true)
						{
							_mealAmount = oMyRate.BreakfastAmount;

							// multiply by number of Pax
							if (loFolio.NoofAdults > 1)
							{

								_mealAmount = _mealAmount * loFolio.NoofAdults;

							}
						}
					}


				}
				// end mealAmount

				bool _inclusiveGovTax = true;
				bool _inclusiveLocalTax = true;
				bool _inclusiveServiceCharge = true;

				decimal _govtTaxPercent = 0;
				decimal _localTaxPercent = 0;
				decimal _serviceChargePercent = 0;

				decimal _govtTaxAmount = 0;
				decimal _localTaxAmount = 0;
				decimal _serviceChargeAmount = 0;


				poFolioTransaction.HotelID = GlobalVariables.gHotelId;
				poFolioTransaction.TransactionDate = this.dtpTransactionDate.Value;
				poFolioTransaction.FolioID = loFolio.FolioID;
				poFolioTransaction.SubFolio = this.cboSubFolio.Text;
                if (loFolio.FolioType == "GROUP")
                {
                    poFolioTransaction.AccountID = loFolio.CompanyID;
                }
                else
                {
                    poFolioTransaction.AccountID = loFolio.AccountID;
                }

				poFolioTransaction.TransactionCode = _strTransactionCode;
				if (this.txtReferenceNo.Text != "AUTO")
				{
					poFolioTransaction.ReferenceNo = this.txtReferenceNo.Text;
				}
				else
				{
					Sequence _oSequence = new Sequence();
                    //comment if statements if generic auto-sequencing
                    string _refNo = _oSequence.GetSequenceLongId("seq_autopost", _strTransactionCode).ToString();
                    if (_refNo == "")
                    {
                        poFolioTransaction.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
                    }
                    else
                    {
                        poFolioTransaction.ReferenceNo = _refNo;
                    }
				}

				TransactionSourceDocument transSourc = (TransactionSourceDocument)this.cboTransSource.SelectedItem;
				poFolioTransaction.TransactionSource = transSourc.Abbreviation;

				poFolioTransaction.Memo = this.txtMemo.Text;
				if (this.pnlSubAccount.Visible)
				{
					poFolioTransaction.Memo += " - " + this.cboSubAccount.Text;
				}
                if (cboAcctSide.Text == "CREDIT" && grbPayment.Enabled == true)
                {
                    poFolioTransaction.Memo += _additionalMemo;
                }

				poFolioTransaction.AcctSide = this.cboAcctSide.Text;
				poFolioTransaction.CurrencyCode = this.cboCurrencyCode.Text;
				poFolioTransaction.ConversionRate = decimal.Parse(this.cboCurrencyRate.Text);
				poFolioTransaction.CurrencyAmount = decimal.Parse(this.txtCurAmount.Text);

				poFolioTransaction.Discount = decimal.Parse(this.txtDiscountAmount.Text);

				// BaseAmount = Currency Amount * Exchange Rate
				decimal _baseAmount = poFolioTransaction.CurrencyAmount * poFolioTransaction.ConversionRate;

				poFolioTransaction.BaseAmount = _baseAmount;
				poFolioTransaction.GrossAmount = decimal.Parse(this.txtBaseAmount.Text);


				// deduct discount b4 applying Tax & Service Charge
				_baseAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount;



				//// if has SubAccount use SubAccount settings for Govt Tax
				//// else use TransactionCode settings for Govt Tax
                if (lSubAccountSelected == null)
                {
                    _inclusiveGovTax = _oTranCode.GovtTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = _oTranCode.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = _oTranCode.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = _oTranCode.GovtTax / 100;
                    _localTaxPercent = _oTranCode.LocalTax / 100;
                    //_serviceChargePercent = _oTranCode.ServiceCharge / 100;
                    if (_inclusiveServiceCharge == false)
                        _serviceChargePercent = decimal.Parse(txtServiceCharge.Text) / 100;
                    else
                        _serviceChargePercent = _oTranCode.ServiceCharge / 100;

                }
                else
                {
                    _inclusiveGovTax = lSubAccountSelected.GovernmentTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = lSubAccountSelected.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = lSubAccountSelected.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = lSubAccountSelected.GovernmentTax / 100;
                    _localTaxPercent = lSubAccountSelected.LocalTax / 100;
                    //_serviceChargePercent = lSubAccountSelected.ServiceCharge / 100;
                    if (_inclusiveServiceCharge == false)
                        _serviceChargePercent = decimal.Parse(txtServiceCharge.Text) / 100;
                    else
                        _serviceChargePercent = lSubAccountSelected.ServiceCharge / 100;
                }

				//>> get Total Inclusive Charges
				decimal _totalInclusive = 0;
				if (_inclusiveGovTax)
				{
					_totalInclusive += _govtTaxPercent;
				}

				if (_inclusiveLocalTax)
				{
					_totalInclusive += _localTaxPercent;
				}

				if (_inclusiveServiceCharge)
				{
					_totalInclusive += _serviceChargePercent;
				}
				//>> end get Total Inclusive Charges

				decimal _amountAfterDeductInclusiveCharges = _baseAmount / (1 + _totalInclusive);


                //>> compute Service Charge
                if (_serviceChargePercent > 0)
                {
                    if (_inclusiveServiceCharge)
                    {
                        _serviceChargeAmount = _amountAfterDeductInclusiveCharges * _serviceChargePercent;
                    }
                    else
                    {
                        _serviceChargeAmount = poFolioTransaction.BaseAmount * _serviceChargePercent;
                    }
                }
                //>> end compute Service Charge
                
                //>> compute Government Tax
				if (_govtTaxPercent > 0)
				{
					if (_inclusiveGovTax)
					{
						_govtTaxAmount = _amountAfterDeductInclusiveCharges * _govtTaxPercent;
					}
					else
					{
                        //_govtTaxAmount = _baseAmount * _govtTaxPercent;
                        _govtTaxAmount = (poFolioTransaction.BaseAmount + _serviceChargeAmount - poFolioTransaction.Discount) * _govtTaxPercent;
					}
				}
				//>> end compute Government Tax

				//>> compute Local Tax
				if (_localTaxPercent > 0)
				{
					if (_inclusiveLocalTax)
					{
						_localTaxAmount = _amountAfterDeductInclusiveCharges * _localTaxPercent;
					}
					else
					{
                        //_localTaxAmount = _baseAmount * _localTaxPercent;
                        _localTaxAmount = (poFolioTransaction.BaseAmount + _serviceChargeAmount - poFolioTransaction.Discount) * _localTaxPercent;
					}
				}
				//>> end compute Local Tax

				poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

				poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;

				poFolioTransaction.NetBaseAmount = _amountAfterDeductInclusiveCharges;
				poFolioTransaction.GovernmentTax = _govtTaxAmount;
				poFolioTransaction.LocalTax = _localTaxAmount;
				poFolioTransaction.ServiceCharge = _serviceChargeAmount;

				poFolioTransaction.GovernmentTaxInclusive = _inclusiveGovTax == true ? 1 : 0;
				poFolioTransaction.LocalTaxInclusive = _inclusiveLocalTax == true ? 1 : 0;
				poFolioTransaction.ServiceChargeInclusive = _inclusiveServiceCharge == true ? 1 : 0;

				// deduct Meal Amount on NetBaseAmount if folio has meal
				poFolioTransaction.MealAmount = _mealAmount;
				poFolioTransaction.NetBaseAmount -= poFolioTransaction.MealAmount;

				poFolioTransaction.RouteSequence = "";
				poFolioTransaction.SourceFolio = "";
				poFolioTransaction.SourceSubFolio = "";
				poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
				poFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;

				// new, Jrom, April 26, 2008
				// Golden prince requirement

				poFolioTransaction.CreditCardNo = this.txtPayment_CardNo.Text;
				poFolioTransaction.ChequeNo = this.txtPayment_Cheque.Text;
				poFolioTransaction.AccountName = this.txtPayment_Account.Text;
				poFolioTransaction.BankName = this.txtPayment_Bank.Text;
				poFolioTransaction.ChequeDate = string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
				poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

				poFolioTransaction.CreditCardType = this.txtCardType.Text;
				poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
				poFolioTransaction.SubAccount = this.cboSubAccount.Text;
				poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);

                //for adjustments
                if (chkAdjustment.Checked == true)
                {
                    poFolioTransaction.AdjustmentFlag = "1";
                }
                else
                {
                    poFolioTransaction.AdjustmentFlag = "0";
                }

                //added for transactions by room number
                poFolioTransaction.RoomID = cboRoomID.Text;
			}


			private void AssignFolioTransValuesPayment(FolioTransaction poFolioTransaction)
			{
				string _selectedTranCode = this.cboPaymentTypes.SelectedValue.ToString();
				string _memo = this.cboPaymentTypes.Text + " - " + this.cboPaymentSubAccount.Text;

				TransactionSourceDocument _oPaymentTransSource = (TransactionSourceDocument)this.cboPaymentTransSource.SelectedValue;


				decimal _amount = 0;
				if (this.pnlAmount.Visible)
				{

					_amount = decimal.Parse(this.txtPayment_Amount.Text);
				}
				else
				{
					_amount = decimal.Parse(this.txtBaseAmount.Text);
				}

				string _strTransactionCode = _selectedTranCode;
				TransactionCode _oTranCode;
				_oTranCode = loTransactionCodeFacade.getTransactionCode(_strTransactionCode);

				poFolioTransaction.HotelID = GlobalVariables.gHotelId;
				poFolioTransaction.FolioID = loFolio.FolioID;
				poFolioTransaction.SubFolio = this.cboSubFolio.Text;
				poFolioTransaction.AccountID = loFolio.AccountID;
				poFolioTransaction.TransactionDate = this.dtpTransactionDate.Value;
				poFolioTransaction.PostingDate = DateTime.Now;
				poFolioTransaction.TransactionCode = _selectedTranCode;
                poFolioTransaction.SubAccount = this.cboPaymentSubAccount.Text;
                if (this.txtPayment_ORNo.Text != "AUTO")
                {
                    poFolioTransaction.ReferenceNo = this.txtPayment_ORNo.Text;
                }
                else
                {
                    Sequence _oSequence = new Sequence();
                    //comment if statements if generic auto-sequencing
                    string _refNo = _oSequence.GetSequenceLongId("seq_autopost", _strTransactionCode).ToString();
                    if (_refNo == "")
                    {
                        poFolioTransaction.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
                    }
                    else
                    {
                        poFolioTransaction.ReferenceNo = _refNo;
                    }
                }
				poFolioTransaction.TransactionSource = _oPaymentTransSource.Abbreviation;
                poFolioTransaction.Memo = _memo + " " + cboPaymentSubAccount.Text + _additionalMemo;
				poFolioTransaction.AcctSide = "CREDIT";
				poFolioTransaction.CurrencyCode = "PHP";
				poFolioTransaction.ConversionRate = 1;
				poFolioTransaction.CurrencyAmount = _amount;
				poFolioTransaction.BaseAmount = _amount;
				poFolioTransaction.GrossAmount = _amount;
				poFolioTransaction.Discount = 0;

				poFolioTransaction.ServiceCharge = 0;
				poFolioTransaction.ServiceChargeInclusive = 0;
				poFolioTransaction.GovernmentTax = 0;
				poFolioTransaction.GovernmentTaxInclusive = 0;
				poFolioTransaction.LocalTax = 0;
				poFolioTransaction.LocalTaxInclusive = 0;

				poFolioTransaction.NetBaseAmount = _amount;
				poFolioTransaction.NetAmount = _amount;
				poFolioTransaction.CreditCardNo = this.txtPayment_CardNo.Text;
				poFolioTransaction.ChequeNo = this.txtPayment_Cheque.Text;
				poFolioTransaction.AccountName = this.txtPayment_Account.Text;
				poFolioTransaction.BankName = this.txtPayment_Bank.Text;
				poFolioTransaction.ChequeDate = string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
				poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;
				poFolioTransaction.CreditCardType = this.txtCardType.Text;
				poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
				poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);

				poFolioTransaction.RouteSequence = "";
				poFolioTransaction.SourceFolio = "";
				poFolioTransaction.SourceSubFolio = "";
				poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
				poFolioTransaction.ShiftCode = GlobalVariables.gShiftCode.ToString();
				poFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;

                //for adjustments
                poFolioTransaction.AdjustmentFlag = "0";
			}


			// >> APPLY PACKAGE
			//Private oFolioFacade As FolioFacade
			private FolioPackage loPackage;
			private void ApplyPackage(string pFolioId, FolioTransaction poFolioTrans)
			{
				bool _inclusiveGovTax = true;
				bool _inclusiveLocalTax = true;
				bool _inclusiveServiceCharge = true;


				try
				{
					loFolioFacade = new FolioFacade();
					loPackage = new FolioPackage();
					loPackage = loFolioFacade.GetFolioTransPackage(pFolioId, poFolioTrans.TransactionCode);

					if (loPackage == null)
						return;

					FolioTransaction _oFolioTransaction = poFolioTrans;
					//_oFolioTransaction.BaseAmount = decimal.Parse(this.txtBaseAmount.Text);

					if (loPackage.Basis == "A")
					{
						poFolioTrans.Discount += loPackage.AmountOff;
					}
					else
					{
						poFolioTrans.Discount += _oFolioTransaction.NetAmount * (loPackage.PercentOff / 100);
					}

					string _strTransactionCode = poFolioTrans.TransactionCode;
					TransactionCode _oTranCode;
					_oTranCode = loTransactionCodeFacade.getTransactionCode(_strTransactionCode);


					// BaseAmount = Currency Amount * Exchange Rate
					decimal _baseAmount = poFolioTrans.BaseAmount;

					poFolioTrans.BaseAmount = _baseAmount;
					poFolioTrans.GrossAmount = poFolioTrans.GrossAmount;


					// deduct discount b4 applying Tax & Service Charge
					_baseAmount = _baseAmount - poFolioTrans.Discount;

					// compute Government Tax here (Inclusive or Exclusive)
					// if has SubAccount use SubAccount settings for Govt Tax
					// else use TransactionCode settings for Govt Tax
					if (lSubAccountSelected != null)
					{
						if (lSubAccountSelected.GovernmentTax > 0)
						{
							decimal _govTaxPercent = (decimal)lSubAccountSelected.GovernmentTax;

							decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, lSubAccountSelected.GovernmentTaxInclusive);
							poFolioTrans.GovernmentTax = _govTaxAmount;

							if (lSubAccountSelected.GovernmentTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _govTaxAmount;

								_inclusiveGovTax = false;
							}
						}
						else
						{
							poFolioTrans.GovernmentTax = 0;
						}
					}
					else
					{
						if (_oTranCode.GovtTax > 0)
						{
							decimal _govTaxPercent = _oTranCode.GovtTax;

							decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, _oTranCode.GovtTaxInclusive);
							poFolioTrans.GovernmentTax = _govTaxAmount;

							if (_oTranCode.GovtTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _govTaxAmount;

								_inclusiveGovTax = false;
							}
						}
						else
						{
							poFolioTrans.GovernmentTax = 0;
						}

					}


					// compute Local Tax here (Inclusive or Exclusive)
					// if has SubAccount use SubAccount settings for Govt Tax
					// else use TransactionCode settings for Local Tax
					if (lSubAccountSelected != null)
					{
						if (lSubAccountSelected.LocalTax > 0)
						{
							decimal _localTaxPercent = (decimal)lSubAccountSelected.LocalTax;

							decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, lSubAccountSelected.LocalTaxInclusive);
							poFolioTrans.LocalTax = _localTaxAmount;


							if (lSubAccountSelected.LocalTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _localTaxAmount;

								_inclusiveLocalTax = false;
							}
						}
						else
						{
							poFolioTrans.LocalTax = 0;
						}
					}
					else
					{
						if (_oTranCode.LocalTax > 0)
						{
							decimal _localTaxPercent = (decimal)_oTranCode.LocalTax;

							decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, _oTranCode.LocalTaxInclusive);
							poFolioTrans.LocalTax = _localTaxAmount;

							if (_oTranCode.LocalTaxInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _localTaxAmount;

								_inclusiveLocalTax = false;
							}
						}
						else
						{
							poFolioTrans.LocalTax = 0;
						}

					}



					// compute Local Tax here (Inclusive or Exclusive)
					// if has SubAccount use SubAccount settings for Govt Tax
					// else use TransactionCode settings for Local Tax
					_baseAmount = _baseAmount - poFolioTrans.GovernmentTax - poFolioTrans.LocalTax;

					if (lSubAccountSelected != null)
					{
						if (lSubAccountSelected.ServiceCharge > 0)
						{
							if (lSubAccountSelected.ServiceChargeInclusive == 0)
							{
								// SUBTRACT GovtTax and LocalTax before applying Service Charge
								_baseAmount = poFolioTrans.BaseAmount - poFolioTrans.Discount;

								_inclusiveServiceCharge = false;
							}

							decimal _serviceChargePercent = (decimal)lSubAccountSelected.ServiceCharge;

							decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, lSubAccountSelected.ServiceChargeInclusive);
							poFolioTrans.ServiceCharge = _serviceChargeAmount;

							// add service charge to Gross Amount if exclusive
							if (lSubAccountSelected.ServiceChargeInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _serviceChargeAmount;

								_inclusiveServiceCharge = false;
							}
						}
						else
						{
							poFolioTrans.ServiceCharge = 0;
						}
					}
					else
					{
						if (_oTranCode.ServiceCharge > 0)
						{
							if (_oTranCode.ServiceChargeInclusive == 0)
							{
								// SUBTRACT GovtTax and LocalTax before applying Service Charge
								_baseAmount = poFolioTrans.BaseAmount;

								_inclusiveServiceCharge = false;
							}

							decimal _serviceChargePercent = (decimal)_oTranCode.ServiceCharge;

							decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, _oTranCode.ServiceChargeInclusive);
							poFolioTrans.ServiceCharge = _serviceChargeAmount;

							// add service charge to Gross Amount if exclusive
							if (_oTranCode.ServiceChargeInclusive == 0)
							{
								//poFolioTransaction.GrossAmount += _serviceChargeAmount;

								_inclusiveServiceCharge = false;
							}
						}
						else
						{
							poFolioTrans.ServiceCharge = 0;
						}

					}


					poFolioTrans.NetAmount = poFolioTrans.GrossAmount - poFolioTrans.Discount;

					poFolioTrans.NetBaseAmount = poFolioTrans.BaseAmount - poFolioTrans.Discount - poFolioTrans.MealAmount;
					if (_inclusiveGovTax)
					{
						poFolioTrans.NetBaseAmount -= poFolioTrans.GovernmentTax;
					}
					if (_inclusiveLocalTax)
					{
						poFolioTrans.NetBaseAmount -= poFolioTrans.LocalTax;
					}

					if (_inclusiveServiceCharge)
					{
						poFolioTrans.NetBaseAmount -= poFolioTrans.ServiceCharge;
					}

					//poFolioTrans.RouteSequence = "";
					//poFolioTrans.SourceFolio = "";
					//poFolioTrans.SourceSubFolio = "";
					//poFolioTrans.TerminalID = GlobalVariables.gTerminalID.ToString();
					//poFolioTrans.CreatedBy = GlobalVariables.gLoggedOnUser;

					//// new, Jrom, April 26, 2008
					//// Golden prince requirement

					//poFolioTrans.CreditCardNo = this.txtPayment_CardNo.Text;
					//poFolioTrans.ChequeNo = this.txtPayment_Cheque.Text;
					//poFolioTrans.AccountName = this.txtPayment_Account.Text;
					//poFolioTrans.BankName = this.txtPayment_Bank.Text;
					//poFolioTrans.ChequeDate = string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
					//poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

					//poFolioTransaction.CreditCardType = this.txtCardType.Text;
					//poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
					//poFolioTransaction.SubAccount = this.cboSubAccount.Text;
					//poFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);



				}
				catch (Exception)
				{
					//MessageBox.Show("No package was applied.", "Insert Folio Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

			private FolioRoutingCollection loFolioRoutingCollection;
			private void ApplyRouting(string pFolioID, FolioTransaction poFolioTransaction)
			{
                if (loFolio.FolioType != "GROUP")
                {
                    TransactionCodeFacade _oTransactionFacade = new TransactionCodeFacade();
                    TransactionCode _oTranCode = _oTransactionFacade.getTransactionCode(poFolioTransaction.TransactionCode);

                    loFolioTransCollection = new FolioTransactions();
                    //loFolioRoutingCollection = new FolioRoutingCollection();
                    loFolioRoutingCollection = loFolioFacade.GetFolioTransRouting(pFolioID, poFolioTransaction.TransactionCode);

                    if (loFolioRoutingCollection.Count == 0)
                        return;

                    // >> this is used in Routing
                    //double originalAmountForRouting = poFolioTransaction.BaseAmount;
                    decimal originalAmountForRouting = poFolioTransaction.NetAmount;

                    string _tempChargeType = "P"; // P=Percent ; A=Amount
                    decimal _tempTotalAmountInRouting = 0;
                    decimal _tempTotalPercentInRouting = 0;
                    foreach (FolioRouting _oRouting in loFolioRoutingCollection)
                    {
                        if (_oRouting.PercentCharged > 0)
                        {
                            _tempTotalPercentInRouting += _oRouting.PercentCharged;
                        }
                        else if (_oRouting.AmountCharged > 0)
                        {
                            _tempTotalAmountInRouting += _oRouting.AmountCharged;
                        }

                        _tempChargeType = _oRouting.Basis;

                    }

                    // check if Routing has a total Percentage of 100
                    // if not then charge the remaining Percent to subFolio A
                    if (_tempChargeType == "P")
                    {
                        if (_tempTotalPercentInRouting < 100)
                        {
                            // we use 1 here since oRouting.PercentCharge will be multiplied by 100
                            loFolioRoutingCollection.Item(0).PercentCharged = (1 - _tempTotalPercentInRouting);
                        }
                    }

                    // check if Routing has a total Amount equal to NetAmount
                    // if not then charge the remaining amount to subFolio A
                    if (_tempChargeType == "A")
                    {

                        if (_tempTotalPercentInRouting < originalAmountForRouting)
                        {
                            loFolioRoutingCollection.Item(0).AmountCharged = (originalAmountForRouting - _tempTotalAmountInRouting);
                        }
                    }


                    foreach (FolioRouting _oRouting in loFolioRoutingCollection)
                    {
                        if (_oRouting.PercentCharged > 0 || _oRouting.AmountCharged > 0)
                        {

                            FolioTransaction _oFolioTrans = new FolioTransaction();

                            _oFolioTrans.HotelID = poFolioTransaction.HotelID;
                            _oFolioTrans.TransactionDate = poFolioTransaction.TransactionDate;
                            _oFolioTrans.FolioID = loFolio.FolioID;
                            _oFolioTrans.AccountID = loFolio.AccountID;
                            _oFolioTrans.TransactionCode = poFolioTransaction.TransactionCode;
                            _oFolioTrans.SubAccount = poFolioTransaction.SubAccount;
                            _oFolioTrans.ReferenceNo = poFolioTransaction.ReferenceNo;
                            _oFolioTrans.TransactionSource = poFolioTransaction.TransactionSource;
                            _oFolioTrans.Memo = poFolioTransaction.Memo;
                            _oFolioTrans.AcctSide = poFolioTransaction.AcctSide;
                            _oFolioTrans.CurrencyCode = poFolioTransaction.CurrencyCode;
                            _oFolioTrans.ConversionRate = poFolioTransaction.ConversionRate;
                            _oFolioTrans.CurrencyAmount = poFolioTransaction.CurrencyAmount;
                            _oFolioTrans.BaseAmount = poFolioTransaction.BaseAmount;
                            _oFolioTrans.GrossAmount = poFolioTransaction.GrossAmount;
                            _oFolioTrans.Discount = poFolioTransaction.Discount;

                            _oFolioTrans.GovernmentTax = poFolioTransaction.GovernmentTax;
                            _oFolioTrans.LocalTax = poFolioTransaction.LocalTax;
                            _oFolioTrans.ServiceCharge = poFolioTransaction.ServiceCharge;

                            //_oFolioTrans.GovernmentTax = ComputeTaxSrvCharge( _oFolioTrans.BaseAmount, poFolioTransaction.GovernmentTax, poFolioTransaction.GovernmentTaxInclusive) ;
                            //_oFolioTrans.LocalTax = ComputeTaxSrvCharge(_oFolioTrans.BaseAmount, poFolioTransaction.LocalTax, poFolioTransaction.LocalTax);
                            //_oFolioTrans.ServiceCharge = ComputeTaxSrvCharge((_oFolioTrans.BaseAmount - _oFolioTrans.GovernmentTax, poFolioTransaction.ServiceCharge, poFolioTransaction.ServiceChargeInclusive);

                            _oFolioTrans.GovernmentTaxInclusive = poFolioTransaction.GovernmentTaxInclusive;
                            _oFolioTrans.LocalTaxInclusive = poFolioTransaction.LocalTaxInclusive;
                            _oFolioTrans.ServiceChargeInclusive = poFolioTransaction.ServiceChargeInclusive;
                            _oFolioTrans.MealAmount = poFolioTransaction.MealAmount;


                            _oFolioTrans.NetBaseAmount = poFolioTransaction.NetBaseAmount;
                            _oFolioTrans.NetAmount = poFolioTransaction.NetAmount;

                            _oFolioTrans.TerminalID = poFolioTransaction.TerminalID;
                            _oFolioTrans.CreatedBy = poFolioTransaction.CreatedBy;

                            _oFolioTrans.CreditCardNo = poFolioTransaction.CreditCardNo;
                            _oFolioTrans.CreditCardExpiry = poFolioTransaction.CreditCardNo;

                            _oFolioTrans.ChequeDate = "1900-01-01";
                            _oFolioTrans.CreditCardExpiry = "1900-01-01";


                            if (_oRouting.PercentCharged > 0)
                            {
                                _oFolioTrans.Discount = _oFolioTrans.Discount * (_oRouting.PercentCharged / 100); ;
                                _oFolioTrans.CurrencyAmount = _oFolioTrans.CurrencyAmount * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.BaseAmount = _oFolioTrans.BaseAmount * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.GrossAmount = _oFolioTrans.GrossAmount * (_oRouting.PercentCharged / 100);

                                _oFolioTrans.GovernmentTax = _oFolioTrans.GovernmentTax * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.LocalTax = _oFolioTrans.LocalTax * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.ServiceCharge = _oFolioTrans.ServiceCharge * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.NetBaseAmount = _oFolioTrans.NetBaseAmount * (_oRouting.PercentCharged / 100);
                                _oFolioTrans.MealAmount = _oFolioTrans.MealAmount * (_oRouting.PercentCharged / 100);

                                _oFolioTrans.NetAmount = _oFolioTrans.NetAmount * (_oRouting.PercentCharged / 100);
                            }
                            else
                            {
                                // checks if amount is > originalAmountForRouting 
                                if (originalAmountForRouting > _oRouting.AmountCharged)
                                {
                                    originalAmountForRouting -= _oRouting.AmountCharged;
                                }
                                else
                                {
                                    _oRouting.AmountCharged = originalAmountForRouting;
                                    originalAmountForRouting = 0;
                                }

                                // Discount = 0 since we won't be able to determine how much discount to Route
                                // to destination folio.
                                _oFolioTrans.Discount = 0;

                                _oFolioTrans.CurrencyAmount = _oRouting.AmountCharged;
                                _oFolioTrans.BaseAmount = _oRouting.AmountCharged;
                                _oFolioTrans.GrossAmount = _oRouting.AmountCharged;

                                _oFolioTrans.GovernmentTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, _oTranCode.GovtTax, _oTranCode.GovtTaxInclusive);
                                _oFolioTrans.LocalTax = ComputeTaxSrvCharge(_oRouting.AmountCharged, _oTranCode.LocalTax, _oTranCode.LocalTaxInclusive);
                                _oFolioTrans.ServiceCharge = ComputeTaxSrvCharge(_oRouting.AmountCharged, _oTranCode.ServiceCharge, _oTranCode.ServiceChargeInclusive);
                                _oFolioTrans.NetBaseAmount = _oRouting.AmountCharged - (_oFolioTrans.GovernmentTax + _oFolioTrans.LocalTax + _oFolioTrans.ServiceCharge);
                                _oFolioTrans.NetAmount = _oRouting.AmountCharged;
                                //_oFolioTrans.NetAmount = _oRouting.AmountCharged - _oFolioTrans.Discount;

                            }


                            // KUNG NAA CYA MASTER FOLIO(DEPENDENT CYA) DERITSO SA 
                            // IYA MASTER FOLIO ANG TRANSACTION SA 
                            // SUB-FOLIO B., IF INDEPENDENT THEN NAA CYA 
                            // SUB-FOLIO B TRANS, IYAHA GHAPON ANG
                            // TRANSACTION PERO, SA SUB-FOLIO B.
                            _oFolioTrans.SubFolio = _oRouting.SubFolio;
                            if (_oFolioTrans.SubFolio == "B")
                            {
                                //_oFolioTrans.AccountID = (loFolio.CompanyID == "" || loFolio.CompanyID == "0") ? loFolio.AccountID : loFolio.CompanyID;
                                //_oFolioTrans.FolioID = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? loFolio.FolioID : loFolio.MasterFolio;
                                //_oFolioTrans.SubFolio = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? "B" : "A";
                                //_oFolioTrans.SourceFolio = loFolio.FolioID;

                                //_oFolioTrans.AccountID = poFolioTransaction.AccountID;
                                //_oFolioTrans.FolioID = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? loFolio.FolioID : loFolio.MasterFolio;
                                //_oFolioTrans.SubFolio = (loFolio.MasterFolio == "" || loFolio.MasterFolio == "0") ? "B" : "A";

                                //_oFolioTrans.SourceFolio = loFolio.FolioID;


                                _oFolioTrans.Discount = _oFolioTrans.Discount;
                            }
                            else
                            {
                                _oFolioTrans.AccountID = loFolio.AccountID;
                                if (loFolio.MasterFolio != "")
                                {
                                    _oFolioTrans.Discount = 0;
                                }
                                else
                                {
                                    _oFolioTrans.Discount = _oFolioTrans.Discount;
                                }
                            }

                            loFolioTransCollection.Add(_oFolioTrans);
                        }
                    }
                }
			}

			private void ApplyPrivileges(FolioTransaction poFolioTrans)
			{
				try
				{
					loFolioFacade = new FolioFacade();


					if (loFolioTransCollection.Count == 0)
					{
						//oFolioTrans.BaseAmount = Me.txtBaseAmount.Text
						loFolioTransCollection.Add(poFolioTrans);
					}

					FolioTransaction _oFolioTransaction;
					foreach (FolioTransaction _tempLoopVar_fTrans in loFolioTransCollection)
					{
						_oFolioTransaction = _tempLoopVar_fTrans;

						DataRow _dtPrivileges = loFolioFacade.GetFolioTransPrivilege(ref _oFolioTransaction);

						if (_dtPrivileges == null)
							return;

						decimal _disc = 0;
						if ((string)_dtPrivileges["Basis"] == "A")
						{
							_disc = decimal.Parse(_dtPrivileges["AmountOff"].ToString());
						}
						else
						{
							_disc = _oFolioTransaction.BaseAmount * (decimal.Parse(_dtPrivileges["PercentOff"].ToString()) / 100);
						}

						_oFolioTransaction.BaseAmount = _oFolioTransaction.BaseAmount - _disc;
						_oFolioTransaction.Discount = _oFolioTransaction.Discount + _disc;

						_oFolioTransaction.GovernmentTax = decimal.Parse(this.txtGovTax.Text);
						if (_oFolioTransaction.GovernmentTax > 0)
						{
							_oFolioTransaction.GovernmentTax = ComputeTaxSrvCharge(_oFolioTransaction.BaseAmount, _oFolioTransaction.GovernmentTax, _oFolioTransaction.GovernmentTaxInclusive);
						}

						_oFolioTransaction.LocalTax = decimal.Parse(this.txtLocalTax.Text);
						if (System.Convert.ToDouble(_oFolioTransaction.LocalTax) > 0)
						{
							_oFolioTransaction.LocalTax = ComputeTaxSrvCharge((_oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax), _oFolioTransaction.LocalTax, _oFolioTransaction.LocalTaxInclusive);
						}

						_oFolioTransaction.ServiceCharge = decimal.Parse(this.txtServiceCharge.Text);
						if (System.Convert.ToDouble(_oFolioTransaction.ServiceCharge) > 0)
						{
							_oFolioTransaction.ServiceCharge = ComputeTaxSrvCharge((_oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax - _oFolioTransaction.LocalTax), _oFolioTransaction.ServiceCharge, _oFolioTransaction.ServiceChargeInclusive);
						}

						//fTrans.NetBaseAmount = fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge;
						_oFolioTransaction.NetBaseAmount = _oFolioTransaction.BaseAmount - _oFolioTransaction.GovernmentTax - _oFolioTransaction.LocalTax - _oFolioTransaction.ServiceCharge - _oFolioTransaction.Discount;

					}

				}
				catch (Exception)
				{
					//MessageBox.Show("No Privilege was applied.", "Insert Folio Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

			private void AppendFolioTransaction(FolioTransaction poFolioTrans)
			{
				MySqlTransaction _myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

				loFolioTransactionFacade = new FolioTransactionFacade();

				if (loFolioTransactionFacade.InsertFolioTransaction(poFolioTrans, ref _myTransaction))
				{
					_myTransaction.Commit();

					FolioTransaction _oFolioTransaction = poFolioTrans;
					ListViewItem _listView = new ListViewItem(string.Format("{0:dd-MMM-yyyy hh:mm:ss tt}", DateTime.Now));
					_listView.SubItems.Add(_oFolioTransaction.TransactionCode);
					_listView.SubItems.Add(_oFolioTransaction.Memo);
					_listView.SubItems.Add(string.Format("{0:#,##0.00}", _oFolioTransaction.BaseAmount));
					_listView.SubItems.Add(string.Format("{0:#,##0.00}", _oFolioTransaction.GovernmentTax));
					_listView.SubItems.Add(string.Format("{0:#,##0.00}", _oFolioTransaction.LocalTax));
					_listView.SubItems.Add(string.Format("{0:#,##0.00}", _oFolioTransaction.ServiceCharge));
					_listView.SubItems.Add(string.Format("{0:#,##0.00}", _oFolioTransaction.Discount));
					_listView.SubItems.Add(string.Format("{0:#,##0.00}", _oFolioTransaction.NetBaseAmount));

					switch (_oFolioTransaction.SubFolio)
					{
						case "A":

							if (_oFolioTransaction.FolioID == loFolio.FolioID)
							{
								lListviewA.Items.Add(_listView);
							}
							else
							{
								lListviewB.Items.Add(_listView);
							}
							break;
						case "B":

							lListviewB.Items.Add(_listView);
							break;
						case "C":

							break;
						case "D":

							break;
					}
				}
				else
				{
					_myTransaction.Rollback();
				}
			}

			private void AppendFolioTransaction(FolioTransactions poFolioTransCollection)
			{
				FolioTransaction _oFolioTrans;
				foreach (FolioTransaction _tempLoopVar_folioTrans in poFolioTransCollection)
				{
					_oFolioTrans = _tempLoopVar_folioTrans;
					AppendFolioTransaction(_oFolioTrans);
				}
			}


			private decimal ComputeTaxSrvCharge(decimal pBaseAmount, decimal pTaxPercent, int isInclusive)
			{
				decimal _taxAmount;

				if (isInclusive == 1)
				{
					_taxAmount = pBaseAmount - (pBaseAmount / (1 + (pTaxPercent / 100)));
				}
				else
				{
					_taxAmount = pBaseAmount * (pTaxPercent / 100);
				}

				return _taxAmount;
			}

			private void ComputeBaseAmount()
			{
				try
				{
					decimal _total = 0;

					_total = decimal.Parse(this.txtCurAmount.Text) * decimal.Parse(this.cboCurrencyRate.Text);

					// this is for RoomService(additional)
					decimal _serviceChargeAmount = 0;
					decimal _serviceChargePercent = decimal.Parse(this.txtServiceCharge.Text);
					if (_serviceChargePercent > 0)
					{
						//decimal _totalCopy = _total - totalDiscount;

						//_serviceChargeAmount = _totalCopy * (_serviceChargePercent / 100);
						_serviceChargeAmount = _total * (_serviceChargePercent / 100);
					}

					decimal _totalGross = _total + _serviceChargeAmount;

					//compute discount
					decimal totalDiscount = 0;
					decimal percentDiscount = 0;
					try // to trap if txtDiscountPercent is BLANK 
					{
						percentDiscount = decimal.Parse(this.txtDiscountPercent.Text);
					}
					catch
					{
						this.txtDiscountPercent.Text = "0.00";
						this.txtDiscountPercent.SelectAll();
					}

					if (percentDiscount > 0 && percentDiscount <= 100)
					{
						percentDiscount = percentDiscount / 100;

						totalDiscount = _total * percentDiscount;
					}
					else
					{

						this.txtDiscountAmount.Text = "0";
						decimal _discount = 0;

						// display DISCOUNT amount if present
						foreach (Privilege _oPrivilege in loFolio.Privileges)
						{
							if (_oPrivilege.TransactionCode == this.txtTransactionCode.Text)
							{
								if (_oPrivilege.Basis == "A") // for percent
								{
									_discount = _oPrivilege.AmountOff;
								}

								break;
							}
						}

						foreach (FolioPackage _oPackage in loFolio.Package)
						{
							if (_oPackage.TransactionCode == txtTransactionCode.Text)
							{
								if (_oPackage.Basis == "A" && _discount < _oPackage.AmountOff)
								{
									_discount = _oPackage.AmountOff;
								}
								break;
							}
						}

						txtDiscountAmount.Text = _discount.ToString(_decimalFormat);
						totalDiscount = decimal.Parse(this.txtDiscountAmount.Text);
					}


					// this is for Government Tax Exclusive sale
					decimal _govTaxAmount = 0;
					decimal _govTaxPercent = decimal.Parse(this.txtGovTax.Text);
					if (_govTaxPercent > 0)
					{
						decimal _totalCopy = _totalGross - totalDiscount;

						_govTaxAmount = _totalCopy * (_govTaxPercent / 100);
					}

					// this is for Local Tax Exclusive sale
					decimal _localTaxAmount = 0;
					decimal _localTaxPercent = decimal.Parse(this.txtLocalTax.Text);
					if (_localTaxPercent > 0)
					{
						decimal _totalCopy = _totalGross - totalDiscount;

						_localTaxAmount = _totalCopy * (_localTaxPercent / 100);
					}

					// add Service Charge and Tax b4 applying discount
					_total = _total + _serviceChargeAmount + _govTaxAmount + _localTaxAmount;


					this.txtBaseAmount.Text = _total.ToString(_decimalFormat);

					// apply discount here
					this.txtDiscountAmount.Text = totalDiscount.ToString(_decimalFormat);

					_total = _total - totalDiscount;

					this.txtNetBaseAmount.Text = _total.ToString(_decimalFormat);

				}
				catch (Exception)
				{
					this.txtBaseAmount.Text = "0.00";
					this.txtNetBaseAmount.Text = "0.00";
				}
			}

			#endregion

			#region "M I S C E L L A N E O U S"

			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				//if (Interaction.MsgBox("Are you sure you want to Cancel?", MsgBoxStyle.DefaultButton2 | MsgBoxStyle.Question | MsgBoxStyle.YesNo, "Add Folio Transaction") == MsgBoxResult.Yes)
				//{
				this.Close();
                return;
				//}
			}


            //private bool _shouldPost = true;
			private void txtTransactionCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					if (this.txtTransactionCode.Text != "")
					{
                        //>>for trapping the use of refund when balance is not yet below zero
                        if (txtTransactionCode.Text == "3300" && decimal.Parse(txtCurrentFolioRunningBalance.Text) >= 0)
                        {
                            DialogResult rsp = MessageBox.Show("Sub-folio balance is not less than zero.\r\nDo you want to continue using Refund transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (rsp == DialogResult.No)
                            {
                                txtTransactionCode.Text = "";
                                txtMemo.Text = "";
                                return;
                            }
                        }

                        if (txtTransactionCode.Text == "1000")
                        {
                            chkAdjustment.Visible = true;

                            //>>for checking if a room charge has been inserted for the day
                            //>>if system founds a room charge for the day, should prompt the user
                            bool _hasRoomChargeForTheDay = false;
                            FolioTransactionFacade _oFolioTransFacade = new FolioTransactionFacade();
                            _hasRoomChargeForTheDay = _oFolioTransFacade.checkIfRoomChargeExist(txtFolioId.Text);

                            if (_hasRoomChargeForTheDay)
                            {
                                DialogResult rsp = MessageBox.Show("Room charge has already been posted for the day! \r\nDo you want to continue posting transaction?", "Post Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rsp == DialogResult.No)
                                {
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            chkAdjustment.Visible = false;
                        }

						_warningIsShown = false;
						SearchInListView();
					}
				}
			}

			public void SearchInListView()
			{
				lSubAccountSelected = null;

				try
				{
					this.lvwCodes.Focus();

					DeselectItem();

					//for (int i = 0; i <= this.lvwCodes.Items.Count - 1; i++)
					foreach (ListViewItem _lvwItem in this.lvwCodes.Items)
					{
						if (_lvwItem.Text.ToUpper().Equals(this.txtTransactionCode.Text.ToUpper()))
						{
							string _accountingSide = _lvwItem.SubItems[2].Text;

							//this.cboAcctSide.Text = "";

                            //>>attach room number to memo for room charges
                            if (txtTransactionCode.Text != "1000")
                            {
                                this.txtMemo.Text = _lvwItem.SubItems[1].Text;
                            }
                            else
                            {
                                this.txtMemo.Text = _lvwItem.SubItems[1].Text + txtRoomId.Text;
                            }
							this.cboAcctSide.Tag = _accountingSide;
							this.cboAcctSide.Text = _accountingSide;

							this.cboTransSource.Text = _lvwItem.SubItems[9].Text;
							if (_lvwItem.SubItems[7].Text == "0")
							{
								this.txtGovTax.Text = _lvwItem.SubItems[4].Text;
							}
							else
							{
								this.txtGovTax.Text = "0.00";
							}


							if (_lvwItem.SubItems[8].Text == "0")
							{
								this.txtLocalTax.Text = _lvwItem.SubItems[5].Text;
							}
							else
							{
								this.txtLocalTax.Text = "0.00";
							}

							if (_lvwItem.SubItems[6].Text == "0")
							{
								this.txtServiceCharge.Text = _lvwItem.SubItems[3].Text;
							}
							else
							{
								this.txtServiceCharge.Text = "0.00";
							}

							this.cboTransSource.Text = _lvwItem.SubItems[9].Text;

							if (_accountingSide == "CREDIT")
							{
								decimal _netBalance = loFolio.SubFolios.Item(this.cboSubFolio.SelectedIndex).Ledger.BalanceNet;

                                if (txtTransactionCode.Text.StartsWith("7") == true)
                                {
                                    this.txtCurAmount.Text = "0.00";
                                }
                                else
                                {
                                    this.txtCurAmount.Text = Math.Abs(_netBalance).ToString(_decimalFormat);
                                }
							}
							else if (_accountingSide == "DEBIT")
							{
								try
								{
									if (this.txtTransactionCode.Text == "1000")
									{
										foreach (Schedule _oSchedule in loFolio.Schedule)
										{
											if (_oSchedule.RoomID == this.txtRoomId.Text)
											{
												this.txtCurAmount.Text = _oSchedule.Rate.ToString(_decimalFormat);
												break;
											}
										}
									}
                                    else if (this.txtTransactionCode.Text == "3300")
                                    {
                                        decimal _netBalance = loFolio.SubFolios.Item(this.cboSubFolio.SelectedIndex).Ledger.BalanceNet;
                                        this.txtCurAmount.Text = Math.Abs(_netBalance).ToString(_decimalFormat);
                                    }
								}
								catch { }
							}

							this.cboAcctSide_SelectedIndexChanged(this, new EventArgs());



							// Display Discount Percentage if TransactionCode selected
							// is present in oFolio.Privileges
							this.txtDiscountAmount.Text = "0.00";
							this.txtDiscountPercent.Text = "0.00";
							showDiscountPercent(this.txtTransactionCode.Text);


							return;
						}
					}

					this.lvwCodes.BringToFront();
					this.lvwCodes.Visible = true;
				}
				catch// (Exception ex)
				{
					this.lvwCodes.SendToBack();
					this.lvwCodes.Visible = false;
					// MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			bool _warningIsShown = false;
			private void showDiscountPercent(string pTransactionCode)
			{
				decimal _discount = 0;
				bool _isPresent = false;

				bool _isPercent = false;
				foreach (Privilege _oPrivilege in loFolio.Privileges)
				{
					if (_oPrivilege.TransactionCode == pTransactionCode)
					{
						if (_oPrivilege.Basis == "P") // for percent
						{
							_discount = _oPrivilege.Percentoff;
							_isPercent = true;
						}
						else
						{
							_discount = _oPrivilege.AmountOff;
							_isPercent = false;
						}

						_isPresent = true;
						break;
					}
				}

				foreach (FolioPackage _oPackage in loFolio.Package)
				{
					if (_oPackage.TransactionCode == pTransactionCode)
					{
						if (_isPresent == true && _warningIsShown == false)
						{
							MessageBox.Show("Two or more discount amount has been detected for this transaction code.\n Higher rate will apply. To change discount, just input in the discount field.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
							_warningIsShown = true;
						}

                        if (_oPackage.Basis == "P" && _discount < _oPackage.PercentOff && (_oPackage.DateFrom.Date >= DateTime.Parse(GlobalVariables.gAuditDate).Date || _oPackage.DateTo.Date >= DateTime.Parse(GlobalVariables.gAuditDate).Date)) // for percent
						{
							_discount = _oPackage.PercentOff;
							_isPercent = true;
							//txtDiscountPercent.Text = _discount.ToString(_decimalFormat);
						}
                        else if (_oPackage.Basis == "A" && _discount < _oPackage.AmountOff && (_oPackage.DateFrom.Date <= DateTime.Parse(GlobalVariables.gAuditDate).Date || _oPackage.DateTo.Date >= DateTime.Parse(GlobalVariables.gAuditDate).Date))
						{
							_discount = _oPackage.AmountOff;
							_isPercent = false;
							//txtDiscountAmount.Text = _discount.ToString(_decimalFormat);
						}
						else if (_oPackage.Basis == "P" && _discount >= _oPackage.PercentOff && (_oPackage.DateFrom.Date >= DateTime.Parse(GlobalVariables.gAuditDate).Date || _oPackage.DateTo.Date <= DateTime.Parse(GlobalVariables.gAuditDate).Date))
						{
							_isPercent = true;
							//txtDiscountPercent.Text = _discount.ToString(_decimalFormat);
						}
						else if (_oPackage.Basis == "A" && _discount >= _oPackage.AmountOff && (_oPackage.DateFrom.Date >= DateTime.Parse(GlobalVariables.gAuditDate).Date || _oPackage.DateTo.Date <= DateTime.Parse(GlobalVariables.gAuditDate).Date))
						{
							_isPercent = false;
							//txtDiscountAmount.Text = _discount.ToString(_decimalFormat);
						}

						break;
					}
				}

				if (_isPercent == true)
				{
					txtDiscountPercent.Text = _discount.ToString(_decimalFormat);
				}
				else
				{
					txtDiscountAmount.Text = _discount.ToString(_decimalFormat);
				}
			}


			private void DeselectItem()
			{
				for (int i = 0; i <= this.lvwCodes.Items.Count - 1; i++)
				{
					this.lvwCodes.Items[i].Selected = false;
				}
			}

			private void lvwCodes_DoubleClick(object sender, System.EventArgs e)
			{
				try
				{
					this.txtTransactionCode.Text = this.lvwCodes.SelectedItems[0].Text;

                    //>>for trapping the use of refund when balance is not yet below zero
                    if (txtTransactionCode.Text == "3300" && decimal.Parse(txtCurrentFolioRunningBalance.Text) >= 0)
                    {
                        DialogResult rsp = MessageBox.Show("Sub-folio balance is not less than zero.\r\nDo you want to continue using Refund transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (rsp == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (txtTransactionCode.Text == "1000")
                    {
                        chkAdjustment.Visible = true;

                        //>>for checking if a room charge has been inserted for the day
                        //>>if system founds a room charge for the day, should prompt the user
                        bool _hasRoomChargeForTheDay = false;
                        FolioTransactionFacade _oFolioTransFacade = new FolioTransactionFacade();
                        _hasRoomChargeForTheDay = _oFolioTransFacade.checkIfRoomChargeExist(txtFolioId.Text);

                        if (_hasRoomChargeForTheDay)
                        {
                            DialogResult rsp = MessageBox.Show("Room charge has already been posted for the day! \r\nDo you want to continue posting transaction?", "Post Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rsp == DialogResult.No)
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        chkAdjustment.Visible = false;
                    }

					SearchInListView();

					////this.txtMemo.Text = this.lvwCodes.SelectedItems[0].SubItems[1].Text;
					////this.cboAcctSide.Tag = this.lvwCodes.SelectedItems[0].SubItems[2].Text;
					////this.cboAcctSide.Text = this.lvwCodes.SelectedItems[0].SubItems[2].Text;

					////this.txtServiceCharge.Text = this.lvwCodes.SelectedItems[0].SubItems[3].Text;
					////this.txtGovTax.Text = this.lvwCodes.SelectedItems[0].SubItems[4].Text;
					////this.txtLocalTax.Text = this.lvwCodes.SelectedItems[0].SubItems[5].Text;
					////SearchInListView();
					//this.txtTransactionCode_KeyPress(sender,new KeyPressEventArgs('\r'));

					////this.txtCurAmount.Focus();
					//this.lvwCodes.SendToBack();
					this.lvwCodes.Visible = false;
				}
				catch (Exception)
				{
					MessageBox.Show("Invalid transaction code! Select a correct transaction code from the list.", "Invalid Transaction code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

			private void txtTransactionCode_LostFocus(object sender, System.EventArgs e)
			{

				if (this.txtTransactionCode.Text != "")
				{
					SearchInListView();
				}

			}

			private void txtCurAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					this.txtReferenceNo.Focus();
				}
				else if (e.KeyChar == '\u002E' || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else if (!char.IsDigit(e.KeyChar))
				{
					e.Handled = true;
				}
			}

			private void LockTextBox(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}

			private void lvwCodes_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\u001B')
				{
					this.lvwCodes.SendToBack();
					this.lvwCodes.Visible = false;
				}
				else if (e.KeyChar == '\r')
				{
					lvwCodes_DoubleClick(sender, e);
				}
			}

			private void AddTransactionUI_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\u001B')
				{
					this.lvwCodes.SendToBack();
				}
			}

			private void btnViewCodes_Click(System.Object sender, System.EventArgs e)
			{
				this.lvwCodes.Visible = true;
				this.lvwCodes.BringToFront();
				this.lvwCodes.Focus();
				this.lvwCodes.Items[0].Selected = true;
			}

			// >> Currency Codes COMBO BOX
			private void cboCurrencyCode_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				try
				{
					this.cboCurrencyRate.SelectedIndex = cboCurrencyCode.SelectedIndex;

					ComputeBaseAmount();
				}
				catch
				{

				}

			}

			private void cboCurrencyRate_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				try
				{
					cboCurrencyCode.SelectedIndex = this.cboCurrencyRate.SelectedIndex;
					convertAmount();

					ComputeBaseAmount();
				}
				catch
				{ }

			}

			public void convertAmount()
			{
				try
				{
					this.txtBaseAmount.Text = string.Format("{0:#,##0.00}", int.Parse(cboCurrencyRate.Text) * int.Parse(this.txtCurAmount.Text));
				}
				catch (Exception)
				{
				}
			}

			private void txtBaseAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}

			#endregion


			public void SaveEntry()
			{
				insertFolioTransaction();
			}

			private void txtAcctSide_TextChanged(object sender, EventArgs e)
			{

			}

			private void getTransactionCode_SubAccount(string a_TranCode)
			{

				this.pnlSubAccount.Visible = false;
				this.cboSubAccount.DataSource = null;

				ArrayList _arrSubAccount = new ArrayList();

				foreach (TransactionCode_SubAccount _oSubAccount in lSubAccountsList)
				{
					if (_oSubAccount.TransactionCode == a_TranCode)
					{
						_arrSubAccount.Add(_oSubAccount);
					}
				}

				if (_arrSubAccount.Count > 0)
				{
					this.cboSubAccount.DataSource = _arrSubAccount;
					this.cboSubAccount.DisplayMember = "SubAccountCode";

					this.pnlSubAccount.Visible = true;
					this.cboSubAccount.Focus();

					//this.cboSubAccount.DroppedDown = true;

					// this is to trap changing ACCOUTING SIDE for PAID OUT
					if (this.txtTransactionCode.Text == "6000")
					{
						this.cboAcctSide.Enabled = false;
					}
				}
				else
				{
					this.cboSubAccount.DataSource = null;

					this.pnlSubAccount.Visible = false;

					this.txtCurAmount.Focus();
				}
			}

            private void getPaymentTransactionCode_SubAccount(string a_TranCode)
            {

                this.pnlPaymentSubAccount.Visible = false;
                this.cboPaymentSubAccount.DataSource = null;

                ArrayList _arrSubAccount = new ArrayList();

                foreach (TransactionCode_SubAccount _oSubAccount in lSubAccountsList)
                {
                    if (_oSubAccount.TransactionCode == a_TranCode)
                    {
                        _arrSubAccount.Add(_oSubAccount);
                    }
                }

                if (_arrSubAccount.Count > 0)
                {
                    this.cboPaymentSubAccount.DataSource = _arrSubAccount;
                    this.cboPaymentSubAccount.DisplayMember = "SubAccountCode";

                    this.pnlPaymentSubAccount.Visible = true;
                    this.cboPaymentSubAccount.Focus();
                }
                else
                {
                    this.cboPaymentSubAccount.DataSource = null;

                    this.pnlPaymentSubAccount.Visible = false;

                    this.txtPayment_ORNo.Focus();
                }
            }

			private void hideAllPaymentPanel()
			{
				this.pnlPaymentTransSource.Visible = false;
				this.pnlOrNo.Visible = false;
				this.pnlAmount.Visible = false;
				this.pnlCardNo.Visible = false;
				this.pnlChequeNo.Visible = false;
				this.pnlAccount.Visible = false;
				this.pnlBank.Visible = false;
				this.pnlDate.Visible = false;
				this.pnlGrantedBy.Visible = false;
                this.pnlPaymentSubAccount.Visible = false;

				this.pnlCardType.Visible = false;
				this.pnlCardExpires.Visible = false;
				this.pnlCardApproval.Visible = false;

				this.pnlPaymentType.Visible = false;
				// removes all textboxes content
				this.txtPayment_Account.Text = "";
				this.txtPayment_Amount.Text = "0.00";
				this.txtPayment_Bank.Text = "";
				this.txtPayment_CardNo.Text = "";
				this.txtPayment_Cheque.Text = "";
				this.txtPayment_ORNo.Text = "";
				this.txtGrantedBy.Text = "";
				this.txtCardType.Text = "";
				this.dtpCardExpires.Value = DateTime.Parse("01/01/1900");
				this.cboPaymentTypes.DataSource = null;
                this.cboPaymentSubAccount.DataSource = null;

			}

			private void txtReferenceNo_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					if (this.txtReferenceNo.Text.Trim().Length <= 0)
					{
						this.txtReferenceNo.Focus();
						return;
					}

					SendKeys.Send("\t");
				}
			}

			private void txtMemo_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\'')
				{
					e.KeyChar = '`';
				}
			}

			private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					this.txtReferenceNo.Focus();
				}
				else if (e.KeyChar == '\u002E' || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else if (!char.IsDigit(e.KeyChar))
				{
					e.Handled = true;
				}
			}

			private void txtDiscount_TextChanged(object sender, EventArgs e)
			{
				ComputeBaseAmount();
			}

			private void txtPayment_ORNo_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					SendKeys.Send("\t");
				}
			}

			private void txtPayment_Amount_KeyPress(object sender, KeyPressEventArgs e)
			{

				if (e.KeyChar == '\r')
				{
					SendKeys.Send("\t");
				}
				else if (e.KeyChar == '\u002E' || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else if (!char.IsDigit(e.KeyChar))
				{
					e.Handled = true;
				}

			}

			private void cboTransSource_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					SendKeys.Send("\t");
				}
			}

			DataRowView oPaymentTranCode = null;
			private void cboPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
			{

				string _selected = "";

				try
				{
					_selected = this.cboPaymentTypes.SelectedValue.ToString();

					hideAllPanelExceptPaymentType();

					oPaymentTranCode = (DataRowView)this.cboPaymentTypes.SelectedItem;

				}
				catch
				{
					_selected = "2000";
				}

                getPaymentTransactionCode_SubAccount(_selected);
				this.pnlOrNo.Visible = true;
				this.pnlPaymentTransSource.Visible = true;

				if (oPaymentTranCode != null)
				{
					this.cboPaymentTransSource.Text = oPaymentTranCode["DefaultTransactionSource"].ToString();
				}

				string _complimentaryTranCode = "";
				_complimentaryTranCode = "7" + this.txtTransactionCode.Text;

				switch (_selected)
				{
					case "2000": // CASH PAYMENT
						this.pnlAmount.Visible = true;
						break;

					case "2100": // CREDIT CARD
						this.pnlCardNo.Visible = true;
						//this.pnlAccount.Visible = true;
						this.pnlCardType.Visible = true;
						this.pnlCardExpires.Visible = true;
						this.pnlCardApproval.Visible = true;
						this.pnlAmount.Visible = true;

						this.txtPayment_CardNo.Text = loFolio.Guest.CreditCardNo;
						this.txtCardType.Text = loFolio.Guest.CreditCardType;

						try
						{
							this.dtpCardExpires.Value = DateTime.Parse(loFolio.Guest.CreditCardExpiry);
						}
						catch { }

						break;

					case "2200": // CHEQUE PAYMENT
						this.pnlOrNo.Visible = true;
						this.pnlAmount.Visible = true;
						//this.pnlCardNo.Visible = true;
						this.pnlChequeNo.Visible = true;
						this.pnlAccount.Visible = true;
						this.pnlBank.Visible = true;
						this.pnlDate.Visible = true;
						break;

					case "2201":
                    case "2800": // GIFT CHEQUE
						this.pnlAmount.Visible = true;
						this.pnlGrantedBy.Visible = true;
                        this.pnlChequeNo.Visible = true;
						break;

					default:
						if (_selected == _complimentaryTranCode)
						{
							DataRowView _tranCode = (DataRowView)this.cboPaymentTypes.SelectedItem;

							//this.lblPayment_DocSource.Text = _tranCode["DefaultTransactionSource"].ToString() + " #";
						}
                        this.pnlAmount.Visible = true;
						break;
				}
			}

			private void hideAllPanelExceptPaymentType()
			{

				this.pnlPaymentTransSource.Visible = false;
				this.pnlOrNo.Visible = false;
				this.pnlAmount.Visible = false;
				this.pnlCardNo.Visible = false;
				this.pnlChequeNo.Visible = false;
				this.pnlAccount.Visible = false;
				this.pnlBank.Visible = false;
				this.pnlDate.Visible = false;
				this.pnlGrantedBy.Visible = false;

				this.pnlCardType.Visible = false;
				this.pnlCardExpires.Visible = false;
				this.pnlCardApproval.Visible = false;

				// removes all textboxes content
				this.txtPayment_Account.Text = "";
				this.txtPayment_Amount.Text = "0.00";
				this.txtPayment_Bank.Text = "";
				this.txtPayment_CardNo.Text = "";
				this.txtPayment_Cheque.Text = "";
				this.txtPayment_ORNo.Text = "";
				this.txtGrantedBy.Text = "";
				this.txtCardType.Text = "";
				this.dtpCardExpires.Value = DateTime.Parse("01/01/1900");
			}

			private void cboAcctSide_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (this.txtTransactionCode.Text == "")
					return;


				// get Transaction Codes SubAccount
				if (this.cboAcctSide.Text != "")
				{
                    //string strCode = this.txtTransactionCode.Text;
                    //getTransactionCode_SubAccount(strCode);

					if (this.cboAcctSide.Tag.ToString() != this.cboAcctSide.Text)
					{
						this.txtMemo.Text = "WRONG ENTRY @ " + this.txtMemo.Text;
					}
					else
					{
						this.txtMemo.Text = this.txtMemo.Text.Replace("WRONG ENTRY @ ", "");
					}


				}
				else
				{
					this.pnlSubAccount.Visible = false;
				}

				if (this.cboAcctSide.Text.ToUpper() == "DEBIT")
				{
                    string strCode = this.txtTransactionCode.Text;
                    getTransactionCode_SubAccount(strCode);
                    
                    this.chkApplyPackage.Visible = true;
					this.chkApplyPrivileges.Visible = true;
					this.chkAppyRouting.Visible = true;


					// show payment Group Box
					// 6000 = PAID OUT [ COMMISSION / DISBURSEMENT ]
					if (this.txtTransactionCode.Text == "6000")
					{
						this.grbPayment.Enabled = false;
					}
					else
					{
						this.grbPayment.Enabled = true;
					}

					this.pnlPaymentType.Visible = true;
					this.pnlPaymentTransSource.Visible = true;
                    //this.pnlOrNo.Visible = true;
                    //this.pnlAmount.Visible = true;
                    //this.pnlAmount.Enabled = true;

					//this.cboTransSource.Text = "CHARGE INVOICE";
					this.txtDiscountPercent.ReadOnly = false;

					loadPaymentTypes();
				}
				else if (this.cboAcctSide.Text.ToUpper() == "CREDIT")
				{
                    string strCode = this.txtTransactionCode.Text;
                    getTransactionCode_SubAccount(strCode);
                    
                    this.chkApplyPackage.Visible = false;
					this.chkApplyPrivileges.Visible = false;
					this.chkAppyRouting.Visible = false;
					this.txtDiscountPercent.Text = "0.00";
					this.txtDiscountPercent.ReadOnly = true;

					hideAllPaymentPanel();
					this.grbPayment.Enabled = true;
					switch (this.txtTransactionCode.Text)
					{
						case "2000": // CASH PAYMENT
							this.grbPayment.Enabled = false;
							//this.cboTransSource.Text = "OFFICIAL RECEIPT";
							break;

						case "2100": // CREDIT CARD
							this.pnlCardNo.Visible = true;
							this.pnlCardType.Visible = true;
							this.pnlCardExpires.Visible = true;
							this.pnlCardApproval.Visible = true;


							// load credit card info
							this.txtPayment_CardNo.Text = loFolio.Guest.CreditCardNo;
							this.txtCardType.Text = loFolio.Guest.CreditCardType;

							try
							{
								this.dtpCardExpires.Value = DateTime.Parse(loFolio.Guest.CreditCardExpiry);
							}
							catch { }

							break;

                        case "2200": // CHEQUE PAYMENT
                            //this.pnlOrNo.Visible = true;
                            //this.pnlAmount.Visible = true;
                            //this.pnlCardNo.Visible = true;
                            this.pnlChequeNo.Visible = true;
                            this.pnlAccount.Visible = true;
                            this.pnlBank.Visible = true;
                            this.pnlDate.Visible = true;
                            break;

                        case "2201":
                        case "2800": // GIFT CHEQUE
                            //this.pnlAmount.Visible = true;
                            this.pnlGrantedBy.Visible = true;
                            this.pnlChequeNo.Visible = true;
                            break;

						case "2501": // FOC PAYMENT
							this.pnlGrantedBy.Visible = true;

							break;

						default:
							this.grbPayment.Enabled = false;
							break;
					}

				}
			}

			private TransactionCode_SubAccount lSubAccountSelected = null;
			private void cboSubAccount_SelectedIndexChanged(object sender, EventArgs e)
			{
				lSubAccountSelected = null;
				try
				{

					TransactionCode_SubAccount _subAccount = (TransactionCode_SubAccount)this.cboSubAccount.SelectedValue;

					lSubAccountSelected = _subAccount;

					if (_subAccount.GovernmentTaxInclusive == 0)
					{
						this.txtGovTax.Text = _subAccount.GovernmentTax.ToString(_decimalFormat);
					}
					else
					{
						this.txtGovTax.Text = "0.00";
					}


					if (_subAccount.LocalTaxInclusive == 0)
					{
						this.txtLocalTax.Text = _subAccount.LocalTax.ToString(_decimalFormat);
					}
					else
					{
						this.txtLocalTax.Text = "0.00";
					}

					if (_subAccount.ServiceChargeInclusive == 0)
					{
						this.txtServiceCharge.Text = _subAccount.ServiceCharge.ToString(_decimalFormat);
					}
					else
					{
						this.txtServiceCharge.Text = "0.00";
					}


				}
				catch
				{
					//this.txtGovTax.Text = "0.00";
					//this.txtLocalTax.Text = "0.00";
					//this.txtServiceCharge.Text = "0.00";
				}

			}

			private void cboSubFolio_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (loFolio != null)
				{
					//loFolio.CreateSubFolio();

					try
					{
						SubFolio _oSubFolio = loFolio.SubFolios.Item(cboSubFolio.SelectedIndex);

						decimal balance = _oSubFolio.Ledger.Charges - (_oSubFolio.Ledger.PayCash + _oSubFolio.Ledger.PayCard + _oSubFolio.Ledger.PayCheque + _oSubFolio.Ledger.PayGiftCheque + _oSubFolio.Ledger.BalanceForwarded);

						this.txtCurrentFolioOutstandingBalance.Text = balance.ToString(_decimalFormat);
						this.txtCurrentFolioRunningBalance.Text = balance.ToString(_decimalFormat);
					}
					catch
					{
						this.txtCurrentFolioOutstandingBalance.Text = "0.00";
						this.txtCurrentFolioRunningBalance.Text = "0.00";
					}


					try
					{
						txtNetBaseAmount_TextChanged(sender, e);
					}
					catch
					{ }

					//foreach (SubFolio _oSubFolio in loFolio.SubFolios)
					//{
					//    try
					//    {
					//        if (_oSubFolio.SubFolio_Renamed == this.cboSubFolio.Text)
					//        {
					//            decimal balance = _oSubFolio.Ledger.Charges - (_oSubFolio.Ledger.PayCash + _oSubFolio.Ledger.PayCard + _oSubFolio.Ledger.PayCheque + _oSubFolio.Ledger.PayGiftCheque + _oSubFolio.Ledger.BalanceForwarded);

					//            this.txtCurrentFolioOutstandingBalance.Text = balance.ToString(_decimalFormat) ;
					//            this.txtCurrentFolioRunningBalance.Text = balance.ToString(_decimalFormat);


					//            try
					//            {
					//                txtNetBaseAmount_TextChanged(sender, e);
					//            }
					//            catch { }

					//            return;
					//        }
					//    }
					//    catch
					//    {
					//        this.txtCurrentFolioOutstandingBalance.Text = "0.00";
					//        this.txtCurrentFolioRunningBalance.Text = "0.00";
					//    }
					//}


				}


			}


			//update "Current Folio and All Folio " Running Balance
			private void txtNetBaseAmount_TextChanged(object sender, EventArgs e)
			{
				decimal _netAmount = decimal.Parse(this.txtNetBaseAmount.Text);

				decimal _currentFolioOutstandingBalance = decimal.Parse(this.txtCurrentFolioOutstandingBalance.Text);
				decimal _allFolioOutstandingBalance = decimal.Parse(this.txtAllFolioOutstandingBalance.Text);

				decimal _currentFolioRunningBalance = 0;
				decimal _allFolioRunningBalance = 0;
				if (this.cboAcctSide.Text == "CREDIT")
				{

					_currentFolioRunningBalance = _currentFolioOutstandingBalance - _netAmount;

					_allFolioRunningBalance = _allFolioOutstandingBalance - _netAmount;

				}
				else
				{
					_currentFolioRunningBalance = _currentFolioOutstandingBalance + _netAmount;

					_allFolioRunningBalance = _allFolioOutstandingBalance + _netAmount;

				}

				// for payments
				decimal _payAmount = 0;
				if (this.pnlAmount.Visible)
				{
					try
					{
						_payAmount = decimal.Parse(this.txtPayment_Amount.Text);

						_currentFolioRunningBalance = _currentFolioRunningBalance - _payAmount;

						_allFolioRunningBalance = _allFolioRunningBalance - _payAmount;
					}
					catch { }
				}
				else
				{
					//_payAmount = _netAmount;

					//_currentFolioRunningBalance = _currentFolioRunningBalance - _payAmount;

					//_allFolioRunningBalance = _allFolioRunningBalance - _payAmount;
				}




				this.txtCurrentFolioRunningBalance.Text = _currentFolioRunningBalance.ToString(_decimalFormat);
				this.txtAllFolioRunningBalance.Text = _allFolioRunningBalance.ToString(_decimalFormat);
			}

			private void txtPayment_Amount_Leave(object sender, EventArgs e)
			{
				try
				{
					decimal _payAmount = decimal.Parse(this.txtPayment_Amount.Text);

					this.txtPayment_Amount.Text = _payAmount.ToString(_decimalFormat);
				}
				catch { }
			}

			private void txtServiceCharge_TextChanged(object sender, EventArgs e)
			{
				ComputeBaseAmount();
			}

			private void txtGovTax_TextChanged(object sender, EventArgs e)
			{
				ComputeBaseAmount();
			}

			private void txtLocalTax_TextChanged(object sender, EventArgs e)
			{
				ComputeBaseAmount();
			}

			private void cboTransSource_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (cboTransSource.Text.Contains("AUTO"))
				{
					this.txtReferenceNo.Text = "AUTO";
				}
                //else
                //{
                //    txtReferenceNo.Text = "";
                //}
			}

            private void cboPaymentTransSource_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cboPaymentTransSource.Text.Contains("AUTO"))
                {
                    this.txtPayment_ORNo.Text = "AUTO";
                }
                //else
                //{
                //    txtPayment_ORNo.Text = "";
                //}
            }

            private void chkAdjustment_CheckedChanged(object sender, EventArgs e)
            {
                //if (chkAdjustment.Checked == true)
                //{
                //    _shouldPost = false;
                //}
                //else
                //{
                //    _shouldPost = true;
                //}
            }

            private void chkAdjustment_VisibleChanged(object sender, EventArgs e)
            {
                if (chkAdjustment.Visible == false)
                {
                    chkAdjustment.Checked = false;
                    //_shouldPost = true;
                }
            }
            //DataTable loRateTypes;
            //private decimal getRate()
            //{
            //    RateTypeFacade _rateTypeFace = new RateTypeFacade();
            //    DataView _dv = new DataView();

            //    if (loRateTypes == null)
            //    {
            //        loRateTypes = _rateTypeFace.getRateTypes();
            //    }
            //    _dv = loRateTypes.DefaultView;
            //    _dv.RowFilter = "";
            //    _dv.RowFilter = "roomID = '" + pRoom + "' and ratecode = '" + pRateCode + "'";
            //}

            private void cboRoomID_SelectedIndexChanged(object sender, EventArgs e)
            {
                //if (txtTransactionCode.Text == ConfigVariables.gRoomChargeTransactionCode)
                //{
                //    txtCurAmount.Text = getRate();
                //}
            }

		}
	}
}