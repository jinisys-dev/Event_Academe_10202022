using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Reflection;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.IO;
using Jinisys.Hotel.Reports.BusinessLayer;
using System.Diagnostics;
using Jinisys.Hotel.Cashier.Presentation;
using CrystalDecisions.Shared;
using System.Configuration;
using Jinisys.Hotel.NightAudit.BusinessLayer;
using C1.Win.C1FlexGrid;
using Jinisys.Hotel.Utilities.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;


namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class MarketingUI : Jinisys.Hotel.UIFramework.TransactionUI
    {

        #region " VARIABLES "

        private bool lIsEventManagementDisabled = false;
        private bool lIsChildFolioViewed = false;
        private string lChildFolioStatus;
        private string lGroupFolioStatus;

        private string lFolioNo;
        private string lEventNo;
        private Company loCompany = new Company();
        private Agent loAgent = new Agent();
        private Folio loFolio;
        private DateTime lToDate;
        private DateTime lFromDate;
        private decimal lBalance;

        private RoomEventFacade loRoomEventFacade = new RoomEventFacade();
        private ScheduleFacade loScheduleFacade = new ScheduleFacade();
        private CompanyFacade loCompanyFacade ;
        private AgentFacade loAgentFacade;
        private FolioFacade loFolioFacade ;
        private EventFacade loEventFacade;
        private ComboBox lcboReqDates = new ComboBox();
        private bool lCanAddEventOfficer = false;
        private bool lCanAddMarketingOfficer = false;
      

        private DataReaderBinder loDataReaderBinder = new DataReaderBinder();
        private FormToObjectInstanceBinder loFormToObjectInstance = new FormToObjectInstanceBinder();
        private Sequence loSequence = new Sequence();

        private C1.Win.C1FlexGrid.C1FlexGrid lSubFolioGrid;
        private string lFlag;


        private string lMessage;

        private string lCode;
        private string lCharge;

        private bool lEdit;

        private string lPackageID;
        private string lDaysApplied;
        private string lPackageName;


        private int lItemIndex;
        private string lTranCode;
        private decimal lTotalPayment = 0;


        private ComboBox lSetup = new ComboBox();
        private ComboBox lActivity = new ComboBox();

        private ComboBox lPersonType = new ComboBox();
        private bool _canAddEventOfficer = false;

        private bool isReinstated = false;
        private String[] aReservationStatus = { "TENTATIVE", "WAIT LIST", "CONFIRMED", "ONGOING", "CLOSED", "CANCELLED", "NO SHOW" };
        DataTable loUserList;


        private SaveFileDialog sfdExport;
        private OpenFileDialog ofdUpload;
        private GuestFacade loGuestFacade;
        #endregion

        #region "Shared Variables/Methods"
        private static AccountType mAccountType;
        public static AccountType ACCOUNT_TYPE
        {
            
            set
            {
                mAccountType = value;
            }
        }
        private static ArrayList tmpFolio = new ArrayList();
        public static void AddTempFolio(string val)
        {
            tmpFolio.Add(val);
        }
        private static string mcompanyid;
        public static string companyid
        {
            set
            {
                mcompanyid = value;
            }
        }
        #endregion
  
        #region Constructors


        private void InitializeFacades()
        {
            loFolioFacade = new FolioFacade();
            loScheduleFacade = new ScheduleFacade();
            loRoomEventFacade = new RoomEventFacade();
            loCompanyFacade = new CompanyFacade();
            loAgentFacade = new AgentFacade();
            loEventFacade = new EventFacade();
            loGuestFacade = new GuestFacade();

            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
        }


        public MarketingUI()
        {
            InitializeComponent();
            InitializeFacades();
            loFolio = new Folio();
     
            lGroupFolioStatus = "New";
            txtFolioID.Text = "AUTO";

            loadEvent();
            loadGroupBookingDropDown();


            loAgent = new Agent();

            //if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
            //{
            //    loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
            //    txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
            //}
            //else
            //{
            //    txtagentid.Text = "";
            //}


            pnlNew.Visible = true;
            lFlag = "Edit";
            //loadFolioRecurringCharges();
            loadEvent();
            lGroupFolioStatus = "New";
            lFlag = "New";

            KeypressTextboxHandler(this, false);
            //txtCompanyId_TextChanged();

            //loadPackages();

            //loadCountries();
            ////loadRooms();
            //getCharges(grdRecurringCharges);
            //getCharges(gridTransactionCodes);

            //LoadFolioRouting(loFolio);
            //loadFolioPrivileges();
            //loadFolioPackage();
            ////loadContractAmendments();

            //grdFolio.Sort(SortFlags.Ascending, 2, 3);
            //gridTransactionCodes_Click(this, new EventArgs());

            loSequence = new Sequence();
            //lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");

            txtFolioID.Text = "AUTO";
            //loFolio.FolioID = lFolioNo;
            //dtpFromDate.Text = GlobalVariables.gAuditDate;
            //dtpTodate.Text = GlobalVariables.gAuditDate; 
  
        }



        public MarketingUI(Folio pFolio)
        {

            InitializeComponent();
            loadGroupBookingDropDown();
            isReinstated = true;

            lGroupFolioStatus = "Old";
            loFolio = pFolio;
            lFolioNo = pFolio.FolioID;
            loFolio.Status = "TENTATIVE";
            //lSubFolioGrid = pGridFolios;
            FacadeDeclarations();

            Control myForm = this;
            FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            mcompanyid = loFolio.CompanyID;
           // grdFolio.AllowEditing = false;
            //txtGroupRemarks.Text = "Reinstated from " + loFolio.FolioID + " : " + loFolio.Remarks;

            //GetChildFolios();
            switch (mAccountType)
            {
                case AccountType.Corporate:
                case AccountType.Personal:

                    if (mcompanyid.StartsWith("G"))
                    {
                        loCompany = new Company();

                        rdbCompany.Checked = true;
                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        loFolio.Company = loCompany;
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    else
                    {
                        Guest _oGuest = new Guest();

                        rdbIndividual.Checked = true;
                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(mcompanyid);

                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    break;
                //case "AGENT":

                //    break;
            }
            loAgent = new Agent();

            //if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
            //{
            //    loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
            //    txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
            //}
            //else
            //{
            //    txtagentid.Text = "";
            //}
            pnlNew.Visible = true;
            lFlag = "Edit";
            loadFolioRecurringCharges();
            loadEvent();
            lGroupFolioStatus = "New";
            lFlag = "New";

            KeypressTextboxHandler(this, false);
            txtCompanyId_TextChanged();
            getCharges(grdRecurringCharges);
            loSequence = new Sequence();
            lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");
            txtFolioID.Text = "AUTO";
        }
      
        //CONSTRUCTOR FOR A NEW RESERVATION
        public MarketingUI(C1.Win.C1FlexGrid.C1FlexGrid pGridFolios)
        {
            InitializeComponent();
            //loadGroupBookingDropDown();
            loSequence = new Sequence();
            loFolioFacade = new FolioFacade();
            loFolio = new Folio();
            // lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");
            txtFolioID.Text = lFolioNo;

            txtCreateTime.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            //txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
            cboStatus.Text = "TENTATIVE";
            //cboAccountType.Text = AccountType.Corporate.ToString().ToUpper();
            //cboPayment_Mode.Text = "CASH";
            //cboPurpose.Text = "BUSINESS";
            rdbCompany.Checked = true;

            lGroupFolioStatus = "New";
            lSubFolioGrid = pGridFolios;
            pnlNew.Visible = true;
            lFlag = "New";

            KeypressTextboxHandler(this, false);
            //getCharges(grdRecurringCharges);
            //getCharges(gridTransactionCodes);
            //loadCountries();

            //>>by Genny: Apr. 30, 2008
            //get all Room Types
            //RoomType _oRoomType = new RoomType();
            //RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
            //_oRoomType = (RoomType)_oRoomTypeFacade.loadObject();

            //DataView _dtvRoomTypes = _oRoomType.Tables[0].DefaultView;
            //_dtvRoomTypes.RowStateFilter = DataViewRowState.OriginalRows;
            //_dtvRoomTypes.RowFilter = "roomTypeCode not like '*FUNCTION*'";
            //foreach (DataRowView _dRow in _dtvRoomTypes)
            //{
            //    string[] items ={ _dRow["roomtypecode"].ToString(), "0", "0", "0", "0", "0", "0", "0" };
            //    gridRooms.AddItem(items);
            //}
            //grdFolio.Sort(SortFlags.Ascending, 2, 3);//<<

        }
     

      

        //constructor from the Guest List
        public MarketingUI(string pFolioID)
        {
            InitializeComponent();
            string test = "";/// cboSource.Text;
            lGroupFolioStatus = "Old";
            isReinstated = true;
            loFolio = new Folio();
            lFolioNo = pFolioID;
            //lSubFolioGrid = pGridFolios;
            FacadeDeclarations();

            loFolio = loFolioFacade.GetFolio(pFolioID);
            Control myForm = this;
            FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            mcompanyid = loFolio.CompanyID;
         
            loadGroupBookingDropDown();
            GetChildFolios();
            switch (mAccountType)
            {
                case AccountType.Corporate:
                case AccountType.Personal:

                    if (mcompanyid.StartsWith("G"))
                    {

                        loCompany = new Company();
                        rdbCompany.Checked = true;
                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        loFolio.Company = loCompany;
                        //cboAccountType.SelectedItem = loFolio.AccountType;
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    else
                    {
                        Guest _oGuest = new Guest();

                        rdbIndividual.Checked = true;
                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(mcompanyid);

                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    break;
                //case "AGENT":

                //    break;
            }
            loAgent = new Agent();
            btnEdit.Visible = true;
            grpEventInfo.Enabled = false;
            lFlag = "Edit";
            loadEvent();
            KeypressTextboxHandler(this, true);
            loadFolioRecurringCharges();
            loadContractAmendments();
            getCharges(grdRecurringCharges);
          
            loadRequirementDetails();
            getRequirementsSchedules();
            loadFolio();
           
        }

        

        #endregion
        
        #region " METHODS "

        public int getIndex(string str, string[] aStr)
        {
            int index = -1;
            for (int i = 0; i < aStr.Length; i++)
            {
                if (aStr[i] == str)
                {
                    index = i;
                }
            }
            return index;
        }
     


        public void saveBookingInfo(ref MySqlTransaction pTrans)
        {
            GenericList<EventBookingInfo> _oEventBookingInfoList = new GenericList<EventBookingInfo>();
            _oEventBookingInfoList = loEventFacade.getEvent(txtFolioID.Text);

            foreach (EventBookingInfo _oEventBookingInfo in _oEventBookingInfoList)
            {
                _oEventBookingInfo.FolioID = txtFolioID.Text;
                _oEventBookingInfo.CREATEDBY = GlobalVariables.gLoggedOnUser;
                _oEventBookingInfo.UPDATEDBY = GlobalVariables.gLoggedOnUser;
                _oEventBookingInfo.HotelID = GlobalVariables.gHotelId;
                _oEventBookingInfo.PackageAmount = decimal.Parse(txtPackageAmount.Text);
              
               
                try
                {
                    _oEventBookingInfo.EstimatedTotalCost = decimal.Parse(txtTotalEstimatedCost.Text);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error in saving folio. \r\nPlease check the total estimated cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;
                    throw new Exception("Error in saving folio. \r\nPlease check the total estimated cost.\n\n" + ex.Message);
                }

                bool _isEventExist = loEventFacade.checkEventExists(txtFolioID.Text);

                if (_isEventExist == false)
                {
                    _oEventBookingInfo.BookingDate = DateTime.Now;
                    loEventFacade.insertEvents(_oEventBookingInfo, ref pTrans);
                }//end of mflag=="new"

                else //if (lFlag == "New" && _isEventExist == true)
                {
                    _oEventBookingInfo.BookingDate = DateTime.Parse(txtCreateTime.Text);
                    loEventFacade.updateEvents(_oEventBookingInfo, ref pTrans);
                }
                //else
                //{
                //    loEventFacade.updateEvents(_oEventBookingInfo);
                //}

                //>>applied _oAppliedRates
                ////EventAppliedRates _oEventAppliedRates = new EventAppliedRates();
                ////EventAppliedRatesFacade _oEventAppliedRatesFacade = new EventAppliedRatesFacade();
                ////_oEventAppliedRatesFacade.deleteAppliedRates(txtFolioID.Text, ref pTrans);

                ////int _counter = 1;
                ////int _rowCount = gridBilling.Rows.Count;
                ////foreach (C1.Win.C1FlexGrid.Row _cntRow in gridBilling.Rows)
                ////{
                ////    try
                ////    {
                ////        if (_cntRow.Index != 0 && gridBilling.GetDataDisplay(_counter, 0) != "") //_counter < _rowCount - 1)
                ////        {
                ////            _oEventAppliedRates.FolioID = txtFolioID.Text;
                ////            _oEventAppliedRates.Description = gridBilling.GetDataDisplay(_counter, 0);
                ////            _oEventAppliedRates.RateAmount = decimal.Parse(gridBilling.GetDataDisplay(_counter, 1));
                ////            _oEventAppliedRates.NumberOfOccupants = int.Parse(gridBilling.GetDataDisplay(_counter, 2));
                ////            _oEventAppliedRates.RateType = gridBilling.GetDataDisplay(_counter, 3);

                ////            _oEventAppliedRatesFacade = new EventAppliedRatesFacade();
                ////            _oEventAppliedRatesFacade.saveAppliedRates(_oEventAppliedRates, ref pTrans);
                ////            _counter++;
                ////        }
                ////    }
                ////    catch (Exception ex)
                ////    {
                ////        throw new Exception("Error in saving applied rates. Please check details \r\n\r\nError message : " + ex.Message);
                ////    }
                ////}//<<
            }
        }

        private void DisableControls(Control pControl, bool pTrueFalse)
        {

            Control pCntrol;
            foreach (Control _tempLoopVarCntrol in pControl.Controls)
            {
                pCntrol = _tempLoopVarCntrol;
                if (pCntrol is TabControl || pCntrol is Panel || pCntrol is GroupBox || pCntrol is ListView)
                {
                    if (pCntrol is TabPage && pCntrol.Name.Contains("_"))
                    {
                    }
                    else
                    {
                        pCntrol.Enabled = true;
                        DisableControls(pCntrol, pTrueFalse);
                    }
                }
                else
                {
                    if (pCntrol.Name != "btnNewMeal" || pCntrol.Name != "btnSaveMeal")
                        pCntrol.Enabled = pTrueFalse;
                }
            }

        }
        private void KeypressTextboxHandler(Control ctrl, bool handle)
        {
            Control _ctrl1;
            foreach (Control _tempLoopVarCtrl1 in ctrl.Controls)
            {
                _ctrl1 = _tempLoopVarCtrl1;
                if (_ctrl1 is Panel || _ctrl1 is GroupBox)
                {
                    KeypressTextboxHandler(_ctrl1, handle);
                }
                else if (_ctrl1 is TextBox
                         || _ctrl1 is NumericUpDown
                         || _ctrl1 is ComboBox)
                {
                    if (_ctrl1.Name != "txtCharge"
                        && _ctrl1.Name != "txtAmountRCharge"
                        && _ctrl1.Name != "txtGroupName"
                        && _ctrl1.Name != "txtSearch"
                        && _ctrl1.Name != "txtLastName"
                        && _ctrl1.Name != "txtFirstName"
                        && _ctrl1.Name != "txtMiddleName"
                        && _ctrl1.Name != "txtCompanyName"
                        && _ctrl1.Name != "txtRemarks"
                        /* Gene
                         * 02-Mar-12
                         * added TIN
                         */
                        && _ctrl1.Name != "txtTIN"
                        && _ctrl1.Name != "txtGroupRemarks")
                    {

                        if (handle == true)
                        {
                            _ctrl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtHandle);
                        }
                        else
                        {
                            _ctrl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(noHandle);
                        }
                    }
                }
            }
        }
        private void txtHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void noHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;
        }


        public void NewEntry()
        {
            newFolio();
        }

        public void SaveEntry()
        {
            btnSave_Click();
        }

        private void loadContractAmendments()
        {
            ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();
            DataTable dtTable = _oAmendmentFacade.getAmendments(txtFolioID.Text);

            foreach (DataRow dtRow in dtTable.Rows)
            {
                grdAmmendments.Rows.Count++;

                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 0, dtRow["AmmendmentID"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 1, dtRow["OldValue"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 2, dtRow["NewValue"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 3, dtRow["ID"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 4, dtRow["CreatedBy"].ToString());
                /* Gene
                 * 01-Mar-12
                 */
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 5, dtRow["CreateTime"].ToString());


            }

            //sort by amendment id ascending
            grdAmmendments.Sort(SortFlags.Ascending, 0);
            grdAmmendments.AutoSizeRows();
            //  grdAmmendments.AutoSizeCols();
            loadSystemAmendments();
        }
        /* FP-SCR-00140 #7 [07.28.2010]
       * added for showing the changes/amendments of the system */
        private void loadSystemAmendments()
        {
            ReportFacade _oReportFacade = new ReportFacade();
            DataTable _dtTable = _oReportFacade.searchChangesLog(txtFolioID.Text, "remarks");
            DataView _dtView = _dtTable.DefaultView;
            string[] _changesLogTables = ConfigVariables.gAmendmentsChangesLogTables.Split(',');

            _dtView.RowStateFilter = DataViewRowState.OriginalRows;
            _dtView.Sort = "DATE_CHANGED ASC";

            if (_changesLogTables.Length > 1)
            {
                string _filter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
                for (int i = 1; i < _changesLogTables.Length; i++)
                {
                    _filter = _filter + " or TABLE_NAME = '" + _changesLogTables[i] + "'";
                }
                _dtView.RowFilter = _filter;
            }
            else if (_changesLogTables.Length == 1)
            {
                _dtView.RowFilter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
            }
            foreach (DataRowView dtRowView in _dtView)
            {
                grdSystemChanges.Rows.Count++;

                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 0, dtRowView["Remarks"].ToString().Split(':')[0]);
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 1, dtRowView["Old_Value"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 2, dtRowView["New_Value"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 3, dtRowView["User_ID"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 4, dtRowView["Date_Changed"].ToString());
            }
            grdSystemChanges.AutoSizeRows();
            grdSystemChanges.AutoSizeCols();
        }
        //CONSTRUCTOR FOR A PREVIOUSLY CREATED RESERVATION
        private void FacadeDeclarations()
        {
            loFolioFacade = new FolioFacade();
            loScheduleFacade = new ScheduleFacade();
            loRoomEventFacade = new RoomEventFacade();
            loCompanyFacade = new CompanyFacade();
            loAgentFacade = new AgentFacade();
            loEventFacade = new EventFacade();
            loGuestFacade = new GuestFacade();

            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
        }

        private void loadGroupBookingDropDown()
        {
            try
            {
                AutoCompleteStringCollection values;
                GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

                DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
                DataView _oDataView = _oDtDropDownValues.DefaultView;

                ////booking source
                //_oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                //_oDataView.RowFilter = "fieldname = 'BookingSource'";

                //if (_oDataView.Count > 0)
                //{
                //    this.cboSource.Items.Clear();
                //    values = new AutoCompleteStringCollection();

                //    foreach (DataRowView _dRowView in _oDataView)
                //    {
                //        values.Add(_dRowView["Value"].ToString());
                //    }
                //    this.cboSource.DataSource = values;
                //}

                //setup
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'FoodSetup'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                }
                this.txtFoodSetup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.txtFoodSetup.AutoCompleteCustomSource = values;
                this.txtFoodSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.txtFoodSetup.Multiline = false;

                //Gene - 9/8/2011
                //this.lSetup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //this.lSetup.AutoCompleteCustomSource = values;
                //this.lSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.lSetup.DataSource = _oDataView.ToTable();
                this.lSetup.ValueMember = "Value";
                this.lSetup.DisplayMember = "Value";
                this.lSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.lSetup.AutoCompleteSource = AutoCompleteSource.ListItems;

                //persontype
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'PersonType'";
                lPersonType.DropDownStyle = ComboBoxStyle.DropDownList;
                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        lPersonType.Items.Add(_dRowView["Value"].ToString());
                    }
                }

                //letterOfProposal
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'LetterOfProposal'";
                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        cboLetterOfProposal.Items.Add(_dRowView["Value"].ToString());
                    }
                }

                //billing arrangement
                //_oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                //_oDataView.RowFilter = "fieldname = 'BookingSource'";
                //values = new AutoCompleteStringCollection();

                //if (_oDataView.Count > 0)
                //{
                //    foreach (DataRowView _dRowView in _oDataView)
                //    {
                //        values.Add(_dRowView["Value"].ToString());
                //    }
                //}
                //this.txtBillingArrangement.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //this.txtBillingArrangement.AutoCompleteCustomSource = values;
                //this.txtBillingArrangement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;




                //if (values.Count > 0)
                //{
                //    txtBillingArrangement.Multiline = false;
                //}
                //else
                //{
                //    this.txtBillingArrangement.Multiline = true;
                //}

                /* FP-SCR-00140 #1 [07.23.2010]
                 * added for auto-complete of Activity field in the grid function room */
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'Activity'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                }

                //Gene - 9/8/2011
                //lActivity.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //lActivity.AutoCompleteCustomSource = values;
                //lActivity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                ////Gene - 9/8/2011
                //lActivity.DataSource = _oDataView.ToTable();
                //lActivity.ValueMember = "Value";
                //lActivity.DisplayMember = "Value";
                //lActivity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //lActivity.AutoCompleteSource = AutoCompleteSource.ListItems;
                ///* end of Activity auto complete */

                ///* added for auto-complete of Account Type */
                //_oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                //_oDataView.RowFilter = "fieldname = 'AccountType'";
                //values = new AutoCompleteStringCollection();

                //if (_oDataView.Count > 0)
                //{
                //    cboAccountType.Items.Clear();
                //    foreach (DataRowView _dRowView in _oDataView)
                //    {
                //        values.Add(_dRowView["Value"].ToString());
                //    }
                //    cboAccountType.DataSource = values;
                //}
                /* end of auto-complete of account type */

                /* added for auto-complete of Payment Mode */
                //_oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                //_oDataView.RowFilter = "fieldname = 'PaymentMode'";
                //values = new AutoCompleteStringCollection();

                //if (_oDataView.Count > 0)
                //{
                //    cboPayment_Mode.Items.Clear();
                //    foreach (DataRowView _dRowView in _oDataView)
                //    {
                //        values.Add(_dRowView["Value"].ToString());
                //    }
                //}
                //cboPayment_Mode.DataSource = values;
                /* end of auto-complete of payment mode */

                /* added for auto-complete of Market Segment */
                //_oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                //_oDataView.RowFilter = "fieldname = 'MarketSegment'";
                //values = new AutoCompleteStringCollection();

                //if (_oDataView.Count > 0)
                //{
                //    cboPurpose.Items.Clear();
                //    foreach (DataRowView _dRowView in _oDataView)
                //    {
                //        values.Add(_dRowView["Value"].ToString());
                //    }
                //    cboPurpose.DataSource = values;
                //}
                ///* end of auto-complete of market segment */
            }
            catch
            {
            }
        }

        private bool isBlankAmountFromRecurringCharge()
        {
            foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
            {
                if (_row.Index != 0)
                {
                    string _amount = grdRecurredCharge.GetDataDisplay(_row.Index, 10);
                    if (_amount == "")
                    {
                        lMessage = "Please Check The Amount in Folio Recurring Charge";
                        return true;
                    }
                }
            }

            return false;
        }
        private ComboBox cboRateType = new ComboBox();

        //>>for disabling and arranging tabs for the Sales Module
        private void checkSalesModule()
        {
            tabFolio_.TabPages.Clear();
            bool _isSales = false;
            bool _isAdmin = false;

            User _oUser = new User();
            _oUser = (User)GlobalVariables.goUser;

            foreach (Role _oRole in _oUser.Roles)
            {
                if (_oRole.RoleName.ToUpper().Contains("SALES"))
                {
                    _isSales = true;
                }
                else if (_oRole.RoleName.ToUpper().Contains("ADMIN"))
                {
                    _isAdmin = true;
                }

                foreach (Role_Privilege _oPrivilege in _oRole.Privileges)
                {
                    if (_oPrivilege.Privilege.ToUpper() == "ADD EVENT OFFICERS" && _oPrivilege.Allowed == 1)
                    {
                        _canAddEventOfficer = true;
                    }
                }
            }

            //>>rearrange tab pages for the Sales and others
            //this.tabFolio_.Controls.Add(this.tabEventDetails_);
            //this.tabFolio_.Controls.Add(this.tabRooms_);
            this.tabFolio_.Controls.Add(this.tabFoodBev_);
            this.tabFolio_.Controls.Add(this.tabEndorsement);
            //this.tabFolio_.Controls.Add(this.TabRecurringCharge);
            //this.tabFolio_.Controls.Add(this.tabEventRequirements);
            this.tabFolio_.Controls.Add(this.tabAmmendments);
            this.tabFolio_.Controls.Add(this.tabContactPerson);
            //this.tabFolio_.Controls.Add(this.TabRecurringCharge);
            //this.tabFolio_.Controls.Add(this.tabEventAttendance);
            //this.tabFolio_.Controls.Add(this.tabCancellation);
            //this.tabFolio_.Controls.Add(this.tabRoomRequirements);
            //this.tabFolio_.Controls.Add(this.tabBillingInfo);
            //this.tabFolio_.Controls.Add(this.tabWedding_);
            //this.tabFolio_.Controls.Add(this.tabBooking);
            //this.tabFolio_.Controls.Add(this.tabPrivilege);
            //this.tabFolio_.Controls.Add(this.tabPackage);



            //if (_isSales == false && _isAdmin == false)
            //{
            //    cboEventGrpPackage.Enabled = false;
            //    gridBilling.Enabled = false;
            //}
            //else
            //{
            //    cboEventGrpPackage.Enabled = true;
            //    gridBilling.Enabled = true;
            //}

            if (_isSales == true)
            {
                pnlStatus.Enabled = false;
            }
            else
            {
                pnlStatus.Enabled = true;
            }

            //>>for enabling and disabling tabs meant for the user
            //string[] _bookingTabs ={ "tabEventDetails_", "tabWedding_", "tabFoodBev_" };
            //foreach (TabPage _tabPage in tabFolio_.TabPages)
            //{
            //    foreach (string _str in _bookingTabs)
            //    {
            //        if (_tabPage.Name == _str && _isSales == false && _isAdmin == false)
            //        {
            //            foreach (Control _ctrl in _tabPage.Controls)
            //            {
            //                _ctrl.Enabled = false;
            //                if (_ctrl.Name == "treeFoodBev")
            //                    _ctrl.Enabled = true;
            //                if (_ctrl.Name == "btnNewDeposit")
            //                    _ctrl.Enabled = true;
            //            }
            //        }
            //    }
            //}
        }
        private void loadEvent()
        {
            loadComboBoxes();
            checkSalesModule();
            //rdoPercent.Checked = true;
            //gridBilling.Cols[0].Editor = cboBillRates;

            //By Kevin Oliveros
            // january 3 2014
            //if(!isReinstated)
             loadFoodRequirements();
            getTotalEstimatedCost();
            loadEventEndorsement();
            loadEventOfficers();
            loadFolioDeposits();
          
        }
        #region Endorsements

        private EventEndorsement assignEventEndorsement()
        {
            EventEndorsement oEventEndorsement = new EventEndorsement();
            oEventEndorsement.FolioID = loFolio.FolioID;
            oEventEndorsement.ContractAmount = txtContractAmount.Value;
            oEventEndorsement.LetterOfProposal = cboLetterOfProposal.Text;
            oEventEndorsement.DueDate1 = dtp25RF1.Value;
            oEventEndorsement.DueDate2 = dtp50RF.Value;
            oEventEndorsement.DueDate3 = dtp25RF2.Value;
            if (rdoBeingProcessed.Checked)
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.BEING_PROCESSED;
            }
            else if (rdoForPickup.Checked)
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.FOR_PICKUP;
            }
            else if (rdoSentToClient.Checked)
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.SENT_TO_CLIENT;
            }
            else
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.SIGNED_RETURNED_TO_PICC;
            }
            oEventEndorsement.PickupDate = dtpForPickUp.Value;
            oEventEndorsement.SentToClientDate = dtpSentToClient.Value;
            oEventEndorsement.SignedDate = dtpSigned.Value;
            oEventEndorsement.HotelID = GlobalVariables.gHotelId;
            oEventEndorsement.Concessions = txtDiscountConcessions.Text;
            oEventEndorsement.Giveaways = txtGiveaways.Text;
            string[] _actions = new string[gridEMDActions.Rows.Count - 1];
            for (int _row = 1; _row < gridEMDActions.Rows.Count; _row++)
            {
                _actions[_row - 1] = gridEMDActions.GetDataDisplay(_row, 0);
            }
            oEventEndorsement.EMDActions = _actions;
            //Kevin L Oliveros 2014-02-28
            oEventEndorsement.Remarks = txtEndorsementRemarks.Text;

            return oEventEndorsement;
        }
        private void loadEventEndorsement()
        {
            if (loFolio.EventEndorsement != null && loFolio.EventEndorsement.FolioID != null)
            {
                try
                {
                    EventEndorsement _oEventEndorsement = loFolio.EventEndorsement;
                    cboLetterOfProposal.Text = _oEventEndorsement.LetterOfProposal;
                    txtContractAmount.Value = _oEventEndorsement.ContractAmount;
                    dtp25RF1.Value = _oEventEndorsement.DueDate1;
                    dtp50RF.Value = _oEventEndorsement.DueDate2;
                    dtp25RF2.Value = _oEventEndorsement.DueDate3;
                    dtpForPickUp.Value = _oEventEndorsement.PickupDate;
                    dtpSentToClient.Value = _oEventEndorsement.SentToClientDate;
                    dtpSigned.Value = _oEventEndorsement.SignedDate;
                    txtDiscountConcessions.Text = _oEventEndorsement.Concessions;
                    txtGiveaways.Text = _oEventEndorsement.Giveaways;
                    txtEndorsementRemarks.Text = _oEventEndorsement.Remarks;
                    if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.BEING_PROCESSED)
                    {
                        rdoBeingProcessed.Checked = true;
                    }
                    else if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.FOR_PICKUP)
                    {
                        rdoForPickup.Checked = true;
                    }
                    else if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.SENT_TO_CLIENT)
                    {
                        rdoSentToClient.Checked = true;
                    }
                    else
                    {
                        rdoReturned.Checked = true;
                    }

                    if (_oEventEndorsement.EMDActions != null && _oEventEndorsement.EMDActions.Length > 0)
                    {
                        gridEMDActions.Rows.Count = 1;
                        int _row = gridEMDActions.Rows.Count;
                        foreach (string _actions in _oEventEndorsement.EMDActions)
                        {
                            gridEMDActions.Rows.Count++;
                            gridEMDActions.SetData(_row, 0, _actions);
                            _row++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("Error @loadEventEndorsement\r\n" + ex.Message);
                }
            }
        }
        private void getEventEndorsement()
        {
            if (loFolio.EventEndorsement != null && loFolio.EventEndorsement.FolioID != null)
            {
                try
                {
                    EventEndorsement _oEventEndorsement = loFolio.EventEndorsement;
                    // _oEventEndorsement = loFolio.EventEndorsement.getEventEndorsement(txtFolioID.Text,);
                    cboLetterOfProposal.Text = _oEventEndorsement.LetterOfProposal;
                    txtContractAmount.Value = _oEventEndorsement.ContractAmount;
                    dtp25RF1.Value = _oEventEndorsement.DueDate1;
                    dtp50RF.Value = _oEventEndorsement.DueDate2;
                    dtp25RF2.Value = _oEventEndorsement.DueDate3;
                    dtpForPickUp.Value = _oEventEndorsement.PickupDate;
                    dtpSentToClient.Value = _oEventEndorsement.SentToClientDate;
                    dtpSigned.Value = _oEventEndorsement.SignedDate;
                    txtDiscountConcessions.Text = _oEventEndorsement.Concessions;
                    txtGiveaways.Text = _oEventEndorsement.Giveaways;
                    if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.BEING_PROCESSED)
                    {
                        rdoBeingProcessed.Checked = true;
                    }
                    else if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.FOR_PICKUP)
                    {
                        rdoForPickup.Checked = true;
                    }
                    else if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.SENT_TO_CLIENT)
                    {
                        rdoSentToClient.Checked = true;
                    }
                    else
                    {
                        rdoReturned.Checked = true;
                    }

                    if (_oEventEndorsement.EMDActions != null && _oEventEndorsement.EMDActions.Length > 0)
                    {
                        gridEMDActions.Rows.Count = 1;
                        int _row = gridEMDActions.Rows.Count;
                        foreach (string _actions in _oEventEndorsement.EMDActions)
                        {
                            gridEMDActions.Rows.Count++;
                            gridEMDActions.SetData(_row, 0, _actions);
                            _row++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("Error @loadEventEndorsement\r\n" + ex.Message);
                }
            }
        }

        #endregion

        private void loadEventOfficers()
        {
            if (loFolio.EventOfficers != null)
            {
                try
                {
                    int _row = this.gridEventOfficer.Rows.Count;
                    this.gridEventOfficer.Rows.Count = 1;
                    foreach (EventOfficer _eventOfficer in loFolio.EventOfficers)
                    {
                        _row = this.gridEventOfficer.Rows.Count;
                        this.gridEventOfficer.Rows.Count++;

                        /**
                         * 0 - lastname
                         * 1 - firstname
                         * */
                        this.gridEventOfficer.SetData(_row, 0, _eventOfficer.LastName);
                        this.gridEventOfficer.SetData(_row, 1, _eventOfficer.FirstName);
                        this.gridEventOfficer.SetData(_row, 2, _eventOfficer.UserID);
                        this.gridEventOfficer.SetData(_row, 3, _eventOfficer.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @ loadEventOfficers\r\n" + ex.Message);
                }
            }
        }
        private void setReqDateDropDown(DateTime pStart, DateTime pEnd)
        {
            lcboReqDates.Items.Clear();
            TimeSpan _span = pEnd.Subtract(pStart);
            int _diff = System.Convert.ToInt32(Math.Floor(_span.TotalDays));
            for (int i = 0; i <= _diff; i++)
            {
                lcboReqDates.Items.Add(string.Format("{0:dd-MMM-yyyy}", pStart.AddDays(i)));
            }
            lcboReqDates.SelectedIndex = 0;
        }
        private void loadRequirementDetails()
        {
            EventRequirementsFacade _oEventRequirementFacade = new EventRequirementsFacade();
            GenericList<EventRequirements> _oEventRequirementList = _oEventRequirementFacade.getEventRequirements(txtFolioID.Text);


            foreach (EventRequirements _oEventRequirements in _oEventRequirementList)
            {
                if (treeRequirements.Nodes.Count > 0)
                {
                    foreach (TreeNode _parentNode in treeRequirements.Nodes)
                    {
                        if (_parentNode.Text == _oEventRequirements.Remarks || (_parentNode.Text == _oEventRequirements.Remarks && _parentNode.Index == treeRequirements.Nodes.Count - 1))
                        {
                            foreach (TreeNode _childNode in _parentNode.Nodes)
                            {
                                if (_childNode.Text == _oEventRequirements.RequirementCode || (_childNode.Text == _oEventRequirements.RequirementCode && _childNode.Index == _parentNode.Nodes.Count - 1))
                                {
                                    _childNode.Nodes.Add(_oEventRequirements.Description);
                                }
                                else if (_childNode.Text != _oEventRequirements.RequirementCode && _childNode.Index != _parentNode.Nodes.Count - 1)
                                {
                                }
                                else
                                {
                                    TreeNode _newChildNode = new TreeNode(_oEventRequirements.RequirementCode);
                                    _newChildNode.Nodes.Add(_oEventRequirements.Description);
                                    _parentNode.Nodes.Add(_newChildNode);
                                }
                            }
                        }
                        else if (_parentNode.Text != _oEventRequirements.Remarks && _parentNode.Index != treeRequirements.Nodes.Count - 1)
                        {
                        }
                        else
                        {
                            TreeNode _newParentNode = new TreeNode(_oEventRequirements.Remarks);
                            TreeNode _newChildNode = new TreeNode(_oEventRequirements.RequirementCode);
                            _newChildNode.Nodes.Add(_oEventRequirements.Description);
                            _newParentNode.Nodes.Add(_newChildNode);
                            treeRequirements.Nodes.Add(_newParentNode);
                        }
                    }
                }
                else
                {
                    TreeNode _newParentNode = new TreeNode(_oEventRequirements.Remarks);
                    TreeNode _newChildNode = new TreeNode(_oEventRequirements.RequirementCode);
                    _newChildNode.Nodes.Add(_oEventRequirements.Description);
                    _newParentNode.Nodes.Add(_newChildNode);
                    treeRequirements.Nodes.Add(_newParentNode);
                }
            }
            treeRequirements.ExpandAll();
        }
        private void getRequirementsSchedules()
        {
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            IList<Schedule> _oScheduleList = _oScheduleFacade.getFolioScheduleList(txtFolioID.Text);

            gridReqSchedules.Rows.Count = 1;
            //  grdAmmendments.Rows.Count = 1;
            foreach (Schedule _oSchedule in _oScheduleList)
            {
                string _roomID = _oSchedule.RoomID.ToString();// +" [" + grdSchedules.GetDataDisplay(_oRow.Index, 2) + "]";
                string _fromDate = _oSchedule.FromDate.ToString();
                string _toDate = _oSchedule.ToDate.ToString();
                string _startTime = _oSchedule.StartTime.ToString("hh:mm tt");
                string _endTime = _oSchedule.EndTime.ToString("hh:mm tt");

                if (DateTime.Parse(_endTime) <= DateTime.Parse(_startTime))
                {
                    if (DateTime.Parse(_toDate) <= DateTime.Parse(_fromDate))
                    {
                        MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                gridReqSchedules.Rows.Count++;
                gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 0, _roomID);
                gridReqSchedules[gridReqSchedules.Rows.Count - 1, 1] = lcboReqDates;
                gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 1, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_fromDate)));

                gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 2, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_fromDate)));
                gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 3, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_toDate)));

                //Kevin Oliveros
                //grdAmmendments.Rows.Count++;
                //grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 0, _roomID);
                //grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 1, _fromDate);
                //grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 2, _toDate);
                //grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 3, _startTime);
                //grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 4, _endTime);

                gridAmendmentSchedules.Rows.Count++;
                gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 0, _roomID);
                gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 1, _fromDate);
                gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 2, _toDate);
                gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 3, _startTime);
                gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 4, _endTime);

                gridPackageRoom.Rows.Count++;
                gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 0, _roomID);
                gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 1, _oSchedule.Venue);
                gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 2, _startTime + "-" + _endTime);
                gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 3,_fromDate);
                gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 4,_toDate);
                gridPackageRoom.AutoSizeCols();

                addMealDates(_oSchedule.FromDate, _oSchedule.ToDate);

            }
        }
        private decimal totalAmount;
        private void loadFoodRequirements()
        {
            loadMenuItems();
            totalAmount = 0;
            treeFoodBev.Nodes.Clear();
            EventFoodRequirementsFacade _oFoodRequirementFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();

            //>>food requirements
            _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();
            _oEventFoodRequirementsList = _oFoodRequirementFacade.getFoodDates(txtFolioID.Text);

            //get food dates
            foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
            {
                TreeNode _eventDatesNode = new TreeNode(_oEventFoodRequirements.EventDate.ToShortDateString());

                //for getting meal types in a date
                EventFoodRequirementsFacade _oMealTypeFacade = new EventFoodRequirementsFacade();
                GenericList<EventFoodRequirements> _oEventMealTypeList = _oMealTypeFacade.getMealTypes(txtFolioID.Text, DateTime.Parse(_eventDatesNode.Text));
                foreach (EventFoodRequirements _mealTypes in _oEventMealTypeList)
                {
                    _eventDatesNode.Nodes.Add(_mealTypes.MealType);
                }

                treeFoodBev.Nodes.Add(_eventDatesNode);
            }
            treeFoodBev.ExpandAll();
            txtTotalMealAmount.Value = totalAmount;
            origAmt = txtTotalMealAmount.Text;

            //<<
        }
        private string origAmt = "0";
        //>>for getting the total estimated cost for the event
        //  this includes all the meals costing and the room rates and also the packages, if any
        private void getTotalEstimatedCost()
        {
            decimal _packageAmount = decimal.Parse(txtPackageAmount.Text);
            decimal _roomRatesAmount = 0;
            decimal _mealRatesAmount = 0;

            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
            GenericList<RoomEvents> _oRoomEventsList = _oRoomEventFacade.getChildFoliosRoomEvents(txtFolioID.Text);
            foreach (RoomEvents _oRoomEvent in _oRoomEventsList)
            {
                _roomRatesAmount += _oRoomEvent.RoomRate;
            }

            //foreach (TreeNode _treeNode in treeFoodBev.Nodes)
            //{
            //    if (_treeNode.Parent == null)
            //    {
            EventFoodRequirementsFacade _oFoodRequirementsFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oFoodRequirementsList = _oFoodRequirementsFacade.getFoodRequirements(txtFolioID.Text);
            foreach (EventFoodRequirements _oEventFoodRequirements in _oFoodRequirementsList)
            {
                _mealRatesAmount += _oEventFoodRequirements.TotalMealCost;
            }
            //    }
            //}

            decimal _totalCost = _packageAmount + _roomRatesAmount + _mealRatesAmount;
            txtTotalEstimatedCost.Text = string.Format("{0:###,##0.#0}", _totalCost);
        }
        private void loadMenuItems()
        {
            lvwMenus.Items.Clear();
            MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
            GenericList<MealMenu> _oMealMenuItemList = new GenericList<MealMenu>();
            _oMealMenuItemList = _oMealMenuItemFacade.getMealMenus();
            foreach (MealMenu _oMealMenu in _oMealMenuItemList)
            {
                string[] items ={ _oMealMenu.Description, _oMealMenu.MenuID.ToString() };
                ListViewItem _listViewItem = new ListViewItem(items);
                lvwMenus.Items.Add(_listViewItem);
            }

            _oMealMenuItemFacade = new MealMenuItemFacade();
            _oMealMenuItemList = new GenericList<MealMenu>();
            _oMealMenuItemList = _oMealMenuItemFacade.getMealMenuItems();
            foreach (MealMenu _oMealItem in _oMealMenuItemList)
            {
                string[] item ={ _oMealItem.Description, _oMealItem.MealMenuItemID.ToString() };
                ListViewItem li = new ListViewItem(item);
                lvwMenus.Items.Add(li);
            }


            IList<MealMenu> _oMealGroups = _oMealMenuItemFacade.getMealGroups();
            //this.cboMealGroups.Items.Clear();
            //this.cboMealGroups.Items.Add("ALL");
            //foreach (MealMenu _group in _oMealGroups)
            //{
            //    this.cboMealGroups.Items.Add(_group.Description);
            //}
            //this.cboMealGroups.SelectedIndex = 0;
            MealMenu _comboMeal = new MealMenu();
            _comboMeal.Description = "COMBO MEALS";
            _oMealGroups.Insert(0, _comboMeal);
            this.cboMealGroups.DataSource = _oMealGroups;
            this.cboMealGroups.DisplayMember = "Description";
            this.cboMealGroups.SelectedIndex = 0;


        }
        private void loadComboBoxes()
        {
            //>>to display all event types in the combo box
            //EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
            //GenericList<EventType> _oEventTypeList = _oEventTypeFacade.getEventTypes();
            //EventType _oEventType = new EventType();
            //_oEventType.Event_Type = "";
            //_oEventType.EventID = 0;
            //_oEventTypeList.Insert(0, _oEventType);
            //cboEventType.DisplayMember = "event_type";
            //cboEventType.ValueMember = "eventid";
            //cboEventType.DataSource = _oEventTypeList;

            //>>to display all requirements type in the combo box
            RequirementCodeFacade _oRequirementCodeFacade = new RequirementCodeFacade();
            GenericList<RequirementCode> _oRequirementCodeList = new GenericList<RequirementCode>();
            _oRequirementCodeList = _oRequirementCodeFacade.getRequirementCodes();
            RequirementCode _oRequirementCode = new RequirementCode();
            _oRequirementCode.Description = "";
            _oRequirementCode.Requirement_Code = "0";
            _oRequirementCodeList.Insert(0, _oRequirementCode);
            cboRequirementType.DisplayMember = "Description";
            cboRequirementType.ValueMember = "Requirement_Code";
            cboRequirementType.DataSource = _oRequirementCodeList;

            //>>to display all applied rates in the combo box
            //AppliedRatesFacade _oAppliedRatesFacade = new AppliedRatesFacade();
            //GenericList<AppliedRates> _oAppliedRatesList = _oAppliedRatesFacade.getAppliedRates();
            //AppliedRates _oAppliedRates = new AppliedRates();
            //cboBillRates.DisplayMember = "Description";
            //cboBillRates.ValueMember = "NumberOfOccupants";
            //cboBillRates.DataSource = _oAppliedRatesList;

            //>>to display all packages in the combo box
            //EventPackageFacade _oEventPackageFacade = new EventPackageFacade();
            //GenericList<EventPackageHeader> _oEventPackage = _oEventPackageFacade.getEventPackages();
            //EventPackageHeader _oEventPackageHeader = new EventPackageHeader();
            //_oEventPackageHeader.PackageID = 0;
            //_oEventPackageHeader.Description = "";
            //_oEventPackage.Insert(0, _oEventPackageHeader);
            //cboEventGrpPackage.DisplayMember = "Description";
            //cboEventGrpPackage.ValueMember = "PackageID";
            //cboEventGrpPackage.DataSource = _oEventPackage;

            //GroupBookingDropDownFacade _oGroupBookingDropDown = new GroupBookingDropDownFacade();
            //DataTable _dt = _oGroupBookingDropDown.getSpecificFieldName("GeographicalScope");
            //foreach (DataRow _dRow in _dt.Rows)
            //{
            //    cboGeoEventType.Items.Add(_dRow["Value"].ToString());
            //}

            //cboGeoEventType.SelectedIndex = 0;
        }
        private void newFolio()
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
                if (lFlag == "New")
                {
                    if (MessageBox.Show("Parent Folio must first be saved, Do you want to Continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //if (this.cboAccountType.Text.Trim().Length <= 0)
                        //{
                        //    MessageBox.Show("Please select account type.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    tabFolio_.TabPages["tabBooking"].Select();
                        //    this.cboAccountType.Focus();
                        //    return;
                        //}

                        //if (this.cboPayment_Mode.Text.Trim().Length <= 0)
                        //{

                        //    MessageBox.Show("Please select payment mode.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    tabFolio_.TabPages["tabBooking"].Select();
                        //    this.cboPayment_Mode.Focus();
                        //    return;
                        //}

                        //if (this.cboPurpose.Text.Trim().Length <= 0)
                        //{

                        //    MessageBox.Show("Please select purpose of booking.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    tabFolio_.TabPages["tabBooking"].Select();
                        //    this.cboPurpose.Focus();
                        //    return;
                        //}

                        //if (gridFunctionRooms.Rows.Count <= 1)
                        //{
                        //    MessageBox.Show("Group Reservation should have at least one(1) schedule.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    tabFolio_.TabPages["tabRooms_"].Select();
                        //    return;
                        //}

                        saveGroupFolio(ref _oTransaction);
                        //saveBookingInfo(ref _oTransaction);

                        //IList<Schedule> _childFolioSchedule = new List<Schedule>();
                        //Schedule _newSchedule = new Schedule();

                        //// if no FUNCTION ROOM defined
                        //if (this.gridFunctionRooms.Rows.Count > 1)
                        //{
                        //    _newSchedule.FromDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 3));
                        //    _newSchedule.ToDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 4));
                        //}
                        //else
                        //{
                        //    _newSchedule.FromDate = dtpFromDate.Value;
                        //    _newSchedule.ToDate = dtpTodate.Value;
                        //}
                        //_newSchedule.RoomID = "";
                        //_childFolioSchedule.Add(_newSchedule);

                        //newReservation(_childFolioSchedule);
                        lFlag = "Edit";
                    }
                }
                else
                {
                    IList<Schedule> _childFolioSchedule = new List<Schedule>();
                    //Schedule _newSchedule = new Schedule();

                    //// if no FUNCTION ROOM defined
                    //if (this.gridFunctionRooms.Rows.Count > 1)
                    //{
                    //    _newSchedule.FromDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 3));
                    //    _newSchedule.ToDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 4));
                    //}
                    //else
                    //{
                    //    _newSchedule.FromDate = dtpFromDate.Value;
                    //    _newSchedule.ToDate = dtpTodate.Value;
                    //}
                    //_newSchedule.RoomID = "";
                    //_childFolioSchedule.Add(_newSchedule);

                    newReservation(_childFolioSchedule);
                    lFlag = "Edit";
                }

                _oTransaction.Commit();
                //End If
            }
            catch
            {
                _oTransaction.Rollback();
            }
        }
        Sequence loFolioSequence = new Sequence();
        private bool createNewCompanyAccount()
        {
            try
            {
                if (this.txtCompanyName.Text.Trim().Length > 0 && txtcompanyid.Text == "")
                {

                    loCompanyFacade = new CompanyFacade();
                    Company _newCompany = new Company();

                    _newCompany.CompanyId = loFolioSequence.getSequenceId("G-", 12, "seq_company");
                    _newCompany.CompanyName = this.txtCompanyName.Text;
                    //_newCompany.ContactNumber1 = txtContactNumber1.Text;
                    //_newCompany.ContactNumber2 = txtContactNumber2.Text;
                    //_newCompany.ContactNumber3 = txtContactNumber3.Text;
                    //_newCompany.ContactPerson = txtContactPerson.Text;
                    //_newCompany.Designation = txtDesignation.Text;
                    _newCompany.HotelID = GlobalVariables.gHotelId;
                    _newCompany.ACCOUNT_TYPE = "";
                    _newCompany.CARD_NO = "";
                    _newCompany.City1 = "";//txtCity1.Text;
                    _newCompany.City2 = "";
                    _newCompany.City3 = "";
                    _newCompany.CompanyCode = this.txtCompanyCode.Text;
                    _newCompany.CompanyURL = "";
                    _newCompany.ContactType1 = "PHONE";
                    _newCompany.ContactType2 = "FAX";
                    _newCompany.ContactType3 = "MOBILE";
                    _newCompany.Country1 = "";//txtCountry1.Text;
                    _newCompany.Country2 = "";
                    _newCompany.Country3 = "";
                    _newCompany.Email1 = "";
                    _newCompany.Email2 = "";
                    _newCompany.Email3 = "";
                    _newCompany.NO_OF_VISIT = 0;
                    _newCompany.Remarks = "";
                    _newCompany.Street1 = "";//txtStreet1.Text;
                    _newCompany.Street2 = "";
                    _newCompany.Street3 = "";
                    _newCompany.THRESHOLD_VALUE = 0;
                    _newCompany.TOTAL_SALES_CONTRIBUTION = 0;
                    _newCompany.X_DEAL_AMOUNT = 0;
                    _newCompany.Zip1 = "";// txtZip1.Text;
                    _newCompany.Zip2 = "";
                    _newCompany.Zip3 = "";
                    /* Gene
                     * 01-Mar-12
                     */
                    _newCompany.TIN = "";// txtTIN.Text;

                    AccountInformation _oAccountInformation = new AccountInformation();
                    _oAccountInformation.AccountID = _newCompany.CompanyId;
                    _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                    _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

                    _newCompany.AccountInformation = _oAccountInformation;

                    loCompanyFacade.insertCompanyGuest(ref _newCompany);


                    this.txtcompanyid.Text = _newCompany.CompanyId;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in creating new company account.\r\n" + ex.Message);
            }
        }
        private void updateGuestInformation()
        {
            // create new guest account
            loGuestFacade = new GuestFacade();
            Guest _newGuest = new Guest();
            loFolio.Guest = loGuestFacade.getGuestRecord(txtcompanyid.Text);

            _newGuest.AccountId = this.txtcompanyid.Text;
            _newGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
            _newGuest.Title = loFolio.Guest.Title;
            _newGuest.LastName = this.txtLastName.Text;
            _newGuest.FirstName = this.txtFirstName.Text;
            _newGuest.MiddleName = loFolio.Guest.MiddleName;
            _newGuest.Sex = loFolio.Guest.Sex;
            _newGuest.Citizenship = loFolio.Guest.Citizenship;
            _newGuest.PassportId = loFolio.Guest.PassportId;
            _newGuest.GuestImage = loFolio.Guest.GuestImage;
            _newGuest.TelephoneNo = loFolio.Guest.TelephoneNo;
            _newGuest.MobileNo = loFolio.Guest.MobileNo;
            _newGuest.FaxNo = loFolio.Guest.FaxNo;
            _newGuest.Street = loFolio.Guest.Street;//this.txtStreet1.Text;
            _newGuest.City = loFolio.Guest.City;//this.txtCity1.Text;
            _newGuest.Country = loFolio.Guest.Country;//this.txtCountry1.Text;
            _newGuest.Zip = loFolio.Guest.Zip;//this.txtZip1.Text;
            _newGuest.EmailAddress = loFolio.Guest.EmailAddress;

            _newGuest.Remark = loFolio.Guest.Remark;
            _newGuest.Concierge = loFolio.Guest.Concierge;
            _newGuest.Memo = loFolio.Guest.Memo;
            _newGuest.BIRTH_DATE = loFolio.Guest.BIRTH_DATE;

            _newGuest.NoOfVisits = loFolio.Guest.NoOfVisits;
            _newGuest.TOTAL_SALES_CONTRIBUTION = loFolio.Guest.TOTAL_SALES_CONTRIBUTION;

            _newGuest.HotelID = GlobalVariables.gHotelId;
            _newGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
            _newGuest.UpdatedBy = GlobalVariables.gLoggedOnUser;

            _newGuest.ACCOUNT_TYPE = loFolio.Guest.ACCOUNT_TYPE;
            _newGuest.CARD_NO = loFolio.Guest.CARD_NO;
            _newGuest.THRESHOLD_VALUE = loFolio.Guest.THRESHOLD_VALUE;

            _newGuest.CreditCardNo = loFolio.Guest.CreditCardNo;
            _newGuest.CreditCardType = loFolio.Guest.CreditCardType;
            _newGuest.CreditCardExpiry = loFolio.Guest.CreditCardExpiry;
            _newGuest.TaxExempted = loFolio.TaxExempted;
            _newGuest.AccountPrivileges = loFolio.Guest.AccountPrivileges;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = _newGuest.AccountId;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");
            _newGuest.AccountInformation = _oAccountInformation;
            // Review to get SP
            loGuestFacade.updateGuest(ref _newGuest);

            this.loFolio.Guest = _newGuest;
        }
        private void saveGroupFolio(ref MySqlTransaction pTrans)
        {
            loFolioFacade = new FolioFacade();
            //txtAccountType.Text = cboAccountType.Text;
            txtGroupName.Text = txtGroupName.Text.Replace('\'', '`');
            //check if needs to change reference number
            bool _refNoChanged = false;
            //if (string.Format("{0:MMM-yyyy}", loFolio.FromDate) != string.Format("{0:MMM-yyyy}", dtpFromDate.Value))
            //{
            //    _refNoChanged = true;
            //}
            FormToObjectInstanceBinder.BindObjectToInputControls(this, loFolio);
            if (rdbCompany.Checked == true)
            {
                // Insert/Update Company
                if (loFolio.Company == null && loFolio.CompanyID == "")
                {
                    createNewCompanyAccount();
                    loFolio.CompanyID = txtcompanyid.Text;
                }
                else
                {

                    updateCompanyInformation(); // update guest information
                }
            }
            else if (rdbIndividual.Checked == true)
            {
                updateGuestInformation();
            }

            //loFolio.UpdatedBy = GlobalVariables.gLoggedOnUser;
            //loFolio.Remarks = txtGroupRemarks.Text;
            //loFolio.Package = assignFolioPackage(loFolio);
            //loFolio.RecurringCharges = assignRecurringCharges();
            //loFolio.FolioRouting = assignFolioRouting();
            //loFolio.Privileges = setUpFolioPrivileges();
            //loFolio.TerminalId = GlobalVariables.gTerminalID.ToString();
            //loFolio.ShiftCode = GlobalVariables.gShiftCode.ToString();
            loFolio.ContactPersons = assignContactPersons();
            //loFolio.EventOfficers = assignEventOfficers();
            //loFolio.IncumbentOfficers = assignIncumbentOfficers();
            loFolio.EventEndorsement = assignEventEndorsement();
            //loFolio.EventAttendance = assignEventAttendance();
            //if (gridFunctionRooms.Rows.Count > 1)
            //{
            //    loFolio.FolioETA = gridFunctionRooms.GetDataDisplay(1, 5);
            //    loFolio.FolioETD = gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 6);
            //}
            //else
            //{
            //    loFolio.FolioETA = "12:00 PM";
            //    loFolio.FolioETD = "2:00 PM";
            //}

            saveFunctionRooms();

            //jlo for alpa 6-9-10
            String _rStatus = "";
            if (lFlag == "Edit")
            {
                _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;
            }
            int _newStatus = getIndex(this.cboStatus.Text, aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                cboStatus.Text = _rStatus;
                if (_rStatus == "ONGOING")
                {
                    //   dtpFromDate.Text = loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString();
                    //grdFolioSchedule.SetData(1, 2, loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString());
                    //   gridFunctionRooms.SetData(1, 2, loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString());
                }
            }
            //jlo

            if (lFlag == "New")
            {
                // Will enter here if new folio
                try
                {
                    loFolioFacade.SaveFolio(loFolio, ref pTrans);
                }
                catch (Exception ex)
                {
                    //loEventFacade.deleteEvents(loFolio.FolioID);
                    //MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;

                    throw new Exception("Transaction failed.\r\nError in saving new folio.\r\n\r\nError message: " + ex.Message);
                }
            }
            else
            {
                // Will enter here if update folio
                try
                {
                    loFolioFacade.updateFolio(loFolio, ref pTrans);
                    if (_refNoChanged && loFolio.Status == "CONFIRMED")
                    {
                        loFolioFacade.setReferencNo(loFolio.FolioID, loFolio.FromDate.Month, loFolio.FromDate.Year, GlobalVariables.gHotelId);
                        loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                        txtReferenceNo.Text = loFolio.ReferenceNo;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Transaction failed.\r\nError in updating folio.\r\n\r\nError message: " + ex.Message);
                }
                //return true;
            }
            //return false;
        }
        private void updateCompanyInformation()
        {
            // by Kevin Oliveros
            // 1-10-2014
            // create new guest account
            loCompanyFacade = new CompanyFacade();
            Company _newCompany = new Company();
            _newCompany.ACCOUNT_TYPE = loCompany.ACCOUNT_TYPE;
            _newCompany.CARD_NO = loCompany.CARD_NO;
            _newCompany.City1 = loCompany.City1;
            _newCompany.City2 = loCompany.City2;
            _newCompany.City3 = loCompany.City3;
            _newCompany.CompanyCode = loCompany.CompanyCode;
            _newCompany.CompanyId = txtcompanyid.Text;
            _newCompany.CompanyName = txtCompanyName.Text;
            _newCompany.CompanyURL = loCompany.CompanyURL;
            _newCompany.ContactNumber1 = loCompany.ContactNumber1;
            _newCompany.ContactNumber2 = loCompany.ContactNumber2;
            _newCompany.ContactNumber3 = loCompany.ContactNumber3;
            _newCompany.ContactPerson = loCompany.ContactPerson;
            _newCompany.ContactType1 = "PHONE";
            _newCompany.ContactType2 = "FAX";
            _newCompany.ContactType3 = "MOBILE";
            _newCompany.Country1 = loCompany.Country1;
            _newCompany.Country2 = loCompany.Country2;
            _newCompany.Country3 = loCompany.Country3;
            _newCompany.Designation = loCompany.Designation;
            _newCompany.Email1 = loCompany.Email1;
            _newCompany.Email2 = loCompany.Email2;
            _newCompany.Email3 = loCompany.Email3;
            _newCompany.NO_OF_VISIT = loCompany.NO_OF_VISIT;
            _newCompany.Remarks = loCompany.Remarks;
            _newCompany.Street1 = loCompany.Street1; 
            _newCompany.Street2 = loCompany.Street2;
            _newCompany.Street3 = loCompany.Street3;
            _newCompany.THRESHOLD_VALUE = loCompany.THRESHOLD_VALUE;
            _newCompany.TOTAL_SALES_CONTRIBUTION = loCompany.TOTAL_SALES_CONTRIBUTION;
            _newCompany.X_DEAL_AMOUNT = loCompany.X_DEAL_AMOUNT;
            _newCompany.Zip1 = loCompany.Zip1;
            _newCompany.Zip2 = loCompany.Zip2;
            _newCompany.Zip3 = loCompany.Zip3;
            /* Gene
             * 01-Mar-12
             */
            _newCompany.TIN = loCompany.TIN;


            _newCompany.AccountPrivileges = loCompany.AccountPrivileges;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = _newCompany.CompanyId;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

            _newCompany.AccountInformation = _oAccountInformation;
            loCompanyFacade.updateCompanyAccount(txtcompanyid.Text, ref _newCompany);
            //loGuestFacade.updateGuest(ref _newCompany);

            this.loFolio.Company = _newCompany;
        }
   
        private void newReservation(IList<Schedule> _childFolioSchedule)
        {
        }
        private void loadRoomRequirements()
        {

        }//<<
        private void updateCurrentRoomStatus()
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

        private void setButtons()
        {
            if (lGroupFolioStatus == "New")
            {
                //btnBlock.Enabled = false;
                //btnManualBlockRooms.Enabled = false;
                btnCheckIN.Enabled = false;
                btnCheckOut.Enabled = false;
                btnPrintContract.Enabled = false;
                btnFolio.Enabled = false;
                btnBookingSheet.Enabled = false;
                btnPostCharges.Enabled = false;
                //btnNewDeposit.Enabled = false;
                btnreinstate.Enabled = false;
                //btnConfirm.Enabled = false;
                btnSaveRequirements.Enabled = false;
                panel6.Enabled = false;
                panel4.Enabled = false;

                pnlAmendments.Enabled = false;
                grpMealDetails.Enabled = false;
                grpNewAmendments.Enabled = false;

                /* Gene
                 * 06-Mar-12
                 * Hide the Cancel Reservation button if it is a new reservation
                 * Disable the panel that contains btnPrintEventAttendance if it is a new reservation
                 */
                btnCancelReservation.Visible = false;
                //panel5.Enabled = false;
            }
            else
            {
                //btnBlock.Enabled = true;
                btnPrintContract.Enabled = true;
                btnFolio.Enabled = true;
                btnBookingSheet.Enabled = true;
                btnPostCharges.Enabled = true;
                //btnNewDeposit.Enabled = true;
                //btnConfirm.Enabled = true;
                //btnManualBlockRooms.Enabled = true;
                btnreinstate.Enabled = true;
                btnSaveRequirements.Enabled = true;
                panel6.Enabled = true;
                panel4.Enabled = true;
                btnCancelReservation.Enabled = true;
                pnlAmendments.Enabled = true;
                grpMealDetails.Enabled = true;
                grpNewAmendments.Enabled = true;
                pnlStatus.Visible = true;
                if (loFolio.FromDate > DateTime.Now && loFolio.Status == "CONFIRMED")
                    btnCheckIN.Enabled = false;
            }

            switch (cboStatus.Text)
            {
                case "ONGOING":
                    btnreinstate.Enabled = false;
                    //btnConfirm.Enabled = false;
                    btnCheckIN.Enabled = false;
                    btnCancelReservation.Enabled = false;
                    btnPostCharges.Enabled = true;
                    btnFolio.Enabled = true;
                    btnPrintContract.Enabled = true;
                    btnEndorsement.Enabled = true;
                    //Clark 10.05.2011
                    //btnUnconfirm.Enabled = false;

                    break;

                case "TENTATIVE":
                case "WAIT LIST":
                    btnFolio.Enabled = false;
                    btnreinstate.Enabled = false;
                    btnCheckIN.Enabled = false;
                    btnCheckOut.Enabled = false;
                    btnPostCharges.Enabled = false;
                    btnPrintContract.Enabled = false;
                    btnEndorsement.Enabled = false;
                    //Clark 10.05.2011
                    //btnUnconfirm.Enabled = false;

                    break;

                case "CONFIRMED":
                    btnreinstate.Enabled = false;
                    //btnConfirm.Enabled = false;
                    btnCheckOut.Enabled = false;
                    btnreinstate.Enabled = false;
                    btnPostCharges.Enabled = true;
                    btnPrintContract.Enabled = true;
                    btnEndorsement.Enabled = true;
                    btnFolio.Enabled = true;
                    //Clark 10.05.2011
                    //btnUnconfirm.Enabled = true;

                    if (loFolio.FromDate > DateTime.Now)
                        btnCheckIN.Enabled = true;
                    break;

                case "CANCELLED":
                    btnFolio.Enabled = false;
                    btnCheckOut.Enabled = false;
                    btnCheckIN.Enabled = false;
                    btnFolio.Enabled = false;
                    //btnConfirm.Enabled = false;
                    btnPostCharges.Enabled = false;
                    pnlNew.Enabled = false;
                    btnCancelReservation.Enabled = false;
                    btnBookingSheet.Enabled = false;
                    btnPrintContract.Enabled = false;
                    btnEndorsement.Enabled = false;

                    //btnSaveCancellation.Enabled = true;

                    //Clark 10.05.2011
                    //btnUnconfirm.Enabled = false;

                    break;

                case "CLOSED":
                    btnreinstate.Enabled = false;
                    pnlStatus.Enabled = false;
                    pnlNew.Enabled = false;
                    btnFolio.Enabled = false;
                    btnCancelReservation.Enabled = false;
                    btnFolio.Enabled = false;
                    btnPrintContract.Enabled = false;
                    btnEndorsement.Enabled = false;
                    //btnUnconfirm.Enabled = false;

                    break;
            }
        }
        public void loadAllFoodAndBevNew()
        {
            //Kevin L Oliveros
            gridNewMeal.Rows.Count = 1;
            EventFoodRequirementsFacade _oFoodRequirementFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();

            //>>food requirements
            _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();
            _oEventFoodRequirementsList = _oFoodRequirementFacade.getFoodRequirements(txtFolioID.Text);

            //get food dates
            string _mealType = "";
            foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
            {
                //for getting meal types in a date
                    EventFoodRequirementsFacade _oMealTypeFacade = new EventFoodRequirementsFacade();
                    GenericList<EventFoodRequirements> _oEventMealTypeList = _oMealTypeFacade.getMealTypes(txtFolioID.Text, DateTime.Parse(_oEventFoodRequirements.EventDate.ToString()));
                //EventFoodRequirements _oFoodRequirement = _oFoodRequirementFacade.getFoodRequirement(DateTime.Parse(_oEventFoodRequirements.EventDate.ToString()), txtFolioID.Text);
 
                    foreach (EventFoodRequirements _mealTypes in _oEventMealTypeList)
                    {
                        //_eventDatesNode.Nodes.Add(_mealTypes.MealType);    
                        _mealType = _mealTypes.MealType.ToString();
                    }

                    gridNewMeal.Rows.Count++;
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "typeOfMeal", _oEventFoodRequirements.MealType);
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "date", String.Format("{0:ddd, MMM d, yyyy} ", _oEventFoodRequirements.EventDate));
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "noOfPax", _oEventFoodRequirements.Pax.ToString());
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "foodNet", _oEventFoodRequirements.TotalMealCost.ToString());
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "totalCost", _oEventFoodRequirements.TotalMealCost * decimal.Parse(_oEventFoodRequirements.Pax.ToString()));
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "venue", _oEventFoodRequirements.Venue);
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "remarks", _oEventFoodRequirements.Remarks);
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "setup", _oEventFoodRequirements.Setup);
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "over", _oEventFoodRequirements.Over);
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "MenuID", _oEventFoodRequirements.MealType);
                //  gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "MealTypeID", _oEventFoodRequirements.MealType);
                    gridNewMeal.SetData(gridNewMeal.Rows.Count - 1, "MealID", _oEventFoodRequirements.MealID);
                //}
            }
            getTotalAmountFoodAndBev();
        }

       

        private void txtCompanyId_TextChanged()
        {
            if (txtcompanyid.Text != "")
            {
                lvwBrowseCompany.Hide();
                lvwBrowseGuestName.Hide();
            }
            else
            {
                txtCompanyName.Text = "";
                txtLastName.Text = "";
                txtFirstName.Text = "";
            }

            //if (lFlag != "New")
            //{
            try
            {
                if (txtcompanyid.Text != "")
                {
                    EventContact oEventContact = new EventContact();
                    if (rdbCompany.Checked)
                    {
                        loCompanyFacade = new CompanyFacade();

                        loCompany = loCompanyFacade.getCompanyAccount(txtcompanyid.Text);
                        loCompany.CreateTime = DateTime.Parse(txtCreateTime.Text);
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);

                        ///  loadCompanyPrivileges();
                        txtTotal_Sales_Contribution.Text = double.Parse(txtTotal_Sales_Contribution.Text).ToString("N");
                        txtTHRESHOLD_VALUE.Text = double.Parse(txtTHRESHOLD_VALUE.Text).ToString("N");
                        //txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;

                    }
                    else
                    {
                        Guest _oGuest = new Guest();
                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(txtcompanyid.Text);
                        // loadCompanyPrivileges();
                        //by  Kevin Oliveros

                        txtLastName.Text = _oGuest.LastName;
                        txtFirstName.Text = _oGuest.FirstName;
                        //txtMiddleName.Text = _oGuest.MiddleName;
                        txtTHRESHOLD_VALUE.Text = _oGuest.THRESHOLD_VALUE.ToString("###,##0.#0");
                        txtTotal_Sales_Contribution.Text = _oGuest.TOTAL_SALES_CONTRIBUTION.ToString("###,##0.#0");
                        txtAccount_Type.Text = _oGuest.ACCOUNT_TYPE;
                        //txtContactPerson.Text = _oGuest.Title + " " + _oGuest.FirstName + " " + _oGuest.LastName;
                        //txtContactNumber1.Text = _oGuest.TelephoneNo;
                        //txtContactNumber2.Text = _oGuest.FaxNo;
                        //txtContactNumber3.Text = _oGuest.MobileNo;
                        //txtStreet1.Text = _oGuest.Street;
                        //txtCity1.Text = _oGuest.City;
                        //txtCountry1.Text = _oGuest.Country;
                        //txtZip1.Text = _oGuest.Zip;

                    }

                    loFolio.ContactPersons = oEventContact.getEventContacts(loFolio.FolioID, loFolio.CompanyID);
                    loadContactPersons();
                }
            }
            catch { }
            //}
            //else
            //{
            //if (txtcompanyid.Text != "")
            //{
            //    Guest _oGuest = new Guest();
            //    loGuestFacade = new GuestFacade();
            //    _oGuest = loGuestFacade.getGuestRecord(txtcompanyid.Text);

            //    txtLastName.Text = _oGuest.LastName;
            //    txtFirstName.Text = _oGuest.FirstName;
            //    //txtMiddleName.Text = _oGuest.MiddleName;
            //    txtTotal_Sales_Contribution.Text = _oGuest.TOTAL_SALES_CONTRIBUTION.ToString("###,##0.#0");
            //    txtAccount_Type.Text = _oGuest.ACCOUNT_TYPE;
            //}
            //loadCompanyPrivileges();
            //}
        }
        public bool lViewOnly = false;
        public void CheckUserRoles()
        {
            User _oUser = (User)GlobalVariables.goUser;
            foreach (Role _oRole in _oUser.Roles)
            {
                foreach (Role_Privilege _oPrivilege in _oRole.Privileges)
                {
                    if (_oPrivilege.Privilege.ToUpper() == "ADD EVENT OFFICERS" && _oPrivilege.Allowed == 1)
                    {
                        lCanAddEventOfficer = true;
                    }
                    if (_oPrivilege.Privilege.ToUpper() == "ASSIGN MARKETING OFFICER" && _oPrivilege.Allowed == 1)
                    {
                        lCanAddMarketingOfficer = true;
                    }
                }
            }

            if (cboSales_Executive.Text == "" && lCanAddMarketingOfficer == false)
            {
                    //MessageBox.Show("This event is not yet assign to a Marketing officer.\n Please contact your Head Marketing Officer!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //this.BeginInvoke(new MethodInvoker(Close));
                //pnlFolio.Enabled = false;
                //pnlStatus.Enabled = false;
                //pnlNew.Enabled = false;
                lViewOnly = true;
            }

            if (cboSales_Executive.Text.ToUpper() != _oUser.UserId.ToUpper() && lCanAddMarketingOfficer == false)
            {
                    //MessageBox.Show("You dont have rights to access this event!\n Please contact your Head Marketing Officer!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //this.BeginInvoke(new MethodInvoker(Close));
                //pnlFolio.Enabled = false;
                //pnlStatus.Enabled = false;
                //pnlNew.Enabled = false;
                lViewOnly = true;
            }
            
            if (lCanAddMarketingOfficer == false)
            {
                cboSales_Executive.Enabled = false;
            }
            else
            {
                cboSales_Executive.Enabled = true;
            }
        }
        private void saveFunctionRooms()
        {
            /* check first whether folio's status is already checked-in or not
             * if checked-in, update the folioschedules and roomevents with the correct schedules
             * if tentative, delete folioschedules and roomevents then save again
             */

            string _roomID = "";
            DateTime _startDate, _endDate, _startTime, _endTime;

            /*  for each row in the grid of function rooms
             *  save to folioschedules and roomevents
             */
            GenericList<Schedule> lScheduleList = new GenericList<Schedule>();
            foreach (C1.Win.C1FlexGrid.Row _row in grdSchedules.Rows)
            {
                if (_row.Index != 0)
                {
                    _roomID = grdSchedules.GetDataDisplay(_row.Index, "room");
                    _startDate = DateTime.Parse(grdSchedules.GetDataDisplay(_row.Index, "fromDate"));
                    _endDate = DateTime.Parse(grdSchedules.GetDataDisplay(_row.Index, "toDate"));
                    _startTime = DateTime.Parse(grdSchedules.GetDataDisplay(_row.Index, "startTime"));
                    _endTime = DateTime.Parse(grdSchedules.GetDataDisplay(_row.Index, "endTime"));

                    Schedule _oSchedule = new Schedule();
                    _oSchedule.RoomID = _roomID;
                    _oSchedule.RoomType = "FUNCTION";
                    _oSchedule.FromDate = _startDate;
                    _oSchedule.ToDate = _endDate;
                    _oSchedule.RateType = grdSchedules.GetDataDisplay(_row.Index, "rateType");
                    _oSchedule.Rate = decimal.Parse(grdSchedules.GetDataDisplay(_row.Index, "amount"));
                    _oSchedule.BreakFast = "N";
                    _oSchedule.FolioID = txtFolioID.Text;
                    _oSchedule.HotelID = GlobalVariables.gHotelId;
                    _oSchedule.CreatedBy = GlobalVariables.gLoggedOnUser;
                    _oSchedule.UpdatedBy = GlobalVariables.gLoggedOnUser;
                    _oSchedule.StartTime = _startTime;
                    _oSchedule.TerminalId = GlobalVariables.gTerminalID.ToString();
                    _oSchedule.ShiftCode = GlobalVariables.gShiftCode.ToString();
                    _oSchedule.EndTime = _endTime;
                    _oSchedule.Venue = grdSchedules.GetDataDisplay(_row.Index, "venueName");
                    _oSchedule.Setup = grdSchedules.GetDataDisplay(_row.Index, "setup");
                    _oSchedule.Activity = grdSchedules.GetDataDisplay(_row.Index, "activity");
                    _oSchedule.Remarks = grdSchedules.GetDataDisplay(_row.Index, "remarks");
                    _oSchedule.Id = grdSchedules.GetDataDisplay(_row.Index, "id");
                    _oSchedule.EVENT_SETUP_START = grdSchedules.GetDataDisplay(_row.Index, "SetUpStart");
                    _oSchedule.EVENT_SETUP_END = grdSchedules.GetDataDisplay(_row.Index, "SetUpEnd");
                    if (grdSchedules.GetDataDisplay(_row.Index, "guaranteedPax") == "")
                        _oSchedule.GuaranteedPax = "0";
                    else
                        _oSchedule.GuaranteedPax = grdSchedules.GetDataDisplay(_row.Index, "guaranteedPax");



                    lScheduleList.Add(_oSchedule);
                }
            }
            loFolio.Schedule = lScheduleList;
        }

       

        private void btnSave_Click()
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

            if (this.cboSales_Executive.Text.Trim().Length <= 0 && cboSales_Executive.Text == "")
            {
                MessageBox.Show("Please select Marketing Officer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSales_Executive.Focus();
                return;
            }
            if ((txtCompanyName.Text != "" || txtLastName.Text != "") && txtGroupName.Text != "")
            {
                if (isBlankAmountFromRecurringCharge() == false)
                {
                    //if (true)//checkChildCheckIn())
                    //{
                    //    loFolio.Status = "ONGOING";
                    //}
                    //commented next line for adding groups without child folios
                    //by Genny - Apr. 26, 2008
                    //MessageBox.Show("No guests in this group yet. Kindly add guests to this group.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // if (MessageBox.Show("Are you sure that you want to save this reservation without Dependent Folios?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    // {
                    try
                    {
                        saveGroupFolio(ref _oTransaction);
                        if (lIsEventManagementDisabled == false)
                        {
                            saveBookingInfo(ref _oTransaction);
                            //saveDependentFolios();
                            saveEventDetails(ref _oTransaction);

                        }
                        saveEventEndorsement(ref _oTransaction);

                        _oTransaction.Commit();

                        AfterSaveAction();
                        MessageBox.Show("Transaction successful. " + "\r\n" + "Event Reservation has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFolio();

                        updateCurrentRoomStatus();
                        this.Text = "Marketing";
                        lEdit = false;
                    }
                    catch (Exception ex)
                    {
                        _oTransaction.Rollback();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //}
                    //else
                    //{
                    //    MessageBox.Show(lMessage, "Group Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}

                }
                else
                {
                    MessageBox.Show("No Company and Group name given", "Group Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void saveEventEndorsement(ref MySqlTransaction poTransaction)
        {
            EventEndorsement _EventEndorsement = loFolio.EventEndorsement;
            DataTable _ResultEventEndorsement = _EventEndorsement.getEventEndorsement(loFolio.EventEndorsement.FolioID, loFolio.EventEndorsement.HotelID.ToString());
            if (_ResultEventEndorsement.Rows.Count < 1)
            {
                _EventEndorsement.save(ref poTransaction);
            }
            else
            {
                _EventEndorsement.update(ref poTransaction);
            }
        }
        private void saveEventDetails(ref MySqlTransaction poTransaction)
        {
            //saveMeals();
            saveRequirements(ref poTransaction);

            ////>>for event type details
            //EventDetails _oEventDetails = new EventDetails();
            //EventFacade _oEventDetailsFacade = new EventFacade();
            //_oEventDetailsFacade.deleteEventDetails(txtFolioID.Text, ref poTransaction);

            //int _counter = 1;
            //int _rowCount = gridEventDetails.Rows.Count - 1;
            //foreach (C1.Win.C1FlexGrid.Row _cntRow in gridEventDetails.Rows)
            //{
            //    if (_cntRow.Index != 0 && _counter < _rowCount)
            //    {
            //        _oEventDetails.FolioID = txtFolioID.Text;
            //        _oEventDetails.EventDetailHeader = gridEventDetails.GetDataDisplay(_counter, 0);
            //        _oEventDetails.Description = gridEventDetails.GetDataDisplay(_counter, 1);

            //        try
            //        {
            //            // WHEN WILL PROGRAM ENTER HERE
            //            _oEventDetailsFacade.saveEventDetails(_oEventDetails, ref poTransaction);
            //        }
            //        catch (Exception ex)
            //        {
            //            throw new Exception("Transaction failed.\r\nError in saving event details.\r\n\r\nError message : " + ex.Message);
            //        }
            //        _counter++;
            //    }
            //}//<<end event type details
        }
        private bool saveRequirements(ref MySqlTransaction pTrans)
        {
            try
            {
                txtRequirementNote.Text = "";

                //>>for other requirements
                EventRequirementsFacade _oEventRequirementsFacade = new EventRequirementsFacade();
                EventRequirements _oEventRequirements = new EventRequirements();
                _oEventRequirementsFacade.deleteEventsRequirements(txtFolioID.Text, ref pTrans);

                for (int _ctr = 0; _ctr < treeRequirements.Nodes.Count; _ctr++)
                {
                    foreach (TreeNode _treeNode in treeRequirements.Nodes[_ctr].Nodes)
                    {
                        //_oEventRequirements.FolioID = txtFolioID.Text;
                        //_oEventRequirements.RequirementCode = _treeNode.Parent.Text;
                        //_oEventRequirements.Description = _treeNode.Text;
                        _oEventRequirements.FolioID = txtFolioID.Text;
                        _oEventRequirements.Remarks = _treeNode.Parent.Text;

                        foreach (TreeNode _childNode in _treeNode.Nodes)
                        {
                            _oEventRequirements.RequirementCode = _childNode.Parent.Text;
                            _oEventRequirements.Description = _childNode.Text;

                            try
                            {
                                _oEventRequirementsFacade.saveEventsRequirements(_oEventRequirements, ref pTrans);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Transaction failed.\r\nError in saving event requirements.\r\n\r\nError message : " + ex.Message);
                            }
                        }
                    }
                }//<<end other requirements
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool saveMeals()
        {
            try
            {
                if (newMeal == true)
                {
                    //>>food requirements
                    EventFoodRequirementsFacade _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    EventFoodRequirements oMealHeader = new EventFoodRequirements();
                    bool _isExist = _oMealHeaderFacade.eventDateExists(dtpFoodDate.Value, txtFolioID.Text);

                    oMealHeader = new EventFoodRequirements();
                    oMealHeader.EventDate = dtpFoodDate.Value;
                    oMealHeader.Venue = txtVenueFood.Text;
                    oMealHeader.StartTime = DateTime.Parse(txtStartMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.EndTime = DateTime.Parse(txtEndMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.Over = txtFoodOver.Text;
                    oMealHeader.Setup = txtFoodSetup.Text;
                    oMealHeader.Remarks = txtFoodRemarks.Text;
                    oMealHeader.FolioID = txtFolioID.Text;
                    oMealHeader.TotalMealCost = 0;
                    oMealHeader.Pax = int.Parse(nudMealPax.Value.ToString());
                    oMealHeader.MealType = cboMealType.Text;
                    oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                    oMealHeader.PaxLiveIn = int.Parse(nudMealLiveIn.Value.ToString());
                    oMealHeader.PaxLiveOut = int.Parse(nudMealPax.Value.ToString());//int.Parse(nudMealLiveOut.Value.ToString());

                    try
                    {
                        oMealHeader.TotalMealCost = decimal.Parse(txtTotalMealAmount.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Meal amount entered is incorrect. Please check input.", "Incorrect entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    _oMealHeaderFacade.saveFoodRequirements(oMealHeader);

                    //>>_oMealMenu details
                    foreach (C1.Win.C1FlexGrid.Row r in gridMealItems.Rows)
                    {
                        if (r.Index != 0)
                        {
                            oMealHeader = new EventFoodRequirements();
                            oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                            oMealHeader.MenuCode = gridMealItems.GetDataDisplay(r.Index, 0).ToString();
                            oMealHeader.MenuItemCode = gridMealItems.GetDataDisplay(r.Index, 1).ToString();
                            oMealHeader.Description = gridMealItems.GetDataDisplay(r.Index, 2).ToString();
                            oMealHeader.Remarks = gridMealItems.GetDataDisplay(r.Index, 3).ToString();
                            oMealHeader.Price = 0;

                            try
                            {
                                EventFoodRequirementsFacade mealDetailFacade = new EventFoodRequirementsFacade();
                                mealDetailFacade.saveMealDetails(oMealHeader);
                            }
                            catch { }
                        }//end foreach of _oMealMenu details
                    }//end of _oMealMenu header

                    return true;
                }//end if isNewMeal

                else
                {
                    EventFoodRequirementsFacade _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    EventFoodRequirements oMealHeader = new EventFoodRequirements();

                    oMealHeader = new EventFoodRequirements();
                    oMealHeader.EventDate = dtpFoodDate.Value;
                    oMealHeader.Venue = txtVenueFood.Text;
                    oMealHeader.StartTime = DateTime.Parse(txtStartMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.EndTime = DateTime.Parse(txtEndMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.Over = txtFoodOver.Text;
                    oMealHeader.Setup = txtFoodSetup.Text;
                    oMealHeader.Remarks = txtFoodRemarks.Text;
                    oMealHeader.FolioID = txtFolioID.Text;
                    oMealHeader.Pax = int.Parse(nudMealPax.Value.ToString());
                    oMealHeader.MealType = cboMealType.Text;
                    oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                    oMealHeader.PaxLiveIn = int.Parse(nudMealLiveIn.Value.ToString());
                    oMealHeader.PaxLiveOut = int.Parse(nudMealPax.Value.ToString());//int.Parse(nudMealLiveOut.Value.ToString());

                    try
                    {
                        oMealHeader.TotalMealCost = decimal.Parse(txtTotalMealAmount.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Meal amount entered is incorrect. Please check input.", "Incorrect entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    _oMealHeaderFacade.updateFoodRequirements(oMealHeader);
                    _oMealHeaderFacade.deleteMealDetails(cboMealType.Tag.ToString());

                    //>>_oMealMenu details
                    foreach (C1.Win.C1FlexGrid.Row r in gridMealItems.Rows)
                    {
                        if (r.Index != 0)
                        {
                            oMealHeader = new EventFoodRequirements();
                            oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                            oMealHeader.MenuCode = gridMealItems.GetDataDisplay(r.Index, 0).ToString();
                            oMealHeader.MenuItemCode = gridMealItems.GetDataDisplay(r.Index, 1).ToString();
                            oMealHeader.Description = gridMealItems.GetDataDisplay(r.Index, 2).ToString();
                            oMealHeader.Remarks = gridMealItems.GetDataDisplay(r.Index, 3).ToString();
                            oMealHeader.Price = 0;

                            try
                            {
                                EventFoodRequirementsFacade mealDetailFacade = new EventFoodRequirementsFacade();
                                mealDetailFacade.saveMealDetails(oMealHeader);
                            }
                            catch { }
                        }//end foreach of _oMealMenu details
                    }//end of _oMealMenu header

                    return true;
                }//end else


                //return false;
            }//end try
            catch
            {
                return false;
            }
            finally
            {
                _isNewMeal = false;
            }
        }
        private bool saveGridMeals()
        {
            foreach (C1.Win.C1FlexGrid.Row _row in gridNewMeal.Rows)
            {
                try
                {
                    if (gridNewMeal.GetDataDisplay(_row.Index,"NewMeal") == "1")
                    {

                        //>>food requirements
                        EventFoodRequirementsFacade _oMealHeaderFacade = new EventFoodRequirementsFacade();
                        EventFoodRequirements oMealHeader = new EventFoodRequirements();
                        bool _isExist = _oMealHeaderFacade.eventDateExists(dtpFoodDate.Value, txtFolioID.Text);

                        oMealHeader = new EventFoodRequirements();
                        oMealHeader.EventDate = DateTime.Parse(string.Format("{0:MMM dd YYYY}", _row["date"]));
                        oMealHeader.Venue = gridNewMeal.GetDataDisplay(_row.Index,"venue").ToString();
                        oMealHeader.StartTime = DateTime.Parse("2012-12-12 12:00:00").ToString("HH:mm:ss");
                        oMealHeader.EndTime = DateTime.Parse("2012-12-12 12:00:00").ToString("HH:mm:ss");
                        oMealHeader.Over = gridNewMeal.GetDataDisplay(_row.Index,"over").ToString();
                        oMealHeader.Setup = gridNewMeal.GetDataDisplay(_row.Index,"setup").ToString();
                        oMealHeader.Remarks = gridNewMeal.GetDataDisplay(_row.Index,"remarks").ToString();
                        oMealHeader.FolioID = txtFolioID.Text;
                        //oMealHeader.TotalMealCost = decimal.Parse(gridNewMeal.GetDataDisplay(_row.Index, "foodNet").ToString());
                        oMealHeader.Pax = int.Parse(gridNewMeal.GetDataDisplay(_row.Index,"noOfPax").ToString());
                        oMealHeader.MealType = gridNewMeal.GetDataDisplay(_row.Index,"typeOfMeal").ToString();
                        string mealID = loSequence.getSequenceId("", 5, "seq_mealid");
                        oMealHeader.MealID = int.Parse(mealID);
                        oMealHeader.PaxLiveIn = int.Parse(nudMealLiveIn.Value.ToString());
                        oMealHeader.PaxLiveOut = int.Parse(nudMealPax.Value.ToString());//int.Parse(nudMealLiveOut.Value.ToString());
                        try
                        {
                            oMealHeader.TotalMealCost = decimal.Parse(gridNewMeal.GetDataDisplay(_row.Index, "foodNet").ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Meal amount entered is incorrect. Please check input.", "Incorrect entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        _oMealHeaderFacade = new EventFoodRequirementsFacade();
                        _oMealHeaderFacade.saveFoodRequirements(oMealHeader);
                        //>>_oMealMenu details
                        

                    }//end if isNewMeal
                    else
                    {
                        EventFoodRequirementsFacade _oMealHeaderFacade = new EventFoodRequirementsFacade();
                        EventFoodRequirements oMealHeader = new EventFoodRequirements();

                        oMealHeader = new EventFoodRequirements();
                        oMealHeader.EventDate = DateTime.Parse(string.Format("{0:MMM dd YYYY}", _row["date"]));
                        oMealHeader.Venue = _row["venue"].ToString();
                        oMealHeader.StartTime = DateTime.Parse("2012-12-12 12:00:00").ToString("HH:mm:ss");
                        oMealHeader.EndTime = DateTime.Parse("2012-12-12 12:00:00").ToString("HH:mm:ss");
                        oMealHeader.Over = gridNewMeal.GetDataDisplay(_row.Index,"over").ToString();
                        oMealHeader.Setup = gridNewMeal.GetDataDisplay(_row.Index,"setup").ToString();
                        oMealHeader.Remarks = gridNewMeal.GetDataDisplay(_row.Index,"remarks").ToString();
                        oMealHeader.FolioID = txtFolioID.Text;
                        //oMealHeader.TotalMealCost = 
                        oMealHeader.Pax = int.Parse(gridNewMeal.GetDataDisplay(_row.Index,"noOfPax").ToString());
                        oMealHeader.MealType = gridNewMeal.GetDataDisplay(_row.Index, "typeOfMeal").ToString(); 
                        oMealHeader.MealID = int.Parse(gridNewMeal.GetDataDisplay(_row.Index,"MealID").ToString());
                        oMealHeader.PaxLiveIn = int.Parse(nudMealLiveIn.Value.ToString());
                        oMealHeader.PaxLiveOut = int.Parse(nudMealPax.Value.ToString());//int.Parse(nudMealLiveOut.Value.ToString());
                        try
                        {
                            oMealHeader.TotalMealCost = decimal.Parse(gridNewMeal.GetDataDisplay(_row.Index, "foodNet").ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Meal amount entered is incorrect. Please check input.", "Incorrect entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        _oMealHeaderFacade = new EventFoodRequirementsFacade();
                        _oMealHeaderFacade.updateFoodRequirements(oMealHeader);
                      //  _oMealHeaderFacade.deleteMealDetails(cboMealType.Tag.ToString());

                    }

                }
                catch
                {
                    if (_row.Index > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }



   


     
        private bool saveChildRoomRequirements(ref MySqlTransaction pTrans)
        {
          
            return true;
        }

        private void AfterSaveAction()
        {
            btnEdit.Visible = true;
            //btnNew.Enabled = false;
            //panelNew.Visible = false;
            KeypressTextboxHandler(this, true);
            lEdit = false;
        }
        private void gridEventOfficer_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string _filter = "";
            for (int i = 1; i < gridEventOfficer.Rows.Count; i++)
            {
                if (i != gridEventOfficer.Row)
                {
                    _filter = _filter + "UserId <> '" + gridEventOfficer.GetDataDisplay(i, 2).ToString() + "' and ";
                }
            }
            if (_filter.Length > 0)
            {
                _filter = _filter.Substring(0, _filter.Length - 4);
            }

            DataView _dv = loUserList.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = _filter;

            cboUsers.DataSource = _dv.ToTable();

            if (e.Col == 0)
            {
                cboUsers.DisplayMember = "LastName";
                gridEventOfficer.Cols[0].Editor = cboUsers;
            }
            if (e.Col == 1)
            {
                cboUsers.DisplayMember = "FirstName";
                gridEventOfficer.Cols[1].Editor = cboUsers;
            }
        }


        DataView dtView;
        private object loadList(string a_LastName, string a_FirstName)
        {
            try
            {
                if (dtView == null)
                {
                    dtView = getRec();
                }

                dtView.RowStateFilter = DataViewRowState.OriginalRows;
                dtView.RowFilter = "LastName like '" + a_LastName + "%' and FirstName like '" + a_FirstName + "%'";
                dtView.Sort = "Lastname, Firstname";

                DataRowView dtr;
                this.lvwBrowseGuestName.Items.Clear();
                foreach (DataRowView tempLoopVar_dtr in dtView)
                {
                    dtr = tempLoopVar_dtr;
                    ListViewItem li = new ListViewItem(dtr["AccountId"].ToString());
                    li.SubItems.Add(dtr["LastName"].ToString());
                    li.SubItems.Add(dtr["FirstName"].ToString());
                    this.lvwBrowseGuestName.Items.Add(li);
                }

                if (dtView.Count <= 0)
                {
                    this.lvwBrowseGuestName.Visible = false;
                    this.txtcompanyid.Text = "";
                }
                else
                {
                    this.lvwBrowseGuestName.Location = new System.Drawing.Point(txtLastName.Location.X, txtLastName.Location.Y + 140);
                    this.lvwBrowseGuestName.Visible = true;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
        private void getGuest()
        {
            if (lFlag == "New" || lFlag == "Edit")
            {
                if (checkGuestAvailability())
                {
                    guestnotfound = false;
                    loGuestFacade = new GuestFacade();
                    this.txtcompanyid.Text = oGuest.Tables["Guests"].Rows[0]["AccountID"].ToString();
                }
                else
                {

                    if (saveGuestConfirmation == "NO" && lvwBrowseGuestName.Visible == false)
                    {
                        confirmSaveGuest();
                    }

                }
                //btnSaveGuest.Visible = true;
            }
            else
            {
                guestnotfound = true;
            }

        }
        private bool checkGuestAvailability()
        {
            if (countGuestRows() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private string saveGuestConfirmation = "NO";
        private int countGuestRows()
        {
            loGuestFacade = new GuestFacade();
            oGuest = loGuestFacade.filterGuestRecordRefName(GlobalFunctions.removeQuotes(this.txtLastName.Text), GlobalFunctions.removeQuotes(this.txtFirstName.Text), "");
            return oGuest.Tables["Guests"].Rows.Count;
        }
        private string mAccountID = "";
        private void assignGuestID()
        {
            Sequence sequence = new Sequence();
            string seqID = sequence.getSequenceId("I-", 12, "seq_guest");
            mAccountID = seqID;
        }

        private void confirmSaveGuest()
        {
            if (!(this.txtLastName.Text == "" || this.txtFirstName.Text == ""))
            {
                saveGuestConfirmation = "YES";
                assignGuestID();
                loGuestFacade = new GuestFacade();
                oGuest.AccountId = mAccountID; ;
                oGuest.LastName = this.txtLastName.Text;
                oGuest.FirstName = this.txtFirstName.Text;
                oGuest.MiddleName = "";
                oGuest.Title = "";
                oGuest.Sex = "";
                oGuest.Remark = "";
                oGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
                oGuest.TelephoneNo = "";
                oGuest.Street = "";
                oGuest.City = "";
                oGuest.Country = "";
                oGuest.Zip = "";
                oGuest.PassportId = "";
                oGuest.Citizenship = "";
                oGuest.MobileNo = "";
                oGuest.FaxNo = "";
                oGuest.EmailAddress = "";
                oGuest.Remark = "";
                oGuest.BIRTH_DATE = DateTime.Parse(txtCreateTime.Text);
                oGuest.THRESHOLD_VALUE = 0;
                oGuest.ACCOUNT_TYPE = "WALK-IN";
                oGuest.CARD_NO = "";
                oGuest.CompanyID = "";
                oGuest.Concierge = "";
                oGuest.CreditCardNo = "";
                oGuest.CreditCardType = "";
                oGuest.GuestImage = "";
                oGuest.Memo = "";
                oGuest.NoOfVisits = 0;
                oGuest.TaxExempted = 0;


                oGuest.HotelID = GlobalVariables.gHotelId;
                oGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
                oGuest.UpdatedBy = GlobalVariables.gLoggedOnUser;

                AccountInformation _oAccountInformation = new AccountInformation();
                _oAccountInformation.AccountID = oGuest.AccountId;
                _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

                oGuest.AccountInformation = _oAccountInformation;

                loGuestFacade.insertGuest(ref oGuest);
                this.txtcompanyid.Text = mAccountID;

                saveGuestConfirmation = "NO";
            }
        }
        private Guest oGuest = new Guest();
        private bool guestnotfound;

        public DataView getRec()
        {
            try
            {
                //Guest oGuest = new Guest();
                //GuestFacade oGuestFacade = new GuestFacade();
                //oGuest = oGuestFacade.getGuests();

                //DataView dtView = oGuest.Tables[0].DefaultView;
                //return dtView;

                DataTable _oDataTable = new DataTable();
                GuestFacade oGuestFacade = new GuestFacade();

                //_oDataTable = oGuestFacade.getGuestAccounts();
                _oDataTable = oGuestFacade.getGuestAccount(txtFirstName.Text, txtLastName.Text);
                DataView dtView = _oDataTable.DefaultView;

                return dtView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private void addMealDates(DateTime pStartDate, DateTime pEndDate)
        {
            //// THIS IS FOR MEAL REQUIREMENTS
            DateTime _startDate = DateTime.Parse(GlobalVariables.gAuditDate);
            DateTime _endDate = DateTime.Parse(GlobalVariables.gAuditDate);
            //for (int i = 1; i < this.gridFunctionRooms.Rows.Count; i++)
            //{
            //    try
            //    {
            //        if (i == 1)
            //        {
            //            _startDate = dtpFromDate.Value;
            //        }

            //        _endDate = dtpTodate.Value;
            //    }
            //    catch { }
            //}

            _startDate = pStartDate;
            _endDate = pEndDate;

            long _days = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _startDate, _endDate);
            for (int d = 0; d <= _days; d++)
            {
                bool isAdded = false;

                foreach (TreeNode tvwNode in treeFoodBev.Nodes)
                {
                    if (tvwNode.Text == _startDate.AddDays(d).ToShortDateString())
                    {
                        isAdded = true;
                        break;
                    }
                }
                if (!isAdded)
                {
                    this.treeFoodBev.Nodes.Add(_startDate.AddDays(d).ToShortDateString());
                }
            }
            //// end MEAL REQUIREMENTS
        }
     


        private bool checkIfRequirementIsAdded(string pRequirementSchedule, string pRequirementCode, string pRequirementDescription)
        {
            //foreach (TreeNode _node in treeRequirements.Nodes)
            //{
            //    if (_node.Text == pRequirementSchedule)
            //        return true;

            //    foreach (TreeNode _childNode in _node.Nodes)
            //    {
            //        if (_childNode.Text == pRequirementSchedule)
            //            return true;+++++++++++
            //    }
            //}

            foreach (TreeNode _parentNode in treeRequirements.Nodes)
            {
                if (_parentNode.Text == pRequirementSchedule)
                {
                    foreach (TreeNode _childNode in _parentNode.Nodes)
                    {
                        if (_childNode.Text == pRequirementCode)
                        {
                            foreach (TreeNode _subNode in _childNode.Nodes)
                            {
                                if (_subNode.Text == pRequirementDescription)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public string NumberToText(int number)
        {
            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            //num[1] = num[1] - 100 * num[2]; // thousands
            num[1] = num[1] - (num[2] * 1000);
            num[3] = number / 1000000000; // crores
            //num[2] = num[2] - 100 * num[3]; // lakhs
            num[2] = num[2] - (num[3] * 1000);
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - (10 * h); // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd().ToUpper();
        }
        private EventContact getDecisionMaker()
        {
            foreach (EventContact _eventContact in loFolio.ContactPersons)
            {
                if (_eventContact.PersonType == "Decision Maker")
                {
                    return _eventContact;
                }
            }
            return null;
        }

        private void loadFolio()
        {
            loFolio = loFolioFacade.GetFolio(txtFolioID.Text);
            Control myForm = this;

            FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            mcompanyid = loFolio.CompanyID;
            //grdFolio.AllowEditing = false;
            //txtGroupRemarks.Text = loFolio.Remarks;

            //GetChildFolios();

            lGroupFolioStatus = "Old";
            switch (mAccountType)
            {
                case AccountType.Corporate:

                    if (mcompanyid.StartsWith("G"))
                    {
                        loCompany = new Company();

                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        rdbCompany.Checked = true;
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    else
                    {
                        Guest _oGuest = new Guest();

                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(mcompanyid);
                        rdbIndividual.Checked = true;

                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loGuestFacade);
                    }
                    break;
            }
            loAgent = new Agent();

            //if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
            //{
            //    loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
            //    txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
            //}
            //else
            //{
            //    txtagentid.Text = "";
            //}

            btnEdit.Visible = true;
           // lFlag = "Edit";
            KeypressTextboxHandler(this, true);
            //txtCompanyId_TextChanged();

            //loadPackages();
            loadFolioRecurringCharges();
            ////loadRooms();
            //getCharges(grdRecurringCharges);

            //getCharges(gridTransactionCodes);
            //LoadFolioRouting(loFolio);
            //loadEventBookingInfo();
            //loadFolioPackage();
            setButtons();
            loadEventBookingInfo();
            loadAllFoodAndBevNew();
            loadFolioSchedules();
            //txtGroupRemarks.Text = loFolio.Remarks;
            //grdFolio.Sort(SortFlags.Ascending, 2, 3);

        }
        public void loadEventBookingInfo()
        {
            GenericList<EventBookingInfo> _oEventBookingInfoList = new GenericList<EventBookingInfo>();
            _oEventBookingInfoList = loEventFacade.getEvent(txtFolioID.Text);
            foreach (EventBookingInfo _oEventBookingInfo in _oEventBookingInfoList)
            {
             
                txtCreateTime.Text = _oEventBookingInfo.BookingDate.ToString("dd-MMM-yyyy");
              
            }
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            string _rooms = "";
            _rooms = _oScheduleFacade.GetRoomFromSchedules(loFolio.FolioID);
            txtRooms.Text = _rooms;
            txtEventDate.Text = loFolio.FromDate.ToString("dd-MMM-yyyy") +" - " + loFolio.Todate.ToString("dd-MMM-yyyy") ;
        }//<<
        private void getCharges(C1.Win.C1FlexGrid.C1FlexGrid grid)
         {
            int i;
            TransactionCodeFacade oTransactionCodesDAO = new TransactionCodeFacade();
            DataSet ds = (DataSet)oTransactionCodesDAO.loadObject();
            DataTable dt = ds.Tables[0];

            grid.Rows.Count = 1;
            foreach (DataRow dRow in dt.Rows)
            {
                if (dRow["acctside"].ToString() == "DEBIT")
                {
                    i = grid.Rows.Count;
                    grid.Rows.Count++;

                    grid.SetData(i, 0, dRow["trancode"].ToString());
                    grid.SetData(i, 1, dRow["memo"].ToString());
                }
            }
        }
        private void btnCancelReservation_Click()
        {
            //if (MessageBox.Show("You have made changes to this reservation, \n Do you want to continue", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //if (btnCancelReservation.Text == "C&ancel")
            //{
            //    //this.Close();
            //    if (MessageBox.Show("You have made changes to this reservation, \n Do you want to continue", "Event Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {

            //        AfterSaveAction();
            //        loadFolio();

            //        updateCurrentRoomStatus();
            //        this.Text = "Marketing";
            //        lEdit = false;
            //    }
            //}
            //else if (btnCancelReservation.Text == "C&ancel Rsvn")
            //{
                MySql.Data.MySqlClient.MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
                FolioFacade oFolioFacade = new FolioFacade();
                if (MessageBox.Show("Action will Cancel the Reservation including the Sub Folios,\n Do You want to continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oFolioFacade.CheckStatusToCancel(txtFolioID.Text) == true)
                    {
                        loFolio.Status = "CANCELLED";
                        //loFolio = oFolioFacade.GetFolio(folioID);

                        bool hasBalance = false;

                        loFolio.CreateSubFolio();
                        decimal balance = 0;
                        foreach (SubFolio subF in loFolio.SubFolios)
                        {
                            subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                            balance = subF.Ledger.BalanceNet;
                            if (balance != 0)
                            {
                                hasBalance = true;
                            }
                        }

                        if (hasBalance)
                        {
                            MessageBox.Show("Transaction failed.\r\n\r\nGuest still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //>>by Genny: Apr. 29, 2008
                        //for cancellation purposes
                        ReasonForCancelUI reasonUI = new ReasonForCancelUI();
                        string reason = reasonUI.showDialog();
                        string reasonType = reasonUI.getReason();
                        string bookingType = reasonUI.getBookingType();

                        if (reason == "" && reasonType == "" && bookingType == "")
                            return;

                        //update folio status to cancelled
                        oFolioFacade.setFolioStatus(txtFolioID.Text, "CANCELLED", reason, reasonType, bookingType);
                        //oFolioFacade.updateFolio(oFolio);
                        //update group's dependent folios to cancelled
                        oFolioFacade.SetChildFolioStatus(txtFolioID.Text, "CANCELLED", reason);

                        //cancell group's room events and also its child's room events
                        RoomEventFacade oRoomEventFacade = new RoomEventFacade();
                        oRoomEventFacade.CancelRoomEvents(txtFolioID.Text, "RESERVATION", "CANCELLED");
                        DataTable getChildFolio = oFolioFacade.GetChildFoliosTable(txtFolioID.Text);
                        if (getChildFolio.Rows.Count > 0)
                        {
                            DataRow dtRows;
                            foreach (DataRow tempLoopVar_dtRows in getChildFolio.Rows)
                            {
                                dtRows = tempLoopVar_dtRows;
                                string foliono = dtRows["FolioID"].ToString();
                                oRoomEventFacade.CancelRoomEvents(foliono, "RESERVATION", "CANCELLED");

                                //jlo 6-9-2010 cancel joiners
                                oFolioFacade.updateJoinerAllFolioStatus("CANCELLED", foliono);
                                //jlo
                            }
                        }

                        //unblock rooms that are blocked for that group
                        RoomBlockFacade _oRoomBlockFacade = new RoomBlockFacade();
                        string _event = txtFolioID.Text;
                        GenericList<RoomBlock> _oRoomBlockList = _oRoomBlockFacade.getBlockedRoomsForEvent(_event);
                        foreach (RoomBlock _oRoomBlock in _oRoomBlockList)
                        {
                            _oRoomBlockFacade.deleteRoomBlockedByEvent(_oRoomBlock.RoomID, txtFolioID.Text, ref trans);
                        }
                        //<<

                        trans.Commit();
                        updateCurrentRoomStatus();
                        this.Close();
                    }
                }
            //}
        }



        TableLogOnInfo logOnInfo;
        private void setDatabaseLogOn()
        {
            logOnInfo = new TableLogOnInfo();
            //TableLogOnInfo logOnInfo = new TableLogOnInfo();
            string con = ConfigurationManager.AppSettings.Get("connection");
            string[] split ={ ";", "=" };
            string[] strCon = con.Split(split, StringSplitOptions.RemoveEmptyEntries);

            logOnInfo.ConnectionInfo.ServerName = strCon[1];
            logOnInfo.ConnectionInfo.UserID = strCon[3];
            logOnInfo.ConnectionInfo.Password = strCon[5];
            logOnInfo.ConnectionInfo.DatabaseName = strCon[7];
            logOnInfo.ConnectionInfo.Type = ConnectionInfoType.CRQE;

            //logOnInfos.Add(logOnInfo);
        }


        private void btnCheckOUt_Click()
        {
            FolioFacade _oFolioFacade = new FolioFacade();
            FolioTransactions _oFolioTransaction = new FolioTransactions();
            _oFolioTransaction = _oFolioFacade.GetFolioTransactions(txtFolioID.Text, "A");

            //if (_oFolioTransaction == null || _oFolioTransaction.Count == 0)
            //{
            //    if (MessageBox.Show("A guest has no posted transactions. Do you want to post transactions?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
            //        if (oPostRoomChargeFacade.initializePostRoomCharges(txtFolioID.Text) == true)
            //        {
            //            MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            if (loEventFacade.isGroupPackagePosted(txtFolioID.Text) == false)
            {
                PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
                if (oPostRoomChargeFacade.initializePostRoomCharges(txtFolioID.Text) == true)
                {
                    MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            CheckOutUI _oCheckOutUI = new CheckOutUI(lFolioNo, txtGroupName.Text);
            _oCheckOutUI.MdiParent = this.MdiParent;
            _oCheckOutUI.Show();
        }


        private void showCompanyLookUp(string pCompanyName)
        {
            try
            {
                CompanyFacade _oCompanyFacade = new CompanyFacade();

                //List<Company> _oCompanies = new List<Company>();
                //_oCompanies = _oCompanyFacade.getCompanyList();

                //_oCompanies = _oCompanies.FindAll(delegate(Company _oCompany) { return _oCompany.CompanyName.ToUpper().StartsWith(pCompanyName.ToUpper()); });

                //this.lvwBrowseCompany.Items.Clear();
                //foreach (Company pCompany in _oCompanies)
                //{
                //    ListViewItem _lvwItem = new ListViewItem();
                //    _lvwItem.Text = pCompany.CompanyId;

                //    _lvwItem.SubItems.Add(pCompany.CompanyName);

                //    this.lvwBrowseCompany.Items.Add(_lvwItem);
                //}

                DataTable _oCompany = new DataTable();
                _oCompany = _oCompanyFacade.getCompanies();
                DataView _dtViewCompany = _oCompany.DefaultView;

                _dtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
                _dtViewCompany.RowFilter = "CompanyName like '" + pCompanyName.ToUpper() + "%'";
                this.lvwBrowseCompany.Items.Clear();
                foreach (DataRowView dr in _dtViewCompany)
                {
                    ListViewItem _lvwItem = new ListViewItem();
                    _lvwItem.Text = dr[0].ToString();
                    _lvwItem.SubItems.Add(dr[2].ToString());
                    /* Gene
                     * 01-Mar-12
                     */
                    _lvwItem.SubItems.Add(dr["TIN"].ToString());

                    lvwBrowseCompany.Items.Add(_lvwItem);
                }


                //if (_oCompanies.Count <= 0)
                if (_dtViewCompany.Count <= 0)
                {
                    this.lvwBrowseCompany.Visible = false;
                    this.txtcompanyid.Text = "";
                }
                else
                {
                    //lvwBrowseCompany.Location = new System.Drawing.Point(390, 122);
                    lvwBrowseCompany.Location = new System.Drawing.Point(txtCompanyName.Location.X, txtCompanyName.Location.Y + 150);
                    this.lvwBrowseCompany.Visible = true;
                    this.lvwBrowseCompany.HeaderStyle = ColumnHeaderStyle.None;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCheckIN_Click()
        {
            //jlo for apla 6-11-10
            String _rStatus = "";
            _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;

            int _newStatus = getIndex("ONGOING", aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                MessageBox.Show("Cannot check in reservation because it is already " + _rStatus + ".\nPlease close this reservation form for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //jlo

            if (cboStatus.Text == "WAIT LIST" || cboStatus.Text == "TENTATIVE")
            {
                MessageBox.Show("Cannot check-in reservation. \nStatus is " + cboStatus.Text + ".\n\nYou must confirm reservation first before checking-in.", "Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DateTime.Parse(loFolio.FromDate.ToString("yyyy-MM-dd")) <= DateTime.Parse(GlobalVariables.gAuditDate))
            {
                DialogResult rsp = MessageBox.Show("Event will now be ONGOING.\r\n\r\nAre you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool _isCheckedIn = false;

                if (rsp == DialogResult.Yes)
                {
                    FolioFacade _oFolioFacade = new FolioFacade();
                    string _folioNo = txtFolioID.Text;
                    Folio _oFolio = new Folio();
                    _oFolio = _oFolioFacade.GetFolio(_folioNo);

                    if (_oFolio.Schedule.Count <= 0)
                    {
                        if (_oFolioFacade.checkInFolio(_folioNo, ""))
                        {
                            _isCheckedIn = true;
                        }
                    }
                    else
                    {
                        foreach (Schedule _oSchedule in _oFolio.Schedule)
                        {
                            //operator changed from == to <= , to allow previous event to start
                            // Clark 08.10.2011
                            if (_oSchedule.FromDate <= DateTime.Parse(GlobalVariables.gAuditDate))
                            {
                                if (_oFolioFacade.checkInFolio(_folioNo, _oSchedule.RoomID))
                                {
                                    _isCheckedIn = true;
                                }
                            }
                            else if (_oSchedule.FromDate > DateTime.Parse(GlobalVariables.gAuditDate))
                            {
                                DialogResult response = MessageBox.Show("Transaction failed.\r\n\r\nScheduled date is on " + string.Format("{0:ddd. MMM dd, yyyy}", _oSchedule.FromDate) + ".\r\n\r\n\r\nWould you like to change it to current date ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                                if (response == DialogResult.Yes)
                                {
                                    foreach (Schedule _oSchedule2 in _oFolio.Schedule)
                                    {
                                        if (_oFolioFacade.checkInFolio(_folioNo, _oSchedule2.RoomID))
                                        {
                                            _isCheckedIn = true;
                                        }
                                    }

                                    break;
                                }
                            }
                        }
                    }
                }

                if (_isCheckedIn)
                {
                    MessageBox.Show("Transaction successful.\r\nEvent is now Ongoing", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //loadFolio();
                    lGroupFolioStatus = "Old";
                    loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                    MarketingUI_Load();
                    cboStatus.Text = "ONGOING";

                    updateCurrentRoomStatus();
                    setButtons();
                }
            }
            else
            {
                MessageBox.Show("Event date is greater than the current audit date.\r\n Change first the event dates of the group before check in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private IList<EventContact> assignContactPersons()
        {
            IList<EventContact> _contactPersons = new List<EventContact>();
            try
            {
                EventContact _oContactPerson;
                for (int row = 1; row < gridContacts.Rows.Count; row++)
                {
                    _oContactPerson = new EventContact();
                    if (gridContacts.GetDataDisplay(row, 11).ToString() != "")
                    {
                        _oContactPerson.ContactID = gridContacts.GetDataDisplay(row, 11).ToString();
                    }
                    else
                    {
                        _oContactPerson.ContactID = "AUTO";
                    }
                    _oContactPerson.FolioID = loFolio.FolioID;
                    _oContactPerson.AccountID = loFolio.CompanyID;
                    _oContactPerson.HotelID = GlobalVariables.gHotelId.ToString();
                    _oContactPerson.LastName = gridContacts.GetDataDisplay(row, 0).ToString();
                    _oContactPerson.FirstName = gridContacts.GetDataDisplay(row, 1).ToString();
                    _oContactPerson.MiddleName = gridContacts.GetDataDisplay(row, 2).ToString();
                    _oContactPerson.Designation = gridContacts.GetDataDisplay(row, 3).ToString();
                    _oContactPerson.PersonType = gridContacts.GetDataDisplay(row, 4).ToString();
                    _oContactPerson.Address = gridContacts.GetDataDisplay(row, 5).ToString();
                    _oContactPerson.TelNo = gridContacts.GetDataDisplay(row, 6).ToString();
                    _oContactPerson.MobileNo = gridContacts.GetDataDisplay(row, 7).ToString();
                    _oContactPerson.FaxNo = gridContacts.GetDataDisplay(row, 8).ToString();
                    _oContactPerson.Email = gridContacts.GetDataDisplay(row, 9).ToString();
                    try
                    {
                        _oContactPerson.BirthDate = DateTime.Parse(gridContacts.GetDataDisplay(row, 10).ToString());
                    }
                    catch
                    {
                        _oContactPerson.BirthDate = DateTime.Parse("01-01-1900");
                    }

                    _contactPersons.Add(_oContactPerson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignContactPersons\r\n" + ex.Message);
            }
            return _contactPersons;
        }
        private void loadContactPersons()
        {
            if (loFolio.ContactPersons != null && loFolio.ContactPersons.Count > 0)
            {
                try
                {
                    this.gridContacts.Rows.Count = 1;
                    int _row = this.gridContacts.Rows.Count - 1;
                    foreach (ContactPerson _contactPerson in loFolio.ContactPersons)
                    {
                        this.gridContacts.Rows.Count += 1;
                        _row = this.gridContacts.Rows.Count - 1;
                        /**
                         * 0 - lastname
                         * 1 - firstname
                         * 2 - middlename
                         * 3 - designation
                         * 4 - persontype
                         * 5 - address
                         * 6 - telno
                         * 7 - mobile no
                         * 8 - fax no
                         * 9 - email
                         * 10 - birthdate
                         * */
                        this.gridContacts.SetData(_row, 0, _contactPerson.LastName);
                        this.gridContacts.SetData(_row, 1, _contactPerson.FirstName);
                        this.gridContacts.SetData(_row, 2, _contactPerson.MiddleName);
                        this.gridContacts.SetData(_row, 3, _contactPerson.Designation);
                        this.gridContacts.SetData(_row, 4, _contactPerson.PersonType);
                        this.gridContacts.SetData(_row, 5, _contactPerson.Address);
                        this.gridContacts.SetData(_row, 6, _contactPerson.TelNo);
                        this.gridContacts.SetData(_row, 7, _contactPerson.MobileNo);
                        this.gridContacts.SetData(_row, 8, _contactPerson.FaxNo);
                        this.gridContacts.SetData(_row, 9, _contactPerson.Email);
                        this.gridContacts.SetData(_row, 10, _contactPerson.BirthDate);
                        this.gridContacts.SetData(_row, 11, _contactPerson.ContactID);
                        if (_contactPerson.PersonType == "Decision Maker")
                        {
                            this.gridContacts.Rows[_row].Style = this.gridContacts.Styles["decisionmaker"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @ loadContactPersons\r\n" + ex.Message);
                }
            }
            //else
            //{
            //    this.gridContacts.Rows.Count = 1;
            //}
        }

        public void loadFolioDeposits()
        {
            grdDeposits.Rows.Count = 1;
            FolioFacade _oFolioFacade = new FolioFacade();
            FolioTransactions _oFolioTransactions = new FolioTransactions();
            _oFolioTransactions = _oFolioFacade.GetFolioTransactions(txtFolioID.Text, "A");
            foreach (FolioTransaction _oFolioTrans in _oFolioTransactions)
            {
                if (_oFolioTrans.AcctSide == "CREDIT")
                {
                    grdDeposits.Rows.Count++;
                    grdDeposits.SetData(grdDeposits.Rows.Count - 1, 0, _oFolioTrans.TransactionDate);
                    grdDeposits.SetData(grdDeposits.Rows.Count - 1, 1, _oFolioTrans.BaseAmount);
                    grdDeposits.SetData(grdDeposits.Rows.Count - 1, 2, _oFolioTrans.ReferenceNo);
                    lTotalPayment += _oFolioTrans.BaseAmount;
                }
            }
            txtContractAmount_TextChanged(null, null);
            txtTotalEstimatedCost_TextChanged_1(null, null);
        }

        private void GetChildFolios()
        {
            try
            {
                DataTable _getChildData;
                loFolioFacade = new FolioFacade();
                _getChildData = loFolioFacade.GetChildFoliosTable(txtFolioID.Text);
                ScheduleFacade _oScheduleFacade = new ScheduleFacade();

                //grdFolio.Rows.Count = 1;

                string _rno;
                DataRow _dtRow;
                int _noShow = 0;
                int _checkIn = 0;
                int _checkOut = 0;
                int _overStay = 0;
                decimal _totalAmount = 0;
                decimal _totalBalance = 0;
                FolioTransactionFacade _oFolioTransFacade = new FolioTransactionFacade();
                Folio _oFolio = new Folio();
                foreach (DataRow _tempLoopVarDtRow in _getChildData.Rows)
                {
                    _dtRow = _tempLoopVarDtRow;
                    _oFolio = new Folio();
                    if (_dtRow["foliotype"].ToString() != "JOINER" && _dtRow["status"].ToString() != "CANCELLED")
                    {
                        _oFolio = loFolioFacade.GetFolio(_dtRow["FolioID"].ToString());
                        DateTime _arrivalTime = DateTime.Parse(_dtRow["arrivalDate"].ToString());
                        string _status = _dtRow["status"].ToString();
                        string _noShowTime = string.Format("{0:hh:mm tt}", _arrivalTime.AddHours(2));
                        string _timeNow = string.Format("{0:hh:mm tt}", DateTime.Parse(DateTime.Parse(GlobalVariables.gAuditDate).TimeOfDay.ToString()));

                        Schedule _oSchedule = new Schedule();
                        string _rooms;
                        if (_dtRow["masterfolio"].ToString() == "" || _dtRow["masterfolio"].ToString() != "" && _dtRow["foliotype"].ToString() == "DEPENDENT")
                        {
                            _rooms = _oScheduleFacade.GetRoomAndRoomTypeFromSchedules(_dtRow["foLIOid"].ToString());
                        }
                        else
                        {
                            _rooms = _oScheduleFacade.GetRoomAndRoomTypeFromSchedules(_dtRow["masterfolio"].ToString());
                        }
                        if (_rooms == "")
                        {
                            _rooms = "";
                        }
                        else
                        {
                            _rooms = _rooms.Substring(0, _rooms.Length - 2);
                        }

                        _rno = _dtRow["FOlioID"].ToString();
                        //grdFolio.Rows.Count++;

                        //-------------------------[ column 1 - ID   ]-----------------------------------'
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 0, _rno);

                        //-------------------------[ column 2 - Folio Owner]-----------------------------------'
                        Guest _oGuest = new Guest();
                        GuestFacade _oGuestFacade = new GuestFacade();
                        string _acctID = _dtRow["accountID"].ToString();
                        _oGuest = _oGuestFacade.getGuestRecord(_acctID);
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 1, _oGuest.LastName + ", " + _oGuest.FirstName);

                        //-------------------------[ column 3 - From Date]-----------------------------------'
                        string _fromDate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(_dtRow["Fromdate"].ToString()));
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 2, _fromDate);

                        //-------------------------[ column 4 - TO Date]-----------------------------------'
                        string _toDate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(_dtRow["todate"].ToString()));
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 3, _toDate);

                        //-------------------------[ column 5 - Rooms]-----------------------------------'
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 4, _rooms);

                        //-------------------------[ column 6 - Amount]-----------------------------------'

                        decimal totalSubFolioCharges = 0;
                        decimal totalSubFolioPayments = 0;
                        decimal totalSubFoliocurrentbalance = 0;
                        decimal totalSubFolioCashPayment = 0;
                        decimal totalSubFolioCardPayment = 0;
                        decimal totalSubFolioChequePayment = 0;
                        decimal totalSubFolioGiftChequePayment = 0;
                        decimal totalSubFolioBalanceForward = 0;


                        _oFolio.CreateSubFolio();
                        SubFolio subF = null;

                        decimal totalCharges = 0;
                        decimal totalPayments = 0;
                        decimal balance = 0;
                        foreach (SubFolio tempLoopVar_subF in _oFolio.SubFolios)
                        {
                            subF = tempLoopVar_subF;
                            //if (subF.SubFolio_Renamed == "B")
                            //{
                            subF.Ledger = loFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                            totalSubFolioCharges += subF.Ledger.Charges;
                            totalSubFolioCashPayment += subF.Ledger.PayCash;
                            totalSubFolioCardPayment += subF.Ledger.PayCard;
                            totalSubFolioChequePayment += subF.Ledger.PayCheque;
                            totalSubFolioGiftChequePayment += subF.Ledger.PayGiftCheque;
                            totalSubFolioBalanceForward += subF.Ledger.BalanceForwarded;
                            totalSubFolioPayments += subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded;

                            totalCharges += subF.Ledger.Charges;
                            totalPayments += (subF.Ledger.PayCard + subF.Ledger.PayCash + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded);
                            balance = totalCharges - totalPayments;

                            totalSubFoliocurrentbalance += balance;
                            //}

                        }
                        //}
                        //_balance += totalSubFoliocurrentbalance;

                        decimal _charges = totalCharges;
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 5, _charges.ToString("N"));

                        //-------------------------[ column 7 - Balance]------------------ -----------------'

                        _oFolio.FolioID = _rno;
                        _oFolio.FolioType = "INDIVIDUAL";

                        decimal _payment = totalPayments;
                        decimal _balance = balance;
                        _totalBalance += _balance;
                        _totalAmount += _charges - _payment;

                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 6, _balance.ToString("N"));

                        //-------------------------[ column 8 - Status]-----------------------------------'
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 7, _status);

                        //-------------------------[ column 9 - Time of Arrival]-----------------------------------'
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 8, string.Format("{0:hh:mm tt}", _arrivalTime));

                        //-------------------------[ column 10 - room#]-----------------------------------'
                        if (_dtRow["status"].ToString() == "ONGOING")
                        {
                            //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                            //havent check for possible errors if not constant parameter is used because of lack of time
                            string _roomNo = loFolioFacade.GetCurrentRoomOccupied(_rno, "INDIVIDUAL");
                            //grdFolio.SetData(grdFolio.Rows.Count - 1, 9, _roomNo);
                        }
                        else
                        {
                            //grdFolio.SetData(grdFolio.Rows.Count - 1, 9, "-");
                            //_listViewItem = new ListViewItem("-");
                        }

                        //-------------------------[ column 11 - number of pax]-----------------------------------'
                        string _numberOfPax = _dtRow["noOfAdults"].ToString();
                        //grdFolio.SetData(grdFolio.Rows.Count - 1, 11, _dtRow["noOfAdults"].ToString());

                        //DateTime noshowdate;
                        if (string.Format("{0:hh:mm tt}", _arrivalTime) == "11:00 PM" || string.Format("{0:hh:mm tt}", _arrivalTime) == "10:00 PM")
                        {
                            _fromDate = System.Convert.ToDateTime(_fromDate).AddDays(1).ToString();
                        }
                        DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

                        //if (DateTime.Today.Date == DateTime.Parse(_toDate) && _status == "ONGOING")
                        if (_auditDate.Date == DateTime.Parse(_toDate) && _status == "ONGOING")
                        {
                            //grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.PaleGreen;
                            _checkOut++;
                            //-------------------------[ TODAYS CHECKIN  ]-----------------------------------'
                        }
                        else if (_status == "CONFIRMED" && DateTime.Parse(_fromDate) == _auditDate.Date)
                        {
                            //grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.LightSkyBlue;
                            _checkIn++;
                            //-------------------------[ FOR OVERSTAY   ]-----------------------------------'
                        }
                        else if (_status == "ONGOING" && _auditDate.Date > DateTime.Parse(_toDate))
                        {
                            //grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.ForeColor = System.Drawing.Color.White;
                            //grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Red;
                            _overStay++;
                        }
                        if (DateTime.Parse(_fromDate) == _auditDate.Date && (_status == "CONFIRMED" || _status == "TENTATIVE") && System.Convert.ToDateTime(_timeNow) >= System.Convert.ToDateTime(_noShowTime))
                        {
                            //grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Gainsboro;
                            _noShow++;
                        }
                        if (DateTime.Parse(_fromDate) < _auditDate.Date && (_status == "CONFIRMED" || _status == "TENTATIVE"))
                        {
                            //grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Gainsboro;
                            _noShow++;
                        }
                        //lblCheckIn.Text = _checkIn.ToString();
                        //lblCheckout.Text = _checkOut.ToString();
                        //lblNoShow.Text = _noShow.ToString();
                        //lblOverStay.Text = _overStay.ToString();
                    }
                }
                //loadRooms();
                //txtAmount.Text = _totalAmount.ToString("N");
                ////txtBalance.Text = _totalBalance.ToString("N");

                decimal _totalGrpBalance = 0;
                foreach (SubFolio pSubFolio in loFolio.SubFolios)
                {
                    if (pSubFolio.SubFolio_Renamed == "A")
                    {
                        decimal _totalPayCash = pSubFolio.Ledger.PayCash;
                        decimal _totalPayCHarge = pSubFolio.Ledger.PayCard;
                        decimal _totalPayCheque = pSubFolio.Ledger.PayCheque;
                        decimal _totalPayGiftCheque = pSubFolio.Ledger.PayGiftCheque;
                        decimal _totalBalanceForward = pSubFolio.Ledger.BalanceForwarded;
                        decimal _totalCharges = pSubFolio.Ledger.Charges;

                        _totalGrpBalance += _totalCharges - (_totalPayCash + _totalPayCHarge + _totalPayCheque + _totalPayGiftCheque + _totalBalanceForward);
                    }
                }
                // txtGrpTotal.Text = _totalGrpBalance.ToString("N");
                //   _totalGrpBalance = decimal.Parse(txtAmount.Text) + _totalGrpBalance;
                //txtBalance.Text = _totalGrpBalance.ToString("N");
            }
            catch { }
        }

        #region RECURRING CHARGES

        private void computePackageAmount()
        {
            double _packageAmount = 0;

            foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
            {
                if (_row.Index != 0)
                {
                    DateTime _from = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 11));
                    DateTime _to = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 12));
                    TimeSpan _d = _to.Subtract(_from);
                    int _diff = _d.Days + 1;
                    _packageAmount += (double.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 10)) * Math.Abs(_diff));
                }
            }

            txtPackageAmount.Text = string.Format("{0:###,##0.#0}", _packageAmount);
            getTotalEstimatedCost();
        }

        //>>assigning group's recurring charges
        private IList<RecurringCharge> assignRecurringCharges()
        {
            IList<RecurringCharge> oRecurringChargeCollection = new List<RecurringCharge>();
            try
            {
                foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
                {
                    if (_row.Index != 0)
                    {
                        RecurringCharge oRecurringCharge = new RecurringCharge();

                        oRecurringCharge.FolioID = txtFolioID.Text;
                        oRecurringCharge.RoomID = grdRecurredCharge.GetDataDisplay(_row.Index, 1);
                        oRecurringCharge.QtyHrs = int.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 7));
                        oRecurringCharge.Discount = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 9));
                        oRecurringCharge.BaseAmount = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 6));
                        oRecurringCharge.RateType = grdRecurredCharge.GetDataDisplay(_row.Index, 5);
                        oRecurringCharge.TransactionCode = grdRecurredCharge.GetDataDisplay(_row.Index, 3);
                        oRecurringCharge.Memo = grdRecurredCharge.GetDataDisplay(_row.Index, 4);
                        oRecurringCharge.Amount = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 10));
                        oRecurringCharge.FromDate = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 11));
                        oRecurringCharge.ToDate = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 12));
                        oRecurringCharge.CreatedBy = GlobalVariables.gLoggedOnUser;
                        oRecurringCharge.HotelID = GlobalVariables.gHotelId;
                        oRecurringCharge.Tax = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 8));
                        //oRecurringCharge.SubAccount = grdRecurredCharge.GetDataDisplay(_row.Index, 6);
                        if (grdRecurredCharge.GetCellCheck(_row.Index, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                        {

                            GenericList<EventBookingInfo> _EventBookingInfos = loEventFacade.getEvent(loFolio.FolioID);

                            int _EventPackage = 0;
                            foreach (EventBookingInfo _EventBook in _EventBookingInfos)
                            {
                                _EventPackage = _EventBook.EventPackage;
                            }

                            oRecurringCharge.SummaryFlag = 1;
                            oRecurringCharge.PackageID = _EventPackage;
                        }
                        else
                        {
                            oRecurringCharge.SummaryFlag = 0;
                            oRecurringCharge.PackageID = 0;
                        }
                        oRecurringCharge.RoomID = grdRecurredCharge.GetDataDisplay(_row.Index, 1);

                        //if (oRecurringCharge.Amount > 0)
                        //{
                        oRecurringChargeCollection.Add(oRecurringCharge);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Recurring Charge Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return oRecurringChargeCollection;
        }


        private void loadRecurringCharge()
        {
            grdRecurredCharge.Rows.Count++;
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 1, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 0));
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 2, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 1));
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, lCode);

            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, "0.00");
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, "0.00");


            decimal _amount = getTotalAmount(lCode, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 0), cboRateTypes.Text);
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _amount);

            if (lCode == ConfigVariables.gRoomChargeTransactionCode)
            {
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, lCharge + "/" + gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 2));
                int _noOfHrs = getNoOfHrs(gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 2));
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, _noOfHrs);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, (_amount * _noOfHrs * loTax / 100) + (_amount * _noOfHrs));
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 5, cboRateTypes.Text);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 8, loTax);
            }
            else
            {
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, lCharge);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, "1");
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, (_amount * loTax / 100) + _amount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 8, loTax);
            }
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 9, "0");

            //if (gridFunctionRooms.Rows.Count > 1)
            //{
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 3)));
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 4)));
            ////grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 4)));
            ////grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 5)));
            //}
            //else
            //{
            //    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(GlobalVariables.gAuditDate));
            //    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(GlobalVariables.gAuditDate));
            //}

            //added by genny for additional field:roomID
            //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 0));
            computePackageAmount();
        }

        private int getNoOfHrs(string pTimeRange)
        {
            try
            {
                string[] _splitter = { "-" };
                string[] _times = pTimeRange.Split(_splitter, StringSplitOptions.RemoveEmptyEntries);

                if (_times.Length != 2)
                {
                    throw new Exception();
                }

                DateTime _startTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd ") + _times[0].ToString());
                DateTime _endTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd ") + _times[1].ToString());

                int _noOfHrs = _endTime.Hour - _startTime.Hour;

                if (_endTime.Hour == 0 && _startTime.Hour == 0)
                {
                    _noOfHrs = 24;
                }

                if (_noOfHrs < 0)
                {
                    _noOfHrs *= -1;
                }

                return _noOfHrs;
            }
            catch
            {
                return 1;
            }
        }

        DataTable loTransactionCodes = null;
        DataTable loRateTypes = null;
        decimal loTax = 0;
        private decimal getTotalAmount(string pCode, string pRoom, string pRateCode)
        {
            TransactionCodeFacade _transactionCodeFacade = new TransactionCodeFacade();
            RateTypeFacade _rateTypeFace = new RateTypeFacade();
            DataView _dv = new DataView();

            decimal _amount = 0;

            if (pCode == ConfigVariables.gRoomChargeTransactionCode)
            {
                if (loRateTypes == null)
                {
                    loRateTypes = _rateTypeFace.getRateTypes();
                }
                _dv = loRateTypes.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = "roomID = '" + pRoom + "' and ratecode = '" + pRateCode + "'";

                if (_dv.Count > 0)
                {
                    _amount = decimal.Parse(_dv[0]["rateamount"].ToString());
                }

                //get tax
                if (loTransactionCodes == null)
                {
                    loTransactionCodes = _transactionCodeFacade.getTransactionCodes();
                }
                _dv = loTransactionCodes.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = "tranCode = '" + pCode + "'";
                if (_dv.Count > 0)
                {
                    string tax = _dv[0]["govtTaxInclusive"].ToString();
                    if (tax == "0")
                        loTax = decimal.Parse(_dv[0]["govtTax"].ToString());
                    else
                        loTax = 0;
                }

            }
            else
            {
                if (loTransactionCodes == null)
                {
                    loTransactionCodes = _transactionCodeFacade.getTransactionCodes();
                }
                _dv = loTransactionCodes.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = "tranCode = '" + pCode + "'";

                if (_dv.Count > 0)
                {
                    _amount = decimal.Parse(_dv[0]["defaultAmount"].ToString());
                    string tax = _dv[0]["govtTaxInclusive"].ToString();
                    if (tax == "0")
                        loTax = decimal.Parse(_dv[0]["govtTax"].ToString());
                    else
                        loTax = 0;
                }
            }

            return _amount;
        }

        private void loadFolioRecurringCharges()
        {
            FolioDAO _oFolioDAO = new FolioDAO();
            IList<RecurringCharge> _dt = _oFolioDAO.getFolioRecurringCharges(txtFolioID.Text);
            RecurringCharge _dr;
            grdRecurredCharge.Rows.Count = 1;
            RoomFacade _roomFacade = new RoomFacade();
            Room _oRoom = new Room();
            foreach (RecurringCharge _tempLoopVarDataRow in _dt)
            {
                _dr = _tempLoopVarDataRow;
                grdRecurredCharge.Rows.Count++;

                if (_dr.SummaryFlag == 1)
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, true);
                else
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, false);

                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, _dr.TransactionCode);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, _dr.Memo);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, _dr.Amount.ToString());
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, _dr.FromDate);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, _dr.ToDate);
                //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _dr.SubAccount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 1, _dr.RoomID);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 5, _dr.RateType);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _dr.BaseAmount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, _dr.QtyHrs);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 9, _dr.Discount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 8, _dr.Tax);

                _oRoom = _roomFacade.getRoom(_dr.RoomID);

                try
                {
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 2, _oRoom.RoomDescription);
                }
                catch
                {
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 2, "PACKAGE");
                }
            }
            computePackageAmount();
        }

        private ComboBox lRecurringCombo = new ComboBox();
        private void grdRecurringCharges_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                lCode = grdRecurringCharges.GetDataDisplay(grdRecurringCharges.Row, 0);
                lCharge = grdRecurringCharges.GetDataDisplay(grdRecurringCharges.Row, 1);
            }
            catch (Exception)
            {
            }
        }

        private void grdRecurredCharge_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

            if (e.Col == 11 || e.Col == 12)
            {
                if (DateTime.Parse(grdRecurredCharge.GetDataDisplay(e.Row, e.Col)) < DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    MessageBox.Show("Selected date is less than the current audit date. Please select another date", "Select Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdRecurredCharge.SetData(e.Row, e.Col, DateTime.Parse(GlobalVariables.gAuditDate));
                    return;
                }
                //Kevin L Oliveros
                //if (DateTime.Parse(grdRecurredCharge.GetDataDisplay(e.Row, e.Col)) > dtpTodate.Value)
                //{
                //    MessageBox.Show("Selected date is greater than the event end date. Please select another date", "Select Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    grdRecurredCharge.SetData(e.Row, e.Col, DateTime.Parse(GlobalVariables.gAuditDate));
                //    return;
                //}
            }
            if (e.Col == 5)
            {
                decimal _amount = getTotalAmount(ConfigVariables.gRoomChargeTransactionCode, grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 1), grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 5));
                grdRecurredCharge.SetData(grdRecurredCharge.Row, 6, _amount);
            }

            decimal _total = 0;

            try
            {
                decimal _baseAmount = decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 6).ToString());
                //decimal _tax = _baseAmount * (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 8)) / 100);
                decimal _quantity = decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 7));
                decimal _discount = _baseAmount * _quantity * (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 9)) / 100);
                //_total = (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 6).ToString()) * decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 7))) * ((100 - decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 8))) / 100);

                _total = (_baseAmount * _quantity) - _discount;
                decimal _tax = _total * (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 8)) / 100);
                _total = _total + _tax;
            }
            catch
            {
                _total = 0;
            }

            grdRecurredCharge.SetData(grdRecurredCharge.Row, 10, _total);


            computePackageAmount();
        }

        private void btnAddRecurringCharge_Click(System.Object sender, System.EventArgs e)
        {
            if (lEdit == true || lFlag == "New")
            {
                if (gridPackageRoom.Rows.Count < 2)
                {
                    MessageBox.Show("No schedule has been set for this event!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (lCode != "")
                    {
                        loadRecurringCharge();
                        //lCode = "";

                        //lCharge = "";
                    }
                }

            }
            else
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRemoveRecurringCharge_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                grdRecurredCharge.RemoveItem(grdRecurredCharge.Row);
            }
            catch
            { }

            computePackageAmount();
        }

        private void lvwRecurredCharge_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lvwRecurredChargeMouseUp(sender, e);
        }

        private void lvwRecurredChargeMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point _point = new System.Drawing.Point(e.X, e.Y);
                    lItemIndex = grdRecurredCharge.Row;
                    lTranCode = grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 0);
                    if (lEdit == true)
                    {
                        mnuDeleteCharge.Visible = true;
                    }
                    else
                    {
                        //mnuEdit.Visible = False
                        mnuDeleteCharge.Visible = false;
                    }
                    //mnuEditRate.Visible = True
                    mnulvwCommands.Show(this.grdRecurredCharge, _point);
                }
            }
            catch (Exception)
            {
            }
        }

        private void mnuDeleteCharge_Click(System.Object sender, System.EventArgs e)
        {
            grdRecurredCharge.RemoveItem(grdRecurredCharge.Row);

            FolioFacade _oFolioFacade = new FolioFacade();
            _oFolioFacade.DeleteFolioRecurringCharge(txtFolioID.Text, lTranCode);
        }

        #endregion


     

        #endregion
        #region " CONTROLS "
        private void MarketingUI_Load()
        {
            DisableControls(this, true);
            switch (lGroupFolioStatus)
            {
                case "New":

                    pnlAmendments.Enabled = false;
                    pnlStatus.Visible = false;
                    grpMealDetails.Enabled = false;
                    grpNewAmendments.Enabled = false;
                    break;

                case "Old":
                    //  lEdit = true;
                    loadRoomRequirements();
                    grpNewAmendments.Enabled = false;
                    btnSaveAmmendment.Enabled = false;
                    break;
            }

            KeypressTextboxHandler(this, true);
            this.Top = 0;
            this.Left = 0;

            User _oSalesExecUser = new User();
            UserFacade _oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);

            _oSalesExecUser = _oUserFacade.GetUserRolesAll();

            DataView _dtvSalesExec = _oSalesExecUser.Tables[0].DefaultView;
            _dtvSalesExec.RowStateFilter = DataViewRowState.OriginalRows;
            _dtvSalesExec.RowFilter = "Department like '100%' and rolename like '%MARKETING OFFICERS%'";

            foreach (DataRowView dRow in _dtvSalesExec)
            {
                this.cboSales_Executive.Items.Add(dRow["UserId"].ToString());
            }
            

            //check if Food and Bev Other details are disabled or not
            if (bool.Parse(ConfigVariables.gDisableFoodOtherDetails) == true)
            {
                tblFoodBevOthers.Visible = false;
            }
          //tabFolio_.TabPages.Remove(TabRecurringCharge);

         



        }
        private void loadFolioSchedules()
        {
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            IList<Schedule> _oScheduleList = _oScheduleFacade.getFolioScheduleList(txtFolioID.Text);
            grdSchedules.Rows.Count = 1;

            foreach (Schedule _oSchedule in _oScheduleList)
            {
                grdSchedules.Rows.Count++;
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "room", _oSchedule.RoomID);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "roomTypeCode", _oSchedule.RoomType);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "venueName", _oSchedule.Venue);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "fromDate", _oSchedule.FromDate);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "toDate", _oSchedule.ToDate);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "startTime", _oSchedule.StartTime.ToString("hh:mm tt"));
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "endTime", _oSchedule.EndTime.ToString("hh:mm tt"));
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "rateType", _oSchedule.RateType);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "amount", _oSchedule.Rate);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "setup", _oSchedule.Setup);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "activity", _oSchedule.Activity);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "remarks", _oSchedule.Remarks);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "id", _oSchedule.Id);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "guaranteedPax", _oSchedule.GuaranteedPax);
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "SetUpStart", "2012-12-12 12:00:00");
                grdSchedules.SetData(grdSchedules.Rows.Count - 1, "SetUpEnd", "2012-12-12 12:00:00");
            }
        }

        private void MarketingUI_Load(object sender, System.EventArgs e)
        {
            lIsEventManagementDisabled = bool.Parse(ConfigVariables.gIsEventManagementDisabled);

            MarketingUI_Load();

            //if (!isReinstated)
            //    loadEvent();

            if (loFolio.Status == "CANCELLED" || loFolio.Status == "NO SHOW" || loFolio.Status == "CLOSED")
            {
                disableControls(this);
                //btnFolio.Enabled = true;
                btnClose.Enabled = true;
                btnPrintContract.Enabled = true;
                if (loFolio.Status == "CANCELLED" || loFolio.Status == "NO SHOW")
                    btnreinstate.Enabled = true;
            }
            else
            {
                setButtons();
            }

            if (groupBox13.ContainsFocus == false)
            {
                this.txtGroupName.Focus();
                this.txtGroupName.Select();
            }

            //jlo 8-27-10 hide cancellation
            if (loFolio.Status != "CANCELLED")
            {

            }
            else
            {

                setButtons();
            }
            //jlo
             CheckUserRoles();
           
            //this.btnPrintContract.Text = Translator.getTranslation(this.btnPrintContract.Text);
            this.btnBookingSheet.Text = Translator.getTranslation(this.btnBookingSheet.Text);

            //jlo 6-10-10 emm only config
            if (ConfigVariables.gIsEMMOnly == "true")
            {
                this.label15.Visible = false;
                this.txtAccount_Type.Visible = false;
                this.label36.Visible = false;
                this.txtTHRESHOLD_VALUE.Visible = false;

            }
            label105.Left = label34.Left;
            label105.Top = label34.Top + label34.Height + 10;
            // Relocate txtEventDate
            txtEventDate.Left = txtCreateTime.Left;
            txtEventDate.Top = txtCreateTime.Top + txtCreateTime.Height + 6;
            User _oSalesExecUser = new User();
            UserFacade _oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);

            // Users list
            loUserList = _oUserFacade.getUsersTable();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
       {
            this.Close();
       }
        public void disableControls(Control pControl)
        {
            foreach (Control _ctrl in pControl.Controls)
            {
                if (_ctrl is TabControl || _ctrl is Panel || _ctrl is GroupBox || _ctrl is TabPage)
                {
                    _ctrl.Enabled = true;
                    disableControls(_ctrl);
                }
                else if (_ctrl is Button)
                {
                    _ctrl.Enabled = false;
                }
            }
        }


        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {

            //jc 9.25.09
            MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                if (!string.IsNullOrEmpty(loFolio.FolioID))
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oTrans);           //jc 9.25.09
                }
                btnSave_Click();
                //jc 9.25.09
                //edited
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in saving folio.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _oTrans.Commit(); //jc 9.5.09
            }

        }
     
        private void gridEventOfficer_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    if (_canAddEventOfficer)
                    {
                        this.mnuAddEventOfficer.Enabled = true;
                        this.mnuRemoveEventOfficer.Enabled = true;
                    }
                    else
                    {
                        this.mnuAddEventOfficer.Enabled = false;
                        this.mnuRemoveEventOfficer.Enabled = false;
                    }
                    mnuEventOfficers.Show(this.gridEventOfficer, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void mnuAddEventOfficer_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = gridEventOfficer.Rows.Count;
            gridEventOfficer.Rows.Count++;

            this.gridEventOfficer.SetData(i, 0, "");
            this.gridEventOfficer.SetData(i, 1, "");
            this.gridEventOfficer.SetData(i, 2, "");
            this.gridEventOfficer.SetData(i, 3, "");
        }

        private void mnuRemoveEventOfficer_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridEventOfficer.Rows.Remove(this.gridEventOfficer.Row);
            }
            catch { }
        }

        private void rdbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIndividual.Checked == true)
            {
                pnlIndividual.BringToFront();
            }
        }

        private void rdbCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (lEdit == true)
            {
                if (rdbCompany.Checked)
                {
                    pnlIndividual.Visible = false;
                    pnlIndividual.SendToBack();

                    pnlCompany.Visible = true;
                    pnlCompany.BringToFront();
                    txtcompanyid.Text = "";
                    txtLastName.Text = "";
                    txtFirstName.Text = "";
                    txtCompanyName.Focus();
                    //cboAccountType.Text = "CORPORATE";
                    //cboPurpose.Text = "BUSINESS";

                    //foreach (Control _ctrl in grpInfo.Controls)
                    //{
                    //    if (_ctrl is TextBox)
                    //    {
                    //        _ctrl.Text = "";
                    //    }
                    //}

                    //lvwGuestPrivileges.Items.Clear();
                    //grdFolioPrivileges.Rows.Count = 1;
                    //rdoApplyGuestPrivilege.Checked = false;
                    //rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && !loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get company privileges
                    //rdoApplyCompanyPrivileges.Checked = true;
                }
                else
                {
                    pnlCompany.Visible = false;
                    pnlCompany.SendToBack();

                    pnlIndividual.Visible = true;
                    pnlIndividual.BringToFront();
                    txtcompanyid.Text = "";
                    txtCompanyName.Text = "";
                    txtLastName.Focus();
                    //cboAccountType.Text = "PERSONAL";
                    //cboPurpose.Text = "PARTY";

                    //foreach (Control _ctrl in grpInfo.Controls)
                    //{
                    //    if (_ctrl is TextBox)
                    //    {
                    //        _ctrl.Text = "";
                    //    }
                    //}

                    //lvwCompanyPrivileges.Items.Clear();
                    //grdFolioPrivileges.Rows.Count = 1;
                    //rdoApplyGuestPrivilege.Checked = false;
                    //rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get guest privileges
                    //rdoApplyGuestPrivilege.Checked = true;
                }
            }
            else
            {
                if (rdbCompany.Checked)
                {
                    pnlIndividual.Visible = false;
                    pnlIndividual.SendToBack();

                    pnlCompany.Visible = true;
                    pnlCompany.BringToFront();
                    txtcompanyid.Text = "";
                    txtLastName.Text = "";
                    txtFirstName.Text = "";
                    txtCompanyName.Focus();
                    //cboAccountType.Text = "CORPORATE";
                    //cboPurpose.Text = "BUSINESS";

                    //foreach (Control _ctrl in grpInfo.Controls)
                    //{
                    //    if (_ctrl is TextBox)
                    //    {
                    //        _ctrl.Text = "";
                    //    }
                    //}

                    //lvwGuestPrivileges.Items.Clear();
                    //grdFolioPrivileges.Rows.Count = 1;
                    //rdoApplyGuestPrivilege.Checked = false;
                    //rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && !loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get company privileges
                    //rdoApplyCompanyPrivileges.Checked = true;
                }
                else
                {
                    pnlCompany.Visible = false;
                    pnlCompany.SendToBack();

                    pnlIndividual.Visible = true;
                    pnlIndividual.BringToFront();
                    txtcompanyid.Text = "";
                    txtCompanyName.Text = "";
                    txtLastName.Focus();
                    //cboAccountType.Text = "PERSONAL";
                    //cboPurpose.Text = "PARTY";

                    //foreach (Control _ctrl in grpInfo.Controls)
                    //{
                    //    if (_ctrl is TextBox)
                    //    {
                    //        _ctrl.Text = "";
                    //    }
                    //}

                    //lvwCompanyPrivileges.Items.Clear();
                    //grdFolioPrivileges.Rows.Count = 1;
                    //rdoApplyGuestPrivilege.Checked = false;
                    //rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get guest privileges
                    //rdoApplyGuestPrivilege.Checked = true;
                }
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtLastName.Text.Trim().Length <= 0)
            {
                this.lvwBrowseGuestName.Visible = false;
                dtView = null;
                return;
            }
            else if (this.txtLastName.Text.Trim().Length > 0 && txtLastName.Focused == true)
            {
                loadList(GlobalFunctions.removeQuotes(this.txtLastName.Text), "");
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            getGuest();
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwBrowseGuestName.Visible)
                {
                    this.lvwBrowseGuestName.Select();
                }
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                getGuest();
            }
        }

        private void txtFirstName_Leave_1(object sender, EventArgs e)
        {
            getGuest();
        }

        private void txtCreateTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlCompany_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFirstName.Text.Trim().Length <= 0)
            {
                this.lvwBrowseGuestName.Visible = false;
                dtView = null;
                return;
            }
            else if (this.txtFirstName.Text.Trim().Length > 0 && txtFirstName.Focused == true)
            {
                loadList(GlobalFunctions.removeQuotes(this.txtLastName.Text), GlobalFunctions.removeQuotes(this.txtFirstName.Text));
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            getGuest();
        }

        private void pnlIndividual_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcompanyid_TextChanged(object sender, EventArgs e)
        {
            txtCompanyId_TextChanged();

        }
        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwBrowseGuestName.Visible)
                {
                    this.lvwBrowseGuestName.Select();
                }
            }
        }

        private void lvwBrowseGuestName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                lvwBrowseGuestName_DoubleClick(sender, new EventArgs());
            }
            else if (e.KeyChar == System.Convert.ToChar(Keys.Escape))
            {
                this.lvwBrowseGuestName.Visible = false;
            }
        }

        private void lvwBrowseGuestName_Leave(object sender, EventArgs e)
        {
            //  this.cboAccountType.Focus();
        }

        private void lvwBrowseGuestName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string accountId = this.lvwBrowseGuestName.SelectedItems[0].Text;

                if (accountId.Trim().Length > 0)
                {

                    this.txtcompanyid.Text = accountId;
                    this.lvwBrowseGuestName.Visible = false;
                }
            }
            catch { }
        }

        private void lvwMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvwMenus.Items.Count > 0)
            {
                this.btnAddMenu.Enabled = true;
            }
            else
            {
                this.btnAddMenu.Enabled = false;
            }
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            lvwMenus_DoubleClick(sender, e);
        }

        private void lvwMenus_DoubleClick(object sender, EventArgs e)
        {
            decimal _totalPrice = 0;
            try
            {
                MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
                GenericList<MealMenu> _oMealMenuItemList = new GenericList<MealMenu>();
                _oMealMenuItemList = _oMealMenuItemFacade.getMealItemsForMenu(lvwMenus.SelectedItems[0].SubItems[1].Text);
                if (_oMealMenuItemList.Count > 0)
                {
                    txtTotalMealAmount.Value = 0;
                    foreach (MealMenu _oMealMenuItems in _oMealMenuItemList)
                    {
                        string[] items ={ _oMealMenuItems.MenuID.ToString(), _oMealMenuItems.MealMenuItemID.ToString(), _oMealMenuItems.Description };
                        gridMealItems.AddItem(items);
                    }
                    _totalPrice += decimal.Parse(lvwMenus.SelectedItems[0].SubItems[2].Text);
                }
                else
                {
                    string[] items ={ "", lvwMenus.SelectedItems[0].SubItems[1].Text, lvwMenus.SelectedItems[0].Text };
                    gridMealItems.AddItem(items);
                    //_totalPrice += decimal.Parse(lvwMenus.SelectedItems[0].SubItems[2].Text);
                }
            }
            catch
            {
                MessageBox.Show("Please select an item on the list.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lvwMenus.Focus();
            }

            nudPaxAmt.Value = _totalPrice;
            txtTotalMealAmount.Value = nudPaxAmt.Value * nudMealPax.Value;

            //to check amount
            //nudMealLiveIn.Value += 1;
            //nudMealLiveIn.Value -= 1;
        }

        private void gridMealItems_RowColChange(object sender, EventArgs e)
        {
            int _row = this.gridMealItems.Row;

            if (_row < 0)
            {
                this.btnRemoveMenu.Enabled = false;
                return;
            }

            this.btnRemoveMenu.Enabled = true;
        }

        private void gridMealItems_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.ToString() == "Delete")
                {
                    gridMealItems.RemoveItem(gridMealItems.Row);
                }
            }
            catch { }
        }



        
        private void tabFolio__SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabFolio_.SelectedTab == tabFoodBev_ && !isReinstated)
                {
                    //addMeallDates();
                }
                if (tabFolio_.SelectedTab == TabRecurringCharge)
                {
                    grdRecurringCharges.Row = 2;
                    grdRecurringCharges.Row = 1;
                    GroupBookingDropDownFacade _groupBookingDropDownFacade = new GroupBookingDropDownFacade();
                    cboDiscount.DataSource = _groupBookingDropDownFacade.getGroupBooking("Discount");
                    cboDiscount.DisplayMember = "Value";

                    RateCodeFacade _rateCodeFacade = new RateCodeFacade();
                    cboRateTypes.DataSource = _rateCodeFacade.getRateCodes();
                    cboRateTypes.DisplayMember = "ratecode";
                    grdRecurredCharge.Cols[5].Editor = cboRateTypes;
                }
            }
            catch
            {
                
             
            }

        }

        private void btnRemoveMenu_Click(object sender, EventArgs e)
        {
            int _row = this.gridMealItems.Row;
            if (_row < 0)
                return;

            this.gridMealItems.RemoveItem(_row);
        }

        private void btnNewMeal_Click(object sender, EventArgs e)
        {
            clearMeals();
            loadMenuItems();
            grpMealDetails.Enabled = true;
            loSequence = new Sequence();
            string mealID = loSequence.getSequenceId("", 5, "seq_mealid");
            cboMealType.Tag = mealID;
            btnSaveMeal.Enabled = true;
            newMeal = true;
            cboMealType.Enabled = true;
        }

        private bool _isNewMeal = false;
        //to add another date in the meals reservation
        private void btnAddDate_Click(object sender, EventArgs e)
        {
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 

            pnlDate.Visible = true;
            pnlDate.BringToFront();
            clearMeals();
            _isNewMeal = true;

        }

        private void btnAddDateOK_Click(object sender, EventArgs e)
        {
            treeFoodBev.Nodes.Add(dtpAddDate.Value.ToShortDateString());
            pnlDate.Visible = false;
        }

        private void btnAddDateCancel_Click(object sender, EventArgs e)
        {
            pnlDate.Visible = false;
        }
        private void btnSaveMeal_Click(object sender, EventArgs e)
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 

            //if (cboMealType.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please select meal type.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    tabFolio_.TabPages["tabFoodBev_"].Select();
            //    this.cboMealType.Focus();
            //    return;
            //}

            //if (txtStartMealTime.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please input ready time.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    tabFolio_.TabPages["tabFoodBev_"].Select();
            //    this.txtStartMealTime.Focus();
            //    return;
            //}

            //if (txtEndMealTime.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please input deliver time.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    tabFolio_.TabPages["tabFoodBev_"].Select();
            //    this.txtEndMealTime.Focus();
            //    return;
            //}

            //if (nudMealPax.Value <= 0)
            //{
            //    MessageBox.Show("Number of pax should be greater than 0", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    tabFolio_.TabPages["tabFoodBev_"].Select();
            //    this.nudMealPax.Focus();
            //    return;
            //}

            if (gridNewMeal.Rows.Count <= 1)//gridMealItems.Rows.Count <= 1)
            {
                MessageBox.Show("Meals should have at least one meal item.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            for(int i = 1;i<gridNewMeal.Rows.Count;i++)
            {
              

                if (gridNewMeal.GetDataDisplay(i,"typeOfMeal").ToString()=="")
                {

                    MessageBox.Show("Please select meal type at row#"+i, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                    return;
                }
                if (gridNewMeal.GetDataDisplay(i, "noOfPax").ToString() == "" || int.Parse(gridNewMeal.GetDataDisplay(i, "noOfPax").ToString()) < 1)
                {
                    MessageBox.Show("Number of pax should be greater than 0 at row#" + i, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                    return;
                }

                if (gridNewMeal.GetDataDisplay(i, "date").ToString() == "")
                {
                    MessageBox.Show("Please select valid date at row#"+i, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                    return;
                }
            }

            if (saveGridMeals())
            {
                MessageBox.Show("Transaction successful. " + "\r\n" + "Meal Requirements has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Text = "Marketing";

            clearMeals();
            
            getTotalEstimatedCost();

            saveBookingInfo(ref _oTransaction);
            cboMealType.Enabled = false;
            loadFoodRequirements();
            getRequirementsSchedules();
            _oTransaction.Commit();
        }

        private void btnPrintSystemChanges_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getSystemChanges(txtFolioID.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        }

        private void btnPrintAmmendments_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getContractAmendments(txtFolioID.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        }

        private void btnNewAmmendment_Click(object sender, EventArgs e)
        {
            if (btnNewAmmendment.Text.ToUpper().Trim() == "NEW")
            {
                btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.close16;
                grpNewAmendments.Enabled = true;
                this.btnNewAmmendment.Text = "    Cancel";
                pnlNew.Enabled = false;
                pnlStatus.Enabled = false;
                pnlFolio.Enabled = false;
                btnPrintAmmendments.Enabled = false;
                btnSaveAmmendment.Enabled = true;
                txtAmendmentNo.Text = "TO BE AMENDED";
            }
            else
            {
                btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.add16;
                grpNewAmendments.Enabled = false;
                pnlNew.Enabled = true;
                pnlStatus.Enabled = true;
                pnlFolio.Enabled = true;
                btnPrintAmmendments.Enabled = true;
                this.btnNewAmmendment.Text = "    New";
                btnSaveAmmendment.Enabled = false;

                //clear text
                txtAmendmentNo.Text = "";
                txtOldValue.Text = "";
                txtNewValue.Text = "";
            }
        }

        private void btnSaveAmmendment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this contract amendment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ContractAmendments _oAmendment = new ContractAmendments();
                ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();

                _oAmendment.AmendmentID = txtAmendmentNo.Text;
                _oAmendment.FolioID = txtFolioID.Text;
                _oAmendment.NewValue = txtNewValue.Text;
                _oAmendment.OldValue = txtOldValue.Text;
                _oAmendmentFacade.saveAmendment(ref _oAmendment);

                //add to grid amendments
                grdAmmendments.Rows.Count++;
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 0, _oAmendment.AmendmentID);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 1, _oAmendment.OldValue);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 2, _oAmendment.NewValue);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 3, _oAmendment.ID);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 4, GlobalVariables.gLoggedOnUser);

                //disable/enable controls
                grpNewAmendments.Enabled = false;
                pnlNew.Enabled = true;
                pnlStatus.Enabled = true;
                pnlFolio.Enabled = true;
                btnPrintAmmendments.Enabled = true;
                this.btnNewAmmendment.Text = "    New";
                btnSaveAmmendment.Enabled = false;

                //clear text
                txtAmendmentNo.Text = "";
                txtOldValue.Text = "";
                txtNewValue.Text = "";

                //sort by amendment id ascending
                grdAmmendments.Sort(SortFlags.Ascending, 0);
                grdAmmendments.AutoSizeRows();

                btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.add16;
            }
            else
            {
                return;
            }
        }

        private void grdAmmendments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().ToUpper() == "DELETE" && grdAmmendments.GetDataDisplay(grdAmmendments.Row, 0) == "TO BE AMENDED")
            {
                if (MessageBox.Show("Are you sure you want to delete this amendment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();
                    string pID = grdAmmendments.GetDataDisplay(grdAmmendments.Row, 3);
                    if (_oAmendmentFacade.deleteAmendment(pID) == true)
                    {
                        grdAmmendments.RemoveItem(grdAmmendments.Row);
                        MessageBox.Show("Successfully deleted.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void mnuAddEMDAction_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = gridEMDActions.Rows.Count;
            gridEMDActions.Rows.Count++;

            this.gridEMDActions.SetData(i, 0, "");
        }

        private void mnuRemoveEMDAction_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridEMDActions.Rows.Remove(this.gridEMDActions.Row);
            }
            catch { }
        }

        private void gridEMDActions_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuAddEMDAction.Enabled = true;
                    this.mnuRemoveEMDAction.Enabled = true;
                    mnuEMDActions.Show(this.gridEMDActions, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridReqSchedules_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                gridReqSchedules.Cols[0].AllowEditing = false;
                DateTime _startDate = DateTime.Parse(gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 2).ToString());
                DateTime _endDate = DateTime.Parse(gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 3).ToString());
                setReqDateDropDown(_startDate, _endDate);
                gridReqSchedules.Cols[1].Editor = lcboReqDates;
            }
            catch
            {
            }
        }

        private void txtContractAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtContractAmount.Value > 0)
                {
                    decimal percent25 = txtContractAmount.Value / 4;
                    this.txt25RF1.Text = string.Format("{0:###,##0.#0}", percent25);
                    this.txt50RF.Text = string.Format("{0:###,##0.#0}", (percent25 * 2));
                    this.txt25RF2.Text = string.Format("{0:###,##0.#0}", (txtContractAmount.Value - decimal.Parse(txt25RF1.Text) - decimal.Parse(txt50RF.Text)));
                    this.txtBalanceRF.Text = string.Format("{0:###,##0.#0}", (txtContractAmount.Value - lTotalPayment));
                }
                else if (txtContractAmount.Value == 0)
                {
                    this.txt25RF1.Text = "0";
                    this.txt50RF.Text = "0";
                    this.txt25RF2.Text = "0";
                    this.txtBalanceRF.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : contract amount should be a valid value\r\n" + ex.Message);
                tabFolio_.TabPages["tabEndorsement"].Select();
                this.txtContractAmount.Focus();
            }
        }
        private void btnAddRequirements_Click(object sender, EventArgs e)
        {
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (cboRequirementType.Text.ToUpper().Contains("EVENT OFFICER") && _canAddEventOfficer == false)
            {
                MessageBox.Show("Sorry! You are not allowed to add Event Officers.\nPlease contact system administrator.\n\nThank you!", "Add Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboRequirementType.Text = "";
                txtRequirementNote.Text = "";
                return;
            }

            string _roomID = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 0);
            string _date = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 1);
            //string _toDate = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 2);
            //string _startTime = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 3);
            //string _endTime = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 4);
            string _schedule = _roomID + " : " + _date;

            if (txtRequirementNote.Text == "")
            {
                if (cboRequirementType.Text != "")
                {
                    //TreeNode _node = new TreeNode(cboRequirementType.Text);
                    TreeNode _parentNode = new TreeNode(_schedule);
                    TreeNode _childNode = new TreeNode(cboRequirementType.Text);
                    bool _isChecked = false;
                    foreach (ListViewItem _listViewItem in lvwDetails.Items)
                    {
                        if (checkIfRequirementIsAdded(_schedule, cboRequirementType.Text, _listViewItem.SubItems[0].Text) == false)
                        {
                            if (_listViewItem.Checked == true)
                            {
                                _childNode.Nodes.Add(_listViewItem.SubItems[0].Text);
                                _isChecked = _isChecked || true;
                            }
                            else
                            {
                                _isChecked = _isChecked || false;
                            }
                        }
                    }

                    if (_isChecked == true)
                    {
                        _parentNode.Nodes.Add(_childNode);
                        treeRequirements.Nodes.Add(_parentNode);
                        treeRequirements.ExpandAll();
                    }
                }
            }
            else
            {
                if (cboRequirementType.Text != "")
                {
                    if (checkIfRequirementIsAdded(_schedule, cboRequirementType.Text, txtRequirementNote.Text) == false)
                    {
                        TreeNode _parentNode = new TreeNode(_schedule); //TreeNode(cboRequirementType.Text);
                        TreeNode _childNode = new TreeNode(cboRequirementType.Text);
                        _childNode.Nodes.Add(txtRequirementNote.Text);
                        _parentNode.Nodes.Add(_childNode);
                        treeRequirements.Nodes.Add(_parentNode);
                        treeRequirements.ExpandAll();

                        txtRequirementNote.Text = "";
                    }
                }
            }

        }

        private void btnRemoveRequirements_Click(object sender, EventArgs e)
        {
            try
            {
                treeRequirements.SelectedNode.Remove();
                this.Text = "Marketing";
            }
            catch { }


        }

        private void cboRequirementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRequirementType.SelectedValue.ToString() != "")
            {
                lvwDetails.Items.Clear();
                RequirementCodeFacade _oRequirementCodeFacade = new RequirementCodeFacade();
                GenericList<RequirementCode> _oRequirementCodeList = new GenericList<RequirementCode>();
                _oRequirementCodeList = _oRequirementCodeFacade.getDetailsForRequirements(cboRequirementType.SelectedValue.ToString());
                foreach (RequirementCode _oRequirementCode in _oRequirementCodeList)
                {
                    lvwDetails.Items.Add(_oRequirementCode.Description);
                }
                lvwDetails.LabelEdit = true;
            }
            txtRequirementNote.Text = "";
        }

        private void cboRequirementType_DropDownClosed(object sender, EventArgs e)
        {
            if (cboRequirementType.Text.ToUpper().Contains("EVENT OFFICER") && _canAddEventOfficer == false)
            {
                MessageBox.Show("Sorry! You are not allowed to add Event Officers.\nPlease contact system administrator.\n\nThank you!", "Add Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboRequirementType.Text = "";
                txtRequirementNote.Text = "";
            }
        }



        private void btnExport_Click(object sender, EventArgs e)
        {

            if (loFolio != null)
            {
                string strFileName = "LOP - " + txtGroupName.Text;

                sfdExport.Filter = "Word Files (*.doc)|*.doc|Excel Files (*.xls)|*.xls|PDF Files (*.pdf)|*.pdf";
                sfdExport.FileName = strFileName;
                DialogResult _result = sfdExport.ShowDialog();

                if (_result == DialogResult.OK)
                {
                    DataTable _dt = new DataTable();
                    _dt.Columns.Add("individual");
                    _dt.Columns.Add("designation");
                    _dt.Columns.Add("company");
                    _dt.Columns.Add("address1");
                    _dt.Columns.Add("address2");
                    _dt.Columns.Add("telephone");
                    _dt.Columns.Add("email");
                    _dt.Columns.Add("dear");
                    _dt.Columns.Add("event");
                    _dt.Columns.Add("wordamount");
                    _dt.Columns.Add("contractamount");
                    _dt.Columns.Add("50%Date");
                    _dt.Columns.Add("lastDate");
                    _dt.Columns.Add("conforme");

                    DataRow _dRow = _dt.NewRow();
                    if (loFolio.CompanyID.StartsWith("G-"))
                    {
                        Company _company = loCompanyFacade.getCompanyAccount(txtcompanyid.Text);

                        _dRow["company"] = _company.CompanyName;
                        EventContact _decisionmaker = getDecisionMaker();
                        _dRow["address1"] = _company.Street1 + ", " + _company.City1;
                        _dRow["address2"] = _company.Country1 + " " + _company.Zip1;
                        _dRow["telephone"] = _company.ContactNumber1;
                        _dRow["email"] = _company.Email1;

                        if (_decisionmaker != null)
                        {
                            _dRow["individual"] = "MR./MS. " + _decisionmaker.FirstName + " " + _decisionmaker.LastName;
                            _dRow["designation"] = _decisionmaker.Designation;
                            _dRow["conforme"] = _decisionmaker.FirstName + " " + _decisionmaker.LastName;
                            _dRow["dear"] = "MR./MS. " + _decisionmaker.LastName;
                        }
                        else
                        {
                            _dRow["individual"] = "";
                            _dRow["designation"] = "";
                            _dRow["conforme"] = "";
                            _dRow["dear"] = "";
                        }
                    }
                    else
                    {
                        Guest _guest = loGuestFacade.getGuestRecord(txtcompanyid.Text);
                        _dRow["individual"] = "MR./MS. " + _guest.FirstName + " " + _guest.LastName;
                        _dRow["designation"] = "Organizer";
                        EventContact _decisionmaker = getDecisionMaker();
                        if (_decisionmaker != null)
                        {
                            _dRow["company"] = "MR./MS. " + _decisionmaker.FirstName + " " + _decisionmaker.LastName;
                            _dRow["address1"] = "Decision Maker";
                            _dRow["address2"] = _decisionmaker.Address;
                            _dRow["telephone"] = _decisionmaker.TelNo;
                            _dRow["email"] = _decisionmaker.Email;
                            _dRow["conforme"] = _guest.FirstName + " " + _guest.LastName;
                            _dRow["dear"] = "MR./MS. " + _guest.LastName;
                        }
                        else
                        {
                            _dRow["company"] = "";
                            _dRow["address1"] = "";
                            _dRow["address2"] = "";
                            _dRow["telephone"] = "";
                            _dRow["email"] = "";
                            _dRow["conforme"] = "";
                            _dRow["dear"] = "";
                        }
                    }

                    _dRow["event"] = loFolio.GroupName;
                    decimal _25 = loFolio.EventEndorsement.ContractAmount / 4;
                    string _numbertoword = string.Format("{0:######0.#0}", _25.ToString());
                    string _cents = "";
                    if (_numbertoword.Contains("."))
                    {
                        string[] _numSplit = _numbertoword.Split('.');
                        _numbertoword = _numSplit[0];
                        _cents = " and " + _numSplit[1] + "/" + "100";
                    }
                    _dRow["wordamount"] = NumberToText(int.Parse(_numbertoword)) + _cents + " PESOS";
                    _dRow["contractamount"] = string.Format("{0:###,##0.#0}", _25);
                    _dRow["50%Date"] = string.Format("{0:MMMM dd, yyyy (dddd)}", loFolio.EventEndorsement.DueDate2);
                    _dRow["lastDate"] = string.Format("{0:MMMM dd, yyyy (dddd)}", loFolio.EventEndorsement.DueDate3);

                    _dt.Rows.Add(_dRow);

                    string _organizerID = "";
                    string _organizerName = "";
                    Company _oCompany;
                    Guest _oGuest;
                    if (loFolio.CompanyID.StartsWith("G-"))
                    {
                    //    isCompany = true;
                        CompanyFacade _oCompanyFacade = new CompanyFacade();
                        _oCompany = _oCompanyFacade.getCompanyAccount(loFolio.CompanyID);
                        _organizerID = _oCompany.CompanyId;
                        _organizerName = _oCompany.CompanyName;
                    }
                    else
                    {
                   //     isCompany = false;
                        GuestFacade _oGuestFacade = new GuestFacade();
                        _oGuest = _oGuestFacade.getGuestRecord(loFolio.CompanyID);
                        _organizerID = _oGuest.AccountId;
                        _organizerName = _oGuest.AccountName;
                    }


                    ReportFacade _rptFacade = new ReportFacade();
                    if (_rptFacade.exportLetterOfProposal(sfdExport.FileName, loFolio.FolioID, _dt,_organizerID,_organizerName))
                    {
                        MessageBox.Show("Export successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Event is still not saved.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      

        private static string[] GetFileNames(string pPath, string pFilter)
        {
            string[] _files = Directory.GetFiles(pPath, "*"+pFilter+"*");
            for (int i = 0; i < _files.Length; i++)
                _files[i] = Path.GetFileName(_files[i]);
            return _files;
        }


        private void btnUploadLOP_Click(object sender, EventArgs e)
        {
            //Kevin Oliveros
            if (loFolio != null)
            {
                //string strFileName = "LOP - " + txtGroupName.Text;
                ofdUpload.Filter = "Word Files (*.doc)|*.doc|Excel Files (*.xls)|*.xls|PDF Files (*.pdf)|*.pdf";
                ofdUpload.FileName = "";
                DialogResult _result = ofdUpload.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    try
                    {
                        string _ext = Path.GetExtension(ofdUpload.FileName);
                        string _fileName = getDestFileName(ConfigVariables.gServerUploadPath.Replace("\\\\","\\"), loFolio.FolioID,_ext);
                     // File.Copy(ofdUpload.FileName, ConfigVariables.gServerUploadPath + loFolio.FolioID + "" + ofdUpload.Filter, true);
                        File.Copy(ofdUpload.FileName, _fileName, false);
                        MessageBox.Show("Upload successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem uploading the document!\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public string getDestFileName(string pServerPath,string pFileName,string pExt)
        {
            string _lFileName = "";
            int _cnt = 0;
            while(true)
            {
                _lFileName = pServerPath + "\\" + pFileName + " LOP " + DateTime.Now.ToString("yyy-dd-MM") + " " + "[" + _cnt + "]" + pExt;
                 if (System.IO.File.Exists(_lFileName)) 
                 {
                     _cnt++;
                     continue;
                 }
                 return _lFileName;
            }
        }

  
        

        private void btnViewLOP_Click(object sender, EventArgs e)
        {
            // Try catch added by Gene - 9/1/2011
            try
            {
                if (loFolio != null)
                {

                    // string _file = ConfigVariables.gServerUploadPath + loFolio.FolioID + ".doc";
                    //_file = _file.Replace("\\\\", "\\");
                    string _path  =ConfigVariables.gServerUploadPath.Replace("\\\\","\\");
                    string[] _files  = GetFileNames(_path,loFolio.FolioID+" LOP");

                    string _file = ConfigVariables.gServerUploadPath.Replace("\\\\", "\\") + "\\" + _files[_files.Length - 1];
                    Process.Start(_file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem viewing the LOP.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void treeFoodBev_Click(object sender, EventArgs e)
        {

        }
        private bool newMeal = false;
        private void clearMeals()
        {
           // lblPaxAmt.Visible = true;
          //  nudPaxAmt.Visible = true;

            nudMealPax.Value = 0;
            nudMealLiveIn.Value = 0;
            nudMealLiveOut.Value = 0;
            txtTotalMealAmount.Value = 0;
            nudPaxAmt.Value = 0;
            txtVenueFood.Text = "";
            txtFoodRemarks.Text = "";
            txtFoodSetup.Text = "";
            txtFoodOver.Text = "";
            gridMealItems.Rows.Count = 1;
            cboMealType.Text = "";
            cboMealType.Enabled = false;
        }

        private void treeFoodBev_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblPaxAmt.Visible = true;
            nudPaxAmt.Visible = true;
            EventFoodRequirementsFacade _oEventFoodRequirementsFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();

            if (treeFoodBev.Nodes.Count > 0)
            {
                btnNewMeal.Enabled = true;
                btnSaveMeal.Enabled = true;

                //>>_oMealMenu header
                if (treeFoodBev.SelectedNode.Parent != null && treeFoodBev.SelectedNode.Parent.Text != treeFoodBev.SelectedNode.Text)
                {
                    clearMeals();
                    _oEventFoodRequirementsList = _oEventFoodRequirementsFacade.getFoodRequirement(DateTime.Parse(treeFoodBev.SelectedNode.Parent.Text), txtFolioID.Text);
                    foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
                    {
                        if (_oEventFoodRequirements.MealType == treeFoodBev.SelectedNode.Text)
                        {
                            cboMealType.Enabled = true;
                            dtpFoodDate.Text = _oEventFoodRequirements.EventDate.ToShortDateString();

                            txtStartMealTime.Value = DateTime.Parse(_oEventFoodRequirements.StartTime);
                            txtEndMealTime.Value = DateTime.Parse(_oEventFoodRequirements.EndTime);
                            txtVenueFood.Text = _oEventFoodRequirements.Venue;
                            txtFoodSetup.Text = _oEventFoodRequirements.Setup;
                            txtFoodRemarks.Text = _oEventFoodRequirements.Remarks;
                            txtFoodOver.Text = _oEventFoodRequirements.Over;

                            cboMealType.Text = _oEventFoodRequirements.MealType;
                            cboMealType.Tag = _oEventFoodRequirements.MealID.ToString();

                            nudMealPax.Value = decimal.Parse(_oEventFoodRequirements.Pax.ToString());
                            nudMealLiveOut.Value = decimal.Parse(_oEventFoodRequirements.PaxLiveOut.ToString());
                            nudMealLiveIn.Value = decimal.Parse(_oEventFoodRequirements.PaxLiveIn.ToString());
                            nudPaxAmt.Value = _oEventFoodRequirements.TotalMealCost / nudMealPax.Value;
                            txtTotalMealAmount.Value = _oEventFoodRequirements.TotalMealCost;

                            break;
                        }
                    }//end foreach

                    //>>_oMealMenu details
                    _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();
                    _oEventFoodRequirementsList = _oEventFoodRequirementsFacade.getMealDetails(cboMealType.Tag.ToString(), DateTime.Parse(treeFoodBev.SelectedNode.Parent.Text), txtFolioID.Text);
                    foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
                    {
                        string[] items ={ _oEventFoodRequirements.MenuCode, _oEventFoodRequirements.MenuItemCode, _oEventFoodRequirements.Description, _oEventFoodRequirements.Remarks };
                        gridMealItems.AddItem(items);
                    }//end foreach

                }//end if 

                else
                {
                    try
                    {
                        this.dtpFoodDate.Value = DateTime.Parse(treeFoodBev.SelectedNode.Text);
                        clearMeals();
                    }
                    catch { }
                }//end if else
            }//end if treefoodbev.nodes.count

            else
            {
                btnNewMeal.Enabled = false;
                btnSaveMeal.Enabled = false;
            }
            newMeal = false;
        }
        private void cboMealType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (newMeal)
            {
                EventFoodRequirementsFacade _oEventFoodRequirementFacade = new EventFoodRequirementsFacade();
                bool _isNew = _oEventFoodRequirementFacade.mealHeaderExists(cboMealType.Text, dtpFoodDate.Value, txtFolioID.Text);
                if (_isNew)
                {
                    MessageBox.Show("Meal type already exists for the day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboMealType.Text = " ";
                }
            }

            //to check total amount
            //nudMealLiveIn.Value += 1;
            //nudMealLiveIn.Value -= 1;
        }

        private void btnSaveRequirements_Click(object sender, EventArgs e)
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
            if (saveRequirements(ref _oTransaction))
            {
                MessageBox.Show("Transaction successful. " + "\r\n" + "Event Requirements has been saved", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _oTransaction.Commit();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit_Click();
            this.Text = "Marketing*";
        }

        private void btnEdit_Click()
        {
            lEdit = true;
            //panelNew.Visible = true;
            //btnNew.Enabled = true;
            //btnEdit.SendToBack();
            btnEdit.Visible = false;
            KeypressTextboxHandler(this, false);
            txtCreateTime.Enabled = false;
          
            //grdFolio.Enabled = true;
            //grdFolio.AllowEditing = true;
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            btnCancelReservation_Click();
        }

        private void btnFolio_Click(object sender, EventArgs e)
        {

            if (loFolio.FolioID != "")
            {
                //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                //havent check for possible errors if not constant parameter is used because of lack of time
                string _currentRoomNo = loFolioFacade.GetCurrentRoomOccupied(loFolio.FolioID, "INDIVIDUAL");


                FolioLedgerUI lFolioLedgerUI = new FolioLedgerUI(loFolio.FolioID, _currentRoomNo, this);
                lFolioLedgerUI.MdiParent = this.MdiParent;
                lFolioLedgerUI.Show();
            }

        }

        private void btnPrintContract_Click(object sender, EventArgs e)
        {
            GenericList<EventBookingInfo> _EventBookingInfos = loEventFacade.getEvent(loFolio.FolioID);
            EventBookingInfo _EventBookingInfo;
            string _EventType = "";
            foreach (EventBookingInfo _EventBook in _EventBookingInfos)
            {
                _EventType = _EventBook.EventType;
            }
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            if (btnPrintContract.Text == "")//"Contract")
            {
                //this.MdiParent.Cursor = Cursors.WaitCursor;

                bool _isBanquet = false;
                EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
                _isBanquet = _oEventTypeFacade.isBanquetType(_EventType);

                string _isAlpa = ConfigVariables.gContractType;

                if (_isBanquet == true && _isAlpa == "STANDARD")
                {
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();

                    setDatabaseLogOn();
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract();
                    banquetContract = _oReportFacade.getBanquetEventContract(txtFolioID.Text);
                    banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                    oReportViewerUI.rptViewer.ReportSource = banquetContract;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }
                else if (_isBanquet == false && _isAlpa == "STANDARD")
                {
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();

                    setDatabaseLogOn();
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomReservationContract roomContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomReservationContract();
                    roomContract = _oReportFacade.getRoomReservationContract(txtFolioID.Text);
                    roomContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                    oReportViewerUI.rptViewer.ReportSource = roomContract;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }
                else
                {
                    //if (_isBanquet == true)
                    //{
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                    //}
                    //else
                    //{
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getRoomTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                    //}

                    setDatabaseLogOn();
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.AlpaEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.AlpaEventContract();
                    banquetContract = _oReportFacade.getAlpaEventContract(txtFolioID.Text);
                    banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                    oReportViewerUI.rptViewer.ReportSource = banquetContract;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }

                this.MdiParent.Cursor = Cursors.Default;
            }
            else
            {
                try
                {
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    loEventFacade = new EventFacade();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk.GroupRegistrationForm_PICC _groupReservation = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk.GroupRegistrationForm_PICC();
                   // _groupReservation = _oReportFacade.getGroupRegistration(loFolio, loEventFacade.getEvent(loFolio.FolioID)[0]);
                    oReportViewerUI.rptViewer.ReportSource = _groupReservation;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Folio Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnBrowseAccount_Click(object sender, EventArgs e)
        {
            if (lEdit == false)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            browseAccount();

        }
        private void browseAccount()
        {
            if (rdbCompany.Checked)
            {
                if (lEdit == true || lFlag == "New")
                {
                    GroupAccountLookUP.AccountType = "COMPANY";
                    GroupAccountLookUP.Flag = "GroupReservation";

                    GroupAccountLookUP groupAccountLookUP = new GroupAccountLookUP(txtCompanyCode, txtCompanyName, txtcompanyid, "COMPANY", txtAccount_Type, txtTHRESHOLD_VALUE, txtTotal_Sales_Contribution);
                    groupAccountLookUP.MdiParent = this.MdiParent;
                    groupAccountLookUP.Show();
                }
                else
                {
                    //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (lEdit == true || lFlag == "New")
                {
                    IndividualGuestLookUP guestAccountLookUp = new IndividualGuestLookUP();
                    this.txtcompanyid.Text = guestAccountLookUp.showDialogID();

                    //guestAccountLookUp.MdiParent = this.MdiParent;
                    //guestAccountLookUp.Show();
                }
                else
                {
                    //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void lvwBrowseCompany_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _companyId = this.lvwBrowseCompany.SelectedItems[0].Text;
                string _companyName = this.lvwBrowseCompany.SelectedItems[0].SubItems[1].Text;
                /* Gene
                 * 01-Mar-12
                 */
                string _companyTIN = this.lvwBrowseCompany.SelectedItems[0].SubItems[2].Text;

                this.txtcompanyid.Text = _companyId;
                this.txtCompanyName.Text = _companyName;
                /* Gene
                 * 01-Mar-12
                 */
                //this.txtTIN.Text = _companyTIN;
            }
            catch
            { }

            this.lvwBrowseCompany.Visible = false;

        }

        private void lvwBrowseCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 13 = ENTER
            {
                lvwBrowseCompany_DoubleClick(sender, new EventArgs());
            }
        }

        private void gridEventOfficer_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                DataRowView _dRow = (DataRowView)cboUsers.SelectedItem;
                gridEventOfficer.SetData(gridEventOfficer.Row, 1, _dRow["FirstName"].ToString());
                gridEventOfficer.SetData(gridEventOfficer.Row, 2, _dRow["UserId"].ToString());
            }
            if (e.Col == 1)
            {
                DataRowView _dRow = (DataRowView)cboUsers.SelectedItem;
                gridEventOfficer.SetData(gridEventOfficer.Row, 0, _dRow["LastName"].ToString());
                gridEventOfficer.SetData(gridEventOfficer.Row, 2, _dRow["UserId"].ToString());
            }
        }
        private void btnPostCharges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Post Charges for this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();

            // added dtpPostingDate to allow posting of charges for previous dates
            // Clark 08.10.2011
            if (oPostRoomChargeFacade.PostGroupCharges(DateTime.Now, txtFolioID.Text) == true)
            {
                MessageBox.Show("Posting transactions successful. ", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
                _oFolioLedgerUI.MdiParent = this.MdiParent;
                _oFolioLedgerUI.Show();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            btnCheckOUt_Click();
        }
        private void cboMealGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MealMenu _oGroup = (MealMenu)cboMealGroups.SelectedValue;
                lvwMenus.Items.Clear();
                MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
                GenericList<MealMenu> _oMealMenuItemList = new GenericList<MealMenu>();
                _oMealMenuItemFacade = new MealMenuItemFacade();
                if (cboMealGroups.Text != "COMBO MEALS")
                {
                    _oMealMenuItemList = new GenericList<MealMenu>();
                    _oMealMenuItemList = _oMealMenuItemFacade.getMealMenuItems();
                    foreach (MealMenu _oMealItem in _oMealMenuItemList)
                    {
                        if (_oMealItem.GroupID == _oGroup.GroupID)
                        {
                            string[] item ={ _oMealItem.Description, _oMealItem.MealMenuItemID.ToString(), _oMealItem.Price.ToString() };
                            ListViewItem li = new ListViewItem(item);
                            lvwMenus.Items.Add(li);
                        }
                    }
                }
                else
                {
                    _oMealMenuItemList = new GenericList<MealMenu>();
                    _oMealMenuItemList = _oMealMenuItemFacade.getMealMenus();
                    foreach (MealMenu _oMealMenu in _oMealMenuItemList)
                    {
                        string[] items ={ _oMealMenu.Description, _oMealMenu.MenuID.ToString(), _oMealMenu.Price.ToString() };
                        ListViewItem _listViewItem = new ListViewItem(items);
                        lvwMenus.Items.Add(_listViewItem);
                    }
                }
            }
            catch 
            {
                
           
            }

        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                txtcompanyid.Text = "";
            }

            if ((lEdit == true || lFlag == "New") && txtcompanyid.Text == "")
            {
                if (this.txtCompanyName.Text.Trim().Length <= 0)
                {
                    this.lvwBrowseCompany.Visible = false;
                }
                else
                {
                    showCompanyLookUp(this.txtCompanyName.Text);
                }
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwBrowseCompany.Visible && this.lvwBrowseCompany.Items.Count > 0)
                {
                    this.lvwBrowseCompany.Focus();
                    this.lvwBrowseCompany.Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (!this.lvwBrowseCompany.Focused)
                {
                    this.lvwBrowseCompany.Visible = false;
                }

                if (this.txtCompanyName.Text.Trim().Length == 0)
                {
                    return;
                }

                try
                {
                    DataTable _oCompany = loCompanyFacade.getCompanyAccountsData().Tables[0];
                    DataView _dtViewCompany = _oCompany.DefaultView;

                    _dtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
                    _dtViewCompany.RowFilter = "CompanyName = '" + this.txtCompanyName.Text + "'";

                    DataRowView _dRow = _dtViewCompany[0];
                    this.txtcompanyid.Text = _dRow["CompanyId"].ToString();
                }
                catch { }

                if (this.txtcompanyid.Text == "")
                {
                    if (this.txtCompanyName.Text.Trim().Length > 0)
                    {
                        createNewCompanyAccount();
                    }
                }
            }
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            txtCompanyName.Text = txtCompanyName.Text.Replace('\'', '`');
        }

        private void btnreinstate_Click(object sender, EventArgs e)
        {
            MarketingUI.ACCOUNT_TYPE = AccountType.Corporate;
            //GroupReservationUI.Flag = "New";
            MarketingUI _MarketingUI = new MarketingUI(loFolio);
            _MarketingUI.MdiParent = this.MdiParent;
            _MarketingUI.Show();
            this.Close();
        }

        private void btnBookingSheet_Click(object sender, EventArgs e)
        {
            if (lEdit == true && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is in Edit Mode, Please save or cancel to proceed", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (btnBookingSheet.Text == "Booking Sheet")
            {
                Reports.Presentation.BookingSheetDepartment _oBookingSheetUI = new Jinisys.Hotel.Reports.Presentation.BookingSheetDepartment(txtFolioID.Text);
                _oBookingSheetUI.MdiParent = this.MdiParent;
                _oBookingSheetUI.Show();
            }
            else
            {
                IList<string> _oRooms = new List<string>();
                string _room = "";
                for (int _row = 1; _row < this.gridReqSchedules.Rows.Count; _row++)
                {
                    _room = gridReqSchedules.GetDataDisplay(_row, 0) + " [" + gridReqSchedules.GetDataDisplay(_row, 1) + "]";
                    if (!_oRooms.Contains(_room))
                    {
                        _oRooms.Add(_room);
                    }
                }
                string _organizer = "";
                if (rdbCompany.Checked)
                {
                    _organizer = txtCompanyName.Text;
                }
                else
                {
                    _organizer = txtFirstName.Text + " " + txtLastName.Text;
                }
                GenericList<EventBookingInfo> _EventBookingInfo = loEventFacade.getEvent(loFolio.FolioID);
                int _MaxNum = 0;
                string _EventType = "";
                foreach (EventBookingInfo _EventBook in _EventBookingInfo)
                {
                    _MaxNum = _EventBook.NumberOfPaxGuaranteed;
                    _EventType = _EventBook.EventType;
                }


                Reports.Presentation.EventOrderUI _oEventOrderUI = new Jinisys.Hotel.Reports.Presentation.EventOrderUI(loFolio, _oRooms, loFolio.FromDate, loFolio.Todate, _organizer, _MaxNum, _EventType);

                //_oEventOrderUI.MdiParent = this.MdiParent;
                _oEventOrderUI.ShowDialog(this);
            }
        }

        private void btnCheckIN_Click(object sender, EventArgs e)
        {

            btnCheckIN_Click();

        }

        private void gridContacts_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuAddContact.Enabled = true;
                    this.mnuRemoveContact.Enabled = true;
                    mnuContactPerson.Show(this.gridContacts, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridContacts_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 10)
            {
                gridContacts.Cols[10].Editor = dtpBirthDate;
            }
            if (e.Col == 4)
            {
                this.gridContacts.Cols[4].Editor = lPersonType;
            }
        }

        private void gridContacts_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 4)
            {
                if (gridContacts.GetDataDisplay(gridContacts.Row, 4) == "Decision Maker")
                {
                    this.gridContacts.Rows[gridContacts.Row].Style = this.gridContacts.Styles["decisionmaker"];
                }
            }
        }



        private void mnuOpenListContact_Click(object sender, EventArgs e)
        {


            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ContactPerson _oContactPerson = new ContactPerson();
            DataTable _dt = _oContactPerson.getContactPersons(txtcompanyid.Text, GlobalVariables.gHotelId);
            gridContactList.Rows.Count = 1;
            int _row = 1;
            bool _found = false;
            foreach (DataRow _dRow in _dt.Rows)
            {
                for (int i = 1; i < gridContacts.Rows.Count; i++)
                {
                    if (_dRow["contactID"].ToString() == gridContacts.GetDataDisplay(i, 11).ToString())
                    {
                        _found = true;
                        break;
                    }
                }
                if (_found)
                {
                    _found = false;
                    continue;
                }
                gridContactList.Rows.Count++;
                gridContactList.SetData(_row, 1, _dRow["contactID"]);
                gridContactList.SetData(_row, 2, _dRow["lastName"]);
                gridContactList.SetData(_row, 3, _dRow["firstName"]);
                gridContactList.SetData(_row, 4, _dRow["middleName"]);
                gridContactList.SetData(_row, 5, _dRow["designation"]);
                gridContactList.SetData(_row, 6, _dRow["personType"]);
                gridContactList.SetData(_row, 7, _dRow["address"]);
                gridContactList.SetData(_row, 8, _dRow["telNo"]);
                gridContactList.SetData(_row, 9, _dRow["mobileNo"]);
                gridContactList.SetData(_row, 10, _dRow["faxNo"]);
                gridContactList.SetData(_row, 11, _dRow["email"]);
                gridContactList.SetData(_row, 12, _dRow["birthdate"]);
                _row++;
            }
            pnlContactList.BringToFront();
            pnlContactList.Visible = true;
        }

        private void mnuAddContact_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = this.gridContacts.Rows.Count;
            this.gridContacts.Rows.Count += 1;

            this.gridContacts.SetData(i, 0, "");
            this.gridContacts.SetData(i, 1, "");
            this.gridContacts.SetData(i, 2, "");
            this.gridContacts.SetData(i, 3, "");
            this.gridContacts.SetData(i, 4, "Contact Person");
            this.gridContacts.SetData(i, 5, "");
            this.gridContacts.SetData(i, 6, "");
            this.gridContacts.SetData(i, 7, "");
            this.gridContacts.SetData(i, 8, "");
            this.gridContacts.SetData(i, 9, "");
            this.gridContacts.SetData(i, 10, "01-01-1900");
            this.gridContacts.SetData(i, 11, "AUTO");
            this.gridContacts.Cols[4].Editor = lPersonType;
            this.gridContacts.Cols[10].Editor = dtpBirthDate;
        }

        private void mnuRemoveContact_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridContacts.Rows.Remove(this.gridContacts.Row);
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int _row = 1; _row < gridContactList.Rows.Count; _row++)
            {
                if (gridContactList.GetCellCheck(_row, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    gridContacts.Rows.Count++;
                    gridContacts.SetData(gridContacts.Rows.Count-1, 11, gridContactList.GetDataDisplay(_row, 1));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 0, gridContactList.GetDataDisplay(_row, 2));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 1, gridContactList.GetDataDisplay(_row, 3));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 2, gridContactList.GetDataDisplay(_row, 4));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 3, gridContactList.GetDataDisplay(_row, 5));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 4, gridContactList.GetDataDisplay(_row, 6));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 5, gridContactList.GetDataDisplay(_row, 7));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 6, gridContactList.GetDataDisplay(_row, 8));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 7, gridContactList.GetDataDisplay(_row, 9));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 8, gridContactList.GetDataDisplay(_row, 10));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 9, gridContactList.GetDataDisplay(_row, 11));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 10, gridContactList.GetDataDisplay(_row, 12));

                }
            }

            pnlContactList.Visible = false;
            pnlContactList.SendToBack();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlContactList.Visible = false;
            pnlContactList.SendToBack();
        }

        private void txtContractAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtContractAmount.Value > 0)
                {
                    decimal percent25 = txtContractAmount.Value / 4;
                    this.txt25RF1.Text = string.Format("{0:###,##0.#0}", percent25);
                    this.txt50RF.Text = string.Format("{0:###,##0.#0}", (percent25 * 2));
                    this.txt25RF2.Text = string.Format("{0:###,##0.#0}", (txtContractAmount.Value - decimal.Parse(txt25RF1.Text) - decimal.Parse(txt50RF.Text)));
                    this.txtBalanceRF.Text = string.Format("{0:###,##0.#0}", (txtContractAmount.Value - lTotalPayment));
                }
                else if (txtContractAmount.Value == 0)
                {
                    this.txt25RF1.Text = "0";
                    this.txt50RF.Text = "0";
                    this.txt25RF2.Text = "0";
                    this.txtBalanceRF.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : contract amount should be a valid value\r\n" + ex.Message);
                tabFolio_.TabPages["tabEndorsement"].Select();
                this.txtContractAmount.Focus();
            }
        }
        private void txtTotalEstimatedCost_TextChanged_1(object sender, EventArgs e)
        {
            decimal _totaldeposit = 0;
            decimal _totalbal = 0;
            if (grdDeposits.Rows.Count > 1)
            {
                for (int _row = 1; _row < grdDeposits.Rows.Count; _row++)
                {
                    decimal _temp;
                    try
                    {
                        string str = grdDeposits.GetDataDisplay(_row, 1).ToString();
                        _temp = decimal.Parse(str);
                    }
                    catch
                    {
                        _temp = 0;
                    }
                    _totaldeposit = _totaldeposit + _temp;
                }
            }
            //by Kevin Oliveros
            //date: 1-08-2014

            GenericList<EventBookingInfo> _EventBookingInfo = loEventFacade.getEvent(loFolio.FolioID);
            decimal _TotalEstimatedCost = 0;
            foreach (EventBookingInfo _EventBook in _EventBookingInfo)
            {
                _TotalEstimatedCost = _EventBook.EstimatedTotalCost;
            }

            try
            {
                _totalbal = _TotalEstimatedCost;//txtTotalEstimatedCost.Text);
            }
            catch
            {
                _totalbal = 0;
            }

            _totalbal = _totalbal - _totaldeposit;
            //txtEstimatedBal.Text = string.Format("{0:###,##0.#0}", _totalbal);
        }

        private void btnNewDeposit_Click(object sender, EventArgs e)
        {
            //by Kevin Oliveros
            //Uncomment if done editing
            if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
            {
                MessageBox.Show("No Shift/Cash drawer open.\r\nCan't proceed transaction.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddTransactionUI _oAddTransaction = new AddTransactionUI(loFolio, this.txtFolioID, "A", "Payments");
            _oAddTransaction.ShowDialog();
            loadFolioDeposits();
        }
        private void grdRecurredCharge_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                if (grdRecurredCharge.GetCellCheck(e.Row, e.Col) == CheckEnum.Checked)
                {
                    grdRecurredCharge.Cols[11].AllowEditing = false;
                    grdRecurredCharge.Cols[12].AllowEditing = false;
                }
                else
                {
                    grdRecurredCharge.Cols[11].AllowEditing = true;
                    grdRecurredCharge.Cols[12].AllowEditing = true;
                }
            }
            else if (e.Col == 11 || e.Col == 12)
            {
                if (grdRecurredCharge.GetCellCheck(e.Row, 0) == CheckEnum.Checked)
                {
                    grdRecurredCharge.Cols[11].AllowEditing = false;
                    grdRecurredCharge.Cols[12].AllowEditing = false;
                }
                else
                {
                    grdRecurredCharge.Cols[11].AllowEditing = true;
                    grdRecurredCharge.Cols[12].AllowEditing = true;
                }
            }

            if (e.Col == 7)
            {
                if (grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 3).ToString() == ConfigVariables.gRoomChargeTransactionCode)
                {
                    nmcQty.Minimum = 2;
                    nmcQty.Maximum = 24;
                    nmcQty.Value = 2;
                }
                else
                {
                    nmcQty.Minimum = 1;
                    nmcQty.Maximum = 1000;
                    nmcQty.Value = 1;
                }
                if (grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 3).ToString() == ConfigVariables.gContingencyCode)
                {
                    grdRecurredCharge.Cols[7].Editor = test;
                }
                else
                {
                    grdRecurredCharge.Cols[7].Editor = nmcQty;
                }
            }

            if (e.Col == 9)
            {
                grdRecurredCharge.Cols[9].Editor = cboDiscount;
            }

            if (e.Col == 5)
            {

                if (grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 3).ToString() == ConfigVariables.gRoomChargeTransactionCode)
                //if(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 5)!= "")
                {
                    //grdRecurredCharge.Cols[5].AllowEditing = true;
                    grdRecurredCharge.Cols[5].Editor = cboRateTypes;
                }
                else
                {
                    //grdRecurredCharge.Cols[5].AllowEditing = false;
                    grdRecurredCharge.Cols[5].Editor = test;
                }
            }

            if (e.Col == 8)
            {
                grdRecurredCharge.Cols[8].Editor = nudTax;
            }

            //else if (e.Col == 6)
            //{
            //    IList<TransactionCode_SubAccount> _transSubAccounts;
            //    TransactionCode_SubAccountFacade _oTransFacade = new TransactionCode_SubAccountFacade();
            //    _transSubAccounts = _oTransFacade.loadTransactionCodeSubAccounts(grdRecurredCharge.GetDataDisplay(e.Row, 1));
            //    lRecurringCombo.DisplayMember = "SubAccountCode";
            //    lRecurringCombo.ValueMember = "SubAccountCode";
            //    lRecurringCombo.DataSource = _transSubAccounts;

            //    grdRecurredCharge.Cols[6].Editor = lRecurringCombo;
            //}
        }
        private void grdRecurredCharge_EnterCell(object sender, EventArgs e)
        {
            try
            {
                if (grdRecurredCharge.Col == 11 || grdRecurredCharge.Col == 12)
                {
                    if (grdRecurredCharge.GetCellCheck(grdRecurredCharge.Row, 0) == CheckEnum.Checked)
                    {
                        grdRecurredCharge.Cols[11].AllowEditing = false;
                        grdRecurredCharge.Cols[12].AllowEditing = false;
                    }
                    else
                    {
                        grdRecurredCharge.Cols[11].AllowEditing = true;
                        grdRecurredCharge.Cols[12].AllowEditing = true;
                    }
                }
            }
            catch { }
        }

        private void grdRecurredCharge_MouseUp(object sender, MouseEventArgs e)
        {
            lvwRecurredChargeMouseUp(sender, e);
        }

        private void txtPackageAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtContractAmount.Value = decimal.Parse(txtPackageAmount.Text);
            }
            catch { }
        }
        ReportViewer rptViewer;
        private EstimatedChargesReport oGroupEstimatedCharge;

        private void btnPrintEstimatedCharges_Click(object sender, EventArgs e)
        {
            pnlEstimateCharges.BringToFront();
            pnlEstimateCharges.Visible = true;
        }

        private void btnPrintEstimated_Click(object sender, EventArgs e)
        {
            DataTable _printableCharges = new DataTable();
            _printableCharges.Columns.Add("Header");
            _printableCharges.Columns.Add("TransactionCode");
            _printableCharges.Columns.Add("FromDate", typeof(DateTime));
            _printableCharges.Columns.Add("Memo");
            _printableCharges.Columns.Add("Amount", typeof(double));
            _printableCharges.Columns.Add("RoomTypeCode");
            _printableCharges.Columns.Add("RoomDescription");

            decimal _totalTax = 0;
            foreach (RecurringCharge _oRecurringCharge in loFolio.RecurringCharges)
            {
                TimeSpan _span = _oRecurringCharge.ToDate.Subtract(_oRecurringCharge.FromDate);
                int _difference = System.Convert.ToInt32(Math.Floor(_span.TotalDays));

                _difference++;
                for (int i = 0; i < _difference; i++)
                {
                    DataRow _row = _printableCharges.NewRow();
                    if (_oRecurringCharge.TransactionCode == ConfigVariables.gContingencyCode)
                    {
                        _row["Header"] = "II. CONTINGENCY FOR ADDITIONAL REQUIREMENTS";
                    }
                    else
                    {
                        _row["Header"] = "I. EVENT AREAS";
                    }

                    //_row["Memo"] = _oRecurringCharge.FromDate.AddDays(i).ToString("MMMM dd, yyyy") + "\n" + _oRecurringCharge.Memo;
                    string[] _subMemo = _oRecurringCharge.Memo.Split('/');
                    if (_subMemo.Length > 1 && _oRecurringCharge.TransactionCode == ConfigVariables.gRoomChargeTransactionCode)
                    {
                        _row["Memo"] = _oRecurringCharge.FromDate.AddDays(i).ToString("MMMM dd, yyyy") + " / " + _subMemo[1] + "\n" + _subMemo[0];
                    }
                    else
                    {
                        _row["Memo"] = _oRecurringCharge.FromDate.AddDays(i).ToString("MMMM dd, yyyy") + "\n" + _oRecurringCharge.Memo;
                    }
                    _row["TransactionCode"] = _oRecurringCharge.TransactionCode;
                    //_row["Amount"] = _oRecurringCharge.Amount;
                    _row["FromDate"] = _oRecurringCharge.FromDate.AddDays(i);

                    Room _oRoom = new Room();
                    RoomFacade _oRoomFacade = new RoomFacade();
                    _oRoom = _oRoomFacade.getRoom(_oRecurringCharge.RoomID);

                    _row["RoomTypeCode"] = _oRoom.RoomTypecode;
                    //_row["RoomDescription"] = _oRoom.RoomDescription;
                    decimal _amount = _oRecurringCharge.BaseAmount * ((100 - _oRecurringCharge.Discount) / 100);
                    _totalTax = _totalTax + (_oRecurringCharge.BaseAmount * _oRecurringCharge.Tax / 100 * _oRecurringCharge.QtyHrs);
                    if (_oRecurringCharge.TransactionCode == ConfigVariables.gRoomChargeTransactionCode)
                    {
                        _row["RoomDescription"] = _oRoom.RoomDescription + " on...\nP" + (_amount * 4) + " (4 hrs.) P" + _amount + " (extra hour)";
                    }
                    else
                    {
                        _row["RoomDescription"] = _oRoom.RoomDescription + "...";
                    }
                    _row["Amount"] = _amount * _oRecurringCharge.QtyHrs;
                    _printableCharges.Rows.Add(_row);
                }
            }

            if (_printableCharges != null)
            {

                oGroupEstimatedCharge = new EstimatedChargesReport();

                oGroupEstimatedCharge.Database.Tables[1].SetDataSource(_printableCharges);
                oGroupEstimatedCharge.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                oGroupEstimatedCharge.SetParameterValue(0, cboShowAmount.Text);
                oGroupEstimatedCharge.SetParameterValue(1, txtContingencyDetails.Text);
                oGroupEstimatedCharge.SetParameterValue(2, _totalTax);
                oGroupEstimatedCharge.SetParameterValue(3, loFolio.ReferenceNo);
                oGroupEstimatedCharge.SetParameterValue(4, loFolio.GroupName);
                oGroupEstimatedCharge.SetParameterValue(5, loFolio.FromDate);
                if (rdbCompany.Checked)
                {
                    oGroupEstimatedCharge.SetParameterValue(6, txtCompanyName.Text);
                }
                else
                {
                    oGroupEstimatedCharge.SetParameterValue(6, txtLastName.Text + ", " + txtFirstName.Text);
                }

                oGroupEstimatedCharge.SetParameterValue(7, loFolio.FolioID);

                rptViewer = new ReportViewer();
                rptViewer.rptViewer.ReportSource = oGroupEstimatedCharge;
                rptViewer.MdiParent = this.MdiParent;
                rptViewer.Show();


                this.MdiParent.Cursor = Cursors.Default;

                //this.Close();
            }

            this.pnlEstimateCharges.SendToBack();
            this.pnlEstimateCharges.Visible = false;
        }

        private void btnCancelEstimated_Click(object sender, EventArgs e)
        {
            this.pnlEstimateCharges.Visible = false;
        }

        private void btnUploadAttachments_Click(object sender, EventArgs e)
        {
            if (loFolio != null)
            {
                ofdUpload.Filter = "Excel Files (*.xls)|*.xls";
                ofdUpload.FileName = "";
                DialogResult _result = ofdUpload.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(ofdUpload.FileName, ConfigVariables.gServerUploadPath + loFolio.FolioID + ".xls", true);
                        MessageBox.Show("Upload successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem uploading the document!\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                if (loFolio != null)
                {
                    string _file = ConfigVariables.gServerUploadPath + loFolio.FolioID + ".xls";
                    _file = _file.Replace("\\\\", "\\");
                    Process.Start(_file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem viewing the Excel file.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdRecurringCharges_SelChange(object sender, EventArgs e)
        {
            try
            {
                lCode = grdRecurringCharges.GetDataDisplay(grdRecurringCharges.Row, 0);
                lCharge = grdRecurringCharges.GetDataDisplay(grdRecurringCharges.Row, 1);
            }
            catch (Exception)
            {
            }
        }

        private void pnlEstimateCharges_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlEstimateCharges.Visible == true)
            {
                txtContingencyDetails.Text = "(Alloted for possible extension of hire period," +
                    " power charges for any technical equipment to be brought inside " + ConfigVariables.gReportOrganization +
                    ", charges for possible damages and for additional requirement that may be incurred, etc.)";

                // tabFolio_.Enabled = false;
            }
            else
            {
                txtContingencyDetails.Text = "";
                tabFolio_.Enabled = true;
            }

        }

        private void btnLossBusiness_Click(object sender, EventArgs e)
        {
            Reports.Presentation.LostBusinessUI _Business = new LostBusinessUI();
            _Business.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintSystemChanges_Click_1(object sender, EventArgs e)
         {

        }

        private void btnEdit_VisibleChanged(object sender, EventArgs e)
        {
            disableTextBoxes();
            if (btnEdit.Visible == true)
            {
                if (loFolio.Status == "CONFIRMED" || loFolio.Status == "WAITLIST" || loFolio.Status == "TENTATIVE")
                    btnCancelReservation.Enabled = true;
                else
                    btnCancelReservation.Enabled = false;
                btnCancelReservation.Enabled = true;

                //btnCancelReservation.Enabled = false;
                // btnCancelReservation.Text = "C&ancel Rsvn";
             
            }
            else
            {
                btnCancelReservation.Enabled = true;
                //btnCancelReservation.Enabled = true;
                // btnCancelReservation.Text = "C&ancel";
                
                pnlStatus.Enabled = false;
                pnlFolio.Enabled = false;
                btnCancelReservation.Enabled = false;

            }
            if (lViewOnly == false)
            {
                pnlStatus.Enabled = true;
                pnlFolio.Enabled = true;
                pnlNew.Enabled = true;
          
              
            }
            else
            {
                //tabFolio_.Enabled = false;
               ((Control)tabFoodBev_).Enabled = false;
               ((Control)tabEventRequirements).Enabled = false;
               ((Control)tabEndorsement).Enabled = false;
               ((Control)tabAmmendments).Enabled = false;
               ((Control)tabContactPerson).Enabled = false;

                pnlStatus.Enabled = false;
                pnlFolio.Enabled = false;
                pnlNew.Enabled = false;
               
            }
        }

        private void disableTextBoxes()
        {
            this.txtFolioID.ReadOnly = true;
            this.cboStatus.Enabled = false;
            this.txtEventDate.ReadOnly = true;
            this.txtReferenceNo.ReadOnly = true;
            this.txt25RF1.ReadOnly = true;
            this.txt25RF2.ReadOnly = true;
            this.txt50RF.ReadOnly = true;
            this.txtBalanceRF.ReadOnly = true;
        }

        private void btnAmendmentArrow_Click(object sender, EventArgs e)
        {
            if (btnNewAmmendment.Text.ToUpper().Trim() == "NEW")
            {
                MessageBox.Show("Please create a new amendment first", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                int _row = gridAmendmentSchedules.Row;
                string _sched = gridAmendmentSchedules.GetDataDisplay(_row, 0) + " (" + gridAmendmentSchedules.GetDataDisplay(_row, 1) + " - " + gridAmendmentSchedules.GetDataDisplay(_row, 2) + ")";
                txtOldValue.AppendText(_sched);
            }
            catch { }
        }

        private void btnAddFAndB_Click(object sender, EventArgs e)
        {
            try
            {
                gridNewMeal.Rows.Count++;
                gridNewMeal.SetData(gridNewMeal.Rows.Count-1, "NewMeal", "1");

            }
            catch
            {

            }
        }

        private void btnRemoveFAndB_Click(object sender, EventArgs e)
        {
            try
            {
                gridNewMeal.Rows.Remove(gridNewMeal.Row);
            }
            catch
            {
            }
        }

        private void gridNewMeal_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                cboMealType.Enabled = true;
                gridNewMeal.Cols[0].Editor = cboMealType;
            }
            else if (e.Col == 1)
            {
                gridNewMeal.Cols[1].Editor = nudMealPax;
            }
            else if (e.Col == 2)
            {
                gridNewMeal.Cols[2].Editor = nudPaxAmt;
            }
            else if (e.Col == 3)
            {

                gridNewMeal.Cols[3].Editor = txtTotalMealAmount;
               
            }
            else if (e.Col == 4)
            {

                gridNewMeal.Cols[4].Editor = dtpFoodDate;
            }
            else if (e.Col == 5)
            {

                gridNewMeal.Cols[5].Editor = txtVenueFood;
            }
            else if (e.Col == 6)
            {
                gridNewMeal.Cols[6].Editor = txtFoodRemarks;
              
            }
            else if (e.Col == 7)
            {
                gridNewMeal.Cols[7].Editor = txtFoodSetup;
             
            }
            else if (e.Col == 8)
            {
                gridNewMeal.Cols[8].Editor = txtFoodOver;
            }
        }

        private void gridNewMeal_AfterEdit(object sender, RowColEventArgs e)
        {
            
            decimal _paxAmount = 0;
            decimal _noOfPax = 0;
            decimal _totalAmount = 0;
            try
            {
                _paxAmount = decimal.Parse(gridNewMeal.GetDataDisplay(gridNewMeal.Row, 2));
                _noOfPax = decimal.Parse(gridNewMeal.GetDataDisplay(gridNewMeal.Row, 1));
                _totalAmount = _noOfPax * _paxAmount;
            }
            catch
            {
                _paxAmount = 0;
                _noOfPax = 0;
                _totalAmount = 0;
            }
            gridNewMeal.SetData(gridNewMeal.Row, "totalCost", _totalAmount);
            if (e.Col == 0)
            {
                gridNewMeal.SetData(gridNewMeal.Row, "MealTypeID", cboMealType.SelectedIndex.ToString());
            }
            getTotalAmountFoodAndBev();


        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void btnUploadContract_Click(object sender, EventArgs e)
        {
            try
            {

                ContractUI _contractUI = new ContractUI(loFolio.FolioID);
                _contractUI.ShowDialog();

            }
            catch
            {

            }
        }

        private void btnEndorsement_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
           
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();
            try
            {


                oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getEndorsementForm(loFolio.FolioID);
                oReportViewerUI.MdiParent = this.MdiParent;
                oReportViewerUI.Show();

                //setDatabaseLogOn();
                //oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                //Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract();
                //banquetContract = _oReportFacade.getBanquetEventContract(txtFolioID.Text);
                //banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                //oReportViewerUI.rptViewer.ReportSource = banquetContract;
                //oReportViewerUI.MdiParent = this.MdiParent;
                //oReportViewerUI.Show();
            }
            catch
            {

            }
        }

   
       

        //#region EVENT PACKAGES

        //private void cboEventGrpPackage_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if (lGroupFolioStatus != "New" && lEdit != true)
        //    {
        //        MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        cboEventGrpPackage.SelectedValue = loFolio.PackageID;
        //        txtFolioID.Focus();
        //    }
        //    else
        //    {
        //        loFolio.RecurringCharges = null;
        //        cboEventPackage.Text = cboEventGrpPackage.Text;
        //    }
        //}

        //private void deletePackageRecurringCharges()
        //{
        //    foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
        //    {
        //        if (_row.Index > 0 && grdRecurredCharge.GetCellCheck(_row.Index, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
        //        {
        //            grdRecurredCharge.RemoveItem(_row.Index);
        //            deletePackageRecurringCharges();
        //            return;
        //        }
        //    }
        //}

        //private void cboEventPackage_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    grdRecurredCharge.Rows.Count = 1;
        //    loadFolioRecurringCharges();

        //    EventPackageFacade _oEventPackageFacade = new EventPackageFacade();
        //    //txtPackageAmount.Text = _oEventPackageFacade.getEventPackageAmount(cboEventPackage.SelectedValue.ToString()).ToString();

        //    if (lEdit == true || lGroupFolioStatus == "New")
        //    {
        //        deletePackageRecurringCharges();
        //        EventPackageDetailFacade _oEventPackageDetailFacade = new EventPackageDetailFacade();
        //        EventPackageHeader _oEventPackageHeader = _oEventPackageFacade.getEventPackage(cboEventGrpPackage.SelectedValue.ToString());
        //        GenericList<EventPackageDetail> _eventPackageDetailList = _oEventPackageDetailFacade.getEventPackageDetails(cboEventGrpPackage.SelectedValue.ToString());

        //        nudNumberOfPaxLiveIn.Value = decimal.Parse(_oEventPackageHeader.MinimumPax.ToString());
        //        nudNumberOfPaxLiveOut.Value = decimal.Parse(_oEventPackageHeader.MaximumPax.ToString());

        //        foreach (EventPackageDetail _oEventPackageDetail in _eventPackageDetailList)
        //        {
        //            grdRecurredCharge.Rows.Count++;
        //            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, true);
        //            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, _oEventPackageDetail.TransactionCode.ToString());
        //            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, _oEventPackageDetail.Description);
        //            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, _oEventPackageDetail.Amount);

        //            try
        //            {
        //                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, gridFunctionRooms.GetData(1, 3));
        //                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, gridFunctionRooms.GetData(1, 3));
        //            }
        //            catch
        //            {
        //                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(GlobalVariables.gAuditDate));
        //                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(GlobalVariables.gAuditDate));
        //            }

        //            //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _oEventPackageDetail.SubAccount);
        //        }

        //        EventPackageDetailFacade _oEventPackageRequirementFacade = new EventPackageDetailFacade();
        //        GenericList<EventPackageDetail> _oEventPackageRequirementList = _oEventPackageRequirementFacade.getEventPackageRequirements(cboEventGrpPackage.SelectedValue.ToString());
        //        treeRequirements.Nodes.Clear();
        //        foreach (EventPackageDetail _oEventPackageRequirement in _oEventPackageRequirementList)
        //        {
        //            if (treeRequirements.Nodes.Count > 0)
        //            {
        //                foreach (TreeNode _tNode in treeRequirements.Nodes)
        //                {
        //                    if (_tNode.Text == _oEventPackageRequirement.RequirementHeader || (_tNode.Text == _oEventPackageRequirement.RequirementHeader && _tNode.Index == treeRequirements.Nodes.Count - 1))
        //                    {
        //                        _tNode.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
        //                    }
        //                    else if ((_tNode.Text != _oEventPackageRequirement.RequirementHeader && _tNode.Index != treeRequirements.Nodes.Count - 1))
        //                    { }
        //                    else if (_tNode.Text == _oEventPackageRequirement.RequirementDetail)
        //                    { }
        //                    else
        //                    {
        //                        TreeNode _node = new TreeNode(_oEventPackageRequirement.RequirementHeader);
        //                        _node.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
        //                        treeRequirements.Nodes.Add(_node);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                TreeNode _node = new TreeNode(_oEventPackageRequirement.RequirementHeader);
        //                _node.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
        //                treeRequirements.Nodes.Add(_node);
        //            }

        //            treeRequirements.ExpandAll();
        //        }
        //        computePackageAmount();
        //    }
        //    cboEventPackage.Text = cboEventGrpPackage.Text;
        //}

        //#endregion //>>packages

        public void getTotalAmountFoodAndBev()
        {
            float _total = 0;
            foreach (C1.Win.C1FlexGrid.Row _row in gridNewMeal.Rows)
            {
                try
                {

                    _total += float.Parse(_row["totalCost"].ToString());
                }
                catch
                {
                    _total += 0;
                }
            }
            try
            {
                lblTotalFB.Text = string.Format("{2:N}", _total);
            }
            catch
            {
                lblTotalFB.Text = "0.00";
            }
        }

        #endregion

       
      

      
       

       
      

       

    
      
        


        

    }

     
}