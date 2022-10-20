using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class DropDownConfigurartionUI : Form
    {
        #region "VARIABLES"
        DropDownConfiguration oDropDownConfigurationFacade;
        DataTable oDropDownList;
        DataTable oFieldNames;
        private OperationMode mOperationMode;
        #endregion

        public DropDownConfigurartionUI()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DropDownConfigurartionUI_Load(object sender, EventArgs e)
        {
            mOperationMode = OperationMode.Edit;
            oDropDownConfigurationFacade = new DropDownConfiguration();
            loadDropDownConfiguration();
            setButtons(true);
        }

        private void loadDropDownConfiguration()
        {
            oDropDownList = oDropDownConfigurationFacade.getGroupBookingDropDown();
            oFieldNames = oDropDownConfigurationFacade.getFieldNames();
            cboFieldName.DataSource = oFieldNames;
            cboFieldName.DisplayMember = "FieldName";
        }

        private void cboFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            setGridValues();
            try
            {
                if (mOperationMode == OperationMode.Edit)
                {
                    txtValue.Text = gridItems.GetDataDisplay(gridItems.Row, 0);
                    txtID.Text = gridItems.GetDataDisplay(gridItems.Row, 1);
                }
            }
            catch { }
        }

        private void setButtons(bool pState)
        {
            btnCancel.Enabled = !pState;
            btnSave.Enabled = !pState;
            btnDelete.Enabled = pState;
            btnNew.Enabled = pState;
        }

        private void setGridValues()
        {
            DataView _dv = new DataView();
            _dv = oDropDownList.DefaultView;
            _dv.RowFilter = "FieldName = '" + cboFieldName.Text +"'";
            gridItems.Rows.Count = 1;
            int _rowCount = 0;
            foreach (DataRowView _dRow in _dv)
            {
                _rowCount++;
                gridItems.Rows.Count++;
                gridItems.SetData(_rowCount, 0, _dRow["Value"].ToString());
                gridItems.SetData(_rowCount, 1, _dRow["ID"].ToString());
            }
        }

        private void gridItems_RowColChange(object sender, EventArgs e)
        {
            try
            {
                if (this.Text.IndexOf('*') > 0 && gridItems.Rows.Count > 2)
                {
                    if (MessageBox.Show("Save changes made to " + cboFieldName.Text + " - " + txtValue.Text + " ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnSave_Click(null, null);
                    }
                    this.Text = this.Text.Remove(this.Text.IndexOf('*'));
                    setButtons(true);
                }

                if (mOperationMode == OperationMode.Edit)
                {
                    txtValue.Text = gridItems.GetDataDisplay(gridItems.Row, 0);
                    txtID.Text = gridItems.GetDataDisplay(gridItems.Row, 1);
                }
            }
            catch
            {
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (txtValue.Text != gridItems.GetDataDisplay(gridItems.Row, 0))
            {
                if(this.Text.IndexOf('*') < 1)
                {
                    this.Text = this.Text + "*";
                }
                if (this.Text.IndexOf('*') > 0)
                {
                    setButtons(false);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch(mOperationMode)
                {
                    case OperationMode.Add :
                        oDropDownConfigurationFacade.saveGroupBookingDropDown(cboFieldName.Text, txtValue.Text);
                        break;
                    case OperationMode.Edit :
                        oDropDownConfigurationFacade.updateGroupBookingDropDown(cboFieldName.Text, txtValue.Text, int.Parse(txtID.Text));
                        break;
                }
                MessageBox.Show("Saving item successful", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.None);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving item\r\n" + ex.Message);
            }
            mOperationMode = OperationMode.Edit;
            setButtons(true);
            string _temp = cboFieldName.Text;
            loadDropDownConfiguration();
            cboFieldName.Text = _temp;
            this.Text = this.Text.Remove(this.Text.IndexOf('*'));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                if (MessageBox.Show("Save changes made to " + cboFieldName.Text + " - " + txtValue.Text + " ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
                this.Text = this.Text.Remove(this.Text.IndexOf('*'));
            }
            if (this.Text.IndexOf('*') < 1)
            {
                this.Text = this.Text + "*";
            }
            mOperationMode = OperationMode.Add;
            txtValue.Text = "";
            setButtons(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtValue.Text = gridItems.GetDataDisplay(gridItems.Row, 0).ToString();
            mOperationMode = OperationMode.Edit;
            setButtons(true);
            this.Text = this.Text.Remove(this.Text.IndexOf('*'));
        }

        private void gridItems_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + cboFieldName.Text + " - " + txtValue.Text + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oDropDownConfigurationFacade.deleteGroupBookingDropDown(int.Parse(txtID.Text));
                MessageBox.Show("Item " + cboFieldName.Text + " - " + txtValue.Text + " has been deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDropDownConfiguration();
            }
        }
    }
}