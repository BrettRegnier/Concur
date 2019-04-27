using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	class SyncControl : Panel
	{
		// TODO fix delegates
		// delegates
		public delegate void UpdateList();
		public event UpdateList PanelModified;

		SyncFile _syncFile;

		// This might be a custom class. dunno yet...
		Panel _additional = new Panel();

		Label _name = new Label();
		Label _lastSync = new Label();
		Button _edit = new Button();
		Button _remove = new Button();

		bool _isEditting = false;

		public SyncControl(SyncFile syncfile)
		{
			_syncFile = syncfile;
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();

			// _name
			this._name.AutoSize = true;
			this._name.Location = new System.Drawing.Point(3, 7);
			this._name.Name = "lblName";
			this._name.Size = new System.Drawing.Size(33, 13);
			this._name.TabIndex = 0;
			this._name.Text = _syncFile.Name;

			// _lastsync
			this._lastSync.AutoSize = true;
			this._lastSync.Location = new System.Drawing.Point(131, 7);
			this._lastSync.Name = "lblLastSync";
			this._lastSync.Size = new System.Drawing.Size(33, 13);
			this._lastSync.TabIndex = 0;
			this._lastSync.Text = _syncFile.LastSync;

			//edit
			this._edit.Location = new System.Drawing.Point(473, 7);
			this._edit.Name = "_edit";
			this._edit.Size = new System.Drawing.Size(29, 23);
			this._edit.TabIndex = 0;
			this._edit.Text = "";
			this._edit.Image = Properties.Resources.edit;
			this._edit.UseVisualStyleBackColor = true;

			//remove
			this._remove.Location = new System.Drawing.Point(508, 7);
			this._remove.Name = "_remove";
			this._remove.Size = new System.Drawing.Size(29, 23);
			this._remove.TabIndex = 0;
			this._remove.Text = "";
			this._remove.Image = Properties.Resources.delete;
			this._remove.UseVisualStyleBackColor = true;

			this.BorderStyle = BorderStyle.FixedSingle;
			this.Left = -1;
			this.Width = 542;
			this.Height = 38;

			this.Controls.Add(this._name);
			this.Controls.Add(this._lastSync);
			this.Controls.Add(this._edit);
			this.Controls.Add(this._remove);

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			int addHeight = 171;
			if (!_isEditting)
			{
				Label panelLabel = new Label();
				panelLabel.Text = "Folders";
				panelLabel.Left = 7;
				panelLabel.Top = 2;
				_additional.Controls.Add(panelLabel);
				_additional.Controls.Add(CreateFoldersPanel(sf));
				this.Controls.Add(_additional);

				this.Height += addHeight;

				// move the other panels below down by a certain amount
				bool fnd = false;
				foreach (Control cntrl in pnlSyncs.Controls)
				{
					if (fnd)
						cntrl.Top += addHeight;

					if ((Panel)cntrl == panel)
						fnd = true;
				}

				_isEditting = true;
			}
			else
			{
				this.Controls.Remove(additional);
				this.Height -= addHeight;

				// move the other panels below up by a certain amount
				bool fnd = false;
				foreach (Control cntrl in pnlSyncs.Controls)
				{
					if (fnd)
						cntrl.Top -= addHeight;

					if ((Panel)cntrl == panel)
						fnd = true;
				}

				isOpen = false;
			}
		}

		public void UpdateText()
		{
			this._name.Text = _syncFile.Name;
			this._lastSync.Text = _syncFile.LastSync;
		}
	}
}
