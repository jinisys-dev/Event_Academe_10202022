using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.AccountingInterface.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class AccountingSetup : Form
    {
        public AccountingSetup()
        {
            InitializeComponent();
        }

		private BackOfficeConfig loBackOfficeConfig;
		private BackOfficeConfigFacade loBackOfficeConfigFacade;

        private string lAccountingInterface = "NAVISION";
		private string lPosting_Sched = "DAILY";


        private void btnBrowseConnection_Click(object sender, EventArgs e)
        {
            switch (lAccountingInterface)
            { 
                case "NAVISION":
                    break;

                case "ORACLE 11i":
                    if (this.ofdOracle.ShowDialog() == DialogResult.OK)
                    {
                        this.txtConnectionStr.Text = ofdOracle.FileName;
                    }
                    else
                    {
                        this.txtConnectionStr.Text = "";
                    }
                    break;
				case "EXACT-GLOBE":
					this.Hide();

                    IntegrationSetupUI_ExactGlobe oIntegrationSetupUI_ExactGlobeUI = new IntegrationSetupUI_ExactGlobe();
					oIntegrationSetupUI_ExactGlobeUI.ShowDialog();

					this.Close();
					break;

                case "SAP-Business 1":
                    this.Hide();

                    SAP_IntegrationSetup oSAP_IntegrationSetup = new SAP_IntegrationSetup();
                    oSAP_IntegrationSetup.ShowDialog();

                    this.Close();
                    break;

                case "PeachTree":
                    this.Hide();

                    Peachtree_IntegrationSetup oPeachTree_AccountMapping = new Peachtree_IntegrationSetup();
                    oPeachTree_AccountMapping.ShowDialog();

                    this.Close();
                    break;

                case "QuickBooks":
                    this.Hide();

                    Quickbooks_IntegrationSetup oQuickBooks_Setup = new Quickbooks_IntegrationSetup();
                    oQuickBooks_Setup.ShowDialog();
                    this.Close();
                    break;
            }
        }

        private void rdoDaily_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpTime.Visible = true;
            this.cboDay.Visible = false;
            this.cboDayofMonth.Visible = false;
            this.lblMonthly.Visible = false;
            this.dtpAnnual.Visible = false;
			this.lblEvery.Visible = true;

			lPosting_Sched = "DAILY";
        }

        private void rdoWeekly_CheckedChanged(object sender, EventArgs e)
        {
            this.cboDay.Visible = true;
            this.dtpTime.Visible = true;
			this.cboDayofMonth.Visible = false;
            this.lblMonthly.Visible = false;
            this.dtpAnnual.Visible = false;
			this.lblEvery.Visible = true;

			this.cboDay.SelectedIndex = 0;

			lPosting_Sched = "WEEKLY";
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            this.cboDay.Visible = false;
			this.cboDayofMonth.Visible = true;
            this.lblMonthly.Visible = true;
            this.dtpTime.Visible = true;
            this.dtpAnnual.Visible = false;
			this.lblEvery.Visible = true;

			this.cboDayofMonth.SelectedIndex = 0;

			lPosting_Sched = "MONTHLY";
        }

        private void rdoAnnual_CheckedChanged(object sender, EventArgs e)
        {
            this.cboDay.Visible = false;
			this.cboDayofMonth.Visible = false;
            this.lblMonthly.Visible = false;
            this.dtpTime.Visible = true;
            this.dtpAnnual.Visible = true;
			this.lblEvery.Visible = true;

			lPosting_Sched = "ANNUAL";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void btnOk_Click(object sender, EventArgs e)
		{
			//if (this.txtConnectionStr.Text.Trim().Length <= 0)
			//{
			//    this.txtConnectionStr.Focus();
			//    return;
			//}
            int idx = this.cboBackOfficeName.SelectedIndex;


            if (idx == 1 && this.txtConnectionStr.Text == "DSN = ")
			{
				MessageBox.Show("Please input DSN Name for Navision Database.","Message", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
				this.txtConnectionStr.Focus();
				return;
			}

			BackOfficeConfig oNewBackOfficeConfig = new BackOfficeConfig();


            oNewBackOfficeConfig.BackOfficeCode = this.cboBackOfficeName.Text;
            //if (this.rdoNavision.Checked)
            //{
            //    oNewBackOfficeConfig.BackOfficeCode = "NAVISION";
            //}
            //else if (this.rdoOracle.Checked)
            //{
            //    oNewBackOfficeConfig.BackOfficeCode = "ORACLE";
            //}
            //else if (this.rdoExactGlobe.Checked)
            //{
            //    oNewBackOfficeConfig.BackOfficeCode = "EXACT-GLOBE";
            //}



            oNewBackOfficeConfig.BackOfficeName = this.cboBackOfficeName.Text;
			oNewBackOfficeConfig.BackOfficeVersion = this.txtVersion.Text;
			oNewBackOfficeConfig.PostingSchedule = lPosting_Sched;
			oNewBackOfficeConfig.PostingScheduleYear = DateTime.Now.Year;
			oNewBackOfficeConfig.PostingScheduleMonth = this.dtpAnnual.Value.ToString() ;
			switch (lPosting_Sched)
			{ 
				case "DAILY":
				case "AFTER_NIGHT_AUDIT":
					oNewBackOfficeConfig.PostingScheduleDay = 1;
					break;
				case "WEEKLY":
					oNewBackOfficeConfig.PostingScheduleDay = this.cboDay.SelectedIndex + 1;
					break;
				case "MONTHLY":
					oNewBackOfficeConfig.PostingScheduleDay = this.cboDayofMonth.SelectedIndex + 1;
					break;
				case "ANNUAL":
					oNewBackOfficeConfig.PostingScheduleDay = this.dtpAnnual.Value.Day;
					break;
			}
			this.txtConnectionStr.Text = this.txtConnectionStr.Text.Replace("\\", "\\\\");
			oNewBackOfficeConfig.ConnectionString = this.txtConnectionStr.Text;

			oNewBackOfficeConfig.PostingScheduleTime = string.Format("{0:hh:mm:ss tt}",this.dtpTime.Value);

			loBackOfficeConfigFacade = new BackOfficeConfigFacade();
			loBackOfficeConfigFacade.insertBackOfficeConfig(oNewBackOfficeConfig);
			// save to database
			MessageBox.Show("Configuration saved.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();

		}

		private void AccountingSetup_Load(object sender, EventArgs e)
		{
			loBackOfficeConfig = new BackOfficeConfig();
			loBackOfficeConfigFacade = new BackOfficeConfigFacade();
			try
			{
				loBackOfficeConfig = loBackOfficeConfigFacade.getBackOfficeConfig();


                this.cboBackOfficeName.Text = loBackOfficeConfig.BackOfficeCode;

                //switch(loBackOfficeConfig.BackOfficeCode)
                //{
                //    case "NAVISION":
                //        this.rdoNavision.Checked = true;
                //        break;
                //    case "ORACLE":
                //        this.rdoOracle.Checked = true;
                //        break;
                //    case "EXACT-GLOBE":
                //        this.rdoExactGlobe.Checked = true;
                //        break;

                //}
				switch (loBackOfficeConfig.PostingSchedule)
				{ 
					case "DAILY":
						this.rdoDaily.Checked = true;
						break;
					case "WEEKLY":
						this.rdoWeekly.Checked = true;
						break;
					case "MONTHLY":
						this.rdoMonthly.Checked = true;
						break;
					case "ANNUAL":
						this.rdoAnnual.Checked = true;
						break;
					case "AFTER_NIGHT_AUDIT":
						this.rdoNightAudit.Checked = true;
						break;
				}
				switch (loBackOfficeConfig.PostingSchedule)
				{

					case "WEEKLY":
						this.cboDay.SelectedIndex = (loBackOfficeConfig.PostingScheduleDay - 1);
						break;

					case "MONTHLY":
						this.cboDayofMonth.SelectedIndex = (loBackOfficeConfig.PostingScheduleDay - 1);
						break;

					case "ANNUAL":
						this.dtpAnnual.Value = DateTime.Parse(loBackOfficeConfig.PostingScheduleMonth + " " + loBackOfficeConfig.PostingScheduleDay + ", " + loBackOfficeConfig.PostingScheduleYear);
						break;
						
				}

				this.dtpTime.Value = DateTime.Parse(loBackOfficeConfig.PostingScheduleTime);
				this.txtConnectionStr.Text = loBackOfficeConfig.ConnectionString;

                this.cboBackOfficeName_SelectedIndexChanged(this, new EventArgs());

			}
			catch
			{
				//MessageBox.Show("No current integrated backoffice configuration found.\r\nPlease setup now.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//this.rdoNavision.Focus();

                this.cboBackOfficeName.SelectedIndex = 0;
			}

		}

		private void rdoNightAudit_CheckedChanged(object sender, EventArgs e)
		{
			this.cboDay.Visible = false;
			this.cboDayofMonth.Visible = false;
			this.lblMonthly.Visible = false;
			this.dtpTime.Visible = false;
			this.dtpAnnual.Visible = false;
			this.lblEvery.Visible = false;

			lPosting_Sched = "AFTER_NIGHT_AUDIT";
		}

        private void cboBackOfficeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.cboBackOfficeName.SelectedIndex;

            switch (idx)
            { 
                case 0: //>> navision
                    this.lblConnectionLabel.Text = "DSN Connection.";
                    this.txtConnectionStr.Text = "DSN=";

                    lAccountingInterface = "NAVISION";

                    //this.txtBackOfficeName.Text = "NAVISION";
                    break;

                case 1: //>> oracle
                    this.lblConnectionLabel.Text = "Accounting Interface file...";
                    this.txtConnectionStr.Text = "";

                    lAccountingInterface = "ORACLE 11i";

                    //this.txtBackOfficeName.Text = "ORACLE";
                    break;

                case 2: //>> exact-globe
                    this.txtConnectionStr.Enabled = false;

                    this.lblConnectionLabel.Text = "Click browse button to setup.";
                    this.txtConnectionStr.Text = "";

                    lAccountingInterface = "EXACT-GLOBE";

                    //this.txtBackOfficeName.Text = "EXACT-GLOBE";
                    this.txtVersion.Text = "";

                    break;

                case 3: //>> sap

                    lAccountingInterface = "SAP-Business 1";

                    this.txtConnectionStr.Enabled = false;

                    this.lblConnectionLabel.Text = "Click browse button to setup.";
                    this.txtConnectionStr.Text = "";

                    this.txtVersion.Text = "";
                    break;

                case 4: //>> PeachTree
                    lAccountingInterface = "PeachTree";
                    this.txtConnectionStr.Enabled = false;
                    this.lblConnectionLabel.Text = "Click browse button to setup.";
                    this.txtConnectionStr.Text = "";

                    this.txtVersion.Text = "";
                    break;

                case 5: //>>QuickBooks
                    lAccountingInterface = "QuickBooks";
                    this.txtConnectionStr.Enabled = false;
                    this.lblConnectionLabel.Text = "Click browse button to setup.";
                    this.txtConnectionStr.Text = "";

                    this.txtVersion.Text = "";
                    break;
            }

        }




        //private void rdoExactGlobe_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (this.rdoExactGlobe.Checked)
        //    {
        //        this.txtConnectionStr.Enabled = false;

        //        this.lblConnectionLabel.Text = "Click browse button to setup.";
        //        this.txtConnectionStr.Text = "";


        //        lAccountingInterface = "EXACT-GLOBE";

        //        this.txtBackOfficeName.Text = "EXACT-GLOBE";
        //        this.txtVersion.Text = "";
        //    }

        //}

        //private void rdoOracle11i_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.rdoOracle.Checked)
        //    {
        //        this.lblConnectionLabel.Text = "Accounting Interface file...";
        //        this.txtConnectionStr.Text = "";

        //        lAccountingInterface = "ORACLE 11i";

        //        this.txtBackOfficeName.Text = "ORACLE";
        //    }
        //}

        //private void rdoNavision_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.rdoNavision.Checked)
        //    {
        //        this.lblConnectionLabel.Text = "DSN Connection.";
        //        this.txtConnectionStr.Text = "DSN=";

        //        lAccountingInterface = "NAVISION";

        //        this.txtBackOfficeName.Text = "NAVISION";
        //    }
        //}
        
    }
}