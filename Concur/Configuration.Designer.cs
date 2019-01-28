namespace Concur
{
	partial class Configuration
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
			this.chkOverride = new System.Windows.Forms.CheckBox();
			this.lblOverride = new System.Windows.Forms.Label();
			this.lblinterval = new System.Windows.Forms.Label();
			this.txtInterval = new System.Windows.Forms.TextBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDefaults = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// chkOverride
			// 
			this.chkOverride.AutoSize = true;
			this.chkOverride.Checked = true;
			this.chkOverride.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOverride.Location = new System.Drawing.Point(246, 84);
			this.chkOverride.Name = "chkOverride";
			this.chkOverride.Size = new System.Drawing.Size(15, 14);
			this.chkOverride.TabIndex = 0;
			this.chkOverride.UseVisualStyleBackColor = true;
			// 
			// lblOverride
			// 
			this.lblOverride.AutoSize = true;
			this.lblOverride.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOverride.Location = new System.Drawing.Point(8, 79);
			this.lblOverride.Name = "lblOverride";
			this.lblOverride.Size = new System.Drawing.Size(232, 20);
			this.lblOverride.TabIndex = 1;
			this.lblOverride.Text = "Destination can override source";
			// 
			// lblinterval
			// 
			this.lblinterval.AutoSize = true;
			this.lblinterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblinterval.Location = new System.Drawing.Point(8, 13);
			this.lblinterval.Name = "lblinterval";
			this.lblinterval.Size = new System.Drawing.Size(178, 20);
			this.lblinterval.TabIndex = 2;
			this.lblinterval.Text = "Synchronization Interval";
			// 
			// txtInterval
			// 
			this.txtInterval.Location = new System.Drawing.Point(12, 36);
			this.txtInterval.Name = "txtInterval";
			this.txtInterval.Size = new System.Drawing.Size(174, 20);
			this.txtInterval.TabIndex = 3;
			this.txtInterval.Tag = "0h 0m 0s";
			this.txtInterval.Text = "0h 0m 0s";
			this.txtInterval.TextChanged += new System.EventHandler(this.txtInterval_TextChanged);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(12, 349);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(101, 39);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(119, 349);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(101, 39);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnDefaults
			// 
			this.btnDefaults.Location = new System.Drawing.Point(226, 349);
			this.btnDefaults.Name = "btnDefaults";
			this.btnDefaults.Size = new System.Drawing.Size(101, 39);
			this.btnDefaults.TabIndex = 6;
			this.btnDefaults.Text = "Defaults";
			this.btnDefaults.UseVisualStyleBackColor = true;
			// 
			// Configuration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 399);
			this.Controls.Add(this.btnDefaults);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.txtInterval);
			this.Controls.Add(this.lblinterval);
			this.Controls.Add(this.lblOverride);
			this.Controls.Add(this.chkOverride);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Configuration";
			this.Text = "Configuration";
			this.Load += new System.EventHandler(this.Configuration_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkOverride;
		private System.Windows.Forms.Label lblOverride;
		private System.Windows.Forms.Label lblinterval;
		private System.Windows.Forms.TextBox txtInterval;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnDefaults;
	}
}