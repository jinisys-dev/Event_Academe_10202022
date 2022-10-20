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
    public partial class ChangePasswordUI : Form
    {

        private User oUser = null;
        public ChangePasswordUI(Object a_User)
        {
            InitializeComponent();

            oUser = (User)a_User;

            loadPersonalInfo();
        }


        private int loadPersonalInfo()
        {
            this.lblUserName.Text = oUser.UserId.ToUpper();
            this.lblWelcome.Text = oUser.FirstName + " " + oUser.LastName + " , ";
            this.lblLoggedTime.Text = string.Format("{0:ddd. MMMM dd, yyyy hh:mm:ss tt}",oUser.LoggedTime);
            this.lblRoles.Text = "";
            foreach(Role role in oUser.Roles)
            {
                lblRoles.Text += role.RoleName + "\r\n";
            }

            return 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (oUser.Password.Equals(this.txtOldPassword.Text))
            {

                if (this.txtPassword.Text.Equals(this.txtConfirmPassword.Text))
                {
                    oUser.Password = this.txtPassword.Text;
                    updateUser();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("The passwords you typed do not match. Type the new password in both textboxes.","Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtConfirmPassword.Focus();
                    this.txtConfirmPassword.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Old password is incorrect. Letters in passwords must be typed using the correct case.","Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtOldPassword.Focus();
                this.txtOldPassword.SelectAll();
            }
        }

        private bool updateUser()
        {
            UserFacade oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);

            if (oUserFacade.changeUserPassword(oUser))
            {
                MessageBox.Show("Your password has been changed.","Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnOk_Click(sender, new EventArgs());
            }
        }

    }
}