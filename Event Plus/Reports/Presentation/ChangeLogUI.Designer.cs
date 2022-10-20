namespace Jinisys.Hotel.Reports.Presentation
{
    partial class ChangeLogUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLogUI));
this.btnView = new System.Windows.Forms.Button();
this.btnPrint = new System.Windows.Forms.Button();
this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
this.nudgShiftCode = new System.Windows.Forms.NumericUpDown();
this.label1 = new System.Windows.Forms.Label();
this.label2 = new System.Windows.Forms.Label();
this.grdChanges = new C1.Win.C1FlexGrid.C1FlexGrid();
this.label3 = new System.Windows.Forms.Label();
this.nudgTerminalID = new System.Windows.Forms.NumericUpDown();
this.label4 = new System.Windows.Forms.Label();
this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
this.textBox1 = new System.Windows.Forms.TextBox();
this.label5 = new System.Windows.Forms.Label();
this.cboFields = new System.Windows.Forms.ComboBox();
this.btnFindNext = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.panel1 = new System.Windows.Forms.Panel();
this.panel2 = new System.Windows.Forms.Panel();
this.cboSearchCriteria = new System.Windows.Forms.ComboBox();
this.txtSearchText = new System.Windows.Forms.TextBox();
this.label6 = new System.Windows.Forms.Label();
this.tabSearch = new System.Windows.Forms.TabControl();
this.tabPage1 = new System.Windows.Forms.TabPage();
this.tabPage2 = new System.Windows.Forms.TabPage();
((System.ComponentModel.ISupportInitialize)(this.nudgShiftCode)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.grdChanges)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudgTerminalID)).BeginInit();
this.panel1.SuspendLayout();
this.panel2.SuspendLayout();
this.tabSearch.SuspendLayout();
this.tabPage1.SuspendLayout();
this.tabPage2.SuspendLayout();
this.SuspendLayout();
// 
// btnView
// 
this.btnView.Location = new System.Drawing.Point(661, 37);
this.btnView.Name = "btnView";
this.btnView.Size = new System.Drawing.Size(60, 33);
this.btnView.TabIndex = 1;
this.btnView.Text = "&View";
this.btnView.UseVisualStyleBackColor = true;
this.btnView.Click += new System.EventHandler(this.btnView_Click);
// 
// btnPrint
// 
this.btnPrint.Location = new System.Drawing.Point(724, 37);
this.btnPrint.Name = "btnPrint";
this.btnPrint.Size = new System.Drawing.Size(60, 33);
this.btnPrint.TabIndex = 2;
this.btnPrint.Text = "&Print";
this.btnPrint.UseVisualStyleBackColor = true;
this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
// 
// dtpStartDate
// 
this.dtpStartDate.Location = new System.Drawing.Point(173, 31);
this.dtpStartDate.Name = "dtpStartDate";
this.dtpStartDate.Size = new System.Drawing.Size(191, 20);
this.dtpStartDate.TabIndex = 3;
// 
// nudgShiftCode
// 
this.nudgShiftCode.Location = new System.Drawing.Point(95, 31);
this.nudgShiftCode.Name = "nudgShiftCode";
this.nudgShiftCode.Size = new System.Drawing.Size(64, 20);
this.nudgShiftCode.TabIndex = 4;
this.nudgShiftCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
// 
// label1
// 
this.label1.AutoSize = true;
this.label1.Location = new System.Drawing.Point(95, 11);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(29, 14);
this.label1.TabIndex = 5;
this.label1.Text = "Shift";
// 
// label2
// 
this.label2.AutoSize = true;
this.label2.Location = new System.Drawing.Point(173, 11);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(55, 14);
this.label2.TabIndex = 6;
this.label2.Text = "Start Date";
// 
// grdChanges
// 
this.grdChanges.AutoGenerateColumns = false;
this.grdChanges.AutoResize = false;
this.grdChanges.ColumnInfo = resources.GetString("grdChanges.ColumnInfo");
this.grdChanges.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdChanges.Location = new System.Drawing.Point(30, 116);
this.grdChanges.Name = "grdChanges";
this.grdChanges.Rows.Count = 9;
this.grdChanges.Size = new System.Drawing.Size(817, 502);
this.grdChanges.StyleInfo = resources.GetString("grdChanges.StyleInfo");
this.grdChanges.TabIndex = 187;
// 
// label3
// 
this.label3.AutoSize = true;
this.label3.Location = new System.Drawing.Point(18, 11);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(47, 14);
this.label3.TabIndex = 189;
this.label3.Text = "Terminal";
// 
// nudgTerminalID
// 
this.nudgTerminalID.Location = new System.Drawing.Point(18, 31);
this.nudgTerminalID.Name = "nudgTerminalID";
this.nudgTerminalID.Size = new System.Drawing.Size(63, 20);
this.nudgTerminalID.TabIndex = 188;
this.nudgTerminalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.nudgTerminalID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
// 
// label4
// 
this.label4.AutoSize = true;
this.label4.Location = new System.Drawing.Point(378, 10);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(50, 14);
this.label4.TabIndex = 191;
this.label4.Text = "End Date";
// 
// dtpEndDate
// 
this.dtpEndDate.Location = new System.Drawing.Point(378, 30);
this.dtpEndDate.Name = "dtpEndDate";
this.dtpEndDate.Size = new System.Drawing.Size(191, 20);
this.dtpEndDate.TabIndex = 190;
// 
// textBox1
// 
this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.textBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.textBox1.Location = new System.Drawing.Point(83, 638);
this.textBox1.Name = "textBox1";
this.textBox1.Size = new System.Drawing.Size(283, 20);
this.textBox1.TabIndex = 192;
this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
// 
// label5
// 
this.label5.AutoSize = true;
this.label5.Location = new System.Drawing.Point(35, 641);
this.label5.Name = "label5";
this.label5.Size = new System.Drawing.Size(42, 14);
this.label5.TabIndex = 193;
this.label5.Text = "Search";
// 
// cboFields
// 
this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboFields.FormattingEnabled = true;
this.cboFields.Items.AddRange(new object[] {
            "TERMINAL",
            "SHIFT",
            "USER",
            "SUPERVISOR",
            "REMARKS",
            "TABLE CHANGED",
            "FIELD CHANGED",
            "OLD VALUE",
            "NEW VALUE",
            "DATE/TIME CHANGED",
            "--------------------------",
            "ALL FIELDS"});
