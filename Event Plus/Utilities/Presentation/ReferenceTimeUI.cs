using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Utilities.BusinessLayer;
namespace Jinisys.Hotel.Utilities.Presentation
{
    public partial class ReferenceTimeUI : Form
    {
        public ReferenceTimeUI()
        {
            InitializeComponent();
        }
        private ReferenceTimeFACADE refTimeFacade = new ReferenceTimeFACADE();
        private ReferenceTime oRefTime = new ReferenceTime();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime t;
            if (!DateTime.TryParse(this.txtReferenceTime.Text,out t))
            {
                MessageBox.Show("Not a valid time!");
                return;
            }
            if (MessageBox.Show("Update reference time values", "Update Reference Time", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                setRefTimeValues();

                if (refTimeFacade.UpdateRefTime(oRefTime))
                {
                    MessageBox.Show("Reference Time Successfully updated!");
                    this.Close();
                }

            }
        }
        private void setRefTimeValues()
        {
            oRefTime.RefTime = this.txtReferenceTime.Text;
            oRefTime.Minimum = (int)this.nudMinimum.Value;
            oRefTime.Maximum = (int)this.nudMaximum.Value;
        }
        private void setFormValues()
        {
            this.txtReferenceTime.Text = oRefTime.RefTime;
            this.nudMinimum.Value=oRefTime.Minimum ;
            this.nudMaximum.Value=oRefTime.Maximum ;
        }
        private void ReferenceTimeUI_Load(object sender, EventArgs e)
        {
           oRefTime =  refTimeFacade.GetReferenceTime();
            setFormValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}