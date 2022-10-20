using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.Security.Presentation;
using Jinisys.Hotel.Cashier.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class FolioLedgerUI : Jinisys.Hotel.UIFramework.TransactionUI
		{
			
			#region "Instantiations/Variable Declarations"
			private MySqlConnection localConnection;
			
			private Folio oFolio = new Folio();
			private FolioFacade oFolioFacade = new FolioFacade();
            private ImageList imgIcon;
			private ColumnHeader colTransRefNoA;
			private ColumnHeader colTransStaffA;
            internal Button btnClose;
			public Label label6;
			public Label label5;
			private TextBox txtTotalPayment;
			private TextBox txtTotalCharges;
			public Label label21;
			public Label label32;
			private TextBox txtDepartureDate;
			private TextBox txtArrivalDate;
			private TextBox txtBalance;
			public Label label46;
			private TextBox txtFolioId;
			private TextBox txtGuestName;
			private TextBox txtRoomId;
			private ColumnHeader colTransBalanceA;
			private ColumnHeader colTransPostingDateA;
			private TextBox txtPayment_Mode;
			public Label label48;
			private TextBox txtAccount_Type;
			public Label label47;
			private ColumnHeader colTransGrossAmountA;
			private ColumnHeader colTransNetBaseAmountA;
			private ListView lvwSubFolioB;
			private ColumnHeader columnHeader2;
			private ColumnHeader columnHeader3;
			private ColumnHeader columnHeader4;
			private ColumnHeader columnHeader5;
			private ColumnHeader columnHeader6;
			private ColumnHeader columnHeader7;
			private ColumnHeader columnHeader8;
			private ColumnHeader columnHeader9;
			private ColumnHeader columnHeader10;
			private ColumnHeader columnHeader11;
			private ColumnHeader columnHeader13;
			private ColumnHeader columnHeader14;
			private ColumnHeader columnHeader15;
			private ColumnHeader columnHeader43;
			private ColumnHeader columnHeader44;
			private ListView lvwSubFolioC;
			private ColumnHeader columnHeader45;
			private ColumnHeader columnHeader46;
			private ColumnHeader columnHeader47;
			private ColumnHeader columnHeader48;
			private ColumnHeader columnHeader49;
			private ColumnHeader columnHeader50;
			private ColumnHeader columnHeader51;
			private ColumnHeader columnHeader52;
			private ColumnHeader columnHeader53;
			private ColumnHeader columnHeader54;
			private ColumnHeader columnHeader55;
			private ColumnHeader columnHeader56;
			private ColumnHeader columnHeader57;
			private ColumnHeader columnHeader58;
			private ColumnHeader columnHeader59;
			private ListView lvwSubFolioD;
			private ColumnHeader columnHeader1;
			private ColumnHeader columnHeader12;
			private ColumnHeader columnHeader16;
			private ColumnHeader columnHeader17;
			private ColumnHeader columnHeader18;
			private ColumnHeader columnHeader19;
			private ColumnHeader columnHeader20;
			private ColumnHeader columnHeader22;
			private ColumnHeader columnHeader23;
			private ColumnHeader columnHeader24;
			private ColumnHeader columnHeader25;
			private ColumnHeader columnHeader26;
			private ColumnHeader columnHeader27;
			private ColumnHeader columnHeader28;
			private ColumnHeader columnHeader30;
			private ColumnHeader columnHeader21;
			private ColumnHeader columnHeader29;
			private ColumnHeader columnHeader31;
			private ColumnHeader columnHeader32;
			private MenuItem menuItem3;
			private MenuItem mnuRefreshLedger;
			internal GroupBox groupBox1;
			public Label label1;
			public Label label7;
			public Label label8;
			public Label label11;
			public Label label12;
			public Label label13;
			public Label lblChequePaymentB;
			public Label lblServiceChargeB;
			public Label lblCommissionB;
			public Label lblLocalTaxB;
			public Label lblGovtTaxB;
			public Label label14;
			public Label label15;
			public Label label16;
			public Label label17;
			public Label label18;
			public Label label19;
			public Label label20;
			public Label lblTotalChargesB;
			public Label lblTotalDiscountB;
			public Label lblChargePaymentB;
			public Label lblGiftChequePaymentB;
			public Label lblCashPaymentB;
			public Label lblBalanceForwardB;
			public Label lblTotalNetB;
			public Label lblTotalBalanceB;
			internal GroupBox groupBox3;
			public Label label2;
			public Label label9;
			public Label label58;
			public Label label10;
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
            public Label label22;
            private Button btnPostToAccounting;
			private FolioTransaction oFolioTransaction = new FolioTransaction();
			
			#endregion

			#region " Windows Form Designer generated code "
			
			public FolioLedgerUI()
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
			internal System.Windows.Forms.Button btnAdd;
			internal System.Windows.Forms.Button btnVoid;
			internal System.Windows.Forms.Button btnRecall;
			internal System.Windows.Forms.Button btnBacktoList;
			internal System.Windows.Forms.TabPage TabPage1;
			internal System.Windows.Forms.TabPage TabPage2;
			internal System.Windows.Forms.TabPage TabPage3;
			internal System.Windows.Forms.TabPage TabPage4;
			internal System.Windows.Forms.ColumnHeader colTransDateA;
			internal System.Windows.Forms.ColumnHeader colTransCodeA;
			internal System.Windows.Forms.ColumnHeader colTransMemoA;
			internal System.Windows.Forms.ColumnHeader colTransBaseAmountA;
			internal System.Windows.Forms.ColumnHeader colTransTaxA;
			internal System.Windows.Forms.ColumnHeader colTransDocSourceA;
			internal System.Windows.Forms.ColumnHeader colTransServiceChargeA;
			internal System.Windows.Forms.ColumnHeader colTransDiscountA;
			internal System.Windows.Forms.ColumnHeader colTransNetAmountA;
			public System.Windows.Forms.Label Label59;
			public System.Windows.Forms.Label Label114;
			internal System.Windows.Forms.TabControl tabSubFolio;
			public System.Windows.Forms.Label Label118;
			public System.Windows.Forms.Label Label115;
			internal System.Windows.Forms.GroupBox GroupBox4;
			public System.Windows.Forms.Label lblChequePaymentA;
			public System.Windows.Forms.Label lblServiceChargeA;
			public System.Windows.Forms.Label lblCommissionA;
			public System.Windows.Forms.Label lblLocalTaxA;
			public System.Windows.Forms.Label lblGovtTaxA;
			public System.Windows.Forms.Label Label33;
			public System.Windows.Forms.Label Label34;
			public System.Windows.Forms.Label Label35;
			public System.Windows.Forms.Label Label36;
			public System.Windows.Forms.Label Label37;
			public System.Windows.Forms.Label Label38;
			public System.Windows.Forms.Label Label39;
			public System.Windows.Forms.Label Label40;
			public System.Windows.Forms.Label Label41;
			public System.Windows.Forms.Label Label42;
			public System.Windows.Forms.Label Label43;
			public System.Windows.Forms.Label Label44;
			public System.Windows.Forms.Label Label45;
			public System.Windows.Forms.Label lblTotalChargesA;
			public System.Windows.Forms.Label lblTotalDiscountA;
            public System.Windows.Forms.Label lblChargePaymentA;
			public System.Windows.Forms.Label lblGiftChequePaymentA;
			public System.Windows.Forms.Label lblCashPaymentA;
			public System.Windows.Forms.Label lblBalanceForwardA;
			public System.Windows.Forms.Label lblTotalNetA;
			public System.Windows.Forms.Label lblTotalBalanceA;
			public System.Windows.Forms.Label lblCom;
			public System.Windows.Forms.Label Label4;
			internal System.Windows.Forms.ListView lvwSubFolioA;
			internal System.Windows.Forms.Button btnCheckOut;
			internal System.Windows.Forms.TextBox txtGuestNameC;
			internal System.Windows.Forms.TextBox txtGuestNameD;
			internal System.Windows.Forms.Button btnBrowseFolioD;
			internal System.Windows.Forms.Button btnBrowseFolioC;
			internal System.Windows.Forms.TextBox txtFolioIdC;
			internal System.Windows.Forms.TextBox txtFolioIdD;
			internal System.Windows.Forms.ContextMenu popUpMenu;
			internal System.Windows.Forms.MenuItem mnuInsert;
			internal System.Windows.Forms.MenuItem MenuItem2;
			internal System.Windows.Forms.MenuItem mnuCheckout;
			internal System.Windows.Forms.MenuItem MenuItem4;
			internal System.Windows.Forms.MenuItem mnuVoid;
			internal System.Windows.Forms.MenuItem mnuRecall;
			internal System.Windows.Forms.MenuItem MenuItem7;
			internal System.Windows.Forms.MenuItem mnuCityLedger;
			public System.Windows.Forms.Label Label3;
			internal System.Windows.Forms.TextBox txtRemarks;
			internal System.Windows.Forms.GroupBox GroupBox5;
			internal System.Windows.Forms.Button btnBrowseCompany;
			internal System.Windows.Forms.TextBox txtCompanyName;
			internal System.Windows.Forms.TextBox txtCompanyId;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolioLedgerUI));
                this.btnAdd = new System.Windows.Forms.Button();
                this.btnVoid = new System.Windows.Forms.Button();
                this.btnRecall = new System.Windows.Forms.Button();
                this.btnBacktoList = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.tabSubFolio = new System.Windows.Forms.TabControl();
                this.TabPage1 = new System.Windows.Forms.TabPage();
                this.GroupBox4 = new System.Windows.Forms.GroupBox();
                this.Label34 = new System.Windows.Forms.Label();
                this.Label35 = new System.Windows.Forms.Label();
                this.Label40 = new System.Windows.Forms.Label();
                this.Label41 = new System.Windows.Forms.Label();
                this.Label42 = new System.Windows.Forms.Label();
                this.Label43 = new System.Windows.Forms.Label();
                this.lblChequePaymentA = new System.Windows.Forms.Label();
                this.lblServiceChargeA = new System.Windows.Forms.Label();
                this.lblCommissionA = new System.Windows.Forms.Label();
                this.lblLocalTaxA = new System.Windows.Forms.Label();
                this.lblGovtTaxA = new System.Windows.Forms.Label();
                this.Label33 = new System.Windows.Forms.Label();
                this.Label36 = new System.Windows.Forms.Label();
                this.Label37 = new System.Windows.Forms.Label();
                this.Label38 = new System.Windows.Forms.Label();
                this.Label39 = new System.Windows.Forms.Label();
                this.Label44 = new System.Windows.Forms.Label();
                this.Label45 = new System.Windows.Forms.Label();
                this.lblTotalChargesA = new System.Windows.Forms.Label();
                this.lblTotalDiscountA = new System.Windows.Forms.Label();
                this.lblChargePaymentA = new System.Windows.Forms.Label();
                this.lblGiftChequePaymentA = new System.Windows.Forms.Label();
                this.lblCashPaymentA = new System.Windows.Forms.Label();
                this.lblBalanceForwardA = new System.Windows.Forms.Label();
                this.lblTotalNetA = new System.Windows.Forms.Label();
                this.lblTotalBalanceA = new System.Windows.Forms.Label();
                this.lvwSubFolioA = new System.Windows.Forms.ListView();
                this.colTransDateA = new System.Windows.Forms.ColumnHeader();
                this.colTransPostingDateA = new System.Windows.Forms.ColumnHeader();
                this.colTransCodeA = new System.Windows.Forms.ColumnHeader();
                this.colTransMemoA = new System.Windows.Forms.ColumnHeader();
                this.colTransDocSourceA = new System.Windows.Forms.ColumnHeader();
                this.colTransRefNoA = new System.Windows.Forms.ColumnHeader();
                this.colTransBaseAmountA = new System.Windows.Forms.ColumnHeader();
                this.colTransTaxA = new System.Windows.Forms.ColumnHeader();
                this.colTransServiceChargeA = new System.Windows.Forms.ColumnHeader();
                this.colTransGrossAmountA = new System.Windows.Forms.ColumnHeader();
                this.colTransDiscountA = new System.Windows.Forms.ColumnHeader();
                this.colTransNetAmountA = new System.Windows.Forms.ColumnHeader();
                this.colTransBalanceA = new System.Windows.Forms.ColumnHeader();
                this.colTransStaffA = new System.Windows.Forms.ColumnHeader();
                this.colTransNetBaseAmountA = new System.Windows.Forms.ColumnHeader();
                this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
                this.TabPage2 = new System.Windows.Forms.TabPage();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.label11 = new System.Windows.Forms.Label();
                this.label12 = new System.Windows.Forms.Label();
                this.label13 = new System.Windows.Forms.Label();
                this.lblChequePaymentB = new System.Windows.Forms.Label();
                this.lblServiceChargeB = new System.Windows.Forms.Label();
                this.lblCommissionB = new System.Windows.Forms.Label();
                this.lblLocalTaxB = new System.Windows.Forms.Label();
                this.lblGovtTaxB = new System.Windows.Forms.Label();
                this.label14 = new System.Windows.Forms.Label();
                this.label15 = new System.Windows.Forms.Label();
                this.label16 = new System.Windows.Forms.Label();
                this.label17 = new System.Windows.Forms.Label();
                this.label18 = new System.Windows.Forms.Label();
                this.label19 = new System.Windows.Forms.Label();
                this.label20 = new System.Windows.Forms.Label();
                this.lblTotalChargesB = new System.Windows.Forms.Label();
                this.lblTotalDiscountB = new System.Windows.Forms.Label();
                this.lblChargePaymentB = new System.Windows.Forms.Label();
                this.lblGiftChequePaymentB = new System.Windows.Forms.Label();
                this.lblCashPaymentB = new System.Windows.Forms.Label();
                this.lblBalanceForwardB = new System.Windows.Forms.Label();
                this.lblTotalNetB = new System.Windows.Forms.Label();
                this.lblTotalBalanceB = new System.Windows.Forms.Label();
                this.lvwSubFolioB = new System.Windows.Forms.ListView();
                this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader43 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
                this.btnBrowseCompany = new System.Windows.Forms.Button();
                this.imgIcon = new System.Windows.Forms.ImageList(this.components);
                this.txtCompanyName = new System.Windows.Forms.TextBox();
                this.txtCompanyId = new System.Windows.Forms.TextBox();
                this.lblCom = new System.Windows.Forms.Label();
                this.TabPage3 = new System.Windows.Forms.TabPage();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.label2 = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.label58 = new System.Windows.Forms.Label();
                this.label10 = new System.Windows.Forms.Label();
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
                this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader47 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader48 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader49 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader50 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader51 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader52 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader53 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader54 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader55 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader56 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader57 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader58 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader59 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
                this.btnBrowseFolioC = new System.Windows.Forms.Button();
                this.txtGuestNameC = new System.Windows.Forms.TextBox();
                this.txtFolioIdC = new System.Windows.Forms.TextBox();
                this.Label59 = new System.Windows.Forms.Label();
                this.TabPage4 = new System.Windows.Forms.TabPage();
                this.groupBox6 = new System.Windows.Forms.GroupBox();
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
                this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
                this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
                this.btnBrowseFolioD = new System.Windows.Forms.Button();
                this.txtGuestNameD = new System.Windows.Forms.TextBox();
                this.txtFolioIdD = new System.Windows.Forms.TextBox();
                this.Label4 = new System.Windows.Forms.Label();
                this.btnCheckOut = new System.Windows.Forms.Button();
                this.GroupBox5 = new System.Windows.Forms.GroupBox();
                this.txtPayment_Mode = new System.Windows.Forms.TextBox();
                this.label48 = new System.Windows.Forms.Label();
                this.txtAccount_Type = new System.Windows.Forms.TextBox();
                this.label47 = new System.Windows.Forms.Label();
                this.txtRoomId = new System.Windows.Forms.TextBox();
                this.txtGuestName = new System.Windows.Forms.TextBox();
                this.txtFolioId = new System.Windows.Forms.TextBox();
                this.txtBalance = new System.Windows.Forms.TextBox();
                this.label46 = new System.Windows.Forms.Label();
                this.txtTotalPayment = new System.Windows.Forms.TextBox();
                this.txtTotalCharges = new System.Windows.Forms.TextBox();
                this.label21 = new System.Windows.Forms.Label();
                this.label32 = new System.Windows.Forms.Label();
                this.txtDepartureDate = new System.Windows.Forms.TextBox();
                this.txtArrivalDate = new System.Windows.Forms.TextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.Label115 = new System.Windows.Forms.Label();
                this.Label118 = new System.Windows.Forms.Label();
                this.Label114 = new System.Windows.Forms.Label();
                this.txtRemarks = new System.Windows.Forms.TextBox();
                this.Label3 = new System.Windows.Forms.Label();
                this.popUpMenu = new System.Windows.Forms.ContextMenu();
                this.mnuInsert = new System.Windows.Forms.MenuItem();
                this.MenuItem2 = new System.Windows.Forms.MenuItem();
                this.mnuCheckout = new System.Windows.Forms.MenuItem();
                this.MenuItem4 = new System.Windows.Forms.MenuItem();
                this.mnuVoid = new System.Windows.Forms.MenuItem();
                this.mnuRecall = new System.Windows.Forms.MenuItem();
                this.MenuItem7 = new System.Windows.Forms.MenuItem();
                this.mnuCityLedger = new System.Windows.Forms.MenuItem();
                this.menuItem3 = new System.Windows.Forms.MenuItem();
                this.mnuRefreshLedger = new System.Windows.Forms.MenuItem();
                this.label22 = new System.Windows.Forms.Label();
                this.btnPostToAccounting = new System.Windows.Forms.Button();
                this.tabSubFolio.SuspendLayout();
                this.TabPage1.SuspendLayout();
                this.GroupBox4.SuspendLayout();
                this.TabPage2.SuspendLayout();
                this.groupBox1.SuspendLayout();
                this.TabPage3.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.TabPage4.SuspendLayout();
                this.groupBox6.SuspendLayout();
                this.GroupBox5.SuspendLayout();
                this.SuspendLayout();
                // 
                // btnAdd
                // 
                this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnAdd.Location = new System.Drawing.Point(423, 609);
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(136, 31);
                this.btnAdd.TabIndex = 1;
                this.btnAdd.Text = "&Insert Transaction";
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // btnVoid
                // 
                this.btnVoid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnVoid.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnVoid.Enabled = false;
                this.btnVoid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnVoid.Location = new System.Drawing.Point(656, 609);
                this.btnVoid.Name = "btnVoid";
                this.btnVoid.Size = new System.Drawing.Size(84, 31);
                this.btnVoid.TabIndex = 91;
                this.btnVoid.Text = "&Void";
                this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
                // 
                // btnRecall
                // 
                this.btnRecall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnRecall.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnRecall.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnRecall.Location = new System.Drawing.Point(566, 609);
                this.btnRecall.Name = "btnRecall";
                this.btnRecall.Size = new System.Drawing.Size(84, 31);
                this.btnRecall.TabIndex = 90;
                this.btnRecall.Text = "&Recall";
                this.btnRecall.Click += new System.EventHandler(this.btnRecall_Click);
                // 
                // btnBacktoList
                // 
                this.btnBacktoList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnBacktoList.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnBacktoList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnBacktoList.Location = new System.Drawing.Point(10, 609);
                this.btnBacktoList.Name = "btnBacktoList";
                this.btnBacktoList.Size = new System.Drawing.Size(103, 31);
                this.btnBacktoList.TabIndex = 89;
                this.btnBacktoList.Text = "« Back to List";
                this.btnBacktoList.Visible = false;
                this.btnBacktoList.Click += new System.EventHandler(this.btnBacktoList_Click);
                // 
                // btnClose
                // 
                this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(746, 609);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(84, 31);
                this.btnClose.TabIndex = 117;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // tabSubFolio
                // 
                this.tabSubFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.tabSubFolio.Controls.Add(this.TabPage1);
                this.tabSubFolio.Controls.Add(this.TabPage2);
                this.tabSubFolio.Controls.Add(this.TabPage3);
                this.tabSubFolio.Controls.Add(this.TabPage4);
                this.tabSubFolio.Location = new System.Drawing.Point(8, 193);
                this.tabSubFolio.Multiline = true;
                this.tabSubFolio.Name = "tabSubFolio";
                this.tabSubFolio.SelectedIndex = 0;
                this.tabSubFolio.Size = new System.Drawing.Size(824, 410);
                this.tabSubFolio.TabIndex = 103;
                this.tabSubFolio.SelectedIndexChanged += new System.EventHandler(this.tabSubFolio_SelectedIndexChanged);
                // 
                // TabPage1
                // 
                this.TabPage1.Controls.Add(this.GroupBox4);
                this.TabPage1.Controls.Add(this.lvwSubFolioA);
                this.TabPage1.Location = new System.Drawing.Point(4, 23);
                this.TabPage1.Name = "TabPage1";
                this.TabPage1.Size = new System.Drawing.Size(816, 383);
                this.TabPage1.TabIndex = 0;
                this.TabPage1.Text = "A (Personal)";
                // 
                // GroupBox4
                // 
                this.GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.GroupBox4.Controls.Add(this.Label34);
                this.GroupBox4.Controls.Add(this.Label35);
                this.GroupBox4.Controls.Add(this.Label40);
                this.GroupBox4.Controls.Add(this.Label41);
                this.GroupBox4.Controls.Add(this.Label42);
                this.GroupBox4.Controls.Add(this.Label43);
                this.GroupBox4.Controls.Add(this.lblChequePaymentA);
                this.GroupBox4.Controls.Add(this.lblServiceChargeA);
                this.GroupBox4.Controls.Add(this.lblCommissionA);
                this.GroupBox4.Controls.Add(this.lblLocalTaxA);
                this.GroupBox4.Controls.Add(this.lblGovtTaxA);
                this.GroupBox4.Controls.Add(this.Label33);
                this.GroupBox4.Controls.Add(this.Label36);
                this.GroupBox4.Controls.Add(this.Label37);
                this.GroupBox4.Controls.Add(this.Label38);
                this.GroupBox4.Controls.Add(this.Label39);
                this.GroupBox4.Controls.Add(this.Label44);
                this.GroupBox4.Controls.Add(this.Label45);
                this.GroupBox4.Controls.Add(this.lblTotalChargesA);
                this.GroupBox4.Controls.Add(this.lblTotalDiscountA);
                this.GroupBox4.Controls.Add(this.lblChargePaymentA);
                this.GroupBox4.Controls.Add(this.lblGiftChequePaymentA);
                this.GroupBox4.Controls.Add(this.lblCashPaymentA);
                this.GroupBox4.Controls.Add(this.lblBalanceForwardA);
                this.GroupBox4.Controls.Add(this.lblTotalNetA);
                this.GroupBox4.Controls.Add(this.lblTotalBalanceA);
                this.GroupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.GroupBox4.Location = new System.Drawing.Point(7, 265);
                this.GroupBox4.Name = "GroupBox4";
                this.GroupBox4.Size = new System.Drawing.Size(801, 114);
                this.GroupBox4.TabIndex = 120;
                this.GroupBox4.TabStop = false;
                this.GroupBox4.Text = "Sub-folio A Summary";
                // 
                // Label34
                // 
                this.Label34.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label34.Location = new System.Drawing.Point(612, 77);
                this.Label34.Name = "Label34";
                this.Label34.Size = new System.Drawing.Size(89, 14);
                this.Label34.TabIndex = 114;
                this.Label34.Text = "Commission :";
                this.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label35
                // 
                this.Label35.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label35.Location = new System.Drawing.Point(612, 59);
                this.Label35.Name = "Label35";
                this.Label35.Size = new System.Drawing.Size(89, 14);
                this.Label35.TabIndex = 113;
                this.Label35.Text = "Service Charge :";
                this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label40
                // 
                this.Label40.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label40.Location = new System.Drawing.Point(195, 40);
                this.Label40.Name = "Label40";
                this.Label40.Size = new System.Drawing.Size(103, 14);
                this.Label40.TabIndex = 108;
                this.Label40.Text = "Charge Payment :";
                this.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label41
                // 
                this.Label41.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label41.Location = new System.Drawing.Point(195, 58);
                this.Label41.Name = "Label41";
                this.Label41.Size = new System.Drawing.Size(103, 14);
                this.Label41.TabIndex = 107;
                this.Label41.Text = "Cheque Payment :";
                this.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label42
                // 
                this.Label42.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label42.Location = new System.Drawing.Point(195, 22);
                this.Label42.Name = "Label42";
                this.Label42.Size = new System.Drawing.Size(103, 14);
                this.Label42.TabIndex = 106;
                this.Label42.Text = "Cash Payment :";
                this.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label43
                // 
                this.Label43.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label43.Location = new System.Drawing.Point(195, 76);
                this.Label43.Name = "Label43";
                this.Label43.Size = new System.Drawing.Size(103, 14);
                this.Label43.TabIndex = 105;
                this.Label43.Text = "Gift Cheque :";
                this.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentA
                // 
                this.lblChequePaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentA.Location = new System.Drawing.Point(293, 58);
                this.lblChequePaymentA.Name = "lblChequePaymentA";
                this.lblChequePaymentA.Size = new System.Drawing.Size(78, 14);
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
                // Label33
                // 
                this.Label33.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label33.Location = new System.Drawing.Point(406, 40);
                this.Label33.Name = "Label33";
                this.Label33.Size = new System.Drawing.Size(98, 14);
                this.Label33.TabIndex = 115;
                this.Label33.Text = "Total Net :";
                this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label33.Visible = false;
                // 
                // Label36
                // 
                this.Label36.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label36.Location = new System.Drawing.Point(612, 40);
                this.Label36.Name = "Label36";
                this.Label36.Size = new System.Drawing.Size(89, 14);
                this.Label36.TabIndex = 112;
                this.Label36.Text = "Local Tax :";
                this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label37
                // 
                this.Label37.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label37.Location = new System.Drawing.Point(612, 22);
                this.Label37.Name = "Label37";
                this.Label37.Size = new System.Drawing.Size(89, 14);
                this.Label37.TabIndex = 111;
                this.Label37.Text = "Gov\'t Tax :";
                this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label38
                // 
                this.Label38.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label38.Location = new System.Drawing.Point(406, 22);
                this.Label38.Name = "Label38";
                this.Label38.Size = new System.Drawing.Size(98, 14);
                this.Label38.TabIndex = 110;
                this.Label38.Text = "Balance :";
                this.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label39
                // 
                this.Label39.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label39.Location = new System.Drawing.Point(26, 40);
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
                this.Label44.Location = new System.Drawing.Point(195, 94);
                this.Label44.Name = "Label44";
                this.Label44.Size = new System.Drawing.Size(98, 14);
                this.Label44.TabIndex = 104;
                this.Label44.Text = "Others :";
                this.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label45
                // 
                this.Label45.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label45.Location = new System.Drawing.Point(26, 22);
                this.Label45.Name = "Label45";
                this.Label45.Size = new System.Drawing.Size(62, 14);
                this.Label45.TabIndex = 103;
                this.Label45.Text = "Charges :";
                this.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
                this.lblChargePaymentA.Location = new System.Drawing.Point(293, 40);
                this.lblChargePaymentA.Name = "lblChargePaymentA";
                this.lblChargePaymentA.Size = new System.Drawing.Size(78, 14);
                this.lblChargePaymentA.TabIndex = 108;
                this.lblChargePaymentA.Text = "0.00";
                this.lblChargePaymentA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentA
                // 
                this.lblGiftChequePaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentA.Location = new System.Drawing.Point(293, 76);
                this.lblGiftChequePaymentA.Name = "lblGiftChequePaymentA";
                this.lblGiftChequePaymentA.Size = new System.Drawing.Size(78, 14);
                this.lblGiftChequePaymentA.TabIndex = 105;
                this.lblGiftChequePaymentA.Text = "0.00";
                this.lblGiftChequePaymentA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentA
                // 
                this.lblCashPaymentA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentA.Location = new System.Drawing.Point(293, 22);
                this.lblCashPaymentA.Name = "lblCashPaymentA";
                this.lblCashPaymentA.Size = new System.Drawing.Size(78, 14);
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
            this.colTransDateA,
            this.colTransPostingDateA,
            this.colTransCodeA,
            this.colTransMemoA,
            this.colTransDocSourceA,
            this.colTransRefNoA,
            this.colTransBaseAmountA,
            this.colTransTaxA,
            this.colTransServiceChargeA,
            this.colTransGrossAmountA,
            this.colTransDiscountA,
            this.colTransNetAmountA,
            this.colTransBalanceA,
            this.colTransStaffA,
            this.colTransNetBaseAmountA,
            this.columnHeader21});
                this.lvwSubFolioA.FullRowSelect = true;
                this.lvwSubFolioA.Location = new System.Drawing.Point(5, 3);
                this.lvwSubFolioA.Name = "lvwSubFolioA";
                this.lvwSubFolioA.Size = new System.Drawing.Size(808, 259);
                this.lvwSubFolioA.TabIndex = 0;
                this.lvwSubFolioA.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioA.View = System.Windows.Forms.View.Details;
                this.lvwSubFolioA.SelectedIndexChanged += new System.EventHandler(this.lvwSubFolioA_SelectedIndexChanged);
                this.lvwSubFolioA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwSubFolio_MouseUp);
                // 
                // colTransDateA
                // 
                this.colTransDateA.Text = "Date";
                this.colTransDateA.Width = 55;
                // 
                // colTransPostingDateA
                // 
                this.colTransPostingDateA.Text = "Posting Date";
                this.colTransPostingDateA.Width = 0;
                // 
                // colTransCodeA
                // 
                this.colTransCodeA.Text = "Code";
                this.colTransCodeA.Width = 40;
                // 
                // colTransMemoA
                // 
                this.colTransMemoA.Text = "Memo";
                this.colTransMemoA.Width = 139;
                // 
                // colTransDocSourceA
                // 
                this.colTransDocSourceA.Text = "Source";
                this.colTransDocSourceA.Width = 72;
                // 
                // colTransRefNoA
                // 
                this.colTransRefNoA.Text = "Ref. No.";
                this.colTransRefNoA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.colTransRefNoA.Width = 75;
                // 
                // colTransBaseAmountA
                // 
                this.colTransBaseAmountA.Text = "Amount";
                this.colTransBaseAmountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransBaseAmountA.Width = 72;
                // 
                // colTransTaxA
                // 
                this.colTransTaxA.Text = "Tax";
                this.colTransTaxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransTaxA.Width = 59;
                // 
                // colTransServiceChargeA
                // 
                this.colTransServiceChargeA.Text = "Srvc Chrg";
                this.colTransServiceChargeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransServiceChargeA.Width = 0;
                // 
                // colTransGrossAmountA
                // 
                this.colTransGrossAmountA.Text = "Gross Amt.";
                this.colTransGrossAmountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransGrossAmountA.Width = 70;
                // 
                // colTransDiscountA
                // 
                this.colTransDiscountA.Text = "Discount";
                this.colTransDiscountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransDiscountA.Width = 54;
                // 
                // colTransNetAmountA
                // 
                this.colTransNetAmountA.Text = "Net Amount";
                this.colTransNetAmountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransNetAmountA.Width = 70;
                // 
                // colTransBalanceA
                // 
                this.colTransBalanceA.Text = "Balance";
                this.colTransBalanceA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.colTransBalanceA.Width = 70;
                // 
                // colTransStaffA
                // 
                this.colTransStaffA.Text = "Staff";
                this.colTransStaffA.Width = 46;
                // 
                // colTransNetBaseAmountA
                // 
                this.colTransNetBaseAmountA.Text = "Net Base Amount";
                this.colTransNetBaseAmountA.Width = 0;
                // 
                // columnHeader21
                // 
                this.columnHeader21.Text = "TransactionNo";
                this.columnHeader21.Width = 0;
                // 
                // TabPage2
                // 
                this.TabPage2.Controls.Add(this.groupBox1);
                this.TabPage2.Controls.Add(this.lvwSubFolioB);
                this.TabPage2.Controls.Add(this.btnBrowseCompany);
                this.TabPage2.Controls.Add(this.txtCompanyName);
                this.TabPage2.Controls.Add(this.txtCompanyId);
                this.TabPage2.Controls.Add(this.lblCom);
                this.TabPage2.Location = new System.Drawing.Point(4, 23);
                this.TabPage2.Name = "TabPage2";
                this.TabPage2.Size = new System.Drawing.Size(816, 383);
                this.TabPage2.TabIndex = 1;
                this.TabPage2.Text = "B (Company)";
                // 
                // groupBox1
                // 
                this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox1.Controls.Add(this.label1);
                this.groupBox1.Controls.Add(this.label7);
                this.groupBox1.Controls.Add(this.label8);
                this.groupBox1.Controls.Add(this.label11);
                this.groupBox1.Controls.Add(this.label12);
                this.groupBox1.Controls.Add(this.label13);
                this.groupBox1.Controls.Add(this.lblChequePaymentB);
                this.groupBox1.Controls.Add(this.lblServiceChargeB);
                this.groupBox1.Controls.Add(this.lblCommissionB);
                this.groupBox1.Controls.Add(this.lblLocalTaxB);
                this.groupBox1.Controls.Add(this.lblGovtTaxB);
                this.groupBox1.Controls.Add(this.label14);
                this.groupBox1.Controls.Add(this.label15);
                this.groupBox1.Controls.Add(this.label16);
                this.groupBox1.Controls.Add(this.label17);
                this.groupBox1.Controls.Add(this.label18);
                this.groupBox1.Controls.Add(this.label19);
                this.groupBox1.Controls.Add(this.label20);
                this.groupBox1.Controls.Add(this.lblTotalChargesB);
                this.groupBox1.Controls.Add(this.lblTotalDiscountB);
                this.groupBox1.Controls.Add(this.lblChargePaymentB);
                this.groupBox1.Controls.Add(this.lblGiftChequePaymentB);
                this.groupBox1.Controls.Add(this.lblCashPaymentB);
                this.groupBox1.Controls.Add(this.lblBalanceForwardB);
                this.groupBox1.Controls.Add(this.lblTotalNetB);
                this.groupBox1.Controls.Add(this.lblTotalBalanceB);
                this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.groupBox1.Location = new System.Drawing.Point(7, 265);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(801, 114);
                this.groupBox1.TabIndex = 141;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "Sub-folio B Summary";
                // 
                // label1
                // 
                this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label1.Location = new System.Drawing.Point(612, 77);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(89, 14);
                this.label1.TabIndex = 114;
                this.label1.Text = "Commission :";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label7
                // 
                this.label7.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label7.Location = new System.Drawing.Point(612, 59);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(89, 14);
                this.label7.TabIndex = 113;
                this.label7.Text = "Service Charge :";
                this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label8
                // 
                this.label8.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label8.Location = new System.Drawing.Point(195, 40);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(94, 14);
                this.label8.TabIndex = 108;
                this.label8.Text = "Charge Payment :";
                this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label11
                // 
                this.label11.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label11.Location = new System.Drawing.Point(195, 58);
                this.label11.Name = "label11";
                this.label11.Size = new System.Drawing.Size(94, 14);
                this.label11.TabIndex = 107;
                this.label11.Text = "Cheque Payment :";
                this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label12
                // 
                this.label12.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label12.Location = new System.Drawing.Point(195, 22);
                this.label12.Name = "label12";
                this.label12.Size = new System.Drawing.Size(94, 14);
                this.label12.TabIndex = 106;
                this.label12.Text = "Cash Payment :";
                this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label13
                // 
                this.label13.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label13.Location = new System.Drawing.Point(195, 76);
                this.label13.Name = "label13";
                this.label13.Size = new System.Drawing.Size(94, 14);
                this.label13.TabIndex = 105;
                this.label13.Text = "Gift Cheque :";
                this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentB
                // 
                this.lblChequePaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentB.Location = new System.Drawing.Point(289, 58);
                this.lblChequePaymentB.Name = "lblChequePaymentB";
                this.lblChequePaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblChequePaymentB.TabIndex = 120;
                this.lblChequePaymentB.Text = "0.00";
                this.lblChequePaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblServiceChargeB
                // 
                this.lblServiceChargeB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblServiceChargeB.Location = new System.Drawing.Point(700, 59);
                this.lblServiceChargeB.Name = "lblServiceChargeB";
                this.lblServiceChargeB.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeB.TabIndex = 119;
                this.lblServiceChargeB.Text = "0.00";
                this.lblServiceChargeB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionB
                // 
                this.lblCommissionB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionB.Location = new System.Drawing.Point(700, 77);
                this.lblCommissionB.Name = "lblCommissionB";
                this.lblCommissionB.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionB.TabIndex = 118;
                this.lblCommissionB.Text = "0.00";
                this.lblCommissionB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxB
                // 
                this.lblLocalTaxB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxB.Location = new System.Drawing.Point(700, 40);
                this.lblLocalTaxB.Name = "lblLocalTaxB";
                this.lblLocalTaxB.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxB.TabIndex = 117;
                this.lblLocalTaxB.Text = "0.00";
                this.lblLocalTaxB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxB
                // 
                this.lblGovtTaxB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxB.Location = new System.Drawing.Point(700, 22);
                this.lblGovtTaxB.Name = "lblGovtTaxB";
                this.lblGovtTaxB.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxB.TabIndex = 116;
                this.lblGovtTaxB.Text = "0.00";
                this.lblGovtTaxB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label14
                // 
                this.label14.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label14.Location = new System.Drawing.Point(406, 40);
                this.label14.Name = "label14";
                this.label14.Size = new System.Drawing.Size(98, 14);
                this.label14.TabIndex = 115;
                this.label14.Text = "Total Net :";
                this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label14.Visible = false;
                // 
                // label15
                // 
                this.label15.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label15.Location = new System.Drawing.Point(612, 40);
                this.label15.Name = "label15";
                this.label15.Size = new System.Drawing.Size(89, 14);
                this.label15.TabIndex = 112;
                this.label15.Text = "Local Tax :";
                this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label16
                // 
                this.label16.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label16.Location = new System.Drawing.Point(612, 22);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(89, 14);
                this.label16.TabIndex = 111;
                this.label16.Text = "Gov\'t Tax :";
                this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label17
                // 
                this.label17.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label17.Location = new System.Drawing.Point(406, 22);
                this.label17.Name = "label17";
                this.label17.Size = new System.Drawing.Size(98, 14);
                this.label17.TabIndex = 110;
                this.label17.Text = "Balance :";
                this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label18
                // 
                this.label18.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label18.Location = new System.Drawing.Point(26, 40);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(62, 14);
                this.label18.TabIndex = 109;
                this.label18.Text = "Discounts :";
                this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.label18.Visible = false;
                // 
                // label19
                // 
                this.label19.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label19.Location = new System.Drawing.Point(195, 94);
                this.label19.Name = "label19";
                this.label19.Size = new System.Drawing.Size(98, 14);
                this.label19.TabIndex = 104;
                this.label19.Text = "Others :";
                this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label20
                // 
                this.label20.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label20.Location = new System.Drawing.Point(26, 22);
                this.label20.Name = "label20";
                this.label20.Size = new System.Drawing.Size(62, 14);
                this.label20.TabIndex = 103;
                this.label20.Text = "Charges :";
                this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesB
                // 
                this.lblTotalChargesB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesB.Location = new System.Drawing.Point(87, 22);
                this.lblTotalChargesB.Name = "lblTotalChargesB";
                this.lblTotalChargesB.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesB.TabIndex = 103;
                this.lblTotalChargesB.Text = "0.00";
                this.lblTotalChargesB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountB
                // 
                this.lblTotalDiscountB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountB.Location = new System.Drawing.Point(87, 40);
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
                this.lblChargePaymentB.Location = new System.Drawing.Point(289, 40);
                this.lblChargePaymentB.Name = "lblChargePaymentB";
                this.lblChargePaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblChargePaymentB.TabIndex = 108;
                this.lblChargePaymentB.Text = "0.00";
                this.lblChargePaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentB
                // 
                this.lblGiftChequePaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentB.Location = new System.Drawing.Point(289, 76);
                this.lblGiftChequePaymentB.Name = "lblGiftChequePaymentB";
                this.lblGiftChequePaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblGiftChequePaymentB.TabIndex = 105;
                this.lblGiftChequePaymentB.Text = "0.00";
                this.lblGiftChequePaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentB
                // 
                this.lblCashPaymentB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentB.Location = new System.Drawing.Point(289, 22);
                this.lblCashPaymentB.Name = "lblCashPaymentB";
                this.lblCashPaymentB.Size = new System.Drawing.Size(82, 14);
                this.lblCashPaymentB.TabIndex = 106;
                this.lblCashPaymentB.Text = "0.00";
                this.lblCashPaymentB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblBalanceForwardB
                // 
                this.lblBalanceForwardB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblBalanceForwardB.Location = new System.Drawing.Point(289, 94);
                this.lblBalanceForwardB.Name = "lblBalanceForwardB";
                this.lblBalanceForwardB.Size = new System.Drawing.Size(82, 14);
                this.lblBalanceForwardB.TabIndex = 108;
                this.lblBalanceForwardB.Text = "0.00";
                this.lblBalanceForwardB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalNetB
                // 
                this.lblTotalNetB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalNetB.Location = new System.Drawing.Point(505, 40);
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
                this.lblTotalBalanceB.Location = new System.Drawing.Point(505, 22);
                this.lblTotalBalanceB.Name = "lblTotalBalanceB";
                this.lblTotalBalanceB.Size = new System.Drawing.Size(82, 14);
                this.lblTotalBalanceB.TabIndex = 106;
                this.lblTotalBalanceB.Text = "0.00";
                this.lblTotalBalanceB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lvwSubFolioB
                // 
                this.lvwSubFolioB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lvwSubFolioB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader43,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader15,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader44,
            this.columnHeader29});
                this.lvwSubFolioB.FullRowSelect = true;
                this.lvwSubFolioB.Location = new System.Drawing.Point(5, 40);
                this.lvwSubFolioB.Name = "lvwSubFolioB";
                this.lvwSubFolioB.Size = new System.Drawing.Size(808, 228);
                this.lvwSubFolioB.TabIndex = 134;
                this.lvwSubFolioB.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioB.View = System.Windows.Forms.View.Details;
                this.lvwSubFolioB.SelectedIndexChanged += new System.EventHandler(this.lvwSubFolioB_SelectedIndexChanged);
                this.lvwSubFolioB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwSubFolio_MouseUp);
                // 
                // columnHeader2
                // 
                this.columnHeader2.Text = "Date";
                this.columnHeader2.Width = 55;
                // 
                // columnHeader43
                // 
                this.columnHeader43.Text = "Posting Date";
                this.columnHeader43.Width = 0;
                // 
                // columnHeader3
                // 
                this.columnHeader3.Text = "Code";
                this.columnHeader3.Width = 40;
                // 
                // columnHeader4
                // 
                this.columnHeader4.Text = "Memo";
                this.columnHeader4.Width = 139;
                // 
                // columnHeader5
                // 
                this.columnHeader5.Text = "Source";
                this.columnHeader5.Width = 72;
                // 
                // columnHeader6
                // 
                this.columnHeader6.Text = "Ref. No.";
                this.columnHeader6.Width = 75;
                // 
                // columnHeader7
                // 
                this.columnHeader7.Text = "Amount";
                this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader7.Width = 72;
                // 
                // columnHeader8
                // 
                this.columnHeader8.Text = "Tax";
                this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader8.Width = 59;
                // 
                // columnHeader15
                // 
                this.columnHeader15.Text = "Service Charge";
                this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader15.Width = 0;
                // 
                // columnHeader9
                // 
                this.columnHeader9.Text = "Gross Amt.";
                this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader9.Width = 70;
                // 
                // columnHeader10
                // 
                this.columnHeader10.Text = "Discount";
                this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader10.Width = 54;
                // 
                // columnHeader11
                // 
                this.columnHeader11.Text = "Net Amount";
                this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader11.Width = 70;
                // 
                // columnHeader13
                // 
                this.columnHeader13.Text = "Balance";
                this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader13.Width = 70;
                // 
                // columnHeader14
                // 
                this.columnHeader14.Text = "Staff";
                this.columnHeader14.Width = 46;
                // 
                // columnHeader44
                // 
                this.columnHeader44.Text = "Net Base Amount";
                this.columnHeader44.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader44.Width = 0;
                // 
                // columnHeader29
                // 
                this.columnHeader29.Text = "TransactionNo";
                this.columnHeader29.Width = 0;
                // 
                // btnBrowseCompany
                // 
                this.btnBrowseCompany.Enabled = false;
                this.btnBrowseCompany.ImageIndex = 0;
                this.btnBrowseCompany.ImageList = this.imgIcon;
                this.btnBrowseCompany.Location = new System.Drawing.Point(221, 10);
                this.btnBrowseCompany.Name = "btnBrowseCompany";
                this.btnBrowseCompany.Size = new System.Drawing.Size(28, 24);
                this.btnBrowseCompany.TabIndex = 132;
                // 
                // imgIcon
                // 
                this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
                this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
                this.imgIcon.Images.SetKeyName(0, "Find_ico_6.ico");
                // 
                // txtCompanyName
                // 
                this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtCompanyName.BackColor = System.Drawing.SystemColors.Control;
                this.txtCompanyName.Location = new System.Drawing.Point(251, 12);
                this.txtCompanyName.Name = "txtCompanyName";
                this.txtCompanyName.ReadOnly = true;
                this.txtCompanyName.Size = new System.Drawing.Size(562, 20);
                this.txtCompanyName.TabIndex = 131;
                // 
                // txtCompanyId
                // 
                this.txtCompanyId.BackColor = System.Drawing.SystemColors.Info;
                this.txtCompanyId.Location = new System.Drawing.Point(93, 12);
                this.txtCompanyId.Name = "txtCompanyId";
                this.txtCompanyId.ReadOnly = true;
                this.txtCompanyId.Size = new System.Drawing.Size(126, 20);
                this.txtCompanyId.TabIndex = 130;
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
                // TabPage3
                // 
                this.TabPage3.Controls.Add(this.groupBox3);
                this.TabPage3.Controls.Add(this.lvwSubFolioC);
                this.TabPage3.Controls.Add(this.btnBrowseFolioC);
                this.TabPage3.Controls.Add(this.txtGuestNameC);
                this.TabPage3.Controls.Add(this.txtFolioIdC);
                this.TabPage3.Controls.Add(this.Label59);
                this.TabPage3.Location = new System.Drawing.Point(4, 23);
                this.TabPage3.Name = "TabPage3";
                this.TabPage3.Size = new System.Drawing.Size(816, 383);
                this.TabPage3.TabIndex = 2;
                this.TabPage3.Text = "C (Others)";
                // 
                // groupBox3
                // 
                this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox3.Controls.Add(this.label2);
                this.groupBox3.Controls.Add(this.label9);
                this.groupBox3.Controls.Add(this.label58);
                this.groupBox3.Controls.Add(this.label10);
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
                this.groupBox3.Location = new System.Drawing.Point(7, 265);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(801, 114);
                this.groupBox3.TabIndex = 142;
                this.groupBox3.TabStop = false;
                this.groupBox3.Text = "Sub-folio C Summary";
                // 
                // label2
                // 
                this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label2.Location = new System.Drawing.Point(612, 77);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(89, 14);
                this.label2.TabIndex = 114;
                this.label2.Text = "Commission :";
                this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label9
                // 
                this.label9.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label9.Location = new System.Drawing.Point(612, 59);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(89, 14);
                this.label9.TabIndex = 113;
                this.label9.Text = "Service Charge :";
                this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label58
                // 
                this.label58.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label58.Location = new System.Drawing.Point(195, 40);
                this.label58.Name = "label58";
                this.label58.Size = new System.Drawing.Size(94, 14);
                this.label58.TabIndex = 108;
                this.label58.Text = "Charge Payment :";
                this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label10
                // 
                this.label10.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label10.Location = new System.Drawing.Point(195, 58);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(94, 14);
                this.label10.TabIndex = 107;
                this.label10.Text = "Cheque Payment :";
                this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label61
                // 
                this.label61.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label61.Location = new System.Drawing.Point(195, 22);
                this.label61.Name = "label61";
                this.label61.Size = new System.Drawing.Size(94, 14);
                this.label61.TabIndex = 106;
                this.label61.Text = "Cash Payment :";
                this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label62
                // 
                this.label62.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label62.Location = new System.Drawing.Point(195, 76);
                this.label62.Name = "label62";
                this.label62.Size = new System.Drawing.Size(94, 14);
                this.label62.TabIndex = 105;
                this.label62.Text = "Gift Cheque :";
                this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblChequePaymentC
                // 
                this.lblChequePaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblChequePaymentC.Location = new System.Drawing.Point(289, 58);
                this.lblChequePaymentC.Name = "lblChequePaymentC";
                this.lblChequePaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblChequePaymentC.TabIndex = 120;
                this.lblChequePaymentC.Text = "0.00";
                this.lblChequePaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblServiceChargeC
                // 
                this.lblServiceChargeC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblServiceChargeC.Location = new System.Drawing.Point(700, 59);
                this.lblServiceChargeC.Name = "lblServiceChargeC";
                this.lblServiceChargeC.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeC.TabIndex = 119;
                this.lblServiceChargeC.Text = "0.00";
                this.lblServiceChargeC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionC
                // 
                this.lblCommissionC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionC.Location = new System.Drawing.Point(700, 77);
                this.lblCommissionC.Name = "lblCommissionC";
                this.lblCommissionC.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionC.TabIndex = 118;
                this.lblCommissionC.Text = "0.00";
                this.lblCommissionC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxC
                // 
                this.lblLocalTaxC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxC.Location = new System.Drawing.Point(700, 40);
                this.lblLocalTaxC.Name = "lblLocalTaxC";
                this.lblLocalTaxC.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxC.TabIndex = 117;
                this.lblLocalTaxC.Text = "0.00";
                this.lblLocalTaxC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxC
                // 
                this.lblGovtTaxC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxC.Location = new System.Drawing.Point(700, 22);
                this.lblGovtTaxC.Name = "lblGovtTaxC";
                this.lblGovtTaxC.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxC.TabIndex = 116;
                this.lblGovtTaxC.Text = "0.00";
                this.lblGovtTaxC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label63
                // 
                this.label63.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label63.Location = new System.Drawing.Point(406, 40);
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
                this.label64.Location = new System.Drawing.Point(612, 40);
                this.label64.Name = "label64";
                this.label64.Size = new System.Drawing.Size(89, 14);
                this.label64.TabIndex = 112;
                this.label64.Text = "Local Tax :";
                this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label65
                // 
                this.label65.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label65.Location = new System.Drawing.Point(612, 22);
                this.label65.Name = "label65";
                this.label65.Size = new System.Drawing.Size(89, 14);
                this.label65.TabIndex = 111;
                this.label65.Text = "Gov\'t Tax :";
                this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label66
                // 
                this.label66.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label66.Location = new System.Drawing.Point(406, 22);
                this.label66.Name = "label66";
                this.label66.Size = new System.Drawing.Size(98, 14);
                this.label66.TabIndex = 110;
                this.label66.Text = "Balance :";
                this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label67
                // 
                this.label67.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label67.Location = new System.Drawing.Point(26, 40);
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
                this.label68.Location = new System.Drawing.Point(195, 94);
                this.label68.Name = "label68";
                this.label68.Size = new System.Drawing.Size(98, 14);
                this.label68.TabIndex = 104;
                this.label68.Text = "Others :";
                this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label69
                // 
                this.label69.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label69.Location = new System.Drawing.Point(26, 22);
                this.label69.Name = "label69";
                this.label69.Size = new System.Drawing.Size(62, 14);
                this.label69.TabIndex = 103;
                this.label69.Text = "Charges :";
                this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesC
                // 
                this.lblTotalChargesC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesC.Location = new System.Drawing.Point(87, 22);
                this.lblTotalChargesC.Name = "lblTotalChargesC";
                this.lblTotalChargesC.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesC.TabIndex = 103;
                this.lblTotalChargesC.Text = "0.00";
                this.lblTotalChargesC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountC
                // 
                this.lblTotalDiscountC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountC.Location = new System.Drawing.Point(87, 40);
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
                this.lblChargePaymentC.Location = new System.Drawing.Point(289, 40);
                this.lblChargePaymentC.Name = "lblChargePaymentC";
                this.lblChargePaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblChargePaymentC.TabIndex = 108;
                this.lblChargePaymentC.Text = "0.00";
                this.lblChargePaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGiftChequePaymentC
                // 
                this.lblGiftChequePaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGiftChequePaymentC.Location = new System.Drawing.Point(289, 76);
                this.lblGiftChequePaymentC.Name = "lblGiftChequePaymentC";
                this.lblGiftChequePaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblGiftChequePaymentC.TabIndex = 105;
                this.lblGiftChequePaymentC.Text = "0.00";
                this.lblGiftChequePaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCashPaymentC
                // 
                this.lblCashPaymentC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCashPaymentC.Location = new System.Drawing.Point(289, 22);
                this.lblCashPaymentC.Name = "lblCashPaymentC";
                this.lblCashPaymentC.Size = new System.Drawing.Size(82, 14);
                this.lblCashPaymentC.TabIndex = 106;
                this.lblCashPaymentC.Text = "0.00";
                this.lblCashPaymentC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblBalanceForwardC
                // 
                this.lblBalanceForwardC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblBalanceForwardC.Location = new System.Drawing.Point(289, 94);
                this.lblBalanceForwardC.Name = "lblBalanceForwardC";
                this.lblBalanceForwardC.Size = new System.Drawing.Size(82, 14);
                this.lblBalanceForwardC.TabIndex = 108;
                this.lblBalanceForwardC.Text = "0.00";
                this.lblBalanceForwardC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalNetC
                // 
                this.lblTotalNetC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalNetC.Location = new System.Drawing.Point(505, 40);
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
                this.lblTotalBalanceC.Location = new System.Drawing.Point(505, 22);
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
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader31});
                this.lvwSubFolioC.FullRowSelect = true;
                this.lvwSubFolioC.Location = new System.Drawing.Point(5, 40);
                this.lvwSubFolioC.Name = "lvwSubFolioC";
                this.lvwSubFolioC.Size = new System.Drawing.Size(808, 228);
                this.lvwSubFolioC.TabIndex = 135;
                this.lvwSubFolioC.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioC.View = System.Windows.Forms.View.Details;
                this.lvwSubFolioC.SelectedIndexChanged += new System.EventHandler(this.lvwSubFolioC_SelectedIndexChanged);
                this.lvwSubFolioC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwSubFolio_MouseUp);
                // 
                // columnHeader45
                // 
                this.columnHeader45.Text = "Date";
                this.columnHeader45.Width = 55;
                // 
                // columnHeader46
                // 
                this.columnHeader46.Text = "Posting Date";
                this.columnHeader46.Width = 0;
                // 
                // columnHeader47
                // 
                this.columnHeader47.Text = "Code";
                this.columnHeader47.Width = 40;
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
                // columnHeader54
                // 
                this.columnHeader54.Text = "Gross Amt.";
                this.columnHeader54.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader54.Width = 70;
                // 
                // columnHeader55
                // 
                this.columnHeader55.Text = "Discount";
                this.columnHeader55.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader55.Width = 54;
                // 
                // columnHeader56
                // 
                this.columnHeader56.Text = "Net Amount";
                this.columnHeader56.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader56.Width = 70;
                // 
                // columnHeader57
                // 
                this.columnHeader57.Text = "Balance";
                this.columnHeader57.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader57.Width = 70;
                // 
                // columnHeader58
                // 
                this.columnHeader58.Text = "Staff";
                this.columnHeader58.Width = 46;
                // 
                // columnHeader59
                // 
                this.columnHeader59.Text = "Net Base Amount";
                this.columnHeader59.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader59.Width = 0;
                // 
                // columnHeader31
                // 
                this.columnHeader31.Text = "TransactionNo";
                this.columnHeader31.Width = 0;
                // 
                // btnBrowseFolioC
                // 
                this.btnBrowseFolioC.Enabled = false;
                this.btnBrowseFolioC.ImageIndex = 0;
                this.btnBrowseFolioC.ImageList = this.imgIcon;
                this.btnBrowseFolioC.Location = new System.Drawing.Point(221, 10);
                this.btnBrowseFolioC.Name = "btnBrowseFolioC";
                this.btnBrowseFolioC.Size = new System.Drawing.Size(28, 24);
                this.btnBrowseFolioC.TabIndex = 129;
                // 
                // txtGuestNameC
                // 
                this.txtGuestNameC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtGuestNameC.BackColor = System.Drawing.SystemColors.Control;
                this.txtGuestNameC.Location = new System.Drawing.Point(251, 12);
                this.txtGuestNameC.Name = "txtGuestNameC";
                this.txtGuestNameC.ReadOnly = true;
                this.txtGuestNameC.Size = new System.Drawing.Size(562, 20);
                this.txtGuestNameC.TabIndex = 115;
                // 
                // txtFolioIdC
                // 
                this.txtFolioIdC.BackColor = System.Drawing.SystemColors.Info;
                this.txtFolioIdC.Location = new System.Drawing.Point(93, 12);
                this.txtFolioIdC.Name = "txtFolioIdC";
                this.txtFolioIdC.ReadOnly = true;
                this.txtFolioIdC.Size = new System.Drawing.Size(126, 20);
                this.txtFolioIdC.TabIndex = 114;
                // 
                // Label59
                // 
                this.Label59.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label59.Location = new System.Drawing.Point(20, 15);
                this.Label59.Name = "Label59";
                this.Label59.Size = new System.Drawing.Size(85, 14);
                this.Label59.TabIndex = 112;
                this.Label59.Text = "Account :";
                // 
                // TabPage4
                // 
                this.TabPage4.Controls.Add(this.groupBox6);
                this.TabPage4.Controls.Add(this.lvwSubFolioD);
                this.TabPage4.Controls.Add(this.btnBrowseFolioD);
                this.TabPage4.Controls.Add(this.txtGuestNameD);
                this.TabPage4.Controls.Add(this.txtFolioIdD);
                this.TabPage4.Controls.Add(this.Label4);
                this.TabPage4.Location = new System.Drawing.Point(4, 23);
                this.TabPage4.Name = "TabPage4";
                this.TabPage4.Size = new System.Drawing.Size(816, 383);
                this.TabPage4.TabIndex = 3;
                this.TabPage4.Text = "D (Others)";
                // 
                // groupBox6
                // 
                this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox6.Controls.Add(this.label72);
                this.groupBox6.Controls.Add(this.label73);
                this.groupBox6.Controls.Add(this.label74);
                this.groupBox6.Controls.Add(this.label75);
                this.groupBox6.Controls.Add(this.label76);
                this.groupBox6.Controls.Add(this.label77);
                this.groupBox6.Controls.Add(this.lblChequePaymentD);
                this.groupBox6.Controls.Add(this.lblServiceChargeD);
                this.groupBox6.Controls.Add(this.lblCommissionD);
                this.groupBox6.Controls.Add(this.lblLocalTaxD);
                this.groupBox6.Controls.Add(this.lblGovtTaxD);
                this.groupBox6.Controls.Add(this.label78);
                this.groupBox6.Controls.Add(this.label79);
                this.groupBox6.Controls.Add(this.label80);
                this.groupBox6.Controls.Add(this.label81);
                this.groupBox6.Controls.Add(this.label82);
                this.groupBox6.Controls.Add(this.label83);
                this.groupBox6.Controls.Add(this.label84);
                this.groupBox6.Controls.Add(this.lblTotalChargesD);
                this.groupBox6.Controls.Add(this.lblTotalDiscountD);
                this.groupBox6.Controls.Add(this.lblChargePaymentD);
                this.groupBox6.Controls.Add(this.lblGiftChequePaymentD);
                this.groupBox6.Controls.Add(this.lblCashPaymentD);
                this.groupBox6.Controls.Add(this.lblBalanceForwardD);
                this.groupBox6.Controls.Add(this.lblTotalNetD);
                this.groupBox6.Controls.Add(this.lblTotalBalanceD);
                this.groupBox6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.groupBox6.Location = new System.Drawing.Point(7, 265);
                this.groupBox6.Name = "groupBox6";
                this.groupBox6.Size = new System.Drawing.Size(801, 114);
                this.groupBox6.TabIndex = 142;
                this.groupBox6.TabStop = false;
                this.groupBox6.Text = "Sub-folio D Summary";
                // 
                // label72
                // 
                this.label72.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label72.Location = new System.Drawing.Point(612, 77);
                this.label72.Name = "label72";
                this.label72.Size = new System.Drawing.Size(89, 14);
                this.label72.TabIndex = 114;
                this.label72.Text = "Commission :";
                this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label73
                // 
                this.label73.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label73.Location = new System.Drawing.Point(612, 59);
                this.label73.Name = "label73";
                this.label73.Size = new System.Drawing.Size(89, 14);
                this.label73.TabIndex = 113;
                this.label73.Text = "Service Charge :";
                this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label74
                // 
                this.label74.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label74.Location = new System.Drawing.Point(195, 40);
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
                this.label76.Location = new System.Drawing.Point(195, 22);
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
                this.lblServiceChargeD.Location = new System.Drawing.Point(700, 59);
                this.lblServiceChargeD.Name = "lblServiceChargeD";
                this.lblServiceChargeD.Size = new System.Drawing.Size(82, 14);
                this.lblServiceChargeD.TabIndex = 119;
                this.lblServiceChargeD.Text = "0.00";
                this.lblServiceChargeD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblCommissionD
                // 
                this.lblCommissionD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblCommissionD.Location = new System.Drawing.Point(700, 77);
                this.lblCommissionD.Name = "lblCommissionD";
                this.lblCommissionD.Size = new System.Drawing.Size(82, 14);
                this.lblCommissionD.TabIndex = 118;
                this.lblCommissionD.Text = "0.00";
                this.lblCommissionD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblLocalTaxD
                // 
                this.lblLocalTaxD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblLocalTaxD.Location = new System.Drawing.Point(700, 40);
                this.lblLocalTaxD.Name = "lblLocalTaxD";
                this.lblLocalTaxD.Size = new System.Drawing.Size(82, 14);
                this.lblLocalTaxD.TabIndex = 117;
                this.lblLocalTaxD.Text = "0.00";
                this.lblLocalTaxD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblGovtTaxD
                // 
                this.lblGovtTaxD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblGovtTaxD.Location = new System.Drawing.Point(700, 22);
                this.lblGovtTaxD.Name = "lblGovtTaxD";
                this.lblGovtTaxD.Size = new System.Drawing.Size(82, 14);
                this.lblGovtTaxD.TabIndex = 116;
                this.lblGovtTaxD.Text = "0.00";
                this.lblGovtTaxD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // label78
                // 
                this.label78.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label78.Location = new System.Drawing.Point(406, 40);
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
                this.label79.Location = new System.Drawing.Point(612, 40);
                this.label79.Name = "label79";
                this.label79.Size = new System.Drawing.Size(89, 14);
                this.label79.TabIndex = 112;
                this.label79.Text = "Local Tax :";
                this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label80
                // 
                this.label80.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label80.Location = new System.Drawing.Point(612, 22);
                this.label80.Name = "label80";
                this.label80.Size = new System.Drawing.Size(89, 14);
                this.label80.TabIndex = 111;
                this.label80.Text = "Gov\'t Tax :";
                this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label81
                // 
                this.label81.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label81.Location = new System.Drawing.Point(406, 22);
                this.label81.Name = "label81";
                this.label81.Size = new System.Drawing.Size(98, 14);
                this.label81.TabIndex = 110;
                this.label81.Text = "Balance :";
                this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label82
                // 
                this.label82.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label82.Location = new System.Drawing.Point(26, 40);
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
                this.label84.Location = new System.Drawing.Point(26, 22);
                this.label84.Name = "label84";
                this.label84.Size = new System.Drawing.Size(62, 14);
                this.label84.TabIndex = 103;
                this.label84.Text = "Charges :";
                this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lblTotalChargesD
                // 
                this.lblTotalChargesD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalChargesD.Location = new System.Drawing.Point(87, 22);
                this.lblTotalChargesD.Name = "lblTotalChargesD";
                this.lblTotalChargesD.Size = new System.Drawing.Size(82, 14);
                this.lblTotalChargesD.TabIndex = 103;
                this.lblTotalChargesD.Text = "0.00";
                this.lblTotalChargesD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // lblTotalDiscountD
                // 
                this.lblTotalDiscountD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.lblTotalDiscountD.Location = new System.Drawing.Point(87, 40);
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
                this.lblChargePaymentD.Location = new System.Drawing.Point(289, 40);
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
                this.lblCashPaymentD.Location = new System.Drawing.Point(289, 22);
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
                this.lblTotalNetD.Location = new System.Drawing.Point(505, 40);
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
                this.lblTotalBalanceD.Location = new System.Drawing.Point(505, 22);
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
            this.columnHeader1,
            this.columnHeader12,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader30,
            this.columnHeader32});
                this.lvwSubFolioD.FullRowSelect = true;
                this.lvwSubFolioD.Location = new System.Drawing.Point(5, 40);
                this.lvwSubFolioD.Name = "lvwSubFolioD";
                this.lvwSubFolioD.Size = new System.Drawing.Size(808, 228);
                this.lvwSubFolioD.TabIndex = 136;
                this.lvwSubFolioD.UseCompatibleStateImageBehavior = false;
                this.lvwSubFolioD.View = System.Windows.Forms.View.Details;
                this.lvwSubFolioD.SelectedIndexChanged += new System.EventHandler(this.lvwSubFolioD_SelectedIndexChanged);
                this.lvwSubFolioD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwSubFolio_MouseUp);
                // 
                // columnHeader1
                // 
                this.columnHeader1.Text = "Date";
                this.columnHeader1.Width = 55;
                // 
                // columnHeader12
                // 
                this.columnHeader12.Text = "Posting Date";
                this.columnHeader12.Width = 0;
                // 
                // columnHeader16
                // 
                this.columnHeader16.Text = "Code";
                this.columnHeader16.Width = 40;
                // 
                // columnHeader17
                // 
                this.columnHeader17.Text = "Memo";
                this.columnHeader17.Width = 139;
                // 
                // columnHeader18
                // 
                this.columnHeader18.Text = "Source";
                this.columnHeader18.Width = 72;
                // 
                // columnHeader19
                // 
                this.columnHeader19.Text = "Ref. No.";
                this.columnHeader19.Width = 75;
                // 
                // columnHeader20
                // 
                this.columnHeader20.Text = "Amount";
                this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader20.Width = 72;
                // 
                // columnHeader22
                // 
                this.columnHeader22.Text = "Tax";
                this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader22.Width = 59;
                // 
                // columnHeader23
                // 
                this.columnHeader23.Text = "Service Charge";
                this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader23.Width = 0;
                // 
                // columnHeader24
                // 
                this.columnHeader24.Text = "Gross Amt.";
                this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader24.Width = 70;
                // 
                // columnHeader25
                // 
                this.columnHeader25.Text = "Discount";
                this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader25.Width = 54;
                // 
                // columnHeader26
                // 
                this.columnHeader26.Text = "Net Amount";
                this.columnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader26.Width = 70;
                // 
                // columnHeader27
                // 
                this.columnHeader27.Text = "Balance";
                this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader27.Width = 70;
                // 
                // columnHeader28
                // 
                this.columnHeader28.Text = "Staff";
                this.columnHeader28.Width = 46;
                // 
                // columnHeader30
                // 
                this.columnHeader30.Text = "Net Base Amount";
                this.columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.columnHeader30.Width = 0;
                // 
                // columnHeader32
                // 
                this.columnHeader32.Text = "TransactionNo";
                this.columnHeader32.Width = 0;
                // 
                // btnBrowseFolioD
                // 
                this.btnBrowseFolioD.Enabled = false;
                this.btnBrowseFolioD.ImageIndex = 0;
                this.btnBrowseFolioD.ImageList = this.imgIcon;
                this.btnBrowseFolioD.Location = new System.Drawing.Point(221, 10);
                this.btnBrowseFolioD.Name = "btnBrowseFolioD";
                this.btnBrowseFolioD.Size = new System.Drawing.Size(28, 24);
                this.btnBrowseFolioD.TabIndex = 128;
                // 
                // txtGuestNameD
                // 
                this.txtGuestNameD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.txtGuestNameD.BackColor = System.Drawing.SystemColors.Control;
                this.txtGuestNameD.Location = new System.Drawing.Point(251, 12);
                this.txtGuestNameD.Name = "txtGuestNameD";
                this.txtGuestNameD.ReadOnly = true;
                this.txtGuestNameD.Size = new System.Drawing.Size(562, 20);
                this.txtGuestNameD.TabIndex = 126;
                // 
                // txtFolioIdD
                // 
                this.txtFolioIdD.BackColor = System.Drawing.SystemColors.Info;
                this.txtFolioIdD.Location = new System.Drawing.Point(93, 12);
                this.txtFolioIdD.Name = "txtFolioIdD";
                this.txtFolioIdD.ReadOnly = true;
                this.txtFolioIdD.Size = new System.Drawing.Size(126, 20);
                this.txtFolioIdD.TabIndex = 125;
                // 
                // Label4
                // 
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label4.Location = new System.Drawing.Point(20, 15);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(85, 14);
                this.Label4.TabIndex = 124;
                this.Label4.Text = "Account :";
                // 
                // btnCheckOut
                // 
                this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnCheckOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCheckOut.Location = new System.Drawing.Point(120, 609);
                this.btnCheckOut.Name = "btnCheckOut";
                this.btnCheckOut.Size = new System.Drawing.Size(129, 31);
                this.btnCheckOut.TabIndex = 1;
                this.btnCheckOut.Text = "&Close Event Window";
                this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
                // 
                // GroupBox5
                // 
                this.GroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.GroupBox5.BackColor = System.Drawing.SystemColors.ControlLight;
                this.GroupBox5.Controls.Add(this.txtPayment_Mode);
                this.GroupBox5.Controls.Add(this.label48);
                this.GroupBox5.Controls.Add(this.txtAccount_Type);
                this.GroupBox5.Controls.Add(this.label47);
                this.GroupBox5.Controls.Add(this.txtRoomId);
                this.GroupBox5.Controls.Add(this.txtGuestName);
                this.GroupBox5.Controls.Add(this.txtFolioId);
                this.GroupBox5.Controls.Add(this.txtBalance);
                this.GroupBox5.Controls.Add(this.label46);
                this.GroupBox5.Controls.Add(this.txtTotalPayment);
                this.GroupBox5.Controls.Add(this.txtTotalCharges);
                this.GroupBox5.Controls.Add(this.label21);
                this.GroupBox5.Controls.Add(this.label32);
                this.GroupBox5.Controls.Add(this.txtDepartureDate);
                this.GroupBox5.Controls.Add(this.txtArrivalDate);
                this.GroupBox5.Controls.Add(this.label6);
                this.GroupBox5.Controls.Add(this.label5);
                this.GroupBox5.Controls.Add(this.Label115);
                this.GroupBox5.Controls.Add(this.Label118);
                this.GroupBox5.Controls.Add(this.Label114);
                this.GroupBox5.Controls.Add(this.txtRemarks);
                this.GroupBox5.Controls.Add(this.Label3);
                this.GroupBox5.Location = new System.Drawing.Point(8, 33);
                this.GroupBox5.Name = "GroupBox5";
                this.GroupBox5.Size = new System.Drawing.Size(826, 153);
                this.GroupBox5.TabIndex = 116;
                this.GroupBox5.TabStop = false;
                // 
                // txtPayment_Mode
                // 
                this.txtPayment_Mode.BackColor = System.Drawing.SystemColors.Control;
                this.txtPayment_Mode.Location = new System.Drawing.Point(315, 41);
                this.txtPayment_Mode.Name = "txtPayment_Mode";
                this.txtPayment_Mode.ReadOnly = true;
                this.txtPayment_Mode.Size = new System.Drawing.Size(99, 20);
                this.txtPayment_Mode.TabIndex = 132;
                // 
                // label48
                // 
                this.label48.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label48.Location = new System.Drawing.Point(222, 44);
                this.label48.Name = "label48";
                this.label48.Size = new System.Drawing.Size(96, 15);
                this.label48.TabIndex = 131;
                this.label48.Text = "Payment Mode :";
                this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtAccount_Type
                // 
                this.txtAccount_Type.BackColor = System.Drawing.SystemColors.Control;
                this.txtAccount_Type.Location = new System.Drawing.Point(315, 15);
                this.txtAccount_Type.Name = "txtAccount_Type";
                this.txtAccount_Type.ReadOnly = true;
                this.txtAccount_Type.Size = new System.Drawing.Size(99, 20);
                this.txtAccount_Type.TabIndex = 130;
                // 
                // label47
                // 
                this.label47.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label47.Location = new System.Drawing.Point(222, 18);
                this.label47.Name = "label47";
                this.label47.Size = new System.Drawing.Size(96, 15);
                this.label47.TabIndex = 129;
                this.label47.Text = "Guest Type :";
                this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtRoomId
                // 
                this.txtRoomId.BackColor = System.Drawing.SystemColors.Control;
                this.txtRoomId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtRoomId.Location = new System.Drawing.Point(105, 15);
                this.txtRoomId.Name = "txtRoomId";
                this.txtRoomId.ReadOnly = true;
                this.txtRoomId.Size = new System.Drawing.Size(88, 20);
                this.txtRoomId.TabIndex = 128;
                this.txtRoomId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtGuestName
                // 
                this.txtGuestName.BackColor = System.Drawing.SystemColors.Control;
                this.txtGuestName.Location = new System.Drawing.Point(105, 71);
                this.txtGuestName.Name = "txtGuestName";
                this.txtGuestName.ReadOnly = true;
                this.txtGuestName.Size = new System.Drawing.Size(187, 20);
                this.txtGuestName.TabIndex = 127;
                // 
                // txtFolioId
                // 
                this.txtFolioId.BackColor = System.Drawing.SystemColors.Control;
                this.txtFolioId.Location = new System.Drawing.Point(105, 44);
                this.txtFolioId.Name = "txtFolioId";
                this.txtFolioId.ReadOnly = true;
                this.txtFolioId.Size = new System.Drawing.Size(88, 20);
                this.txtFolioId.TabIndex = 126;
                this.txtFolioId.TextChanged += new System.EventHandler(this.txtFolioId_TextChanged);
                // 
                // txtBalance
                // 
                this.txtBalance.BackColor = System.Drawing.SystemColors.Control;
                this.txtBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtBalance.ForeColor = System.Drawing.Color.Black;
                this.txtBalance.Location = new System.Drawing.Point(500, 119);
                this.txtBalance.Name = "txtBalance";
                this.txtBalance.ReadOnly = true;
                this.txtBalance.Size = new System.Drawing.Size(99, 20);
                this.txtBalance.TabIndex = 125;
                this.txtBalance.Text = "0.00";
                this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label46
                // 
                this.label46.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label46.Location = new System.Drawing.Point(431, 124);
                this.label46.Name = "label46";
                this.label46.Size = new System.Drawing.Size(96, 15);
                this.label46.TabIndex = 124;
                this.label46.Text = "Balance :";
                this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtTotalPayment
                // 
                this.txtTotalPayment.BackColor = System.Drawing.SystemColors.Control;
                this.txtTotalPayment.Location = new System.Drawing.Point(315, 123);
                this.txtTotalPayment.Name = "txtTotalPayment";
                this.txtTotalPayment.ReadOnly = true;
                this.txtTotalPayment.Size = new System.Drawing.Size(99, 20);
                this.txtTotalPayment.TabIndex = 123;
                this.txtTotalPayment.Text = "0.00";
                this.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtTotalCharges
                // 
                this.txtTotalCharges.BackColor = System.Drawing.SystemColors.Control;
                this.txtTotalCharges.Location = new System.Drawing.Point(315, 97);
                this.txtTotalCharges.Name = "txtTotalCharges";
                this.txtTotalCharges.ReadOnly = true;
                this.txtTotalCharges.Size = new System.Drawing.Size(99, 20);
                this.txtTotalCharges.TabIndex = 122;
                this.txtTotalCharges.Text = "0.00";
                this.txtTotalCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label21
                // 
                this.label21.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label21.Location = new System.Drawing.Point(222, 127);
                this.label21.Name = "label21";
                this.label21.Size = new System.Drawing.Size(96, 15);
                this.label21.TabIndex = 121;
                this.label21.Text = "Total Payment :";
                this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label32
                // 
                this.label32.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label32.Location = new System.Drawing.Point(222, 101);
                this.label32.Name = "label32";
                this.label32.Size = new System.Drawing.Size(83, 15);
                this.label32.TabIndex = 120;
                this.label32.Text = "Total Charges :";
                this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtDepartureDate
                // 
                this.txtDepartureDate.BackColor = System.Drawing.SystemColors.Control;
                this.txtDepartureDate.Location = new System.Drawing.Point(105, 124);
                this.txtDepartureDate.Name = "txtDepartureDate";
                this.txtDepartureDate.ReadOnly = true;
                this.txtDepartureDate.Size = new System.Drawing.Size(88, 20);
                this.txtDepartureDate.TabIndex = 119;
                // 
                // txtArrivalDate
                // 
                this.txtArrivalDate.BackColor = System.Drawing.SystemColors.Control;
                this.txtArrivalDate.Location = new System.Drawing.Point(105, 98);
                this.txtArrivalDate.Name = "txtArrivalDate";
                this.txtArrivalDate.ReadOnly = true;
                this.txtArrivalDate.Size = new System.Drawing.Size(88, 20);
                this.txtArrivalDate.TabIndex = 118;
                // 
                // label6
                // 
                this.label6.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label6.Location = new System.Drawing.Point(12, 128);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(96, 15);
                this.label6.TabIndex = 117;
                this.label6.Text = "Departure Date :";
                this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label5
                // 
                this.label5.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label5.Location = new System.Drawing.Point(12, 102);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(74, 15);
                this.label5.TabIndex = 116;
                this.label5.Text = "Arrival Date :";
                this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label115
                // 
                this.Label115.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label115.Location = new System.Drawing.Point(12, 74);
                this.Label115.Name = "Label115";
                this.Label115.Size = new System.Drawing.Size(60, 14);
                this.Label115.TabIndex = 111;
                this.Label115.Text = "Guest :";
                this.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label118
                // 
                this.Label118.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label118.Location = new System.Drawing.Point(12, 18);
                this.Label118.Name = "Label118";
                this.Label118.Size = new System.Drawing.Size(60, 14);
                this.Label118.TabIndex = 110;
                this.Label118.Text = "Room No :";
                this.Label118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label114
                // 
                this.Label114.Font = new System.Drawing.Font("Arial", 8.25F);
                this.Label114.Location = new System.Drawing.Point(12, 47);
                this.Label114.Name = "Label114";
                this.Label114.Size = new System.Drawing.Size(58, 14);
                this.Label114.TabIndex = 106;
                this.Label114.Text = "Folio ID :";
                this.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // txtRemarks
                // 
                this.txtRemarks.BackColor = System.Drawing.SystemColors.Control;
                this.txtRemarks.Location = new System.Drawing.Point(500, 16);
                this.txtRemarks.Multiline = true;
                this.txtRemarks.Name = "txtRemarks";
                this.txtRemarks.ReadOnly = true;
                this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtRemarks.Size = new System.Drawing.Size(310, 77);
                this.txtRemarks.TabIndex = 115;
                // 
                // Label3
                // 
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.Label3.Location = new System.Drawing.Point(431, 17);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(63, 14);
                this.Label3.TabIndex = 114;
                this.Label3.Text = "Remarks";
                this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // popUpMenu
                // 
                this.popUpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInsert,
            this.MenuItem2,
            this.mnuCheckout,
            this.MenuItem4,
            this.mnuVoid,
            this.mnuRecall,
            this.MenuItem7,
            this.mnuCityLedger,
            this.menuItem3,
            this.mnuRefreshLedger});
                // 
                // mnuInsert
                // 
                this.mnuInsert.DefaultItem = true;
                this.mnuInsert.Index = 0;
                this.mnuInsert.Text = "Insert";
                this.mnuInsert.Click += new System.EventHandler(this.mnuInsert_Click);
                // 
                // MenuItem2
                // 
                this.MenuItem2.Index = 1;
                this.MenuItem2.Text = "-";
                // 
                // mnuCheckout
                // 
                this.mnuCheckout.Index = 2;
                this.mnuCheckout.Text = "Check Out";
                this.mnuCheckout.Click += new System.EventHandler(this.mnuCheckout_Click);
                // 
                // MenuItem4
                // 
                this.MenuItem4.Index = 3;
                this.MenuItem4.Text = "-";
                // 
                // mnuVoid
                // 
                this.mnuVoid.Index = 4;
                this.mnuVoid.Text = "Void";
                this.mnuVoid.Click += new System.EventHandler(this.mnuVoid_Click);
                // 
                // mnuRecall
                // 
                this.mnuRecall.Index = 5;
                this.mnuRecall.Text = "Recall";
                this.mnuRecall.Click += new System.EventHandler(this.mnuRecall_Click);
                // 
                // MenuItem7
                // 
                this.MenuItem7.Index = 6;
                this.MenuItem7.Text = "-";
                // 
                // mnuCityLedger
                // 
                this.mnuCityLedger.Index = 7;
                this.mnuCityLedger.Text = "City Ledger";
                // 
                // menuItem3
                // 
                this.menuItem3.Index = 8;
                this.menuItem3.Text = "-";
                // 
                // mnuRefreshLedger
                // 
                this.mnuRefreshLedger.Index = 9;
                this.mnuRefreshLedger.Text = "Refresh";
                this.mnuRefreshLedger.Click += new System.EventHandler(this.mnuRefreshLedger_Click);
                // 
                // label22
                // 
                this.label22.AutoSize = true;
                this.label22.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label22.Location = new System.Drawing.Point(9, 9);
                this.label22.Name = "label22";
                this.label22.Size = new System.Drawing.Size(124, 22);
                this.label22.TabIndex = 118;
                this.label22.Text = "Event Ledger";
                this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // btnPostToAccounting
                // 
                this.btnPostToAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnPostToAccounting.Location = new System.Drawing.Point(255, 609);
                this.btnPostToAccounting.Name = "btnPostToAccounting";
                this.btnPostToAccounting.Size = new System.Drawing.Size(130, 31);
                this.btnPostToAccounting.TabIndex = 119;
                this.btnPostToAccounting.Text = "&Post To Accounting";
                this.btnPostToAccounting.UseVisualStyleBackColor = true;
                this.btnPostToAccounting.Click += new System.EventHandler(this.btnPostToAccounting_Click);
                // 
                // FolioLedgerUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(848, 647);
                this.Controls.Add(this.btnPostToAccounting);
                this.Controls.Add(this.label22);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnAdd);
                this.Controls.Add(this.tabSubFolio);
                this.Controls.Add(this.btnVoid);
                this.Controls.Add(this.GroupBox5);
                this.Controls.Add(this.btnRecall);
                this.Controls.Add(this.btnBacktoList);
                this.Controls.Add(this.btnCheckOut);
                this.Name = "FolioLedgerUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Event Ledger";
                this.Load += new System.EventHandler(this.FolioLedgerUI_Load);
                this.Activated += new System.EventHandler(this.FolioLedgerUI_Activated);
                this.tabSubFolio.ResumeLayout(false);
                this.TabPage1.ResumeLayout(false);
                this.GroupBox4.ResumeLayout(false);
                this.TabPage2.ResumeLayout(false);
                this.TabPage2.PerformLayout();
                this.groupBox1.ResumeLayout(false);
                this.TabPage3.ResumeLayout(false);
                this.TabPage3.PerformLayout();
                this.groupBox3.ResumeLayout(false);
                this.TabPage4.ResumeLayout(false);
                this.TabPage4.PerformLayout();
                this.groupBox6.ResumeLayout(false);
                this.GroupBox5.ResumeLayout(false);
                this.GroupBox5.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			
			#endregion
			
	
            private string shareRoomNo = "";

            private Object loReservation;
            public FolioLedgerUI(string folioID, string roomNo, Object obj) : this(folioID, roomNo)
            {
                loReservation = obj;
            }

			// >> Used in: FolioLedgersUI.lvwIndividual.DoubleClick()
			public FolioLedgerUI(string folioID, string roomNo)
			{
				InitializeComponent();

                shareRoomNo = roomNo;
				this.txtFolioId.Text = folioID;

				this.txtRoomId.Text = roomNo;
			}


			// >> Used in: FolioLedgersUI.lvwGroup.DoubleClick()
			public FolioLedgerUI(string folioID)
			{
				InitializeComponent();

				this.txtFolioId.Text = folioID;
			}
			
			// >> REVISION::: JEROME
			private void txtFolioId_TextChanged(object sender, System.EventArgs e)
			{
				if (this.txtFolioId.Text != "")
				{
					LoadPersonalInfo();
				}
			}
			
			private Company oCompany;
			//private CompanyFacade oCompanyFacade;

			public void LoadPersonalInfo()
			{
				// Try
				oCompany = new Company();
                CompanyFacade oCompanyFacade = new CompanyFacade();

				oFolio = new Folio();
				oFolioFacade = new FolioFacade();
				oFolio = oFolioFacade.GetFolio(this.txtFolioId.Text);

				Guest oGuest = new Guest();
				GuestFacade oGuestFacade = new GuestFacade();
				oGuest = oGuestFacade.getGuestRecord(oFolio.AccountID);

				//oFolio = oFolioFacade.GetGuestFolioInfo(this.lblFolioId.Text);

                if (oFolio.CompanyID != "")
                {
                    oCompany = oCompanyFacade.getCompanyAccount(oFolio.CompanyID);
                    this.txtCompanyId.Text = oFolio.CompanyID;
                    this.txtCompanyName.Text = oCompany.CompanyName;
                }

				this.txtRemarks.Text = oFolio.Remarks;
				
				this.txtArrivalDate.Text = oFolio.FromDate.ToString("dd-MMM-yyyy");
				this.txtDepartureDate.Text = oFolio.Todate.ToString("dd-MMM-yyyy"); //string.Format("{0:dd-MMM-yyyy}", oFolio.DepartureDate);


				switch (oFolio.FolioType.ToUpper())
				{
					case "DEPENDENT":

                        try
                        {
                            oCompany = oCompanyFacade.getCompanyInfo(oFolio.MasterFolio);
                            this.txtCompanyId.Text = oCompany.CompanyId;
                            oFolio.CompanyID = this.txtCompanyId.Text;
                            this.txtCompanyName.Text = oCompany.CompanyName;
                        }
                        catch
                        {
                            Guest oGroupGuest = new Guest();
                            oGroupGuest = oGuestFacade.getGuestRecord(oFolio.CompanyID);
                            this.txtCompanyId.Text = oGroupGuest.AccountId;
                            oFolio.CompanyID = this.txtCompanyId.Text;
                            this.txtCompanyName.Text = oGroupGuest.LastName + ", " + oGroupGuest.FirstName;
                        }

						this.txtGuestName.Tag = oFolio.AccountID;
						this.txtGuestName.Text = oGuest.LastName + ", " + oGuest.FirstName;

						this.txtAccount_Type.Text = oFolio.AccountType;
						this.txtPayment_Mode.Text = oFolio.Payment_Mode;

						break;
						
					case "SHARE":

						this.txtGuestName.Tag = oFolio.AccountID;
						this.txtGuestName.Text = oGuest.LastName + ", " + oGuest.FirstName;

						this.txtAccount_Type.Text = oFolio.AccountType;
						this.txtPayment_Mode.Text = oFolio.Payment_Mode;

                        this.Text = "Room No. " + shareRoomNo;
                        shareRoomNo = "-";
                        
						break;
                        // removes unnecessary TABS [only 1 tab(SUBFOLIO-A) for GROUP]
					case "GROUP":
                        removeUnnecessaryTabs("GROUP");

                        if (oFolio.CompanyID.StartsWith("G"))
                        {
                            oCompany = oCompanyFacade.getCompanyInfo(this.txtFolioId.Text);
                            this.txtGuestName.Tag = oCompany.CompanyId;
                            this.txtGuestName.Text = oCompany.CompanyName;
                        }
                        else
                        {
                            oGuest = oGuestFacade.getGuestRecord(oFolio.CompanyID);
                            txtGuestName.Tag = oGuest.AccountId;
                            txtGuestName.Text = oGuest.LastName + ", " + oGuest.FirstName;
                        }

						this.txtAccount_Type.Text = oFolio.AccountType;
						this.txtPayment_Mode.Text = oFolio.Payment_Mode;

						//this.lblAccountId.Text = oCompany.CompanyId;
						//this.lblGuestName.Text = oCompany.CompanyName;

                        //this.btnBacktoList.Enabled = true; 

						break;

                    default:

                        this.txtGuestName.Tag = oFolio.AccountID;
						this.txtGuestName.Text = oGuest.LastName + ", " + oGuest.FirstName;//oFolio.Tables[0].Rows[0]["GuestName"].ToString();

						this.txtAccount_Type.Text = oFolio.AccountType;
						this.txtPayment_Mode.Text = oFolio.Payment_Mode;

                        break;
				}

				if (oFolio != null)
				{
                    
                    /* revised : jrom 18-Jan-07
                     * desc      this has been added so that Reserved guest could be
                     *           added a folio transaction (advance deposit)
                     */ 
                    if (oFolio.Status != "ONGOING")
                    {
                        this.btnCheckOut.Enabled = false;
                    }


					LoadTransactionsToSubFolio(oFolio);
				}
				
			}

            private int removeUnnecessaryTabs(string TYPE)
            {
                switch (TYPE)
                { 
                    case "GROUP":
                        this.TabPage1.Text = "A (Company)";
                        this.tabSubFolio.TabPages.Remove(TabPage2);
                        this.tabSubFolio.TabPages.Remove(TabPage3);
                        this.tabSubFolio.TabPages.Remove(TabPage4);
                        break;
                    
                }
                return 1;
            }

			private void lblRoomID_TextChanged(object sender, System.EventArgs e)
			{
                //if (this.lblRoomID.Text != "-")
                //{
                //    LoadFolioTransactions();
                //}
			}
			
         
			public void LoadTransactionsToSubFolio(Folio oFolio)
			{
				decimal totalCharges = 0;
				decimal totalPayments = 0;
				decimal balance = 0;

				if (oFolio != null)
				{
					oFolio.CreateSubFolio();
					SubFolio subF;
					foreach (SubFolio tempLoopVar_subF in oFolio.SubFolios)
					{
						subF = tempLoopVar_subF;
						subF.Folio.FolioTransactions = oFolioFacade.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
						subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
						
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
				}



				this.txtTotalCharges.Text = totalCharges.ToString("N");
				this.txtTotalPayment.Text = totalPayments.ToString("N");
				this.txtBalance.Text = balance.ToString("N");

			}
			
			private void btnAdd_Click(System.Object sender, System.EventArgs e)
			    {
				// this is to trace all folio transactions
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
				
			    AddTransactionUI AddTransactionUI = new AddTransactionUI(oFolio, this.txtFolioId, subFolioTab, "All");
				
                if (this.tabSubFolio.SelectedIndex > 0)
				{
					AddTransactionUI.chkApplyPrivileges.Visible = false;
					AddTransactionUI.chkAppyRouting.Visible = false;
				}
				
                AddTransactionUI.ShowDialog(this);
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

                            if (_oFolioTransaction.NetAmount.ToString().Contains("-"))
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

						//// changing color of ITEM [DEBIT/CREDIT]
						//if (_oFolioTransaction.AcctSide == "DEBIT")
						//{
						//    lvwItem.ForeColor = Color.Black;
						//}
						//else
						//{
						//    lvwItem.ForeColor = Color.Red;
						//}
						lvwItem.UseItemStyleForSubItems = false;
						//ListViewItem.ListViewSubItem lvwSubItem = lvwItem.SubItems[6];
						//lvwSubItem.ForeColor = Color.Red;
						foreach (ListViewItem.ListViewSubItem lvwSubItem in lvwItem.SubItems)
						{
							lvwSubItem.BackColor = lvwItem.BackColor;
						}
					}

				}
				catch (Exception ex)
				{
					//oFolio = Nothing
					//Exit Sub
					MessageBox.Show(ex.Message, "LoadInListView Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
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
				this.lblTotalNetA.Text = fLedger.TotalNet.ToString("N");
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
				this.lblChargePaymentB.Text =fLedger.PayCard.ToString("N");
				this.lblChequePaymentB.Text = fLedger.PayCheque.ToString("N");
				this.lblGiftChequePaymentB.Text = fLedger.PayGiftCheque.ToString("N");
				this.lblTotalBalanceB.Text = fLedger.BalanceNet.ToString("N");
				this.lblBalanceForwardB.Text = fLedger.BalanceForwarded.ToString("N");
				this.lblTotalNetB.Text =fLedger.TotalNet.ToString("N");
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
				this.lblTotalNetC.Text = fLedger.TotalNet.ToString("N");
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
				this.lblTotalNetD.Text = fLedger.TotalNet.ToString("N");
				this.lblGovtTaxD.Text = fLedger.GovernmentTax.ToString("N");
				this.lblLocalTaxD.Text = fLedger.LocalTax.ToString("N");
				this.lblCommissionD.Text = fLedger.AgentComission.ToString("N");
				this.lblServiceChargeD.Text = fLedger.ServiceCharge.ToString("N");
			}
			
			private FolioTransactionFacade oFolioTransFacade;
			private void btnVoid_Click(System.Object sender, System.EventArgs e)
			{
                // this is to trace all folio transactions
                //Kevin L. Oliveros
                //if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
                //{
                //    MessageBox.Show("Can't proceed transaction.\r\nNo Shift/Cash drawer open.\r\n\r\nTo Open Shift/Cash Drawer goto Transactions menu, Cashiering->Open Shift/Cash drawer.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

                try
                {
                    string vMemo = "";
                    System.Drawing.Color lvwBackColor = System.Drawing.Color.White;

                    
						oFolioTransaction = new FolioTransaction();
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
                        // posted to ACCOUTING...
                        if (lvwBackColor == System.Drawing.Color.Gainsboro )
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

                            oFolioTransFacade = new FolioTransactionFacade();

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

            private int getTransactionTerminalId(FolioTransaction a_FolioTransaction)
            {
                oFolioTransFacade = new FolioTransactionFacade();
                return oFolioTransFacade.getTransactionTerminalId(a_FolioTransaction);
            }

			private string mMode;
			private void btnCheckOut_Click(System.Object sender, System.EventArgs e)
			{
				mMode = "Check Out";
				Folio oFolioTmp;
				FolioFacade oFolioTmpFacade = new FolioFacade();
				oFolioTmp = oFolioTmpFacade.GetFolio(this.txtFolioId.Text);

                if (oFolioTmp.FolioType == "SHARE")
				{
					CheckOutUI CheckOutUI = new CheckOutUI(this.txtFolioId.Text, oFolioTmp.MasterFolio, "SHARE");
					CheckOutUI.MdiParent = this.MdiParent;
					CheckOutUI.Show();
				}
                else if (oFolioTmp.FolioType == "GROUP")
                {
                    CheckOutUI checkOutUI = new CheckOutUI(this.txtFolioId.Text, this.txtGuestName.Text);
                    checkOutUI.MdiParent = this.MdiParent;
                    checkOutUI.Show();
                }
                else
                {
                    CheckOutUI CheckOutUI = new CheckOutUI(this.txtFolioId.Text);
                    CheckOutUI.MdiParent = this.MdiParent;
                    CheckOutUI.Show();
                }
				this.Close();
			}
			
			private void btnRecall_Click(System.Object sender, System.EventArgs e)
			{
                // this is to trace all folio transactions
                // Kevin L. Oliveros 
                //if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
                //{
                //    MessageBox.Show("Can't proceed transaction.\r\nNo Shift/Cash drawer open.\r\n\r\nTo Open Shift/Cash Drawer goto Transactions menu, Cashiering->Open Shift/Cash drawer.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //} 
                
                VoidedTransactionUI voidedTransactionUI = new VoidedTransactionUI(localConnection, this.txtFolioId.Text, this.txtGuestName.Tag.ToString(), (this.txtRoomId.Text == "-" ? this.txtGuestName.Tag.ToString() : this.txtRoomId.Text), this.txtFolioId);
				voidedTransactionUI.ShowDialog(this);
			}
			
			#region "POP UP MENU"
			private void mnuInsert_Click(System.Object sender, System.EventArgs e)
			{
				btnAdd_Click(sender, e);
			}
			
			private void mnuCheckout_Click(System.Object sender, System.EventArgs e)
			{
				btnCheckOut_Click(sender, e);
			}
			
			private void mnuVoid_Click(System.Object sender, System.EventArgs e)
			{
				btnVoid_Click(sender, e);
			}
			
			private void mnuRecall_Click(System.Object sender, System.EventArgs e)
			{
				btnRecall_Click(sender, e);
			}
			
			
			#endregion
			
			private void lvwSubFolio_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				ListView lvw = (ListView)sender;

				if (e.Button == MouseButtons.Right)
				{
					System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);

					popUpMenu.Show(lvw, pos);
				}
			}

            private void lvwSubFolioB_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);

                    popUpMenu.Show(this.lvwSubFolioB, pos);
                }
            }

            private void lvwSubFolioC_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);

                    popUpMenu.Show(this.lvwSubFolioC, pos);
                }
            }

            private void lvwSubFolioD_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);

                    popUpMenu.Show(this.lvwSubFolioD, pos);
                }
            }

            private void btnBacktoList_Click(object sender, EventArgs e)
            {
                //if (mMode != "Check Out")
                //{
                FolioLedgersUI FolioLedgersListUI = new FolioLedgersUI(GlobalVariables.gPersistentConnection);
                FolioLedgersListUI.MdiParent = this.MdiParent;
                FolioLedgersListUI.Top = 0;
                FolioLedgersListUI.Left = 0;
                FolioLedgersListUI.Show();

                this.Close();
                //}
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                if (loReservation != null)
                {
                    loReservation.GetType().GetMethod("loadFolioDeposits").Invoke(loReservation, null);
                }
                this.Close();
            }

			private void lvwSubFolioA_SelectedIndexChanged(object sender, EventArgs e)
			{
				try
				{
					string temp = this.lvwSubFolioA.SelectedItems[0].SubItems[3].Text;

					this.btnVoid.Enabled = true;
				}
				catch
				{ }
			}

			private void lvwSubFolioB_SelectedIndexChanged(object sender, EventArgs e)
			{
				try
				{
					string temp = this.lvwSubFolioB.SelectedItems[0].SubItems[3].Text;

					this.btnVoid.Enabled = true;
				}
				catch
				{ }
			}

			private void lvwSubFolioC_SelectedIndexChanged(object sender, EventArgs e)
			{
				try
				{
					string temp = this.lvwSubFolioC.SelectedItems[0].SubItems[3].Text;

					this.btnVoid.Enabled = true;
				}
				catch
				{ }
			}

			private void lvwSubFolioD_SelectedIndexChanged(object sender, EventArgs e)
			{
				try
				{
					string temp = this.lvwSubFolioD.SelectedItems[0].SubItems[3].Text;

					this.btnVoid.Enabled = true;
				}
				catch
				{ }
			}

			private void tabSubFolio_SelectedIndexChanged(object sender, EventArgs e)
			{
				this.btnVoid.Enabled = false;
			}

			private void mnuRefreshLedger_Click(object sender, EventArgs e)
			{
				txtFolioId_TextChanged(sender, e);
			}

			private void FolioLedgerUI_Activated(object sender, EventArgs e)
			{
				this.WindowState = FormWindowState.Maximized;
			}

            private void btnPostToAccounting_Click(object sender, EventArgs e)
            {
                DialogResult _res = MessageBox.Show("Are you sure you want to post Event Transactions to Accounting?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res != DialogResult.Yes)
                {
                    return;
                }

                if (txtFolioId.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Invalid Folio ID!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    Jinisys.Hotel.NightAudit.BusinessLayer.PostRoomChargesFacade _oPostRoomChargeFacade = new Jinisys.Hotel.NightAudit.BusinessLayer.PostRoomChargesFacade();
                    _oPostRoomChargeFacade.postToSAP(txtFolioId.Text.Trim());
                    MessageBox.Show("Successfully posted to Accounting!", "Posting Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error posting to SAP:\n\n" + ex.Message);
                }

                try
                {
                    LoadPersonalInfo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private void FolioLedgerUI_Load(object sender, EventArgs e)
            {

            }

		}
	}
	
}
