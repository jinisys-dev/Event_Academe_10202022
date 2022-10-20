using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Security.Presentation
{
	public partial class ResetPasswordUI : Form
	{
		public ResetPasswordUI()
		{
			InitializeComponent();
		}

		string lUserId = null;
		public ResetPasswordUI(string pUserId)
		{
			InitializeComponent();

			lUserId = pUserId;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string _newPassword = this.txtPassword.Text;
			string _confirmPassword = this.txtConfirmPassword.Text;

			if (_newPassword == _confirmPassword)
			{
				DialogResult rsp = MessageBox.Show("Are you sure you want to reset user password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (rsp == DialogResult.Yes)
				{
					UserFacade _oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);

					try
					{
						bool _resetPassword = _oUserFacade.resetPassword(lUserId, _newPassword);

						if (_resetPassword)
						{
							MessageBox.Show("Transaction successful.\r\nPassword changed.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
							this.Close();
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}


				}


			}
			else
			{
				MessageBox.Show("Password did not match. Please re-type your password.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.txtConfirmPassword.Focus();
				this.txtConfirmPassword.SelectAll();
			}
		}

	
	}
}