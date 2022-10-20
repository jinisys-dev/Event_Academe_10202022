using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Accounts.Presentation
{
    public partial class AgentUI : Form
    {
        public AgentUI()
        {
            InitializeComponent();
            oControlListener = new ControlListener();
            oAgentFacade = new AgentFacade();
        }

        
		#region "VARIABLES/CONSTANTS/OBJECTS"

		ControlListener oControlListener;
		private OperationMode mOperationMode;
		private AgentFacade oAgentFacade;
		private IList<Agent> ilAgents;

		#endregion

		#region "METHODS"

		private void loadData()
		{
			oAgentFacade = new AgentFacade();

			ilAgents = oAgentFacade.getAgents();

			this.grdAgents.Rows.Count = ilAgents.Count + 1;
			int i = 1;
			foreach (Agent Agent in ilAgents)
			{
	
				this.grdAgents.SetData(i, 0, Agent.AgentID);
				this.grdAgents.SetData(i, 1, Agent.Agency);
				i++;
			}

			grdAgents_RowColChange(this, new EventArgs());

			setActionButtonStates(true);
		}

		private void viewRecord(string AgentId)
		{
			foreach (Agent Agent in ilAgents)
			{
				if (Agent.AgentID == AgentId)
				{

					this.lblAgentID.Text = Agent.AgentID;
					this.txtAgency.Text = Agent.Agency;
					this.txtContactPerson.Text = Agent.ContactPerson;
					this.txtAddress.Text = Agent.Address;
                    txtContactNo.Text = Agent.ContactNumber;

					return;
				}
			}
		}

		/********************************************************
         * Purpose: Set the state of the button
         *********************************************************/
		private void setActionButtonStates(bool a_states)
		{
			//this.btnSearch.Enabled = pStates;
			this.btnDelete.Enabled = a_states;
			this.btnNew.Enabled = a_states;
			this.btnSave.Enabled = !a_states;
			this.btnCancel.Enabled = !a_states;
			this.btnClose.Enabled = a_states;

			// set CANCEL BUTTON for this form
			// if in EDIT/ADD mode CANCEL BUTTON is btnCancel
			// else CANCEL BUTTON is btnClose
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
			mOperationMode = a_OperationMode;
		}

		#endregion

		#region "EVENTS"

		private void AgentUI_TextChanged(object sender, EventArgs e)
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

		private void AgentUI_Load(object sender, EventArgs e)
		{
			loadData();
		}

        private void clearText()
        {
            txtAddress.Text = "";
            txtAgency.Text = "";
            txtContactNo.Text = "";
            txtContactPerson.Text = "";
            lblAgentID.Text = "";
        }

		private void grdAgents_RowColChange(object sender, EventArgs e)
		{
			oControlListener.StopListen(this);
			try
			{
                if (grdAgents.Rows.Count == 1)
                {
                    clearText();
                    return;
                }

				int row = this.grdAgents.Row;
				string AgentId = this.grdAgents.GetDataDisplay(row, 0);

				viewRecord(AgentId);
			}
			catch
			{ }
			finally
			{
				oControlListener.Listen(this);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{

			if (this.grdAgents.Rows.Count > 1)
			{
				this.grdAgents_RowColChange(this, new EventArgs());
			}


			this.Text = "Agents";
			setActionButtonStates(true);
			oControlListener.Listen(this);

		}

		#endregion

		private void btnNew_Click(object sender, EventArgs e)
		{
			setOperationMode(OperationMode.Add);
			oControlListener.StopListen(this);

			initializeBlankForm();
			this.txtAgency.Focus();

			setActionButtonStates(false);
		}

		private void initializeBlankForm()
		{
			this.lblAgentID.Text = "AUTO";
			this.txtAgency.Text = "";
			this.txtContactPerson.Text = "";
			this.txtAddress.Text = "";
            this.txtContactNo.Text = "";
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (checkRequiredFields())
			{
                DialogResult rsp = MessageBox.Show("Save Agent information ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {

                    Agent oAgent = new Agent();
                    initializeNewAgentObject(ref oAgent);

                    if (mOperationMode == OperationMode.Add)
                    {
                        insertNewAgent(oAgent);
						
                    } // else if operation mode is EDIT
                    else
                    {
                        oAgent.AgentID = this.lblAgentID.Text;
                        updateAgentInfo(oAgent);
                    }

					setActionButtonStates(true);
					this.Text = "Agents";
					btnCancel_Click(sender, new EventArgs());
                }

			}
		}

		/* checks if all required fields are not empty
		 * returns true if all required fields are not empty
		 */ 
		private bool checkRequiredFields()
		{
            //if (this.txtAgency.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please input license number.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtAgency.Focus();
            //    return false;
            //}

            //if (this.txtContactPerson.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please input Agent's last name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtContactPerson.Focus();
            //    return false;
            //}

            //if (this.txtAddress.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Please input Agent's first name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtAddress.Focus();
            //    return false;
            //}

			return true;
		}

		private void initializeNewAgentObject(ref Agent a_Agent)
		{
			a_Agent.Agency = this.txtAgency.Text;
			a_Agent.ContactPerson = this.txtContactPerson.Text;
			a_Agent.Address = this.txtAddress.Text;
            a_Agent.ContactNumber = txtContactNo.Text;
		}

		private void insertNewAgent(Agent a_Agent)
		{
			oAgentFacade = new AgentFacade();

			try
			{
				oAgentFacade.insertNewAgent(a_Agent, ref ilAgents);

				int lastRow = this.grdAgents.Rows.Count;
				this.grdAgents.Rows.Count += 1;
				this.grdAgents.SetData(lastRow, 0, a_Agent.AgentID);
				this.grdAgents.SetData(lastRow, 1, a_Agent.Agency);

				this.grdAgents.Row = lastRow;
				this.grdAgents_RowColChange(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void updateAgentInfo(Agent a_Agent)
		{
			oAgentFacade = new AgentFacade();

			try
			{
				oAgentFacade.updateAgentInfo(a_Agent, ref ilAgents);

				int row = this.grdAgents.Row;
				//this.grdAgents.set_TextMatrix(lastRow, 0, a_Agent.AgentId);
                this.grdAgents.SetData(row, 1, a_Agent.Agency);

				//this.grdAgents.Row = lastRow;
				this.grdAgents_RowColChange(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Remove this Agent from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                oAgentFacade = new AgentFacade();

                try
                {
                    string AgentId = this.lblAgentID.Text;

                    oAgentFacade.deleteAgent(AgentId, ref ilAgents);

                    this.grdAgents.RemoveItem(this.grdAgents.Row);

                    if (this.grdAgents.Rows.Count > 1)
                    {
                        this.grdAgents.Row = 1;
                        this.grdAgents_RowColChange(this, new EventArgs());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}