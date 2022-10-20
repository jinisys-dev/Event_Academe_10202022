using System.Diagnostics;
using Jinisys.Hotel.UIFramework;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class EventPackageUI : Form
    {
        #region CONSTRUCTORS

        public EventPackageUI()
        {
            InitializeComponent();
            this.Text = "Event Packages";
            loControlListener = new ControlListener();
            loOperationMode = OperationMode.Edit;
        }

        #endregion

        #region VARIABLES

        private ControlListener loControlListener;
        private OperationMode loOperationMode;
        private GenericList<EventPackageHeader> lEventPackageHeaderList = new GenericList<EventPackageHeader>();
        private EventPackageFacade loPackageHeaderFacade;
        private EventPackageHeader loPackage = new EventPackageHeader();

        private GenericList<EventPackageDetail> loEventPackageChargesList = new GenericList<EventPackageDetail>();
        private EventPackageDetailFacade loEventPackageDetailFacade;
        private List<EventPackageDetail> loEventPackageRequirementsList = new List<EventPackageDetail>();
        private string mode = "edit";

        #endregion

        #region METHODS EVENT PACKAGE HEADER

        private void loadData()
        {
            mode = "new";
            loPackageHeaderFacade = new EventPackageFacade();
            lEventPackageHeaderList = loPackageHeaderFacade.getEventPackages();

            this.gridMain.Rows.Count = lEventPackageHeaderList.Count + 1;

            int _cntGridRows = 1;
            foreach (EventPackageHeader _package in lEventPackageHeaderList)
            {
                gridMain.SetData(_cntGridRows, 0, _package.PackageID.ToString());
                gridMain.SetData(_cntGridRows, 1, _package.Description);

                _cntGridRows++;
            }

           
            gridMain_RowColChange(this, new EventArgs());
        }

        private void viewPackageHeader(int pPackageID)
        {
            foreach (EventPackageHeader _package in lEventPackageHeaderList)
            {
                if (_package.PackageID == pPackageID)
                {
                    txtDaysApplied.Text = _package.DaysApplied.ToString();
                    txtDescription.Text = _package.Description;
                    txtPackageID.Text = _package.PackageID.ToString();
                    cboEventType.SelectedValue = int.Parse(_package.EventType);
                    txtRateAmount.Text = string.Format("{0:###,##0.#0}", _package.PackageAmount);
                    nudMaxPax.Value = decimal.Parse(_package.MaximumPax.ToString());
                    nudMinPax.Value = decimal.Parse(_package.MinimumPax.ToString());
                }
            }
        }

        private void setActionButtonStates(bool pStates)
        {
            this.btnDelete.Enabled = pStates;
            this.btnNew.Enabled = pStates;
            this.btnSave.Enabled = !pStates;
            this.btnCancel.Enabled = !pStates;
            this.btnClose.Enabled = pStates;

            if (pStates)
            {
                this.CancelButton = this.btnClose;
            }
            else
            {
                this.CancelButton = this.btnCancel;
            }
        }

        private void setOperationMode(OperationMode poOperationMode)
        {
            loOperationMode = poOperationMode;
        }

        private void initializeBlankForm()
        {
            txtDescription.Text = "";
            txtDaysApplied.Text = "0";
            txtPackageID.Text = "Auto";
            txtRateAmount.Text = "0.00";
            nudMinPax.Value = 0;
            nudMaxPax.Value = 0;
            cboEventType.Text = "";
            grid.Rows.Count = 1;

            loEventPackageChargesList.Clear();
            loEventPackageRequirementsList.Clear();
            lvwDetails.Items.Clear();
            cboRequirementType.SelectedValue = "0";
        }

        private void initializeNewEventPackage(ref EventPackageHeader poPackage)
        {
            poPackage.DaysApplied = int.Parse(txtDaysApplied.Text);
            poPackage.Description = txtDescription.Text;
            poPackage.EventType = cboEventType.SelectedValue.ToString();
            poPackage.PackageAmount = double.Parse(txtRateAmount.Text);

            poPackage.MinimumPax = int.Parse(nudMinPax.Value.ToString());
            poPackage.MaximumPax = int.Parse(nudMaxPax.Value.ToString());
        }

        private bool insertEventPackage(EventPackageHeader poEventPackage)
        {
            loPackageHeaderFacade = new EventPackageFacade();

            try
            {
                loPackageHeaderFacade.saveEventPackage(ref poEventPackage, ref lEventPackageHeaderList);

                this.gridMain.Rows.Count += 1;
                int lastRow = this.gridMain.Rows.Count - 1;
                gridMain.SetData(lastRow, 0, poEventPackage.PackageID.ToString());
                gridMain.SetData(lastRow, 1, poEventPackage.Description);

                gridMain.Row = lastRow;

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool updateEventPackage(EventPackageHeader poEventPackage)
        {
            loPackageHeaderFacade = new EventPackageFacade();
            try
            {
                loPackageHeaderFacade.updateEventPackage(poEventPackage, ref lEventPackageHeaderList);

                int lastRow = gridMain.Row;
                gridMain.SetData(lastRow, 1, poEventPackage.Description);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void loadComboBoxes()
        {
            loControlListener.StopListen(this);

            EventTypeFacade typeFacade = new EventTypeFacade();
            GenericList<EventType> eventType = typeFacade.getEventTypes();
            cboEventType.DisplayMember = "event_type";
            cboEventType.ValueMember = "eventid";
            cboEventType.DataSource = eventType;

            RequirementCodeFacade reqFacade = new RequirementCodeFacade();
            GenericList<RequirementCode> requirements = new GenericList<RequirementCode>();
            requirements = reqFacade.getRequirementCodes();
            RequirementCode _oREquirementCode = new RequirementCode();
            _oREquirementCode.Requirement_Code = "0";
            _oREquirementCode.Description = "";
            cboRequirementType.DisplayMember = "Description";
            cboRequirementType.ValueMember = "Requirement_Code";
            cboRequirementType.DataSource = requirements;

            loControlListener.Listen(this);
        }

        #endregion

        #region EVENTS

        private void EventPackageUI_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.Edit);
                setActionButtonStates(false);
            }
            else
            {
                setActionButtonStates(true);
            }
        }

        private void EventPackageUI_Load(object sender, EventArgs e)
        {
            loadComboBoxes();
            loadData();
            //loOperationMode = OperationMode.Edit;
        }

        private void gridMain_RowColChange(object sender, EventArgs e)
        {
            loControlListener.StopListen(this);
            try
            {
                int row = gridMain.Row;
                int _packageID = int.Parse(gridMain.GetDataDisplay(row, 0));

                viewPackageHeader(_packageID);
                loadEventPackageDetails();
                cboRequirementType.SelectedValue = "0";
                lvwDetails.Items.Clear();
            }
            catch { }
            finally
            {
                loControlListener.Listen(this);
                mode = "edit";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (gridMain.Rows.Count > 1)
                gridMain_RowColChange(sender, new EventArgs());

            this.Text = "Event Packages";
            setActionButtonStates(true);
            loControlListener.Listen(this);
        }

        //set the form into a blank form for creating new items
        private void btnNew_Click(object sender, EventArgs e)
        {
            setOperationMode(OperationMode.Add);
            loControlListener.StopListen(this);
            initializeBlankForm();
            this.txtDescription.Focus();
            setActionButtonStates(false);
        }

        //save the item in the database
        //then add new row and add the item into the grid
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult _rsp = MessageBox.Show("Save event package entry? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_rsp == DialogResult.Yes)
            {
                loPackage = new EventPackageHeader();
                initializeNewEventPackage(ref loPackage);

                if (loOperationMode == OperationMode.Add)
                {                    
                    if (insertEventPackage(loPackage))
                    {
                        //>>for package details
                        insertEventPackageDetails(loPackage.PackageID.ToString());

                        //>>for package requirements
                        insertEventPackageRequirements(loPackage.PackageID.ToString());
                    }

                } // else if operation mode is EDIT
                else
                {
                    loPackage.PackageID = int.Parse(txtPackageID.Text);
                    if (updateEventPackage(loPackage))
                    {
                        //>>for package details
                        insertEventPackageDetails(txtPackageID.Text);

                        //>>for package requirements
                        insertEventPackageRequirements(txtPackageID.Text);
                    }
                }

                //setActionButtonStates(true);
                this.Text = "Event Packages";
                //grid.Cols[1].Editor 
                btnCancel_Click(sender, new EventArgs());
            }
        }

        //update the item in the database as deleted
        //then remove the item in the grid
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Remove this package from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                loPackageHeaderFacade = new EventPackageFacade();

                try
                {
                    string _packageID = this.txtPackageID.Text;

                    loPackageHeaderFacade.deleteEventPackage(_packageID, ref lEventPackageHeaderList);

                    //if (this.gridMain.Rows > 1)
                    //{
                    //    this.gridMain.Row = 1;
                        this.gridMain_RowColChange(this, new EventArgs());
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            EventPackageUI_Load(sender, new EventArgs());
        }

        #endregion

        #region METHODS EVENT PACKAGE DETAILs / REQUIREMENTS

        //for displaying the recurring charges for a package in the grid
        private void loadEventPackageDetails()
        {
            grid.AllowAddNew = true;
            loEventPackageDetailFacade = new EventPackageDetailFacade();

            loEventPackageChargesList = loEventPackageDetailFacade.getEventPackageDetails(txtPackageID.Text);
            loEventPackageRequirementsList = loEventPackageDetailFacade.getEventPackageRequirements(txtPackageID.Text);

            grid.Rows.Count = 1;
            int _cntGridRows = 1;
            foreach (EventPackageDetail _packageDetail in loEventPackageChargesList)
            {
                grid.Rows.Count += 1;

                grid.SetData(_cntGridRows, 0, _packageDetail.TransactionCode.ToString());
                grid.SetData(_cntGridRows, 1, _packageDetail.Description);
                grid.SetData(_cntGridRows, 2, string.Format("{0:###,##0.#0}", _packageDetail.Amount));
                grid.SetData(_cntGridRows, 3, _packageDetail.SubAccount);

                _cntGridRows++;
            }
            grid.AllowAddNew = false;
        }

        private void insertEventPackageDetails(string pPackageID)
        {
            try
            {
                loEventPackageDetailFacade = new EventPackageDetailFacade();
                loEventPackageDetailFacade.deleteEventPackageDetail(pPackageID);

                for (int _cntGridRows = 1; _cntGridRows <= grid.Rows.Count; _cntGridRows++)
                {
                    EventPackageDetail _oEventPackageDetail = new EventPackageDetail();
                    _oEventPackageDetail.PackageID = int.Parse(pPackageID);
                    _oEventPackageDetail.Amount = double.Parse(grid.GetDataDisplay(_cntGridRows, 2));
                    _oEventPackageDetail.Description = grid.GetDataDisplay(_cntGridRows, 1);
                    _oEventPackageDetail.TransactionCode = int.Parse(grid.GetDataDisplay(_cntGridRows, 0));
                    //try
                    //{
                    //    _oEventPackageDetail.SubAccount = grid.Rows[_cntGridRows].UserData.ToString();
                    //}
                    //catch
                    //{
                    //    _oEventPackageDetail.SubAccount = "";
                    //}
                    _oEventPackageDetail.SubAccount = grid.GetDataDisplay(_cntGridRows, 3);

                    loEventPackageDetailFacade.saveEventPackageDetail(_oEventPackageDetail);
                }
            }
            catch { }
        }

        private void insertEventPackageRequirements(string pPackageID)
        {
            try
            {
                //>>for event package requirements
                loEventPackageDetailFacade = new EventPackageDetailFacade();
                loEventPackageDetailFacade.deleteEventPackageRequirements(pPackageID);

                foreach (EventPackageDetail _oEventPackageDetail in loEventPackageRequirementsList)
                {
                    _oEventPackageDetail.PackageID = int.Parse(pPackageID);
                    loEventPackageDetailFacade.saveEventPackageRequirements(_oEventPackageDetail);
                }
            }
            catch
            { }
        }

#endregion

        private void cboRequirementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mode = "new";
                loControlListener.StopListen(this);

                EventPackageDetailFacade _oEventPackageRequirementFacade = new EventPackageDetailFacade();
                List<EventPackageDetail> _oEventPackageRequirementList = _oEventPackageRequirementFacade.getEventPackageRequirements(txtPackageID.Text);

                _oEventPackageRequirementList = loEventPackageRequirementsList.FindAll(delegate(EventPackageDetail _oEventPackageDetail) { return _oEventPackageDetail.RequirementHeader.ToUpper().Contains(cboRequirementType.Text.ToUpper()); });

                if (cboRequirementType.SelectedValue != null && cboRequirementType.SelectedValue.ToString() != "")
                {
                    lvwDetails.Items.Clear();
                    RequirementCodeFacade _oRequirementCodeFacade = new RequirementCodeFacade();
                    GenericList<RequirementCode> _oRequirementCodeList = new GenericList<RequirementCode>();
                    _oRequirementCodeList = _oRequirementCodeFacade.getDetailsForRequirements(cboRequirementType.SelectedValue.ToString());

                    foreach (RequirementCode _oRequirementCode in _oRequirementCodeList)
                    {
                        lvwDetails.Items.Add(_oRequirementCode.Description, _oRequirementCode.Description, "");

                        foreach (EventPackageDetail _oEventPackageDetail in _oEventPackageRequirementList)
                        {
                            if (_oRequirementCode.Description == _oEventPackageDetail.RequirementDetail)
                            {
                                lvwDetails.Items[_oRequirementCode.Description].Checked = true;
                            }
                        }
                    }
                }

                mode = "edit";
            }
            catch { }
        }

        private ComboBox lCboItems = new ComboBox();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (loOperationMode == OperationMode.Edit)
            {
                this.grid.Rows.Count++;
                this.Text = "Event Packages*";
            }
            else
                this.grid.Rows.Count++;

            setActionButtonStates(false);

            grid.Select(grid.BottomRow, 1);
			//grid.StartEditing(grid.BottomRow, 1);

            grid.Cols[0].AllowEditing = false;
            startEditingGrid();

            this.grid.Cols[1].Editor = lCboItems;
            grid.StartEditing(grid.BottomRow, 1);
        }

        private void startEditingGrid()
        {
            lCboItems.SelectedIndexChanged += new EventHandler(cboItems_SelectedIndexChanged);

            TransactionCodeFacade _oTransFacade = new TransactionCodeFacade();
            DataTable _dataTable = new DataTable();
            _dataTable = _oTransFacade.getTransactionCodes();
            lCboItems.DisplayMember = "Memo";
            lCboItems.ValueMember = "TranCode";
            //lCboItems.Tag = "SubAccount";
            lCboItems.DataSource = _dataTable;
        }

        private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.SetData(grid.Row, 0, lCboItems.SelectedValue.ToString());
            grid.SetData(grid.Row, 1, lCboItems.Text);
            grid.Rows[grid.Row].UserData = lCboItems.Text.Substring(lCboItems.Text.IndexOf('-') + 1);

            grid.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (loOperationMode == OperationMode.Edit)
            {
                this.Text = "Event Packages*";
            }
            
            grid.RemoveItem(grid.Row);
            computeTotalPackage();
        }

        private void computeTotalPackage()
        {
            double totalAmount = 0;
            try
            {
                for (int i = 1; i <= grid.Rows.Count; i++)
                {
                    totalAmount += double.Parse(grid.GetDataDisplay(i, 2));
                }
            }
            catch { }
            txtRateAmount.Text = string.Format("{0:###,##0.#0}", totalAmount);
        }

        private void grid_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (loOperationMode == OperationMode.Edit)
            {
                this.Text = "Event Packages*";
            }
            computeTotalPackage();
        }

        private void lvwDetails_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (mode != "new")
            {
                if (e.Item.Checked == true)
                {
                    EventPackageDetail _oEventPackageDetail = new EventPackageDetail();
                    _oEventPackageDetail.RequirementHeader = cboRequirementType.Text;
                    _oEventPackageDetail.RequirementDetail = e.Item.Text;

                    loEventPackageRequirementsList.Add(_oEventPackageDetail);
                }
                else
                {
                    EventPackageDetail _oEventPackageDetail = new EventPackageDetail();
                    try
                    {
                        _oEventPackageDetail.PackageID = int.Parse(txtPackageID.Text);
                    }
                    catch { }
                    _oEventPackageDetail.RequirementHeader = cboRequirementType.Text;
                    _oEventPackageDetail.RequirementDetail = e.Item.Text;

                    loEventPackageRequirementsList.RemoveAll(delegate(EventPackageDetail _packageDetail)
                    {
                        return _packageDetail.PackageID == _oEventPackageDetail.PackageID &&
                            _packageDetail.RequirementDetail == _oEventPackageDetail.RequirementDetail &&
                            _packageDetail.RequirementHeader == _oEventPackageDetail.RequirementHeader;
                    });
                }

                if (loOperationMode != OperationMode.Add)
                {
                    this.Text = "Event Packages*";
                }
            }
        }

        private void grid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                startEditingGrid();

                this.grid.Cols[1].Editor = lCboItems;
                grid.StartEditing(grid.Row, 1);
            }
        }

        private ComboBox lRecurringCombo = new ComboBox();
        private void grid_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (e.Col == 3)
            {
                IList<TransactionCode_SubAccount> _transSubAccounts;
                TransactionCode_SubAccountFacade _oTransFacade = new TransactionCode_SubAccountFacade();
                _transSubAccounts = _oTransFacade.loadTransactionCodeSubAccounts(grid.GetDataDisplay(e.Row, 0));
                lRecurringCombo.DisplayMember = "SubAccountCode";
                lRecurringCombo.ValueMember = "SubAccountCode";
                lRecurringCombo.DataSource = _transSubAccounts;

                grid.Cols[3].Editor = lRecurringCombo;
                //grid.StartEditing(grid.Row, 3);
            }
        }
    }
}