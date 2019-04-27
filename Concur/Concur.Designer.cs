namespace Concur
{
	partial class ConcurMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcurMain));
			this.timSync = new System.Windows.Forms.Timer(this.components);
			this.menu = new System.Windows.Forms.MenuStrip();
			this.menuPreferences = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timCheckLast = new System.Windows.Forms.Timer(this.components);
			this.pnlSyncs = new System.Windows.Forms.Panel();
			this.lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuForceSync = new System.Windows.Forms.ToolStripMenuItem();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// timSync
			// 
			this.timSync.Interval = 1000;
			this.timSync.Tick += new System.EventHandler(this.timSync_Tick);
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuPreferences,
            this.menuForceSync,
            this.aboutToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(565, 24);
			this.menu.TabIndex = 7;
			this.menu.Text = "menuStrip1";
			// 
			// menuPreferences
			// 
			this.menuPreferences.Name = "menuPreferences";
			this.menuPreferences.Size = new System.Drawing.Size(80, 20);
			this.menuPreferences.Text = "Preferences";
			this.menuPreferences.Click += new System.EventHandler(this.menuPreferences_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// trayIcon
			// 
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "Concur";
			this.trayIcon.Visible = true;
			this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
			// 
			// timCheckLast
			// 
			this.timCheckLast.Tick += new System.EventHandler(this.timCheckLast_Tick);
			// 
			// pnlSyncs
			// 
			this.pnlSyncs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSyncs.Location = new System.Drawing.Point(12, 67);
			this.pnlSyncs.Name = "pnlSyncs";
			this.pnlSyncs.Size = new System.Drawing.Size(542, 598);
			this.pnlSyncs.TabIndex = 8;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(12, 44);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(51, 20);
			this.lblName.TabIndex = 9;
			this.lblName.Text = "Name";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(144, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 20);
			this.label1.TabIndex = 10;
			this.label1.Text = "Last Sync";
			// 
			// menuNew
			// 
			this.menuNew.Name = "menuNew";
			this.menuNew.Size = new System.Drawing.Size(43, 20);
			this.menuNew.Text = "New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuForceSync
			// 
			this.menuForceSync.Name = "menuForceSync";
			this.menuForceSync.Size = new System.Drawing.Size(76, 20);
			this.menuForceSync.Text = "Force Sync";
			this.menuForceSync.Click += new System.EventHandler(this.menuForceSync_Click);
			// 
			// ConcurMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(565, 677);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.pnlSyncs);
			this.Controls.Add(this.menu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConcurMain";
			this.Text = "Concur";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConcurMain_FormClosing);
			this.Load += new System.EventHandler(this.ConcurMain_Load);
			this.Resize += new System.EventHandler(this.ConcurMain_Resize);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timSync;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem menuPreferences;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.Timer timCheckLast;
		private System.Windows.Forms.Panel pnlSyncs;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem menuNew;
		private System.Windows.Forms.ToolStripMenuItem menuForceSync;
	}
}