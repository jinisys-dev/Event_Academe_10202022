using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class RoomSuperTypeUI : Form
    {
        public RoomSuperTypeUI()
        {
            InitializeComponent();
            loRoomSuperTypeFacade = new RoomSuperTypeFacade();
            lControlListener = new ControlListener();
        }

        private void RoomSuperTypeUI_Load(object sender, EventArgs e)
        {
            loadRoomSuperTypes();

            if (grdRateCodes.Rows.Count > 1)
            {
                grdRateCodes.Select(1, 0);
            }

            lControlListener.Listen(this);

            setActionButtonStates(true);
        }

        #region VARIABLES
        private DataTable loRoomSuperTypesTable;
        private RoomSuperTypeFacade loRoomSuperTypeFacade;
        private RoomSuperTypes loRoomSuperTypes;
        enum OperationMode { ADD, EDIT };
        private OperationMode lOperationMode;
        private ControlListener lControlListener;
        #endregion

        private void loadRoomSuperTypes()
        {
            grdRateCodes.Rows.Count = 1;
            loRoomSuperTypesTable = new DataTable();
            loRoomSuperTypesTable = loRoomSuperTypeFacade.getRoomSuperTypes();

            foreach (DataRow _dRow in loRoomSuperTypesTable.Rows)
            {
                grdRateCodes.Rows.Count++;
                grdRateCodes.SetData(grdRateCodes.Rows.Count - 1, 0, _dRow["RoomSuperType"]);
            }
        }

        private void grdRateCodes_RowColChange(object sender, EventArgs e)
        {
            lControlListener.StopListen(this);
            try
            {
                DataRow[] _oRoomSuperType = loRoomSuperTypesTable.Select("RoomSuperType = '" + grdRateCodes.GetDataDisplay(grdRateCodes.Row, 0) + "'");
                txtRoomSuperType.Text = _oRoomSuperType[0]["RoomSuperType"].ToString();
                txtDescription.Text = _oRoomSuperType[0]["Description"].ToString();
            }
            catch { }
            lControlListener.Listen(this);
        }

        private bool hasChanges()
        {
            if (this.Text.IndexOf("*") > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isRequiredEntriesFilled()
        {
            if (this.txtRoomSuperType.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void assignEntityValues()
        {
            loRoomSuperTypes = new RoomSuperTypes();
            loRoomSuperTypes.RoomSuperType = txtRoomSuperType.Text;
            loRoomSuperTypes.Description = txtDescription.Text;
            loRoomSuperTypes.UpdatedBy = GlobalVariables.gLoggedOnUser;
            loRoomSuperTypes.CreatedBy = GlobalVariables.gLoggedOnUser;
            loRoomSuperTypes.HotelID = GlobalVariables.gHotelId;
        }

        private bool Save()
        {
            try
            {
                loRoomSuperTypeFacade = new RoomSuperTypeFacade();
                loRoomSuperTypeFacade.saveRoomSuperType(loRoomSuperTypes);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool Update()
        {
            try
            {
                loRoomSuperTypeFacade = new RoomSuperTypeFacade();
                loRoomSuperTypeFacade.updateRoomSuperType(loRoomSuperTypes);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void setActionButtonStates(bool state)
        {
            this.btnNew.Enabled = state;
            this.btnDelete.Enabled = state;
            this.btnSave.Enabled = !state;
            this.btnCancel.Enabled = !state;
        }

        private void setOperationMode(OperationMode pOperationMode)
        {
            lOperationMode = pOperationMode;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setOperationMode(OperationMode.ADD);
            lControlListener.StopListen(this);
            clearText();
            setActionButtonStates(false);
        }

        private void clearText()
        {
            txtRoomSuperType.Text = "";
            txtDescription.Text = "";

            txtRoomSuperType.Enabled = true;
            txtRoomSuperType.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isRequiredEntriesFilled())
            {
                assignEntityValues();
                switch (lOperationMode)
                {
                    case OperationMode.ADD:
                        if (Save())
                        {
                            MessageBox.Show("Item successfully added.", "Room Super Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadRoomSuperTypes();
                            this.Text = "Room Super Type";

                            setActionButtonStates(true);
                            lControlListener.Listen(this);

                        }
                        break;

                    case OperationMode.EDIT:
                        if (Update())
                        {
                            MessageBox.Show("Item successfully updated.", "Room Super Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadRoomSuperTypes();
                            this.Text = "Room Super Type";
                            
                            setActionButtonStates(true);
                            lControlListener.Listen(this);
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid operation mode", "Abort operation");
                        break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Text = "Room Super Type";
            setActionButtonStates(true);
            lControlListener.Listen(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.lControlListener.StopListen(this);
            if (MessageBox.Show("Are you certain you want to remove '" + this.grdRateCodes.GetDataDisplay(this.grdRateCodes.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    loRoomSuperTypeFacade = new RoomSuperTypeFacade();
                    loRoomSuperTypeFacade.deleteRoomSuperType(txtRoomSuperType.Text);

                    loadRoomSuperTypes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No rows deleted.\n" + ex.Message, "Database Update Error");
                }
            }
            this.lControlListener.Listen(this);
        }

        private void RoomSuperTypeUI_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.EDIT);
                setActionButtonStates(false);
            }
            else
            {
                setActionButtonStates(true);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}