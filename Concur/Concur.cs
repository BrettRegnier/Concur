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
	public partial class Concur : Form
	{

		public Concur()
		{
			InitializeComponent();

			//Button btn = new Button();
			//btn.Left = 10;
			//btn.Top = 10;
			//btn.Width = 100;
			//btn.Height = 60;
			//btn.Click += SyncFolders;
		}

		private void btnReg_Click(object sender, EventArgs e)
		{
			FileSyncer fileSyncer = new FileSyncer(txtSource.Text, txtDest.Text);

			fileSyncer.Sync();
		}
	}
}
