using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using C1.Win.C1FlexGrid;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.NightAudit.BusinessLayer;
using Jinisys.Hotel.Cashier.Presentation;

using SAP_SDK;
using Integrations;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class ReservationUI : Jinisys.Hotel.UIFramework.TransactionUI
    {
        #region "Variables"
        private TableLogOnInfo logOnInfo;
        private EventStatus lEventStatus;
        private ReservationType lReservationType;
        private Sequence loSequence;
        private FolioFacade loFolioFacade;
        private CompanyFacade loCompanyFacade;
        private EventFacade loEventFacade;
        private GuestFacade loGuestFacade;
        private Company loCompany;
        private Guest loGuest;
        private Folio loFolio;
        private string lFolioId;
        private DataTable loUserList;
        private OperationMode lUIMode;
        private bool lCanAddEventOfficer = false;
        private bool lCanAddMarketingOfficer = false;
        private ComboBox lcboPersonType = new ComboBox();
        private ComboBox lcboRooms = new ComboBox();
        private ComboBox lcboUsers = new ComboBox();
        private ComboBox lcboRateTypes = new ComboBox();
        private ComboBox lcboSetups = new ComboBox();
        private ComboBox lcboActivities = new ComboBox();
        private ComboBox lcboReqDates = new ComboBox();
        private DateTimePicker ldtpDatePicker = new DateTimePicker();
        private DateTimePicker ldtpTimePicker = new DateTimePicker();
        private DateTimePicker ldtpFromDate = new DateTimePicker();
        private DateTimePicker ldtpToDate = new DateTimePicker();
        private String[] aReservationStatus = { "TENTATIVE", "WAIT LIST", "CONFIRMED", "ONGOING", "CLOSED", "CANCELLED", "NO SHOW" };

        private bool lIsReinstated;
      
        #endregion

        #region "Constructors"
        private void InitializeFacades()
        {

            loFolioFacade = new FolioFacade();
            loEventFacade = new EventFacade();
            loGuestFacade = new GuestFacade();
            loCompanyFacade = new CompanyFacade();
        }

        public ReservationUI()
        {
            InitializeComponent();
            InitializeFacades();
            loFolio = new Folio();
            loSequence = new Sequence();

            lReservationType = ReservationType.NEW;
            lUIMode = OperationMode.Add;

            txtControlNo.Text = "AUTO";
            txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
            txtStatus.Text = EventStatus.TENTATIVE.ToString();
            cboClientType.Text = AccountType.Corporate.ToString().ToUpper();
            cboPaymentMode.Text = PaymentMode.Cash.ToString().ToUpper();
            cboMarketSegment.Text = ReservationPurpose.Business.ToString().ToUpper();
            rdbCompany.Checked = true;

            KeypressTextboxHandler(this, false);

            loadDropDowns();
        }

        public ReservationUI(Folio pFolio)
            : this()
        {
            lReservationType = ReservationType.OLD;
            lUIMode = OperationMode.Edit;
            loadDropDowns();
            lIsReinstated = true;
            loFolio = loFolioFacade.GetFolio(pFolio.FolioID);
            // Assign folio attributes to form objects

            txtEventName.Text = loFolio.GroupName;
            cboMarketingOfficer.SelectedItem = loFolio.Sales_Executive;
            //txtStatus.Text = loFolio.Status;
            //txtRemarks.Text = "Reinstated from " + loFolio.FolioID + " : " + loFolio.Remarks;
  
            txtStatus.Text = "TENTATIVE";
            loFolio.Status = "TENTATIVE";
            loFolio.CreateTime = DateTime.Now;
            txtControlNo.Text = loFolio.FolioID;
            txtReferenceNo.Text = loFolio.ReferenceNo;
            txtUpdatedBy.Text = loFolio.UpdatedBy;
            txtBookingDate.Text = loFolio.CreateTime.ToString("yyyy-MM-dd");
            txtCreatedBy.Text = loFolio.CreatedBy;
            //txtRemarks.Text = loFolio.Remarks;
            //txtAccountID.Text = loFolio.CompanyID;
            //grdContactPersons.DataSource = loFolio.ContactPersons;
            //>>


            AccountId = loFolio.CompanyID;

            if (AccountId.StartsWith("G"))
            {
                loCompany = new Company();
                rdbCompany.Checked = true;
                txtAccountID.Text = loFolio.CompanyID;
                loCompany = loCompanyFacade.getCompanyAccount(AccountId);
                loFolio.Company = loCompany;
                cboClientType.SelectedItem = loFolio.AccountType;

                txtCompanyName.Text = loCompany.CompanyName;
                txtTINNo.Text = loCompany.TIN;
                txtStreet.Text = loCompany.Street1;
                txtCity.Text = loCompany.City1;
                txtCountry.Text = loCompany.Country1;
                txtZIP.Text = loCompany.Zip1;
            }
            else
            {
                loGuest = new Guest();
                rdbIndividual.Checked = true;
                txtAccountID.Text = loFolio.CompanyID;
                loGuestFacade = new GuestFacade();
                loGuest = loGuestFacade.getGuestRecord(AccountId);

                txtLastName.Text = loGuest.LastName;
                txtFirstName.Text = loGuest.FirstName;
                txtPassportID.Text = loGuest.PassportId;
                txtStreet.Text = loGuest.Street;
                txtCity.Text = loGuest.City;
                txtCountry.Text = loGuest.Country;
                txtZIP.Text = loGuest.Zip;
            }

            btnEdit.Visible = true;

            KeypressTextboxHandler(this, true);

            //loadFolio();
            loadContactPersons();
            loadContractAmendments();
            loadEventOfficers();
            if (lIsReinstated == false)
            {

                loadRequirementDetails();
                loadContractAmendments();
            }
            btnEdit.Enabled = true;
 
        }

        public ReservationUI(string pFolioId)
            : this()
        {
            loadDropDowns();
            lReservationType = ReservationType.OLD;
            lUIMode = OperationMode.View;

            loFolio = loFolioFacade.GetFolio(pFolioId);
            // Assign folio attributes to form objects

            txtEventName.Text = loFolio.GroupName;
            cboMarketingOfficer.SelectedItem = loFolio.Sales_Executive;
            txtStatus.Text = loFolio.Status;
            txtControlNo.Text = loFolio.FolioID;
            txtReferenceNo.Text = loFolio.ReferenceNo;
            txtUpdatedBy.Text = loFolio.UpdatedBy;
            txtBookingDate.Text = loFolio.CreateTime.ToString("yyyy-MM-dd");
            txtCreatedBy.Text = loFolio.CreatedBy;
            txtRemarks.Text = loFolio.Remarks;
            //txtAccountID.Text = loFolio.CompanyID;
            //grdContactPersons.DataSource = loFolio.ContactPersons;
            //>>


            AccountId = loFolio.CompanyID;

            if (AccountId.StartsWith("G"))
            {
                loCompany = new Company();
                rdbCompany.Checked = true;
                txtAccountID.Text = loFolio.CompanyID;
                loCompany = loCompanyFacade.getCompanyAccount(AccountId);
                loFolio.Company = loCompany;
                cboClientType.SelectedItem = loFolio.AccountType;

                txtCompanyName.Text = loCompany.CompanyName;
                txtTINNo.Text = loCompany.TIN;
                txtStreet.Text = loCompany.Street1;
                txtCity.Text = loCompany.City1;
                txtCountry.Text = loCompany.Country1;
                txtZIP.Text = loCompany.Zip1;
            }
            else
            {
                loGuest = new Guest();
                rdbIndividual.Checked = true;
                txtAccountID.Text = loFolio.CompanyID;
                loGuestFacade = new GuestFacade();
                loGuest = loGuestFacade.getGuestRecord(AccountId);

                txtLastName.Text = loGuest.LastName;
                txtFirstName.Text = loGuest.FirstName;
                txtPassportID.Text = loGuest.PassportId;
                txtStreet.Text = loGuest.Street;
                txtCity.Text = loGuest.City;
                txtCountry.Text = loGuest.Country;
                txtZIP.Text = loGuest.Zip;
            }

            btnEdit.Visible = true;
            btnReservationForm.Enabled = false;
            KeypressTextboxHandler(this, true);

            loadFolio();
            loadContactPersons();
            loadContractAmendments();
            loadEventOfficers();
            if (lIsReinstated == false)
            {
                loadRequirementDetails();

            }

            
        }
        #endregion

        #region "Attributes"
        private AccountType mAccountType;
        public AccountType AccountType
        {
            set { this.mAccountType = value; }
            get { return this.mAccountType; }
        }
        private string mAccountId;
        public string AccountId
        {
            set { this.mAccountId = value; }
            get { return this.mAccountId; }
        }
        #endregion

        #region "Events"
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReservationUI_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void rdbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIndividual.Checked == true)
            {
                pnlCompany.Visible = false;
                txtAccountID.Text = "";
            }
        }

        private void rdbCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompany.Checked == true)
            {
                pnlCompany.Visible = true;
                txtAccountID.Text = "";
            }
        }
        private void ReservationUI_Load(object sender, EventArgs e)
        {
            //by Kevin Oliveros
            //Hide tabpage
                tabReservation_.TabPages.Remove(tabReservation_.TabPages["tabRequirements"]);
            //
            this.ldtpDatePicker.CustomFormat = "MM/dd/yyyy";
            this.ldtpDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ldtpTimePicker.CustomFormat = "hh:mm tt";
            this.ldtpTimePicker.Format = DateTimePickerFormat.Custom;
            this.ldtpTimePicker.ShowUpDown = true;

            switch (lReservationType)
            {
                case ReservationType.NEW:
                    pnlAmendments.Enabled = false;
                    grpNewAmendment.Enabled = false;
                    btnCancelReservation.Enabled = false ;
                    break;

                case ReservationType.OLD:
                    loadRoomRequirements();
                    cboMarketSegment.SelectedItem = loFolio.Purpose;
                    cboPaymentMode.SelectedItem = loFolio.Payment_Mode;
                    cboSource.SelectedItem = loFolio.Source;
                    grpNewAmendment.Enabled = false;
                    btnSaveAmendment.Enabled = false;
                    btnCancelReservation.Enabled = true; 
                    
                    break;
            }

            KeypressTextboxHandler(this, true);

            if (loFolio.Status == "CANCELLED" || loFolio.Status == "NO SHOW" || loFolio.Status == "CLOSED")
            {
                DisableControls(this);
                btnClose.Enabled = true;
                btnReservationForm.Enabled = true;
                if (loFolio.Status == "CANCELLED" || loFolio.Status == "NO SHOW")
                    btnReinstate.Enabled = true;
            }
            else
            {
                setButtons();
            }
         
          
            CheckUserRoles();
            //Kevin Oliveros
            if (loFolio.Status == "CANCELLED")
            {
                btnReservationForm.Enabled = false;
            }
          
            if (lIsReinstated == true)
            {
               
                btnCharges.Enabled = false;
                btnReservationForm.Enabled = false;
                btnEventOrder.Enabled = false;
                btnConfirm.Enabled = false;
                btnUnconfirm.Enabled = false;
                pnlAmendments.Enabled = false;
                grpNewAmendment.Enabled = false;
                btnEdit_Click(null, null);
                btnReinstate.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
         {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

         
            if ( checkScheduleDuplicate() !="")
            {
                MessageBox.Show("Conflict in room schedule " + checkScheduleDuplicate(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabReservation_.SelectedTab = tabBookingInfo;
                return;
            }

            if (grdSchedules.Rows.Count <= 1)
            {
                MessageBox.Show("Event should have at least one(1) schedule.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabReservation_.SelectedTab = tabBookingInfo;
                return;
            }
  
            if (!(isValidSchedule()))
            {
                MessageBox.Show("Invalid schedule for function rooms.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (bool.Parse(ConfigVariables.gIsEventManagementDisabled) == false)
            {
                if (this.cboSource.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select booking source.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabReservation_.SelectedTab = tabBookingInfo;
                    this.cboSource.SelectAll();
                    return;
                }

                if (this.cboEventType.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select type of event.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabReservation_.SelectedTab = tabBookingInfo;
                    this.cboEventType.SelectAll();
                    return;
                }
            }
            if (this.cboClientType.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select client type.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabReservation_.SelectedTab = tabBookingInfo;
                this.cboClientType.SelectAll();
                return;
            }

            if (this.cboPaymentMode.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select payment mode.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabReservation_.SelectedTab = tabBookingInfo;
                this.cboPaymentMode.SelectAll();
                return;
            }

            if (this.cboMarketSegment.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select market segment.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabReservation_.SelectedTab = tabBookingInfo;
                this.cboMarketSegment.SelectAll();
                return;
            }

            //if (this.cboMarketingOfficer.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please select Marketing Officer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cboMarketingOfficer.Focus();
            //    return;
            //}

            if (this.nudMinPax.Value > this.nudMaxPax.Value)
            {
                MessageBox.Show("Minimum pax should be less than maximum pax.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudMinPax.Focus();
                return;
            }

            foreach (C1.Win.C1FlexGrid.Row grdRows in grdSchedules.Rows)
            {
                if (grdRows.Index != 0)
                {
                    DateTime _startDate = DateTime.Parse(grdSchedules.GetDataDisplay(grdRows.Index, "fromDate"));
                    string _room = grdSchedules.GetDataDisplay(grdRows.Index, "room");
                    DateTime _startTime = DateTime.Parse(grdSchedules.GetDataDisplay(grdRows.Index, "startTime"));
                    DateTime _endDate = DateTime.Parse(grdSchedules.GetDataDisplay(grdRows.Index, "toDate"));
                    DateTime _endTime = DateTime.Parse(grdSchedules.GetDataDisplay(grdRows.Index, "endTime"));
                    for (DateTime _date = _startDate; _date <= _endDate; _date = _date.AddDays(1))
                    {
                        if ((_room != "" && _room != "  ") && (loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _startTime.ToString("HH:mm:ss"), txtControlNo.Text) == true || loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _endTime.ToString("HH:mm:ss"), txtControlNo.Text) == true) && txtStatus.Text != "WAIT LIST")
                        {
                            if (txtStatus.Text != "ONGOING")
                            {
                                if (MessageBox.Show("Conflict in function room schedule: " + _room.ToString() + "\r\nfor Date: " + _date.ToString("yyyy-MM-dd") + " andTime: " + _startTime.ToString("HH:mm") + "-" + _endTime.ToString("HH:mm") + ". \r\n\r\nWARNING: The ENTIRE EVENT ROOMS will be placed under WAIT LIST!! Recommend to delete conflict EVENT SCHEDULE!!\r\nDo you still want to continue and place EVENT in WAIT LIST?", "Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    txtStatus.Text = "WAIT LIST";
                                    loFolio.Status = "WAIT LIST";
                                    this.ttpInfo.SetToolTip(this.btnConfirm, "Set to Tentative");
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Conflict in function room schedule. \r\nPlease check Room Calendar to verify if room is available on that day and time.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    // Filters if wrong date/time heirarchy has been set. Will not save.
                    if (_endTime <= _startTime)
                    {
                        if (_endDate <= _startDate)
                        {
                            MessageBox.Show("Please review Event Schedule Date and Time!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }

            // CODE BELOW IS START OF DATABASE INSERT/UPDATE TRANSACTIONS
            if ((txtCompanyName.Text != "" || txtLastName.Text != "") && txtEventName.Text.Trim() != "")
            {
                if (txtControlNo.Text == "AUTO")
                {
                    lFolioId = loSequence.getSequenceId("F-", 12, "seq_folio");
                    txtControlNo.Text = lFolioId;
                    loFolio.FolioID = lFolioId;
                }

                
                //if (checkChildCheckIn())
                //{
                //    loFolio.Status = "ONGOING";
                //}
                //commented next line for adding groups without child folios
                //by Genny - Apr. 26, 2008
                //MessageBox.Show("No guests in this group yet. Kindly add guests to this group.","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                //if (MessageBox.Show("Are you sure that you want to save this reservation without Dependent Folios?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                try
                {
                    if (lReservationType == ReservationType.NEW)
                    {
                        loFolio.CreateTime = DateTime.Now;
                    }
                    
                    saveGroupFolio(ref _oTransaction);
                    if (bool.Parse(ConfigVariables.gIsEventManagementDisabled) == false)
                    {
                        
                        saveBookingInfo(ref _oTransaction);
                        //saveDependentFolios();
                        saveEventDetails(ref _oTransaction);
                    }
                    //saveChildRoomRequirements(ref _oTransaction);

                    _oTransaction.Commit();

                    AfterSaveAction();
                    MessageBox.Show("Transaction successful. " + "\r\n" + "Event Reservation has been saved", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                    loadFolio();
                    lIsReinstated = false;

                    updateCurrentRoomStatus();
                    this.Text = "Reservation";
                    lUIMode = OperationMode.View;
                }
                catch (Exception ex)
                {
                    _oTransaction.Rollback();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Company and Event name given", "Event Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void grdEventOfficers_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    if (lCanAddEventOfficer)
                    {
                        this.mnuEventOfficersAdd.Enabled = true;
                        this.mnuEventOfficersRemove.Enabled = true;
                    }
                    else
                    {
                        this.mnuEventOfficersAdd.Enabled = false;
                        this.mnuEventOfficersRemove.Enabled = false;
                    }

                    cmsEventOfficers.Show(this.grdEventOfficers, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void mnuEventOfficersAdd_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = grdEventOfficers.Rows.Count;
            grdEventOfficers.Rows.Count++;

            this.grdEventOfficers.SetData(i, 0, "");
            this.grdEventOfficers.SetData(i, 1, "");
            this.grdEventOfficers.SetData(i, 2, "");
            this.grdEventOfficers.SetData(i, 3, "");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lUIMode = OperationMode.Edit;
            btnEdit.Visible = false;
            KeypressTextboxHandler(this, false);
            this.Text = "Reservation*";
        }

        private void mnuEventOfficersRemove_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.grdEventOfficers.Rows.Remove(this.grdEventOfficers.Row);
            }
            catch { }
        }

        private void btnSelectRooms_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (lstRooms.SelectedIndex >= 0)
            {
                AddScheduleUI _addSchedule = new AddScheduleUI();

                _addSchedule.ShowDialog();
                if (!_addSchedule.Confirmed)
                {
                    return;
                }

                foreach(object _item in lstRooms.SelectedItems)
                {
                    mnuSchedulesAdd_Click(grdSchedules, new EventArgs());
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["room"] = _item.ToString();
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 0));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["fromDate"] = _addSchedule.FromDate.Date;
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 2));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["toDate"] = _addSchedule.ToDate.Date;
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 3));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["startTime"] = _addSchedule.StartTime.ToString("hh:mm tt");
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 4));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["endTime"] = _addSchedule.EndTime.ToString("hh:mm tt");
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 5));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["setup"] = _addSchedule.Setup;
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 8));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["activity"] = _addSchedule.Activity;
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 9));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["guaranteedPax"] = _addSchedule.GuaranteedPax;
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 10));
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["remarks"] = _addSchedule.Remarks;
                    grdSchedules_AfterEdit(grdSchedules, new C1.Win.C1FlexGrid.RowColEventArgs(grdSchedules.Rows.Count - 1, 11));
                }
            }
        }

        private void cboRequirementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRequirementType.SelectedValue.ToString() != "")
            {
                lvwRequirementDetails.Items.Clear();
                RequirementCodeFacade _oRequirementCodeFacade = new RequirementCodeFacade();
                GenericList<RequirementCode> _oRequirementCodeList = new GenericList<RequirementCode>();
                _oRequirementCodeList = _oRequirementCodeFacade.getDetailsForRequirements(cboRequirementType.SelectedValue.ToString());
                foreach (RequirementCode _oRequirementCode in _oRequirementCodeList)
                {
                    lvwRequirementDetails.Items.Add(_oRequirementCode.Description);
                }
                lvwRequirementDetails.LabelEdit = true;
            }
            txtRequirementNote.Text = "";
        }

        private void lvwRequirementDetails_DoubleClick(object sender, EventArgs e)
        {
            if (lvwRequirementDetails.SelectedItems.Count > 0)
            {
                lvwRequirementDetails.SelectedItems[0].BeginEdit();
            }
        }

        private void mnuContactPersonsAddNew_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = this.grdContactPersons.Rows.Count;
            this.grdContactPersons.Rows.Count += 1;

            this.grdContactPersons.SetData(i, 0, "");
            this.grdContactPersons.SetData(i, 1, "");
            this.grdContactPersons.SetData(i, 2, "");
            this.grdContactPersons.SetData(i, 3, "");
            this.grdContactPersons.SetData(i, 4, "Contact Person");
            this.grdContactPersons.SetData(i, 5, "");
            this.grdContactPersons.SetData(i, 6, "");
            this.grdContactPersons.SetData(i, 7, "");
            this.grdContactPersons.SetData(i, 8, "");
            this.grdContactPersons.SetData(i, 9, "");
            this.grdContactPersons.SetData(i, 10, "01-01-1900");
            this.grdContactPersons.SetData(i, 11, "AUTO");
            this.grdContactPersons.Cols[4].Editor = lcboPersonType;
            this.grdContactPersons.Cols[10].Editor = ldtpDatePicker;
          
        }

        private void grdContactPersons_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuContactPersonAddFromList.Enabled = true;
                    this.mnuContactPersonsAddNew.Enabled = true;
                    this.mnuContactPersonsRemove.Enabled = true;
                    cmsContactPersons.Show(this.grdContactPersons, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void mnuContactPersonsRemove_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.grdContactPersons.Rows.Remove(this.grdContactPersons.Row);
            }
            catch { }
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                txtAccountID.Text = "";
            }

            if ((lUIMode != OperationMode.View) && txtAccountID.Text == "")
            {
                if (this.txtCompanyName.Text.Trim().Length <= 0)
                {
                    this.lvwCompanies.Visible = false;
                    return;
                }
                else
                {
                    showLookUp(this.txtCompanyName.Text, ref this.txtCompanyName);
                }
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtLastName.Text.Trim().Length <= 0)
            {
                this.lvwGuestNames.Visible = false;
                return;
            }
            else if (this.txtLastName.Text.Trim().Length > 0 && txtLastName.Focused == true)
            {
                showLookUp(this.txtLastName.Text, ref this.txtLastName);
            }
        }

        private void grdEventOfficers_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                string _filter = "";
                for (int i = 1; i < grdEventOfficers.Rows.Count; i++)
                {
                    if (i != grdEventOfficers.Row)
                    {
                        _filter = _filter + "UserId <> '" + grdEventOfficers.GetDataDisplay(i, 2).ToString() + "' and ";
                    }
                }
                if (_filter.Length > 0)
                {
                    _filter = _filter.Substring(0, _filter.Length - 4);
                }

                DataView _dv = loUserList.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = _filter;

                lcboUsers.DropDownStyle = ComboBoxStyle.DropDownList;
                lcboUsers.DataSource = _dv.ToTable();

                if (e.Col == 0)
                {
                    lcboUsers.DisplayMember = "LastName";
                    grdEventOfficers.Cols[0].Editor = lcboUsers;
                }
                if (e.Col == 1)
                {
                    lcboUsers.DisplayMember = "FirstName";
                    grdEventOfficers.Cols[1].Editor = lcboUsers;
                }
            }
            catch { }
        }

        private void grdEventOfficers_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                if (e.Col == 0)
                {
                    DataRowView _dRow = (DataRowView)lcboUsers.SelectedItem;
                    grdEventOfficers.SetData(grdEventOfficers.Row, 1, _dRow["FirstName"].ToString());
                    grdEventOfficers.SetData(grdEventOfficers.Row, 2, _dRow["UserId"].ToString());
                }
                if (e.Col == 1)
                {
                    DataRowView _dRow = (DataRowView)lcboUsers.SelectedItem;
                    grdEventOfficers.SetData(grdEventOfficers.Row, 0, _dRow["LastName"].ToString());
                    grdEventOfficers.SetData(grdEventOfficers.Row, 2, _dRow["UserId"].ToString());
                }
            }
            catch { }
        }

        private void btnBrowseAccount_Click(object sender, EventArgs e)
        {
            if (rdbCompany.Checked)
            {
                if (lUIMode != OperationMode.View)
                {
                    GroupAccountLookUP.AccountType = "COMPANY";
                    GroupAccountLookUP.Flag = "GroupReservation";

                    GroupAccountLookUP groupAccountLookUP = new GroupAccountLookUP(txtCompanyCode, txtCompanyName, txtAccountID, "COMPANY", txtAccountType, txtThresholdValue, txtTotalSalesContribution);
                    groupAccountLookUP.MdiParent = this.MdiParent;
                    groupAccountLookUP.Show();
                }
            }
            else
            {
                if (lUIMode != OperationMode.View)
                {
                    IndividualGuestLookUP guestAccountLookUp = new IndividualGuestLookUP();
                    this.txtAccountID.Text = guestAccountLookUp.showDialogID();
                }
            }
        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountID.Text != "")
            {
                lvwCompanies.Hide();
                lvwGuestNames.Hide();
            }
            else
            {
                txtCompanyName.Text = "";
                txtLastName.Text = "";
                txtFirstName.Text = "";
            }

            try
            {
                if (txtAccountID.Text != "")
                {
                    EventContact oEventContact = new EventContact();
                    if (rdbCompany.Checked)
                    {
                        loCompanyFacade = new CompanyFacade();
                        loCompany = loCompanyFacade.getCompanyAccount(txtAccountID.Text);

                        txtAccountID.Text = loCompany.CompanyId;
                        txtCompanyName.Text = loCompany.CompanyName;
                        txtTINNo.Text = loCompany.TIN;
                        txtStreet.Text = loCompany.Street1;
                        txtCity.Text = loCompany.City1;
                        txtCountry.Text = loCompany.Country1;
                        txtZIP.Text = loCompany.Zip1;
                    }
                    else
                    {
                        loGuestFacade = new GuestFacade();
                        loGuest = loGuestFacade.getGuestRecord(txtAccountID.Text);

                        txtLastName.Text = loGuest.LastName;
                        txtFirstName.Text = loGuest.FirstName;
                        txtPassportID.Text = loGuest.PassportId;
                        txtStreet.Text = loGuest.Street;
                        txtCity.Text = loGuest.City;
                        txtCountry.Text = loGuest.Country;
                        txtZIP.Text = loGuest.Zip;
                    }
                    
                }
            }
            catch { }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwCompanies.Visible && this.lvwCompanies.Items.Count > 0)
                {
                    this.lvwCompanies.Focus();
                    this.lvwCompanies.Items[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (!this.lvwCompanies.Focused)
                {
                    this.lvwCompanies.Visible = false;
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
                    this.txtAccountID.Text = _dRow["CompanyId"].ToString();
                }
                catch { }

                if (this.txtAccountID.Text == "")
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

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwGuestNames.Visible)
                {
                    this.lvwGuestNames.Select();
                }
            }
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwGuestNames.Visible)
                {
                    this.lvwGuestNames.Select();
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



        private void lvwCompanies_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _companyId = this.lvwCompanies.SelectedItems[0].Text;
                string _companyName = this.lvwCompanies.SelectedItems[0].SubItems[1].Text;
                string _companyTIN = this.lvwCompanies.SelectedItems[0].SubItems[2].Text;

                loCompanyFacade = new CompanyFacade();

                Company _oCompany = loCompanyFacade.getCompanyAccount(_companyId);

                this.txtAccountID.Text = _oCompany.CompanyId;
                this.txtCompanyName.Text = _oCompany.CompanyName;
                this.txtTINNo.Text = _oCompany.TIN;
                this.txtStreet.Text = _oCompany.Street1;
                this.txtCity.Text = _oCompany.City1;
                this.txtCountry.Text = _oCompany.Country1;
                this.txtZIP.Text = _oCompany.Zip1;
            }
            catch
            { }

            this.lvwCompanies.Visible = false;
        }

        private void lvwCompanies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lvwCompanies_DoubleClick(sender, new EventArgs());
            }
        }

        private void lvwGuestNames_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string accountId = this.lvwGuestNames.SelectedItems[0].Text;

                if (accountId.Trim().Length > 0)
                {
                    this.txtAccountID.Text = accountId;
                    this.lvwGuestNames.Visible = false;
                }
            }
            catch { }
        }

        private void lvwGuestNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                lvwGuestNames_DoubleClick(sender, new EventArgs());
            }
            else if (e.KeyChar == System.Convert.ToChar(Keys.Escape))
            {
                this.lvwGuestNames.Visible = false;
            }
        }

        private void btnAddRequirements_Click(object sender, EventArgs e)
        {
            if (grdRequirementSchedules.Rows.Count < 2)
            {
                MessageBox.Show("Please add schedules first.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabReservation_.SelectedTab = tabBookingInfo;
                return;
            }

            string _roomID = grdRequirementSchedules.GetDataDisplay(grdRequirementSchedules.Row, 0);
            string _date = grdRequirementSchedules.GetDataDisplay(grdRequirementSchedules.Row, 1);
            string _schedule = _roomID + " : " + _date;

            if (_roomID.Trim() == "")
            {
                MessageBox.Show("Please check the schedule's room id.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabReservation_.SelectedTab = tabBookingInfo;
                return;
            }

            if (txtRequirementNote.Text == "")
            {
                if (cboRequirementType.Text != "")
                {
                    //TreeNode _node = new TreeNode(cboRequirementType.Text);
                    TreeNode _parentNode = new TreeNode(_schedule);
                    TreeNode _childNode = new TreeNode(cboRequirementType.Text);
                    bool _isChecked = false;
                    foreach (ListViewItem _listViewItem in lvwRequirementDetails.Items)
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
                        TreeNode _parentNode = new TreeNode(_schedule);
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

        private void grdSchedules_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            DateTime TimeTo = DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, "endTime"));
            if (e.Col == 2 || e.Col == 3)
            {
                if (DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, e.Col)) < DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    MessageBox.Show("Cannot change to selected date. \nEither date is already charged or is less than the current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdSchedules.SetData(e.Row, e.Col, DateTime.Parse(GlobalVariables.gAuditDate));
                }
                else
                {
                    ldtpFromDate.Value = DateTime.Parse(grdSchedules.GetDataDisplay(1, "fromDate"));
                    ldtpToDate.Value = DateTime.Parse(grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 1, "toDate"));
                    //txtArrivalDate.Text = dtpFromDate.Value.ToShortDateString();
                    //txtDepartureDate.Text = dtpTodate.Value.ToShortDateString();

                    ////for changing of event package dates
                    //foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
                    //{
                    //    if (_row.Index != 0)
                    //    {
                    //        if (grdRecurredCharge.GetCellCheck(_row.Index, 0) == CheckEnum.Checked)
                    //        {
                    //            grdRecurredCharge.SetData(_row.Index, 11, dtpFromDate.Value);
                    //            grdRecurredCharge.SetData(_row.Index, 12, dtpFromDate.Value);
                    //        }
                    //    }
                    //}
                }
            }
            if ((e.Col == 4 || e.Col == 5) && (DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, 2)) == DateTime.Parse(GlobalVariables.gAuditDate)))// && DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, 3)) == DateTime.Parse(GlobalVariables.gAuditDate)))
            {
                if (DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, e.Col)) < DateTime.Now)
                {
                    MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current date/time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdSchedules.SetData(e.Row, e.Col, DateTime.Now.ToShortTimeString());
                }
            }
            else if (e.Col == 6)
            {
                RateTypeFacade _oRateTypeFacade = new RateTypeFacade();
                string _rateType = grdSchedules.GetDataDisplay(e.Row, e.Col);
                decimal _amount = _oRateTypeFacade.getRateTypeAmount(_rateType, grdSchedules.GetDataDisplay(e.Row, "roomTypeCode"));
                grdSchedules.SetData(e.Row, "amount", _amount);
            }
            else if (e.Col == 0)
            {
                try
                {
                    Room _oRoom = new Room();
                    RoomFacade _oRoomFacade = new RoomFacade();
                    _oRoom = _oRoomFacade.getRoom(grdSchedules.GetDataDisplay(e.Row, 0));
                    grdSchedules.SetData(e.Row, "roomTypeCode", _oRoom.RoomTypecode);
                    grdSchedules.SetData(e.Row, "venueName", _oRoom.RoomDescription);
                    //gridFunctionRooms.SetData(e.Row, 12, _oRoom.RoomTypecode);
                }
                catch { }
            }

            if (e.Col == 2)
            {
                try
                {
                    grdSchedules.SetData(e.Row, 3, grdSchedules.GetData(e.Row, e.Col));
                }
                catch { }
            }

          
            //addMeallDates();	
            //Gene - 9/8/2011
            grdSchedules.AutoSizeCol(1);
            grdSchedules.AutoSizeCol(2);
            grdSchedules.AutoSizeRows();
            //Kevin Oliveros 2014-02-12
            //grdSchedules.Sort(SortFlags.Ascending, 2, 4);
        }

        private void grdSchedules_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                RoomFacade _oRoomFacade = new RoomFacade();
                ArrayList _roomList = new ArrayList();
                _roomList = _oRoomFacade.getRoomsByRoomSuperType("FUNCTION");
                _roomList.Insert(0, "  ");
                lcboRooms.DisplayMember = "RoomID";
                lcboRooms.ValueMember = "RoomID";
                lcboRooms.DataSource = _roomList;
                lcboRooms.DropDownStyle = ComboBoxStyle.DropDownList;

                grdSchedules.Cols[e.Col].Editor = lcboRooms;
            }
            else if (e.Col == 2 || e.Col == 3)
            {
                /*
                DateFrom = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 3));
                DateTo = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 4));
                */
            }
            else if (e.Col == 4 || e.Col == 5)
            {
                grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;

                //TimeFrom = DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, 2));
                //TimeTo = DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, 3));

                //if (DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, 3)) <= DateTime.Parse(grdSchedules.GetDataDisplay(e.Row, 2)))
                //{
                //    MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //    e.Cancel = true;
                //}
            }

            else if (e.Col == 6)
            {
                //lcboRateTypes.Items.Clear();
                //>>to display all rate types
                RateTypeFacade _oRateTypeFacade = new RateTypeFacade();
                //IList<RateType> _oRateTypeList = _oRateTypeFacade.getRateTypeList();
                //foreach (RateType _oRateType in _oRateTypeList)
                //{
                //    string type = grdSchedules.GetDataDisplay(e.Row, "roomTypeCode");
                //    if (_oRateType.RoomTypeCode == type)
                //    {
                //        lcboRateTypes.Items.Add(_oRateType.RateCode);
                //    }
                //}

                DataTable _dtRates = _oRateTypeFacade.getRateTypes();
                DataView _dtvRates = _dtRates.DefaultView;
                _dtvRates.RowStateFilter = DataViewRowState.OriginalRows;
                _dtvRates.RowFilter = "roomtypecode = '" + grdSchedules.GetDataDisplay(e.Row, "roomTypeCode") + "' and roomID = '" + grdSchedules.GetDataDisplay(e.Row, "room") + "'";

                lcboRateTypes.DisplayMember = "ratecode";
                lcboRateTypes.ValueMember = "ratecode";

                lcboRateTypes.DataSource = _dtvRates.ToTable();

                grdSchedules.Cols[e.Col].Editor = lcboRateTypes;
            }
            else if (e.Col == 8)
            {
                grdSchedules.Cols[e.Col].Editor = lcboSetups;
            }
            else if (e.Col == 9)
            {
                grdSchedules.Cols[e.Col].Editor = lcboActivities;
            }
            else if (e.Col == 10)
            {
                grdSchedules.Cols[e.Col].Editor = nudGuaranteedPax;
            }      
            else if (e.Col == 12)
            {
                grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;
            }
            else if (e.Col == 13)
            {
                grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;
            }
        }

        private void grdSchedules_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                grdRequirementSchedules.Rows.Count = 1;
                grdNewAmendment.Rows.Count = 1;

                foreach (C1.Win.C1FlexGrid.Row _oRow in grdSchedules.Rows)
                {
                    if (_oRow.Index > 0)
                    {
                        string _roomID = grdSchedules.GetDataDisplay(_oRow.Index, "room");// +" [" + grdSchedules.GetDataDisplay(_oRow.Index, 2) + "]";
                        string _fromDate = grdSchedules.GetDataDisplay(_oRow.Index, "fromDate");
                        string _toDate = grdSchedules.GetDataDisplay(_oRow.Index, "toDate");
                        string _startTime = grdSchedules.GetDataDisplay(_oRow.Index, "startTime");
                        string _endTime = grdSchedules.GetDataDisplay(_oRow.Index, "endTime");

                        if (DateTime.Parse(_endTime) <= DateTime.Parse(_startTime))
                        {
                            if (DateTime.Parse(_toDate) <= DateTime.Parse(_fromDate))
                            {
                                MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }

                        grdRequirementSchedules.Rows.Count++;
                        grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 0, _roomID);
                        grdRequirementSchedules[grdRequirementSchedules.Rows.Count - 1, 1] = lcboReqDates;
                        grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 1, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_fromDate)));

                        grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 2, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_fromDate)));
                        grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 3, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_toDate)));

                        grdNewAmendment.Rows.Count++;
                        grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 0, _roomID);
                        grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 1, _fromDate);
                        grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 2, _toDate);
                        grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 3, _startTime);
                        grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 4, _endTime);
                    }
                }
            }
            catch { }

            if (e.Col == 0)
            {
                try
                {
                    Room _oRoom = new Room();
                    RoomFacade _oRoomFacade = new RoomFacade();
                    _oRoom = _oRoomFacade.getRoom(grdSchedules.GetDataDisplay(e.Row, 0));
                }
                catch { }
            }
        }

        private void grdSchedules_ChangeEdit(object sender, EventArgs e)
        {
            using (Graphics _oGraphics = grdSchedules.CreateGraphics())
            {
                // measure text height
                StringFormat _stringFormat = new StringFormat();
                int _width = grdSchedules.Cols[grdSchedules.Col].WidthDisplay - 2;
                string _text = grdSchedules.Editor.Text;
                SizeF _sizeF = _oGraphics.MeasureString(_text, grdSchedules.Font, _width, _stringFormat);

                // adjust row height if necessary
                C1.Win.C1FlexGrid.Row _oC1Row = grdSchedules.Rows[grdSchedules.Row];
                if (_sizeF.Height + 4 > _oC1Row.HeightDisplay)
                    _oC1Row.HeightDisplay = (int)_sizeF.Height + 4;
            }
        }

        private void grdSchedules_GridChanged(object sender, C1.Win.C1FlexGrid.GridChangedEventArgs e)
        {
            try
            {
                ldtpFromDate.Value = DateTime.Parse(grdSchedules.GetDataDisplay(1, "fromDate"));
                ldtpToDate.Value = DateTime.Parse(grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 1, "toDate"));
                //txtArrivalDate.Text = dtpFromDate.Value.ToShortDateString();
                //txtDepartureDate.Text = dtpTodate.Value.ToShortDateString();

                //dtpFolioETA.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 5));
                //dtpFolioETD.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 6));
            }
            catch { }
        }

        private void grdSchedules_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {

                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuSchedulesAdd.Enabled = true;
                    this.mnuSchedulesDelete.Enabled = true;
                    cmsSchedules.Show(this.grdSchedules, point);

                    //Kevin Oliveros 2014-02-12
                    if (lCopySchedules.Rows.Count < 1)
                    {
                        pasteScheduleToolStripMenuItem.Enabled = false;

                    }
                    else
                    {
                        pasteScheduleToolStripMenuItem.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
                pasteScheduleToolStripMenuItem.Enabled = false;
            }
        }


        private void grdSchedules_RowColChange(object sender, EventArgs e)
        {
            grdSchedules.AutoSizeRows();
        }

        private void grdSchedules_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            switch (e.Col)
            {
                case 4:
                    ldtpTimePicker.Value = DateTime.Parse("08/08/2008 08:00:00 AM");

                    grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;
                    break;
                case 5:
                    ldtpTimePicker.Value = DateTime.Parse("08/08/2008 05:00:00 PM");

                    grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;
                    break;

                case 8:
                    grdSchedules.Cols[e.Col].Editor = lcboSetups;
                    break;
                case 12:
                    ldtpTimePicker.Value = DateTime.Parse("08/08/2008 06:00:00 AM");

                    grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;
                    break;
                case 13:
                    ldtpTimePicker.Value = DateTime.Parse("08/08/2008 08:00:00 AM");

                    grdSchedules.Cols[e.Col].Editor = ldtpTimePicker;
                    break;
                default:
                    break;
            }
        }

        private void mnuSchedulesAdd_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime fromDate = DateTime.Parse(GlobalVariables.gAuditDate);
            DateTime toDate = fromDate.AddDays(1);

            int i = this.grdSchedules.Rows.Count;
            this.grdSchedules.Rows.Count += 1;

            this.grdSchedules.Cols["setup"].Editor = lcboSetups;
            this.grdSchedules.Cols["activity"].Editor = lcboActivities;

            // set folio schedule grid
            if (grdSchedules.Rows.Count <= 2)
            {
                this.grdSchedules.SetData(i, "room", ""); // room no
                this.grdSchedules.SetData(i, "roomTypeCode", "FUNCTION"); //room type
                this.grdSchedules.SetData(i, "venueName", ""); //room name
                this.grdSchedules.SetData(i, "fromDate", fromDate.Date); //from date
                this.grdSchedules.SetData(i, "toDate", toDate.Date); //end date
                this.grdSchedules.SetData(i, "startTime", "08:00 AM"); // time start
                this.grdSchedules.SetData(i, "endTime", "05:00 PM"); // time end
                this.grdSchedules.SetData(i, "rateType", "REGULAR"); // rate type
                this.grdSchedules.SetData(i, "amount", 0.00); // rate amount
                this.grdSchedules.SetData(i, "guaranteedPax", "0");// guaranteed pax
                this.grdSchedules.SetData(i, "remarks", "");//remarks
                this.grdSchedules.SetData(i, "SetUpStart", "06:00 AM"); // time start
                this.grdSchedules.SetData(i, "SetUpEnd", "08:00 AM"); // time end
            }
            else
            {
                this.grdSchedules.SetData(i, "room", ""); // room no
                this.grdSchedules.SetData(i, "roomTypeCode", "FUNCTION"); //room type
                this.grdSchedules.SetData(i, "venueName", ""); //room name
                this.grdSchedules.SetData(i, "fromDate", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "fromDate")); //from date
                this.grdSchedules.SetData(i, "toDate", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "toDate")); //end date
                this.grdSchedules.SetData(i, "startTime", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "startTime")); // time start
                this.grdSchedules.SetData(i, "endTime", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "endTime")); // time end
                this.grdSchedules.SetData(i, "rateType", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "rateType")); // rate type
                this.grdSchedules.SetData(i, "amount", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "amount")); // rate amount
                this.grdSchedules.SetData(i, "setup", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "setup"));// setup
                this.grdSchedules.SetData(i, "activity", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "activity"));// remarks or activity
                this.grdSchedules.SetData(i, "guaranteedPax", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "guaranteedPax"));// guaranteed pax
                this.grdSchedules.SetData(i, "remarks", grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 2, "remarks"));//remarks
                this.grdSchedules.SetData(i, "SetUpStart", "06:00 AM"); // time start
                this.grdSchedules.SetData(i, "SetUpEnd", "08:00 AM"); // time end
            }

        }
        private string checkScheduleDuplicate()
        {
            
           // bool _flag = false;
            int _count = 0;
            int _countExisting = 0;
            string _str = "";
            foreach(C1.Win.C1FlexGrid.Row _row in grdSchedules.Rows)
            {
                if (_count != 0)
                {
                    foreach (C1.Win.C1FlexGrid.Row _rowSub in grdSchedules.Rows)
                    {

                        if (_row["room"].ToString() == _rowSub["room"].ToString())
                        {
                            if ((DateTime.Parse(_row["fromDate"].ToString()).Date >= DateTime.Parse(_rowSub["fromDate"].ToString()).Date &&
                                DateTime.Parse(_row["toDate"].ToString()).Date <= DateTime.Parse(_rowSub["toDate"].ToString()).Date)
                                ||
                                (DateTime.Parse(_row["fromDate"].ToString()) >= DateTime.Parse(_rowSub["fromDate"].ToString()) &&
                                DateTime.Parse(_row["toDate"].ToString()) <= DateTime.Parse(_rowSub["toDate"].ToString()))

                                )
                            {
                                if ((DateTime.Parse(_row["startTime"].ToString()) > DateTime.Parse(_rowSub["startTime"].ToString()) &&
                                    DateTime.Parse(_row["startTime"].ToString()) <DateTime.Parse(_rowSub["endTime"].ToString()))
                                    ||
                                   (DateTime.Parse(_row["endTime"].ToString()) > DateTime.Parse(_rowSub["startTime"].ToString()) &&
                                    DateTime.Parse(_row["endTime"].ToString()) < DateTime.Parse(_rowSub["endTime"].ToString()))
                                    )
                                {
                                   // return true;
                                    _str = "Row#" + Convert.ToString(_row.Index)+ "  " + _row["room"].ToString() + " " + _row["startTime"].ToString() + " " + _row["endTime"].ToString();
                                    return _str;
                                    break;

                                }
                                if (DateTime.Parse(_row["startTime"].ToString()) == DateTime.Parse(_rowSub["startTime"].ToString()) ||
                                 DateTime.Parse(_row["endTime"].ToString()) == DateTime.Parse(_rowSub["endTime"].ToString()))
                                {
                                    _countExisting++;
                                    if (_countExisting > 1)
                                    {
                                        //return true;
                                        _str = "Row#" + Convert.ToString(_row.Index) + "  " + _row["room"].ToString() + " " + _row["startTime"].ToString() + " " + _row["endTime"].ToString();
                                        return _str;
                                        break;
                                    }

                                }
                            }
                         
                        }

                    }
                    _countExisting = 0;
                }
                _count++;
            }
            return _str;
        }

        private void mnuSchedulesDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lUIMode == OperationMode.View)
                {
                    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!loFolio.Status.Equals(""))
                {
                    if(MessageBox.Show("Continue to remove this venue?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No )
                    {
                        return;
                    }
                }


                if (grdSchedules.Rows.Count <= 2)
                {
                    MessageBox.Show("Reservation should have at least one schedule.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    grdSchedules.Rows.Remove(grdSchedules.Row);
                    updateSchedules();
                }
            }
            catch { }
        }

        private void btnRemoveRequirements_Click(object sender, EventArgs e)
        {
            try
            {
                treeRequirements.SelectedNode.Remove();
            }
            catch { }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

            String _rStatus = "";
            _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;

            int _newStatus = getIndex("CONFIRMED", aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                MessageBox.Show("Cannot confirmed reservation because it is already " + _rStatus + ".\nPlease close this reservation form for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grdSchedules.Rows.Count <= 1)
            {
                FolioFacade _oFolioFacade = new FolioFacade();
                _oFolioFacade.confirmFolio(loFolio.FolioID, ref _oDBTrans);
                MessageBox.Show("Event should have at least one(1) schedule.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabReservation_.SelectedTab = tabBookingInfo;
                return;
            }

            if (!(isValidSchedule()))
            {
                MessageBox.Show("Invalid schedule for function rooms.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //>> check if there is conflict with other reservations
            foreach (C1.Win.C1FlexGrid.Row grdFolioRows in grdSchedules.Rows)
            {
                if (grdFolioRows.Index != 0)
                {
                    DateTime _startDate = DateTime.Parse(grdSchedules.GetDataDisplay(grdFolioRows.Index, "fromDate"));
                    string _room = grdSchedules.GetDataDisplay(grdFolioRows.Index, "room");
                    DateTime _startTime = DateTime.Parse(grdSchedules.GetDataDisplay(grdFolioRows.Index, "startTime"));
                    DateTime _endDate = DateTime.Parse(grdSchedules.GetDataDisplay(grdFolioRows.Index, "toDate"));
                    DateTime _endTime = DateTime.Parse(grdSchedules.GetDataDisplay(grdFolioRows.Index, "endTime"));
                    for (DateTime _date = _startDate; _date <= _endDate; _date = _date.AddDays(1))
                    {
                        if ((_room != "" && _room != "  ") && (loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _startTime.ToString("HH:mm:ss"), txtControlNo.Text) == true || loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _endTime.ToString("HH:mm:ss"), txtControlNo.Text) == true))
                        {
                            MessageBox.Show("Cannot confirm reservation.\nConflict in function room schedule.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }


            //check if contract amount has been endorsed from marketing
            // Clark 08.10.2011
            //if (txtContractAmount.Value <= 0)
            //{
            //    MessageBox.Show("Reservation is not yet endorsed by Marketing!", "Endorsement Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            DialogResult rsp;
            if (ConfigVariables.gDefaultStatusForNewReservation == "TENTATIVE" && loFolio.Status == "WAIT LIST")
            {
                rsp = MessageBox.Show("Are you sure you want to set this reservation to Tentative?",
                       "Confirm",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2);
            }
            else
            {
                rsp = MessageBox.Show("Are you sure you want to set this reservation to Confirmed?",
                                       "Confirm",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2);
            }
            if (rsp == DialogResult.No)
            {
                return;
            }

            try
            {
                if (ConfigVariables.gDefaultStatusForNewReservation == "TENTATIVE" && loFolio.Status == "WAIT LIST")
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oDBTrans);
                    loFolioFacade.tentativeFolio(loFolio.FolioID, ref _oDBTrans);
                    _oDBTrans.Commit();
                    MessageBox.Show("Transaction successful.\r\nReservation status is now Tentative.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    txtStatus.Text = "TENTATIVE";
                }
                else
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oDBTrans);
                    loFolioFacade.confirmFolio(loFolio.FolioID, ref _oDBTrans);
                    loFolioFacade.setReferencNo(loFolio.FolioID, loFolio.FromDate.Month, loFolio.FromDate.Year, GlobalVariables.gHotelId);
                    _oDBTrans.Commit();

                    loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                    txtReferenceNo.Text = loFolio.ReferenceNo;
                    txtStatus.Text = "CONFIRMED";

                    if (ConfigVariables.gSAPServer != "")
                    {
                        SAPCompany _oSapCompany = new SAPCompany();
                        //if (_oSapCompany.SAPConnect(ConfigVariables.gSAPServer,
                        //                            ConfigVariables.gSAPCompanyDB,
                        //                            ConfigVariables.gSAPDBUsername,
                        //                            ConfigVariables.gSAPDBPassword,
                        //                            ConfigVariables.gSAPUsername,
                        //                            ConfigVariables.gSAPPassword))
                        //{
                        if(GlobalVariables.goIsConnectedToBackOffice == true)
                        {
                           // MessageBox.Show("Unable to connect to SAP Server!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           // return false;
                          _oSapCompany.addUDFTableEventPlus(loFolio.FolioID,
                                                    loFolio.GroupName,
                                                    loFolio.CompanyID,
                                                    ((rdbCompany.Checked ==true)? txtCompanyName.Text:txtFirstName.Text+" "+txtLastName.Text),
                                                    loFolio.FromDate.ToString(),
                                                    loFolio.Todate.ToString());
                        }
                      

                        //try
                        //{
                        //    addon _integration;

                        //    if (ConfigVariables.gSAPDBUsername != "" && ConfigVariables.gSAPDBPassword != "" && ConfigVariables.gSAPCompanyDB != "" && ConfigVariables.gSAPUsername != "" && ConfigVariables.gSAPPassword != "")
                        //    {
                        //        _integration = new addon(ConfigVariables.gSAPServer, ConfigVariables.gSAPDBUsername, ConfigVariables.gSAPDBPassword, ConfigVariables.gSAPCompanyDB, ConfigVariables.gSAPUsername, ConfigVariables.gSAPPassword);
                        //    }
                        //    else
                        //    {
                        //        _integration = new addon(ConfigVariables.gSAPServer);
                        //    }
                        //    string _error = "";
                        //    try
                        //    {
                        //        string _cardCode = "";
                        //        if (rdbCompany.Checked)
                        //        {
                        //            _error = "Integration.eventPlusToSAPB1_BP(" + txtCompanyName.Text + ");";
                        //            //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            _cardCode = _integration.eventPlusToSAPB1_BP(txtCompanyName.Text);
                        //            //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //        else
                        //        {
                        //            _error = "Integration.eventPlusToSAPB1_BP(" + txtLastName.Text + ", " + txtFirstName.Text + ");";
                        //            //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            _cardCode = _integration.eventPlusToSAPB1_BP(txtLastName.Text + ", " + txtFirstName.Text);
                        //            //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //        if (_cardCode != "")
                        //        {
                        //            EnterAmountUI _oEnterAmount = new EnterAmountUI();
                        //            _oEnterAmount.Text = "Enter Contract Amount";
                        //            _oEnterAmount.ShowDialog();

                        //            _error = "Integration.eventPlusToSAPB1_SO(" + _cardCode + ", " + loFolio.CreateTime + ", " + txtReferenceNo.Text + ", " + loFolio.FromDate + ", " + loFolio.Todate + ", " + txtControlNo.Text + ", " + txtEventName.Text + ", " + txtAccountID.Text + ", " + getRoomsForIntegration(0) + ", " + getRoomsForIntegration(1) + ", " + _oEnterAmount.Amount + ")";

                        //            if (!_oEnterAmount.Success)
                        //                throw new Exception("No Contract amount entered.");

                        //            //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            if (!_integration.eventPlusToSAPB1_SO(_cardCode, loFolio.CreateTime, txtReferenceNo.Text, loFolio.FromDate, loFolio.Todate, txtControlNo.Text, txtEventName.Text, txtAccountID.Text, getRoomsForIntegration(0), getRoomsForIntegration(2), _oEnterAmount.Amount))
                        //            {
                        //                MessageBox.Show("Sales Order for SAP integration failed. Please check settings for integration.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            }
                        //            //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("SAP Integration did not return a cardcode value.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //        _integration.Dispose();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        _integration.Dispose();
                        //        MessageBox.Show("There was a problem with SAP integration\r\nMethod: " + _error + "\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Unable to connect to SAP Server for integration.\r\n Please check the server IP settigns in Event Plus.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
                MessageBox.Show("Transaction successful.\r\nReservation status is now Confirmed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                setButtons();

            }
            catch (Exception ex)
            {
                _oDBTrans.Rollback();

                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void btnUnconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtStatus.Text.Trim().ToUpper().Equals("CONFIRMED"))
                {
                    return;
                }

                loEventFacade = new EventFacade();

                if (MessageBox.Show("This action will set the reservation back to Tentative. Are you sure?", "Unconfirm Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (loEventFacade.unconfirmEventReservation(txtControlNo.Text))
                {
                    MessageBox.Show("Unconfirm successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStatus.Text = "TENTATIVE";
                    txtReferenceNo.Text = "";
                    setButtons();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem unconfirming the Event Reservation.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartEvent_Click(object sender, EventArgs e)
        {
            String _rStatus = "";
            _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;

            int _newStatus = getIndex("ONGOING", aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                MessageBox.Show("Cannot check in reservation because it is already " + _rStatus + ".\nPlease close this reservation form for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtStatus.Text == "WAIT LIST" || txtStatus.Text == "TENTATIVE")
            {
                MessageBox.Show("Cannot check-in reservation. \nStatus is " + txtStatus.Text + ".\n\nYou must confirm reservation first before checking-in.", "Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DateTime.Parse(loFolio.FromDate.ToString("yyyy-MM-dd")) <= DateTime.Parse(GlobalVariables.gAuditDate))
            {
                DialogResult rsp = MessageBox.Show("Event Status will now be ONGOING.\r\n\r\nAre you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool _isCheckedIn = false;

                if (rsp == DialogResult.Yes)
                {
                    FolioFacade _oFolioFacade = new FolioFacade();
                    string _folioNo = txtControlNo.Text;
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
                    lReservationType = ReservationType.OLD;
                    loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                    ReservationUI_Load(null, new EventArgs());
                    txtStatus.Text = "ONGOING";

                    updateCurrentRoomStatus();
                    setButtons();
                }
            }
            else
            {
                MessageBox.Show("Event date is greater than the current audit date.\r\n Change first the event dates of the group before check in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEndEvent_Click(object sender, EventArgs e)
        {
            FolioFacade _oFolioFacade = new FolioFacade();
            FolioTransactions _oFolioTransaction = new FolioTransactions();
            _oFolioTransaction = _oFolioFacade.GetFolioTransactions(txtControlNo.Text, "A");

            if (loEventFacade.isGroupPackagePosted(txtControlNo.Text) == false)
            {
                PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
                if (oPostRoomChargeFacade.initializePostRoomCharges(txtControlNo.Text) == true)
                {
                    MessageBox.Show("Posting transactions successful. ", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Transactions are already posted for the day. ", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            CheckOutUI _oCheckOutUI = new CheckOutUI(loFolio.FolioID, txtEventName.Text);
            _oCheckOutUI.MdiParent = this.MdiParent;
            _oCheckOutUI.Show();
        }

        private void btnPostCharges_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want to Post Charges for this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            //PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();

            //if (oPostRoomChargeFacade.PostGroupCharges(dtpPostingDate.Value, txtControlNo.Text) == true)
            //{
            //    MessageBox.Show("Posting transactions successful. ", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtControlNo.Text);
            //    _oFolioLedgerUI.MdiParent = this.MdiParent;
            //    _oFolioLedgerUI.Show();
            //}
        }

        private void btnReinstate_Click(object sender, EventArgs e)
        {
            //GroupReservationUI.Flag = "New";
            
            ReservationUI _ReservationUI = new ReservationUI(loFolio);
           
            _ReservationUI.MdiParent = this.MdiParent;
            _ReservationUI.Show();
            this.Close();
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

        private void btnCharges_Click(object sender, EventArgs e)
        {
            if (loFolio.FolioID != "")
            {
                string _currentRoomNo = loFolioFacade.GetCurrentRoomOccupied(loFolio.FolioID, "INDIVIDUAL");

                FolioLedgerUI lFolioLedgerUI = new FolioLedgerUI(loFolio.FolioID, _currentRoomNo, this);
                lFolioLedgerUI.MdiParent = this.MdiParent;
                lFolioLedgerUI.Show();
            }
        }

        private void btnAmendmentMove_Click(object sender, EventArgs e)
        {
            if (btnNewAmendment.Text.ToUpper().Trim() == "NEW")
            {
                MessageBox.Show("Please create a new amendment first", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                int _row = grdNewAmendment.Row;
                string _sched = grdNewAmendment.GetDataDisplay(_row, 0) + " (" + grdNewAmendment.GetDataDisplay(_row, 1) + " - " + grdNewAmendment.GetDataDisplay(_row, 2) + ")";
                txtOldEntry.AppendText(_sched);

            }
            catch { }
        }

        private void btnNewAmendment_Click(object sender, EventArgs e)
        {
            if (btnNewAmendment.Text.ToUpper().Trim() == "NEW")
            {
                //btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.close16;
                grpNewAmendment.Enabled = true;
                this.btnNewAmendment.Text = "    Cancel";
                //pnlNew.Enabled = false;
                //pnlStatus.Enabled = false;
                //pnlFolio.Enabled = false;
                btnAmendmentMove.Enabled = true;
                btnPrintAmendments.Enabled = false;
                btnSaveAmendment.Enabled = true;
                txtAmendmentNo.Text = "TO BE AMENDED";
            }
            else
            {
                //btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.add16;
                grpNewAmendment.Enabled = false;
                //pnlNew.Enabled = true;
                //pnlStatus.Enabled = true;
                //pnlFolio.Enabled = true;
                btnPrintAmendments.Enabled = true;
                btnAmendmentMove.Enabled = false;
                this.btnNewAmendment.Text = "    New";
                btnSaveAmendment.Enabled = false;

                //clear text
                txtAmendmentNo.Text = "";
                txtOldEntry.Text = "";
                txtNewEntry.Text = "";
            }
        }

        private void btnSaveAmendment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this contract amendment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtNewEntry.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the new value.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNewEntry.Focus();
                    return;
                }

                if (txtOldEntry.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the old value.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtOldEntry.Focus();
                    return;
                }

                ContractAmendments _oAmendment = new ContractAmendments();
                ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();

                _oAmendment.AmendmentID = txtAmendmentNo.Text;
                _oAmendment.FolioID = txtControlNo.Text;
                _oAmendment.NewValue = txtNewEntry.Text;
                _oAmendment.OldValue = txtOldEntry.Text;
                _oAmendmentFacade.saveAmendment(ref _oAmendment);

                //add to grid amendments
                grdRequestedAmendments.Rows.Count++;
                grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 0, _oAmendment.AmendmentID);
                grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 1, _oAmendment.OldValue);
                grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 2, _oAmendment.NewValue);
                grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 3, _oAmendment.ID);
                grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 4, GlobalVariables.gLoggedOnUser);
                grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 5, DateTime.Now);
                //disable/enable controls
                grpNewAmendment.Enabled = false;
                //pnlNew.Enabled = true;
                //pnlStatus.Enabled = true;
                //pnlFolio.Enabled = true;
                btnPrintAmendments.Enabled = true;
                this.btnNewAmendment.Text = "    New";
                btnSaveAmendment.Enabled = false;

                //clear text
                txtAmendmentNo.Text = "";
                txtOldEntry.Text = "";
                txtNewEntry.Text = "";

                //sort by amendment id ascending
                grdRequestedAmendments.Sort(SortFlags.Ascending, 0);
                grdRequestedAmendments.AutoSizeRows();

                //btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.add16;
            }
            else
            {
                return;
            }
        }

        private void btnPrintAmendments_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getContractAmendments(txtControlNo.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        
        }

        private void btnPrintScheduleChanges_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getSystemChanges(txtControlNo.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        }

        private void mnuContactPersonAddFromList_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ContactPerson _oContactPerson = new ContactPerson();
            DataTable _dt = _oContactPerson.getContactPersons(txtAccountID.Text, GlobalVariables.gHotelId);
            grdContactList.Rows.Count = 1;

            int _row = 1;
            bool _found = false;
            foreach (DataRow _dRow in _dt.Rows)
            {

                for (int i = 0; i < grdContactPersons.Rows.Count; i++)
                {
                    if (_dRow["contactID"].ToString() == grdContactPersons.GetDataDisplay(i, "contactid").ToString())
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
                grdContactList.Rows.Count++;
                grdContactList.SetData(_row, 1, _dRow["contactID"]);
                grdContactList.SetData(_row, 2, _dRow["lastName"]);
                grdContactList.SetData(_row, 3, _dRow["firstName"]);
                grdContactList.SetData(_row, 4, _dRow["middleName"]);
                grdContactList.SetData(_row, 5, _dRow["designation"]);
                grdContactList.SetData(_row, 6, _dRow["personType"]);
                grdContactList.SetData(_row, 7, _dRow["address"]);
                grdContactList.SetData(_row, 8, _dRow["telNo"]);
                grdContactList.SetData(_row, 9, _dRow["mobileNo"]);
                grdContactList.SetData(_row, 10, _dRow["faxNo"]);
                grdContactList.SetData(_row, 11, _dRow["email"]);
                grdContactList.SetData(_row, 12, _dRow["birthdate"]);
                _row++;
            }
            pnlContactList.BringToFront();
            pnlContactList.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Kevin Oliveros 
            //2014-01-14
            for (int _row = 1; _row < grdContactList.Rows.Count; _row++)
            {
                if (grdContactList.GetCellCheck(_row, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    grdContactPersons.Rows.Count++;
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 11, grdContactList.GetDataDisplay(_row, 1));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 0, grdContactList.GetDataDisplay(_row, 2));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 1, grdContactList.GetDataDisplay(_row, 3));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 2, grdContactList.GetDataDisplay(_row, 4));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 3, grdContactList.GetDataDisplay(_row, 5));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 4, grdContactList.GetDataDisplay(_row, 6));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 5, grdContactList.GetDataDisplay(_row, 7));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 6, grdContactList.GetDataDisplay(_row, 8));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 7, grdContactList.GetDataDisplay(_row, 9));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 8, grdContactList.GetDataDisplay(_row, 10));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 9, grdContactList.GetDataDisplay(_row, 11));
                    grdContactPersons.SetData(grdContactPersons.Rows.Count - 1, 10, grdContactList.GetDataDisplay(_row, 12));
                    //string [] _object = {grdContactList.GetDataDisplay(_row, 2),
                    //    grdContactList.GetDataDisplay(_row, 3),grdContactList.GetDataDisplay(_row, 4),grdContactList.GetDataDisplay(_row, 5),
                    //    grdContactList.GetDataDisplay(_row, 6),grdContactList.GetDataDisplay(_row, 7),grdContactList.GetDataDisplay(_row, 8),
                    //    grdContactList.GetDataDisplay(_row, 9),grdContactList.GetDataDisplay(_row, 10),grdContactList.GetDataDisplay(_row, 11),
                    //    grdContactList.GetDataDisplay(_row, 1)};
                    //grdContactPersons.AddItem(_object);

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

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            mnuSchedulesAdd_Click(grdSchedules, new EventArgs());
        }
        private void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            mnuSchedulesDelete_Click(grdSchedules, new EventArgs());
        }

        private void btnReservationForm_Click(object sender, EventArgs e)
        {
             
            //Kevin Oliveros 2014-14-01
            //ReportFacade _oReportFacade = new ReportFacade();
            //Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            ////if (btnPrintContract.Text == "Contract")
            ////{
            ////this.MdiParent.Cursor = Cursors.WaitCursor;

            //bool _isBanquet = false;
            //EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
            //_isBanquet = _oEventTypeFacade.isBanquetType(cboEventType.Text.ToUpper());

            //string _isAlpa = ConfigVariables.gContractType;

            //if (_isBanquet == true && _isAlpa == "STANDARD")
            //{
            //    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtControlNo.Text, txtEventName.Text, ConfigVariables.gReportOrganization);
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();

            //    setDatabaseLogOn();
            //    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            //    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract();
            //    banquetContract = _oReportFacade.getBanquetEventContract(txtControlNo.Text);
            //    banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
            //    oReportViewerUI.rptViewer.ReportSource = banquetContract;
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();
            //}
            //else if (_isBanquet == false && _isAlpa == "STANDARD")
            //{
            //    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtControlNo.Text, txtEventName.Text, ConfigVariables.gReportOrganization);
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();

            //    setDatabaseLogOn();
            //    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            //    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomReservationContract roomContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomReservationContract();
            //    roomContract = _oReportFacade.getRoomReservationContract(txtControlNo.Text);
            //    roomContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
            //    oReportViewerUI.rptViewer.ReportSource = roomContract;
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();
            //}
            //else
            //{
            //    //if (_isBanquet == true)
            //    //{
            //    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            //    _oReportFacade = new ReportFacade();
            //    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtControlNo.Text, txtEventName.Text, ConfigVariables.gReportOrganization);
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();
            //    //}
            //    //else
            //    //{
            //    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            //    _oReportFacade = new ReportFacade();
            //    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getRoomTermsAndConditions(txtControlNo.Text, txtEventName.Text, ConfigVariables.gReportOrganization);
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();
            //    //}

            //    setDatabaseLogOn();
            //    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            //    _oReportFacade = new ReportFacade();
            //    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.AlpaEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.AlpaEventContract();
            //    banquetContract = _oReportFacade.getAlpaEventContract(txtControlNo.Text);
            //    banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
            //    oReportViewerUI.rptViewer.ReportSource = banquetContract;
            //    oReportViewerUI.MdiParent = this.MdiParent;
            //    oReportViewerUI.Show();
            //}

            //this.MdiParent.Cursor = Cursors.Default;

            
            try
            {
                    ContactPersonsUI _ContactPerson = new ContactPersonsUI(loFolio.FolioID, txtAccountID.Text, loFolio.ContactPersons);
                    _ContactPerson.Owner = this;
                    _ContactPerson.ShowDialog();
                    if (rdbCompany.Checked == true)
                    {
                        getCompany();
                    }
                    else
                    {
                        getGuestReservation();
                    }
                    
                    if(_ContactPerson.DialogResult.Equals(DialogResult.OK))
                    {
                        PrintReservationForm(_ContactPerson.CHECK_DATA);
                    }
            }
            catch (Exception ex)
            {
                     MessageBox.Show(ex.Message, "Folio Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getGuestReservation()
        {
            try
            {
                loFolio.Guest = loGuestFacade.getGuestRecord(txtAccountID.Text);
            }
            catch
            {
            }
        }
        public void PrintReservationForm(string[] pList)
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            bool _isBanquet = false;
            EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
            _isBanquet = _oEventTypeFacade.isBanquetType(cboEventType.Text.ToUpper());

            string _isAlpa = ConfigVariables.gContractType;
        
            oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            _oReportFacade = new ReportFacade();
            loEventFacade = new EventFacade();

            Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk.GroupRegistrationForm_PICC _groupReservation = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk.GroupRegistrationForm_PICC();
            _groupReservation = _oReportFacade.getGroupRegistration(loFolio, loEventFacade.getEvent(loFolio.FolioID)[0], pList);
            oReportViewerUI.rptViewer.ReportSource = _groupReservation;
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();

        }

        private void btnEventOrder_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.Edit)
            {
                MessageBox.Show("Reservation is in Edit Mode, Please save or cancel to proceed", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (btnBookingSheet.Text == "Booking Sheet")
            //{
            //    Reports.Presentation.BookingSheetDepartment _oBookingSheetUI = new Jinisys.Hotel.Reports.Presentation.BookingSheetDepartment(txtFolioID.Text);
            //    _oBookingSheetUI.MdiParent = this.MdiParent;
            //    _oBookingSheetUI.Show();
            //}
            //else
            //{
           
            IList<string> _oRooms = new List<string>();
            string _room = "";
            for (int _row = 1; _row < this.grdSchedules.Rows.Count; _row++)
            {
                _room = grdSchedules.GetDataDisplay(_row, 0); //+ " [" + grdSchedules.GetDataDisplay(_row, 1) + "]";
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

            Reports.Presentation.EventOrderUI _oEventOrderUI = new Jinisys.Hotel.Reports.Presentation.EventOrderUI(loFolio, _oRooms, loFolio.FromDate, loFolio.Todate, _organizer, this.nudMaxPax.Value, this.cboEventType.Text);
            //_oEventOrderUI.MdiParent = this.MdiParent;
            _oEventOrderUI.ShowDialog(this);
            //}
        }

        private void cboMarketingOfficer_Leave(object sender, EventArgs e)
        {
            if (!cboMarketingOfficer.Items.Contains(cboMarketingOfficer.Text.ToUpper()) && cboMarketingOfficer.Text != "")
                cboMarketingOfficer.Text = "";
        }
        private void cboMarketingOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdContactPersons_BeforeEdit(object sender, RowColEventArgs e)
        {

        }
        private void txtZIP_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtZIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                   && !char.IsDigit(e.KeyChar)
                   && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {

        }

        private void cboEventPackage_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private double lTotalRecurredChargePackage = 0;
        private void cboEventPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //KEVIN OLIVEROS 2014-01-21
                double _PackageAmount = 0;
                //grdRecurredCharge.Rows.Count = 1;
                //loadFolioRecurringCharges();
                EventPackageFacade _oEventPackageFacade = new EventPackageFacade();

                _PackageAmount = double.Parse(_oEventPackageFacade.getEventPackageAmount(cboEventPackage.SelectedValue.ToString()).ToString());
                if (lUIMode == OperationMode.Edit || lReservationType == ReservationType.NEW)
                {

                    //deletePackageRecurringCharges();
                    EventPackageDetailFacade _oEventPackageDetailFacade = new EventPackageDetailFacade();
                    EventPackageHeader _oEventPackageHeader = _oEventPackageFacade.getEventPackage(cboEventPackage.SelectedValue.ToString());
                    GenericList<EventPackageDetail> _eventPackageDetailList = _oEventPackageDetailFacade.getEventPackageDetails(cboEventPackage.SelectedValue.ToString());
                    nudMinPax.Value = decimal.Parse(_oEventPackageHeader.MinimumPax.ToString());
                    nudMaxPax.Value = decimal.Parse(_oEventPackageHeader.MaximumPax.ToString());

                    foreach (EventPackageDetail _oEventPackageDetail in _eventPackageDetailList)
                    {
                        //    lTotalRecurredChargePackage += _oEventPackageDetail.Amount;
                        //    grdRecurredCharge.Rows.Count++;
                        //    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, true);
                        //    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, _oEventPackageDetail.TransactionCode.ToString());
                        //    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, _oEventPackageDetail.Description);
                        //    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, _oEventPackageDetail.Amount);

                        //    try
                        //    {
                        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, gridFunctionRooms.GetData(1, 3));
                        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, gridFunctionRooms.GetData(1, 3));
                        //    }
                        //    catch
                        //    {
                        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(GlobalVariables.gAuditDate));
                        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(GlobalVariables.gAuditDate));
                        //    }
                        //    //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _oEventPackageDetail.SubAccount);
                    }
                    EventPackageDetailFacade _oEventPackageRequirementFacade = new EventPackageDetailFacade();
                    GenericList<EventPackageDetail> _oEventPackageRequirementList = _oEventPackageRequirementFacade.getEventPackageRequirements(cboEventPackage.SelectedValue.ToString());
                    treeRequirements.Nodes.Clear();
                    foreach (EventPackageDetail _oEventPackageRequirement in _oEventPackageRequirementList)
                    {
                        if (treeRequirements.Nodes.Count > 0)
                        {
                            foreach (TreeNode _tNode in treeRequirements.Nodes)
                            {
                                if (_tNode.Text == _oEventPackageRequirement.RequirementHeader || (_tNode.Text == _oEventPackageRequirement.RequirementHeader && _tNode.Index == treeRequirements.Nodes.Count - 1))
                                {
                                    _tNode.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
                                }
                                else if ((_tNode.Text != _oEventPackageRequirement.RequirementHeader && _tNode.Index != treeRequirements.Nodes.Count - 1))
                                { }
                                else if (_tNode.Text == _oEventPackageRequirement.RequirementDetail)
                                { }
                                else
                                {
                                    TreeNode _node = new TreeNode(_oEventPackageRequirement.RequirementHeader);
                                    _node.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
                                    treeRequirements.Nodes.Add(_node);
                                }
                            }
                        }
                        else
                        {
                            TreeNode _node = new TreeNode(_oEventPackageRequirement.RequirementHeader);
                            _node.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
                            treeRequirements.Nodes.Add(_node);
                        }

                        treeRequirements.ExpandAll();
                    }
                    lTotalRecurredChargePackage = _PackageAmount;
                    computePackageAmount();
                }
            }
            catch
            {

            }
            //cboEventPackage.Text = cboEventGrpPackage.Text;
        }





        private void cboEventPackage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lUIMode != OperationMode.Edit && lUIMode != OperationMode.Add)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEventPackage.SelectedValue = (loFolio.PackageID == null) ? "0" : loFolio.PackageID;
                txtControlNo.Focus();
            }
            else
            {
                //loFolio.RecurringCharges = null;
                //cboEventPackage.Text = cboEventGrpPackage.Text;
            }
        }

        DataTable lCopySchedules;

        private void copyScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            lCopySchedules = new DataTable();
            lCopySchedules.Columns.Add("room");
            lCopySchedules.Columns.Add("venueName");
            lCopySchedules.Columns.Add("fromDate");
            lCopySchedules.Columns.Add("toDate");
            lCopySchedules.Columns.Add("startTime");
            lCopySchedules.Columns.Add("endTime");
            lCopySchedules.Columns.Add("rateType");
            lCopySchedules.Columns.Add("Amount");
            lCopySchedules.Columns.Add("setup");
            lCopySchedules.Columns.Add("activity");
            lCopySchedules.Columns.Add("guaranteedPax");
            lCopySchedules.Columns.Add("remarks");
            lCopySchedules.Columns.Add("roomTypeCode");
            CellRange _range = this.grdSchedules.Selection;
            lCopySchedules.Clear();
            int _diff = _range.r2 - _range.r1;
            //this.MdiParent.Cursor = Cursors.WaitCursor;
            for (int i = _range.r1; i <= _range.r2; i++)
            {
                DataRow _row = lCopySchedules.NewRow();
                try
                {
                    _row["room"] = grdSchedules.Rows[i]["room"].ToString();
                    _row["venueName"] = grdSchedules.Rows[i]["venueName"].ToString();
                    _row["fromDate"] = grdSchedules.Rows[i]["fromDate"].ToString();
                    _row["toDate"] = grdSchedules.Rows[i]["toDate"].ToString();
                    _row["startTime"] = grdSchedules.Rows[i]["startTime"].ToString();
                    _row["endTime"] = grdSchedules.Rows[i]["endTime"].ToString();
                    _row["rateType"] = grdSchedules.Rows[i]["rateType"].ToString();
                    _row["Amount"] = grdSchedules.Rows[i]["Amount"].ToString();
                    _row["setup"] = grdSchedules.Rows[i]["setup"].ToString();
                    _row["activity"] = grdSchedules.Rows[i]["activity"].ToString();
                    _row["guaranteedPax"] = grdSchedules.Rows[i]["guaranteedPax"].ToString();
                    _row["remarks"] = grdSchedules.Rows[i]["remarks"].ToString();
                    _row["roomTypeCode"] = grdSchedules.Rows[i]["roomTypeCode"].ToString();
                }
                catch
                {
                }
                lCopySchedules.Rows.Add(_row);

            }//end for
        }

        private void pasteScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lUIMode == OperationMode.View)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (lCopySchedules.Rows.Count > 0)
            {
                foreach (DataRow _row in lCopySchedules.Rows)
                {
                    grdSchedules.Rows.Count++;
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["room"] = _row["room"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["fromDate"] = _row["fromDate"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["venueName"] = _row["venueName"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["toDate"] = _row["toDate"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["startTime"] = _row["startTime"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["endTime"] = _row["endTime"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["rateType"] = _row["rateType"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["amount"] = _row["Amount"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["setup"] = _row["setup"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["activity"] = _row["activity"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["guaranteedPax"] = _row["guaranteedPax"].ToString();
                    grdSchedules.Rows[grdSchedules.Rows.Count - 1]["remarks"] = _row["remarks"].ToString();
                }
                lCopySchedules.Clear();
            }

        }
        #endregion

        #region "Methods"
        private void showLookUp(string pLookUp,ref TextBox pControlToBind)
        {
            try
            {
                if (pControlToBind.Name == "txtCompanyName")
                {
                    CompanyFacade _oCompanyFacade = new CompanyFacade();

                    DataTable _oCompany = new DataTable();
                    _oCompany = _oCompanyFacade.getCompanies();
                    DataView _dtViewCompany = _oCompany.DefaultView;

                    _dtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
                    _dtViewCompany.RowFilter = "CompanyName like '" + pLookUp.ToUpper() + "%'";
                    this.lvwCompanies.Items.Clear();
                    foreach (DataRowView dr in _dtViewCompany)
                    {
                        ListViewItem _lvwItem = new ListViewItem();
                        _lvwItem.Text = dr[0].ToString();
                        _lvwItem.SubItems.Add(dr[2].ToString());
                        _lvwItem.SubItems.Add(dr["TIN"].ToString());

                        lvwCompanies.Items.Add(_lvwItem);
                    }

                    this.lvwCompanies.Visible = false;
                    this.txtAccountID.Text = "";

                    Point _locationOnForm = pControlToBind.FindForm().PointToClient(pControlToBind.Parent.PointToScreen(pControlToBind.Location));
                    _locationOnForm.Y = _locationOnForm.Y + pControlToBind.Height;

                    lvwCompanies.Location = _locationOnForm;
                    if( lvwCompanies.Items.Count > 0 )
                        this.lvwCompanies.Visible = true;
                    this.lvwCompanies.HeaderStyle = ColumnHeaderStyle.None;
                }
                else
                {
                    
                    GuestFacade oGuestFacade = new GuestFacade();

                    DataTable _oDataTable = new DataTable();
                    _oDataTable = oGuestFacade.getGuestAccount(txtFirstName.Text, txtLastName.Text);
                    DataView dtView = _oDataTable.DefaultView;

                    dtView.RowStateFilter = DataViewRowState.OriginalRows;
                    dtView.RowFilter = "LastName like '" + txtLastName.Text + "%' and FirstName like '" + txtFirstName.Text + "%'";
                    dtView.Sort = "Lastname, Firstname";

                    DataRowView dtr;
                    this.lvwGuestNames.Items.Clear();
                    foreach (DataRowView tempLoopVar_dtr in dtView)
                    {
                        dtr = tempLoopVar_dtr;
                        ListViewItem li = new ListViewItem(dtr["AccountId"].ToString());
                        li.SubItems.Add(dtr["LastName"].ToString());
                        li.SubItems.Add(dtr["FirstName"].ToString());
                        this.lvwGuestNames.Items.Add(li);
                    }

                    if (dtView.Count <= 0)
                    {
                        this.lvwGuestNames.Visible = false;
                        this.txtAccountID.Text = "";
                    }
                    else
                    {
                        Point _locationOnForm = pControlToBind.FindForm().PointToClient(pControlToBind.Parent.PointToScreen(pControlToBind.Location));
                        _locationOnForm.Y = _locationOnForm.Y + pControlToBind.Height;

                        this.lvwGuestNames.Location = _locationOnForm;
                        this.lvwGuestNames.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setButtons(){
            if (lReservationType == ReservationType.NEW)
            {
                btnStartEvent.Enabled = false;
                btnEndEvent.Enabled = false;
                btnReservationForm.Enabled = false;
                btnCharges.Enabled = false;
                btnPaymentSlip.Enabled = false;
                btnEventOrder.Enabled = false;
                btnPostCharges.Enabled = false;
                btnReinstate.Enabled = false;
                btnConfirm.Enabled = false;
                btnSaveRequirements.Enabled = false;
                btnEdit.Visible = false;

                pnlAmendments.Enabled = false;
                grpNewAmendment.Enabled = false;
                btnCancelReservation.Enabled = false; 
            }
            else
            {
                btnReservationForm.Enabled = true;
                btnCharges.Enabled = true;
                btnEventOrder.Enabled = true;
                btnPaymentSlip.Enabled = true;
                btnPostCharges.Enabled = true;
                btnConfirm.Enabled = true;
                btnReinstate.Enabled = true;
                btnSaveRequirements.Enabled = true;
                btnEdit.Visible = true;

                pnlAmendments.Enabled = true;
                grpNewAmendment.Enabled = true;
                btnCancelReservation.Enabled = true; 


                if (loFolio.FromDate.Date >= DateTime.Now.Date && loFolio.Status == "CONFIRMED")
                    btnStartEvent.Enabled = false;
            }

            switch ((EventStatus)Enum.Parse(typeof(EventStatus),txtStatus.Text.Replace(" ","")))
            {
                case EventStatus.ONGOING:
                    btnReinstate.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnStartEvent.Enabled = false;
                    btnUnconfirm.Enabled = false;
                    btnCancelReservation.Enabled = false;

                    
                    break;

                case EventStatus.TENTATIVE:
                case EventStatus.WAITLIST:
                    btnReinstate.Enabled = false;
                    btnStartEvent.Enabled = false;
                    btnEndEvent.Enabled = false;
                    btnPostCharges.Enabled = false;
                    btnUnconfirm.Enabled = false;
                 


                    break;

                case EventStatus.CONFIRMED:
                    btnReinstate.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnEndEvent.Enabled = false;
                    btnReinstate.Enabled = false;
                    btnPostCharges.Enabled = false;
                    btnUnconfirm.Enabled = true;

                    if (loFolio.FromDate.Date >= DateTime.Now.Date)
                        btnStartEvent.Enabled = true;
                    break;

                case EventStatus.CANCELLED:
                    btnEndEvent.Enabled = false;
                    btnStartEvent.Enabled = false;
                    btnCharges.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnPostCharges.Enabled = false;
                    btnEventOrder.Enabled = false;
                    btnReservationForm.Enabled = false;
                    btnUnconfirm.Enabled = false;

                    break;

                case EventStatus.CLOSED:
                    btnReinstate.Enabled = false;
                    btnCharges.Enabled = false;
                    btnUnconfirm.Enabled = false;

                    break;
            }
        }

        private void loadDropDowns()
        {
            AutoCompleteStringCollection values;
            GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

            DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
            DataView _oDataView = _oDtDropDownValues.DefaultView;

            //booking source
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'BookingSource'";

            if (_oDataView.Count > 0)
            {
                //this.cboSource.Items.Clear();
                values = new AutoCompleteStringCollection();

                foreach (DataRowView _dRowView in _oDataView)
                {
                    values.Add(_dRowView["Value"].ToString());
                }
                this.cboSource.DataSource = values;
            }

            // Client type
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'AccountType'";
            values = new AutoCompleteStringCollection();

            if (_oDataView.Count > 0)
            {
                //cboClientType.Items.Clear();
                foreach (DataRowView _dRowView in _oDataView)
                {
                    values.Add(_dRowView["Value"].ToString());
                }
                cboClientType.DataSource = values;
            }
            
            // Payment mode
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'PaymentMode'";
            values = new AutoCompleteStringCollection();

            if (_oDataView.Count > 0)
            {
                //cboPaymentMode.Items.Clear();
                foreach (DataRowView _dRowView in _oDataView)
                {
                    values.Add(_dRowView["Value"].ToString());
                }
            }
            cboPaymentMode.DataSource = values;
            
            // Market Segment
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'MarketSegment'";
            values = new AutoCompleteStringCollection();

            if (_oDataView.Count > 0)
            {
                //cboMarketSegment.Items.Clear();
                foreach (DataRowView _dRowView in _oDataView)
                {
                    values.Add(_dRowView["Value"].ToString());
                }
                cboMarketSegment.DataSource = values;
            }

            // person type
            _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
            _oDataView.RowFilter = "fieldname = 'PersonType'";
            lcboPersonType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (_oDataView.Count > 0)
            {
                foreach (DataRowView _dRowView in _oDataView)
                {
                    lcboPersonType.Items.Add(_dRowView["Value"].ToString());
                }
            }

            // setup
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

            this.lcboSetups.DataSource = _oDataView.ToTable();
            this.lcboSetups.ValueMember = "Value";
            this.lcboSetups.DisplayMember = "Value";
            this.lcboSetups.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.lcboSetups.AutoCompleteSource = AutoCompleteSource.ListItems;

            // activity
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

            lcboActivities.DataSource = _oDataView.ToTable();
            lcboActivities.ValueMember = "Value";
            lcboActivities.DisplayMember = "Value";
            lcboActivities.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            lcboActivities.AutoCompleteSource = AutoCompleteSource.ListItems;

            // event types
            EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
            GenericList<EventType> _oEventTypeList = _oEventTypeFacade.getEventTypes();
            EventType _oEventType = new EventType();
            _oEventType.Event_Type = "";
            _oEventType.EventID = 0;
            _oEventTypeList.Insert(0, _oEventType);
            cboEventType.DisplayMember = "event_type";
            cboEventType.ValueMember = "event_type";
            //cboEventType.ValueMember = "eventid";
            cboEventType.DataSource = _oEventTypeList;

            // requirements types
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

            // packages
            EventPackageFacade _oEventPackageFacade = new EventPackageFacade();
            GenericList<EventPackageHeader> _oEventPackage = _oEventPackageFacade.getEventPackages();
            EventPackageHeader _oEventPackageHeader = new EventPackageHeader();
            _oEventPackageHeader.PackageID = 0;
            _oEventPackageHeader.Description = "";
            _oEventPackage.Insert(0, _oEventPackageHeader);
            cboEventPackage.DisplayMember = "Description";
            cboEventPackage.ValueMember = "PackageID";
            cboEventPackage.DataSource = _oEventPackage;

            // Sales Executive
            User _oSalesExecUser = new User();
            UserFacade _oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
            _oSalesExecUser = _oUserFacade.GetUserRolesAll();

            DataView _dtvSalesExec = _oSalesExecUser.Tables[0].DefaultView;
            _dtvSalesExec.RowStateFilter = DataViewRowState.OriginalRows;
            _dtvSalesExec.RowFilter = "Department like '100%' and rolename like '%marketing%'";

            foreach (DataRowView dRow in _dtvSalesExec)
            {
                this.cboMarketingOfficer.Items.Add(dRow["UserId"].ToString());
            }

            // Users list
            loUserList = _oUserFacade.getUsersTable();

            /*** Populate lstRooms ***/
            RoomFacade _oRoomFacade = new RoomFacade();
            
            ArrayList _roomList = new ArrayList();
            _roomList = _oRoomFacade.getRoomsByRoomSuperType("FUNCTION");
            lstRooms.DataSource = _roomList;

            //_roomList.Insert(0, "  ");
            //lCboFunctionRooms.DisplayMember = "RoomID";
            //lCboFunctionRooms.ValueMember = "RoomID";
            //lCboFunctionRooms.DataSource = _roomList;
            //lCboFunctionRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            //gridFunctionRooms.Cols[e.Col].Editor = lCboFunctionRooms;
        }

        private void txtHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void noHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;
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
                    if (_ctrl1.Name != "txtEventName"
                        && _ctrl1.Name != "txtLastName"
                        && _ctrl1.Name != "txtFirstName"
                        && _ctrl1.Name != "txtCompanyName"
                        && _ctrl1.Name != "txtAddress"
                        && _ctrl1.Name != "txtTIN"
                        && _ctrl1.Name != "txtRemarks")
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
                    //if (pCntrol.Name != "btnNewMeal" || pCntrol.Name != "btnSaveMeal")
                        pCntrol.Enabled = pTrueFalse;
                }
            }
        }

        public void DisableControls(Control pControl)
        {
            foreach (Control _ctrl in pControl.Controls)
            {
                if (_ctrl is TabControl || _ctrl is Panel || _ctrl is GroupBox || _ctrl is TabPage)
                {
                    _ctrl.Enabled = true;
                    DisableControls(_ctrl);
                }
                else if (_ctrl is Button)
                {
                    _ctrl.Enabled = false;
                }
            }
        }

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
            if (lCanAddMarketingOfficer == false)
            {
                cboMarketingOfficer.Enabled = false;
            }
            else
            {
                cboMarketingOfficer.Enabled = true;
            }
        }

        private bool isValidSchedule()
        {
            foreach (C1.Win.C1FlexGrid.Row _row in grdSchedules.Rows)
            {
                if (_row.Index != 0)
                {
                    if (DateTime.Parse(grdSchedules.GetDataDisplay(_row.Index, "fromDate")) > DateTime.Parse(grdSchedules.GetDataDisplay(_row.Index, "toDate")))
                    {
                        return false;
                    }

                    if (grdSchedules.GetDataDisplay(_row.Index, "room").Trim().Equals(""))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool createNewIndividualAccount()
        {
            try
            {
                if (this.txtLastName.Text.Trim().Length > 0 && txtAccountID.Text == "")
                {
                    loGuestFacade = new GuestFacade();
                    Guest _newGuest = new Guest();

                    _newGuest.AccountId = loSequence.getSequenceId("I-", 12, "seq_guest");
                    _newGuest.AccountName = txtLastName.Text.ToUpper() + "_" + txtFirstName.Text.ToUpper();
                    _newGuest.Title = "";
                    _newGuest.LastName = txtLastName.Text;
                    _newGuest.FirstName = txtFirstName.Text;
                    _newGuest.MiddleName = "";
                    _newGuest.Sex = "";
                    _newGuest.Street = txtStreet.Text;
                    _newGuest.City = txtCity.Text;
                    _newGuest.Country = txtCountry.Text;
                    _newGuest.Zip = txtZIP.Text;
                    _newGuest.EmailAddress = "";
                    _newGuest.Citizenship = "";
                    _newGuest.PassportId = txtPassportID.Text;
                    _newGuest.TelephoneNo = "";
                    _newGuest.MobileNo = "";
                    _newGuest.FaxNo = "";
                    _newGuest.GuestImage = "";
                    _newGuest.Memo = "";
                    _newGuest.Concierge = "";
                    _newGuest.Remark = "";
                    _newGuest.HotelID = GlobalVariables.gHotelId;
                    _newGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
                    _newGuest.BIRTH_DATE = new DateTime();
                    _newGuest.ACCOUNT_TYPE = txtAccountType.Text;
                    _newGuest.CARD_NO = "";
                    _newGuest.THRESHOLD_VALUE = 0;
                    _newGuest.TOTAL_SALES_CONTRIBUTION = 0;
                    _newGuest.CreditCardType = "";
                    _newGuest.CreditCardNo = "";
                    _newGuest.CreditCardExpiry = "";
                    _newGuest.TaxExempted = 0;
                    _newGuest.CreateTime = DateTime.Now;
                     

                    AccountInformation _oAccountInformation = new AccountInformation();
                    _oAccountInformation.AccountID = _newGuest.AccountId;
                    _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                    _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

                    _newGuest.AccountInformation = _oAccountInformation;

                    loGuestFacade.insertGuest(ref _newGuest);

                    this.txtAccountID.Text = _newGuest.AccountId;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in creating new company account.\r\n" + ex.Message);
            }
        }

        private bool createNewCompanyAccount()
        {
            try
            {
                if (this.txtCompanyName.Text.Trim().Length > 0 && txtAccountID.Text == "")
                {

                    loCompanyFacade = new CompanyFacade();
                    Company _newCompany = new Company();

                    _newCompany.CompanyId = loSequence.getSequenceId("G-", 12, "seq_company");
                    _newCompany.CompanyName = this.txtCompanyName.Text;
                    _newCompany.ContactNumber1 = "";
                    _newCompany.ContactNumber2 = "";
                    _newCompany.ContactNumber3 = "";
                    _newCompany.ContactPerson = "";
                    _newCompany.Designation = "";
                    _newCompany.HotelID = GlobalVariables.gHotelId;
                    _newCompany.ACCOUNT_TYPE = "";
                    _newCompany.CARD_NO = "";
                    _newCompany.City1 = txtCity.Text;
                    _newCompany.City2 = "";
                    _newCompany.City3 = "";
                    _newCompany.CompanyCode = this.txtCompanyName.Text;
                    _newCompany.CompanyURL = "";
                    _newCompany.ContactType1 = "PHONE";
                    _newCompany.ContactType2 = "FAX";
                    _newCompany.ContactType3 = "MOBILE";
                    _newCompany.Country1 = txtCountry.Text;
                    _newCompany.Country2 = "";
                    _newCompany.Country3 = "";
                    _newCompany.Email1 = "";
                    _newCompany.Email2 = "";
                    _newCompany.Email3 = "";
                    _newCompany.NO_OF_VISIT = 0;
                    _newCompany.Remarks = "";
                    _newCompany.Street1 = txtStreet.Text;
                    _newCompany.Street2 = "";
                    _newCompany.Street3 = "";
                    _newCompany.THRESHOLD_VALUE = 0;
                    _newCompany.TOTAL_SALES_CONTRIBUTION = 0;
                    _newCompany.X_DEAL_AMOUNT = 0;
                    _newCompany.Zip1 = txtZIP.Text;
                    _newCompany.Zip2 = "";
                    _newCompany.Zip3 = "";
                    _newCompany.TIN = txtTINNo.Text;

                    AccountInformation _oAccountInformation = new AccountInformation();
                    _oAccountInformation.AccountID = _newCompany.CompanyId;
                    _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                    _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

                    _newCompany.AccountInformation = _oAccountInformation;

                    loCompanyFacade.insertCompanyGuest(ref _newCompany);


                    this.txtAccountID.Text = _newCompany.CompanyId;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in creating new company account.\r\n" + ex.Message);
            }
        }

        private bool getGuest()
        {
            bool found = false;
            if (lUIMode != OperationMode.View)
            {
                if (checkGuestAvailability())
                {
                    found = true;
                    loGuestFacade = new GuestFacade();
                    this.txtAccountID.Text = loGuest.Tables["Guests"].Rows[0]["AccountID"].ToString();
                }
                //else
                //{

                //    if (lvwGuestNames.Visible == false)
                //    {
                //        confirmSaveGuest();
                //    }
                //}
            }

            return found;
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

        private int countGuestRows()
        {
            loGuestFacade = new GuestFacade();
            loGuest = loGuestFacade.filterGuestRecordRefName(GlobalFunctions.removeQuotes(this.txtLastName.Text), GlobalFunctions.removeQuotes(this.txtFirstName.Text), "");
            return loGuest.Tables["Guests"].Rows.Count;
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

        private bool checkIfRequirementIsAdded(string pRequirementSchedule, string pRequirementCode, string pRequirementDescription)
        {
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

        private void updateCompanyInformation()
        {
            // create new guest account
            loCompanyFacade = new CompanyFacade();
            Company _newCompany = new Company();

            _newCompany.ACCOUNT_TYPE = loCompany.ACCOUNT_TYPE;
            _newCompany.CARD_NO = loCompany.CARD_NO;
            _newCompany.City1 = txtCity.Text;
            _newCompany.City2 = loCompany.City2;
            _newCompany.City3 = loCompany.City3;
            _newCompany.CompanyCode = loCompany.CompanyCode;
            _newCompany.CompanyId = txtAccountID.Text;
            _newCompany.CompanyName = txtCompanyName.Text;
            _newCompany.CompanyURL = loCompany.CompanyURL;
            _newCompany.ContactNumber1 = loCompany.ContactNumber1;
            _newCompany.ContactNumber2 = loCompany.ContactNumber2;
            _newCompany.ContactNumber3 = loCompany.ContactNumber3;
            _newCompany.ContactPerson = loCompany.ContactPerson;
            _newCompany.ContactType1 = "PHONE";
            _newCompany.ContactType2 = "FAX";
            _newCompany.ContactType3 = "MOBILE";
            _newCompany.Country1 = txtCountry.Text;
            _newCompany.Country2 = loCompany.Country2;
            _newCompany.Country3 = loCompany.Country3;
            _newCompany.Designation = loCompany.Designation;
            _newCompany.Email1 = loCompany.Email1;
            _newCompany.Email2 = loCompany.Email2;
            _newCompany.Email3 = loCompany.Email3;
            _newCompany.NO_OF_VISIT = loCompany.NO_OF_VISIT;
            _newCompany.Remarks = loCompany.Remarks;
            _newCompany.Street1 = txtStreet.Text;
            _newCompany.Street2 = loCompany.Street2;
            _newCompany.Street3 = loCompany.Street3;
            _newCompany.THRESHOLD_VALUE = loCompany.THRESHOLD_VALUE;
            _newCompany.TOTAL_SALES_CONTRIBUTION = loCompany.TOTAL_SALES_CONTRIBUTION;
            _newCompany.X_DEAL_AMOUNT = loCompany.X_DEAL_AMOUNT;
            _newCompany.Zip1 = txtZIP.Text;
            _newCompany.Zip2 = loCompany.Zip2;
            _newCompany.Zip3 = loCompany.Zip3;
            _newCompany.TIN = txtTINNo.Text;

            _newCompany.AccountPrivileges = loCompany.AccountPrivileges;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = _newCompany.CompanyId;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

            _newCompany.AccountInformation = _oAccountInformation;
            loCompanyFacade.updateCompanyAccount(txtAccountID.Text, ref _newCompany);
            //loGuestFacade.updateGuest(ref _newCompany);

            this.loFolio.Company = _newCompany;
        }
        private void getCompany()
        {
            loCompanyFacade = new CompanyFacade();
            Company _newCompany = new Company();

            _newCompany.ACCOUNT_TYPE = loCompany.ACCOUNT_TYPE;
            _newCompany.CARD_NO = loCompany.CARD_NO;
            _newCompany.City1 = txtCity.Text;
            _newCompany.City2 = loCompany.City2;
            _newCompany.City3 = loCompany.City3;
            _newCompany.CompanyCode = loCompany.CompanyCode;
            _newCompany.CompanyId = txtAccountID.Text;
            _newCompany.CompanyName = txtCompanyName.Text;
            _newCompany.CompanyURL = loCompany.CompanyURL;
            _newCompany.ContactNumber1 = loCompany.ContactNumber1;
            _newCompany.ContactNumber2 = loCompany.ContactNumber2;
            _newCompany.ContactNumber3 = loCompany.ContactNumber3;
            _newCompany.ContactPerson = loCompany.ContactPerson;
            _newCompany.ContactType1 = "PHONE";
            _newCompany.ContactType2 = "FAX";
            _newCompany.ContactType3 = "MOBILE";
            _newCompany.Country1 = txtCountry.Text;
            _newCompany.Country2 = loCompany.Country2;
            _newCompany.Country3 = loCompany.Country3;
            _newCompany.Designation = loCompany.Designation;
            _newCompany.Email1 = loCompany.Email1;
            _newCompany.Email2 = loCompany.Email2;
            _newCompany.Email3 = loCompany.Email3;
            _newCompany.NO_OF_VISIT = loCompany.NO_OF_VISIT;
            _newCompany.Remarks = loCompany.Remarks;
            _newCompany.Street1 = txtStreet.Text;
            _newCompany.Street2 = loCompany.Street2;
            _newCompany.Street3 = loCompany.Street3;
            _newCompany.THRESHOLD_VALUE = loCompany.THRESHOLD_VALUE;
            _newCompany.TOTAL_SALES_CONTRIBUTION = loCompany.TOTAL_SALES_CONTRIBUTION;
            _newCompany.X_DEAL_AMOUNT = loCompany.X_DEAL_AMOUNT;
            _newCompany.Zip1 = txtZIP.Text;
            _newCompany.Zip2 = loCompany.Zip2;
            _newCompany.Zip3 = loCompany.Zip3;
            _newCompany.TIN = txtTINNo.Text;

            _newCompany.AccountPrivileges = loCompany.AccountPrivileges;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = _newCompany.CompanyId;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

            _newCompany.AccountInformation = _oAccountInformation;
          //  loCompanyFacade.updateCompanyAccount(txtAccountID.Text, ref _newCompany);
            //loGuestFacade.updateGuest(ref _newCompany);

            this.loFolio.Company = _newCompany;

        }

        private void saveGroupFolio(ref MySqlTransaction pTrans)
        {
            loFolioFacade = new FolioFacade();
          
            txtEventName.Text = txtEventName.Text.Replace('\'', '`');
            //check if needs to change reference number
            bool _refNoChanged = false;
            if (string.Format("{0:MMM-yyyy}", loFolio.FromDate) != string.Format("{0:MMM-yyyy}", ldtpFromDate.Value))
            {
                _refNoChanged = true;
            }
            //FormToObjectInstanceBinder.BindObjectToInputControls(this, loFolio);
            // manual assignment due to name difference
            loFolio.FolioType = "GROUP";
            loFolio.AccountID = "";
            loFolio.ReferenceNo = txtReferenceNo.Text;
            loFolio.GroupName = txtEventName.Text;
            loFolio.AccountType = cboClientType.Text;
            loFolio.NoofAdults = 0;
            loFolio.NoOfChild = 0;
            loFolio.MasterFolio = "";
            loFolio.CompanyID = txtAccountID.Text;
            loFolio.AgentID = "";
            loFolio.Source = cboSource.Text;
            try
            {
                loFolio.PackageID = cboEventPackage.SelectedValue.ToString() ;
            }
            catch
            {
                loFolio.PackageID = "0";
            }
            loFolio.Status = txtStatus.Text;
            loFolio.Remarks = txtRemarks.Text;
            loFolio.TerminalId = GlobalVariables.gTerminalID.ToString();
            loFolio.ShiftCode = GlobalVariables.gShiftCode.ToString();
            loFolio.SupervisorId = "";
            loFolio.Sales_Executive = cboMarketingOfficer.Text;
            loFolio.Payment_Mode = cboPaymentMode.Text;
            loFolio.Purpose = cboMarketSegment.Text;
            loFolio.REASON_FOR_CANCEL = "";
            loFolio.TaxExempted = 0;
            loFolio.EVENT_SETUP_START = "";
            loFolio.EVENT_SETUP_END  = "";
            loFolio.FolioETA = "";
            loFolio.FolioETD = "";
            loFolio.CreatedBy = txtCreatedBy.Text;
            loFolio.FromDate = ldtpFromDate.Value;
            loFolio.Todate = ldtpToDate.Value;
            
            //>>
            if (rdbCompany.Checked == true)
            {
                // Insert/Update Company
                if (loFolio.Company == null && loFolio.CompanyID == "")
                {
                   
                    createNewCompanyAccount();
                    loFolio.CompanyID = txtAccountID.Text;
                }
                else
                {
                    
                    updateCompanyInformation(); // update guest information
                }
            }
            else if (rdbIndividual.Checked == true)
            {
                if (txtAccountID.Text.Trim() != "")
                {
                    updateGuestInformation();
                }
                else
                {
                    createNewIndividualAccount();
                    loFolio.CompanyID = txtAccountID.Text;
                }
            }

            loFolio.UpdatedBy = GlobalVariables.gLoggedOnUser;
            loFolio.Remarks = txtRemarks.Text;
            //loFolio.Package = assignFolioPackage(loFolio);
            //loFolio.RecurringCharges = assignRecurringCharges();
            //loFolio.FolioRouting = assignFolioRouting();
            //loFolio.Privileges = setUpFolioPrivileges();
            loFolio.TerminalId = GlobalVariables.gTerminalID.ToString();
            loFolio.ShiftCode = GlobalVariables.gShiftCode.ToString();
            loFolio.ContactPersons = assignContactPersons();
            loFolio.EventOfficers = assignEventOfficers();
            //loFolio.IncumbentOfficers = assignIncumbentOfficers();
            //loFolio.EventEndorsement = assignEventEndorsement();
            //loFolio.EventAttendance = assignEventAttendance();
            //by Kevin Oliveros 2014-01-20
          

            if (grdSchedules.Rows.Count > 1)
            {
                loFolio.FolioETA = grdSchedules.GetDataDisplay(1, "startTime");
                loFolio.FolioETD = grdSchedules.GetDataDisplay(grdSchedules.Rows.Count - 1, "endTime");
            }
            else
            {
                loFolio.FolioETA = "12:00 PM";
                loFolio.FolioETD = "2:00 PM";
            }

            saveFunctionRooms();

            //jlo for alpa 6-9-10
            String _rStatus = "";
            if (lUIMode == OperationMode.Edit)
            {
                _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;
            }
            int _newStatus = getIndex(this.txtStatus.Text, aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {

                //Kevin L. Oliveros 2014-16-01
                //txtStatus.Text = _rStatus;
                if (_rStatus == "ONGOING")
                {
                    ldtpFromDate.Text = loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString();
                    grdSchedules.SetData(1, "fromDate", loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString());
                }
            }
            //jlo

            if (lReservationType == ReservationType.NEW)
            {
                // Will enter here if new folio
                try
                {
                    loFolio.EventEndorsement = null;
                    loFolioFacade.SaveFolio(loFolio, ref pTrans);
                }
                catch (Exception ex)
                {
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
            }
        }

        private void updateGuestInformation()
        {
            // create new guest account
            loGuestFacade = new GuestFacade();
            Guest _newGuest = new Guest();
            loFolio.Guest = loGuestFacade.getGuestRecord(txtAccountID.Text);

            _newGuest.AccountId = this.txtAccountID.Text;
            _newGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
            _newGuest.Title = loFolio.Guest.Title;
            _newGuest.LastName = this.txtLastName.Text;
            _newGuest.FirstName = this.txtFirstName.Text;
            _newGuest.MiddleName = loFolio.Guest.MiddleName;
            _newGuest.Sex = loFolio.Guest.Sex;
            _newGuest.Citizenship = loFolio.Guest.Citizenship;
            _newGuest.PassportId = txtPassportID.Text;
            _newGuest.GuestImage = loFolio.Guest.GuestImage;
            _newGuest.TelephoneNo = loFolio.Guest.TelephoneNo;
            _newGuest.MobileNo = loFolio.Guest.MobileNo;
            _newGuest.FaxNo = loFolio.Guest.FaxNo;
            _newGuest.Street = txtStreet.Text;
            _newGuest.City = txtCity.Text;
            _newGuest.Country = txtCountry.Text;
            _newGuest.Zip = txtZIP.Text;
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

        private IList<EventContact> assignContactPersons()
        {
            IList<EventContact> _contactPersons = new List<EventContact>();
            try
            {
                EventContact _oContactPerson;
                for (int row = 1; row < grdContactPersons.Rows.Count; row++)
                {
                    _oContactPerson = new EventContact();
                    if (grdContactPersons.GetDataDisplay(row, 11).ToString() != "")
                    {
                        _oContactPerson.ContactID = grdContactPersons.GetDataDisplay(row, 11).ToString();
                    }
                    else
                    {
                        _oContactPerson.ContactID = "AUTO";
                    }
                    _oContactPerson.FolioID = loFolio.FolioID;
                    _oContactPerson.AccountID = loFolio.CompanyID;
                    _oContactPerson.HotelID = GlobalVariables.gHotelId.ToString();
                    _oContactPerson.LastName = grdContactPersons.GetDataDisplay(row, 0).ToString();
                    _oContactPerson.FirstName = grdContactPersons.GetDataDisplay(row, 1).ToString();
                    _oContactPerson.MiddleName = grdContactPersons.GetDataDisplay(row, 2).ToString();
                    _oContactPerson.Designation = grdContactPersons.GetDataDisplay(row, 3).ToString();
                    _oContactPerson.PersonType = grdContactPersons.GetDataDisplay(row, 4).ToString();
                    _oContactPerson.Address = grdContactPersons.GetDataDisplay(row, 5).ToString();
                    _oContactPerson.TelNo = grdContactPersons.GetDataDisplay(row, 6).ToString();
                    _oContactPerson.MobileNo = grdContactPersons.GetDataDisplay(row, 7).ToString();
                    _oContactPerson.FaxNo = grdContactPersons.GetDataDisplay(row, 8).ToString();
                    _oContactPerson.Email = grdContactPersons.GetDataDisplay(row, 9).ToString();
                    try
                    {
                        _oContactPerson.BirthDate = DateTime.Parse(grdContactPersons.GetDataDisplay(row, 10).ToString());
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

        private IList<EventOfficer> assignEventOfficers()
        {
            IList<EventOfficer> _eventOfficers = new List<EventOfficer>();
            try
            {
                EventOfficer _oEventOfficer;
                for (int row = 1; row < grdEventOfficers.Rows.Count; row++)
                {
                    _oEventOfficer = new EventOfficer();
                    if (grdEventOfficers.GetDataDisplay(row, 3).ToString() == "")
                    {
                        _oEventOfficer.ID = "AUTO";
                    }
                    else
                    {
                        _oEventOfficer.ID = grdEventOfficers.GetDataDisplay(row, 3).ToString();
                    }
                    if (grdEventOfficers.GetDataDisplay(row, 0).ToString().Trim() != "" || grdEventOfficers.GetDataDisplay(row, 0).ToString().Trim() != "")
                    {
                        _oEventOfficer.LastName = grdEventOfficers.GetDataDisplay(row, 0).ToString();
                        _oEventOfficer.FirstName = grdEventOfficers.GetDataDisplay(row, 1).ToString();
                        _oEventOfficer.UserID = grdEventOfficers.GetDataDisplay(row, 2).ToString();
                        _oEventOfficer.FolioID = loFolio.FolioID;
                        _oEventOfficer.HotelID = GlobalVariables.gHotelId.ToString();
                        _eventOfficers.Add(_oEventOfficer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignEventOfficers\r\n" + ex.Message);
            }
            return _eventOfficers;

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
                    _oSchedule.FolioID = txtControlNo.Text;
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
            loEventFacade = new EventFacade();

            EventBookingInfo _oEventBookingInfo = new EventBookingInfo();
            _oEventBookingInfo.BookingDate = loFolio.CreateTime;
            _oEventBookingInfo.EventType = cboEventType.Text;
            _oEventBookingInfo.NumberOfLiveIn = 0;
            _oEventBookingInfo.NumberOfLiveOut = int.Parse(nudMinPax.Value.ToString());
            _oEventBookingInfo.FolioID = txtControlNo.Text;
            _oEventBookingInfo.NumberOfPaxGuaranteed = int.Parse(nudMaxPax.Value.ToString());
            _oEventBookingInfo.BillingArrangement = "";
            _oEventBookingInfo.AuthorizedSignatory = "";
            _oEventBookingInfo.LobbyPosting = "";
            _oEventBookingInfo.CREATEDBY = GlobalVariables.gLoggedOnUser;
            _oEventBookingInfo.UPDATEDBY = GlobalVariables.gLoggedOnUser;
            _oEventBookingInfo.HotelID = GlobalVariables.gHotelId;
            try
            {
                _oEventBookingInfo.EventPackage = int.Parse(cboEventPackage.SelectedValue.ToString());
            }
            catch
            {
                _oEventBookingInfo.EventPackage = 0;
            }
            //_oEventBookingInfo.PackageAmount = decimal.Parse(txtPackageAmount.Text);
            _oEventBookingInfo.PackageAmount =  decimal.Parse(lTotalRecurredChargePackage.ToString());
            _oEventBookingInfo.ContactAddress = GlobalFunctions.addSlashes(txtStreet.Text + ", " + txtCity.Text + ", " + txtCountry.Text + ", " + txtZIP.Text);
            _oEventBookingInfo.ContactNumber = "";
            _oEventBookingInfo.ContactPerson = "";
            _oEventBookingInfo.ContactPosition = "";
            _oEventBookingInfo.MobileNumber = "";
            _oEventBookingInfo.FaxNumber = "";
            _oEventBookingInfo.EmailAddress = "";

            try
            {
                _oEventBookingInfo.EstimatedTotalCost = decimal.Parse(txtEstimatedCost.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in saving folio. \r\nPlease check the total estimated cost.\n\n" + ex.Message);
            }

            bool _isEventExist = loEventFacade.checkEventExists(txtControlNo.Text);

            if (_isEventExist == false)
            {
                _oEventBookingInfo.BookingDate = DateTime.Now;
                loEventFacade.insertEvents(_oEventBookingInfo, ref pTrans);
            }
            else
            {
                _oEventBookingInfo.BookingDate = loFolio.CreateTime; 
                loEventFacade.updateEvents(_oEventBookingInfo, ref pTrans);
            }

            //>>applied _oAppliedRates
            //EventAppliedRates _oEventAppliedRates = new EventAppliedRates();
            //EventAppliedRatesFacade _oEventAppliedRatesFacade = new EventAppliedRatesFacade();
            //_oEventAppliedRatesFacade.deleteAppliedRates(txtControlNo.Text, ref pTrans);

            //int _counter = 1;
            //int _rowCount = gridBilling.Rows.Count;
            //foreach (C1.Win.C1FlexGrid.Row _cntRow in gridBilling.Rows)
            //{
            //    try
            //    {
            //        if (_cntRow.Index != 0 && gridBilling.GetDataDisplay(_counter, 0) != "") //_counter < _rowCount - 1)
            //        {
            //            _oEventAppliedRates.FolioID = txtFolioID.Text;
            //            _oEventAppliedRates.Description = gridBilling.GetDataDisplay(_counter, 0);
            //            _oEventAppliedRates.RateAmount = decimal.Parse(gridBilling.GetDataDisplay(_counter, 1));
            //            _oEventAppliedRates.NumberOfOccupants = int.Parse(gridBilling.GetDataDisplay(_counter, 2));
            //            _oEventAppliedRates.RateType = gridBilling.GetDataDisplay(_counter, 3);

            //            _oEventAppliedRatesFacade = new EventAppliedRatesFacade();
            //            _oEventAppliedRatesFacade.saveAppliedRates(_oEventAppliedRates, ref pTrans);
            //            _counter++;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error in saving applied rates. Please check details \r\n\r\nError message : " + ex.Message);
            //    }
            //}//<<
        }

        private void saveEventDetails(ref MySqlTransaction poTransaction)
        {
            //saveMeals();
            saveRequirements(ref poTransaction);

            ////>>for event type details
            //EventDetails _oEventDetails = new EventDetails();
            //EventFacade _oEventDetailsFacade = new EventFacade();
            //_oEventDetailsFacade.deleteEventDetails(txtControlNo.Text, ref poTransaction);

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
                _oEventRequirementsFacade.deleteEventsRequirements(txtControlNo.Text, ref pTrans);

                for (int _ctr = 0; _ctr < treeRequirements.Nodes.Count; _ctr++)
                {
                    foreach (TreeNode _treeNode in treeRequirements.Nodes[_ctr].Nodes)
                    {
                        //_oEventRequirements.FolioID = txtFolioID.Text;
                        //_oEventRequirements.RequirementCode = _treeNode.Parent.Text;
                        //_oEventRequirements.Description = _treeNode.Text;
                        _oEventRequirements.FolioID = txtControlNo.Text;
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

        private void AfterSaveAction()
        {
            btnEdit.Visible = true;
            //btnNew.Enabled = false;
            //panelNew.Visible = false;
            KeypressTextboxHandler(this, true);
            lUIMode = OperationMode.View;
        }

        private void loadFolio()
        {
            loFolio = loFolioFacade.GetFolio(txtControlNo.Text);
            Control myForm = this;

            //FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            AccountId = loFolio.CompanyID;
            txtRemarks.Text = loFolio.Remarks;

            //GetChildFolios();

            //lGroupFolioStatus = "Old";
            lReservationType = ReservationType.OLD;
            switch (AccountType)
            {
                case AccountType.Corporate:

                    if (AccountId.StartsWith("G"))
                    {
                        loCompany = new Company();

                        loCompany = loCompanyFacade.getCompanyAccount(AccountId);
                        rdbCompany.Checked = true;
                        Control frm = this;
                        //FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                        txtAccountID.Text = loCompany.CompanyId;
                        txtCompanyName.Text = loCompany.CompanyName;
                        txtCompanyCode.Text = loCompany.CompanyCode;
                        txtCity.Text = loCompany.City1;
                        txtStreet.Text = loCompany.Street1;
                        txtCountry.Text = loCompany.Country1;
                        txtZIP.Text = loCompany.Zip1;
                        txtTINNo.Text = loCompany.TIN;
                    }
                    else
                    {
                        loGuest = new Guest();

                        loGuestFacade = new GuestFacade();
                        loGuest = loGuestFacade.getGuestRecord(AccountId);
                        rdbIndividual.Checked = true;

                        Control frm = this;
                        //FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loGuestFacade);
                        txtAccountID.Text = loGuest.AccountId;
                        txtLastName.Text = loGuest.LastName;
                        txtFirstName.Text = loGuest.FirstName;
                        txtStreet.Text = loGuest.Street;
                        txtCity.Text = loGuest.City;
                        txtCountry.Text = loGuest.Country;
                        txtZIP.Text = loGuest.Zip;
                        txtPassportID.Text = loGuest.PassportId;

                    }
                    break;
            }

            btnEdit.Visible = true;
            lUIMode = OperationMode.View;
            KeypressTextboxHandler(this, true);
            txtAccountID_TextChanged(txtAccountID, new EventArgs());

            //loadPackages();
            //loadFolioRecurringCharges();
            //loadRooms();
            //getCharges(grdRecurringCharges);
            //getCharges(gridTransactionCodes);
            //LoadFolioRouting(loFolio);
            loadEventBookingInfo();
            //loadFolioPackage();
            setButtons();
            txtRemarks.Text = loFolio.Remarks;
            //grdFolio.Sort(SortFlags.Ascending, 2, 3);
        }

        public void loadEventBookingInfo()
        {
            GenericList<EventBookingInfo> _oEventBookingInfoList = new GenericList<EventBookingInfo>();
            _oEventBookingInfoList = loEventFacade.getEvent(txtControlNo.Text);
            foreach (EventBookingInfo _oEventBookingInfo in _oEventBookingInfoList)
            {
                nudMinPax.Value = int.Parse(_oEventBookingInfo.NumberOfLiveOut.ToString());
                cboEventType.SelectedValue = _oEventBookingInfo.EventType;
                nudMaxPax.Value = int.Parse(_oEventBookingInfo.NumberOfPaxGuaranteed.ToString());
                cboEventPackage.SelectedValue = _oEventBookingInfo.EventPackage;
                txtEstimatedCost.Text = string.Format("{0:###,##0.#0}", _oEventBookingInfo.EstimatedTotalCost);
                loFolio.CreateTime = _oEventBookingInfo.BookingDate;
                txtEventName.Tag = _oEventBookingInfo.PackagePosted.ToString();
            }
        }

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

        private void loadSystemAmendments()
        {
            ReportFacade _oReportFacade = new ReportFacade();
            DataTable _dtTable = _oReportFacade.searchChangesLog(txtControlNo.Text, "remarks");
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
                grdReservationChanges.Rows.Count++;

                grdReservationChanges.SetData(grdReservationChanges.Rows.Count - 1, 0, dtRowView["Remarks"].ToString().Split(':')[0]);
                grdReservationChanges.SetData(grdReservationChanges.Rows.Count - 1, 1, dtRowView["Old_Value"].ToString());
                grdReservationChanges.SetData(grdReservationChanges.Rows.Count - 1, 2, dtRowView["New_Value"].ToString());
                grdReservationChanges.SetData(grdReservationChanges.Rows.Count - 1, 3, dtRowView["User_ID"].ToString());
                grdReservationChanges.SetData(grdReservationChanges.Rows.Count - 1, 4, dtRowView["Date_Changed"].ToString());
            }
            grdReservationChanges.AutoSizeRows();
            grdReservationChanges.AutoSizeCols();
        }

        private void loadContractAmendments()
        {
                ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();
                DataTable dtTable = _oAmendmentFacade.getAmendments(txtControlNo.Text);

                foreach (DataRow dtRow in dtTable.Rows)
                {
                    grdRequestedAmendments.Rows.Count++;

                    grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 0, dtRow["AmmendmentID"].ToString());
                    grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 1, dtRow["OldValue"].ToString());
                    grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 2, dtRow["NewValue"].ToString());
                    grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 3, dtRow["ID"].ToString());
                    grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 4, dtRow["CreatedBy"].ToString());
                    grdRequestedAmendments.SetData(grdRequestedAmendments.Rows.Count - 1, 5, dtRow["CreateTime"].ToString());
                }

                //sort by amendment id ascending
                grdRequestedAmendments.Sort(SortFlags.Ascending, 0);
                grdRequestedAmendments.AutoSizeRows();
                grdRequestedAmendments.AutoSizeCols();
                loadSystemAmendments();
        }

        private void loadContactPersons()
        {
            if (loFolio.ContactPersons != null && loFolio.ContactPersons.Count > 0)
            {
                try
                {
                    this.grdContactPersons.Rows.Count = 1;
                    int _row = this.grdContactPersons.Rows.Count - 1;
                    foreach (ContactPerson _contactPerson in loFolio.ContactPersons)
                    {
                        this.grdContactPersons.Rows.Count += 1;
                        _row = this.grdContactPersons.Rows.Count - 1;
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
                        this.grdContactPersons.SetData(_row, 0, _contactPerson.LastName);
                        this.grdContactPersons.SetData(_row, 1, _contactPerson.FirstName);
                        this.grdContactPersons.SetData(_row, 2, _contactPerson.MiddleName);
                        this.grdContactPersons.SetData(_row, 3, _contactPerson.Designation);
                        this.grdContactPersons.SetData(_row, 4, _contactPerson.PersonType);
                        this.grdContactPersons.SetData(_row, 5, _contactPerson.Address);
                        this.grdContactPersons.SetData(_row, 6, _contactPerson.TelNo);
                        this.grdContactPersons.SetData(_row, 7, _contactPerson.MobileNo);
                        this.grdContactPersons.SetData(_row, 8, _contactPerson.FaxNo);
                        this.grdContactPersons.SetData(_row, 9, _contactPerson.Email);
                        this.grdContactPersons.SetData(_row, 10, _contactPerson.BirthDate.Date);
                        this.grdContactPersons.SetData(_row, 11, _contactPerson.ContactID);
                        if (_contactPerson.PersonType == "Decision Maker")
                        {
                            this.grdContactPersons.Rows[_row].Style = this.grdContactPersons.Styles["decisionmaker"];
                        }
                    }
                    this.grdContactPersons.Cols[4].Editor = lcboPersonType;
                    this.grdContactPersons.Cols[10].Editor = ldtpDatePicker;

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

        private void loadEventOfficers()
        {
            if (loFolio.EventOfficers != null)
            {
                try
                {
                    int _row = this.grdEventOfficers.Rows.Count;
                    this.grdEventOfficers.Rows.Count = 1;
                    foreach (EventOfficer _eventOfficer in loFolio.EventOfficers)
                    {
                        _row = this.grdEventOfficers.Rows.Count;
                        this.grdEventOfficers.Rows.Count++;

                        /**
                         * 0 - lastname
                         * 1 - firstname
                         * */
                        this.grdEventOfficers.SetData(_row, 0, _eventOfficer.LastName);
                        this.grdEventOfficers.SetData(_row, 1, _eventOfficer.FirstName);
                        this.grdEventOfficers.SetData(_row, 2, _eventOfficer.UserID);
                        this.grdEventOfficers.SetData(_row, 3, _eventOfficer.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @ loadEventOfficers\r\n" + ex.Message);
                }
            }
        }

        private void loadRoomRequirements()
        {
            try
            {
                //EventRoomRequirementFacade _oRoomRequirementFacade = new EventRoomRequirementFacade();
                //GenericList<EventRoomRequirements> _oEventBookingInfoList = new GenericList<EventRoomRequirements>();
                //_oEventBookingInfoList = _oRoomRequirementFacade.getRoomRequirements(txtControlNo.Text);
                //int _rooms = 0;
                //int _pax = 0;

                //foreach (EventRoomRequirements _oEventRoomRequirement in _oEventBookingInfoList)
                //{
                //    //gridRooms.Rows.Count++;

                //    //gridRooms.SetData(gridRooms.Rows.Count - 1, 0, _oEventRoomRequirement.RoomType);
                //    //gridRooms.SetData(gridRooms.Rows.Count - 1, 1, _oEventRoomRequirement.NumberOfRooms.ToString());
                //    //gridRooms.SetData(gridRooms.Rows.Count - 1, 2, _oEventRoomRequirement.NumberOfPax.ToString());
                //    //nudGuaranteedRooms.Value = _oEventRoomRequirement.GuaranteedRooms;
                //    //nudGuaranteedPax.Value = _oEventRoomRequirement.GuaranteedPax;
                //    //try
                //    //{
                //    //    gridRooms.SetData(gridRooms.Rows.Count - 1, 3, _oEventRoomRequirement.BlockedRooms.ToString());
                //    //}
                //    //catch
                //    //{
                //    //    gridRooms.SetData(gridRooms.Rows.Count - 1, 3, 0);
                //    //}
                //    //txtRoomRemarks.Text = _oEventRoomRequirement.Remarks;

                //    _rooms += _oEventRoomRequirement.NumberOfRooms;
                //    _pax += _oEventRoomRequirement.NumberOfPax;

                //    //if #of rooms blocked is less than #of rooms needed, backcolor will be red
                //    //if (_oEventRoomRequirement.BlockedRooms < _oEventRoomRequirement.NumberOfRooms)
                //    //{
                //    //    gridRooms.Rows[gridRooms.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Red;
                //    //}
                //}

                //nudMaxPax.Value = _pax;

                getFolioSchedules();
            }
            catch (Exception ex)
            { }
        }//<<

        private void getFolioSchedules()
        {
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            IList<Schedule> _oScheduleList = _oScheduleFacade.getFolioScheduleList(txtControlNo.Text);
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

        private void loadRequirementDetails()
        {
            EventRequirementsFacade _oEventRequirementFacade = new EventRequirementsFacade();
            GenericList<EventRequirements> _oEventRequirementList = _oEventRequirementFacade.getEventRequirements(txtControlNo.Text);

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
        private decimal lTotalPayment = 0;
        public void loadFolioDeposits()
        {
            //grdDeposits.Rows.Count = 1;
            FolioFacade _oFolioFacade = new FolioFacade();
            FolioTransactions _oFolioTransactions = new FolioTransactions();
            _oFolioTransactions = _oFolioFacade.GetFolioTransactions(txtControlNo.Text, "A");
            foreach (FolioTransaction _oFolioTrans in _oFolioTransactions)
            {
                if (_oFolioTrans.AcctSide == "CREDIT")
                {
                    //grdDeposits.Rows.Count++;
                    //grdDeposits.SetData(grdDeposits.Rows.Count - 1, 0, _oFolioTrans.TransactionDate);
                    //grdDeposits.SetData(grdDeposits.Rows.Count - 1, 1, _oFolioTrans.BaseAmount);
                    //grdDeposits.SetData(grdDeposits.Rows.Count - 1, 2, _oFolioTrans.ReferenceNo);
                    lTotalPayment += _oFolioTrans.BaseAmount;
                }
            }

            decimal _totaldeposit = lTotalPayment;
            decimal _totalbal = 0;

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
            txtEstimatedBalance.Text = string.Format("{0:###,##0.#0}", _totalbal);

            //txtContractAmount_TextChanged(null, null);
           // txtTotalEstimatedCost_TextChanged_1(null, null);
        }
     

        private string getRoomsForIntegration(int pColumn)
        {
            string _rooms = "";
            for (int i = 1; i < grdSchedules.Rows.Count; i++)
            {
                if (!_rooms.Contains(grdSchedules.GetDataDisplay(i, pColumn)))
                {
                    _rooms = _rooms + grdSchedules.GetDataDisplay(i, pColumn) + "/";
                }
            }
            if (_rooms != "")
            {
                _rooms = _rooms.Substring(0, _rooms.Length - 1);
            }
            return _rooms;
        }

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

        private void updateSchedules()
        {
            if (grdSchedules.Rows.Count > 1)
            {
                grdRequirementSchedules.Rows.Count = 1;
                grdNewAmendment.Rows.Count = 1;
            }
            else
            {
                return;
            }

            for (int i = 1; i < grdSchedules.Rows.Count; i++)
            {
                grdRequirementSchedules.Rows.Count++;
                grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 0, grdSchedules.GetDataDisplay(i,"room"));
                grdRequirementSchedules[grdRequirementSchedules.Rows.Count - 1, 1] = lcboReqDates;
                grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 1, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(grdSchedules.GetDataDisplay(i, "fromDate"))));

                grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 2, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(grdSchedules.GetDataDisplay(i, "fromDate"))));
                grdRequirementSchedules.SetData(grdRequirementSchedules.Rows.Count - 1, 3, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(grdSchedules.GetDataDisplay(i, "toDate"))));

                grdNewAmendment.Rows.Count++;
                grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 0, grdSchedules.GetDataDisplay(i, "room"));
                grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 1, grdSchedules.GetDataDisplay(i, "fromDate"));
                grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 2, grdSchedules.GetDataDisplay(i, "toDate"));
                grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 3, grdSchedules.GetDataDisplay(i, "startTime"));
                grdNewAmendment.SetData(grdNewAmendment.Rows.Count - 1, 4, grdSchedules.GetDataDisplay(i, "endTime"));
            }

        }

             private void computePackageAmount()
        {
            //double _packageAmount = 0;
            //foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
            //{
            //    if (_row.Index != 0)
            //    {
            //        DateTime _from = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 11));
            //        DateTime _to = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 12));
            //        TimeSpan _d = _to.Subtract(_from);
            //        int _diff = _d.Days + 1;
            //        _packageAmount += (double.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 10)) * Math.Abs(_diff));
            //    }
            //}
            //txtPackageAmount.Text = string.Format("{0:###,##0.#0}", _packageAmount);

            getTotalEstimatedCost();
        }

        private void getTotalEstimatedCost()
        {
            decimal _packageAmount = decimal.Parse(lTotalRecurredChargePackage.ToString());
            decimal _roomRatesAmount = 0;
            decimal _mealRatesAmount = 0;

            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
            GenericList<RoomEvents> _oRoomEventsList = _oRoomEventFacade.getChildFoliosRoomEvents(txtControlNo.Text);
            foreach (RoomEvents _oRoomEvent in _oRoomEventsList)
            {
                _roomRatesAmount += _oRoomEvent.RoomRate;
            }

            //foreach (TreeNode _treeNode in treeFoodBev.Nodes)
            //{
            //    if (_treeNode.Parent == null)
            //    {
            EventFoodRequirementsFacade _oFoodRequirementsFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oFoodRequirementsList = _oFoodRequirementsFacade.getFoodRequirements(txtControlNo.Text);
            foreach (EventFoodRequirements _oEventFoodRequirements in _oFoodRequirementsList)
            {
                _mealRatesAmount += _oEventFoodRequirements.TotalMealCost;
            }
            //    }
            //}

            decimal _totalCost = _packageAmount + _roomRatesAmount + _mealRatesAmount;
            txtEstimatedCost.Text = string.Format("{0:###,##0.#0}", _totalCost);
        }
        #endregion

        private void btnPaymentSlip_Click(object sender, EventArgs e)
        {
            try
            {

                Jinisys.Hotel.Reports.Presentation.PaymentOrderUI _frmPaymentOrderUI = new Jinisys.Hotel.Reports.Presentation.PaymentOrderUI(loFolio.FolioID,loFolio.GroupName,loFolio.CompanyID,(txtCompanyName.Text!="")?txtCompanyName.Text:txtLastName.Text +" "+txtFirstName.Text);
                _frmPaymentOrderUI.MdiParent = this.MdiParent;
                _frmPaymentOrderUI.Show();

            }
            catch
            {
            }
        }

        private void nudGuaranteedPax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            btnCancelReservation_Click();
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
                if (oFolioFacade.CheckStatusToCancel(txtControlNo.Text) == true)
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
                    oFolioFacade.setFolioStatus(txtControlNo.Text, "CANCELLED", reason, reasonType, bookingType);
                    //oFolioFacade.updateFolio(oFolio);
                    //update group's dependent folios to cancelled
                    oFolioFacade.SetChildFolioStatus(txtControlNo.Text, "CANCELLED", reason);

                    //cancell group's room events and also its child's room events
                    RoomEventFacade oRoomEventFacade = new RoomEventFacade();
                    oRoomEventFacade.CancelRoomEvents(txtControlNo.Text, "RESERVATION", "CANCELLED");
                    DataTable getChildFolio = oFolioFacade.GetChildFoliosTable(txtControlNo.Text);
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
                    string _event =  txtControlNo.Text;
                    GenericList<RoomBlock> _oRoomBlockList = _oRoomBlockFacade.getBlockedRoomsForEvent(_event);
                    foreach (RoomBlock _oRoomBlock in _oRoomBlockList)
                    {
                        _oRoomBlockFacade.deleteRoomBlockedByEvent(_oRoomBlock.RoomID, txtControlNo.Text, ref trans);
                    }
                    //<<

                    trans.Commit();
                    updateCurrentRoomStatus();
                    this.Close();
                }
            }
            //}
        }

        private void ReservationUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult rsp = MessageBox.Show("You are currently processing reservation.\r\n\r\nChanges will not be saved.\r\n\r\nClick Ok to exit without saving.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (rsp == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            
        }
      

      

      
    }
}