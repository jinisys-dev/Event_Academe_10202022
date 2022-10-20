using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.UIFramework
{
	namespace Presentation
	{
		public class MDIChildPropertiesUI : System.Windows.Forms.Form
		{
			
			
			#region " Windows Form Designer generated code "
			
			public MDIChildPropertiesUI()
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
			internal System.Windows.Forms.Button ButtonApply;
			internal System.Windows.Forms.Button ButtonClose;
			protected System.Windows.Forms.Panel PanelProperties;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.ButtonApply = new System.Windows.Forms.Button();
				this.ButtonClose = new System.Windows.Forms.Button();
				this.ButtonClose.Click += new System.EventHandler(ButtonClose_Click);
				this.PanelProperties = new System.Windows.Forms.Panel();
				this.SuspendLayout();
				//
				//ButtonApply
				//
				this.ButtonApply.Location = new System.Drawing.Point(208, 432);
				this.ButtonApply.Name = "ButtonApply";
				this.ButtonApply.TabIndex = 1;
				this.ButtonApply.Text = "Apply";
				//
				//ButtonClose
				//
				this.ButtonClose.Location = new System.Drawing.Point(296, 432);
				this.ButtonClose.Name = "ButtonClose";
				this.ButtonClose.TabIndex = 2;
				this.ButtonClose.Text = "Close";
				//
				//PanelProperties
				//
				this.PanelProperties.Location = new System.Drawing.Point(8, 8);
				this.PanelProperties.Name = "PanelProperties";
				this.PanelProperties.Size = new System.Drawing.Size(376, 416);
				this.PanelProperties.TabIndex = 3;
				//
				//MDIChildPropertiesUI
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(394, 468);
				this.Controls.Add(this.PanelProperties);
				this.Controls.Add(this.ButtonClose);
				this.Controls.Add(this.ButtonApply);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
				this.MaximizeBox = false;
				this.Name = "MDIChildPropertiesUI";
				this.Text = "MDIChildPropertiesUI";
				this.ResumeLayout(false);
				
			}
			
			#endregion
			
			private void ButtonClose_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
		}
	}
	
}
