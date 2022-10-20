namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    partial class MinibarSalesViewUI
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.salesTree = new System.Windows.Forms.TreeView();
			this.lvwSalesDetails = new System.Windows.Forms.ListView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblListHeader = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnVoid = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 121);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.salesTree);
			this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(5);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lvwSalesDetails);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.splitContainer1.Size = new System.Drawing.Size(914, 505);
			this.splitContainer1.SplitterDistance = 299;
			this.splitContainer1.TabIndex = 1;
			// 
			// salesTree
			// 
			this.salesTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.salesTree.Location = new System.Drawing.Point(10, 11);
			this.salesTree.Name = "salesTree";
			this.salesTree.Size = new System.Drawing.Size(279, 483);
			this.salesTree.TabIndex = 0;
			this.salesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.salesTree_AfterSelect);
			this.salesTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.salesTree_NodeMouseClick);
			// 
			// lvwSalesDetails
			// 
			this.lvwSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwSalesDetails.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvwSalesDetails.FullRowSelect = true;
			this.lvwSalesDetails.GridLines = true;
			this.lvwSalesDetails.Location = new System.Drawing.Point(10, 11);
			this.lvwSalesDetails.Name = "lvwSalesDetails";
			this.lvwSalesDetails.Size = new System.Drawing.Size(591, 483);
			this.lvwSalesDetails.TabIndex = 2;
			this.lvwSalesDetails.UseCompatibleStateImageBehavior = false;
			this.lvwSalesDetails.View = System.Windows.Forms.View.Details;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.lblListHeader);
			this.groupBox2.Controls.Add(this.btnClose);
			this.groupBox2.Controls.Add(this.btnVoid);
			this.groupBox2.Controls.Add(this.btnLoad);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.dateTimePicker2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.dateTimePicker1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(10, 11);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(894, 99);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(15, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 22);
			this.label3.TabIndex = 11;
			this.label3.Text = "Minibar Sales";
			// 
			// lblListHeader
			// 
			this.lblListHeader.AutoSize = true;
			this.lblListHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblListHeader.Location = new System.Drawing.Point(4, 99);
			this.lblListHeader.Name = "lblListHeader";
			this.lblListHeader.Size = new System.Drawing.Size(0, 16);
			this.lblListHeader.TabIndex = 10;
			this.lblListHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(585, 35);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnVoid
			// 
			this.btnVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnVoid.Location = new System.Drawing.Point(684, 35);
			this.btnVoid.Name = "btnVoid";
			this.btnVoid.Size = new System.Drawing.Size(66, 31);
			this.btnVoid.TabIndex = 1;
			this.btnVoid.Text = "Void";
			this.btnVoid.UseVisualStyleBackColor = true;
			this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoad.Location = new System.Drawing.Point(513, 35);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(66, 31);
			this.btnLoad.TabIndex = 9;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(188, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 14);
			this.label2.TabIndex = 8;
			this.label2.Text = "To :";
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(216, 61);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(108, 20);
			this.dateTimePicker2.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(20, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 14);
			this.label1.TabIndex = 6;
			this.label1.Text = "From :";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(62, 61);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(110, 20);
			this.dateTimePicker1.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.panel1.Size = new System.Drawing.Size(914, 121);
			this.panel1.TabIndex = 0;
			// 
			// MinibarSalesViewUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(914, 626);
			this.ControlBox = false;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MinibarSalesViewUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Minibar Sales";
			this.Activated += new System.EventHandler(this.MinibarSalesViewUI_Activated);
			this.Load += new System.EventHandler(this.ViewUI_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView salesTree;
		private System.Windows.Forms.ListView lvwSalesDetails;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblListHeader;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnVoid;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
    }
}