this.cboFields.Location = new System.Drawing.Point(372, 637);
this.cboFields.Name = "cboFields";
this.cboFields.Size = new System.Drawing.Size(174, 22);
this.cboFields.TabIndex = 194;
// 
// btnFindNext
// 
this.btnFindNext.Location = new System.Drawing.Point(555, 636);
this.btnFindNext.Name = "btnFindNext";
this.btnFindNext.Size = new System.Drawing.Size(68, 24);
this.btnFindNext.TabIndex = 195;
this.btnFindNext.Text = "Find Next";
this.btnFindNext.UseVisualStyleBackColor = true;
this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Location = new System.Drawing.Point(787, 37);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(60, 33);
this.btnClose.TabIndex = 196;
this.btnClose.Text = "Cl&ose";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// panel1
// 
this.panel1.Controls.Add(this.label3);
this.panel1.Controls.Add(this.dtpStartDate);
this.panel1.Controls.Add(this.nudgShiftCode);
this.panel1.Controls.Add(this.label1);
this.panel1.Controls.Add(this.label2);
this.panel1.Controls.Add(this.nudgTerminalID);
this.panel1.Controls.Add(this.label4);
this.panel1.Controls.Add(this.dtpEndDate);
this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
this.panel1.Location = new System.Drawing.Point(3, 3);
this.panel1.Name = "panel1";
this.panel1.Size = new System.Drawing.Size(611, 62);
this.panel1.TabIndex = 197;
// 
// panel2
// 
this.panel2.Controls.Add(this.cboSearchCriteria);
this.panel2.Controls.Add(this.txtSearchText);
this.panel2.Controls.Add(this.label6);
this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
this.panel2.Location = new System.Drawing.Point(3, 3);
this.panel2.Name = "panel2";
this.panel2.Size = new System.Drawing.Size(611, 62);
this.panel2.TabIndex = 200;
// 
// cboSearchCriteria
// 
this.cboSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboSearchCriteria.FormattingEnabled = true;
this.cboSearchCriteria.Items.AddRange(new object[] {
            "TERMINAL",
            "SHIFT",
            "USER",
            "SUPERVISOR",
            "REMARKS",
            "TABLE CHANGED",
            "FIELD CHANGED",
            "OLD VALUE",
            "NEW VALUE",
            "DATE/TIME CHANGED",
            "--------------------------",
            "ALL FIELDS"});
