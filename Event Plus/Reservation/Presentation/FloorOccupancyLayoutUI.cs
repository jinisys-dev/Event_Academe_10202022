

using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;


namespace Jinisys.Hotel.Reservation.Presentation
{
    public class FloorOccupancyUI : Jinisys.Hotel.UIFramework.TransactionUI
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
        internal System.Windows.Forms.Label Label1;

        internal System.Windows.Forms.PictureBox pic;
        internal System.Windows.Forms.Panel panFloors;
        internal System.Windows.Forms.ComboBox cboFloors;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button btnPrevious;
        internal System.Windows.Forms.TextBox txtHotelID;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.PictureBox dotPic;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox picVacant;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.PictureBox picOOO;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.PictureBox picOccupied;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.PictureBox picReserved;
        internal Button btnClose;
		internal Label label7;
        internal System.Windows.Forms.Label Label6;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorOccupancyUI));
			this.Label1 = new System.Windows.Forms.Label();
			this.panFloors = new System.Windows.Forms.Panel();
			this.dotPic = new System.Windows.Forms.PictureBox();
			this.cboFloors = new System.Windows.Forms.ComboBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.txtHotelID = new System.Windows.Forms.TextBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.picVacant = new System.Windows.Forms.PictureBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.picOOO = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.picOccupied = new System.Windows.Forms.PictureBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.picReserved = new System.Windows.Forms.PictureBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.panFloors.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dotPic)).BeginInit();
			this.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picVacant)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picOOO)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picOccupied)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picReserved)).BeginInit();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(17, 13);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(64, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "HotelID";
			this.Label1.Visible = false;
			// 
			// panFloors
			// 
			this.panFloors.Controls.Add(this.dotPic);
			this.panFloors.Location = new System.Drawing.Point(8, 89);
			this.panFloors.Name = "panFloors";
			this.panFloors.Size = new System.Drawing.Size(608, 368);
			this.panFloors.TabIndex = 6;
			// 
			// dotPic
			// 
			this.dotPic.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dotPic.Location = new System.Drawing.Point(111, 132);
			this.dotPic.Name = "dotPic";
			this.dotPic.Size = new System.Drawing.Size(28, 21);
			this.dotPic.TabIndex = 0;
			this.dotPic.TabStop = false;
			// 
			// cboFloors
			// 
			this.cboFloors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFloors.Location = new System.Drawing.Point(89, 49);
			this.cboFloors.Name = "cboFloors";
			this.cboFloors.Size = new System.Drawing.Size(81, 22);
			this.cboFloors.TabIndex = 7;
			this.cboFloors.SelectedIndexChanged += new System.EventHandler(this.cboFloors_SelectedIndexChanged);
			// 
			// btnNext
			// 
			this.btnNext.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(303, 47);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(71, 24);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = "Next";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrevious.Location = new System.Drawing.Point(234, 47);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(65, 24);
			this.btnPrevious.TabIndex = 9;
			this.btnPrevious.Text = "Pevious";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// txtHotelID
			// 
			this.txtHotelID.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.txtHotelID.Location = new System.Drawing.Point(89, 11);
			this.txtHotelID.Name = "txtHotelID";
			this.txtHotelID.ReadOnly = true;
			this.txtHotelID.Size = new System.Drawing.Size(81, 20);
			this.txtHotelID.TabIndex = 10;
			this.txtHotelID.Visible = false;
			// 
			// GroupBox2
			// 
			this.GroupBox2.Location = new System.Drawing.Point(4, 81);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(617, 378);
			this.GroupBox2.TabIndex = 11;
			this.GroupBox2.TabStop = false;
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.White;
			this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel1.Controls.Add(this.Label6);
			this.Panel1.Controls.Add(this.Label5);
			this.Panel1.Controls.Add(this.picVacant);
			this.Panel1.Controls.Add(this.Label4);
			this.Panel1.Controls.Add(this.picOOO);
			this.Panel1.Controls.Add(this.Label3);
			this.Panel1.Controls.Add(this.picOccupied);
			this.Panel1.Controls.Add(this.Label2);
			this.Panel1.Controls.Add(this.picReserved);
			this.Panel1.Location = new System.Drawing.Point(3, 463);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(617, 54);
			this.Panel1.TabIndex = 20;
			// 
			// Label6
			// 
			this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.Location = new System.Drawing.Point(4, 4);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(64, 14);
			this.Label6.TabIndex = 28;
			this.Label6.Text = "LEGEND :";
			// 
			// Label5
			// 
			this.Label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Label5.Location = new System.Drawing.Point(103, 16);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(80, 21);
			this.Label5.TabIndex = 27;
			this.Label5.Text = "Vacant";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picVacant
			// 
			this.picVacant.BackColor = System.Drawing.Color.LightGray;
			this.picVacant.Image = ((System.Drawing.Image)(resources.GetObject("picVacant.Image")));
			this.picVacant.Location = new System.Drawing.Point(79, 16);
			this.picVacant.Name = "picVacant";
			this.picVacant.Size = new System.Drawing.Size(23, 24);
			this.picVacant.TabIndex = 26;
			this.picVacant.TabStop = false;
			// 
			// Label4
			// 
			this.Label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Label4.Location = new System.Drawing.Point(244, 16);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(80, 21);
			this.Label4.TabIndex = 25;
			this.Label4.Text = "Out of Order";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picOOO
			// 
			this.picOOO.BackColor = System.Drawing.Color.LightGray;
			this.picOOO.Image = ((System.Drawing.Image)(resources.GetObject("picOOO.Image")));
			this.picOOO.Location = new System.Drawing.Point(220, 16);
			this.picOOO.Name = "picOOO";
			this.picOOO.Size = new System.Drawing.Size(23, 24);
			this.picOOO.TabIndex = 24;
			this.picOOO.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Label3.Location = new System.Drawing.Point(387, 16);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(80, 21);
			this.Label3.TabIndex = 23;
			this.Label3.Text = "Occupied";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picOccupied
			// 
			this.picOccupied.BackColor = System.Drawing.Color.LightGray;
			this.picOccupied.Image = ((System.Drawing.Image)(resources.GetObject("picOccupied.Image")));
			this.picOccupied.Location = new System.Drawing.Point(363, 16);
			this.picOccupied.Name = "picOccupied";
			this.picOccupied.Size = new System.Drawing.Size(23, 24);
			this.picOccupied.TabIndex = 22;
			this.picOccupied.TabStop = false;
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Label2.Location = new System.Drawing.Point(525, 16);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(80, 21);
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Reserve";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picReserved
			// 
			this.picReserved.BackColor = System.Drawing.Color.LightGray;
			this.picReserved.Image = ((System.Drawing.Image)(resources.GetObject("picReserved.Image")));
			this.picReserved.Location = new System.Drawing.Point(501, 16);
			this.picReserved.Name = "picReserved";
			this.picReserved.Size = new System.Drawing.Size(23, 24);
			this.picReserved.TabIndex = 20;
			this.picReserved.TabStop = false;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(554, 530);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 191;
			this.btnClose.Text = "C&lose";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 54);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 192;
			this.label7.Text = "Floor No.";
			// 
			// FloorOccupancyUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(625, 571);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtHotelID);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.cboFloors);
			this.Controls.Add(this.panFloors);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.Panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FloorOccupancyUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Floor Occupancy Layout";
			this.panFloors.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dotPic)).EndInit();
			this.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picVacant)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picOOO)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picOccupied)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picReserved)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        #region " VARIABLES "

        private int noOfFloors;
        private int currentFloor = 0;

        #endregion

        #region " CONSTRUCTORS "

        public FloorOccupancyUI()
        {
            InitializeComponent();
            GetDistinctFloors();

            this.txtHotelID.Text = GlobalVariables.gHotelId.ToString();
        }

        #endregion

        #region " METHODS "

        private void GetDistinctFloors()
        {
            DataSet datasetFloor = new DataSet();
            
            MySqlCommand SelectCommand = new MySqlCommand("Select *  from floors where hotelid=" + GlobalVariables.gHotelId, GlobalVariables.gPersistentConnection );
            SelectCommand.CommandType = CommandType.Text;
            MySqlDataAdapter dataAdapterFloor = new MySqlDataAdapter(SelectCommand);
            dataAdapterFloor.Fill(datasetFloor, "Floors");
            DataRow datarows;

            foreach (DataRow tempLoopVar_datarows in datasetFloor.Tables["Floors"].Rows)
            {
                datarows = tempLoopVar_datarows;

                pic = new System.Windows.Forms.PictureBox();
                pic.Name = datarows["floor"].ToString();

                this.cboFloors.Items.Add(datarows["floor"]);
                noOfFloors++;
                System.Drawing.Image img = null;

                try
                {
                    img = System.Drawing.Image.FromFile(datarows["FloorLayoutImage"].ToString());

					

                }
                catch// (Exception ex)
                {
                    //MessageBox.Show("Floor layout not found.\r\nDescription: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//Label lbl = new Label();
					//lbl.Text = "No layout available.";
					
					//lbl.Dock = DockStyle.Fill;
					//lbl.Visible = true;
					//this.panFloors.Controls.Add(lbl);
                }

				pic.Image = img;
				pic.Dock = System.Windows.Forms.DockStyle.Fill;
				pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

				pic.Visible = false;
				this.panFloors.Controls.Add(pic);

            }
            try
            {
                this.cboFloors.Text = this.cboFloors.Items[0].ToString();
                setImagevisible(this.cboFloors.Text);
            }
            catch { }

            plotOccupancy();
            
        }
      
        private void plotOccupancy()
        {

            DataTable dtTable = new DataTable("Occupancy");

			string _sqlStr = "call spSelectRoomEventsForFloorOccupancy('" + 
				                   GlobalVariables.gHotelId + "','" + 
								   GlobalVariables.gAuditDate + "')";

            MySqlDataAdapter dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

			dtAdapter.Fill(dtTable);

            
            foreach (DataRow datarows in dtTable.Rows)
            {
                
                foreach (Control ctrl in this.panFloors.Controls)
                {
                    
                    if (datarows["floor"].ToString().ToUpper() == ctrl.Name.ToUpper())
                    {

                        if (ctrl is System.Windows.Forms.PictureBox)
                        {
                            System.Windows.Forms.PictureBox dotPic = new System.Windows.Forms.PictureBox();
                            dotPic.Size = new Size(24, 20);
                           
                            string eventType = datarows["eventtype"].ToString().ToUpper();

                            switch (eventType)
                            {
                                case "RESERVATION":
								case "TENTATIVE":

                                    dotPic.Image = this.picReserved.Image; 
                                    break;
                                case "IN HOUSE":

                                    dotPic.Image = this.picOccupied.Image;
                                    break;
                                case "ENGINEERING JOB":

                                    dotPic.Image = this.picOOO.Image;
                                    break;
                                default:

                                    dotPic.Image = this.picVacant.Image;
                                    break;

                            }
                            
                            dotPic.Location = new System.Drawing.Point(int.Parse(datarows["xcoordinate"].ToString()) - 10, int.Parse(datarows["ycoordinate"].ToString()) - 10);
                            if (!(datarows["xcoordinate"].ToString() == "0" && datarows["ycoordinate"].ToString() == "0"))
                            {
                                ctrl.Controls.Add(dotPic);
                            }
                        }

                    }
                }

            }
        }

        private void setFloor(int flrIndex)
        {
            this.cboFloors.Text = this.cboFloors.Items[flrIndex].ToString();
        }

        private void setImagevisible(string floor)
        {
            System.Windows.Forms.Control ctrl;

            foreach (System.Windows.Forms.Control tempLoopVar_ctrl in this.panFloors.Controls)
            {
                ctrl = tempLoopVar_ctrl;
                if (ctrl.Name.ToUpper() == floor.ToUpper())
                {
                    ctrl.Visible = true;
                }
                else
                {
                    ctrl.Visible = false;
                }
            }
        }

        #endregion

        #region " EVENTS "

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            if (currentFloor < noOfFloors - 1)
            {
                currentFloor++;
                setFloor(currentFloor);
                setImagevisible(this.cboFloors.Text);
            }
        }

        private void btnPrevious_Click(System.Object sender, System.EventArgs e)
        {
            if (currentFloor > 0)
            {
                currentFloor--;
                setFloor(currentFloor);
                setImagevisible(this.cboFloors.Text);
            }
        }

        private void cboFloors_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            currentFloor = this.cboFloors.SelectedIndex;
            setFloor(currentFloor);
            setImagevisible(this.cboFloors.Text);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}