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

			RefreshDataGrid();
			CreateTrayMenu();
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
				manager.RegisterSync(addForm.fileSyncer);
			}
			RefreshDataGrid();
		}

		private void RefreshDataGrid()
		{
			dgSyncs.AllowUserToAddRows = true;
			dgSyncs.Rows.Clear();
			foreach (FileSyncer fs in manager.FileSyncers())
			{
				DataGridViewRow row = (DataGridViewRow)dgSyncs.Rows[0].Clone();
				row.Cells[0].Value = fs.ID;
				row.Cells[1].Value = fs.Source().Path;
				row.Cells[2].Value = fs.Destination().Path;
				row.Cells[3].Value = fs.LastSync;
				dgSyncs.Rows.Add(row);
			}

			dgSyncs.AllowUserToAddRows = false;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			string id = (string)dgSyncs[0, dgSyncs.CurrentCell.RowIndex].Value;
			AddSync ad = new AddSync(manager.GetSyncer(id));

			manager.SaveFileSyncs();
			RefreshDataGrid();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			string id = (string)dgSyncs[0, dgSyncs.CurrentCell.RowIndex].Value;
			manager.Delete(id);
			manager.SaveFileSyncs();
			RefreshDataGrid();
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

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
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
				RefreshDataGrid();
				manager.ContinueTask();
			}

			timCheckLast.Enabled = false;
		}
	}
}
