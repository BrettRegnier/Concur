using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	public partial class AddSync : Form
	{
		public FileSyncer fileSyncer;
		public AddSync(FileSyncer fs = null)
		{
			InitializeComponent();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			fileSyncer = fs;

			txtSrc.Text = "Example: C:\\MyFolder";
			txtSrc.ForeColor = Color.DarkGray;
			txtDest.Text = "Example: C:\\MyFolder";
			txtDest.ForeColor = Color.DarkGray;

			txtSrc.GotFocus += RemoveText;
			txtSrc.LostFocus += AddText;

			txtDest.GotFocus += RemoveText;
			txtDest.LostFocus += AddText;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			// error check for bad folders, such as 
			//C:/ 
			//C:/Windows
			//C:/ProgramFiles/

			if (fileSyncer == null)
			{
				fileSyncer = new FileSyncer();
			}
			fileSyncer.Source(txtSrc.Text);
			fileSyncer.Destination(txtDest.Text);
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Close();
		}

		private void btnSrc_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult r = fbd.ShowDialog();
				if (r == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txtSrc.Text = fbd.SelectedPath;
					txtSrc.ForeColor = Color.Black;
				}
			}
		}

		private void btnDest_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult r = fbd.ShowDialog();
				if (r == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txtDest.Text = fbd.SelectedPath;
					txtDest.ForeColor = Color.Black;
				}
			}
		}

		public void RemoveText(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "Example: C:\\MyFolder")
				((TextBox)sender).Text = "";

			((TextBox)sender).ForeColor = Color.Black;
		}

		public void AddText(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
			{
				((TextBox)sender).Text = "Example: C:\\MyFolder";
				((TextBox)sender).ForeColor = Color.DarkGray;
			}
		}
	}
}
