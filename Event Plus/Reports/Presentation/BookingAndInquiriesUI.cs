using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.BusinessLayer;

using Excel = Microsoft.Office.Interop.Excel;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class BookingAndInquiriesUI : Form
    {
        #region "VARIABLES"
        internal GroupBox groupBox2;
        private GroupBox groupBox1;
        private ComboBox cboYear;
        private ComboBox cboMonthYear;
        private ComboBox cboMonth;
        private RadioButton rdoDateRange;
        private RadioButton rdoYearly;
        private RadioButton rdoMonthly;
        private Label label2;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private C1.Win.C1FlexGrid.C1FlexGrid gridBookingInquiries;
        private Button btnClose;
        private Button btnExport;
        private Label label1;

        private ReportFacade loReportFacade;
        private SaveFileDialog sfdExport;
        private GroupBox groupBox3;
        private RadioButton rdbSource;
        private RadioButton rdbStatus;
        private RadioButton rdbMarketSegment;
        private Button btnFilter;
        private Label label3;
        private ComboBox cboFilter;
        private Button btnPreview;
        private DataTable loBookingsInquiries;

        /* Gene
         * 2-Feb-12
         * Will be using dataview to apply filters
         */
        private DataView loBookingsInquiriesView;
        #endregion

        public BookingAndInquiriesUI()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingAndInquiriesUI));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonthYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.rdoDateRange = new System.Windows.Forms.RadioButton();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.gridBookingInquiries = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.rdbMarketSegment = new System.Windows.Forms.RadioButton();
            this.rdbSource = new System.Windows.Forms.RadioButton();
            this.rdbStatus = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookingInquiries)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bookings and Inquiries";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 7);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboMonthYear);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.rdoDateRange);
            this.groupBox1.Controls.Add(this.rdoYearly);
            this.groupBox1.Controls.Add(this.rdoMonthly);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 134);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "to";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(310, 83);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(141, 20);
            this.dtpTo.TabIndex = 7;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(140, 82);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(142, 20);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cboYear.Location = new System.Drawing.Point(140, 51);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 21);
            this.cboYear.TabIndex = 5;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // cboMonthYear
            // 
            this.cboMonthYear.FormattingEnabled = true;
            this.cboMonthYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cboMonthYear.Location = new System.Drawing.Point(267, 18);
            this.cboMonthYear.Name = "cboMonthYear";
            this.cboMonthYear.Size = new System.Drawing.Size(88, 21);
            this.cboMonthYear.TabIndex = 4;
            this.cboMonthYear.SelectedIndexChanged += new System.EventHandler(this.cboMonthYear_SelectedIndexChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMonth.Location = new System.Drawing.Point(140, 18);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 21);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // rdoDateRange
            // 
            this.rdoDateRange.AutoSize = true;
            this.rdoDateRange.Location = new System.Drawing.Point(6, 85);
            this.rdoDateRange.Name = "rdoDateRange";
            this.rdoDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdoDateRange.TabIndex = 2;
            this.rdoDateRange.Text = "Date Range";
            this.rdoDateRange.UseVisualStyleBackColor = true;
            this.rdoDateRange.CheckedChanged += new System.EventHandler(this.rdoDateRange_CheckedChanged);
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(6, 52);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(54, 17);
            this.rdoYearly.TabIndex = 1;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            this.rdoYearly.CheckedChanged += new System.EventHandler(this.rdoYearly_CheckedChanged);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Checked = true;
            this.rdoMonthly.Location = new System.Drawing.Point(6, 19);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 0;
            this.rdoMonthly.TabStop = true;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.rdoMonthly_CheckedChanged);
            // 
            // gridBookingInquiries
            // 
            this.gridBookingInquiries.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gridBookingInquiries.AllowEditing = false;
            this.gridBookingInquiries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBookingInquiries.ColumnInfo = resources.GetString("gridBookingInquiries.ColumnInfo");
            this.gridBookingInquiries.Location = new System.Drawing.Point(12, 187);
            this.gridBookingInquiries.Name = "gridBookingInquiries";
            this.gridBookingInquiries.Rows.Count = 1;
            this.gridBookingInquiries.Rows.DefaultSize = 17;
            this.gridBookingInquiries.Size = new System.Drawing.Size(815, 293);
            this.gridBookingInquiries.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(752, 486);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(654, 486);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 32);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnFilter);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cboFilter);
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Controls.Add(this.rdbMarketSegment);
            this.groupBox3.Controls.Add(this.rdbSource);
            this.groupBox3.Controls.Add(this.rdbStatus);
            this.groupBox3.Location = new System.Drawing.Point(536, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 134);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::Jinisys.Hotel.Reports.Properties.Resources.filesearch16;
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(127, 84);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 31);
            this.btnFilter.TabIndex = 20;
            this.btnFilter.Text = "&Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Filter by :";
            // 
            // cboFilter
            // 
            this.cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(122, 38);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(160, 21);
            this.cboFilter.TabIndex = 17;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::Jinisys.Hotel.Reports.Properties.Resources.filesearch16;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(208, 84);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(77, 31);
            this.btnPreview.TabIndex = 18;
            this.btnPreview.Text = "     &Show";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // rdbMarketSegment
            // 
            this.rdbMarketSegment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbMarketSegment.Location = new System.Drawing.Point(9, 68);
            this.rdbMarketSegment.Name = "rdbMarketSegment";
            this.rdbMarketSegment.Size = new System.Drawing.Size(107, 17);
            this.rdbMarketSegment.TabIndex = 11;
            this.rdbMarketSegment.Text = "Market Segment";
            this.rdbMarketSegment.UseVisualStyleBackColor = true;
            this.rdbMarketSegment.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdbSource
            // 
            this.rdbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSource.Location = new System.Drawing.Point(9, 44);
            this.rdbSource.Name = "rdbSource";
            this.rdbSource.Size = new System.Drawing.Size(107, 18);
            this.rdbSource.TabIndex = 9;
            this.rdbSource.Text = "Source";
            this.rdbSource.UseVisualStyleBackColor = true;
            this.rdbSource.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdbStatus
            // 
            this.rdbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbStatus.Checked = true;
            this.rdbStatus.Location = new System.Drawing.Point(9, 22);
            this.rdbStatus.Name = "rdbStatus";
            this.rdbStatus.Size = new System.Drawing.Size(107, 17);
            this.rdbStatus.TabIndex = 8;
            this.rdbStatus.TabStop = true;
            this.rdbStatus.Text = "Status";
            this.rdbStatus.UseVisualStyleBackColor = true;
            this.rdbStatus.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // BookingAndInquiriesUI
            // 
            this.ClientSize = new System.Drawing.Size(839, 526);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridBookingInquiries);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Name = "BookingAndInquiriesUI";
            this.Text = "Bookings and Inquiries";
            this.Load += new System.EventHandler(this.BookingAndInquiriesUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookingInquiries)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookingAndInquiriesUI_Load(object sender, EventArgs e)
        {
            loReportFacade = new ReportFacade();
            DateTime _now = DateTime.Now;
            cboMonth.SelectedIndex = _now.Month - 1;
            cboMonthYear.Text = _now.Year.ToString();
            cboYear.Text = _now.Year.ToString();
            loadBookingInquiries();
            loadToGrid();
            setButtons();

            /* Gene
             * 2-Feb-12
             * Added to select the first option of the group in the filter box and update the combolist for the filter
             */

            radioButton_CheckedChanged(null, null);
        }

        private DateTime lStartDate;
        private DateTime lEndDate;
        private void loadBookingInquiries()
        {
            try
            {
                if (cboMonth.Text != "" && cboMonthYear.Text != "" && cboYear.Text != "")
                {
                    if (rdoMonthly.Checked)
                    {
                        int _month = cboMonth.SelectedIndex + 1;
                        lStartDate = DateTime.Parse(cboMonthYear.Text + "-" + _month.ToString() + "-01");
                        lEndDate = DateTime.Parse(cboMonthYear.Text + "-" + _month.ToString() + "-" + DateTime.DaysInMonth(int.Parse(cboMonthYear.Text), _month));
                    }
                    else if (rdoYearly.Checked)
                    {
                        lStartDate = DateTime.Parse(cboYear.Text + "-01-01");
                        lEndDate = DateTime.Parse(cboYear.Text + "-12-31");
                    }
                    else
                    {
                        lStartDate = dtpFrom.Value;
                        lEndDate = dtpTo.Value;
                    }
                    loBookingsInquiries = loReportFacade.getBookingInquiries(lStartDate, lEndDate, GlobalVariables.gHotelId);

                    /* Gene
                     * 2-Feb-12
                     */                    
                    loBookingsInquiriesView = loBookingsInquiries.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings and inquiries\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadToGrid()
        {
            /**
             * 0 - CN
             * 1 - Event
             * 2 - Rooms
             * 3 - eventDate
             * 4 - reservationDate
             * 5 - organizer
             * 6 - bookingStatus
             * 7 - clientType
             * 8 - bookingSource
             * 9 - status
             * 10 - mo
             * 11 - reasonType *Gene 01-Mar-12*
             **/

            try
            {
                gridBookingInquiries.Rows.Count = 1;
                ProgressForm progress = new ProgressForm();
                if (loBookingsInquiries != null && loBookingsInquiries.Rows.Count > 0)
                {
                    /* Gene
                     * 01-Mar-12
                     */
                    //gridBookingInquiries.Rows.Count = loBookingsInquiries.Rows.Count + 1;
                    //int count = loBookingsInquiries.Rows.Count + 1;
                    gridBookingInquiries.Rows.Count = loBookingsInquiriesView.ToTable().Rows.Count + 1;
                    int count = loBookingsInquiriesView.ToTable().Rows.Count + 1;
                    progress = new ProgressForm(count, "Loading bookings and inquiries.....");
                    progress.Height = 27;
                    progress.Show();
                    int _row = 1;

                    /* Gene
                     * 2-Feb-12
                     * Used the filtered view instead of the data table
                     */                    
                    //foreach (DataRow _dRow in loBookingsInquiries.Rows)
                    if (loBookingsInquiriesView.ToTable().Rows.Count < 1)
                        gridBookingInquiries.Rows.Count = 1;
                    else
                    {
                        foreach (DataRow _dRow in loBookingsInquiriesView.ToTable().Rows)
                        {
                            gridBookingInquiries.SetData(_row, 0, _dRow["CN"].ToString());
                            gridBookingInquiries.SetData(_row, 1, _dRow["Event"].ToString());
                            gridBookingInquiries.SetData(_row, 2, _dRow["Rooms"].ToString());
                            gridBookingInquiries.SetData(_row, 3, _dRow["eventDate"].ToString());
                            gridBookingInquiries.SetData(_row, 4, _dRow["reservationDate"].ToString());
                            gridBookingInquiries.SetData(_row, 5, _dRow["organizer"].ToString());
                            gridBookingInquiries.SetData(_row, 6, _dRow["bookingStatus"].ToString());
                            gridBookingInquiries.SetData(_row, 7, _dRow["clientType"].ToString());
                            gridBookingInquiries.SetData(_row, 8, _dRow["bookingSource"].ToString());
                            gridBookingInquiries.SetData(_row, 9, _dRow["status"].ToString());
                            gridBookingInquiries.SetData(_row, 10, _dRow["mo"].ToString());
                            /* Gene
                             * 01-Mar-12
                             */
                            gridBookingInquiries.SetData(_row, 11, _dRow["reasonType"].ToString());
                            _row++;
                            progress.updateProgress(_row);
                        }
                    }
                    progress.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings and inquiries in grid\r\n" + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setButtons()
        {
            if (rdoMonthly.Checked)
            {
                cboYear.Enabled = false;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboMonth.Enabled = true;
                cboMonthYear.Enabled = true;
            }
            else if (rdoYearly.Checked)
            {
                cboYear.Enabled = true;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboMonth.Enabled = false;
                cboMonthYear.Enabled = false;
            }
            else
            {
                cboYear.Enabled = false;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                cboMonth.Enabled = false;
                cboMonthYear.Enabled = false;
            }
        }

        private void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadBookingInquiries();
            loadToGrid();
        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadBookingInquiries();
            loadToGrid();
        }

        private void rdoDateRange_CheckedChanged(object sender, EventArgs e)
        {
            setButtons();
            loadBookingInquiries();
            loadToGrid();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadBookingInquiries();
            loadToGrid();
        }

        private void cboMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadBookingInquiries();
            loadToGrid();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButtons();
            loadBookingInquiries();
            loadToGrid();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

            if (dtpFrom.Value > dtpTo.Value)
            {
                gridBookingInquiries.Rows.Count = 1;
                loBookingsInquiries = null;
                MessageBox.Show("From date should be less than to date", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                dtpTo.MinDate = dtpFrom.Value;
                loadBookingInquiries();
                loadToGrid();
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("From date should be less than to date", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            loadBookingInquiries();
            loadToGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            /* Gene
             * 05-Mar-12
             * Changed the source from lobookingsinquiries to lobookingsinquiriesview
             */
            if (loBookingsInquiries == null && loBookingsInquiries.Rows.Count < 1)
                return;

            try
            {
                string strFileName = "List of Bookings and Inquiries(" + string.Format("{0:dd-MMM-yyyy}",lStartDate) +" to " + string.Format("{0:dd-MMM-yyyy}",lEndDate) + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;
                DataTable _user = loReportFacade.getUser(GlobalVariables.goUser.GetType().GetProperty("UserId").GetValue(GlobalVariables.goUser, null).ToString());
                DialogResult _result = sfdExport.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    string[] _letterAddress = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                    ProgressForm progress = new ProgressForm();
                    int count = gridBookingInquiries.Rows.Count + 1;
                    progress = new ProgressForm(count, "Exporting Event List......");
                    progress.Height = 27;
                    progress.Show();

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlApp.ActiveWindow.DisplayGridlines = false;

                    int rowCount = 1;
                    int _tentativeCounter = 0;
                    int _confirmedCounter = 0;
                    int _waitlistCounter = 0;
                    /* Gene
                     * 01-Mar-12
                     */
                    int _cancelledCounter = 0;

                    string _dateHeader = "";
                    if (rdoMonthly.Checked)
                    {
                        _dateHeader = string.Format("{0:MMMM yyyy}", lStartDate);
                    }
                    else if (rdoYearly.Checked)
                    {
                        _dateHeader = string.Format("{0:yyyy}", lStartDate);
                    }
                    else
                    {
                        _dateHeader = string.Format("{0:MMMM dd yyyy}", lStartDate) + "-" +  string.Format("{0:MMMM dd yyyy}", lEndDate);
                    }

                    //add report header
                    xlWorkSheet.Cells[rowCount, 1] = "LIST OF BOOKINGS & INQUIRIES FOR " + string.Format("{0:yyyy}", lStartDate);
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = _dateHeader;
                    rowCount++;
                    //add column headers
                    for (int _col = 1; _col <= loBookingsInquiries.Columns.Count; _col++)
                    {
                        if (_col == 10)
                        {
                            xlWorkSheet.Cells[rowCount, _col] = this.gridBookingInquiries.Cols[_col - 1].Name + "as of " + string.Format("{0:MMMM dd}",DateTime.Now);
                        }
                        else
                        {
                            xlWorkSheet.Cells[rowCount, _col] = this.gridBookingInquiries.Cols[_col - 1].Name;
                        }
                    }
                    rowCount++;
                    //add values
                    /* Gene
                     * 05-Mar-12
                     */
                    //Old Code
                    //foreach(DataRow _drow in loBookingsInquiries.Rows)
                    foreach (DataRow _drow in loBookingsInquiriesView.ToTable().Rows)
                    {
                        /* Gene
                         * 05-Mar-12
                         */
                        //Old Code
                        //for(int _col = 1; _col <= loBookingsInquiries.Columns.Count;_col++)
                        for (int _col = 1; _col <= loBookingsInquiriesView.ToTable().Columns.Count; _col++)
                        {
                            xlWorkSheet.Cells[rowCount, _col] = _drow[_col - 1].ToString();
                            if (_col == 10)
                            {
                                switch (_drow[_col - 1].ToString())
                                {
                                    case "TENTATIVE" :
                                        _tentativeCounter++;
                                        break;
                                    case "WAIT LIST" :
                                        _waitlistCounter++;
                                        break;
                                    case "CONFIRMED" :
                                        _confirmedCounter++;
                                        break;
                                    /* Gene
                                     * 01-Mar-12
                                     */
                                    case "CANCELLED":
                                        _cancelledCounter++;
                                        break;
                                }
                            }
                        }
                        rowCount++;
                        progress.updateProgress(rowCount);
                    }

                    //format
                    xlWorkSheet.get_Range("A1", _letterAddress[gridBookingInquiries.Cols.Count - 1] + "1").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A2", _letterAddress[gridBookingInquiries.Cols.Count - 1] + "2").Merge(Type.Missing);
                    xlWorkSheet.get_Range("A1", _letterAddress[gridBookingInquiries.Cols.Count - 1] + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A2", _letterAddress[gridBookingInquiries.Cols.Count - 1] + "2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range("A3", _letterAddress[gridBookingInquiries.Cols.Count - 1] + (rowCount - 1)).Borders.Weight = Excel.XlBorderWeight.xlThin;


                    //summary
                    xlWorkSheet.Cells[rowCount, 1] = "Total No of Inquiries";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    /* Gene
                     * 05-Mar-12
                     */
                    //Old Code
                    //xlWorkSheet.Cells[rowCount, 3] = loBookingsInquiries.Rows.Count;
                    xlWorkSheet.Cells[rowCount, 3] = loBookingsInquiriesView.ToTable().Rows.Count;

                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "TENTATIVE";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    xlWorkSheet.Cells[rowCount, 3] = _tentativeCounter;
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "WAITLISTED";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    xlWorkSheet.Cells[rowCount, 3] = _waitlistCounter;
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = "CONFIRMED";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    xlWorkSheet.Cells[rowCount, 3] = _confirmedCounter;
                    rowCount++;
                    /* Gene
                     * 01-Mar-12
                     */
                    xlWorkSheet.Cells[rowCount, 1] = "CANCELLED";
                    xlWorkSheet.get_Range("A" + rowCount, "B" + rowCount).Merge(Type.Missing);
                    xlWorkSheet.Cells[rowCount, 3] = _cancelledCounter;
                    /*************************************************/
                    rowCount = rowCount + 2;
                    xlWorkSheet.Cells[rowCount, 1] = "Prepared By";
                    xlWorkSheet.get_Range("A1", _letterAddress[gridBookingInquiries.Cols.Count - 1] + rowCount).EntireColumn.AutoFit();
                    rowCount++;
                    xlWorkSheet.Cells[rowCount, 1] = _user.Rows[0]["FirstName"].ToString() + " " + _user.Rows[0]["LastName"].ToString();
                    rowCount++;

                    progress.Close();
                    try
                    {
                        xlWorkBook.SaveAs(sfdExport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        MessageBox.Show("File Saved", "Event Plus", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot Save/Overwrite XLS File errmsg: " + ex.ToString());
                    }
                    finally
                    {
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                    }

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at importing to excel\r\n" + ex.Message,"Event Management Plus",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /* Gene
         * 2-Feb-12
         * radio buttons for the filter
         */

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboFilter.Text = "";
                if (rdbSource.Checked == true)
                {
                    GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
                    DataTable _oDataTable = _BookingFacade.getSpecificFieldName("BookingSource");

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (DataRow _oRow in _oDataTable.Rows)
                    {
                        cboFilter.Items.Add(_oRow["value"].ToString().ToUpper());
                    }
                }

                if (rdbMarketSegment.Checked == true)
                {
                    GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
                    DataTable _oDataTable = _BookingFacade.getSpecificFieldName("MarketSegment");

                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");
                    foreach (DataRow _oRow in _oDataTable.Rows)
                    {
                        cboFilter.Items.Add(_oRow["value"].ToString().ToUpper());
                    }
                }

                if (rdbStatus.Checked == true)
                {
                    cboFilter.Items.Clear();
                    cboFilter.Items.Add("");                    
                    cboFilter.Items.Add("TENTATIVE");
                    cboFilter.Items.Add("WAIT LIST");
                    cboFilter.Items.Add("CONFIRMED");
                    /* Gene
                     * 01-Mar-12
                     */
                    cboFilter.Items.Add("CANCELLED");
                }
            }
            catch { }
        }

        /* Gene
         * 2-Feb-12
         */
        private void btnFilter_Click(object sender, EventArgs e)
        {
            loBookingsInquiriesView.RowFilter = "";

            if (rdbSource.Checked == true)
            {
                loBookingsInquiriesView.RowFilter = "bookingSource Like '%" + cboFilter.Text + "%'";
            }

            if (rdbMarketSegment.Checked == true)
            {
                loBookingsInquiriesView.RowFilter = "clientType Like '%" + cboFilter.Text + "%'";
            }

            if (rdbStatus.Checked == true)
            {
                loBookingsInquiriesView.RowFilter = "status Like '%" + cboFilter.Text + "%'";
            }

            loadToGrid();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            loadBookingInquiries();
            loadToGrid();
        }
    }
}