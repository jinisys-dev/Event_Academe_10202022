
using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public class AddReasonUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
    {

        #region " Windows Form Designer generated lCode "

        public AddReasonUI()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
        }

        
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
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label BlockID;
        public System.Windows.Forms.TextBox txtBlockID;
        public System.Windows.Forms.TextBox txtReason;
        internal System.Windows.Forms.Button btnOk;
		public TextBox txtRoomsToBlock;
		internal Label label2;
		public TextBox txtFromDate;
		internal Label label3;
		public TextBox txtToDate;
		internal Label label4;
		private FlowLayoutPanel flowLayoutPanel1;
		private Label lblRequiredRooms;
		private TextBox txtRequiredRooms;
		private Label lblBlockedRooms;
		private TextBox txtBlockedRooms;
        internal System.Windows.Forms.Button btnCancel;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReasonUI));
			this.Label1 = new System.Windows.Forms.Label();
			this.BlockID = new System.Windows.Forms.Label();
			this.txtBlockID = new System.Windows.Forms.TextBox();
			this.txtReason = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtRoomsToBlock = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFromDate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtToDate = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblRequiredRooms = new System.Windows.Forms.Label();
			this.txtRequiredRooms = new System.Windows.Forms.TextBox();
			this.lblBlockedRooms = new System.Windows.Forms.Label();
			this.txtBlockedRooms = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(3, 182);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(65, 35);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Reason for blocking :";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// BlockID
			// 
			this.BlockID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BlockID.Location = new System.Drawing.Point(3, 0);
			this.BlockID.Name = "BlockID";
			this.BlockID.Size = new System.Drawing.Size(64, 22);
			this.BlockID.TabIndex = 1;
			this.BlockID.Text = "Block ID :";
			this.BlockID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBlockID
			// 
			this.txtBlockID.BackColor = System.Drawing.SystemColors.Control;
			this.txtBlockID.Location = new System.Drawing.Point(73, 3);
			this.txtBlockID.Name = "txtBlockID";
			this.txtBlockID.ReadOnly = true;
			this.txtBlockID.Size = new System.Drawing.Size(160, 20);
			this.txtBlockID.TabIndex = 0;
			// 
			// txtReason
			// 
			this.txtReason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtReason.Location = new System.Drawing.Point(74, 185);
			this.txtReason.Multiline = true;
			this.txtReason.Name = "txtReason";
			this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtReason.Size = new System.Drawing.Size(212, 76);
			this.txtReason.TabIndex = 4;
			// 
			// btnOk
			// 
			this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOk.Location = new System.Drawing.Point(267, 22);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(66, 31);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(267, 59);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 31);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtRoomsToBlock
			// 
			this.txtRoomsToBlock.BackColor = System.Drawing.SystemColors.Control;
			this.txtRoomsToBlock.Location = new System.Drawing.Point(73, 107);
			this.txtRoomsToBlock.Multiline = true;
			this.txtRoomsToBlock.Name = "txtRoomsToBlock";
			this.txtRoomsToBlock.ReadOnly = true;
			this.txtRoomsToBlock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRoomsToBlock.Size = new System.Drawing.Size(213, 72);
			this.txtRoomsToBlock.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "Room(s) :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFromDate
			// 
			this.txtFromDate.BackColor = System.Drawing.SystemColors.Control;
			this.txtFromDate.Location = new System.Drawing.Point(73, 29);
			this.txtFromDate.Name = "txtFromDate";
			this.txtFromDate.ReadOnly = true;
			this.txtFromDate.Size = new System.Drawing.Size(160, 20);
			this.txtFromDate.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 22);
			this.label3.TabIndex = 6;
			this.label3.Text = "Date From :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtToDate
			// 
			this.txtToDate.BackColor = System.Drawing.SystemColors.Control;
			this.txtToDate.Location = new System.Drawing.Point(73, 55);
			this.txtToDate.Name = "txtToDate";
			this.txtToDate.ReadOnly = true;
			this.txtToDate.Size = new System.Drawing.Size(160, 20);
			this.txtToDate.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 22);
			this.label4.TabIndex = 8;
			this.label4.Text = "Date To :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.BlockID);
			this.flowLayoutPanel1.Controls.Add(this.txtBlockID);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.txtFromDate);
			this.flowLayoutPanel1.Controls.Add(this.label4);
			this.flowLayoutPanel1.Controls.Add(this.txtToDate);
			this.flowLayoutPanel1.Controls.Add(this.lblRequiredRooms);
			this.flowLayoutPanel1.Controls.Add(this.txtRequiredRooms);
			this.flowLayoutPanel1.Controls.Add(this.lblBlockedRooms);
			this.flowLayoutPanel1.Controls.Add(this.txtBlockedRooms);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.txtRoomsToBlock);
			this.flowLayoutPanel1.Controls.Add(this.Label1);
			this.flowLayoutPanel1.Controls.Add(this.txtReason);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 21);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(296, 278);
			this.flowLayoutPanel1.TabIndex = 9;
			// 
			// lblRequiredRooms
			// 
			this.lblRequiredRooms.Location = new System.Drawing.Point(3, 78);
			this.lblRequiredRooms.Name = "lblRequiredRooms";
			this.lblRequiredRooms.Size = new System.Drawing.Size(64, 24);
			this.lblRequiredRooms.TabIndex = 9;
			this.lblRequiredRooms.Text = "Required :";
			this.lblRequiredRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRequiredRooms
			// 
			this.txtRequiredRooms.Location = new System.Drawing.Point(73, 81);
			this.txtRequiredRooms.Name = "txtRequiredRooms";
			this.txtRequiredRooms.ReadOnly = true;
			this.txtRequiredRooms.Size = new System.Drawing.Size(43, 20);
			this.txtRequiredRooms.TabIndex = 10;
			// 
			// lblBlockedRooms
			// 
			this.lblBlockedRooms.Location = new System.Drawing.Point(122, 78);
			this.lblBlockedRooms.Name = "lblBlockedRooms";
			this.lblBlockedRooms.Size = new System.Drawing.Size(63, 24);
			this.lblBlockedRooms.TabIndex = 11;
			this.lblBlockedRooms.Text = "Blocked :";
			this.lblBlockedRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBlockedRooms
			// 
			this.txtBlockedRooms.Location = new System.Drawing.Point(191, 81);
			this.txtBlockedRooms.Name = "txtBlockedRooms";
			this.txtBlockedRooms.ReadOnly = true;
			this.txtBlockedRooms.Size = new System.Drawing.Size(42, 20);
			this.txtBlockedRooms.TabIndex = 12;
			// 
			// AddReasonUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(350, 314);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "AddReasonUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Reason";
			this.Load += new System.EventHandler(this.AddReasonUI_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        private RoomBlockCollection RoomBlockCollection;
        private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic vsGrid;
        private int rowStart;
        private int startCol;
        private int rowEnd;
        private int endCol;
        private bool success = false;
        private RoomBlockFacade RoomBlockFacade;

        #endregion

        #region " CONSTRUCTORS "

		//>> added by jrom
		//>> jan 31, 2009 [For d new Calendar]
		RoomBlockCollection loRoomBlockCollection = null;
		public AddReasonUI(RoomBlockCollection poRoomBlockCollection)
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();

			
			this.txtBlockID.Text = "AUTO";

			int _start = 0;
			int _end = poRoomBlockCollection.Count -1;
			int i= 0;
			RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
			foreach(RoomBlock _oRoomBlock in poRoomBlockCollection)
			{
				_oRoomBlock.BlockID = oRoomBlockFacade.getNextBlockNo();
				if (i == _start)
				{
					this.txtFromDate.Text = _oRoomBlock.BlockFrom.ToLongDateString();
				}
				if (i == _end)
				{
					this.txtToDate.Text = _oRoomBlock.BlockTo.ToLongDateString();
				}

				this.txtRoomsToBlock.Text += _oRoomBlock.RoomID + ", ";

				i++;
			}
			
			loRoomBlockCollection = poRoomBlockCollection;

		}


		public AddReasonUI(RoomBlockFacade oRoomBlockFacade, RoomBlockCollection oRoomBlockColl, C1.Win.C1FlexGrid.Classic.C1FlexGridClassic vs, int rowSt, int startC, int rowE, int endC)
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
            

            RoomBlockFacade = oRoomBlockFacade;
            RoomBlockCollection = oRoomBlockColl;
			rowStart = rowSt;
			startCol = startC;
			rowEnd = rowE;
			endCol = endC;
			vsGrid = vs;
            this.txtBlockID.Text = oRoomBlockFacade.getNextBlockNo().ToString();
            RoomBlockCollection.AddBlockID(Int32.Parse(this.txtBlockID.Text));

        }


		// jrom
		// to fix bug regarding future date blocking
		// passed FromDate & ToDate and removed reference to currentAuditDate
		DateTime lStartDate;
		DateTime lEndDate;
		public AddReasonUI(RoomBlockFacade oRoomBlockFacade, RoomBlockCollection oRoomBlockColl, C1.Win.C1FlexGrid.Classic.C1FlexGridClassic vs, DateTime pStartDate, DateTime pEndDate, int pRowStart, int pRowEnd)
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();


			RoomBlockFacade = oRoomBlockFacade;
			RoomBlockCollection = oRoomBlockColl;
			rowStart = pRowStart;
			//startCol = startC;
			rowEnd = pRowEnd;
			//endCol = endC;
			lStartDate = pStartDate;
			lEndDate = pEndDate;

			vsGrid = vs;
			this.txtBlockID.Text = oRoomBlockFacade.getNextBlockNo().ToString();
			RoomBlockCollection.AddBlockID(Int32.Parse(this.txtBlockID.Text));

			
			for (int _row = rowStart; _row <= rowEnd; _row++)
			{
				this.txtRoomsToBlock.Text += this.vsGrid.get_TextMatrix(_row, 1) + ", ";
			}
			this.txtFromDate.Text = pStartDate.ToLongDateString();
			this.txtToDate.Text = pEndDate.ToLongDateString();
			this.txtReason.Focus();
		}

		//>>to be revised, [dont pass reason]
		//>> jrom jan 31, 2009
		public AddReasonUI(int blockID)
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

			string _folioID = "";

            this.txtBlockID.Text = blockID.ToString();
            //this.txtReason.Text = Reason;


			try
			{
				RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
				IList<RoomBlock> _oRoomBlockList = oRoomBlockFacade.getRoomBlockInfoById(blockID.ToString());

				// load blocking information
				foreach (RoomBlock _oRoomBlock in _oRoomBlockList)
				{
					this.txtRoomsToBlock.Text += _oRoomBlock.RoomID + ", ";
					this.txtFromDate.Text = _oRoomBlock.BlockFrom.ToLongDateString();
					this.txtToDate.Text = _oRoomBlock.BlockTo.ToLongDateString();
					this.txtReason.Text = _oRoomBlock.Reason;

					_folioID = _oRoomBlock.FolioID;

				}

				this.btnOk.Enabled = false;

				if (_folioID == "")
				{
					this.lblBlockedRooms.Visible = false;
					this.lblRequiredRooms.Visible = false;
					this.txtBlockedRooms.Visible = false;
					this.txtRequiredRooms.Visible = false;
				}
				else
				{ 
					//get Folio Information
					ReservationsFacade oReservationFacade = new ReservationsFacade();
					DataTable tempTable = oReservationFacade.getGroupList();

					DataView tempView = tempTable.DefaultView;
					tempView.RowFilter = "FolioId = '" + _folioID + "'";

					if (tempView.Count > 0)
					{
						this.txtBlockedRooms.Text = tempView[0]["BlockedRooms"].ToString();
						this.txtRequiredRooms.Text = tempView[0]["RequiredRooms"].ToString();
					}

				}

			}
			catch(Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        #endregion

        #region " EVENTS "


        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
			if (loRoomBlockCollection != null)
			{
				if (loRoomBlockCollection.Count > 0)
				{

					foreach (RoomBlock _oRoomBlock in loRoomBlockCollection)
					{
						_oRoomBlock.Reason = this.txtReason.Text;
					}

					RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
					oRoomBlockFacade.SaveRoomBlock(loRoomBlockCollection);

					this.Close();
				}
			}
			else
			{
				ArrayList rooms = new ArrayList();
				for (int r = rowStart; r <= rowEnd; r++)
				{
					rooms.Add(this.vsGrid.get_TextMatrix(r, 1));
				}
				int dayStart = ((startCol - 1) / 2) + 1;//allow overlapping at start date
				int dayEnd = ((endCol - 1) / 2) - 1; //allow overlapping at end date
				string sDate = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate).AddDays(dayStart));
				string eDate = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate).AddDays(dayEnd));

				RoomBlockFacade oRmBlockFacade = new RoomBlockFacade();
				if (!(oRmBlockFacade.isConflictWithRoomEvents(sDate, eDate, rooms)))
				{
					SaveEntry();
				}
				else
				{
					MessageBox.Show("There is an existing blocking or roomevents set by other user for this selection.\nPress F10 to refresh room calendar display.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            if (RoomBlockCollection != null)
            {
                RoomBlockCollection.Clear();
            }
            this.Close();
        }

        #endregion

        #region " METHODS "

        public void SaveEntry()
        {
            if (RoomBlockCollection != null)
            {
                if (this.txtReason.Text != "")
                {
					
                    for (int _row = rowStart; _row <= rowEnd; _row++)
                    {
                        RoomBlock roomBlock = new RoomBlock();
                        roomBlock.RoomID = vsGrid.get_TextMatrix(_row, 1).ToString();
						
						roomBlock.BlockFrom = lStartDate;
						roomBlock.BlockTo = lEndDate;

                        
                        RoomBlockCollection.Add(roomBlock);
                        
                    }
                    RoomBlockCollection.AddBlockID(System.Convert.ToInt32(this.txtBlockID.Text));
                    RoomBlockCollection.AddReason(this.txtReason.Text);
                    
                    //change here to incorparate confirmation process during blocking
                    RoomBlockFacade.SaveRoomBlock(RoomBlockCollection);
                    success = true;

                    RoomBlockCollection.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please input reason for blocking!", "Blocking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        public bool showAddReason()
        {
            ShowDialog();
            this.Close();
            return success;

        }

        #endregion

		private void AddReasonUI_Load(object sender, EventArgs e)
		{
			this.txtReason.Focus();
		}

    }
}