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
		public class AddDirectPostTransactionUI : System.Windows.Forms.Form
		{

            private string lMode = "";
            string _decimalFormat = ConfigVariables.gDecimalFormat;

			#region " Windows Form Designer generated code "
			
			public AddDirectPostTransactionUI(string pMode)
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();
                lMode = pMode;
				
				//Add any initialization after the InitializeComponent() call
				LoadTransactionCodes();
				loadTransactionCodeSubAccount();
				LoadCurrencyCodes();
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
            internal ComboBox cboTransSource;
            public Label label8;
            private DateTimePicker dtpTransactionDate;
			public Label label13;
			private GroupBox grbFolioInfo;
			private GroupBox grbPayment;
			public TextBox txtDiscountPercent;
			public Label label17;
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
			private ColumnHeader colServiceChargeInclusive;
			private ColumnHeader colGovtTaxInclusive;
			private ColumnHeader colLocalTaxInclusive;
			private ColumnHeader colDefaultSource;
			public TextBox txtDiscountAmount;
			public Label label41;
			public Label label20;
			public Label label19;
			public Label label18;
			public TextBox txtDepartureDate;
			public Label label5;
			public TextBox txtArrivalDate;
			public Label label40;
			public TextBox txtRoomNo;
			public Label label21;
			internal CheckBox chkWalkIn;
			internal Button btnBrowseFolioId;
			public TextBox txtGroupName;
			public Label label16;
			public TextBox txtGuestName;
			public Label label14;
			public TextBox txtFolioId;
			public Label label15;
			private GroupBox grbDriver;
			public TextBox txtMakeModel;
			public Label label43;
			public TextBox txtTotalCommission;
			public Label label39;
			public TextBox txtPlateNum;
			public Label label38;
			internal Button btnBrowseDriver;
			public TextBox txtCarCompany;
			public Label label36;
			public TextBox txtLicenseNumber;
			public Label label37;
			public TextBox txtDriverName;
			public Label label44;
			public TextBox txtDriverId;
			public Label label45;
			private Panel pnlPaymentTransSource;
			internal ComboBox cboPaymentTransSource;
			public Label label23;
            private Panel pnlPaymentSubAccount;
            public Label label46;
            internal ComboBox cboPaymentSubAccount;
            public TextBox txtReservationSource;
            public Label label47;
            public TextBox txtCardNumber;
            public Label lblCardNumber;
            private Panel pnlPayment_AccountID;
            public TextBox txtPayment_AccountID;
            public Label label48;
            internal Button btnSearchAccount;
            public TextBox txtPayment_AccountName;
			internal System.Windows.Forms.Button btnViewCodes;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
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
                this.grbFolioInfo = new System.Windows.Forms.GroupBox();
                this.txtCardNumber = new System.Windows.Forms.TextBox();
                this.lblCardNumber = new System.Windows.Forms.Label();
                this.txtReservationSource = new System.Windows.Forms.TextBox();
                this.label47 = new System.Windows.Forms.Label();
                this.txtDepartureDate = new System.Windows.Forms.TextBox();
                this.label5 = new System.Windows.Forms.Label();
                this.txtArrivalDate = new System.Windows.Forms.TextBox();
                this.label40 = new System.Windows.Forms.Label();
                this.txtRoomNo = new System.Windows.Forms.TextBox();
                this.label21 = new System.Windows.Forms.Label();
                this.chkWalkIn = new System.Windows.Forms.CheckBox();
                this.btnBrowseFolioId = new System.Windows.Forms.Button();
                this.txtGroupName = new System.Windows.Forms.TextBox();
                this.label16 = new System.Windows.Forms.Label();
                this.txtGuestName = new System.Windows.Forms.TextBox();
                this.label14 = new System.Windows.Forms.Label();
                this.txtFolioId = new System.Windows.Forms.TextBox();
                this.label15 = new System.Windows.Forms.Label();
                this.grbPayment = new System.Windows.Forms.GroupBox();
                this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
                this.pnlPaymentType = new System.Windows.Forms.Panel();
                this.label34 = new System.Windows.Forms.Label();
                this.cboPaymentTypes = new System.Windows.Forms.ComboBox();
                this.pnlPaymentSubAccount = new System.Windows.Forms.Panel();
                this.label46 = new System.Windows.Forms.Label();
                this.cboPaymentSubAccount = new System.Windows.Forms.ComboBox();
                this.pnlPaymentTransSource = new System.Windows.Forms.Panel();
                this.cboPaymentTransSource = new System.Windows.Forms.ComboBox();
                this.label23 = new System.Windows.Forms.Label();
                this.pnlOrNo = new System.Windows.Forms.Panel();
                this.txtPayment_ORNo = new System.Windows.Forms.TextBox();
                this.lblPayment_DocSource = new System.Windows.Forms.Label();
                this.pnlAmount = new System.Windows.Forms.Panel();
                this.txtPayment_Amount = new System.Windows.Forms.TextBox();
                this.label28 = new System.Windows.Forms.Label();
                this.pnlCardNo = new System.Windows.Forms.Panel();
                this.txtPayment_CardNo = new System.Windows.Forms.TextBox();
                this.label22 = new System.Windows.Forms.Label();
                this.pnlChequeNo = new System.Windows.Forms.Panel();
                this.txtPayment_Cheque = new System.Windows.Forms.TextBox();
                this.label24 = new System.Windows.Forms.Label();
                this.pnlPayment_AccountID = new System.Windows.Forms.Panel();
                this.txtPayment_AccountName = new System.Windows.Forms.TextBox();
                this.btnSearchAccount = new System.Windows.Forms.Button();
                this.txtPayment_AccountID = new System.Windows.Forms.TextBox();
                this.label48 = new System.Windows.Forms.Label();
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
                this.grbDriver = new System.Windows.Forms.GroupBox();
                this.txtMakeModel = new System.Windows.Forms.TextBox();
                this.label43 = new System.Windows.Forms.Label();
                this.txtTotalCommission = new System.Windows.Forms.TextBox();
                this.label39 = new System.Windows.Forms.Label();
                this.txtPlateNum = new System.Windows.Forms.TextBox();
                this.label38 = new System.Windows.Forms.Label();
                this.btnBrowseDriver = new System.Windows.Forms.Button();
                this.txtCarCompany = new System.Windows.Forms.TextBox();
                this.label36 = new System.Windows.Forms.Label();
                this.txtLicenseNumber = new System.Windows.Forms.TextBox();
                this.label37 = new System.Windows.Forms.Label();
                this.txtDriverName = new System.Windows.Forms.TextBox();
                this.label44 = new System.Windows.Forms.Label();
                this.txtDriverId = new System.Windows.Forms.TextBox();
                this.label45 = new System.Windows.Forms.Label();
                this.GroupBox1.SuspendLayout();
                this.pnlSubAccount.SuspendLayout();
                this.grbFolioInfo.SuspendLayout();
                this.grbPayment.SuspendLayout();
                this.flowLayoutPanel1.SuspendLayout();
                this.pnlPaymentType.SuspendLayout();
                this.pnlPaymentSubAccount.SuspendLayout();
                this.pnlPaymentTransSource.SuspendLayout();
                this.pnlOrNo.SuspendLayout();
                this.pnlAmount.SuspendLayout();
                this.pnlCardNo.SuspendLayout();
                this.pnlChequeNo.SuspendLayout();
                this.pnlPayment_AccountID.SuspendLayout();
                this.pnlAccount.SuspendLayout();
                this.pnlBank.SuspendLayout();
                this.pnlDate.SuspendLayout();
                this.pnlGrantedBy.SuspendLayout();
                this.pnlCardType.SuspendLayout();
                this.pnlCardApproval.SuspendLayout();
                this.pnlCardExpires.SuspendLayout();
                this.grbDriver.SuspendLayout();
                this.SuspendLayout();
                // 
                // Label42
                // 
                this.Label42.BackColor = System.Drawing.SystemColors.Control;
                this.Label42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label42.ForeColor = System.Drawing.Color.Black;
                this.Label42.Location = new System.Drawing.Point(21, 329);
                this.Label42.Name = "Label42";
                this.Label42.Size = new System.Drawing.Size(79, 16);
                this.Label42.TabIndex = 87;
                this.Label42.Text = "Reference # :";
                // 
                // txtReferenceNo
                // 
                this.txtReferenceNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtReferenceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtReferenceNo.Location = new System.Drawing.Point(119, 325);
                this.txtReferenceNo.MaxLength = 100;
                this.txtReferenceNo.Name = "txtReferenceNo";
                this.txtReferenceNo.Size = new System.Drawing.Size(159, 20);
                this.txtReferenceNo.TabIndex = 17;
                this.txtReferenceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferenceNo_KeyPress);
                // 
                // Label1
                // 
                this.Label1.BackColor = System.Drawing.SystemColors.Control;
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.ForeColor = System.Drawing.Color.Black;
                this.Label1.Location = new System.Drawing.Point(21, 94);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(72, 16);
                this.Label1.TabIndex = 89;
                this.Label1.Text = "Trans Code :";
                // 
                // txtTransactionCode
                // 
                this.txtTransactionCode.BackColor = System.Drawing.SystemColors.Info;
                this.txtTransactionCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtTransactionCode.Location = new System.Drawing.Point(119, 92);
                this.txtTransactionCode.MaxLength = 20;
                this.txtTransactionCode.Name = "txtTransactionCode";
                this.txtTransactionCode.Size = new System.Drawing.Size(80, 20);
                this.txtTransactionCode.TabIndex = 3;
                this.txtTransactionCode.LostFocus += new System.EventHandler(this.txtTransactionCode_LostFocus);
                this.txtTransactionCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransactionCode_KeyPress);
                // 
                // Label2
                // 
                this.Label2.BackColor = System.Drawing.SystemColors.Control;
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.ForeColor = System.Drawing.Color.Black;
                this.Label2.Location = new System.Drawing.Point(21, 125);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(48, 16);
                this.Label2.TabIndex = 91;
                this.Label2.Text = "Memo :";
                // 
                // txtMemo
                // 
                this.txtMemo.BackColor = System.Drawing.SystemColors.Info;
                this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtMemo.Location = new System.Drawing.Point(119, 120);
                this.txtMemo.MaxLength = 500;
                this.txtMemo.Name = "txtMemo";
                this.txtMemo.Size = new System.Drawing.Size(305, 20);
                this.txtMemo.TabIndex = 6;
                this.txtMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemo_KeyPress);
                // 
                // Label4
                // 
                this.Label4.BackColor = System.Drawing.SystemColors.Control;
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.ForeColor = System.Drawing.Color.Black;
                this.Label4.Location = new System.Drawing.Point(259, 154);
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
                this.Label6.Location = new System.Drawing.Point(21, 184);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(86, 16);
                this.Label6.TabIndex = 101;
                this.Label6.Text = "Gross Amount :";
                // 
                // txtBaseAmount
                // 
                this.txtBaseAmount.BackColor = System.Drawing.SystemColors.Control;
                this.txtBaseAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtBaseAmount.Location = new System.Drawing.Point(119, 182);
                this.txtBaseAmount.Name = "txtBaseAmount";
                this.txtBaseAmount.ReadOnly = true;
                this.txtBaseAmount.Size = new System.Drawing.Size(108, 20);
                this.txtBaseAmount.TabIndex = 9;
                this.txtBaseAmount.Text = "0.00";
                this.txtBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtBaseAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseAmount_KeyPress);
                // 
                // Label7
                // 
                this.Label7.BackColor = System.Drawing.SystemColors.Control;
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label7.ForeColor = System.Drawing.Color.Black;
                this.Label7.Location = new System.Drawing.Point(21, 154);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(99, 16);
                this.Label7.TabIndex = 103;
                this.Label7.Text = "Currency Amount :";
                // 
                // txtCurAmount
                // 
                this.txtCurAmount.BackColor = System.Drawing.SystemColors.Info;
                this.txtCurAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtCurAmount.Location = new System.Drawing.Point(119, 152);
                this.txtCurAmount.MaxLength = 15;
                this.txtCurAmount.Name = "txtCurAmount";
                this.txtCurAmount.Size = new System.Drawing.Size(108, 20);
                this.txtCurAmount.TabIndex = 7;
                this.txtCurAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtCurAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurAmount_KeyPress);
                this.txtCurAmount.TextChanged += new System.EventHandler(this.txtCurAmount_TextChanged);
                // 
                // btnCancel
                // 
                this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnCancel.Location = new System.Drawing.Point(656, 581);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(66, 31);
                this.btnCancel.TabIndex = 51;
                this.btnCancel.Text = "&Close";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnOk
                // 
                this.btnOk.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnOk.Location = new System.Drawing.Point(584, 581);
                this.btnOk.Name = "btnOk";
                this.btnOk.Size = new System.Drawing.Size(66, 31);
                this.btnOk.TabIndex = 50;
                this.btnOk.Text = "&Insert";
                this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
                // 
                // GroupBox1
                // 
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
                // label20
                // 
                this.label20.BackColor = System.Drawing.SystemColors.Control;
                this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label20.ForeColor = System.Drawing.Color.Black;
                this.label20.Location = new System.Drawing.Point(425, 277);
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
                this.label19.Location = new System.Drawing.Point(425, 249);
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
                this.label18.Location = new System.Drawing.Point(425, 219);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(18, 16);
                this.label18.TabIndex = 149;
                this.label18.Text = "%";
                // 
                // txtDiscountAmount
                // 
                this.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control;
                this.txtDiscountAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtDiscountAmount.Location = new System.Drawing.Point(119, 241);
                this.txtDiscountAmount.MaxLength = 15;
                this.txtDiscountAmount.Name = "txtDiscountAmount";
                this.txtDiscountAmount.ReadOnly = true;
                this.txtDiscountAmount.Size = new System.Drawing.Size(108, 20);
                this.txtDiscountAmount.TabIndex = 13;
                this.txtDiscountAmount.Text = "0.00";
                this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label41
                // 
                this.label41.BackColor = System.Drawing.SystemColors.Control;
                this.label41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label41.ForeColor = System.Drawing.Color.Black;
                this.label41.Location = new System.Drawing.Point(21, 243);
                this.label41.Name = "label41";
                this.label41.Size = new System.Drawing.Size(78, 16);
                this.label41.TabIndex = 148;
                this.label41.Text = "Discount Amt :";
                // 
                // txtNetBaseAmount
                // 
                this.txtNetBaseAmount.BackColor = System.Drawing.SystemColors.Control;
                this.txtNetBaseAmount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtNetBaseAmount.Location = new System.Drawing.Point(119, 271);
                this.txtNetBaseAmount.MaxLength = 15;
                this.txtNetBaseAmount.Name = "txtNetBaseAmount";
                this.txtNetBaseAmount.ReadOnly = true;
                this.txtNetBaseAmount.Size = new System.Drawing.Size(108, 29);
                this.txtNetBaseAmount.TabIndex = 15;
                this.txtNetBaseAmount.Text = "0.00";
                this.txtNetBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label35
                // 
                this.label35.BackColor = System.Drawing.SystemColors.Control;
                this.label35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label35.ForeColor = System.Drawing.Color.Black;
                this.label35.Location = new System.Drawing.Point(21, 277);
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
                this.cboAcctSide.Location = new System.Drawing.Point(313, 57);
                this.cboAcctSide.Name = "cboAcctSide";
                this.cboAcctSide.Size = new System.Drawing.Size(111, 22);
                this.cboAcctSide.TabIndex = 2;
                this.cboAcctSide.SelectedIndexChanged += new System.EventHandler(this.cboAcctSide_SelectedIndexChanged);
                // 
                // pnlSubAccount
                // 
                this.pnlSubAccount.Controls.Add(this.label33);
                this.pnlSubAccount.Controls.Add(this.cboSubAccount);
                this.pnlSubAccount.Location = new System.Drawing.Point(233, 89);
                this.pnlSubAccount.Name = "pnlSubAccount";
                this.pnlSubAccount.Size = new System.Drawing.Size(197, 27);
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
                this.cboSubAccount.Size = new System.Drawing.Size(111, 22);
                this.cboSubAccount.TabIndex = 5;
                this.cboSubAccount.SelectedIndexChanged += new System.EventHandler(this.cboSubAccount_SelectedIndexChanged);
                // 
                // txtDiscountPercent
                // 
                this.txtDiscountPercent.BackColor = System.Drawing.Color.White;
                this.txtDiscountPercent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtDiscountPercent.Location = new System.Drawing.Point(119, 212);
                this.txtDiscountPercent.MaxLength = 15;
                this.txtDiscountPercent.Name = "txtDiscountPercent";
                this.txtDiscountPercent.Size = new System.Drawing.Size(108, 20);
                this.txtDiscountPercent.TabIndex = 11;
                this.txtDiscountPercent.Text = "0.00";
                this.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtDiscountPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
                this.txtDiscountPercent.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
                // 
                // label17
                // 
                this.label17.BackColor = System.Drawing.SystemColors.Control;
                this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label17.ForeColor = System.Drawing.Color.Black;
                this.label17.Location = new System.Drawing.Point(21, 214);
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
                this.dtpTransactionDate.Location = new System.Drawing.Point(119, 58);
                this.dtpTransactionDate.Name = "dtpTransactionDate";
                this.dtpTransactionDate.Size = new System.Drawing.Size(80, 20);
                this.dtpTransactionDate.TabIndex = 1;
                // 
                // label13
                // 
                this.label13.BackColor = System.Drawing.SystemColors.Control;
                this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label13.ForeColor = System.Drawing.Color.Black;
                this.label13.Location = new System.Drawing.Point(21, 60);
                this.label13.Name = "label13";
                this.label13.Size = new System.Drawing.Size(72, 16);
                this.label13.TabIndex = 136;
                this.label13.Text = "Trans. Date :";
                // 
                // cboTransSource
                // 
                this.cboTransSource.BackColor = System.Drawing.Color.White;
                this.cboTransSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboTransSource.Items.AddRange(new object[] {
            "ORDER SLIP",
            "CHARGE INVOICE",
            "SALES INVOICE"});
                this.cboTransSource.Location = new System.Drawing.Point(119, 355);
                this.cboTransSource.Name = "cboTransSource";
                this.cboTransSource.Size = new System.Drawing.Size(159, 22);
                this.cboTransSource.TabIndex = 18;
                this.cboTransSource.SelectedIndexChanged += new System.EventHandler(this.cboTransSource_SelectedIndexChanged);
                this.cboTransSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTransSource_KeyPress);
                // 
                // label8
                // 
                this.label8.BackColor = System.Drawing.SystemColors.Control;
                this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label8.ForeColor = System.Drawing.Color.Black;
                this.label8.Location = new System.Drawing.Point(21, 359);
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
                this.btnViewCodes.Location = new System.Drawing.Point(203, 89);
                this.btnViewCodes.Name = "btnViewCodes";
                this.btnViewCodes.Size = new System.Drawing.Size(27, 26);
                this.btnViewCodes.TabIndex = 4;
                this.btnViewCodes.Click += new System.EventHandler(this.btnViewCodes_Click);
                // 
                // cboCurrencyRate
                // 
                this.cboCurrencyRate.BackColor = System.Drawing.Color.White;
                this.cboCurrencyRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboCurrencyRate.Location = new System.Drawing.Point(344, 181);
                this.cboCurrencyRate.Name = "cboCurrencyRate";
                this.cboCurrencyRate.Size = new System.Drawing.Size(80, 22);
                this.cboCurrencyRate.TabIndex = 10;
                this.cboCurrencyRate.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyRate_SelectedIndexChanged);
                // 
                // Label3
                // 
                this.Label3.BackColor = System.Drawing.SystemColors.Control;
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.ForeColor = System.Drawing.Color.Black;
                this.Label3.Location = new System.Drawing.Point(259, 184);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(79, 16);
                this.Label3.TabIndex = 127;
                this.Label3.Text = "Rate :";
                // 
                // cboCurrencyCode
                // 
                this.cboCurrencyCode.BackColor = System.Drawing.Color.White;
                this.cboCurrencyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboCurrencyCode.Location = new System.Drawing.Point(344, 151);
                this.cboCurrencyCode.Name = "cboCurrencyCode";
                this.cboCurrencyCode.Size = new System.Drawing.Size(80, 22);
                this.cboCurrencyCode.TabIndex = 8;
                this.cboCurrencyCode.SelectedIndexChanged += new System.EventHandler(this.cboCurrencyCode_SelectedIndexChanged);
                // 
                // txtServiceCharge
                // 
                this.txtServiceCharge.BackColor = System.Drawing.SystemColors.Control;
                this.txtServiceCharge.Location = new System.Drawing.Point(344, 212);
                this.txtServiceCharge.Name = "txtServiceCharge";
                this.txtServiceCharge.ReadOnly = true;
                this.txtServiceCharge.Size = new System.Drawing.Size(80, 20);
                this.txtServiceCharge.TabIndex = 12;
                this.txtServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtLocalTax
                // 
                this.txtLocalTax.BackColor = System.Drawing.SystemColors.Control;
                this.txtLocalTax.Location = new System.Drawing.Point(344, 271);
                this.txtLocalTax.Name = "txtLocalTax";
                this.txtLocalTax.ReadOnly = true;
                this.txtLocalTax.Size = new System.Drawing.Size(80, 20);
                this.txtLocalTax.TabIndex = 16;
                this.txtLocalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtGovTax
                // 
                this.txtGovTax.BackColor = System.Drawing.SystemColors.Control;
                this.txtGovTax.Location = new System.Drawing.Point(344, 241);
                this.txtGovTax.Name = "txtGovTax";
                this.txtGovTax.ReadOnly = true;
                this.txtGovTax.Size = new System.Drawing.Size(80, 20);
                this.txtGovTax.TabIndex = 14;
                this.txtGovTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // Label9
                // 
                this.Label9.BackColor = System.Drawing.SystemColors.Control;
                this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label9.ForeColor = System.Drawing.Color.Black;
                this.Label9.Location = new System.Drawing.Point(240, 60);
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
                this.Label12.Location = new System.Drawing.Point(259, 273);
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
                this.Label11.Location = new System.Drawing.Point(259, 243);
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
                this.Label10.Location = new System.Drawing.Point(259, 214);
                this.Label10.Name = "Label10";
                this.Label10.Size = new System.Drawing.Size(79, 16);
                this.Label10.TabIndex = 120;
                this.Label10.Text = "Service Chrg :";
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
                // grbFolioInfo
                // 
                this.grbFolioInfo.Controls.Add(this.txtCardNumber);
                this.grbFolioInfo.Controls.Add(this.lblCardNumber);
                this.grbFolioInfo.Controls.Add(this.txtReservationSource);
                this.grbFolioInfo.Controls.Add(this.label47);
                this.grbFolioInfo.Controls.Add(this.txtDepartureDate);
                this.grbFolioInfo.Controls.Add(this.label5);
                this.grbFolioInfo.Controls.Add(this.txtArrivalDate);
                this.grbFolioInfo.Controls.Add(this.label40);
                this.grbFolioInfo.Controls.Add(this.txtRoomNo);
                this.grbFolioInfo.Controls.Add(this.label21);
                this.grbFolioInfo.Controls.Add(this.chkWalkIn);
                this.grbFolioInfo.Controls.Add(this.btnBrowseFolioId);
                this.grbFolioInfo.Controls.Add(this.txtGroupName);
                this.grbFolioInfo.Controls.Add(this.label16);
                this.grbFolioInfo.Controls.Add(this.txtGuestName);
                this.grbFolioInfo.Controls.Add(this.label14);
                this.grbFolioInfo.Controls.Add(this.txtFolioId);
                this.grbFolioInfo.Controls.Add(this.label15);
                this.grbFolioInfo.Location = new System.Drawing.Point(12, 12);
                this.grbFolioInfo.Name = "grbFolioInfo";
                this.grbFolioInfo.Size = new System.Drawing.Size(383, 200);
                this.grbFolioInfo.TabIndex = 4;
                this.grbFolioInfo.TabStop = false;
                this.grbFolioInfo.Text = "Folio Information";
                // 
                // txtCardNumber
                // 
                this.txtCardNumber.BackColor = System.Drawing.SystemColors.Info;
                this.txtCardNumber.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtCardNumber.Location = new System.Drawing.Point(114, 165);
                this.txtCardNumber.Name = "txtCardNumber";
                this.txtCardNumber.ReadOnly = true;
                this.txtCardNumber.Size = new System.Drawing.Size(230, 20);
                this.txtCardNumber.TabIndex = 143;
                // 
                // lblCardNumber
                // 
                this.lblCardNumber.BackColor = System.Drawing.SystemColors.Control;
                this.lblCardNumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblCardNumber.ForeColor = System.Drawing.Color.Black;
                this.lblCardNumber.Location = new System.Drawing.Point(38, 167);
                this.lblCardNumber.Name = "lblCardNumber";
                this.lblCardNumber.Size = new System.Drawing.Size(76, 18);
                this.lblCardNumber.TabIndex = 144;
                this.lblCardNumber.Text = "Card No. :";
                // 
                // txtReservationSource
                // 
                this.txtReservationSource.BackColor = System.Drawing.SystemColors.Info;
                this.txtReservationSource.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtReservationSource.Location = new System.Drawing.Point(271, 139);
                this.txtReservationSource.Name = "txtReservationSource";
                this.txtReservationSource.ReadOnly = true;
                this.txtReservationSource.Size = new System.Drawing.Size(73, 20);
                this.txtReservationSource.TabIndex = 141;
                // 
                // label47
                // 
                this.label47.BackColor = System.Drawing.SystemColors.Control;
                this.label47.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label47.ForeColor = System.Drawing.Color.Black;
                this.label47.Location = new System.Drawing.Point(195, 141);
                this.label47.Name = "label47";
                this.label47.Size = new System.Drawing.Size(75, 16);
                this.label47.TabIndex = 142;
                this.label47.Text = "Res. Source :";
                // 
                // txtDepartureDate
                // 
                this.txtDepartureDate.BackColor = System.Drawing.SystemColors.Info;
                this.txtDepartureDate.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtDepartureDate.Location = new System.Drawing.Point(271, 113);
                this.txtDepartureDate.Name = "txtDepartureDate";
                this.txtDepartureDate.ReadOnly = true;
                this.txtDepartureDate.Size = new System.Drawing.Size(73, 20);
                this.txtDepartureDate.TabIndex = 140;
                // 
                // label5
                // 
                this.label5.BackColor = System.Drawing.SystemColors.Control;
                this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label5.ForeColor = System.Drawing.Color.Black;
                this.label5.Location = new System.Drawing.Point(195, 115);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(75, 18);
                this.label5.TabIndex = 139;
                this.label5.Text = "Departure :";
                // 
                // txtArrivalDate
                // 
                this.txtArrivalDate.BackColor = System.Drawing.SystemColors.Info;
                this.txtArrivalDate.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtArrivalDate.Location = new System.Drawing.Point(114, 113);
                this.txtArrivalDate.Name = "txtArrivalDate";
                this.txtArrivalDate.ReadOnly = true;
                this.txtArrivalDate.Size = new System.Drawing.Size(73, 20);
                this.txtArrivalDate.TabIndex = 137;
                // 
                // label40
                // 
                this.label40.BackColor = System.Drawing.SystemColors.Control;
                this.label40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label40.ForeColor = System.Drawing.Color.Black;
                this.label40.Location = new System.Drawing.Point(38, 115);
                this.label40.Name = "label40";
                this.label40.Size = new System.Drawing.Size(75, 16);
                this.label40.TabIndex = 138;
                this.label40.Text = "Arrival :";
                // 
                // txtRoomNo
                // 
                this.txtRoomNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtRoomNo.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtRoomNo.Location = new System.Drawing.Point(114, 139);
                this.txtRoomNo.Name = "txtRoomNo";
                this.txtRoomNo.ReadOnly = true;
                this.txtRoomNo.Size = new System.Drawing.Size(73, 20);
                this.txtRoomNo.TabIndex = 135;
                // 
                // label21
                // 
                this.label21.BackColor = System.Drawing.SystemColors.Control;
                this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label21.ForeColor = System.Drawing.Color.Black;
                this.label21.Location = new System.Drawing.Point(38, 141);
                this.label21.Name = "label21";
                this.label21.Size = new System.Drawing.Size(75, 16);
                this.label21.TabIndex = 136;
                this.label21.Text = "Room No. :";
                // 
                // chkWalkIn
                // 
                this.chkWalkIn.Location = new System.Drawing.Point(274, 33);
                this.chkWalkIn.Name = "chkWalkIn";
                this.chkWalkIn.Size = new System.Drawing.Size(66, 18);
                this.chkWalkIn.TabIndex = 129;
                this.chkWalkIn.Text = "Walk In";
                this.chkWalkIn.CheckedChanged += new System.EventHandler(this.chkWalkIn_CheckedChanged);
                // 
                // btnBrowseFolioId
                // 
                this.btnBrowseFolioId.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnBrowseFolioId.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnBrowseFolioId.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
                this.btnBrowseFolioId.Location = new System.Drawing.Point(234, 27);
                this.btnBrowseFolioId.Name = "btnBrowseFolioId";
                this.btnBrowseFolioId.Size = new System.Drawing.Size(27, 26);
                this.btnBrowseFolioId.TabIndex = 128;
                this.btnBrowseFolioId.Click += new System.EventHandler(this.btnBrowseFolioId_Click);
                // 
                // txtGroupName
                // 
                this.txtGroupName.BackColor = System.Drawing.SystemColors.Info;
                this.txtGroupName.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtGroupName.Location = new System.Drawing.Point(114, 86);
                this.txtGroupName.Name = "txtGroupName";
                this.txtGroupName.ReadOnly = true;
                this.txtGroupName.Size = new System.Drawing.Size(230, 20);
                this.txtGroupName.TabIndex = 131;
                // 
                // label16
                // 
                this.label16.BackColor = System.Drawing.SystemColors.Control;
                this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label16.ForeColor = System.Drawing.Color.Black;
                this.label16.Location = new System.Drawing.Point(38, 88);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(75, 16);
                this.label16.TabIndex = 134;
                this.label16.Text = "Group Name :";
                // 
                // txtGuestName
                // 
                this.txtGuestName.BackColor = System.Drawing.SystemColors.Info;
                this.txtGuestName.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtGuestName.Location = new System.Drawing.Point(114, 58);
                this.txtGuestName.Name = "txtGuestName";
                this.txtGuestName.ReadOnly = true;
                this.txtGuestName.Size = new System.Drawing.Size(230, 20);
                this.txtGuestName.TabIndex = 130;
                // 
                // label14
                // 
                this.label14.BackColor = System.Drawing.SystemColors.Control;
                this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label14.ForeColor = System.Drawing.Color.Black;
                this.label14.Location = new System.Drawing.Point(38, 60);
                this.label14.Name = "label14";
                this.label14.Size = new System.Drawing.Size(75, 16);
                this.label14.TabIndex = 133;
                this.label14.Text = "Guest Name :";
                // 
                // txtFolioId
                // 
                this.txtFolioId.BackColor = System.Drawing.SystemColors.Info;
                this.txtFolioId.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtFolioId.Location = new System.Drawing.Point(114, 30);
                this.txtFolioId.Name = "txtFolioId";
                this.txtFolioId.Size = new System.Drawing.Size(111, 20);
                this.txtFolioId.TabIndex = 127;
                this.txtFolioId.Leave += new System.EventHandler(this.txtFolioId_Leave);
                this.txtFolioId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolioId_KeyPress);
                // 
                // label15
                // 
                this.label15.BackColor = System.Drawing.SystemColors.Control;
                this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label15.ForeColor = System.Drawing.Color.Black;
                this.label15.Location = new System.Drawing.Point(38, 32);
                this.label15.Name = "label15";
                this.label15.Size = new System.Drawing.Size(75, 16);
                this.label15.TabIndex = 132;
                this.label15.Text = "Folio Id :";
                // 
                // grbPayment
                // 
                this.grbPayment.Controls.Add(this.flowLayoutPanel1);
                this.grbPayment.Location = new System.Drawing.Point(476, 220);
                this.grbPayment.Name = "grbPayment";
                this.grbPayment.Size = new System.Drawing.Size(265, 402);
                this.grbPayment.TabIndex = 19;
                this.grbPayment.TabStop = false;
                this.grbPayment.Text = "Payment";
                // 
                // flowLayoutPanel1
                // 
                this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this.flowLayoutPanel1.Controls.Add(this.pnlPaymentType);
                this.flowLayoutPanel1.Controls.Add(this.pnlPaymentSubAccount);
                this.flowLayoutPanel1.Controls.Add(this.pnlPaymentTransSource);
                this.flowLayoutPanel1.Controls.Add(this.pnlOrNo);
                this.flowLayoutPanel1.Controls.Add(this.pnlAmount);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardNo);
                this.flowLayoutPanel1.Controls.Add(this.pnlChequeNo);
                this.flowLayoutPanel1.Controls.Add(this.pnlPayment_AccountID);
                this.flowLayoutPanel1.Controls.Add(this.pnlAccount);
                this.flowLayoutPanel1.Controls.Add(this.pnlBank);
                this.flowLayoutPanel1.Controls.Add(this.pnlDate);
                this.flowLayoutPanel1.Controls.Add(this.pnlGrantedBy);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardType);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardApproval);
                this.flowLayoutPanel1.Controls.Add(this.pnlCardExpires);
                this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 20);
                this.flowLayoutPanel1.Name = "flowLayoutPanel1";
                this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 331);
                this.flowLayoutPanel1.TabIndex = 20;
                // 
                // pnlPaymentType
                // 
                this.pnlPaymentType.Controls.Add(this.label34);
                this.pnlPaymentType.Controls.Add(this.cboPaymentTypes);
                this.pnlPaymentType.Location = new System.Drawing.Point(3, 3);
                this.pnlPaymentType.Name = "pnlPaymentType";
                this.pnlPaymentType.Size = new System.Drawing.Size(243, 27);
                this.pnlPaymentType.TabIndex = 21;
                this.pnlPaymentType.Visible = false;
                // 
                // label34
                // 
                this.label34.BackColor = System.Drawing.SystemColors.Control;
                this.label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label34.ForeColor = System.Drawing.Color.Black;
                this.label34.Location = new System.Drawing.Point(3, 6);
                this.label34.Name = "label34";
                this.label34.Size = new System.Drawing.Size(72, 16);
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
                this.cboPaymentTypes.Location = new System.Drawing.Point(88, 2);
                this.cboPaymentTypes.Name = "cboPaymentTypes";
                this.cboPaymentTypes.Size = new System.Drawing.Size(147, 22);
                this.cboPaymentTypes.TabIndex = 19;
                this.cboPaymentTypes.SelectedIndexChanged += new System.EventHandler(this.cboPaymentTypes_SelectedIndexChanged);
                // 
                // pnlPaymentSubAccount
                // 
                this.pnlPaymentSubAccount.Controls.Add(this.label46);
                this.pnlPaymentSubAccount.Controls.Add(this.cboPaymentSubAccount);
                this.pnlPaymentSubAccount.Location = new System.Drawing.Point(3, 36);
                this.pnlPaymentSubAccount.Name = "pnlPaymentSubAccount";
                this.pnlPaymentSubAccount.Size = new System.Drawing.Size(243, 27);
                this.pnlPaymentSubAccount.TabIndex = 34;
                this.pnlPaymentSubAccount.Visible = false;
                // 
                // label46
                // 
                this.label46.BackColor = System.Drawing.SystemColors.Control;
                this.label46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label46.ForeColor = System.Drawing.Color.Black;
                this.label46.Location = new System.Drawing.Point(3, 5);
                this.label46.Name = "label46";
                this.label46.Size = new System.Drawing.Size(72, 16);
                this.label46.TabIndex = 144;
                this.label46.Text = "Sub Account";
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
                this.cboPaymentSubAccount.Location = new System.Drawing.Point(88, 2);
                this.cboPaymentSubAccount.Name = "cboPaymentSubAccount";
                this.cboPaymentSubAccount.Size = new System.Drawing.Size(147, 22);
                this.cboPaymentSubAccount.TabIndex = 20;
                // 
                // pnlPaymentTransSource
                // 
                this.pnlPaymentTransSource.Controls.Add(this.cboPaymentTransSource);
                this.pnlPaymentTransSource.Controls.Add(this.label23);
                this.pnlPaymentTransSource.Location = new System.Drawing.Point(3, 69);
                this.pnlPaymentTransSource.Name = "pnlPaymentTransSource";
                this.pnlPaymentTransSource.Size = new System.Drawing.Size(243, 27);
                this.pnlPaymentTransSource.TabIndex = 22;
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
                this.cboPaymentTransSource.Location = new System.Drawing.Point(88, 4);
                this.cboPaymentTransSource.Name = "cboPaymentTransSource";
                this.cboPaymentTransSource.Size = new System.Drawing.Size(148, 22);
                this.cboPaymentTransSource.TabIndex = 21;
                this.cboPaymentTransSource.SelectedIndexChanged += new System.EventHandler(this.cboPaymentTransSource_SelectedIndexChanged);
                // 
                // label23
                // 
                this.label23.BackColor = System.Drawing.SystemColors.Control;
                this.label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label23.ForeColor = System.Drawing.Color.Black;
                this.label23.Location = new System.Drawing.Point(3, 6);
                this.label23.Name = "label23";
                this.label23.Size = new System.Drawing.Size(78, 16);
                this.label23.TabIndex = 124;
                this.label23.Text = "Source :";
                // 
                // pnlOrNo
                // 
                this.pnlOrNo.Controls.Add(this.txtPayment_ORNo);
                this.pnlOrNo.Controls.Add(this.lblPayment_DocSource);
                this.pnlOrNo.Location = new System.Drawing.Point(3, 102);
                this.pnlOrNo.Name = "pnlOrNo";
                this.pnlOrNo.Size = new System.Drawing.Size(243, 27);
                this.pnlOrNo.TabIndex = 23;
                this.pnlOrNo.Visible = false;
                // 
                // txtPayment_ORNo
                // 
                this.txtPayment_ORNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_ORNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_ORNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_ORNo.Location = new System.Drawing.Point(88, 3);
                this.txtPayment_ORNo.MaxLength = 100;
                this.txtPayment_ORNo.Name = "txtPayment_ORNo";
                this.txtPayment_ORNo.Size = new System.Drawing.Size(148, 20);
                this.txtPayment_ORNo.TabIndex = 22;
                this.txtPayment_ORNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayment_ORNo_KeyPress);
                // 
                // lblPayment_DocSource
                // 
                this.lblPayment_DocSource.BackColor = System.Drawing.SystemColors.Control;
                this.lblPayment_DocSource.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblPayment_DocSource.ForeColor = System.Drawing.Color.Black;
                this.lblPayment_DocSource.Location = new System.Drawing.Point(3, 6);
                this.lblPayment_DocSource.Name = "lblPayment_DocSource";
                this.lblPayment_DocSource.Size = new System.Drawing.Size(75, 16);
                this.lblPayment_DocSource.TabIndex = 130;
                this.lblPayment_DocSource.Text = "Ref. No. :";
                // 
                // pnlAmount
                // 
                this.pnlAmount.Controls.Add(this.txtPayment_Amount);
                this.pnlAmount.Controls.Add(this.label28);
                this.pnlAmount.Location = new System.Drawing.Point(3, 135);
                this.pnlAmount.Name = "pnlAmount";
                this.pnlAmount.Size = new System.Drawing.Size(243, 27);
                this.pnlAmount.TabIndex = 24;
                this.pnlAmount.Visible = false;
                // 
                // txtPayment_Amount
                // 
                this.txtPayment_Amount.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Amount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Amount.Location = new System.Drawing.Point(88, 5);
                this.txtPayment_Amount.MaxLength = 15;
                this.txtPayment_Amount.Name = "txtPayment_Amount";
                this.txtPayment_Amount.Size = new System.Drawing.Size(82, 20);
                this.txtPayment_Amount.TabIndex = 23;
                this.txtPayment_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtPayment_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayment_Amount_KeyPress);
                // 
                // label28
                // 
                this.label28.BackColor = System.Drawing.SystemColors.Control;
                this.label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label28.ForeColor = System.Drawing.Color.Black;
                this.label28.Location = new System.Drawing.Point(3, 7);
                this.label28.Name = "label28";
                this.label28.Size = new System.Drawing.Size(75, 16);
                this.label28.TabIndex = 132;
                this.label28.Text = "Amount :";
                // 
                // pnlCardNo
                // 
                this.pnlCardNo.Controls.Add(this.txtPayment_CardNo);
                this.pnlCardNo.Controls.Add(this.label22);
                this.pnlCardNo.Location = new System.Drawing.Point(3, 168);
                this.pnlCardNo.Name = "pnlCardNo";
                this.pnlCardNo.Size = new System.Drawing.Size(243, 27);
                this.pnlCardNo.TabIndex = 25;
                this.pnlCardNo.Visible = false;
                // 
                // txtPayment_CardNo
                // 
                this.txtPayment_CardNo.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_CardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_CardNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_CardNo.Location = new System.Drawing.Point(88, 4);
                this.txtPayment_CardNo.MaxLength = 16;
                this.txtPayment_CardNo.Name = "txtPayment_CardNo";
                this.txtPayment_CardNo.Size = new System.Drawing.Size(148, 20);
                this.txtPayment_CardNo.TabIndex = 24;
                // 
                // label22
                // 
                this.label22.BackColor = System.Drawing.SystemColors.Control;
                this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label22.ForeColor = System.Drawing.Color.Black;
                this.label22.Location = new System.Drawing.Point(3, 7);
                this.label22.Name = "label22";
                this.label22.Size = new System.Drawing.Size(75, 16);
                this.label22.TabIndex = 114;
                this.label22.Text = "Card # :";
                // 
                // pnlChequeNo
                // 
                this.pnlChequeNo.Controls.Add(this.txtPayment_Cheque);
                this.pnlChequeNo.Controls.Add(this.label24);
                this.pnlChequeNo.Location = new System.Drawing.Point(3, 201);
                this.pnlChequeNo.Name = "pnlChequeNo";
                this.pnlChequeNo.Size = new System.Drawing.Size(243, 27);
                this.pnlChequeNo.TabIndex = 26;
                this.pnlChequeNo.Visible = false;
                // 
                // txtPayment_Cheque
                // 
                this.txtPayment_Cheque.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Cheque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Cheque.Location = new System.Drawing.Point(88, 4);
                this.txtPayment_Cheque.MaxLength = 100;
                this.txtPayment_Cheque.Name = "txtPayment_Cheque";
                this.txtPayment_Cheque.Size = new System.Drawing.Size(148, 20);
                this.txtPayment_Cheque.TabIndex = 25;
                // 
                // label24
                // 
                this.label24.BackColor = System.Drawing.SystemColors.Control;
                this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label24.ForeColor = System.Drawing.Color.Black;
                this.label24.Location = new System.Drawing.Point(3, 7);
                this.label24.Name = "label24";
                this.label24.Size = new System.Drawing.Size(75, 16);
                this.label24.TabIndex = 122;
                this.label24.Text = "Cheque # :";
                // 
                // pnlPayment_AccountID
                // 
                this.pnlPayment_AccountID.Controls.Add(this.txtPayment_AccountName);
                this.pnlPayment_AccountID.Controls.Add(this.btnSearchAccount);
                this.pnlPayment_AccountID.Controls.Add(this.txtPayment_AccountID);
                this.pnlPayment_AccountID.Controls.Add(this.label48);
                this.pnlPayment_AccountID.Location = new System.Drawing.Point(3, 234);
                this.pnlPayment_AccountID.Name = "pnlPayment_AccountID";
                this.pnlPayment_AccountID.Size = new System.Drawing.Size(243, 27);
                this.pnlPayment_AccountID.TabIndex = 131;
                this.pnlPayment_AccountID.Visible = false;
                // 
                // txtPayment_AccountName
                // 
                this.txtPayment_AccountName.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_AccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_AccountName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_AccountName.Location = new System.Drawing.Point(88, 3);
                this.txtPayment_AccountName.MaxLength = 100;
                this.txtPayment_AccountName.Name = "txtPayment_AccountName";
                this.txtPayment_AccountName.Size = new System.Drawing.Size(119, 20);
                this.txtPayment_AccountName.TabIndex = 132;
                // 
                // btnSearchAccount
                // 
                this.btnSearchAccount.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnSearchAccount.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnSearchAccount.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
                this.btnSearchAccount.Location = new System.Drawing.Point(209, 2);
                this.btnSearchAccount.Name = "btnSearchAccount";
                this.btnSearchAccount.Size = new System.Drawing.Size(27, 22);
                this.btnSearchAccount.TabIndex = 131;
                this.btnSearchAccount.Click += new System.EventHandler(this.btnSearchAccount_Click);
                // 
                // txtPayment_AccountID
                // 
                this.txtPayment_AccountID.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_AccountID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_AccountID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_AccountID.Location = new System.Drawing.Point(88, 3);
                this.txtPayment_AccountID.MaxLength = 100;
                this.txtPayment_AccountID.Name = "txtPayment_AccountID";
                this.txtPayment_AccountID.Size = new System.Drawing.Size(100, 20);
                this.txtPayment_AccountID.TabIndex = 22;
                // 
                // label48
                // 
                this.label48.BackColor = System.Drawing.SystemColors.Control;
                this.label48.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label48.ForeColor = System.Drawing.Color.Black;
                this.label48.Location = new System.Drawing.Point(3, 6);
                this.label48.Name = "label48";
                this.label48.Size = new System.Drawing.Size(75, 16);
                this.label48.TabIndex = 130;
                this.label48.Text = "Account ID :";
                // 
                // pnlAccount
                // 
                this.pnlAccount.Controls.Add(this.txtPayment_Account);
                this.pnlAccount.Controls.Add(this.label26);
                this.pnlAccount.Location = new System.Drawing.Point(3, 267);
                this.pnlAccount.Name = "pnlAccount";
                this.pnlAccount.Size = new System.Drawing.Size(243, 27);
                this.pnlAccount.TabIndex = 27;
                this.pnlAccount.Visible = false;
                // 
                // txtPayment_Account
                // 
                this.txtPayment_Account.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Account.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Account.Location = new System.Drawing.Point(88, 3);
                this.txtPayment_Account.MaxLength = 100;
                this.txtPayment_Account.Name = "txtPayment_Account";
                this.txtPayment_Account.Size = new System.Drawing.Size(148, 20);
                this.txtPayment_Account.TabIndex = 26;
                // 
                // label26
                // 
                this.label26.BackColor = System.Drawing.SystemColors.Control;
                this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label26.ForeColor = System.Drawing.Color.Black;
                this.label26.Location = new System.Drawing.Point(3, 7);
                this.label26.Name = "label26";
                this.label26.Size = new System.Drawing.Size(75, 16);
                this.label26.TabIndex = 126;
                this.label26.Text = "Account :";
                // 
                // pnlBank
                // 
                this.pnlBank.Controls.Add(this.txtPayment_Bank);
                this.pnlBank.Controls.Add(this.label27);
                this.pnlBank.Location = new System.Drawing.Point(3, 300);
                this.pnlBank.Name = "pnlBank";
                this.pnlBank.Size = new System.Drawing.Size(243, 27);
                this.pnlBank.TabIndex = 28;
                this.pnlBank.Visible = false;
                // 
                // txtPayment_Bank
                // 
                this.txtPayment_Bank.BackColor = System.Drawing.SystemColors.Info;
                this.txtPayment_Bank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPayment_Bank.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPayment_Bank.Location = new System.Drawing.Point(88, 4);
                this.txtPayment_Bank.MaxLength = 100;
                this.txtPayment_Bank.Name = "txtPayment_Bank";
                this.txtPayment_Bank.Size = new System.Drawing.Size(148, 20);
                this.txtPayment_Bank.TabIndex = 27;
                // 
                // label27
                // 
                this.label27.BackColor = System.Drawing.SystemColors.Control;
                this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label27.ForeColor = System.Drawing.Color.Black;
                this.label27.Location = new System.Drawing.Point(3, 7);
                this.label27.Name = "label27";
                this.label27.Size = new System.Drawing.Size(75, 16);
                this.label27.TabIndex = 128;
                this.label27.Text = "Bank :";
                // 
                // pnlDate
                // 
                this.pnlDate.Controls.Add(this.dtpPayment_Date);
                this.pnlDate.Controls.Add(this.label25);
                this.pnlDate.Location = new System.Drawing.Point(3, 333);
                this.pnlDate.Name = "pnlDate";
                this.pnlDate.Size = new System.Drawing.Size(243, 27);
                this.pnlDate.TabIndex = 29;
                this.pnlDate.Visible = false;
                // 
                // dtpPayment_Date
                // 
                this.dtpPayment_Date.CalendarMonthBackground = System.Drawing.Color.White;
                this.dtpPayment_Date.CalendarTitleForeColor = System.Drawing.Color.White;
                this.dtpPayment_Date.CustomFormat = "MMM. dd, yyyy";
                this.dtpPayment_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                this.dtpPayment_Date.Location = new System.Drawing.Point(88, 3);
                this.dtpPayment_Date.Name = "dtpPayment_Date";
                this.dtpPayment_Date.Size = new System.Drawing.Size(82, 20);
                this.dtpPayment_Date.TabIndex = 28;
                // 
                // label25
                // 
                this.label25.BackColor = System.Drawing.SystemColors.Control;
                this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label25.ForeColor = System.Drawing.Color.Black;
                this.label25.Location = new System.Drawing.Point(3, 6);
                this.label25.Name = "label25";
                this.label25.Size = new System.Drawing.Size(78, 16);
                this.label25.TabIndex = 124;
                this.label25.Text = "Cheque Date :";
                // 
                // pnlGrantedBy
                // 
                this.pnlGrantedBy.Controls.Add(this.txtGrantedBy);
                this.pnlGrantedBy.Controls.Add(this.label29);
                this.pnlGrantedBy.Location = new System.Drawing.Point(3, 366);
                this.pnlGrantedBy.Name = "pnlGrantedBy";
                this.pnlGrantedBy.Size = new System.Drawing.Size(243, 27);
                this.pnlGrantedBy.TabIndex = 30;
                this.pnlGrantedBy.Visible = false;
                // 
                // txtGrantedBy
                // 
                this.txtGrantedBy.BackColor = System.Drawing.SystemColors.Info;
                this.txtGrantedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtGrantedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtGrantedBy.Location = new System.Drawing.Point(88, 3);
                this.txtGrantedBy.MaxLength = 100;
                this.txtGrantedBy.Name = "txtGrantedBy";
                this.txtGrantedBy.Size = new System.Drawing.Size(142, 20);
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
                this.pnlCardType.Location = new System.Drawing.Point(3, 399);
                this.pnlCardType.Name = "pnlCardType";
                this.pnlCardType.Size = new System.Drawing.Size(243, 27);
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
                this.txtCardType.Location = new System.Drawing.Point(88, 3);
                this.txtCardType.MaxLength = 100;
                this.txtCardType.Name = "txtCardType";
                this.txtCardType.Size = new System.Drawing.Size(142, 20);
                this.txtCardType.TabIndex = 31;
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
                this.pnlCardApproval.Location = new System.Drawing.Point(3, 432);
                this.pnlCardApproval.Name = "pnlCardApproval";
                this.pnlCardApproval.Size = new System.Drawing.Size(243, 27);
                this.pnlCardApproval.TabIndex = 32;
                this.pnlCardApproval.Visible = false;
                // 
                // txtCardApproval
                // 
                this.txtCardApproval.BackColor = System.Drawing.SystemColors.Info;
                this.txtCardApproval.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtCardApproval.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtCardApproval.Location = new System.Drawing.Point(88, 3);
                this.txtCardApproval.MaxLength = 100;
                this.txtCardApproval.Name = "txtCardApproval";
                this.txtCardApproval.Size = new System.Drawing.Size(142, 20);
                this.txtCardApproval.TabIndex = 32;
                // 
                // label32
                // 
                this.label32.BackColor = System.Drawing.SystemColors.Control;
                this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label32.ForeColor = System.Drawing.Color.Black;
                this.label32.Location = new System.Drawing.Point(3, 6);
                this.label32.Name = "label32";
                this.label32.Size = new System.Drawing.Size(84, 16);
                this.label32.TabIndex = 124;
                this.label32.Text = "Approval/Slip #:";
                // 
                // pnlCardExpires
                // 
                this.pnlCardExpires.Controls.Add(this.dtpCardExpires);
                this.pnlCardExpires.Controls.Add(this.label31);
                this.pnlCardExpires.Location = new System.Drawing.Point(3, 465);
                this.pnlCardExpires.Name = "pnlCardExpires";
                this.pnlCardExpires.Size = new System.Drawing.Size(243, 27);
                this.pnlCardExpires.TabIndex = 33;
                this.pnlCardExpires.Visible = false;
                // 
                // dtpCardExpires
                // 
                this.dtpCardExpires.CalendarMonthBackground = System.Drawing.Color.White;
                this.dtpCardExpires.CalendarTitleForeColor = System.Drawing.Color.White;
                this.dtpCardExpires.CustomFormat = "MMM. dd, yyyy";
                this.dtpCardExpires.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                this.dtpCardExpires.Location = new System.Drawing.Point(88, 3);
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
                // grbDriver
                // 
                this.grbDriver.Controls.Add(this.txtMakeModel);
                this.grbDriver.Controls.Add(this.label43);
                this.grbDriver.Controls.Add(this.txtTotalCommission);
                this.grbDriver.Controls.Add(this.label39);
                this.grbDriver.Controls.Add(this.txtPlateNum);
                this.grbDriver.Controls.Add(this.label38);
                this.grbDriver.Controls.Add(this.btnBrowseDriver);
                this.grbDriver.Controls.Add(this.txtCarCompany);
                this.grbDriver.Controls.Add(this.label36);
                this.grbDriver.Controls.Add(this.txtLicenseNumber);
                this.grbDriver.Controls.Add(this.label37);
                this.grbDriver.Controls.Add(this.txtDriverName);
                this.grbDriver.Controls.Add(this.label44);
                this.grbDriver.Controls.Add(this.txtDriverId);
                this.grbDriver.Controls.Add(this.label45);
                this.grbDriver.Enabled = false;
                this.grbDriver.Location = new System.Drawing.Point(401, 12);
                this.grbDriver.Name = "grbDriver";
                this.grbDriver.Size = new System.Drawing.Size(340, 200);
                this.grbDriver.TabIndex = 114;
                this.grbDriver.TabStop = false;
                this.grbDriver.Text = "Driver Information";
                this.grbDriver.EnabledChanged += new System.EventHandler(this.grbDriver_EnabledChanged);
                // 
                // txtMakeModel
                // 
                this.txtMakeModel.BackColor = System.Drawing.SystemColors.Info;
                this.txtMakeModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtMakeModel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtMakeModel.Location = new System.Drawing.Point(112, 128);
                this.txtMakeModel.Name = "txtMakeModel";
                this.txtMakeModel.Size = new System.Drawing.Size(111, 20);
                this.txtMakeModel.TabIndex = 148;
                // 
                // label43
                // 
                this.label43.BackColor = System.Drawing.SystemColors.Control;
                this.label43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label43.ForeColor = System.Drawing.Color.Black;
                this.label43.Location = new System.Drawing.Point(17, 130);
                this.label43.Name = "label43";
                this.label43.Size = new System.Drawing.Size(95, 16);
                this.label43.TabIndex = 137;
                this.label43.Text = "Car Model :";
                // 
                // txtTotalCommission
                // 
                this.txtTotalCommission.BackColor = System.Drawing.SystemColors.Control;
                this.txtTotalCommission.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtTotalCommission.Location = new System.Drawing.Point(232, 152);
                this.txtTotalCommission.Name = "txtTotalCommission";
                this.txtTotalCommission.ReadOnly = true;
                this.txtTotalCommission.Size = new System.Drawing.Size(91, 20);
                this.txtTotalCommission.TabIndex = 150;
                this.txtTotalCommission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label39
                // 
                this.label39.BackColor = System.Drawing.SystemColors.Control;
                this.label39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label39.ForeColor = System.Drawing.Color.Black;
                this.label39.Location = new System.Drawing.Point(229, 128);
                this.label39.Name = "label39";
                this.label39.Size = new System.Drawing.Size(101, 16);
                this.label39.TabIndex = 135;
                this.label39.Text = "Total Commission :";
                // 
                // txtPlateNum
                // 
                this.txtPlateNum.BackColor = System.Drawing.SystemColors.Info;
                this.txtPlateNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPlateNum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPlateNum.Location = new System.Drawing.Point(112, 152);
                this.txtPlateNum.Name = "txtPlateNum";
                this.txtPlateNum.Size = new System.Drawing.Size(111, 20);
                this.txtPlateNum.TabIndex = 149;
                // 
                // label38
                // 
                this.label38.BackColor = System.Drawing.SystemColors.Control;
                this.label38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label38.ForeColor = System.Drawing.Color.Black;
                this.label38.Location = new System.Drawing.Point(17, 154);
                this.label38.Name = "label38";
                this.label38.Size = new System.Drawing.Size(73, 16);
                this.label38.TabIndex = 134;
                this.label38.Text = "Plate No.";
                // 
                // btnBrowseDriver
                // 
                this.btnBrowseDriver.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnBrowseDriver.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnBrowseDriver.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
                this.btnBrowseDriver.Location = new System.Drawing.Point(227, 24);
                this.btnBrowseDriver.Name = "btnBrowseDriver";
                this.btnBrowseDriver.Size = new System.Drawing.Size(27, 26);
                this.btnBrowseDriver.TabIndex = 6;
                this.btnBrowseDriver.Click += new System.EventHandler(this.btnBrowseDriver_Click);
                // 
                // txtCarCompany
                // 
                this.txtCarCompany.BackColor = System.Drawing.SystemColors.Info;
                this.txtCarCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtCarCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtCarCompany.Location = new System.Drawing.Point(112, 103);
                this.txtCarCompany.Name = "txtCarCompany";
                this.txtCarCompany.Size = new System.Drawing.Size(111, 20);
                this.txtCarCompany.TabIndex = 147;
                // 
                // label36
                // 
                this.label36.BackColor = System.Drawing.SystemColors.Control;
                this.label36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label36.ForeColor = System.Drawing.Color.Black;
                this.label36.Location = new System.Drawing.Point(17, 105);
                this.label36.Name = "label36";
                this.label36.Size = new System.Drawing.Size(95, 16);
                this.label36.TabIndex = 131;
                this.label36.Text = "Car Company:";
                // 
                // txtLicenseNumber
                // 
                this.txtLicenseNumber.BackColor = System.Drawing.SystemColors.Info;
                this.txtLicenseNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtLicenseNumber.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtLicenseNumber.Location = new System.Drawing.Point(112, 77);
                this.txtLicenseNumber.Name = "txtLicenseNumber";
                this.txtLicenseNumber.ReadOnly = true;
                this.txtLicenseNumber.Size = new System.Drawing.Size(211, 20);
                this.txtLicenseNumber.TabIndex = 146;
                // 
                // label37
                // 
                this.label37.BackColor = System.Drawing.SystemColors.Control;
                this.label37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label37.ForeColor = System.Drawing.Color.Black;
                this.label37.Location = new System.Drawing.Point(17, 79);
                this.label37.Name = "label37";
                this.label37.Size = new System.Drawing.Size(75, 16);
                this.label37.TabIndex = 130;
                this.label37.Text = "License No. :";
                // 
                // txtDriverName
                // 
                this.txtDriverName.BackColor = System.Drawing.SystemColors.Info;
                this.txtDriverName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtDriverName.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtDriverName.Location = new System.Drawing.Point(112, 52);
                this.txtDriverName.Name = "txtDriverName";
                this.txtDriverName.ReadOnly = true;
                this.txtDriverName.Size = new System.Drawing.Size(211, 20);
                this.txtDriverName.TabIndex = 145;
                // 
                // label44
                // 
                this.label44.BackColor = System.Drawing.SystemColors.Control;
                this.label44.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label44.ForeColor = System.Drawing.Color.Black;
                this.label44.Location = new System.Drawing.Point(17, 54);
                this.label44.Name = "label44";
                this.label44.Size = new System.Drawing.Size(75, 16);
                this.label44.TabIndex = 129;
                this.label44.Text = "Name :";
                // 
                // txtDriverId
                // 
                this.txtDriverId.BackColor = System.Drawing.SystemColors.Info;
                this.txtDriverId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtDriverId.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtDriverId.Location = new System.Drawing.Point(112, 28);
                this.txtDriverId.Name = "txtDriverId";
                this.txtDriverId.ReadOnly = true;
                this.txtDriverId.Size = new System.Drawing.Size(111, 20);
                this.txtDriverId.TabIndex = 144;
                this.txtDriverId.TextChanged += new System.EventHandler(this.txtDriverId_TextChanged);
                // 
                // label45
                // 
                this.label45.BackColor = System.Drawing.SystemColors.Control;
                this.label45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label45.ForeColor = System.Drawing.Color.Black;
                this.label45.Location = new System.Drawing.Point(17, 30);
                this.label45.Name = "label45";
                this.label45.Size = new System.Drawing.Size(75, 16);
                this.label45.TabIndex = 128;
                this.label45.Text = "Driver Id :";
                // 
                // AddDirectPostTransactionUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(753, 634);
                this.Controls.Add(this.grbDriver);
                this.Controls.Add(this.btnOk);
                this.Controls.Add(this.btnCancel);
                this.Controls.Add(this.grbPayment);
                this.Controls.Add(this.grbFolioInfo);
                this.Controls.Add(this.GroupBox1);
                this.Controls.Add(this.lvwCodes);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "AddDirectPostTransactionUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Add Transaction";
                this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddTransactionUI_KeyPress);
                this.Load += new System.EventHandler(this.AddTransactionUI_Load);
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.pnlSubAccount.ResumeLayout(false);
                this.grbFolioInfo.ResumeLayout(false);
                this.grbFolioInfo.PerformLayout();
                this.grbPayment.ResumeLayout(false);
                this.flowLayoutPanel1.ResumeLayout(false);
                this.pnlPaymentType.ResumeLayout(false);
                this.pnlPaymentSubAccount.ResumeLayout(false);
                this.pnlPaymentTransSource.ResumeLayout(false);
                this.pnlOrNo.ResumeLayout(false);
                this.pnlOrNo.PerformLayout();
                this.pnlAmount.ResumeLayout(false);
                this.pnlAmount.PerformLayout();
                this.pnlCardNo.ResumeLayout(false);
                this.pnlCardNo.PerformLayout();
                this.pnlChequeNo.ResumeLayout(false);
                this.pnlChequeNo.PerformLayout();
                this.pnlPayment_AccountID.ResumeLayout(false);
                this.pnlPayment_AccountID.PerformLayout();
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
                this.grbDriver.ResumeLayout(false);
                this.grbDriver.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion
			
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
				txtServiceCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(LockTextBox);
                this.cboTransSource.SelectedIndex = 0;

				this.dtpTransactionDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);

				// to focus on TRANSACTION CODE TEXT BOX
				this.chkWalkIn.Checked = true;

                //check if user is allowed to post on previous days
                bool _allowPreviousDatePosting = false;
                bool.TryParse(ConfigVariables.gAllowPreviousDatePosting, out _allowPreviousDatePosting);

                if (lMode == "ADJUSTMENT")
                {
                    dtpTransactionDate.Enabled = true;
                }
                else
                {
                    dtpTransactionDate.Enabled = _allowPreviousDatePosting;
                }

				SendKeys.Send("\t");
				
			}

            private string _additionalMemo = "";
            private void btnOk_Click(System.Object sender, System.EventArgs e)
            {
                try
                {
                    _additionalMemo = "";
                    // this is to trace all folio transactions

                    if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
                    {
                        MessageBox.Show("No Shift/Cash drawer open.\r\nCan't proceed transaction.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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

                    //checks if CITY TRANSFER transaction and has account id
                    try
                    {
                        if (this.cboPaymentTypes.SelectedValue.ToString() == "4200")
                        {
                            if (this.pnlPayment_AccountID.Visible)
                            {
                                if (this.txtPayment_AccountID.Text.Trim().Length <= 0)
                                {
                                    this.txtPayment_AccountID.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                if (this.txtFolioId.Text.Trim().Length <= 0)
                                {
                                    this.txtFolioId.Focus();
                                    return;
                                }
                            }
                        }
                    }
                    catch
                    { }


                    if (this.txtReferenceNo.Text.Trim().Length <= 0)
                    {
                        this.txtReferenceNo.Focus();
                        return;
                    }
                    bool _exemptedRefNo = isExemptedReferenceNo(this.txtReferenceNo.Text);
                    bool _exemptedPaymentRefNo = isExemptedReferenceNo(this.txtPayment_ORNo.Text);

                    //bool _exNoOr = this.txtReferenceNo.Text.ToUpper().Contains("NO OR");
                    //bool _exNoOs = this.txtReferenceNo.Text.ToUpper().Contains("NO OS");
                    //bool _exAutoPost = this.txtReferenceNo.Text.ToUpper().Contains("AUTO-POST");
                    //bool _exAutoPost1 =this.txtReferenceNo.Text.ToUpper().Contains("AUTO POST");
                    //_exemptedRefNo = _exNoOr || _exAutoPost || _exAutoPost1 || _exNoOs;

                    FolioTransactionFacade _oFolioTranFacade = new FolioTransactionFacade();
                    if (!_exemptedRefNo)
                    {
                        if (_oFolioTranFacade.RefNoIfExist(this.cboTransSource.Text, this.txtReferenceNo.Text))
                        {
                            MessageBox.Show("Ref # " + this.txtReferenceNo.Text + " for this type of transaction already exist in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtReferenceNo.Focus();
                            return;
                        }
                    }

                    if (!_exemptedPaymentRefNo)
                    {
                        if (this.txtPayment_ORNo.Text.Trim().Length > 0)
                        {
                            if (_oFolioTranFacade.RefNoIfExist(this.cboPaymentTransSource.Text, this.txtPayment_ORNo.Text) || (cboPaymentTransSource.Text == cboTransSource.Text && txtPayment_ORNo.Text == txtReferenceNo.Text))
                            {
                                MessageBox.Show("Ref # " + this.txtPayment_ORNo.Text + " for this type of transaction already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // check if has Payment [Direct Transaction should be paid]
                    if (lMode == "DIRECT POST")
                    {
                        if (this.cboPaymentTypes.Enabled)
                        {
                            string _paymentType = this.cboPaymentTypes.SelectedValue.ToString();

                            if (_paymentType != null)
                            {
                                decimal amountPaid = 0;
                                try
                                {
                                    switch (this.cboPaymentTypes.SelectedValue.ToString())
                                    {
                                        //case "2100": // if credit card
                                        //case "2800": // if gift cheque
                                        //    amountPaid = decimal.Parse(this.txtBaseAmount.Text);
                                        //    break;

                                        default:
                                            amountPaid = decimal.Parse(this.txtPayment_Amount.Text);
                                            break;
                                    }

                                }
                                catch
                                {
                                }


                                decimal _curAmount = decimal.Parse(this.txtNetBaseAmount.Text);

                                if (amountPaid <= 0 || amountPaid != _curAmount)
                                {
                                    MessageBox.Show("Transaction failed.\r\n\r\nDirect transaction charges should be paid.\r\n", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.txtPayment_Amount.Focus();
                                    this.txtPayment_Amount.SelectAll();
                                    return;
                                }

                                if (this.txtPayment_ORNo.Text.Trim().Length == 0)
                                {
                                    MessageBox.Show("Transaction failed.\r\nPlease input a valid O.R. number.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.txtPayment_ORNo.Focus();
                                    return;

                                }
                            }
                        }
                    }//end if: end check payment


                    insertFolioTransaction();
                    lAmountPaid = System.Convert.ToDecimal(this.txtBaseAmount.Text);

                    //} // end if
                    //else
                    //{

                    //    MessageBox.Show("Duplicate reference number detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //} // end else


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

			private bool isExemptedReferenceNo(string pRefNo)
			{
				string[] exemptedRefNo = { "NO OR", "NO OS", "AUTO-POST", "AUTO POST", "AUTO", "FILLER" };

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
			
			//private MySqlConnection lLocalConnection;
			//private Folio loFolio = new Folio();
			private ListView lListviewA = new ListView();
			private ListView lListviewB = new ListView();
			private ListView lListviewC = new ListView();
			private ListView lListviewD = new ListView();
			
			// >> Constructor for AddFolioTrans in FOLIO LEDGERS from payments
			//private System.Windows.Forms.Control lControl;
			//private string lMode;
			//private string lTranCode;
			//private decimal lAmount;
			private decimal lAmountPaid;
            //private string subFolioTab;
			

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

				DataView dtView = loTransactionCode.Tables[0].DefaultView;
				dtView.RowStateFilter = DataViewRowState.OriginalRows;

                //added to check if UI is used for accounting or direct transaction posting
                if (lMode == "DIRECT POST")
                {
                    dtView.RowFilter = "acctSide = 'DEBIT' and tranCode <> '3300' and trancode <> '4100'";
                }

				foreach (DataRowView _dataRow in dtView)
				{
					
					ListViewItem _listViewItem = new ListViewItem(_dataRow["TranCode"].ToString());
					
					_listViewItem.SubItems.Add(_dataRow["Memo"].ToString());
					_listViewItem.SubItems.Add(_dataRow["AcctSide"].ToString());
					_listViewItem.SubItems.Add(double.Parse(_dataRow["ServiceCharge"].ToString()).ToString(_decimalFormat));
                    _listViewItem.SubItems.Add(double.Parse(_dataRow["GovtTax"].ToString()).ToString(_decimalFormat));
                    _listViewItem.SubItems.Add(double.Parse(_dataRow["LocalTax"].ToString()).ToString(_decimalFormat));

					_listViewItem.SubItems.Add(_dataRow["ServiceChargeInclusive"].ToString());
					_listViewItem.SubItems.Add(_dataRow["GovtTaxInclusive"].ToString());
					_listViewItem.SubItems.Add(_dataRow["LocalTaxInclusive"].ToString());
					_listViewItem.SubItems.Add(_dataRow["defaultTransactionSource"].ToString());

                    
					this.Text = "DIRECT TRANSACTION POST";
					this.lvwCodes.Items.Add(_listViewItem);
					
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
				catch(Exception ex)
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

                //_dtView.RowFilter = "tranTypeId = '2' or tranTypeId = '3' or tranTypeId = '4' or tranTypeId = '5' or (tranCode = '7" + this.txtTransactionCode.Text + "')";
                _dtView.RowFilter = "tranTypeId = '2' or tranTypeId = '3' or tranTypeId = '4' or tranTypeId = '5' or tranTypeId = '7' or tranTypeId = '9'";

                this.cboPaymentTypes.DataSource = lPaymentTypes;
                this.cboPaymentTypes.DisplayMember = "Memo";
                this.cboPaymentTypes.ValueMember = "tranCode";


                ////this.cboPaymentTypes.DataSource = null;
                //lPaymentTypes = new DataTable();

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

                //this.cboPaymentTypes.DataSource = lPaymentTypes;
                //this.cboPaymentTypes.DisplayMember = "Memo";
                //this.cboPaymentTypes.ValueMember = "TransactionCode";
            }

			private bool isFormReady()
			{
				if (this.grbFolioInfo.Enabled)
				{
					if (this.txtFolioId.Tag == null)
					{
						MessageBox.Show("Please input guest information.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtFolioId.Focus();
						return false;
					}
				}

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

				// checks if has Driver Information
				if (this.grbDriver.Enabled)
				{
					if (this.txtDriverId.Text.Trim().Length <= 0)
					{
						MessageBox.Show("Please input driver information.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtDriverId.Focus();
						return false;
					}

					if (this.txtCarCompany.Text.Trim().Length <= 0)
					{
						MessageBox.Show("Please input car company.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtCarCompany.Focus();
						return false;
					}
					if (this.txtMakeModel.Text.Trim().Length <= 0)
					{
						MessageBox.Show("Please input car model.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtMakeModel.Focus();
						return false;
					}
					if (this.txtPlateNum.Text.Trim().Length <= 0)
					{
						MessageBox.Show("Please input car plate number.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtPlateNum.Focus();
						return false;
					}

				}

				return true;
			}

	
			IList<NonGuestTransaction> ilNonGuestTrans;
            IList<AccountingAdjustments> ilAccountingAdjTrans;
			private void insertFolioTransaction()
			{

				if (!isFormReady())
				{
					return;
				}

                if (lMode == "DIRECT POST")
                {
                    ilNonGuestTrans = new List<NonGuestTransaction>();
                    NonGuestTransaction nonGuestTransaction = new NonGuestTransaction();
                    AssignFolioTransValues(nonGuestTransaction);

                    ilNonGuestTrans.Add(nonGuestTransaction);

                    // FOR PAYMENT --------------------------------------------
                    if (this.cboAcctSide.Text == "DEBIT")
                    {
                        double amountPaid = 0;
                        try
                        {
                            switch (this.cboPaymentTypes.SelectedValue.ToString())
                            {
                                case "2000":
                                    amountPaid = double.Parse(this.txtPayment_Amount.Text);
                                    break;

                                default:
                                    amountPaid = double.Parse(this.txtBaseAmount.Text);
                                    break;
                            }

                        }
                        catch
                        { }

                        if (this.txtPayment_ORNo.Text.Trim().Length <= 0)
                        {
                            amountPaid = 0;
                        }
                        else
                        {
                            if (amountPaid <= 0)
                            {
                                this.txtPayment_ORNo.Focus();
                                return;
                            }
                        }

                        if (amountPaid > 0.0)
                        {

                            NonGuestTransaction _oPaymentFolioTrans = new NonGuestTransaction();
                            AssignFolioTransValuesPayment(_oPaymentFolioTrans);

                            ilNonGuestTrans.Add(_oPaymentFolioTrans);

                        }
                    }

                    // > saves in database
                    NonGuestTransactionFacade oNonGuestTransactionFacade = new NonGuestTransactionFacade();
                    try
                    {
                        oNonGuestTransactionFacade.appendNonGuestTransaction(ilNonGuestTrans);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ilAccountingAdjTrans = new List<AccountingAdjustments>();
                    AccountingAdjustments accountingAdjTransaction = new AccountingAdjustments();
                    AssignFolioTransValues(accountingAdjTransaction);

                    ilAccountingAdjTrans.Add(accountingAdjTransaction);

                    // FOR PAYMENT --------------------------------------------
                    if (this.cboAcctSide.Text == "DEBIT")
                    {
                        double amountPaid = 0;
                        try
                        {
                            amountPaid = double.Parse(txtPayment_Amount.Text);
                        }
                        catch
                        {
                            amountPaid = 0;
                        }

                        if (amountPaid > 0.0)
                        {

                            AccountingAdjustments _oPaymentFolioTrans = new AccountingAdjustments();
                            AssignFolioTransValuesPayment(_oPaymentFolioTrans);

                            ilAccountingAdjTrans.Add(_oPaymentFolioTrans);

                        }
                    }

                    // > saves in database
                    AccountingAdjustmentFacade oAccountingAdjFacade = new AccountingAdjustmentFacade();
                    try
                    {
                        oAccountingAdjFacade.appendAccountingAdjustment(ilAccountingAdjTrans);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

				this.Close();
			}

            string lChargeReferenceNo = "";
			private void AssignFolioTransValues(NonGuestTransaction poFolioTransaction)
			{

				bool _inclusiveGovTax = true;
				bool _inclusiveLocalTax = true;
				bool _inclusiveServiceCharge = true;


				decimal _govtTaxPercent = 0;
				decimal _localTaxPercent = 0;
				decimal _serviceChargePercent = 0;

				decimal _govtTaxAmount = 0;
				decimal _localTaxAmount = 0;
				decimal _serviceChargeAmount = 0;


				string _strTransactionCode = this.txtTransactionCode.Text;
				TransactionCode _oTranCode;
				_oTranCode = loTransactionCodeFacade.getTransactionCode(_strTransactionCode);

				poFolioTransaction.HotelID = GlobalVariables.gHotelId;
				poFolioTransaction.TransactionDate = this.dtpTransactionDate.Value;
				poFolioTransaction.PostingDate = DateTime.Now ;
				
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
                lChargeReferenceNo = poFolioTransaction.ReferenceNo;
                TransactionSourceDocument transSourc = (TransactionSourceDocument)this.cboTransSource.SelectedItem;
				poFolioTransaction.TransactionSource = transSourc.Abbreviation;

				poFolioTransaction.Memo = this.txtMemo.Text;
				if (this.pnlSubAccount.Visible)
				{
					poFolioTransaction.Memo += " - " + this.cboSubAccount.Text;
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
				_baseAmount = _baseAmount - poFolioTransaction.Discount;




				//// if has SubAccount use SubAccount settings for Govt Tax
				//// else use TransactionCode settings for Govt Tax
				if (lSubAccountSelected == null)
				{
					_inclusiveGovTax = _oTranCode.GovtTaxInclusive == 1 ? true : false;
					_inclusiveLocalTax = _oTranCode.LocalTaxInclusive == 1 ? true : false;
					_inclusiveServiceCharge = _oTranCode.ServiceChargeInclusive == 1 ? true : false;

					_govtTaxPercent = _oTranCode.GovtTax / 100;
					_localTaxPercent = _oTranCode.LocalTax / 100;
					_serviceChargePercent = _oTranCode.ServiceCharge / 100;

				}
				else
				{
					_inclusiveGovTax = lSubAccountSelected.GovernmentTaxInclusive == 1 ? true : false;
					_inclusiveLocalTax = lSubAccountSelected.LocalTaxInclusive == 1 ? true : false;
					_inclusiveServiceCharge = lSubAccountSelected.ServiceChargeInclusive == 1 ? true : false;

					_govtTaxPercent = lSubAccountSelected.GovernmentTax / 100;
					_localTaxPercent = lSubAccountSelected.LocalTax / 100;
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

                ///>> compute Service Charge
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



				//// compute Government Tax here (Inclusive or Exclusive)
				//// if has SubAccount use SubAccount settings for Govt Tax
				//// else use TransactionCode settings for Govt Tax
				//if (lSubAccountSelected != null)
				//{
				//    if (lSubAccountSelected.GovernmentTax > 0)
				//    {
				//        decimal _govTaxPercent = System.Convert.ToDecimal(lSubAccountSelected.GovernmentTax);

				//        decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, lSubAccountSelected.GovernmentTaxInclusive);
				//        poFolioTransaction.GovernmentTax = _govTaxAmount;

				//        if (lSubAccountSelected.GovernmentTaxInclusive == 0)
				//        {
				//            //poFolioTransaction.GrossAmount += _govTaxAmount;

				//            _inclusiveGovTax = false;
				//        }
				//    }
				//    else
				//    {
				//        poFolioTransaction.GovernmentTax = 0;
				//    }
				//}
				//else
				//{
				//    if (_oTranCode.GovtTax > 0)
				//    {
				//        decimal _govTaxPercent = System.Convert.ToDecimal(_oTranCode.GovtTax);

				//        decimal _govTaxAmount = ComputeTaxSrvCharge(_baseAmount, _govTaxPercent, _oTranCode.GovtTaxInclusive);
				//        poFolioTransaction.GovernmentTax = _govTaxAmount;

				//        if (_oTranCode.GovtTaxInclusive == 0)
				//        {
				//            //poFolioTransaction.GrossAmount += _govTaxAmount;

				//            _inclusiveGovTax = false;
				//        }
				//    }
				//    else
				//    {
				//        poFolioTransaction.GovernmentTax = 0;
				//    }

				//}


				//// compute Local Tax here (Inclusive or Exclusive)
				//// if has SubAccount use SubAccount settings for Govt Tax
				//// else use TransactionCode settings for Local Tax
				//if (lSubAccountSelected != null)
				//{
				//    if (lSubAccountSelected.LocalTax > 0)
				//    {
				//        decimal _localTaxPercent = System.Convert.ToDecimal(lSubAccountSelected.LocalTax);

				//        decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, lSubAccountSelected.LocalTaxInclusive);
				//        poFolioTransaction.LocalTax = _localTaxAmount;


				//        if (lSubAccountSelected.LocalTaxInclusive == 0)
				//        {
				//            //poFolioTransaction.GrossAmount += _localTaxAmount;

				//            _inclusiveLocalTax = false;
				//        }
				//    }
				//    else
				//    {
				//        poFolioTransaction.LocalTax = 0;
				//    }
				//}
				//else
				//{
				//    if (_oTranCode.LocalTax > 0)
				//    {
				//        decimal _localTaxPercent = System.Convert.ToDecimal(_oTranCode.LocalTax);

				//        decimal _localTaxAmount = ComputeTaxSrvCharge(_baseAmount, _localTaxPercent, _oTranCode.LocalTaxInclusive);
				//        poFolioTransaction.LocalTax = _localTaxAmount;

				//        if (_oTranCode.LocalTaxInclusive == 0)
				//        {
				//            //poFolioTransaction.GrossAmount += _localTaxAmount;

				//            _inclusiveLocalTax = false;
				//        }
				//    }
				//    else
				//    {
				//        poFolioTransaction.LocalTax = 0;
				//    }

				//}



				//// compute Local Tax here (Inclusive or Exclusive)
				//// if has SubAccount use SubAccount settings for Govt Tax
				//// else use TransactionCode settings for Local Tax
				//_baseAmount = _baseAmount - poFolioTransaction.GovernmentTax - poFolioTransaction.LocalTax;

				//if (lSubAccountSelected != null)
				//{
				//    if (lSubAccountSelected.ServiceCharge > 0)
				//    {
				//        if (lSubAccountSelected.ServiceChargeInclusive == 0)
				//        {
				//            // SUBTRACT GovtTax and LocalTax before applying Service Charge
				//            _baseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;

				//            _inclusiveServiceCharge = false;
				//        }

				//        decimal _serviceChargePercent = System.Convert.ToDecimal(lSubAccountSelected.ServiceCharge);

				//        decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, lSubAccountSelected.ServiceChargeInclusive);
				//        poFolioTransaction.ServiceCharge = _serviceChargeAmount;

				//        // add service charge to Gross Amount if exclusive
				//        if (lSubAccountSelected.ServiceChargeInclusive == 0)
				//        {
				//            //poFolioTransaction.GrossAmount += _serviceChargeAmount;

				//            _inclusiveServiceCharge = false;
				//        }
				//    }
				//    else
				//    {
				//        poFolioTransaction.ServiceCharge = 0;
				//    }
				//}
				//else
				//{
				//    if (_oTranCode.ServiceCharge > 0)
				//    {
				//        if (_oTranCode.ServiceChargeInclusive == 0)
				//        {
				//            // SUBTRACT GovtTax and LocalTax before applying Service Charge
				//            _baseAmount = poFolioTransaction.BaseAmount;

				//            _inclusiveServiceCharge = false;
				//        }

				//        decimal _serviceChargePercent = System.Convert.ToDecimal(_oTranCode.ServiceCharge);

				//        decimal _serviceChargeAmount = ComputeTaxSrvCharge(_baseAmount, _serviceChargePercent, _oTranCode.ServiceChargeInclusive);
				//        poFolioTransaction.ServiceCharge = _serviceChargeAmount;

				//        // add service charge to Gross Amount if exclusive
				//        if (_oTranCode.ServiceChargeInclusive == 0)
				//        {
				//            //poFolioTransaction.GrossAmount += _serviceChargeAmount;

				//            _inclusiveServiceCharge = false;
				//        }
				//    }
				//    else
				//    {
				//        poFolioTransaction.ServiceCharge = 0;
				//    }

				//}


				//poFolioTransaction.NetAmount = poFolioTransaction.GrossAmount - poFolioTransaction.Discount; //System.Convert.ToDouble(poFolioTransaction.BaseAmount - poFolioTransaction.Discount);

				//poFolioTransaction.NetBaseAmount = poFolioTransaction.BaseAmount - poFolioTransaction.Discount;
				//if (_inclusiveGovTax)
				//{
				//    poFolioTransaction.NetBaseAmount -= poFolioTransaction.GovernmentTax;
				//}
				//if (_inclusiveLocalTax)
				//{
				//    poFolioTransaction.NetBaseAmount -= poFolioTransaction.LocalTax;
				//}

				//if (_inclusiveServiceCharge)
				//{
				//    poFolioTransaction.NetBaseAmount -= poFolioTransaction.ServiceCharge;
				//}

				//poFolioTransaction.RouteSequence = "";
				//poFolioTransaction.SourceFolio = "";
				//poFolioTransaction.SourceSubFolio = "";
				poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
				poFolioTransaction.createdBy = GlobalVariables.gLoggedOnUser;

				// new, Jrom, April 26, 2008
				// Golden prince requirement

				poFolioTransaction.CreditCardNo = this.txtPayment_CardNo.Text;
				poFolioTransaction.ChequeNo = this.txtPayment_Cheque.Text;
				poFolioTransaction.AccountName = this.txtPayment_Account.Text;
				poFolioTransaction.BankName = this.txtPayment_Bank.Text;
				poFolioTransaction.ChequeDate = this.dtpPayment_Date.Value;
				poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

				poFolioTransaction.CreditCardType = this.txtCardType.Text;
				poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
				poFolioTransaction.SubAccount = this.cboSubAccount.Text;
				poFolioTransaction.CreditCardExpiry =this.dtpCardExpires.Value;
				poFolioTransaction.updatedBy = GlobalVariables.gLoggedOnUser;

				if (this.grbFolioInfo.Enabled)
				{
                    string _addGuestInfo = "";
                    if (txtReservationSource.Text != "")
                    {
                        _addGuestInfo = " (" + txtReservationSource.Text;
                        if (txtCardNumber.Text != "")
                        {
                            _addGuestInfo += " #" + txtCardNumber.Text;
                        }
                        _addGuestInfo += ")";
                    }

					poFolioTransaction.ReferenceFolioId = this.txtFolioId.Text;
					poFolioTransaction.RoomNumber = this.txtRoomNo.Text;
					poFolioTransaction.AccountId = this.txtFolioId.Tag.ToString();
                    poFolioTransaction.GuestName = this.txtGuestName.Text + _addGuestInfo;
					poFolioTransaction.CompanyName = this.txtGroupName.Text;
				}
				else
				{
					poFolioTransaction.ReferenceFolioId = "";
					poFolioTransaction.RoomNumber = "";
					poFolioTransaction.AccountId = "";
					poFolioTransaction.GuestName = "";
					poFolioTransaction.CompanyName = "";
				}
				if (this.txtArrivalDate.Text == "")
				{
					poFolioTransaction.ArrivalDate = DateTime.Parse(GlobalVariables.gAuditDate);
				}
				else
				{
					poFolioTransaction.ArrivalDate = DateTime.Parse(this.txtArrivalDate.Text);
				}

				if (this.txtDepartureDate.Text == "")
				{
					poFolioTransaction.DepartureDate = DateTime.Parse(GlobalVariables.gAuditDate);
				}
				else
				{
					poFolioTransaction.DepartureDate = DateTime.Parse(this.txtDepartureDate.Text);
				}
				

				if (this.grbDriver.Enabled)
				{
					poFolioTransaction.ReferenceDriverId = this.txtDriverId.Text;
					poFolioTransaction.CarCompany = this.txtCarCompany.Text;
					poFolioTransaction.MakeModel = this.txtMakeModel.Text;
					poFolioTransaction.PlateNumber = this.txtPlateNum.Text;

					poFolioTransaction.DriverFirstName = driver.FirstName;
					poFolioTransaction.DriverLastName = driver.LastName;
				}
				else
				{
					poFolioTransaction.ReferenceDriverId = "";
					poFolioTransaction.CarCompany = "";
					poFolioTransaction.MakeModel = "";
					poFolioTransaction.PlateNumber = "";
				}


			}


			private void AssignFolioTransValuesPayment(NonGuestTransaction poFolioTransaction)
			{
				string _selectedTranCode = this.cboPaymentTypes.SelectedValue.ToString();
				string _memo = this.cboPaymentTypes.Text;


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
			
				poFolioTransaction.TransactionDate = this.dtpTransactionDate.Value;
				poFolioTransaction.PostingDate = DateTime.Now;
				poFolioTransaction.TransactionCode = _selectedTranCode;
                poFolioTransaction.SubAccount = cboPaymentSubAccount.Text;
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
                poFolioTransaction.TransactionSource = this.cboPaymentTransSource.Text;

                //get transaction description for the charged payment
                TransactionCode _transDescription = loTransactionCodeFacade.getTransactionCode(txtTransactionCode.Text);
                poFolioTransaction.Memo = _memo + _additionalMemo + "[" + _transDescription.Memo + " - #" + lChargeReferenceNo + "]";
                if (this.pnlPaymentSubAccount.Visible)
                {
                    poFolioTransaction.Memo += " - " + this.cboPaymentSubAccount.Text;
                }
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
				poFolioTransaction.ChequeDate = this.dtpPayment_Date.Value;
				poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;
				poFolioTransaction.CreditCardType = this.txtCardType.Text;
				poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
				poFolioTransaction.CreditCardExpiry = this.dtpCardExpires.Value;

				poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
				poFolioTransaction.ShiftCode = GlobalVariables.gShiftCode;
				poFolioTransaction.createdBy = GlobalVariables.gLoggedOnUser;
				poFolioTransaction.updatedBy = GlobalVariables.gLoggedOnUser;


				if (this.grbFolioInfo.Enabled)
				{
                    //>>show reservation source and card number of guest if it has
                    string _addGuestInfo = "";
                    if (txtReservationSource.Text != "")
                    {
                        _addGuestInfo = " (" + txtReservationSource.Text;
                        if (txtCardNumber.Text != "")
                        {
                            _addGuestInfo += " #" + txtCardNumber.Text;
                        }
                        _addGuestInfo += ")";
                    }
                    
                    poFolioTransaction.ReferenceFolioId = this.txtFolioId.Text;
					poFolioTransaction.RoomNumber = this.txtRoomNo.Text;
                    if (cboPaymentTypes.SelectedValue.ToString() == "4200")
                    {
                        poFolioTransaction.AccountId = this.txtPayment_AccountID.Text;
                        poFolioTransaction.GuestName = this.txtPayment_AccountName.Text;
                        poFolioTransaction.Memo += " - " + txtPayment_AccountName.Text;
                    }
                    else
                    {
                        poFolioTransaction.AccountId = this.txtFolioId.Tag.ToString();
                        poFolioTransaction.GuestName = this.txtGuestName.Text + _addGuestInfo;
                    }
					poFolioTransaction.CompanyName = this.txtGroupName.Text;
				}
				else
				{
					poFolioTransaction.ReferenceFolioId = "";
					poFolioTransaction.RoomNumber = "";
                    if (cboPaymentTypes.SelectedValue.ToString() == "4200")
                    {
                        poFolioTransaction.AccountId = this.txtPayment_AccountID.Text;
                        poFolioTransaction.GuestName = this.txtPayment_AccountName.Text;
                        poFolioTransaction.Memo += " - " + txtPayment_AccountName.Text;
                    }
                    else
                    {
                        poFolioTransaction.AccountId = "";
                        poFolioTransaction.GuestName = "";
                    }
					poFolioTransaction.CompanyName = "";
				}
				poFolioTransaction.ArrivalDate = DateTime.Parse(this.txtArrivalDate.Text);
				poFolioTransaction.DepartureDate = DateTime.Parse(this.txtDepartureDate.Text);

				if (this.grbDriver.Enabled)
				{
					poFolioTransaction.ReferenceDriverId = this.txtDriverId.Text;
					poFolioTransaction.CarCompany = this.txtCarCompany.Text;
					poFolioTransaction.MakeModel = this.txtMakeModel.Text;
					poFolioTransaction.PlateNumber = this.txtPlateNum.Text;

					poFolioTransaction.DriverFirstName = driver.FirstName;
					poFolioTransaction.DriverLastName = driver.LastName;
				}
				else
				{
					poFolioTransaction.ReferenceDriverId = "";
					poFolioTransaction.CarCompany = "";
					poFolioTransaction.MakeModel = "";
					poFolioTransaction.PlateNumber = "";
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

					//compute discount
					decimal totalDiscount = 0;
					decimal percentDiscount = 0;
					try // to trap if txtDiscountPercent is BLANK 
					{
						percentDiscount = decimal.Parse(this.txtDiscountPercent.Text);
					}
					catch {
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
					}

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
                //}
			}
		
			private void txtTransactionCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					if (this.txtTransactionCode.Text != "")
					{
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
                            //this.chkWalkIn.Checked = true;
                            //this.grbFolioInfo.Enabled = false;
							this.grbDriver.Enabled = false;

							string _accountingSide = _lvwItem.SubItems[2].Text;

							//this.cboAcctSide.Text = "";

							this.txtMemo.Text = _lvwItem.SubItems[1].Text;
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

							this.cboAcctSide_SelectedIndexChanged(this, new EventArgs());


							// Display Discount Percentage if TransactionCode selected
							// is present in oFolio.Privileges
							this.txtDiscountAmount.Text = "0.00";
							this.txtDiscountPercent.Text = "0.00";
							//showDiscountPercent(this.txtTransactionCode.Text);


							return;
						}
					}

					this.lvwCodes.BringToFront();
					this.lvwCodes.Visible = true;
				}
				catch
				{
					this.lvwCodes.SendToBack();
					this.lvwCodes.Visible = false;
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
					MessageBox.Show("Invalid transaction code! Select a correct transaction code from the list.", "Invalid Transaction code",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				this.txtPayment_Amount.Text = "";
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

				//try
				//{
				//    double total;
				//    total = double.Parse(this.txtCurAmount.Text) * double.Parse(this.cboCurrencyRate.Text);
				//    total = total - double.Parse(this.txtDiscount.Text);

				//    this.txtBaseAmount.Text = string.Format("{0:#,##0.00}", total);
				//}
				//catch (Exception)
				//{
				//    this.txtBaseAmount.Text = "0.00";
				//}
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
				if(e.KeyChar == '\r')
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

                    case "2800":
					case "2201": // GIFT CHEQUE
                        this.pnlChequeNo.Visible = true;
						this.pnlAmount.Visible = true;
                        this.pnlGrantedBy.Visible = true;
						break;

                    case "4200": //FOR CHARGED(CITY TRANSFER) TRANSACTIONS
                        this.pnlAmount.Visible = true;
                        this.pnlGrantedBy.Visible = true;
                        this.pnlPayment_AccountID.Visible = true;
                        break;

					default:
                        //if (_selected == _complimentaryTranCode)
                        //{
							DataRowView _tranCode = (DataRowView)this.cboPaymentTypes.SelectedItem;

							//this.lblPayment_DocSource.Text = _tranCode["DefaultTransactionSource"].ToString() + " #";
							this.pnlAmount.Visible = true;
                        //}

						break;
				}
			}

			private void hideAllPanelExceptPaymentType()
			{
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
				this.txtPayment_Amount.Text = "";
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
					// show payment Group Box
					if (this.txtTransactionCode.Text == "6000") // 6000 = PAID OUT [ COMMISSION / DISBURSEMENT ]
					{
						this.grbPayment.Enabled = false;
					}
					else
					{
						this.grbPayment.Enabled = true;
					}
					this.pnlPaymentType.Visible = true;
					this.pnlOrNo.Visible = true;
					this.pnlAmount.Visible = true;
					this.pnlAmount.Enabled = true;

					//this.cboTransSource.Text = "CHARGE INVOICE";
					this.txtDiscountPercent.ReadOnly = false;

					loadPaymentTypes();
				}
				else if (this.cboAcctSide.Text.ToUpper() == "CREDIT")
				{
                    string strCode = this.txtTransactionCode.Text;
                    getTransactionCode_SubAccount(strCode);
                    
                    this.pnlSubAccount.Visible = false;
                    this.txtDiscountPercent.Text = "0.00";
					this.txtDiscountPercent.ReadOnly = true;

					hideAllPaymentPanel();
					switch (this.txtTransactionCode.Text)
					{
						case "2000": // CASH PAYMENT
							this.grbPayment.Enabled = false;
							//this.cboTransSource.Text = "OFFICIAL RECEIPT";
							break;

						case "2100": // CREDIT CARD
                            this.grbPayment.Enabled = true;
                            this.pnlCardNo.Visible = true;
                            this.pnlCardType.Visible = true;
                            this.pnlCardExpires.Visible = true;
                            this.pnlCardApproval.Visible = true;
                            break;

						case "2200": // CHEQUE PAYMENT
                            this.grbPayment.Enabled = true;
                            this.pnlChequeNo.Visible = true;
                            this.pnlAccount.Visible = true;
                            this.pnlBank.Visible = true;
                            this.pnlDate.Visible = true;
                            break;

                        case "2201":
                        case "2800": // GIFT CHEQUE
                            this.grbPayment.Enabled = true;
                            //this.pnlAmount.Visible = true;
                            this.pnlGrantedBy.Visible = true;
                            this.pnlChequeNo.Visible = true;
                            break;
                        
                        case "2501": // FOC PAYMENT
                            this.grbPayment.Enabled = true;
                            this.pnlGrantedBy.Visible = true;
							break;

                        case "4200": //FOR CHARGED(CITY TRANSFER) TRANSACTIONS
                            this.pnlGrantedBy.Visible = true;
                            this.pnlPayment_AccountID.Visible = true;
                            break;
                        
                        default:
                            this.pnlSubAccount.Visible = true;
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


				string strSubAccount = this.cboSubAccount.Text;
				switch (strSubAccount)
				{
					case "COMMISSION":
						this.grbDriver.Enabled = true;
						this.grbFolioInfo.Enabled = true;

						break;

					case "DISBURSEMENT":
						this.grbFolioInfo.Enabled = false;
						this.grbDriver.Enabled = false;

						break;

					default:
						this.grbDriver.Enabled = false;

						break;



				}
			}

			public IList<NonGuestTransaction> showDialog(Form parent)
			{
				base.ShowDialog(parent);

						return ilNonGuestTrans;

			}

            public IList<AccountingAdjustments> showAdjustmentDialog(Form parent)
            {
                base.ShowDialog(parent);
                return ilAccountingAdjTrans;
            }

			private void chkWalkIn_CheckedChanged(object sender, EventArgs e)
			{
				if (this.chkWalkIn.CheckState == CheckState.Checked)
				{
					this.txtFolioId.Tag = ConfigVariables.gDefaultWalkInAccount;
					this.txtFolioId.Text = "";
					this.txtGuestName.Text = "WALK-IN GUEST";
					//this.txtGroupName.Text = "WALK-IN GUEST";
					this.txtArrivalDate.Text = GlobalVariables.gAuditDate;
					this.txtDepartureDate.Text = GlobalVariables.gAuditDate;
					this.txtRoomNo.Text = "";

					this.txtFolioId.ReadOnly = true;
					this.txtGuestName.ReadOnly = true;
					this.txtGroupName.ReadOnly = true;
					this.txtArrivalDate.ReadOnly = true;
					this.txtDepartureDate.ReadOnly = true;
					this.txtRoomNo.ReadOnly = true;

					this.txtFolioId.BackColor = System.Drawing.SystemColors.Control;
					this.txtGuestName.BackColor = System.Drawing.SystemColors.Control;
					this.txtGroupName.BackColor = System.Drawing.SystemColors.Control;

					this.txtArrivalDate.BackColor = System.Drawing.SystemColors.Control;
					this.txtDepartureDate.BackColor = System.Drawing.SystemColors.Control;
					this.txtRoomNo.BackColor = System.Drawing.SystemColors.Control;

					this.btnBrowseFolioId.Enabled = false;

                    try
                    {
                        if (cboPaymentTypes.SelectedValue.ToString() == "4200")
                        {
                            pnlPayment_AccountID.Visible = true;
                        }
                    }
                    catch { }
				}
				else
				{
					this.txtFolioId.Text = "";
					this.txtFolioId.Tag = null;
					this.txtGuestName.Text = "";
					this.txtArrivalDate.Text = "";
					this.txtDepartureDate.Text = "";
					this.txtRoomNo.Text = "";

                    this.txtFolioId.ReadOnly = false;
					this.txtGuestName.ReadOnly = true;
					this.txtGroupName.ReadOnly = true;
					this.txtArrivalDate.ReadOnly = true;
					this.txtDepartureDate.ReadOnly = true;
					this.txtRoomNo.ReadOnly = true;

					this.txtFolioId.BackColor = System.Drawing.Color.White;
					this.txtGuestName.BackColor = System.Drawing.Color.White;
					this.txtGroupName.BackColor = System.Drawing.Color.White;

					this.txtArrivalDate.BackColor = System.Drawing.Color.White;
					this.txtDepartureDate.BackColor = System.Drawing.Color.White;
					this.txtRoomNo.BackColor = System.Drawing.Color.White;

                    this.btnBrowseFolioId.Enabled = true;

                    try
                    {
                        if (cboPaymentTypes.SelectedValue.ToString() == "4200")
                        {
                            pnlPayment_AccountID.Visible = false;
                        }
                    }
                    catch { }
				}


			}

			Driver driver = null;
			private void btnBrowseDriver_Click(object sender, EventArgs e)
			{

				BrowseDriverUI browseDriver = new BrowseDriverUI();
				driver = browseDriver.showDialog(this);

				if (driver != null)
				{
					this.txtDriverId.Text = driver.DriverId;
					this.txtLicenseNumber.Text = driver.LicenseNumber;
					this.txtDriverName.Text = driver.LastName + ", " + driver.FirstName;
                    this.txtCarCompany.Text = driver.Company;
                    this.txtPlateNum.Text = driver.Plate_Number;
                    this.txtMakeModel.Text = driver.Car_Model;

					this.txtTotalCommission.Text = driver.TotalCommission.ToString(_decimalFormat);
					this.txtCarCompany.Focus();

				}

			}

			private void btnBrowseFolioId_Click(object sender, EventArgs e)
			{
				Folio oFolio;
				BrowseFolioUI browseFolio = new BrowseFolioUI();
				oFolio = browseFolio.showDialog(this);

				if (oFolio != null)
				{
					switch (oFolio.FolioType)
					{
                        case "DEPENDENT":
						case "INDIVIDUAL":
							// Pops-up if Guest is an affiliate card holder
							if (oFolio.Guest.CARD_NO.Trim().Length > 0)
							{
								MessageBox.Show("Guest is an affiliate card holder.\r\n\r\nThis message is intended to prevent taxi driver Paid-out.\r\n", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //return;
							}

                            this.txtCardNumber.Text = oFolio.Guest.CARD_NO;
                            this.txtReservationSource.Text = oFolio.Source;
                            this.txtFolioId.Text = oFolio.FolioID;
							this.txtFolioId.Tag = oFolio.AccountID;
                            this.txtGroupName.Text = oFolio.GroupName;
							this.txtGuestName.Text = oFolio.Guest.LastName + ", " + oFolio.Guest.FirstName;
							this.txtArrivalDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.FromDate);
							this.txtDepartureDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.Todate);

							this.txtRoomNo.Text = oFolio.RoomNo;
							break;
						case "GROUP":
							this.txtFolioId.Text = oFolio.FolioID;
							this.txtFolioId.Tag = oFolio.AccountID;
							this.txtGuestName.Text = oFolio.Company.CompanyName;
							this.txtGroupName.Text = oFolio.GroupName;
							this.txtArrivalDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.FromDate);
							this.txtDepartureDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.Todate);
                            this.txtReservationSource.Text = oFolio.Source;

							this.txtRoomNo.Text = oFolio.RoomNo;
							break;

						default:
                            this.chkWalkIn.Checked = true;
                            //MessageBox.Show("Folio not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
							
					} //end switch
				}
			}

			private void txtDriverId_TextChanged(object sender, EventArgs e)
			{
				if (this.txtDriverId.Text.Trim().Length > 0)
				{
					NonGuestTransactionFacade oNonGuestTransactionFacade = new NonGuestTransactionFacade();

					NonGuestTransaction trans = oNonGuestTransactionFacade.getDriverCarInformation(this.txtDriverId.Text);

					if (trans != null)
					{
						this.txtCarCompany.Text = trans.CarCompany;
						this.txtMakeModel.Text = trans.MakeModel;
						this.txtPlateNum.Text = trans.PlateNumber;
					}
				}

			}

			private void grbDriver_EnabledChanged(object sender, EventArgs e)
			{
				if (this.grbDriver.Enabled == false)
				{
					this.txtDriverId.Text = "";
					this.txtDriverName.Text = "";
					this.txtLicenseNumber.Text = "";
					this.txtCarCompany.Text = "";
					this.txtMakeModel.Text = "";
					this.txtPlateNum.Text = "";
					this.txtTotalCommission.Text = "";
				}

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

            private void txtFolioId_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        Folio oFolio;
                        FolioFacade oFolioFacade = new FolioFacade();
                        oFolio = oFolioFacade.GetFolio(txtFolioId.Text.ToUpper());

                        if (oFolio != null)
                        {
                            switch (oFolio.FolioType)
                            {
                                case "DEPENDENT":
                                case "INDIVIDUAL":
                                    // Pops-up if Guest is an affiliate card holder
                                    if (oFolio.Guest.CARD_NO.Trim().Length > 0)
                                    {
                                        MessageBox.Show("Guest is an affiliate card holder.\r\n\r\nThis message is intended to prevent taxi driver Paid-out.\r\n", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //return;
                                    }

                                    this.txtCardNumber.Text = oFolio.Guest.CARD_NO;
                                    this.txtReservationSource.Text = oFolio.Source;
                                    this.txtFolioId.Text = oFolio.FolioID;
                                    this.txtFolioId.Tag = oFolio.AccountID;
                                    this.txtGuestName.Text = oFolio.Guest.LastName + ", " + oFolio.Guest.FirstName;
                                    this.txtArrivalDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.FromDate);
                                    this.txtDepartureDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.Todate);

                                    //>>for rooms
                                    foreach (Schedule _oSchedule in oFolio.Schedule)
                                    {
                                        this.txtRoomNo.Text += _oSchedule.RoomID + ",";
                                    }
                                    break;
                                case "GROUP":
                                    this.txtFolioId.Text = oFolio.FolioID;
                                    this.txtFolioId.Tag = oFolio.AccountID;
                                    this.txtGuestName.Text = oFolio.Company.CompanyName;
                                    this.txtGroupName.Text = oFolio.GroupName;
                                    this.txtArrivalDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.FromDate);
                                    this.txtDepartureDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.Todate);
                                    this.txtReservationSource.Text = oFolio.Source;

                                    //>>for rooms
                                    foreach (Schedule _oSchedule in oFolio.Schedule)
                                    {
                                        this.txtRoomNo.Text += _oSchedule.RoomID + ",";
                                    }
                                    break;

                                default:
                                    this.chkWalkIn.Checked = true;
                                    MessageBox.Show("Folio ID not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;

                            } //end switch
                        }
                    }
                }
                catch { }
            }

            private void txtFolioId_Leave(object sender, EventArgs e)
            {
                try
                {
                    this.txtRoomNo.Text = "";
                    Folio oFolio;
                    FolioFacade oFolioFacade = new FolioFacade();
                    oFolio = oFolioFacade.GetFolio(txtFolioId.Text.ToUpper());

                    if (oFolio != null)
                    {
                        switch (oFolio.FolioType)
                        {
                            case "DEPENDENT":
                            case "INDIVIDUAL":
                                // Pops-up if Guest is an affiliate card holder
                                if (oFolio.Guest.CARD_NO.Trim().Length > 0)
                                {
                                    MessageBox.Show("Guest is an affiliate card holder.\r\n\r\nThis message is intended to prevent taxi driver Paid-out.\r\n", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //return;
                                }

                                this.txtCardNumber.Text = oFolio.Guest.CARD_NO;
                                this.txtReservationSource.Text = oFolio.Source;
                                this.txtFolioId.Text = oFolio.FolioID;
                                this.txtGroupName.Text = oFolio.GroupName;
                                this.txtFolioId.Tag = oFolio.AccountID;
                                this.txtGuestName.Text = oFolio.Guest.LastName + ", " + oFolio.Guest.FirstName;
                                this.txtArrivalDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.FromDate);
                                this.txtDepartureDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.Todate);

                                //>>for rooms
                                foreach (Schedule _oSchedule in oFolio.Schedule)
                                {
                                    this.txtRoomNo.Text += _oSchedule.RoomID + ",";
                                }
                                break;
                            case "GROUP":
                                this.txtFolioId.Text = oFolio.FolioID;
                                this.txtFolioId.Tag = oFolio.AccountID;
                                if (oFolio.CompanyID.StartsWith("G"))
                                {
                                    Company _oCompany = new Company();
                                    CompanyFacade _oCompanyFacade = new CompanyFacade();
                                    _oCompany = _oCompanyFacade.getCompanyAccount(oFolio.CompanyID);
                                    this.txtGuestName.Text = _oCompany.CompanyName;
                                }
                                else
                                {
                                    Guest _oGuest = new Guest();
                                    GuestFacade _oGuestFacade = new GuestFacade();
                                    _oGuest = _oGuestFacade.getGuestRecord(oFolio.CompanyID);
                                    this.txtGuestName.Text = _oGuest.LastName + ", " + _oGuest.FirstName;
                                }
                                this.txtGroupName.Text = oFolio.GroupName;
                                this.txtArrivalDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.FromDate);
                                this.txtDepartureDate.Text = string.Format("{0:dd-MMM-yyyy}", oFolio.Todate);
                                this.txtReservationSource.Text = oFolio.Source;

                                //>>for rooms
                                foreach (Schedule _oSchedule in oFolio.Schedule)
                                {
                                    this.txtRoomNo.Text += _oSchedule.RoomID + ",";
                                }
                                break;

                            default:
                                this.chkWalkIn.Checked = true;
                                MessageBox.Show("Folio ID not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;

                        } //end switch
                    }
                }
                catch { }
            }

            private void btnSearchAccount_Click(object sender, EventArgs e)
            {
                BrowseAccountUI _oBrowseAccount = new BrowseAccountUI(GlobalVariables.gPersistentConnection, "GUESTS", txtPayment_AccountID, txtPayment_AccountName);
                _oBrowseAccount.ShowDialog();
            }	
		
            //for accounting adjustments
            private void AssignFolioTransValues(AccountingAdjustments poFolioTransaction)
            {

                bool _inclusiveGovTax = true;
                bool _inclusiveLocalTax = true;
                bool _inclusiveServiceCharge = true;


                decimal _govtTaxPercent = 0;
                decimal _localTaxPercent = 0;
                decimal _serviceChargePercent = 0;

                decimal _govtTaxAmount = 0;
                decimal _localTaxAmount = 0;
                decimal _serviceChargeAmount = 0;


                string _strTransactionCode = this.txtTransactionCode.Text;
                TransactionCode _oTranCode;
                _oTranCode = loTransactionCodeFacade.getTransactionCode(_strTransactionCode);

                poFolioTransaction.HotelID = GlobalVariables.gHotelId;
                poFolioTransaction.TransactionDate = this.dtpTransactionDate.Value;
                poFolioTransaction.PostingDate = DateTime.Now;

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
                lChargeReferenceNo = poFolioTransaction.ReferenceNo;
                TransactionSourceDocument transSourc = (TransactionSourceDocument)this.cboTransSource.SelectedItem;
                poFolioTransaction.TransactionSource = transSourc.Abbreviation;

                poFolioTransaction.Memo = this.txtMemo.Text;
                if (this.pnlSubAccount.Visible)
                {
                    poFolioTransaction.Memo += " - " + this.cboSubAccount.Text;
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
                _baseAmount = _baseAmount - poFolioTransaction.Discount;




                //// if has SubAccount use SubAccount settings for Govt Tax
                //// else use TransactionCode settings for Govt Tax
                if (lSubAccountSelected == null)
                {
                    _inclusiveGovTax = _oTranCode.GovtTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = _oTranCode.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = _oTranCode.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = _oTranCode.GovtTax / 100;
                    _localTaxPercent = _oTranCode.LocalTax / 100;
                    _serviceChargePercent = _oTranCode.ServiceCharge / 100;

                }
                else
                {
                    _inclusiveGovTax = lSubAccountSelected.GovernmentTaxInclusive == 1 ? true : false;
                    _inclusiveLocalTax = lSubAccountSelected.LocalTaxInclusive == 1 ? true : false;
                    _inclusiveServiceCharge = lSubAccountSelected.ServiceChargeInclusive == 1 ? true : false;

                    _govtTaxPercent = lSubAccountSelected.GovernmentTax / 100;
                    _localTaxPercent = lSubAccountSelected.LocalTax / 100;
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

                ///>> compute Service Charge
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

                poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
                poFolioTransaction.createdBy = GlobalVariables.gLoggedOnUser;

                // new, Jrom, April 26, 2008
                // Golden prince requirement

                poFolioTransaction.CreditCardNo = this.txtPayment_CardNo.Text;
                poFolioTransaction.ChequeNo = this.txtPayment_Cheque.Text;
                poFolioTransaction.AccountName = this.txtPayment_Account.Text;
                poFolioTransaction.BankName = this.txtPayment_Bank.Text;
                poFolioTransaction.ChequeDate = this.dtpPayment_Date.Value;
                poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;

                poFolioTransaction.CreditCardType = this.txtCardType.Text;
                poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
                poFolioTransaction.SubAccount = this.cboSubAccount.Text;
                poFolioTransaction.CreditCardExpiry = this.dtpCardExpires.Value;
                poFolioTransaction.updatedBy = GlobalVariables.gLoggedOnUser;

                if (this.grbFolioInfo.Enabled)
                {
                    string _addGuestInfo = "";
                    if (txtReservationSource.Text != "")
                    {
                        _addGuestInfo = " (" + txtReservationSource.Text;
                        if (txtCardNumber.Text != "")
                        {
                            _addGuestInfo += " #" + txtCardNumber.Text;
                        }
                        _addGuestInfo += ")";
                    }

                    poFolioTransaction.ReferenceFolioId = this.txtFolioId.Text;
                    poFolioTransaction.RoomNumber = this.txtRoomNo.Text;
                    poFolioTransaction.AccountId = this.txtFolioId.Tag.ToString();
                    poFolioTransaction.GuestName = this.txtGuestName.Text + _addGuestInfo;
                    poFolioTransaction.CompanyName = this.txtGroupName.Text;
                }
                else
                {
                    poFolioTransaction.ReferenceFolioId = "";
                    poFolioTransaction.RoomNumber = "";
                    poFolioTransaction.AccountId = "";
                    poFolioTransaction.GuestName = "";
                    poFolioTransaction.CompanyName = "";
                }
                if (this.txtArrivalDate.Text == "")
                {
                    poFolioTransaction.ArrivalDate = DateTime.Parse(GlobalVariables.gAuditDate);
                }
                else
                {
                    poFolioTransaction.ArrivalDate = DateTime.Parse(this.txtArrivalDate.Text);
                }

                if (this.txtDepartureDate.Text == "")
                {
                    poFolioTransaction.DepartureDate = DateTime.Parse(GlobalVariables.gAuditDate);
                }
                else
                {
                    poFolioTransaction.DepartureDate = DateTime.Parse(this.txtDepartureDate.Text);
                }


                if (this.grbDriver.Enabled)
                {
                    poFolioTransaction.ReferenceDriverId = this.txtDriverId.Text;
                    poFolioTransaction.CarCompany = this.txtCarCompany.Text;
                    poFolioTransaction.MakeModel = this.txtMakeModel.Text;
                    poFolioTransaction.PlateNumber = this.txtPlateNum.Text;

                    poFolioTransaction.DriverFirstName = driver.FirstName;
                    poFolioTransaction.DriverLastName = driver.LastName;
                }
                else
                {
                    poFolioTransaction.ReferenceDriverId = "";
                    poFolioTransaction.CarCompany = "";
                    poFolioTransaction.MakeModel = "";
                    poFolioTransaction.PlateNumber = "";
                }


            }


            private void AssignFolioTransValuesPayment(AccountingAdjustments poFolioTransaction)
            {
                string _selectedTranCode = this.cboPaymentTypes.SelectedValue.ToString();
                string _memo = this.cboPaymentTypes.Text;


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

                poFolioTransaction.TransactionDate = this.dtpTransactionDate.Value;
                poFolioTransaction.PostingDate = DateTime.Now;
                poFolioTransaction.TransactionCode = _selectedTranCode;
                poFolioTransaction.SubAccount = cboPaymentSubAccount.Text;
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
                poFolioTransaction.TransactionSource = this.cboPaymentTransSource.Text;

                //get transaction description for the charged payment
                TransactionCode _transDescription = loTransactionCodeFacade.getTransactionCode(txtTransactionCode.Text);
                poFolioTransaction.Memo = _memo + _additionalMemo + "[" + _transDescription.Memo + " - #" + lChargeReferenceNo + "]";
                if (this.pnlPaymentSubAccount.Visible)
                {
                    poFolioTransaction.Memo += " - " + this.cboPaymentSubAccount.Text;
                }
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
                poFolioTransaction.ChequeDate = this.dtpPayment_Date.Value;
                poFolioTransaction.FOCGrantedBy = this.txtGrantedBy.Text;
                poFolioTransaction.CreditCardType = this.txtCardType.Text;
                poFolioTransaction.ApprovalSlip = this.txtCardApproval.Text;
                poFolioTransaction.CreditCardExpiry = this.dtpCardExpires.Value;

                poFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
                poFolioTransaction.ShiftCode = GlobalVariables.gShiftCode;
                poFolioTransaction.createdBy = GlobalVariables.gLoggedOnUser;
                poFolioTransaction.updatedBy = GlobalVariables.gLoggedOnUser;


                if (this.grbFolioInfo.Enabled)
                {
                    //>>show reservation source and card number of guest if it has
                    string _addGuestInfo = "";
                    if (txtReservationSource.Text != "")
                    {
                        _addGuestInfo = " (" + txtReservationSource.Text;
                        if (txtCardNumber.Text != "")
                        {
                            _addGuestInfo += " #" + txtCardNumber.Text;
                        }
                        _addGuestInfo += ")";
                    }

                    poFolioTransaction.ReferenceFolioId = this.txtFolioId.Text;
                    poFolioTransaction.RoomNumber = this.txtRoomNo.Text;
                    if (cboPaymentTypes.SelectedValue.ToString() == "4200")
                    {
                        poFolioTransaction.AccountId = this.txtPayment_AccountID.Text;
                        poFolioTransaction.GuestName = this.txtPayment_AccountName.Text;
                    }
                    else
                    {
                        poFolioTransaction.AccountId = this.txtFolioId.Tag.ToString();
                        poFolioTransaction.GuestName = this.txtGuestName.Text + _addGuestInfo;
                    }
                    poFolioTransaction.CompanyName = this.txtGroupName.Text;
                }
                else
                {
                    poFolioTransaction.ReferenceFolioId = "";
                    poFolioTransaction.RoomNumber = "";
                    if (cboPaymentTypes.SelectedValue.ToString() == "4200")
                    {
                        poFolioTransaction.AccountId = this.txtPayment_AccountID.Text;
                        poFolioTransaction.GuestName = this.txtPayment_AccountName.Text;
                    }
                    else
                    {
                        poFolioTransaction.AccountId = "";
                        poFolioTransaction.GuestName = "";
                    }
                    poFolioTransaction.CompanyName = "";
                }
                poFolioTransaction.ArrivalDate = DateTime.Parse(this.txtArrivalDate.Text);
                poFolioTransaction.DepartureDate = DateTime.Parse(this.txtDepartureDate.Text);

                if (this.grbDriver.Enabled)
                {
                    poFolioTransaction.ReferenceDriverId = this.txtDriverId.Text;
                    poFolioTransaction.CarCompany = this.txtCarCompany.Text;
                    poFolioTransaction.MakeModel = this.txtMakeModel.Text;
                    poFolioTransaction.PlateNumber = this.txtPlateNum.Text;

                    poFolioTransaction.DriverFirstName = driver.FirstName;
                    poFolioTransaction.DriverLastName = driver.LastName;
                }
                else
                {
                    poFolioTransaction.ReferenceDriverId = "";
                    poFolioTransaction.CarCompany = "";
                    poFolioTransaction.MakeModel = "";
                    poFolioTransaction.PlateNumber = "";
                }
            }
		}
	}
}
