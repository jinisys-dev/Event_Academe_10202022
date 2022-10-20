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
	public partial class TransactionSourceDocumentUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
	{

		#region "CONSTRUCTORS"

		public TransactionSourceDocumentUI()
		{
			InitializeComponent();

			oControlListener = new ControlListener();
		}

		#endregion

		#region "VARIABLES/CONSTANTS/OBJECTS"

		ControlListener oControlListener;
		private OperationMode mOperationMode;
		private TransactionSourceDocumentFacade oTransactionSourceDocumentFacade;
		private IList<TransactionSourceDocument> ilTransactionSourceDocuments;

		#endregion

		#region "METHODS"

		private void loadData()
		{
			oTransactionSourceDocumentFacade = new TransactionSourceDocumentFacade();

			ilTransactionSourceDocuments = oTransactionSourceDocumentFacade.getTransactionSourceDocuments();

			this.grdTransactionSources.Rows = ilTransactionSourceDocuments.Count + 1;
			int i = 1;
			foreach (TransactionSourceDocument TransactionSourceDocument in ilTransactionSourceDocuments)
			{
	
				this.grdTransactionSources.set_TextMatrix(i, 0, TransactionSourceDocument.TransactionSourceId);
				this.grdTransactionSources.set_TextMatrix(i, 1, TransactionSourceDocument.Description);


				i++;
			}

			grdTransactionSourceDocuments_RowColChange(this, new EventArgs());
			setActionButtonStates(true);
		}

		private void viewRecord(string TransactionSourceDocumentId)
		{
			foreach (TransactionSourceDocument TransactionSourceDocument in ilTransactionSourceDocuments)
			{
				if (TransactionSourceDocument.TransactionSourceId == TransactionSourceDocumentId)
				{

					this.lblSourceId.Text = TransactionSourceDocument.TransactionSourceId;
					//this.lblTotalCommission.Text = TransactionSourceDocument.TotalCommission.ToString("N");
					this.txtAbbreviation.Text = TransactionSourceDocument.Abbreviation;
					this.txtDescription.Text = TransactionSourceDocument.Description;
					//this.txtFirstName.Text = TransactionSourceDocument.FirstName;
					//this.txtMiddleName.Text = TransactionSourceDocument.MiddleName;

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

		private void TransactionSourceDocumentUI_TextChanged(object sender, EventArgs e)
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

		private void TransactionSourceDocumentUI_Load(object sender, EventArgs e)
		{
			loadData();
		}

		private void grdTransactionSourceDocuments_RowColChange(object sender, EventArgs e)
		{
			oControlListener.StopListen(this);
			try
			{
				int row = this.grdTransactionSources.Row;
				string TransactionSourceDocumentId = this.grdTransactionSources.get_TextMatrix(row, 0);

				viewRecord(TransactionSourceDocumentId);
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

			if (this.grdTransactionSources.Rows > 1)
			{
				this.grdTransactionSourceDocuments_RowColChange(this, new EventArgs());
			}


			this.Text = "TransactionSourceDocuments";
			setActionButtonStates(true);
			oControlListener.Listen(this);

		}

		#endregion

		private void btnNew_Click(object sender, EventArgs e)
		{
			setOperationMode(OperationMode.Add);
			oControlListener.StopListen(this);

			initializeBlankForm();
			this.txtAbbreviation.Focus();

			setActionButtonStates(false);
		}

		private void initializeBlankForm()
		{
			this.lblSourceId.Text = "AUTO";
			//this.lblTotalCommission.Text = "0.00";
			this.txtAbbreviation.Text = "";
			this.txtDescription.Text = "";
			//this.txtFirstName.Text = "";
			//this.txtMiddleName.Text = "";
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (checkRequiredFields())
			{
				DialogResult rsp = MessageBox.Show("Save new TransactionSourceDocument entry? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (rsp == DialogResult.Yes)
				{

					TransactionSourceDocument oTransactionSourceDocument = new TransactionSourceDocument();
					initializeNewTransactionSourceDocumentObject(ref oTransactionSourceDocument);

					if (mOperationMode == OperationMode.Add)
					{
						insertNewTransactionSourceDocument(oTransactionSourceDocument);
						
					} // else if operation mode is EDIT
					else
					{
						oTransactionSourceDocument.TransactionSourceId = this.lblSourceId.Text;
						updateTransactionSourceDocumentInfo(oTransactionSourceDocument);
					}

					//setActionButtonStates(true);
					this.Text = "TransactionSourceDocuments";
					btnCancel_Click(sender, new EventArgs());
				}

			}
		}

		/* checks if all required fields are not empty
		 * returns true if all required fields are not empty
		 */ 
		private bool checkRequiredFields()
		{
			if (this.txtAbbreviation.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Please input license number.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtAbbreviation.Focus();
				return false;
			}

			if (this.txtDescription.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Please input TransactionSourceDocument's last name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtDescription.Focus();
				return false;
			}

			//if (this.txtFirstName.Text.Trim().Length <= 0)
			//{
			//    MessageBox.Show("Please input TransactionSourceDocument's first name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//    this.txtFirstName.Focus();
			//    return false;
			//}

			return true;
		}

		private void initializeNewTransactionSourceDocumentObject(ref TransactionSourceDocument a_TransactionSourceDocument)
		{
			a_TransactionSourceDocument.Abbreviation = this.txtAbbreviation.Text;
			a_TransactionSourceDocument.Description = this.txtDescription.Text;
			//a_TransactionSourceDocument.FirstName = this.txtFirstName.Text;
			//a_TransactionSourceDocument.MiddleName = this.txtMiddleName.Text;
			//a_TransactionSourceDocument.TotalCommission = double.Parse(this.lblTotalCommission.Text);
		}

		private void insertNewTransactionSourceDocument(TransactionSourceDocument a_TransactionSourceDocument)
		{
			oTransactionSourceDocumentFacade = new TransactionSourceDocumentFacade();

			try
			{
				oTransactionSourceDocumentFacade.insertNewTransactionSourceDocument(a_TransactionSourceDocument, ref ilTransactionSourceDocuments);

				int lastRow = this.grdTransactionSources.Rows;
				this.grdTransactionSources.Rows += 1;
				this.grdTransactionSources.set_TextMatrix(lastRow, 0, a_TransactionSourceDocument.TransactionSourceId);
				this.grdTransactionSources.set_TextMatrix(lastRow, 1, a_TransactionSourceDocument.Description);

				this.grdTransactionSources.Row = lastRow;
				this.grdTransactionSourceDocuments_RowColChange(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void updateTransactionSourceDocumentInfo(TransactionSourceDocument a_TransactionSourceDocument)
		{
			oTransactionSourceDocumentFacade = new TransactionSourceDocumentFacade();

			try
			{
				oTransactionSourceDocumentFacade.updateTransactionSourceDocumentInfo(a_TransactionSourceDocument, ref ilTransactionSourceDocuments);

				int row = this.grdTransactionSources.Row;
				//this.grdTransactionSourceDocuments.set_TextMatrix(lastRow, 0, a_TransactionSourceDocument.TransactionSourceDocumentId);
				this.grdTransactionSources.set_TextMatrix(row, 1, a_TransactionSourceDocument.Description);

				//this.grdTransactionSourceDocuments.Row = lastRow;
				this.grdTransactionSourceDocuments_RowColChange(this, new EventArgs());

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult response = MessageBox.Show("Remove this TransactionSourceDocument from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (response == DialogResult.Yes)
			{
				oTransactionSourceDocumentFacade = new TransactionSourceDocumentFacade();

				try
				{
					string TransactionSourceDocumentId = this.lblSourceId.Text;

					oTransactionSourceDocumentFacade.deleteTransactionSourceDocument(TransactionSourceDocumentId, ref ilTransactionSourceDocuments);

					this.grdTransactionSources.RemoveItem(this.grdTransactionSources.Row);

					if (this.grdTransactionSources.Rows > 1)
					{
						this.grdTransactionSources.Row = 1;
						this.grdTransactionSourceDocuments_RowColChange(this, new EventArgs());
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

