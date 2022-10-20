using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management
{
    public partial class RoomingListUI : Form
    {
        public RoomingListUI()
        {
            InitializeComponent();
            loadGroupNames();
        }

        public DataTable loDataTable = new DataTable();
        public Reports.BusinessLayer.ReportFacade loReportFacade;
        DataView loDataView = new DataView();

        public void loadGroupNames()
        {
            loReportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
            loDataTable = loReportFacade.getGroupedRoomingList();
        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtEventName.Text != "")
            {
                loDataView = loDataTable.DefaultView;
                loDataView.RowStateFilter = DataViewRowState.OriginalRows;
                loDataView.RowFilter = "status = 'ONGOING' and groupname like '" + txtEventName.Text + "%'";

                this.lvwList.Items.Clear();
                this.lvwList.Visible = true;
                foreach (DataRowView dtRow in loDataView)
                {
                    ListViewItem _listItem = new ListViewItem();
                    _listItem.Text = dtRow["folioid"].ToString();
                    _listItem.SubItems.Add(dtRow["groupname"].ToString());
                    _listItem.SubItems.Add(dtRow["companyname"].ToString());

                    lvwList.Items.Add(_listItem);
                }
            }
            else
            {
                this.lvwList.Visible = false;
            }

            //lvwList.HeaderStyle = ColumnHeaderStyle.None;
        }

        private void txtEventName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwList.Visible && this.lvwList.Items.Count > 0)
                {
                    this.lvwList.Focus();
                    this.lvwList.Items[0].Selected = true;
                }
            }
        }

        private void lvwList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _eventname = this.lvwList.SelectedItems[0].SubItems[1].Text;
                string _folioID = this.lvwList.SelectedItems[0].Text;

                this.txtEventName.Text = _eventname;
                this.txtEventName.Tag = _folioID;
            }
            catch
            { }

            this.lvwList.Visible = false;
            btnPreview_Click(sender, new EventArgs());
        }

        private void lvwList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 13 = ENTER
            {
                lvwList_DoubleClick(sender, new EventArgs());
            }
        }

        private void showReport()
        {
            loReportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
            this.crpViewer.ReportSource = loReportFacade.getRoomingList(txtEventName.Tag.ToString());

            if (this.crpViewer.ReportSource != null)
            {
                this.crpViewer.Show();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                showReport();
            }
            catch { }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.lvwList.Items.Clear();
            this.lvwList.Visible = true;

            loDataView = loDataTable.DefaultView;
            loDataView.RowStateFilter = DataViewRowState.OriginalRows;
            loDataView.RowFilter = "status = 'ONGOING'";
            
            foreach (DataRowView dtRow in loDataView)
            {
                ListViewItem _listItem = new ListViewItem();
                _listItem.Text = dtRow["folioid"].ToString();
                _listItem.SubItems.Add(dtRow["groupname"].ToString());
                _listItem.SubItems.Add(dtRow["companyname"].ToString());

                lvwList.Items.Add(_listItem);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.crpViewer.PrintReport();
        }
    }
}