namespace Concur
{
	partial class AddSync
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSync));
			this.txtSrc = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblDest = new System.Windows.Forms.Label();
			this.lblSrc = new System.Windows.Forms.Label();
			this.txtDest = new System.Windows.Forms.TextBox();
			this.btnSrc = new System.Windows.Forms.Button();
			this.btnDest = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtSrc
			// 
			this.txtSrc.Location = new System.Drawing.Point(12, 40);
			this.txtSrc.Name = "txtSrc";
			this.txtSrc.Size = new System.Drawing.Size(197, 20);
			this.txtSrc.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 129);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 37);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(172, 129);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(79, 37);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Add";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblDest
			// 
			this.lblDest.AutoSize = true;
			this.lblDest.Location = new System.Drawing.Point(13, 72);
			this.lblDest.Name = "lblDest";
			this.lblDest.Size = new System.Drawing.Size(92, 13);
			this.lblDest.TabIndex = 4;
			this.lblDest.Text = "Destination Folder";
			// 
			// lblSrc
			// 
			this.lblSrc.AutoSize = true;
			this.lblSrc.Location = new System.Drawing.Point(12, 24);
			this.lblSrc.Name = "lblSrc";
			this.lblSrc.Size = new System.Drawing.Size(73, 13);
			this.lblSrc.TabIndex = 5;
			this.lblSrc.Text = "Source Folder";
			// 
			// txtDest
			// 
			this.txtDest.Location = new System.Drawing.Point(12, 91);
			this.txtDest.Name = "txtDest";
			this.txtDest.Size = new System.Drawing.Size(197, 20);
			this.txtDest.TabIndex = 1;
			// 
			// btnSrc
			// 
			this.btnSrc.Location = new System.Drawing.Point(215, 38);
			this.btnSrc.Name = "btnSrc";
			this.btnSrc.Size = new System.Drawing.Size(36, 23);
			this.btnSrc.TabIndex = 6;
			this.btnSrc.Text = "...";
			this.btnSrc.UseVisualStyleBackColor = true;
			this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
			// 
			// btnDest
			// 
			this.btnDest.Location = new System.Drawing.Point(215, 89);
			this.btnDest.Name = "btnDest";
			this.btnDest.Size = new System.Drawing.Size(36, 23);
			this.btnDest.TabIndex = 7;
			this.btnDest.Text = "...";
			this.btnDest.UseVisualStyleBackColor = true;
			this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
			// 
			// AddSync
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(263, 176);
			this.Controls.Add(this.btnDest);
			this.Controls.Add(this.btnSrc);
			this.Controls.Add(this.lblSrc);
			this.Controls.Add(this.lblDest);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtDest);
			this.Controls.Add(this.txtSrc);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AddSync";
			this.Text = "Add Folder Sync";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSrc;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblDest;
		private System.Windows.Forms.Label lblSrc;
		private System.Windows.Forms.TextBox txtDest;
		private System.Windows.Forms.Button btnSrc;
		private System.Windows.Forms.Button btnDest;
	}
}