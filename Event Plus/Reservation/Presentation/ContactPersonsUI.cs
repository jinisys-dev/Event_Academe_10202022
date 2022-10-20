using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using System.Reflection;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class ContactPersonsUI : Form
    {
        #region " PROPERTIES/VARIABLES "
            private string lAccountID;
            private string lFolioID;
            private C1.Win.C1FlexGrid.C1FlexGrid lGrid;
            private ComboBox lPersonType = new ComboBox();
            private IList<EventContact> lContactPersons;

            private string[] mCheckData;
            public string[] CHECK_DATA
            {
                get
                {
                    return mCheckData;

                }
                set
                {
                    mCheckData = value;
                }
            }
        #endregion

        #region " CONSTRUCTOR "
        public ContactPersonsUI()
        {
            InitializeComponent();
        }
        public ContactPersonsUI(string pFolioID, string pAccountID, IList<EventContact> pContactPersons)
        {
            InitializeComponent();
            lAccountID = pAccountID;
            lFolioID = pFolioID;
            lContactPersons = pContactPersons;

        }
        #endregion

        #region " CONTACTS "

        private void ContactPersonsUI_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection values;
            GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

            DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
            DataView _oDataView = _oDtDropDownValues.DefaultView;

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

            //this.gridContacts.Cols[4].Editor = lPersonType;
            //this.gridContacts.Cols[10].Editor = dtpBirthDate;
            loadContactPersons();

        }

        private void mnuContactPersonAddFromList_Click(object sender, EventArgs e)
        {
        }

        private void mnuContactPersonsAddNew_Click(object sender, EventArgs e)
        {

        }

        private void mnuContactPersonsRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
        private void PrintReservationForm()
        {
            try
            {

                IList<EventContact> _EventContact = assignContactPersons();
                mCheckData = lEventChecked.ToArray();
                //object[] objParam = { (object)_EventContact };
                //Type[] objParamTypes = { typeof(IList<EventContact>) };

                //Type objectType = this.Owner.GetType();
                //MethodInfo[] objMethods = objectType.GetMethods();
                //MethodInfo method;

                //foreach (MethodInfo tempLoopVar_method in objMethods)
                //{
                //    method = tempLoopVar_method;
                //    if (method.Name.ToUpper() == "PrintReservationForm".ToUpper())
                //    {
                //        method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, lEventChecked.ToArray());
                //    }
                //}
            }
            catch { }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            PrintReservationForm();
            this.Close();
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void grdContactPersons_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col == 10)
            {
                //     grdContactPersons.Cols[10].Editor = dtpBirthDate;
            }
            if (e.Col == 4)
            {
                this.grdGLAccounts.Cols[5].Editor = lPersonType;
            }
        }
        #endregion

        #region " METHODS "
        private void loadContactPersons()
        {
            if (lContactPersons != null && lContactPersons.Count > 0)
            {
                try
                {
                    this.grdGLAccounts.Rows.Count = 1;
                    int _row = this.grdGLAccounts.Rows.Count - 1;
                    foreach (ContactPerson _contactPerson in lContactPersons)
                    {
                        this.grdGLAccounts.Rows.Count += 1;
                        _row = this.grdGLAccounts.Rows.Count - 1;
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
                        this.grdGLAccounts.SetCellCheck(_row, 0, C1.Win.C1FlexGrid.CheckEnum.Checked);
                        this.grdGLAccounts.SetData(_row, 1, _contactPerson.LastName);
                        this.grdGLAccounts.SetData(_row, 2, _contactPerson.FirstName);
                        this.grdGLAccounts.SetData(_row, 3, _contactPerson.MiddleName);
                        this.grdGLAccounts.SetData(_row, 4, _contactPerson.Designation);
                        this.grdGLAccounts.SetData(_row, 5, _contactPerson.PersonType);
                        this.grdGLAccounts.SetData(_row, 6, _contactPerson.Address);
                        this.grdGLAccounts.SetData(_row, 7, _contactPerson.TelNo);
                        this.grdGLAccounts.SetData(_row, 8, _contactPerson.MobileNo);
                        this.grdGLAccounts.SetData(_row, 9, _contactPerson.FaxNo);
                        this.grdGLAccounts.SetData(_row, 10, _contactPerson.Email);
                        this.grdGLAccounts.SetData(_row, 11, _contactPerson.BirthDate.Date);
                        this.grdGLAccounts.SetData(_row, 12, _contactPerson.ContactID);
                        if (_contactPerson.PersonType == "Decision Maker")
                        {
                            this.grdGLAccounts.Rows[_row].Style = this.grdGLAccounts.Styles["decisionmaker"];
                        }
                    }
                    //this.grdContactPersons.Cols[4].Editor = lcboPersonType;
                    //this.grdContactPersons.Cols[10].Editor = ldtpDatePicker;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @ loadContactPersons\r\n" + ex.Message);
                }
            }
        }

        private List<string> lEventChecked;
        private IList<EventContact> assignContactPersons()
        {
            lEventChecked = new List<string>();
            IList<EventContact> _contactPersons = new List<EventContact>();
            try
            {

                EventContact _oContactPerson;
                for (int row = 1; row < grdGLAccounts.Rows.Count; row++)
                {
                    if (grdGLAccounts.GetCellCheck(row, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                    {
                        lEventChecked.Add(grdGLAccounts.GetDataDisplay(row, 12).ToString());
                        _oContactPerson = new EventContact();
                        if (grdGLAccounts.GetDataDisplay(row, 11).ToString() != "")
                        {
                            _oContactPerson.ContactID = grdGLAccounts.GetDataDisplay(row, 11).ToString();
                        }
                        else
                        {
                            _oContactPerson.ContactID = "AUTO";
                        }
                        _oContactPerson.FolioID = lFolioID;
                        _oContactPerson.AccountID = lAccountID;
                        _oContactPerson.HotelID = GlobalVariables.gHotelId.ToString();
                        _oContactPerson.LastName = grdGLAccounts.GetDataDisplay(row, 1).ToString();
                        _oContactPerson.FirstName = grdGLAccounts.GetDataDisplay(row, 2).ToString();
                        _oContactPerson.MiddleName = grdGLAccounts.GetDataDisplay(row, 3).ToString();
                        _oContactPerson.Designation = grdGLAccounts.GetDataDisplay(row, 4).ToString();
                        _oContactPerson.PersonType = grdGLAccounts.GetDataDisplay(row, 5).ToString();
                        _oContactPerson.Address = grdGLAccounts.GetDataDisplay(row, 6).ToString();
                        _oContactPerson.TelNo = grdGLAccounts.GetDataDisplay(row, 7).ToString();
                        _oContactPerson.MobileNo = grdGLAccounts.GetDataDisplay(row, 8).ToString();
                        _oContactPerson.FaxNo = grdGLAccounts.GetDataDisplay(row, 9).ToString();
                        _oContactPerson.Email = grdGLAccounts.GetDataDisplay(row, 10).ToString();
                        try
                        {
                            _oContactPerson.BirthDate = DateTime.Parse(grdGLAccounts.GetDataDisplay(row, 11).ToString());
                        }
                        catch
                        {
                            _oContactPerson.BirthDate = DateTime.Parse("01-01-1900");
                        }

                        _contactPersons.Add(_oContactPerson);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignContactPersons\r\n" + ex.Message);
            }
            return _contactPersons;
        }
        #endregion


    }
}