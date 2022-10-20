using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.Presentation;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.NightAudit.BusinessLayer;

using System.Reflection;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Collections.Generic;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Security.Presentation;


namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class CheckOutUI : Jinisys.Hotel.UIFramework.Maintenance2UI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public CheckOutUI()
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
			internal System.Windows.Forms.TabPage TabPage1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader14;
			internal System.Windows.Forms.ColumnHeader ColumnHeader15;
			internal System.Windows.Forms.ColumnHeader ColumnHeader16;
			internal System.Windows.Forms.ColumnHeader ColumnHeader17;
			internal System.Windows.Forms.ColumnHeader ColumnHeader18;
			internal System.Windows.Forms.ColumnHeader ColumnHeader19;
			internal System.Windows.Forms.ColumnHeader ColumnHeader20;
			internal System.Windows.Forms.ColumnHeader ColumnHeader21;
			internal System.Windows.Forms.ColumnHeader ColumnHeader22;
			internal System.Windows.Forms.ColumnHeader ColumnHeader23;
			internal System.Windows.Forms.ColumnHeader ColumnHeader24;
			internal System.Windows.Forms.ColumnHeader ColumnHeader25;
			internal System.Windows.Forms.ColumnHeader ColumnHeader26;
			internal System.Windows.Forms.ColumnHeader ColumnHeader27;
			internal System.Windows.Forms.TabPage tpgGroup;
			internal System.Windows.Forms.ColumnHeader ColumnHeader7;
			internal System.Windows.Forms.ColumnHeader ColumnHeader8;
			internal System.Windows.Forms.ColumnHeader ColumnHeader9;
			internal System.Windows.Forms.ColumnHeader ColumnHeader10;
			internal System.Windows.Forms.ColumnHeader ColumnHeader11;
			internal System.Windows.Forms.ColumnHeader ColumnHeader12;
			internal System.Windows.Forms.ColumnHeader ColumnHeader13;
			internal System.Windows.Forms.ColumnHeader ColumnHeader28;
			internal System.Windows.Forms.ColumnHeader ColumnHeader29;
			internal System.Windows.Forms.ColumnHeader ColumnHeader30;
			internal System.Windows.Forms.ColumnHeader ColumnHeader31;
			internal System.Windows.Forms.ColumnHeader ColumnHeader32;
			internal System.Windows.Forms.ColumnHeader ColumnHeader33;
			internal System.Windows.Forms.ColumnHeader ColumnHeader34;
			internal System.Windows.Forms.ColumnHeader ColumnHeader35;
			internal System.Windows.Forms.ColumnHeader ColumnHeader36;
			internal System.Windows.Forms.ColumnHeader ColumnHeader37;
			internal System.Windows.Forms.ColumnHeader ColumnHeader38;
			public System.Windows.Forms.Label Label33;
			public System.Windows.Forms.Label Label34;
			public System.Windows.Forms.Label Label30;
			public System.Windows.Forms.Label Label32;
			public System.Windows.Forms.Label Label20;
			public System.Windows.Forms.Label Label21;
			public System.Windows.Forms.Label Label17;
			public System.Windows.Forms.Label Label18;
			public System.Windows.Forms.Label Label19;
			public System.Windows.Forms.Label Label16;
			public System.Windows.Forms.Label Label15;
			public System.Windows.Forms.Label Label14;
			public System.Windows.Forms.Label Label7;
			public System.Windows.Forms.Label Label13;
			public System.Windows.Forms.Label Label12;
			public System.Windows.Forms.Label Label11;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.Label Label22;
			public System.Windows.Forms.Label Label23;
			public System.Windows.Forms.Label Label24;
			public System.Windows.Forms.Label Label25;
			public System.Windows.Forms.Label Label26;
			public System.Windows.Forms.Label Label27;
			public System.Windows.Forms.Label Label28;
			public System.Windows.Forms.Label Label29;
			public System.Windows.Forms.Label Label31;
			internal System.Windows.Forms.ColumnHeader ColumnHeader41;
			internal System.Windows.Forms.ColumnHeader ColumnHeader40;
			internal System.Windows.Forms.ColumnHeader ColumnHeader39;
			internal System.Windows.Forms.ColumnHeader ColumnHeader47;
			internal System.Windows.Forms.ColumnHeader ColumnHeader46;
			internal System.Windows.Forms.ColumnHeader ColumnHeader45;
			internal System.Windows.Forms.ColumnHeader ColumnHeader44;
			internal System.Windows.Forms.ColumnHeader ColumnHeader43;
			internal System.Windows.Forms.ColumnHeader ColumnHeader42;
			internal System.Windows.Forms.GroupBox GroupBox7;
			internal System.Windows.Forms.TextBox txtGroupName;
			internal System.Windows.Forms.ListView lvwChildFolio;
			internal System.Windows.Forms.ColumnHeader colRoom;
			internal System.Windows.Forms.ColumnHeader colFolioID;
			internal System.Windows.Forms.ColumnHeader colName;
			internal System.Windows.Forms.ColumnHeader colCharges;
			internal System.Windows.Forms.ColumnHeader colPayments;
			internal System.Windows.Forms.ColumnHeader colBalance;
			internal System.Windows.Forms.ColumnHeader colStatus;
			internal System.Windows.Forms.GroupBox GroupBox1;
			public System.Windows.Forms.Label Label9;
			public System.Windows.Forms.Label Label10;
			public System.Windows.Forms.Label Label35;
			public System.Windows.Forms.Label Label49;
			public System.Windows.Forms.Label Label50;
			public System.Windows.Forms.Label Label51;
			public System.Windows.Forms.Label Label52;
			public System.Windows.Forms.Label Label53;
			public System.Windows.Forms.Label Label54;
			public System.Windows.Forms.Label Label55;
			public System.Windows.Forms.Label Label56;
			public System.Windows.Forms.Label Label57;
			public System.Windows.Forms.Label Label60;
			internal System.Windows.Forms.Button btnLookUp;
			public System.Windows.Forms.Label lblGrpSrvChrg;
			public System.Windows.Forms.Label lblGrpCommission;
			public System.Windows.Forms.Label lblGrpLocalTax;
			public System.Windows.Forms.Label lblGrpGovTax;
			public System.Windows.Forms.Label lblGrpTotalCharge;
			public System.Windows.Forms.Label lblGrpTotalDisCount;
			public System.Windows.Forms.Label lblGrpChargePayment;
			public System.Windows.Forms.Label lblGrpChequePayment;
			public System.Windows.Forms.Label lblGrpGiftChequePayment;
			public System.Windows.Forms.Label lblGrpCashPayment;
			public System.Windows.Forms.Label lblGrpBalanceForwarded;
			public System.Windows.Forms.Label lblGrpTotalNet;
			public System.Windows.Forms.Label lblGrpTotalBalance;
			internal System.Windows.Forms.CheckBox chkCheckAll;
			internal System.Windows.Forms.ListView lvwBrowseGroupName;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			internal System.Windows.Forms.Button btnClose;
			internal System.Windows.Forms.Button btnViewBill;
			internal System.Windows.Forms.Button btnPayment;
			internal System.Windows.Forms.Button btnCheckOutSingle;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.Label Label4;
			internal System.Windows.Forms.TabControl tabSubFolio;
			internal System.Windows.Forms.TabPage TabPage2;
			internal System.Windows.Forms.TabPage TabPage3;
			public System.Windows.Forms.Label lblCom;
			internal System.Windows.Forms.TabPage TabPage4;
			public System.Windows.Forms.Label Label86;
			internal System.Windows.Forms.TabPage TabPage5;
			public System.Windows.Forms.Label Label87;
			internal System.Windows.Forms.TabControl tabCheckout;
			internal System.Windows.Forms.TextBox txtRemarks;
			public System.Windows.Forms.Label Label88;
			internal System.Windows.Forms.Button btnBrowseCompany;
			internal System.Windows.Forms.TextBox txtCompanyName;
			internal System.Windows.Forms.TextBox txtCompanyId;
			internal System.Windows.Forms.Button btnBrowseAccountC;
			internal System.Windows.Forms.TextBox txtAccountNameC;
			internal System.Windows.Forms.TextBox txtAccountIdC;
			internal System.Windows.Forms.Button btnBrowseAccountD;
			internal System.Windows.Forms.TextBox txtAccountNameD;
			internal System.Windows.Forms.TextBox txtAccountIdD;
			internal System.Windows.Forms.TabControl tabGroupCheckOut;
			internal System.Windows.Forms.TabPage TabPage6;
            internal System.Windows.Forms.TabPage TabPage7;
			private ImageList imgIcon;
			private TextBox txtRoomID;
			private TextBox txtGuestName;
			private TextBox txtFolioId;
			private TextBox txtBalance;
			public Label label46;
			private TextBox txtTotalPayment;
			private TextBox txtTotalCharges;
			public Label label70;
			public Label label71;
			private TextBox txtDepartureDate;
			private TextBox txtArrivalDate;
			public Label label85;
			public Label label89;
			public Label label90;
			public Label Label118;
			public Label label91;
			private TextBox txtGroup_CompanyName;
			private TextBox txtGroupFolioId;
			private TextBox txtGrpBalance;
			public Label label105;
			private TextBox txtGrpTotalPayment;
			private TextBox txtGrpTotalCharges;
			public Label label106;
			public Label label107;
			private TextBox txtGrpDepartureDate;
			private TextBox txtGrpArrivalDate;
			public Label label108;
			public Label label109;
			private TextBox txtPayment_Mode;
			public Label label110;
			private TextBox txtAccount_Type;
			public Label label111;
			private TextBox txtGroupPaymentMode;
			public Label label112;
			private TextBox txtGroupAccountType;
			public Label label113;
			internal Button btnTransferDebit;
			private ListView lvwSubFolioA;
			private ColumnHeader columnHeader85;
			private ColumnHeader columnHeader86;
			private ColumnHeader columnHeader87;
			private ColumnHeader columnHeader88;
			private ColumnHeader columnHeader89;
			private ColumnHeader columnHeader102;
			private ColumnHeader columnHeader103;
			private ColumnHeader columnHeader104;
			private ColumnHeader columnHeader105;
			private ColumnHeader columnHeader106;
			private ColumnHeader columnHeader107;
			private ColumnHeader columnHeader108;
			private ColumnHeader columnHeader109;
			private ColumnHeader columnHeader110;
			private ColumnHeader columnHeader111;
			internal Button btnInsertCharges;
			private ListView lvwSubFolioB;
			private ColumnHeader columnHeader4;
			private ColumnHeader columnHeader5;
			private ColumnHeader columnHeader6;
			private ColumnHeader columnHeader48;
			private ColumnHeader columnHeader49;
			private ColumnHeader columnHeader50;
			private ColumnHeader columnHeader51;
			private ColumnHeader columnHeader52;
			private ColumnHeader columnHeader53;
			private ColumnHeader columnHeader81;
			private ColumnHeader columnHeader90;
			private ColumnHeader columnHeader94;
			private ColumnHeader columnHeader95;
			private ColumnHeader columnHeader112;
			private ColumnHeader columnHeader113;
			private ColumnHeader columnHeader54;
			private ColumnHeader columnHeader55;
            private ListView lvwGroupFolioA;
            private ColumnHeader columnHeader58;
            private ColumnHeader columnHeader59;
            private ColumnHeader columnHeader60;
            private ColumnHeader columnHeader61;
            private ColumnHeader columnHeader62;
            private ColumnHeader columnHeader82;
            private ColumnHeader columnHeader91;
            private ColumnHeader columnHeader96;
            private ColumnHeader columnHeader97;
            private ColumnHeader columnHeader114;
            private ColumnHeader columnHeader115;
            private ColumnHeader columnHeader116;
            private ColumnHeader columnHeader117;
            private ColumnHeader columnHeader118;
            private ColumnHeader columnHeader119;
			private ListView lvwSubFolioC;
			private ColumnHeader columnHeader56;
			private ColumnHeader columnHeader57;
			private ColumnHeader columnHeader63;
			private ColumnHeader columnHeader64;
			private ColumnHeader columnHeader65;
			private ColumnHeader columnHeader66;
			private ColumnHeader columnHeader67;
			private ColumnHeader columnHeader68;
			private ColumnHeader columnHeader69;
			private ColumnHeader columnHeader70;
			private ColumnHeader columnHeader71;
			private ColumnHeader columnHeader72;
			private ColumnHeader columnHeader73;
			private ColumnHeader columnHeader74;
			private ColumnHeader columnHeader75;
			private ColumnHeader columnHeader76;
			private ListView lvwSubFolioD;
			private ColumnHeader columnHeader77;
			private ColumnHeader columnHeader78;
			private ColumnHeader columnHeader79;
			private ColumnHeader columnHeader80;
			private ColumnHeader columnHeader83;
			private ColumnHeader columnHeader84;
			private ColumnHeader columnHeader92;
			private ColumnHeader columnHeader93;
			private ColumnHeader columnHeader98;
			private ColumnHeader columnHeader99;
			private ColumnHeader columnHeader100;
			private ColumnHeader columnHeader101;
			private ColumnHeader columnHeader121;
			private ColumnHeader columnHeader122;
			private ColumnHeader columnHeader123;
			private ColumnHeader columnHeader124;
			private ContextMenuStrip mnuPopUp;
			private ToolStripMenuItem mnuVoidTransaction;
			private ToolStripSeparator toolStripMenuItem1;
			private ToolStripMenuItem mnuRefreshLedger;
			private ToolStripMenuItem mnuInsertPayment;
			private ToolStripMenuItem mnuInsertCharges;
			private ToolStripSeparator toolStripMenuItem2;
			private ToolStripSeparator toolStripMenuItem3;
			private ToolStripMenuItem mnuPrintFolio;
			internal GroupBox GroupBox4;
			public Label label5;
			public Label label6;
			public Label Label40;
			public Label Label41;
			public Label Label42;
			public Label Label43;
			public Label lblChequePaymentB;
			public Label lblServiceChargeB;
			public Label lblCommissionB;
			public Label lblLocalTaxB;
			public Label lblGovtTaxB;
			public Label label8;
			public Label Label36;
			public Label Label37;
			public Label Label38;
			public Label Label39;
			public Label Label44;
			public Label Label45;
			public Label lblTotalChargesB;
			public Label lblTotalDiscountB;
			public Label lblChargePaymentB;
			public Label lblGiftChequePaymentB;
			public Label lblCashPaymentB;
			public Label lblBalanceForwardB;
			public Label lblTotalNetB;
			public Label lblTotalBalanceB;
			internal GroupBox groupBox3;
			public Label label47;
			public Label label48;
			public Label label58;
			public Label label59;
			public Label label61;
			public Label label62;
			public Label lblChequePaymentC;
			public Label lblServiceChargeC;
			public Label lblCommissionC;
			public Label lblLocalTaxC;
			public Label lblGovtTaxC;
			public Label label63;
			public Label label64;
			public Label label65;
			public Label label66;
			public Label label67;
			public Label label68;
			public Label label69;
			public Label lblTotalChargesC;
			public Label lblTotalDiscountC;
			public Label lblChargePaymentC;
			public Label lblGiftChequePaymentC;
			public Label lblCashPaymentC;
			public Label lblBalanceForwardC;
			public Label lblTotalNetC;
			public Label lblTotalBalanceC;
			internal GroupBox groupBox6;
			public Label label92;
			public Label label93;
			public Label label94;
			public Label label95;
			public Label label96;
			public Label label97;
			public Label lblChequePaymentA;
			public Label lblServiceChargeA;
			public Label lblCommissionA;
			public Label lblLocalTaxA;
			public Label lblGovtTaxA;
			public Label label98;
			public Label label99;
			public Label label100;
			public Label label101;
			public Label label102;
			public Label label103;
			public Label label104;
			public Label lblTotalChargesA;
			public Label lblTotalDiscountA;
			public Label lblChargePaymentA;
			public Label lblGiftChequePaymentA;
			public Label lblCashPaymentA;
			public Label lblBalanceForwardA;
			public Label lblTotalNetA;
			public Label lblTotalBalanceA;
			internal GroupBox groupBox5;
			public Label label72;
			public Label label73;
			public Label label74;
			public Label label75;
			public Label label76;
			public Label label77;
			public Label lblChequePaymentD;
			public Label lblServiceChargeD;
			public Label lblCommissionD;
			public Label lblLocalTaxD;
			public Label lblGovtTaxD;
			public Label label78;
			public Label label79;
			public Label label80;
			public Label label81;
			public Label label82;
			public Label label83;
			public Label label84;
			public Label lblTotalChargesD;
			public Label lblTotalDiscountD;
			public Label lblChargePaymentD;
			public Label lblGiftChequePaymentD;
			public Label lblCashPaymentD;
			public Label lblBalanceForwardD;
			public Label lblTotalNetD;
			public Label lblTotalBalanceD;
			public Label label114;
			private GroupBox groupBox2;
            public Label label115;
            private TextBox txtGrpRoomID;
            private ColumnHeader colRunningBalance;
            private TextBox txtGroupRemarks;
            private Label label116;
            private Panel pnlRemarks;
            private Button btnRemarksOK;
            private Button btnRemarksCancel;
            private CheckBox chkNoPayments;
            private Label label117;
            private TextBox txtComptrollersInfo;
			private ColumnHeader columnHeader120;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOutUI));
                this.tabCheckout = new System.Windows.Forms.TabControl();
                this.TabPage1 = new System.Windows.Forms.TabPage();
                this.tabSubFolio = new System.Windows.Forms.TabControl();
                this.TabPage2 = new System.Windows.Forms.TabPage();
                this.groupBox6 = new System.Windows.Forms.GroupBox();
                this.label92 = new System.Windows.Forms.Label();
                this.label93 = new System.Windows.Forms.Label();
                this.label94 = new System.Windows.Forms.Label();
                this.label95 = new System.Windows.Forms.Label();
                this.label96 = new System.Windows.Forms.Label();
                this.label97 = new System.Windows.Forms.Label();
                this.lblChequePaymentA = new System.Windows.Forms.Label();
                this.lblServiceChargeA = new System.Windows.Forms.Label();
                this.lblCommissionA = new System.Windows.Forms.Label();
                this.lblLocalTaxA = new System.Windows.Forms.Label();
                this.lblGovtTaxA = new System.Windows.Forms.Label();
                this.label98 = new System.Windows.Forms.Label();
                this.label99 = new System.Windows.Forms.Label();
                this.label100 = new System.Windows.Forms.Label();
                this.label101 = new System.Windows.Forms.Label();
                this.label102 = new System.Windows.Forms.Label();
                this.label103 = new System.Windows.Forms.Label();
                this.label104 = new System.Windows.Forms.Label();
                this.lblTotalChargesA = new System.Windows.Forms.Label();
                this.lblTotalDiscountA = new System.Windows.Forms.Label();
                this.lblChargePaymentA = new System.Windows.Forms.Label();
                this.lblGiftChequePaymentA = new System.Windows.Forms.Label();
                this.lblCashPaymentA = new System.Windows.Forms.Label();
                this.lblBalanceForwardA = new System.Windows.Forms.Label();
                this.lblTotalNetA = new System.Windows.Forms.Label();
                this.lblTotalBalanceA = new System.Windows.Forms.Label();
                this.lvwSubFolioA = new System.Windows.Forms.ListView();
                this.columnHeader85 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader86 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader87 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader88 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader89 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader102 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader103 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader104 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader105 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader106 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader107 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader108 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader109 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader110 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader111 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader54 = new System.Windows.Forms.ColumnHeader();
                this.mnuPopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.mnuInsertPayment = new System.Windows.Forms.ToolStripMenuItem();
                this.mnuInsertCharges = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
                this.mnuVoidTransaction = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
                this.mnuRefreshLedger = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
                this.mnuPrintFolio = new System.Windows.Forms.ToolStripMenuItem();
                this.TabPage3 = new System.Windows.Forms.TabPage();
                this.GroupBox4 = new System.Windows.Forms.GroupBox();
                this.label5 = new System.Windows.Forms.Label();
                this.label6 = new System.Windows.Forms.Label();
                this.Label40 = new System.Windows.Forms.Label();
                this.Label41 = new System.Windows.Forms.Label();
                this.Label42 = new System.Windows.Forms.Label();
                this.Label43 = new System.Windows.Forms.Label();
                this.lblChequePaymentB = new System.Windows.Forms.Label();
                this.lblServiceChargeB = new System.Windows.Forms.Label();
                this.lblCommissionB = new System.Windows.Forms.Label();
                this.lblLocalTaxB = new System.Windows.Forms.Label();
                this.lblGovtTaxB = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.Label36 = new System.Windows.Forms.Label();
                this.Label37 = new System.Windows.Forms.Label();
                this.Label38 = new System.Windows.Forms.Label();
                this.Label39 = new System.Windows.Forms.Label();
                this.Label44 = new System.Windows.Forms.Label();
                this.Label45 = new System.Windows.Forms.Label();
                this.lblTotalChargesB = new System.Windows.Forms.Label();
                this.lblTotalDiscountB = new System.Windows.Forms.Label();
                this.lblChargePaymentB = new System.Windows.Forms.Label();
                this.lblGiftChequePaymentB = new System.Windows.Forms.Label();
                this.lblCashPaymentB = new System.Windows.Forms.Label();
                this.lblBalanceForwardB = new System.Windows.Forms.Label();
                this.lblTotalNetB = new System.Windows.Forms.Label();
                this.lblTotalBalanceB = new System.Windows.Forms.Label();
                this.btnBrowseCompany = new System.Windows.Forms.Button();
                this.imgIcon = new System.Windows.Forms.ImageList(this.components);
                this.txtCompanyName = new System.Windows.Forms.TextBox();
                this.txtCompanyId = new System.Windows.Forms.TextBox();
                this.lblCom = new System.Windows.Forms.Label();
                this.lvwSubFolioB = new System.Windows.Forms.ListView();
                this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader48 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader49 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader50 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader51 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader52 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader53 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader81 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader90 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader94 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader95 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader112 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader113 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader55 = new System.Windows.Forms.ColumnHeader();
                this.TabPage4 = new System.Windows.Forms.TabPage();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.label47 = new System.Windows.Forms.Label();
                this.label48 = new System.Windows.Forms.Label();
                this.label58 = new System.Windows.Forms.Label();
                this.label59 = new System.Windows.Forms.Label();
                this.label61 = new System.Windows.Forms.Label();
                this.label62 = new System.Windows.Forms.Label();
                this.lblChequePaymentC = new System.Windows.Forms.Label();
                this.lblServiceChargeC = new System.Windows.Forms.Label();
                this.lblCommissionC = new System.Windows.Forms.Label();
                this.lblLocalTaxC = new System.Windows.Forms.Label();
                this.lblGovtTaxC = new System.Windows.Forms.Label();
                this.label63 = new System.Windows.Forms.Label();
                this.label64 = new System.Windows.Forms.Label();
                this.label65 = new System.Windows.Forms.Label();
                this.label66 = new System.Windows.Forms.Label();
                this.label67 = new System.Windows.Forms.Label();
                this.label68 = new System.Windows.Forms.Label();
                this.label69 = new System.Windows.Forms.Label();
                this.lblTotalChargesC = new System.Windows.Forms.Label();
                this.lblTotalDiscountC = new System.Windows.Forms.Label();
                this.lblChargePaymentC = new System.Windows.Forms.Label();
                this.lblGiftChequePaymentC = new System.Windows.Forms.Label();
                this.lblCashPaymentC = new System.Windows.Forms.Label();
                this.lblBalanceForwardC = new System.Windows.Forms.Label();
                this.lblTotalNetC = new System.Windows.Forms.Label();
                this.lblTotalBalanceC = new System.Windows.Forms.Label();
                this.lvwSubFolioC = new System.Windows.Forms.ListView();
                this.columnHeader56 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader57 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader63 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader64 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader65 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader66 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader67 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader68 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader69 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader70 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader71 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader72 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader73 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader74 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader75 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader76 = new System.Windows.Forms.ColumnHeader();
                this.btnBrowseAccountC = new System.Windows.Forms.Button();
                this.txtAccountNameC = new System.Windows.Forms.TextBox();
                this.txtAccountIdC = new System.Windows.Forms.TextBox();
                this.Label86 = new System.Windows.Forms.Label();
                this.TabPage5 = new System.Windows.Forms.TabPage();
                this.groupBox5 = new System.Windows.Forms.GroupBox();
                this.label72 = new System.Windows.Forms.Label();
                this.label73 = new System.Windows.Forms.Label();
                this.label74 = new System.Windows.Forms.Label();
                this.label75 = new System.Windows.Forms.Label();
                this.label76 = new System.Windows.Forms.Label();
                this.label77 = new System.Windows.Forms.Label();
                this.lblChequePaymentD = new System.Windows.Forms.Label();
                this.lblServiceChargeD = new System.Windows.Forms.Label();
                this.lblCommissionD = new System.Windows.Forms.Label();
                this.lblLocalTaxD = new System.Windows.Forms.Label();
                this.lblGovtTaxD = new System.Windows.Forms.Label();
                this.label78 = new System.Windows.Forms.Label();
                this.label79 = new System.Windows.Forms.Label();
                this.label80 = new System.Windows.Forms.Label();
                this.label81 = new System.Windows.Forms.Label();
                this.label82 = new System.Windows.Forms.Label();
                this.label83 = new System.Windows.Forms.Label();
                this.label84 = new System.Windows.Forms.Label();
                this.lblTotalChargesD = new System.Windows.Forms.Label();
                this.lblTotalDiscountD = new System.Windows.Forms.Label();
                this.lblChargePaymentD = new System.Windows.Forms.Label();
                this.lblGiftChequePaymentD = new System.Windows.Forms.Label();
                this.lblCashPaymentD = new System.Windows.Forms.Label();
                this.lblBalanceForwardD = new System.Windows.Forms.Label();
                this.lblTotalNetD = new System.Windows.Forms.Label();
                this.lblTotalBalanceD = new System.Windows.Forms.Label();
                this.lvwSubFolioD = new System.Windows.Forms.ListView();
                this.columnHeader77 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader78 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader79 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader80 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader83 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader84 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader92 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader93 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader98 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader99 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader100 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader101 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader121 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader122 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader123 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader124 = new System.Windows.Forms.ColumnHeader();
                this.btnBrowseAccountD = new System.Windows.Forms.Button();
                this.txtAccountNameD = new System.Windows.Forms.TextBox();
                this.txtAccountIdD = new System.Windows.Forms.TextBox();
                this.Label87 = new System.Windows.Forms.Label();
                this.GroupBox7 = new System.Windows.Forms.GroupBox();
                this.txtPayment_Mode = new System.Windows.Forms.TextBox();
                this.label110 = new System.Windows.Forms.Label();
                this.txtAccount_Type = new System.Windows.Forms.TextBox();
                this.label111 = new System.Windows.Forms.Label();
                this.txtRoomID = new System.Windows.Forms.TextBox();
                this.txtGuestName = new System.Windows.Forms.TextBox();
                this.txtFolioId = new System.Windows.Forms.TextBox();
                this.txtBalance = new System.Windows.Forms.TextBox();
                this.label46 = new System.Windows.Forms.Label();
                this.txtTotalPayment = new System.Windows.Forms.TextBox();
                this.txtTotalCharges = new System.Windows.Forms.TextBox();
                this.label70 = new System.Windows.Forms.Label();
                this.label71 = new System.Windows.Forms.Label();
                this.txtDepartureDate = new System.Windows.Forms.TextBox();
                this.txtArrivalDate = new System.Windows.Forms.TextBox();
                this.label85 = new System.Windows.Forms.Label();
                this.label89 = new System.Windows.Forms.Label();
                this.label90 = new System.Windows.Forms.Label();
                this.Label118 = new System.Windows.Forms.Label();
                this.label91 = new System.Windows.Forms.Label();
                this.txtRemarks = new System.Windows.Forms.TextBox();
                this.Label88 = new System.Windows.Forms.Label();
                this.tpgGroup = new System.Windows.Forms.TabPage();
                this.pnlRemarks = new System.Windows.Forms.Panel();
                this.chkNoPayments = new System.Windows.Forms.CheckBox();
                this.btnRemarksCancel = new System.Windows.Forms.Button();
                this.btnRemarksOK = new System.Windows.Forms.Button();
                this.label116 = new System.Windows.Forms.Label();
                this.txtGroupRemarks = new System.Windows.Forms.TextBox();
                this.label115 = new System.Windows.Forms.Label();
                this.txtGrpRoomID = new System.Windows.Forms.TextBox();
                this.txtGroupPaymentMode = new System.Windows.Forms.TextBox();
                this.label112 = new System.Windows.Forms.Label();
                this.Label4 = new System.Windows.Forms.Label();
                this.txtGroupAccountType = new System.Windows.Forms.TextBox();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.lblGrpSrvChrg = new System.Windows.Forms.Label();
                this.lblGrpCommission = new System.Windows.Forms.Label();
                this.lblGrpLocalTax = new System.Windows.Forms.Label();
                this.lblGrpGovTax = new System.Windows.Forms.Label();
                this.Label9 = new System.Windows.Forms.Label();
                this.Label10 = new System.Windows.Forms.Label();
                this.Label35 = new System.Windows.Forms.Label();
                this.Label49 = new System.Windows.Forms.Label();
                this.Label50 = new System.Windows.Forms.Label();
                this.Label51 = new System.Windows.Forms.Label();
                this.Label52 = new System.Windows.Forms.Label();
                this.Label53 = new System.Windows.Forms.Label();
                this.Label54 = new System.Windows.Forms.Label();
                this.Label55 = new System.Windows.Forms.Label();
                this.Label56 = new System.Windows.Forms.Label();
                this.Label57 = new System.Windows.Forms.Label();
                this.Label60 = new System.Windows.Forms.Label();
                this.lblGrpTotalCharge = new System.Windows.Forms.Label();
                this.lblGrpTotalDisCount = new System.Windows.Forms.Label();
                this.lblGrpChargePayment = new System.Windows.Forms.Label();
                this.lblGrpChequePayment = new System.Windows.Forms.Label();
                this.lblGrpGiftChequePayment = new System.Windows.Forms.Label();
                this.lblGrpCashPayment = new System.Windows.Forms.Label();
                this.lblGrpBalanceForwarded = new System.Windows.Forms.Label();
                this.lblGrpTotalNet = new System.Windows.Forms.Label();
                this.lblGrpTotalBalance = new System.Windows.Forms.Label();
                this.label113 = new System.Windows.Forms.Label();
                this.txtGroupName = new System.Windows.Forms.TextBox();
                this.lvwBrowseGroupName = new System.Windows.Forms.ListView();
                this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.Label1 = new System.Windows.Forms.Label();
                this.txtGrpBalance = new System.Windows.Forms.TextBox();
                this.btnLookUp = new System.Windows.Forms.Button();
                this.label105 = new System.Windows.Forms.Label();
                this.Label2 = new System.Windows.Forms.Label();
                this.txtGrpTotalPayment = new System.Windows.Forms.TextBox();
                this.tabGroupCheckOut = new System.Windows.Forms.TabControl();
                this.TabPage6 = new System.Windows.Forms.TabPage();
                this.lvwChildFolio = new System.Windows.Forms.ListView();
                this.colRoom = new System.Windows.Forms.ColumnHeader();
                this.colName = new System.Windows.Forms.ColumnHeader();
                this.colFolioID = new System.Windows.Forms.ColumnHeader();
                this.colCharges = new System.Windows.Forms.ColumnHeader();
                this.colPayments = new System.Windows.Forms.ColumnHeader();
                this.colBalance = new System.Windows.Forms.ColumnHeader();
                this.colRunningBalance = new System.Windows.Forms.ColumnHeader();
                this.colStatus = new System.Windows.Forms.ColumnHeader();
                this.chkCheckAll = new System.Windows.Forms.CheckBox();
                this.TabPage7 = new System.Windows.Forms.TabPage();
                this.lvwGroupFolioA = new System.Windows.Forms.ListView();
                this.columnHeader58 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader59 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader60 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader61 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader62 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader82 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader91 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader96 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader97 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader114 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader115 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader116 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader117 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader118 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader119 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader120 = new System.Windows.Forms.ColumnHeader();
                this.txtGrpTotalCharges = new System.Windows.Forms.TextBox();
                this.txtGroupFolioId = new System.Windows.Forms.TextBox();
                this.label106 = new System.Windows.Forms.Label();
                this.txtGroup_CompanyName = new System.Windows.Forms.TextBox();
                this.label107 = new System.Windows.Forms.Label();
                this.label109 = new System.Windows.Forms.Label();
                this.txtGrpDepartureDate = new System.Windows.Forms.TextBox();
                this.label108 = new System.Windows.Forms.Label();
                this.txtGrpArrivalDate = new System.Windows.Forms.TextBox();
                this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader15 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader16 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader17 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader18 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader19 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader21 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader22 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader23 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader24 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader25 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader26 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader27 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader10 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader28 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader29 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader30 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader31 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader32 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader33 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader34 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader35 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader36 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader37 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader38 = new System.Windows.Forms.ColumnHeader();
                this.Label33 = new System.Windows.Forms.Label();
                this.Label34 = new System.Windows.Forms.Label();
                this.Label30 = new System.Windows.Forms.Label();
                this.Label32 = new System.Windows.Forms.Label();
                this.Label20 = new System.Windows.Forms.Label();
                this.Label21 = new System.Windows.Forms.Label();
                this.Label17 = new System.Windows.Forms.Label();
                this.Label18 = new System.Windows.Forms.Label();
                this.Label19 = new System.Windows.Forms.Label();
                this.Label16 = new System.Windows.Forms.Label();
                this.Label15 = new System.Windows.Forms.Label();
                this.Label14 = new System.Windows.Forms.Label();
                this.Label7 = new System.Windows.Forms.Label();
                this.Label13 = new System.Windows.Forms.Label();
                this.Label12 = new System.Windows.Forms.Label();
                this.Label11 = new System.Windows.Forms.Label();
                this.Label3 = new System.Windows.Forms.Label();
                this.Label22 = new System.Windows.Forms.Label();
                this.Label23 = new System.Windows.Forms.Label();
                this.Label24 = new System.Windows.Forms.Label();
                this.Label25 = new System.Windows.Forms.Label();
                this.Label26 = new System.Windows.Forms.Label();
                this.Label27 = new System.Windows.Forms.Label();
                this.Label28 = new System.Windows.Forms.Label();
                this.Label29 = new System.Windows.Forms.Label();
                this.Label31 = new System.Windows.Forms.Label();
                this.ColumnHeader41 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader40 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader39 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader47 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader46 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader45 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader44 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader43 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader42 = new System.Windows.Forms.ColumnHeader();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnViewBill = new System.Windows.Forms.Button();
                this.btnPayment = new System.Windows.Forms.Button();
                this.btnCheckOutSingle = new System.Windows.Forms.Button();
                this.btnTransferDebit = new System.Windows.Forms.Button();
                this.btnInsertCharges = new System.Windows.Forms.Button();
                this.label114 = new System.Windows.Forms.Label();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.label117 = new System.Windows.Forms.Label();
                this.txtComptrollersInfo = new System.Windows.Forms.TextBox();
                this.tabCheckout.SuspendLayout();
                this.TabPage1.SuspendLayout();
                this.tabSubFolio.SuspendLayout();
                this.TabPage2.SuspendLayout();
                this.groupBox6.SuspendLayout();
                this.mnuPopUp.SuspendLayout();
                this.TabPage3.SuspendLayout();
                this.GroupBox4.SuspendLayout();
                this.TabPage4.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.TabPage5.SuspendLayout();
                this.groupBox5.SuspendLayout();
                this.GroupBox7.SuspendLayout();
                this.tpgGroup.SuspendLayout();
                this.pnlRemarks.SuspendLayout();
                this.GroupBox1.SuspendLayout();
                this.tabGroupCheckOut.SuspendLayout();
                this.TabPage6.SuspendLayout();
                this.TabPage7.SuspendLayout();
                this.SuspendLayout();
                // 
                // tabCheckout
                // 
                this.tabCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tabCheckout.Controls.Add(this.TabPage1);
                this.tabCheckout.Controls.Add(this.tpgGroup);
                this.tabCheckout.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tabCheckout.Location = new System.Drawing.Point(9, 45);
                this.tabCheckout.Name = "tabCheckout";
                this.tabCheckout.SelectedIndex = 0;
                this.tabCheckout.Size = new System.Drawing.Size(834, 556);
                this.tabCheckout.TabIndex = 0;
                this.tabCheckout.SelectedIndexChanged += new System.EventHandler(this.tabCheckout_SelectedIndexChanged);
                // 
                // TabPage1
                // 
                this.TabPage1.Controls.Add(this.tabSubFolio);
                this.TabPage1.Controls.Add(this.GroupBox7);
                this.TabPage1.Location = new System.Drawing.Point(4, 23);
                this.TabPage1.Name = "TabPage1";
                this.TabPage1.Size = new System.Drawing.Size(826, 529);
                this.TabPage1.TabIndex = 0;
                this.TabPage1.Text = "Single";
                // 
                // tabSubFolio
                // 
                this.tabSubFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tabSubFolio.Controls.Add(this.TabPage2);
                this.tabSubFolio.Controls.Add(this.TabPage3);
                this.tabSubFolio.Controls.Add(this.TabPage4);
                this.tabSubFolio.Controls.Add(this.TabPage5);
                this.tabSubFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tabSubFolio.Location = new System.Drawing.Point(6, 172);
                this.tabSubFolio.Multiline = true;
                this.tabSubFolio.Name = "tabSubFolio";
                this.tabSubFolio.SelectedIndex = 0;
                this.tabSubFolio.Size = new System.Drawing.Size(813, 350);
                this.tabSubFolio.TabIndex = 104;
                // 
                // TabPage2
                // 
                this.TabPage2.Controls.Add(this.groupBox6);
                this.TabPage2.Controls.Add(this.lvwSubFolioA);
                this.TabPage2.Location = new System.Drawing.Point(4, 23);
                this.TabPage2.Name = "TabPage2";
                this.TabPage2.Size = new System.Drawing.Size(805, 323);
                this.TabPage2.TabIndex = 0;
                this.TabPage2.Text = "A (Personal)";
                // 
                // groupBox6
                // 
                this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox6.Controls.Add(this.label92);
                this.groupBox6.Controls.Add(this.label93);
                this.groupBox6.Controls.Add(this.label94);
                this.groupBox6.Controls.Add(this.label95);
                this.groupBox6.Controls.Add(this.label96);
                this.groupBox6.Controls.Add(this.label97);
                this.groupBox6.Controls.Add(this.lblChequePaymentA);
                this.groupBox6.Controls.Add(this.lblServiceChargeA);
                this.groupBox6.Controls.Add(this.lblCommissionA);
                this.groupBox6.Controls.Add(this.lblLocalTaxA);
                this.groupBox6.Controls.Add(this.lblGovtTaxA);
                this.groupBox6.Controls.Add(this.label98);
                this.groupBox6.Controls.Add(this.label99);
                this.groupBox6.Controls.Add(this.label100);
                this.groupBox6.Controls.Add(this.label101);
                this.groupBox6.Controls.Add(this.label102);
                this.groupBox6.Controls.Add(this.label103);
                this.groupBox6.Controls.Add(this.label104);
                this.groupBox6.Controls.Add(this.lblTotalChargesA);
                this.groupBox6.Controls.Add(this.lblTotalDiscountA);
                this.groupBox6.Controls.Add(this.lblChargePaymentA);
                this.groupBox6.Controls.Add(this.lblGiftChequePaymentA);
                this.groupBox6.Controls.Add(this.lblCashPaymentA);
                this.groupBox6.Controls.Add(this.lblBalanceForwardA);
                this.groupBox6.Controls.Add(this.lblTotalNetA);
                this.groupBox6.Controls.Add(this.lblTotalBalanceA);
                this.groupBox6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.groupBox6.Location = new System.Drawing.Point(4, 206);
                this.groupBox6.Name = "groupBox6";
                this.groupBox6.Size = new System.Drawing.Size(796, 113);
                this.groupBox6.TabIndex = 138;
                this.groupBox6.TabStop = false;
                this.groupBox6.Text = "Sub-folio A Summary";
                // 
                // label92
                // 
                this.label92.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label92.Location = new System.Drawing.Point(612, 77);
                this.label92.Name = "label92";
                this.label92.Size = new System.Drawing.Size(89, 14);
                this.label92.TabIndex = 114;
                this.label92.Text = "Commission :";
                this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label93
                // 
                this.label93.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label93.Location = new System.Drawing.Point(612, 59);
                this.label93.Name = "label93";
                this.label93.Size = new System.Drawing.Size(89, 14);
                this.label93.TabIndex = 113;
                this.label93.Text = "Service Charge :";
                this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label94
                // 
                this.label94.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label94.Location = new System.Drawing.Point(195, 40);
                this.label94.Name = "label94";
                this.label94.Size = new System.Drawing.Size(94, 14);
                this.label94.TabIndex = 108;
                this.label94.Text = "Charge Payment :";
                this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label95
                // 
                this.label95.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label95.Location = new System.Drawing.Point(195, 58);
                this.label95.Name = "label95";
                this.label95.Size = new System.Drawing.Size(94, 14);
                this.label95.TabIndex = 107;
                this.label95.Text = "Cheque Payment :";
                this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label96
                // 
                this.label96.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label96.Location = new System.Drawing.Point(195, 22);
                this.label96.Name = "label96";
                this.label96.Size = new System.Drawing.Size(94, 14);
                this.label96.TabIndex = 106;
                this.label96.Text = "Cash Payment :";
                this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label97
                // 
                this.label97.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label97.Location = new System.Drawing.Point(195, 76);
                this.label97.Name = "label97";
                this.label97.Size = new System.Drawing.Size(94, 14);
                this.label97.TabIndex = 105;
                this.label97.Text = "Gift Cheque :";
                this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentA
                // 
                this.lblChequePaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentA.Location = new System.Drawing.Point(289, 58);
                this.lblChequePaymentA.Name = "lblChequePaymentA";
                this.lblChequePaymentA.Size = new System.Drawing.Size(82, 14);
                this.lblChequePaymentA.TabIndex = 120;
                this.lblChequePaymentA.Text = "0.00";
                this.lblChequePaymentA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblServiceChargeA
                // 
                this.lblServiceChargeA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblServiceChargeA.Location = new System.Drawing.Point(700, 59);
                this.lblServiceChargeA.Name = "lblServiceChargeA";
                this.lblServiceChargeA.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeA.TabIndex = 119;
                this.lblServiceChargeA.Text = "0.00";
                this.lblServiceChargeA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionA
                // 
                this.lblCommissionA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionA.Location = new System.Drawing.Point(700, 77);
                this.lblCommissionA.Name = "lblCommissionA";
                this.lblCommissionA.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionA.TabIndex = 118;
                this.lblCommissionA.Text = "0.00";
                this.lblCommissionA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxA
                // 
                this.lblLocalTaxA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxA.Location = new System.Drawing.Point(700, 40);
                this.lblLocalTaxA.Name = "lblLocalTaxA";
                this.lblLocalTaxA.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxA.TabIndex = 117;
                this.lblLocalTaxA.Text = "0.00";
                this.lblLocalTaxA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxA
                // 
                this.lblGovtTaxA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxA.Location = new System.Drawing.Point(700, 22);
                this.lblGovtTaxA.Name = "lblGovtTaxA";
                this.lblGovtTaxA.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxA.TabIndex = 116;
                this.lblGovtTaxA.Text = "0.00";
                this.lblGovtTaxA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label98
                // 
                this.label98.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label98.Location = new System.Drawing.Point(406, 40);
                this.label98.Name = "label98";
                this.label98.Size = new System.Drawing.Size(98, 14);
                this.label98.TabIndex = 115;
                this.label98.Text = "Total Net :";
                this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label98.Visible = false;
                // 
                // label99
                // 
                this.label99.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label99.Location = new System.Drawing.Point(612, 40);
                this.label99.Name = "label99";
                this.label99.Size = new System.Drawing.Size(89, 14);
                this.label99.TabIndex = 112;
                this.label99.Text = "Local Tax :";
                this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label100
                // 
                this.label100.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label100.Location = new System.Drawing.Point(612, 22);
                this.label100.Name = "label100";
                this.label100.Size = new System.Drawing.Size(89, 14);
                this.label100.TabIndex = 111;
                this.label100.Text = "Gov\'t Tax :";
                this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label101
                // 
                this.label101.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label101.Location = new System.Drawing.Point(406, 22);
                this.label101.Name = "label101";
                this.label101.Size = new System.Drawing.Size(98, 14);
                this.label101.TabIndex = 110;
                this.label101.Text = "Balance :";
                this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label102
                // 
                this.label102.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label102.Location = new System.Drawing.Point(26, 40);
                this.label102.Name = "label102";
                this.label102.Size = new System.Drawing.Size(62, 14);
                this.label102.TabIndex = 109;
                this.label102.Text = "Discounts :";
                this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label102.Visible = false;
                // 
                // label103
                // 
                this.label103.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label103.Location = new System.Drawing.Point(195, 94);
                this.label103.Name = "label103";
                this.label103.Size = new System.Drawing.Size(98, 14);
                this.label103.TabIndex = 104;
                this.label103.Text = "Others :";
                this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label104
                // 
                this.label104.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label104.Location = new System.Drawing.Point(26, 22);
                this.label104.Name = "label104";
                this.label104.Size = new System.Drawing.Size(62, 14);
                this.label104.TabIndex = 103;
                this.label104.Text = "Charges :";
                this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesA
                // 
                this.lblTotalChargesA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesA.Location = new System.Drawing.Point(87, 22);
                this.lblTotalChargesA.Name = "lblTotalChargesA";
                this.lblTotalChargesA.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesA.TabIndex = 103;
                this.lblTotalChargesA.Text = "0.00";
                this.lblTotalChargesA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountA
                // 
                this.lblTotalDiscountA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountA.Location = new System.Drawing.Point(87, 40);
                this.lblTotalDiscountA.Name = "lblTotalDiscountA";
                this.lblTotalDiscountA.Size = new System.Drawing.Size(82, 14);
                this.lblTotalDiscountA.TabIndex = 109;
                this.lblTotalDiscountA.Text = "0.00";
                this.lblTotalDiscountA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalDiscountA.Visible = false;
                // 
                // lblChargePaymentA
                // 
                this.lblChargePaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChargePaymentA.Location = new System.Drawing.Point(289, 40);
                this.lblChargePaymentA.Name = "lblChargePaymentA";
                this.lblChargePaymentA.Size = new System.Drawing.Size(82, 14);
                this.lblChargePaymentA.TabIndex = 108;
                this.lblChargePaymentA.Text = "0.00";
                this.lblChargePaymentA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentA
                // 
                this.lblGiftChequePaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentA.Location = new System.Drawing.Point(289, 76);
                this.lblGiftChequePaymentA.Name = "lblGiftChequePaymentA";
                this.lblGiftChequePaymentA.Size = new System.Drawing.Size(82, 14);
                this.lblGiftChequePaymentA.TabIndex = 105;
                this.lblGiftChequePaymentA.Text = "0.00";
                this.lblGiftChequePaymentA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentA
                // 
                this.lblCashPaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentA.Location = new System.Drawing.Point(289, 22);
                this.lblCashPaymentA.Name = "lblCashPaymentA";
                this.lblCashPaymentA.Size = new System.Drawing.Size(82, 14);
                this.lblCashPaymentA.TabIndex = 106;
                this.lblCashPaymentA.Text = "0.00";
                this.lblCashPaymentA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblBalanceForwardA
                // 
                this.lblBalanceForwardA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblBalanceForwardA.Location = new System.Drawing.Point(289, 94);
                this.lblBalanceForwardA.Name = "lblBalanceForwardA";
                this.lblBalanceForwardA.Size = new System.Drawing.Size(82, 14);
                this.lblBalanceForwardA.TabIndex = 108;
                this.lblBalanceForwardA.Text = "0.00";
                this.lblBalanceForwardA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalNetA
                // 
                this.lblTotalNetA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalNetA.Location = new System.Drawing.Point(505, 40);
                this.lblTotalNetA.Name = "lblTotalNetA";
                this.lblTotalNetA.Size = new System.Drawing.Size(82, 14);
                this.lblTotalNetA.TabIndex = 107;
                this.lblTotalNetA.Text = "0.00";
                this.lblTotalNetA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalNetA.Visible = false;
                // 
                // lblTotalBalanceA
                // 
                this.lblTotalBalanceA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalBalanceA.Location = new System.Drawing.Point(505, 22);
                this.lblTotalBalanceA.Name = "lblTotalBalanceA";
                this.lblTotalBalanceA.Size = new System.Drawing.Size(82, 14);
                this.lblTotalBalanceA.TabIndex = 106;
                this.lblTotalBalanceA.Text = "0.00";
                this.lblTotalBalanceA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lvwSubFolioA
                // 
                this.lvwSubFolioA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwSubFolioA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader85,
            this.columnHeader86,
            this.columnHeader87,
            this.columnHeader88,
            this.columnHeader89,
            this.columnHeader102,
            this.columnHeader103,
            this.columnHeader104,
            this.columnHeader105,
            this.columnHeader106,
            this.columnHeader107,
            this.columnHeader108,
            this.columnHeader109,
            this.columnHeader110,
            this.columnHeader111,
            this.columnHeader54});
                this.lvwSubFolioA.ContextMenuStrip = this.mnuPopUp;
                this.lvwSubFolioA.FullRowSelect = true;
                this.lvwSubFolioA.Location = new System.Drawing.Point(4, 5);
                this.lvwSubFolioA.Name = "lvwSubFolioA";
                this.lvwSubFolioA.Size = new System.Drawing.Size(796, 201);
                this.lvwSubFolioA.TabIndex = 137;
                this.lvwSubFolioA.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioA.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader85
                // 
                this.columnHeader85.Text = "Date";
                this.columnHeader85.Width = 55;
                // 
                // columnHeader86
                // 
                this.columnHeader86.Text = "Posting Date";
                this.columnHeader86.Width = 0;
                // 
                // columnHeader87
                // 
                this.columnHeader87.Text = "Code";
                this.columnHeader87.Width = 40;
                // 
                // columnHeader88
                // 
                this.columnHeader88.Text = "Memo";
                this.columnHeader88.Width = 139;
                // 
                // columnHeader89
                // 
                this.columnHeader89.Text = "Source";
                this.columnHeader89.Width = 72;
                // 
                // columnHeader102
                // 
                this.columnHeader102.Text = "Ref. No.";
                this.columnHeader102.Width = 75;
                // 
                // columnHeader103
                // 
                this.columnHeader103.Text = "Amount";
                this.columnHeader103.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader103.Width = 72;
                // 
                // columnHeader104
                // 
                this.columnHeader104.Text = "Tax";
                this.columnHeader104.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader104.Width = 59;
                // 
                // columnHeader105
                // 
                this.columnHeader105.Text = "Service Charge";
                this.columnHeader105.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader105.Width = 0;
                // 
                // columnHeader106
                // 
                this.columnHeader106.Text = "Gross Amt.";
                this.columnHeader106.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader106.Width = 70;
                // 
                // columnHeader107
                // 
                this.columnHeader107.Text = "Discount";
                this.columnHeader107.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader107.Width = 54;
                // 
                // columnHeader108
                // 
                this.columnHeader108.Text = "Net Amount";
                this.columnHeader108.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader108.Width = 70;
                // 
                // columnHeader109
                // 
                this.columnHeader109.Text = "Balance";
                this.columnHeader109.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader109.Width = 70;
                // 
                // columnHeader110
                // 
                this.columnHeader110.Text = "Staff";
                this.columnHeader110.Width = 46;
                // 
                // columnHeader111
                // 
                this.columnHeader111.Text = "Net Base Amount";
                this.columnHeader111.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader111.Width = 0;
                // 
                // columnHeader54
                // 
                this.columnHeader54.Text = "Transaction No";
                this.columnHeader54.Width = 0;
                // 
                // mnuPopUp
                // 
                this.mnuPopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertPayment,
            this.mnuInsertCharges,
            this.toolStripMenuItem2,
            this.mnuVoidTransaction,
            this.toolStripMenuItem1,
            this.mnuRefreshLedger,
            this.toolStripMenuItem3,
            this.mnuPrintFolio});
                this.mnuPopUp.Name = "mnuPopUp";
                this.mnuPopUp.Size = new System.Drawing.Size(164, 132);
                // 
                // mnuInsertPayment
                // 
                this.mnuInsertPayment.Name = "mnuInsertPayment";
                this.mnuInsertPayment.Size = new System.Drawing.Size(163, 22);
                this.mnuInsertPayment.Text = "Insert Payment";
                this.mnuInsertPayment.Click += new System.EventHandler(this.mnuInsertPayment_Click);
                // 
                // mnuInsertCharges
                // 
                this.mnuInsertCharges.Name = "mnuInsertCharges";
                this.mnuInsertCharges.Size = new System.Drawing.Size(163, 22);
                this.mnuInsertCharges.Text = "Insert Charge";
                this.mnuInsertCharges.Click += new System.EventHandler(this.mnuInsertCharges_Click);
                // 
                // toolStripMenuItem2
                // 
                this.toolStripMenuItem2.Name = "toolStripMenuItem2";
                this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
                // 
                // mnuVoidTransaction
                // 
                this.mnuVoidTransaction.Name = "mnuVoidTransaction";
                this.mnuVoidTransaction.Size = new System.Drawing.Size(163, 22);
                this.mnuVoidTransaction.Text = "Void Transaction";
                this.mnuVoidTransaction.Click += new System.EventHandler(this.mnuVoidTransaction_Click);
                // 
                // toolStripMenuItem1
                // 
                this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
                // 
                // mnuRefreshLedger
                // 
                this.mnuRefreshLedger.Name = "mnuRefreshLedger";
                this.mnuRefreshLedger.Size = new System.Drawing.Size(163, 22);
                this.mnuRefreshLedger.Text = "Refresh";
                this.mnuRefreshLedger.Click += new System.EventHandler(this.mnuRefreshLedger_Click);
                // 
                // toolStripMenuItem3
                // 
                this.toolStripMenuItem3.Name = "toolStripMenuItem3";
                this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
                // 
                // mnuPrintFolio
                // 
                this.mnuPrintFolio.Name = "mnuPrintFolio";
                this.mnuPrintFolio.Size = new System.Drawing.Size(163, 22);
                this.mnuPrintFolio.Text = "Print Folio";
                this.mnuPrintFolio.Click += new System.EventHandler(this.mnuPrintFolio_Click);
                // 
                // TabPage3
                // 
                this.TabPage3.Controls.Add(this.GroupBox4);
                this.TabPage3.Controls.Add(this.btnBrowseCompany);
                this.TabPage3.Controls.Add(this.txtCompanyName);
                this.TabPage3.Controls.Add(this.txtCompanyId);
                this.TabPage3.Controls.Add(this.lblCom);
                this.TabPage3.Controls.Add(this.lvwSubFolioB);
                this.TabPage3.Location = new System.Drawing.Point(4, 23);
                this.TabPage3.Name = "TabPage3";
                this.TabPage3.Size = new System.Drawing.Size(805, 323);
                this.TabPage3.TabIndex = 1;
                this.TabPage3.Text = "B (Company)";
                this.TabPage3.Visible = false;
                // 
                // GroupBox4
                // 
                this.GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.GroupBox4.Controls.Add(this.label5);
                this.GroupBox4.Controls.Add(this.label6);
                this.GroupBox4.Controls.Add(this.Label40);
                this.GroupBox4.Controls.Add(this.Label41);
                this.GroupBox4.Controls.Add(this.Label42);
                this.GroupBox4.Controls.Add(this.Label43);
                this.GroupBox4.Controls.Add(this.lblChequePaymentB);
                this.GroupBox4.Controls.Add(this.lblServiceChargeB);
                this.GroupBox4.Controls.Add(this.lblCommissionB);
                this.GroupBox4.Controls.Add(this.lblLocalTaxB);
                this.GroupBox4.Controls.Add(this.lblGovtTaxB);
                this.GroupBox4.Controls.Add(this.label8);
                this.GroupBox4.Controls.Add(this.Label36);
                this.GroupBox4.Controls.Add(this.Label37);
                this.GroupBox4.Controls.Add(this.Label38);
                this.GroupBox4.Controls.Add(this.Label39);
                this.GroupBox4.Controls.Add(this.Label44);
                this.GroupBox4.Controls.Add(this.Label45);
                this.GroupBox4.Controls.Add(this.lblTotalChargesB);
                this.GroupBox4.Controls.Add(this.lblTotalDiscountB);
                this.GroupBox4.Controls.Add(this.lblChargePaymentB);
                this.GroupBox4.Controls.Add(this.lblGiftChequePaymentB);
                this.GroupBox4.Controls.Add(this.lblCashPaymentB);
                this.GroupBox4.Controls.Add(this.lblBalanceForwardB);
                this.GroupBox4.Controls.Add(this.lblTotalNetB);
                this.GroupBox4.Controls.Add(this.lblTotalBalanceB);
                this.GroupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.GroupBox4.Location = new System.Drawing.Point(4, 206);
                this.GroupBox4.Name = "GroupBox4";
                this.GroupBox4.Size = new System.Drawing.Size(796, 113);
                this.GroupBox4.TabIndex = 140;
                this.GroupBox4.TabStop = false;
                this.GroupBox4.Text = "Sub-folio B Summary";
                // 
                // label5
                // 
                this.label5.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label5.Location = new System.Drawing.Point(612, 78);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(89, 14);
                this.label5.TabIndex = 114;
                this.label5.Text = "Commission :";
                this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label6
                // 
                this.label6.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label6.Location = new System.Drawing.Point(612, 60);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(89, 14);
                this.label6.TabIndex = 113;
                this.label6.Text = "Service Charge :";
                this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label40
                // 
                this.Label40.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label40.Location = new System.Drawing.Point(195, 41);
                this.Label40.Name = "Label40";
                this.Label40.Size = new System.Drawing.Size(94, 14);
                this.Label40.TabIndex = 108;
                this.Label40.Text = "Charge Payment :";
                this.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label41
                // 
                this.Label41.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label41.Location = new System.Drawing.Point(195, 59);
                this.Label41.Name = "Label41";
                this.Label41.Size = new System.Drawing.Size(94, 14);
                this.Label41.TabIndex = 107;
                this.Label41.Text = "Cheque Payment :";
                this.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label42
                // 
                this.Label42.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label42.Location = new System.Drawing.Point(195, 23);
                this.Label42.Name = "Label42";
                this.Label42.Size = new System.Drawing.Size(94, 14);
                this.Label42.TabIndex = 106;
                this.Label42.Text = "Cash Payment :";
                this.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label43
                // 
                this.Label43.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label43.Location = new System.Drawing.Point(195, 75);
                this.Label43.Name = "Label43";
                this.Label43.Size = new System.Drawing.Size(94, 14);
                this.Label43.TabIndex = 105;
                this.Label43.Text = "Gift Cheque :";
                this.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentB
                // 
                this.lblChequePaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentB.Location = new System.Drawing.Point(289, 59);
                this.lblChequePaymentB.Name = "lblChequePaymentB";
                this.lblChequePaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblChequePaymentB.TabIndex = 120;
                this.lblChequePaymentB.Text = "0.00";
                this.lblChequePaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblServiceChargeB
                // 
                this.lblServiceChargeB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblServiceChargeB.Location = new System.Drawing.Point(700, 60);
                this.lblServiceChargeB.Name = "lblServiceChargeB";
                this.lblServiceChargeB.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeB.TabIndex = 119;
                this.lblServiceChargeB.Text = "0.00";
                this.lblServiceChargeB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionB
                // 
                this.lblCommissionB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionB.Location = new System.Drawing.Point(700, 78);
                this.lblCommissionB.Name = "lblCommissionB";
                this.lblCommissionB.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionB.TabIndex = 118;
                this.lblCommissionB.Text = "0.00";
                this.lblCommissionB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxB
                // 
                this.lblLocalTaxB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxB.Location = new System.Drawing.Point(700, 41);
                this.lblLocalTaxB.Name = "lblLocalTaxB";
                this.lblLocalTaxB.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxB.TabIndex = 117;
                this.lblLocalTaxB.Text = "0.00";
                this.lblLocalTaxB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxB
                // 
                this.lblGovtTaxB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxB.Location = new System.Drawing.Point(700, 23);
                this.lblGovtTaxB.Name = "lblGovtTaxB";
                this.lblGovtTaxB.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxB.TabIndex = 116;
                this.lblGovtTaxB.Text = "0.00";
                this.lblGovtTaxB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label8
                // 
                this.label8.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label8.Location = new System.Drawing.Point(406, 41);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(98, 14);
                this.label8.TabIndex = 115;
                this.label8.Text = "Total Net :";
                this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label8.Visible = false;
                // 
                // Label36
                // 
                this.Label36.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label36.Location = new System.Drawing.Point(612, 41);
                this.Label36.Name = "Label36";
                this.Label36.Size = new System.Drawing.Size(89, 14);
                this.Label36.TabIndex = 112;
                this.Label36.Text = "Local Tax :";
                this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label37
                // 
                this.Label37.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label37.Location = new System.Drawing.Point(612, 23);
                this.Label37.Name = "Label37";
                this.Label37.Size = new System.Drawing.Size(89, 14);
                this.Label37.TabIndex = 111;
                this.Label37.Text = "Gov\'t Tax :";
                this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label38
                // 
                this.Label38.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label38.Location = new System.Drawing.Point(406, 23);
                this.Label38.Name = "Label38";
                this.Label38.Size = new System.Drawing.Size(98, 14);
                this.Label38.TabIndex = 110;
                this.Label38.Text = "Balance :";
                this.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label39
                // 
                this.Label39.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label39.Location = new System.Drawing.Point(26, 41);
                this.Label39.Name = "Label39";
                this.Label39.Size = new System.Drawing.Size(62, 14);
                this.Label39.TabIndex = 109;
                this.Label39.Text = "Discounts :";
                this.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label39.Visible = false;
                // 
                // Label44
                // 
                this.Label44.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label44.Location = new System.Drawing.Point(195, 92);
                this.Label44.Name = "Label44";
                this.Label44.Size = new System.Drawing.Size(98, 14);
                this.Label44.TabIndex = 104;
                this.Label44.Text = "Others :";
                this.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label45
                // 
                this.Label45.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label45.Location = new System.Drawing.Point(26, 23);
                this.Label45.Name = "Label45";
                this.Label45.Size = new System.Drawing.Size(62, 14);
                this.Label45.TabIndex = 103;
                this.Label45.Text = "Charges :";
                this.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesB
                // 
                this.lblTotalChargesB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesB.Location = new System.Drawing.Point(87, 23);
                this.lblTotalChargesB.Name = "lblTotalChargesB";
                this.lblTotalChargesB.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesB.TabIndex = 103;
                this.lblTotalChargesB.Text = "0.00";
                this.lblTotalChargesB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountB
                // 
                this.lblTotalDiscountB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountB.Location = new System.Drawing.Point(87, 41);
                this.lblTotalDiscountB.Name = "lblTotalDiscountB";
                this.lblTotalDiscountB.Size = new System.Drawing.Size(82, 14);
                this.lblTotalDiscountB.TabIndex = 109;
                this.lblTotalDiscountB.Text = "0.00";
                this.lblTotalDiscountB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalDiscountB.Visible = false;
                // 
                // lblChargePaymentB
                // 
                this.lblChargePaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChargePaymentB.Location = new System.Drawing.Point(289, 41);
                this.lblChargePaymentB.Name = "lblChargePaymentB";
                this.lblChargePaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblChargePaymentB.TabIndex = 108;
                this.lblChargePaymentB.Text = "0.00";
                this.lblChargePaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentB
                // 
                this.lblGiftChequePaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentB.Location = new System.Drawing.Point(289, 75);
                this.lblGiftChequePaymentB.Name = "lblGiftChequePaymentB";
                this.lblGiftChequePaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblGiftChequePaymentB.TabIndex = 105;
                this.lblGiftChequePaymentB.Text = "0.00";
                this.lblGiftChequePaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentB
                // 
                this.lblCashPaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentB.Location = new System.Drawing.Point(289, 23);
                this.lblCashPaymentB.Name = "lblCashPaymentB";
                this.lblCashPaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblCashPaymentB.TabIndex = 106;
                this.lblCashPaymentB.Text = "0.00";
                this.lblCashPaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblBalanceForwardB
                // 
                this.lblBalanceForwardB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblBalanceForwardB.Location = new System.Drawing.Point(289, 92);
                this.lblBalanceForwardB.Name = "lblBalanceForwardB";
                this.lblBalanceForwardB.Size = new System.Drawing.Size(82, 14);
                this.lblBalanceForwardB.TabIndex = 108;
                this.lblBalanceForwardB.Text = "0.00";
                this.lblBalanceForwardB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalNetB
                // 
                this.lblTotalNetB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalNetB.Location = new System.Drawing.Point(505, 41);
                this.lblTotalNetB.Name = "lblTotalNetB";
                this.lblTotalNetB.Size = new System.Drawing.Size(82, 14);
                this.lblTotalNetB.TabIndex = 107;
                this.lblTotalNetB.Text = "0.00";
                this.lblTotalNetB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalNetB.Visible = false;
                // 
                // lblTotalBalanceB
                // 
                this.lblTotalBalanceB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalBalanceB.Location = new System.Drawing.Point(505, 23);
                this.lblTotalBalanceB.Name = "lblTotalBalanceB";
                this.lblTotalBalanceB.Size = new System.Drawing.Size(82, 14);
                this.lblTotalBalanceB.TabIndex = 106;
                this.lblTotalBalanceB.Text = "0.00";
                this.lblTotalBalanceB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // btnBrowseCompany
                // 
                this.btnBrowseCompany.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnBrowseCompany.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnBrowseCompany.ImageIndex = 0;
                this.btnBrowseCompany.ImageList = this.imgIcon;
                this.btnBrowseCompany.Location = new System.Drawing.Point(220, 11);
                this.btnBrowseCompany.Name = "btnBrowseCompany";
                this.btnBrowseCompany.Size = new System.Drawing.Size(25, 24);
                this.btnBrowseCompany.TabIndex = 137;
                this.btnBrowseCompany.Click += new System.EventHandler(this.btnBrowseCompany_Click);
                // 
                // imgIcon
                // 
                this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
                this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
                this.imgIcon.Images.SetKeyName(0, "");
                // 
                // txtCompanyName
                // 
                this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtCompanyName.BackColor = System.Drawing.SystemColors.Control;
                this.txtCompanyName.Location = new System.Drawing.Point(251, 12);
                this.txtCompanyName.Name = "txtCompanyName";
                this.txtCompanyName.ReadOnly = true;
                this.txtCompanyName.Size = new System.Drawing.Size(549, 20);
                this.txtCompanyName.TabIndex = 136;
                // 
                // txtCompanyId
                // 
                this.txtCompanyId.BackColor = System.Drawing.SystemColors.Info;
                this.txtCompanyId.Location = new System.Drawing.Point(93, 12);
                this.txtCompanyId.Name = "txtCompanyId";
                this.txtCompanyId.ReadOnly = true;
                this.txtCompanyId.Size = new System.Drawing.Size(126, 20);
                this.txtCompanyId.TabIndex = 135;
                this.txtCompanyId.TextChanged += new System.EventHandler(this.txtCompanyId_TextChanged);
                // 
                // lblCom
                // 
                this.lblCom.Font = new System.Drawing.Font("Arial", 8.25F);
                this.lblCom.Location = new System.Drawing.Point(20, 15);
                this.lblCom.Name = "lblCom";
                this.lblCom.Size = new System.Drawing.Size(62, 15);
                this.lblCom.TabIndex = 114;
                this.lblCom.Text = "Company :";
                // 
                // lvwSubFolioB
                // 
                this.lvwSubFolioB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwSubFolioB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader81,
            this.columnHeader90,
            this.columnHeader94,
            this.columnHeader95,
            this.columnHeader112,
            this.columnHeader113,
            this.columnHeader55});
                this.lvwSubFolioB.ContextMenuStrip = this.mnuPopUp;
                this.lvwSubFolioB.FullRowSelect = true;
                this.lvwSubFolioB.Location = new System.Drawing.Point(4, 38);
                this.lvwSubFolioB.Name = "lvwSubFolioB";
                this.lvwSubFolioB.Size = new System.Drawing.Size(796, 164);
                this.lvwSubFolioB.TabIndex = 139;
                this.lvwSubFolioB.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioB.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader4
                // 
                this.columnHeader4.Text = "Date";
                this.columnHeader4.Width = 55;
                // 
                // columnHeader5
                // 
                this.columnHeader5.Text = "Posting Date";
                this.columnHeader5.Width = 0;
                // 
                // columnHeader6
                // 
                this.columnHeader6.Text = "Code";
                this.columnHeader6.Width = 40;
                // 
                // columnHeader48
                // 
                this.columnHeader48.Text = "Memo";
                this.columnHeader48.Width = 139;
                // 
                // columnHeader49
                // 
                this.columnHeader49.Text = "Source";
                this.columnHeader49.Width = 72;
                // 
                // columnHeader50
                // 
                this.columnHeader50.Text = "Ref. No.";
                this.columnHeader50.Width = 75;
                // 
                // columnHeader51
                // 
                this.columnHeader51.Text = "Amount";
                this.columnHeader51.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader51.Width = 72;
                // 
                // columnHeader52
                // 
                this.columnHeader52.Text = "Tax";
                this.columnHeader52.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader52.Width = 59;
                // 
                // columnHeader53
                // 
                this.columnHeader53.Text = "Service Charge";
                this.columnHeader53.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader53.Width = 0;
                // 
                // columnHeader81
                // 
                this.columnHeader81.Text = "Gross Amt.";
                this.columnHeader81.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader81.Width = 70;
                // 
                // columnHeader90
                // 
                this.columnHeader90.Text = "Discount";
                this.columnHeader90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader90.Width = 54;
                // 
                // columnHeader94
                // 
                this.columnHeader94.Text = "Net Amount";
                this.columnHeader94.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader94.Width = 70;
                // 
                // columnHeader95
                // 
                this.columnHeader95.Text = "Balance";
                this.columnHeader95.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader95.Width = 70;
                // 
                // columnHeader112
                // 
                this.columnHeader112.Text = "Staff";
                this.columnHeader112.Width = 46;
                // 
                // columnHeader113
                // 
                this.columnHeader113.Text = "Net Base Amount";
                this.columnHeader113.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader113.Width = 0;
                // 
                // columnHeader55
                // 
                this.columnHeader55.Text = "Transaction No";
                this.columnHeader55.Width = 0;
                // 
                // TabPage4
                // 
                this.TabPage4.Controls.Add(this.groupBox3);
                this.TabPage4.Controls.Add(this.lvwSubFolioC);
                this.TabPage4.Controls.Add(this.btnBrowseAccountC);
                this.TabPage4.Controls.Add(this.txtAccountNameC);
                this.TabPage4.Controls.Add(this.txtAccountIdC);
                this.TabPage4.Controls.Add(this.Label86);
                this.TabPage4.Location = new System.Drawing.Point(4, 23);
                this.TabPage4.Name = "TabPage4";
                this.TabPage4.Size = new System.Drawing.Size(805, 323);
                this.TabPage4.TabIndex = 2;
                this.TabPage4.Text = "C (Others)";
                this.TabPage4.Visible = false;
                // 
                // groupBox3
                // 
                this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox3.Controls.Add(this.label47);
                this.groupBox3.Controls.Add(this.label48);
                this.groupBox3.Controls.Add(this.label58);
                this.groupBox3.Controls.Add(this.label59);
                this.groupBox3.Controls.Add(this.label61);
                this.groupBox3.Controls.Add(this.label62);
                this.groupBox3.Controls.Add(this.lblChequePaymentC);
                this.groupBox3.Controls.Add(this.lblServiceChargeC);
                this.groupBox3.Controls.Add(this.lblCommissionC);
                this.groupBox3.Controls.Add(this.lblLocalTaxC);
                this.groupBox3.Controls.Add(this.lblGovtTaxC);
                this.groupBox3.Controls.Add(this.label63);
                this.groupBox3.Controls.Add(this.label64);
                this.groupBox3.Controls.Add(this.label65);
                this.groupBox3.Controls.Add(this.label66);
                this.groupBox3.Controls.Add(this.label67);
                this.groupBox3.Controls.Add(this.label68);
                this.groupBox3.Controls.Add(this.label69);
                this.groupBox3.Controls.Add(this.lblTotalChargesC);
                this.groupBox3.Controls.Add(this.lblTotalDiscountC);
                this.groupBox3.Controls.Add(this.lblChargePaymentC);
                this.groupBox3.Controls.Add(this.lblGiftChequePaymentC);
                this.groupBox3.Controls.Add(this.lblCashPaymentC);
                this.groupBox3.Controls.Add(this.lblBalanceForwardC);
                this.groupBox3.Controls.Add(this.lblTotalNetC);
                this.groupBox3.Controls.Add(this.lblTotalBalanceC);
                this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.groupBox3.Location = new System.Drawing.Point(4, 206);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(796, 113);
                this.groupBox3.TabIndex = 141;
                this.groupBox3.TabStop = false;
                this.groupBox3.Text = "Sub-folio C Summary";
                // 
                // label47
                // 
                this.label47.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label47.Location = new System.Drawing.Point(612, 78);
                this.label47.Name = "label47";
                this.label47.Size = new System.Drawing.Size(89, 14);
                this.label47.TabIndex = 114;
                this.label47.Text = "Commission :";
                this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label48
                // 
                this.label48.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label48.Location = new System.Drawing.Point(612, 60);
                this.label48.Name = "label48";
                this.label48.Size = new System.Drawing.Size(89, 14);
                this.label48.TabIndex = 113;
                this.label48.Text = "Service Charge :";
                this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label58
                // 
                this.label58.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label58.Location = new System.Drawing.Point(195, 41);
                this.label58.Name = "label58";
                this.label58.Size = new System.Drawing.Size(94, 14);
                this.label58.TabIndex = 108;
                this.label58.Text = "Charge Payment :";
                this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label59
                // 
                this.label59.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label59.Location = new System.Drawing.Point(195, 59);
                this.label59.Name = "label59";
                this.label59.Size = new System.Drawing.Size(94, 14);
                this.label59.TabIndex = 107;
                this.label59.Text = "Cheque Payment :";
                this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label61
                // 
                this.label61.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label61.Location = new System.Drawing.Point(195, 23);
                this.label61.Name = "label61";
                this.label61.Size = new System.Drawing.Size(94, 14);
                this.label61.TabIndex = 106;
                this.label61.Text = "Cash Payment :";
                this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label62
                // 
                this.label62.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label62.Location = new System.Drawing.Point(195, 77);
                this.label62.Name = "label62";
                this.label62.Size = new System.Drawing.Size(94, 14);
                this.label62.TabIndex = 105;
                this.label62.Text = "Gift Cheque :";
                this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentC
                // 
                this.lblChequePaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentC.Location = new System.Drawing.Point(289, 59);
                this.lblChequePaymentC.Name = "lblChequePaymentC";
                this.lblChequePaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblChequePaymentC.TabIndex = 120;
                this.lblChequePaymentC.Text = "0.00";
                this.lblChequePaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblServiceChargeC
                // 
                this.lblServiceChargeC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblServiceChargeC.Location = new System.Drawing.Point(700, 60);
                this.lblServiceChargeC.Name = "lblServiceChargeC";
                this.lblServiceChargeC.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeC.TabIndex = 119;
                this.lblServiceChargeC.Text = "0.00";
                this.lblServiceChargeC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionC
                // 
                this.lblCommissionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionC.Location = new System.Drawing.Point(700, 78);
                this.lblCommissionC.Name = "lblCommissionC";
                this.lblCommissionC.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionC.TabIndex = 118;
                this.lblCommissionC.Text = "0.00";
                this.lblCommissionC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxC
                // 
                this.lblLocalTaxC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxC.Location = new System.Drawing.Point(700, 41);
                this.lblLocalTaxC.Name = "lblLocalTaxC";
                this.lblLocalTaxC.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxC.TabIndex = 117;
                this.lblLocalTaxC.Text = "0.00";
                this.lblLocalTaxC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxC
                // 
                this.lblGovtTaxC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxC.Location = new System.Drawing.Point(700, 23);
                this.lblGovtTaxC.Name = "lblGovtTaxC";
                this.lblGovtTaxC.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxC.TabIndex = 116;
                this.lblGovtTaxC.Text = "0.00";
                this.lblGovtTaxC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label63
                // 
                this.label63.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label63.Location = new System.Drawing.Point(406, 41);
                this.label63.Name = "label63";
                this.label63.Size = new System.Drawing.Size(98, 14);
                this.label63.TabIndex = 115;
                this.label63.Text = "Total Net :";
                this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label63.Visible = false;
                // 
                // label64
                // 
                this.label64.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label64.Location = new System.Drawing.Point(612, 41);
                this.label64.Name = "label64";
                this.label64.Size = new System.Drawing.Size(89, 14);
                this.label64.TabIndex = 112;
                this.label64.Text = "Local Tax :";
                this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label65
                // 
                this.label65.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label65.Location = new System.Drawing.Point(612, 23);
                this.label65.Name = "label65";
                this.label65.Size = new System.Drawing.Size(89, 14);
                this.label65.TabIndex = 111;
                this.label65.Text = "Gov\'t Tax :";
                this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label66
                // 
                this.label66.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label66.Location = new System.Drawing.Point(406, 23);
                this.label66.Name = "label66";
                this.label66.Size = new System.Drawing.Size(98, 14);
                this.label66.TabIndex = 110;
                this.label66.Text = "Balance :";
                this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label67
                // 
                this.label67.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label67.Location = new System.Drawing.Point(26, 41);
                this.label67.Name = "label67";
                this.label67.Size = new System.Drawing.Size(62, 14);
                this.label67.TabIndex = 109;
                this.label67.Text = "Discounts :";
                this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label67.Visible = false;
                // 
                // label68
                // 
                this.label68.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label68.Location = new System.Drawing.Point(195, 93);
                this.label68.Name = "label68";
                this.label68.Size = new System.Drawing.Size(98, 14);
                this.label68.TabIndex = 104;
                this.label68.Text = "Others :";
                this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label69
                // 
                this.label69.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label69.Location = new System.Drawing.Point(26, 23);
                this.label69.Name = "label69";
                this.label69.Size = new System.Drawing.Size(62, 14);
                this.label69.TabIndex = 103;
                this.label69.Text = "Charges :";
                this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesC
                // 
                this.lblTotalChargesC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesC.Location = new System.Drawing.Point(87, 23);
                this.lblTotalChargesC.Name = "lblTotalChargesC";
                this.lblTotalChargesC.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesC.TabIndex = 103;
                this.lblTotalChargesC.Text = "0.00";
                this.lblTotalChargesC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountC
                // 
                this.lblTotalDiscountC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountC.Location = new System.Drawing.Point(87, 41);
                this.lblTotalDiscountC.Name = "lblTotalDiscountC";
                this.lblTotalDiscountC.Size = new System.Drawing.Size(82, 14);
                this.lblTotalDiscountC.TabIndex = 109;
                this.lblTotalDiscountC.Text = "0.00";
                this.lblTotalDiscountC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalDiscountC.Visible = false;
                // 
                // lblChargePaymentC
                // 
                this.lblChargePaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChargePaymentC.Location = new System.Drawing.Point(289, 41);
                this.lblChargePaymentC.Name = "lblChargePaymentC";
                this.lblChargePaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblChargePaymentC.TabIndex = 108;
                this.lblChargePaymentC.Text = "0.00";
                this.lblChargePaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentC
                // 
                this.lblGiftChequePaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentC.Location = new System.Drawing.Point(289, 77);
                this.lblGiftChequePaymentC.Name = "lblGiftChequePaymentC";
                this.lblGiftChequePaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblGiftChequePaymentC.TabIndex = 105;
                this.lblGiftChequePaymentC.Text = "0.00";
                this.lblGiftChequePaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentC
                // 
                this.lblCashPaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentC.Location = new System.Drawing.Point(289, 23);
                this.lblCashPaymentC.Name = "lblCashPaymentC";
                this.lblCashPaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblCashPaymentC.TabIndex = 106;
                this.lblCashPaymentC.Text = "0.00";
                this.lblCashPaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblBalanceForwardC
                // 
                this.lblBalanceForwardC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblBalanceForwardC.Location = new System.Drawing.Point(289, 93);
                this.lblBalanceForwardC.Name = "lblBalanceForwardC";
                this.lblBalanceForwardC.Size = new System.Drawing.Size(82, 14);
                this.lblBalanceForwardC.TabIndex = 108;
                this.lblBalanceForwardC.Text = "0.00";
                this.lblBalanceForwardC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalNetC
                // 
                this.lblTotalNetC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalNetC.Location = new System.Drawing.Point(505, 41);
                this.lblTotalNetC.Name = "lblTotalNetC";
                this.lblTotalNetC.Size = new System.Drawing.Size(82, 14);
                this.lblTotalNetC.TabIndex = 107;
                this.lblTotalNetC.Text = "0.00";
                this.lblTotalNetC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalNetC.Visible = false;
                // 
                // lblTotalBalanceC
                // 
                this.lblTotalBalanceC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalBalanceC.Location = new System.Drawing.Point(505, 23);
                this.lblTotalBalanceC.Name = "lblTotalBalanceC";
                this.lblTotalBalanceC.Size = new System.Drawing.Size(82, 14);
                this.lblTotalBalanceC.TabIndex = 106;
                this.lblTotalBalanceC.Text = "0.00";
                this.lblTotalBalanceC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lvwSubFolioC
                // 
                this.lvwSubFolioC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwSubFolioC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader63,
            this.columnHeader64,
            this.columnHeader65,
            this.columnHeader66,
            this.columnHeader67,
            this.columnHeader68,
            this.columnHeader69,
            this.columnHeader70,
            this.columnHeader71,
            this.columnHeader72,
            this.columnHeader73,
            this.columnHeader74,
            this.columnHeader75,
            this.columnHeader76});
                this.lvwSubFolioC.ContextMenuStrip = this.mnuPopUp;
                this.lvwSubFolioC.FullRowSelect = true;
                this.lvwSubFolioC.Location = new System.Drawing.Point(4, 39);
                this.lvwSubFolioC.Name = "lvwSubFolioC";
                this.lvwSubFolioC.Size = new System.Drawing.Size(796, 164);
                this.lvwSubFolioC.TabIndex = 140;
                this.lvwSubFolioC.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioC.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader56
                // 
                this.columnHeader56.Text = "Date";
                this.columnHeader56.Width = 55;
                // 
                // columnHeader57
                // 
                this.columnHeader57.Text = "Posting Date";
                this.columnHeader57.Width = 0;
                // 
                // columnHeader63
                // 
                this.columnHeader63.Text = "Code";
                this.columnHeader63.Width = 40;
                // 
                // columnHeader64
                // 
                this.columnHeader64.Text = "Memo";
                this.columnHeader64.Width = 139;
                // 
                // columnHeader65
                // 
                this.columnHeader65.Text = "Source";
                this.columnHeader65.Width = 72;
                // 
                // columnHeader66
                // 
                this.columnHeader66.Text = "Ref. No.";
                this.columnHeader66.Width = 75;
                // 
                // columnHeader67
                // 
                this.columnHeader67.Text = "Amount";
                this.columnHeader67.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader67.Width = 72;
                // 
                // columnHeader68
                // 
                this.columnHeader68.Text = "Tax";
                this.columnHeader68.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader68.Width = 59;
                // 
                // columnHeader69
                // 
                this.columnHeader69.Text = "Service Charge";
                this.columnHeader69.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader69.Width = 0;
                // 
                // columnHeader70
                // 
                this.columnHeader70.Text = "Gross Amt.";
                this.columnHeader70.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader70.Width = 70;
                // 
                // columnHeader71
                // 
                this.columnHeader71.Text = "Discount";
                this.columnHeader71.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader71.Width = 54;
                // 
                // columnHeader72
                // 
                this.columnHeader72.Text = "Net Amount";
                this.columnHeader72.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader72.Width = 70;
                // 
                // columnHeader73
                // 
                this.columnHeader73.Text = "Balance";
                this.columnHeader73.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader73.Width = 70;
                // 
                // columnHeader74
                // 
                this.columnHeader74.Text = "Staff";
                this.columnHeader74.Width = 46;
                // 
                // columnHeader75
                // 
                this.columnHeader75.Text = "Net Base Amount";
                this.columnHeader75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader75.Width = 0;
                // 
                // columnHeader76
                // 
                this.columnHeader76.Text = "Transaction No";
                this.columnHeader76.Width = 0;
                // 
                // btnBrowseAccountC
                // 
                this.btnBrowseAccountC.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnBrowseAccountC.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnBrowseAccountC.ImageIndex = 0;
                this.btnBrowseAccountC.ImageList = this.imgIcon;
                this.btnBrowseAccountC.Location = new System.Drawing.Point(220, 11);
                this.btnBrowseAccountC.Name = "btnBrowseAccountC";
                this.btnBrowseAccountC.Size = new System.Drawing.Size(25, 24);
                this.btnBrowseAccountC.TabIndex = 134;
                this.btnBrowseAccountC.Click += new System.EventHandler(this.btnBrowseAccountC_Click);
                // 
                // txtAccountNameC
                // 
                this.txtAccountNameC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtAccountNameC.Location = new System.Drawing.Point(251, 12);
                this.txtAccountNameC.Name = "txtAccountNameC";
                this.txtAccountNameC.ReadOnly = true;
                this.txtAccountNameC.Size = new System.Drawing.Size(549, 20);
                this.txtAccountNameC.TabIndex = 115;
                // 
                // txtAccountIdC
                // 
                this.txtAccountIdC.BackColor = System.Drawing.SystemColors.Info;
                this.txtAccountIdC.Location = new System.Drawing.Point(93, 12);
                this.txtAccountIdC.Name = "txtAccountIdC";
                this.txtAccountIdC.ReadOnly = true;
                this.txtAccountIdC.Size = new System.Drawing.Size(126, 20);
                this.txtAccountIdC.TabIndex = 114;
                // 
                // Label86
                // 
                this.Label86.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label86.Location = new System.Drawing.Point(20, 15);
                this.Label86.Name = "Label86";
                this.Label86.Size = new System.Drawing.Size(85, 14);
                this.Label86.TabIndex = 112;
                this.Label86.Text = "Account :";
                // 
                // TabPage5
                // 
                this.TabPage5.Controls.Add(this.groupBox5);
                this.TabPage5.Controls.Add(this.lvwSubFolioD);
                this.TabPage5.Controls.Add(this.btnBrowseAccountD);
                this.TabPage5.Controls.Add(this.txtAccountNameD);
                this.TabPage5.Controls.Add(this.txtAccountIdD);
                this.TabPage5.Controls.Add(this.Label87);
                this.TabPage5.Location = new System.Drawing.Point(4, 23);
                this.TabPage5.Name = "TabPage5";
                this.TabPage5.Size = new System.Drawing.Size(805, 323);
                this.TabPage5.TabIndex = 3;
                this.TabPage5.Text = "D (Others)";
                this.TabPage5.Visible = false;
                // 
                // groupBox5
                // 
                this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox5.Controls.Add(this.label72);
                this.groupBox5.Controls.Add(this.label73);
                this.groupBox5.Controls.Add(this.label74);
                this.groupBox5.Controls.Add(this.label75);
                this.groupBox5.Controls.Add(this.label76);
                this.groupBox5.Controls.Add(this.label77);
                this.groupBox5.Controls.Add(this.lblChequePaymentD);
                this.groupBox5.Controls.Add(this.lblServiceChargeD);
                this.groupBox5.Controls.Add(this.lblCommissionD);
                this.groupBox5.Controls.Add(this.lblLocalTaxD);
                this.groupBox5.Controls.Add(this.lblGovtTaxD);
                this.groupBox5.Controls.Add(this.label78);
                this.groupBox5.Controls.Add(this.label79);
                this.groupBox5.Controls.Add(this.label80);
                this.groupBox5.Controls.Add(this.label81);
                this.groupBox5.Controls.Add(this.label82);
                this.groupBox5.Controls.Add(this.label83);
                this.groupBox5.Controls.Add(this.label84);
                this.groupBox5.Controls.Add(this.lblTotalChargesD);
                this.groupBox5.Controls.Add(this.lblTotalDiscountD);
                this.groupBox5.Controls.Add(this.lblChargePaymentD);
                this.groupBox5.Controls.Add(this.lblGiftChequePaymentD);
                this.groupBox5.Controls.Add(this.lblCashPaymentD);
                this.groupBox5.Controls.Add(this.lblBalanceForwardD);
                this.groupBox5.Controls.Add(this.lblTotalNetD);
                this.groupBox5.Controls.Add(this.lblTotalBalanceD);
                this.groupBox5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.groupBox5.Location = new System.Drawing.Point(4, 206);
                this.groupBox5.Name = "groupBox5";
                this.groupBox5.Size = new System.Drawing.Size(796, 113);
                this.groupBox5.TabIndex = 141;
                this.groupBox5.TabStop = false;
                this.groupBox5.Text = "Sub-folio D Summary";
                // 
                // label72
                // 
                this.label72.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label72.Location = new System.Drawing.Point(612, 78);
                this.label72.Name = "label72";
                this.label72.Size = new System.Drawing.Size(89, 14);
                this.label72.TabIndex = 114;
                this.label72.Text = "Commission :";
                this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label73
                // 
                this.label73.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label73.Location = new System.Drawing.Point(612, 60);
                this.label73.Name = "label73";
                this.label73.Size = new System.Drawing.Size(89, 14);
                this.label73.TabIndex = 113;
                this.label73.Text = "Service Charge :";
                this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label74
                // 
                this.label74.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label74.Location = new System.Drawing.Point(195, 41);
                this.label74.Name = "label74";
                this.label74.Size = new System.Drawing.Size(94, 14);
                this.label74.TabIndex = 108;
                this.label74.Text = "Charge Payment :";
                this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label75
                // 
                this.label75.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label75.Location = new System.Drawing.Point(195, 58);
                this.label75.Name = "label75";
                this.label75.Size = new System.Drawing.Size(94, 14);
                this.label75.TabIndex = 107;
                this.label75.Text = "Cheque Payment :";
                this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label76
                // 
                this.label76.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label76.Location = new System.Drawing.Point(195, 23);
                this.label76.Name = "label76";
                this.label76.Size = new System.Drawing.Size(94, 14);
                this.label76.TabIndex = 106;
                this.label76.Text = "Cash Payment :";
                this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label77
                // 
                this.label77.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label77.Location = new System.Drawing.Point(195, 76);
                this.label77.Name = "label77";
                this.label77.Size = new System.Drawing.Size(94, 14);
                this.label77.TabIndex = 105;
                this.label77.Text = "Gift Cheque :";
                this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentD
                // 
                this.lblChequePaymentD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentD.Location = new System.Drawing.Point(289, 58);
                this.lblChequePaymentD.Name = "lblChequePaymentD";
                this.lblChequePaymentD.Size = new System.Drawing.Size(82, 14);
                this.lblChequePaymentD.TabIndex = 120;
                this.lblChequePaymentD.Text = "0.00";
                this.lblChequePaymentD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblServiceChargeD
                // 
                this.lblServiceChargeD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblServiceChargeD.Location = new System.Drawing.Point(700, 60);
                this.lblServiceChargeD.Name = "lblServiceChargeD";
                this.lblServiceChargeD.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeD.TabIndex = 119;
                this.lblServiceChargeD.Text = "0.00";
                this.lblServiceChargeD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionD
                // 
                this.lblCommissionD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionD.Location = new System.Drawing.Point(700, 78);
                this.lblCommissionD.Name = "lblCommissionD";
                this.lblCommissionD.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionD.TabIndex = 118;
                this.lblCommissionD.Text = "0.00";
                this.lblCommissionD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxD
                // 
                this.lblLocalTaxD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxD.Location = new System.Drawing.Point(700, 41);
                this.lblLocalTaxD.Name = "lblLocalTaxD";
                this.lblLocalTaxD.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxD.TabIndex = 117;
                this.lblLocalTaxD.Text = "0.00";
                this.lblLocalTaxD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxD
                // 
                this.lblGovtTaxD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxD.Location = new System.Drawing.Point(700, 23);
                this.lblGovtTaxD.Name = "lblGovtTaxD";
                this.lblGovtTaxD.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxD.TabIndex = 116;
                this.lblGovtTaxD.Text = "0.00";
                this.lblGovtTaxD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label78
                // 
                this.label78.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label78.Location = new System.Drawing.Point(406, 41);
                this.label78.Name = "label78";
                this.label78.Size = new System.Drawing.Size(98, 14);
                this.label78.TabIndex = 115;
                this.label78.Text = "Total Net :";
                this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label78.Visible = false;
                // 
                // label79
                // 
                this.label79.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label79.Location = new System.Drawing.Point(612, 41);
                this.label79.Name = "label79";
                this.label79.Size = new System.Drawing.Size(89, 14);
                this.label79.TabIndex = 112;
                this.label79.Text = "Local Tax :";
                this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label80
                // 
                this.label80.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label80.Location = new System.Drawing.Point(612, 23);
                this.label80.Name = "label80";
                this.label80.Size = new System.Drawing.Size(89, 14);
                this.label80.TabIndex = 111;
                this.label80.Text = "Gov\'t Tax :";
                this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label81
                // 
                this.label81.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label81.Location = new System.Drawing.Point(406, 23);
                this.label81.Name = "label81";
                this.label81.Size = new System.Drawing.Size(98, 14);
                this.label81.TabIndex = 110;
                this.label81.Text = "Balance :";
                this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label82
                // 
                this.label82.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label82.Location = new System.Drawing.Point(26, 41);
                this.label82.Name = "label82";
                this.label82.Size = new System.Drawing.Size(62, 14);
                this.label82.TabIndex = 109;
                this.label82.Text = "Discounts :";
                this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label82.Visible = false;
                // 
                // label83
                // 
                this.label83.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label83.Location = new System.Drawing.Point(195, 94);
                this.label83.Name = "label83";
                this.label83.Size = new System.Drawing.Size(98, 14);
                this.label83.TabIndex = 104;
                this.label83.Text = "Others :";
                this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label84
                // 
                this.label84.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label84.Location = new System.Drawing.Point(26, 23);
                this.label84.Name = "label84";
                this.label84.Size = new System.Drawing.Size(62, 14);
                this.label84.TabIndex = 103;
                this.label84.Text = "Charges :";
                this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesD
                // 
                this.lblTotalChargesD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesD.Location = new System.Drawing.Point(87, 23);
                this.lblTotalChargesD.Name = "lblTotalChargesD";
                this.lblTotalChargesD.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesD.TabIndex = 103;
                this.lblTotalChargesD.Text = "0.00";
                this.lblTotalChargesD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountD
                // 
                this.lblTotalDiscountD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountD.Location = new System.Drawing.Point(87, 41);
                this.lblTotalDiscountD.Name = "lblTotalDiscountD";
                this.lblTotalDiscountD.Size = new System.Drawing.Size(82, 14);
                this.lblTotalDiscountD.TabIndex = 109;
                this.lblTotalDiscountD.Text = "0.00";
                this.lblTotalDiscountD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalDiscountD.Visible = false;
                // 
                // lblChargePaymentD
                // 
                this.lblChargePaymentD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChargePaymentD.Location = new System.Drawing.Point(289, 41);
                this.lblChargePaymentD.Name = "lblChargePaymentD";
                this.lblChargePaymentD.Size = new System.Drawing.Size(82, 14);
                this.lblChargePaymentD.TabIndex = 108;
                this.lblChargePaymentD.Text = "0.00";
                this.lblChargePaymentD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentD
                // 
                this.lblGiftChequePaymentD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentD.Location = new System.Drawing.Point(289, 76);
                this.lblGiftChequePaymentD.Name = "lblGiftChequePaymentD";
                this.lblGiftChequePaymentD.Size = new System.Drawing.Size(82, 14);
                this.lblGiftChequePaymentD.TabIndex = 105;
                this.lblGiftChequePaymentD.Text = "0.00";
                this.lblGiftChequePaymentD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentD
                // 
                this.lblCashPaymentD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentD.Location = new System.Drawing.Point(289, 23);
                this.lblCashPaymentD.Name = "lblCashPaymentD";
                this.lblCashPaymentD.Size = new System.Drawing.Size(82, 14);
                this.lblCashPaymentD.TabIndex = 106;
                this.lblCashPaymentD.Text = "0.00";
                this.lblCashPaymentD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblBalanceForwardD
                // 
                this.lblBalanceForwardD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblBalanceForwardD.Location = new System.Drawing.Point(289, 94);
                this.lblBalanceForwardD.Name = "lblBalanceForwardD";
                this.lblBalanceForwardD.Size = new System.Drawing.Size(82, 14);
                this.lblBalanceForwardD.TabIndex = 108;
                this.lblBalanceForwardD.Text = "0.00";
                this.lblBalanceForwardD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalNetD
                // 
                this.lblTotalNetD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalNetD.Location = new System.Drawing.Point(505, 41);
                this.lblTotalNetD.Name = "lblTotalNetD";
                this.lblTotalNetD.Size = new System.Drawing.Size(82, 14);
                this.lblTotalNetD.TabIndex = 107;
                this.lblTotalNetD.Text = "0.00";
                this.lblTotalNetD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblTotalNetD.Visible = false;
                // 
                // lblTotalBalanceD
                // 
                this.lblTotalBalanceD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalBalanceD.Location = new System.Drawing.Point(505, 23);
                this.lblTotalBalanceD.Name = "lblTotalBalanceD";
                this.lblTotalBalanceD.Size = new System.Drawing.Size(82, 14);
                this.lblTotalBalanceD.TabIndex = 106;
                this.lblTotalBalanceD.Text = "0.00";
                this.lblTotalBalanceD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lvwSubFolioD
                // 
                this.lvwSubFolioD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwSubFolioD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader77,
            this.columnHeader78,
            this.columnHeader79,
            this.columnHeader80,
            this.columnHeader83,
            this.columnHeader84,
            this.columnHeader92,
            this.columnHeader93,
            this.columnHeader98,
            this.columnHeader99,
            this.columnHeader100,
            this.columnHeader101,
            this.columnHeader121,
            this.columnHeader122,
            this.columnHeader123,
            this.columnHeader124});
                this.lvwSubFolioD.ContextMenuStrip = this.mnuPopUp;
                this.lvwSubFolioD.FullRowSelect = true;
                this.lvwSubFolioD.Location = new System.Drawing.Point(4, 39);
                this.lvwSubFolioD.Name = "lvwSubFolioD";
                this.lvwSubFolioD.Size = new System.Drawing.Size(796, 164);
                this.lvwSubFolioD.TabIndex = 140;
                this.lvwSubFolioD.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioD.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader77
                // 
                this.columnHeader77.Text = "Date";
                this.columnHeader77.Width = 55;
                // 
                // columnHeader78
                // 
                this.columnHeader78.Text = "Posting Date";
                this.columnHeader78.Width = 0;
                // 
                // columnHeader79
                // 
                this.columnHeader79.Text = "Code";
                this.columnHeader79.Width = 40;
                // 
                // columnHeader80
                // 
                this.columnHeader80.Text = "Memo";
                this.columnHeader80.Width = 139;
                // 
                // columnHeader83
                // 
                this.columnHeader83.Text = "Source";
                this.columnHeader83.Width = 72;
                // 
                // columnHeader84
                // 
                this.columnHeader84.Text = "Ref. No.";
                this.columnHeader84.Width = 75;
                // 
                // columnHeader92
                // 
                this.columnHeader92.Text = "Amount";
                this.columnHeader92.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader92.Width = 72;
                // 
                // columnHeader93
                // 
                this.columnHeader93.Text = "Tax";
                this.columnHeader93.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader93.Width = 59;
                // 
                // columnHeader98
                // 
                this.columnHeader98.Text = "Service Charge";
                this.columnHeader98.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader98.Width = 0;
                // 
                // columnHeader99
                // 
                this.columnHeader99.Text = "Gross Amt.";
                this.columnHeader99.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader99.Width = 70;
                // 
                // columnHeader100
                // 
                this.columnHeader100.Text = "Discount";
                this.columnHeader100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader100.Width = 54;
                // 
                // columnHeader101
                // 
                this.columnHeader101.Text = "Net Amount";
                this.columnHeader101.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader101.Width = 70;
                // 
                // columnHeader121
                // 
                this.columnHeader121.Text = "Balance";
                this.columnHeader121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader121.Width = 70;
                // 
                // columnHeader122
                // 
                this.columnHeader122.Text = "Staff";
                this.columnHeader122.Width = 46;
                // 
                // columnHeader123
                // 
                this.columnHeader123.Text = "Net Base Amount";
                this.columnHeader123.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader123.Width = 0;
                // 
                // columnHeader124
                // 
                this.columnHeader124.Text = "Transaction No";
                this.columnHeader124.Width = 0;
                // 
                // btnBrowseAccountD
                // 
                this.btnBrowseAccountD.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnBrowseAccountD.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnBrowseAccountD.ImageIndex = 0;
                this.btnBrowseAccountD.ImageList = this.imgIcon;
                this.btnBrowseAccountD.Location = new System.Drawing.Point(220, 11);
                this.btnBrowseAccountD.Name = "btnBrowseAccountD";
                this.btnBrowseAccountD.Size = new System.Drawing.Size(25, 24);
                this.btnBrowseAccountD.TabIndex = 134;
                this.btnBrowseAccountD.Click += new System.EventHandler(this.btnBrowseAccountD_Click);
                // 
                // txtAccountNameD
                // 
                this.txtAccountNameD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtAccountNameD.Location = new System.Drawing.Point(251, 12);
                this.txtAccountNameD.Name = "txtAccountNameD";
                this.txtAccountNameD.ReadOnly = true;
                this.txtAccountNameD.Size = new System.Drawing.Size(549, 20);
                this.txtAccountNameD.TabIndex = 126;
                // 
                // txtAccountIdD
                // 
                this.txtAccountIdD.BackColor = System.Drawing.SystemColors.Info;
                this.txtAccountIdD.Location = new System.Drawing.Point(93, 12);
                this.txtAccountIdD.Name = "txtAccountIdD";
                this.txtAccountIdD.ReadOnly = true;
                this.txtAccountIdD.Size = new System.Drawing.Size(126, 20);
                this.txtAccountIdD.TabIndex = 125;
                // 
                // Label87
                // 
                this.Label87.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label87.Location = new System.Drawing.Point(20, 15);
                this.Label87.Name = "Label87";
                this.Label87.Size = new System.Drawing.Size(85, 14);
                this.Label87.TabIndex = 124;
                this.Label87.Text = "Account :";
                // 
                // GroupBox7
                // 
                this.GroupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.GroupBox7.Controls.Add(this.txtPayment_Mode);
                this.GroupBox7.Controls.Add(this.label110);
                this.GroupBox7.Controls.Add(this.txtAccount_Type);
                this.GroupBox7.Controls.Add(this.label111);
                this.GroupBox7.Controls.Add(this.txtRoomID);
                this.GroupBox7.Controls.Add(this.txtGuestName);
                this.GroupBox7.Controls.Add(this.txtFolioId);
                this.GroupBox7.Controls.Add(this.txtBalance);
                this.GroupBox7.Controls.Add(this.label46);
                this.GroupBox7.Controls.Add(this.txtTotalPayment);
                this.GroupBox7.Controls.Add(this.txtTotalCharges);
                this.GroupBox7.Controls.Add(this.label70);
                this.GroupBox7.Controls.Add(this.label71);
                this.GroupBox7.Controls.Add(this.txtDepartureDate);
                this.GroupBox7.Controls.Add(this.txtArrivalDate);
                this.GroupBox7.Controls.Add(this.label85);
                this.GroupBox7.Controls.Add(this.label89);
                this.GroupBox7.Controls.Add(this.label90);
                this.GroupBox7.Controls.Add(this.Label118);
                this.GroupBox7.Controls.Add(this.label91);
                this.GroupBox7.Controls.Add(this.txtRemarks);
                this.GroupBox7.Controls.Add(this.Label88);
                this.GroupBox7.Location = new System.Drawing.Point(6, 4);
                this.GroupBox7.Name = "GroupBox7";
                this.GroupBox7.Size = new System.Drawing.Size(813, 162);
                this.GroupBox7.TabIndex = 102;
                this.GroupBox7.TabStop = false;
                // 
                // txtPayment_Mode
                // 
                this.txtPayment_Mode.BackColor = System.Drawing.SystemColors.Control;
                this.txtPayment_Mode.Location = new System.Drawing.Point(320, 43);
                this.txtPayment_Mode.Name = "txtPayment_Mode";
                this.txtPayment_Mode.ReadOnly = true;
                this.txtPayment_Mode.Size = new System.Drawing.Size(99, 20);
                this.txtPayment_Mode.TabIndex = 148;
                // 
                // label110
                // 
                this.label110.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label110.Location = new System.Drawing.Point(227, 46);
                this.label110.Name = "label110";
                this.label110.Size = new System.Drawing.Size(96, 15);
                this.label110.TabIndex = 147;
                this.label110.Text = "Payment Mode :";
                this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtAccount_Type
                // 
                this.txtAccount_Type.BackColor = System.Drawing.SystemColors.Control;
                this.txtAccount_Type.Location = new System.Drawing.Point(320, 17);
                this.txtAccount_Type.Name = "txtAccount_Type";
                this.txtAccount_Type.ReadOnly = true;
                this.txtAccount_Type.Size = new System.Drawing.Size(99, 20);
                this.txtAccount_Type.TabIndex = 146;
                // 
                // label111
                // 
                this.label111.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label111.Location = new System.Drawing.Point(227, 20);
                this.label111.Name = "label111";
                this.label111.Size = new System.Drawing.Size(96, 15);
                this.label111.TabIndex = 145;
                this.label111.Text = "Guest Type :";
                this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtRoomID
                // 
                this.txtRoomID.BackColor = System.Drawing.Color.White;
                this.txtRoomID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtRoomID.Location = new System.Drawing.Point(110, 20);
                this.txtRoomID.Name = "txtRoomID";
                this.txtRoomID.Size = new System.Drawing.Size(88, 20);
                this.txtRoomID.TabIndex = 144;
                this.txtRoomID.TextChanged += new System.EventHandler(this.txtRoomID_TextChanged);
                this.txtRoomID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomID_KeyPress);
                // 
                // txtGuestName
                // 
                this.txtGuestName.BackColor = System.Drawing.SystemColors.Control;
                this.txtGuestName.Location = new System.Drawing.Point(110, 75);
                this.txtGuestName.Name = "txtGuestName";
                this.txtGuestName.ReadOnly = true;
                this.txtGuestName.Size = new System.Drawing.Size(187, 20);
                this.txtGuestName.TabIndex = 143;
                // 
                // txtFolioId
                // 
                this.txtFolioId.BackColor = System.Drawing.SystemColors.Control;
                this.txtFolioId.Location = new System.Drawing.Point(110, 48);
                this.txtFolioId.Name = "txtFolioId";
                this.txtFolioId.ReadOnly = true;
                this.txtFolioId.Size = new System.Drawing.Size(88, 20);
                this.txtFolioId.TabIndex = 142;
                // 
                // txtBalance
                // 
                this.txtBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtBalance.Location = new System.Drawing.Point(504, 123);
                this.txtBalance.Name = "txtBalance";
                this.txtBalance.ReadOnly = true;
                this.txtBalance.Size = new System.Drawing.Size(99, 20);
                this.txtBalance.TabIndex = 141;
                this.txtBalance.Text = "0.00";
                this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label46
                // 
                this.label46.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label46.Location = new System.Drawing.Point(436, 128);
                this.label46.Name = "label46";
                this.label46.Size = new System.Drawing.Size(96, 15);
                this.label46.TabIndex = 140;
                this.label46.Text = "Balance :";
                this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtTotalPayment
                // 
                this.txtTotalPayment.BackColor = System.Drawing.SystemColors.Control;
                this.txtTotalPayment.Location = new System.Drawing.Point(320, 127);
                this.txtTotalPayment.Name = "txtTotalPayment";
                this.txtTotalPayment.ReadOnly = true;
                this.txtTotalPayment.Size = new System.Drawing.Size(99, 20);
                this.txtTotalPayment.TabIndex = 139;
                this.txtTotalPayment.Text = "0.00";
                this.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtTotalCharges
                // 
                this.txtTotalCharges.BackColor = System.Drawing.SystemColors.Control;
                this.txtTotalCharges.Location = new System.Drawing.Point(320, 101);
                this.txtTotalCharges.Name = "txtTotalCharges";
                this.txtTotalCharges.ReadOnly = true;
                this.txtTotalCharges.Size = new System.Drawing.Size(99, 20);
                this.txtTotalCharges.TabIndex = 138;
                this.txtTotalCharges.Text = "0.00";
                this.txtTotalCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label70
                // 
                this.label70.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label70.Location = new System.Drawing.Point(227, 131);
                this.label70.Name = "label70";
                this.label70.Size = new System.Drawing.Size(96, 15);
                this.label70.TabIndex = 137;
                this.label70.Text = "Total Payment :";
                this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label71
                // 
                this.label71.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label71.Location = new System.Drawing.Point(227, 105);
                this.label71.Name = "label71";
                this.label71.Size = new System.Drawing.Size(83, 15);
                this.label71.TabIndex = 136;
                this.label71.Text = "Total Charges :";
                this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtDepartureDate
                // 
                this.txtDepartureDate.BackColor = System.Drawing.SystemColors.Control;
                this.txtDepartureDate.Location = new System.Drawing.Point(110, 128);
                this.txtDepartureDate.Name = "txtDepartureDate";
                this.txtDepartureDate.ReadOnly = true;
                this.txtDepartureDate.Size = new System.Drawing.Size(88, 20);
                this.txtDepartureDate.TabIndex = 135;
                // 
                // txtArrivalDate
                // 
                this.txtArrivalDate.BackColor = System.Drawing.SystemColors.Control;
                this.txtArrivalDate.Location = new System.Drawing.Point(110, 102);
                this.txtArrivalDate.Name = "txtArrivalDate";
                this.txtArrivalDate.ReadOnly = true;
                this.txtArrivalDate.Size = new System.Drawing.Size(88, 20);
                this.txtArrivalDate.TabIndex = 134;
                // 
                // label85
                // 
                this.label85.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label85.Location = new System.Drawing.Point(17, 132);
                this.label85.Name = "label85";
                this.label85.Size = new System.Drawing.Size(96, 15);
                this.label85.TabIndex = 133;
                this.label85.Text = "Departure Date :";
                this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label89
                // 
                this.label89.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label89.Location = new System.Drawing.Point(17, 106);
                this.label89.Name = "label89";
                this.label89.Size = new System.Drawing.Size(74, 15);
                this.label89.TabIndex = 132;
                this.label89.Text = "Arrival Date :";
                this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label90
                // 
                this.label90.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label90.Location = new System.Drawing.Point(17, 78);
                this.label90.Name = "label90";
                this.label90.Size = new System.Drawing.Size(60, 14);
                this.label90.TabIndex = 131;
                this.label90.Text = "Guest :";
                this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label118
                // 
                this.Label118.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label118.Location = new System.Drawing.Point(17, 23);
                this.Label118.Name = "Label118";
                this.Label118.Size = new System.Drawing.Size(60, 14);
                this.Label118.TabIndex = 130;
                this.Label118.Text = "Room No :";
                this.Label118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label91
                // 
                this.label91.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label91.Location = new System.Drawing.Point(17, 51);
                this.label91.Name = "label91";
                this.label91.Size = new System.Drawing.Size(58, 14);
                this.label91.TabIndex = 129;
                this.label91.Text = "Folio ID :";
                this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtRemarks
                // 
                this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtRemarks.BackColor = System.Drawing.Color.White;
                this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtRemarks.Location = new System.Drawing.Point(504, 14);
                this.txtRemarks.Multiline = true;
                this.txtRemarks.Name = "txtRemarks";
                this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtRemarks.Size = new System.Drawing.Size(297, 84);
                this.txtRemarks.TabIndex = 118;
                // 
                // Label88
                // 
                this.Label88.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label88.Location = new System.Drawing.Point(436, 18);
                this.Label88.Name = "Label88";
                this.Label88.Size = new System.Drawing.Size(63, 14);
                this.Label88.TabIndex = 117;
                this.Label88.Text = "Remarks :";
                this.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // tpgGroup
                // 
                this.tpgGroup.Controls.Add(this.pnlRemarks);
                this.tpgGroup.Controls.Add(this.label115);
                this.tpgGroup.Controls.Add(this.txtGrpRoomID);
                this.tpgGroup.Controls.Add(this.txtGroupPaymentMode);
                this.tpgGroup.Controls.Add(this.label112);
                this.tpgGroup.Controls.Add(this.Label4);
                this.tpgGroup.Controls.Add(this.txtGroupAccountType);
                this.tpgGroup.Controls.Add(this.GroupBox1);
                this.tpgGroup.Controls.Add(this.label113);
                this.tpgGroup.Controls.Add(this.txtGroupName);
                this.tpgGroup.Controls.Add(this.lvwBrowseGroupName);
                this.tpgGroup.Controls.Add(this.Label1);
                this.tpgGroup.Controls.Add(this.txtGrpBalance);
                this.tpgGroup.Controls.Add(this.btnLookUp);
                this.tpgGroup.Controls.Add(this.label105);
                this.tpgGroup.Controls.Add(this.Label2);
                this.tpgGroup.Controls.Add(this.txtGrpTotalPayment);
                this.tpgGroup.Controls.Add(this.tabGroupCheckOut);
                this.tpgGroup.Controls.Add(this.txtGrpTotalCharges);
                this.tpgGroup.Controls.Add(this.txtGroupFolioId);
                this.tpgGroup.Controls.Add(this.label106);
                this.tpgGroup.Controls.Add(this.txtGroup_CompanyName);
                this.tpgGroup.Controls.Add(this.label107);
                this.tpgGroup.Controls.Add(this.label109);
                this.tpgGroup.Controls.Add(this.txtGrpDepartureDate);
                this.tpgGroup.Controls.Add(this.label108);
                this.tpgGroup.Controls.Add(this.txtGrpArrivalDate);
                this.tpgGroup.Location = new System.Drawing.Point(4, 23);
                this.tpgGroup.Name = "tpgGroup";
                this.tpgGroup.Size = new System.Drawing.Size(826, 529);
                this.tpgGroup.TabIndex = 1;
                this.tpgGroup.Text = "Group";
                // 
                // pnlRemarks
                // 
                this.pnlRemarks.BackColor = System.Drawing.Color.Gainsboro;
                this.pnlRemarks.Controls.Add(this.label117);
                this.pnlRemarks.Controls.Add(this.txtComptrollersInfo);
                this.pnlRemarks.Controls.Add(this.chkNoPayments);
                this.pnlRemarks.Controls.Add(this.btnRemarksCancel);
                this.pnlRemarks.Controls.Add(this.btnRemarksOK);
                this.pnlRemarks.Controls.Add(this.label116);
                this.pnlRemarks.Controls.Add(this.txtGroupRemarks);
                this.pnlRemarks.Location = new System.Drawing.Point(53, 119);
                this.pnlRemarks.Name = "pnlRemarks";
                this.pnlRemarks.Size = new System.Drawing.Size(358, 284);
                this.pnlRemarks.TabIndex = 116;
                this.pnlRemarks.Visible = false;
                // 
                // chkNoPayments
                // 
                this.chkNoPayments.AutoSize = true;
                this.chkNoPayments.Location = new System.Drawing.Point(254, 24);
                this.chkNoPayments.Name = "chkNoPayments";
                this.chkNoPayments.Size = new System.Drawing.Size(98, 18);
                this.chkNoPayments.TabIndex = 165;
                this.chkNoPayments.Text = "No Payments";
                this.chkNoPayments.UseVisualStyleBackColor = true;
                // 
                // btnRemarksCancel
                // 
                this.btnRemarksCancel.Location = new System.Drawing.Point(191, 247);
                this.btnRemarksCancel.Name = "btnRemarksCancel";
                this.btnRemarksCancel.Size = new System.Drawing.Size(75, 30);
                this.btnRemarksCancel.TabIndex = 164;
                this.btnRemarksCancel.Text = "Cancel";
                this.btnRemarksCancel.UseVisualStyleBackColor = true;
                this.btnRemarksCancel.Click += new System.EventHandler(this.btnRemarksCancel_Click);
                // 
                // btnRemarksOK
                // 
                this.btnRemarksOK.Location = new System.Drawing.Point(272, 247);
                this.btnRemarksOK.Name = "btnRemarksOK";
                this.btnRemarksOK.Size = new System.Drawing.Size(75, 30);
                this.btnRemarksOK.TabIndex = 163;
                this.btnRemarksOK.Text = "OK";
                this.btnRemarksOK.UseVisualStyleBackColor = true;
                this.btnRemarksOK.Click += new System.EventHandler(this.btnRemarksOK_Click);
                // 
                // label116
                // 
                this.label116.AutoSize = true;
                this.label116.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label116.Location = new System.Drawing.Point(18, 25);
                this.label116.Name = "label116";
                this.label116.Size = new System.Drawing.Size(52, 14);
                this.label116.TabIndex = 162;
                this.label116.Text = "Remarks:";
                // 
                // txtGroupRemarks
                // 
                this.txtGroupRemarks.Location = new System.Drawing.Point(21, 46);
                this.txtGroupRemarks.Multiline = true;
                this.txtGroupRemarks.Name = "txtGroupRemarks";
                this.txtGroupRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtGroupRemarks.Size = new System.Drawing.Size(322, 91);
                this.txtGroupRemarks.TabIndex = 161;
                // 
                // label115
                // 
                this.label115.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label115.Location = new System.Drawing.Point(211, 16);
                this.label115.Name = "label115";
                this.label115.Size = new System.Drawing.Size(63, 19);
                this.label115.TabIndex = 159;
                this.label115.Text = "Room No. :";
                this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGrpRoomID
                // 
                this.txtGrpRoomID.BackColor = System.Drawing.SystemColors.Control;
                this.txtGrpRoomID.Location = new System.Drawing.Point(274, 14);
                this.txtGrpRoomID.Name = "txtGrpRoomID";
                this.txtGrpRoomID.ReadOnly = true;
                this.txtGrpRoomID.Size = new System.Drawing.Size(88, 20);
                this.txtGrpRoomID.TabIndex = 160;
                // 
                // txtGroupPaymentMode
                // 
                this.txtGroupPaymentMode.BackColor = System.Drawing.SystemColors.Control;
                this.txtGroupPaymentMode.Location = new System.Drawing.Point(509, 68);
                this.txtGroupPaymentMode.Name = "txtGroupPaymentMode";
                this.txtGroupPaymentMode.ReadOnly = true;
                this.txtGroupPaymentMode.Size = new System.Drawing.Size(99, 20);
                this.txtGroupPaymentMode.TabIndex = 158;
                this.txtGroupPaymentMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label112
                // 
                this.label112.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label112.Location = new System.Drawing.Point(416, 71);
                this.label112.Name = "label112";
                this.label112.Size = new System.Drawing.Size(96, 15);
                this.label112.TabIndex = 157;
                this.label112.Text = "Payment Mode :";
                this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label4
                // 
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.Location = new System.Drawing.Point(14, 16);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(89, 19);
                this.Label4.TabIndex = 114;
                this.Label4.Text = "Control No :";
                this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGroupAccountType
                // 
                this.txtGroupAccountType.BackColor = System.Drawing.SystemColors.Control;
                this.txtGroupAccountType.Location = new System.Drawing.Point(509, 96);
                this.txtGroupAccountType.Name = "txtGroupAccountType";
                this.txtGroupAccountType.ReadOnly = true;
                this.txtGroupAccountType.Size = new System.Drawing.Size(99, 20);
                this.txtGroupAccountType.TabIndex = 156;
                this.txtGroupAccountType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // GroupBox1
                // 
                this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.GroupBox1.Controls.Add(this.lblGrpSrvChrg);
                this.GroupBox1.Controls.Add(this.lblGrpCommission);
                this.GroupBox1.Controls.Add(this.lblGrpLocalTax);
                this.GroupBox1.Controls.Add(this.lblGrpGovTax);
                this.GroupBox1.Controls.Add(this.Label9);
                this.GroupBox1.Controls.Add(this.Label10);
                this.GroupBox1.Controls.Add(this.Label35);
                this.GroupBox1.Controls.Add(this.Label49);
                this.GroupBox1.Controls.Add(this.Label50);
                this.GroupBox1.Controls.Add(this.Label51);
                this.GroupBox1.Controls.Add(this.Label52);
                this.GroupBox1.Controls.Add(this.Label53);
                this.GroupBox1.Controls.Add(this.Label54);
                this.GroupBox1.Controls.Add(this.Label55);
                this.GroupBox1.Controls.Add(this.Label56);
                this.GroupBox1.Controls.Add(this.Label57);
                this.GroupBox1.Controls.Add(this.Label60);
                this.GroupBox1.Controls.Add(this.lblGrpTotalCharge);
                this.GroupBox1.Controls.Add(this.lblGrpTotalDisCount);
                this.GroupBox1.Controls.Add(this.lblGrpChargePayment);
                this.GroupBox1.Controls.Add(this.lblGrpChequePayment);
                this.GroupBox1.Controls.Add(this.lblGrpGiftChequePayment);
                this.GroupBox1.Controls.Add(this.lblGrpCashPayment);
                this.GroupBox1.Controls.Add(this.lblGrpBalanceForwarded);
                this.GroupBox1.Controls.Add(this.lblGrpTotalNet);
                this.GroupBox1.Controls.Add(this.lblGrpTotalBalance);
                this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.GroupBox1.Location = new System.Drawing.Point(10, 405);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(808, 116);
                this.GroupBox1.TabIndex = 115;
                this.GroupBox1.TabStop = false;
                this.GroupBox1.Text = "Summary";
                // 
                // lblGrpSrvChrg
                // 
                this.lblGrpSrvChrg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpSrvChrg.Location = new System.Drawing.Point(723, 39);
                this.lblGrpSrvChrg.Name = "lblGrpSrvChrg";
                this.lblGrpSrvChrg.Size = new System.Drawing.Size(49, 14);
                this.lblGrpSrvChrg.TabIndex = 119;
                this.lblGrpSrvChrg.Text = "0.00";
                this.lblGrpSrvChrg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpCommission
                // 
                this.lblGrpCommission.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpCommission.Location = new System.Drawing.Point(723, 21);
                this.lblGrpCommission.Name = "lblGrpCommission";
                this.lblGrpCommission.Size = new System.Drawing.Size(49, 14);
                this.lblGrpCommission.TabIndex = 118;
                this.lblGrpCommission.Text = "0.00";
                this.lblGrpCommission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpLocalTax
                // 
                this.lblGrpLocalTax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpLocalTax.Location = new System.Drawing.Point(568, 39);
                this.lblGrpLocalTax.Name = "lblGrpLocalTax";
                this.lblGrpLocalTax.Size = new System.Drawing.Size(49, 14);
                this.lblGrpLocalTax.TabIndex = 117;
                this.lblGrpLocalTax.Text = "0.00";
                this.lblGrpLocalTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpGovTax
                // 
                this.lblGrpGovTax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpGovTax.Location = new System.Drawing.Point(568, 21);
                this.lblGrpGovTax.Name = "lblGrpGovTax";
                this.lblGrpGovTax.Size = new System.Drawing.Size(49, 14);
                this.lblGrpGovTax.TabIndex = 116;
                this.lblGrpGovTax.Text = "0.00";
                this.lblGrpGovTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label9
                // 
                this.Label9.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label9.Location = new System.Drawing.Point(329, 39);
                this.Label9.Name = "Label9";
                this.Label9.Size = new System.Drawing.Size(76, 14);
                this.Label9.TabIndex = 115;
                this.Label9.Text = "Total Net :";
                this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label9.Visible = false;
                // 
                // Label10
                // 
                this.Label10.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label10.Location = new System.Drawing.Point(632, 21);
                this.Label10.Name = "Label10";
                this.Label10.Size = new System.Drawing.Size(89, 14);
                this.Label10.TabIndex = 114;
                this.Label10.Text = "Commission :";
                this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label35
                // 
                this.Label35.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label35.Location = new System.Drawing.Point(632, 39);
                this.Label35.Name = "Label35";
                this.Label35.Size = new System.Drawing.Size(89, 14);
                this.Label35.TabIndex = 113;
                this.Label35.Text = "Service Charge :";
                this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label49
                // 
                this.Label49.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label49.Location = new System.Drawing.Point(496, 39);
                this.Label49.Name = "Label49";
                this.Label49.Size = new System.Drawing.Size(64, 14);
                this.Label49.TabIndex = 112;
                this.Label49.Text = "Local Tax :";
                this.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label50
                // 
                this.Label50.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label50.Location = new System.Drawing.Point(496, 21);
                this.Label50.Name = "Label50";
                this.Label50.Size = new System.Drawing.Size(64, 14);
                this.Label50.TabIndex = 111;
                this.Label50.Text = "Gov\'t Tax :";
                this.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label51
                // 
                this.Label51.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label51.Location = new System.Drawing.Point(329, 21);
                this.Label51.Name = "Label51";
                this.Label51.Size = new System.Drawing.Size(97, 14);
                this.Label51.TabIndex = 110;
                this.Label51.Text = "Total Balance :";
                this.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label52
                // 
                this.Label52.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label52.Location = new System.Drawing.Point(16, 39);
                this.Label52.Name = "Label52";
                this.Label52.Size = new System.Drawing.Size(85, 14);
                this.Label52.TabIndex = 109;
                this.Label52.Text = "Total Discount :";
                this.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label52.Visible = false;
                // 
                // Label53
                // 
                this.Label53.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label53.Location = new System.Drawing.Point(167, 39);
                this.Label53.Name = "Label53";
                this.Label53.Size = new System.Drawing.Size(97, 14);
                this.Label53.TabIndex = 108;
                this.Label53.Text = "Charge Payment :";
                this.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label54
                // 
                this.Label54.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label54.Location = new System.Drawing.Point(167, 57);
                this.Label54.Name = "Label54";
                this.Label54.Size = new System.Drawing.Size(97, 14);
                this.Label54.TabIndex = 107;
                this.Label54.Text = "Cheque Payment :";
                this.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label55
                // 
                this.Label55.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label55.Location = new System.Drawing.Point(167, 21);
                this.Label55.Name = "Label55";
                this.Label55.Size = new System.Drawing.Size(89, 14);
                this.Label55.TabIndex = 106;
                this.Label55.Text = "Cash Payment :";
                this.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label56
                // 
                this.Label56.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label56.Location = new System.Drawing.Point(167, 75);
                this.Label56.Name = "Label56";
                this.Label56.Size = new System.Drawing.Size(97, 14);
                this.Label56.TabIndex = 105;
                this.Label56.Text = "Gift Cheque :";
                this.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label57
                // 
                this.Label57.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label57.Location = new System.Drawing.Point(167, 93);
                this.Label57.Name = "Label57";
                this.Label57.Size = new System.Drawing.Size(103, 14);
                this.Label57.TabIndex = 104;
                this.Label57.Text = "Others :";
                this.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label60
                // 
                this.Label60.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label60.Location = new System.Drawing.Point(16, 21);
                this.Label60.Name = "Label60";
                this.Label60.Size = new System.Drawing.Size(82, 14);
                this.Label60.TabIndex = 103;
                this.Label60.Text = "Total Charges :";
                this.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblGrpTotalCharge
                // 
                this.lblGrpTotalCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpTotalCharge.Location = new System.Drawing.Point(108, 21);
                this.lblGrpTotalCharge.Name = "lblGrpTotalCharge";
                this.lblGrpTotalCharge.Size = new System.Drawing.Size(49, 14);
                this.lblGrpTotalCharge.TabIndex = 103;
                this.lblGrpTotalCharge.Text = "0.00";
                this.lblGrpTotalCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpTotalDisCount
                // 
                this.lblGrpTotalDisCount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpTotalDisCount.Location = new System.Drawing.Point(108, 39);
                this.lblGrpTotalDisCount.Name = "lblGrpTotalDisCount";
                this.lblGrpTotalDisCount.Size = new System.Drawing.Size(49, 14);
                this.lblGrpTotalDisCount.TabIndex = 109;
                this.lblGrpTotalDisCount.Text = "0.00";
                this.lblGrpTotalDisCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblGrpTotalDisCount.Visible = false;
                // 
                // lblGrpChargePayment
                // 
                this.lblGrpChargePayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpChargePayment.Location = new System.Drawing.Point(265, 39);
                this.lblGrpChargePayment.Name = "lblGrpChargePayment";
                this.lblGrpChargePayment.Size = new System.Drawing.Size(49, 14);
                this.lblGrpChargePayment.TabIndex = 108;
                this.lblGrpChargePayment.Text = "0.00";
                this.lblGrpChargePayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpChequePayment
                // 
                this.lblGrpChequePayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpChequePayment.Location = new System.Drawing.Point(265, 57);
                this.lblGrpChequePayment.Name = "lblGrpChequePayment";
                this.lblGrpChequePayment.Size = new System.Drawing.Size(49, 14);
                this.lblGrpChequePayment.TabIndex = 107;
                this.lblGrpChequePayment.Text = "0.00";
                this.lblGrpChequePayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpGiftChequePayment
                // 
                this.lblGrpGiftChequePayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpGiftChequePayment.Location = new System.Drawing.Point(265, 75);
                this.lblGrpGiftChequePayment.Name = "lblGrpGiftChequePayment";
                this.lblGrpGiftChequePayment.Size = new System.Drawing.Size(49, 14);
                this.lblGrpGiftChequePayment.TabIndex = 105;
                this.lblGrpGiftChequePayment.Text = "0.00";
                this.lblGrpGiftChequePayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpCashPayment
                // 
                this.lblGrpCashPayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpCashPayment.Location = new System.Drawing.Point(265, 21);
                this.lblGrpCashPayment.Name = "lblGrpCashPayment";
                this.lblGrpCashPayment.Size = new System.Drawing.Size(49, 14);
                this.lblGrpCashPayment.TabIndex = 106;
                this.lblGrpCashPayment.Text = "0.00";
                this.lblGrpCashPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpBalanceForwarded
                // 
                this.lblGrpBalanceForwarded.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpBalanceForwarded.Location = new System.Drawing.Point(265, 93);
                this.lblGrpBalanceForwarded.Name = "lblGrpBalanceForwarded";
                this.lblGrpBalanceForwarded.Size = new System.Drawing.Size(49, 14);
                this.lblGrpBalanceForwarded.TabIndex = 108;
                this.lblGrpBalanceForwarded.Text = "0.00";
                this.lblGrpBalanceForwarded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGrpTotalNet
                // 
                this.lblGrpTotalNet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpTotalNet.Location = new System.Drawing.Point(432, 39);
                this.lblGrpTotalNet.Name = "lblGrpTotalNet";
                this.lblGrpTotalNet.Size = new System.Drawing.Size(49, 14);
                this.lblGrpTotalNet.TabIndex = 107;
                this.lblGrpTotalNet.Text = "0.00";
                this.lblGrpTotalNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblGrpTotalNet.Visible = false;
                // 
                // lblGrpTotalBalance
                // 
                this.lblGrpTotalBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGrpTotalBalance.Location = new System.Drawing.Point(432, 21);
                this.lblGrpTotalBalance.Name = "lblGrpTotalBalance";
                this.lblGrpTotalBalance.Size = new System.Drawing.Size(49, 14);
                this.lblGrpTotalBalance.TabIndex = 106;
                this.lblGrpTotalBalance.Text = "0.00";
                this.lblGrpTotalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label113
                // 
                this.label113.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label113.Location = new System.Drawing.Point(416, 99);
                this.label113.Name = "label113";
                this.label113.Size = new System.Drawing.Size(96, 15);
                this.label113.TabIndex = 155;
                this.label113.Text = "Account Type :";
                this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGroupName
                // 
                this.txtGroupName.BackColor = System.Drawing.SystemColors.Info;
                this.txtGroupName.Location = new System.Drawing.Point(103, 41);
                this.txtGroupName.Name = "txtGroupName";
                this.txtGroupName.Size = new System.Drawing.Size(259, 20);
                this.txtGroupName.TabIndex = 108;
                this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
                this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
                // 
                // lvwBrowseGroupName
                // 
                this.lvwBrowseGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lvwBrowseGroupName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3});
                this.lvwBrowseGroupName.FullRowSelect = true;
                this.lvwBrowseGroupName.Location = new System.Drawing.Point(103, 62);
                this.lvwBrowseGroupName.Name = "lvwBrowseGroupName";
                this.lvwBrowseGroupName.Size = new System.Drawing.Size(282, 93);
                this.lvwBrowseGroupName.TabIndex = 116;
                this.lvwBrowseGroupName.UseCompatibleStateImageBehavior = false;
                this.lvwBrowseGroupName.View = System.Windows.Forms.View.Details;
                this.lvwBrowseGroupName.Visible = false;
                this.lvwBrowseGroupName.DoubleClick += new System.EventHandler(this.lvwBrowseGroupName_DoubleClick);
                this.lvwBrowseGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGroupName_KeyPress);
                this.lvwBrowseGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwBrowseGroupName_KeyDown);
                // 
                // ColumnHeader1
                // 
                this.ColumnHeader1.Text = "GroupName";
                this.ColumnHeader1.Width = 108;
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "Company";
                this.ColumnHeader2.Width = 197;
                // 
                // ColumnHeader3
                // 
                this.ColumnHeader3.Text = "FolioID";
                this.ColumnHeader3.Width = 112;
                // 
                // Label1
                // 
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.Location = new System.Drawing.Point(14, 41);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(76, 19);
                this.Label1.TabIndex = 109;
                this.Label1.Text = "Group Name:";
                this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGrpBalance
                // 
                this.txtGrpBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtGrpBalance.Location = new System.Drawing.Point(509, 122);
                this.txtGrpBalance.Name = "txtGrpBalance";
                this.txtGrpBalance.ReadOnly = true;
                this.txtGrpBalance.Size = new System.Drawing.Size(99, 20);
                this.txtGrpBalance.TabIndex = 154;
                this.txtGrpBalance.Text = "0.00";
                this.txtGrpBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // btnLookUp
                // 
                this.btnLookUp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnLookUp.ImageIndex = 0;
                this.btnLookUp.ImageList = this.imgIcon;
                this.btnLookUp.Location = new System.Drawing.Point(368, 37);
                this.btnLookUp.Name = "btnLookUp";
                this.btnLookUp.Size = new System.Drawing.Size(32, 27);
                this.btnLookUp.TabIndex = 110;
                this.btnLookUp.Click += new System.EventHandler(this.btnLookUp_Click);
                // 
                // label105
                // 
                this.label105.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label105.Location = new System.Drawing.Point(445, 124);
                this.label105.Name = "label105";
                this.label105.Size = new System.Drawing.Size(96, 15);
                this.label105.TabIndex = 153;
                this.label105.Text = "Balance :";
                this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label2
                // 
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.Location = new System.Drawing.Point(14, 68);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(79, 19);
                this.Label2.TabIndex = 112;
                this.Label2.Text = "Company:";
                this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGrpTotalPayment
                // 
                this.txtGrpTotalPayment.BackColor = System.Drawing.SystemColors.Control;
                this.txtGrpTotalPayment.Location = new System.Drawing.Point(301, 123);
                this.txtGrpTotalPayment.Name = "txtGrpTotalPayment";
                this.txtGrpTotalPayment.ReadOnly = true;
                this.txtGrpTotalPayment.Size = new System.Drawing.Size(99, 20);
                this.txtGrpTotalPayment.TabIndex = 152;
                this.txtGrpTotalPayment.Text = "0.00";
                this.txtGrpTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // tabGroupCheckOut
                // 
                this.tabGroupCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tabGroupCheckOut.Controls.Add(this.TabPage6);
                this.tabGroupCheckOut.Controls.Add(this.TabPage7);
                this.tabGroupCheckOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tabGroupCheckOut.Location = new System.Drawing.Point(10, 155);
                this.tabGroupCheckOut.Name = "tabGroupCheckOut";
                this.tabGroupCheckOut.SelectedIndex = 0;
                this.tabGroupCheckOut.Size = new System.Drawing.Size(806, 248);
                this.tabGroupCheckOut.TabIndex = 117;
                // 
                // TabPage6
                // 
                this.TabPage6.Controls.Add(this.lvwChildFolio);
                this.TabPage6.Controls.Add(this.chkCheckAll);
                this.TabPage6.Location = new System.Drawing.Point(4, 23);
                this.TabPage6.Name = "TabPage6";
                this.TabPage6.Size = new System.Drawing.Size(798, 221);
                this.TabPage6.TabIndex = 0;
                this.TabPage6.Text = "Child Folios";
                // 
                // lvwChildFolio
                // 
                this.lvwChildFolio.AllowColumnReorder = true;
                this.lvwChildFolio.AllowDrop = true;
                this.lvwChildFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwChildFolio.AutoArrange = false;
                this.lvwChildFolio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRoom,
            this.colName,
            this.colFolioID,
            this.colCharges,
            this.colPayments,
            this.colBalance,
            this.colRunningBalance,
            this.colStatus});
                this.lvwChildFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwChildFolio.FullRowSelect = true;
                this.lvwChildFolio.Location = new System.Drawing.Point(3, 6);
                this.lvwChildFolio.MultiSelect = false;
                this.lvwChildFolio.Name = "lvwChildFolio";
                this.lvwChildFolio.Size = new System.Drawing.Size(793, 191);
                this.lvwChildFolio.TabIndex = 107;
                this.lvwChildFolio.UseCompatibleStateImageBehavior = false;
                this.lvwChildFolio.View = System.Windows.Forms.View.Details;
                this.lvwChildFolio.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwChildFolio_ItemChecked);
                this.lvwChildFolio.DoubleClick += new System.EventHandler(this.lvwChildFolio_DoubleClick);
                // 
                // colRoom
                // 
                this.colRoom.Text = "Room#";
                this.colRoom.Width = 59;
                // 
                // colName
                // 
                this.colName.Text = "Name";
                this.colName.Width = 190;
                // 
                // colFolioID
                // 
                this.colFolioID.Text = " ID";
                this.colFolioID.Width = 90;
                // 
                // colCharges
                // 
                this.colCharges.Text = "Charges";
                this.colCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colCharges.Width = 78;
                // 
                // colPayments
                // 
                this.colPayments.Text = "Payments";
                this.colPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colPayments.Width = 85;
                // 
                // colBalance
                // 
                this.colBalance.Text = "Sub-folio Balance";
                this.colBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colBalance.Width = 100;
                // 
                // colRunningBalance
                // 
                this.colRunningBalance.Text = "Running Balance";
                this.colRunningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colRunningBalance.Width = 100;
                // 
                // colStatus
                // 
                this.colStatus.Text = "Status";
                this.colStatus.Width = 80;
                // 
                // chkCheckAll
                // 
                this.chkCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.chkCheckAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.chkCheckAll.Location = new System.Drawing.Point(11, 199);
                this.chkCheckAll.Name = "chkCheckAll";
                this.chkCheckAll.Size = new System.Drawing.Size(140, 19);
                this.chkCheckAll.TabIndex = 115;
                this.chkCheckAll.Text = "&Select All";
                this.chkCheckAll.Visible = false;
                this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
                // 
                // TabPage7
                // 
                this.TabPage7.Controls.Add(this.lvwGroupFolioA);
                this.TabPage7.Location = new System.Drawing.Point(4, 23);
                this.TabPage7.Name = "TabPage7";
                this.TabPage7.Size = new System.Drawing.Size(798, 221);
                this.TabPage7.TabIndex = 1;
                this.TabPage7.Text = "Transactions";
                // 
                // lvwGroupFolioA
                // 
                this.lvwGroupFolioA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwGroupFolioA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader60,
            this.columnHeader61,
            this.columnHeader62,
            this.columnHeader82,
            this.columnHeader91,
            this.columnHeader96,
            this.columnHeader97,
            this.columnHeader114,
            this.columnHeader115,
            this.columnHeader116,
            this.columnHeader117,
            this.columnHeader118,
            this.columnHeader119,
            this.columnHeader120});
                this.lvwGroupFolioA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwGroupFolioA.FullRowSelect = true;
                this.lvwGroupFolioA.Location = new System.Drawing.Point(4, 6);
                this.lvwGroupFolioA.Name = "lvwGroupFolioA";
                this.lvwGroupFolioA.Size = new System.Drawing.Size(793, 210);
                this.lvwGroupFolioA.TabIndex = 138;
                this.lvwGroupFolioA.UseCompatibleStateImageBehavior = false;
                this.lvwGroupFolioA.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader58
                // 
                this.columnHeader58.Text = "Date";
                this.columnHeader58.Width = 51;
                // 
                // columnHeader59
                // 
                this.columnHeader59.Text = "Posting Date";
                this.columnHeader59.Width = 0;
                // 
                // columnHeader60
                // 
                this.columnHeader60.Text = "Code";
                this.columnHeader60.Width = 40;
                // 
                // columnHeader61
                // 
                this.columnHeader61.Text = "Memo";
                this.columnHeader61.Width = 139;
                // 
                // columnHeader62
                // 
                this.columnHeader62.Text = "Source";
                this.columnHeader62.Width = 72;
                // 
                // columnHeader82
                // 
                this.columnHeader82.Text = "Ref. No.";
                this.columnHeader82.Width = 75;
                // 
                // columnHeader91
                // 
                this.columnHeader91.Text = "Amount";
                this.columnHeader91.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader91.Width = 72;
                // 
                // columnHeader96
                // 
                this.columnHeader96.Text = "Tax";
                this.columnHeader96.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader96.Width = 59;
                // 
                // columnHeader97
                // 
                this.columnHeader97.Text = "Service Charge";
                this.columnHeader97.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader97.Width = 0;
                // 
                // columnHeader114
                // 
                this.columnHeader114.Text = "Gross Amt.";
                this.columnHeader114.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader114.Width = 70;
                // 
                // columnHeader115
                // 
                this.columnHeader115.Text = "Discount";
                this.columnHeader115.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader115.Width = 54;
                // 
                // columnHeader116
                // 
                this.columnHeader116.Text = "Net Amount";
                this.columnHeader116.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader116.Width = 70;
                // 
                // columnHeader117
                // 
                this.columnHeader117.Text = "Balance";
                this.columnHeader117.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader117.Width = 70;
                // 
                // columnHeader118
                // 
                this.columnHeader118.Text = "Staff";
                this.columnHeader118.Width = 46;
                // 
                // columnHeader119
                // 
                this.columnHeader119.Text = "Net Base Amount";
                this.columnHeader119.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader119.Width = 0;
                // 
                // columnHeader120
                // 
                this.columnHeader120.Text = "Transaction No";
                this.columnHeader120.Width = 0;
                // 
                // txtGrpTotalCharges
                // 
                this.txtGrpTotalCharges.BackColor = System.Drawing.SystemColors.Control;
                this.txtGrpTotalCharges.Location = new System.Drawing.Point(301, 97);
                this.txtGrpTotalCharges.Name = "txtGrpTotalCharges";
                this.txtGrpTotalCharges.ReadOnly = true;
                this.txtGrpTotalCharges.Size = new System.Drawing.Size(99, 20);
                this.txtGrpTotalCharges.TabIndex = 151;
                this.txtGrpTotalCharges.Text = "0.00";
                this.txtGrpTotalCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtGroupFolioId
                // 
                this.txtGroupFolioId.BackColor = System.Drawing.SystemColors.Control;
                this.txtGroupFolioId.Location = new System.Drawing.Point(103, 14);
                this.txtGroupFolioId.Name = "txtGroupFolioId";
                this.txtGroupFolioId.ReadOnly = true;
                this.txtGroupFolioId.Size = new System.Drawing.Size(88, 20);
                this.txtGroupFolioId.TabIndex = 143;
                this.txtGroupFolioId.TextChanged += new System.EventHandler(this.lblGrpFolioID_TextChanged);
                // 
                // label106
                // 
                this.label106.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label106.Location = new System.Drawing.Point(208, 127);
                this.label106.Name = "label106";
                this.label106.Size = new System.Drawing.Size(96, 15);
                this.label106.TabIndex = 150;
                this.label106.Text = "Total Payment :";
                this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGroup_CompanyName
                // 
                this.txtGroup_CompanyName.BackColor = System.Drawing.SystemColors.Control;
                this.txtGroup_CompanyName.Location = new System.Drawing.Point(103, 68);
                this.txtGroup_CompanyName.Name = "txtGroup_CompanyName";
                this.txtGroup_CompanyName.ReadOnly = true;
                this.txtGroup_CompanyName.Size = new System.Drawing.Size(297, 20);
                this.txtGroup_CompanyName.TabIndex = 144;
                // 
                // label107
                // 
                this.label107.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label107.Location = new System.Drawing.Point(208, 101);
                this.label107.Name = "label107";
                this.label107.Size = new System.Drawing.Size(83, 15);
                this.label107.TabIndex = 149;
                this.label107.Text = "Total Charges :";
                this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label109
                // 
                this.label109.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label109.Location = new System.Drawing.Point(14, 102);
                this.label109.Name = "label109";
                this.label109.Size = new System.Drawing.Size(74, 15);
                this.label109.TabIndex = 145;
                this.label109.Text = "Arrival Date :";
                this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGrpDepartureDate
                // 
                this.txtGrpDepartureDate.BackColor = System.Drawing.SystemColors.Control;
                this.txtGrpDepartureDate.Location = new System.Drawing.Point(103, 124);
                this.txtGrpDepartureDate.Name = "txtGrpDepartureDate";
                this.txtGrpDepartureDate.ReadOnly = true;
                this.txtGrpDepartureDate.Size = new System.Drawing.Size(88, 20);
                this.txtGrpDepartureDate.TabIndex = 148;
                // 
                // label108
                // 
                this.label108.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label108.Location = new System.Drawing.Point(14, 128);
                this.label108.Name = "label108";
                this.label108.Size = new System.Drawing.Size(96, 15);
                this.label108.TabIndex = 146;
                this.label108.Text = "Departure Date :";
                this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtGrpArrivalDate
                // 
                this.txtGrpArrivalDate.BackColor = System.Drawing.SystemColors.Control;
                this.txtGrpArrivalDate.Location = new System.Drawing.Point(103, 98);
                this.txtGrpArrivalDate.Name = "txtGrpArrivalDate";
                this.txtGrpArrivalDate.ReadOnly = true;
                this.txtGrpArrivalDate.Size = new System.Drawing.Size(88, 20);
                this.txtGrpArrivalDate.TabIndex = 147;
                // 
                // ColumnHeader14
                // 
                this.ColumnHeader14.Text = "Room No.";
                // 
                // ColumnHeader15
                // 
                this.ColumnHeader15.Text = "Type";
                this.ColumnHeader15.Width = 90;
                // 
                // ColumnHeader16
                // 
                this.ColumnHeader16.Text = "From";
                this.ColumnHeader16.Width = 90;
                // 
                // ColumnHeader17
                // 
                this.ColumnHeader17.Text = "To";
                this.ColumnHeader17.Width = 90;
                // 
                // ColumnHeader18
                // 
                this.ColumnHeader18.Text = "Rate";
                // 
                // ColumnHeader19
                // 
                this.ColumnHeader19.Text = "Days";
                this.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader19.Width = 40;
                // 
                // ColumnHeader20
                // 
                this.ColumnHeader20.Text = "Amount";
                // 
                // ColumnHeader21
                // 
                this.ColumnHeader21.Text = "Room No.";
                // 
                // ColumnHeader22
                // 
                this.ColumnHeader22.Text = "Type";
                this.ColumnHeader22.Width = 90;
                // 
                // ColumnHeader23
                // 
                this.ColumnHeader23.Text = "From";
                this.ColumnHeader23.Width = 90;
                // 
                // ColumnHeader24
                // 
                this.ColumnHeader24.Text = "To";
                this.ColumnHeader24.Width = 90;
                // 
                // ColumnHeader25
                // 
                this.ColumnHeader25.Text = "Rate";
                // 
                // ColumnHeader26
                // 
                this.ColumnHeader26.Text = "Days";
                this.ColumnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader26.Width = 40;
                // 
                // ColumnHeader27
                // 
                this.ColumnHeader27.Text = "Amount";
                // 
                // ColumnHeader7
                // 
                this.ColumnHeader7.Text = "Date";
                this.ColumnHeader7.Width = 139;
                // 
                // ColumnHeader8
                // 
                this.ColumnHeader8.Text = "Reference No.";
                this.ColumnHeader8.Width = 84;
                // 
                // ColumnHeader9
                // 
                this.ColumnHeader9.Text = "Transaction Code";
                this.ColumnHeader9.Width = 103;
                // 
                // ColumnHeader10
                // 
                this.ColumnHeader10.Text = "Memo";
                this.ColumnHeader10.Width = 211;
                // 
                // ColumnHeader11
                // 
                this.ColumnHeader11.Text = "AccountSide";
                this.ColumnHeader11.Width = 78;
                // 
                // ColumnHeader12
                // 
                this.ColumnHeader12.Text = "Currency Code";
                this.ColumnHeader12.Width = 91;
                // 
                // ColumnHeader13
                // 
                this.ColumnHeader13.Text = "Conversion Rate";
                this.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader13.Width = 117;
                // 
                // ColumnHeader28
                // 
                this.ColumnHeader28.Text = "Currency Amount";
                this.ColumnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // ColumnHeader29
                // 
                this.ColumnHeader29.Text = "Base Amount";
                this.ColumnHeader29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // ColumnHeader30
                // 
                this.ColumnHeader30.Text = "Update Time";
                // 
                // ColumnHeader31
                // 
                this.ColumnHeader31.Text = "Route Code";
                // 
                // ColumnHeader32
                // 
                this.ColumnHeader32.Text = "Updated By";
                this.ColumnHeader32.Width = 103;
                // 
                // ColumnHeader33
                // 
                this.ColumnHeader33.Text = "Payment Type";
                this.ColumnHeader33.Width = 103;
                // 
                // ColumnHeader34
                // 
                this.ColumnHeader34.Text = "gTerminalID";
                // 
                // ColumnHeader35
                // 
                this.ColumnHeader35.Text = "Cheque No";
                this.ColumnHeader35.Width = 103;
                // 
                // ColumnHeader36
                // 
                this.ColumnHeader36.Text = "Bank Code";
                this.ColumnHeader36.Width = 103;
                // 
                // ColumnHeader37
                // 
                this.ColumnHeader37.Text = "CreditCard No";
                this.ColumnHeader37.Width = 103;
                // 
                // ColumnHeader38
                // 
                this.ColumnHeader38.Text = "CreditCard Type";
                this.ColumnHeader38.Width = 103;
                // 
                // Label33
                // 
                this.Label33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label33.Location = new System.Drawing.Point(723, 39);
                this.Label33.Name = "Label33";
                this.Label33.Size = new System.Drawing.Size(49, 14);
                this.Label33.TabIndex = 119;
                this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label34
                // 
                this.Label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label34.Location = new System.Drawing.Point(723, 21);
                this.Label34.Name = "Label34";
                this.Label34.Size = new System.Drawing.Size(49, 14);
                this.Label34.TabIndex = 118;
                this.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label30
                // 
                this.Label30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label30.Location = new System.Drawing.Point(568, 39);
                this.Label30.Name = "Label30";
                this.Label30.Size = new System.Drawing.Size(49, 14);
                this.Label30.TabIndex = 117;
                this.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label32
                // 
                this.Label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label32.Location = new System.Drawing.Point(568, 21);
                this.Label32.Name = "Label32";
                this.Label32.Size = new System.Drawing.Size(49, 14);
                this.Label32.TabIndex = 116;
                this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label20
                // 
                this.Label20.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label20.Location = new System.Drawing.Point(329, 58);
                this.Label20.Name = "Label20";
                this.Label20.Size = new System.Drawing.Size(76, 14);
                this.Label20.TabIndex = 115;
                this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label21
                // 
                this.Label21.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label21.Location = new System.Drawing.Point(632, 21);
                this.Label21.Name = "Label21";
                this.Label21.Size = new System.Drawing.Size(89, 14);
                this.Label21.TabIndex = 114;
                this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label17
                // 
                this.Label17.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label17.Location = new System.Drawing.Point(632, 39);
                this.Label17.Name = "Label17";
                this.Label17.Size = new System.Drawing.Size(89, 14);
                this.Label17.TabIndex = 113;
                this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label18
                // 
                this.Label18.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label18.Location = new System.Drawing.Point(496, 39);
                this.Label18.Name = "Label18";
                this.Label18.Size = new System.Drawing.Size(64, 14);
                this.Label18.TabIndex = 112;
                this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label19
                // 
                this.Label19.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label19.Location = new System.Drawing.Point(496, 21);
                this.Label19.Name = "Label19";
                this.Label19.Size = new System.Drawing.Size(64, 14);
                this.Label19.TabIndex = 111;
                this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label16
                // 
                this.Label16.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label16.Location = new System.Drawing.Point(329, 21);
                this.Label16.Name = "Label16";
                this.Label16.Size = new System.Drawing.Size(97, 14);
                this.Label16.TabIndex = 110;
                this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label15
                // 
                this.Label15.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label15.Location = new System.Drawing.Point(16, 39);
                this.Label15.Name = "Label15";
                this.Label15.Size = new System.Drawing.Size(85, 14);
                this.Label15.TabIndex = 109;
                this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label14
                // 
                this.Label14.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label14.Location = new System.Drawing.Point(167, 39);
                this.Label14.Name = "Label14";
                this.Label14.Size = new System.Drawing.Size(97, 14);
                this.Label14.TabIndex = 108;
                this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label7
                // 
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label7.Location = new System.Drawing.Point(167, 58);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(97, 14);
                this.Label7.TabIndex = 107;
                this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label13
                // 
                this.Label13.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label13.Location = new System.Drawing.Point(167, 21);
                this.Label13.Name = "Label13";
                this.Label13.Size = new System.Drawing.Size(89, 14);
                this.Label13.TabIndex = 106;
                this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label12
                // 
                this.Label12.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label12.Location = new System.Drawing.Point(167, 78);
                this.Label12.Name = "Label12";
                this.Label12.Size = new System.Drawing.Size(97, 14);
                this.Label12.TabIndex = 105;
                this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label11
                // 
                this.Label11.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label11.Location = new System.Drawing.Point(329, 39);
                this.Label11.Name = "Label11";
                this.Label11.Size = new System.Drawing.Size(103, 14);
                this.Label11.TabIndex = 104;
                this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label3
                // 
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label3.Location = new System.Drawing.Point(16, 21);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(82, 14);
                this.Label3.TabIndex = 103;
                this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label22
                // 
                this.Label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label22.Location = new System.Drawing.Point(108, 21);
                this.Label22.Name = "Label22";
                this.Label22.Size = new System.Drawing.Size(49, 14);
                this.Label22.TabIndex = 103;
                this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label23
                // 
                this.Label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label23.Location = new System.Drawing.Point(108, 39);
                this.Label23.Name = "Label23";
                this.Label23.Size = new System.Drawing.Size(49, 14);
                this.Label23.TabIndex = 109;
                this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label24
                // 
                this.Label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label24.Location = new System.Drawing.Point(265, 39);
                this.Label24.Name = "Label24";
                this.Label24.Size = new System.Drawing.Size(49, 14);
                this.Label24.TabIndex = 108;
                this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label25
                // 
                this.Label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label25.Location = new System.Drawing.Point(265, 58);
                this.Label25.Name = "Label25";
                this.Label25.Size = new System.Drawing.Size(49, 14);
                this.Label25.TabIndex = 107;
                this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label26
                // 
                this.Label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label26.Location = new System.Drawing.Point(265, 79);
                this.Label26.Name = "Label26";
                this.Label26.Size = new System.Drawing.Size(49, 14);
                this.Label26.TabIndex = 105;
                this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label27
                // 
                this.Label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label27.Location = new System.Drawing.Point(265, 21);
                this.Label27.Name = "Label27";
                this.Label27.Size = new System.Drawing.Size(49, 14);
                this.Label27.TabIndex = 106;
                this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label28
                // 
                this.Label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label28.Location = new System.Drawing.Point(432, 39);
                this.Label28.Name = "Label28";
                this.Label28.Size = new System.Drawing.Size(49, 14);
                this.Label28.TabIndex = 108;
                this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label29
                // 
                this.Label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label29.Location = new System.Drawing.Point(432, 58);
                this.Label29.Name = "Label29";
                this.Label29.Size = new System.Drawing.Size(49, 14);
                this.Label29.TabIndex = 107;
                this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Label31
                // 
                this.Label31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label31.Location = new System.Drawing.Point(432, 21);
                this.Label31.Name = "Label31";
                this.Label31.Size = new System.Drawing.Size(49, 14);
                this.Label31.TabIndex = 106;
                this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // ColumnHeader41
                // 
                this.ColumnHeader41.Text = "Memo";
                this.ColumnHeader41.Width = 167;
                // 
                // ColumnHeader40
                // 
                this.ColumnHeader40.Text = "Code";
                this.ColumnHeader40.Width = 40;
                // 
                // ColumnHeader39
                // 
                this.ColumnHeader39.Text = "Date / Time";
                this.ColumnHeader39.Width = 117;
                // 
                // ColumnHeader47
                // 
                this.ColumnHeader47.Text = "Net Amount";
                this.ColumnHeader47.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader47.Width = 75;
                // 
                // ColumnHeader46
                // 
                this.ColumnHeader46.Text = "Discount";
                this.ColumnHeader46.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader46.Width = 75;
                // 
                // ColumnHeader45
                // 
                this.ColumnHeader45.Text = "Service Chrg";
                this.ColumnHeader45.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader45.Width = 75;
                // 
                // ColumnHeader44
                // 
                this.ColumnHeader44.Text = "Local Tax";
                this.ColumnHeader44.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader44.Width = 75;
                // 
                // ColumnHeader43
                // 
                this.ColumnHeader43.Text = "Gov\'t Tax";
                this.ColumnHeader43.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader43.Width = 75;
                // 
                // ColumnHeader42
                // 
                this.ColumnHeader42.Text = "Amount";
                this.ColumnHeader42.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.ColumnHeader42.Width = 75;
                // 
                // btnClose
                // 
                this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(763, 608);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(80, 31);
                this.btnClose.TabIndex = 102;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnSingleCancel_Click);
                // 
                // btnViewBill
                // 
                this.btnViewBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnViewBill.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnViewBill.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnViewBill.Location = new System.Drawing.Point(4, 608);
                this.btnViewBill.Name = "btnViewBill";
                this.btnViewBill.Size = new System.Drawing.Size(80, 31);
                this.btnViewBill.TabIndex = 104;
                this.btnViewBill.Text = "Pri&nt ACR";
                this.btnViewBill.Click += new System.EventHandler(this.btnViewBill_Click);
                // 
                // btnPayment
                // 
                this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnPayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnPayment.Location = new System.Drawing.Point(458, 608);
                this.btnPayment.Name = "btnPayment";
                this.btnPayment.Size = new System.Drawing.Size(108, 31);
                this.btnPayment.TabIndex = 105;
                this.btnPayment.Text = "Insert &Payment";
                this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
                // 
                // btnCheckOutSingle
                // 
                this.btnCheckOutSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCheckOutSingle.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCheckOutSingle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCheckOutSingle.Location = new System.Drawing.Point(680, 608);
                this.btnCheckOutSingle.Name = "btnCheckOutSingle";
                this.btnCheckOutSingle.Size = new System.Drawing.Size(80, 31);
                this.btnCheckOutSingle.TabIndex = 103;
                this.btnCheckOutSingle.Text = "Close Event";
                this.btnCheckOutSingle.Click += new System.EventHandler(this.btnCheckOutSingle_Click);
                // 
                // btnTransferDebit
                // 
                this.btnTransferDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnTransferDebit.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnTransferDebit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnTransferDebit.Location = new System.Drawing.Point(94, 608);
                this.btnTransferDebit.Name = "btnTransferDebit";
                this.btnTransferDebit.Size = new System.Drawing.Size(119, 31);
                this.btnTransferDebit.TabIndex = 106;
                this.btnTransferDebit.Text = "&Transfer Debit/Credit";
                this.btnTransferDebit.Visible = false;
                this.btnTransferDebit.Click += new System.EventHandler(this.btnTransferDebit_Click);
                // 
                // btnInsertCharges
                // 
                this.btnInsertCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnInsertCharges.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnInsertCharges.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnInsertCharges.Location = new System.Drawing.Point(569, 608);
                this.btnInsertCharges.Name = "btnInsertCharges";
                this.btnInsertCharges.Size = new System.Drawing.Size(108, 31);
                this.btnInsertCharges.TabIndex = 107;
                this.btnInsertCharges.Text = "&Insert Charge";
                this.btnInsertCharges.Click += new System.EventHandler(this.btnInsertCharges_Click);
                // 
                // label114
                // 
                this.label114.AutoSize = true;
                this.label114.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label114.Location = new System.Drawing.Point(11, 9);
                this.label114.Name = "label114";
                this.label114.Size = new System.Drawing.Size(113, 22);
                this.label114.TabIndex = 131;
                this.label114.Text = "Close Event";
                this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // groupBox2
                // 
                this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox2.Location = new System.Drawing.Point(8, 34);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(835, 5);
                this.groupBox2.TabIndex = 132;
                this.groupBox2.TabStop = false;
                // 
                // label117
                // 
                this.label117.AutoSize = true;
                this.label117.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label117.Location = new System.Drawing.Point(18, 143);
                this.label117.Name = "label117";
                this.label117.Size = new System.Drawing.Size(110, 14);
                this.label117.TabIndex = 167;
                this.label117.Text = "For Comptrollers Info:";
                // 
                // txtComptrollersInfo
                // 
                this.txtComptrollersInfo.Location = new System.Drawing.Point(21, 163);
                this.txtComptrollersInfo.Multiline = true;
                this.txtComptrollersInfo.Name = "txtComptrollersInfo";
                this.txtComptrollersInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtComptrollersInfo.Size = new System.Drawing.Size(322, 78);
                this.txtComptrollersInfo.TabIndex = 166;
                // 
                // CheckOutUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(848, 647);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.label114);
                this.Controls.Add(this.btnInsertCharges);
                this.Controls.Add(this.btnTransferDebit);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnViewBill);
                this.Controls.Add(this.btnPayment);
                this.Controls.Add(this.btnCheckOutSingle);
                this.Controls.Add(this.tabCheckout);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.Name = "CheckOutUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Close Event";
                this.Load += new System.EventHandler(this.CheckOutUI_Load);
                this.Closed += new System.EventHandler(this.CheckOutUI_Closed);
                this.Activated += new System.EventHandler(this.CheckOutUI_Activated);
                this.Enter += new System.EventHandler(this.CheckOutUI_Enter);
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckOutUI_FormClosing);
                this.tabCheckout.ResumeLayout(false);
                this.TabPage1.ResumeLayout(false);
                this.tabSubFolio.ResumeLayout(false);
                this.TabPage2.ResumeLayout(false);
                this.groupBox6.ResumeLayout(false);
                this.mnuPopUp.ResumeLayout(false);
                this.TabPage3.ResumeLayout(false);
                this.TabPage3.PerformLayout();
                this.GroupBox4.ResumeLayout(false);
                this.TabPage4.ResumeLayout(false);
                this.TabPage4.PerformLayout();
                this.groupBox3.ResumeLayout(false);
                this.TabPage5.ResumeLayout(false);
                this.TabPage5.PerformLayout();
                this.groupBox5.ResumeLayout(false);
                this.GroupBox7.ResumeLayout(false);
                this.GroupBox7.PerformLayout();
                this.tpgGroup.ResumeLayout(false);
                this.tpgGroup.PerformLayout();
                this.pnlRemarks.ResumeLayout(false);
                this.pnlRemarks.PerformLayout();
                this.GroupBox1.ResumeLayout(false);
                this.tabGroupCheckOut.ResumeLayout(false);
                this.TabPage6.ResumeLayout(false);
                this.TabPage7.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			
			#endregion

			#region "variable declaration"
			private MySqlConnection localConnection;
			//private ReservationListUI SingleReservationListUI;
			//private GroupReservationListUI GrpReservationListUI;
			private Guest oGuest = new Guest();
			private Company oCompany = new Company();
			private Folio oFolio = new Folio();
			private Folio oGroupFolio = new Folio();
			private Schedule oSchedule = new Schedule();
			
			private RoomEventCollection oRoomEventsCollection = new RoomEventCollection();
			private FolioFacade oFolioFACADE = new FolioFacade();
			private GuestFacade oGuestFACADE = new GuestFacade();
			private CompanyFacade oCompanyFACADE = new CompanyFacade();
			private ScheduleFacade oScheduleFACADE;
			private RoomEventFacade oRoomEventFacade;
			//private Jinisys.Hotel.Configuration.BusinessLayer.RoomType oRateFacade;
			//private DataReaderBinder oDataReaderBinder = new DataReaderBinder();
			private FormToObjectInstanceBinder oFormtoObjectInstance = new FormToObjectInstanceBinder();
			private string mType = string.Empty;

			private ReportViewer reportViewerUI;
			private ReportFacade reportFacade;

			#endregion

			#region "Constructor"
			
			private string mFolioID;
			
			// >> INDIVIDUAL CHECKOUT
			public CheckOutUI(string FolioID)
			{
				InitializeComponent();
				this.txtFolioId.Text = FolioID;
				mFolioID = FolioID;
				oFolioFACADE = new FolioFacade( );
                //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                //used a constant parameter to avoid possible error/dependencies, no time to check
				this.txtRoomID.Text = oFolioFACADE.GetCurrentRoomOccupied(FolioID, "INDIVIDUAL");
				this.txtRoomID_KeyPress(txtRoomID, new System.Windows.Forms.KeyPressEventArgs('\r'));

                if (oFolio.FolioType == "DEPENDENT")
                {
                    //>>display information for the group too
                    this.txtGroupFolioId.Text = oFolio.MasterFolio;
                    oFolioFACADE = new FolioFacade();

                    oGroupFolio = oFolioFACADE.GetFolio(oFolio.MasterFolio);
                    oGroupFolio.FolioTransactions = oFolioFACADE.GetFolioTransactions(oFolio.MasterFolio, "A");
                    txtGrpArrivalDate.Text = oGroupFolio.FromDate.ToString("dd-MMM-yyyy");
                    txtGrpDepartureDate.Text = oGroupFolio.Todate.ToString("dd-MMM-yyyy");
                    //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                    //used a constant parameter to avoid possible error/dependencies, no time to check
                    this.txtGrpRoomID.Text = oFolioFACADE.GetCurrentRoomOccupied(oFolio.MasterFolio, "INDIVIDUAL");

                    CompanyFacade _oCompanyFacade = new CompanyFacade();
                    Company _oCompany = new Company();
                    _oCompany = _oCompanyFacade.getCompanyInfo(txtGroupFolioId.Text);

                    if (_oCompany == null)
                    {
                        txtGroup_CompanyName.Text = "";
                    }
                    else
                    {
                        txtGroup_CompanyName.Text = _oCompany.CompanyName;
                    }
                    loadDataInListView(oGroupFolio.FolioTransactions, lvwGroupFolioA);
                }
            }

			public CheckOutUI(string FolioID, string parentFolio, string type)
			{
				InitializeComponent();
				this.txtFolioId.Text = FolioID;
				//this.txtRoomID.Visible = false;
				//Me.lblRoomNo.Visible = False
				mType = type;
				//           Me.lblGuestName.Text = parentFolio
				oFolioFACADE = new FolioFacade();
                if (parentFolio == "")
                {
                    //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                    //used a constant parameter to avoid possible error/dependencies, no time to check
                    this.txtRoomID.Text = oFolioFACADE.GetCurrentRoomOccupied(FolioID, "INDIVIDUAL");
                }
                else
                {
                    //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                    //used a constant parameter to avoid possible error/dependencies, no time to check
                    this.txtRoomID.Text = oFolioFACADE.GetCurrentRoomOccupied(parentFolio,"INDIVIDUAL");
                }

				this.txtRoomID_KeyPress(txtRoomID, new System.Windows.Forms.KeyPressEventArgs('\r'));
			}
			
			//private string mGroupFolioID;
            //>>GROUP FOLIO CHECK OUT
            private void loadGroupFolio(string FolioID, string GroupName)
            {
                this.txtGroupFolioId.Text = FolioID;
                oFolioFACADE = new FolioFacade();

                oFolio = oFolioFACADE.GetFolio(FolioID);
                oFolio.FolioTransactions = oFolioFACADE.GetFolioTransactions(FolioID, "A");
                txtGrpArrivalDate.Text = oFolio.FromDate.ToString("dd-MMM-yyyy");
                txtGrpDepartureDate.Text = oFolio.Todate.ToString("dd-MMM-yyyy");
                //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                //used a constant parameter to avoid possible error/dependencies, no time to check
                this.txtGrpRoomID.Text = oFolioFACADE.GetCurrentRoomOccupied(FolioID,"INDIVIDUAL");

                CompanyFacade _oCompanyFacade = new CompanyFacade();
                Company _oCompany = new Company();
                _oCompany = _oCompanyFacade.getCompanyInfo(txtGroupFolioId.Text);

                if (_oCompany == null)
                {
                    txtGroup_CompanyName.Text = "";
                }
                else
                {
                    txtGroup_CompanyName.Text = _oCompany.CompanyName;
                }
                loadDataInListView(oFolio.FolioTransactions, lvwGroupFolioA);

                this.tabCheckout.SelectedIndex = 1;
            }

			public CheckOutUI(string FolioID, string GroupName)
			{
				InitializeComponent();
                loadGroupFolio(FolioID, GroupName);
			}
			
			#endregion
			
			private void loadconnectionStrings()
			{
				oRoomEventFacade = new RoomEventFacade();
				oScheduleFACADE = new ScheduleFacade();
				oFolioFACADE = new FolioFacade();
				oRoomEventFacade = new RoomEventFacade();
				oGuestFACADE = new GuestFacade();
				
			}

			private void loadDataInListView(FolioTransactions poFolioTransaction, ListView pListView)
			{

				try
				{
					pListView.Items.Clear();
					FolioTransaction _oFolioTransaction;

					decimal _totalCharges = 0;
					decimal _totalPayment = 0;
					decimal _balance = 0;

					foreach (FolioTransaction _fFolioTransaction in poFolioTransaction)
					{
						_oFolioTransaction = _fFolioTransaction;

						ListViewItem lvwItem = new ListViewItem();
						decimal _totalTax = _oFolioTransaction.GovernmentTax + _oFolioTransaction.LocalTax;


						lvwItem.Text = _oFolioTransaction.TransactionDate.ToShortDateString();

						lvwItem.SubItems.Add(_oFolioTransaction.PostingDate.ToString("MM/dd/yyyy hh:mm"));

						lvwItem.SubItems.Add(_oFolioTransaction.TransactionCode);
						lvwItem.SubItems.Add(_oFolioTransaction.Memo);
						lvwItem.SubItems.Add(_oFolioTransaction.TransactionSource);
						lvwItem.SubItems.Add(_oFolioTransaction.ReferenceNo);


						string _strBaseAmount = _oFolioTransaction.BaseAmount.ToString("N");
						Color _color = Color.Black;
						if (_oFolioTransaction.AcctSide == "CREDIT")
						{
                            if (_oFolioTransaction.BaseAmount.ToString().Contains("-"))
                            {
                                _strBaseAmount = _oFolioTransaction.BaseAmount.ToString("N");
                            }
                            else
                            {
                                _strBaseAmount = "-" + _oFolioTransaction.BaseAmount.ToString("N");
                            }

							_color = Color.Red;
						}

						lvwItem.SubItems.Add(_strBaseAmount);

						// change color of BaseAmount to Red since payment
						lvwItem.SubItems[6].ForeColor = _color;


						lvwItem.SubItems.Add(_totalTax.ToString("N"));

						lvwItem.SubItems.Add(_oFolioTransaction.ServiceCharge.ToString("N"));
						lvwItem.SubItems.Add(_oFolioTransaction.GrossAmount.ToString("N"));
						lvwItem.SubItems.Add(_oFolioTransaction.Discount.ToString("N"));

						if (_oFolioTransaction.AcctSide == "DEBIT")
						{
							//_totalCharges += _oFolioTransaction.BaseAmount;
							_totalCharges += _oFolioTransaction.NetAmount;

							lvwItem.SubItems.Add(_oFolioTransaction.NetAmount.ToString("N"));


						}
						else
						{
							//_totalPayment += _oFolioTransaction.BaseAmount;
							_totalPayment += _oFolioTransaction.NetAmount;
                            string _strAmount = "";

                            if (_oFolioTransaction.BaseAmount.ToString().Contains("-"))
                            {
                                _strAmount = _oFolioTransaction.NetAmount.ToString("N");
                            }
                            else
                            {
                                _strAmount = "-" + _oFolioTransaction.NetAmount.ToString("N");
                            }

							lvwItem.SubItems.Add(_strAmount);

							// change color of NetAmount to Red since payment
							lvwItem.SubItems[11].ForeColor = Color.Red;
						}

						_balance = _totalCharges - _totalPayment;

						lvwItem.SubItems.Add(_balance.ToString("N"));
						// change color of Balance to Red if < 0
						if (_balance < 0)
						{
							lvwItem.SubItems[12].ForeColor = Color.Red;
						}

						lvwItem.SubItems.Add(_oFolioTransaction.UpdatedBy);
						lvwItem.SubItems.Add(_oFolioTransaction.NetBaseAmount.ToString("N"));
						lvwItem.SubItems.Add(_oFolioTransaction.FolioTransactionNo.ToString());

						pListView.Items.Add(lvwItem);

						if (_oFolioTransaction.AuditFlag == "1")
						{
							lvwItem.BackColor = System.Drawing.Color.Gainsboro;
						}
						else
						{
							lvwItem.BackColor = System.Drawing.Color.White;
						}

						
						lvwItem.UseItemStyleForSubItems = false;
						
						foreach (ListViewItem.ListViewSubItem lvwSubItem in lvwItem.SubItems)
						{
							lvwSubItem.BackColor = lvwItem.BackColor;
						}
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "LoadInListView Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

			public void setCheckedOut(string pFolioId)
			{
				oFolioFACADE = new FolioFacade();
				
				try
				{
                    //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                    //used a constant parameter to avoid possible error/dependencies, no time to check
					string _roomNo = oFolioFACADE.GetCurrentRoomOccupied(pFolioId, "INDIVIDUAL");
					string _remarks = "";

					oFolioFACADE = new FolioFacade();
					oFolioFACADE.checkOutFolio(pFolioId, _roomNo, _remarks);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Check-out failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				//RoomEvents oRoomEvents = new RoomEvents();
				//FolioFacade oFolioFACADE = new FolioFacade();
				//RoomEventFacade oRoomEventFacade = new RoomEventFacade();
				//RoomFacade oRoomFacade = new RoomFacade();
				//oRoomEvents.EventType = "CLOSED";
				//oFolioFACADE.UpdateStatusAndRemarks("CLOSED", mfolioid, this.txtRemarks.Text);

				//// update all dependent folios if any
				//IList<Folio> _oShareFolioList = oFolioFACADE.getShareFolios(mfolioid);
				//foreach (Folio _oFolio in _oShareFolioList)
				//{
				//    string folioId = _oFolio.FolioID;
				//    oFolioFACADE.updateShareFolioStatus("CLOSED", mfolioid, folioId);
				//}

				//// this is to update Account Type, Total Sales Contribution, X-Deal Amount for Company
				//// and No Of Visits
				//Folio coFolio = oFolioFACADE.GetFolio(mfolioid);
				//coFolio.CreateSubFolio();
				//double totalSales = 0;
				//double totalCharges = 0;
				//try
				//{
				//    foreach (SubFolio subFolio in coFolio.SubFolios)
				//    {
				//        subFolio.Folio.FolioTransactions = oFolioFACADE.GetFolioTransactions(coFolio.FolioID, subFolio.SubFolio_Renamed);
				//        subFolio.Ledger = oFolioFACADE.GetFolioLedger(coFolio.FolioID, subFolio.SubFolio_Renamed);

				//        totalSales += (double)(subFolio.Ledger.PayCash + subFolio.Ledger.PayCard + subFolio.Ledger.PayCheque + subFolio.Ledger.PayGiftCheque + subFolio.Ledger.BalanceForwarded);
				//        totalCharges += (double)subFolio.Ledger.Charges;
				//    }
				//}
				//catch
				//{ }

				//switch (coFolio.AccountType)
				//{
				//    case "PERSONAL":
				//        try
				//        {
				//            oGuestFACADE = new GuestFacade();
				//            oGuestFACADE.setNoOfVisits(coFolio.AccountID);
				//            oGuestFACADE.updateAccountTotalSales(coFolio.AccountID, totalSales);
				//        }
				//        catch (Exception ex)
				//        {
				//            MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

				//        }

				//        break;

				//    case "CORPORATE":
				//        try
				//        {
				//            //if (coFolio.MasterFolio == "0" || coFolio.MasterFolio == "")
				//            if (coFolio.CompanyID.Trim().Length > 0)
				//            {

				//                oCompanyFACADE = new CompanyFacade();

				//                if (coFolio.Payment_Mode == "EX-DEAL")
				//                {
				//                    oCompanyFACADE.deductXDealAmount(coFolio.CompanyID, totalCharges);
				//                }


				//                oCompanyFACADE.updateAccountTotalSales(coFolio.CompanyID, totalSales);
				//                // dont include no of visits
				//                //oCompanyFACADE.setNoOfVisits(coFolio.CompanyID);

				//            }
				//        }
				//        catch (Exception ex)
				//        {
				//            MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

				//        }
				//        break;


				//}

				//oRoomEventFacade.SetRoomEventType(ref oRoomEvents, mfolioid);

				//oRoomFacade = new RoomFacade();

				//// this is added for early CHECK-OUT
				////Schedule oSchedule = new Schedule();
				//ScheduleFacade oScheduleFacade = new ScheduleFacade();

				//oSchedule = oScheduleFacade.GetSchedule(mfolioid);
				//string roomId = "";
				////DateTime toDate = DateTime.Now;

				//foreach (DataRow dtRow in oSchedule.Tables[0].Rows)
				//{
				//    roomId = dtRow["RoomId"].ToString();
				//    //toDate = DateTime.Parse( dtRow["To"].ToString() );
				//}

				//// >> set room as dirty
				//roomId = this.txtRoomID.Text;

				//oRoomFacade = new RoomFacade();
				//oRoomFacade.setRoomStatus(roomId, "VACANT");
				//oRoomFacade.setRoomCleaningStatus(roomId, "DIRTY");

				//oScheduleFacade.setScheduleEarlyCheckOut(mfolioid, roomId);

			}
			
			private bool dependentSettled()
			{
				//Dim lvwChild As ListViewItem
				//For Each lvwChild In Me.lvwChildFolio.Items
				//    If Not lvwChild.Checked Then
				//        Return False
				//        Exit Function
				//    End If
				//Next
				//Return True
				return false;
			}

			private void btnCheckOutGroup_Click(System.Object sender, System.EventArgs e)
			{
				// If dependentSettled() Then
				// If oFolio.Charges - oFolio.Payments = 0 Then
				//        Me.setCheckedOut(oFolio, localConnection)
				//        MsgBox("Group has been Successfully CLOSED")
				//        Me.Close()
				//        Dim folioTransFacade As New Jinisys.Hotel.Reservation.BusinessLayer.FolioTransactionFACADE(localConnection)
				//        folioTransFacade.PostToLedger(oFolio.FolioID)
				
				//        Dim reportViewer As New Jinisys.Hotel.Reports.Presentation.ReportViewerUI
				//        Dim reportFacade As New Jinisys.Hotel.Reports.BusinessLayer.ReportFacade(localConnection)
				//        reportViewer.rptViewer.ReportSource = reportFacade.GetIndividualGuestBill(oFolio.FolioID)
				//        reportViewer.MdiParent = Me.MdiParent
				//        reportViewer.Show()
				//        reportViewer.rptViewer.PrintReport()
				//        reportViewer.Close()
				
				//        Me.lvwChildFolio.Items.Clear()
				//    'End If
				//Else
				//    MsgBox("All dependent folio must all be settled first before a group can be checked-out!")
				//End If
			}
			
			private void btnCheckOutSingle_Click(System.Object sender, System.EventArgs e)
			{
                string _guestName = txtGuestName.Text;
                if (_guestName == "")
                    _guestName = txtGroup_CompanyName.Text;
                DialogResult rsp = MessageBox.Show("You are about to check out '" + _guestName + "'.\r\n\r\nDo you want to continue?", "Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rsp == DialogResult.No)
                {
                    return;
                }

                btnProceedCheckOut();
            }

			public bool hasPassedRequiredTransaction()
			{
				// check if Arrival Date is equal to AuditDate(Today)
				// if EQUAL check if has insert at least 1 ROOM CHARGE

				// if config requires no transaction b4 checkout, return true;
				if (ConfigVariables.gTransactionRequiredUponCheckOut == "NONE")
				{
					return true;

				}//end if

				string[] _transRequired;
				try
				{
					_transRequired = ConfigVariables.gTransactionRequiredUponCheckOut.Split(',');

					if (_transRequired.Length <= 0)
						return true;
				}
				catch
				{
					return true;
				}

				oFolio.CreateSubFolio();
				TransactionCode _oTranCode = new TransactionCode();

				bool _passed = false;
				foreach (string _strCode in _transRequired)
				{
					string _tranCode = _strCode.Trim();

					//>> if TransactionCode is "" then return true
					if (_tranCode == "")
						return true;

					//>> check if Transaction Code is a valid Trancode
					
					try
					{
						TransactionCodeFacade _oTransactionCodeFacade = new TransactionCodeFacade();
						_oTranCode = _oTransactionCodeFacade.getTransactionCode(_tranCode);
					}
					catch
					{
						return true;
					}

					//>> if not valid Transaction then return TRUE.
					if(_oTranCode == null)
						return true;


					_passed = false;

					foreach (SubFolio subF in oFolio.SubFolios)
					{

						subF.Folio.FolioTransactions = oFolioFACADE.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
						subF.Ledger = oFolioFACADE.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);


						foreach (FolioTransaction _oFolioTransaction in subF.Folio.FolioTransactions)
						{
							if (_oFolioTransaction.TransactionCode == _tranCode)
							{
								_passed = true;
                                //break;
							}
						}

                        //if (_passed)
                        //    break;
					}

				}

				
				if (_passed)
					return true;


				MessageBox.Show("Transaction failed.\r\nA guest should have at least One(1) " + _oTranCode.Memo  +  " transaction.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			public void btnProceedCheckOut()
            {
                try
                {
                    // this is for INDIVIDUAL FOLIO
                    if (this.tabCheckout.SelectedIndex == 0)
                    {

                        //asdfasdf
                        if (!hasPassedRequiredTransaction())
                            return;

                        // till here


                        decimal _subFolioABalance = 0;
                        decimal _subFolioBBalance = 0;
                        decimal _subFolioCBalance = 0;
                        decimal _subFolioDBalance = 0;


                        _subFolioABalance = decimal.Parse(this.lblTotalBalanceA.Text);
                        _subFolioBBalance = decimal.Parse(this.lblTotalBalanceB.Text);
                        _subFolioCBalance = decimal.Parse(this.lblTotalBalanceC.Text);
                        _subFolioDBalance = decimal.Parse(this.lblTotalBalanceD.Text);


                        // SUB FOLIO D [check if has balance]
                        if (_subFolioDBalance != 0)
                        {
                            MessageBox.Show("Can't proceed check out!\r\nPlease settle payable amount in Sub-Folio D", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.tabSubFolio.SelectedIndex = 3;
                            return;
                        }
                        // SUB FOLIO C [check if has balance]
                        if (_subFolioCBalance != 0)
                        {
                            MessageBox.Show("Can't proceed check out!\r\nPlease settle payable amount in Sub-Folio C", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.tabSubFolio.SelectedIndex = 2;
                            return;
                        }
                        // SUB FOLIO B [check if has balance]
                        if (_subFolioBBalance != 0)
                        {
                            MessageBox.Show("Can't proceed check out!\r\nPlease settle payable amount in Sub-Folio B", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.tabSubFolio.SelectedIndex = 1;
                            return;
                        }

                        // check if balance > 0
                        if (_subFolioABalance != 0)
                        {
                            MessageBox.Show("Check-out not allowed when remaining balance is not zero!", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.tabSubFolio.SelectedIndex = 0;
                            return;
                        }


                        decimal _balanceForwardedSubFolioA = 0;
                        decimal _balanceForwardedSubFolioB = 0;
                        decimal _balanceForwardedSubFolioC = 0;
                        decimal _balanceForwardedSubFolioD = 0;

                        _balanceForwardedSubFolioA = decimal.Parse(this.lblBalanceForwardA.Text);
                        _balanceForwardedSubFolioB = decimal.Parse(this.lblBalanceForwardB.Text); ;
                        _balanceForwardedSubFolioC = decimal.Parse(this.lblBalanceForwardC.Text); ;
                        _balanceForwardedSubFolioD = decimal.Parse(this.lblBalanceForwardD.Text); ;


                        if (oFolio.AccountID == "" || oFolio.AccountID == ConfigVariables.gDefault_Guest)
                        {
                            MessageBox.Show("Can't proceed check-out.\r\nPlease assign a valid account id for this guest.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tabSubFolio.SelectedIndex = 0;
                            return;
                        }

                        //>> check if has BalanceForwarded amount in sub-folioB 
                        if (_balanceForwardedSubFolioB != 0 && this.txtCompanyId.Text == "")
                        {
                            MessageBox.Show("Please assign Company ID for 'Sub-Folio B'", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tabSubFolio.SelectedIndex = 1;
                            this.txtCompanyId.Focus();
                            return;
                        }
                        else if (this.txtCompanyId.Text != "")
                        {
                            // >> update folio ledger 'sub folio b' here
                            oFolioFACADE = new FolioFacade();
                            oFolioFACADE.UpdateFolioLedger(this.txtFolioId.Text, "B", this.txtCompanyId.Text);
                        }

                        //>> check if has BalanceForwarded amount in sub-folioC
                        if (_balanceForwardedSubFolioC != 0 && this.txtAccountIdC.Text == "")
                        {
                            MessageBox.Show("Please assign Account ID for 'Sub-Folio C'", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tabSubFolio.SelectedIndex = 2;
                            this.txtAccountIdC.Focus();
                            return;
                        }

                        else if (this.txtAccountIdC.Text != "")
                        {
                            // >> update folio ledger 'sub folio b' here
                            oFolioFACADE = new FolioFacade();
                            oFolioFACADE.UpdateFolioLedger(this.txtFolioId.Text, "C", this.txtAccountIdC.Text);
                        }

                        //>> check if has BalanceForwarded amount in sub-folioD
                        if (_balanceForwardedSubFolioD != 0 && this.txtAccountIdD.Text == "")
                        {
                            MessageBox.Show("Please assign Account ID for 'Sub-Folio D'", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tabSubFolio.SelectedIndex = 3;
                            this.txtAccountNameD.Focus();
                            return;

                        }
                        else if (this.txtAccountIdD.Text != "")
                        {
                            // >> update folio ledger 'sub folio b' here
                            oFolioFACADE = new FolioFacade();
                            oFolioFACADE.UpdateFolioLedger(this.txtFolioId.Text, "D", this.txtAccountIdD.Text);
                        }

                        try
                        {
                            string _folioId = this.txtFolioId.Text;
                            string _roomNo = this.txtRoomID.Text;
                            string _remarks =  this.txtRemarks.Text;

                            //jc 9.28.09
                            MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
                            try
                            {
                                GlobalFunctions.protectFolioID(_folioId, ref _oTrans);           //jc 9.2.09

                                oFolioFACADE = new FolioFacade();
                                oFolioFACADE.checkOutFolio(_folioId, _roomNo, _remarks);

                                FolioTransactionFacade folioTransFacade = new FolioTransactionFacade();
                                folioTransFacade.PostToLedger(oFolio);

                                updateCurrentDayRoomStatus();
                                MessageBox.Show("Closing Event process successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                btnViewBill_Click(this, new EventArgs());

                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                _oTrans.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Check-out failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                    }

                //>> this is for GROUP CHECK OUT
                    else
                    {
                        EventFacade _oEventFacade = new EventFacade();
                        bool _isGroupPackagePosted = _oEventFacade.isGroupPackagePosted(oGroupFolio.FolioID);
                        if (_isGroupPackagePosted == false)
                        {
                            DialogResult _postedRsp = MessageBox.Show("Group packages are not yet posted.\r\n\r\nDo you want to post now?", "Post Charges", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (_postedRsp == DialogResult.Yes)
                            {
                                PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
                                if (oPostRoomChargeFacade.initializePostRoomCharges(oGroupFolio.FolioID) == true)
                                {
                                    MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                return;
                            }
                        }

                        if (AllItemsCheckedInLvwChild())
                        {
                            if (System.Convert.ToDecimal(this.lblGrpTotalBalance.Text) <=0)
                            {
                                //Kevin Oliveros
                                if (System.Convert.ToDecimal(this.lblGrpTotalBalance.Text) <0)
                                {
                                    MessageBox.Show("An overdue payment occured", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                FolioTransactionFacade folioTransFacade = new FolioTransactionFacade();

                                Folio childF;
                                foreach (Folio tempLoopVar_childF in oGroupFolio.ChildFolios)
                                {
                                    childF = tempLoopVar_childF;
                                    if (childF.Status == "ONGOING")
                                    {
                                        this.setCheckedOut(childF.FolioID);
                                    }
                                    folioTransFacade.PostToLedger(childF);
                                }

                                this.setCheckedOut(oGroupFolio.FolioID);

                                folioTransFacade.PostToLedger(oGroupFolio);

                                MessageBox.Show("Check-out process successful \r\n Thank you.", "Check Out Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                updateCurrentDayRoomStatus();
                                btnViewBill_Click(this, new EventArgs());

                                this.Close();
                            }
                            else 
                            {
                                MessageBox.Show("Cannot proceed checkout! \r\n Please settle group balance first.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Cannot process check out. \r\n\r\nThere are still group blockings and ONGOING dependents \r\nor schedules and balances of dependents has not been settled yet.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

			private void updateCurrentDayRoomStatus()
			{
				try
				{
					Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
					MethodInfo[] objMethods = objectType.GetMethods();
					MethodInfo method;
					foreach (MethodInfo tempLoopVar_method in objMethods)
					{
						method = tempLoopVar_method;
						if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
						{
							method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
						}
					}
				}
				catch { }
			}


			private void btnViewBill_Click(System.Object sender, System.EventArgs e)
			{
				if (this.tabCheckout.SelectedIndex == 0) // if the first tab selected
				{
					if (! this.txtFolioId.Text.Equals("") )
					{
                        //this.MdiParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						
						reportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
						reportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
						
						string folioId = this.txtFolioId.Text;

                        if (bool.Parse(ConfigVariables.gFolioPrintOutWithTax) == true)
                        {
                            reportViewerUI.rptViewer.ReportSource = reportFacade.getIndividualGuestBill(folioId, "A");
                        }
                        else
                        {
                            reportViewerUI.rptViewer.ReportSource = reportFacade.getIndividualGuestBillWithoutTax(folioId, "A");
                        }
                        
						reportViewerUI.MdiParent = this.MdiParent;
						reportViewerUI.Show();
					}
				}
				else //second tab selected
				{
                    //this.MdiParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					ReportViewer reportViewerUI = new ReportViewer();
					ReportFacade reportFacade = new ReportFacade();
                    if (ConfigVariables.gGuestSOA == "PICC")
                    {
                        pnlRemarks.BringToFront();
                        pnlRemarks.Visible = true;
                    }
                    else
                    {
                        reportViewerUI.rptViewer.ReportSource = reportFacade.getCompanyBill(this.txtGroupFolioId.Text);
                        reportViewerUI.MdiParent = this.MdiParent;
                        reportViewerUI.Show();
                    }

				}
			}

			private void btnPayment_Click(System.Object sender, System.EventArgs e)
			{
				showAddTransactionUI("Payments");
			}

			/// <summary>
			/// showAddTransactionUI
			/// displays AddTransaction UI
			/// </summary>
			/// <param name="pTransactionFilter">possible values would be Payments or All</param>
			public void showAddTransactionUI(string pTransactionFilter)
			{
				// this is to trace all folio transactions
				// checks if has opened cash drawer / shift
                //Kevin Oliveros
                //if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
                //{
                //    MessageBox.Show("Can't proceed transaction.\r\nNo Shift/Cash drawer open.\r\n\r\nTo Open Shift/Cash Drawer goto Transactions menu, Cashiering->Open Shift/Cash drawer.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

				string subFolioTab = "";
				switch (this.tabSubFolio.SelectedIndex)
				{
					case 0:
						subFolioTab = "A";
						break;
					case 1:
						subFolioTab = "B";
						break;

					case 2:
						subFolioTab = "C";
						break;

					case 3:
						subFolioTab = "D";
						break;
				}

				if (this.tabCheckout.SelectedIndex == 0)
				{
					AddTransactionUI AddTransaction = new AddTransactionUI(oFolio, this.txtRoomID, subFolioTab, pTransactionFilter);
					AddTransaction.ShowDialog(this);
				}
				else
				{
					if (oGroupFolio.FolioID == null)
					{
						this.txtGroupName.Focus();
						return;
					}

					AddTransactionUI AddTransaction = new AddTransactionUI(oGroupFolio, this.txtGroupFolioId, subFolioTab, pTransactionFilter);
					AddTransaction.ShowDialog(this);
				}

			}

			public void CheckOutUI_Activated(object sender, System.EventArgs e)
			{
				//updateCharges()
				this.WindowState = FormWindowState.Maximized;	
			}

			public void updateCharges()
			{
				//Try
				//    If Not Me.txtFolioID.Text = "" Then
				//        txtFolioID_TextChanged(Nothing, Nothing)
				//        oFolio.Charges = oFolioFACADE.ComputeCharges(oFolio)
				//        oFolio.Payments = oFolioFACADE.ComputePayments(oFolio)
				//        Me.txtCharge.Text = Format(oFolio.Charges, GlobalVariables.gCurrencyFormat)
				//        Me.txtPayment.Text = Format(oFolio.Payments, GlobalVariables.gCurrencyFormat)
				//        Me.txtNetBalance.Text = Format(oFolio.Charges - oFolio.Payments, GlobalVariables.gCurrencyFormat)
				
				//    End If
				//    If Not Me.txtGroupFolioID.Text = "" Then
				
				//        ' Me.txtGroupFolioID.Text = mgrpID
				//        oFolio.Charges = oFolioFACADE.ComputeCharges(oFolio)
				//        oFolio.Payments = oFolioFACADE.ComputePayments(oFolio)
				//        Me.txtGrpCharges.Text = Format(oFolio.Charges, GlobalVariables.gCurrencyFormat)
				//        Me.txtGrpPayments.Text = Format(oFolio.Payments, GlobalVariables.gCurrencyFormat)
				//        Me.txtGrpNetBalance.Text = Format(oFolio.Charges - oFolio.Payments, GlobalVariables.gCurrencyFormat)
				//        txtGroupFolioID_TextChanged(Nothing, Nothing)
				//    End If
				//Catch ex As NullReferenceException
				//    Exit Sub
				//End Try
			}

			private void btnSingleCancel_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
			
			private void btnGroupCancel_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
			
			private void btnGroupBill_Click(System.Object sender, System.EventArgs e)
			{
				if ( this.txtGroupFolioId.Text != "") 
                {
				    ReportViewer reportViewerUI = new ReportViewer();
				    ReportFacade reportFacade = new ReportFacade();

                    reportViewerUI.rptViewer.ReportSource = reportFacade.getIndividualGuestBill(this.txtGroupFolioId.Text, "B");

                    reportViewerUI.MdiParent = this.MdiParent;
				    reportViewerUI.Show();
				}
			}

			private void btnGroupPayment_Click(System.Object sender, System.EventArgs e)
			{
				//If Me.txtGroupFolioID.Text <> "" Then
				//    AddTransactionUI.Flag = "New"
				//    Dim AddTransaction As New AddTransactionUI(localConnection, txtGroupFolioID)
				//    AddTransaction.ShowDialog()
				//Else
				//    MsgBox("No Group Selected")
				//End If
			}
		
			private void txtHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}

			private void noHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = false;
			}
			
			private void CheckOutUI_Load(object sender, System.EventArgs e)
			{
				this.Top = 0;
				this.Left = 0;
				// close all form, so you can't alter a checked-out Guest
				try
				{
					Form mdi = (Form)GlobalVariables.gMDI;
					Form[] children = mdi.MdiChildren;

					foreach (Form _childForm in children)
					{
						if (_childForm.Name != this.Name)
						{
							_childForm.Close();
						}
					}

                    //jlo 6-10-10 emm only config
                    if (ConfigVariables.gIsEMMOnly == "true")
                    {
                        this.tabGroupCheckOut.Controls.Remove(this.TabPage6);
                    }
                    //jlo
				}
				catch { }



			}

			private void showLedgerA(FolioTransactionLedger fLedger)
			{
				this.lblTotalChargesA.Text = fLedger.Charges.ToString("N");
				this.lblTotalDiscountA.Text = fLedger.Discount.ToString("N");
				this.lblCashPaymentA.Text = fLedger.PayCash.ToString("N");
				this.lblChargePaymentA.Text = fLedger.PayCard.ToString("N");
				this.lblChequePaymentA.Text = fLedger.PayCheque.ToString("N");
				this.lblGiftChequePaymentA.Text = fLedger.PayGiftCheque.ToString("N");
				this.lblTotalBalanceA.Text = fLedger.BalanceNet.ToString("N");
				this.lblBalanceForwardA.Text = fLedger.BalanceForwarded.ToString("N");
				this.lblTotalBalanceA.Text = fLedger.BalanceNet.ToString("N");
				this.lblGovtTaxA.Text = fLedger.GovernmentTax.ToString("N");
				this.lblLocalTaxA.Text = fLedger.LocalTax.ToString("N");
				this.lblCommissionA.Text = fLedger.AgentComission.ToString("N");
				this.lblServiceChargeA.Text = fLedger.ServiceCharge.ToString("N");
			}

			private void showLedgerB(FolioTransactionLedger fLedger)
			{
				this.lblTotalChargesB.Text = fLedger.Charges.ToString("N");
				this.lblTotalDiscountB.Text = fLedger.Discount.ToString("N");
				this.lblCashPaymentB.Text = fLedger.PayCash.ToString("N");
				this.lblChargePaymentB.Text = fLedger.PayCard.ToString("N");
				this.lblChequePaymentB.Text = fLedger.PayCheque.ToString("N");
				this.lblGiftChequePaymentB.Text = fLedger.PayGiftCheque.ToString("N");
				this.lblTotalBalanceB.Text = fLedger.BalanceNet.ToString("N");
				this.lblBalanceForwardB.Text = fLedger.BalanceForwarded.ToString("N");
				this.lblTotalBalanceB.Text = fLedger.BalanceNet.ToString("N");
				this.lblGovtTaxB.Text = fLedger.GovernmentTax.ToString("N");
				this.lblLocalTaxB.Text = fLedger.LocalTax.ToString("N");
				this.lblCommissionB.Text = fLedger.AgentComission.ToString("N");
				this.lblServiceChargeB.Text = fLedger.ServiceCharge.ToString("N");
			}

			private void showLedgerC(FolioTransactionLedger fLedger)
			{
				this.lblTotalChargesC.Text = fLedger.Charges.ToString("N");
				this.lblTotalDiscountC.Text = fLedger.Discount.ToString("N");
				this.lblCashPaymentC.Text = fLedger.PayCash.ToString("N");
				this.lblChargePaymentC.Text = fLedger.PayCard.ToString("N");
				this.lblChequePaymentC.Text = fLedger.PayCheque.ToString("N");
				this.lblGiftChequePaymentC.Text = fLedger.PayGiftCheque.ToString("N");
				this.lblTotalBalanceC.Text = fLedger.BalanceNet.ToString("N");
				this.lblBalanceForwardC.Text = fLedger.BalanceForwarded.ToString("N");
				this.lblTotalBalanceC.Text = fLedger.BalanceNet.ToString("N");
				this.lblGovtTaxC.Text = fLedger.GovernmentTax.ToString("N");
				this.lblLocalTaxC.Text = fLedger.LocalTax.ToString("N");
				this.lblCommissionC.Text = fLedger.AgentComission.ToString("N");
				this.lblServiceChargeC.Text = fLedger.ServiceCharge.ToString("N");
			}

			private void showLedgerD(FolioTransactionLedger fLedger)
			{
				this.lblTotalChargesD.Text = fLedger.Charges.ToString("N");
				this.lblTotalDiscountD.Text = fLedger.Discount.ToString("N");
				this.lblCashPaymentD.Text = fLedger.PayCash.ToString("N");
				this.lblChargePaymentD.Text = fLedger.PayCard.ToString("N");
				this.lblChequePaymentD.Text = fLedger.PayCheque.ToString("N");
				this.lblGiftChequePaymentD.Text = fLedger.PayGiftCheque.ToString("N");
				this.lblTotalBalanceD.Text = fLedger.BalanceNet.ToString("N");
				this.lblBalanceForwardD.Text = fLedger.BalanceForwarded.ToString("N");
				this.lblTotalBalanceD.Text = fLedger.BalanceNet.ToString("N");
				this.lblGovtTaxD.Text = fLedger.GovernmentTax.ToString("N");
				this.lblLocalTaxD.Text = fLedger.LocalTax.ToString("N");
				this.lblCommissionD.Text = fLedger.AgentComission.ToString("N");
				this.lblServiceChargeD.Text = fLedger.ServiceCharge.ToString("N");
			}

			private void txtRoomID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				try
				{
					if (e.KeyChar == '\r')
					{

						oFolioFACADE = new FolioFacade();

						if (this.txtFolioId.Text == "")
						{
							oFolio = oFolioFACADE.GetFolioByRoomID(this.txtRoomID.Text);
						}
						else
						{
							oFolio = oFolioFACADE.GetFolio(this.txtFolioId.Text);
						}

						if (oFolio != null)
						{
							// this is added to TRAP checkout of GUEST that is Still RESERVED
							// 13-Dec-2006
							// jrom
							///////////////////////Code to Trap textchange Event//////////////
							if (oFolio.FolioID.Trim() != "")
							{
								if (oFolio.Status != "ONGOING")
								{
									MessageBox.Show(" Guest has not ONGOING \r\n Can't proceed check out", "Invalid Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
									this.txtRoomID.Text = "";
									return;
								}
							}

							oGuestFACADE = new GuestFacade();
							oGuest = oGuestFACADE.getGuestRecord(oFolio.AccountID);
							this.txtFolioId.Text = oFolio.FolioID;
							this.txtCompanyId.Text = oFolio.CompanyID;
							this.txtRemarks.Text = oFolio.Remarks;
							oCompanyFACADE = new CompanyFacade();
							oCompany = oCompanyFACADE.getCompanyAccount(oFolio.CompanyID);
							//this.lblCompanyName.Text = oCompany.CompanyName;
                            //this.txtCompanyName.Text = oCompany.CompanyName;

							this.txtGuestName.Text = oGuest.LastName + " , " + oGuest.FirstName;
							this.txtGuestName.Tag = oGuest.AccountId;
							this.txtAccount_Type.Text = oFolio.AccountType;
							this.txtPayment_Mode.Text = oFolio.Payment_Mode;

							this.txtArrivalDate.Text = oFolio.FromDate.ToString("dd-MMM-yyyy");
							this.txtDepartureDate.Text = oFolio.Todate.ToString("dd-MMM-yyyy");

							//this.lblGuestAddress.Text = oGuest.Street + " " + oGuest.City + " " + oGuest.Country;
							decimal totalCharges = 0;
							decimal totalPayments = 0;
							decimal balance = 0;


							oFolio.CreateSubFolio();
							SubFolio subF;
							foreach (SubFolio tempLoopVar_subF in oFolio.SubFolios)
							{
								subF = tempLoopVar_subF;
								subF.Folio.FolioTransactions = oFolioFACADE.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
								subF.Ledger = oFolioFACADE.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
								switch (subF.SubFolio_Renamed)
								{
									case "A":

										loadDataInListView(subF.Folio.FolioTransactions, this.lvwSubFolioA);
										showLedgerA(subF.Ledger);
										break;
									case "B":

										loadDataInListView(subF.Folio.FolioTransactions, this.lvwSubFolioB);
										showLedgerB(subF.Ledger);
										break;
									case "C":

										loadDataInListView(subF.Folio.FolioTransactions, this.lvwSubFolioC);
										showLedgerC(subF.Ledger);
										break;

									case "D":

										loadDataInListView(subF.Folio.FolioTransactions, this.lvwSubFolioD);
										showLedgerD(subF.Ledger);
										break;
								}


								totalCharges += subF.Ledger.Charges;
								totalPayments += (subF.Ledger.PayCard + subF.Ledger.PayCash + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded);
								balance += subF.Ledger.BalanceNet;

							}


							this.txtTotalCharges.Text = totalCharges.ToString("N");
							this.txtTotalPayment.Text = totalPayments.ToString("N");
							this.txtBalance.Text = balance.ToString("N");


						}

					}

					//}
				}
				catch (Exception)
				{

				}
			}
			
			private void lblGrpFolioID_TextChanged(object sender, System.EventArgs e)
			{
				loadconnectionStrings();
				if (this.txtGroupFolioId.Text != "")
				{
					oGroupFolio = oFolioFACADE.GetFolio(this.txtGroupFolioId.Text);
					this.txtGroupName.Text = oGroupFolio.GroupName;

					this.txtArrivalDate.Text = oGroupFolio.FromDate.ToString("dd-MMM-yyyy");
					this.txtDepartureDate.Text = oGroupFolio.Todate.ToString("dd-MMM-yyyy");

					this.txtGroupAccountType.Text = oGroupFolio.AccountType;
					this.txtGroupPaymentMode.Text = oGroupFolio.Payment_Mode;

					FolioTransactionFacade oFolioTransFacade = new FolioTransactionFacade();
					oGroupFolio.ChildFolios = oFolioFACADE.GetChildFolios(oGroupFolio.FolioID);
					Jinisys.Hotel.Reservation.BusinessLayer.Folio childFolio;
					this.lvwChildFolio.Items.Clear();

					decimal totalChildFolioCharges = 0;
					decimal totalChildFolioPayments = 0;
					decimal totalChildFolioCurrentBalance = 0;
                    decimal totalChildFolioCashPayment = 0;
                    decimal totalChildFolioCardPayment = 0;
                    decimal totalChildFolioChequePayment = 0;
                    decimal totalChildFolioGiftChequePayment = 0;
                    decimal totalChildFolioBalanceForward = 0;


					foreach (Folio tempLoopVar_childFolio in oGroupFolio.ChildFolios)
					{
						childFolio = tempLoopVar_childFolio;

                        if (childFolio.Status == "ONGOING" || childFolio.Status == "CONFIRMED" || childFolio.Status == "TENTATIVE")
                        {
                            childFolio.CreateSubFolio();
                            SubFolio subF = null;

                            decimal totalChildSubFolioCharges = 0;
                            decimal totalChildSubFolioPayments = 0;
                            decimal balance = 0;
                            foreach (SubFolio tempLoopVar_subF in childFolio.SubFolios)
                            {
                                subF = tempLoopVar_subF;
                                subF.Ledger = oFolioFACADE.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                                totalChildFolioCharges += subF.Ledger.Charges;
                                totalChildFolioCashPayment += subF.Ledger.PayCash;
                                totalChildFolioCardPayment += subF.Ledger.PayCard;
                                totalChildFolioChequePayment += subF.Ledger.PayCheque;
                                totalChildFolioGiftChequePayment += subF.Ledger.PayGiftCheque;
                                totalChildFolioBalanceForward += subF.Ledger.BalanceForwarded;
                                totalChildFolioPayments += subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded;

                                totalChildSubFolioCharges += subF.Ledger.Charges;
                                totalChildSubFolioPayments += subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded;
                                balance = totalChildSubFolioCharges - totalChildSubFolioPayments;

                                totalChildFolioCurrentBalance += subF.Ledger.Charges - (subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded);
                            }

                            string Guestname = oScheduleFACADE.GetGuest(childFolio.AccountID);
                            string Rooms = oScheduleFACADE.GetRoomFromSchedules(childFolio.FolioID);
                            ListViewItem lvwItem = new ListViewItem();
                            lvwItem.Text = Rooms.Substring(0, Rooms.Length - 2);
                            lvwItem.SubItems.Add(Guestname);
                            lvwItem.SubItems.Add(childFolio.FolioID);
                            lvwItem.SubItems.Add(totalChildSubFolioCharges.ToString("N"));
                            lvwItem.SubItems.Add(totalChildSubFolioPayments.ToString("N"));
                            lvwItem.SubItems.Add(balance.ToString("N"));
                            lvwItem.SubItems.Add(totalChildFolioCurrentBalance.ToString("N"));

                            lvwItem.SubItems.Add(childFolio.Status);
                            this.lvwChildFolio.Items.Add(lvwItem);
                        }

					}

                    //>>display blocked rooms also
                    GenericList<RoomBlock> _oRoomBlock = new GenericList<RoomBlock>();
                    RoomBlockFacade _oRoomblockFacade = new RoomBlockFacade();
                    _oRoomBlock = _oRoomblockFacade.getBlockedRoomsForEvent(txtGroupFolioId.Text);
                    foreach (RoomBlock pRoomblock in _oRoomBlock)
                    {
                        ListViewItem _listViewItem = new ListViewItem();
                        _listViewItem.Text = pRoomblock.RoomID;
                        _listViewItem.SubItems.Add("BLOCKED");

                        lvwChildFolio.Items.Add(_listViewItem);
                    }

					oGroupFolio.CreateSubFolio();
					
					SubFolio parentSubF;
					
					SubFolio _subFolio = oGroupFolio.SubFolios.Item(0);

					_subFolio.Folio.FolioTransactions = oFolioFACADE.GetFolioTransactions(oGroupFolio.FolioID, "A");
					_subFolio.Ledger = oFolioFACADE.GetFolioLedger(oGroupFolio.FolioID, "A");

					loadDataInListView(_subFolio.Folio.FolioTransactions, this.lvwGroupFolioA);
						

					foreach (SubFolio tempLoopVar_parentSubF in oGroupFolio.SubFolios)
					{
						parentSubF = tempLoopVar_parentSubF;
						if (parentSubF.SubFolio_Renamed == "A")
						{
							parentSubF.Ledger = oFolioFACADE.GetFolioLedger(parentSubF.Folio.FolioID, parentSubF.SubFolio_Renamed);
                            this.lblGrpTotalCharge.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.Charges + totalChildFolioCharges);
							this.lblGrpTotalDisCount.Text = parentSubF.Ledger.Discount.ToString();
                            this.lblGrpCashPayment.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.PayCash + totalChildFolioCashPayment);
                            this.lblGrpChargePayment.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.PayCard + totalChildFolioCardPayment);
                            this.lblGrpChequePayment.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.PayCheque + totalChildFolioGiftChequePayment);
                            this.lblGrpGiftChequePayment.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.PayGiftCheque + totalChildFolioGiftChequePayment);
                            this.lblGrpTotalBalance.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.BalanceNet + (totalChildFolioCurrentBalance));
                            this.lblGrpBalanceForwarded.Text = string.Format("{0:###,##0.#0}", parentSubF.Ledger.BalanceForwarded + totalChildFolioBalanceForward);
							this.lblGrpTotalNet.Text = parentSubF.Ledger.TotalNet.ToString();
							this.lblGrpGovTax.Text = parentSubF.Ledger.GovernmentTax.ToString();
							this.lblGrpLocalTax.Text = parentSubF.Ledger.LocalTax.ToString();
							this.lblGrpCommission.Text = parentSubF.Ledger.AgentComission.ToString();
							this.lblGrpSrvChrg.Text = parentSubF.Ledger.ServiceCharge.ToString();
						}

						totalChildFolioCharges += parentSubF.Ledger.Charges;
						totalChildFolioPayments += (parentSubF.Ledger.PayCard + parentSubF.Ledger.PayCash + parentSubF.Ledger.PayCheque + parentSubF.Ledger.PayGiftCheque + parentSubF.Ledger.BalanceForwarded);
						totalChildFolioCurrentBalance += parentSubF.Ledger.BalanceNet;
					}


					this.txtGrpTotalCharges.Text = totalChildFolioCharges.ToString("N");
					this.txtGrpTotalPayment.Text = totalChildFolioPayments.ToString("N");
					this.txtGrpBalance.Text = totalChildFolioCurrentBalance.ToString("N");

				}
				//Catch ex As Exception
				//    oGroupFolio = Nothing
				//    Exit Sub
				//End Try
			}
			
			private void btnLookUp_Click(System.Object sender, System.EventArgs e)
			{
				loadList(0);
			}

			DataView dtView;
			public DataView getRec()
			{
                try
                {
                    string cmdText = "select folio.groupname,Company.Companyname,folio.folioid from Company,Folio  where Company.CompanyId = Folio.CompanyID AND Folio.Status=\'ONGOING\' and folio.foliotype='GROUP'";
                   
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdText,GlobalVariables.gPersistentConnection);
                    DataTable dt = new DataTable("LookUp");
                    da.Fill(dt);
					
                    DataView dtView = dt.DefaultView;
                    return dtView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
			}

			private void txtGroupName_TextChanged(System.Object sender, System.EventArgs e)
			{
				if (txtGroupName.Text.Length == 0)
				{
					this.lvwBrowseGroupName.Visible = false;
					return;
				}
			}

			private object loadList(byte filteFlag)
			{
				string filterValue;
				//Try
				if (lvwBrowseGroupName.Visible == false)
				{
					lvwBrowseGroupName.Visible = true;
				}
				
				if (dtView == null)
				{
					dtView = getRec();
				}
				filterValue = this.txtGroupName.Text.ToString().Replace("\'", "\'\'");
				if (filteFlag == 1)
				{
					dtView.RowStateFilter = DataViewRowState.OriginalRows;
					dtView.RowFilter = "GroupName like '" + filterValue + "%'";
					if (dtView.Count == 0)
					{
						dtView.RowFilter = "CompanyName like '" + this.txtGroupName.Text + "%'";
					}
				}
				
				DataRowView dtr;
				this.lvwBrowseGroupName.Items.Clear();
				foreach (DataRowView tempLoopVar_dtr in dtView)
				{
					dtr = tempLoopVar_dtr;
					ListViewItem li = new ListViewItem(dtr[0].ToString());
					li.SubItems.Add(dtr[1].ToString());
					li.SubItems.Add(dtr[2].ToString());
					this.lvwBrowseGroupName.Items.Add(li);
				}
				//Catch ex As Exception
				//    MsgBox()
				//End Try
				return null;
			}
			
			private void txtGroupName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Down)
				{
					this.lvwBrowseGroupName.Select();
				}
				else if (e.KeyCode == Keys.Escape)
				{
					this.lvwBrowseGroupName.Visible = false;
					return;
				}
				loadList(1);
			}

			private void assignTextBoxValue()
			{
				try
				{
					if (this.lvwBrowseGroupName.SelectedItems.Count > 0)
					{
						this.txtGroupName.Text = this.lvwBrowseGroupName.SelectedItems[0].Text;
						ListViewItem li = new ListViewItem();
						li = this.lvwBrowseGroupName.SelectedItems[0];
						this.txtGroupFolioId.Text = li.SubItems[2].Text;
						this.txtGroup_CompanyName.Text = li.SubItems[1].Text;
					}
					this.lvwBrowseGroupName.Items.Clear();
					this.lvwBrowseGroupName.Visible = false;
				}
				catch (Exception)
				{
					
				}
			}
			
			private void lvwBrowseGroupName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				
				if (e.KeyChar == '\r')
				{
					assignTextBoxValue();
				}
				
			}
			
			private void lvwBrowseGroupName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Escape)
				{
					this.lvwBrowseGroupName.Visible = false;
				}
			}
			
			private void lvwBrowseGroupName_DoubleClick(object sender, System.EventArgs e)
			{
				assignTextBoxValue();
			}

			private bool AllItemsCheckedInLvwChild()
			{
                
                //Folio childF;
				foreach (Folio childF in oGroupFolio.ChildFolios)
                {
                    //childF = tempLoopVar_childF;
                    try
                    {
                        foreach (SubFolio subFolio in childF.SubFolios)
                        {
                            if (subFolio.Ledger != null)
                            {
                                if (subFolio.Ledger.BalanceNet != 0)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    catch { }
                }

                //>>check if child is still ONGOING
                foreach (Folio _childFolio in oGroupFolio.ChildFolios)
                {
                    if (_childFolio.Status == "ONGOING")
                    {
                        return false;
                    }
                }

                //>>check for late check-outs
                foreach (Folio _childFolio in oGroupFolio.ChildFolios)
                {
                    string _departureDate = _childFolio.DepartureDate.ToString("yyyy-MM-dd");
                    if (DateTime.Parse(_departureDate) > DateTime.Parse(GlobalVariables.gAuditDate))
                    {
                        return false;
                    }
                }

                //>>check for blockings
                GenericList<RoomBlock> _oRoomBlock = new GenericList<RoomBlock>();
                RoomBlockFacade _oRoomblockFacade = new RoomBlockFacade();
                _oRoomBlock = _oRoomblockFacade.getBlockedRoomsForEvent(txtGroupFolioId.Text);
                if (_oRoomBlock.Count > 0)
                    return false;

				return true;
			}
			
			private void chkCheckAll_CheckedChanged(System.Object sender, System.EventArgs e)
			{
				if (chkCheckAll.Checked)
				{
					ListViewItem li;
					foreach (ListViewItem tempLoopVar_li in this.lvwChildFolio.Items)
					{
						li = tempLoopVar_li;
						if (System.Convert.ToDecimal(li.SubItems[5].Text) == 0)
						{
							li.Checked = true;
						}
						else
						{
							chkCheckAll.Checked = false;
							MessageBox.Show("Not all dependent folio has settled their account!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
				}
			}
			
			private void txtRoomID_TextChanged(System.Object sender, System.EventArgs e)
			{
				if (this.txtFolioId.Text != "")
				{
					txtRoomID_KeyPress(sender, new System.Windows.Forms.KeyPressEventArgs('\r'));
				}
			}
			
			private BrowseAccountUI browseAccountUI;
			private void btnBrowseCompany_Click(System.Object sender, System.EventArgs e)
			{
				browseAccountUI = new BrowseAccountUI(localConnection, "COMPANY", this.txtCompanyId, this.txtCompanyName);
				browseAccountUI.ShowDialog(this);
			}
			
			private void btnBrowseAccountC_Click(System.Object sender, System.EventArgs e)
			{
				browseAccountUI = new BrowseAccountUI(localConnection, "GUESTS", this.txtAccountIdC, this.txtAccountNameC);
				browseAccountUI.ShowDialog(this);
			}
			
			private void btnBrowseAccountD_Click(System.Object sender, System.EventArgs e)
			{
				browseAccountUI = new BrowseAccountUI(localConnection, "GUESTS", this.txtAccountIdD, this.txtAccountNameD);
				browseAccountUI.ShowDialog(this);
			}
			
			private void CheckOutUI_Closed(object sender, System.EventArgs e)
			{
				//if (folioClick == false)
				//{
				//    FolioLedgersUI FolioLedgersListUI = new FolioLedgersUI(localConnection);
				//    FolioLedgersListUI.MdiParent = this.MdiParent;
				//    FolioLedgersListUI.Show();
				//}
			}
			
			
			public void SaveEntry()
			{
				btnProceedCheckOut();
			}

            private void lvwChildFolio_ItemChecked(object sender, ItemCheckedEventArgs e)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem = (ListViewItem)lvwChildFolio.Items[e.Item.Index].Clone();

                if (e.Item.Checked == true)
                {
                    if (lvwItem.SubItems[5].Text != "")
                    {
                        if (Double.Parse(lvwItem.SubItems[5].Text) != 0)
                        {
                            //MessageBox.Show(" Dependent folio has not settled his/her account. \r\n Please settle account before checking out.", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //e.Item.Checked = false;
							this.btnTransferDebit.Enabled = true;
                        }
                    }
                }
            }

            bool folioClick = false;
            private void lvwChildFolio_DoubleClick(object sender, EventArgs e)
            {
                if (this.lvwChildFolio.SelectedItems.Count <= 0)
                {
                    return;
                }

                 if (this.lvwChildFolio.SelectedItems[0].SubItems[1].Text == "BLOCKED")
                {
                    GroupReservationUI _oGroupUI = new GroupReservationUI(txtGroupFolioId.Text);
                    _oGroupUI.MdiParent = this.MdiParent;
                    _oGroupUI.Show();

                    return;
                }
                else if (this.lvwChildFolio.SelectedItems[0].SubItems[7].Text == "CONFIRMED" || this.lvwChildFolio.SelectedItems[0].SubItems[7].Text == "TENTATIVE")
                {
                    ReservationFolioUI _oFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewChildFolio, this.lvwChildFolio.SelectedItems[0].SubItems[2].Text);
                    _oFolioUI.MdiParent = this.MdiParent;
                    _oFolioUI.Show();

                    return;
                }

                try
                {
                    string folioId = this.lvwChildFolio.SelectedItems[0].SubItems[2].Text;
                    folioClick = true;

                    CheckOutUI checkOutUI = new CheckOutUI(folioId);
                    checkOutUI.MdiParent = this.MdiParent;
                    checkOutUI.Show();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

			private void btnInsertCharges_Click(object sender, EventArgs e)
			{
				showAddTransactionUI("Charges");
			}

			
			private void mnuVoidTransaction_Click(object sender, EventArgs e)
			{
                // this is to trace all folio transactions
                if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
                {
                    MessageBox.Show("Can't proceed transaction.\r\nNo Shift/Cash drawer open.\r\n\r\nTo Open Shift/Cash Drawer goto Transactions menu, Cashiering->Open Shift/Cash drawer.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
				try
				{
					string vMemo = "";
					System.Drawing.Color lvwBackColor = System.Drawing.Color.White;


					FolioTransaction oFolioTransaction = new FolioTransaction();
					oFolioTransaction.HotelID = GlobalVariables.gHotelId;
					oFolioTransaction.FolioID = this.txtFolioId.Text;

					/* this has been added in order for SUBFOLIO B,C,D to be voided */

					switch (this.tabSubFolio.SelectedIndex)
					{
						case 0:
							vMemo = this.lvwSubFolioA.SelectedItems[0].SubItems[3].Text;
							lvwBackColor = this.lvwSubFolioA.SelectedItems[0].BackColor;

							oFolioTransaction.SubFolio = "A";
							break;
						case 1:
							vMemo = this.lvwSubFolioB.SelectedItems[0].SubItems[3].Text;
							lvwBackColor = this.lvwSubFolioB.SelectedItems[0].BackColor;

							oFolioTransaction.SubFolio = "B";
							break;
						case 2:
							vMemo = this.lvwSubFolioC.SelectedItems[0].SubItems[3].Text;
							lvwBackColor = this.lvwSubFolioC.SelectedItems[0].BackColor;

							oFolioTransaction.SubFolio = "C";
							break;
						case 3:
							vMemo = this.lvwSubFolioD.SelectedItems[0].SubItems[3].Text;
							lvwBackColor = this.lvwSubFolioD.SelectedItems[0].BackColor;

							oFolioTransaction.SubFolio = "D";
							break;
					}

					// this is to trap VOIDING TRANSACTIONS THAT ARE ALREADY
					// posted to ACCOUNTING...
					if (lvwBackColor == System.Drawing.Color.Gainsboro)
					{
						MessageBox.Show("Can't void this transaction.\r\nIt is already posted to accounting.", "Void Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}


					if (MessageBox.Show("Are you sure you want to Void transaction '" + vMemo + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
                        string _priv = "Void Folio Transaction";
                        VerifyUserUI oVerifyUserUI = new VerifyUserUI(_priv);
                        if (!oVerifyUserUI.showDialog())
                        {
                            // exit if not authorized to void
                            return;
                        }

						oFolioTransaction.AccountID = this.txtGuestName.Tag.ToString();

						FolioTransactionFacade oFolioTransFacade = new FolioTransactionFacade();

						string _folioTransactionNo = "";

						switch (this.tabSubFolio.SelectedIndex)
						{

							case 0:

								_folioTransactionNo = this.lvwSubFolioA.SelectedItems[0].SubItems[15].Text;

								break;
							case 1:

								_folioTransactionNo = this.lvwSubFolioB.SelectedItems[0].SubItems[15].Text;

								break;
							case 2:

								_folioTransactionNo = this.lvwSubFolioC.SelectedItems[0].SubItems[15].Text;

								break;
							case 3:

								_folioTransactionNo = this.lvwSubFolioD.SelectedItems[0].SubItems[15].Text;

								break;
						}

						oFolioTransaction.FolioTransactionNo = int.Parse(_folioTransactionNo);

						if (oFolioTransFacade.VoidFolioTransaction(oFolioTransaction, ref myTransaction))
						{
							myTransaction.Commit();
							
							string temp = this.txtFolioId.Text;
							this.txtFolioId.Text = "";
							this.txtFolioId.Text = temp;

							txtRoomID_KeyPress(sender, new KeyPressEventArgs('\r'));
						}
						else
						{
							myTransaction.Rollback();
						}
					}

				}
				catch (ArgumentOutOfRangeException)
				{
					MessageBox.Show("Please select an item on the list.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.tabSubFolio.SelectedIndex = 0;
					myTransaction.Rollback();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					myTransaction.Rollback();
				}
			}

			private void mnuRefreshLedger_Click(object sender, EventArgs e)
			{
				txtRoomID_KeyPress(sender, new KeyPressEventArgs('\r'));
			}

			private void mnuInsertPayment_Click(object sender, EventArgs e)
			{
				btnPayment_Click(sender, e);
			}

			private void mnuInsertCharges_Click(object sender, EventArgs e)
			{
				btnInsertCharges_Click(sender, e);
			}

			private void mnuPrintFolio_Click(object sender, EventArgs e)
			{
				btnViewBill_Click(sender, e);
			}

			private void btnTransferDebit_Click(object sender, EventArgs e)
			{
                if (this.tabCheckout.SelectedIndex == 0)
                {
                    string _roomNo = this.txtRoomID.Text;

                    if (oFolio.FolioType != "DEPENDENT")
                    {
                        TransferDebitUI _oTransferDebitUI = new TransferDebitUI(oFolio, _roomNo);
                        _oTransferDebitUI.ShowDialog();
                    }
                    else
                    {
                        Folio _oMasterFolio = new Folio();
                        FolioFacade _oFolioFacade = new FolioFacade();
                        _oMasterFolio = _oFolioFacade.GetFolio(oFolio.MasterFolio);

                        TransferDebitUI _oTransferDebitUI = new TransferDebitUI(oFolio, _roomNo, _oMasterFolio);
                        _oTransferDebitUI.ShowDialog();
                    }

                    txtRoomID_KeyPress(sender, new KeyPressEventArgs('\r'));
                }
                else
                {
                    //this.btnTransferDebit.Enabled = false;
                    try
                    {
                        Folio _oFolio = new Folio();
                        FolioFacade _oFolioFacade = new FolioFacade();

                        string folioID = lvwChildFolio.SelectedItems[0].SubItems[2].Text;
                        string roomNo = lvwChildFolio.SelectedItems[0].Text;

                        _oFolio = _oFolioFacade.GetFolio(folioID);
                        _oFolio.CreateSubFolio();
                        SubFolio subF;
                        foreach (SubFolio tempLoopVar_subF in _oFolio.SubFolios)
                        {
                            subF = tempLoopVar_subF;
                            subF.Folio.FolioTransactions = _oFolioFacade.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
                            subF.Ledger = _oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                        }

                        if (_oFolio.FolioType != "DEPENDENT")
                        {
                            TransferDebitUI _oTransferDebitUI = new TransferDebitUI(_oFolio, roomNo);
                            _oTransferDebitUI.ShowDialog();
                        }
                        else
                        {
                            Folio _oMasterFolio = new Folio();
                            _oMasterFolio = _oFolioFacade.GetFolio(_oFolio.MasterFolio);

                            TransferDebitUI _oTransferDebitUI = new TransferDebitUI(_oFolio, roomNo, _oMasterFolio);
                            _oTransferDebitUI.ShowDialog();
                        } 
                    }
                    catch
                    {
                        MessageBox.Show("Please select a child folio to transfer charges from.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
			}

			private void tabCheckout_SelectedIndexChanged(object sender, EventArgs e)
			{
                //if (tabCheckout.SelectedIndex == 0)
                //{
                //    this.btnTransferDebit.Enabled = true;
                //}
                //else
                //{
                //    this.btnTransferDebit.Enabled = false;
                //}

			}

            private void CheckOutUI_Enter(object sender, EventArgs e)
            {
                //loadGroupFolio(txtGroupFolioId.Text, txtGroupName.Text);
            }

            private void CheckOutUI_FormClosing(object sender, FormClosingEventArgs e)
            {
                try
                {
                    Form mdi = (Form)GlobalVariables.gMDI;
                    Form[] children = mdi.MdiChildren;

                    foreach (Form _childForm in children)
                    {
                        if (_childForm.Name.ToUpper() != "REPORTVIEWER" && _childForm.Name != this.Name)
                        {
                            _childForm.Close();
                        }
                    }
                }
                catch { }
            }

            private void txtCompanyId_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    if (txtCompanyId.Text.StartsWith("G"))
                    {
                        oCompanyFACADE = new CompanyFacade();
                        Company _oCompany = new Company();
                        _oCompany = oCompanyFACADE.getCompanyAccount(txtCompanyId.Text);
                        txtCompanyName.Text = _oCompany.CompanyName;
                    }
                    else
                    {
                        oGuestFACADE = new GuestFacade();
                        Guest _oGuest = new Guest();
                        _oGuest = oGuestFACADE.getGuestRecord(txtCompanyId.Text);
                        txtCompanyName.Text = _oGuest.LastName + ", " + _oGuest.FirstName;
                    }
                }
                catch { }
            }

            private void btnRemarksOK_Click(object sender, EventArgs e)
            {
                ReportViewer reportViewerUI = new ReportViewer();
                ReportFacade reportFacade = new ReportFacade();
                reportViewerUI.rptViewer.ReportSource = reportFacade.getCompanyBill_PICC(this.txtGroupFolioId.Text, oFolio.GroupName, oFolio.FromDate, txtGroup_CompanyName.Text, oFolio.ReferenceNo, oFolio.CompanyID, txtGroupRemarks.Text,txtComptrollersInfo.Text, chkNoPayments.Checked);
                reportViewerUI.MdiParent = this.MdiParent;
                reportViewerUI.Show();
            }

            private void btnRemarksCancel_Click(object sender, EventArgs e)
            {
                pnlRemarks.SendToBack();
                pnlRemarks.Visible = false;
            }	

		}
	}
}
