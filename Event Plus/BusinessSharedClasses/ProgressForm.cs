using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ProgressForm : System.Windows.Forms.Form
	{
		
		
		#region " Windows Form Designer generated code "
		
		public ProgressForm()
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
		internal SPB.SmoothProgressBar prgBar;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.prgBar = new SPB.SmoothProgressBar();
            this.SuspendLayout();
            // 
            // prgBar
            // 
            this.prgBar.BackColorStyle = SPB.SmoothProgressBar.ColorStyle.Gradient;
            this.prgBar.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.prgBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgBar.Location = new System.Drawing.Point(0, 0);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(440, 26);
            this.prgBar.Step = 5;
            this.prgBar.TabIndex = 0;
            this.prgBar.Text = "SmoothProgressBar1";
            // 
            // ProgressForm
            // 
            this.ClientSize = new System.Drawing.Size(440, 26);
            this.ControlBox = false;
            this.Controls.Add(this.prgBar);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

		}
		
		#endregion
		private int max;
		public ProgressForm(int maxval, string caption)
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			//Add any initialization after the InitializeComponent() call
			this.prgBar.Maximum = maxval;
			max = maxval;
			this.prgBar.Text = caption;
			this.prgBar.Update();
		}
		public void updateProgress(int currProgress)
		{
			this.prgBar.Value = currProgress;
			this.prgBar.Update();
			this.Update();
			if (currProgress == max)
			{
				this.Close();
			}
		}
		
	}
	
}
