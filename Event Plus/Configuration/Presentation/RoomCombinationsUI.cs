using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class RoomCombinationsUI : Form
    {
        public RoomCombinationsUI()
        {
            InitializeComponent();
        }
        private string lRoomID = "";
        private RoomFacade loRoomFacade;
        private Room loRoom;
        private void RoomCombinationsUI_Load(object sender, EventArgs e)
        {
            initialize();
            loadRooms();
        }
        public void setLocalRoom(string pRoomID, string pRoomDescription)
        {
            lRoomID = pRoomID;
            lblRoomID.Text = pRoomID;
            lblDescription.Text = pRoomDescription;
        }
        
        private void initialize()
        {

            loRoomFacade = new RoomFacade();
            loRoom = new Room();
            loadCombRooms();


        }
        public bool loadRooms()
        {
            try
            {
                
                loRoom = (Room)loRoomFacade.loadObject();
                DataTable _dt = loRoom.Tables[0];
                cboRooms.DataSource = _dt;
                cboRooms.DisplayMember = "RoomDescription";
                cboRooms.ValueMember = "roomid";
                cboRooms.Text = "";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void loadCombRooms()
        {
           // grdRoomCombination.DataSource = loRoomFacade.getAllRoomComb(lRoomID);
            try
            {
                foreach (DataRow _row in loRoomFacade.getAllRoomComb(lRoomID).Rows)
                {
                    grdRoomCombination.Rows.Count++;
                    grdRoomCombination.SetData(grdRoomCombination.Rows.Count - 1, "RoomMergeID", _row["RoomMergeID"].ToString());
                    grdRoomCombination.SetData(grdRoomCombination.Rows.Count - 1, "RoomMergeDescription", _row["RoomMergeDescription"].ToString());
                }
            }
            catch
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboRooms.Text != "")
                {
                    grdRoomCombination.Rows.Count++;
                    int _cnt = grdRoomCombination.Rows.Count - 1;
                    grdRoomCombination.SetData(_cnt, "RoomMergeID", cboRooms.SelectedValue.ToString());
                    grdRoomCombination.SetData(_cnt, "RoomMergeDescription", cboRooms.Text);
                }
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (loRoomFacade.insertRoomCombination(lRoomID, grdRoomCombination))
            {
                MessageBox.Show("Successfully Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdRoomCombination.Rows.Count != 1)
                {
                  grdRoomCombination.Rows.Remove(grdRoomCombination.Row);
                }
            }
            catch
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}