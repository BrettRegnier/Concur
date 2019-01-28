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
			this.dgSyncs = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LastSync = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSync = new System.Windows.Forms.Button();
			this.timSync = new System.Windows.Forms.Timer(this.components);
			this.menu = new System.Windows.Forms.MenuStrip();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timCheckLast = new System.Windows.Forms.Timer(this.components);
			this.lsLog = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.dgSyncs)).BeginInit();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgSyncs
			// 
			this.dgSyncs.AllowUserToDeleteRows = false;
			this.dgSyncs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgSyncs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSyncs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Source,
            this.Destination,
            this.LastSync});
			this.dgSyncs.Location = new System.Drawing.Point(12, 37);
			this.dgSyncs.Name = "dgSyncs";
			this.dgSyncs.ReadOnly = true;
			this.dgSyncs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgSyncs.Size = new System.Drawing.Size(538, 228);
			this.dgSyncs.TabIndex = 0;
			// 
			// ID
			// 
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Width = 50;
			// 
			// Source
			// 
			this.Source.HeaderText = "Source Folder";
			this.Source.Name = "Source";
			this.Source.ReadOnly = true;
			this.Source.Width = 150;
			// 
			// Destination
			// 
			this.Destination.HeaderText = "Destination Folder";
			this.Destination.Name = "Destination";
			this.Destination.ReadOnly = true;
			this.Destination.Width = 150;
			// 
			// LastSync
			// 
			this.LastSync.HeaderText = "Last Synced";
			this.LastSync.Name = "LastSync";
			this.LastSync.ReadOnly = true;
			this.LastSync.Width = 150;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 272);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(130, 35);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(148, 272);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(130, 35);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(284, 272);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(130, 35);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSync
			// 
			this.btnSync.Location = new System.Drawing.Point(420, 271);
			this.btnSync.Name = "btnSync";
			this.btnSync.Size = new System.Drawing.Size(130, 35);
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
            this.optionsToolStripMenuItem,
            this.showLogToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(562, 24);
			this.menu.TabIndex = 7;
			this.menu.Text = "menuStrip1";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// showLogToolStripMenuItem
			// 
			this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
			this.showLogToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.showLogToolStripMenuItem.Text = "Show Log";
			this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
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
			// lsLog
			// 
			this.lsLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsLog.FormattingEnabled = true;
			this.lsLog.Location = new System.Drawing.Point(12, 323);
			this.lsLog.Name = "lsLog";
			this.lsLog.Size = new System.Drawing.Size(538, 186);
			this.lsLog.TabIndex = 8;
			// 
			// ConcurMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(562, 316);
			this.Controls.Add(this.lsLog);
			this.Controls.Add(this.btnSync);
			this.Controls.Add(this.dgSyncs);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.menu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConcurMain";
			this.Text = "Concur";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConcurMain_FormClosing);
			this.Load += new System.EventHandler(this.ConcurMain_Load);
			this.Resize += new System.EventHandler(this.ConcurMain_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dgSyncs)).EndInit();
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgSyncs;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.Button btnSync;
		private System.Windows.Forms.Timer timSync;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.Timer timCheckLast;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Source;
		private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
		private System.Windows.Forms.DataGridViewTextBoxColumn LastSync;
		private System.Windows.Forms.ListBox lsLog;
	}
}