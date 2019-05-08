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

		private SyncController manager = new SyncController();

		private void Test_Load(object sender, EventArgs e)
		{

			for (int i = 0; i < 5; i++)
			{
				string[] s = new string[10];
				for (int j = 0; j < s.Length; j++)
					s[j] = "test" + i.ToString();
				AddSyncView("test" + i.ToString(), s);
			}
			
		}

		private void AddSyncView(string name, string[] s)
		{
			FileSync fs = new FileSync(name, s);
			SyncView view = new SyncView(fs);
			view.Top = pnlDisplay.Controls.Count * (view.Height - 1);
			view.UpdateView += UpdateView;
			pnlDisplay.Controls.Add(view);
			manager.RegisterSync(fs);
		}

		// Transfer this to the main view
		private void UpdateView(SyncView.ButtonType type, SyncView sender)
		{
			if (type == SyncView.ButtonType.Edit)
			{
				// editting
				// move the other panels below down by a certain amount
				bool find = false;
				for (int i = 0; i < pnlDisplay.Controls.Count; i++)
				{
					if (find)
						pnlDisplay.Controls[i].Top = pnlDisplay.Controls[i - 1].Top + pnlDisplay.Controls[i - 1].Height - 1;
					else if (pnlDisplay.Controls[i] == sender)
						find = true;
				}
			}
			else if (type == SyncView.ButtonType.Delete)
			{
				// deleting
				// move the other panels below down by a certain amount
				manager.Delete(sender.FileSync.ID);
				pnlDisplay.Controls.Remove(sender);

				for (int i = 0; i < pnlDisplay.Controls.Count; i++)
				{
					if (i == 0)
						pnlDisplay.Controls[i].Top = 0;
					else
						pnlDisplay.Controls[i].Top = pnlDisplay.Controls[i - 1].Top + pnlDisplay.Controls[i - 1].Height - 1;
				}
			}
		}

		private void pnlTitle_Paint(object sender, PaintEventArgs e)
		{
			// Left, Top, Right, Bottom
			ControlPaint.DrawBorder(e.Graphics, pnlTitle.ClientRectangle,
				Color.White, ButtonBorderStyle.Solid);
		}

		private void pnlMenu_Paint(object sender, PaintEventArgs e)
		{
			// Left, Top, Right, Bottom
			ControlPaint.DrawBorder(e.Graphics, pnlMenu.ClientRectangle,
				Color.White, 1, ButtonBorderStyle.Solid,
				Color.Transparent, 0, ButtonBorderStyle.Solid,
				Color.White, 1, ButtonBorderStyle.Solid,
				Color.White, 1, ButtonBorderStyle.Solid);
		}

		private void pnlDisplay_Paint(object sender, PaintEventArgs e)
		{
			// Left, Top, Right, Bottom
			ControlPaint.DrawBorder(e.Graphics, pnlDisplay.ClientRectangle,
				Color.Transparent, 0, ButtonBorderStyle.Solid,
				Color.Transparent, 0, ButtonBorderStyle.Solid,
				Color.White, 1, ButtonBorderStyle.Solid,
				Color.White, 1, ButtonBorderStyle.Solid);
		}
	}
}
