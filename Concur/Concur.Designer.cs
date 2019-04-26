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
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSync = new System.Windows.Forms.Button();
			this.timSync = new System.Windows.Forms.Timer(this.components);
			this.menu = new System.Windows.Forms.MenuStrip();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPreferences = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timCheckLast = new System.Windows.Forms.Timer(this.components);
			this.pnlSyncs = new System.Windows.Forms.Panel();
			this.lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.menu.SuspendLayout();
			this.pnlSyncs.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(560, 68);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(118, 35);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnSync
			// 
			this.btnSync.Location = new System.Drawing.Point(560, 109);
			this.btnSync.Name = "btnSync";
			this.btnSync.Size = new System.Drawing.Size(118, 35);
			this.btnSync.TabIndex = 4;
			this.btnSync.Text = "Sync Folders";
			this.btnSync.UseVisualStyleBackColor = true;
			this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
			// 
			// timSync
			// 
			this.timSync.Interval = 1000;
			this.timSync.Tick += new System.EventHandler(this.timSync_Tick);
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.menuPreferences,
            this.aboutToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(690, 24);
			this.menu.TabIndex = 7;
			this.menu.Text = "menuStrip1";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
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
			this.pnlSyncs.Controls.Add(this.panel1);
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(131, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "name";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Miriam CLM", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(508, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(29, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "x";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Miriam CLM", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(473, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(29, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "v";
			this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Location = new System.Drawing.Point(7, 63);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 141);
			this.panel2.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "label4";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(542, 209);
			this.panel1.TabIndex = 0;
			this.panel1.Visible = false;
			// 
			// ConcurMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(690, 677);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.pnlSyncs);
			this.Controls.Add(this.btnSync);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.menu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConcurMain";
			this.Text = "Concur";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConcurMain_FormClosing);
			this.Load += new System.EventHandler(this.ConcurMain_Load);
			this.Resize += new System.EventHandler(this.ConcurMain_Resize);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.pnlSyncs.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.Button btnSync;
		private System.Windows.Forms.Timer timSync;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem menuPreferences;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.Timer timCheckLast;
		private System.Windows.Forms.Panel pnlSyncs;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}