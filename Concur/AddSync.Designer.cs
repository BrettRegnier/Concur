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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.pnlLocations = new System.Windows.Forms.Panel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.txtInterval = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(339, 97);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 37);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(339, 12);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(79, 37);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Confirm";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// pnlLocations
			// 
			this.pnlLocations.AutoScroll = true;
			this.pnlLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLocations.Location = new System.Drawing.Point(12, 97);
			this.pnlLocations.Name = "pnlLocations";
			this.pnlLocations.Size = new System.Drawing.Size(321, 213);
			this.pnlLocations.TabIndex = 8;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(339, 54);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(79, 37);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "Add Location";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(79, 20);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(254, 20);
			this.txtName.TabIndex = 10;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(8, 18);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(55, 20);
			this.lblName.TabIndex = 11;
			this.lblName.Text = "Name:";
			// 
			// txtInterval
			// 
			this.txtInterval.Location = new System.Drawing.Point(79, 63);
			this.txtInterval.Name = "txtInterval";
			this.txtInterval.Size = new System.Drawing.Size(254, 20);
			this.txtInterval.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 20);
			this.label1.TabIndex = 13;
			this.label1.Text = "Interval:";
			// 
			// AddSync
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(430, 322);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtInterval);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.pnlLocations);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AddSync";
			this.Text = "Add Folder Sync";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel pnlLocations;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtInterval;
		private System.Windows.Forms.Label label1;
	}
}