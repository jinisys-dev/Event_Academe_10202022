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
        public partial class MealGroupUI : Form
        {
            #region CONSTRUCTORS
            public MealGroupUI()
            {
                InitializeComponent();
                this.Text = "Meal Group";
                loControlListener = new ControlListener();
            }
            #endregion

            #region VARIABLES

            ControlListener loControlListener;
            private OperationMode loOperationMode;
            private MealMenuItemFacade loMealGroupFacade;
            private GenericList<MealMenu> lMealGroupList;

            #endregion


            #region METHODS

            private void loadMealGroup()
            {
                loMealGroupFacade = new MealMenuItemFacade();
                lMealGroupList = loMealGroupFacade.getMealGroups();

                this.gridMain.Rows = lMealGroupList.Count + 1;
                int _cntRow = 1;
                foreach (MealMenu _oMealGroup in lMealGroupList)
                {
                    gridMain.set_TextMatrix(_cntRow, 0, _oMealGroup.GroupID.ToString());
                    gridMain.set_TextMatrix(_cntRow, 1, _oMealGroup.Description);

                    _cntRow++;
                }

                gridMain_RowColChange(this, new EventArgs());
            }

            private void viewMealGroup(string _groupID)
            {
                foreach (MealMenu _oMealGroup in lMealGroupList)
                {
                    if (_oMealGroup.GroupID == int.Parse(_groupID))
                    {
                        txtDESCRIPTION.Text = _oMealGroup.Description;
						this.cboMainGroupId.Text = _oMealGroup.MainGroupId;
                        lblGroupID.Text = _oMealGroup.GroupID.ToString();

                    }
                }
            }

            private void setActionButtonStates(bool pStates)
            {
                //this.btnSearch.Enabled = pStates;
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
                lblGroupID.Text = "Auto";
                txtDESCRIPTION.Text = "";
            }

            private bool checkRequiredFields()
            {
                return true;
            }

            private void initializeNewMealGroupObject(ref MealMenu poMealGroup)
            {
                poMealGroup.Description = this.txtDESCRIPTION.Text;
				poMealGroup.MainGroupId = this.cboMainGroupId.Text;
            }

            private void insertNewMealGroup(MealMenu poMealGroup)
            {
                loMealGroupFacade = new MealMenuItemFacade();

                try
                {
                    loMealGroupFacade.saveMealGroup(ref poMealGroup, ref lMealGroupList);

                    int _lastRow = this.gridMain.Rows;
                    this.gridMain.Rows += 1;
                    this.gridMain.set_TextMatrix(_lastRow, 0, poMealGroup.GroupID.ToString());
                    this.gridMain.set_TextMatrix(_lastRow, 1, poMealGroup.Description);

                    this.gridMain.Row = _lastRow;
                    this.gridMain_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            private void updateMealGroupInfo(MealMenu poMealGroup)
            {
                loMealGroupFacade = new MealMenuItemFacade();

                try
                {
                    loMealGroupFacade.updateMealGroup(ref poMealGroup, ref lMealGroupList);

                    int _cntRow = this.gridMain.Row;
                    this.gridMain.set_TextMatrix(_cntRow, 1, poMealGroup.Description);

                    this.gridMain_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            #endregion

            #region EVENTS

            private void MealGroupUI_TextChanged(object sender, EventArgs e)
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

            private void MealGroupUI_Load(object sender, EventArgs e)
            {
                loadMealGroup();
            }

            private void gridMain_RowColChange(object sender, EventArgs e)
            {
                loControlListener.StopListen(this);
                try
                {
                    int _cntRow = this.gridMain.Row;
                    string _groupID = this.gridMain.get_TextMatrix(_cntRow, 0);

                    viewMealGroup(_groupID);
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
                if (this.gridMain.Rows > 1)
                {
                    this.gridMain_RowColChange(this, new EventArgs());
                }


                this.Text = "Meal Group";
                setActionButtonStates(true);
                loControlListener.Listen(this);
            }

            private void btnNew_Click(object sender, EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                loControlListener.StopListen(this);

                initializeBlankForm();
                txtDESCRIPTION.Focus();

                setActionButtonStates(false);
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (checkRequiredFields())
                {
                    DialogResult _rsp = MessageBox.Show("Save new meal group entry? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (_rsp == DialogResult.Yes)
                    {

                        MealMenu _oMealGroup = new MealMenu();
                        initializeNewMealGroupObject(ref _oMealGroup);

                        if (loOperationMode == OperationMode.Add)
                        {
                            insertNewMealGroup(_oMealGroup);

                        } // else if operation mode is EDIT
                        else
                        {
                            _oMealGroup.GroupID = int.Parse(this.lblGroupID.Text);
                            updateMealGroupInfo(_oMealGroup);
                        }

                        //setActionButtonStates(true);
                        this.Text = "Meal Group";
                        btnCancel_Click(sender, new EventArgs());
                    }

                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                DialogResult _response = MessageBox.Show("Remove this meal group from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_response == DialogResult.Yes)
                {
                    loMealGroupFacade = new MealMenuItemFacade();

                    try
                    {
                        string _mealGroupID = this.lblGroupID.Text;

                        loMealGroupFacade.deleteMealGroup(_mealGroupID, ref lMealGroupList);

                        this.gridMain.RemoveItem(this.gridMain.Row);

                        if (this.gridMain.Rows > 1)
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

			private void txtDESCRIPTION_TextChanged(object sender, EventArgs e)
			{

			}

			private void label4_Click(object sender, EventArgs e)
			{

			}
        }
    }
}