
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;

using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.NightAudit.BusinessLayer;
using Jinisys.Hotel.Utilities.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Cashier.BusinessLayer;

using System.Data.Odbc;

namespace Jinisys.Hotel.NightAudit.Presentation
{
    public class DayEndClosingUI : Jinisys.Hotel.UIFramework.TransactionUI
    {

        #region " Windows Form Designer generated code "

        public DayEndClosingUI()
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
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblCheckPostAllFolioTrans;
        internal System.Windows.Forms.Label lblCheckPost;
        private Label lblDate;
        internal Label lblgAuditDate;
        internal Label label3;
        private Panel panel1;
        private PictureBox picProgress;
        internal Label label4;
        internal Label label8;
        internal Label label9;
        internal Label lblCheckgAuditDate;
        internal Label label11;
        internal Label label12;
        internal Label lblCheckFinish;
        internal Label lblFinish;
        internal Label label5;
        internal Label lblNoOfGuestPosted;
        internal System.Windows.Forms.Label lblCheckReports;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblCheckPostAllFolioTrans = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblCheckReports = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblgAuditDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoOfGuestPosted = new System.Windows.Forms.Label();
            this.lblCheckFinish = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.lblCheckgAuditDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.lblCheckPost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(338, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(266, 386);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 31);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblCheckPostAllFolioTrans
            // 
            this.lblCheckPostAllFolioTrans.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblCheckPostAllFolioTrans.Location = new System.Drawing.Point(58, 105);
            this.lblCheckPostAllFolioTrans.Name = "lblCheckPostAllFolioTrans";
            this.lblCheckPostAllFolioTrans.Size = new System.Drawing.Size(32, 32);
            this.lblCheckPostAllFolioTrans.TabIndex = 25;
            this.lblCheckPostAllFolioTrans.Text = "ü";
            this.lblCheckPostAllFolioTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckPostAllFolioTrans.Visible = false;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(97, 114);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(161, 15);
            this.Label6.TabIndex = 24;
            this.Label6.Text = "Post All Folio Transactions.";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(97, 78);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(123, 14);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "Post Room Charges.";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(86, 16);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Processes :";
            // 
            // lblCheckReports
            // 
            this.lblCheckReports.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblCheckReports.Location = new System.Drawing.Point(58, 141);
            this.lblCheckReports.Name = "lblCheckReports";
            this.lblCheckReports.Size = new System.Drawing.Size(32, 32);
            this.lblCheckReports.TabIndex = 27;
            this.lblCheckReports.Text = "ü";
            this.lblCheckReports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckReports.Visible = false;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(97, 149);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(161, 15);
            this.Label7.TabIndex = 26;
            this.Label7.Text = "Generates Day-End Reports";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(20, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 16);
            this.lblDate.TabIndex = 29;
            this.lblDate.Text = "Audit Date :";
            // 
            // lblgAuditDate
            // 
            this.lblgAuditDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgAuditDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgAuditDate.Location = new System.Drawing.Point(97, 26);
            this.lblgAuditDate.Name = "lblgAuditDate";
            this.lblgAuditDate.Size = new System.Drawing.Size(307, 23);
            this.lblgAuditDate.TabIndex = 30;
            this.lblgAuditDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(9, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 46);
            this.label3.TabIndex = 27;
            this.label3.Text = "Note: This process should be executed only once for every audit date. Executing t" +
                "his would result the audit date to increment 1 day. ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNoOfGuestPosted);
            this.panel1.Controls.Add(this.lblCheckFinish);
            this.panel1.Controls.Add(this.lblFinish);
            this.panel1.Controls.Add(this.lblCheckgAuditDate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.picProgress);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.lblCheckPost);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.lblCheckReports);
            this.panel1.Controls.Add(this.lblCheckPostAllFolioTrans);
            this.panel1.Controls.Add(this.Label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(19, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 299);
            this.panel1.TabIndex = 33;
            // 
            // lblNoOfGuestPosted
            // 
            this.lblNoOfGuestPosted.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfGuestPosted.ForeColor = System.Drawing.Color.Red;
            this.lblNoOfGuestPosted.Location = new System.Drawing.Point(236, 79);
            this.lblNoOfGuestPosted.Name = "lblNoOfGuestPosted";
            this.lblNoOfGuestPosted.Size = new System.Drawing.Size(145, 14);
            this.lblNoOfGuestPosted.TabIndex = 43;
            this.lblNoOfGuestPosted.Text = "Post Room Charges.";
            this.lblNoOfGuestPosted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNoOfGuestPosted.Visible = false;
            // 
            // lblCheckFinish
            // 
            this.lblCheckFinish.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblCheckFinish.Location = new System.Drawing.Point(58, 212);
            this.lblCheckFinish.Name = "lblCheckFinish";
            this.lblCheckFinish.Size = new System.Drawing.Size(32, 32);
            this.lblCheckFinish.TabIndex = 41;
            this.lblCheckFinish.Text = "ü";
            this.lblCheckFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckFinish.Visible = false;
            // 
            // lblFinish
            // 
            this.lblFinish.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinish.Location = new System.Drawing.Point(97, 220);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(161, 15);
            this.lblFinish.TabIndex = 40;
            this.lblFinish.Text = "Finish";
            this.lblFinish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCheckgAuditDate
            // 
            this.lblCheckgAuditDate.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblCheckgAuditDate.Location = new System.Drawing.Point(58, 178);
            this.lblCheckgAuditDate.Name = "lblCheckgAuditDate";
            this.lblCheckgAuditDate.Size = new System.Drawing.Size(32, 32);
            this.lblCheckgAuditDate.TabIndex = 38;
            this.lblCheckgAuditDate.Text = "ü";
            this.lblCheckgAuditDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckgAuditDate.Visible = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(97, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 15);
            this.label11.TabIndex = 37;
            this.label11.Text = "Increment Audit Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(58, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 32);
            this.label12.TabIndex = 39;
            this.label12.Text = "ü";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picProgress
            // 
            this.picProgress.Image = global::Jinisys.Hotel.NightAudit.Properties.Resources.balls_white;
            this.picProgress.Location = new System.Drawing.Point(304, 20);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(32, 32);
            this.picProgress.TabIndex = 33;
            this.picProgress.TabStop = false;
            this.picProgress.Visible = false;
            // 
            // lblCheckPost
            // 
            this.lblCheckPost.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblCheckPost.Location = new System.Drawing.Point(58, 68);
            this.lblCheckPost.Name = "lblCheckPost";
            this.lblCheckPost.Size = new System.Drawing.Size(32, 32);
            this.lblCheckPost.TabIndex = 22;
            this.lblCheckPost.Text = "ü";
            this.lblCheckPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCheckPost.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(58, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 32);
            this.label4.TabIndex = 34;
            this.label4.Text = "ü";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(58, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 32);
            this.label8.TabIndex = 36;
            this.label8.Text = "ü";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(58, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 32);
            this.label9.TabIndex = 35;
            this.label9.Text = "ü";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(58, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 32);
            this.label5.TabIndex = 42;
            this.label5.Text = "ü";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayEndClosingUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(427, 443);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblgAuditDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "DayEndClosingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day End Closing";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DayEndClosingUI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        private PostRoomChargesFacade oPostRoomChargeFacade;
        private ArrayList lstReports = new ArrayList();

        #endregion

        #region " METHODS "

        #endregion

        #region " EVENTS "

        private void btnShowReports_Click(System.Object sender, System.EventArgs e)
        {
            //DayEndReportsListUI dayEndReportsListUI = new DayEndReportsListUI(lstReports);
            //dayEndReportsListUI.ShowDialog(this);
        }

        private void DayEndClosingUI_Load(object sender, System.EventArgs e)
        {
            this.lstReports.Add("getActualArrivalReport");
            this.lstReports.Add("getActualDepartureReport");
            this.lstReports.Add("getInHouseGuests");
            this.lstReports.Add("getExpectedArrivalReport");
            this.lstReports.Add("getExpectedDepartureReport");
            this.lstReports.Add("getCancelledReservation");
            this.lstReports.Add("getGuestLedger");
            this.lstReports.Add("getRoomAvailability");
            this.lstReports.Add("getRoomTransferReport");
            this.lstReports.Add("getRoomOccupancy");
            this.lstReports.Add("getDailyTransactions");
            this.lstReports.Add("getSalesReport");
            this.lstReports.Add("getSalesReport");
            this.lstReports.Add("getSalesReport");
            this.lstReports.Add("getSalesSummary");
            this.lstReports.Add("getTransactionRegisterReport");
            this.lstReports.Add("getCityLedger");
            this.lstReports.Add("getCityTransaferTransactions");


            this.lblgAuditDate.Text = string.Format("{0:dddd, MMMM dd, yyyy}",DateTime.Parse(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gAuditDate));
        }


        private OpenShiftFacade oOpenShiftFacade;

        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
            // double checks if double posting is about to happen
            AuditFacade oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
            string _AuditDate = oAuditFacade.getCurrentAuditDate();
            GlobalVariables.gAuditDate = _AuditDate;
            this.lblgAuditDate.Text = string.Format("{0:dddd, MMMM dd, yyyy}",DateTime.Parse(GlobalVariables.gAuditDate));


            Type t = GlobalVariables.gMDI.GetType();
            t.GetMethod("updateAuditDate").Invoke(GlobalVariables.gMDI, null);

            // till here ----------------------------------

            ReferenceTimeFACADE oRefFacade = new ReferenceTimeFACADE();
            ReferenceTime oRefTime = oRefFacade.GetReferenceTime();
            oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
           
            Audit oAudit = oAuditFacade.getCurrentAudit(GlobalVariables.gAuditDate);
                       
            TimeSpan ServerTime = TimeSpan.Parse(oAuditFacade.getServerTime());
            String strMaxTime = string.Format("{0:HH:mm:ss}",DateTime.Parse(oRefTime.RefTime).AddHours(oRefTime.Maximum));
            String strMinTime = string.Format("{0:HH:mm:ss}", DateTime.Parse(oRefTime.RefTime).AddHours(oRefTime.Minimum));
            TimeSpan MaxTime = TimeSpan.Parse(strMaxTime);
            TimeSpan MinTime = TimeSpan.Parse(strMinTime);
           
            DateTime incrementedDate = DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1);
            DateTime lstProcessedDate = DateTime.Parse(oAuditFacade.getLastProcessedgAuditDate());
            TimeSpan t1 = new TimeSpan(0, 0, 0);
            TimeSpan t2 = new TimeSpan(23, 59, 59);
            bool cond1 = ServerTime >= MinTime && ServerTime <= t2;
            bool cond2 = ServerTime >= t1 && ServerTime <= MaxTime;
            bool isWithin = cond1 || cond2;
            DateTime ServerDateAndTime = DateTime.Parse(oAuditFacade.getServerDateAndTime());
            int Hoursdiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Hour, lstProcessedDate, ServerDateAndTime);
            int DaysDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, ServerDateAndTime.Date, incrementedDate.Date);
            if (isWithin)
            {
                if ((oAudit.Meridian == "PROCESSED") || (DaysDiff > 1) || (Hoursdiff < 8))
                {
                    MessageBox.Show("Night audit has been processed at " + lstProcessedDate.ToString() + "!", "Night Audit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("The time now is " + string.Format("{0:HH:mm:ss}",ServerTime) + ", But Night audit has been set to be processed between " + string.Format("{0:HH:mm:ss}",MinTime) + " and " + string.Format("{0:HH:mm:ss}",MaxTime), "Night audit not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // checks if all Cash Drawers are closed
            oOpenShiftFacade = new OpenShiftFacade();
            DataSet dsTerminal = new DataSet();

            dsTerminal = (DataSet)oOpenShiftFacade.GetType().GetMethod("GetCashierTerminals").Invoke(oOpenShiftFacade, null);

            foreach (DataRow dRow in dsTerminal.Tables[0].Rows)
            {
                if (dRow["Status"].ToString() == "OPEN")
                {
                    MessageBox.Show("Cash Terminal " + dRow["TerminalId"].ToString() + "(" + dRow["UpdatedBy"].ToString() + ") is still open." + "\r\nPlease close all cash drawer before proceeding this process.", "Day-End Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            // newly added March 31, 2008
            // this is to check wether there are still EXPECTED CHECKOUT 
            // for this day, CANT PROCEED DAY-END CLOSING if there are still
            // EXPECTED CHECKOUT'
            try
            {
                string overrideNightAudit = ConfigVariables.gNightAuditOverride;

                if (overrideNightAudit == "NO")
                {

                    int expectedCheckOutCount = 0;
                    int expectedCheckInCount = 0;
                    int groupRoomBlocks = 0;

                    oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
                    expectedCheckOutCount = oAuditFacade.countTodaysExpectedCheckOut();
                    expectedCheckInCount = oAuditFacade.countTodaysExpectedCheckIn();
                    groupRoomBlocks = oAuditFacade.countTodaysGroupRoomBlocks();

                    if (groupRoomBlocks > 0)
                    {
                        MessageBox.Show("Can't proceed night audit, there are still group room blockings.\r\nPlease check schedules of group dependents.\r\n\r\nTo view guest list, press F4.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (expectedCheckOutCount > 0)
                    {
                        MessageBox.Show("Can't proceed night audit, there are still pending check out.\r\nPlease check guest schedules from Guest List.\r\n\r\nTo view guest list, press F4.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (expectedCheckInCount > 0)
                    {
                        MessageBox.Show("Can't proceed night audit, there are still pending check in.\r\nPlease check guest schedules from Guest List, under Confirmed or Wait List status \r\n and group schedules from Group Reservation Listing.\r\n\r\nTo view guest list, press F4.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting expected checkout/check in.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // confirm nyt audit process
            if (MessageBox.Show("Are you sure you want to Process Day-End Closing", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            

			AuditFacade _oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
			DayEndProcessConfig _oDayEndProcessConfig = _oAuditFacade.getDayEndProcessConfig();

			if (_oDayEndProcessConfig.BackupDatabase == 1)
			{
				//>> do Database Backup (after processing night audit)
				backupDatabase("MN");
				//>> end Database Backup
			}

            this.picProgress.Visible = true;
            this.picProgress.Location = this.lblCheckPost.Location;
            
            this.Cursor = Cursors.WaitCursor;

            oPostRoomChargeFacade = new PostRoomChargesFacade();

            //>>start of Night Audit process
            if (oPostRoomChargeFacade.initializePostRoomCharges() == true)
            {
                this.lblNoOfGuestPosted.Visible = true;
                this.lblNoOfGuestPosted.Text = oPostRoomChargeFacade.noOfGuestPosted + " Guest Posted.";

                this.lblCheckPost.Visible = true;

                // posting of Folio Transactions
                this.picProgress.Location = this.lblCheckPostAllFolioTrans.Location;
                oPostRoomChargeFacade.PostFolioTransactions();

                //posting of Hotel Revenue
                ReportFacade _oReportFacade = new ReportFacade();
                _oReportFacade.postHotelRevenue(GlobalVariables.gAuditDate);

                this.lblCheckPostAllFolioTrans.Visible = true;

                // reports
                this.picProgress.Location = this.lblCheckReports.Location;

                oPostRoomChargeFacade.generateReports();
                this.lblCheckReports.Visible = true;

                // back office postings

                
                // audit date
                this.picProgress.Location = this.lblCheckgAuditDate.Location;

                oPostRoomChargeFacade.IncrementgAuditDate();
                this.lblCheckgAuditDate.Visible = true;

                // finish
                this.picProgress.Location = this.lblCheckFinish.Location;
                this.lblCheckFinish.Visible = true;

                this.lblFinish.Text = "Finish  ( Successful )";
                this.lblFinish.ForeColor = Color.Red;
                this.picProgress.Visible = false;
            }

            t = GlobalVariables.gMDI.GetType();
            t.GetMethod("updateAuditDate").Invoke(GlobalVariables.gMDI, null);
            this.lblgAuditDate.Text = string.Format("{0:dddd, MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));
            //>> end of Night Audit process

			if (_oDayEndProcessConfig.BackupDatabase == 1)
			{
				//>> do Database Backup (after processing night audit)
				backupDatabase("");
				//>> end Database Backup
			}

            //this.Close();
            this.btnOk.Enabled = false;
            this.btnCancel.Text = "&Close";

            try
            {
                Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
                MethodInfo objMethod = objectType.GetMethod("plotCurrentDayRoomStatus");
                objMethod.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion



        private void ProgressPostRoomCharges()
        {
            this.picProgress.Visible = true;
            this.picProgress.Location = this.lblCheckPost.Location;
        }


		public void backupDatabase(string fileNameSuffix)
		{
			//>> do Database Backup
			try
			{
				string _backUpBATFile = Application.StartupPath + "\\backup.bat";

				string _fileName = Application.StartupPath + "\\DB Backup\\" + GlobalVariables.gAuditDate.Replace("-", "") + fileNameSuffix;
				string _db = GlobalVariables.gPersistentConnection.Database;
				string _dbUser = GlobalVariables.gPersistentConnection.Database;
                string _dbPassword = GlobalVariables.gPersistentConnection.Database;
				string _dbHost = GlobalVariables.gPersistentConnection.DataSource;

                string _connectionStr = ConfigurationManager.AppSettings.Get("connection");
                string[] strArr = _connectionStr.Split(';');
                foreach (string strTemp in strArr)
                {
                    if (strTemp.StartsWith("user id"))
                    {
                        _dbUser = strTemp.Substring(strTemp.IndexOf('=') + 1);
                    }
                    else if (strTemp.StartsWith("password"))
                    {
                        _dbPassword = strTemp.Substring(strTemp.IndexOf('=') + 1);
                    }
                }

				StreamReader strReader = new StreamReader(Application.StartupPath + "\\backup.bat");
				string strorig = strReader.ReadToEnd();
				string str;
				str = string.Copy(strorig);
                //str = str.Replace("%dbname%", _db);
                //str = str.Replace("%fname%", _fileName);
				str = str.Replace("%user%", _dbUser);
				str = str.Replace("%dbpass%", _dbPassword);
				str = str.Replace("%dbHost%", _dbHost);
                str = str.Replace("%fname%", _fileName);

				//MessageBox.Show(str);
				strReader.Close();
				StreamWriter strWriter = new StreamWriter(_backUpBATFile);
				strWriter.Write(str);
				strWriter.Close();
				System.Diagnostics.Process.Start(_backUpBATFile);
				System.Threading.Thread.Sleep(2000);
				strWriter = new StreamWriter(_backUpBATFile);
				strWriter.Write(strorig);
				strWriter.Close();

			}
			catch (Exception ex)
			{
				//MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message,"Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//>> end Database Backup
		}

    }
}