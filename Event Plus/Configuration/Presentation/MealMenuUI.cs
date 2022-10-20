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
        public partial class MealMenuUI : Form
        {
            public MealMenuUI()
            {
                InitializeComponent();
                this.Text = "Meal Menus";
                loControlListener = new ControlListener();
            }

            #region VARIABLES

            ControlListener loControlListener;
            private OperationMode loOperationMode;
            private MealMenuItemFacade loMealMenuFacade;
            private GenericList<MealMenu> lMealMenuList;

            #endregion

            #region METHODS

            private void loadMealMenus()
            {
                loMealMenuFacade = new MealMenuItemFacade();
                lMealMenuList = loMealMenuFacade.getMealMenus();

                this.gridMain.Rows.Count = lMealMenuList.Count + 1;
                int i = 1;
                foreach (MealMenu _oMealMenu in lMealMenuList)
                {
                    gridMain.SetData(i, 0, _oMealMenu.MenuID);
                    gridMain.SetData(i, 1, _oMealMenu.Description);

                    i++;
                }

                gridMain_RowColChange(this, new EventArgs());
            }

            private void viewMealMenu(string _menuID)
            {
                foreach (MealMenu _oMealMenu in lMealMenuList)
                {
                    if (_oMealMenu.MenuID == _menuID)
                    {
                        txtDescription.Text = _oMealMenu.Description;
                        txtVat.Text = _oMealMenu.Vat.ToString();
                        lblMenuID.Text = _oMealMenu.MenuID.ToString();
                        txtSellingPrice.Text = string.Format("{0:###,##0.#0}", _oMealMenu.Price);
                        txtServiceCharge.Text = _oMealMenu.ServiceCharge.ToString();
                    }
                }
            }

            private void viewMealItems(string _menuID)
            {
                grid.Rows.Count = 1;
                loMealMenuFacade = new MealMenuItemFacade();
                GenericList<MealMenu> _mealMenuItemsList = loMealMenuFacade.getMealItemsForMenu(_menuID);

                foreach (MealMenu _mealMenuItems in _mealMenuItemsList)
                {
                    string[] items ={ _mealMenuItems.MealMenuItemID.ToString(), _mealMenuItems.Description };
                    grid.AddItem(items);
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
                lblMenuID.Text = "Auto";
                txtDescription.Text = "";
                txtVat.Text = "0.00";
                txtSellingPrice.Text = "0.00";
                txtServiceCharge.Text = "0.00";
            }

            private bool checkRequiredFields()
            {
                return true;
            }

            private void initializeNewMealMenu(ref MealMenu poMealMenu)
            {
                poMealMenu.Description = txtDescription.Text;
                poMealMenu.Price = double.Parse(txtSellingPrice.Text);
                poMealMenu.ServiceCharge = double.Parse(txtServiceCharge.Text);
                poMealMenu.Vat = double.Parse(txtVat.Text);
            }

            private void insertNewMealMenu(MealMenu poMealMenu)
            {
                loMealMenuFacade = new MealMenuItemFacade();

                try
                {
                    loMealMenuFacade.saveMealMenu(poMealMenu, ref lMealMenuList);

 
                    for (int i = 1; i <= grid.Rows.Count - 1; i++)
                    {
                        MealMenu _oMealMenuItem = new MealMenu();
                        _oMealMenuItem.MenuID = poMealMenu.MenuID;
                        _oMealMenuItem.MealMenuItemID = grid.GetDataDisplay(i, 0);

                        loMealMenuFacade.saveMenuDetail(_oMealMenuItem);
                    }

                    int _lastRow = this.gridMain.Rows.Count;
                    this.gridMain.Rows.Count += 1;
                    this.gridMain.SetData(_lastRow, 0, poMealMenu.MenuID.ToString());
                    this.gridMain.SetData(_lastRow, 1, poMealMenu.Description);

                    this.gridMain.Row = _lastRow;
                    this.gridMain_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            private void updateMealMenu(MealMenu poMealMenu)
            {
                loMealMenuFacade = new MealMenuItemFacade();

                try
                {
                    loMealMenuFacade.updateMealMenu(poMealMenu, ref lMealMenuList);
                    loMealMenuFacade.deleteMenuDetail(lblMenuID.Text);

                    for (int i = 1; i <= grid.Rows.Count - 1; i++)
                    {
                        MealMenu _oMealMenuItem = new MealMenu();
                        _oMealMenuItem.MenuID = poMealMenu.MenuID;
                        _oMealMenuItem.MealMenuItemID = grid.GetDataDisplay(i, 0);

                        loMealMenuFacade.saveMenuDetail(_oMealMenuItem);
                    }

                    int _cntRow = this.gridMain.Row;
                    this.gridMain.SetData(_cntRow, 1, poMealMenu.Description);

                    this.gridMain_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            #endregion

            #region EVENTS

            private void MealMenuUI_TextChanged(object sender, EventArgs e)
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

            private void MealMenuUI_Load(object sender, EventArgs e)
            {
                loadMealMenus();
            }

            private void gridMain_RowColChange(object sender, EventArgs e)
            {
                loControlListener.StopListen(this);
                try
                {
                    int _cntRow = this.gridMain.Row;
                    string _menuID = this.gridMain.GetDataDisplay(_cntRow, 0);

                    viewMealMenu(_menuID);
                    viewMealItems(_menuID);
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


                this.Text = "Meal Menus";
                setActionButtonStates(true);
                loControlListener.Listen(this);
            }

            private void btnNew_Click(object sender, EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                loControlListener.StopListen(this);

                initializeBlankForm();
                txtDescription.Focus();
                grid.Rows.Count = 1;

                setActionButtonStates(false);
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (checkRequiredFields())
                {
                    DialogResult _rsp = MessageBox.Show("Save meal menu entry? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (_rsp == DialogResult.Yes)
                    {

                        MealMenu _oMealMenu = new MealMenu();
                        initializeNewMealMenu(ref _oMealMenu);

                        if (loOperationMode == OperationMode.Add)
                        {
                            insertNewMealMenu(_oMealMenu);

                        } // else if operation mode is EDIT
                        else
                        {
                            _oMealMenu.MenuID = this.lblMenuID.Text;
                            updateMealMenu(_oMealMenu);
                        }

                        //setActionButtonStates(true);
                        this.Text = "Meal Menus";
                        btnCancel_Click(sender, new EventArgs());
                    }

                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                DialogResult _response = MessageBox.Show("Remove this meal menu from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_response == DialogResult.Yes)
                {
                    loMealMenuFacade = new MealMenuItemFacade();

                    try
                    {
                        string _mealMenuID = this.lblMenuID.Text;

                        loMealMenuFacade.deleteMealMenu(_mealMenuID, ref lMealMenuList);

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

            ComboBox lCboItems = new ComboBox();
            private void btnAdd_Click(object sender, EventArgs e)
            {
                if (lblMenuID.Text == "Auto")
                    setOperationMode(OperationMode.Add);
                else
                    setOperationMode(OperationMode.Edit);

                loControlListener.StopListen(this);
                setActionButtonStates(false);

                grid.Rows.Count += 1;
                grid.Select(grid.BottomRow, 1);
                grid.Cols[0].AllowEditing = false;

                lCboItems.SelectedIndexChanged += new EventHandler(cboItems_SelectedIndexChanged);

                loMealMenuFacade = new MealMenuItemFacade();
                GenericList<MealMenu> _oMealItemList = loMealMenuFacade.getMealMenuItems();
                lCboItems.DisplayMember = "Description";
                lCboItems.ValueMember = "MealMenuItemID";
                lCboItems.DataSource = _oMealItemList;

                this.grid.Cols[1].Editor = lCboItems;
            }

            private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
            {
                grid.SetData(grid.Row, 0, lCboItems.SelectedValue.ToString());
                grid.SetData(grid.Row, 1, lCboItems.Text);

                grid.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus;
            }

            private void grid_RowColChange(object sender, EventArgs e)
            {
                //loControlListener.Listen(this);
            }

            #endregion

            private void btnRemove_Click(object sender, EventArgs e)
            {
                if (grid.Rows.Count > 1)
                {
                    grid.RemoveItem(grid.Row);
                }
            }
        }
    }
}