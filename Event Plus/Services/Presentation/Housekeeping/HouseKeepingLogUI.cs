using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;
using Jinisys.Hotel.Security.BusinessLayer;
namespace Jinisys.Hotel.Services.Presentation
{
    public partial class HouseKeepingLogUI : Form
    {
    
        
        HouseKeepingLogFacade oHouseKeepingLogFacade = null;
        public HouseKeepingLogUI()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HouseKeepingLogUI_Load(object sender, EventArgs e)
        {
            //GlobalVariables.HouseKeepingConnection.Open();
            //MessageBox.Show(GlobalVariables.HouseKeepingConnection.State.ToString());
            dtpDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);

            loadDataToGrid();

            this.tmrLog.Enabled = true;
        }
        private void loadDataToGrid()
        {
            this.hkGrid.Rows.Count = 1;
            oHouseKeepingLogFacade = new HouseKeepingLogFacade();
			DataTable _dtTemp = oHouseKeepingLogFacade.GetHouseKeepingLogs( this.dtpDate.Value.ToString("yyyy-M-dd") );

			this.hkGrid.Rows.Count = _dtTemp.Rows.Count + 1;
			int i = 1;
			foreach (DataRow dRow in _dtTemp.Rows)
            {
                this.hkGrid.SetData(i,0,dRow["RoomId"].ToString());
				this.hkGrid.SetData(i, 1, dRow["housekeepingjobno"].ToString());
				this.hkGrid.SetData(i, 2, dRow["RoomType"].ToString());
				this.hkGrid.SetData(i, 3, dRow["housekeeper"].ToString());
				this.hkGrid.SetData(i, 4, dRow["StartTime"]);
				this.hkGrid.SetData(i, 5, dRow["EndTime"]);
				this.hkGrid.SetData(i, 6, dRow["duration"]);
				this.hkGrid.SetData(i, 7, dRow["remarks"].ToString());
				this.hkGrid.SetData(i, 8, dRow["verifiedby"].ToString());
				this.hkGrid.SetData(i, 9, dRow["timeverified"]);

				i++;
            }

        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadDataToGrid();
            //setHousekeeperList();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
          this.loadDataToGrid();
        }
		//private void setHousekeeperList()
		//{
		//    oHouseKeepingLogFacade = new HouseKeepingLogFacade();
		//    string combo = "";
		//    foreach (DataRow dRow in oHouseKeepingLogFacade.GetHouseKeepers().Rows)
		//    {
		//        combo +=dRow["HouseKeeper"].ToString() + "|";
                
		//    }
		//    //this.hGrid.set_ColComboList(3, combo);
		//}

        private void tmrLog_Tick(object sender, EventArgs e)
        {
			loadDataToGrid();
        }

		//private void update()
		//{
		//    try
		//    {
		//        oHouseKeepingLogFacade = new HouseKeepingLogFacade();
		//        int idx = this.hkGrid.Row;

		//        int length = this.hkGrid.GetDataDisplay(idx, 4).IndexOf('-');
		//        string roomid = this.hkGrid.GetDataDisplay(idx, 0);
		//        string status = this.hkGrid.GetDataDisplay(idx, 3);
		//        string hk_id = this.hkGrid.GetDataDisplay(idx, 4).Substring(0, length);
		//        string sTime = this.hkGrid.GetDataDisplay(idx, 5);
		//        string eTime = string.Format("{0:hh:mm:ss}", DateTime.Now);//this.hGrid.get_TextMatrix(idx, 6);
		//        //string duration = this.hGrid.get_TextMatrix(idx, 7);
		//        TimeSpan duration = TimeSpan.Parse(eTime) - TimeSpan.Parse(sTime);
		//        // MessageBox.Show(e1.ToString());
		//        if (oHouseKeepingLogFacade.UpdateHouseKeepingLog(roomid, status, hk_id, sTime, eTime, duration.ToString()))
		//        {
		//            MessageBox.Show("Record has been updated!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//            this.loadDataToGrid();
		//        }
		//        else
		//        {
		//            MessageBox.Show("Somthing Wrong in your code!!!");
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(ex.Message);
		//    }
		//}

		//private void mnuUpdate_Click(object sender, EventArgs e)
		//{
		//    update();
		//}

		//private void mnuInsertNew_Click(object sender, EventArgs e)
		//{

