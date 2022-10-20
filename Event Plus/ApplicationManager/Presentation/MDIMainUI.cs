using System.Windows.Forms;
using System.Drawing;
using System;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Reflection;
using System.Management;
using System.IO;
using System.Diagnostics;

using MySql.Data.MySqlClient;
using CrystalDecisions.Windows.Forms;

using Jinisys.Hotel.Security.Presentation;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.NightAudit.BusinessLayer;
using Jinisys.Hotel.AccountingInterface.Presentation;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Utilities.BusinessLayer;
using Integrations.Presentation;
using Jinisys.Hotel.Reports.Presentation;
using Integrations;

namespace Jinisys.Hotel.ApplicationManager
{
	namespace Presentation
	{
        public class MDIMainUI : System.Windows.Forms.Form
        {

            private ToolStripButton toolStripButton1;
            private ToolStripButton toolStripButton2;
            private ToolStripButton toolStripButton3;
            private ToolStripSeparator toolStripSeparator1;
            private ToolStripButton toolStripButton4;
            private ToolStripButton toolStripButton5;
            private ToolStripSeparator toolStripSeparator2;
            private ToolStripButton toolStripButton6;
            private ToolStripButton toolStripButton7;
            private ToolStripButton toolStripButton8;
            private ToolStripSeparator toolStripSeparator3;
            private ToolStripSeparator toolStripSeparator4;
            private ToolStripButton toolStripButton11;
            private ToolStripButton toolStripButton12;
            private ToolStripButton toolStripButton10;
            private ToolStripButton toolStripButton9;
            private ToolStrip toolStrip1;
            private ToolStripButton toolNew;
            private ToolStripButton toolOpen;
            private ToolStripButton toolSave;
            private ToolStripSeparator toolStripSeparator5;
            private ToolStripButton toolCut;
            private ToolStripButton toolCopy;
            private ToolStripButton toolPaste;
            private ToolStripSeparator toolStripSeparator6;
            private ToolStripButton toolUndo;
            private ToolStripButton toolRedo;
            private ToolStripButton toolSearch;
            private ToolStripButton toolRefresh;
            private ToolStripButton toolPrint;
            private ToolStripButton toolPrintPreview;
            private ToolStripSeparator toolStripSeparator8;
            private ToolStripSeparator toolStripSeparator7;
            private ToolStripButton toolClose;
            internal PictureBox pictHotelLogo;
            internal Label Label6;
            internal GroupBox grbOccupancy;
            internal Label lblCurrentOccpancyRate1;
			internal Label lblYesterdayOccupacyRate1;
			public MenuStrip menuStrip;
            private ToolStripMenuItem tsmFile;
            private ToolStripMenuItem mnuNew;
            private ToolStripMenuItem mnuOpen;
            private ToolStripMenuItem mnuClose;
            private ToolStripSeparator toolStripMenuItem2;
            private ToolStripMenuItem mnuSave;
            private ToolStripSeparator toolStripMenuItem3;
            private ToolStripMenuItem mnuPageSetup;
            private ToolStripMenuItem mnuPrintPreview;
            private ToolStripMenuItem mnuPrint;
            private ToolStripSeparator toolStripMenuItem4;
            private ToolStripMenuItem sendToToolStripMenuItem;
            private ToolStripMenuItem mnuMailRecipient;
            private ToolStripSeparator toolStripMenuItem5;
            private ToolStripMenuItem mnuLockScreen;
            private ToolStripMenuItem mnuLogOff;
            private ToolStripMenuItem mnuExit;
            private ToolStripMenuItem tsmEdit;
            private ToolStripMenuItem mnuUndo;
            private ToolStripMenuItem mnuRedo;
            private ToolStripSeparator toolStripMenuItem6;
            private ToolStripMenuItem mnuCut;
            private ToolStripMenuItem mnuCopy;
            private ToolStripMenuItem mnuPaste;
            private ToolStripMenuItem mnuDelete;
            private ToolStripSeparator toolStripMenuItem7;
            private ToolStripMenuItem mnuSearch;
            private ToolStripMenuItem tsmTransactions;
			private ToolStripMenuItem mnuFontDesk;
            private ToolStripMenuItem mnuGroupBlocking;
            private ToolStripSeparator toolStripMenuItem9;
            private ToolStripMenuItem mnuCashiering;
            private ToolStripMenuItem mnuAudit;
            private ToolStripMenuItem mnuSingleReservation;
            private ToolStripMenuItem mnuGroupReservation;
            private ToolStripMenuItem mnuSharedReservation;
            private ToolStripSeparator toolStripMenuItem10;
            private ToolStripMenuItem mnuFolioLedgers;
            private ToolStripMenuItem mnuFolioRouting;
            private ToolStripSeparator toolStripMenuItem11;
            private ToolStripMenuItem mnuCheckOut;
            private ToolStripSeparator toolStripMenuItem12;
            private ToolStripMenuItem mnuOpenShift;
            private ToolStripMenuItem mnuCloseShift;
            private ToolStripMenuItem mnuConfigureDayEndClosing;
            private ToolStripSeparator toolStripMenuItem14;
            private ToolStripMenuItem mnuDayEndClosing;
            private ToolStripMenuItem tsmConfiguration;
            private ToolStripMenuItem tsmReports;
            private ToolStripMenuItem tsmWindow;
            private ToolStripMenuItem tsmTools;
            private ToolStripMenuItem calculatorToolStripMenuItem;
            private ToolStripMenuItem notepadToolStripMenuItem;
            private ToolStripSeparator toolStripMenuItem15;
            private ToolStripMenuItem mnuReportGenerator;
            private ToolStripMenuItem mnuGuestReport;
            private ToolStripMenuItem mnuArrivals;
            private ToolStripMenuItem mnuDepartures;
            private ToolStripMenuItem mnuInHouseGuest;
            private ToolStripSeparator toolStripMenuItem17;
            private ToolStripMenuItem mnuExpectedArrivals;
            private ToolStripMenuItem mnuExpectedDepartures;
            private ToolStripMenuItem mnuRoomsReport;
            private ToolStripMenuItem tileHorizontalToolStripMenuItem;
            private ToolStripMenuItem tileVerticalToolStripMenuItem;
            private ToolStripMenuItem cascadeToolStripMenuItem;
            private ToolStripSeparator toolStripMenuItem16;
            private ToolStripMenuItem closeAllWindowToolStripMenuItem;
            private ToolStripMenuItem mnuCurrencyCodes;
            private ToolStripSeparator toolStripMenuItem22;
            private ToolStripMenuItem mnuRoom;
            private ToolStripMenuItem mnuRoomRates;
            private ToolStripMenuItem mnuRoomAvailability;
            private ToolStripMenuItem mnuRoomTransfer;
            private ToolStripSeparator toolStripMenuItem18;
            private ToolStripMenuItem mnuUnderRepair;
            private ToolStripSeparator toolStripMenuItem19;
            private ToolStripMenuItem mnuRoomStatus;
            private ToolStripSeparator toolStripMenuItem20;
            private ToolStripMenuItem mnuTransactionReports;
            private ToolStripMenuItem mnuAllTransaction;
            private ToolStripMenuItem mnuSalesSummary;
			private ToolStripSeparator toolStripMenuItem21;
            private ToolStripMenuItem mnuRooms;
            private ToolStripMenuItem mnuRoomTypes;
            private ToolStripMenuItem mnuTransactions;
            private ToolStripMenuItem mnuServices;
            private ToolStripMenuItem mnuHotel;
            private ToolStripMenuItem mnuPromos;
            private ToolStripSeparator toolStripMenuItem24;
            private ToolStripMenuItem mnuFloorPlan;
            private ToolStripMenuItem mnuDepartments;
            private ToolStripMenuItem mnuHotelInfo;
            private ToolStripSeparator toolStripMenuItem26;
            private ToolStripMenuItem mnuSetTerminal;
            private ToolStripSeparator toolStripMenuItem25;
            private ToolStripMenuItem mnuSystemUsers;
            private ToolStripMenuItem mnuRateCodes;
            private ToolStripMenuItem mnuRateTypes;
            private ToolStripMenuItem mnuTransactionTypes;
            private ToolStripMenuItem mnuTransactionCodes;
            private ToolStripMenuItem mnuHousekeepers;
            private ToolStripMenuItem mnuEngineeringServices;
            private ToolStripSeparator toolStripMenuItem27;
            private ToolStripMenuItem mnuEngineeringJob;
            private ToolStripMenuItem mnuHousekeepingJob;
            private ToolStripMenuItem mnuSystemRoles;
            private ToolStripMenuItem mnuSystemMenuRoles;
            private ToolStripSeparator toolStripMenuItem1;
            private ToolStripMenuItem mnuRefresh;
            private FlowLayoutPanel flpSidePanel;
            private Panel pnlLegend;
            internal Label lblReservedRoomColor;
            internal Label lbl4;
            internal Label lbl6;
            internal Label lbl5;
            private Panel pnlRooms;
            private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic vsDayPlo;
            private ToolStripSeparator toolStripMenuItem28;
            private ToolStripMenuItem backupDatabaseToolStripMenuItem;
            private ToolStripMenuItem captureImageToolStripMenuItem;
            private ToolStripSeparator toolStripMenuItem29;
            internal Label lblCurrentOccupancyRate;
            internal Label lblYesterdayOccupacyRate;
            private ToolStripSeparator toolStripSeparator9;
            private ToolStripButton btnStressTest;
            private ToolStripMenuItem mnuGuestPrivileges;
            private ToolStripMenuItem guestsToolStripMenuItem;
            private ToolStripMenuItem mnuIndividualGuest;
            private ToolStripMenuItem mnuGroupGuest;
            private ToolStripSeparator toolStripSeparator10;
            private ToolStripMenuItem mnuAmenities;
			private ToolStripSeparator toolStripSeparator11;
            private ToolStripButton toolStripSingle;
            private ToolStripButton tooltipGroup;
            private ToolStripButton toolStripShare;
            private ToolStripSeparator toolStripSeparator13;
            private ToolStripButton toolStripGroupBlock;
            private ToolStripButton toolStripRoom;
            private ToolStripSeparator toolStripSeparator14;
            private ToolStripButton toolStripFolioLedger;
            private ToolStripButton toolStripRoute;
			private ToolStripButton toolStripCheckOut;
            private ContextMenuStrip cmuLiveRoomStatus;
            private ToolStripMenuItem cmuQuickCheckIn;
            private ToolStripSeparator toolStripMenuItem23;
            private ToolStripMenuItem cmuViewReservationInfo;
            private ToolStripSeparator toolStripMenuItem30;
            private ToolStripMenuItem cmuViewFolio;
            private ToolStripMenuItem cmuCheckOutFolio;
            private ToolStripSeparator toolStripMenuItem31;
            private ToolStripMenuItem cancelledReservationToolStripMenuItem;
            private ToolStripSeparator toolStripMenuItem32;
            private ToolStripMenuItem guestLedgerToolStripMenuItem;
            private ToolStripMenuItem roomOccupancyToolStripMenuItem;
			private ToolStripSeparator toolStripMenuItem34;
            private ToolStripMenuItem cityLedgerToolStripMenuItem;
            private ToolStripButton toolStripButtonNonStaying;
            private ToolStripMenuItem inquiryToolStripMenuItem;
            private ToolStripMenuItem cityLedgerToolStripMenuItem1;
            private ToolStripMenuItem menuInhouseGuestsForecast;
            private ToolStripSeparator toolStripMenuItem33;
            private ToolStripSeparator toolStripMenuItem35;
            private ToolStripMenuItem mnuCityTransferTransactions;
            private ToolStripMenuItem salesForecsToolStripMenuItem;
            private ToolStripMenuItem noOfPaxToolStripMenuItem;
            private ToolStripMenuItem cityTransferToolStripMenuItem;
            private ToolStripMenuItem MenutransactionRegisterToolStrip;
            private ToolStripSeparator toolStripMenuItem36;
            private ToolStripMenuItem MenuReservationNoRoom;
			private ToolStripMenuItem folioLedgerIToolStripMenuItem;
            private ToolStripSeparator toolStripMenuItem37;
            private ToolStripMenuItem cmuTransactionsPerCashier;
            private ToolStripMenuItem mnuChangePassword;
            private ToolStripSeparator toolStripMenuItem38;
            private ToolStripMenuItem mnuVoidedTransactions;
            private ToolStripMenuItem roomAvailabilityToolStripMenuItem;
            private ToolStripMenuItem mnuChangeAuditDate;
            private ToolStripSeparator toolStripMenuItem39;
            private ToolStripMenuItem guestsListToolStripMenuItem;
            private ToolStripMenuItem mnuRoomHistoryInquiry;
            private Timer tmrSysTime;
            internal Label lbl0;
            internal Label lbl2;
            private ToolStripSeparator toolStripMenuItem13;
            private ToolStripMenuItem logsToolStripMenuItem;
            private Label lblSysTime;
            private ToolStripMenuItem mnuOccupancyForecast;
            private ToolStripSeparator toolStripMenuItem40;
            private ToolStripSeparator toolStripMenuItem41;
            private ToolStripMenuItem guestByRateCodeToolStripMenuItem;
            internal Label lbl1;
            private Timer tmrUpdateRoomStat;
            private ToolStripSeparator toolStripMenuItem42;
            private ToolStripMenuItem mnuAccountingInterface;
            private ToolStripMenuItem mnuPostToAccounting;
            internal Label lbl3;
            internal Label lblVacantCleanRoom;
            internal Label lblVacantDirtyRoom;
            internal Label lblOccupiedDirtyRoom;
			internal Label lblOccupiedCleanRoom;
            private ToolStripMenuItem mnuAvailableRoomsToday;
            private StatusBarPanel statDBConnection;
            private ToolStripButton toolStripAvailableRoomsToday;
			private ToolStripSeparator toolStripMenuItem43;
			private ToolStripMenuItem mnuWaitListReservation;
			private ToolStripSeparator toolStripMenuItem44;
			private ToolStripSeparator toolStripMenuItem45;
			private ToolStripMenuItem mnuConfigDrivers;
			private ToolStripSeparator toolStripMenuItem46;
            private ToolStripMenuItem mnuPostTransactionNonGuest;
            private ToolStripMenuItem toolStripMenuItem47;
            private ToolStripMenuItem mnuEventTypes;
            private ToolStripMenuItem mnuConfigRequirement;
            private ToolStripMenuItem eventMealToolStripMenuItem;
            private ToolStripMenuItem mnuMealItem;
            private ToolStripMenuItem mealGroupToolStripMenuItem;
            private ToolStripMenuItem mealMenuToolStripMenuItem;
            private ToolStripMenuItem mnuEventPackage;
            private ToolStripMenuItem appliedRatesToolStripMenuItem;
			private TabControl tabRooms;
			private TabPage tabPage1;
			private TabPage tabPage2;
			private FlowLayoutPanel flpRooms;
			private FlowLayoutPanel flpFunctions;
			private Panel pnlFunction;
			private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic gridFunctions;
			internal GroupBox groupBox1;
			internal Label lblCurrentDayFunctionRoomOccupancy;
			internal Label lblYesterDayFunctionRoomOccupancy;
			internal Label label3;
			internal Label label4;
			private Panel panel3;
			internal Label lblOccupiedCleanFunction;
			internal Label lblOccupiedDirtyFunction;
			internal Label lblVacantCleanFunction;
			internal Label lblVacantDirtyFunction;
			internal Label label10;
			internal Label label11;
			internal Label label12;
			internal Label label13;
			internal Label label14;
			internal Label label15;
			internal Label label16;
			internal Label label17;
			private ToolStripMenuItem mnuTransactionCodeSubAccounts;
			private ToolStripMenuItem mnuTransactionSources;
			private ToolStripMenuItem mnuInquiryHotelRevenue;
			internal Label lblReservedRooms;
			internal Label lblBlockedRooms;
			internal Label lblTotalRooms;
			internal Label lblOutOfOrderRooms;
			internal Label lblTotalFunctions;
			internal Label lblOutOfOrderFunction;
			internal Label lblBlockedFunction;
			private ToolTip toolTipNytAudit;
			private ToolStripSeparator toolStripMenuItem48;
			private ToolStripMenuItem cmuSystemConfiguration;
			private ToolStripMenuItem mnuInquiryRoomRevenue;
			private ToolStripSeparator toolStripMenuItem49;
			private ToolStripMenuItem minibarToolStripMenuItem;
			private ToolStripMenuItem mnuMinibarItemCategory;
			private ToolStripSeparator toolStripMenuItem53;
			private ToolStripMenuItem housekeepingStepProcedureToolStripMenuItem;
			private ToolStripSeparator toolStripMenuItem50;
			private ToolStripMenuItem mnuMinibarItems;
			private ToolStripMenuItem housekeepingToolStripMenuItem;
			private ToolStripMenuItem mnuHouseKeepingReport;
			private ToolStripMenuItem mnuHouseKeepingNew;
			private ToolStripMenuItem mnuFloorOccupancy;
			private ToolStripSeparator toolStripMenuItem51;
			private ToolStripMenuItem mnuMinibarSalesView;
			private ToolStripSeparator toolStripMenuItem8;
			private ToolStripSeparator toolStripMenuItem52;
			private ToolStripMenuItem mnuHousekeepingActivity;
			private ToolStripMenuItem mnuHousekeepersReport;
			private ToolStripMenuItem mnuHousekeepersSummary;
			private ToolStripSeparator toolStripMenuItem54;
			private ToolStripMenuItem mnuMinibarSales;
			private ToolStripMenuItem mnuMinibarSalesByHousekeeper;
			private ToolStripMenuItem mnuMinibarSalesByRoom;
			private ToolStripMenuItem mnuMinibarSalesByItemCategory;
			private ToolStripSeparator toolStripMenuItem55;
			private ToolStripMenuItem mnuMinibarItemsList;
			private ToolStripSeparator toolStripMenuItem56;
			private ToolStripMenuItem cmuPrintRegCard;
            private ToolStripSeparator toolStripSeparator12;
			private ToolStripMenuItem mnuTelephoneDirectory;
            private ToolStripButton tsbZoomIn;
            private ToolStripButton tsbZoomOut;
            internal Label lblTotalInHouse;
            internal Label label2;
			private ToolStripSeparator toolStripMenuItem57;
			private ToolStripMenuItem mnuShiftEndorsements;
			private ToolStripMenuItem mnuHighBalanceGuests;
			private ToolStripSeparator toolStripMenuItem58;
			private ToolStripMenuItem roomCalendarNEWToolStripMenuItem;
			private ToolStripSeparator toolStripMenuItem59;
			private ToolStripMenuItem mnuDailyHotelRevenueReport;
			private ToolStripMenuItem mnuTranCodeGLSetup;
            private ToolStripSeparator toolStripSeparator15;
            private ToolStripMenuItem roomingListToolStripMenuItem;
            private ToolStripMenuItem mnuAgents;
            private ToolStripMenuItem mnuAccountingAdjustment;
            private ToolStripMenuItem nationalityReportToolStripMenuItem;
            private ToolStripSeparator toolStripSeparator16;
            private ToolStripMenuItem mnuRestaurant;
            private ToolStripMenuItem mnuMealRequirements;
            private System.ComponentModel.BackgroundWorker backgroundWorker1;
            private ToolStripMenuItem roomSuperTypesToolStripMenuItem;
            private ToolStripMenuItem mnuEventList;
            private ToolStripMenuItem mnuEventsRevenue;
            private ToolStripMenuItem statisticalDataToolStripMenuItem;
            private ToolStripSeparator toolStripSeparator17;
            private ToolStripMenuItem marketSegmentToolStripMenuItem;
            private ToolStripMenuItem mnuCalendarOfEvents;
            private ToolStripMenuItem mnuLostBusiness;
            private ToolStripMenuItem mnuBookingInquiries;
            private ToolStripMenuItem toolStripMenuItem60;
            private ToolStripMenuItem mnuDropDownConfig;
            private ToolStripMenuItem mnuAvailabilityOfRooms;
            private ToolStripMenuItem mnuWeeklyEventSchedules;
            private PictureBox pictureBox1;
            private ToolStripMenuItem synchronizeSAPToolStripMenuItem;
            private ToolStripMenuItem tsmHelp;
            private ToolStripMenuItem aboutToolStripMenuItem;
            private ToolStripMenuItem folioUserGuideToolStripMenuItem;
            private ToolStripMenuItem topClientsToolStripMenuItem;
            private ToolStripMenuItem accountingIntegrationSetupToolStripMenuItem;
            private ToolStripMenuItem historicalEventsAndRevenueToolStripMenuItem;
            private ToolStripMenuItem clientTypeReportToolStripMenuItem;
			internal Label lblReservedFunction;


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

            private System.ComponentModel.IContainer components;

            //NOTE: The following procedure is required by the Windows Form Designer
            //It can be modified using the Windows Form Designer.
            //Do not modify it using the code editor.
            public System.Windows.Forms.ImageList imgMenu;
            internal System.Windows.Forms.ToolTip toolTipVs;
            internal System.Windows.Forms.StatusBar stbHotel;
            internal System.Windows.Forms.StatusBarPanel pnlUser;
            internal System.Windows.Forms.StatusBarPanel pnlUserLogTime;
            internal System.Windows.Forms.StatusBarPanel pnlDate;
            internal System.Windows.Forms.StatusBarPanel pnlJinisys;
            internal System.Windows.Forms.StatusBarPanel pnlApplication;
            internal System.Windows.Forms.StatusBarPanel pnlTerminal;
            public System.Windows.Forms.ImageList imgIcons;
            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
this.components = new System.ComponentModel.Container();
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMainUI));
this.imgMenu = new System.Windows.Forms.ImageList(this.components);
this.stbHotel = new System.Windows.Forms.StatusBar();
this.pnlApplication = new System.Windows.Forms.StatusBarPanel();
this.statDBConnection = new System.Windows.Forms.StatusBarPanel();
this.pnlTerminal = new System.Windows.Forms.StatusBarPanel();
this.pnlUser = new System.Windows.Forms.StatusBarPanel();
this.pnlUserLogTime = new System.Windows.Forms.StatusBarPanel();
this.pnlDate = new System.Windows.Forms.StatusBarPanel();
this.pnlJinisys = new System.Windows.Forms.StatusBarPanel();
this.toolTipVs = new System.Windows.Forms.ToolTip(this.components);
this.vsDayPlo = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.cmuLiveRoomStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
this.cmuQuickCheckIn = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripSeparator();
this.cmuViewReservationInfo = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripSeparator();
this.cmuViewFolio = new System.Windows.Forms.ToolStripMenuItem();
this.cmuCheckOutFolio = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem56 = new System.Windows.Forms.ToolStripSeparator();
this.cmuPrintRegCard = new System.Windows.Forms.ToolStripMenuItem();
this.gridFunctions = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.lblSysTime = new System.Windows.Forms.Label();
this.lblReservedRoomColor = new System.Windows.Forms.Label();
this.lbl4 = new System.Windows.Forms.Label();
this.lbl6 = new System.Windows.Forms.Label();
this.lbl5 = new System.Windows.Forms.Label();
this.lbl0 = new System.Windows.Forms.Label();
this.lbl2 = new System.Windows.Forms.Label();
this.imgIcons = new System.Windows.Forms.ImageList(this.components);
this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
this.toolStrip1 = new System.Windows.Forms.ToolStrip();
this.toolNew = new System.Windows.Forms.ToolStripButton();
this.toolOpen = new System.Windows.Forms.ToolStripButton();
this.toolSave = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
this.toolCut = new System.Windows.Forms.ToolStripButton();
this.toolCopy = new System.Windows.Forms.ToolStripButton();
this.toolPaste = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
this.toolPrint = new System.Windows.Forms.ToolStripButton();
this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
this.toolUndo = new System.Windows.Forms.ToolStripButton();
this.toolRedo = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
this.toolRefresh = new System.Windows.Forms.ToolStripButton();
this.toolSearch = new System.Windows.Forms.ToolStripButton();
this.toolClose = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
this.toolStripSingle = new System.Windows.Forms.ToolStripButton();
this.btnStressTest = new System.Windows.Forms.ToolStripButton();
this.tooltipGroup = new System.Windows.Forms.ToolStripButton();
this.toolStripShare = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
this.toolStripGroupBlock = new System.Windows.Forms.ToolStripButton();
this.toolStripRoom = new System.Windows.Forms.ToolStripButton();
this.toolStripAvailableRoomsToday = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
this.toolStripFolioLedger = new System.Windows.Forms.ToolStripButton();
this.toolStripRoute = new System.Windows.Forms.ToolStripButton();
this.toolStripCheckOut = new System.Windows.Forms.ToolStripButton();
this.toolStripButtonNonStaying = new System.Windows.Forms.ToolStripButton();
this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
this.Label6 = new System.Windows.Forms.Label();
this.grbOccupancy = new System.Windows.Forms.GroupBox();
this.lblCurrentOccupancyRate = new System.Windows.Forms.Label();
this.lblYesterdayOccupacyRate = new System.Windows.Forms.Label();
this.lblCurrentOccpancyRate1 = new System.Windows.Forms.Label();
this.lblYesterdayOccupacyRate1 = new System.Windows.Forms.Label();
this.menuStrip = new System.Windows.Forms.MenuStrip();
this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
this.mnuPageSetup = new System.Windows.Forms.ToolStripMenuItem();
this.mnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
this.sendToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMailRecipient = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
this.mnuLockScreen = new System.Windows.Forms.ToolStripMenuItem();
this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
this.mnuLogOff = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripSeparator();
this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
this.tsmConfiguration = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHotel = new System.Windows.Forms.ToolStripMenuItem();
this.mnuPromos = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripSeparator();
this.mnuFloorPlan = new System.Windows.Forms.ToolStripMenuItem();
this.mnuDepartments = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHotelInfo = new System.Windows.Forms.ToolStripMenuItem();
this.mnuTelephoneDirectory = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripSeparator();
this.mnuSystemUsers = new System.Windows.Forms.ToolStripMenuItem();
this.mnuSystemRoles = new System.Windows.Forms.ToolStripMenuItem();
this.mnuSystemMenuRoles = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripSeparator();
this.mnuSetTerminal = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem48 = new System.Windows.Forms.ToolStripSeparator();
this.cmuSystemConfiguration = new System.Windows.Forms.ToolStripMenuItem();
this.mnuDropDownConfig = new System.Windows.Forms.ToolStripMenuItem();
this.mnuCurrencyCodes = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripSeparator();
this.mnuRoom = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRooms = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRoomTypes = new System.Windows.Forms.ToolStripMenuItem();
this.mnuAmenities = new System.Windows.Forms.ToolStripMenuItem();
this.roomSuperTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRoomRates = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRateCodes = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRateTypes = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
this.guestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuIndividualGuest = new System.Windows.Forms.ToolStripMenuItem();
this.mnuGroupGuest = new System.Windows.Forms.ToolStripMenuItem();
this.mnuGuestPrivileges = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
this.mnuTransactions = new System.Windows.Forms.ToolStripMenuItem();
this.mnuTransactionTypes = new System.Windows.Forms.ToolStripMenuItem();
this.mnuTransactionCodes = new System.Windows.Forms.ToolStripMenuItem();
this.mnuTransactionCodeSubAccounts = new System.Windows.Forms.ToolStripMenuItem();
this.mnuTransactionSources = new System.Windows.Forms.ToolStripMenuItem();
this.mnuServices = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHousekeepers = new System.Windows.Forms.ToolStripMenuItem();
this.mnuEngineeringServices = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripSeparator();
this.mnuEngineeringJob = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHousekeepingJob = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem53 = new System.Windows.Forms.ToolStripSeparator();
this.housekeepingStepProcedureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripSeparator();
this.minibarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMinibarItemCategory = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMinibarItems = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem45 = new System.Windows.Forms.ToolStripSeparator();
this.mnuAgents = new System.Windows.Forms.ToolStripMenuItem();
this.mnuConfigDrivers = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem47 = new System.Windows.Forms.ToolStripMenuItem();
this.mnuEventTypes = new System.Windows.Forms.ToolStripMenuItem();
this.mnuConfigRequirement = new System.Windows.Forms.ToolStripMenuItem();
this.eventMealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMealItem = new System.Windows.Forms.ToolStripMenuItem();
this.mealGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mealMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuEventPackage = new System.Windows.Forms.ToolStripMenuItem();
this.appliedRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.tsmTransactions = new System.Windows.Forms.ToolStripMenuItem();
this.mnuFontDesk = new System.Windows.Forms.ToolStripMenuItem();
this.guestsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripSeparator();
this.mnuSingleReservation = new System.Windows.Forms.ToolStripMenuItem();
this.mnuGroupReservation = new System.Windows.Forms.ToolStripMenuItem();
this.mnuSharedReservation = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
this.mnuWaitListReservation = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripSeparator();
this.mnuGroupBlocking = new System.Windows.Forms.ToolStripMenuItem();
this.roomCalendarNEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.roomAvailabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuAvailableRoomsToday = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
this.MenuReservationNoRoom = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem58 = new System.Windows.Forms.ToolStripSeparator();
this.mnuCashiering = new System.Windows.Forms.ToolStripMenuItem();
this.mnuFolioLedgers = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
this.mnuFolioRouting = new System.Windows.Forms.ToolStripMenuItem();
this.mnuCheckOut = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
this.mnuPostTransactionNonGuest = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem46 = new System.Windows.Forms.ToolStripSeparator();
this.mnuOpenShift = new System.Windows.Forms.ToolStripMenuItem();
this.mnuCloseShift = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripSeparator();
this.mnuAudit = new System.Windows.Forms.ToolStripMenuItem();
this.mnuDayEndClosing = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
this.mnuConfigureDayEndClosing = new System.Windows.Forms.ToolStripMenuItem();
this.mnuChangeAuditDate = new System.Windows.Forms.ToolStripMenuItem();
this.inquiryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.menuInhouseGuestsForecast = new System.Windows.Forms.ToolStripMenuItem();
this.noOfPaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripSeparator();
this.MenutransactionRegisterToolStrip = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem36 = new System.Windows.Forms.ToolStripSeparator();
this.folioLedgerIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRoomHistoryInquiry = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripSeparator();
this.cityLedgerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
this.cityTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripSeparator();
this.guestByRateCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem49 = new System.Windows.Forms.ToolStripSeparator();
this.mnuInquiryHotelRevenue = new System.Windows.Forms.ToolStripMenuItem();
this.mnuInquiryRoomRevenue = new System.Windows.Forms.ToolStripMenuItem();
this.salesForecsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem57 = new System.Windows.Forms.ToolStripSeparator();
this.mnuShiftEndorsements = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
this.mnuEventList = new System.Windows.Forms.ToolStripMenuItem();
this.mnuEventsRevenue = new System.Windows.Forms.ToolStripMenuItem();
this.statisticalDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem60 = new System.Windows.Forms.ToolStripMenuItem();
this.marketSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuCalendarOfEvents = new System.Windows.Forms.ToolStripMenuItem();
this.mnuLostBusiness = new System.Windows.Forms.ToolStripMenuItem();
this.mnuBookingInquiries = new System.Windows.Forms.ToolStripMenuItem();
this.mnuAvailabilityOfRooms = new System.Windows.Forms.ToolStripMenuItem();
this.mnuWeeklyEventSchedules = new System.Windows.Forms.ToolStripMenuItem();
this.topClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.historicalEventsAndRevenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.clientTypeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.tsmReports = new System.Windows.Forms.ToolStripMenuItem();
this.mnuGuestReport = new System.Windows.Forms.ToolStripMenuItem();
this.mnuArrivals = new System.Windows.Forms.ToolStripMenuItem();
this.mnuDepartures = new System.Windows.Forms.ToolStripMenuItem();
this.mnuInHouseGuest = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
this.mnuExpectedArrivals = new System.Windows.Forms.ToolStripMenuItem();
this.mnuExpectedDepartures = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripSeparator();
this.cancelledReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripSeparator();
this.guestLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHighBalanceGuests = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
this.roomingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.nationalityReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRoomsReport = new System.Windows.Forms.ToolStripMenuItem();
this.roomOccupancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRoomStatus = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
this.mnuRoomAvailability = new System.Windows.Forms.ToolStripMenuItem();
this.mnuUnderRepair = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
this.mnuRoomTransfer = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripSeparator();
this.mnuTransactionReports = new System.Windows.Forms.ToolStripMenuItem();
this.mnuAllTransaction = new System.Windows.Forms.ToolStripMenuItem();
this.mnuSalesSummary = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripSeparator();
this.cmuTransactionsPerCashier = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem35 = new System.Windows.Forms.ToolStripSeparator();
this.mnuCityTransferTransactions = new System.Windows.Forms.ToolStripMenuItem();
this.mnuVoidedTransactions = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem59 = new System.Windows.Forms.ToolStripSeparator();
this.mnuDailyHotelRevenueReport = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripSeparator();
this.housekeepingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHouseKeepingReport = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHouseKeepingNew = new System.Windows.Forms.ToolStripMenuItem();
this.mnuFloorOccupancy = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem51 = new System.Windows.Forms.ToolStripSeparator();
this.mnuMinibarSalesView = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem52 = new System.Windows.Forms.ToolStripSeparator();
this.mnuHousekeepingActivity = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHousekeepersReport = new System.Windows.Forms.ToolStripMenuItem();
this.mnuHousekeepersSummary = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem54 = new System.Windows.Forms.ToolStripSeparator();
this.mnuMinibarSales = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMinibarSalesByRoom = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMinibarSalesByHousekeeper = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMinibarSalesByItemCategory = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem55 = new System.Windows.Forms.ToolStripSeparator();
this.mnuMinibarItemsList = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
this.mnuRestaurant = new System.Windows.Forms.ToolStripMenuItem();
this.mnuMealRequirements = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
this.mnuOccupancyForecast = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripSeparator();
this.cityLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
this.mnuReportGenerator = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripSeparator();
this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.captureImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripSeparator();
this.mnuAccountingInterface = new System.Windows.Forms.ToolStripMenuItem();
this.mnuPostToAccounting = new System.Windows.Forms.ToolStripMenuItem();
this.mnuAccountingAdjustment = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripSeparator();
this.mnuTranCodeGLSetup = new System.Windows.Forms.ToolStripMenuItem();
this.synchronizeSAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.accountingIntegrationSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.tsmWindow = new System.Windows.Forms.ToolStripMenuItem();
this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
this.closeAllWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.folioUserGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
this.flpSidePanel = new System.Windows.Forms.FlowLayoutPanel();
this.pictHotelLogo = new System.Windows.Forms.PictureBox();
this.tabRooms = new System.Windows.Forms.TabControl();
this.tabPage1 = new System.Windows.Forms.TabPage();
this.flpRooms = new System.Windows.Forms.FlowLayoutPanel();
this.pnlRooms = new System.Windows.Forms.Panel();
this.pnlLegend = new System.Windows.Forms.Panel();
this.lblTotalInHouse = new System.Windows.Forms.Label();
this.label2 = new System.Windows.Forms.Label();
this.lblTotalRooms = new System.Windows.Forms.Label();
this.lblOutOfOrderRooms = new System.Windows.Forms.Label();
this.lblBlockedRooms = new System.Windows.Forms.Label();
this.lblReservedRooms = new System.Windows.Forms.Label();
this.lblOccupiedCleanRoom = new System.Windows.Forms.Label();
this.lblVacantDirtyRoom = new System.Windows.Forms.Label();
this.lblOccupiedDirtyRoom = new System.Windows.Forms.Label();
this.lblVacantCleanRoom = new System.Windows.Forms.Label();
this.lbl1 = new System.Windows.Forms.Label();
this.lbl3 = new System.Windows.Forms.Label();
this.tabPage2 = new System.Windows.Forms.TabPage();
this.flpFunctions = new System.Windows.Forms.FlowLayoutPanel();
this.pnlFunction = new System.Windows.Forms.Panel();
this.panel3 = new System.Windows.Forms.Panel();
this.lblTotalFunctions = new System.Windows.Forms.Label();
this.lblOutOfOrderFunction = new System.Windows.Forms.Label();
this.lblBlockedFunction = new System.Windows.Forms.Label();
this.lblReservedFunction = new System.Windows.Forms.Label();
this.lblOccupiedCleanFunction = new System.Windows.Forms.Label();
this.lblVacantCleanFunction = new System.Windows.Forms.Label();
this.lblVacantDirtyFunction = new System.Windows.Forms.Label();
this.label10 = new System.Windows.Forms.Label();
this.label12 = new System.Windows.Forms.Label();
this.label13 = new System.Windows.Forms.Label();
this.label14 = new System.Windows.Forms.Label();
this.label15 = new System.Windows.Forms.Label();
this.label16 = new System.Windows.Forms.Label();
this.label17 = new System.Windows.Forms.Label();
this.label11 = new System.Windows.Forms.Label();
this.lblOccupiedDirtyFunction = new System.Windows.Forms.Label();
this.groupBox1 = new System.Windows.Forms.GroupBox();
this.lblCurrentDayFunctionRoomOccupancy = new System.Windows.Forms.Label();
this.lblYesterDayFunctionRoomOccupancy = new System.Windows.Forms.Label();
this.label3 = new System.Windows.Forms.Label();
this.label4 = new System.Windows.Forms.Label();
this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
this.tmrSysTime = new System.Windows.Forms.Timer(this.components);
this.tmrUpdateRoomStat = new System.Windows.Forms.Timer(this.components);
this.toolTipNytAudit = new System.Windows.Forms.ToolTip(this.components);
this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
this.pictureBox1 = new System.Windows.Forms.PictureBox();
((System.ComponentModel.ISupportInitialize)(this.pnlApplication)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.statDBConnection)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.pnlTerminal)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.pnlUser)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.pnlUserLogTime)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.pnlDate)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.pnlJinisys)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.vsDayPlo)).BeginInit();
this.cmuLiveRoomStatus.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridFunctions)).BeginInit();
this.toolStrip1.SuspendLayout();
this.grbOccupancy.SuspendLayout();
this.menuStrip.SuspendLayout();
this.flpSidePanel.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.pictHotelLogo)).BeginInit();
this.tabRooms.SuspendLayout();
this.tabPage1.SuspendLayout();
this.flpRooms.SuspendLayout();
this.pnlRooms.SuspendLayout();
this.pnlLegend.SuspendLayout();
this.tabPage2.SuspendLayout();
this.flpFunctions.SuspendLayout();
this.pnlFunction.SuspendLayout();
this.panel3.SuspendLayout();
this.groupBox1.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
this.SuspendLayout();
// 
// imgMenu
// 
this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
this.imgMenu.Images.SetKeyName(0, "");
this.imgMenu.Images.SetKeyName(1, "");
this.imgMenu.Images.SetKeyName(2, "");
this.imgMenu.Images.SetKeyName(3, "");
this.imgMenu.Images.SetKeyName(4, "");
// 
// stbHotel
// 
this.stbHotel.Location = new System.Drawing.Point(0, 724);
this.stbHotel.Name = "stbHotel";
this.stbHotel.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.pnlApplication,
            this.statDBConnection,
            this.pnlTerminal,
            this.pnlUser,
            this.pnlUserLogTime,
            this.pnlDate,
            this.pnlJinisys});
this.stbHotel.ShowPanels = true;
this.stbHotel.Size = new System.Drawing.Size(1028, 22);
this.stbHotel.TabIndex = 11;
this.stbHotel.Text = "Event Plus";
// 
// pnlApplication
// 
this.pnlApplication.Name = "pnlApplication";
this.pnlApplication.Text = "Event Plus Professional Edition - Version 1.0.0";
this.pnlApplication.Width = 230;
// 
// statDBConnection
// 
this.statDBConnection.Name = "statDBConnection";
this.statDBConnection.Text = " Server :";
this.statDBConnection.Width = 200;
// 
// pnlTerminal
// 
this.pnlTerminal.Name = "pnlTerminal";
this.pnlTerminal.Text = " Terminal :";
this.pnlTerminal.Width = 80;
// 
// pnlUser
// 
this.pnlUser.Name = "pnlUser";
this.pnlUser.Text = " User:";
this.pnlUser.Width = 120;
// 
// pnlUserLogTime
// 
this.pnlUserLogTime.Name = "pnlUserLogTime";
this.pnlUserLogTime.Text = " Time Logged : 00:00:00 AM";
this.pnlUserLogTime.Width = 140;
// 
// pnlDate
// 
this.pnlDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
this.pnlDate.Name = "pnlDate";
this.pnlDate.Text = "%D";
this.pnlDate.Width = 80;
// 
// pnlJinisys
// 
this.pnlJinisys.Name = "pnlJinisys";
this.pnlJinisys.Text = " Powered by: Jinisys Software";
this.pnlJinisys.Width = 250;
// 
// toolTipVs
// 
this.toolTipVs.AutomaticDelay = 10000;
this.toolTipVs.IsBalloon = true;
this.toolTipVs.ShowAlways = true;
// 
// vsDayPlo
// 
this.vsDayPlo.AllowBigSelection = false;
this.vsDayPlo.AllowSelection = false;
this.vsDayPlo.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.vsDayPlo.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop;
this.vsDayPlo.BackColor = System.Drawing.Color.White;
this.vsDayPlo.BackColorAlternate = System.Drawing.Color.White;
this.vsDayPlo.BackColorSel = System.Drawing.Color.Transparent;
this.vsDayPlo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
this.vsDayPlo.Cols = 4;
this.vsDayPlo.ColumnInfo = "4,0,0,0,0,85,Columns:0{Width:36;}\t1{Width:36;}\t2{Width:36;}\t3{Width:36;}\t";
this.vsDayPlo.ContextMenuStrip = this.cmuLiveRoomStatus;
this.vsDayPlo.Dock = System.Windows.Forms.DockStyle.Fill;

this.vsDayPlo.ExtendLastCol = true;
this.vsDayPlo.FixedCols = 0;
this.vsDayPlo.FixedRows = 0;
this.vsDayPlo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.vsDayPlo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.vsDayPlo.ForeColorSel = System.Drawing.Color.Black;
this.vsDayPlo.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.vsDayPlo.Location = new System.Drawing.Point(0, 0);
this.vsDayPlo.Name = "vsDayPlo";
this.vsDayPlo.NodeClosedPicture = null;
this.vsDayPlo.NodeOpenPicture = null;
this.vsDayPlo.OutlineCol = -1;
this.vsDayPlo.RowHeightMax = 19;
this.vsDayPlo.RowHeightMin = 19;
this.vsDayPlo.Rows = 0;
this.vsDayPlo.ScrollBars = System.Windows.Forms.ScrollBars.None;
this.vsDayPlo.Size = new System.Drawing.Size(151, 305);
this.vsDayPlo.StyleInfo = resources.GetString("vsDayPlo.StyleInfo");
this.vsDayPlo.TabIndex = 12;
this.toolTipVs.SetToolTip(this.vsDayPlo, "Current Room Status\\r\\n[Double-Click] for Quick Check-In");
this.vsDayPlo.TreeColor = System.Drawing.Color.DarkGray;
this.vsDayPlo.Visible = false;
this.vsDayPlo.MouseHoverCell += new System.EventHandler(this.vsDayPlo_MouseHoverCell);
this.vsDayPlo.DoubleClick += new System.EventHandler(this.vsDayPlo_DoubleClick);
this.vsDayPlo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vsDayPlo_KeyPress);
this.vsDayPlo.RowColChange += new System.EventHandler(this.vsDayPlo_RowColChange);
// 
// cmuLiveRoomStatus
// 
this.cmuLiveRoomStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmuQuickCheckIn,
            this.toolStripMenuItem23,
            this.cmuViewReservationInfo,
            this.toolStripMenuItem30,
            this.cmuViewFolio,
            this.cmuCheckOutFolio,
            this.toolStripMenuItem56,
            this.cmuPrintRegCard});
this.cmuLiveRoomStatus.Name = "cmuLiveRoomStatus";
this.cmuLiveRoomStatus.Size = new System.Drawing.Size(199, 132);
this.cmuLiveRoomStatus.Opened += new System.EventHandler(this.cmuLiveRoomStatus_Opened);
// 
// cmuQuickCheckIn
// 
this.cmuQuickCheckIn.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.USER_32;
this.cmuQuickCheckIn.Name = "cmuQuickCheckIn";
this.cmuQuickCheckIn.Size = new System.Drawing.Size(198, 22);
this.cmuQuickCheckIn.Text = "&Quick Check-In";
this.cmuQuickCheckIn.Click += new System.EventHandler(this.cmuQuickCheckIn_Click);
// 
// toolStripMenuItem23
// 
this.toolStripMenuItem23.Name = "toolStripMenuItem23";
this.toolStripMenuItem23.Size = new System.Drawing.Size(195, 6);
// 
// cmuViewReservationInfo
// 
this.cmuViewReservationInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
this.cmuViewReservationInfo.Name = "cmuViewReservationInfo";
this.cmuViewReservationInfo.Size = new System.Drawing.Size(198, 22);
this.cmuViewReservationInfo.Text = "View &Reservation Info";
this.cmuViewReservationInfo.Click += new System.EventHandler(this.cmuViewReservationInfo_Click);
// 
// toolStripMenuItem30
// 
this.toolStripMenuItem30.Name = "toolStripMenuItem30";
this.toolStripMenuItem30.Size = new System.Drawing.Size(195, 6);
// 
// cmuViewFolio
// 
this.cmuViewFolio.Name = "cmuViewFolio";
this.cmuViewFolio.Size = new System.Drawing.Size(198, 22);
this.cmuViewFolio.Text = "View &Folio";
this.cmuViewFolio.Click += new System.EventHandler(this.cmuViewFolio_Click);
// 
// cmuCheckOutFolio
// 
this.cmuCheckOutFolio.Name = "cmuCheckOutFolio";
this.cmuCheckOutFolio.Size = new System.Drawing.Size(198, 22);
this.cmuCheckOutFolio.Text = "Check &Out";
this.cmuCheckOutFolio.Click += new System.EventHandler(this.cmuCheckOutFolio_Click);
// 
// toolStripMenuItem56
// 
this.toolStripMenuItem56.Name = "toolStripMenuItem56";
this.toolStripMenuItem56.Size = new System.Drawing.Size(195, 6);
// 
// cmuPrintRegCard
// 
this.cmuPrintRegCard.Name = "cmuPrintRegCard";
this.cmuPrintRegCard.Size = new System.Drawing.Size(198, 22);
this.cmuPrintRegCard.Text = "Print Registration &Card";
this.cmuPrintRegCard.Click += new System.EventHandler(this.cmuPrintRegCard_Click);
// 
// gridFunctions
// 
this.gridFunctions.AllowBigSelection = false;
this.gridFunctions.AllowSelection = false;
this.gridFunctions.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.gridFunctions.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop;
this.gridFunctions.BackColor = System.Drawing.Color.White;
this.gridFunctions.BackColorAlternate = System.Drawing.Color.White;
this.gridFunctions.BackColorSel = System.Drawing.Color.Transparent;
this.gridFunctions.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
this.gridFunctions.Cols = 3;
this.gridFunctions.ColumnInfo = resources.GetString("gridFunctions.ColumnInfo");
this.gridFunctions.ColWidthMax = 48;
this.gridFunctions.ColWidthMin = 48;
this.gridFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
this.gridFunctions.ExplorerBar = C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExMoveRows;
this.gridFunctions.FixedCols = 0;
this.gridFunctions.FixedRows = 0;
this.gridFunctions.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.gridFunctions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.gridFunctions.ForeColorSel = System.Drawing.Color.Black;
this.gridFunctions.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.gridFunctions.Location = new System.Drawing.Point(0, 0);
this.gridFunctions.Name = "gridFunctions";
this.gridFunctions.NodeClosedPicture = null;
this.gridFunctions.NodeOpenPicture = null;
this.gridFunctions.OutlineCol = -1;
this.gridFunctions.Rows = 0;
this.gridFunctions.ScrollBars = System.Windows.Forms.ScrollBars.None;
this.gridFunctions.Size = new System.Drawing.Size(148, 301);
this.gridFunctions.StyleInfo = resources.GetString("gridFunctions.StyleInfo");
this.gridFunctions.TabIndex = 12;
this.gridFunctions.TreeColor = System.Drawing.Color.DarkGray;
this.gridFunctions.Visible = false;
this.gridFunctions.MouseHoverCell += new System.EventHandler(this.vsDayPlo_MouseHoverCell);
this.gridFunctions.DoubleClick += new System.EventHandler(this.gridFunctions_DoubleClick);
this.gridFunctions.RowColChange += new System.EventHandler(this.gridFunctions_RowColChange);
// 
// lblSysTime
// 
this.lblSysTime.BackColor = System.Drawing.Color.WhiteSmoke;
this.lblSysTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
this.lblSysTime.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblSysTime.ForeColor = System.Drawing.Color.Black;
this.lblSysTime.Location = new System.Drawing.Point(697, 25);
this.lblSysTime.Name = "lblSysTime";
this.lblSysTime.Size = new System.Drawing.Size(325, 24);
this.lblSysTime.TabIndex = 27;
this.lblSysTime.Text = "sysTime";
this.lblSysTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
this.lblSysTime.TextChanged += new System.EventHandler(this.lblSysTime_TextChanged);
// 
// lblReservedRoomColor
// 
this.lblReservedRoomColor.AutoEllipsis = true;
this.lblReservedRoomColor.BackColor = System.Drawing.Color.DodgerBlue;
this.lblReservedRoomColor.Location = new System.Drawing.Point(0, 15);
this.lblReservedRoomColor.Name = "lblReservedRoomColor";
this.lblReservedRoomColor.Size = new System.Drawing.Size(140, 14);
this.lblReservedRoomColor.TabIndex = 15;
this.lblReservedRoomColor.Text = " Reserved";
this.lblReservedRoomColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// lbl4
// 
this.lbl4.AutoEllipsis = true;
this.lbl4.BackColor = System.Drawing.Color.Aqua;
this.lbl4.Location = new System.Drawing.Point(-2, 29);
this.lbl4.Name = "lbl4";
this.lbl4.Size = new System.Drawing.Size(161, 15);
this.lbl4.TabIndex = 14;
this.lbl4.Text = " Occupied - Clean";
this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// lbl6
// 
this.lbl6.AutoEllipsis = true;
this.lbl6.BackColor = System.Drawing.Color.GreenYellow;
this.lbl6.Location = new System.Drawing.Point(-2, 44);
this.lbl6.Name = "lbl6";
this.lbl6.Size = new System.Drawing.Size(161, 15);
this.lbl6.TabIndex = 13;
this.lbl6.Text = " OOO";
this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// lbl5
// 
this.lbl5.AutoEllipsis = true;
this.lbl5.BackColor = System.Drawing.Color.Brown;
this.lbl5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
this.lbl5.Location = new System.Drawing.Point(0, 72);
this.lbl5.Name = "lbl5";
this.lbl5.Size = new System.Drawing.Size(76, 14);
this.lbl5.TabIndex = 12;
this.lbl5.Text = " Blocked";
this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.lbl5.Visible = false;
// 
// lbl0
// 
this.lbl0.AutoEllipsis = true;
this.lbl0.BackColor = System.Drawing.Color.Red;
this.lbl0.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lbl0.ForeColor = System.Drawing.Color.White;
this.lbl0.Location = new System.Drawing.Point(0, 59);
this.lbl0.Name = "lbl0";
this.lbl0.Size = new System.Drawing.Size(159, 14);
this.lbl0.TabIndex = 16;
this.lbl0.Text = " Vacant - Dirty";
this.lbl0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.lbl0.Visible = false;
// 
// lbl2
// 
this.lbl2.AutoEllipsis = true;
this.lbl2.BackColor = System.Drawing.Color.White;
this.lbl2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lbl2.ForeColor = System.Drawing.Color.Black;
this.lbl2.Location = new System.Drawing.Point(0, 2);
this.lbl2.Name = "lbl2";
this.lbl2.Size = new System.Drawing.Size(159, 14);
this.lbl2.TabIndex = 17;
this.lbl2.Text = " Vacant - Clean";
this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// imgIcons
// 
this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
this.imgIcons.Images.SetKeyName(0, "");
this.imgIcons.Images.SetKeyName(1, "");
this.imgIcons.Images.SetKeyName(2, "");
this.imgIcons.Images.SetKeyName(3, "");
this.imgIcons.Images.SetKeyName(4, "");
this.imgIcons.Images.SetKeyName(5, "");
this.imgIcons.Images.SetKeyName(6, "");
this.imgIcons.Images.SetKeyName(7, "");
this.imgIcons.Images.SetKeyName(8, "");
// 
// toolStripSeparator1
// 
this.toolStripSeparator1.Name = "toolStripSeparator1";
this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
// 
// toolStripSeparator2
// 
this.toolStripSeparator2.Name = "toolStripSeparator2";
this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
// 
// toolStripSeparator3
// 
this.toolStripSeparator3.Name = "toolStripSeparator3";
this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
// 
// toolStripSeparator4
// 
this.toolStripSeparator4.Name = "toolStripSeparator4";
this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
// 
// toolStrip1
// 
this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
this.toolStrip1.ImageScalingSize = new System.Drawing.Size(17, 17);
this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolOpen,
            this.toolSave,
            this.toolStripSeparator5,
            this.toolCut,
            this.toolCopy,
            this.toolPaste,
            this.toolStripSeparator6,
            this.toolPrint,
            this.toolPrintPreview,
            this.toolStripSeparator8,
            this.toolUndo,
            this.toolRedo,
            this.toolStripSeparator7,
            this.toolRefresh,
            this.toolSearch,
            this.toolClose,
            this.toolStripSeparator9,
            this.toolStripSingle,
            this.btnStressTest,
            this.tooltipGroup,
            this.toolStripShare,
            this.toolStripSeparator13,
            this.toolStripGroupBlock,
            this.toolStripRoom,
            this.toolStripAvailableRoomsToday,
            this.toolStripSeparator14,
            this.toolStripFolioLedger,
            this.toolStripRoute,
            this.toolStripCheckOut,
            this.toolStripButtonNonStaying,
            this.toolStripSeparator12,
            this.tsbZoomIn,
            this.tsbZoomOut});
this.toolStrip1.Location = new System.Drawing.Point(0, 24);
this.toolStrip1.Name = "toolStrip1";
this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
this.toolStrip1.TabIndex = 19;
// 
// toolNew
// 
this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolNew.Enabled = false;
this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolNew.Name = "toolNew";
this.toolNew.Size = new System.Drawing.Size(23, 22);
this.toolNew.Tag = "New";
this.toolNew.Text = "New";
this.toolNew.ToolTipText = "New";
this.toolNew.Visible = false;
this.toolNew.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolOpen
// 
this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolOpen.Enabled = false;
this.toolOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolOpen.Image")));
this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolOpen.Name = "toolOpen";
this.toolOpen.Size = new System.Drawing.Size(23, 22);
this.toolOpen.Tag = "Open";
this.toolOpen.Text = "Open";
this.toolOpen.ToolTipText = "Open";
this.toolOpen.Visible = false;
this.toolOpen.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolSave
// 
this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolSave.Enabled = false;
this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolSave.Name = "toolSave";
this.toolSave.Size = new System.Drawing.Size(23, 22);
this.toolSave.Tag = "Save";
this.toolSave.Text = "Save";
this.toolSave.ToolTipText = "Save";
this.toolSave.Visible = false;
this.toolSave.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolStripSeparator5
// 
this.toolStripSeparator5.Name = "toolStripSeparator5";
this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
this.toolStripSeparator5.Visible = false;
// 
// toolCut
// 
this.toolCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolCut.Enabled = false;
this.toolCut.Image = ((System.Drawing.Image)(resources.GetObject("toolCut.Image")));
this.toolCut.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolCut.Name = "toolCut";
this.toolCut.Size = new System.Drawing.Size(23, 22);
this.toolCut.Tag = "Cut";
this.toolCut.Text = "Cut";
this.toolCut.ToolTipText = "Cut";
this.toolCut.Visible = false;
this.toolCut.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolCopy
// 
this.toolCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolCopy.Enabled = false;
this.toolCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolCopy.Image")));
this.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolCopy.Name = "toolCopy";
this.toolCopy.Size = new System.Drawing.Size(23, 22);
this.toolCopy.Tag = "Copy";
this.toolCopy.Text = "Copy";
this.toolCopy.ToolTipText = "Copy";
this.toolCopy.Visible = false;
this.toolCopy.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolPaste
// 
this.toolPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolPaste.Enabled = false;
this.toolPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolPaste.Image")));
this.toolPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolPaste.Name = "toolPaste";
this.toolPaste.Size = new System.Drawing.Size(23, 22);
this.toolPaste.Tag = "Paste";
this.toolPaste.Text = "Paste";
this.toolPaste.ToolTipText = "Paste";
this.toolPaste.Visible = false;
this.toolPaste.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolStripSeparator6
// 
this.toolStripSeparator6.Name = "toolStripSeparator6";
this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
this.toolStripSeparator6.Visible = false;
// 
// toolPrint
// 
this.toolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolPrint.Image")));
this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolPrint.Name = "toolPrint";
this.toolPrint.Size = new System.Drawing.Size(23, 22);
this.toolPrint.Tag = "Print";
this.toolPrint.Text = "Print";
this.toolPrint.ToolTipText = "Print";
this.toolPrint.Visible = false;
this.toolPrint.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolPrintPreview
// 
this.toolPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolPrintPreview.Enabled = false;
this.toolPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintPreview.Image")));
this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolPrintPreview.Name = "toolPrintPreview";
this.toolPrintPreview.Size = new System.Drawing.Size(23, 22);
this.toolPrintPreview.Tag = "Preview";
this.toolPrintPreview.Text = "Preview";
this.toolPrintPreview.ToolTipText = "Print Preview";
this.toolPrintPreview.Visible = false;
this.toolPrintPreview.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolStripSeparator8
// 
this.toolStripSeparator8.Name = "toolStripSeparator8";
this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
this.toolStripSeparator8.Visible = false;
// 
// toolUndo
// 
this.toolUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolUndo.Enabled = false;
this.toolUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolUndo.Image")));
this.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolUndo.Name = "toolUndo";
this.toolUndo.Size = new System.Drawing.Size(23, 22);
this.toolUndo.Tag = "Undo";
this.toolUndo.Text = "Undo";
this.toolUndo.ToolTipText = "Undo";
this.toolUndo.Visible = false;
this.toolUndo.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolRedo
// 
this.toolRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolRedo.Enabled = false;
this.toolRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolRedo.Image")));
this.toolRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolRedo.Name = "toolRedo";
this.toolRedo.Size = new System.Drawing.Size(23, 22);
this.toolRedo.Tag = "Redo";
this.toolRedo.Text = "Redo";
this.toolRedo.ToolTipText = "Redo";
this.toolRedo.Visible = false;
this.toolRedo.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolStripSeparator7
// 
this.toolStripSeparator7.Name = "toolStripSeparator7";
this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
this.toolStripSeparator7.Visible = false;
// 
// toolRefresh
// 
this.toolRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolRefresh.Image")));
this.toolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolRefresh.Name = "toolRefresh";
this.toolRefresh.Size = new System.Drawing.Size(23, 22);
this.toolRefresh.Tag = "Refresh";
this.toolRefresh.Text = "Refresh";
this.toolRefresh.ToolTipText = "Refresh";
this.toolRefresh.Click += new System.EventHandler(this.toolRefresh_Click);
// 
// toolSearch
// 
this.toolSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolSearch.Enabled = false;
this.toolSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolSearch.Image")));
this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolSearch.Name = "toolSearch";
this.toolSearch.Size = new System.Drawing.Size(23, 22);
this.toolSearch.Tag = "Search";
this.toolSearch.Text = "Search";
this.toolSearch.ToolTipText = "Search";
this.toolSearch.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolClose
// 
this.toolClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolClose.Image = ((System.Drawing.Image)(resources.GetObject("toolClose.Image")));
this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolClose.Name = "toolClose";
this.toolClose.Size = new System.Drawing.Size(23, 22);
this.toolClose.Tag = "Close";
this.toolClose.Text = "Close";
this.toolClose.ToolTipText = "Close";
this.toolClose.Click += new System.EventHandler(this.toolBar_Click);
// 
// toolStripSeparator9
// 
this.toolStripSeparator9.Name = "toolStripSeparator9";
this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
// 
// toolStripSingle
// 
this.toolStripSingle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripSingle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSingle.Image")));
this.toolStripSingle.Name = "toolStripSingle";
this.toolStripSingle.Size = new System.Drawing.Size(23, 22);
this.toolStripSingle.Tag = "Jinisys.Hotel.Reservation.Presentation.ReservationListUI";
this.toolStripSingle.Text = "Guests List";
this.toolStripSingle.ToolTipText = "Event List [F4]";
this.toolStripSingle.Click += new System.EventHandler(this.mnuReservationList_Click);
// 
// btnStressTest
// 
this.btnStressTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.btnStressTest.Enabled = false;
this.btnStressTest.Image = ((System.Drawing.Image)(resources.GetObject("btnStressTest.Image")));
this.btnStressTest.ImageTransparentColor = System.Drawing.Color.Magenta;
this.btnStressTest.Name = "btnStressTest";
this.btnStressTest.Size = new System.Drawing.Size(23, 22);
this.btnStressTest.Text = "toolStripButton13";
this.btnStressTest.Visible = false;
this.btnStressTest.Click += new System.EventHandler(this.btnStressTest_Click);
// 
// tooltipGroup
// 
this.tooltipGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.tooltipGroup.Image = ((System.Drawing.Image)(resources.GetObject("tooltipGroup.Image")));
this.tooltipGroup.Name = "tooltipGroup";
this.tooltipGroup.Size = new System.Drawing.Size(23, 22);
this.tooltipGroup.Tag = "Jinisys.Hotel.Reservation.Presentation.GroupReservationListUI";
this.tooltipGroup.Text = "&Event Reservation";
this.tooltipGroup.Click += new System.EventHandler(this.mnuGroupReservation_Click);
// 
// toolStripShare
// 
this.toolStripShare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripShare.Image = ((System.Drawing.Image)(resources.GetObject("toolStripShare.Image")));
this.toolStripShare.Name = "toolStripShare";
this.toolStripShare.Size = new System.Drawing.Size(23, 22);
this.toolStripShare.Tag = "Jinisys.Hotel.Reservation.Presentation.MarketingUI";
this.toolStripShare.Text = "Marketing ";
this.toolStripShare.Click += new System.EventHandler(this.MnuShare_Click);
// 
// toolStripSeparator13
// 
this.toolStripSeparator13.Name = "toolStripSeparator13";
this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
// 
// toolStripGroupBlock
// 
this.toolStripGroupBlock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripGroupBlock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripGroupBlock.Image")));
this.toolStripGroupBlock.Name = "toolStripGroupBlock";
this.toolStripGroupBlock.Size = new System.Drawing.Size(23, 22);
this.toolStripGroupBlock.Tag = "Jinisys.Hotel.Reservation.Presentation.GroupBlokingUI";
this.toolStripGroupBlock.Text = "&Quick Blocking";
this.toolStripGroupBlock.Click += new System.EventHandler(this.mnuGrpBlocking_Click);
// 
// toolStripRoom
// 
this.toolStripRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripRoom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRoom.Image")));
this.toolStripRoom.Name = "toolStripRoom";
this.toolStripRoom.Size = new System.Drawing.Size(23, 22);
this.toolStripRoom.Tag = "Jinisys.Hotel.Reservation.Presentation.RoomCalendar_New";
this.toolStripRoom.Text = "Roo&m Calendar";
this.toolStripRoom.Click += new System.EventHandler(this.mnuFrontDeskRoomBlocking_Click);
// 
// toolStripAvailableRoomsToday
// 
this.toolStripAvailableRoomsToday.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripAvailableRoomsToday.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.anotacoes;
this.toolStripAvailableRoomsToday.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripAvailableRoomsToday.Name = "toolStripAvailableRoomsToday";
this.toolStripAvailableRoomsToday.Size = new System.Drawing.Size(23, 22);
this.toolStripAvailableRoomsToday.Text = "Available Rooms Today";
this.toolStripAvailableRoomsToday.ToolTipText = "Available Rooms Today";
this.toolStripAvailableRoomsToday.Click += new System.EventHandler(this.mnuAvailableRoomsToday_Click);
// 
// toolStripSeparator14
// 
this.toolStripSeparator14.Name = "toolStripSeparator14";
this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
// 
// toolStripFolioLedger
// 
this.toolStripFolioLedger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripFolioLedger.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFolioLedger.Image")));
this.toolStripFolioLedger.Name = "toolStripFolioLedger";
this.toolStripFolioLedger.Size = new System.Drawing.Size(23, 22);
this.toolStripFolioLedger.Tag = "Jinisys.Hotel.Cashier.Presentation.FolioLedgersUI";
this.toolStripFolioLedger.Text = "Folio &Ledgers";
this.toolStripFolioLedger.Click += new System.EventHandler(this.mnuCashierFolioLedger_Click);
// 
// toolStripRoute
// 
this.toolStripRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripRoute.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRoute.Image")));
this.toolStripRoute.Name = "toolStripRoute";
this.toolStripRoute.Size = new System.Drawing.Size(23, 22);
this.toolStripRoute.Tag = "Jinisys.Hotel.Cashier.Presentation.TransactionRoutingUI";
this.toolStripRoute.Text = "Route Transaction";
this.toolStripRoute.Click += new System.EventHandler(this.mnuCashieringFolioAdjustment_Click);
// 
// toolStripCheckOut
// 
this.toolStripCheckOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCheckOut.Image")));
this.toolStripCheckOut.Name = "toolStripCheckOut";
this.toolStripCheckOut.Size = new System.Drawing.Size(23, 22);
this.toolStripCheckOut.Tag = "Jinisys.Hotel.Cashier.Presentation.CheckOutUI";
this.toolStripCheckOut.Text = "Check &Out";
this.toolStripCheckOut.Click += new System.EventHandler(this.mnuCashieringCheckOut_Click);
// 
// toolStripButtonNonStaying
// 
this.toolStripButtonNonStaying.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButtonNonStaying.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.contact_newL;
this.toolStripButtonNonStaying.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButtonNonStaying.Name = "toolStripButtonNonStaying";
this.toolStripButtonNonStaying.Size = new System.Drawing.Size(23, 22);
this.toolStripButtonNonStaying.Tag = "Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI";
this.toolStripButtonNonStaying.Text = "toolStripButtonNonStaying";
this.toolStripButtonNonStaying.Click += new System.EventHandler(this.toolStripButtonNonStaying_Click);
// 
// toolStripSeparator12
// 
this.toolStripSeparator12.Name = "toolStripSeparator12";
this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
// 
// tsbZoomIn
// 
this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.tsbZoomIn.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.zoomin;
this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
this.tsbZoomIn.Name = "tsbZoomIn";
this.tsbZoomIn.Size = new System.Drawing.Size(23, 22);
this.tsbZoomIn.ToolTipText = "Zoom In";
this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
// 
// tsbZoomOut
// 
this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.tsbZoomOut.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.zoom_out;
this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
this.tsbZoomOut.Name = "tsbZoomOut";
this.tsbZoomOut.Size = new System.Drawing.Size(23, 22);
this.tsbZoomOut.ToolTipText = "Zoom Out";
// 
// Label6
// 
this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label6.Location = new System.Drawing.Point(3, 112);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(174, 20);
this.Label6.TabIndex = 10;
this.Label6.Text = "Today\'s Room Status";
this.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
// 
// grbOccupancy
// 
this.grbOccupancy.Controls.Add(this.lblCurrentOccupancyRate);
this.grbOccupancy.Controls.Add(this.lblYesterdayOccupacyRate);
this.grbOccupancy.Controls.Add(this.lblCurrentOccpancyRate1);
this.grbOccupancy.Controls.Add(this.lblYesterdayOccupacyRate1);
this.grbOccupancy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.grbOccupancy.Location = new System.Drawing.Point(3, 427);
this.grbOccupancy.Name = "grbOccupancy";
this.grbOccupancy.Size = new System.Drawing.Size(148, 10);
this.grbOccupancy.TabIndex = 5;
this.grbOccupancy.TabStop = false;
this.grbOccupancy.Text = "Occupancy Rate";
this.grbOccupancy.Visible = false;
// 
// lblCurrentOccupancyRate
// 
this.lblCurrentOccupancyRate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.lblCurrentOccupancyRate.Location = new System.Drawing.Point(87, 23);
this.lblCurrentOccupancyRate.Name = "lblCurrentOccupancyRate";
this.lblCurrentOccupancyRate.Size = new System.Drawing.Size(57, 17);
this.lblCurrentOccupancyRate.TabIndex = 14;
this.lblCurrentOccupancyRate.Text = "00.00 %";
this.lblCurrentOccupancyRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblYesterdayOccupacyRate
// 
this.lblYesterdayOccupacyRate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.lblYesterdayOccupacyRate.Location = new System.Drawing.Point(87, 47);
this.lblYesterdayOccupacyRate.Name = "lblYesterdayOccupacyRate";
this.lblYesterdayOccupacyRate.Size = new System.Drawing.Size(57, 17);
this.lblYesterdayOccupacyRate.TabIndex = 15;
this.lblYesterdayOccupacyRate.Text = "00.00 %";
this.lblYesterdayOccupacyRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblCurrentOccpancyRate1
// 
this.lblCurrentOccpancyRate1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblCurrentOccpancyRate1.Location = new System.Drawing.Point(11, 23);
this.lblCurrentOccpancyRate1.Name = "lblCurrentOccpancyRate1";
this.lblCurrentOccpancyRate1.Size = new System.Drawing.Size(48, 17);
this.lblCurrentOccpancyRate1.TabIndex = 11;
this.lblCurrentOccpancyRate1.Text = "Today:";
this.lblCurrentOccpancyRate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// lblYesterdayOccupacyRate1
// 
this.lblYesterdayOccupacyRate1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblYesterdayOccupacyRate1.Location = new System.Drawing.Point(11, 46);
this.lblYesterdayOccupacyRate1.Name = "lblYesterdayOccupacyRate1";
this.lblYesterdayOccupacyRate1.Size = new System.Drawing.Size(67, 18);
this.lblYesterdayOccupacyRate1.TabIndex = 13;
this.lblYesterdayOccupacyRate1.Text = "Yesterday:";
this.lblYesterdayOccupacyRate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// menuStrip
// 
this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmEdit,
            this.tsmConfiguration,
            this.tsmTransactions,
            this.inquiryToolStripMenuItem,
            this.tsmReports,
            this.tsmTools,
            this.tsmWindow,
            this.tsmHelp});
this.menuStrip.Location = new System.Drawing.Point(0, 0);
this.menuStrip.Name = "menuStrip";
this.menuStrip.Size = new System.Drawing.Size(1028, 24);
this.menuStrip.TabIndex = 23;
this.menuStrip.Text = "menuStrip1";
// 
// tsmFile
// 
this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuClose,
            this.toolStripMenuItem2,
            this.mnuSave,
            this.toolStripMenuItem3,
            this.mnuPageSetup,
            this.mnuPrintPreview,
            this.mnuPrint,
            this.toolStripMenuItem4,
            this.sendToToolStripMenuItem,
            this.toolStripMenuItem5,
            this.mnuLockScreen,
            this.mnuChangePassword,
            this.mnuLogOff,
            this.toolStripMenuItem38,
            this.mnuExit});
this.tsmFile.Name = "tsmFile";
this.tsmFile.Size = new System.Drawing.Size(37, 20);
this.tsmFile.Text = "&File";
// 
// mnuNew
// 
this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
this.mnuNew.Name = "mnuNew";
this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
this.mnuNew.Size = new System.Drawing.Size(206, 22);
this.mnuNew.Text = "&New";
this.mnuNew.Visible = false;
// 
// mnuOpen
// 
this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
this.mnuOpen.Name = "mnuOpen";
this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
this.mnuOpen.Size = new System.Drawing.Size(206, 22);
this.mnuOpen.Text = "&Open";
this.mnuOpen.Visible = false;
// 
// mnuClose
// 
this.mnuClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuClose.Image")));
this.mnuClose.ImageTransparentColor = System.Drawing.Color.Magenta;
this.mnuClose.Name = "mnuClose";
this.mnuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
this.mnuClose.Size = new System.Drawing.Size(206, 22);
this.mnuClose.Text = "&Close";
this.mnuClose.Visible = false;
// 
// toolStripMenuItem2
// 
this.toolStripMenuItem2.Name = "toolStripMenuItem2";
this.toolStripMenuItem2.Size = new System.Drawing.Size(203, 6);
this.toolStripMenuItem2.Visible = false;
// 
// mnuSave
// 
this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
this.mnuSave.Name = "mnuSave";
this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
this.mnuSave.Size = new System.Drawing.Size(206, 22);
this.mnuSave.Text = "&Save";
this.mnuSave.Visible = false;
// 
// toolStripMenuItem3
// 
this.toolStripMenuItem3.Name = "toolStripMenuItem3";
this.toolStripMenuItem3.Size = new System.Drawing.Size(203, 6);
this.toolStripMenuItem3.Visible = false;
// 
// mnuPageSetup
// 
this.mnuPageSetup.Image = ((System.Drawing.Image)(resources.GetObject("mnuPageSetup.Image")));
this.mnuPageSetup.Name = "mnuPageSetup";
this.mnuPageSetup.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
this.mnuPageSetup.Size = new System.Drawing.Size(206, 22);
this.mnuPageSetup.Text = "Page Set&up";
this.mnuPageSetup.Visible = false;
// 
// mnuPrintPreview
// 
this.mnuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrintPreview.Image")));
this.mnuPrintPreview.Name = "mnuPrintPreview";
this.mnuPrintPreview.Size = new System.Drawing.Size(206, 22);
this.mnuPrintPreview.Text = "Print Pre&view";
this.mnuPrintPreview.Visible = false;
// 
// mnuPrint
// 
this.mnuPrint.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrint.Image")));
this.mnuPrint.Name = "mnuPrint";
this.mnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
this.mnuPrint.Size = new System.Drawing.Size(206, 22);
this.mnuPrint.Text = "&Print";
this.mnuPrint.Visible = false;
// 
// toolStripMenuItem4
// 
this.toolStripMenuItem4.Name = "toolStripMenuItem4";
this.toolStripMenuItem4.Size = new System.Drawing.Size(203, 6);
this.toolStripMenuItem4.Visible = false;
// 
// sendToToolStripMenuItem
// 
this.sendToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMailRecipient});
this.sendToToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendToToolStripMenuItem.Image")));
this.sendToToolStripMenuItem.Name = "sendToToolStripMenuItem";
this.sendToToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
this.sendToToolStripMenuItem.Text = "Send To";
this.sendToToolStripMenuItem.Visible = false;
// 
// mnuMailRecipient
// 
this.mnuMailRecipient.Image = ((System.Drawing.Image)(resources.GetObject("mnuMailRecipient.Image")));
this.mnuMailRecipient.Name = "mnuMailRecipient";
this.mnuMailRecipient.Size = new System.Drawing.Size(149, 22);
this.mnuMailRecipient.Text = "&Mail Recipient";
// 
// toolStripMenuItem5
// 
this.toolStripMenuItem5.Name = "toolStripMenuItem5";
this.toolStripMenuItem5.Size = new System.Drawing.Size(203, 6);
this.toolStripMenuItem5.Visible = false;
// 
// mnuLockScreen
// 
this.mnuLockScreen.Image = ((System.Drawing.Image)(resources.GetObject("mnuLockScreen.Image")));
this.mnuLockScreen.Name = "mnuLockScreen";
this.mnuLockScreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
this.mnuLockScreen.Size = new System.Drawing.Size(206, 22);
this.mnuLockScreen.Text = "Loc&k Screen";
this.mnuLockScreen.Click += new System.EventHandler(this.mnuLockScreen_Click);
// 
// mnuChangePassword
// 
this.mnuChangePassword.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Encrypted;
this.mnuChangePassword.Name = "mnuChangePassword";
this.mnuChangePassword.Size = new System.Drawing.Size(206, 22);
this.mnuChangePassword.Tag = "Jinisys.Hotel.Security.Presentation.ChangePasswordUI";
this.mnuChangePassword.Text = "Change Pass&word";
this.mnuChangePassword.Click += new System.EventHandler(this.mnuChangePassword_Click);
// 
// mnuLogOff
// 
this.mnuLogOff.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogOff.Image")));
this.mnuLogOff.Name = "mnuLogOff";
this.mnuLogOff.Size = new System.Drawing.Size(206, 22);
this.mnuLogOff.Text = "Log O&ff";
this.mnuLogOff.Click += new System.EventHandler(this.mnuLogOff_Click);
// 
// toolStripMenuItem38
// 
this.toolStripMenuItem38.Name = "toolStripMenuItem38";
this.toolStripMenuItem38.Size = new System.Drawing.Size(203, 6);
// 
// mnuExit
// 
this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
this.mnuExit.Name = "mnuExit";
this.mnuExit.Size = new System.Drawing.Size(206, 22);
this.mnuExit.Text = "E&xit";
this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
// 
// tsmEdit
// 
this.tsmEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo,
            this.mnuRedo,
            this.toolStripMenuItem6,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.toolStripMenuItem1,
            this.mnuRefresh,
            this.mnuDelete,
            this.toolStripMenuItem7,
            this.mnuSearch});
this.tsmEdit.Name = "tsmEdit";
this.tsmEdit.Size = new System.Drawing.Size(39, 20);
this.tsmEdit.Text = "&Edit";
this.tsmEdit.Visible = false;
// 
// mnuUndo
// 
this.mnuUndo.Image = ((System.Drawing.Image)(resources.GetObject("mnuUndo.Image")));
this.mnuUndo.Name = "mnuUndo";
this.mnuUndo.Size = new System.Drawing.Size(132, 22);
this.mnuUndo.Text = "&Undo";
this.mnuUndo.Visible = false;
// 
// mnuRedo
// 
this.mnuRedo.Image = ((System.Drawing.Image)(resources.GetObject("mnuRedo.Image")));
this.mnuRedo.Name = "mnuRedo";
this.mnuRedo.Size = new System.Drawing.Size(132, 22);
this.mnuRedo.Text = "&Redo";
this.mnuRedo.Visible = false;
// 
// toolStripMenuItem6
// 
this.toolStripMenuItem6.Name = "toolStripMenuItem6";
this.toolStripMenuItem6.Size = new System.Drawing.Size(129, 6);
this.toolStripMenuItem6.Visible = false;
// 
// mnuCut
// 
this.mnuCut.Image = ((System.Drawing.Image)(resources.GetObject("mnuCut.Image")));
this.mnuCut.Name = "mnuCut";
this.mnuCut.Size = new System.Drawing.Size(132, 22);
this.mnuCut.Text = "C&ut";
this.mnuCut.Visible = false;
// 
// mnuCopy
// 
this.mnuCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopy.Image")));
this.mnuCopy.Name = "mnuCopy";
this.mnuCopy.Size = new System.Drawing.Size(132, 22);
this.mnuCopy.Text = "&Copy";
this.mnuCopy.Visible = false;
// 
// mnuPaste
// 
this.mnuPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuPaste.Image")));
this.mnuPaste.Name = "mnuPaste";
this.mnuPaste.Size = new System.Drawing.Size(132, 22);
this.mnuPaste.Text = "&Paste";
this.mnuPaste.Visible = false;
// 
// toolStripMenuItem1
// 
this.toolStripMenuItem1.Name = "toolStripMenuItem1";
this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
this.toolStripMenuItem1.Visible = false;
// 
// mnuRefresh
// 
this.mnuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuRefresh.Image")));
this.mnuRefresh.Name = "mnuRefresh";
this.mnuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
this.mnuRefresh.Size = new System.Drawing.Size(132, 22);
this.mnuRefresh.Text = "Refresh";
this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
// 
// mnuDelete
// 
this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
this.mnuDelete.Name = "mnuDelete";
this.mnuDelete.Size = new System.Drawing.Size(132, 22);
this.mnuDelete.Text = "&Delete";
this.mnuDelete.Visible = false;
// 
// toolStripMenuItem7
// 
this.toolStripMenuItem7.Name = "toolStripMenuItem7";
this.toolStripMenuItem7.Size = new System.Drawing.Size(129, 6);
// 
// mnuSearch
// 
this.mnuSearch.Image = ((System.Drawing.Image)(resources.GetObject("mnuSearch.Image")));
this.mnuSearch.Name = "mnuSearch";
this.mnuSearch.Size = new System.Drawing.Size(132, 22);
this.mnuSearch.Text = "&Search";
this.mnuSearch.Visible = false;
// 
// tsmConfiguration
// 
this.tsmConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHotel,
            this.mnuCurrencyCodes,
            this.toolStripMenuItem22,
            this.mnuRoom,
            this.mnuRoomRates,
            this.toolStripSeparator10,
            this.guestsToolStripMenuItem,
            this.mnuGuestPrivileges,
            this.toolStripSeparator11,
            this.mnuTransactions,
            this.mnuServices,
            this.toolStripMenuItem50,
            this.minibarToolStripMenuItem,
            this.toolStripMenuItem45,
            this.mnuAgents,
            this.mnuConfigDrivers,
            this.toolStripMenuItem47});
this.tsmConfiguration.Name = "tsmConfiguration";
this.tsmConfiguration.Size = new System.Drawing.Size(93, 20);
this.tsmConfiguration.Text = "&Configuration";
// 
// mnuHotel
// 
this.mnuHotel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPromos,
            this.toolStripMenuItem24,
            this.mnuFloorPlan,
            this.mnuDepartments,
            this.mnuHotelInfo,
            this.mnuTelephoneDirectory,
            this.toolStripMenuItem26,
            this.mnuSystemUsers,
            this.mnuSystemRoles,
            this.mnuSystemMenuRoles,
            this.toolStripMenuItem25,
            this.mnuSetTerminal,
            this.toolStripMenuItem48,
            this.cmuSystemConfiguration,
            this.mnuDropDownConfig});
this.mnuHotel.Name = "mnuHotel";
this.mnuHotel.Size = new System.Drawing.Size(158, 22);
this.mnuHotel.Text = "Hotel";
// 
// mnuPromos
// 
this.mnuPromos.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Favorites;
this.mnuPromos.Name = "mnuPromos";
this.mnuPromos.Size = new System.Drawing.Size(255, 22);
this.mnuPromos.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.PackageHeaderUI";
this.mnuPromos.Text = "&Promos";
this.mnuPromos.Visible = false;
this.mnuPromos.Click += new System.EventHandler(this.mnuPackages_Click);
// 
// toolStripMenuItem24
// 
this.toolStripMenuItem24.Name = "toolStripMenuItem24";
this.toolStripMenuItem24.Size = new System.Drawing.Size(252, 6);
// 
// mnuFloorPlan
// 
this.mnuFloorPlan.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Applications;
this.mnuFloorPlan.Name = "mnuFloorPlan";
this.mnuFloorPlan.Size = new System.Drawing.Size(255, 22);
this.mnuFloorPlan.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.FloorPlanUI";
this.mnuFloorPlan.Text = "&Floor Plan";
this.mnuFloorPlan.Visible = false;
this.mnuFloorPlan.Click += new System.EventHandler(this.mnuFloorPlan_Click);
// 
// mnuDepartments
// 
this.mnuDepartments.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Fonts;
this.mnuDepartments.Name = "mnuDepartments";
this.mnuDepartments.Size = new System.Drawing.Size(255, 22);
this.mnuDepartments.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.DepartmentUI";
this.mnuDepartments.Text = "&Departments";
this.mnuDepartments.Click += new System.EventHandler(this.mnuDepartment_Click);
// 
// mnuHotelInfo
// 
this.mnuHotelInfo.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Home;
this.mnuHotelInfo.Name = "mnuHotelInfo";
this.mnuHotelInfo.Size = new System.Drawing.Size(255, 22);
this.mnuHotelInfo.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.HotelUI";
this.mnuHotelInfo.Text = "System Owner &Information";
this.mnuHotelInfo.Click += new System.EventHandler(this.mnuHotelInfo_Click);
// 
// mnuTelephoneDirectory
// 
this.mnuTelephoneDirectory.Name = "mnuTelephoneDirectory";
this.mnuTelephoneDirectory.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
this.mnuTelephoneDirectory.Size = new System.Drawing.Size(255, 22);
this.mnuTelephoneDirectory.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.TelephoneDirectoryUI";
this.mnuTelephoneDirectory.Text = "Telephone Directory";
this.mnuTelephoneDirectory.Visible = false;
this.mnuTelephoneDirectory.Click += new System.EventHandler(this.mnuTelephoneDirectory_Click);
// 
// toolStripMenuItem26
// 
this.toolStripMenuItem26.Name = "toolStripMenuItem26";
this.toolStripMenuItem26.Size = new System.Drawing.Size(252, 6);
// 
// mnuSystemUsers
// 
this.mnuSystemUsers.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Encrypted1;
this.mnuSystemUsers.Name = "mnuSystemUsers";
this.mnuSystemUsers.Size = new System.Drawing.Size(255, 22);
this.mnuSystemUsers.Text = "System &Users";
this.mnuSystemUsers.Click += new System.EventHandler(this.mnuSystemUsers_Click);
// 
// mnuSystemRoles
// 
this.mnuSystemRoles.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Button___Shared;
this.mnuSystemRoles.Name = "mnuSystemRoles";
this.mnuSystemRoles.Size = new System.Drawing.Size(255, 22);
this.mnuSystemRoles.Text = "System Roles";
this.mnuSystemRoles.Click += new System.EventHandler(this.mnuSystemRoles_Click);
// 
// mnuSystemMenuRoles
// 
this.mnuSystemMenuRoles.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.System_Desktop;
this.mnuSystemMenuRoles.Name = "mnuSystemMenuRoles";
this.mnuSystemMenuRoles.Size = new System.Drawing.Size(255, 22);
this.mnuSystemMenuRoles.Text = "System Menu Roles";
this.mnuSystemMenuRoles.Click += new System.EventHandler(this.mnuSystemRole_Click);
// 
// toolStripMenuItem25
// 
this.toolStripMenuItem25.Name = "toolStripMenuItem25";
this.toolStripMenuItem25.Size = new System.Drawing.Size(252, 6);
// 
// mnuSetTerminal
// 
this.mnuSetTerminal.Name = "mnuSetTerminal";
this.mnuSetTerminal.Size = new System.Drawing.Size(255, 22);
this.mnuSetTerminal.Text = "Set &Terminal";
this.mnuSetTerminal.Visible = false;
// 
// toolStripMenuItem48
// 
this.toolStripMenuItem48.Name = "toolStripMenuItem48";
this.toolStripMenuItem48.Size = new System.Drawing.Size(252, 6);
this.toolStripMenuItem48.Visible = false;
// 
// cmuSystemConfiguration
// 
this.cmuSystemConfiguration.Name = "cmuSystemConfiguration";
this.cmuSystemConfiguration.Size = new System.Drawing.Size(255, 22);
this.cmuSystemConfiguration.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.SystemConfigurationUI";
this.cmuSystemConfiguration.Text = "System Configuration";
this.cmuSystemConfiguration.Click += new System.EventHandler(this.cmuSystemConfiguration_Click);
// 
// mnuDropDownConfig
// 
this.mnuDropDownConfig.Name = "mnuDropDownConfig";
this.mnuDropDownConfig.Size = new System.Drawing.Size(255, 22);
this.mnuDropDownConfig.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.DropDownConfigurartionUI";
this.mnuDropDownConfig.Text = "Drop Down Configurations";
this.mnuDropDownConfig.Click += new System.EventHandler(this.mnuDropDownConfig_Click);
// 
// mnuCurrencyCodes
// 
this.mnuCurrencyCodes.Image = ((System.Drawing.Image)(resources.GetObject("mnuCurrencyCodes.Image")));
this.mnuCurrencyCodes.Name = "mnuCurrencyCodes";
this.mnuCurrencyCodes.Size = new System.Drawing.Size(158, 22);
this.mnuCurrencyCodes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.CurrencyCodeUI";
this.mnuCurrencyCodes.Text = "&Currency Codes";
this.mnuCurrencyCodes.Click += new System.EventHandler(this.mnuCurrencyCodes_Click);
// 
// toolStripMenuItem22
// 
this.toolStripMenuItem22.Name = "toolStripMenuItem22";
this.toolStripMenuItem22.Size = new System.Drawing.Size(155, 6);
// 
// mnuRoom
// 
this.mnuRoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRooms,
            this.mnuRoomTypes,
            this.mnuAmenities,
            this.roomSuperTypesToolStripMenuItem});
this.mnuRoom.Name = "mnuRoom";
this.mnuRoom.Size = new System.Drawing.Size(158, 22);
this.mnuRoom.Text = "&Room";
// 
// mnuRooms
// 
this.mnuRooms.Image = ((System.Drawing.Image)(resources.GetObject("mnuRooms.Image")));
this.mnuRooms.Name = "mnuRooms";
this.mnuRooms.Size = new System.Drawing.Size(173, 22);
this.mnuRooms.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RoomUI";
this.mnuRooms.Text = "&Rooms";
this.mnuRooms.Click += new System.EventHandler(this.mnuRooms_Click);
// 
// mnuRoomTypes
// 
this.mnuRoomTypes.Image = ((System.Drawing.Image)(resources.GetObject("mnuRoomTypes.Image")));
this.mnuRoomTypes.Name = "mnuRoomTypes";
this.mnuRoomTypes.Size = new System.Drawing.Size(173, 22);
this.mnuRoomTypes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RoomTypeUI";
this.mnuRoomTypes.Text = "Room &Types";
this.mnuRoomTypes.Click += new System.EventHandler(this.mnuRoomTypes_Click);
// 
// mnuAmenities
// 
this.mnuAmenities.Image = ((System.Drawing.Image)(resources.GetObject("mnuAmenities.Image")));
this.mnuAmenities.Name = "mnuAmenities";
this.mnuAmenities.Size = new System.Drawing.Size(173, 22);
this.mnuAmenities.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RoomAmenityUI";
this.mnuAmenities.Text = "Room Amenities";
this.mnuAmenities.Click += new System.EventHandler(this.mnuRoomAmenities_Click);
// 
// roomSuperTypesToolStripMenuItem
// 
this.roomSuperTypesToolStripMenuItem.Name = "roomSuperTypesToolStripMenuItem";
this.roomSuperTypesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
this.roomSuperTypesToolStripMenuItem.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RoomSuperTypeUI";
this.roomSuperTypesToolStripMenuItem.Text = "Room Super Types";
this.roomSuperTypesToolStripMenuItem.Click += new System.EventHandler(this.roomSuperTypesToolStripMenuItem_Click);
// 
// mnuRoomRates
// 
this.mnuRoomRates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRateCodes,
            this.mnuRateTypes});
this.mnuRoomRates.Name = "mnuRoomRates";
this.mnuRoomRates.Size = new System.Drawing.Size(158, 22);
this.mnuRoomRates.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RoomTyeUI";
this.mnuRoomRates.Text = "Room R&ates";
// 
// mnuRateCodes
// 
this.mnuRateCodes.Image = ((System.Drawing.Image)(resources.GetObject("mnuRateCodes.Image")));
this.mnuRateCodes.Name = "mnuRateCodes";
this.mnuRateCodes.Size = new System.Drawing.Size(133, 22);
this.mnuRateCodes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RateCodeUI";
this.mnuRateCodes.Text = "Rate &Codes";
this.mnuRateCodes.Click += new System.EventHandler(this.mnuRateCodes_Click);
// 
// mnuRateTypes
// 
this.mnuRateTypes.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.PRICE;
this.mnuRateTypes.Name = "mnuRateTypes";
this.mnuRateTypes.Size = new System.Drawing.Size(133, 22);
this.mnuRateTypes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RateTypeUI";
this.mnuRateTypes.Text = "Rate &Types";
this.mnuRateTypes.Click += new System.EventHandler(this.mnuRateTypes_Click);
// 
// toolStripSeparator10
// 
this.toolStripSeparator10.Name = "toolStripSeparator10";
this.toolStripSeparator10.Size = new System.Drawing.Size(155, 6);
// 
// guestsToolStripMenuItem
// 
this.guestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIndividualGuest,
            this.mnuGroupGuest});
this.guestsToolStripMenuItem.Name = "guestsToolStripMenuItem";
this.guestsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
this.guestsToolStripMenuItem.Text = "&Guests";
// 
// mnuIndividualGuest
// 
this.mnuIndividualGuest.Image = ((System.Drawing.Image)(resources.GetObject("mnuIndividualGuest.Image")));
this.mnuIndividualGuest.Name = "mnuIndividualGuest";
this.mnuIndividualGuest.Size = new System.Drawing.Size(126, 22);
this.mnuIndividualGuest.Tag = "Jinisys.Hotel.Accounts.Presentation.GuestUI";
this.mnuIndividualGuest.Text = "&Individual";
this.mnuIndividualGuest.Click += new System.EventHandler(this.mnuEditIndividualAccount_Click);
// 
// mnuGroupGuest
// 
this.mnuGroupGuest.Image = ((System.Drawing.Image)(resources.GetObject("mnuGroupGuest.Image")));
this.mnuGroupGuest.Name = "mnuGroupGuest";
this.mnuGroupGuest.Size = new System.Drawing.Size(126, 22);
this.mnuGroupGuest.Tag = "Jinisys.Hotel.Accounts.Presentation.CompanyUI";
this.mnuGroupGuest.Text = "&Group";
this.mnuGroupGuest.Click += new System.EventHandler(this.mnuEditGroupAccount_Click);
// 
// mnuGuestPrivileges
// 
this.mnuGuestPrivileges.Image = ((System.Drawing.Image)(resources.GetObject("mnuGuestPrivileges.Image")));
this.mnuGuestPrivileges.Name = "mnuGuestPrivileges";
this.mnuGuestPrivileges.Size = new System.Drawing.Size(158, 22);
this.mnuGuestPrivileges.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.PrivilegeHeaderUI";
this.mnuGuestPrivileges.Text = "Privileges";
this.mnuGuestPrivileges.Click += new System.EventHandler(this.mnuPrivileges_Click);
// 
// toolStripSeparator11
// 
this.toolStripSeparator11.Name = "toolStripSeparator11";
this.toolStripSeparator11.Size = new System.Drawing.Size(155, 6);
// 
// mnuTransactions
// 
this.mnuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTransactionTypes,
            this.mnuTransactionCodes,
            this.mnuTransactionCodeSubAccounts,
            this.mnuTransactionSources});
this.mnuTransactions.Name = "mnuTransactions";
this.mnuTransactions.Size = new System.Drawing.Size(158, 22);
this.mnuTransactions.Text = "&Transaction";
// 
// mnuTransactionTypes
// 
this.mnuTransactionTypes.Image = ((System.Drawing.Image)(resources.GetObject("mnuTransactionTypes.Image")));
this.mnuTransactionTypes.Name = "mnuTransactionTypes";
this.mnuTransactionTypes.Size = new System.Drawing.Size(245, 22);
this.mnuTransactionTypes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.TransactionTypeUI";
this.mnuTransactionTypes.Text = "Transaction &Types";
this.mnuTransactionTypes.Click += new System.EventHandler(this.mnuTransactionTypes_Click);
// 
// mnuTransactionCodes
// 
this.mnuTransactionCodes.Image = ((System.Drawing.Image)(resources.GetObject("mnuTransactionCodes.Image")));
this.mnuTransactionCodes.Name = "mnuTransactionCodes";
this.mnuTransactionCodes.Size = new System.Drawing.Size(245, 22);
this.mnuTransactionCodes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.TransactionCodeUI";
this.mnuTransactionCodes.Text = "Transaction &Codes";
this.mnuTransactionCodes.Click += new System.EventHandler(this.mnuTransactionCodes_Click);
// 
// mnuTransactionCodeSubAccounts
// 
this.mnuTransactionCodeSubAccounts.Name = "mnuTransactionCodeSubAccounts";
this.mnuTransactionCodeSubAccounts.Size = new System.Drawing.Size(245, 22);
this.mnuTransactionCodeSubAccounts.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.TransactionCodeSubAccountUI";
this.mnuTransactionCodeSubAccounts.Text = "Transaction Code Sub-Accounts";
this.mnuTransactionCodeSubAccounts.Visible = false;
this.mnuTransactionCodeSubAccounts.Click += new System.EventHandler(this.mnuTransactionCodeSubAccounts_Click);
// 
// mnuTransactionSources
// 
this.mnuTransactionSources.Name = "mnuTransactionSources";
this.mnuTransactionSources.Size = new System.Drawing.Size(245, 22);
this.mnuTransactionSources.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.TransactionSourceDocumentUI";
this.mnuTransactionSources.Text = "Transaction Sources";
this.mnuTransactionSources.Click += new System.EventHandler(this.mnuTransactionSources_Click);
// 
// mnuServices
// 
this.mnuServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHousekeepers,
            this.mnuEngineeringServices,
            this.toolStripMenuItem27,
            this.mnuEngineeringJob,
            this.mnuHousekeepingJob,
            this.toolStripMenuItem53,
            this.housekeepingStepProcedureToolStripMenuItem});
this.mnuServices.Name = "mnuServices";
this.mnuServices.Size = new System.Drawing.Size(158, 22);
this.mnuServices.Text = "&Services";
// 
// mnuHousekeepers
// 
this.mnuHousekeepers.Name = "mnuHousekeepers";
this.mnuHousekeepers.Size = new System.Drawing.Size(233, 22);
this.mnuHousekeepers.Tag = "Jinisys.Hotel.Services.Presentation.HouseKeeperUI";
this.mnuHousekeepers.Text = "&Housekeepers";
this.mnuHousekeepers.Click += new System.EventHandler(this.mnuConfigurationHousekeepers_Click);
// 
// mnuEngineeringServices
// 
this.mnuEngineeringServices.Name = "mnuEngineeringServices";
this.mnuEngineeringServices.Size = new System.Drawing.Size(233, 22);
this.mnuEngineeringServices.Tag = "Jinisys.Hotel.Services.Presentation.EngineeringServiceUI";
this.mnuEngineeringServices.Text = "&Engineering Services";
this.mnuEngineeringServices.Click += new System.EventHandler(this.mnuEngineering_Click);
// 
// toolStripMenuItem27
// 
this.toolStripMenuItem27.Name = "toolStripMenuItem27";
this.toolStripMenuItem27.Size = new System.Drawing.Size(230, 6);
// 
// mnuEngineeringJob
// 
this.mnuEngineeringJob.Name = "mnuEngineeringJob";
this.mnuEngineeringJob.Size = new System.Drawing.Size(233, 22);
this.mnuEngineeringJob.Tag = "Jinisys.Hotel.Services.Presentation.EngineeringJobUI";
this.mnuEngineeringJob.Text = "Engineering &Job";
this.mnuEngineeringJob.Click += new System.EventHandler(this.mnuEngineeringJob_Click);
// 
// mnuHousekeepingJob
// 
this.mnuHousekeepingJob.Name = "mnuHousekeepingJob";
this.mnuHousekeepingJob.Size = new System.Drawing.Size(233, 22);
this.mnuHousekeepingJob.Tag = "Jinisys.Hotel.Services.Presentation.HousekeepingUI";
this.mnuHousekeepingJob.Text = "House&keeping Job";
this.mnuHousekeepingJob.Click += new System.EventHandler(this.mnuHousekeeping_Click);
// 
// toolStripMenuItem53
// 
this.toolStripMenuItem53.Name = "toolStripMenuItem53";
this.toolStripMenuItem53.Size = new System.Drawing.Size(230, 6);
// 
// housekeepingStepProcedureToolStripMenuItem
// 
this.housekeepingStepProcedureToolStripMenuItem.Name = "housekeepingStepProcedureToolStripMenuItem";
this.housekeepingStepProcedureToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
this.housekeepingStepProcedureToolStripMenuItem.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.HousekeepingStepProcedureUI";
this.housekeepingStepProcedureToolStripMenuItem.Text = "Housekeeping Step Procedure";
this.housekeepingStepProcedureToolStripMenuItem.Click += new System.EventHandler(this.housekeepingStepProcedureToolStripMenuItem_Click);
// 
// toolStripMenuItem50
// 
this.toolStripMenuItem50.Name = "toolStripMenuItem50";
this.toolStripMenuItem50.Size = new System.Drawing.Size(155, 6);
// 
// minibarToolStripMenuItem
// 
this.minibarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMinibarItemCategory,
            this.mnuMinibarItems});
this.minibarToolStripMenuItem.Name = "minibarToolStripMenuItem";
this.minibarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
this.minibarToolStripMenuItem.Text = "Minibar";
// 
// mnuMinibarItemCategory
// 
this.mnuMinibarItemCategory.Name = "mnuMinibarItemCategory";
this.mnuMinibarItemCategory.Size = new System.Drawing.Size(157, 22);
this.mnuMinibarItemCategory.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.MinibarItemCategoryUI";
this.mnuMinibarItemCategory.Text = "Item Categories";
this.mnuMinibarItemCategory.Click += new System.EventHandler(this.mnuMinibarItemCategory_Click);
// 
// mnuMinibarItems
// 
this.mnuMinibarItems.Name = "mnuMinibarItems";
this.mnuMinibarItems.Size = new System.Drawing.Size(157, 22);
this.mnuMinibarItems.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.MinibarItemUI";
this.mnuMinibarItems.Text = "Items";
this.mnuMinibarItems.Click += new System.EventHandler(this.mnuMinibarItems_Click);
// 
// toolStripMenuItem45
// 
this.toolStripMenuItem45.Name = "toolStripMenuItem45";
this.toolStripMenuItem45.Size = new System.Drawing.Size(155, 6);
// 
// mnuAgents
// 
this.mnuAgents.Name = "mnuAgents";
this.mnuAgents.Size = new System.Drawing.Size(158, 22);
this.mnuAgents.Tag = "Jinisys.Hotel.Accounts.Presentation.AgentUI";
this.mnuAgents.Text = "Agents";
this.mnuAgents.Click += new System.EventHandler(this.mnuAgents_Click);
// 
// mnuConfigDrivers
// 
this.mnuConfigDrivers.Name = "mnuConfigDrivers";
this.mnuConfigDrivers.Size = new System.Drawing.Size(158, 22);
this.mnuConfigDrivers.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.DriverUI";
this.mnuConfigDrivers.Text = "Drivers";
this.mnuConfigDrivers.Click += new System.EventHandler(this.mnuConfigDrivers_Click);
// 
// toolStripMenuItem47
// 
this.toolStripMenuItem47.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEventTypes,
            this.mnuConfigRequirement,
            this.eventMealToolStripMenuItem,
            this.mnuEventPackage,
            this.appliedRatesToolStripMenuItem});
this.toolStripMenuItem47.Name = "toolStripMenuItem47";
this.toolStripMenuItem47.Size = new System.Drawing.Size(158, 22);
this.toolStripMenuItem47.Text = "Events";
// 
// mnuEventTypes
// 
this.mnuEventTypes.Name = "mnuEventTypes";
this.mnuEventTypes.Size = new System.Drawing.Size(147, 22);
this.mnuEventTypes.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.EventHeaderUI";
this.mnuEventTypes.Text = "Event Types";
this.mnuEventTypes.Click += new System.EventHandler(this.mnuEventTypes_Click);
// 
// mnuConfigRequirement
// 
this.mnuConfigRequirement.Name = "mnuConfigRequirement";
this.mnuConfigRequirement.Size = new System.Drawing.Size(147, 22);
this.mnuConfigRequirement.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.RequirementHeaderUI";
this.mnuConfigRequirement.Text = "Requirements";
this.mnuConfigRequirement.Click += new System.EventHandler(this.requirementCodeToolStripMenuItem_Click);
// 
// eventMealToolStripMenuItem
// 
this.eventMealToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMealItem,
            this.mealGroupToolStripMenuItem,
            this.mealMenuToolStripMenuItem});
this.eventMealToolStripMenuItem.Name = "eventMealToolStripMenuItem";
this.eventMealToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
this.eventMealToolStripMenuItem.Text = "Meals";
// 
// mnuMealItem
// 
this.mnuMealItem.Name = "mnuMealItem";
this.mnuMealItem.Size = new System.Drawing.Size(136, 22);
this.mnuMealItem.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.MealItemUI";
this.mnuMealItem.Text = "Meal Item";
this.mnuMealItem.Click += new System.EventHandler(this.mnuMealItem_Click);
// 
// mealGroupToolStripMenuItem
// 
this.mealGroupToolStripMenuItem.Name = "mealGroupToolStripMenuItem";
this.mealGroupToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
this.mealGroupToolStripMenuItem.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.MealGroupUI";
this.mealGroupToolStripMenuItem.Text = "Meal Group";
this.mealGroupToolStripMenuItem.Click += new System.EventHandler(this.mealGroupToolStripMenuItem_Click);
// 
// mealMenuToolStripMenuItem
// 
this.mealMenuToolStripMenuItem.Name = "mealMenuToolStripMenuItem";
this.mealMenuToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
this.mealMenuToolStripMenuItem.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.MealMenuUI";
this.mealMenuToolStripMenuItem.Text = "Meal Menu";
this.mealMenuToolStripMenuItem.Click += new System.EventHandler(this.mealMenuToolStripMenuItem_Click);
// 
// mnuEventPackage
// 
this.mnuEventPackage.Name = "mnuEventPackage";
this.mnuEventPackage.Size = new System.Drawing.Size(147, 22);
this.mnuEventPackage.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.EventPackageUI";
this.mnuEventPackage.Text = "Package";
this.mnuEventPackage.Click += new System.EventHandler(this.mnuEventPackage_Click);
// 
// appliedRatesToolStripMenuItem
// 
this.appliedRatesToolStripMenuItem.Name = "appliedRatesToolStripMenuItem";
this.appliedRatesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
this.appliedRatesToolStripMenuItem.Tag = "Jinisys.Hotel.ConfigurationHotel.Presentation.AppliedRatesUI";
this.appliedRatesToolStripMenuItem.Text = "Applied Rates";
this.appliedRatesToolStripMenuItem.Click += new System.EventHandler(this.appliedRatesToolStripMenuItem_Click);
// 
// tsmTransactions
// 
this.tsmTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFontDesk,
            this.mnuCashiering,
            this.toolStripMenuItem29,
            this.mnuAudit});
this.tsmTransactions.Name = "tsmTransactions";
this.tsmTransactions.Size = new System.Drawing.Size(48, 20);
this.tsmTransactions.Text = "Event";
// 
// mnuFontDesk
// 
this.mnuFontDesk.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guestsListToolStripMenuItem,
            this.toolStripMenuItem39,
            this.mnuSingleReservation,
            this.mnuGroupReservation,
            this.mnuSharedReservation,
            this.toolStripMenuItem10,
            this.mnuWaitListReservation,
            this.toolStripMenuItem44,
            this.mnuGroupBlocking,
            this.roomCalendarNEWToolStripMenuItem,
            this.roomAvailabilityToolStripMenuItem,
            this.mnuAvailableRoomsToday,
            this.toolStripMenuItem9,
            this.MenuReservationNoRoom,
            this.toolStripMenuItem58});
this.mnuFontDesk.Name = "mnuFontDesk";
this.mnuFontDesk.Size = new System.Drawing.Size(152, 22);
this.mnuFontDesk.Text = "Reservations";
// 
// guestsListToolStripMenuItem
// 
this.guestsListToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Accounts;
this.guestsListToolStripMenuItem.Name = "guestsListToolStripMenuItem";
this.guestsListToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
this.guestsListToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
this.guestsListToolStripMenuItem.Tag = "Jinisys.Hotel.Reservation.Presentation.ReservationListUI";
this.guestsListToolStripMenuItem.Text = "Guests List";
this.guestsListToolStripMenuItem.Click += new System.EventHandler(this.mnuReservationList_Click);
// 
// toolStripMenuItem39
// 
this.toolStripMenuItem39.Name = "toolStripMenuItem39";
this.toolStripMenuItem39.Size = new System.Drawing.Size(245, 6);
// 
// mnuSingleReservation
// 
this.mnuSingleReservation.Image = ((System.Drawing.Image)(resources.GetObject("mnuSingleReservation.Image")));
this.mnuSingleReservation.Name = "mnuSingleReservation";
this.mnuSingleReservation.ShortcutKeys = System.Windows.Forms.Keys.F6;
this.mnuSingleReservation.Size = new System.Drawing.Size(248, 22);
this.mnuSingleReservation.Tag = "Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI";
this.mnuSingleReservation.Text = "&Single Reservation";
this.mnuSingleReservation.Click += new System.EventHandler(this.mnuSingleReservation_Click);
// 
// mnuGroupReservation
// 
this.mnuGroupReservation.Image = ((System.Drawing.Image)(resources.GetObject("mnuGroupReservation.Image")));
this.mnuGroupReservation.Name = "mnuGroupReservation";
this.mnuGroupReservation.ShortcutKeys = System.Windows.Forms.Keys.F7;
this.mnuGroupReservation.Size = new System.Drawing.Size(248, 22);
this.mnuGroupReservation.Tag = "Jinisys.Hotel.Reservation.Presentation.ReservationUI";
this.mnuGroupReservation.Text = "&Group Reservation";
this.mnuGroupReservation.Click += new System.EventHandler(this.mnuGroupReservation_Click);
// 
// mnuSharedReservation
// 
this.mnuSharedReservation.Image = ((System.Drawing.Image)(resources.GetObject("mnuSharedReservation.Image")));
this.mnuSharedReservation.Name = "mnuSharedReservation";
this.mnuSharedReservation.ShortcutKeys = System.Windows.Forms.Keys.F8;
this.mnuSharedReservation.Size = new System.Drawing.Size(248, 22);
this.mnuSharedReservation.Tag = "Jinisys.Hotel.Reservation.Presentation.MarketingUI";
this.mnuSharedReservation.Text = "Marketing";
this.mnuSharedReservation.Visible = false;
this.mnuSharedReservation.Click += new System.EventHandler(this.MnuShare_Click);
// 
// toolStripMenuItem10
// 
this.toolStripMenuItem10.Name = "toolStripMenuItem10";
this.toolStripMenuItem10.Size = new System.Drawing.Size(245, 6);
// 
// mnuWaitListReservation
// 
this.mnuWaitListReservation.Name = "mnuWaitListReservation";
this.mnuWaitListReservation.Size = new System.Drawing.Size(248, 22);
this.mnuWaitListReservation.Text = "Wait List Reservation";
this.mnuWaitListReservation.Click += new System.EventHandler(this.mnuWaitListReservation_Click);
// 
// toolStripMenuItem44
// 
this.toolStripMenuItem44.Name = "toolStripMenuItem44";
this.toolStripMenuItem44.Size = new System.Drawing.Size(245, 6);
// 
// mnuGroupBlocking
// 
this.mnuGroupBlocking.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.calendar_32;
this.mnuGroupBlocking.Name = "mnuGroupBlocking";
this.mnuGroupBlocking.ShortcutKeys = System.Windows.Forms.Keys.F9;
this.mnuGroupBlocking.Size = new System.Drawing.Size(248, 22);
this.mnuGroupBlocking.Tag = "Jinisys.Hotel.Reservation.Presentation.GroupBlokingUI";
this.mnuGroupBlocking.Text = "&Quick Blocking";
this.mnuGroupBlocking.Click += new System.EventHandler(this.mnuGrpBlocking_Click);
// 
// roomCalendarNEWToolStripMenuItem
// 
this.roomCalendarNEWToolStripMenuItem.Name = "roomCalendarNEWToolStripMenuItem";
this.roomCalendarNEWToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
this.roomCalendarNEWToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
this.roomCalendarNEWToolStripMenuItem.Tag = "Jinisys.Hotel.Reservation.Presentation.RoomCalendar_New";
this.roomCalendarNEWToolStripMenuItem.Text = "Room Calendar";
this.roomCalendarNEWToolStripMenuItem.Click += new System.EventHandler(this.roomCalendarNEWToolStripMenuItem_Click);
// 
// roomAvailabilityToolStripMenuItem
// 
this.roomAvailabilityToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.CALENDR1;
this.roomAvailabilityToolStripMenuItem.Name = "roomAvailabilityToolStripMenuItem";
this.roomAvailabilityToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
this.roomAvailabilityToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
this.roomAvailabilityToolStripMenuItem.Tag = "Jinisys.Hotel.Reservation.Presentation.RoomCalendarUI";
this.roomAvailabilityToolStripMenuItem.Text = "Room Availability";
this.roomAvailabilityToolStripMenuItem.Click += new System.EventHandler(this.roomAvailabilityToolStripMenuItem_Click);
// 
// mnuAvailableRoomsToday
// 
this.mnuAvailableRoomsToday.Name = "mnuAvailableRoomsToday";
this.mnuAvailableRoomsToday.ShortcutKeys = System.Windows.Forms.Keys.F1;
this.mnuAvailableRoomsToday.Size = new System.Drawing.Size(248, 22);
this.mnuAvailableRoomsToday.Tag = "Jinisys.Hotel.Reservation.Presentation.RoomAvailabilityTodayUI";
this.mnuAvailableRoomsToday.Text = "Available Rooms Today";
this.mnuAvailableRoomsToday.Click += new System.EventHandler(this.mnuAvailableRoomsToday_Click);
// 
// toolStripMenuItem9
// 
this.toolStripMenuItem9.Name = "toolStripMenuItem9";
this.toolStripMenuItem9.Size = new System.Drawing.Size(245, 6);
// 
// MenuReservationNoRoom
// 
this.MenuReservationNoRoom.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.people;
this.MenuReservationNoRoom.Name = "MenuReservationNoRoom";
this.MenuReservationNoRoom.Size = new System.Drawing.Size(248, 22);
this.MenuReservationNoRoom.Text = "Single Reservation (Non-Staying)";
this.MenuReservationNoRoom.Click += new System.EventHandler(this.MenuReservationNoRoom_Click);
// 
// toolStripMenuItem58
// 
this.toolStripMenuItem58.Name = "toolStripMenuItem58";
this.toolStripMenuItem58.Size = new System.Drawing.Size(245, 6);
// 
// mnuCashiering
// 
this.mnuCashiering.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFolioLedgers,
            this.toolStripMenuItem11,
            this.mnuFolioRouting,
            this.mnuCheckOut,
            this.toolStripMenuItem12,
            this.mnuPostTransactionNonGuest,
            this.toolStripMenuItem46,
            this.mnuOpenShift,
            this.mnuCloseShift});
this.mnuCashiering.Name = "mnuCashiering";
this.mnuCashiering.Size = new System.Drawing.Size(152, 22);
this.mnuCashiering.Text = "&Cashiering";
// 
// mnuFolioLedgers
// 
this.mnuFolioLedgers.Image = ((System.Drawing.Image)(resources.GetObject("mnuFolioLedgers.Image")));
this.mnuFolioLedgers.Name = "mnuFolioLedgers";
this.mnuFolioLedgers.ShortcutKeys = System.Windows.Forms.Keys.F11;
this.mnuFolioLedgers.Size = new System.Drawing.Size(236, 22);
this.mnuFolioLedgers.Tag = "Jinisys.Hotel.Cashier.Presentation.FolioLedgersUI";
this.mnuFolioLedgers.Text = "Folio &Ledgers";
this.mnuFolioLedgers.Click += new System.EventHandler(this.mnuCashierFolioLedger_Click);
// 
// toolStripMenuItem11
// 
this.toolStripMenuItem11.Name = "toolStripMenuItem11";
this.toolStripMenuItem11.Size = new System.Drawing.Size(233, 6);
// 
// mnuFolioRouting
// 
this.mnuFolioRouting.Image = ((System.Drawing.Image)(resources.GetObject("mnuFolioRouting.Image")));
this.mnuFolioRouting.Name = "mnuFolioRouting";
this.mnuFolioRouting.ShortcutKeyDisplayString = "^R";
this.mnuFolioRouting.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
this.mnuFolioRouting.Size = new System.Drawing.Size(236, 22);
this.mnuFolioRouting.Tag = "Jinisys.Hotel.Cashier.Presentation.TransactionRoutingUI";
this.mnuFolioRouting.Text = "Route Transaction";
this.mnuFolioRouting.Click += new System.EventHandler(this.mnuCashieringFolioAdjustment_Click);
// 
// mnuCheckOut
// 
this.mnuCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("mnuCheckOut.Image")));
this.mnuCheckOut.Name = "mnuCheckOut";
this.mnuCheckOut.ShortcutKeyDisplayString = "^O";
this.mnuCheckOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
this.mnuCheckOut.Size = new System.Drawing.Size(236, 22);
this.mnuCheckOut.Tag = "Jinisys.Hotel.Cashier.Presentation.CheckOutUI";
this.mnuCheckOut.Text = "Check &Out";
this.mnuCheckOut.Click += new System.EventHandler(this.mnuCashieringCheckOut_Click);
// 
// toolStripMenuItem12
// 
this.toolStripMenuItem12.Name = "toolStripMenuItem12";
this.toolStripMenuItem12.Size = new System.Drawing.Size(233, 6);
// 
// mnuPostTransactionNonGuest
// 
this.mnuPostTransactionNonGuest.Name = "mnuPostTransactionNonGuest";
this.mnuPostTransactionNonGuest.ShortcutKeyDisplayString = "^D";
this.mnuPostTransactionNonGuest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
this.mnuPostTransactionNonGuest.Size = new System.Drawing.Size(236, 22);
this.mnuPostTransactionNonGuest.Tag = "Jinisys.Hotel.Cashier.Presentation.DirectTransactionPostUI";
this.mnuPostTransactionNonGuest.Text = "Direct Transaction Posting";
this.mnuPostTransactionNonGuest.Click += new System.EventHandler(this.mnuPostTransactionNonGuest_Click);
// 
// toolStripMenuItem46
// 
this.toolStripMenuItem46.Name = "toolStripMenuItem46";
this.toolStripMenuItem46.Size = new System.Drawing.Size(233, 6);
// 
// mnuOpenShift
// 
this.mnuOpenShift.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenShift.Image")));
this.mnuOpenShift.Name = "mnuOpenShift";
this.mnuOpenShift.Size = new System.Drawing.Size(236, 22);
this.mnuOpenShift.Tag = "Jinisys.Hotel.Cashier.Presentation.CashTerminalListUI";
this.mnuOpenShift.Text = "&Open Shift / Cash Drawer";
this.mnuOpenShift.Click += new System.EventHandler(this.mnuOpenShift_Click);
// 
// mnuCloseShift
// 
this.mnuCloseShift.Image = ((System.Drawing.Image)(resources.GetObject("mnuCloseShift.Image")));
this.mnuCloseShift.Name = "mnuCloseShift";
this.mnuCloseShift.Size = new System.Drawing.Size(236, 22);
this.mnuCloseShift.Tag = "Jinisys.Hotel.Cashier.Presentation.CloseShiftUI";
this.mnuCloseShift.Text = "&Close Shift / Cash Drawer";
this.mnuCloseShift.Click += new System.EventHandler(this.mnuCloseShift_Click);
// 
// toolStripMenuItem29
// 
this.toolStripMenuItem29.Name = "toolStripMenuItem29";
this.toolStripMenuItem29.Size = new System.Drawing.Size(149, 6);
this.toolStripMenuItem29.Visible = false;
// 
// mnuAudit
// 
this.mnuAudit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDayEndClosing,
            this.toolStripMenuItem14,
            this.mnuConfigureDayEndClosing,
            this.mnuChangeAuditDate});
this.mnuAudit.Name = "mnuAudit";
this.mnuAudit.Size = new System.Drawing.Size(152, 22);
this.mnuAudit.Text = "Night &Audit";
// 
// mnuDayEndClosing
// 
this.mnuDayEndClosing.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.history_32;
this.mnuDayEndClosing.Name = "mnuDayEndClosing";
this.mnuDayEndClosing.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
this.mnuDayEndClosing.Size = new System.Drawing.Size(218, 22);
this.mnuDayEndClosing.Tag = "Jinisys.Hotel.NightAudit.Presentation.DayEndClosingUI";
this.mnuDayEndClosing.Text = "&Day-End Closing";
this.mnuDayEndClosing.Click += new System.EventHandler(this.mnuAuditDayEnd_Click);
// 
// toolStripMenuItem14
// 
this.toolStripMenuItem14.Name = "toolStripMenuItem14";
this.toolStripMenuItem14.Size = new System.Drawing.Size(215, 6);
// 
// mnuConfigureDayEndClosing
// 
this.mnuConfigureDayEndClosing.Image = ((System.Drawing.Image)(resources.GetObject("mnuConfigureDayEndClosing.Image")));
this.mnuConfigureDayEndClosing.Name = "mnuConfigureDayEndClosing";
this.mnuConfigureDayEndClosing.Size = new System.Drawing.Size(218, 22);
this.mnuConfigureDayEndClosing.Tag = "Jinisys.Hotel.NightAudit.Presentation.DayEndConfigurationUI";
this.mnuConfigureDayEndClosing.Text = "Configure Day-End Closing";
this.mnuConfigureDayEndClosing.Click += new System.EventHandler(this.mnuAuditPostRoomCharges_Click);
// 
// mnuChangeAuditDate
// 
this.mnuChangeAuditDate.Name = "mnuChangeAuditDate";
this.mnuChangeAuditDate.Size = new System.Drawing.Size(218, 22);
this.mnuChangeAuditDate.Text = "Change Audit Date";
// 
// inquiryToolStripMenuItem
// 
this.inquiryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInhouseGuestsForecast,
            this.noOfPaxToolStripMenuItem,
            this.toolStripMenuItem33,
            this.MenutransactionRegisterToolStrip,
            this.toolStripMenuItem36,
            this.folioLedgerIToolStripMenuItem,
            this.mnuRoomHistoryInquiry,
            this.toolStripMenuItem37,
            this.cityLedgerToolStripMenuItem1,
            this.cityTransferToolStripMenuItem,
            this.toolStripMenuItem41,
            this.guestByRateCodeToolStripMenuItem,
            this.toolStripMenuItem49,
            this.mnuInquiryHotelRevenue,
            this.mnuInquiryRoomRevenue,
            this.salesForecsToolStripMenuItem,
            this.toolStripMenuItem57,
            this.mnuShiftEndorsements,
            this.toolStripSeparator17,
            this.mnuEventList,
            this.mnuEventsRevenue,
            this.statisticalDataToolStripMenuItem,
            this.toolStripMenuItem60,
            this.marketSegmentToolStripMenuItem,
            this.mnuCalendarOfEvents,
            this.mnuLostBusiness,
            this.mnuBookingInquiries,
            this.mnuAvailabilityOfRooms,
            this.mnuWeeklyEventSchedules,
            this.topClientsToolStripMenuItem,
            this.historicalEventsAndRevenueToolStripMenuItem,
            this.clientTypeReportToolStripMenuItem});
this.inquiryToolStripMenuItem.Name = "inquiryToolStripMenuItem";
this.inquiryToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
this.inquiryToolStripMenuItem.Text = "Inquiry";
// 
// menuInhouseGuestsForecast
// 
this.menuInhouseGuestsForecast.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Author;
this.menuInhouseGuestsForecast.Name = "menuInhouseGuestsForecast";
this.menuInhouseGuestsForecast.Size = new System.Drawing.Size(234, 22);
this.menuInhouseGuestsForecast.Tag = "Jinisys.Hotel.Reports.Presentation.InHouseForeCastUI";
this.menuInhouseGuestsForecast.Text = "Inhouse Guests Forecast";
this.menuInhouseGuestsForecast.Visible = false;
this.menuInhouseGuestsForecast.Click += new System.EventHandler(this.menuInhouseGuestsForecast_Click);
// 
// noOfPaxToolStripMenuItem
// 
this.noOfPaxToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.MorePeople;
this.noOfPaxToolStripMenuItem.Name = "noOfPaxToolStripMenuItem";
this.noOfPaxToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.noOfPaxToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.NoOfPax";
this.noOfPaxToolStripMenuItem.Text = "No. Of Pax";
this.noOfPaxToolStripMenuItem.Visible = false;
this.noOfPaxToolStripMenuItem.Click += new System.EventHandler(this.noOfPaxToolStripMenuItem_Click);
// 
// toolStripMenuItem33
// 
this.toolStripMenuItem33.Name = "toolStripMenuItem33";
this.toolStripMenuItem33.Size = new System.Drawing.Size(231, 6);
this.toolStripMenuItem33.Visible = false;
// 
// MenutransactionRegisterToolStrip
// 
this.MenutransactionRegisterToolStrip.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.libraryCabinet;
this.MenutransactionRegisterToolStrip.Name = "MenutransactionRegisterToolStrip";
this.MenutransactionRegisterToolStrip.Size = new System.Drawing.Size(234, 22);
this.MenutransactionRegisterToolStrip.Tag = "Jinisys.Hotel.Reports.Presentation.TransactionRegisterUI";
this.MenutransactionRegisterToolStrip.Text = "Transaction Register";
this.MenutransactionRegisterToolStrip.Visible = false;
this.MenutransactionRegisterToolStrip.Click += new System.EventHandler(this.MenutransactionRegisterToolStrip_Click);
// 
// toolStripMenuItem36
// 
this.toolStripMenuItem36.Name = "toolStripMenuItem36";
this.toolStripMenuItem36.Size = new System.Drawing.Size(231, 6);
this.toolStripMenuItem36.Visible = false;
// 
// folioLedgerIToolStripMenuItem
// 
this.folioLedgerIToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.My_Favorites_Folder;
this.folioLedgerIToolStripMenuItem.Name = "folioLedgerIToolStripMenuItem";
this.folioLedgerIToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.folioLedgerIToolStripMenuItem.Tag = "Jinisys.Hotel.Cashier.Presentation.FolioLedgerInquiryUI";
this.folioLedgerIToolStripMenuItem.Text = "Event History";
this.folioLedgerIToolStripMenuItem.Click += new System.EventHandler(this.folioLedgerIToolStripMenuItem_Click);
// 
// mnuRoomHistoryInquiry
// 
this.mnuRoomHistoryInquiry.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.SETI_Home;
this.mnuRoomHistoryInquiry.Name = "mnuRoomHistoryInquiry";
this.mnuRoomHistoryInquiry.Size = new System.Drawing.Size(234, 22);
this.mnuRoomHistoryInquiry.Tag = "Jinisys.Hotel.Reservation.Presentation.RoomHistoryUI";
this.mnuRoomHistoryInquiry.Text = "Room History";
this.mnuRoomHistoryInquiry.Click += new System.EventHandler(this.mnuRoomHistoryInquiry_Click);
// 
// toolStripMenuItem37
// 
this.toolStripMenuItem37.Name = "toolStripMenuItem37";
this.toolStripMenuItem37.Size = new System.Drawing.Size(231, 6);
// 
// cityLedgerToolStripMenuItem1
// 
this.cityLedgerToolStripMenuItem1.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.anotacoes;
this.cityLedgerToolStripMenuItem1.Name = "cityLedgerToolStripMenuItem1";
this.cityLedgerToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
this.cityLedgerToolStripMenuItem1.Tag = "Jinisys.Hotel.AccountingInterface.Presentation.CityLedgerUI";
this.cityLedgerToolStripMenuItem1.Text = "City Ledger";
this.cityLedgerToolStripMenuItem1.Visible = false;
this.cityLedgerToolStripMenuItem1.Click += new System.EventHandler(this.cityLedgerToolStripMenuItem1_Click);
// 
// cityTransferToolStripMenuItem
// 
this.cityTransferToolStripMenuItem.Name = "cityTransferToolStripMenuItem";
this.cityTransferToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.cityTransferToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.CityTransferUI";
this.cityTransferToolStripMenuItem.Text = "City Transfer";
this.cityTransferToolStripMenuItem.Visible = false;
this.cityTransferToolStripMenuItem.Click += new System.EventHandler(this.cityTransferToolStripMenuItem_Click);
// 
// toolStripMenuItem41
// 
this.toolStripMenuItem41.Name = "toolStripMenuItem41";
this.toolStripMenuItem41.Size = new System.Drawing.Size(231, 6);
this.toolStripMenuItem41.Visible = false;
// 
// guestByRateCodeToolStripMenuItem
// 
this.guestByRateCodeToolStripMenuItem.Name = "guestByRateCodeToolStripMenuItem";
this.guestByRateCodeToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.guestByRateCodeToolStripMenuItem.Tag = "Jinisys.Hotel.Reservation.Presentation.RateType_Inquiry";
this.guestByRateCodeToolStripMenuItem.Text = "Guest by Rate Code";
this.guestByRateCodeToolStripMenuItem.Visible = false;
this.guestByRateCodeToolStripMenuItem.Click += new System.EventHandler(this.guestByRateCodeToolStripMenuItem_Click);
// 
// toolStripMenuItem49
// 
this.toolStripMenuItem49.Name = "toolStripMenuItem49";
this.toolStripMenuItem49.Size = new System.Drawing.Size(231, 6);
this.toolStripMenuItem49.Visible = false;
// 
// mnuInquiryHotelRevenue
// 
this.mnuInquiryHotelRevenue.Name = "mnuInquiryHotelRevenue";
this.mnuInquiryHotelRevenue.Size = new System.Drawing.Size(234, 22);
this.mnuInquiryHotelRevenue.Tag = "Jinisys.Hotel.Reports.Presentation.HotelRevenueUI";
this.mnuInquiryHotelRevenue.Text = "Hotel Revenue";
this.mnuInquiryHotelRevenue.Visible = false;
this.mnuInquiryHotelRevenue.Click += new System.EventHandler(this.mnuInquiryHotelRevenue_Click);
// 
// mnuInquiryRoomRevenue
// 
this.mnuInquiryRoomRevenue.Name = "mnuInquiryRoomRevenue";
this.mnuInquiryRoomRevenue.Size = new System.Drawing.Size(234, 22);
this.mnuInquiryRoomRevenue.Tag = "Jinisys.Hotel.Reports.Presentation.RoomRevenueUI";
this.mnuInquiryRoomRevenue.Text = "Room Revenue";
this.mnuInquiryRoomRevenue.Click += new System.EventHandler(this.mnuInquiryRoomRevenue_Click);
// 
// salesForecsToolStripMenuItem
// 
this.salesForecsToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.System_Monitor;
this.salesForecsToolStripMenuItem.Name = "salesForecsToolStripMenuItem";
this.salesForecsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.salesForecsToolStripMenuItem.Tag = "Jinisys.Hotel.Cashier.Presentation.SalesForecastUI";
this.salesForecsToolStripMenuItem.Text = "Sales Forecast";
this.salesForecsToolStripMenuItem.Visible = false;
this.salesForecsToolStripMenuItem.Click += new System.EventHandler(this.salesForecsToolStripMenuItem_Click);
// 
// toolStripMenuItem57
// 
this.toolStripMenuItem57.Name = "toolStripMenuItem57";
this.toolStripMenuItem57.Size = new System.Drawing.Size(231, 6);
// 
// mnuShiftEndorsements
// 
this.mnuShiftEndorsements.Name = "mnuShiftEndorsements";
this.mnuShiftEndorsements.Size = new System.Drawing.Size(234, 22);
this.mnuShiftEndorsements.Tag = "Jinisys.Hotel.Reservation.Presentation.EndorsementListUI";
this.mnuShiftEndorsements.Text = "Endorsements";
this.mnuShiftEndorsements.Visible = false;
this.mnuShiftEndorsements.Click += new System.EventHandler(this.mnuShiftEndorsements_Click);
// 
// toolStripSeparator17
// 
this.toolStripSeparator17.Name = "toolStripSeparator17";
this.toolStripSeparator17.Size = new System.Drawing.Size(231, 6);
this.toolStripSeparator17.Visible = false;
// 
// mnuEventList
// 
this.mnuEventList.Name = "mnuEventList";
this.mnuEventList.Size = new System.Drawing.Size(234, 22);
this.mnuEventList.Tag = "Jinisys.Hotel.Reservation.Presentation.EventListUI";
this.mnuEventList.Text = "Event List Report";
this.mnuEventList.Click += new System.EventHandler(this.mnuEventList_Click);
// 
// mnuEventsRevenue
// 
this.mnuEventsRevenue.Name = "mnuEventsRevenue";
this.mnuEventsRevenue.Size = new System.Drawing.Size(234, 22);
this.mnuEventsRevenue.Tag = "Jinisys.Hotel.Reports.Presentation.NumberOfEventsAndRevenue";
this.mnuEventsRevenue.Text = "Events and Revenue";
this.mnuEventsRevenue.Click += new System.EventHandler(this.mnuEventsRevenue_Click);
// 
// statisticalDataToolStripMenuItem
// 
this.statisticalDataToolStripMenuItem.Name = "statisticalDataToolStripMenuItem";
this.statisticalDataToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.statisticalDataToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.StatisticalReportUI";
this.statisticalDataToolStripMenuItem.Text = "Report Query";
this.statisticalDataToolStripMenuItem.Click += new System.EventHandler(this.statisticalDataToolStripMenuItem_Click);
// 
// toolStripMenuItem60
// 
this.toolStripMenuItem60.Name = "toolStripMenuItem60";
this.toolStripMenuItem60.Size = new System.Drawing.Size(234, 22);
this.toolStripMenuItem60.Tag = "Jinisys.Hotel.Reports.Presentation.MarketSegmentReport";
this.toolStripMenuItem60.Text = "Market Segment Comparison";
this.toolStripMenuItem60.Click += new System.EventHandler(this.toolStripMenuItem60_Click);
// 
// marketSegmentToolStripMenuItem
// 
this.marketSegmentToolStripMenuItem.Name = "marketSegmentToolStripMenuItem";
this.marketSegmentToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.marketSegmentToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.MarketSegmentUI";
this.marketSegmentToolStripMenuItem.Text = "Annual Market Segment";
this.marketSegmentToolStripMenuItem.Click += new System.EventHandler(this.marketSegmentToolStripMenuItem_Click);
// 
// mnuCalendarOfEvents
// 
this.mnuCalendarOfEvents.Name = "mnuCalendarOfEvents";
this.mnuCalendarOfEvents.Size = new System.Drawing.Size(234, 22);
this.mnuCalendarOfEvents.Tag = "Jinisys.Hotel.Reports.Presentation.CalendarOfEventsUI";
this.mnuCalendarOfEvents.Text = "Calendar of Events";
this.mnuCalendarOfEvents.Click += new System.EventHandler(this.mnuCalendarOfEvents_Click);
// 
// mnuLostBusiness
// 
this.mnuLostBusiness.Name = "mnuLostBusiness";
this.mnuLostBusiness.Size = new System.Drawing.Size(234, 22);
this.mnuLostBusiness.Tag = "Jinisys.Hotel.Reports.Presentation.LostBusinessUI";
this.mnuLostBusiness.Text = "Lost Business";
this.mnuLostBusiness.Click += new System.EventHandler(this.mnuLostBusiness_Click);
// 
// mnuBookingInquiries
// 
this.mnuBookingInquiries.Name = "mnuBookingInquiries";
this.mnuBookingInquiries.Size = new System.Drawing.Size(234, 22);
this.mnuBookingInquiries.Tag = "Jinisys.Hotel.Reports.Presentation.BookingAndInquiriesUI";
this.mnuBookingInquiries.Text = "Booking and Inquiries";
this.mnuBookingInquiries.Click += new System.EventHandler(this.mnuBookingInquiries_Click);
// 
// mnuAvailabilityOfRooms
// 
this.mnuAvailabilityOfRooms.Name = "mnuAvailabilityOfRooms";
this.mnuAvailabilityOfRooms.Size = new System.Drawing.Size(234, 22);
this.mnuAvailabilityOfRooms.Tag = "Jinisys.Hotel.Reports.Presentation.AvailabilityOfRoomsUI";
this.mnuAvailabilityOfRooms.Text = "Availability of Rooms";
this.mnuAvailabilityOfRooms.Click += new System.EventHandler(this.mnuAvailabilityOfRooms_Click);
// 
// mnuWeeklyEventSchedules
// 
this.mnuWeeklyEventSchedules.Name = "mnuWeeklyEventSchedules";
this.mnuWeeklyEventSchedules.Size = new System.Drawing.Size(234, 22);
this.mnuWeeklyEventSchedules.Tag = "Jinisys.Hotel.Reports.Presentation.WeeklyScheduleUI";
this.mnuWeeklyEventSchedules.Text = "Weekly Event Schedules";
this.mnuWeeklyEventSchedules.Click += new System.EventHandler(this.mnuWeeklyEventSchedules_Click);
// 
// topClientsToolStripMenuItem
// 
this.topClientsToolStripMenuItem.Name = "topClientsToolStripMenuItem";
this.topClientsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.topClientsToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.TopClientsUI";
this.topClientsToolStripMenuItem.Text = "Top Clients";
this.topClientsToolStripMenuItem.Click += new System.EventHandler(this.topClientsToolStripMenuItem_Click);
// 
// historicalEventsAndRevenueToolStripMenuItem
// 
this.historicalEventsAndRevenueToolStripMenuItem.Name = "historicalEventsAndRevenueToolStripMenuItem";
this.historicalEventsAndRevenueToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.historicalEventsAndRevenueToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.HistoricalEventsAndRevenue";
this.historicalEventsAndRevenueToolStripMenuItem.Text = "Historical Events And Revenue";
this.historicalEventsAndRevenueToolStripMenuItem.Click += new System.EventHandler(this.historicalEventsAndRevenueToolStripMenuItem_Click);
// 
// clientTypeReportToolStripMenuItem
// 
this.clientTypeReportToolStripMenuItem.Name = "clientTypeReportToolStripMenuItem";
this.clientTypeReportToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
this.clientTypeReportToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.StatisticAccountTypeUI";
this.clientTypeReportToolStripMenuItem.Text = "Client Type Report";
this.clientTypeReportToolStripMenuItem.Click += new System.EventHandler(this.clientTypeReportToolStripMenuItem_Click);
// 
// tsmReports
// 
this.tsmReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuestReport,
            this.mnuRoomsReport,
            this.toolStripMenuItem20,
            this.mnuTransactionReports,
            this.toolStripMenuItem21,
            this.housekeepingToolStripMenuItem,
            this.toolStripSeparator16,
            this.mnuRestaurant,
            this.toolStripMenuItem8,
            this.mnuOccupancyForecast,
            this.toolStripMenuItem40,
            this.cityLedgerToolStripMenuItem});
this.tsmReports.Name = "tsmReports";
this.tsmReports.Size = new System.Drawing.Size(59, 20);
this.tsmReports.Text = "&Reports";
// 
// mnuGuestReport
// 
this.mnuGuestReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArrivals,
            this.mnuDepartures,
            this.mnuInHouseGuest,
            this.toolStripMenuItem17,
            this.mnuExpectedArrivals,
            this.mnuExpectedDepartures,
            this.toolStripMenuItem31,
            this.cancelledReservationToolStripMenuItem,
            this.toolStripMenuItem32,
            this.guestLedgerToolStripMenuItem,
            this.mnuHighBalanceGuests,
            this.toolStripSeparator15,
            this.roomingListToolStripMenuItem,
            this.nationalityReportToolStripMenuItem});
this.mnuGuestReport.Name = "mnuGuestReport";
this.mnuGuestReport.Size = new System.Drawing.Size(203, 22);
this.mnuGuestReport.Text = "&Guests Report";
this.mnuGuestReport.Visible = false;
// 
// mnuArrivals
// 
this.mnuArrivals.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_arrivals;
this.mnuArrivals.Name = "mnuArrivals";
this.mnuArrivals.Size = new System.Drawing.Size(190, 22);
this.mnuArrivals.Tag = "Jinisys.Hotel.Reports.BusinessLayer.ReportFacade";
this.mnuArrivals.Text = "&Arrivals";
this.mnuArrivals.Click += new System.EventHandler(this.mnuGuestArrivalsReport_Click);
// 
// mnuDepartures
// 
this.mnuDepartures.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_departures;
this.mnuDepartures.Name = "mnuDepartures";
this.mnuDepartures.Size = new System.Drawing.Size(190, 22);
this.mnuDepartures.Text = "&Departures";
this.mnuDepartures.Click += new System.EventHandler(this.mnuGuestDeparture_Click);
// 
// mnuInHouseGuest
// 
this.mnuInHouseGuest.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_inhouse;
this.mnuInHouseGuest.Name = "mnuInHouseGuest";
this.mnuInHouseGuest.Size = new System.Drawing.Size(190, 22);
this.mnuInHouseGuest.Text = "&In-House Guest List";
this.mnuInHouseGuest.Click += new System.EventHandler(this.mnuReportsInHouseGuests_Click);
// 
// toolStripMenuItem17
// 
this.toolStripMenuItem17.Name = "toolStripMenuItem17";
this.toolStripMenuItem17.Size = new System.Drawing.Size(187, 6);
// 
// mnuExpectedArrivals
// 
this.mnuExpectedArrivals.Image = ((System.Drawing.Image)(resources.GetObject("mnuExpectedArrivals.Image")));
this.mnuExpectedArrivals.Name = "mnuExpectedArrivals";
this.mnuExpectedArrivals.Size = new System.Drawing.Size(190, 22);
this.mnuExpectedArrivals.Text = "&Expected Arrivals";
this.mnuExpectedArrivals.Click += new System.EventHandler(this.mnuReportExpectedArrivals_Click);
// 
// mnuExpectedDepartures
// 
this.mnuExpectedDepartures.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_expected_departure;
this.mnuExpectedDepartures.Name = "mnuExpectedDepartures";
this.mnuExpectedDepartures.Size = new System.Drawing.Size(190, 22);
this.mnuExpectedDepartures.Text = "E&xpected Departures";
this.mnuExpectedDepartures.Click += new System.EventHandler(this.mnuReportExpectedDeparture_Click);
// 
// toolStripMenuItem31
// 
this.toolStripMenuItem31.Name = "toolStripMenuItem31";
this.toolStripMenuItem31.Size = new System.Drawing.Size(187, 6);
// 
// cancelledReservationToolStripMenuItem
// 
this.cancelledReservationToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_cancelled;
this.cancelledReservationToolStripMenuItem.Name = "cancelledReservationToolStripMenuItem";
this.cancelledReservationToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
this.cancelledReservationToolStripMenuItem.Text = "Cancelled Reservation";
this.cancelledReservationToolStripMenuItem.Click += new System.EventHandler(this.cancelledReservationToolStripMenuItem_Click);
// 
// toolStripMenuItem32
// 
this.toolStripMenuItem32.Name = "toolStripMenuItem32";
this.toolStripMenuItem32.Size = new System.Drawing.Size(187, 6);
// 
// guestLedgerToolStripMenuItem
// 
this.guestLedgerToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_guestledger;
this.guestLedgerToolStripMenuItem.Name = "guestLedgerToolStripMenuItem";
this.guestLedgerToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
this.guestLedgerToolStripMenuItem.Text = "Guest Ledger";
this.guestLedgerToolStripMenuItem.Click += new System.EventHandler(this.guestLedgerToolStripMenuItem_Click);
// 
// mnuHighBalanceGuests
// 
this.mnuHighBalanceGuests.Name = "mnuHighBalanceGuests";
this.mnuHighBalanceGuests.Size = new System.Drawing.Size(190, 22);
this.mnuHighBalanceGuests.Text = "High Balance Guests";
this.mnuHighBalanceGuests.Click += new System.EventHandler(this.mnuHighBalanceGuests_Click);
// 
// toolStripSeparator15
// 
this.toolStripSeparator15.Name = "toolStripSeparator15";
this.toolStripSeparator15.Size = new System.Drawing.Size(187, 6);
// 
// roomingListToolStripMenuItem
// 
this.roomingListToolStripMenuItem.Name = "roomingListToolStripMenuItem";
this.roomingListToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
this.roomingListToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomingListU" +
    "I";
this.roomingListToolStripMenuItem.Text = "Rooming List";
this.roomingListToolStripMenuItem.Click += new System.EventHandler(this.roomingListToolStripMenuItem_Click);
// 
// nationalityReportToolStripMenuItem
// 
this.nationalityReportToolStripMenuItem.Name = "nationalityReportToolStripMenuItem";
this.nationalityReportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
this.nationalityReportToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.NationalityReport";
this.nationalityReportToolStripMenuItem.Text = "Nationality Report";
this.nationalityReportToolStripMenuItem.Click += new System.EventHandler(this.nationalityReportToolStripMenuItem_Click);
// 
// mnuRoomsReport
// 
this.mnuRoomsReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomOccupancyToolStripMenuItem,
            this.mnuRoomStatus,
            this.toolStripMenuItem19,
            this.mnuRoomAvailability,
            this.mnuUnderRepair,
            this.toolStripMenuItem18,
            this.mnuRoomTransfer});
this.mnuRoomsReport.Name = "mnuRoomsReport";
this.mnuRoomsReport.Size = new System.Drawing.Size(203, 22);
this.mnuRoomsReport.Text = "Rooms Report";
// 
// roomOccupancyToolStripMenuItem
// 
this.roomOccupancyToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_roomoccupancy;
this.roomOccupancyToolStripMenuItem.Name = "roomOccupancyToolStripMenuItem";
this.roomOccupancyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
this.roomOccupancyToolStripMenuItem.Text = "Room Occupancy";
this.roomOccupancyToolStripMenuItem.Visible = false;
this.roomOccupancyToolStripMenuItem.Click += new System.EventHandler(this.roomOccupancyToolStripMenuItem_Click);
// 
// mnuRoomStatus
// 
this.mnuRoomStatus.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_roomstatus1;
this.mnuRoomStatus.Name = "mnuRoomStatus";
this.mnuRoomStatus.Size = new System.Drawing.Size(183, 22);
this.mnuRoomStatus.Text = "Room &Status";
this.mnuRoomStatus.Visible = false;
this.mnuRoomStatus.Click += new System.EventHandler(this.mnuRoomStatus_Click);
// 
// toolStripMenuItem19
// 
this.toolStripMenuItem19.Name = "toolStripMenuItem19";
this.toolStripMenuItem19.Size = new System.Drawing.Size(180, 6);
this.toolStripMenuItem19.Visible = false;
// 
// mnuRoomAvailability
// 
this.mnuRoomAvailability.Name = "mnuRoomAvailability";
this.mnuRoomAvailability.Size = new System.Drawing.Size(183, 22);
this.mnuRoomAvailability.Text = "Room &Availability";
this.mnuRoomAvailability.Visible = false;
this.mnuRoomAvailability.Click += new System.EventHandler(this.mnuReportRoomAvailability_Click);
// 
// mnuUnderRepair
// 
this.mnuUnderRepair.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.reports_roomOutofOrder;
this.mnuUnderRepair.Name = "mnuUnderRepair";
this.mnuUnderRepair.Size = new System.Drawing.Size(183, 22);
this.mnuUnderRepair.Text = "Out Of Order Rooms";
this.mnuUnderRepair.Click += new System.EventHandler(this.mnuReportRoomForEngineeringJob_Click);
// 
// toolStripMenuItem18
// 
this.toolStripMenuItem18.Name = "toolStripMenuItem18";
this.toolStripMenuItem18.Size = new System.Drawing.Size(180, 6);
// 
// mnuRoomTransfer
// 
this.mnuRoomTransfer.Name = "mnuRoomTransfer";
this.mnuRoomTransfer.Size = new System.Drawing.Size(183, 22);
this.mnuRoomTransfer.Text = "Room &Transfer";
this.mnuRoomTransfer.Visible = false;
this.mnuRoomTransfer.Click += new System.EventHandler(this.mnuReportsRoomTransfer_Click);
// 
// toolStripMenuItem20
// 
this.toolStripMenuItem20.Name = "toolStripMenuItem20";
this.toolStripMenuItem20.Size = new System.Drawing.Size(200, 6);
// 
// mnuTransactionReports
// 
this.mnuTransactionReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAllTransaction,
            this.mnuSalesSummary,
            this.toolStripMenuItem34,
            this.cmuTransactionsPerCashier,
            this.toolStripMenuItem35,
            this.mnuCityTransferTransactions,
            this.mnuVoidedTransactions,
            this.toolStripMenuItem59,
            this.mnuDailyHotelRevenueReport});
this.mnuTransactionReports.Name = "mnuTransactionReports";
this.mnuTransactionReports.Size = new System.Drawing.Size(203, 22);
this.mnuTransactionReports.Text = "Transactions Report";
// 
// mnuAllTransaction
// 
this.mnuAllTransaction.Name = "mnuAllTransaction";
this.mnuAllTransaction.Size = new System.Drawing.Size(230, 22);
this.mnuAllTransaction.Tag = "Jinisys.Hotel.Reports.Presentation.ReportDateParamUI";
this.mnuAllTransaction.Text = "Daily Transaction Register";
this.mnuAllTransaction.Visible = false;
this.mnuAllTransaction.Click += new System.EventHandler(this.mnuAllTransactionsReport_Click);
// 
// mnuSalesSummary
// 
this.mnuSalesSummary.Name = "mnuSalesSummary";
this.mnuSalesSummary.Size = new System.Drawing.Size(230, 22);
this.mnuSalesSummary.Tag = "Jinisys.Hotel.Reports.Presentation.ReportDateParamUI";
this.mnuSalesSummary.Text = "&Transaction Summary";
this.mnuSalesSummary.Click += new System.EventHandler(this.mnuSalesSummary_Click);
// 
// toolStripMenuItem34
// 
this.toolStripMenuItem34.Name = "toolStripMenuItem34";
this.toolStripMenuItem34.Size = new System.Drawing.Size(227, 6);
// 
// cmuTransactionsPerCashier
// 
this.cmuTransactionsPerCashier.Name = "cmuTransactionsPerCashier";
this.cmuTransactionsPerCashier.Size = new System.Drawing.Size(230, 22);
this.cmuTransactionsPerCashier.Tag = "Jinisys.Hotel.Reports.Presentation.ReportDateParamUI";
this.cmuTransactionsPerCashier.Text = "Cashier Transactions Per Shift";
this.cmuTransactionsPerCashier.Visible = false;
this.cmuTransactionsPerCashier.Click += new System.EventHandler(this.cmuTransactionsPerCashier_Click);
// 
// toolStripMenuItem35
// 
this.toolStripMenuItem35.Name = "toolStripMenuItem35";
this.toolStripMenuItem35.Size = new System.Drawing.Size(227, 6);
this.toolStripMenuItem35.Visible = false;
// 
// mnuCityTransferTransactions
// 
this.mnuCityTransferTransactions.Name = "mnuCityTransferTransactions";
this.mnuCityTransferTransactions.Size = new System.Drawing.Size(230, 22);
this.mnuCityTransferTransactions.Tag = "Jinisys.Hotel.Reports.Presentation.ReportDateParamUI";
this.mnuCityTransferTransactions.Text = "City Transfer Transactions";
this.mnuCityTransferTransactions.Visible = false;
this.mnuCityTransferTransactions.Click += new System.EventHandler(this.mnucityTransferTransactions_Click);
// 
// mnuVoidedTransactions
// 
this.mnuVoidedTransactions.Name = "mnuVoidedTransactions";
this.mnuVoidedTransactions.Size = new System.Drawing.Size(230, 22);
this.mnuVoidedTransactions.Tag = "Jinisys.Hotel.Reports.Presentation.ReportDateParamUI";
this.mnuVoidedTransactions.Text = "Voided Transactions";
this.mnuVoidedTransactions.Visible = false;
this.mnuVoidedTransactions.Click += new System.EventHandler(this.mnuVoidedTransactions_Click);
// 
// toolStripMenuItem59
// 
this.toolStripMenuItem59.Name = "toolStripMenuItem59";
this.toolStripMenuItem59.Size = new System.Drawing.Size(227, 6);
this.toolStripMenuItem59.Visible = false;
// 
// mnuDailyHotelRevenueReport
// 
this.mnuDailyHotelRevenueReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
this.mnuDailyHotelRevenueReport.Name = "mnuDailyHotelRevenueReport";
this.mnuDailyHotelRevenueReport.Size = new System.Drawing.Size(230, 22);
this.mnuDailyHotelRevenueReport.Tag = "Jinisys.Hotel.Reports.Presentation.DailyHotelRevenueUI";
this.mnuDailyHotelRevenueReport.Text = "Daily Hotel Revenue Report";
this.mnuDailyHotelRevenueReport.Visible = false;
this.mnuDailyHotelRevenueReport.Click += new System.EventHandler(this.mnuDailyHotelRevenueReport_Click);
// 
// toolStripMenuItem21
// 
this.toolStripMenuItem21.Name = "toolStripMenuItem21";
this.toolStripMenuItem21.Size = new System.Drawing.Size(200, 6);
// 
// housekeepingToolStripMenuItem
// 
this.housekeepingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHouseKeepingReport,
            this.mnuHouseKeepingNew,
            this.mnuFloorOccupancy,
            this.toolStripMenuItem51,
            this.mnuMinibarSalesView,
            this.toolStripMenuItem52,
            this.mnuHousekeepingActivity,
            this.mnuHousekeepersReport,
            this.mnuHousekeepersSummary,
            this.toolStripMenuItem54,
            this.mnuMinibarSales,
            this.mnuMinibarSalesByRoom,
            this.mnuMinibarSalesByHousekeeper,
            this.mnuMinibarSalesByItemCategory,
            this.toolStripMenuItem55,
            this.mnuMinibarItemsList});
this.housekeepingToolStripMenuItem.Name = "housekeepingToolStripMenuItem";
this.housekeepingToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
this.housekeepingToolStripMenuItem.Text = "Housekeeping";
this.housekeepingToolStripMenuItem.Visible = false;
// 
// mnuHouseKeepingReport
// 
this.mnuHouseKeepingReport.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.applications_graphics16;
this.mnuHouseKeepingReport.Name = "mnuHouseKeepingReport";
this.mnuHouseKeepingReport.Size = new System.Drawing.Size(238, 22);
this.mnuHouseKeepingReport.Text = "Housekeeping Report";
this.mnuHouseKeepingReport.Click += new System.EventHandler(this.mnuHouseKeepingReport_Click);
// 
// mnuHouseKeepingNew
// 
this.mnuHouseKeepingNew.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.xxxx;
this.mnuHouseKeepingNew.Name = "mnuHouseKeepingNew";
this.mnuHouseKeepingNew.Size = new System.Drawing.Size(238, 22);
this.mnuHouseKeepingNew.Tag = "Jinisys.Hotel.Services.Presentation.HouseKeepingLogUI";
this.mnuHouseKeepingNew.Text = "Housekeeping Status";
this.mnuHouseKeepingNew.Click += new System.EventHandler(this.mnuHouseKeepingNew_Click);
// 
// mnuFloorOccupancy
// 
this.mnuFloorOccupancy.Image = ((System.Drawing.Image)(resources.GetObject("mnuFloorOccupancy.Image")));
this.mnuFloorOccupancy.Name = "mnuFloorOccupancy";
this.mnuFloorOccupancy.Size = new System.Drawing.Size(238, 22);
this.mnuFloorOccupancy.Tag = "Jinisys.Hotel.Reservation.Presentation.FloorOccupancyUI";
this.mnuFloorOccupancy.Text = "&Floor Occupancy";
this.mnuFloorOccupancy.Click += new System.EventHandler(this.mnuFloorOccupancy_Click);
// 
// toolStripMenuItem51
// 
this.toolStripMenuItem51.Name = "toolStripMenuItem51";
this.toolStripMenuItem51.Size = new System.Drawing.Size(235, 6);
// 
// mnuMinibarSalesView
// 
this.mnuMinibarSalesView.Name = "mnuMinibarSalesView";
this.mnuMinibarSalesView.Size = new System.Drawing.Size(238, 22);
this.mnuMinibarSalesView.Tag = "Jinisys.Hotel.Reservation.Presentation.MinibarSalesViewUI";
this.mnuMinibarSalesView.Text = "Minibar Sales View";
this.mnuMinibarSalesView.Click += new System.EventHandler(this.mnuMinibarSalesView_Click);
// 
// toolStripMenuItem52
// 
this.toolStripMenuItem52.Name = "toolStripMenuItem52";
this.toolStripMenuItem52.Size = new System.Drawing.Size(235, 6);
// 
// mnuHousekeepingActivity
// 
this.mnuHousekeepingActivity.Name = "mnuHousekeepingActivity";
this.mnuHousekeepingActivity.Size = new System.Drawing.Size(238, 22);
this.mnuHousekeepingActivity.Tag = "Jinisys.Housekeeping.Reports.Presentation.HKReportViewerUI";
this.mnuHousekeepingActivity.Text = "Housekeeping Activity";
this.mnuHousekeepingActivity.Click += new System.EventHandler(this.mnuHousekeepingActivity_Click);
// 
// mnuHousekeepersReport
// 
this.mnuHousekeepersReport.Name = "mnuHousekeepersReport";
this.mnuHousekeepersReport.Size = new System.Drawing.Size(238, 22);
this.mnuHousekeepersReport.Text = "Housekeepers Report";
this.mnuHousekeepersReport.Click += new System.EventHandler(this.mnuHousekeepersReport_Click);
// 
// mnuHousekeepersSummary
// 
this.mnuHousekeepersSummary.Name = "mnuHousekeepersSummary";
this.mnuHousekeepersSummary.Size = new System.Drawing.Size(238, 22);
this.mnuHousekeepersSummary.Text = "Housekeepers Summary";
this.mnuHousekeepersSummary.Click += new System.EventHandler(this.mnuHousekeepersSummary_Click);
// 
// toolStripMenuItem54
// 
this.toolStripMenuItem54.Name = "toolStripMenuItem54";
this.toolStripMenuItem54.Size = new System.Drawing.Size(235, 6);
// 
// mnuMinibarSales
// 
this.mnuMinibarSales.Name = "mnuMinibarSales";
this.mnuMinibarSales.Size = new System.Drawing.Size(238, 22);
this.mnuMinibarSales.Text = "Minibar Sales";
this.mnuMinibarSales.Click += new System.EventHandler(this.mnuMinibarSales_Click);
// 
// mnuMinibarSalesByRoom
// 
this.mnuMinibarSalesByRoom.Name = "mnuMinibarSalesByRoom";
this.mnuMinibarSalesByRoom.Size = new System.Drawing.Size(238, 22);
this.mnuMinibarSalesByRoom.Text = "Minibar Sales by Room";
this.mnuMinibarSalesByRoom.Click += new System.EventHandler(this.mnuMinibarSalesByRoom_Click);
// 
// mnuMinibarSalesByHousekeeper
// 
this.mnuMinibarSalesByHousekeeper.Name = "mnuMinibarSalesByHousekeeper";
this.mnuMinibarSalesByHousekeeper.Size = new System.Drawing.Size(238, 22);
this.mnuMinibarSalesByHousekeeper.Text = "Minibar Sales by Housekeeper";
this.mnuMinibarSalesByHousekeeper.Click += new System.EventHandler(this.mnuMinibarSalesByHousekeeper_Click);
// 
// mnuMinibarSalesByItemCategory
// 
this.mnuMinibarSalesByItemCategory.Name = "mnuMinibarSalesByItemCategory";
this.mnuMinibarSalesByItemCategory.Size = new System.Drawing.Size(238, 22);
this.mnuMinibarSalesByItemCategory.Text = "Minibar Sales by Item Category";
this.mnuMinibarSalesByItemCategory.Click += new System.EventHandler(this.mnuMinibarSalesByItemCategory_Click);
// 
// toolStripMenuItem55
// 
this.toolStripMenuItem55.Name = "toolStripMenuItem55";
this.toolStripMenuItem55.Size = new System.Drawing.Size(235, 6);
// 
// mnuMinibarItemsList
// 
this.mnuMinibarItemsList.Name = "mnuMinibarItemsList";
this.mnuMinibarItemsList.Size = new System.Drawing.Size(238, 22);
this.mnuMinibarItemsList.Text = "Minibar Items";
this.mnuMinibarItemsList.Click += new System.EventHandler(this.mnuMinibarItemsList_Click);
// 
// toolStripSeparator16
// 
this.toolStripSeparator16.Name = "toolStripSeparator16";
this.toolStripSeparator16.Size = new System.Drawing.Size(200, 6);
this.toolStripSeparator16.Visible = false;
// 
// mnuRestaurant
// 
this.mnuRestaurant.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMealRequirements});
this.mnuRestaurant.Name = "mnuRestaurant";
this.mnuRestaurant.Size = new System.Drawing.Size(203, 22);
this.mnuRestaurant.Text = "Restaurant";
this.mnuRestaurant.Visible = false;
// 
// mnuMealRequirements
// 
this.mnuMealRequirements.Name = "mnuMealRequirements";
this.mnuMealRequirements.Size = new System.Drawing.Size(176, 22);
this.mnuMealRequirements.Tag = "Jinisys.Hotel.Reports.Presentation.MealRequirements";
this.mnuMealRequirements.Text = "Meal Requirements";
this.mnuMealRequirements.Click += new System.EventHandler(this.mnuMealRequirements_Click);
// 
// toolStripMenuItem8
// 
this.toolStripMenuItem8.Name = "toolStripMenuItem8";
this.toolStripMenuItem8.Size = new System.Drawing.Size(200, 6);
this.toolStripMenuItem8.Visible = false;
// 
// mnuOccupancyForecast
// 
this.mnuOccupancyForecast.Name = "mnuOccupancyForecast";
this.mnuOccupancyForecast.Size = new System.Drawing.Size(203, 22);
this.mnuOccupancyForecast.Tag = "Jinisys.Hotel.Reports.Presentation.OccupancyForecastUI";
this.mnuOccupancyForecast.Text = "Room Occupancy Trend";
this.mnuOccupancyForecast.Visible = false;
this.mnuOccupancyForecast.Click += new System.EventHandler(this.mnuOccupancyForecast_Click);
// 
// toolStripMenuItem40
// 
this.toolStripMenuItem40.Name = "toolStripMenuItem40";
this.toolStripMenuItem40.Size = new System.Drawing.Size(200, 6);
this.toolStripMenuItem40.Visible = false;
// 
// cityLedgerToolStripMenuItem
// 
this.cityLedgerToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.anotacoes;
this.cityLedgerToolStripMenuItem.Name = "cityLedgerToolStripMenuItem";
this.cityLedgerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
this.cityLedgerToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.ReportDateParamUI";
this.cityLedgerToolStripMenuItem.Text = "City Ledger";
this.cityLedgerToolStripMenuItem.Visible = false;
this.cityLedgerToolStripMenuItem.Click += new System.EventHandler(this.cityLedgerToolStripMenuItem_Click);
// 
// tsmTools
// 
this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculatorToolStripMenuItem,
            this.notepadToolStripMenuItem,
            this.toolStripMenuItem15,
            this.mnuReportGenerator,
            this.toolStripMenuItem28,
            this.backupDatabaseToolStripMenuItem,
            this.captureImageToolStripMenuItem,
            this.toolStripMenuItem13,
            this.logsToolStripMenuItem,
            this.toolStripMenuItem42,
            this.mnuAccountingInterface,
            this.mnuPostToAccounting,
            this.mnuAccountingAdjustment,
            this.toolStripMenuItem43,
            this.mnuTranCodeGLSetup,
            this.synchronizeSAPToolStripMenuItem,
            this.accountingIntegrationSetupToolStripMenuItem});
this.tsmTools.Name = "tsmTools";
this.tsmTools.Size = new System.Drawing.Size(48, 20);
this.tsmTools.Text = "&Tools";
// 
// calculatorToolStripMenuItem
// 
this.calculatorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("calculatorToolStripMenuItem.Image")));
this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.calculatorToolStripMenuItem.Text = "&Calculator";
this.calculatorToolStripMenuItem.Visible = false;
this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.calculatorToolStripMenuItem_Click);
// 
// notepadToolStripMenuItem
// 
this.notepadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("notepadToolStripMenuItem.Image")));
this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
this.notepadToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.notepadToolStripMenuItem.Text = "&Notepad";
this.notepadToolStripMenuItem.Visible = false;
this.notepadToolStripMenuItem.Click += new System.EventHandler(this.notepadToolStripMenuItem_Click);
// 
// toolStripMenuItem15
// 
this.toolStripMenuItem15.Name = "toolStripMenuItem15";
this.toolStripMenuItem15.Size = new System.Drawing.Size(270, 6);
this.toolStripMenuItem15.Visible = false;
// 
// mnuReportGenerator
// 
this.mnuReportGenerator.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Printer;
this.mnuReportGenerator.Name = "mnuReportGenerator";
this.mnuReportGenerator.Size = new System.Drawing.Size(273, 22);
this.mnuReportGenerator.Tag = "Jinisys.Hotel.Reports.Presentation.ReportGeneratorUI";
this.mnuReportGenerator.Text = "&Report Generator";
this.mnuReportGenerator.Click += new System.EventHandler(this.mnuUtilitiesReportGenerator_Click);
// 
// toolStripMenuItem28
// 
this.toolStripMenuItem28.Name = "toolStripMenuItem28";
this.toolStripMenuItem28.Size = new System.Drawing.Size(270, 6);
// 
// backupDatabaseToolStripMenuItem
// 
this.backupDatabaseToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.uploads_folder;
this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.backupDatabaseToolStripMenuItem.Tag = "Jinisys.Hotel.Utilities.Presentation.BackUpUI";
this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
// 
// captureImageToolStripMenuItem
// 
this.captureImageToolStripMenuItem.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.folder_music;
this.captureImageToolStripMenuItem.Name = "captureImageToolStripMenuItem";
this.captureImageToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.captureImageToolStripMenuItem.Tag = "Jinisys.Hotel.Utilities.Presentation.CaptureImageUI";
this.captureImageToolStripMenuItem.Text = "Capture Image";
this.captureImageToolStripMenuItem.Visible = false;
this.captureImageToolStripMenuItem.Click += new System.EventHandler(this.captureImageToolStripMenuItem_Click);
// 
// toolStripMenuItem13
// 
this.toolStripMenuItem13.Name = "toolStripMenuItem13";
this.toolStripMenuItem13.Size = new System.Drawing.Size(270, 6);
this.toolStripMenuItem13.Visible = false;
// 
// logsToolStripMenuItem
// 
this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
this.logsToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.logsToolStripMenuItem.Tag = "Jinisys.Hotel.Reports.Presentation.ChangeLogUI";
this.logsToolStripMenuItem.Text = "Logs";
this.logsToolStripMenuItem.Visible = false;
this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
// 
// toolStripMenuItem42
// 
this.toolStripMenuItem42.Name = "toolStripMenuItem42";
this.toolStripMenuItem42.Size = new System.Drawing.Size(270, 6);
// 
// mnuAccountingInterface
// 
this.mnuAccountingInterface.Name = "mnuAccountingInterface";
this.mnuAccountingInterface.Size = new System.Drawing.Size(273, 22);
this.mnuAccountingInterface.Text = "Accounting Interface";
this.mnuAccountingInterface.Click += new System.EventHandler(this.mnuAccountingInterface_Click);
// 
// mnuPostToAccounting
// 
this.mnuPostToAccounting.Name = "mnuPostToAccounting";
this.mnuPostToAccounting.Size = new System.Drawing.Size(273, 22);
this.mnuPostToAccounting.Text = "Post to Accounting";
this.mnuPostToAccounting.Click += new System.EventHandler(this.mnuPostToAccounting_Click);
// 
// mnuAccountingAdjustment
// 
this.mnuAccountingAdjustment.Name = "mnuAccountingAdjustment";
this.mnuAccountingAdjustment.Size = new System.Drawing.Size(273, 22);
this.mnuAccountingAdjustment.Tag = "Jinisys.Hotel.Cashier.Presentation.AccountingAdjustmentPostUI";
this.mnuAccountingAdjustment.Text = "Accounting Adjustments";
this.mnuAccountingAdjustment.Visible = false;
this.mnuAccountingAdjustment.Click += new System.EventHandler(this.mnuAccountingAdjustment_Click);
// 
// toolStripMenuItem43
// 
this.toolStripMenuItem43.Name = "toolStripMenuItem43";
this.toolStripMenuItem43.Size = new System.Drawing.Size(270, 6);
// 
// mnuTranCodeGLSetup
// 
this.mnuTranCodeGLSetup.Name = "mnuTranCodeGLSetup";
this.mnuTranCodeGLSetup.Size = new System.Drawing.Size(273, 22);
this.mnuTranCodeGLSetup.Tag = "Jinisys.Hotel.AccountingInterface.Presentation.TranCode_GLAccountSetup";
this.mnuTranCodeGLSetup.Text = "Transaction Code - GL Account Setup";
this.mnuTranCodeGLSetup.Click += new System.EventHandler(this.mnuTranCodeGLSetup_Click);
// 
// synchronizeSAPToolStripMenuItem
// 
this.synchronizeSAPToolStripMenuItem.Name = "synchronizeSAPToolStripMenuItem";
this.synchronizeSAPToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.synchronizeSAPToolStripMenuItem.Tag = "Integrations.Presentation.SyncSAP";
this.synchronizeSAPToolStripMenuItem.Text = "Synchronize SAP";
this.synchronizeSAPToolStripMenuItem.Click += new System.EventHandler(this.synchronizeSAPToolStripMenuItem_Click);
// 
// accountingIntegrationSetupToolStripMenuItem
// 
this.accountingIntegrationSetupToolStripMenuItem.Name = "accountingIntegrationSetupToolStripMenuItem";
this.accountingIntegrationSetupToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
this.accountingIntegrationSetupToolStripMenuItem.Text = "Accounting Integration Setup";
this.accountingIntegrationSetupToolStripMenuItem.Click += new System.EventHandler(this.accountingIntegrationSetupToolStripMenuItem_Click);
// 
// tsmWindow
// 
this.tsmWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.toolStripMenuItem16,
            this.closeAllWindowToolStripMenuItem});
this.tsmWindow.Name = "tsmWindow";
this.tsmWindow.Size = new System.Drawing.Size(63, 20);
this.tsmWindow.Text = "&Window";
// 
// tileHorizontalToolStripMenuItem
// 
this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
// 
// tileVerticalToolStripMenuItem
// 
this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.mnuTileVertical_Click);
// 
// cascadeToolStripMenuItem
// 
this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
this.cascadeToolStripMenuItem.Text = "&Cascade";
this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.mnuCascade_Click);
// 
// toolStripMenuItem16
// 
this.toolStripMenuItem16.Name = "toolStripMenuItem16";
this.toolStripMenuItem16.Size = new System.Drawing.Size(164, 6);
// 
// closeAllWindowToolStripMenuItem
// 
this.closeAllWindowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeAllWindowToolStripMenuItem.Image")));
this.closeAllWindowToolStripMenuItem.Name = "closeAllWindowToolStripMenuItem";
this.closeAllWindowToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
this.closeAllWindowToolStripMenuItem.Text = "Close &All Window";
this.closeAllWindowToolStripMenuItem.Click += new System.EventHandler(this.closeAllWindowToolStripMenuItem_Click);
// 
// tsmHelp
// 
this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.folioUserGuideToolStripMenuItem});
this.tsmHelp.Name = "tsmHelp";
this.tsmHelp.Size = new System.Drawing.Size(44, 20);
this.tsmHelp.Text = "&Help";
// 
// aboutToolStripMenuItem
// 
this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
this.aboutToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
this.aboutToolStripMenuItem.Text = "&About";
this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
// 
// folioUserGuideToolStripMenuItem
// 
this.folioUserGuideToolStripMenuItem.Name = "folioUserGuideToolStripMenuItem";
this.folioUserGuideToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
this.folioUserGuideToolStripMenuItem.Text = "Folio User Guide";
this.folioUserGuideToolStripMenuItem.Click += new System.EventHandler(this.folioUserGuideToolStripMenuItem_Click);
// 
// flpSidePanel
// 
this.flpSidePanel.BackColor = System.Drawing.SystemColors.Control;
this.flpSidePanel.Controls.Add(this.pictHotelLogo);
this.flpSidePanel.Controls.Add(this.Label6);
this.flpSidePanel.Controls.Add(this.tabRooms);
this.flpSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
this.flpSidePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
this.flpSidePanel.Location = new System.Drawing.Point(0, 49);
this.flpSidePanel.Margin = new System.Windows.Forms.Padding(4);
this.flpSidePanel.Name = "flpSidePanel";
this.flpSidePanel.Size = new System.Drawing.Size(162, 675);
this.flpSidePanel.TabIndex = 25;
this.flpSidePanel.WrapContents = false;
// 
// pictHotelLogo
// 
this.pictHotelLogo.Location = new System.Drawing.Point(3, 3);
this.pictHotelLogo.Name = "pictHotelLogo";
this.pictHotelLogo.Size = new System.Drawing.Size(159, 106);
this.pictHotelLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
this.pictHotelLogo.TabIndex = 7;
this.pictHotelLogo.TabStop = false;
// 
// tabRooms
// 
this.tabRooms.Controls.Add(this.tabPage1);
this.tabRooms.Controls.Add(this.tabPage2);
this.tabRooms.Location = new System.Drawing.Point(3, 135);
this.tabRooms.Name = "tabRooms";
this.tabRooms.SelectedIndex = 0;
this.tabRooms.Size = new System.Drawing.Size(159, 600);
this.tabRooms.TabIndex = 14;
// 
// tabPage1
// 
this.tabPage1.Controls.Add(this.flpRooms);
this.tabPage1.Location = new System.Drawing.Point(4, 23);
this.tabPage1.Name = "tabPage1";
this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
this.tabPage1.Size = new System.Drawing.Size(151, 573);
this.tabPage1.TabIndex = 0;
this.tabPage1.Text = "Rooms";
this.tabPage1.UseVisualStyleBackColor = true;
// 
// flpRooms
// 
this.flpRooms.Controls.Add(this.pnlRooms);
this.flpRooms.Controls.Add(this.pnlLegend);
this.flpRooms.Controls.Add(this.grbOccupancy);
this.flpRooms.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
this.flpRooms.Location = new System.Drawing.Point(-2, 3);
this.flpRooms.Name = "flpRooms";
this.flpRooms.Size = new System.Drawing.Size(152, 567);
this.flpRooms.TabIndex = 14;
this.flpRooms.WrapContents = false;
// 
// pnlRooms
// 
this.pnlRooms.Controls.Add(this.vsDayPlo);
this.pnlRooms.Location = new System.Drawing.Point(3, 3);
this.pnlRooms.Name = "pnlRooms";
this.pnlRooms.Size = new System.Drawing.Size(151, 305);
this.pnlRooms.TabIndex = 13;
// 
// pnlLegend
// 
this.pnlLegend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.pnlLegend.Controls.Add(this.lblTotalInHouse);
this.pnlLegend.Controls.Add(this.label2);
this.pnlLegend.Controls.Add(this.lblTotalRooms);
this.pnlLegend.Controls.Add(this.lblOutOfOrderRooms);
this.pnlLegend.Controls.Add(this.lblBlockedRooms);
this.pnlLegend.Controls.Add(this.lblReservedRooms);
this.pnlLegend.Controls.Add(this.lblOccupiedCleanRoom);
this.pnlLegend.Controls.Add(this.lblVacantDirtyRoom);
this.pnlLegend.Controls.Add(this.lblOccupiedDirtyRoom);
this.pnlLegend.Controls.Add(this.lbl0);
this.pnlLegend.Controls.Add(this.lblVacantCleanRoom);
this.pnlLegend.Controls.Add(this.lbl6);
this.pnlLegend.Controls.Add(this.lbl1);
this.pnlLegend.Controls.Add(this.lbl2);
this.pnlLegend.Controls.Add(this.lblReservedRoomColor);
this.pnlLegend.Controls.Add(this.lbl5);
this.pnlLegend.Controls.Add(this.lbl4);
this.pnlLegend.Controls.Add(this.lbl3);
this.pnlLegend.Location = new System.Drawing.Point(3, 314);
this.pnlLegend.Name = "pnlLegend";
this.pnlLegend.Size = new System.Drawing.Size(147, 107);
this.pnlLegend.TabIndex = 9;
// 
// lblTotalInHouse
// 
this.lblTotalInHouse.AutoEllipsis = true;
this.lblTotalInHouse.BackColor = System.Drawing.Color.White;
this.lblTotalInHouse.Location = new System.Drawing.Point(112, 86);
this.lblTotalInHouse.Name = "lblTotalInHouse";
this.lblTotalInHouse.Size = new System.Drawing.Size(31, 14);
this.lblTotalInHouse.TabIndex = 30;
this.lblTotalInHouse.Text = " 00";
this.lblTotalInHouse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// label2
// 
this.label2.AutoEllipsis = true;
this.label2.BackColor = System.Drawing.Color.White;
this.label2.Location = new System.Drawing.Point(-2, 86);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(161, 14);
this.label2.TabIndex = 29;
this.label2.Text = "Total In House Guests";
this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.label2.Visible = false;
// 
// lblTotalRooms
// 
this.lblTotalRooms.AutoEllipsis = true;
this.lblTotalRooms.BackColor = System.Drawing.Color.White;
this.lblTotalRooms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblTotalRooms.Location = new System.Drawing.Point(121, 72);
this.lblTotalRooms.Name = "lblTotalRooms";
this.lblTotalRooms.Size = new System.Drawing.Size(22, 13);
this.lblTotalRooms.TabIndex = 28;
this.lblTotalRooms.Text = " 00";
this.lblTotalRooms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblOutOfOrderRooms
// 
this.lblOutOfOrderRooms.AutoEllipsis = true;
this.lblOutOfOrderRooms.BackColor = System.Drawing.Color.GreenYellow;
this.lblOutOfOrderRooms.Location = new System.Drawing.Point(121, 45);
this.lblOutOfOrderRooms.Name = "lblOutOfOrderRooms";
this.lblOutOfOrderRooms.Size = new System.Drawing.Size(22, 14);
this.lblOutOfOrderRooms.TabIndex = 27;
this.lblOutOfOrderRooms.Text = " 00";
this.lblOutOfOrderRooms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblBlockedRooms
// 
this.lblBlockedRooms.AutoEllipsis = true;
this.lblBlockedRooms.BackColor = System.Drawing.Color.Brown;
this.lblBlockedRooms.ForeColor = System.Drawing.Color.White;
this.lblBlockedRooms.Location = new System.Drawing.Point(52, 72);
this.lblBlockedRooms.Name = "lblBlockedRooms";
this.lblBlockedRooms.Size = new System.Drawing.Size(22, 14);
this.lblBlockedRooms.TabIndex = 26;
this.lblBlockedRooms.Text = " 00";
this.lblBlockedRooms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
this.lblBlockedRooms.Visible = false;
// 
// lblReservedRooms
// 
this.lblReservedRooms.AutoEllipsis = true;
this.lblReservedRooms.BackColor = System.Drawing.Color.DodgerBlue;
this.lblReservedRooms.Location = new System.Drawing.Point(88, 16);
this.lblReservedRooms.Name = "lblReservedRooms";
this.lblReservedRooms.Size = new System.Drawing.Size(55, 13);
this.lblReservedRooms.TabIndex = 25;
this.lblReservedRooms.Text = " 00";
this.lblReservedRooms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblOccupiedCleanRoom
// 
this.lblOccupiedCleanRoom.AutoEllipsis = true;
this.lblOccupiedCleanRoom.BackColor = System.Drawing.Color.Aqua;
this.lblOccupiedCleanRoom.Location = new System.Drawing.Point(99, 29);
this.lblOccupiedCleanRoom.Name = "lblOccupiedCleanRoom";
this.lblOccupiedCleanRoom.Size = new System.Drawing.Size(44, 14);
this.lblOccupiedCleanRoom.TabIndex = 23;
this.lblOccupiedCleanRoom.Text = " 00";
this.lblOccupiedCleanRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblVacantDirtyRoom
// 
this.lblVacantDirtyRoom.AutoEllipsis = true;
this.lblVacantDirtyRoom.BackColor = System.Drawing.Color.Red;
this.lblVacantDirtyRoom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblVacantDirtyRoom.ForeColor = System.Drawing.Color.White;
this.lblVacantDirtyRoom.Location = new System.Drawing.Point(99, 59);
this.lblVacantDirtyRoom.Name = "lblVacantDirtyRoom";
this.lblVacantDirtyRoom.Size = new System.Drawing.Size(44, 14);
this.lblVacantDirtyRoom.TabIndex = 20;
this.lblVacantDirtyRoom.Text = "00";
this.lblVacantDirtyRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
this.lblVacantDirtyRoom.Visible = false;
// 
// lblOccupiedDirtyRoom
// 
this.lblOccupiedDirtyRoom.AutoEllipsis = true;
this.lblOccupiedDirtyRoom.BackColor = System.Drawing.Color.Gold;
this.lblOccupiedDirtyRoom.Location = new System.Drawing.Point(99, 29);
this.lblOccupiedDirtyRoom.Name = "lblOccupiedDirtyRoom";
this.lblOccupiedDirtyRoom.Size = new System.Drawing.Size(44, 14);
this.lblOccupiedDirtyRoom.TabIndex = 22;
this.lblOccupiedDirtyRoom.Text = "00";
this.lblOccupiedDirtyRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblVacantCleanRoom
// 
this.lblVacantCleanRoom.AutoEllipsis = true;
this.lblVacantCleanRoom.BackColor = System.Drawing.Color.White;
this.lblVacantCleanRoom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblVacantCleanRoom.ForeColor = System.Drawing.Color.Black;
this.lblVacantCleanRoom.Location = new System.Drawing.Point(99, 2);
this.lblVacantCleanRoom.Name = "lblVacantCleanRoom";
this.lblVacantCleanRoom.Size = new System.Drawing.Size(44, 14);
this.lblVacantCleanRoom.TabIndex = 21;
this.lblVacantCleanRoom.Text = "00";
this.lblVacantCleanRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lbl1
// 
this.lbl1.AutoEllipsis = true;
this.lbl1.BackColor = System.Drawing.Color.White;
this.lbl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lbl1.ForeColor = System.Drawing.Color.Black;
this.lbl1.Location = new System.Drawing.Point(74, 72);
this.lbl1.Name = "lbl1";
this.lbl1.Size = new System.Drawing.Size(85, 14);
this.lbl1.TabIndex = 18;
this.lbl1.Text = " Total :";
this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.lbl1.Visible = false;
// 
// lbl3
// 
this.lbl3.AutoEllipsis = true;
this.lbl3.BackColor = System.Drawing.Color.Gold;
this.lbl3.Location = new System.Drawing.Point(-2, 29);
this.lbl3.Name = "lbl3";
this.lbl3.Size = new System.Drawing.Size(161, 14);
this.lbl3.TabIndex = 19;
this.lbl3.Text = " Occupied - Dirty";
this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.lbl3.Visible = false;
// 
// tabPage2
// 
this.tabPage2.Controls.Add(this.flpFunctions);
this.tabPage2.Location = new System.Drawing.Point(4, 23);
this.tabPage2.Name = "tabPage2";
this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
this.tabPage2.Size = new System.Drawing.Size(151, 573);
this.tabPage2.TabIndex = 1;
this.tabPage2.Text = "Venue";
this.tabPage2.UseVisualStyleBackColor = true;
// 
// flpFunctions
// 
this.flpFunctions.Controls.Add(this.pnlFunction);
this.flpFunctions.Controls.Add(this.panel3);
this.flpFunctions.Controls.Add(this.groupBox1);
this.flpFunctions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
this.flpFunctions.Location = new System.Drawing.Point(-3, -1);
this.flpFunctions.Name = "flpFunctions";
this.flpFunctions.Size = new System.Drawing.Size(156, 519);
this.flpFunctions.TabIndex = 15;
this.flpFunctions.WrapContents = false;
// 
// pnlFunction
// 
this.pnlFunction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.pnlFunction.Controls.Add(this.gridFunctions);
this.pnlFunction.Location = new System.Drawing.Point(3, 3);
this.pnlFunction.Name = "pnlFunction";
this.pnlFunction.Size = new System.Drawing.Size(152, 305);
this.pnlFunction.TabIndex = 13;
// 
// panel3
// 
this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.panel3.Controls.Add(this.lblTotalFunctions);
this.panel3.Controls.Add(this.lblOutOfOrderFunction);
this.panel3.Controls.Add(this.lblBlockedFunction);
this.panel3.Controls.Add(this.lblReservedFunction);
this.panel3.Controls.Add(this.lblOccupiedCleanFunction);
this.panel3.Controls.Add(this.lblVacantCleanFunction);
this.panel3.Controls.Add(this.lblVacantDirtyFunction);
this.panel3.Controls.Add(this.label10);
this.panel3.Controls.Add(this.label12);
this.panel3.Controls.Add(this.label13);
this.panel3.Controls.Add(this.label14);
this.panel3.Controls.Add(this.label15);
this.panel3.Controls.Add(this.label16);
this.panel3.Controls.Add(this.label17);
this.panel3.Controls.Add(this.label11);
this.panel3.Controls.Add(this.lblOccupiedDirtyFunction);
this.panel3.Location = new System.Drawing.Point(3, 314);
this.panel3.Name = "panel3";
this.panel3.Size = new System.Drawing.Size(151, 93);
this.panel3.TabIndex = 9;
// 
// lblTotalFunctions
// 
this.lblTotalFunctions.AutoEllipsis = true;
this.lblTotalFunctions.BackColor = System.Drawing.Color.White;
this.lblTotalFunctions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblTotalFunctions.Location = new System.Drawing.Point(121, 72);
this.lblTotalFunctions.Name = "lblTotalFunctions";
this.lblTotalFunctions.Size = new System.Drawing.Size(22, 18);
this.lblTotalFunctions.TabIndex = 32;
this.lblTotalFunctions.Text = " 00";
this.lblTotalFunctions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblOutOfOrderFunction
// 
this.lblOutOfOrderFunction.AutoEllipsis = true;
this.lblOutOfOrderFunction.BackColor = System.Drawing.Color.GreenYellow;
this.lblOutOfOrderFunction.Location = new System.Drawing.Point(121, 54);
this.lblOutOfOrderFunction.Name = "lblOutOfOrderFunction";
this.lblOutOfOrderFunction.Size = new System.Drawing.Size(22, 18);
this.lblOutOfOrderFunction.TabIndex = 31;
this.lblOutOfOrderFunction.Text = " 00";
this.lblOutOfOrderFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblBlockedFunction
// 
this.lblBlockedFunction.AutoEllipsis = true;
this.lblBlockedFunction.BackColor = System.Drawing.Color.Brown;
this.lblBlockedFunction.ForeColor = System.Drawing.Color.White;
this.lblBlockedFunction.Location = new System.Drawing.Point(52, 90);
this.lblBlockedFunction.Name = "lblBlockedFunction";
this.lblBlockedFunction.Size = new System.Drawing.Size(22, 18);
this.lblBlockedFunction.TabIndex = 30;
this.lblBlockedFunction.Text = " 00";
this.lblBlockedFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
this.lblBlockedFunction.Visible = false;
// 
// lblReservedFunction
// 
this.lblReservedFunction.AutoEllipsis = true;
this.lblReservedFunction.BackColor = System.Drawing.Color.DodgerBlue;
this.lblReservedFunction.Location = new System.Drawing.Point(97, 36);
this.lblReservedFunction.Name = "lblReservedFunction";
this.lblReservedFunction.Size = new System.Drawing.Size(46, 18);
this.lblReservedFunction.TabIndex = 29;
this.lblReservedFunction.Text = " 00";
this.lblReservedFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblOccupiedCleanFunction
// 
this.lblOccupiedCleanFunction.AutoEllipsis = true;
this.lblOccupiedCleanFunction.BackColor = System.Drawing.Color.Aqua;
this.lblOccupiedCleanFunction.Location = new System.Drawing.Point(99, 18);
this.lblOccupiedCleanFunction.Name = "lblOccupiedCleanFunction";
this.lblOccupiedCleanFunction.Size = new System.Drawing.Size(44, 18);
this.lblOccupiedCleanFunction.TabIndex = 23;
this.lblOccupiedCleanFunction.Text = " 00";
this.lblOccupiedCleanFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblVacantCleanFunction
// 
this.lblVacantCleanFunction.AutoEllipsis = true;
this.lblVacantCleanFunction.BackColor = System.Drawing.Color.White;
this.lblVacantCleanFunction.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblVacantCleanFunction.ForeColor = System.Drawing.Color.Black;
this.lblVacantCleanFunction.Location = new System.Drawing.Point(99, 0);
this.lblVacantCleanFunction.Name = "lblVacantCleanFunction";
this.lblVacantCleanFunction.Size = new System.Drawing.Size(44, 18);
this.lblVacantCleanFunction.TabIndex = 21;
this.lblVacantCleanFunction.Text = "00";
this.lblVacantCleanFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblVacantDirtyFunction
// 
this.lblVacantDirtyFunction.AutoEllipsis = true;
this.lblVacantDirtyFunction.BackColor = System.Drawing.Color.Red;
this.lblVacantDirtyFunction.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblVacantDirtyFunction.ForeColor = System.Drawing.Color.White;
this.lblVacantDirtyFunction.Location = new System.Drawing.Point(99, 0);
this.lblVacantDirtyFunction.Name = "lblVacantDirtyFunction";
this.lblVacantDirtyFunction.Size = new System.Drawing.Size(44, 18);
this.lblVacantDirtyFunction.TabIndex = 20;
this.lblVacantDirtyFunction.Text = "00";
this.lblVacantDirtyFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
this.lblVacantDirtyFunction.Visible = false;
// 
// label10
// 
this.label10.AutoEllipsis = true;
this.label10.BackColor = System.Drawing.Color.GreenYellow;
this.label10.Location = new System.Drawing.Point(0, 54);
this.label10.Name = "label10";
this.label10.Size = new System.Drawing.Size(148, 18);
this.label10.TabIndex = 13;
this.label10.Text = " OOO";
this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label12
// 
this.label12.AutoEllipsis = true;
this.label12.BackColor = System.Drawing.Color.White;
this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label12.ForeColor = System.Drawing.Color.Black;
this.label12.Location = new System.Drawing.Point(1, 72);
this.label12.Name = "label12";
this.label12.Size = new System.Drawing.Size(147, 18);
this.label12.TabIndex = 18;
this.label12.Text = "Total :";
this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label13
// 
this.label13.AutoEllipsis = true;
this.label13.BackColor = System.Drawing.Color.White;
this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label13.ForeColor = System.Drawing.Color.Black;
this.label13.Location = new System.Drawing.Point(0, 0);
this.label13.Name = "label13";
this.label13.Size = new System.Drawing.Size(159, 18);
this.label13.TabIndex = 17;
this.label13.Text = " Vacant";
this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label14
// 
this.label14.AutoEllipsis = true;
this.label14.BackColor = System.Drawing.Color.Red;
this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label14.ForeColor = System.Drawing.Color.White;
this.label14.Location = new System.Drawing.Point(0, 0);
this.label14.Name = "label14";
this.label14.Size = new System.Drawing.Size(159, 18);
this.label14.TabIndex = 16;
this.label14.Text = " Vacant - Dirty";
this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.label14.Visible = false;
// 
// label15
// 
this.label15.AutoEllipsis = true;
this.label15.BackColor = System.Drawing.Color.DodgerBlue;
this.label15.Location = new System.Drawing.Point(0, 36);
this.label15.Name = "label15";
this.label15.Size = new System.Drawing.Size(150, 18);
this.label15.TabIndex = 15;
this.label15.Text = " Reserved";
this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label16
// 
this.label16.AutoEllipsis = true;
this.label16.BackColor = System.Drawing.Color.Brown;
this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
this.label16.Location = new System.Drawing.Point(0, 90);
this.label16.Name = "label16";
this.label16.Size = new System.Drawing.Size(76, 18);
this.label16.TabIndex = 12;
this.label16.Text = " Blocked";
this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.label16.Visible = false;
// 
// label17
// 
this.label17.AutoEllipsis = true;
this.label17.BackColor = System.Drawing.Color.Aqua;
this.label17.Location = new System.Drawing.Point(-2, 18);
this.label17.Name = "label17";
this.label17.Size = new System.Drawing.Size(161, 18);
this.label17.TabIndex = 14;
this.label17.Text = " Occupied";
this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label11
// 
this.label11.AutoEllipsis = true;
this.label11.BackColor = System.Drawing.Color.Gold;
this.label11.Location = new System.Drawing.Point(-2, 36);
this.label11.Name = "label11";
this.label11.Size = new System.Drawing.Size(161, 18);
this.label11.TabIndex = 19;
this.label11.Text = " Occupied - Dirty";
this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.label11.Visible = false;
// 
// lblOccupiedDirtyFunction
// 
this.lblOccupiedDirtyFunction.AutoEllipsis = true;
this.lblOccupiedDirtyFunction.BackColor = System.Drawing.Color.Gold;
this.lblOccupiedDirtyFunction.Location = new System.Drawing.Point(99, 36);
this.lblOccupiedDirtyFunction.Name = "lblOccupiedDirtyFunction";
this.lblOccupiedDirtyFunction.Size = new System.Drawing.Size(44, 18);
this.lblOccupiedDirtyFunction.TabIndex = 22;
this.lblOccupiedDirtyFunction.Text = "00";
this.lblOccupiedDirtyFunction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
this.lblOccupiedDirtyFunction.Visible = false;
// 
// groupBox1
// 
this.groupBox1.Controls.Add(this.lblCurrentDayFunctionRoomOccupancy);
this.groupBox1.Controls.Add(this.lblYesterDayFunctionRoomOccupancy);
this.groupBox1.Controls.Add(this.label3);
this.groupBox1.Controls.Add(this.label4);
this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.groupBox1.Location = new System.Drawing.Point(3, 413);
this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new System.Drawing.Size(151, 75);
this.groupBox1.TabIndex = 5;
this.groupBox1.TabStop = false;
this.groupBox1.Text = "Occupancy Rate";
this.groupBox1.Visible = false;
// 
// lblCurrentDayFunctionRoomOccupancy
// 
this.lblCurrentDayFunctionRoomOccupancy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.lblCurrentDayFunctionRoomOccupancy.Location = new System.Drawing.Point(89, 23);
this.lblCurrentDayFunctionRoomOccupancy.Name = "lblCurrentDayFunctionRoomOccupancy";
this.lblCurrentDayFunctionRoomOccupancy.Size = new System.Drawing.Size(57, 17);
this.lblCurrentDayFunctionRoomOccupancy.TabIndex = 14;
this.lblCurrentDayFunctionRoomOccupancy.Text = "00.00 %";
this.lblCurrentDayFunctionRoomOccupancy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// lblYesterDayFunctionRoomOccupancy
// 
this.lblYesterDayFunctionRoomOccupancy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.lblYesterDayFunctionRoomOccupancy.Location = new System.Drawing.Point(89, 47);
this.lblYesterDayFunctionRoomOccupancy.Name = "lblYesterDayFunctionRoomOccupancy";
this.lblYesterDayFunctionRoomOccupancy.Size = new System.Drawing.Size(57, 17);
this.lblYesterDayFunctionRoomOccupancy.TabIndex = 15;
this.lblYesterDayFunctionRoomOccupancy.Text = "00.00 %";
this.lblYesterDayFunctionRoomOccupancy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// label3
// 
this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label3.Location = new System.Drawing.Point(11, 23);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(48, 17);
this.label3.TabIndex = 11;
this.label3.Text = "Today:";
this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label4
// 
this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label4.Location = new System.Drawing.Point(11, 46);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(67, 18);
this.label4.TabIndex = 13;
this.label4.Text = "Yesterday:";
this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// toolStripButton1
// 
this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton1.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.New;
this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton1.Name = "toolStripButton1";
this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
this.toolStripButton1.Text = "toolStripButton1";
// 
// toolStripButton2
// 
this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton2.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Open;
this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton2.Name = "toolStripButton2";
this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
this.toolStripButton2.Text = "toolStripButton2";
// 
// toolStripButton3
// 
this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton3.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Save;
this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton3.Name = "toolStripButton3";
this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
this.toolStripButton3.Text = "toolStripButton3";
// 
// toolStripButton4
// 
this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton4.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Print;
this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton4.Name = "toolStripButton4";
this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
this.toolStripButton4.Text = "toolStripButton4";
// 
// toolStripButton5
// 
this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton5.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Preview;
this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton5.Name = "toolStripButton5";
this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
this.toolStripButton5.Text = "toolStripButton5";
// 
// toolStripButton6
// 
this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton6.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Cut;
this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton6.Name = "toolStripButton6";
this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
this.toolStripButton6.Text = "toolStripButton6";
// 
// toolStripButton7
// 
this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton7.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Copy;
this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton7.Name = "toolStripButton7";
this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
this.toolStripButton7.Text = "toolStripButton7";
// 
// toolStripButton8
// 
this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton8.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Paste;
this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton8.Name = "toolStripButton8";
this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
this.toolStripButton8.Text = "toolStripButton8";
// 
// toolStripButton11
// 
this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton11.Image = global::Jinisys.Hotel.ApplicationManager.Properties.Resources.Refresh;
this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton11.Name = "toolStripButton11";
this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
this.toolStripButton11.Text = "toolStripButton11";
// 
// toolStripButton10
// 
this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton10.Name = "toolStripButton10";
this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
this.toolStripButton10.Text = "toolStripButton10";
// 
// toolStripButton12
// 
this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton12.Name = "toolStripButton12";
this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
this.toolStripButton12.Text = "toolStripButton12";
// 
// toolStripButton9
// 
this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
this.toolStripButton9.Name = "toolStripButton9";
this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
this.toolStripButton9.Text = "toolStripButton9";
// 
// tmrSysTime
// 
this.tmrSysTime.Interval = 1000;
this.tmrSysTime.Tick += new System.EventHandler(this.tmrSysTime_Tick);
// 
// tmrUpdateRoomStat
// 
this.tmrUpdateRoomStat.Interval = 8000;
this.tmrUpdateRoomStat.Tick += new System.EventHandler(this.tmrUpdateRoomStat_Tick);
// 
// toolTipNytAudit
// 
this.toolTipNytAudit.IsBalloon = true;
// 
// backgroundWorker1
// 
this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
// 
// pictureBox1
// 
this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
this.pictureBox1.Location = new System.Drawing.Point(916, 724);
this.pictureBox1.Name = "pictureBox1";
this.pictureBox1.Size = new System.Drawing.Size(112, 22);
this.pictureBox1.TabIndex = 29;
this.pictureBox1.TabStop = false;
this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
// 
// MDIMainUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
this.BackColor = System.Drawing.Color.WhiteSmoke;
this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
this.ClientSize = new System.Drawing.Size(1028, 746);
this.Controls.Add(this.pictureBox1);
this.Controls.Add(this.lblSysTime);
this.Controls.Add(this.flpSidePanel);
this.Controls.Add(this.toolStrip1);
this.Controls.Add(this.menuStrip);
this.Controls.Add(this.stbHotel);
this.Font = new System.Drawing.Font("Arial", 8.25F);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
this.HelpButton = true;
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.IsMdiContainer = true;
this.MainMenuStrip = this.menuStrip;
this.Name = "MDIMainUI";
this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "IT";
this.toolTipVs.SetToolTip(this, "EventPlus - Professional Edition");
this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
this.Load += new System.EventHandler(this.MDIMainUI_Load);
this.Shown += new System.EventHandler(this.MDIMainUI_Shown);
this.MdiChildActivate += new System.EventHandler(this.MDIMainUI_MdiChildActivate);
this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClosing);
this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MDIMainUI_KeyPress);
((System.ComponentModel.ISupportInitialize)(this.pnlApplication)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.statDBConnection)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.pnlTerminal)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.pnlUser)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.pnlUserLogTime)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.pnlDate)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.pnlJinisys)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.vsDayPlo)).EndInit();
this.cmuLiveRoomStatus.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.gridFunctions)).EndInit();
this.toolStrip1.ResumeLayout(false);
this.toolStrip1.PerformLayout();
this.grbOccupancy.ResumeLayout(false);
this.menuStrip.ResumeLayout(false);
this.menuStrip.PerformLayout();
this.flpSidePanel.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.pictHotelLogo)).EndInit();
this.tabRooms.ResumeLayout(false);
this.tabPage1.ResumeLayout(false);
this.flpRooms.ResumeLayout(false);
this.pnlRooms.ResumeLayout(false);
this.pnlLegend.ResumeLayout(false);
this.tabPage2.ResumeLayout(false);
this.flpFunctions.ResumeLayout(false);
this.pnlFunction.ResumeLayout(false);
this.panel3.ResumeLayout(false);
this.groupBox1.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
this.ResumeLayout(false);
this.PerformLayout();

            }

            #endregion

            #region " C O N S T R U C T O R S "

            public MDIMainUI(string connectionStr)
            {
                //This call is required by the Windows Form Designer.
                InitializeComponent();
                //Add any initialization after the InitializeComponent() call

                connectionString = connectionStr;

//                this.backgroundWorker1.RunWorkerAsync();

                loadFolioAssemblies();

                //paramType[0] = typeof(System.String);
                //String[] param = new String[1];
                //param[0] = connectionString;
                //Form objSplash = FolioRegistry.CreateObject("Jinisys.Hotel.Security.Presentation.SplashScreenUI", paramType, param);
                //objSplash.ShowDialog(this);
            }

            #endregion

            #region " V A R I A B L E S / C O N S T A N T S "

            private FolioPlusRegistry FolioRegistry = new FolioPlusRegistry();

            private Point fLocation = new Point(0, 0);
            private string connectionString;
            public static int HotelID;

            Object loCurrencyFacade = null;
            Object loCalendarFacade = null;
            Object loOpenShiftFacade = null;
            Object loRoomBlockFacade = null;

            public UserUI frmSystemUsers;
            public TerminalUI frmTerminal;
            public SystemRoleUI frmSysRole;

            private User loUser = null;
            MySqlConnection[] param1 = new MySqlConnection[1];
            Type[] paramType = new Type[1];

            private int occupied = 0;
            private int noOfRooms = 0;
            private double occupancyRate = 0;

            private Form frmPostToLedger = null;
            private Form frmReportGenerator = null;
            private Form frmShareFolioUI = null;
            private Form frmGroupBlocking = null;
            private Form frmCurrencyCodes = null;
            private Form frmDepartment = null;
            private Form frmPackages = null;
            private Form frmPrivileges = null;
            private Form frmHotel = null;

            private Form frmBackUp = null;
            private Form frmCaptureImage = null;
            private Form frmHousekeepingUI = null;
            private Form frmCashTerminalList = null;
            private Form frmNoOfPax = null;
            private Form frmSalesForecast = null;
            private Form frmFolioInquiry = null;
            private Form frmCityLedgerSummary = null;
            private Form frmInhouseGuestForeCast = null;
            private Form frmCityTransfer = null;
            private Form frmTransactionRegister = null;
            private Form frmRefUI = null;
            public Form frmReservationList = null;
            public Form frmChangePassword = null;
            private Form frmAvailability = null;
            private Form frmRoomingList = null;

            private Color cellColor = Color.White;
            private Form frmRoomHistory = null;
            private string lastHoverRoomNo = "";

            private object oFolioFacade = null;
            private DataTable oGuestFolio = null;
			private DataTable oCompanyFolio = null;

            private DataTable oRoomBlock;
            private int countReshowNytAuditTip = 60;

            DateTime auditDate;
            #endregion

            #region " M E T H O D S "

            public bool isOpen(System.Windows.Forms.Form frm1)
            {
                System.Windows.Forms.Form frm;
                foreach (System.Windows.Forms.Form tempLoopVar_frm in this.MdiChildren)
                {
                    frm = tempLoopVar_frm;

                    if (frm == frm1)
                    {
                        frm.Focus();
                        return true;
                    }
                }
                return false;
            }

            private void loadFolioAssemblies() //revised Jess  10.9.09 
            {

                FolioRegistry.RegisterFolioTypes("../main/reservation.dll");
                FolioRegistry.RegisterFolioTypes("../main/Accounts.dll");
                FolioRegistry.RegisterFolioTypes("../main/Cashier.dll");
                FolioRegistry.RegisterFolioTypes("../main/Security.dll");
                FolioRegistry.RegisterFolioTypes("../main/Utilities.dll");
                FolioRegistry.RegisterFolioTypes("../main/Services.dll");

                //FolioRegistry.RegisterFolioTypes("../main/Reports.dll");
                FolioRegistry.RegisterFolioTypes("../main/NightAudit.dll");
                FolioRegistry.RegisterFolioTypes("../main/ConfigurationHotel.dll");
                FolioRegistry.RegisterFolioTypes("../main/AccountingInterface.dll");

                ////
                ////ORIGINAL CODES PRIOR TO REVISION 
                ////
                //try
                //{
                //    XmlTextReader reader = new XmlTextReader("Assemblies.xml");

                //    while (reader.Read())
                //    {
                //        switch (reader.NodeType)
                //        {
                //            case XmlNodeType.Text:
                //                FolioRegistry.RegisterFolioTypes(reader.Value);
                //                break;
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

            public void closeAllForms()
            {
                Form frm;
                foreach (Form tempLoopVar_frm in this.MdiChildren)
                {
                    frm = tempLoopVar_frm;
                    frm.Close();
                }
            }

            private void alignValuesInRoom()
            {
                for (int i = 0; i <= vsDayPlo.Cols - 1; i++)
                {
                    vsDayPlo.set_ColAlignment(i, C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter);
                }
            }

            public void updateCurrentDayRoomStatus(string roomid, string updateType)
            {
                for (int row = 0; row < this.vsDayPlo.Rows; row++)
                {
                    for (int col = 0; col < this.vsDayPlo.Cols; col++)
                    {
                        if (roomid == vsDayPlo.get_TextMatrix(row, col))
                        {
                            setColor(updateType, row, col);

                            getCurrentDayRoomBlock();
                            return;
                        }
                    }
                }

            }

            DataTable ldataTableCurrentDayStat;
			//private int vacantCleanRooms = 0;
			//private int vacantDirtyRooms = 0;
			//private int occupiedRooms = 0;
			//private int occupiedDirtyRooms = 0;
			//private int reservedRooms = 0;
			//private int outOfOrderRooms = 0;
			//private int blockedRooms = 0;
            public void plotCurrentDayRoomStatus()
            {
                // for TOOL TIP
                try
                {
                    getAllFolioInformation();
                    getCurrentDayRoomBlock();
                }
                catch { }


                occupied = 0;
                noOfRooms = 0;

                this.vsDayPlo.Rows = 0;

                Object[] paramVal = { GlobalVariables.gAuditDate };
                ldataTableCurrentDayStat = (DataTable)loCalendarFacade.GetType().GetMethod("getCurrentDayRoomStatus").Invoke(loCalendarFacade, paramVal);

				DataColumn[] dtCols = new DataColumn[1];
				dtCols[0] = new DataColumn();
				dtCols[0] = ldataTableCurrentDayStat.Columns["RoomId"];
				ldataTableCurrentDayStat.PrimaryKey = dtCols;

				DataView _dtViewRooms = ldataTableCurrentDayStat.DefaultView;
				_dtViewRooms.RowStateFilter = DataViewRowState.OriginalRows;
                //_dtViewRooms.RowFilter = "roomtypecode <> 'FUNCTION'";
                
                /* FP-SCR-00139 [07.21.2010]
                 * filter by room super type */
                _dtViewRooms.RowFilter = "RoomSuperType <> 'FUNCTION'";
                
                int col = 0;
                vsDayPlo.Rows++;
				//vacantCleanRooms = 0;
				//vacantDirtyRooms = 0;
				//occupiedRooms = 0;
				//reservedRooms = 0;
				//outOfOrderRooms = 0;
				//blockedRooms = 0;
				//occupiedDirtyRooms = 0;

                //foreach (DataRow dRow in ldataTableCurrentDayStat.Rows)
                foreach (DataRowView dRow in _dtViewRooms)
                {
                    noOfRooms++;
                    if (col <= 3)
                    {
                        string _roomId = "";
                        string _roomCleaningStatus = "";

                        _roomId = dRow["roomid"].ToString();
                        _roomCleaningStatus = dRow["cleaningstatus"].ToString();

                        this.vsDayPlo.set_TextMatrix(vsDayPlo.Rows - 1, col, _roomId);

                        vsDayPlo.set_RowHeight(vsDayPlo.Rows - 1, 20);
                        C1.Win.C1FlexGrid.CellRange range = this.vsDayPlo.GetCellRange(vsDayPlo.Rows - 1, col);
                        range.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

                        string _eventType = dRow["eventtype"].ToString().ToUpper();
                        if ((dRow["eventtype"]) != null)
                        {
                            // to SET COLOR VACANT-DIRTY for RESERVED ROOMS
                            if (_roomCleaningStatus == "DIRTY")
                            {
                                if (_eventType == "IN HOUSE")
                                {
                                    // check if Expected CHECKOUT
                                    // if so, then Dont treat as Inhouse-Dirty
                                    // since room will be cleaned upon guest checkout
                                    //if (!isExpectedCheckOut(_roomId, "ONGOING"))
                                    //{
                                    _eventType = "IN HOUSE-DIRTY";
                                    //}
                                }
                                else
                                {
                                    _eventType = "VACANT-DIRTY";
                                }

                            }

                            setColor(_eventType, vsDayPlo.Rows - 1, col);

                        }

                        col++;
                    }
                    if (col > 3)
                    {
                        col = 0;
                        vsDayPlo.Rows++;
                    }
                }

				//>> show CurrentDate and Yesterday's Occupancy Rate
				showOccupancyRate();

                vsDayPlo.Visible = true;

                int _sidePanelHeight = this.flpSidePanel.Height;// -125;

				this.tabRooms.Height = (_sidePanelHeight + 55);
				this.flpRooms.Height = (_sidePanelHeight + 55);
				this.flpFunctions.Height = (_sidePanelHeight + 55);

                // for the CURSOR to reside at the last ROW/COL.
                this.vsDayPlo.Select(vsDayPlo.Rows - 1, vsDayPlo.Cols - 1);
               
                // set up vs height
                int _rowsIndividual = this.vsDayPlo.Rows;
                int _rowsFunction = this.gridFunctions.Rows;

                if (_rowsIndividual > 28)
                    this.pictHotelLogo.Visible = false;

                int _heightIndividual = (_rowsIndividual * 19) + 8;
                int _heightFunction = (_rowsFunction * 19) + 8;

                if (_heightFunction > _heightIndividual)
                    this.pnlRooms.Height = _heightFunction;
                else
                    this.pnlRooms.Height = _heightIndividual;
                //this.tabRooms.Height = (_height + 40);

                this.pnlFunction.Height = _heightFunction;

				//plot funtions ROOMS stat
				plotFunctionRoomStatus();

				
				//update LEGEND values
				updateRoomLegendValues();

                //this.BackgroundImage = Image.FromFile(ConfigVariables.gAppBackground);
                //this.BackgroundImageLayout = ImageLayout.Stretch;
            }

			private void updateRoomLegendValues()
			{
				int _totalVacantDirtyRooms = 0;
				int _totalVacantCleanRooms = 0;
				int _totalOccupiedDirtyRooms = 0;
				int _totalOccupiedCleanRooms = 0;
				int _totalRooms = 0;
                int _totalInHouseGuests = 0;


				int _totalVacantDirtyFunction = 0;
				int _totalVacantCleanFunction = 0;
				int _totalOccupiedDirtyFunction = 0;
				int _totalOccupiedCleanFunction = 0;
				int _totalFunction = 0;

				// -------  ROOM SUMMARY  -------------
				DataTable _dtRoomStatusSummary = (DataTable)loCalendarFacade.GetType().GetMethod("getRoomStatusAndCleaningSummary").Invoke(loCalendarFacade, null);
				DataView _dtvStat = _dtRoomStatusSummary.DefaultView;
				try {
					foreach (DataRowView _dRow in _dtvStat)
					{ 
						_totalRooms += int.Parse(_dRow["Total"].ToString());
					}
				}
				catch { }
				this.lblTotalRooms.Text = _totalRooms.ToString();


				// VACANT DIRTY
				_dtvStat.RowStateFilter = DataViewRowState.OriginalRows;
				_dtvStat.RowFilter = "stateFlag = 'VACANT' and cleaningStatus = 'DIRTY'";
				try
				{
					_totalVacantDirtyRooms = int.Parse(_dtvStat[0]["Total"].ToString());
				}
				catch { }
				this.lblVacantDirtyRoom.Text = _totalVacantDirtyRooms.ToString();


				// VACANT CLEAN
				_dtvStat.RowStateFilter = DataViewRowState.OriginalRows;
				_dtvStat.RowFilter = "stateFlag = 'VACANT' and cleaningStatus = 'CLEAN'";
				try
				{
					_totalVacantCleanRooms = int.Parse( _dtvStat[0]["Total"].ToString() );
				}
				catch { }
				// VACANT CLEAN = vacant - reserved - blocked - ooo;

				//this.lblVacantCleanRoom.Text = _totalVacantCleanRooms.ToString();


				// OCCUPIED DIRTY
				_dtvStat.RowStateFilter = DataViewRowState.OriginalRows;
				_dtvStat.RowFilter = "stateFlag = 'OCCUPIED' and cleaningStatus = 'DIRTY'";
				try
				{
					_totalOccupiedDirtyRooms = int.Parse( _dtvStat[0]["Total"].ToString() );
				}
				catch { }
				this.lblOccupiedDirtyRoom.Text = _totalOccupiedDirtyRooms.ToString();


				// OCCUPIED CLEAN
				_dtvStat.RowStateFilter = DataViewRowState.OriginalRows;
				_dtvStat.RowFilter = "stateFlag = 'OCCUPIED' and cleaningStatus = 'CLEAN'";
				try
				{
					_totalOccupiedCleanRooms = int.Parse( _dtvStat[0]["Total"].ToString() );
				}
				catch { }
				this.lblOccupiedCleanRoom.Text = _totalOccupiedCleanRooms.ToString();

				// RESERVED ROOMS
				int _totalReserve = 0;
				try
				{
					_totalReserve = (int)loCalendarFacade.GetType().GetMethod("getExpectedCheckInRoomCount").Invoke(loCalendarFacade, null);
				}
				catch { }
				this.lblReservedRooms.Text = _totalReserve.ToString();
                this.lblReservedRooms.BringToFront();

				// BLOCKED ROOMS[count]
				int _totalBlockRooms = 0;
				try
				{
					_totalBlockRooms = (int)loCalendarFacade.GetType().GetMethod("getTotalBlockRoomsCount").Invoke(loCalendarFacade, null);
				}
				catch { }
				this.lblBlockedRooms.Text = _totalBlockRooms.ToString();


				// OUT OF ORDER ROOMS[count]
				int _totalOutOfOrderRooms = 0;
				try
				{
					_totalOutOfOrderRooms = (int)loCalendarFacade.GetType().GetMethod("getTotalOutOfOrderRoomsCount").Invoke(loCalendarFacade, null);
				}
				catch { }
				this.lblOutOfOrderRooms.Text = _totalOutOfOrderRooms.ToString();


				// TOTAL VACANT CLEAN = totalVacantClean - blocked - ooo;
				_totalVacantCleanRooms = _totalVacantCleanRooms - (_totalBlockRooms + _totalOutOfOrderRooms);
				this.lblVacantCleanRoom.Text = _totalVacantCleanRooms.ToString();
				// ------ END OR ROOM SUMMARY ---------


				// FUNCTION ROOMS 
				//DataTable _dtFunctionStatusSummary = (DataTable)loCalendarFacade.GetType().GetMethod("getFunctionStatusAndCleaningSummary").Invoke(loCalendarFacade, null);
				//DataView _dtvFunction = _dtFunctionStatusSummary.DefaultView;
                DataView _dtvFunction = ldataTableCurrentDayStat.DefaultView;
                _dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
				try
				{
                    //foreach (DataRowView _dRow in _dtvFunction)
                    //{
                    //    _totalFunction += int.Parse(_dRow["Total"].ToString());
                    //}
                    _totalFunction = _dtvFunction.Count;
				}
				catch { }
				this.lblTotalFunctions.Text = _totalFunction.ToString();

                //// VACANT DIRTY FUNCTIONS
                //_dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
                //_dtvFunction.RowFilter = "stateFlag = 'VACANT' and cleaningStatus = 'DIRTY'";
                //try
                //{
                //    _totalVacantDirtyFunction = int.Parse(_dtvFunction[0]["Total"].ToString());
                //}
                //catch { }
                //this.lblVacantDirtyFunction.Text = _totalVacantDirtyFunction.ToString();


				// VACANT CLEAN
				_dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
				//_dtvFunction.RowFilter = "stateFlag = 'VACANT' and cleaningStatus = 'CLEAN'";
                _dtvFunction.RowFilter = "eventtype is null";
                //try
                //{
                //    _totalVacantCleanFunction = int.Parse(_dtvFunction[0]["Total"].ToString());
                //}
                //catch { }
				//this.lblVacantCleanFunction.Text = _totalVacantCleanFunction.ToString();
                _totalVacantCleanFunction = _dtvFunction.Count;
                lblVacantCleanFunction.Text = _totalVacantCleanFunction.ToString();

                //// OCCUPIED DIRTY
                //_dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
                //_dtvFunction.RowFilter = "stateFlag = 'OCCUPIED' and cleaningStatus = 'DIRTY'";
                //try
                //{
                //    _totalOccupiedDirtyFunction = int.Parse(_dtvFunction[0]["Total"].ToString());
                //}
                //catch { }
                //this.lblOccupiedDirtyFunction.Text = _totalOccupiedDirtyFunction.ToString();


				// OCCUPIED CLEAN
				_dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
				//_dtvFunction.RowFilter = "stateFlag = 'OCCUPIED' and cleaningStatus = 'CLEAN'";
                _dtvFunction.RowFilter = "eventtype = 'IN HOUSE'";
                //try
                //{
                //    _totalOccupiedCleanFunction = int.Parse(_dtvFunction[0]["Total"].ToString());
                //}
                //catch { }
				//this.lblOccupiedCleanFunction.Text = _totalOccupiedCleanFunction.ToString();
                //jlo 9-6-10 picc
                //_totalOccupiedCleanFunction = _totalOccupiedCleanFunction + _totalOccupiedDirtyFunction;
                _totalOccupiedCleanFunction = _dtvFunction.Count;
                this.lblOccupiedCleanFunction.Text = _totalOccupiedCleanFunction.ToString();

				// RESERVED FUNCTIONS
				int _totalReserveFunction = 0;
                _dtvFunction.RowStateFilter = DataViewRowState.OriginalRows;
                _dtvFunction.RowFilter = "eventtype = 'RESERVATION'";
                //try
                //{
                //    _totalReserveFunction = (int)loCalendarFacade.GetType().GetMethod("getExpectedCheckInFunctionCount").Invoke(loCalendarFacade, null);
                //}
                //catch { }
                _totalReserveFunction = _dtvFunction.Count;
				this.lblReservedFunction.Text = _totalReserveFunction.ToString();

				// BLOCKED ROOMS[count]
				int _totalBlockFunction = 0;
				try
				{
					_totalBlockFunction = (int)loCalendarFacade.GetType().GetMethod("getTotalBlockFunctionCount").Invoke(loCalendarFacade, null);
				}
				catch { }
				this.lblBlockedFunction.Text = _totalBlockFunction.ToString();


				// OUT OF ORDER ROOMS[count]
				int _totalOutOfOrderFunction = 0;
				try
				{
					_totalOutOfOrderFunction = (int)loCalendarFacade.GetType().GetMethod("getTotalOutOfOrderFunctionCount").Invoke(loCalendarFacade, null);
				}
				catch { }
				this.lblOutOfOrderFunction.Text = _totalOutOfOrderFunction.ToString();


				// TOTAL VACANT CLEAN = totalVacantClean - blocked - ooo;
                //_totalVacantCleanFunction = _totalVacantCleanFunction - (_totalBlockFunction + _totalOutOfOrderFunction);
                //jlo 9-06-10 picc
                //_totalVacantCleanFunction = _totalVacantCleanFunction - (_totalBlockFunction + _totalOutOfOrderFunction) + _totalVacantDirtyFunction;
				//this.lblVacantCleanFunction.Text = _totalVacantCleanFunction.ToString();

				// ----- END OF FUNCTION ROOMS SUMMARY -------

                //for TOTAL IN HOUSE GUESTS
                FolioFacade _oFolioFacade = new FolioFacade();
                _totalInHouseGuests = _oFolioFacade.getTotalInHouseGuests();
                this.lblTotalInHouse.Text = _totalInHouseGuests.ToString();

			}



            public void showOccupancyRate()
            {

                //>> ROOM OCCUPANCY
				object[] paramVal = { string.Format("{0:yyyy-MM-dd}", auditDate) };
				decimal _currentDayOccupancy = (decimal)loCalendarFacade.GetType().GetMethod("getDailyRoomOccupancyRate").Invoke(loCalendarFacade, paramVal);
				
				object[] paramValYesterday = { string.Format("{0:yyyy-MM-dd}", auditDate.AddDays(-1)) };
				decimal _yesterdayOccupancy = (decimal)loCalendarFacade.GetType().GetMethod("getDailyRoomOccupancyRate").Invoke(loCalendarFacade, paramValYesterday);

				
				this.lblCurrentOccupancyRate.Text = _currentDayOccupancy.ToString("N") + " %";
				this.lblYesterdayOccupacyRate.Text = _yesterdayOccupancy.ToString("N") + " %";

				

				//>> FUNCTION ROOM OCCUPANCY
				object[] paramValFunction = { string.Format("{0:yyyy-MM-dd}", auditDate) };
				decimal _currentDayFunctionRoomOccupancy = (decimal)loCalendarFacade.GetType().GetMethod("getDailyFunctionRoomOccupancyRate").Invoke(loCalendarFacade, paramValFunction);

				object[] paramValYesterdayFunction = { string.Format("{0:yyyy-MM-dd}", auditDate.AddDays(-1)) };
				decimal _yesterdayFunctionRoomOccupancy = (decimal)loCalendarFacade.GetType().GetMethod("getDailyFunctionRoomOccupancyRate").Invoke(loCalendarFacade, paramValYesterdayFunction);


				this.lblCurrentDayFunctionRoomOccupancy.Text = _currentDayFunctionRoomOccupancy.ToString("N") + " %";
				this.lblYesterDayFunctionRoomOccupancy.Text = _yesterdayFunctionRoomOccupancy.ToString("N") + " %";

                plotBlockRooms();
            }

			DataTable lBlockRoomTable;
            public void plotBlockRooms()
            {
                
                lBlockRoomTable = (DataTable)oFolioFacade.GetType().GetMethod("getRoomBlocksForToolTip").Invoke(oFolioFacade, null);
				
                int row;
                int col;
                DataRow dtRow;
                if (lBlockRoomTable != null)
                {
                    foreach (DataRow tempLoopVar_dtRow in lBlockRoomTable.Rows)
                    {
                        dtRow = tempLoopVar_dtRow;
                        for (row = 0; row <= this.vsDayPlo.Rows - 1; row++)
                        {
                            for (col = 0; col <= this.vsDayPlo.Cols - 1; col++)
                            {
                                if (dtRow["roomid"].ToString() == this.vsDayPlo.get_TextMatrix(row, col))
                                {
                                    //check whether cell already has color
                                    if (this.vsDayPlo.GetCellStyle(row, col).BackColor == Color.White)
                                    {
                                        setColor(dtRow["eventtype"].ToString(), row, col);
                                    }
                                }
                            }
                        }
                    }
                }
                //showCurrencyRates();
            }

            private void setColor(string eventtype, int row, int col)
            {
                C1.Win.C1FlexGrid.CellRange range = this.vsDayPlo.GetCellRange(row, col);
                switch (eventtype.ToUpper())
                {
                    case "RESERVATION":

                        range.StyleNew.BackColor = Color.DodgerBlue;
                        range.StyleNew.ForeColor = Color.Black;
                        //reservedRooms++;
                        break;
                    case "IN HOUSE":

                        range.StyleNew.BackColor = Color.Aqua;
                        range.StyleNew.ForeColor = Color.Black;
                        //occupiedRooms++;
                        occupied++;
                        break;
                    case "ENGINEERING JOB":

                        range.StyleNew.BackColor = Color.GreenYellow;
                        range.StyleNew.ForeColor = Color.Black;
                        //outOfOrderRooms++;
                        break;
                    case "BLOCKING":

                        range.StyleNew.BackColor = Color.Brown;
                        range.StyleNew.ForeColor = Color.White;
                        //blockedRooms++;
                        //vacantCleanRooms--;
                        break;

                    case "VACANT-DIRTY":
                        range.StyleNew.BackColor = this.lbl0.BackColor;
                        range.StyleNew.ForeColor = this.lbl0.ForeColor;
                        //vacantDirtyRooms++;
                        break;

                    case "IN HOUSE-DIRTY":
                        range.StyleNew.BackColor = this.lbl3.BackColor;
                        range.StyleNew.ForeColor = this.lbl3.ForeColor;
                        //occupiedDirtyRooms++;
						occupied++;
                        break;

                    case "":

                        range.StyleNew.BackColor = Color.White;
                        range.StyleNew.ForeColor = Color.Black;
                        //vacantCleanRooms++;
                        break;
                }
            }

			private void setColorFunction(string eventtype, int row, int col)
			{
				C1.Win.C1FlexGrid.CellRange range = this.gridFunctions.GetCellRange(row, col);
				switch (eventtype.ToUpper())
				{
					case "RESERVATION":
                    case "TENTATIVE":
						range.StyleNew.BackColor = Color.DodgerBlue;
						range.StyleNew.ForeColor = Color.Black;
						//reservedRooms++;
						break;

                    case "IN HOUSE-DIRTY":
                        //range.StyleNew.BackColor = this.lbl3.BackColor;
                        //range.StyleNew.ForeColor = this.lbl3.ForeColor;
                        ////occupiedDirtyRooms++;
                        ////occupied++;
                        //break;
					case "IN HOUSE":
                    case "CONFIRMED":
						range.StyleNew.BackColor = Color.Aqua;
						range.StyleNew.ForeColor = Color.Black;
						//occupiedRooms++;
						//occupied++;
						break;
					case "ENGINEERING JOB":

						range.StyleNew.BackColor = Color.GreenYellow;
						range.StyleNew.ForeColor = Color.Black;
						//outOfOrderRooms++;
						break;
					case "BLOCKING":

						range.StyleNew.BackColor = Color.Brown;
						range.StyleNew.ForeColor = Color.White;
						//blockedRooms++;
						//vacantCleanRooms--;
						break;

                    case "VACANT-DIRTY":
                        //range.StyleNew.BackColor = this.lbl0.BackColor;
                        //range.StyleNew.ForeColor = this.lbl0.ForeColor;
                        ////vacantDirtyRooms++;
                        //break;

					case "":

						range.StyleNew.BackColor = Color.White;
						range.StyleNew.ForeColor = Color.Black;
						//vacantCleanRooms++;
						break;
				}
			}

            private void setUserToolbars()
            {
                foreach (ToolStripItem tbutton in this.toolStrip1.Items)
                {
                    tbutton.Enabled = false;
                }
                foreach (ToolStripItem tbutton in this.toolStrip1.Items)
                {
                    string str = tbutton.Text.Replace("&", "");
                    if (isUserRoleMenu(str))
                    {
                        tbutton.Enabled = true;
                    }
                }
            }

            public string getTranslation(string pValue)
            {
                DataView _dv = loTranslations.DefaultView;
                _dv.RowFilter = "defaultValue = '" + pValue + "'";
                string _translated = "";
                try
                {
                    //_translated = _dv.ToTable().Rows[0]["english"].ToString();
                    _translated = _dv[0]["english"].ToString();
                }
                catch { }
                return _translated;
            }

            private void setUserMenus()
            {
                //setDisableMenuItems();
                ToolStripItem ctrl;
                foreach (ToolStripItem tempLoopVar_ctrl in this.menuStrip.Items)
                {
                    ctrl = tempLoopVar_ctrl;
                    string str = ctrl.Text.Replace("&", "");

                    if (isUserRoleMenu(str))
                    {

                        ctrl.Enabled = true;
                    }

                    //jlo 8-24-10 add menu translator
                    string ctrl_trans = this.getTranslation(ctrl.Text.Replace("&", ""));
                    if (ctrl_trans != "")
                        ctrl.Text = ctrl_trans;
                    //jlo


                    if (((ToolStripMenuItem)ctrl).HasDropDownItems)
                    {
                        foreach (ToolStripItem drop in ((ToolStripMenuItem)ctrl).DropDownItems)
                        {
                            string str_1 = drop.Text.Replace("&", "");
                            if (isUserRoleMenu(str_1))
                            {
                                drop.Enabled = true;
                            }

                            //jlo 8-24-10 add menu translator
                            string _translation = this.getTranslation(drop.Text.Replace("&", ""));
                            if (_translation != "")
                                drop.Text = _translation;
                            //jlo

                            if (drop.GetType() != typeof(ToolStripSeparator))
                            {
                                if (((ToolStripMenuItem)drop).HasDropDownItems)
                                {
                                    foreach (ToolStripItem drop_1 in ((ToolStripMenuItem)drop).DropDownItems)
                                    {
                                        string str_2 = drop_1.Text.Replace("&", "");
                                        if (isUserRoleMenu(str_2))
                                        {
                                            drop_1.Enabled = true;
                                        }

                                        //jlo 8-24-10 add menu translator
                                        string _translation_1 = this.getTranslation(drop_1.Text.Replace("&", ""));
                                        if (_translation_1 != "")
                                            drop_1.Text = _translation_1;
                                        //jlo
                                    }
                                }
                            }

                        }
                    }

                }

            }

            private void setDisableMenuItems()
            {
                ToolStripItem ctrl;

                foreach (ToolStripItem tempLoopVar_ctrl in this.menuStrip.Items)
                {
                    ctrl = tempLoopVar_ctrl;
                    ctrl.Enabled = false;
                    if (((ToolStripMenuItem)ctrl).HasDropDownItems)
                    {
                        foreach (ToolStripItem drop in ((ToolStripMenuItem)ctrl).DropDownItems)
                        {
                            drop.Enabled = false;

                            if (drop.GetType() != typeof(ToolStripSeparator))
                            {
                                if (((ToolStripMenuItem)drop).HasDropDownItems)
                                {
                                    foreach (ToolStripItem drop_1 in ((ToolStripMenuItem)drop).DropDownItems)
                                    {
                                        drop_1.Enabled = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            public bool isUserRoleMenu(string menuName)
            {
                foreach (Role oRole in loUser.Roles)
                {

                    foreach (SystemMenu oMenu in oRole.Menus)
                    {

                        if (oMenu.MenuName.ToUpper().Equals(menuName.ToUpper()))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            public void showRoomAvailability(int noOfWeeks, DateTime startDate)
            {
                try
                {
                    Type[] paramType = { typeof(System.Int32), typeof(System.DateTime) };
                    object[] paramVal = { noOfWeeks, startDate };
                    frmAvailability = (Form)FolioRegistry.CreateObject(roomAvailabilityToolStripMenuItem.Tag.ToString(), paramVal, paramType);
                    frmAvailability.MdiParent = this;
                    frmAvailability.Show();
                }
                catch
                {
                    //MessageBox.Show("
                }
            }

            public void NewReservationNonStaying()
            {

				Type[] paramType = { typeof(ReservationOperationMode) };
				object[] paramVal = { ReservationOperationMode.NonStaying };

				frmShareFolioUI = (Form)FolioRegistry.CreateObject(this.mnuSingleReservation.Tag.ToString(), paramType, paramVal);

				frmShareFolioUI.MdiParent = this;
				frmShareFolioUI.Top = 0;
				frmShareFolioUI.Left = 0;
				frmShareFolioUI.Show();

            }

			public void newIndividualReservation()
			{

				Type[] paramType = { typeof(ReservationOperationMode) };
				object[] paramVal = { ReservationOperationMode.NewGuestReservation };

				frmShareFolioUI = (Form)FolioRegistry.CreateObject(this.mnuSingleReservation.Tag.ToString(), paramType, paramVal);
				
				frmShareFolioUI.MdiParent = this;
				frmShareFolioUI.Top = 0;
				frmShareFolioUI.Left = 0;
				frmShareFolioUI.Show();
			}

            public void updateAuditDate()
            {
                pnlDate.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                //this.stbHotel.Panels[4].Text = 
            }

            public string getFolioId(string a_RoomId, string a_EventType)
            {
                try
                {
                    DataTable dt = new DataTable();
                    MySqlCommand cmdCommand = new MySqlCommand("call spGetCurrentDayFolioIdByRoom('" + a_RoomId + "','" + a_EventType + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
                    return  cmdCommand.ExecuteScalar().ToString();

                }
                catch (Exception ex)
                {
                    throw (new Exception(ex.Message));
                }

            }

            private int getAllFolioInformation()
            {
                oFolioFacade = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.BusinessLayer.FolioFacade");
                oGuestFolio = (DataTable)oFolioFacade.GetType().GetMethod("getGuestForToolTip").Invoke(oFolioFacade, null);

				oCompanyFolio = (DataTable)oFolioFacade.GetType().GetMethod("getCompanyFoliosForToolTip").Invoke(oFolioFacade, null);

                return 1;
            }

            private string showFolioInformation(string a_RoomId, string a_FolioStatus)
            {
                try
                {
                    string folioInfo = "";

                    DataView dtView = oGuestFolio.DefaultView;

                    dtView.RowStateFilter = DataViewRowState.OriginalRows;
                    dtView.RowFilter = "RoomId = '" + a_RoomId + "' AND Status = '" + a_FolioStatus + "'";

                    foreach (DataRowView dRowView in dtView)
                    {
                        folioInfo += "Type\t:  " + dRowView["RoomTypeCode"] + "\r\n";

                        folioInfo += "\r\n";

                        folioInfo += "Guest\t:  " + dRowView["GuestName"] + "\r\n";
                        folioInfo += "Rate\t:  " + string.Format("{0:#,##0.00}", Double.Parse(dRowView["Rate"].ToString())) + "\r\n";
                        folioInfo += "Arrival\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["ArrivalDate"].ToString())) + "\r\n";
                        folioInfo += "Depart'r\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["DepartureDate"].ToString())) + "\r\n";
                        folioInfo += "E.T.A.\t:  " + dRowView["folioETA"].ToString() + "\r\n";
                        folioInfo += "E.T.D.\t:  " + dRowView["folioETD"].ToString() + "\r\n";
                        folioInfo += "Pax\t:  " + dRowView["noOfAdults"].ToString() + "\r\n\r\n";

                        folioInfo += "Comp.\t:  " + dRowView["CompanyName"] + "\r\n";
                        folioInfo += "Folio\t:  " + dRowView["FolioType"] + "\r\n\r\n";

                        folioInfo += "Source\t: " + dRowView["source"] + "\r\n";
						folioInfo += "Remarks :\r\n" + dRowView["Remarks"] + "\r\n";

                        break;
                    }


                    return folioInfo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }

			private string showCompanyFolioInformation(string a_RoomId, string a_FolioStatus)
			{
				try
				{
					string folioInfo = "";

					DataView dtView = oCompanyFolio.DefaultView;

					dtView.RowStateFilter = DataViewRowState.OriginalRows;
					dtView.RowFilter = "RoomId = '" + a_RoomId + "' AND (Status = '" + a_FolioStatus + "' or Status='TENTATIVE')";

					int i = 0;
					foreach (DataRowView dRowView in dtView)
					{
						if (i == 0)
						{
							folioInfo += "Type\t: " + dRowView["roomtype"] + "\r\n";
						}
						else
						{
							folioInfo += "--------------------------------\r\n";
						}

						folioInfo += "\r\n";

						folioInfo += "Event \t: " + dRowView["groupname"] + "\r\n";
						folioInfo += "Comp.\t: " + dRowView["companyname"] + "\r\n\r\n";
                        //folioInfo += "Contact\t:  " + dRowView["contactperson"] + "\r\n";
                        //folioInfo += "Live In\t:  " + dRowView["liveInPax"] + "\r\n";
                        //folioInfo += "Live Out:  " + dRowView["liveOutPax"] + "\r\n\r\n";SSSSS

						folioInfo += "Start\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["ArrivalDate"].ToString())) + "\r\n";
						folioInfo += "End\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["DepartureDate"].ToString())) + "\r\n\r\n";

						folioInfo += "Remarks :\r\n" + dRowView["Remarks"] + "\r\n";

						//break;
						i++;
					}


					return folioInfo;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Exception: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return "";
				}
			}

            private int getCurrentDayRoomBlock()
            {
                oRoomBlock = new DataTable();

                oFolioFacade = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.BusinessLayer.FolioFacade");
                oRoomBlock = (DataTable)oFolioFacade.GetType().GetMethod("getRoomBlocksForToolTip").Invoke(oFolioFacade, null);

				updateRoomLegendValues();
                return 1;

            }

            private string showRoomBlockInformation(string a_RoomId)
            {
                try
                {
                    string roomInfo = "";

                    DataView dtView = oRoomBlock.DefaultView;

                    dtView.RowStateFilter = DataViewRowState.OriginalRows;
                    dtView.RowFilter = "RoomId = '" + a_RoomId + "'";

                    foreach (DataRowView dRowView in dtView)
                    {
                        roomInfo += dRowView["cleaningStatus"].ToString() + "\r\n\r\n";
                        roomInfo += "Block Id\t:  " + dRowView["BlockId"] + "\r\n";
                        roomInfo += "From\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["FromDate"].ToString())) + "\r\n";
                        roomInfo += "To\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["ToDate"].ToString())) + "\r\n";
                        roomInfo += "Remaks\t:  " + dRowView["Reason"].ToString().ToUpper() + "\r\n\r\n";

                        break;
                    }

                    return roomInfo;
                }
                catch
                { return ""; }
            }

			private void protectConfigFile()
			{

				Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				ConfigurationSection appSettings = conf.GetSection("appSettings");

				if (appSettings.SectionInformation.IsProtected)
					return;

				appSettings.SectionInformation.ProtectSection(null);
				appSettings.SectionInformation.ForceSave = true;
				conf.Save(ConfigurationSaveMode.Full);

			}


            #endregion

            #region " E D I T "
            // >> GUEST > Individual
            Form frmGuestAccount = null;
            private void mnuEditIndividualAccount_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmGuestAccount))
                {

                    frmGuestAccount = (Form)FolioRegistry.CreateObject(mnuIndividualGuest.Tag.ToString());
                    frmGuestAccount.MdiParent = this;
                    frmGuestAccount.Show();
                    frmGuestAccount.Location = fLocation;
                }
            }

            // >> GUEST > Group
            Form frmCompanyAccount = null;
            private void mnuEditGroupAccount_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmCompanyAccount))
                {
                    frmCompanyAccount = (Form)FolioRegistry.CreateObject(mnuGroupGuest.Tag.ToString());
                    frmCompanyAccount.MdiParent = this;
                    frmCompanyAccount.Show();
                    frmCompanyAccount.Location = fLocation;
                }
            }

            #endregion

            #region " T R A N S A C T I O N "

            // >> AUDIT > Post Room Charges
            Form frmPostRoomCharges = null;
            private void mnuAuditPostRoomCharges_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmPostRoomCharges))
                {

                    frmPostRoomCharges = (Form)FolioRegistry.CreateObject(mnuConfigureDayEndClosing.Tag.ToString());
                    frmPostRoomCharges.MdiParent = this;
                    frmPostRoomCharges.Show();
                    frmPostRoomCharges.Location = fLocation;
                }
            }

            // >> AUDIT > Day-End Closing
            Form frmdayEndClosing = null;
            private void mnuAuditDayEnd_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmdayEndClosing))
                {
					closeAllForms();

                    frmdayEndClosing = (Form)FolioRegistry.CreateObject(mnuDayEndClosing.Tag.ToString());
                    //frmdayEndClosing.MdiParent = this;
                    frmdayEndClosing.ShowDialog(this);
                    //frmdayEndClosing.Location = fLocation;
                }
            }

            // >> CASHIER > Folio Ledger
            Form frmFolioLedgers = null;
            private void mnuCashierFolioLedger_Click(System.Object sender, System.EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmFolioLedgers))
                {

                    frmFolioLedgers = (Form)FolioRegistry.CreateObject(mnuFolioLedgers.Tag.ToString());
                    frmFolioLedgers.MdiParent = this;
                    frmFolioLedgers.Show();
                    frmFolioLedgers.Location = fLocation;
                }
            }

            // >> CASHIER > Folio Adjustment
            Form frmTransactionRouting = null;
            private void mnuCashieringFolioAdjustment_Click(System.Object sender, System.EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmTransactionRouting))
                {

                    frmTransactionRouting = (Form)FolioRegistry.CreateObject(mnuFolioRouting.Tag.ToString());
                    frmTransactionRouting.MdiParent = this;
                    frmTransactionRouting.Show();
                    frmTransactionRouting.Location = fLocation;
                }
            }

            // >> CASHIER > Check Out
            Form frmCheckOUT = null;
            private void mnuCashieringCheckOut_Click(System.Object sender, System.EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmCheckOUT))
                {

                    frmCheckOUT = (Form)FolioRegistry.CreateObject(mnuCheckOut.Tag.ToString());
                    frmCheckOUT.MdiParent = this;
                    frmCheckOUT.Show();
                    frmCheckOUT.Location = fLocation;
                }
            }

            // >> CASHIER > Close Shift
            Form frmCloseShift = null;
            private void mnuCloseShift_Click(System.Object sender, System.EventArgs e)
            {
                try
                {

					closeAllForms();

                    if (!isOpen(frmCloseShift))
                    {
                        //if (GlobalVariables.cashDrawerOpen)
                        //{
						object[] objParam = {(object)GlobalVariables.gTerminalID};
						Type[] objParamTypes = {typeof(int)};


                        frmCloseShift = (Form)FolioRegistry.CreateObject(mnuCloseShift.Tag.ToString(),objParam, objParamTypes);
                        frmCloseShift.MdiParent = this;
                        frmCloseShift.Show();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("No cash drawer opened.", "Close Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
                catch // this happens only if CLoseShiftUI is destroyed upon Load
                {
                    frmCloseShift = null;
                }
            }

            // >> FRONT DESK > Reservation > Single
            public Form frmReservationUI = null;
            public void mnuSingleReservation_Click(System.Object sender, System.EventArgs e)
            {
				newIndividualReservation();
            }


            // >> FRONT DESK > Reservation > Group
            Form frmGRPReservationList = null;
            public void mnuGroupReservation_Click(System.Object sender, System.EventArgs e)
            {
                //Close all active forms
                //closeAllForms();

                if (!isOpen(frmGRPReservationList))
                {

                    frmGRPReservationList = (Form)FolioRegistry.CreateObject(mnuGroupReservation.Tag.ToString());
                    frmGRPReservationList.MdiParent = this;
                    frmGRPReservationList.Show();
                    frmGRPReservationList.Location = fLocation;
                }
            }

            // >> FRONT DESK > Room Blocking
            public Form frmRoomBlocking = null;
            public void reloadBlockingForm(DateTime startDate, string oMode, object roomtype, int noOfWeeks)
            {
				////closeAllForms();

				//Type[] paramType ={ typeof(System.String), typeof(System.Object), typeof(System.Int32), typeof(System.DateTime) };
				//object[] paramVal ={ "BLOCKING", roomtype.ToString(), noOfWeeks, startDate };
				//frmRoomBlocking = FolioRegistry.CreateObject(mnuRoomBlocking.Tag.ToString(), paramType, paramVal);
				//frmRoomBlocking.MdiParent = this;
				//frmRoomBlocking.Show();
            }

            public void mnuFrontDeskRoomBlocking_Click(System.Object sender, System.EventArgs e)
            {
				roomCalendarNEWToolStripMenuItem_Click(sender, e);
				//closeAllForms();

				//Type[] paramType = new Type[1];

				//paramType[0] = typeof(System.String);
				//object[] paramVal = new object[1];
				//paramVal[0] = "BLOCKING";
				//frmRoomBlocking = FolioRegistry.CreateObject(mnuRoomBlocking.Tag.ToString(), paramType, paramVal);
				//frmRoomBlocking.MdiParent = this;
				//frmRoomBlocking.Show();
            }

            // >> FRONT DESK > Floor Occupancy
            Form frmFloorOccupancy = null;
            private void mnuFloorOccupancy_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmFloorOccupancy))
                {
                    //Type[] paramType = new Type[1];
                    //paramType[0] = typeof(int);
                    //object[] paramVal = null;
                    //   paramVal[0] = GlobalVariables.HotelId;
                    //paramVal[0] = null;
                    frmFloorOccupancy = (Form)FolioRegistry.CreateObject(mnuFloorOccupancy.Tag.ToString());
                    frmFloorOccupancy.MdiParent = this;
                    frmFloorOccupancy.Show();
                }
            }

            // >> SERVICES > Engineering Job
            Form frmEngineeringJob = null;
            private void mnuEngineeringJob_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmEngineeringJob))
                {

                    frmEngineeringJob = (Form)FolioRegistry.CreateObject(mnuEngineeringJob.Tag.ToString());
                    frmEngineeringJob.MdiParent = this;
                    frmEngineeringJob.Show();
                }
            }

            // >> SERVICES > Housekeeping Job
            Form frmHousekeepingJob = null;
            private void mnuHousekeeping_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmHousekeepingJob))
                {
                    frmHousekeepingJob = (Form)FolioRegistry.CreateObject(mnuHousekeepingJob.Tag.ToString());
                    frmHousekeepingJob.MdiParent = this;
                    frmHousekeepingJob.Show();
                    frmHousekeepingJob.Location = fLocation;
                }
            }

            #endregion

            #region " C O N F I G U R A T I O N "

            // >> ROOM > Rooms
            private Form frmRoom = null;
            private void mnuRooms_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmRoom))
                {

                    frmRoom = (Form)FolioRegistry.CreateObject(mnuRooms.Tag.ToString());

                    frmRoom.MdiParent = this;
                    frmRoom.Show();
                    frmRoom.Location = fLocation;
                }
            }

            // >> ROOM > Room Types
            Form frmRoomType = null;
            private void mnuRoomTypes_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmRoomType))
                {
                    frmRoomType = (Form)FolioRegistry.CreateObject(mnuRoomTypes.Tag.ToString());
                    frmRoomType.MdiParent = this;
                    frmRoomType.Show();
                    frmRoomType.Location = fLocation;
                }
            }

            // >> ROOM > Rate Types
            Form frmRateType = null;
            private void mnuRateTypes_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmRateType))
                {
                    frmRateType = (Form)FolioRegistry.CreateObject(mnuRateTypes.Tag.ToString());
                    frmRateType.MdiParent = this;
                    frmRateType.Show();
                    frmRateType.Location = fLocation;
                }
            }

            // >> ROOM > Rate Codes
            Form frmRateCode = null;
            private void mnuRateCodes_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmRateCode))
                {

                    frmRateCode = (Form)FolioRegistry.CreateObject(mnuRateCodes.Tag.ToString());
                    frmRateCode.MdiParent = this;
                    frmRateCode.Show();
                    frmRateCode.Location = fLocation;
                }
            }

            // >> ROOM > Room Amenities
            Form frmAmenity = null;
            private void mnuRoomAmenities_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmAmenity))
                {

                    frmAmenity = (Form)FolioRegistry.CreateObject(mnuAmenities.Tag.ToString());
                    frmAmenity.MdiParent = this;
                    frmAmenity.Show();
                    frmAmenity.Location = fLocation;
                }
            }

            // >> TRANSACTION > Transaction Types
            Form frmTrasactionType = null;
            private void mnuTransactionTypes_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmTrasactionType))
                {
                    frmTrasactionType = (Form)FolioRegistry.CreateObject(mnuTransactionTypes.Tag.ToString());
                    frmTrasactionType.MdiParent = this;
                    frmTrasactionType.Show();
                    frmTrasactionType.Location = fLocation;
                }
            }

            // >> TRANSACTION > Transaction Codes
            Form frmTrasactionCode = null;
            private void mnuTransactionCodes_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmTrasactionCode))
                {
                    frmTrasactionCode = (Form)FolioRegistry.CreateObject(mnuTransactionCodes.Tag.ToString());
                    frmTrasactionCode.MdiParent = this;
                    frmTrasactionCode.Show();
                    frmTrasactionCode.Location = fLocation;
                }
            }

            // >> ENGINEERING SERVICES
            Form frmEngineeringService = null;
            private void mnuEngineering_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmEngineeringService))
                {
                    frmEngineeringService = (Form)FolioRegistry.CreateObject(mnuEngineeringServices.Tag.ToString());
                    frmEngineeringService.MdiParent = this;
                    frmEngineeringService.Show();
                    frmEngineeringService.Location = fLocation;
                }
            }

            // >> HOUSEKEEPERS
            Form frmHousekeeper = null;
            private void mnuConfigurationHousekeepers_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmHousekeeper))
                {
                    frmHousekeeper = (Form)FolioRegistry.CreateObject(mnuHousekeepers.Tag.ToString());
                    frmHousekeeper.MdiParent = this;
                    frmHousekeeper.Show();
                    frmHousekeeper.Location = fLocation;
                }
            }

            // >> HOTEL > Floor Plan
            Form frmFloorPlan = null;
            private void mnuFloorPlan_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmFloorPlan))
                {
                    frmFloorPlan = (Form)FolioRegistry.CreateObject(mnuFloorPlan.Tag.ToString());
                    frmFloorPlan.MdiParent = this;
                    frmFloorPlan.Show();
                    frmFloorPlan.Location = fLocation;
                }
            }


            // >> SYSTEM USERS
            private void mnuSystemUsers_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmSystemUsers))
                {
                    frmSystemUsers = new Security.Presentation.UserUI(connectionString);
                    frmSystemUsers.MdiParent = this;
                    frmSystemUsers.Show();
                    frmSystemUsers.Location = fLocation;
                }
            }

            #endregion

            #region " R E P O R T S "


            //Function that gets a property of an object
            private bool setReportSource(Form frm, object rptSource)
            {
                CrystalReportViewer cv = null;
                foreach (Control ct in frm.Controls)
                {
                    if (ct is CrystalReportViewer)
                    {
                        cv = (CrystalReportViewer)ct;
                        cv.ReportSource = rptSource;
                        return true;
                    }
                }
                return false;

            }
            // >> GUEST > Arrival

            private Form createViewerForm()
            {
                Type t = FolioRegistry.GetTypeByName("Jinisys.Hotel.Reports.Presentation.ReportViewer");
                ConstructorInfo ci = t.GetConstructor(System.Type.EmptyTypes);
                return ci.Invoke(null) as Form;
            }
            bool isFacadeCreated = false;
            object reportFacade = null;
            private void createReportFacade()
            {
                if (!isFacadeCreated)
                {

                    reportFacade = FolioRegistry.CreateObject("Jinisys.Hotel.Reports.BusinessLayer.ReportFacade");
                    isFacadeCreated = true;
                }

            }
            private void showReport(string facadeMethodName)
            {
                Form frmReportViewer = createViewerForm();
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                MethodInfo mi = reportFacade.GetType().GetMethod(facadeMethodName);
                if (setReportSource(frmReportViewer, mi.Invoke(reportFacade, null)))
                {
                    frmReportViewer.MdiParent = this;
                    frmReportViewer.Refresh();
                    frmReportViewer.Show();
                    frmReportViewer.Location = fLocation;
                }
                this.Cursor = Cursors.Default;
            }

            private void showReport(string facadeMethodName, object[] pa)
            {
                Form frmReportViewer = createViewerForm();
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                MethodInfo mi = reportFacade.GetType().GetMethod(facadeMethodName);
                if (setReportSource(frmReportViewer, mi.Invoke(reportFacade, pa)))
                {
                    frmReportViewer.MdiParent = this;
                    frmReportViewer.Refresh();
                    frmReportViewer.Show();
                    frmReportViewer.Location = fLocation;
                }
                this.Cursor = Cursors.Default;
            }


            private void mnuGuestArrivalsReport_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "ACTUAL GUEST ARRIVAL" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();
                }
            }

            // >> GUEST > Departure
            private void mnuGuestDeparture_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "ACTUAL GUEST DEPARTURE" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();

                }
                //showReport("getActualDepartureReport");
            }

            private void mnuReportsInHouseGuests_Click(System.Object sender, System.EventArgs e)
            {
                showReport("getInHouseGuests");
            }

            // >> Expected Arrivals
            private void mnuReportExpectedArrivals_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "EXPECTED GUEST ARRIVAL" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();

                }
                //showReport("getExpectedArrivalReport");
            }
            // >> Expected Departure
            private void mnuReportExpectedDeparture_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "EXPECTED GUEST DEPARTURE" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();

                }
                //showReport("getExpectedDepartureReport");
            }

            // >> ROOM > Transfer
            private void mnuReportsRoomTransfer_Click(System.Object sender, System.EventArgs e)
            {
                showReport("getRoomTransferReport");
            }

            // >> ROOM AVAILABILITY
            private void mnuReportRoomAvailability_Click(System.Object sender, System.EventArgs e)
            {
                showReport("getRoomAvailability");
            }


            // >> ROOM > Scheduled For Engineering Job
            private void mnuReportRoomForEngineeringJob_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "OUT OF ORDER ROOMS" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();

                }
                //showReport("getOutOfOrderRooms"); ;
            }

            // >> ROOM > Room Status
            private void mnuRoomStatus_Click(System.Object sender, System.EventArgs e)
            {
                showReport("getRoomCleaningStatus");
            }


            // >> TRANSACTIONS > All
            Form frmReportDateParam = null;
            private void mnuAllTransactionsReport_Click(System.Object sender, System.EventArgs e)
            {

                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "TRANSACTION REGISTER" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();

                }

                //showReport("getTransactionRegisterReport");
                //showReport("getTransactionRegisterReport");

            }

            #endregion

            #region " E V E N T S "
            //jlo 8-24-2010
            //added for translations
            private DataTable loTranslations;
            private void MDIMainUI_Load(object sender, System.EventArgs e)
            {
                try
                {
                    try
                    {
                        this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\\bg.png");
                        this.BackgroundImageLayout = ImageLayout.Center;
                    }
                    catch { }

                    // Riyadh 05/13/2015
                    // Removed for academe

                    //bool _validLicenseKey = false;
                    //GlobalVariables.APP_LICENSE_KEY = ConfigurationManager.AppSettings.Get("LicenseKey");

                    //_validLicenseKey = checkApplicationLicenseKey();
                    //if (_validLicenseKey == false)
                    //{
                    //    if (MessageBox.Show("Invalid License Key. Please contact your vendor.    \n\nClick on YES to enter License Key or NO to use Trial Version", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //    {
                    //        System.Diagnostics.Process.Start("ConfigLoader.exe");
                    //        Application.Exit();
                    //        return;
                    //    }
                    //}

                    int _x = (this.Width - this.lblSysTime.Width) - 20;
                    this.lblSysTime.Location = new Point(_x, this.lblSysTime.Location.Y);
                    this.tsmReports.Enabled = false;

                    paramType[0] = typeof(System.String);
                    String[] param = new String[1];
                    param[0] = connectionString;
                    Form objSplash = FolioRegistry.CreateObject("Jinisys.Hotel.Security.Presentation.SplashScreenUI", paramType, param);
                    objSplash.ShowDialog(this);

                    paramType[0] = typeof(MySqlConnection);
                    param1[0] = GlobalVariables.gPersistentConnection;
                    Form LogInUI = FolioRegistry.CreateObject("Jinisys.Hotel.Security.Presentation.LogInUI", paramType, param1);
                    LogInUI.ShowDialog(this);

                    // Riyadh 05/13/2015
                    // Added for Academe

                    #region "ACADEME LICENSE AND CONFIGURATION"
                    // License Duration
                    DateTime _licenseStart = new DateTime(2022, 10, 11);
                    DateTime _licenseEnd = new DateTime(2023, 10, 11);

                    // School Details
                    string _schoolName = "Saint Vincent’s College";
                    string _schoolAddress1 = "7100 Padre Ramon Street Estaka";
                    string _schoolAddress2 = "Dipolog City Zamboanga del Norte Philippines";
                    string _schoolWebsite = "https://svc.edu.ph/";
                    string _schoolContactNumber = "Tel. No.: (065) 212-6292";
                    #endregion

                    // Riyadh 05/13/2015
                    // Added for Academe

                    #region "ACADEME"
                    // Configuration Variables override
                    ConfigVariables.gAppTitle = "Event Academe [" + _schoolName + "]";
                    ConfigVariables.gReportOrganization = _schoolName;
                    ConfigVariables.gReportAddress1 = _schoolAddress1;
                    ConfigVariables.gReportAddress2 = _schoolAddress2;
                    ConfigVariables.gReportContactNo = _schoolContactNumber;
                    ConfigVariables.gReportWebsite = _schoolWebsite;

                    // License Check
                    if (!((DateTime.Now.Date >= _licenseStart.Date) && (DateTime.Now.Date <= _licenseEnd.Date)))
                    {
                        MessageBox.Show("Sorry, this software has expired. Please contact your vendor to continue.", "License Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                        return;
                    }
                    #endregion

                    loUser = (Jinisys.Hotel.Security.BusinessLayer.User)GlobalVariables.goUser;
                    if (loUser != null)
                    {
                        //jlo 8-24-2010
                        Translator _translator = new Translator();
                        loTranslations = _translator.getTranslations();
                        //jlo

                        //>> disable menus
                        this.setDisableMenuItems();
                        //>> Set USER MENUS()
                        this.setUserMenus();
                        //>> Set USER TOOLBARS
                        this.setUserToolbars();
                        AuditFacade oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
                        string AuditDate = "";
                        if (ConfigVariables.gNightAuditEnabled == "true")
                        {
                            AuditDate = oAuditFacade.getCurrentAuditDate();
                        }
                        else
                        {
                            AuditDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                        }

                        GlobalVariables.gAuditDate = AuditDate;

                        auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

                        // Riyadh 05/13/2015
                        // Removed for academe

                        //// checks if TRIAL VERSION [comment for LICENSED VERSION]>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //if (_validLicenseKey == false)
                        //{
                        //    if (DateTime.Parse(GlobalVariables.gAuditDate) >= GlobalVariables.gExpiryDate)
                        //    {
                        //        MessageBox.Show("Trial version expired.\r\n\r\nPlease contact:\r\n\r\n   Jinisys Softwares Corporation\r\n   Cebu City, Philippines\r\n   Tel. (032) 2320485\r\n\r\nThank you.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        Application.Exit();
                        //        this.Close();
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("You are currently using Event Plus Trial Version.    \nThis will expire on " + GlobalVariables.gExpiryDate.ToString("MMMM dd, yyyy"), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //}
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>



                        ///// Check for Application Version & Build No
                        ///// Application Version & Database version should be the same
                        ///// 
                        //if (!(GlobalVariables.APP_VERSION == ConfigVariables.gAppVersion &&
                        //    GlobalVariables.APP_BUILD_NO == ConfigVariables.gAppBuildNo))
                        //{
                        //    MessageBox.Show("Database version error.\r\n\r\nPlease contact system administrator", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    Application.Exit();
                        //    this.Close();
                        //    return;
                        //}

                        //commented next line if firstname is to be shown
                        GlobalVariables.gLoggedOnUser = loUser.UserId;
                        //GlobalVariables.gLoggedOnUser = loUser.FirstName;
                        GlobalVariables.gHotelId = System.Convert.ToInt32(loUser.HotelId);

                        pnlUser.Text = " User : " + loUser.UserId;
                        pnlUserLogTime.Text = " Time Logged: " + string.Format("{0:hh:mm:ss tt}", DateTime.Now);
                        pnlDate.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));

                        this.Text = ConfigVariables.gAppTitle;
                        this.Text += " Version " + ConfigVariables.gAppVersion;
                        this.pictHotelLogo.Image = Image.FromFile(ConfigVariables.gAppLogo);


                        loCalendarFacade = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.BusinessLayer.CalendarFacade");
                        loRoomBlockFacade = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.BusinessLayer.RoomBlockFacade");
                        loCurrencyFacade = FolioRegistry.CreateObject("Jinisys.Hotel.ConfigurationHotel.BusinessLayer.CurrencyCodeFacade");


                        loOpenShiftFacade = FolioRegistry.CreateObject("Jinisys.Hotel.Cashier.BusinessLayer.CashTerminalFacade");

                        plotCurrentDayRoomStatus();
                        plotFunctionRoomStatus();

                        //Kevin 
                        try
                        {
                            GlobalVariables.gTerminalID = int.Parse(ConfigurationManager.AppSettings.Get("TerminalId"));
                            this.pnlTerminal.Text = " Terminal: " + GlobalVariables.gTerminalID;
                            this.pnlApplication.Text = "Event Plus Professional Edition Version " + GlobalVariables.APP_VERSION + " Build " + GlobalVariables.APP_BUILD_NO;

                        }
                        catch { }

                        //Microsoft.Win32.RegistryKey regkey;

                        //regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("TerminalID", true);
                        //if (regkey != null)
                        //{
                        //    GlobalVariables.gTerminalID = System.Convert.ToInt32(regkey.GetValue("TerminalID", true));

                        //}
                        //else
                        //{
                        //    if (GlobalVariables.gLoggedOnUser == "ADMIN")
                        //    {
                        //        MessageBox.Show("Terminal ID of this Computer is not set.." + "\r\n" + "Please set Terminal ID now..", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        mnuSetTerminal_Click(sender, e);

                        //        // >> DISABLE SA SYSTEM USER>>>
                        //        //Me.mnuSystemUsers.Enabled = False

                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Terminal ID of this Computer is not set.." + "\r\n" + "Please contact System Administrator to set Terminal ID.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        this.mnuSetTerminal.Enabled = false;
                        //        this.mnuSystemUsers.Enabled = true;
                        //    }
                        //}


                        /* This is to get the Current Cash Drawer open
                         * 
                         */
                        GlobalVariables.gCashDrawerOpen = false;
                        GlobalVariables.gShiftCode = 0;

                        DataSet dsTerminal = new DataSet();
                        dsTerminal = (DataSet)loOpenShiftFacade.GetType().GetMethod("GetCashierTerminals").Invoke(loOpenShiftFacade, null);

                        foreach (DataRow dRow in dsTerminal.Tables[0].Rows)
                        {
                            if (dRow["Status"].ToString() == "OPEN" && dRow["UpdatedBy"].ToString().ToUpper() == GlobalVariables.gLoggedOnUser.ToUpper())
                            {
                                if (int.Parse(dRow["TerminalId"].ToString()) == GlobalVariables.gTerminalID)
                                {
                                    GlobalVariables.gCashDrawerOpen = true;
                                    GlobalVariables.gShiftCode = int.Parse(dRow["ShiftCode"].ToString());
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("You have opened your cash drawer at Terminal " + dRow["TerminalId"].ToString() + "\r\nYou can't transact any payment in this Terminal.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    GlobalVariables.gCashDrawerOpen = false;
                                }
                            }
                        }

                    }
                    

                    this.tmrSysTime.Enabled = true;

                    string hasHousekeepingInterface = ConfigVariables.gIsHousekeepingIntegrated;
                    if (hasHousekeepingInterface == "YES")
                    {
                        this.tmrUpdateRoomStat.Enabled = true;
                    }
                    else
                    {
                        this.tmrUpdateRoomStat.Enabled = false;
                    }

                    /* RFE#
                     * for REPORT IMAGE optimization
                     * load report to BusinessSharedClasses->reportImage
                     * Jerome, March 17, 2008, Jinisys Softwares
                     */

                    byte[] rptImage = null;
                    string imgPath = ConfigVariables.gReportLogo;

                    try
                    {
                        rptImage = File.ReadAllBytes(imgPath);
                        GlobalVariables.gReportImage = rptImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading report image file.\r\nException: " + ex.Message + ".\r\nPlease contact system administrator.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // END RFE#

                    //SCR-001, Golden Prince
                    // added by: Jerome, April 14, 2008
                    string showAvailability = ConfigVariables.gShowRoomAvailabilityAtStartUp;
                    if (showAvailability == "YES")
                    {
                        mnuAvailableRoomsToday_Click(this, new EventArgs());
                    }
                    //end SCR-001

                    //>>check if panel has more than 50 rooms
                    if (vsDayPlo.Rows > 15)
                    {
                        pictHotelLogo.Size = new Size(159, 40);
                    }

                    try
                    {
                        //SCR-001, Golden Prince
                        // added by: Jerome, April 14, 2008
                        string dbServer = GlobalVariables.gPersistentConnection.DataSource.ToString().ToUpper();
                        string str = " - OFFLINE";
                        if (dbServer != "LOCALHOST")
                        {
                            str = " - ONLINE";
                        }

                        this.statDBConnection.Text = " Server : " + dbServer + str;
                        //end SCR-001
                    }
                    catch
                    { }

                    //>> protect Config File
                    protectConfigFile();
                    //jlo 6-10-10 emm only config
                    if (ConfigVariables.gIsEMMOnly == "true")
                    {
                        this.mnuSingleReservation.Visible = false;
                        this.mnuSingleReservation.ShortcutKeys = Keys.None;
                        // for Marketing Reservation by Kevin
                        //this.mnuSharedReservation.Visible = false;
                        //this.mnuSharedReservation.ShortcutKeys = Keys.None;
                        this.mnuGroupBlocking.Visible = false;
                        this.mnuGroupBlocking.ShortcutKeys = Keys.None;
                        this.mnuAvailableRoomsToday.Visible = false;
                        this.mnuAvailableRoomsToday.ShortcutKeys = Keys.None;
                        this.roomAvailabilityToolStripMenuItem.Visible = false;
                        this.MenuReservationNoRoom.Visible = false;
                        this.mnuWaitListReservation.Visible = false;
                        this.toolStripMenuItem10.Visible = false;
                        this.toolStripMenuItem58.Visible = false;
                        this.toolStripShare.Visible = false;
                        this.toolStripGroupBlock.Visible = false;
                        this.toolStripAvailableRoomsToday.Visible = false;
                        this.mnuConfigDrivers.Visible = false;
                        this.mnuAgents.Visible = false;
                        this.mnuHousekeepers.Visible = false;
                        this.mnuHousekeepingJob.Visible = false;
                        this.housekeepingStepProcedureToolStripMenuItem.Visible = false;
                        this.mnuGuestPrivileges.Visible = false;
                        this.appliedRatesToolStripMenuItem.Visible = false;
                        this.captureImageToolStripMenuItem.Visible = false;
                        this.cityLedgerToolStripMenuItem.Visible = false;
                        this.mnuRestaurant.Visible = false;
                        this.housekeepingToolStripMenuItem.Visible = false;
                        this.cityLedgerToolStripMenuItem1.Visible = false;
                        this.cityTransferToolStripMenuItem.Visible = false;
                        this.guestByRateCodeToolStripMenuItem.Visible = false;
                        this.toolStripMenuItem41.Visible = false;
                        this.toolStripMenuItem49.Visible = false;
                        this.mnuInquiryHotelRevenue.Visible = false;
                        this.toolStripMenuItem21.Visible = false;
                        this.toolStripMenuItem8.Visible = false;
                        this.mnuInHouseGuest.Visible = false;
                        this.mnuHighBalanceGuests.Visible = false;
                        this.guestLedgerToolStripMenuItem.Visible = false;
                        this.roomingListToolStripMenuItem.Visible = false;
                        this.nationalityReportToolStripMenuItem.Visible = false;
                        this.toolStripMenuItem32.Visible = false;
                        this.toolStripMenuItem35.Visible = false;
                        this.mnuCityTransferTransactions.Visible = false;
                        this.mnuVoidedTransactions.Visible = false;
                        this.mnuDailyHotelRevenueReport.Visible = false;
                        this.mnuRoomTransfer.Visible = false;
                        //this.mnuRoomTypes.Visible = false;
                        this.tabRooms.Controls.Remove(this.tabPage1);
                        this.minibarToolStripMenuItem.Visible = false;
                        this.toolStripMenuItem45.Visible = false;
                    }
                    //jlo

                    //jlo 8-24-10 night audit is disabled scr 00153
                    if (ConfigVariables.gNightAuditEnabled != "true")
                    {
                        this.mnuDayEndClosing.Visible = false;
                        this.mnuDayEndClosing.ShortcutKeys = Keys.None;
                        this.mnuConfigureDayEndClosing.Visible = false;
                        this.mnuChangeAuditDate.Visible = false;
                        this.mnuAudit.Visible = false;
                    }
                    //jlo

                    //jlo 8-24-10 cashiering is disabled scr 00153
                    if (ConfigVariables.gCashieringEnabled != "true")
                    {
                        this.mnuFolioLedgers.Visible = false;
                        this.mnuFolioLedgers.ShortcutKeys = Keys.None;
                        this.mnuCheckOut.Visible = false;
                        this.mnuCheckOut.ShortcutKeys = Keys.None;
                        this.mnuFolioRouting.Visible = false;
                        this.mnuFolioRouting.ShortcutKeys = Keys.None;
                        this.mnuPostTransactionNonGuest.Visible = false;
                        this.mnuPostTransactionNonGuest.ShortcutKeys = Keys.None;
                       this.mnuCloseShift.Visible = false;
                        this.mnuOpenShift.Visible = false;
                        this.mnuCashiering.Visible = false;
                        this.toolStripRoute.Visible = false;
                        this.toolStripFolioLedger.Visible = false;
                        this.toolStripMenuItem34.Visible = false;
                        this.cmuTransactionsPerCashier.Visible = false;
                    }
                    //jlo


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            private void mnuTileHorizontal_Click(System.Object sender, System.EventArgs e)
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }

            private void mnuTileVertical_Click(object sender, System.EventArgs e)
            {
                this.LayoutMdi(MdiLayout.TileVertical);
            }

            private void closeAllWindowToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.closeAllForms();
            }

            private void mnuArrangeIcon_Click(object sender, System.EventArgs e)
            {
                this.LayoutMdi(MdiLayout.ArrangeIcons);
            }

            private void mnuCascade_Click(object sender, System.EventArgs e)
            {
                this.LayoutMdi(MdiLayout.Cascade);
            }

            private void mnuSetTerminal_Click(System.Object sender, System.EventArgs e)
            {
                if (GlobalVariables.gLoggedOnUser.ToUpper() == "ADMIN")
                {
                    if (GlobalVariables.gTerminalID == 0)
                    {
                        frmTerminal = new Jinisys.Hotel.Security.Presentation.TerminalUI();
                        frmTerminal.ShowDialog();
                    }
                    else
                    {
                        frmTerminal = new Jinisys.Hotel.Security.Presentation.TerminalUI(GlobalVariables.gTerminalID);
                        frmTerminal.MdiParent = this;
                        frmTerminal.Show();
                    }
                }
            }

            private void mnuExit_Click(System.Object sender, System.EventArgs e)
            {
				this.Close();
            }

            private void mnuLogOff_Click(System.Object sender, System.EventArgs e)
            {

				string _msg = "Are you sure you want to log off ?     ";
				MessageBoxIcon msgIcon = MessageBoxIcon.Question;

				if (GlobalVariables.gCashDrawerOpen && ConfigVariables.gCashieringEnabled == "true")
				{
					_msg = "\r\nWarning: Cash Drawer is still open.\r\n\r\n\r\nAre you sure you want to log off ?    \r\n\r\n";
					msgIcon = MessageBoxIcon.Exclamation;
				}

                DialogResult res;
				res = MessageBox.Show(_msg, "Confirm", MessageBoxButtons.YesNo, msgIcon);
                if (res == DialogResult.Yes)
                {
                    GlobalVariables.gLoggedOnUser = null;
                    GlobalVariables.gUserDesignation = null;
                    this.closeAllForms();
                    this.pnlUser.Text = "User:";
                    this.pnlUserLogTime.Text = "00:00:00";
                    MDIMainUI_Load(sender, e);
                }
            }

            private void mnuPostToLedger_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmPostToLedger))
                {
                    //frmPostToLedger = (Form)FolioRegistry.CreateObject(mnuPostToLedger.Tag.ToString());
                    frmPostToLedger.MdiParent = this;
                    frmPostToLedger.Show();
                }
            }

			//private void mnuSalesSummary_Click(System.Object sender, System.EventArgs e)
			//{
			//    if (!isOpen(frmReportDateParam))
			//    {
			//        frmReportDateParam = (Form)FolioRegistry.CreateObject(dailySalesToolStripMenuItem.Tag.ToString(), new object[] { "TRANSACTION SUMMARY" }, new Type[] { typeof(System.String) });
			//        frmReportDateParam.MdiParent = this;
			//        frmReportDateParam.Show();

			//    }
			//    // object[] pa=new object[] { DateTime.Now };
			//    //showReport("getSalesSummary",pa);
			//}

            private void mnuUtilitiesReportGenerator_Click(System.Object sender, System.EventArgs e)
            {
                closeAllForms();

                if (!isOpen(frmReportGenerator))
                {
                    frmReportGenerator = (Form)FolioRegistry.CreateObject(this.mnuReportGenerator.Tag.ToString());
                    frmReportGenerator.MdiParent = this;
                    frmReportGenerator.Top = 0;
                    frmReportGenerator.Left = 0;
                    frmReportGenerator.Show();
                }
            }

			//private void vsDayPlo_DblClick(object sender, System.EventArgs e)
			//{
			//    string roomId;

			//    vsDayPlo.Select(vsDayPlo.Row, vsDayPlo.Col);

			//    roomId = this.vsDayPlo.get_TextMatrix(this.vsDayPlo.Row, this.vsDayPlo.Col);

			//    Form FolioUI = null;
			//    if (vsDayPlo.CellBackColor.Equals(Color.Aqua) || vsDayPlo.CellBackColor.Equals(Color.DodgerBlue))
			//    {

			//        Type[] paramType = new Type[1];
			//        paramType[0] = typeof(MySqlConnection);
			//        MySqlConnection[] paramVal = new MySqlConnection[1];
			//        paramVal[0] = GlobalVariables.gPersistentConnection;
			//        FolioUI = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI", paramType, paramVal);
			//        FolioUI.GetType().GetProperty("AccountType").SetValue(FolioUI, "PERSONAL", null);
			//        // FolioUI.AccountType = "GUEST";
			//        FolioUI.GetType().GetProperty("Flag").SetValue(FolioUI, "Edit", null);
			//        //FolioUI.Flag = "Edit";


			//        FolioUI.MdiParent = this;
			//        FolioUI.Top = 0;
			//        FolioUI.Left = 0;
			//        FolioUI.Show();

			//    }
			//    else if (vsDayPlo.CellBackColor.Equals(Color.White) || vsDayPlo.CellBackColor.Equals(Color.Black))
			//    {
			//        FolioUI.GetType().GetProperty("AccountType").SetValue(FolioUI, "PERSONAL", null);
			//        FolioUI.GetType().GetProperty("Flag").SetValue(FolioUI, "New", null);

			//        Type[] paramType = new Type[2];
			//        paramType[0] = typeof(System.String);
			//        paramType[1] = typeof(System.String);

			//        Object[] paramVal = new object[2];
			//        paramVal[0] = "Quick Reservation";
			//        paramVal[1] = roomId;

			//        FolioUI = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI", paramType, paramVal);
			//        //FolioUI = new Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI("Quick Reservation", roomId, GlobalVariables.PersistentConnection);

			//        FolioUI.MdiParent = this;
			//        FolioUI.Top = 0;
			//        FolioUI.Left = 0;
			//        FolioUI.Show();
			//    }
			//}

            private void MnuShare_Click(System.Object sender, System.EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmShareFolioUI))
                {
                    //Type[] paramType = { typeof(ReservationOperationMode) };
                    //object[] paramVal = { ReservationOperationMode.NewShareFolio };

                    //frmShareFolioUI = (Form)FolioRegistry.CreateObject(this.mnuSharedReservation.Tag.ToString(), paramType, paramVal);
					
                    //frmShareFolioUI.MdiParent = this;
                    //frmShareFolioUI.Top = 0;
                    //frmShareFolioUI.Left = 0;
                    //frmShareFolioUI.Show();

                    frmShareFolioUI = (Form)FolioRegistry.CreateObject(mnuSharedReservation.Tag.ToString());
                    frmShareFolioUI.MdiParent = this;
                    frmShareFolioUI.WindowState = FormWindowState.Maximized;
                    frmShareFolioUI.Show();
                }
            }

            private void mnuGrpBlocking_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmGroupBlocking))
                {

                    frmGroupBlocking = (Form)FolioRegistry.CreateObject(mnuGroupBlocking.Tag.ToString());
                    frmGroupBlocking.MdiParent = this;
                    frmGroupBlocking.Show();

                }
            }

            private void mnuCurrencyCodes_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmCurrencyCodes))
                {

                    frmCurrencyCodes = (Form)FolioRegistry.CreateObject(mnuCurrencyCodes.Tag.ToString());
                    frmCurrencyCodes.MdiParent = this;
                    frmCurrencyCodes.Show();
                }
            }

            private void mnuDepartment_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmDepartment))
                {

                    frmDepartment = (Form)FolioRegistry.CreateObject(mnuDepartments.Tag.ToString());
                    frmDepartment.MdiParent = this;
                    frmDepartment.Show();
                }
            }

            private void mnuPackages_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmPackages))
                {


                    frmPackages = (Form)FolioRegistry.CreateObject(mnuPromos.Tag.ToString());
                    frmPackages.MdiParent = this;

                    frmPackages.Show();
                }
            }

            private void mnuPrivileges_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmPrivileges))
                {

                    frmPrivileges = (Form)FolioRegistry.CreateObject(mnuGuestPrivileges.Tag.ToString());
                    frmPrivileges.MdiParent = this;

                    frmPrivileges.Show();
                }
            }

            private void mnuHotelInfo_Click(System.Object sender, System.EventArgs e)
            {
                if (!isOpen(frmHotel))
                {

                    frmHotel = (Form)FolioRegistry.CreateObject(mnuHotelInfo.Tag.ToString());
                    frmHotel.MdiParent = this;

                    frmHotel.Show();
                }
            }

            private void mnuSystemRole_Click(System.Object sender, System.EventArgs e)
            {
				this.Cursor = Cursors.WaitCursor;

                if (!isOpen(frmSysRole))
                {

                    frmSysRole = new Jinisys.Hotel.Security.Presentation.SystemRoleUI(GlobalVariables.gPersistentConnection);
                    frmSysRole.MdiParent = this;

                    frmSysRole.Show();
                }

				this.Cursor = Cursors.Default ;
            }

            private new void FormClosing(System.Object sender, System.ComponentModel.CancelEventArgs e)
            {
				string _msg = "Are you sure you want to exit ?     ";
				MessageBoxIcon msgIcon = MessageBoxIcon.Question;

				if (GlobalVariables.gCashDrawerOpen && ConfigVariables.gCashieringEnabled == "true")
				{
					_msg = "\r\nWarning: Cash Drawer is still open.\r\n\r\n\r\nAre you sure you want to close Event Plus ?    \r\n\r\n";
					msgIcon = MessageBoxIcon.Exclamation;
				}

				DialogResult res;
				res = MessageBox.Show(_msg, "Confirm", MessageBoxButtons.YesNo, msgIcon);
				if (res == DialogResult.Yes)
				{
					e.Cancel = false;
                    GlobalVariables.gPersistentConnection.Close();
                    GlobalVariables.gConnectionForBackGroundWorker.Close();
                    SAPCompany _oSapCompany = new SAPCompany();
                    if (GlobalVariables.goIsConnectedToBackOffice == true)
                    {
                        _oSapCompany.disconnectFromSAP();
                    }


					Application.Exit();
				}
				else
				{
					e.Cancel = true;
				}

            }

            private void mnuLockScreen_Click(System.Object sender, System.EventArgs e)
            {
                Jinisys.Hotel.Security.Presentation.LockScreenUI lockSreenUI = new Jinisys.Hotel.Security.Presentation.LockScreenUI(loUser);
                lockSreenUI.ShowDialog(this);
            }

            private void toolbarMain_ButtonClick(string buttonTag)
            {
                try
                {
                    string methodName = "";

                    switch (buttonTag)
                    {
                        case "New":

                            methodName = "NewEntry";
                            break;

                        case "Open":

                            break;

                        case "Save":

                            methodName = "SaveEntry";
                            break;

                        case "Print":

                            methodName = "PrintReport";
                            break;

                        case "LockScreen":

                            //      mnuLockScreen_Click(sender, e);
                            break;

                        case "Close":

                            this.ActiveMdiChild.Close();
                            return;
                    }

                    if (this.ActiveMdiChild != null)
                    {
                        Type objectType = this.ActiveMdiChild.GetType();
                        MethodInfo[] objMethods = objectType.GetMethods();
                        foreach (MethodInfo method in objMethods)
                        {
                            if (method.Name.ToUpper() == methodName.ToUpper())
                            {
                                method.Invoke(this.ActiveMdiChild, null);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception on toolbarMain_ButtonClick(string buttonTag) at MDIMainUI! Message:" + ex.Message);
                }

            }

            private void MenuItem15_Click(System.Object sender, System.EventArgs e)
            {
                Form1 form1 = new Form1(GlobalVariables.gPersistentConnection);
                form1.MdiParent = this;
                form1.Show();
            }

            private void vsDayPlo_DoubleClick(object sender, System.EventArgs e)
            {
                try
                {

                    if (this.mnuSingleReservation.Enabled == false)
                        return;

                    //closeAllForms();

                    string _roomNo = "";

                    vsDayPlo.Select(vsDayPlo.Row, vsDayPlo.Col);

                    _roomNo = this.vsDayPlo.get_TextMatrix(this.vsDayPlo.Row, this.vsDayPlo.Col);

                    Form oFolioUI = null;
                    if (cellColor.Equals(Color.Aqua) || cellColor.Equals(Color.DodgerBlue) || cellColor.Equals(Color.Gold))
                    {
                        string eventType = "";
                        if (cellColor.Equals(Color.Aqua) || cellColor.Equals(Color.Gold))
                        {
                            eventType = "IN HOUSE";
                        }
                        else
                        {
                            eventType = "RESERVATION";
                        }


                        Type[] paramType = { typeof(ReservationOperationMode) , typeof(System.String) };
                        object[] paramVal ={ ReservationOperationMode.ViewFolioInformation, getFolioId(_roomNo, eventType) };

                        oFolioUI = FolioRegistry.CreateObject(mnuSingleReservation.Tag.ToString(), paramType, paramVal);
                        oFolioUI.MdiParent = this;
                        oFolioUI.Top = 0;
                        oFolioUI.Left = 0;
                        oFolioUI.Show();

                    }
                    else if (cellColor.Equals(Color.White) || cellColor.Equals(Color.Black))
                    {
                        Type[] paramType = { typeof(System.String) };
                        object[] paramVal ={ _roomNo };

                        oFolioUI = FolioRegistry.CreateObject(mnuSingleReservation.Tag.ToString(), paramType, paramVal);
                        
                        oFolioUI.MdiParent = this;
                        oFolioUI.Top = 0;
                        oFolioUI.Left = 0;
                        oFolioUI.Show();
                    }
                    else if (cellColor.Equals(Color.GreenYellow))
                    {
                        MessageBox.Show("Room is out of order.\r\nSorry for the inconvenience.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception) { }
            }

            private void toolBar_Click(object sender, EventArgs e)
            {

                ToolStripButton tButton = sender as ToolStripButton;
                toolbarMain_ButtonClick(tButton.Tag.ToString());

            }

            private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
            {

                //if (!isOpen(frmBackUp))
                //{

                    //frmBackUp = (Form)FolioRegistry.CreateObject(backupDatabaseToolStripMenuItem.Tag.ToString());

                    //frmBackUp.MdiParent = this;
                    //frmBackUp.Show();
                    //frmBackUp.Location = fLocation;
                   

                //}

                DialogResult rsp = MessageBox.Show("Backup database locally?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {

                    //string _backupLink = Application.StartupPath + "\\backup_link.lnk";

                    //System.Diagnostics.Process.Start(_backupLink);

                    //>> do Database Backup
                    try
                    {
                        //new Backup Database process Clark 09.26.2011
                        backupDatabase();

                        //old Backup Database process Clark 09.26.2011
                        //string _backUpBATFile = Application.StartupPath + "\\backup.bat";

                        //string _fileName = Application.StartupPath + "\\DB Backup\\" + GlobalVariables.gAuditDate.Replace("-", "");
                        //string _db = GlobalVariables.gPersistentConnection.Database;
                        //string _dbUser = GlobalVariables.gPersistentConnection.Database;
                        //string _dbPassword = GlobalVariables.gPersistentConnection.Database;
                        //string _dbHost = GlobalVariables.gPersistentConnection.DataSource;

                        //string _connectionStr = ConfigurationManager.AppSettings.Get("connection");
                        //string[] strArr = _connectionStr.Split(';');
                        //foreach (string strTemp in strArr)
                        //{
                        //    if (strTemp.StartsWith("user id"))
                        //    {
                        //        _dbUser = strTemp.Substring(strTemp.IndexOf('=') + 1);
                        //    }
                        //    else if (strTemp.StartsWith("password"))
                        //    {
                        //        _dbPassword = strTemp.Substring(strTemp.IndexOf('=') + 1);
                        //    }
                        //}

                        //StreamReader strReader = new StreamReader(Application.StartupPath + "\\backup.bat");
                        //string strorig = strReader.ReadToEnd();
                        //string str;
                        //str = string.Copy(strorig);
                        ////str = str.Replace("%dbname%", _db);
                        ////str = str.Replace("%fname%", _fileName);
                        //str = str.Replace("%user%", _dbUser);
                        //str = str.Replace("%dbpass%", _dbPassword);
                        //str = str.Replace("%dbHost%", _dbHost);
                        //str = str.Replace("%fname%", _fileName);

                        ////MessageBox.Show(str);
                        //strReader.Close();
                        //StreamWriter strWriter = new StreamWriter(_backUpBATFile);
                        //strWriter.Write(str);
                        //strWriter.Close();
                        //System.Diagnostics.Process.Start(_backUpBATFile);
                        //System.Threading.Thread.Sleep(2000);
                        //strWriter = new StreamWriter(_backUpBATFile);
                        //strWriter.Write(strorig);
                        //strWriter.Close();

                        MessageBox.Show("Event Plus Database Backup Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //>> end Database Backup
                }//end if

            }

            //Clark 09.26.2011 copied from folio plus
            public string backupDatabase()
            {
                try
                {
                    string filePath = Application.StartupPath + @"//Backup//";
                    string _connectionString = ConfigurationManager.AppSettings.Get("connection");
                    string _error = "";
                    string fileName = "Folio_" + DateTime.Now.ToString("MM-dd-yyyy_hh.mm.ss") + ".sql";
                    try
                    {
                        if (!System.IO.Directory.Exists(filePath))
                        {
                            System.IO.Directory.CreateDirectory(filePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        return "There was a problem in creating the backup path\r\n" + ex.Message;
                    }

                    if (!System.IO.File.Exists(Application.StartupPath + @"//mysqldump.exe"))
                    {
                        return "mysqldump.exe is not found in the installation path. Please re-install ";
                    }

                    Process _proc = new Process();
                    try
                    {

                        _proc.EnableRaisingEvents = false;
                        _proc.StartInfo.UseShellExecute = false;
                        _proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        _proc.StartInfo.CreateNoWindow = false;
                        _proc.StartInfo.RedirectStandardError = true;
                        _proc.StartInfo.FileName = Application.StartupPath + "\\mysqldump.exe";
                        _proc.StartInfo.Arguments = "-B " + getConnectionVariables("database", _connectionString) + " -u " + getConnectionVariables("user", _connectionString) + " -p --password=" + getConnectionVariables("password", _connectionString) + " --host=" + getConnectionVariables("server", _connectionString) + " --port=" + getConnectionVariables("port", _connectionString) + " --routines" + " --result-file \"" + Application.StartupPath + "\\Backup\\" + fileName + "\"";
                        _proc.Start();
                        _proc.WaitForExit();
                        _error = _proc.StandardError.ReadToEnd();

                        if (_error != "")
                        {
                            return _error;
                        }

                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    finally
                    {
                        _proc.Close();
                        _proc.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            //Clark 09.26.2011 copied from folio plus
            private string getConnectionVariables(string pVariable, string pConnectionString)
            {
                string[] _variables = pConnectionString.Split(';');
                string[] _val;
                foreach (string _variable in _variables)
                {
                    if (pVariable.Trim().ToUpper().Equals("DATABASE"))
                    {
                        if (_variable.Trim().ToUpper().Contains("DATABASE") || _variable.Trim().ToUpper().Contains("DB"))
                        {
                            _val = _variable.Split('=');
                            if (_val.Length > 1)
                            {
                                return _val[1];
                            }
                        }
                    }
                    else if (pVariable.Trim().ToUpper().Equals("USER"))
                    {
                        if (_variable.Trim().ToUpper().Contains("USER") || _variable.Trim().ToUpper().Contains("UID"))
                        {
                            _val = _variable.Split('=');
                            if (_val.Length > 1)
                            {
                                return _val[1];
                            }
                        }
                    }
                    else if (pVariable.Trim().ToUpper().Equals("PASSWORD"))
                    {
                        if (_variable.Trim().ToUpper().Contains("PASSWORD") || _variable.Trim().ToUpper().Contains("PWD"))
                        {
                            _val = _variable.Split('=');
                            if (_val.Length > 1)
                            {
                                return _val[1];
                            }
                        }
                    }
                    else if (pVariable.Trim().ToUpper().Equals("SERVER"))
                    {
                        if (_variable.Trim().ToUpper().Contains("SERVER"))
                        {
                            _val = _variable.Split('=');
                            if (_val.Length > 1)
                            {
                                return _val[1];
                            }
                        }
                    }
                    else if (pVariable.Trim().ToUpper().Equals("PORT"))
                    {
                        if (_variable.Trim().ToUpper().Contains("PORT"))
                        {
                            _val = _variable.Split('=');
                            if (_val.Length > 1)
                            {
                                return _val[1];
                            }
                        }
                    }
                }
                return "";
            }

            private void captureImageToolStripMenuItem_Click(object sender, EventArgs e)
            {

                if (!isOpen(frmCaptureImage))
                {

                    frmCaptureImage = (Form)FolioRegistry.CreateObject(captureImageToolStripMenuItem.Tag.ToString());

                    frmCaptureImage.MdiParent = this;
                    frmCaptureImage.Show();
                    frmCaptureImage.Location = fLocation;
                }
            }

            private void btnStressTest_Click(object sender, EventArgs e)
            {
                Form1 frmStressTest = new Form1(GlobalVariables.gPersistentConnection);
                frmStressTest.ShowDialog();
            }

            private void mnuHouseKeepingNew_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmHousekeepingUI))
                {
                    frmHousekeepingUI = (Form)FolioRegistry.CreateObject(mnuHouseKeepingNew.Tag.ToString());
                    frmHousekeepingUI.MdiParent = this;
                    frmHousekeepingUI.Show();
                    frmHousekeepingUI.Location = fLocation;
                }
            }

            private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
            {
                System.Diagnostics.Process.Start("calc");
            }

            private void mnuOpenShift_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmCashTerminalList))
                {
                    if (GlobalVariables.gCashDrawerOpen)
                    {
                        MessageBox.Show("Cash Drawer already opened.", "Open Shift", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
						closeAllForms();

                        frmCashTerminalList = (Form)FolioRegistry.CreateObject(mnuOpenShift.Tag.ToString());
                        frmCashTerminalList.MdiParent = this;
                        frmCashTerminalList.Show();
                    }
                }
            }

            private void mnuSystemRoles_Click(object sender, EventArgs e)
            {
                Jinisys.Hotel.Security.Presentation.RolesUI frmSysRole = new Jinisys.Hotel.Security.Presentation.RolesUI(GlobalVariables.gPersistentConnection);
                frmSysRole.MdiParent = this;
                frmSysRole.Show();
            }

            private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
            {
                System.Diagnostics.Process.Start("notepad");
            }

            private void cancelledReservationToolStripMenuItem_Click(object sender, EventArgs e)
            {
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "CANCELLED RESERVATION" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();

				}
            }

            private void guestLedgerToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //showReport("getGuestLedger");
                if (!isOpen(frmReportDateParam))
                {
                    frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "GUEST LEDGER" }, new Type[] { typeof(System.String) });
                    frmReportDateParam.MdiParent = this;
                    frmReportDateParam.Show();

                }

            }

            private void roomOccupancyToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //showReport("getRoomOccupancy");
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "ROOM OCCUPANCY" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();
				}

            }

            private void dailySalesToolStripMenuItem_Click(object sender, EventArgs e)
            {

				//if (!isOpen(frmReportDateParam))
				//{
				//    frmReportDateParam = (Form)FolioRegistry.CreateObject(dailySalesToolStripMenuItem.Tag.ToString(), new object[] { "DAILY TRANSACTIONS" }, new Type[] { typeof(System.String) });
				//    frmReportDateParam.MdiParent = this;
				//    frmReportDateParam.Show();

				//}
                //showReport("getDailyTransactions");
            }

            private void noOfPaxToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmNoOfPax))
                {
                    frmNoOfPax = (Form)FolioRegistry.CreateObject(noOfPaxToolStripMenuItem.Tag.ToString());
                    frmNoOfPax.MdiParent = this;
                    frmNoOfPax.Show();

                }
            }

            private void cityLedgerToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //if (!isOpen(frmSalesGenerator))
                //{
                //    frmSalesGenerator = (Form)FolioRegistry.CreateObject(cityLedgerToolStripMenuItem.Tag.ToString(), new object[] { "CITY LEDGER" }, new Type[] { typeof(System.String) });
                //    frmSalesGenerator.MdiParent = this;
                //    frmSalesGenerator.Show();

                //}
                showReport("getCityLedger");
            }

            private void salesForecsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmSalesForecast))
                {
                    frmSalesForecast = (Form)FolioRegistry.CreateObject(salesForecsToolStripMenuItem.Tag.ToString());
                    frmSalesForecast.MdiParent = this;
                    frmSalesForecast.Show();

                }
            }

            private void toolStripButtonNonStaying_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmShareFolioUI))
                {
                    Type[] paramType = { typeof(ReservationOperationMode) };
                    object[] paramVal ={ ReservationOperationMode.NonStaying };

                    frmShareFolioUI = (Form)FolioRegistry.CreateObject(toolStripButtonNonStaying.Tag.ToString(), paramVal, paramType);
                    frmShareFolioUI.MdiParent = this;
                    frmShareFolioUI.Show();
                }
            }

            private void folioLedgerIToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmFolioInquiry))
                {
                    frmFolioInquiry = (Form)FolioRegistry.CreateObject(folioLedgerIToolStripMenuItem.Tag.ToString());
                    frmFolioInquiry.MdiParent = this;
                    frmFolioInquiry.Show();

                }
            }

            private void cityLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmCityLedgerSummary))
                {

                    frmCityLedgerSummary = (Form)FolioRegistry.CreateObject(cityLedgerToolStripMenuItem1.Tag.ToString());
                    frmCityLedgerSummary.MdiParent = this;
                    frmCityLedgerSummary.Show();
                    frmCityLedgerSummary.Location = fLocation;
                }
            }

            private void menuInhouseGuestsForecast_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmInhouseGuestForeCast))
                {
                    frmInhouseGuestForeCast = (Form)FolioRegistry.CreateObject(menuInhouseGuestsForecast.Tag.ToString());
                    frmInhouseGuestForeCast.MdiParent = this;
                    frmInhouseGuestForeCast.Show();
                    frmInhouseGuestForeCast.Location = fLocation;
                }
            }

            private void mnucityTransferTransactions_Click(object sender, EventArgs e)
            {
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuCityTransferTransactions.Tag.ToString(), new object[] { "CITY TRANSFER" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();

				}
                //showReport("getCityTransferTransactions");
            }

            private void cityTransferToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmCityTransfer))
                {

                    frmCityTransfer = (Form)FolioRegistry.CreateObject(cityTransferToolStripMenuItem.Tag.ToString());
                    frmCityTransfer.MdiParent = this;
                    frmCityTransfer.Show();
                    frmCityTransfer.Location = fLocation;
                }
            }

            private void MenutransactionRegisterToolStrip_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmTransactionRegister))
                {
                    frmTransactionRegister = (Form)FolioRegistry.CreateObject(MenutransactionRegisterToolStrip.Tag.ToString());
                    frmTransactionRegister.MdiParent = this;
                    frmTransactionRegister.Show();
                    frmTransactionRegister.Location = fLocation;
                }
            }

            private void MenuReservationNoRoom_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();
                NewReservationNonStaying();
            }

            private void MenuShareReservationNoRoom_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmShareFolioUI))
                {
                    Type[] paramType = { typeof(System.String), typeof(ListView), typeof(System.String) };
                    object[] paramVal = { "New Share Folio", null, null, };

                    frmShareFolioUI = (Form)FolioRegistry.CreateObject(this.mnuSharedReservation.Tag.ToString(), paramType, paramVal);
                    frmShareFolioUI.GetType().GetProperty("AccountType").SetValue(frmShareFolioUI, "PERSONAL", null);
                    frmShareFolioUI.GetType().GetProperty("Flag").SetValue(frmShareFolioUI, "New", null);   // dapat new ang iya flag dili EDIT
                    frmShareFolioUI.GetType().GetProperty("FolioType").SetValue(frmShareFolioUI, "SHARE", null);
                    frmShareFolioUI.MdiParent = this;
                    frmShareFolioUI.Top = 0;
                    frmShareFolioUI.Left = 0;
                    frmShareFolioUI.Show();
                }
            }

            private void toolRefresh_Click(object sender, EventArgs e)
            {
                plotCurrentDayRoomStatus();
            }

			
            private void cmuTransactionsPerCashier_Click(object sender, EventArgs e)
            {
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(cmuTransactionsPerCashier.Tag.ToString(), new object[] { "ALL CASHIER TRANSACTIONS" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();

				}
            }

            private void mnuReservationList_Click(object sender, EventArgs e)
            {
                //Close all active forms
                //closeAllForms();

                if (!isOpen(frmReservationList))
                {

					frmReservationList = (Form)FolioRegistry.CreateObject(guestsListToolStripMenuItem.Tag.ToString());
					//object[] param = new object[1];
					//param[0] = "";

					//frmReservationList = (Form)frmReservationList.GetType().GetMethod("getInstance").Invoke(frmReservationUI, param);
                    frmReservationList.MdiParent = this;
                    frmReservationList.Show();
                    frmReservationList.Location = fLocation;
                }
            }

            private void mnuChangePassword_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmChangePassword))
                {
                    Type[] paramType = { typeof(System.Object) };
                    object[] paramVal = { GlobalVariables.goUser };


                    frmChangePassword = (Form)FolioRegistry.CreateObject(mnuChangePassword.Tag.ToString(), paramVal, paramType);
                    frmChangePassword.MdiParent = this;
                    frmChangePassword.Show();
                    frmChangePassword.Location = fLocation;
                }
            }

            private void mnuVoidedTransactions_Click(object sender, EventArgs e)
            {
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuVoidedTransactions.Tag.ToString(), new object[] { "VOIDED TRANSACTIONS" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();

				}
            }


            private void roomAvailabilityToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();
                //showRoomAvailability(0, DateTime.Now);
                showRoomAvailability(4, auditDate);
            }

            private void mnuRefresh_Click(object sender, EventArgs e)
            {
                plotCurrentDayRoomStatus();
                plotFunctionRoomStatus();
            }

            private void vsDayPlo_RowColChange(object sender, EventArgs e)
            {
                try
                {
                    cellColor = vsDayPlo.CellBackColor;
                    
                    this.vsDayPlo.Styles.Highlight.BackColor = cellColor;
                }
                catch
                {
                }
            }

            private void vsDayPlo_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    this.vsDayPlo_DoubleClick(sender, new EventArgs());
                }
            }

            private void mnuRoomHistoryInquiry_Click(object sender, EventArgs e)
            {

                if (!isOpen(frmRoomHistory))
                {

                    frmRoomHistory = (Form)FolioRegistry.CreateObject(this.mnuRoomHistoryInquiry.Tag.ToString());
                    frmRoomHistory.MdiParent = this;
                    frmRoomHistory.Top = 0;
                    frmRoomHistory.Left = 0;
                    frmRoomHistory.Show();
                }
            }

            private void tmrSysTime_Tick(object sender, EventArgs e)
            {
                string date = string.Format("{0:ddd, MMM. dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
                this.lblSysTime.Text = date + " ";

                this.lblSysTime.Text += string.Format("{0:hh:mm:ss tt }", DateTime.Now);
            }

            private void vsDayPlo_MouseHoverCell(object sender, EventArgs e)
            {

				C1.Win.C1FlexGrid.Classic.C1FlexGridClassic vs = (C1.Win.C1FlexGrid.Classic.C1FlexGridClassic)sender;

				// select current row
				vs.Select(vs.MouseRow, vs.MouseCol);

                try
                {
                    string tip = "";
                    string hoverRoomNo = "";

					hoverRoomNo = vs.GetData(vs.MouseRow, vs.MouseCol).ToString();
                    
                    if (lastHoverRoomNo != hoverRoomNo)
                    {
                        lastHoverRoomNo = hoverRoomNo;

                        C1.Win.C1FlexGrid.CellStyle cellStyle;
						cellStyle = vs.GetCellStyle(vs.MouseRow, vs.MouseCol);

                        Color clr = cellStyle.BackColor;

                        string _roomType = this.ldataTableCurrentDayStat.Rows.Find(hoverRoomNo)["RoomSuperType"].ToString();
                        string _description = this.ldataTableCurrentDayStat.Rows.Find(hoverRoomNo)["RoomDescription"].ToString();
                        switch (clr.Name)
                        {
                            case "White":
                                {
                                    if (_roomType == "FUNCTION") { tip += _description + "\r\n"; }
									tip += "Type: " + _roomType;
                                    //tip += "\r\n\r\nRoom is ready for Sale.\r\nDouble click for quick \r\ncheck-in.";
                                    string title = " Room  " + hoverRoomNo;


                                    toolTipVs.ToolTipTitle = title;



                                    toolTipVs.BackColor = System.Drawing.Color.White;

                                    break;
                                }

                            case "DodgerBlue":
                                {
									string reservationInfo = "";

									// check wether ROOM or FUNCTION
									if (_roomType == "FUNCTION")
									{
										reservationInfo = showCompanyFolioInformation(hoverRoomNo, "CONFIRMED");
									}
									else
									{
										reservationInfo = showFolioInformation(hoverRoomNo, "CONFIRMED");
									}

                                    tip += reservationInfo;
                                    toolTipVs.ToolTipTitle = " Reserve Room\t" + hoverRoomNo;
                                    toolTipVs.BackColor = SystemColors.Info;
                                    break;
                                }

                            case "Aqua":
                            case "Gold":
                                {
									string folioInfo = "";

									// check wether ROOM or FUNCTION
									if (_roomType == "FUNCTION")
									{
										folioInfo = showCompanyFolioInformation(hoverRoomNo, "ONGOING");
									}
									else
									{
										folioInfo = showFolioInformation(hoverRoomNo, "ONGOING");
									}

                                    tip += folioInfo;
                                    toolTipVs.ToolTipTitle = " Occupied Room\t" + hoverRoomNo;
                                    toolTipVs.BackColor = SystemColors.Info;
                                    break;
                                }

                            case "Brown":
                                {
                                    string blockInfo = showRoomBlockInformation(hoverRoomNo);
                                    tip += blockInfo;
                                    toolTipVs.ToolTipTitle = " Blocked Room\t" + hoverRoomNo;
                                    toolTipVs.BackColor = System.Drawing.Color.WhiteSmoke;
                                    break;
                                }

                            case "GreenYellow":
                                {
                                    tip += "\r\nRoom is Out of Order\r\n";
									toolTipVs.ToolTipTitle = " Room\t" + hoverRoomNo;
									toolTipVs.BackColor = System.Drawing.Color.WhiteSmoke;

                                    break; 
                                }
                            case "Red":
                                {
                                    tip += "ROOM IS DIRTY";
                                    toolTipVs.ToolTipTitle = " Room\t" + hoverRoomNo;
                                    toolTipVs.BackColor = System.Drawing.Color.WhiteSmoke;

                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

						toolTipVs.SetToolTip(vs, tip);
                        toolTipVs.ToolTipIcon = ToolTipIcon.Info;

                    }
                }
                catch
                { }
            }



            private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Form objSplash = (Form)FolioRegistry.CreateObject("Jinisys.Hotel.Security.Presentation.SplashScreenUI");
                objSplash.ShowDialog(this);
            }

            private void lblSysTime_TextChanged(object sender, EventArgs e)
            {
                if (GlobalVariables.gPersistentConnection != null)
                {
                    try
                    {
                        if (GlobalVariables.gPersistentConnection.State == ConnectionState.Open)
                        {

                            string dateToday = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                            long dateDiff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(dateToday), DateTime.Parse(GlobalVariables.gAuditDate));

                            if (dateDiff != 0)
                            {

                                AuditFacade oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
                                string AuditDate = "";
                                if (ConfigVariables.gNightAuditEnabled == "true")
                                {
                                    AuditDate = oAuditFacade.getCurrentAuditDate();
                                }
                                else
                                {
                                    AuditDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                                }

                                GlobalVariables.gAuditDate = AuditDate;
                                this.pnlDate.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));

                                // recompute Difference between date
                                dateDiff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(dateToday), DateTime.Parse(GlobalVariables.gAuditDate));

                                if (dateDiff < 0)
                                {
                                    if (countReshowNytAuditTip > 100)
                                    {
                                        this.toolTipNytAudit.RemoveAll();

                                        this.toolTipNytAudit.ShowAlways = false;

                                        double locX = this.stbHotel.Width * 0.75;
                                        double locY = this.stbHotel.Location.Y + 2;//this.Height-(this.stbHotel.Height*3);//this.stbHotel.Location.Y - 30;

                                        this.toolTipNytAudit.ToolTipIcon = ToolTipIcon.Warning;
                                        this.toolTipNytAudit.ToolTipTitle = "System Warning";
                                        this.toolTipNytAudit.IsBalloon = true;
                                        this.toolTipNytAudit.UseFading = true;

                                        try
                                        {
                                            this.toolTipNytAudit.Show("Night Audit has not been processed.", this, int.Parse(locX.ToString()), int.Parse(locY.ToString()), 15000);
                                        }
                                        catch { }
                                        countReshowNytAuditTip = 0;
                                    }

                                    countReshowNytAuditTip++;
                                }
                                //else
                                //{
                                //    plotCurrentDayRoomStatus();
                                //}
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.tmrSysTime.Stop();
                        this.tmrUpdateRoomStat.Stop();
                        MessageBox.Show(ex.Message);
                        Application.Exit();
                    }

                }

                {

                }
            }

            #endregion

            Form frmChangesLog = null;
            private void logsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmChangesLog))
                {
                    frmChangesLog = (Form)FolioRegistry.CreateObject(logsToolStripMenuItem.Tag.ToString());
                    frmChangesLog.MdiParent = this;
                    frmChangesLog.Show();
                    frmChangesLog.WindowState = FormWindowState.Maximized;
                }
            }

            private void newSingleReservation()
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmReservationUI))
                {
                    Type[] paramType = { typeof(System.String), typeof(ListView), typeof(System.String) };
                    object[] paramVal = { "New Guest Reservation", null, null, };

                    frmReservationUI = (Form)FolioRegistry.CreateObject(this.mnuSharedReservation.Tag.ToString(), paramType, paramVal);
                    frmReservationUI.GetType().GetProperty("AccountType").SetValue(frmShareFolioUI, "PERSONAL", null);
                    frmReservationUI.GetType().GetProperty("Flag").SetValue(frmShareFolioUI, "New", null);   // dapat new ang iya flag dili EDIT
                    frmReservationUI.GetType().GetProperty("FolioType").SetValue(frmShareFolioUI, "INDIVIDUAL", null);
                    frmReservationUI.MdiParent = this;
                    frmReservationUI.Top = 0;
                    frmReservationUI.Left = 0;
                    frmReservationUI.Show();
                }
            }


            Form frmOccupancyForecast = null;
            private void mnuOccupancyForecast_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmOccupancyForecast))
                {
                    frmOccupancyForecast = (Form)FolioRegistry.CreateObject(mnuOccupancyForecast.Tag.ToString());
                    frmOccupancyForecast.MdiParent = this;

                    frmOccupancyForecast.Show();

                    frmOccupancyForecast.WindowState = FormWindowState.Maximized;


                }
            }

            Form frmRateTypeInquiry = null;
            private void guestByRateCodeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //Close all active forms
                closeAllForms();

                if (!isOpen(frmRateTypeInquiry))
                {

                    frmRateTypeInquiry = (Form)FolioRegistry.CreateObject(guestByRateCodeToolStripMenuItem.Tag.ToString());
                    frmRateTypeInquiry.MdiParent = this;
                    frmRateTypeInquiry.Show();

                    frmRateTypeInquiry.WindowState = FormWindowState.Maximized;
                }
            }


            private void tmrUpdateRoomStat_Tick(object sender, EventArgs e)
            {
				try
				{
					DataView _oldDataView = ldataTableCurrentDayStat.DefaultView;

					// compare Room Status b4 updating Current Day Room Status Grid
					Object[] paramVal = { GlobalVariables.gAuditDate };
					DataTable _dtTemp = (DataTable)loCalendarFacade.GetType().GetMethod("getCurrentDayRoomStatus").Invoke(loCalendarFacade, paramVal);

					bool _update = false;

					if (ldataTableCurrentDayStat.Rows.Count != _dtTemp.Rows.Count)
					{
						_update = true;
					}
					else // compare values
					{
						foreach (DataRow _dtRow in _dtTemp.Rows)
						{
							string _compStr = "";
							foreach (DataColumn dtCol in _dtTemp.Columns)
							{
								_compStr += dtCol.ColumnName + " " + (_dtRow[dtCol] is DBNull ? " is Null" : " = '" + _dtRow[dtCol].ToString() + "'") + " and ";
							}
							_compStr = _compStr.Substring(0, _compStr.Length - 5);
							_oldDataView.RowStateFilter = DataViewRowState.OriginalRows;
							_oldDataView.RowFilter = _compStr;

							DataView _dtViewTEMP = _dtTemp.DefaultView;
							_dtViewTEMP.RowStateFilter = DataViewRowState.OriginalRows;
							_dtViewTEMP.RowFilter = _compStr;


							if (_dtViewTEMP.Count != _oldDataView.Count)
							{
								_update = true;
								break;
							}
						}
					}



					if (_update)
					{
						plotCurrentDayRoomStatus();
						//updateCurrentDayRoomStatus();
						ldataTableCurrentDayStat = _dtTemp;
					}
				}
				catch (Exception ex)
                {
                    this.tmrUpdateRoomStat.Stop();
                    this.tmrSysTime.Stop();
                    MessageBox.Show(ex.Message);
                    Application.Exit();

                }
            }

            private void mnuAccountingInterface_Click(object sender, EventArgs e)
            {
                AccountingSetup accountingSetupUI = new AccountingSetup();
                accountingSetupUI.MdiParent = this;
                accountingSetupUI.Show();
            }

            private void mnuPostToAccounting_Click(object sender, EventArgs e)
            {
                PostToAccountingUI postUI = new PostToAccountingUI();
                postUI.MdiParent = this;
                postUI.Show();
            }

            private bool isExpectedCheckOut(string a_RoomId, string a_FolioStatus)
            {
                try
                {

                    DataView dtView = oGuestFolio.DefaultView;

                    dtView.RowStateFilter = DataViewRowState.OriginalRows;
                    dtView.RowFilter = "RoomId = '" + a_RoomId + "' AND Status = '" + a_FolioStatus + "'";

                    foreach (DataRowView dRowView in dtView)
                    {

                        DateTime _departureDate = DateTime.Parse(dRowView["DepartureDate"].ToString());
                        DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);


                        if (_departureDate.Date == _auditDate.Date)
                        {
                            return true;
                        }
                        //folioInfo += "Type\t:  " + dRowView["RoomTypeCode"] + "\r\n";

                        //folioInfo += "\r\n";

                        //folioInfo += "Guest\t:  " + dRowView["GuestName"] + "\r\n";
                        //folioInfo += "Rate\t:  " + string.Format("{0:#,##0.00}", Double.Parse(dRowView["Rate"].ToString())) + "\r\n";
                        //folioInfo += "Arrival\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["ArrivalDate"].ToString())) + "\r\n";
                        //folioInfo += "Depart'r\t:  " + string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(dRowView["DepartureDate"].ToString())) + "\r\n\r\n";

                        //folioInfo += "Comp.\t:  " + dRowView["CompanyName"] + "\r\n";
                        //folioInfo += "Folio\t:  " + dRowView["FolioType"] + "\r\n";

                        break;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception @ checkIfExpectedCheckOut() : " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            Form roomAvailability = null;
            private void mnuAvailableRoomsToday_Click(object sender, EventArgs e)
            {

                closeAllForms();


                roomAvailability.MdiParent = this;
                roomAvailability.Show();
                roomAvailability.Location = fLocation;
            }

            private void tsbAvailability_Click(object sender, EventArgs e)
            {
                if (!isOpen(roomAvailability))
                {

                    roomAvailability = (Form)FolioRegistry.CreateObject(mnuAvailableRoomsToday.Tag.ToString());

                    roomAvailability.MdiParent = this;
                    roomAvailability.Show();
                    roomAvailability.Location = fLocation;
                }
            }

			//private void mnuProtectAppSettings_Click(object sender, EventArgs e)
			//{
			//    protectSettings(true);
			//}

			//private void protectSettings(bool encrypt)
			//{
			//    try
			//    {
			//        string path = Application.ExecutablePath;

			//        Configuration config = ConfigurationManager.OpenExeConfiguration(path);

			//        ConfigurationSection appSettings = config.GetSection("appSettings");
			//        if (encrypt)
			//        {
			//            appSettings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
			//        }
			//        else
			//        {
			//            appSettings.SectionInformation.UnprotectSection();
			//        }
			//        config.Save();
			//    }
			//    catch
			//    { }
			//}

			private void mnuWaitListReservation_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(ReservationOperationMode) };
				object[] paramVal = { ReservationOperationMode.WaitList };

				frmShareFolioUI = (Form)FolioRegistry.CreateObject(this.mnuSingleReservation.Tag.ToString(), paramType, paramVal);

				frmShareFolioUI.MdiParent = this;
				frmShareFolioUI.Top = 0;
				frmShareFolioUI.Left = 0;
				frmShareFolioUI.Show();

			}

			private Form frmDrivers = null;
			private void mnuConfigDrivers_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmDrivers))
				{
					frmDrivers = (Form)FolioRegistry.CreateObject(mnuConfigDrivers.Tag.ToString());
					frmDrivers.MdiParent = this;
					frmDrivers.Show();
					frmDrivers.Location = fLocation;
				}
			}

			private Form frmPostNonGuest = null;
			private void mnuPostTransactionNonGuest_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmPostNonGuest))
				{
					frmPostNonGuest = (Form)FolioRegistry.CreateObject(mnuPostTransactionNonGuest.Tag.ToString());
					frmPostNonGuest.MdiParent = this;
					frmPostNonGuest.Show();
					frmPostNonGuest.Location = fLocation;
				}
			}

			private void mnuSalesSummary_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(cmuTransactionsPerCashier.Tag.ToString(), new object[] { "TRANSACTION SUMMARY" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();

				}
			}

            private Form frmRequirements = null;
            private void requirementCodeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmRequirements))
                {
                    frmRequirements = (Form)FolioRegistry.CreateObject(mnuConfigRequirement.Tag.ToString());
                    frmRequirements.MdiParent = this;
                    frmRequirements.Show();
                    frmRequirements.Location = fLocation;
                }
            }

            private Form frmEventTypes = null;
            private void mnuEventTypes_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmEventTypes))
                {
                    frmEventTypes = (Form)FolioRegistry.CreateObject(mnuEventTypes.Tag.ToString());
                    frmEventTypes.MdiParent = this;
                    frmEventTypes.Show();
                    frmEventTypes.Location = fLocation;
                }
            }

            private Form frmMealItem = null;
            private void mnuMealItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmMealItem))
                {
                    frmMealItem = (Form)FolioRegistry.CreateObject(mnuMealItem.Tag.ToString());
                    frmMealItem.MdiParent = this;
                    frmMealItem.Show();
                    frmMealItem.Location = fLocation;
                }
            }

            private Form frmMealGroup = null;
            private void mealGroupToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmMealGroup))
                {
                    frmMealGroup = (Form)FolioRegistry.CreateObject(mealGroupToolStripMenuItem.Tag.ToString());
                    frmMealGroup.MdiParent = this;
                    frmMealGroup.Show();
                    frmMealGroup.Location = fLocation;
                }
            }

            private Form frmMealMenu = null;
            private void mealMenuToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmMealMenu))
                {
                    frmMealMenu = (Form)FolioRegistry.CreateObject(mealMenuToolStripMenuItem.Tag.ToString());
                    frmMealMenu.MdiParent = this;
                    frmMealMenu.Show();
                    frmMealMenu.Location = fLocation;
                }
            }

            private Form frmEventPackage = null;
            private void mnuEventPackage_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmEventPackage))
                {
                    frmEventPackage = (Form)FolioRegistry.CreateObject(mnuEventPackage.Tag.ToString());
                    frmEventPackage.MdiParent = this;
                    frmEventPackage.Show();
                    frmEventPackage.Location = fLocation;
                }
            }

            private Form frmAppliedRates = null;
            private void appliedRatesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmAppliedRates))
                {
                    frmAppliedRates = (Form)FolioRegistry.CreateObject(appliedRatesToolStripMenuItem.Tag.ToString());
                    frmAppliedRates.MdiParent = this;
                    frmAppliedRates.Show();
                    frmAppliedRates.Location = fLocation;
                }
            }

			public void plotFunctionRoomStatus()
			{
                DataView _dtViewRooms = ldataTableCurrentDayStat.DefaultView;
                _dtViewRooms.RowStateFilter = DataViewRowState.OriginalRows;
                //_dtViewRooms.RowFilter = "roomtypecode like '%FUNCTION%'";

                /* FP-SCR-00139 [07.21.2010]
                 * filter by room super type */
                _dtViewRooms.RowFilter = "roomsupertype like '%FUNCTION%'";

                int col = 0;

                this.gridFunctions.Rows = 1;

                int _ctr = 0;
                foreach (DataRowView dRow in _dtViewRooms)
                {
                    if (col <= 2)
                    {
                        string _roomId = "";
                        string _roomCleaningStatus = "";

                        _roomId = dRow["roomid"].ToString();
                        _roomCleaningStatus = dRow["cleaningstatus"].ToString();

                        this.gridFunctions.set_TextMatrix(gridFunctions.Rows - 1, col, _roomId);

                        gridFunctions.set_RowHeight(gridFunctions.Rows - 1, 19);
                        C1.Win.C1FlexGrid.CellRange range = this.gridFunctions.GetCellRange(gridFunctions.Rows - 1, col);
                        range.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

                        string _eventType = dRow["eventtype"].ToString().ToUpper();
                        if ((dRow["eventtype"]) != null)
                        {

                            // to SET COLOR VACANT-DIRTY for RESERVED ROOMS
                            //if (_roomCleaningStatus == "DIRTY")
                            //{
                            //    if (_eventType == "IN HOUSE")
                            //    {
                            //        // check if Expected CHECKOUT
                            //        // if so, then Dont treat as Inhouse-Dirty
                            //        // since room will be cleaned upon guest checkout
                            //        if (!isExpectedCheckOut(_roomId, "ONGOING"))
                            //        {
                            //            _eventType = "IN HOUSE-DIRTY";
                            //        }
                            //    }
                            //    else
                            //    {
                            //        _eventType = "VACANT-DIRTY";
                            //    }

                            //}
                            //if (_eventType == "RESERVATION")
                            //{
                            //    //FolioFacade _oFolioFacade = new FolioFacade();

                            //    DataView dtView = oCompanyFolio.DefaultView;

                            //    dtView.RowStateFilter = DataViewRowState.OriginalRows;
                            //    dtView.RowFilter = "RoomId = '" + dRow["roomid"].ToString() + "' AND (Status = 'CONFIRMED' or Status='TENTATIVE')";
                            //    if (dtView.Count > 0)
                            //    {
                            //        setColorFunction(dtView[0]["Status"].ToString(), gridFunctions.Rows - 1, col);
                            //    }
                            //    else
                            //    {
                            //        setColorFunction("CONFIRMED", gridFunctions.Rows - 1, col);
                            //    }
                            //}
                            //else
                            //{
                            setColorFunction(_eventType, gridFunctions.Rows - 1, col);
                            //}

                        }

                        col++;
                    }
                    if (col > 2)
                    {
                        col = 0;
                        gridFunctions.Rows++;
                    }


                    _ctr++;

                }

                /* added for auto-resize of function rooms */
                int _sidePanelHeight = this.flpSidePanel.Height;// -125;

                this.tabRooms.Height = (_sidePanelHeight + 55);
                this.flpRooms.Height = (_sidePanelHeight + 55);
                this.flpFunctions.Height = (_sidePanelHeight + 55);

                // for the CURSOR to reside at the last ROW/COL.
                this.vsDayPlo.Select(vsDayPlo.Rows - 1, vsDayPlo.Cols - 1);

                // set up vs height
                int _rowsIndividual = this.vsDayPlo.Rows;
                int _rowsFunction = this.gridFunctions.Rows;

                if (_rowsIndividual > 28 || _rowsFunction > 28)
                    this.pictHotelLogo.Visible = false;

                int _heightIndividual = (_rowsIndividual * 19) + 8;
                int _heightFunction = (_rowsFunction * 19) + 8;

                if (_heightFunction > _heightIndividual)
                    this.pnlRooms.Height = _heightFunction;
                else
                    this.pnlRooms.Height = _heightIndividual;
                //this.tabRooms.Height = (_height + 40);

                this.pnlFunction.Height = _heightFunction;

                gridFunctions.Visible = true;

                gridFunctions.Select(gridFunctions.Rows - 1, 2);
			}

			private void gridFunctions_RowColChange(object sender, EventArgs e)
			{
				try
				{
					cellColor = gridFunctions.CellBackColor;
					this.gridFunctions.Styles.Highlight.BackColor = cellColor;
				}
				catch
				{
				}
			}

			Form frmTransactionCode_SubAccounts;
			private void mnuTransactionCodeSubAccounts_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmTransactionCode_SubAccounts))
				{
					frmTransactionCode_SubAccounts = (Form)FolioRegistry.CreateObject(mnuTransactionCodeSubAccounts.Tag.ToString());
					frmTransactionCode_SubAccounts.MdiParent = this;
					frmTransactionCode_SubAccounts.Show();
					frmTransactionCode_SubAccounts.Location = fLocation;
				}
			}

			Form frmTransactionSourceUI;
			private void mnuTransactionSources_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmTransactionSourceUI))
				{
					frmTransactionSourceUI = (Form)FolioRegistry.CreateObject(mnuTransactionSources.Tag.ToString());
					frmTransactionSourceUI.MdiParent = this;
					frmTransactionSourceUI.Show();
					frmTransactionSourceUI.Location = fLocation;
				}
			}

			private void cmuLiveRoomStatus_Opened(object sender, EventArgs e)
			{
				try
				{
					int _row = this.vsDayPlo.Row;
					int _col = this.vsDayPlo.Col;

					string _roomNo = this.vsDayPlo.get_TextMatrix(_row, _col);
					Color _currentColor = this.vsDayPlo.CellBackColor;
					
					if (_roomNo == "") // if no room number
						_currentColor = Color.Orange;

					switch (_currentColor.Name)
					{
						case "White": // vacant clean
								this.cmuQuickCheckIn.Enabled = true;

								this.cmuViewReservationInfo.Enabled = false;
								this.cmuViewFolio.Enabled = false;
								this.cmuCheckOutFolio.Enabled = false;

								this.cmuPrintRegCard.Enabled = false;
							break;

						case "Aqua": // occupied-clean
						case "Gold": // occupied-dirty

							this.cmuQuickCheckIn.Enabled = false;
							this.cmuViewReservationInfo.Enabled = true;
							this.cmuViewFolio.Enabled = true;
							this.cmuCheckOutFolio.Enabled = true;

							this.cmuPrintRegCard.Enabled = true;
							break;

						case "DodgerBlue": // reserve

							this.cmuQuickCheckIn.Enabled = false;
							this.cmuViewReservationInfo.Enabled = true;
							this.cmuViewFolio.Enabled = true;
							this.cmuCheckOutFolio.Enabled = false;

							this.cmuPrintRegCard.Enabled = true;
							break;

						default:

							this.cmuQuickCheckIn.Enabled = false;
							this.cmuViewReservationInfo.Enabled = false;
							this.cmuViewFolio.Enabled = false;
							this.cmuCheckOutFolio.Enabled = false;
							this.cmuPrintRegCard.Enabled = false;
							break;

					}
				}
				catch
				{ }
				
			}

			private void cmuViewReservationInfo_Click(object sender, EventArgs e)
			{
				try
				{
					this.vsDayPlo_DoubleClick(sender, e);
				}
				catch
				{ }
			}

			private void cmuQuickCheckIn_Click(object sender, EventArgs e)
			{
				try
				{
					this.vsDayPlo_DoubleClick(sender, e);
				}catch
				{}
			}

			Form loFolioUI = null;
			private void cmuViewFolio_Click(object sender, EventArgs e)
			{
				try
				{
					string _roomNo = this.vsDayPlo.get_TextMatrix(this.vsDayPlo.Row, this.vsDayPlo.Col);
					string _cellColor = this.vsDayPlo.CellBackColor.Name;
					string _eventType = "";

					switch (_cellColor)
					{
						case "Aqua":
						case "Gold":
							_eventType = "IN HOUSE";

							break;

						case "DodgerBlue":
							_eventType = "RESERVATION";

							break;

						default:
							return;
					}
					string _folioId = getFolioId(_roomNo, _eventType);

					// only RESERVED/ONGOING are allowed to view Folio Transactions
					if (_folioId != "")
					{
						Type[] paramType = { typeof(System.String), typeof(System.String) };
						object[] paramVal ={ _folioId, _roomNo };

						loFolioUI = FolioRegistry.CreateObject("Jinisys.Hotel.Cashier.Presentation.FolioLedgerUI", paramType, paramVal);
						loFolioUI.MdiParent = this;

						loFolioUI.Left = 0;
						loFolioUI.Top = 0;
						loFolioUI.Show();
					}

				}
				catch { }


			}
			Form loCheckoutUI = null;
			private void cmuCheckOutFolio_Click(object sender, EventArgs e)
			{
				closeAllForms();

				if (!isOpen(loCheckoutUI))
				{
					try
					{
						string _roomNo = this.vsDayPlo.get_TextMatrix(this.vsDayPlo.Row, this.vsDayPlo.Col);
						string _cellColor = this.vsDayPlo.CellBackColor.Name;
						string _eventType = "";

						switch (_cellColor)
						{
							case "Aqua":
							case "Gold":
								_eventType = "IN HOUSE";

								break;

							case "DodgerBlue":
								_eventType = "RESERVATION";

								break;

							default:
								return;
						}
						string _folioId = getFolioId(_roomNo, _eventType);

						// only RESERVED/ONGOING are allowed to view Folio Transactions
						if (_folioId != "")
						{
							Type[] paramType = { typeof(System.String) };
							object[] paramVal ={ _folioId };

							loCheckoutUI = FolioRegistry.CreateObject("Jinisys.Hotel.Cashier.Presentation.CheckOutUI", paramType, paramVal);
							loCheckoutUI.MdiParent = this;

							loCheckoutUI.Left = 0;
							loCheckoutUI.Top = 0;
							loCheckoutUI.Show();
						}

					}
					catch { }
				}
			}

			Form loGroupReservationUI = null;
			private void gridFunctions_DoubleClick(object sender, EventArgs e)
			{
				try
				{

					if (this.mnuGroupReservation.Enabled == false)
						return;

					//closeAllForms();

					string _roomNo = "";
					gridFunctions.Select(gridFunctions.Row, gridFunctions.Col);

					_roomNo = this.gridFunctions.get_TextMatrix(this.gridFunctions.Row, this.gridFunctions.Col);

					Color _cellColor = this.gridFunctions.CellBackColor;

					//Form oFolioUI = null;
					if (_cellColor.Equals(Color.Aqua) || 
						_cellColor.Equals(Color.DodgerBlue) ||
						_cellColor.Equals(Color.Gold))
					{
						string eventType = "";
						if (_cellColor.Equals(Color.Aqua) || _cellColor.Equals(Color.Gold))
						{
							eventType = "IN HOUSE";
						}
						else
						{
							eventType = "RESERVATION";
						}


						Type[] paramType = { typeof(System.String) };
						string _folioId = getFolioId(_roomNo, eventType);

						object[] paramVal ={ _folioId };

                        //loGroupReservationUI = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.Presentation.GroupReservationUI", paramType, paramVal);
                        loGroupReservationUI = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.Presentation.ReservationUI", paramType, paramVal);
						loGroupReservationUI.MdiParent = this;
						loGroupReservationUI.Top = 0;
						loGroupReservationUI.Left = 0;
						loGroupReservationUI.Show();

					}
                    //else if (_cellColor.Equals(Color.White) || _cellColor.Equals(Color.Black))
                    //{
                    //    Type[] paramType = { typeof(C1.Win.C1FlexGrid.C1FlexGrid) };

                    //    object[] paramVal ={ new C1.Win.C1FlexGrid.C1FlexGrid() };

                    //    loGroupReservationUI = FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.Presentation.GroupReservationUI", paramType, paramVal);
                    //    loGroupReservationUI.MdiParent = this;
                    //    loGroupReservationUI.Top = 0;
                    //    loGroupReservationUI.Left = 0;
                    //    loGroupReservationUI.Show();
                    //}
					else if (_cellColor.Equals(Color.GreenYellow))
					{
						MessageBox.Show("Room is out of order.\r\nSorry for the inconvenience.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

				}
				catch (Exception ex) { 
                
                }
			}

			Form frmHotelRevenue = null;
			private void mnuInquiryHotelRevenue_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmHotelRevenue))
				{
					frmHotelRevenue = (Form)FolioRegistry.CreateObject(mnuInquiryHotelRevenue.Tag.ToString());
					frmHotelRevenue.MdiParent = this;
					frmHotelRevenue.Show();
					frmHotelRevenue.Location = fLocation;
				}
			}

			private void MDIMainUI_MdiChildActivate(object sender, EventArgs e)
			{

				Form child = null;
				try
				{
					child = this.MdiChildren[this.MdiChildren.Length - 1];
				}
				catch
				{
				}


				UserFacade oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
				User oUser = (User)GlobalVariables.goUser;
				if (!oUserFacade.isAllowedToViewUI(child, oUser))
				{
					child.Paint += new PaintEventHandler(child_Paint);
				}
				

			}

			internal void child_Paint(object sender, PaintEventArgs e)
			{
				Form _childForm = (Form)sender;
				_childForm.Close();
			}

			Form frmSystemConfiguration = null;
			private void cmuSystemConfiguration_Click(object sender, EventArgs e)
			{

				if (!isOpen(frmSystemConfiguration))
				{

					frmSystemConfiguration = (Form)FolioRegistry.CreateObject(cmuSystemConfiguration.Tag.ToString());

					frmSystemConfiguration.MdiParent = this;
					frmSystemConfiguration.Show();
					frmSystemConfiguration.Location = fLocation;
				}
			}

			Form frmRoomRevenue = null;
			private void mnuInquiryRoomRevenue_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmRoomRevenue))
				{

					frmRoomRevenue = (Form)FolioRegistry.CreateObject(mnuInquiryRoomRevenue.Tag.ToString());

					frmRoomRevenue.MdiParent = this;
					frmRoomRevenue.Show();
					frmRoomRevenue.Location = fLocation;
				}
			}

			Form frmMinibarItemCategory = null;
			private void mnuMinibarItemCategory_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmMinibarItemCategory))
				{

					frmMinibarItemCategory = (Form)FolioRegistry.CreateObject(mnuMinibarItemCategory.Tag.ToString());
					frmMinibarItemCategory.MdiParent = this;
					frmMinibarItemCategory.Show();
					frmMinibarItemCategory.Location = fLocation;
				}
			}

			Form frmMinibarItem = null;
			private void mnuMinibarItems_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmMinibarItem))
				{

					frmMinibarItem = (Form)FolioRegistry.CreateObject(mnuMinibarItems.Tag.ToString());
					frmMinibarItem.MdiParent = this;
					frmMinibarItem.Show();
					frmMinibarItem.Location = fLocation;
				}
			}

			Form frmMinibarSalesView = null;
			private void mnuMinibarSalesView_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmMinibarSalesView))
				{

					frmMinibarSalesView = (Form)FolioRegistry.CreateObject(mnuMinibarSalesView.Tag.ToString());
					frmMinibarSalesView.MdiParent = this;
					frmMinibarSalesView.Show();
					frmMinibarSalesView.Location = fLocation;
				}
			}

			private void mnuHouseKeepingReport_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmReportDateParam))
				{
					frmReportDateParam = (Form)FolioRegistry.CreateObject(mnuAllTransaction.Tag.ToString(), new object[] { "HOUSEKEEPING JOB" }, new Type[] { typeof(System.String) });
					frmReportDateParam.MdiParent = this;
					frmReportDateParam.Show();

				}
			}

			Form frmHousekeepingReport = null;
			private void mnuHousekeepingActivity_Click(object sender, EventArgs e)
			{
				
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Housekeeping Report" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();

			}

			private void mnuHousekeepersReport_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Housekeeping Report by Housekeepers" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();
			}

			private void mnuHousekeepersSummary_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Housekeeper Summary" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();
			}

			private void mnuMinibarSales_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Minibar Sales" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();

			}

			private void mnuMinibarSalesByHousekeeper_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Minibar Sales By Housekeeper" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();
			}

			private void mnuMinibarSalesByRoom_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Minibar Sales By Room" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();
			}

			private void mnuMinibarSalesByItemCategory_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Minibar Sales By Category" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();	
			}

			private void mnuMinibarItemsList_Click(object sender, EventArgs e)
			{
				Type[] paramType = { typeof(string) };
				object[] paramVal = { "Items List" };

				frmHousekeepingReport = (Form)FolioRegistry.CreateObject(this.mnuHousekeepingActivity.Tag.ToString(), paramType, paramVal);

				frmHousekeepingReport.MdiParent = this;
				frmHousekeepingReport.Top = 0;
				frmHousekeepingReport.Left = 0;
				frmHousekeepingReport.Show();
			}

			private void cmuPrintRegCard_Click(object sender, EventArgs e)
			{
				try
				{
					string _roomNo = this.vsDayPlo.get_TextMatrix(this.vsDayPlo.Row, this.vsDayPlo.Col);
					string _cellColor = this.vsDayPlo.CellBackColor.Name;
					string _eventType = "";

					switch (_cellColor)
					{
						case "Aqua":
						case "Gold":
							_eventType = "IN HOUSE";

							break;

						case "DodgerBlue":
							_eventType = "RESERVATION";

							break;

						default:
							return;
					}
					string _folioId = getFolioId(_roomNo, _eventType);

					// only RESERVED/ONGOING are allowed to view Folio Transactions
					if (_folioId != "")
					{
						Type[] paramType = { typeof(System.String) };
						object[] paramVal ={ _folioId };

						showReport("getGuestInformation", paramVal);
					}

				}
				catch { }

			}

	
            private void tsbZoomIn_Click(object sender, EventArgs e)
            {
                
            }

			Form frmTelephoneDirectory = null;
			private void mnuTelephoneDirectory_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmTelephoneDirectory))
				{

					frmTelephoneDirectory = (Form)FolioRegistry.CreateObject(mnuTelephoneDirectory.Tag.ToString());
					frmTelephoneDirectory.MdiParent = this;

					frmTelephoneDirectory.Show();
				}
			}

			Form frmEndorsement = null;
			private void mnuShiftEndorsements_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmEndorsement))
				{

					frmEndorsement = (Form)FolioRegistry.CreateObject(mnuShiftEndorsements.Tag.ToString());
					frmEndorsement.MdiParent = this;

					frmEndorsement.Show();
				}
			}

			
			private void mnuHighBalanceGuests_Click(object sender, EventArgs e)
			{
				try
				{
					object[] param = { DateTime.Parse(GlobalVariables.gAuditDate) };
					showReport("getHighBalanceGuests", param);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			private void roomCalendarNEWToolStripMenuItem_Click(object sender, EventArgs e)
			{
				closeAllForms();

				frmRoomBlocking = (Form)FolioRegistry.CreateObject(roomCalendarNEWToolStripMenuItem.Tag.ToString());
				frmRoomBlocking.MdiParent = this;
				frmRoomBlocking.Show();
			}

			public void reloadCalendar(string pOperationMode, DateTime pStartDate, int pNoOfWeeks, string pRoomType, object pSchedule)
			{
				Type[] paramTypes = { typeof(System.String), typeof(System.DateTime), typeof(int), typeof(System.String), typeof(object) };
				object[] paramValues = { pOperationMode, pStartDate, pNoOfWeeks, pRoomType, pSchedule };
				frmRoomBlocking = (Form)FolioRegistry.CreateObject(roomCalendarNEWToolStripMenuItem.Tag.ToString(), paramValues, paramTypes);
				frmRoomBlocking.MdiParent = this;
				frmRoomBlocking.Show();
			}

			Form frmDailyHotelRevenueUI = null;
			private void mnuDailyHotelRevenueReport_Click(object sender, EventArgs e)
			{
				if (!isOpen(frmDailyHotelRevenueUI))
				{

					frmDailyHotelRevenueUI = (Form)FolioRegistry.CreateObject(mnuDailyHotelRevenueReport.Tag.ToString());

					frmDailyHotelRevenueUI.MdiParent = this;
					frmDailyHotelRevenueUI.Show();
					frmDailyHotelRevenueUI.Location = fLocation;
				}
			}

			private void mnuTranCodeGLSetup_Click(object sender, EventArgs e)
			{
				TranCode_GLAccountSetup glSetupUI = new TranCode_GLAccountSetup();
				glSetupUI.MdiParent = this;

				glSetupUI.Show();
			}

            private void roomingListToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();

                if (!isOpen(frmRoomingList))
                {
                    frmRoomingList = (Form)FolioRegistry.CreateObject(roomingListToolStripMenuItem.Tag.ToString());
                    frmRoomingList.MdiParent = this;
                    frmRoomingList.WindowState = FormWindowState.Maximized;
                    frmRoomingList.Show();
                    frmRoomingList.Location = fLocation;
                }
            }

            private Form frmAgent = null;
            private void mnuAgents_Click(object sender, EventArgs e)
            {
                if (!isOpen(frmAgent))
                {
                    frmAgent = (Form)FolioRegistry.CreateObject(mnuAgents.Tag.ToString());
                    frmAgent.MdiParent = this;
                    frmAgent.Show();
                    frmAgent.Location = fLocation;
                }
                
            }

            private Form frmAccountingAdjustment = null;
            private void mnuAccountingAdjustment_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmAccountingAdjustment))
                {
                    frmAccountingAdjustment = (Form)FolioRegistry.CreateObject(mnuAccountingAdjustment.Tag.ToString());
                    frmAccountingAdjustment.MdiParent = this;
                    frmAccountingAdjustment.WindowState = FormWindowState.Maximized;
                    frmAccountingAdjustment.Show();
                    frmAccountingAdjustment.Location = fLocation;
                }
            }

            private bool checkApplicationLicenseKey()
            {
                string _licenseKey = getGenerateLicenseKeyFromVolume();
                if (_licenseKey.ToUpper() == GlobalVariables.APP_LICENSE_KEY.ToUpper())
                    return true;
                else
                    return false;
            }
            private Form frmHousekeepingStepProcedure = null;
            private void housekeepingStepProcedureToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmHousekeepingStepProcedure))
                {
                    frmHousekeepingStepProcedure = (Form)FolioRegistry.CreateObject(housekeepingStepProcedureToolStripMenuItem.Tag.ToString());
                    frmHousekeepingStepProcedure.MdiParent = this;
                    frmHousekeepingStepProcedure.WindowState = FormWindowState.Maximized;
                    frmHousekeepingStepProcedure.Show();
                    frmHousekeepingStepProcedure.Location = fLocation;
                }
            }

            private Form frmNationalityReport = null;
            private void nationalityReportToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmNationalityReport))
                {
                    frmNationalityReport = (Form)FolioRegistry.CreateObject(nationalityReportToolStripMenuItem.Tag.ToString());
                    frmNationalityReport.MdiParent = this;
                    frmNationalityReport.WindowState = FormWindowState.Maximized;
                    frmNationalityReport.Show();
                    frmNationalityReport.Location = fLocation;
                }
            }


            private string getGenerateLicenseKeyFromVolume()
            {

                int _checkDigit = int.Parse(GlobalVariables.APP_CHECK_DIGIT);
                int _buildNo = int.Parse(GlobalVariables.APP_BUILD_NO);
                string _licenseKey = "";


                string[] _appDirectory = Application.StartupPath.Split(':');
                string _appDriveLetter = _appDirectory[0];

                if (_appDriveLetter == "" || _appDriveLetter == null)
                {
                    _appDriveLetter = "C";
                }
                //create our ManagementObject, passing it the drive letter to the
                //DevideID using WQL
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + _appDriveLetter + ":\"");
                //bind our management object
                disk.Get();
                string diskVolumeSerialNo = disk["VolumeSerialNumber"].ToString();

                char[] charArray = diskVolumeSerialNo.ToCharArray();

                int _firstChar = 0;
                _firstChar = (int)charArray[0];
                _firstChar *= _checkDigit;

                int _totalChar = 0;
                foreach (char chr in charArray)
                {
                    int _charCode = (int)chr;
                    _charCode *= _checkDigit;

                    _totalChar += _charCode;
                }

                string _firstCharHexStr = System.Convert.ToString(_firstChar, 16).ToUpper();
                string _totalCharHexStr = System.Convert.ToString(_totalChar, 16).ToUpper();

                _licenseKey = _firstCharHexStr + "-" + _totalCharHexStr;

                return _licenseKey;
            }

            private void MDIMainUI_KeyPress(object sender, KeyPressEventArgs e)
            {
                if(e.KeyChar== (char)Keys.Escape)
                {
                    toolBar_Click(sender, new EventArgs());
                }
            }

            private Form frmMealRequirements = null;
            private void mnuMealRequirements_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmMealRequirements))
                {
                    frmMealRequirements = (Form)FolioRegistry.CreateObject(mnuMealRequirements.Tag.ToString());
                    frmMealRequirements.MdiParent = this;
                    frmMealRequirements.WindowState = FormWindowState.Maximized;
                    frmMealRequirements.Show();
                    frmMealRequirements.Location = fLocation;
                }
            }

            private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                //this.tsmReports.Enabled = false;

                FolioRegistry.RegisterFolioTypes("../main/Reports.dll");
                
            }

            private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
            {
                createReportFacade();
                this.tsmReports.Enabled = true;
                this.inquiryToolStripMenuItem.Enabled = true;
                this.mnuReportGenerator.Enabled = true;
                this.stbHotel.Panels["pnlApplication"].Text = "Event Plus Professional Edition - Version 1.0.0";
            }

            private void folioUserGuideToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string filename = "..\\User Guide\\Event Plus User Guide.pdf";
                    System.Diagnostics.Process.Start(filename);
                }
                catch
                {
                    MessageBox.Show("System cannot find the file specified.\r\n@../User Guide/Event Plus User Guide.pdf", "Find File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            /* FP-SCR-00139 #2 [07.21.2010]
             * added for creating room super type */
            private Form frmRoomSuperType = null;
            private void roomSuperTypesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmRoomSuperType))
                {
                    frmRoomSuperType = (Form)FolioRegistry.CreateObject(roomSuperTypesToolStripMenuItem.Tag.ToString());
                    frmRoomSuperType.MdiParent = this;
                    frmRoomSuperType.Show();
                    frmRoomSuperType.Location = fLocation;
                }
            }
            private Form frmEventList = null;
            private void mnuEventList_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmEventList))
                {
                    frmEventList = (Form)FolioRegistry.CreateObject(mnuEventList.Tag.ToString());
                    frmEventList.MdiParent = this;
                    frmEventList.Show();
                    frmEventList.Location = fLocation;
                }
            }
            private Form frmEventsRevenue = null;
            private void mnuEventsRevenue_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmEventsRevenue))
                {
                    frmEventsRevenue = (Form)FolioRegistry.CreateObject(mnuEventsRevenue.Tag.ToString());
                    frmEventsRevenue.MdiParent = this;
                    frmEventsRevenue.Show();
                    frmEventsRevenue.Location = fLocation;
                }
            }

            private Form frmStatisticalData = null;
            private void statisticalDataToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmStatisticalData))
                {
                    frmStatisticalData = (Form)FolioRegistry.CreateObject(statisticalDataToolStripMenuItem.Tag.ToString());
                    frmStatisticalData.MdiParent = this;
                    frmStatisticalData.Show();
                    frmStatisticalData.Location = fLocation;
                }
            }

            private Form frmMarketSegment = null;
            private void marketSegmentToolStripMenuItem_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmMarketSegment))
                {
                    frmMarketSegment = (Form)FolioRegistry.CreateObject(marketSegmentToolStripMenuItem.Tag.ToString());
                    frmMarketSegment.MdiParent = this;
                    frmMarketSegment.Show();
                    frmMarketSegment.Location = fLocation;
                }
            }
            private Form frmCalendarOfEvents = null;
            private void mnuCalendarOfEvents_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmCalendarOfEvents))
                {
                    frmCalendarOfEvents = (Form)FolioRegistry.CreateObject(mnuCalendarOfEvents.Tag.ToString());
                    frmCalendarOfEvents.MdiParent = this;
                    frmCalendarOfEvents.Show();
                    frmCalendarOfEvents.Location = fLocation;
                }
            }

            private Form frmLostBusiness = null;
            private void mnuLostBusiness_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmLostBusiness))
                {
                    frmLostBusiness = (Form)FolioRegistry.CreateObject(mnuLostBusiness.Tag.ToString());
                    frmLostBusiness.MdiParent = this;
                    frmLostBusiness.Show();
                    frmLostBusiness.Location = fLocation;
                }
            }

            private Form frmBookingInquiries = null;
            private void mnuBookingInquiries_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmBookingInquiries))
                {
                    frmBookingInquiries = (Form)FolioRegistry.CreateObject(mnuBookingInquiries.Tag.ToString());
                    frmBookingInquiries.MdiParent = this;
                    frmBookingInquiries.Show();
                    frmBookingInquiries.Location = fLocation;
                }
            }

            private void toolStripMenuItem60_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmMarketSegment))
                {
                    frmMarketSegment = (Form)FolioRegistry.CreateObject(toolStripMenuItem60.Tag.ToString());
                    frmMarketSegment.MdiParent = this;
                    frmMarketSegment.Show();
                    frmMarketSegment.Location = fLocation;
                }
            }

            private Form frmDropDownConfig = null;
            private void mnuDropDownConfig_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmDropDownConfig))
                {
                    frmDropDownConfig = (Form)FolioRegistry.CreateObject(mnuDropDownConfig.Tag.ToString());
                    frmDropDownConfig.MdiParent = this;
                    frmDropDownConfig.Show();
                    frmDropDownConfig.Location = fLocation;
                }
            }

            private Form frmAvailabilityOfRooms = null;
            private void mnuAvailabilityOfRooms_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmAvailability))
                {
                    frmAvailability = (Form)FolioRegistry.CreateObject(mnuAvailabilityOfRooms.Tag.ToString());
                    frmAvailability.MdiParent = this;
                    frmAvailability.Show();
                    frmAvailability.Location = fLocation;
                }
            }

            private Form frmWeeklyEventSchedules = null;
            private void mnuWeeklyEventSchedules_Click(object sender, EventArgs e)
            {
                closeAllForms();
                if (!isOpen(frmWeeklyEventSchedules))
                {
                    frmWeeklyEventSchedules = (Form)FolioRegistry.CreateObject(mnuWeeklyEventSchedules.Tag.ToString());
                    frmWeeklyEventSchedules.MdiParent = this;
                    frmWeeklyEventSchedules.Show();
                    frmWeeklyEventSchedules.Location = fLocation;
                }
            }

            private void pictureBox1_MouseHover(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Hand;
            }

            private void pictureBox1_MouseLeave(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Arrow;
            }

            private void pictureBox1_DoubleClick(object sender, EventArgs e)
            {
                System.Diagnostics.Process.Start("http:\\www.jinisyssoftware.com");
            }

            private void MDIMainUI_Shown(object sender, EventArgs e)
            {
                tabRooms.TabPages.Remove(tabPage1);
                this.tsmReports.Enabled = false;
                this.inquiryToolStripMenuItem.Enabled = false;
                this.mnuReportGenerator.Enabled = false;
                this.stbHotel.Panels["pnlApplication"].Text = "Loading report resources...";
                this.backgroundWorker1.RunWorkerAsync();

                btnStressTest.Visible = false;
                toolStripShare.Visible = false;
                toolStripGroupBlock.Visible = false;
                toolStripAvailableRoomsToday.Visible = false;
                toolStripFolioLedger.Visible = false;
                toolStripRoute.Visible = false;

                mnuNew.Visible = false;
                mnuOpen.Visible = false;
                mnuClose.Visible = false;
                mnuSave.Visible = false;
                mnuPageSetup.Visible = false;
                mnuPrintPreview.Visible = false;
                mnuPrint.Visible = false;
                sendToToolStripMenuItem.Visible = false;
                tsmEdit.Visible = false;

                mnuGuestPrivileges.Visible = false;
                minibarToolStripMenuItem.Visible = false;
                mnuAgents.Visible = false;
                mnuConfigDrivers.Visible = false;
                
                mnuPromos.Visible = false;
                mnuFloorPlan.Visible = false;
                mnuTelephoneDirectory.Visible = false;
                mnuSetTerminal.Visible = false;
                mnuTransactionCodeSubAccounts.Visible = false;
                mnuHousekeepers.Visible = false;
                mnuHousekeepingJob.Visible = false;
                housekeepingStepProcedureToolStripMenuItem.Visible = false;
                appliedRatesToolStripMenuItem.Visible = false;


                mnuCashiering.Visible = false;
                mnuAudit.Visible = false;
                mnuSingleReservation.Visible = false;
                mnuWaitListReservation.Visible = false;
                mnuGroupBlocking.Visible = false;
                roomCalendarNEWToolStripMenuItem.Visible = false;
                roomAvailabilityToolStripMenuItem.Visible = false;
                mnuAvailableRoomsToday.Visible = false;
                MenuReservationNoRoom.Visible = false;

                menuInhouseGuestsForecast.Visible = false;
                noOfPaxToolStripMenuItem.Visible = false;
                MenutransactionRegisterToolStrip.Visible = false;
                cityLedgerToolStripMenuItem1.Visible = false;
                cityTransferToolStripMenuItem.Visible = false;
                guestByRateCodeToolStripMenuItem.Visible = false;
                mnuInquiryHotelRevenue.Visible = false;
                salesForecsToolStripMenuItem.Visible = false;
                mnuShiftEndorsements.Visible = false;

                mnuGuestReport.Visible = false;
                housekeepingToolStripMenuItem.Visible = false;
                mnuRestaurant.Visible = false;
                mnuOccupancyForecast.Visible = false;
                cityLedgerToolStripMenuItem.Visible = false;

                roomOccupancyToolStripMenuItem.Visible = false;
                mnuRoomStatus.Visible = false;
                mnuRoomAvailability.Visible = false;
                mnuRoomTransfer.Visible = false;

                mnuAllTransaction.Visible = false;
                cmuTransactionsPerCashier.Visible = false;
                mnuCityTransferTransactions.Visible = false;
                mnuVoidedTransactions.Visible = false;
                mnuDailyHotelRevenueReport.Visible = false;

                calculatorToolStripMenuItem.Visible = false;
                notepadToolStripMenuItem.Visible = false;
                captureImageToolStripMenuItem.Visible = false;
                logsToolStripMenuItem.Visible = false;
                mnuAccountingAdjustment.Visible = false;

                mnuTranCodeGLSetup.Visible = false;
                accountingIntegrationSetupToolStripMenuItem.Visible = false;


                if (ConfigVariables.gSAPServer.Trim() != "")
                {
                    SAPCompany _oCompany = new SAPCompany();
                    _oCompany.SAPConnect(ConfigVariables.gSAPServer,
                                            ConfigVariables.gSAPCompanyDB,
                                            ConfigVariables.gSAPDBUsername,
                                            ConfigVariables.gSAPDBPassword,
                                            ConfigVariables.gSAPUsername,
                                            ConfigVariables.gSAPPassword);
                }

            }

            private SyncSAP _formSyncSAP = null;
            private void synchronizeSAPToolStripMenuItem_Click(object sender, EventArgs e)
            {
                _formSyncSAP = new SyncSAP();
                if (!isOpen(_formSyncSAP))
                {
                    _formSyncSAP.Show();
                }
            }

            //Kevin  Oliveros 2014-04-29
            private Form frmTopClients= null;
            private void topClientsToolStripMenuItem_Click(object sender, EventArgs e)
            {
              
                if (!isOpen(frmTopClients))
                {
                    frmTopClients = (Form)FolioRegistry.CreateObject(topClientsToolStripMenuItem.Tag.ToString());
                    frmTopClients.MdiParent = this;
                    frmTopClients.Show();
                    frmTopClients.Location = fLocation;
                }
            }

            private TransactionCodeMappingUI_ExactGlobe lFrmSapIntegration = null;
            private void accountingIntegrationSetupToolStripMenuItem_Click(object sender, EventArgs e)
            {
                lFrmSapIntegration = new TransactionCodeMappingUI_ExactGlobe();
                if (!isOpen(lFrmSapIntegration))
                {
                    lFrmSapIntegration.Show();
                }

            }
            private Form lFrmHistoricalEventAndRevenueUI = null;
            private void historicalEventsAndRevenueToolStripMenuItem_Click(object sender, EventArgs e)
            {
               // lFrmHistoricalEventAndRevenueUI = new StatisticAccountTypeUI();
                if (!isOpen(lFrmHistoricalEventAndRevenueUI))
                {
                    lFrmHistoricalEventAndRevenueUI = (Form)FolioRegistry.CreateObject(historicalEventsAndRevenueToolStripMenuItem.Tag.ToString());
                    lFrmHistoricalEventAndRevenueUI.MdiParent = this;
                    lFrmHistoricalEventAndRevenueUI.Show();
                    lFrmHistoricalEventAndRevenueUI.Location = fLocation;
                }
            }

            private Form lFrmStatisticAccountTypeUI = null;
            private void clientTypeReportToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //lFrmStatisticAccountTypeUI = new StatisticAccountTypeUI();
                if (!isOpen(lFrmStatisticAccountTypeUI))
                {
                    lFrmStatisticAccountTypeUI = (Form)FolioRegistry.CreateObject(clientTypeReportToolStripMenuItem.Tag.ToString());
                    lFrmStatisticAccountTypeUI.MdiParent = this;
                    lFrmStatisticAccountTypeUI.Show();
                    lFrmStatisticAccountTypeUI.Location = fLocation;
                }
            }

            private void MDIMainUI_FormClosing(object sender, FormClosingEventArgs e)
            {
                SAPCompany _oSapCompany = new SAPCompany();
                if (GlobalVariables.goIsConnectedToBackOffice==true)
                {
                    _oSapCompany.disconnectFromSAP();
                }
            }

                      
            //private Form frmEvents = null;
            //private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    //Close all active forms
            //    //closeAllForms();

            //    if (!isOpen(frmEvents))
            //    {

            //        frmEvents = (Form)FolioRegistry.CreateObject("Jinisys.Hotel.Reservation.Presentation.EventsUI");
            //        frmEvents.MdiParent = this;
            //        frmEvents.Show();
            //        frmEvents.Location = fLocation;
            //    }
            //}
            
        }		

	}
	
}
