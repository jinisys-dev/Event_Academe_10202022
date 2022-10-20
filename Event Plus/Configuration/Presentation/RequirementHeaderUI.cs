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
    public partial class RequirementHeaderUI : Form
    {
        #region CONSTRUCTORS

        public RequirementHeaderUI()
        {
            InitializeComponent();

            this.Text = "Requirements";
            oControlListener = new ControlListener();
        }

        #endregion

        #region VARIABLES

        ControlListener oControlListener;
        private OperationMode operationMode;
        private RequirementCodeFacade oRequirementFacade;
        private GenericList<RequirementCode> oRequirement;

        #endregion

        #region METHODS

        private void loadRequirementHeader()
        {
            oRequirementFacade = new RequirementCodeFacade();
            oRequirement = oRequirementFacade.getRequirementCodes();

            this.grdRequirements.Rows = oRequirement.Count + 1;
            int i = 1;
            foreach (RequirementCode reqCode in oRequirement)
            {

                this.grdRequirements.set_TextMatrix(i, 0, reqCode.Requirement_Code);
                this.grdRequirements.set_TextMatrix(i, 1, reqCode.Description);


                i++;
            }

            grdRequirements_RowColChange(this, new EventArgs());
        }

        private void viewRecord(string requirementID)
        {
            grid.Rows = 1;
            foreach (RequirementCode requirement in oRequirement)
            {
                if (requirement.Requirement_Code == requirementID)
                {
                    this.txtRequirementID.Text = requirement.Requirement_Code;
                    this.txtDescription.Text = requirement.Description;
                }
            }

            oRequirementFacade = new RequirementCodeFacade();
            GenericList<RequirementCode> requirementDetails = oRequirementFacade.getDetailsForRequirements(requirementID);
            int ctr = 1;
            foreach (RequirementCode r in requirementDetails)
            {
                grid.Rows++;
                grid.set_TextMatrix(ctr, 0, r.Description);
                ctr++;
            }
        }

        private void setActionButtonStates(bool a_states)
        {
            this.btnDelete.Enabled = a_states;
            this.btnNew.Enabled = a_states;
            this.btnSave.Enabled = !a_states;
            this.btnCancel.Enabled = !a_states;
            this.btnClose.Enabled = a_states;

            if (a_states)
            {
                this.CancelButton = this.btnClose;
            }
            else
            {
                this.CancelButton = this.btnCancel;
            }
        }

        private void setOperationMode(OperationMode a_OperationMode)
        {
            operationMode = a_OperationMode;
        }

        private void initializeBlankForm()
        {
            foreach (Control c in grpMain.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            grid.Rows = 1;
            set_Enable(true);
            txtRequirementID.Text = "AUTO";
        }

        private void set_Enable(bool a_setEnable)
        {
            this.btnRemove.Enabled = a_setEnable;
            this.btnAdd.Enabled = a_setEnable;
        }

        private bool checkRequiredFields()
        {
            return true;
        }

        private void insertNewRequirement(RequirementCode mRequirement)
        {
            oRequirementFacade = new RequirementCodeFacade();

            try
            {
                oRequirementFacade.insertRequirementCode(mRequirement, ref oRequirement);

                int r = 1;
                while (r < grid.Rows)
                {
                    if (r != 0)
                    {
                        RequirementCode requirementDetail = new RequirementCode();
                        requirementDetail.Description = grid.GetDataDisplay(r, 0);
                        requirementDetail.Requirement_Code = mRequirement.Requirement_Code;

                        oRequirementFacade = new RequirementCodeFacade();
                        oRequirementFacade.insertRequirementDetail(requirementDetail);
                    }
                    r++;
                }

                int lastRow = this.grdRequirements.Rows;
                this.grdRequirements.Rows += 1;
                this.grdRequirements.set_TextMatrix(lastRow, 0, mRequirement.Requirement_Code);
                this.grdRequirements.set_TextMatrix(lastRow, 1, mRequirement.Description);

                this.grdRequirements.Row = lastRow;
                this.grdRequirements_RowColChange(this, new EventArgs());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateRequirementInfo(RequirementCode a_Requirement)
        {
            oRequirementFacade = new RequirementCodeFacade();

            try
            {
                oRequirementFacade.updateRequirement(a_Requirement, oRequirement);
                oRequirementFacade.deleteRequirementDetail(txtRequirementID.Text);
                int row = this.grdRequirements.Row;

                int r = 1;
                while (r < grid.Rows)
                {
                    if (r != 0)
                    {
                        RequirementCode requirementDetail = new RequirementCode();
                        requirementDetail.Description = grid.GetDataDisplay(r, 0);
                        requirementDetail.Requirement_Code = a_Requirement.Requirement_Code;

                        oRequirementFacade = new RequirementCodeFacade();
                        oRequirementFacade.insertRequirementDetail(requirementDetail);
                    }
                    r++;
                }

                this.grdRequirements.set_TextMatrix(row, 1, a_Requirement.Description);
                this.grdRequirements_RowColChange(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initializeNewRequirement(ref RequirementCode mRequirement)
        {
            mRequirement.Description = txtDescription.Text;
            mRequirement.TransactionCode = "";
        }

        #endregion

        #region EVENTS

        private void grdRequirements_RowColChange(object sender, EventArgs e)
        {
            oControlListener.StopListen(this);
            try
            {
                int row = this.grdRequirements.Row;
                string requirementID = this.grdRequirements.get_TextMatrix(row, 0);

                viewRecord(requirementID);
                set_Enable(true);
            }
            catch
            { }
            finally
            {
                oControlListener.Listen(this);
            }
        }

        private void RequirementUI_Load(object sender, EventArgs e)
        {
            loadRequirementHeader();
            setActionButtonStates(true);
            set_Enable(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.grdRequirements.Rows > 1)
            {
                this.grdRequirements_RowColChange(this, new EventArgs());
            }

            this.Text = "Requirements";
            setActionButtonStates(true);
            oControlListener.Listen(this);
            set_Enable(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setOperationMode(OperationMode.Add);
            oControlListener.StopListen(this);

            initializeBlankForm();
            this.txtDescription.Focus();

            setActionButtonStates(false);
            set_Enable(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkRequiredFields())
            {
                DialogResult rsp = MessageBox.Show("Save requirement entry? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {
                    RequirementCode oRequirement = new RequirementCode();
                    initializeNewRequirement(ref oRequirement);

                    if (operationMode == OperationMode.Add)
                    {
                        insertNewRequirement(oRequirement);
                    } 
                    else
                    {
                        oRequirement.Requirement_Code = txtRequirementID.Text;
                        updateRequirementInfo(oRequirement);
                    }

                    this.Text = "Requirements";
                    btnCancel_Click(sender, new EventArgs());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rsp = MessageBox.Show("Remove requirement type from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp == DialogResult.Yes)
            {
                oRequirementFacade = new RequirementCodeFacade();

                try
                {
                    oRequirementFacade.deleteRequirement(txtRequirementID.Text, ref oRequirement);
                    grdRequirements.RemoveItem(grdRequirements.Row);

                    if(grdRequirements.Rows>1)
                    {
                        grdRequirements.Row = 1;
                        grdRequirements_RowColChange(this, new EventArgs());
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void RequirementUI_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.Edit);
                setActionButtonStates(false);
                set_Enable(true);
            }
            else
            {
                setActionButtonStates(true);
                set_Enable(false);
            }

        #endregion
        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (operationMode.Equals(OperationMode.Add))
                this.grid.Rows++;
            else
            {
                this.Text = "Requirements*";
                this.grid.Rows++;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Text = "Requirements*";
            grid.RemoveItem(grid.Row);
        }
    }
}