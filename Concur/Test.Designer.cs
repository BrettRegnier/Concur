namespace Concur
{
	partial class Test
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
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.pnlDisplay = new System.Windows.Forms.Panel();
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.btnPref = new System.Windows.Forms.Button();
			this.btnForce = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnHelp = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.pnlMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMenu
			// 
			this.pnlMenu.Controls.Add(this.btnExit);
			this.pnlMenu.Controls.Add(this.btnHelp);
			this.pnlMenu.Controls.Add(this.btnSearch);
			this.pnlMenu.Controls.Add(this.btnForce);
			this.pnlMenu.Controls.Add(this.btnPref);
			this.pnlMenu.Location = new System.Drawing.Point(0, 20);
			this.pnlMenu.Name = "pnlMenu";
			this.pnlMenu.Size = new System.Drawing.Size(200, 780);
			this.pnlMenu.TabIndex = 0;
			this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
			// 
			// pnlDisplay
			// 
			this.pnlDisplay.Location = new System.Drawing.Point(200, 20);
			this.pnlDisplay.Name = "pnlDisplay";
			this.pnlDisplay.Size = new System.Drawing.Size(1000, 780);
			this.pnlDisplay.TabIndex = 1;
			// 
			// pnlTitle
			// 
			this.pnlTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Size = new System.Drawing.Size(1200, 20);
			this.pnlTitle.TabIndex = 2;
			this.pnlTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitle_Paint);
			// 
			// btnPref
			// 
			this.btnPref.FlatAppearance.BorderSize = 0;
			this.btnPref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPref.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPref.ForeColor = System.Drawing.Color.White;
			this.btnPref.Location = new System.Drawing.Point(0, 0);
			this.btnPref.Name = "btnPref";
			this.btnPref.Size = new System.Drawing.Size(199, 120);
			this.btnPref.TabIndex = 0;
			this.btnPref.Text = "Preferences";
			this.btnPref.UseVisualStyleBackColor = true;
			// 
			// btnForce
			// 
			this.btnForce.FlatAppearance.BorderSize = 0;
			this.btnForce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnForce.ForeColor = System.Drawing.Color.White;
			this.btnForce.Location = new System.Drawing.Point(0, 120);
			this.btnForce.Name = "btnForce";
			this.btnForce.Size = new System.Drawing.Size(199, 120);
			this.btnForce.TabIndex = 1;
			this.btnForce.Text = "Force Sync";
			this.btnForce.UseVisualStyleBackColor = true;
			// 
			// btnSearch
			// 
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.ForeColor = System.Drawing.Color.White;
			this.btnSearch.Location = new System.Drawing.Point(0, 240);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(199, 120);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			// 
			// btnHelp
			// 
			this.btnHelp.FlatAppearance.BorderSize = 0;
			this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHelp.ForeColor = System.Drawing.Color.White;
			this.btnHelp.Location = new System.Drawing.Point(0, 360);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(199, 120);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// btnExit
			// 
			this.btnExit.FlatAppearance.BorderSize = 0;
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.Color.White;
			this.btnExit.Location = new System.Drawing.Point(0, 660);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(199, 120);
			this.btnExit.TabIndex = 4;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			// 
			// Test
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.ClientSize = new System.Drawing.Size(1200, 800);
			this.Controls.Add(this.pnlTitle);
			this.Controls.Add(this.pnlDisplay);
			this.Controls.Add(this.pnlMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Test";
			this.Text = "Test";
			this.Load += new System.EventHandler(this.Test_Load);
			this.pnlMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlMenu;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnForce;
		private System.Windows.Forms.Button btnPref;
		private System.Windows.Forms.Panel pnlDisplay;
		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Button btnExit;
	}
}