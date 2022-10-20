using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace Presentation
    {
        public partial class MealItemUI : Form
        {

            #region CONSTRUCTORS

            public MealItemUI()
            {
                InitializeComponent();
                this.Text = "Meal Item";
                loControlListener = new ControlListener();
                loadComboBox();
                loadMealItems();
            }

            #endregion

            #region VARIABLES

            ControlListener loControlListener;
            private OperationMode loOperationMode;
            private MealMenuItemFacade loMealItemFacade;
            private GenericList<MealMenu> loMealItemList;

            #endregion

            #region METHODS

            private void loadMealItems()
            {
                loMealItemFacade = new MealMenuItemFacade();
                loMealItemList = loMealItemFacade.getMealMenuItems();

                this.gridMain.Rows.Count = loMealItemList.Count + 1;
                int _ctr = 1;
                foreach (MealMenu _mealItem in loMealItemList)
                {
                    gridMain.SetData(_ctr, 0, _mealItem.MealMenuItemID.ToString());
                    gridMain.SetData(_ctr, 1, _mealItem.Description);

                    _ctr++;
                }

                gridMain_RowColChange(this, new EventArgs());
            }

            private void viewMealItem(string pItemID)
            {
                foreach (MealMenu _mealItem in loMealItemList)
                {
                    if (_mealItem.MealMenuItemID == pItemID)
                    {
                        txtDESCRIPTION.Text = _mealItem.Description;
                        txtEVAT.Text = _mealItem.Vat.ToString();
                        lblItemID.Text = _mealItem.MealMenuItemID.ToString();
                        txtSELLING_PRICE.Text = string.Format("{0:###,##0.#0}", _mealItem.SellingPrice);
                        txtSERVICE_CHARGE.Text = _mealItem.ServiceCharge.ToString();
                        txtUNIT.Text = _mealItem.Unit;
                        txtUNIT_COST.Text = string.Format("{0:###,##0.#0}", _mealItem.UnitCost);
                        cboGROUP_ID.SelectedValue = _mealItem.GroupID;
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

                // set CANCEL BUTTON for this form
                // if in EDIT/ADD mode CANCEL BUTTON is btnCancel
                // else CANCEL BUTTON is btnClose
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
                lblItemID.Text = "";
                txtDESCRIPTION.Text = "";
                txtEVAT.Text = "0.00";
                txtSELLING_PRICE.Text = "0.00";
                txtSERVICE_CHARGE.Text = "0.00";
                txtUNIT.Text = "";
                txtUNIT_COST.Text = "0.00";
                cboGROUP_ID.Text = "";
            }

            private void loadComboBox()
            {
                loControlListener.StopListen(this);

                MealMenuItemFacade _groupFacade = new MealMenuItemFacade();
                GenericList<MealMenu> _mealGroupList = _groupFacade.getMealGroups();
                cboGROUP_ID.DisplayMember = "Description";
                cboGROUP_ID.ValueMember = "GroupID";
                cboGROUP_ID.DataSource = _mealGroupList;

                loControlListener.Listen(this);
            }

            private bool checkRequiredFields()
            {
                if (this.cboGROUP_ID.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select group.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboGROUP_ID.Focus();
                    return false;
                }

                return true;
            }

            private void initializeNewMealItemObject(ref MealMenu pMealItem)
            {
                pMealItem.MealMenuItemID = lblItemID.Text;
                pMealItem.Description = txtDESCRIPTION.Text;
                pMealItem.GroupID = int.Parse(cboGROUP_ID.SelectedValue.ToString());
                pMealItem.SellingPrice = double.Parse(txtSELLING_PRICE.Text);
                pMealItem.ServiceCharge = double.Parse(txtSERVICE_CHARGE.Text);
                pMealItem.Unit = txtUNIT.Text;
                pMealItem.UnitCost = double.Parse(txtUNIT_COST.Text);
                pMealItem.Vat = double.Parse(txtEVAT.Text);
            }

            private void insertNewMealItem(MealMenu pMealItem)
            {
                loMealItemFacade = new MealMenuItemFacade();

                try
                {
                    loMealItemFacade.saveNewMealItem(pMealItem, ref loMealItemList);

                    int lastRow = this.gridMain.Rows.Count;
                    this.gridMain.Rows.Count += 1;
                    this.gridMain.SetData(lastRow, 0, pMealItem.MealMenuItemID.ToString());
                    this.gridMain.SetData(lastRow, 1, pMealItem.Description);

                    this.gridMain.Row = lastRow;
                    this.gridMain_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            private void updateMealItemInfo(MealMenu pMealItem)
            {
                loMealItemFacade = new MealMenuItemFacade();

                try
                {
                    loMealItemFacade.updateMealItem(pMealItem, ref loMealItemList);

                    int row = this.gridMain.Row;
                    this.gridMain.SetData(row, 1, pMealItem.Description);

                    this.gridMain_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            #endregion

            #region EVENTS

            private void MealItemUI_TextChanged(object sender, EventArgs e)
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

            private void MealItemUI_Load(object sender, EventArgs e)
            {
                
            }

            private void gridMain_RowColChange(object sender, EventArgs e)
            {
                loControlListener.StopListen(this);
                try
                {
                    int _cntRow = this.gridMain.Row;
                    string _itemID = this.gridMain.GetDataDisplay(_cntRow, 0);

                    viewMealItem(_itemID);
                }
                catch
                { }
                finally
                {
                    loControlListener.Listen(this);
                }
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                if (this.gridMain.Rows.Count > 1)
                {
                    this.gridMain_RowColChange(this, new EventArgs());
                }


                this.Text = "Meal Items";
                setActionButtonStates(true);
                loControlListener.Listen(this);
            }

            private void btnNew_Click(object sender, EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                loControlListener.StopListen(this);

                initializeBlankForm();
                lblItemID.Focus();

                setActionButtonStates(false);
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (checkRequiredFields())
                {
                    DialogResult _rsp = MessageBox.Show("Save new meal item entry? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (_rsp == DialogResult.Yes)
                    {

                        MealMenu _oMealItem = new MealMenu();
                        initializeNewMealItemObject(ref _oMealItem);

                        if (loOperationMode == OperationMode.Add)
                        {
                            insertNewMealItem(_oMealItem);

                        } // else if operation mode is EDIT
                        else
                        {
                            _oMealItem.MealMenuItemID = this.lblItemID.Text;
                            updateMealItemInfo(_oMealItem);
                        }

                        this.Text = "Meal Items";
                        btnCancel_Click(sender, new EventArgs());
                    }

                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                DialogResult _response = MessageBox.Show("Remove this meal item from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_response == DialogResult.Yes)
                {
                    loMealItemFacade = new MealMenuItemFacade();

                    try
                    {
                        string _mealItemID = this.lblItemID.Text;

                        loMealItemFacade.deleteMealItem(_mealItemID, ref loMealItemList);

                        this.gridMain.RemoveItem(this.gridMain.Row);

                        if (this.gridMain.Rows.Count > 1)
                        {
                            this.gridMain.Row = 1;
                            this.gridMain_RowColChange(this, new EventArgs());
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            #endregion
        }
    }
}