this.cboSearchCriteria.Location = new System.Drawing.Point(346, 21);
this.cboSearchCriteria.Name = "cboSearchCriteria";
this.cboSearchCriteria.Size = new System.Drawing.Size(174, 22);
this.cboSearchCriteria.TabIndex = 197;
// 
// txtSearchText
// 
this.txtSearchText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtSearchText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtSearchText.Location = new System.Drawing.Point(57, 22);
this.txtSearchText.Name = "txtSearchText";
this.txtSearchText.Size = new System.Drawing.Size(283, 20);
this.txtSearchText.TabIndex = 195;
// 
// label6
// 
this.label6.AutoSize = true;
this.label6.Location = new System.Drawing.Point(9, 25);
this.label6.Name = "label6";
this.label6.Size = new System.Drawing.Size(42, 14);
this.label6.TabIndex = 196;
this.label6.Text = "Search";
// 
// tabSearch
// 
this.tabSearch.Appearance = System.Windows.Forms.TabAppearance.Buttons;
this.tabSearch.Controls.Add(this.tabPage1);
this.tabSearch.Controls.Add(this.tabPage2);
this.tabSearch.Location = new System.Drawing.Point(30, 12);
this.tabSearch.Name = "tabSearch";
this.tabSearch.SelectedIndex = 0;
this.tabSearch.Size = new System.Drawing.Size(625, 98);
this.tabSearch.TabIndex = 201;
// 
// tabPage1
// 
this.tabPage1.Controls.Add(this.panel1);
this.tabPage1.Location = new System.Drawing.Point(4, 26);
this.tabPage1.Name = "tabPage1";
this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
this.tabPage1.Size = new System.Drawing.Size(617, 68);
this.tabPage1.TabIndex = 0;
this.tabPage1.Text = "View by Terminal";
this.tabPage1.UseVisualStyleBackColor = true;
// 
// tabPage2
// 
this.tabPage2.Controls.Add(this.panel2);
this.tabPage2.Location = new System.Drawing.Point(4, 26);
this.tabPage2.Name = "tabPage2";
this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
this.tabPage2.Size = new System.Drawing.Size(617, 68);
this.tabPage2.TabIndex = 1;
this.tabPage2.Text = "Search by Keyword";
this.tabPage2.UseVisualStyleBackColor = true;
// 
// ChangeLogUI
// 
this.AcceptButton = this.btnView;
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(859, 717);
this.Controls.Add(this.tabSearch);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.btnFindNext);
this.Controls.Add(this.cboFields);
this.Controls.Add(this.label5);
this.Controls.Add(this.textBox1);
this.Controls.Add(this.grdChanges);
this.Controls.Add(this.btnPrint);
this.Controls.Add(this.btnView);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Name = "ChangeLogUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Change Logs";
this.Load += new System.EventHandler(this.ChangeLogUI_Load);
((System.ComponentModel.ISupportInitialize)(this.nudgShiftCode)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.grdChanges)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudgTerminalID)).EndInit();
this.panel1.ResumeLayout(false);
this.panel1.PerformLayout();
this.panel2.ResumeLayout(false);
this.panel2.PerformLayout();
this.tabSearch.ResumeLayout(false);
this.tabPage1.ResumeLayout(false);
this.tabPage2.ResumeLayout(false);
this.ResumeLayout(false);
this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.NumericUpDown nudgShiftCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal C1.Win.C1FlexGrid.C1FlexGrid grdChanges;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudgTerminalID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFields;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboSearchCriteria;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}