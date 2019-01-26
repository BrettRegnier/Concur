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
			this.dgSyncs = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LastSync = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSync = new System.Windows.Forms.Button();
			this.btnOverrideDest = new System.Windows.Forms.Button();
			this.btnOverrideSrc = new System.Windows.Forms.Button();
			this.timSync = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgSyncs)).BeginInit();
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
			this.dgSyncs.Location = new System.Drawing.Point(12, 12);
			this.dgSyncs.Name = "dgSyncs";
			this.dgSyncs.ReadOnly = true;
			this.dgSyncs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgSyncs.Size = new System.Drawing.Size(443, 228);
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
			this.Source.Width = 125;
			// 
			// Destination
			// 
			this.Destination.HeaderText = "Destination Folder";
			this.Destination.Name = "Destination";
			this.Destination.ReadOnly = true;
			this.Destination.Width = 125;
			// 
			// LastSync
			// 
			this.LastSync.HeaderText = "Last Synced";
			this.LastSync.Name = "LastSync";
			this.LastSync.ReadOnly = true;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 247);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(130, 35);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(167, 247);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(130, 35);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(325, 247);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(130, 35);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSync
			// 
			this.btnSync.Location = new System.Drawing.Point(12, 288);
			this.btnSync.Name = "btnSync";
			this.btnSync.Size = new System.Drawing.Size(130, 35);
			this.btnSync.TabIndex = 4;
			this.btnSync.Text = "Sync Folders";
			this.btnSync.UseVisualStyleBackColor = true;
			this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
			// 
			// btnOverrideDest
			// 
			this.btnOverrideDest.Location = new System.Drawing.Point(167, 288);
			this.btnOverrideDest.Name = "btnOverrideDest";
			this.btnOverrideDest.Size = new System.Drawing.Size(130, 35);
			this.btnOverrideDest.TabIndex = 5;
			this.btnOverrideDest.Text = "Override Destination";
			this.btnOverrideDest.UseVisualStyleBackColor = true;
			this.btnOverrideDest.Click += new System.EventHandler(this.btnOverrideDest_Click);
			// 
			// btnOverrideSrc
			// 
			this.btnOverrideSrc.Location = new System.Drawing.Point(325, 288);
			this.btnOverrideSrc.Name = "btnOverrideSrc";
			this.btnOverrideSrc.Size = new System.Drawing.Size(130, 35);
			this.btnOverrideSrc.TabIndex = 6;
			this.btnOverrideSrc.Text = "Override Source";
			this.btnOverrideSrc.UseVisualStyleBackColor = true;
			this.btnOverrideSrc.Click += new System.EventHandler(this.btnOverrideSrc_Click);
			// 
			// timSync
			// 
			this.timSync.Interval = 1000;
			this.timSync.Tick += new System.EventHandler(this.timSync_Tick);
			// 
			// ConcurMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 337);
			this.Controls.Add(this.btnOverrideSrc);
			this.Controls.Add(this.btnOverrideDest);
			this.Controls.Add(this.btnSync);
			this.Controls.Add(this.dgSyncs);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Name = "ConcurMain";
			this.Text = "Concur";
			this.Load += new System.EventHandler(this.ConcurMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgSyncs)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgSyncs;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Source;
		private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
		private System.Windows.Forms.DataGridViewTextBoxColumn LastSync;
		private System.Windows.Forms.Button btnSync;
		private System.Windows.Forms.Button btnOverrideDest;
		private System.Windows.Forms.Button btnOverrideSrc;
		private System.Windows.Forms.Timer timSync;
	}
}