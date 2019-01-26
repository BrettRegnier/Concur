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
			btnEdit.Left = ((dgSyncs.Left + dgSyncs.Right) / 2) - btnEdit.Width / 2;

			// Load from file, if no file is found then it returns a blank manager
			manager = SyncManager.LoadFileSyncs();

			RefreshDataGrid();
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

		public void RefreshDataGrid()
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

			manager.SaveFileSyncs();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{

		}

		private void btnSync_Click(object sender, EventArgs e)
		{
			// Force a sync
		}

		private void btnOverrideDest_Click(object sender, EventArgs e)
		{
			// Force the destination overriding
		}

		private void btnOverrideSrc_Click(object sender, EventArgs e)
		{
			// Force the source overriding

		}

		private void timSync_Tick(object sender, EventArgs e)
		{
			// sync the folders. This should have a configuration for the interval
		}
	}
}
