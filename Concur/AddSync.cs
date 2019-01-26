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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			fileSyncer = fs;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
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

		}

		private void btnDest_Click(object sender, EventArgs e)
		{

		}
	}
}
