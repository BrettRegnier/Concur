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
	public partial class ConcurMain : Form
	{
		static SyncManager manager;

		public ConcurMain()
		{
			InitializeComponent();
		}

		private void ConcurMain_Load(object sender, EventArgs e)
		{
			// Load from file, if no file is found then it returns a blank manager
			manager = SyncManager.LoadFileSyncs();

			foreach (SyncFile sf in manager.Syncers())
				DisplaySync(sf);

			CreateTrayMenu();
		}

		private void AddSyncPanel(Panel pnl)
		{
			int idx = pnlSyncs.Controls.Count;
			pnl.Top = idx == 0 ? 52 : pnlSyncs.Controls[idx].Top + 52;
			pnlSyncs.Controls.Add(pnl);
		}

		private void DisplaySync(SyncFile sf)
		{
			Panel panel = new Panel();
			Label name = new Label();
			Label lastSync = new Label();
			Button edit = new Button();
			Button remove = new Button();
			Panel additional = new Panel();

			name.Text = "TODO";
			name.Left = 3;
			name.Top = 7;

			lastSync.Text = sf.LastSync;
			lastSync.Left = 131;
			lastSync.Top = 7;

			edit.Text = "v";
			edit.Width = 29;
			edit.Height = 23;
			edit.Left = 473;
			edit.Top = 7;
			edit.Font = new Font("Miriam CLM", edit.Font.Size);
			bool isOpen = false;
			edit.Click += (sender, e) =>
			{
				if (!isOpen)
				{
					additional = new Panel();
					// Maybe make one big panel for this all so I can just remove the panel.
					Label panelLabel = new Label();
					panelLabel.Text = "Folders";
					panelLabel.Left = 7;
					panelLabel.Top = 2;
					additional.Controls.Add(panelLabel);
					panel.Controls.Add(CreateFoldersPanel(sf));
					panel.Height = 209;
					isOpen = true;
				}
				else
				{
					panel.Controls.Remove(additional);
					panel.Height = 38;
					isOpen = false;
				}
			};

			remove.Text = "x";
			remove.ForeColor = System.Drawing.Color.Red;
			remove.Width = 29;
			remove.Height = 23;
			remove.Left = 508;
			remove.Top = 7;
			remove.Font = new Font("Miriam CLM", remove.Font.Size);
			remove.Click += (sender, e) =>
			{
				DialogResult confirm = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Deletion", MessageBoxButtons.YesNo);
				if (confirm == DialogResult.Yes)
				{
					bool find = false;
					for (int i = 0; i < pnlSyncs.Controls.Count; i++)
					{
						if (find)
							pnlSyncs.Controls[i].Top -= 52;
						if (panel == pnlSyncs.Controls[i])
							find = true;
					}
					pnlSyncs.Controls.Remove(panel);
					manager.Delete(sf.ID);
				}
			};

			panel.BorderStyle = BorderStyle.FixedSingle;
			panel.Left = -1;
			panel.Width = 542;
			panel.Height = 38;

			panel.Controls.Add(name);
			panel.Controls.Add(lastSync);
			panel.Controls.Add(edit);
			panel.Controls.Add(remove);

			int idx = pnlSyncs.Controls.Count - 1;
			panel.Top = idx == 0 ? pnlSyncs.Controls[idx].Top + 37 : -1;
			pnlSyncs.Controls.Add(panel);
		}

		private Panel CreateFoldersPanel(SyncFile sf, string location = "Example: C:\\MyFolder")
		{
			Panel container = new Panel();
			container.Left = 7;
			container.Top = 44;
			container.Width = 321;
			container.Height = 141;
			container.BorderStyle = BorderStyle.FixedSingle;
			container.AutoScroll = true;

			foreach (Folder folder in sf.Folders())
			{
				Panel panel = new Panel();
				Label lbl = new Label();
				TextBox txt = new TextBox();
				Button browse = new Button();
				Button delete = new Button();

				lbl.Text = folder.Name;
				lbl.Width = 100;
				lbl.Height = 13;

				txt.Text = folder.Path;
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
					for (int i = 0; i < container.Controls.Count; i++)
					{
						if (find)
							container.Controls[i].Top -= 52;
						if (panel == container.Controls[i])
							find = true;
					}
					container.Controls.Remove(panel);
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
				panel.Top = container.Controls.Count * 52;

				container.Controls.Add(panel);
			}
			return container;
		}

		private void CreateTrayMenu()
		{
			ContextMenuStrip trayMenu = new ContextMenuStrip();
			trayMenu.Items.Add("Restore");
			trayMenu.Items.Add("Options");
			trayMenu.Items.Add("Exit");

			trayMenu.Items[0].Click += (sender, e) =>
			{
				RestoreWindow();
			};
			trayMenu.Items[1].Click += (sender, e) =>
			{
				Options();
			};
			trayMenu.Items[2].Click += (sender, e) =>
			{
				this.Close();
			};

			trayIcon.ContextMenuStrip = trayMenu;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			AddSync addForm = new AddSync();
			var result = addForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				SyncFile sf = addForm.fileSyncer;
				manager.RegisterSync(sf);
				DisplaySync(sf);
			}
		}

		private void btnSync_Click(object sender, EventArgs e)
		{
			Sync();
		}

		private void timSync_Tick(object sender, EventArgs e)
		{
			// sync the folders. This should have a configuration for the interval
			Sync();
		}

		private void Sync()
		{
			manager.SyncAll();
			timCheckLast.Enabled = true;
		}

		private void menuPreferences_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			config.ShowDialog();
		}

		private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void ConcurMain_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == WindowState)
			{
				Hide();
			}
		}

		private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			RestoreWindow();
		}

		private void RestoreWindow()
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void Options()
		{
		}

		private void ConcurMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			trayIcon.Visible = false;
			trayIcon.Icon = null;
		}

		private void timCheckLast_Tick(object sender, EventArgs e)
		{
			if (manager.WaitingForConfirm())
			{
				manager.ContinueTask();
			}

			timCheckLast.Enabled = false;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void btnDelete_Click(object sender, EventArgs e)
		{

		}

		private void btnEdit_Click(object sender, EventArgs e)
		{

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
