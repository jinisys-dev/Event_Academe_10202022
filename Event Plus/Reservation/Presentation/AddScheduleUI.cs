using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class AddScheduleUI : Form
    {
        #region "Constructors"
        public AddScheduleUI()
        {
            InitializeComponent();
        }
        #endregion

        #region "Attributes"
        private DateTime mFromDate;
        public DateTime FromDate
        {
            set { this.mFromDate = value; }
            get { return this.mFromDate; }
        }
        private DateTime mToDate;
        public DateTime ToDate
        {
            set { this.mToDate = value; }
            get { return this.mToDate; }
        }
        private DateTime mStartTime;
        public DateTime StartTime
        {
            set { this.mStartTime = value; }
            get { return this.mStartTime; }
        }
        private DateTime mEndTime;
        public DateTime EndTime
        {
            set { this.mEndTime = value; }
            get { return this.mEndTime; }
        }
        private string mRemarks;
        public string Remarks
        {
            set { this.mRemarks = value; }
            get { return this.mRemarks; }
        }
        private string mSetup;
        public string Setup
        {
            set { this.mSetup = value; }
            get { return this.mSetup; }
        }
        private string mActivity;
        public string Activity
        {
            set { this.mActivity = value; }
            get { return this.mActivity; }
        }
        private decimal mGuaranteedPax;
        public decimal GuaranteedPax
        {
            set { this.mGuaranteedPax = value; }
            get { return this.mGuaranteedPax; }
        }
        public bool mConfirmed;
        public bool Confirmed
        {
            set { this.mConfirmed = value; }
            get { return this.mConfirmed; }
        }
        #endregion

        #region "Events"
        private void AddScheduleUI_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection values;
            GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

            DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
            DataView _oDataView = _oDtDropDownValues.DefaultView;

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

            this.cboSetup.DataSource = _oDataView.ToTable();
            this.cboSetup.ValueMember = "Value";
            this.cboSetup.DisplayMember = "Value";
            this.cboSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboSetup.AutoCompleteSource = AutoCompleteSource.ListItems;

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

            cboActivity.DataSource = _oDataView.ToTable();
            cboActivity.ValueMember = "Value";
            cboActivity.DisplayMember = "Value";
            cboActivity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboActivity.AutoCompleteSource = AutoCompleteSource.ListItems;

            dtpFrom.Value = DateTime.Parse(GlobalVariables.gAuditDate);
            dtpTo.Value = dtpFrom.Value.AddDays(1);
            dtpStartTime.Value = DateTime.Parse("08/08/2008 08:00:00 AM");
            dtpEndTime.Value = DateTime.Parse("08/08/2008 05:00:00 PM");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Confirmed = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.FromDate = dtpFrom.Value;
            this.ToDate = dtpTo.Value;
            this.StartTime = dtpStartTime.Value;
            this.EndTime = dtpEndTime.Value;
            this.Setup = cboSetup.Text;
            this.Activity = cboActivity.Text;
            this.GuaranteedPax = nudGuaranteedPax.Value;
            this.Remarks = txtRemarks.Text;
            this.Confirmed = true;

            this.Close();
        }

        private void dtpFrom_Leave(object sender, EventArgs e)
        {
            dtpTo.Value = dtpFrom.Value.AddDays(1);
        }
        #endregion
    }
}