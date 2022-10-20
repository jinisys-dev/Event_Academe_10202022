using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public partial class EndorsementUI : Form
	{
		// for NEW endorsement entry
		public EndorsementUI()
		{
			InitializeComponent();



			this.txtAcknowledgeAtShiftCode.Text = GlobalVariables.gShiftCode.ToString();
			this.txtAcknowledgeAtTerminalNo.Text = GlobalVariables.gTerminalID.ToString();
			this.txtAcknowledgeBy.Text = GlobalVariables.gLoggedOnUser;
			this.txtStatus.Text = "ACTIVE";

			this.txtAuditDate.Text = DateTime.Parse(GlobalVariables.gAuditDate).ToString("MMM. dd, yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt");
			this.txtShiftCode.Text = GlobalVariables.gShiftCode.ToString();
			this.txtTerminalNo.Text = GlobalVariables.gTerminalID.ToString();
			this.txtLoggedUser.Text = GlobalVariables.gLoggedOnUser;

			this.txtEndorsementDescription.Enabled = true;
			this.txtEndorsementRemarks.Enabled = false;

			this.txtEndorsementDescription.Focus();

			lAction = "NEW";

		}


		string lAction = "";
		// to Edit/Acknowledge existing endorsement
		public EndorsementUI(int pEndorsementId, string pAction)
		{
			InitializeComponent();

			lAction = pAction;

			switch (lAction)
			{ 
				case "EDIT":

					this.txtEndorsementRemarks.Enabled = false;

					loadEndorsementDetails(pEndorsementId);

					if (this.txtLoggedUser.Text.ToUpper() != GlobalVariables.gLoggedOnUser.ToUpper())
					{
						this.btnSave.Enabled = false;
						this.txtEndorsementDescription.ReadOnly = true;
					}

					break;
				case "ACKNOWLEDGED":

					loadEndorsementDetails(pEndorsementId);

					this.txtAcknowledgeAtShiftCode.Text = GlobalVariables.gShiftCode.ToString();
					this.txtAcknowledgeAtTerminalNo.Text = GlobalVariables.gTerminalID.ToString();
					this.txtAcknowledgeBy.Text = GlobalVariables.gLoggedOnUser;
					this.txtStatus.Text = "ACKNOWLEDGED";

					this.txtEndorsementDescription.ReadOnly = true;	
					this.txtEndorsementRemarks.Enabled = true;
					this.txtEndorsementRemarks.ReadOnly = false;

					this.txtEndorsementRemarks.Focus();

					this.pnlAcknowledgement.Height = 214;
					this.Height = 595;


					break;
				default:

					break;
			}
		}


		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private EndorsementFacade lEndorsementFacade;
		private Endorsement lEndorsement;
		private void loadEndorsementDetails(int pEndorsementId)
		{
			
			lEndorsementFacade = new EndorsementFacade();
			Endorsement _oEndorsement = lEndorsementFacade.getEndorsementById(pEndorsementId);


			if (_oEndorsement != null)
			{
				this.txtEndorsementId.Text = _oEndorsement.Id.ToString();
				this.txtAuditDate.Text = _oEndorsement.LogDate.ToString("MMM. dd, yyyy hh:mm:ss tt");

				this.txtTerminalNo.Text = _oEndorsement.TerminalNo.ToString();
				this.txtShiftCode.Text = _oEndorsement.ShiftCode.ToString();
				this.txtLoggedUser.Text = _oEndorsement.LoggedUser;
				this.txtEndorsementDescription.Text = _oEndorsement.EndorsementDescription;
				this.txtStatus.Text = _oEndorsement.StatusFlag;
				this.txtEndorsementRemarks.Text = _oEndorsement.EndorsementRemarks;
				this.txtAcknowledgeBy.Text = _oEndorsement.AcknowledgedBy;
				this.txtAcknowledgeAtTerminalNo.Text = _oEndorsement.AcknowledgeAtTerminal.ToString();
				this.txtAcknowledgeAtShiftCode.Text = _oEndorsement.AcknowledgeAtShiftCode.ToString();

				this.txtUpdateTime.Text = _oEndorsement.UpdateTime.ToString("MMM. dd, yyyy hh:mm:ss tt");
				//_oEndorsement.CreatedBy
				//_oEndorsement.CreateTime
				//_oEndorsement.UpdatedBy
				//_oEndorsement.UpdateTime
				//_oEndorsement.HotelId
				lEndorsement = _oEndorsement;
			}

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult rsp = MessageBox.Show("Are you sure you want to save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rsp == DialogResult.No)
				return;

			
			switch (lAction)
			{
				case "EDIT":
					try
					{
						lEndorsement.EndorsementDescription = this.txtEndorsementDescription.Text;

						lEndorsementFacade.updateEndorsement(lEndorsement);

						this.Close();
					}
					catch(Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;
				case "ACKNOWLEDGED":

					try
					{
						lEndorsement.EndorsementRemarks = this.txtEndorsementRemarks.Text;

						lEndorsementFacade.acknowledgeEndorsement(lEndorsement);

						this.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;

				case "NEW":
					lEndorsement = new Endorsement();

					lEndorsement.LogDate = DateTime.Parse(this.txtAuditDate.Text);
					lEndorsement.TerminalNo = GlobalVariables.gTerminalID;
					lEndorsement.ShiftCode = GlobalVariables.gShiftCode;
					lEndorsement.LoggedUser = GlobalVariables.gLoggedOnUser;
					lEndorsement.EndorsementDescription = this.txtEndorsementDescription.Text;
					lEndorsement.StatusFlag = "ACTIVE";
					lEndorsement.EndorsementRemarks = "";
					lEndorsement.AcknowledgedBy = "";
					lEndorsement.AcknowledgeAtTerminal = 0;
					lEndorsement.AcknowledgeAtShiftCode = 0;
					
					try
					{
						lEndorsementFacade = new EndorsementFacade();
					
						lEndorsementFacade.insertNewEndorsement(lEndorsement);

						this.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					

					break;
				default:

					break;
			}
		}


		private void txtStatus_TextChanged(object sender, EventArgs e)
		{
			if (txtStatus.Text == "ACKNOWLEDGED" && lAction != "ACKNOWLEDGED")
			{
				this.btnSave.Enabled = false;

				this.txtEndorsementDescription.ReadOnly = true;
				this.txtEndorsementRemarks.Enabled = true;
				this.txtEndorsementRemarks.ReadOnly = true;
				
				this.pnlAcknowledgement.Height = 214;
				this.Height = 595;

			}
		}

		private void EndorsementUI_Activated(object sender, EventArgs e)
		{

			if (this.Height > 421)
			{
				this.pnlAcknowledgement.Visible = true;

				this.txtEndorsementRemarks.Focus();
			}
			else
			{
				this.pnlAcknowledgement.Visible = false;

				this.txtEndorsementDescription.Focus();
			}
		}


	}
}