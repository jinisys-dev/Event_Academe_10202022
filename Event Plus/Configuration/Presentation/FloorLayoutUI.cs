/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	
		public class FloorLayoutUI : Maintenance2UI
		{
			
			#region " Windows Form Designer generated code "
			
			public FloorLayoutUI()
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
			//Do not modify it using the code editor.
			internal System.Windows.Forms.PictureBox picFloorLayout;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.PictureBox picRoomTypeLookUp;
			public System.Windows.Forms.Label Label4;
			public System.Windows.Forms.Label Label5;
			public System.Windows.Forms.Label Label6;
			public System.Windows.Forms.TextBox txtgHotelId;
			public System.Windows.Forms.TextBox txtFloor;
			public System.Windows.Forms.TextBox txtFloorLayoutImage;
			internal System.Windows.Forms.OpenFileDialog ofdPickFloorLayout;
			internal System.Windows.Forms.Button btnUpdate;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.TextBox txtRoomId;
			public System.Windows.Forms.TextBox txtXAxis;
			public System.Windows.Forms.TextBox txtYAxis;
			internal System.Windows.Forms.TextBox txtCoord;
			internal System.Windows.Forms.PictureBox picRoomCoord;
			internal System.Windows.Forms.GroupBox gbxRoom;
            internal Button btnClose;
			internal System.Windows.Forms.GroupBox GroupBox1;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorLayoutUI));
				this.picFloorLayout = new System.Windows.Forms.PictureBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.txtgHotelId = new System.Windows.Forms.TextBox();
				this.Label2 = new System.Windows.Forms.Label();
				this.txtFloor = new System.Windows.Forms.TextBox();
				this.Label3 = new System.Windows.Forms.Label();
				this.txtFloorLayoutImage = new System.Windows.Forms.TextBox();
				this.picRoomTypeLookUp = new System.Windows.Forms.PictureBox();
				this.Label4 = new System.Windows.Forms.Label();
				this.txtRoomId = new System.Windows.Forms.TextBox();
				this.Label5 = new System.Windows.Forms.Label();
				this.txtXAxis = new System.Windows.Forms.TextBox();
				this.Label6 = new System.Windows.Forms.Label();
				this.txtYAxis = new System.Windows.Forms.TextBox();
				this.ofdPickFloorLayout = new System.Windows.Forms.OpenFileDialog();
				this.btnUpdate = new System.Windows.Forms.Button();
				this.btnSave = new System.Windows.Forms.Button();
				this.btnCancel = new System.Windows.Forms.Button();
				this.txtCoord = new System.Windows.Forms.TextBox();
				this.picRoomCoord = new System.Windows.Forms.PictureBox();
				this.gbxRoom = new System.Windows.Forms.GroupBox();
				this.GroupBox1 = new System.Windows.Forms.GroupBox();
				this.btnClose = new System.Windows.Forms.Button();
				((System.ComponentModel.ISupportInitialize)(this.picFloorLayout)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.picRoomTypeLookUp)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.picRoomCoord)).BeginInit();
				this.gbxRoom.SuspendLayout();
				this.SuspendLayout();
				// 
				// picFloorLayout
				// 
				this.picFloorLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				this.picFloorLayout.Location = new System.Drawing.Point(5, 70);
				this.picFloorLayout.Name = "picFloorLayout";
				this.picFloorLayout.Size = new System.Drawing.Size(608, 368);
				this.picFloorLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
				this.picFloorLayout.TabIndex = 0;
				this.picFloorLayout.TabStop = false;
				this.picFloorLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFloorLayout_MouseDown);
				this.picFloorLayout.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picFloorLayout_MouseMove);
				// 
				// Label1
				// 
				this.Label1.Location = new System.Drawing.Point(7, 11);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(64, 17);
				this.Label1.TabIndex = 56;
				this.Label1.Text = "Hote Id";
				// 
				// txtgHotelId
				// 
				this.txtgHotelId.BackColor = System.Drawing.SystemColors.ActiveBorder;
				this.txtgHotelId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtgHotelId.Enabled = false;
				this.txtgHotelId.Location = new System.Drawing.Point(61, 9);
				this.txtgHotelId.MaxLength = 11;
				this.txtgHotelId.Multiline = true;
				this.txtgHotelId.Name = "txtgHotelId";
				this.txtgHotelId.ReadOnly = true;
				this.txtgHotelId.Size = new System.Drawing.Size(35, 20);
				this.txtgHotelId.TabIndex = 55;
				this.txtgHotelId.Text = "1";
				// 
				// Label2
				// 
				this.Label2.Location = new System.Drawing.Point(6, 39);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(64, 17);
				this.Label2.TabIndex = 58;
				this.Label2.Text = "Floor";
				// 
				// txtFloor
				// 
				this.txtFloor.BackColor = System.Drawing.SystemColors.Info;
				this.txtFloor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtFloor.Location = new System.Drawing.Point(60, 37);
				this.txtFloor.MaxLength = 11;
				this.txtFloor.Multiline = true;
				this.txtFloor.Name = "txtFloor";
				this.txtFloor.Size = new System.Drawing.Size(86, 20);
				this.txtFloor.TabIndex = 57;
				this.txtFloor.TextChanged += new System.EventHandler(this.txtFloor_TextChanged);
				// 
				// Label3
				// 
				this.Label3.Location = new System.Drawing.Point(149, 42);
				this.Label3.Name = "Label3";
				this.Label3.Size = new System.Drawing.Size(66, 17);
				this.Label3.TabIndex = 58;
				this.Label3.Text = "Layout File :";
				// 
				// txtFloorLayoutImage
				// 
				this.txtFloorLayoutImage.BackColor = System.Drawing.SystemColors.Info;
				this.txtFloorLayoutImage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtFloorLayoutImage.Location = new System.Drawing.Point(217, 39);
				this.txtFloorLayoutImage.MaxLength = 11;
				this.txtFloorLayoutImage.Multiline = true;
				this.txtFloorLayoutImage.Name = "txtFloorLayoutImage";
				this.txtFloorLayoutImage.Size = new System.Drawing.Size(396, 20);
				this.txtFloorLayoutImage.TabIndex = 57;
				this.txtFloorLayoutImage.TextChanged += new System.EventHandler(this.txtFloorLayoutImage_TextChanged);
				// 
				// picRoomTypeLookUp
				// 
				this.picRoomTypeLookUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				this.picRoomTypeLookUp.Cursor = System.Windows.Forms.Cursors.Hand;
				this.picRoomTypeLookUp.Image = ((System.Drawing.Image)(resources.GetObject("picRoomTypeLookUp.Image")));
				this.picRoomTypeLookUp.Location = new System.Drawing.Point(593, 39);
				this.picRoomTypeLookUp.Name = "picRoomTypeLookUp";
				this.picRoomTypeLookUp.Size = new System.Drawing.Size(22, 20);
				this.picRoomTypeLookUp.TabIndex = 83;
				this.picRoomTypeLookUp.TabStop = false;
				this.picRoomTypeLookUp.Click += new System.EventHandler(this.picRoomTypeLookUp_Click);
				// 
				// Label4
				// 
				this.Label4.Location = new System.Drawing.Point(14, 14);
				this.Label4.Name = "Label4";
				this.Label4.Size = new System.Drawing.Size(52, 17);
				this.Label4.TabIndex = 56;
				this.Label4.Text = "Room Id";
				// 
				// txtRoomId
				// 
				this.txtRoomId.BackColor = System.Drawing.Color.White;
				this.txtRoomId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtRoomId.Location = new System.Drawing.Point(70, 12);
				this.txtRoomId.MaxLength = 11;
				this.txtRoomId.Multiline = true;
				this.txtRoomId.Name = "txtRoomId";
				this.txtRoomId.Size = new System.Drawing.Size(121, 20);
				this.txtRoomId.TabIndex = 55;
				// 
				// Label5
				// 
				this.Label5.Location = new System.Drawing.Point(208, 12);
				this.Label5.Name = "Label5";
				this.Label5.Size = new System.Drawing.Size(41, 17);
				this.Label5.TabIndex = 56;
				this.Label5.Text = "X-axis";
				// 
				// txtXAxis
				// 
				this.txtXAxis.BackColor = System.Drawing.Color.White;
				this.txtXAxis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtXAxis.Location = new System.Drawing.Point(255, 12);
				this.txtXAxis.MaxLength = 11;
				this.txtXAxis.Multiline = true;
				this.txtXAxis.Name = "txtXAxis";
				this.txtXAxis.Size = new System.Drawing.Size(66, 20);
				this.txtXAxis.TabIndex = 55;
				// 
				// Label6
				// 
				this.Label6.Location = new System.Drawing.Point(330, 12);
				this.Label6.Name = "Label6";
				this.Label6.Size = new System.Drawing.Size(41, 17);
				this.Label6.TabIndex = 56;
				this.Label6.Text = "Y-axis";
				// 
				// txtYAxis
				// 
				this.txtYAxis.BackColor = System.Drawing.Color.White;
				this.txtYAxis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtYAxis.Location = new System.Drawing.Point(379, 12);
				this.txtYAxis.MaxLength = 11;
				this.txtYAxis.Multiline = true;
				this.txtYAxis.Name = "txtYAxis";
				this.txtYAxis.Size = new System.Drawing.Size(66, 20);
				this.txtYAxis.TabIndex = 55;
				// 
				// ofdPickFloorLayout
				// 
				this.ofdPickFloorLayout.Filter = " JPEG (*.jpg) |*.jpg| GIF (*.gif) |*.gif| PNG(*.png) |*.png| Bitmap (*.bmp) |*.bm" +
					"p";
				this.ofdPickFloorLayout.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdPickFloorLayout_FileOk);
				// 
				// btnUpdate
				// 
				this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Arrow;
				this.btnUpdate.Font = new System.Drawing.Font("Arial", 8.25F);
				this.btnUpdate.Location = new System.Drawing.Point(342, 449);
				this.btnUpdate.Name = "btnUpdate";
				this.btnUpdate.Size = new System.Drawing.Size(66, 31);
				this.btnUpdate.TabIndex = 85;
				this.btnUpdate.Text = "&Update";
				this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
				// 
				// btnSave
				// 
				this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
				this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
				this.btnSave.Location = new System.Drawing.Point(411, 449);
				this.btnSave.Name = "btnSave";
				this.btnSave.Size = new System.Drawing.Size(66, 31);
				this.btnSave.TabIndex = 86;
				this.btnSave.Text = "&Save";
				this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
				// 
				// btnCancel
				// 
				this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
				this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
				this.btnCancel.Location = new System.Drawing.Point(480, 449);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(66, 31);
				this.btnCancel.TabIndex = 87;
				this.btnCancel.Text = "&Cancel";
				this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
				// 
				// txtCoord
				// 
				this.txtCoord.BorderStyle = System.Windows.Forms.BorderStyle.None;
				this.txtCoord.Location = new System.Drawing.Point(8, 72);
				this.txtCoord.Name = "txtCoord";
				this.txtCoord.Size = new System.Drawing.Size(49, 13);
				this.txtCoord.TabIndex = 88;
				// 
				// picRoomCoord
				// 
				this.picRoomCoord.Image = ((System.Drawing.Image)(resources.GetObject("picRoomCoord.Image")));
				this.picRoomCoord.Location = new System.Drawing.Point(175, 156);
				this.picRoomCoord.Name = "picRoomCoord";
				this.picRoomCoord.Size = new System.Drawing.Size(24, 21);
				this.picRoomCoord.TabIndex = 89;
				this.picRoomCoord.TabStop = false;
				this.picRoomCoord.Visible = false;
				// 
				// gbxRoom
				// 
				this.gbxRoom.Controls.Add(this.txtYAxis);
				this.gbxRoom.Controls.Add(this.Label6);
				this.gbxRoom.Controls.Add(this.txtXAxis);
				this.gbxRoom.Controls.Add(this.Label5);
				this.gbxRoom.Controls.Add(this.txtRoomId);
				this.gbxRoom.Controls.Add(this.Label4);
				this.gbxRoom.Location = new System.Drawing.Point(163, -2);
				this.gbxRoom.Name = "gbxRoom";
				this.gbxRoom.Size = new System.Drawing.Size(456, 37);
				this.gbxRoom.TabIndex = 91;
				this.gbxRoom.TabStop = false;
				// 
				// GroupBox1
				// 
				this.GroupBox1.Location = new System.Drawing.Point(2, 60);
				this.GroupBox1.Name = "GroupBox1";
				this.GroupBox1.Size = new System.Drawing.Size(615, 383);
				this.GroupBox1.TabIndex = 92;
				this.GroupBox1.TabStop = false;
				// 
				// btnClose
				// 
				this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
				this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
				this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
				this.btnClose.Location = new System.Drawing.Point(549, 449);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(66, 31);
				this.btnClose.TabIndex = 188;
				this.btnClose.Text = "Cl&ose";
				this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
				// 
				// FloorLayoutUI
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btnClose;
				this.ClientSize = new System.Drawing.Size(620, 484);
				this.Controls.Add(this.btnClose);
				this.Controls.Add(this.gbxRoom);
				this.Controls.Add(this.picRoomCoord);
				this.Controls.Add(this.txtCoord);
				this.Controls.Add(this.txtFloor);
				this.Controls.Add(this.txtgHotelId);
				this.Controls.Add(this.btnUpdate);
				this.Controls.Add(this.btnSave);
				this.Controls.Add(this.btnCancel);
				this.Controls.Add(this.picRoomTypeLookUp);
				this.Controls.Add(this.picFloorLayout);
				this.Controls.Add(this.Label2);
				this.Controls.Add(this.Label1);
				this.Controls.Add(this.txtFloorLayoutImage);
				this.Controls.Add(this.Label3);
				this.Controls.Add(this.GroupBox1);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.Name = "FloorLayoutUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
				this.Text = "Floor Layout";
				this.Load += new System.EventHandler(this.FloorLayoutUI_Load);
				((System.ComponentModel.ISupportInitialize)(this.picFloorLayout)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.picRoomTypeLookUp)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.picRoomCoord)).EndInit();
				this.gbxRoom.ResumeLayout(false);
				this.gbxRoom.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();

			}
			
			#endregion

            #region " VARIABLES/CONSTANTS "

            private string mode;
            private string picFilenameBeforeEdit;

            Floor oFloor ;
            FloorFacade oFloorFacade ;
            RoomFacade oRoomFacade;
            FormToObjectInstanceBinder oInstanceBinder;

            #endregion

            #region " CONSTRUCTORS "

            // >> Constructor for New Floor Entry
            public FloorLayoutUI(Floor mFloor)
            {
                InitializeComponent();
                oInstanceBinder = new FormToObjectInstanceBinder();
                oFloor = new Floor();
                oFloorFacade = new FloorFacade();
                this.gbxRoom.Visible = false;
                mode = "Add New";

                oFloor = mFloor;
                if (mFloor != null)
                {
                    this.txtgHotelId.Text = mFloor.HotelID.ToString();
                    this.txtFloor.Text = mFloor.FloorName;
                    this.txtFloorLayoutImage.Text = mFloor.FloorLayoutImage;
                    this.mode = "Edit";
                }
                
            }

            // >> constructor for Floor Plan (Update Image)
            //public FloorLayoutUI(Floor mFloor)
            //{
            //    InitializeComponent();
                
            //    oInstanceBinder = new FormToObjectInstanceBinder();
            //    oFloor = new Floor();
            //    oFloorFacade = new FloorFacade();
            //    this.txtgHotelId.Text = mFloor.HotelID.ToString();
            //    this.txtFloor.Text = mFloor.FloorName;
            //    oFloor = mFloor;
            //    mode = "Edit";
            //}

            // >> Constructor for ROOM [SET ROOM COORDINATES]
            public FloorLayoutUI(string roomId, string hotelId, string floor)
            {
                InitializeComponent();

                oInstanceBinder = new FormToObjectInstanceBinder();
                oFloor = new Floor();
                oFloorFacade = new FloorFacade();

                this.txtgHotelId.Text = hotelId;
                this.txtFloor.Text = floor;
                this.txtRoomId.Text = roomId;

                mode = "Set Room Coords";
            }
			
            #endregion

            #region     " METHODS "

			private void loadImage()
			{
				System.Drawing.Image img;
				try
				{
					img = System.Drawing.Image.FromFile(this.txtFloorLayoutImage.Text);
                    this.picFloorLayout.Image = img;
                 
				}
				catch (Exception){}
			}

			private void selectImageFile()
			{
				if ( ! ( mode == "Set Room Coords" ) )
				{
					picFilenameBeforeEdit = this.txtFloorLayoutImage.Text;
					ofdPickFloorLayout.ShowDialog(this);
				}
			}

			private void getFileName()
			{
				try
				{
					this.txtFloorLayoutImage.Text = ofdPickFloorLayout.FileName;
				}
				catch (Exception)
				{
					MessageBox.Show(this.txtFloorLayoutImage.Text + " is not a valid or not supported picture file!","Invalid Picture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
					this.txtFloorLayoutImage.Text = picFilenameBeforeEdit;
				}
			}
         
            private void getImageFileName()
			{
				if (mode != "Add New")
				{
					oFloorFacade = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.FloorFacade();
					this.txtFloorLayoutImage.Text = oFloorFacade.getFloorLayoutImage(this.txtgHotelId.Text, this.txtFloor.Text);
					
				}
			}

            private void assignEntityValues() 
            {   
                oFloor.HotelID = GlobalVariables.gHotelId;
                oFloor.FloorName = this.txtFloor.Text;
                oFloor.FloorLayoutImage = this.txtFloorLayoutImage.Text;
                oFloor.HotelID = GlobalVariables.gHotelId;
                oFloor.CreatedBy = GlobalVariables.gLoggedOnUser;

            }

            public int insert()
            {
                try
                {
                    int rowsAffected = 0;
                    assignEntityValues();
                    oFloorFacade = new FloorFacade();
                    rowsAffected = oFloorFacade.insertFloor(ref oFloor);
                    return rowsAffected;

                }
                catch (Exception)
                {
                    return 0;
                }
            }

			#endregion
      
            #region " EVENTS "

            private void txtKeyPressHandler(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                e.Handled = true;
            }

            private void txtFloorLayoutImage_TextChanged(object sender, System.EventArgs e)
            {
                loadImage();
            }

            private void picRoomTypeLookUp_Click(System.Object sender, System.EventArgs e)
            {
                selectImageFile();
            }

            private void ofdPickFloorLayout_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
            {
                getFileName();
            }

            private void txtFloor_TextChanged(System.Object sender, System.EventArgs e)
            {
                getImageFileName();
            }

            private void picFloorLayout_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (this.txtXAxis.Visible)
                {
                    this.txtCoord.Text = e.X + "," + e.Y;
                    this.txtCoord.Top = e.Y + 100;
                    this.txtCoord.Left = e.X;
                    if (e.X <= 0 || e.Y <= 0 || e.X >= 603 || e.Y >= 363)
                    {
                        this.txtCoord.Visible = false;
                    }
                    else
                    {
                        this.txtCoord.Visible = true;
                    }
                }
            }

            private void picFloorLayout_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (mode == "Set Room Coords" && !(this.picFloorLayout == null))
                {
                    this.txtXAxis.Text = e.X.ToString();
                    this.txtYAxis.Text = e.Y.ToString();

                    this.picRoomCoord.Visible = true;
                    picRoomCoord.Top = e.Y - (this.picRoomCoord.Height / 2);
                    picRoomCoord.Left = e.X - (this.picRoomCoord.Width / 2);
                }
            }

            private void FloorLayoutUI_Load(object sender, System.EventArgs e)
            {
                try
                {
                    this.picFloorLayout.Controls.Add(this.picRoomCoord);
                    switch (mode)
                    {
                        case "Edit":

                            txtgHotelId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPressHandler);
                            txtFloor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPressHandler);

                            this.gbxRoom.Visible = false;
                            this.btnCancel.Enabled = true;
                            this.btnUpdate.Enabled = true;
                            this.btnSave.Enabled = false;
                            this.txtCoord.Visible = false;
                            break;

                        case "Set Room Coords":

                            txtgHotelId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPressHandler);
                            txtFloor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPressHandler);
                            txtFloorLayoutImage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPressHandler);

                            this.gbxRoom.Visible = true;
                            this.btnCancel.Enabled = true;
                            this.btnUpdate.Enabled = true;
                            this.btnSave.Enabled = false;

							this.picRoomTypeLookUp.Visible = false;
                            break;

                        case "Add New":

                            this.gbxRoom.Visible = false;
                            this.btnCancel.Enabled = true;
                            this.btnUpdate.Enabled = false;
                            this.btnSave.Enabled = true;
                            break;
                    }
                   
                }
                catch (Exception){}
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
                this.Close();
            }

            private void btnUpdate_Click(System.Object sender, System.EventArgs e)
            {

                switch (mode)
                {
                    case "Set Room Coords":
                        oRoomFacade = new RoomFacade();
                        oRoomFacade.updateRoomCoordinates(this.txtRoomId.Text, System.Convert.ToInt32(this.txtXAxis.Text), System.Convert.ToInt32(this.txtYAxis.Text));
                        break;
                    case "Edit":
                        
                        assignEntityValues();
                        oFloorFacade = new FloorFacade();
                        oFloorFacade.updateFloorLayoutImage(ref oFloor);
                        break;
                }
                this.Close();
            }

            private void btnSave_Click(System.Object sender, System.EventArgs e)
            {
                if (insert() > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Layout added", "Database Insert Error");
                }
               
            }
			
            #endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            
        }
	
}
