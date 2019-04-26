using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	public class SyncDetail
	{
		Panel _panel = new Panel();
		Label _name = new Label();
		Label _lastSync = new Label();
		Button _edit = new Button();
		Button _remove = new Button();

		public SyncDetail(string name, string lastSync)
		{
			_name.Text = name;
			_lastSync.Text = lastSync;
			BuildDisplay();
		}

		private void BuildDisplay()
		{
			_name.Width = 100;
			_name.Left = 1;

			_lastSync.Width = 100;
			_lastSync.Left = 110;

			_edit.Text = "Edit";
			_edit.Width = 100;
			_edit.Height = 30;
			_edit.Left = 210;

			_remove.Text = "x";
			_remove.ForeColor = System.Drawing.Color.Red;
			_remove.Width = 30;
			_remove.Height = 30;
			_remove.Left = 320;

			_panel.Width = 500;
			_panel.Height = 50;

			_panel.Controls.Add(_name);
			_panel.Controls.Add(_lastSync);
			_panel.Controls.Add(_edit);
			_panel.Controls.Add(_remove);
		}

		public Panel GetPanel()
		{
			return _panel;
		}
	}
}
