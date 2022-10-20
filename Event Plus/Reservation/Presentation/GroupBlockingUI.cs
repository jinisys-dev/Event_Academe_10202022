
using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
//using MySql.Data.Common;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public class GroupBlokingUI : System.Windows.Forms.Form
    {

        #region " Windows Form Designer generated lCode "

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.Container components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the lCode editor.
        internal System.Windows.Forms.DateTimePicker dtpFrom;
        internal System.Windows.Forms.DateTimePicker dtpTo;
        internal System.Windows.Forms.Button btnShowVacant;
        internal System.Windows.Forms.Button btnBlock;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtReason;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal ListViewEx.ListViewEx lvwGrpBlocking;
        internal System.Windows.Forms.ColumnHeader colRoomType;
        internal System.Windows.Forms.ColumnHeader ColVacant;
        internal System.Windows.Forms.ColumnHeader colBlock;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.TextBox txtInput;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnShowVacant = new System.Windows.Forms.Button();
            this.btnBlock = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lvwGrpBlocking = new ListViewEx.ListViewEx();
            this.colRoomType = new System.Windows.Forms.ColumnHeader();
            this.ColVacant = new System.Windows.Forms.ColumnHeader();
            this.colBlock = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(59, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(195, 20);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.CloseUp += new System.EventHandler(this.dtpFrom_CloseUp);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(59, 49);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(195, 20);
            this.dtpTo.TabIndex = 2;
            this.dtpTo.CloseUp += new System.EventHandler(this.dtpTo_CloseUp);
            // 
            // btnShowVacant
            // 
            this.btnShowVacant.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowVacant.Location = new System.Drawing.Point(260, 19);
            this.btnShowVacant.Name = "btnShowVacant";
            this.btnShowVacant.Size = new System.Drawing.Size(102, 50);
            this.btnShowVacant.TabIndex = 3;
            this.btnShowVacant.Text = "&Show Vacant";
            this.btnShowVacant.Click += new System.EventHandler(this.btnShowVacant_Click);
            // 
            // btnBlock
            // 
            this.btnBlock.Enabled = false;
            this.btnBlock.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlock.Location = new System.Drawing.Point(224, 474);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(66, 31);
            this.btnBlock.TabIndex = 5;
            this.btnBlock.Text = "&Block";
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(42, 24);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "From :";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(13, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 24);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "To :";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtReason);
            this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 337);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(350, 128);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Reason for Blocking";
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.SystemColors.Info;
            this.txtReason.Location = new System.Drawing.Point(12, 20);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(331, 94);
            this.txtReason.TabIndex = 9;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtInput);
            this.GroupBox2.Controls.Add(this.lvwGrpBlocking);
            this.GroupBox2.Location = new System.Drawing.Point(11, 73);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(351, 256);
            this.GroupBox2.TabIndex = 10;
            this.GroupBox2.TabStop = false;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.Info;
            this.txtInput.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(256, 92);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(64, 20);
            this.txtInput.TabIndex = 5;
            this.txtInput.Text = "0";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInput.Visible = false;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // lvwGrpBlocking
            // 
            this.lvwGrpBlocking.AllowColumnReorder = true;
            this.lvwGrpBlocking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRoomType,
            this.ColVacant,
            this.colBlock});
            this.lvwGrpBlocking.DoubleClickActivation = false;
            this.lvwGrpBlocking.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGrpBlocking.FullRowSelect = true;
            this.lvwGrpBlocking.GridLines = true;
            this.lvwGrpBlocking.Location = new System.Drawing.Point(8, 12);
            this.lvwGrpBlocking.Name = "lvwGrpBlocking";
            this.lvwGrpBlocking.Size = new System.Drawing.Size(336, 232);
            this.lvwGrpBlocking.TabIndex = 1;
            this.lvwGrpBlocking.UseCompatibleStateImageBehavior = false;
            this.lvwGrpBlocking.View = System.Windows.Forms.View.Details;
            this.lvwGrpBlocking.SubItemClicked += new ListViewEx.SubItemEventHandler(this.lvwGrpBlocking_SubItemClicked);
            this.lvwGrpBlocking.SubItemEndEditing += new ListViewEx.SubItemEndEditingEventHandler(this.lvwGrpBlocking_SubItemEndEditing);
            // 
            // colRoomType
            // 
            this.colRoomType.Text = "Room Type";
            this.colRoomType.Width = 120;
            // 
            // ColVacant
            // 
            this.ColVacant.Text = "Vacant";
            this.ColVacant.Width = 100;
            // 
            // colBlock
            // 
            this.colBlock.Text = "For Blocking";
            this.colBlock.Width = 100;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(296, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GroupBlokingUI
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(376, 516);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.btnShowVacant);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GroupBlokingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group Blocking";
            this.Load += new System.EventHandler(this.GroupBlokingUI_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "
    
        private RoomBlockFacade oRoomBlockFacade;
        private DataTable RoomTypes;
        private DataTable RoomTypeOccupied;
        //private DataTable RoomTypeBlocked;
        private DataTable oCcupiedAndBlockedRooms = new DataTable("OccupiedAndBlocked");
        private RoomBlockCollection BlockRoomsColl;
        private RoomTypeFacade oRoomTypeFacade;

        private ArrayList RoomTypesToBlock;
        private RoomBlockCollection RmBlkCollection = new RoomBlockCollection();

        #endregion

        #region " CONSTRUCTORS "

        public GroupBlokingUI()
        {
            InitializeComponent();
            oRoomBlockFacade = new RoomBlockFacade();

            DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

            this.dtpFrom.Value = _auditDate;
            this.dtpTo.Value = _auditDate.AddDays(1);
        }

        private ArrayList lRoomsBlockedArray;
        private ArrayList lRoomsToBeBlockArray;
        private ArrayList lRoomsNeeded;
		private string lFolioID;
        public GroupBlokingUI(string eventName, DateTime startDate, DateTime endDate, ArrayList arr, ArrayList roomsToBeBlock, ArrayList roomsNeeded)
        {
            InitializeComponent();
            lvwGrpBlocking.Columns[1].Width = 65;
            lvwGrpBlocking.Columns[2].Width = 75;
            lvwGrpBlocking.Columns.Add("Rooms Required", 100);
            oRoomBlockFacade = new RoomBlockFacade();
            txtReason.Text = eventName;
            lRoomsBlockedArray = arr;
            lRoomsToBeBlockArray = roomsToBeBlock;
            lRoomsNeeded = roomsNeeded;

            dtpFrom.Value = startDate;
            dtpTo.Value = endDate;
        }

		public GroupBlokingUI( string eventName,
							   string folioID, 
							   DateTime startDate, 
						       DateTime endDate, 
							   ArrayList arr, 
							   ArrayList roomsToBeBlock, 
							   ArrayList roomsNeeded)
		{
			InitializeComponent();
			lvwGrpBlocking.Columns[1].Width = 65;
			lvwGrpBlocking.Columns[2].Width = 75;
			lvwGrpBlocking.Columns.Add("Rooms Required", 100);
			oRoomBlockFacade = new RoomBlockFacade();
			txtReason.Text = eventName;
			lRoomsBlockedArray = arr;
			lRoomsToBeBlockArray = roomsToBeBlock;
			lRoomsNeeded = roomsNeeded;

			//added folio id on RoomBlock table
			lFolioID = folioID;

			dtpFrom.Value = startDate;
			dtpTo.Value = endDate;
		}


        #endregion

        #region " METHODS "

        private void populateBlockedRooms()
        {
			string _dateFrom = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
			string _dateTo = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

            DataTable BlockedRooms = oRoomBlockFacade.getBlockedRooms(_dateFrom, _dateTo, true);
            oRoomTypeFacade = new RoomTypeFacade();
            BlockRoomsColl = new RoomBlockCollection();

            foreach (DataRow dr in BlockedRooms.Rows)
            {
                RoomBlock roomblock = new RoomBlock();
                roomblock.BlockID = int.Parse(dr["blockid"].ToString());
                roomblock.RoomID = dr["roomid"].ToString();
                roomblock.BlockFrom = DateTime.Parse(dr["blockfrom"].ToString());
                roomblock.BlockTo = DateTime.Parse(dr["blockto"].ToString());
                roomblock.Reason = dr["reason"].ToString();
                bool intersect = false;
                int noOfDays = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day,roomblock.BlockFrom,roomblock.BlockTo);
                for (int i = 0; i < noOfDays; i++)
                {
                    DateTime DateFromRoomBlock = roomblock.BlockFrom.AddDays(i).Date;
                    int noOfDaysInDp = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtpFrom.Value.Date, dtpTo.Value.Date);
					//if (!(noOfDaysInDp - 1 < 0))
					//{
					//    noOfDaysInDp--;
					//}
                    DateTime DateFromDtPicker = this.dtpFrom.Value.Date;
                    for (int x = 0; x < noOfDaysInDp; x++)
                    {
                        if (DateFromRoomBlock == DateFromDtPicker.AddDays(x).Date)
                        {
                            intersect = true;
                            goto proceedlloop;
                        }
                    }
              
                }
            proceedlloop:
                if (intersect && !isFoundInOccupied(roomblock.RoomID) && !isInBlockedRoomsCollection(roomblock.RoomID))
                    BlockRoomsColl.Add(roomblock);
           }
        }
        private bool isInBlockedRoomsCollection(string roomid)
        {
            bool isFound = false;
            foreach (RoomBlock rb in BlockRoomsColl)
            {
                if (rb.RoomID == roomid)
                {
                    isFound = true;
                    return isFound;
                }
            }
            return isFound;
        }

        private void PopulateOccupiedAndBlockedRooms()
        {
            DataColumn dtCol1 = new DataColumn();
            oCcupiedAndBlockedRooms = RoomTypeOccupied.Copy();
            RoomBlock RBlock;
            foreach (RoomBlock tempLoopVar_RBlock in BlockRoomsColl)
            {
                RBlock = tempLoopVar_RBlock;
                DataRow dtNewRow = oCcupiedAndBlockedRooms.NewRow();
                dtNewRow["roomid"] = RBlock.RoomID;
                dtNewRow["roomtypecode"] = oRoomTypeFacade.getRoomType(RBlock.RoomID);
                oCcupiedAndBlockedRooms.Rows.Add(dtNewRow);
            }
            oCcupiedAndBlockedRooms.AcceptChanges();
        }

        private void reconcile()
        {
            DataRow dtRowRoomTypeOccupied;
            DataRow dtRowRoomTypes;
            foreach (DataRow tempLoopVar_dtRowRoomTypeOccupied in oCcupiedAndBlockedRooms.Rows)
            {
                dtRowRoomTypeOccupied = tempLoopVar_dtRowRoomTypeOccupied;

                foreach (DataRow tempLoopVar_dtRowRoomTypes in RoomTypes.Rows)
                {
                    dtRowRoomTypes = tempLoopVar_dtRowRoomTypes;
                    if (dtRowRoomTypeOccupied["roomtypecode"].ToString() == dtRowRoomTypes["roomtypecode"].ToString())
                    {
                        dtRowRoomTypes["vacant"] = int.Parse(dtRowRoomTypes["vacant"].ToString()) - 1;
                    }
                }
            }

            RoomTypes.AcceptChanges();
        }

        private void loadToListView()
        {
            this.lvwGrpBlocking.Items.Clear();
            DataRow dtRowRoomTypes;
            int ctr = 0;
            foreach (DataRow tempLoopVar_dtRowRoomTypes in RoomTypes.Rows)
            {
                dtRowRoomTypes = tempLoopVar_dtRowRoomTypes;
                if (!(dtRowRoomTypes["roomtypecode"].ToString().Contains("FUNCTION")))
                {
                    ListViewItem li = new ListViewItem(dtRowRoomTypes["roomtypecode"].ToString());
                    li.SubItems.Add(dtRowRoomTypes["vacant"].ToString());

                    //add the number of rooms needed to block in the list
                    //if array is > vacant rooms, set rooms to be blocked to #of vacant
                    try
                    {
                        if (int.Parse(dtRowRoomTypes["vacant"].ToString()) < int.Parse(lRoomsToBeBlockArray[ctr].ToString()))
                        {
                            li.SubItems.Add(dtRowRoomTypes["vacant"].ToString());
                            li.SubItems.Add(lRoomsNeeded[ctr].ToString());
                        }
                        else
                        {
                            li.SubItems.Add(lRoomsToBeBlockArray[ctr].ToString());
                            li.SubItems.Add(lRoomsNeeded[ctr].ToString());
                        }
                    }
                    catch
                    {
                        li.SubItems.Add("");
                    }

                    this.lvwGrpBlocking.Items.Add(li);
                    ctr++;
                }
            }
        }

        private void PopulateArrayList()
        {
            RoomTypesToBlock = new ArrayList();
            ListViewItem li;
            foreach (ListViewItem tempLoopVar_li in this.lvwGrpBlocking.Items)
            {
                li = tempLoopVar_li;
                if (li.SubItems[2].Text != "")
                {
                    if (System.Convert.ToInt32(li.SubItems[2].Text) != 0)
                    {
                        RoomTypesToBlock.Add(li.Text + "," + li.SubItems[2].Text);
                    }
                }
            }
        }


        private DataTable getRoomiDs()
        {
            try
            {
                MySqlCommand getCommand = new MySqlCommand("select roomid,roomtypecode from rooms", GlobalVariables.gPersistentConnection);
                getCommand.CommandType = CommandType.Text;
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getCommand);
                DataTable dtRoomID = new DataTable("RoomIDs");
                dtAdapter.Fill(dtRoomID);
                return dtRoomID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message + " AT getRoomiDs");
                return null;
            }
        }

        private bool isBlockedOrOccupied(string roomid)
        {
            DataRow dt;
            foreach (DataRow tempLoopVar_dt in oCcupiedAndBlockedRooms.Rows)
            {
                dt = tempLoopVar_dt;
                if (roomid == dt["roomid"].ToString())
                {
                    return true;
                } 
            }
            return false;
        }   

        private void populateRoomBlockCollection()
        {

            DataTable dtRooms =  getRoomiDs();
            DataView dvRooms = dtRooms.DefaultView;
            string str;
            int blockid = oRoomBlockFacade.getNextBlockNo();
            foreach (string tempLoopVar_str in RoomTypesToBlock)
            {
                str = tempLoopVar_str;
                string[] roomtype;
                roomtype = str.Split(',');
                dvRooms.RowFilter = "roomtypecode='" + roomtype[0] + "'";
                dvRooms.RowStateFilter = DataViewRowState.OriginalRows;
                DataRowView dvRow;
                int numofRooms = System.Convert.ToInt32(roomtype[1]);
                int counter = 0;
                foreach (DataRowView tempLoopVar_dvRow in dvRooms)
                {
                    dvRow = tempLoopVar_dvRow;
                    if (!isBlockedOrOccupied(dvRow["roomid"].ToString()))
                    {
                        RoomBlock roomblock = new RoomBlock();
                        roomblock.BlockID = blockid;
                        roomblock.RoomID = dvRow["roomid"].ToString();
                        roomblock.BlockFrom = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value.ToShortDateString()));
                        roomblock.BlockTo = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value.ToShortDateString()));
                        roomblock.Reason = this.txtReason.Text;
						
						roomblock.FolioID = lFolioID;

                        RmBlkCollection.Add(roomblock);
                        counter++;
                    }

                    if (counter == numofRooms)
                    {
                        goto endOfForLoop;
                    }
                }
            endOfForLoop:
                1.GetHashCode(); //nop


            }
            RmBlkCollection.AddBlockID(blockid);
            RmBlkCollection.AddReason(this.txtReason.Text);
        }

        public void SaveEntry()
        {
            if (this.txtReason.Text != "")
            {

                if (this.dtpFrom.Value.ToShortDateString() == this.dtpTo.Value.ToShortDateString())
                {
                    MessageBox.Show("Please select a valid [To] date..", "Group Blocking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (isNotEmptyList() == false)
                {
					MessageBox.Show("Please select roomtypes to block.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                PopulateArrayList();
                populateRoomBlockCollection();
                oRoomBlockFacade.SaveRoomBlock(RmBlkCollection);

				updateCurrentDayRoomStatus();

                //>>
                //_array.Clear();
                foreach (ListViewItem li in lvwGrpBlocking.Items)
                {
                    try
                    {
                        lRoomsBlockedArray[li.Index] = (object)(int.Parse(lRoomsBlockedArray[li.Index].ToString()) + int.Parse(li.SubItems[2].Text));
                    }
                    catch { }
                }
                //<<


                //this.txtReason.Text = "";

				MessageBox.Show("Transaction successful.\r\n\r\nRooms are now blocked.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// applied try catch for Quick Blocking
				// without Rooms needed
				try 
				{
					lRoomsNeeded.Clear();
					lRoomsToBeBlockArray.Clear();
					//for computation of blockings
					foreach (ListViewItem _listviewItem in lvwGrpBlocking.Items)
					{
						int _roomsForBlocking = int.Parse(_listviewItem.SubItems[2].Text);
						int _roomsNeeded = int.Parse(_listviewItem.SubItems[3].Text);
						int _roomsLacking = _roomsNeeded - _roomsForBlocking;
						int _vacantRooms = int.Parse(_listviewItem.SubItems[1].Text);

						if (_roomsLacking > _vacantRooms)
						{
							lRoomsToBeBlockArray.Add(0);
						}
						else
						{
							lRoomsToBeBlockArray.Add(_roomsLacking);
						}
						lRoomsNeeded.Add(_roomsLacking);
					}
				}
				catch { }

                btnShowVacant_Click(null, new EventArgs());
            }
            else
            {
                MessageBox.Show("Reason for blocking must be supplied!","Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                this.txtReason.Focus();
            }
           
        }

		private void updateCurrentDayRoomStatus()
		{
			try
			{
				Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
				MethodInfo[] objMethods = objectType.GetMethods();
				MethodInfo method;
				foreach (MethodInfo tempLoopVar_method in objMethods)
				{
					method = tempLoopVar_method;
					if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
					{
						method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
					}
				}
			}
			catch// (Exception ex)
			{
				//MessageBox.Show("Transaction"ex.Message);
			}
		}
        private bool isNotEmptyList()
        {
            
            foreach (ListViewItem li in this.lvwGrpBlocking.Items)
            {
                if (li.SubItems[2].Text != "")
                {
					if (System.Convert.ToInt32(li.SubItems[2].Text) != 0)
					{
						return true;
					}
                }

            }
            return false;
        }
        #endregion

        #region " EVENTS "

        private void btnShowVacant_Click(System.Object sender, System.EventArgs e)
        {
			this.btnBlock.Enabled = false;

			if (this.dtpFrom.Value.ToShortDateString() == this.dtpTo.Value.ToShortDateString() ||
                this.dtpFrom.Value > this.dtpTo.Value)
			{
				MessageBox.Show("Please select a valid [To] date..", "Group Blocking", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}


            RoomTypes = oRoomBlockFacade.CountRoomTypes();
            RoomTypeOccupied = oRoomBlockFacade.GetRoomAndTypeOccupied(string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value), string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value));
            
            populateBlockedRooms();
            PopulateOccupiedAndBlockedRooms();
            ExcludeExpectedDepartures();
            reconcile();
            loadToListView();

			this.btnBlock.Enabled = true;
        }

        CalendarFacade oCalendarFacade =null;
        ArrayList ExpectecDepartures = new ArrayList();
        private void ExcludeExpectedDepartures()
        {

            oCalendarFacade = new CalendarFacade();
           
            DataTable oExpectedCheckouts = oCalendarFacade.GetSpectedDepartures(string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value));
            foreach (DataRow dr in oExpectedCheckouts.Rows)
            {
                //bool intersect = false;

                //DateTime DateFromDepartures = DateTime.Parse(dr["toDate"].ToString()).Date;
                //int noOfDaysInDp = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtpFrom.Value, dtpTo.Value);
                //if (!(noOfDaysInDp - 1 < 0))
                //{
                //    noOfDaysInDp--;
                //}
                //DateTime DateFromDtPicker = this.dtpFrom.Value.Date;
                //for (int x = 0; x <= noOfDaysInDp; x++)
                //{

                //    if (DateFromDepartures == DateFromDtPicker.AddDays(x).Date)
                //    {
                //        intersect = true;
                //        //addToExpectedDepartures(dr["roomtype"].ToString(), dr["roomid"].ToString());
                //    }
                //}

                //foreach (DataRow _dataRow in oCcupiedAndBlockedRooms.Rows)
                //{
                //    if (_dataRow["roomid"].ToString() == dr["roomid"].ToString() &&
                //        _dataRow["eventdate"].ToString() == dr["todate"].ToString())
                //    {
                //        _dataRow.Delete();
                //    }
                //}
                //oCcupiedAndBlockedRooms.AcceptChanges();
                //ExpectecDepartures.Add(dr["roomid"]);
            }
        }
        private struct Departure
        {
            public string roomid;
            public string roomtype;
           
        }
        private void addToExpectedDepartures(string  roomtype,string roomid )
        {
            Departure dept = new Departure();
            dept.roomid = roomid;
            dept.roomtype = roomtype;
            if (ExpectecDepartures.IndexOf(dept) ==- 1)
            {
                ExpectecDepartures.Add(dept);
            }
         
           
        }

        private bool isFoundInOccupied(string roomid)
        {
            bool found= false;

            foreach (DataRow dr in RoomTypeOccupied.Rows)
            {
                if (dr["roomid"].ToString() == roomid)
                {
                    found = true;
                    return found;
                }
            }
            return found;
        }
        private void lvwGrpBlocking_SubItemClicked(System.Object sender, ListViewEx.SubItemEventArgs e)
        {
            if (e.SubItem == 2)
            {
                this.lvwGrpBlocking.StartEditing(this.txtInput, e.Item, e.SubItem);
            }
        }

        private void lvwGrpBlocking_SubItemEndEditing(System.Object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            try
            {
                if (e.DisplayText != "")
                {
                    if (System.Convert.ToInt32(e.DisplayText) > System.Convert.ToInt32(e.Item.SubItems[1].Text))
                    {
                        MessageBox.Show("The value entered is more than the vacant " + e.Item.Text + " type!", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.DisplayText = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnBlock_Click(System.Object sender, System.EventArgs e)
        {
			SaveEntry();
        }
        
        #endregion

		private void GroupBlokingUI_Load(object sender, EventArgs e)
		{

		}

		private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			// NUMBER INPUT only
			switch (e.KeyChar)
			{
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
				case '\b':
				case '\r':
					e.Handled = false;
					break;
				default:
					e.Handled = true;
					break;
			}
		}

        private void dtpFrom_CloseUp(object sender, EventArgs e)
        {
            if (dtpFrom.Value < DateTime.Parse(GlobalVariables.gAuditDate))
            {
                dtpFrom.Value = DateTime.Parse(GlobalVariables.gAuditDate);
                MessageBox.Show("Cannot navigate to date. Selected date is less than the current audit date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpTo_CloseUp(object sender, EventArgs e)
        {
            if (dtpTo.Value < DateTime.Parse(GlobalVariables.gAuditDate))
            {
                dtpTo.Value = dtpFrom.Value.AddDays(1);
                MessageBox.Show("Cannot navigate to date. Selected date is less than the current audit date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}