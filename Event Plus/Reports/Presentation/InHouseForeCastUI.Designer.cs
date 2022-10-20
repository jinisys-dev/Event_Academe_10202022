namespace Jinisys.Hotel.Reports.Presentation
{
    partial class InHouseForeCastUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InHouseForeCastUI));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpForeCastDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.txtAttendees = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGroups = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWaitList = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPax = new System.Windows.Forms.TextBox();
            this.txtTotalRooms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grdInHouse = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInHouse)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Date :";
            // 
            // dtpForeCastDate
            // 
            this.dtpForeCastDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpForeCastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForeCastDate.Location = new System.Drawing.Point(34, 37);
            this.dtpForeCastDate.Name = "dtpForeCastDate";
            this.dtpForeCastDate.Size = new System.Drawing.Size(140, 20);
            this.dtpForeCastDate.TabIndex = 1;
            this.dtpForeCastDate.ValueChanged += new System.EventHandler(this.dtpForeCastDate_ValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(698, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(66, 31);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(770, 34);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 22);
            this.label2.TabIndex = 186;
            this.label2.Text = "Inhouse Guest Forecast";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblFilter);
            this.groupBox1.Controls.Add(this.cboFilter);
            this.groupBox1.Controls.Add(this.txtAttendees);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGroups);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtWaitList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTotalPax);
            this.groupBox1.Controls.Add(this.txtTotalRooms);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.grdInHouse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpForeCastDate);
            this.groupBox1.Location = new System.Drawing.Point(13, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 597);
            this.groupBox1.TabIndex = 187;
            this.groupBox1.TabStop = false;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(189, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(111, 16);
            this.lblFilter.TabIndex = 198;
            this.lblFilter.Text = "Event Type Filter :";
            // 
            // cboFilter
            // 
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(200, 35);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(121, 22);
            this.cboFilter.TabIndex = 197;
            this.cboFilter.TextChanged += new System.EventHandler(this.cboFilter_TextChanged);
            // 
            // txtAttendees
            // 
            this.txtAttendees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttendees.Enabled = false;
            this.txtAttendees.Location = new System.Drawing.Point(774, 46);
            this.txtAttendees.Name = "txtAttendees";
            this.txtAttendees.ReadOnly = true;
            this.txtAttendees.Size = new System.Drawing.Size(35, 20);
            this.txtAttendees.TabIndex = 196;
            this.txtAttendees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(676, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 195;
            this.label7.Text = "Total Attendees :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGroups
            // 
            this.txtGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroups.Enabled = false;
            this.txtGroups.Location = new System.Drawing.Point(635, 45);
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.ReadOnly = true;
            this.txtGroups.Size = new System.Drawing.Size(35, 20);
            this.txtGroups.TabIndex = 194;
            this.txtGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(554, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 193;
            this.label6.Text = "Total Groups :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWaitList
            // 
            this.txtWaitList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWaitList.Enabled = false;
            this.txtWaitList.Location = new System.Drawing.Point(506, 20);
            this.txtWaitList.Name = "txtWaitList";
            this.txtWaitList.ReadOnly = true;
            this.txtWaitList.Size = new System.Drawing.Size(35, 20);
            this.txtWaitList.TabIndex = 192;
            this.txtWaitList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(421, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 191;
            this.label5.Text = "Total Wait List :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalPax
            // 
            this.txtTotalPax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPax.Enabled = false;
            this.txtTotalPax.Location = new System.Drawing.Point(774, 19);
            this.txtTotalPax.Name = "txtTotalPax";
            this.txtTotalPax.ReadOnly = true;
            this.txtTotalPax.Size = new System.Drawing.Size(35, 20);
            this.txtTotalPax.TabIndex = 190;
            this.txtTotalPax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalRooms
            // 
            this.txtTotalRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRooms.Enabled = false;
            this.txtTotalRooms.Location = new System.Drawing.Point(635, 19);
            this.txtTotalRooms.Name = "txtTotalRooms";
            this.txtTotalRooms.ReadOnly = true;
            this.txtTotalRooms.Size = new System.Drawing.Size(35, 20);
            this.txtTotalRooms.TabIndex = 189;
            this.txtTotalRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(694, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 188;
            this.label4.Text = "Total Pax :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(554, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 187;
            this.label3.Text = "Total Rooms :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdInHouse
            // 
            this.grdInHouse.AllowEditing = false;
            this.grdInHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInHouse.ColumnInfo = resources.GetString("grdInHouse.ColumnInfo");
            this.grdInHouse.ExtendLastCol = true;
            this.grdInHouse.Location = new System.Drawing.Point(10, 77);
            this.grdInHouse.Name = "grdInHouse";
            this.grdInHouse.Rows.DefaultSize = 17;
            this.grdInHouse.Size = new System.Drawing.Size(814, 509);
            this.grdInHouse.StyleInfo = resources.GetString("grdInHouse.StyleInfo");
            this.grdInHouse.TabIndex = 186;
            // 
            // InHouseForeCastUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(870, 691);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InHouseForeCastUI";
            this.Text = "InHouse ForeCast";
            this.Activated += new System.EventHandler(this.InHouseForeCastUI_Activated);
            this.Load += new System.EventHandler(this.InHouseForeCastUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInHouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpForeCastDate;
        private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private C1.Win.C1FlexGrid.C1FlexGrid grdInHouse;
        private System.Windows.Forms.TextBox txtTotalPax;
        private System.Windows.Forms.TextBox txtTotalRooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWaitList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAttendees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cboFilter;
    }
}