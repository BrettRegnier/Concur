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
	public partial class Test : Form
	{
		public Test()
		{
			InitializeComponent();
		}

		private void Test_Load(object sender, EventArgs e)
		{
			string[] s = { "test", "test" };
			FileSync sf = new FileSync("test", s);
			AddSyncView(sf);
			AddSyncView(sf);
		}

		private void AddSyncView(FileSync sync)
		{
			SyncView view = new SyncView(sync);
			view.Top = Controls.Count * 36;
			view.UpdateView += UpdateView;
			Controls.Add(view);
		}

		// Transfer this to the main view
		private void UpdateView(int type, SyncView sender)
		{
			if (type == 0)
			{
				// editting
				// move the other panels below down by a certain amount
				bool find = false;
				for (int i = 0; i < Controls.Count; i++)
				{
					if (find)
						Controls[i].Top = Controls[i - 1].Top + Controls[i - 1].Height - 1;
					else if (Controls[i] == sender)
						find = true;
				}
			}
			else if (type == 1)
			{
				// deleting
			}
		}
	}
}