		//}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.loadDataToGrid();
            //setHousekeeperList();
        }

        private void hGrid_SelChange(object sender, EventArgs e)
        {
            if (this.hkGrid.Row != -1 )
            {
                if (this.hkGrid.GetDataDisplay(this.hkGrid.Row, 3) != "")
					if (this.hkGrid.GetDataDisplay(this.hkGrid.Row, 8) != "")
                {
                    this.btnVerify.Enabled = false;
                }
                else
                {
                    this.btnVerify.Enabled = true;
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
			this.tmrLog.Enabled = false;

			DialogResult rsp = MessageBox.Show("Set selected housekeeping job as verified?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (rsp == DialogResult.Yes)
			{
				UserFacade uFacade = new UserFacade(GlobalVariables.gPersistentConnection);
				string supervisor = GlobalVariables.gLoggedOnUser;
				HouseKeepingJobFacade oHousekeepingjobFacade = new HouseKeepingJobFacade();

				// bantayonon ky naa column sa grid nga g-hide
				try
				{
					if (oHousekeepingjobFacade.verifyHouseKeepingJob(supervisor, int.Parse(this.hkGrid.GetDataDisplay(hkGrid.Row, 1))))
						MessageBox.Show("House keeping job verified!", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.loadDataToGrid();
				}
				catch(Exception ex)
				{
					MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			this.tmrLog.Enabled = true;

        }

             
        private void mnuContext_Opening(object sender, CancelEventArgs e)
        {
            String name = this.hkGrid.GetDataDisplay(hkGrid.Row,3);
            if (name==String.Empty)
            {
                this.mnuAddRemarks.Enabled = false;
                this.viewUpdateRemarksToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.mnuAddRemarks.Enabled = true;
                this.viewUpdateRemarksToolStripMenuItem.Enabled = true;
            }
        }

        private void mnuAddRemarks_Click(object sender, EventArgs e)
        {
            int jobid ;
            try
            {
                jobid =int.Parse(this.hkGrid.GetDataDisplay(hkGrid.Row,1));
            }
            catch(Exception)
            {
                jobid =0;
            }
            
            if (jobid!=0)
            {

                AddRemark addRemark = new AddRemark(0, "JobID=" + jobid.ToString() + ", Housekeeper:" + this.hkGrid.GetDataDisplay(hkGrid.Row,3));
                DialogResult res= addRemark.ShowAddRemark();
                if (res == DialogResult.OK)
                {
                    String remarks = addRemark.Remarks;
                    HouseKeepingJobFacade oHousekeepingjobFacade = new HouseKeepingJobFacade();
                    oHousekeepingjobFacade.updateMemo(jobid, remarks);
                    addRemark.Dispose();
                }
            }
            
        }

        private void viewUpdateRemarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int jobid;
            try
            {
                jobid = int.Parse(this.hkGrid.GetDataDisplay(hkGrid.Row, 1));
            }
            catch (Exception)
            {
                jobid = 0;
            }

            if (jobid != 0)
            {
                HouseKeepingJobFacade oHousekeepingjobFacade = new HouseKeepingJobFacade();
                String rem = oHousekeepingjobFacade.getMemo(jobid);
                if (rem != string.Empty)
                {
                    AddRemark addRemark = new AddRemark(0, "JobID=" + jobid.ToString() + ", Housekeeper:" + this.hkGrid.GetDataDisplay(hkGrid.Row, 3),rem);
                    DialogResult rsp = addRemark.ShowAddRemark();
                    if (rsp == DialogResult.OK)
                    {
                        String remarks = addRemark.Remarks;
                        oHousekeepingjobFacade.updateMemo(jobid, remarks);
                        addRemark.Dispose()
                        ;
                    }
                }
                
            }
        }

		private void HouseKeepingLogUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void hkGrid_RowColChange(object sender, EventArgs e)
		{
			if (this.hkGrid.Row > 0)
			{
				if (this.hkGrid.GetDataDisplay(this.hkGrid.Row, 3) != "")

					if (this.hkGrid.GetDataDisplay(this.hkGrid.Row, 8) != "")
					{
						this.btnVerify.Enabled = false;
					}
					else
					{
						this.btnVerify.Enabled = true;
					}
			}
		}
    }
}