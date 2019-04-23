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
		public AddSync(FileSyncer fs)
		{
			fileSyncer = fs;
			Init();
		}

		public AddSync()
		{
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

			if (fileSyncer != null)
			{
				for (int i = 0; i < fileSyncer.Folders().Count; i++)
					CreateLocationControl(fileSyncer.Folders()[i].Path);
			}
			else
			{
				CreateLocationControl();
				CreateLocationControl();
			}
		}

		private void CreateLocationControl(string location = "Example: C:\\MyFolder")
		{
			Panel panel = new Panel();
			Label lbl = new Label();
			TextBox txt = new TextBox();
			Button browse = new Button();
			Button delete = new Button();

			lbl.Text = "Location " + (pnlLocations.Controls.Count + 1).ToString();
			lbl.Width = 100;
			lbl.Height = 13;

			txt.Text = location;
			txt.ForeColor = Color.DarkGray;
			txt.GotFocus += RemoveText;
			txt.LostFocus += AddText;
			txt.Width = 197;

			browse.Text = "...";
			browse.Width = 36;
			browse.Click += (sender, e) =>
			{
				using (var fbd = new FolderBrowserDialog())
				{
					DialogResult r = fbd.ShowDialog();
					if (r == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						txt.Text = fbd.SelectedPath;
						txt.ForeColor = Color.Black;
					}
				}
			};

			delete.Text = "x";
			delete.ForeColor = Color.Red;
			delete.Width = 36;
			delete.Click += (sender, e) =>
			{
				bool find = false;
				for (int i = 0; i < pnlLocations.Controls.Count; i++)
				{
					if (find)
						pnlLocations.Controls[i].Top -= 52;
					if (panel == pnlLocations.Controls[i])
						find = true;
				}
				pnlLocations.Controls.Remove(panel);
			};


			lbl.Left = 1;
			lbl.Top = 2;

			txt.Left = 10;
			txt.Top = 20;

			browse.Left = 213;
			browse.Top = 20;

			delete.Left = 255;
			delete.Top = 20;

			panel.Controls.Add(lbl);
			panel.Controls.Add(txt);
			panel.Controls.Add(browse);
			panel.Controls.Add(delete);

			panel.Width = 300;
			panel.Height = 46;

			panel.Left = 0;
			panel.Top = pnlLocations.Controls.Count * 52;

			pnlLocations.Controls.Add(panel);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			//TODO error check for bad folders, such as 
			//C:/ 
			//C:/Windows
			//C:/ProgramFiles/

			// Error check if the source folder is empty, and ask if the user is okay with that 

			string[] str = new string[pnlLocations.Controls.Count];
			int i = 0;
			foreach (Control pnl in pnlLocations.Controls)
			{
				foreach (Control cntrl in pnl.Controls)
				{
					if (cntrl is TextBox)
					{
						str[i++] = cntrl.Text;
						continue;
					}
				}
			}

			if (fileSyncer == null)
				fileSyncer = new FileSyncer(str);
			else
				fileSyncer.Folders(str);
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Close();
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			CreateLocationControl();
		}
	}
}
