namespace Jinisys.Hotel.Reports.Presentation
{
    partial class NoOfPax
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
            this.lvwViewNoOfPax = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.Rooms = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.chkIncoming = new System.Windows.Forms.CheckBox();
            this.chkCheckin = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPax = new System.Windows.Forms.TextBox();
            this.txtTotalRooms = new System.Windows.Forms.TextBox();
            this.chkWaitList = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lvwViewNoOfPax
            // 
            this.lvwViewNoOfPax.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.Rooms});
            this.lvwViewNoOfPax.FullRowSelect = true;
            this.lvwViewNoOfPax.GridLines = true;
            this.lvwViewNoOfPax.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwViewNoOfPax.Location = new System.Drawing.Point(12, 71);
            this.lvwViewNoOfPax.Name = "lvwViewNoOfPax";
            this.lvwViewNoOfPax.Size = new System.Drawing.Size(268, 256);
            this.lvwViewNoOfPax.TabIndex = 0;
            this.lvwViewNoOfPax.UseCompatibleStateImageBehavior = false;
            this.lvwViewNoOfPax.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Room Type";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pax";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Rooms
            // 
            this.Rooms.Text = "Rooms";
            this.Rooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(308, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "ddd., MMM. dd, yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(87, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(197, 20);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.CloseUp += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(308, 264);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(66, 31);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(308, 233);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(66, 31);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // chkIncoming
            // 
            this.chkIncoming.AutoSize = true;
            this.chkIncoming.Checked = true;
            this.chkIncoming.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncoming.Location = new System.Drawing.Point(297, 151);
            this.chkIncoming.Name = "chkIncoming";
            this.chkIncoming.Size = new System.Drawing.Size(68, 18);
            this.chkIncoming.TabIndex = 8;
            this.chkIncoming.Text = "Incoming";
            this.chkIncoming.UseVisualStyleBackColor = true;
            // 
            // chkCheckin
            // 
            this.chkCheckin.AutoSize = true;
            this.chkCheckin.Checked = true;
            this.chkCheckin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckin.Location = new System.Drawing.Point(297, 168);
            this.chkCheckin.Name = "chkCheckin";
            this.chkCheckin.Size = new System.Drawing.Size(67, 18);
            this.chkCheckin.TabIndex = 9;
            this.chkCheckin.Text = "Check In";
            this.chkCheckin.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Include Options:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total Pax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total Rooms";
            // 
            // txtTotalPax
            // 
            this.txtTotalPax.Enabled = false;
            this.txtTotalPax.Location = new System.Drawing.Point(359, 73);
            this.txtTotalPax.Name = "txtTotalPax";
            this.txtTotalPax.ReadOnly = true;
            this.txtTotalPax.Size = new System.Drawing.Size(25, 20);
            this.txtTotalPax.TabIndex = 13;
            this.txtTotalPax.Text = "0";
            this.txtTotalPax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalRooms
            // 
            this.txtTotalRooms.Enabled = false;
            this.txtTotalRooms.Location = new System.Drawing.Point(359, 94);
            this.txtTotalRooms.Name = "txtTotalRooms";
            this.txtTotalRooms.ReadOnly = true;
            this.txtTotalRooms.Size = new System.Drawing.Size(25, 20);
            this.txtTotalRooms.TabIndex = 14;
            this.txtTotalRooms.Text = "0";
            this.txtTotalRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkWaitList
            // 
            this.chkWaitList.AutoSize = true;
            this.chkWaitList.Checked = true;
            this.chkWaitList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitList.Location = new System.Drawing.Point(297, 185);
            this.chkWaitList.Name = "chkWaitList";
            this.chkWaitList.Size = new System.Drawing.Size(73, 32);
            this.chkWaitList.TabIndex = 15;
            this.chkWaitList.Text = "Wait List /\r\nBlocked";
            this.chkWaitList.UseVisualStyleBackColor = true;
            // 
            // NoOfPax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 345);
            this.Controls.Add(this.chkWaitList);
            this.Controls.Add(this.txtTotalRooms);
            this.Controls.Add(this.txtTotalPax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkIncoming);
            this.Controls.Add(this.chkCheckin);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwViewNoOfPax);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoOfPax";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View No. of Pax";
            this.Load += new System.EventHandler(this.NoOfPax_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwViewNoOfPax;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkIncoming;
        private System.Windows.Forms.CheckBox chkCheckin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader Rooms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPax;
        private System.Windows.Forms.TextBox txtTotalRooms;
        private System.Windows.Forms.CheckBox chkWaitList;
    }
}