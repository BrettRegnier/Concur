using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	class SyncView : Panel
	{
		//public static List<SyncView> _syncViews = new List<SyncView>();
		// TODO fix delegates
		// delegates
		public delegate void UpdateList(int type, SyncView sender);
		public event UpdateList UpdateView;

		// Enum for delegates
		private enum ButtonType
		{
			Edit = 0,
			Delete = 1
		}

		FileSync _fileSync;

		// This might be a custom class. dunno yet...
		Panel _editPanel = new Panel();

		Label _name = new Label();
		Label _lastSync = new Label();
		Button _edit = new Button();
		Button _remove = new Button();

		bool _isEditting = false;

		public SyncView(FileSync syncfile)
		{
			_fileSync = syncfile;
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
			this._name.Text = _fileSync.Name;

			// _lastsync
			this._lastSync.AutoSize = true;
			this._lastSync.Location = new System.Drawing.Point(131, 7);
			this._lastSync.Name = "lblLastSync";
			this._lastSync.Size = new System.Drawing.Size(33, 13);
			this._lastSync.TabIndex = 0;
			this._lastSync.Text = _fileSync.LastSync;

			//edit
			this._edit.Location = new System.Drawing.Point(473, 7);
			this._edit.Name = "_edit";
			this._edit.Size = new System.Drawing.Size(29, 23);
			this._edit.TabIndex = 0;
			this._edit.Text = "";
			this._edit.Image = Properties.Resources.edit;
			this._edit.UseVisualStyleBackColor = true;
			this._edit.Click += Edit_Click;

			//remove
			this._remove.Location = new System.Drawing.Point(508, 7);
			this._remove.Name = "_remove";
			this._remove.Size = new System.Drawing.Size(29, 23);
			this._remove.TabIndex = 0;
			this._remove.Text = "";
			this._remove.Image = Properties.Resources.delete;
			this._remove.UseVisualStyleBackColor = true;
			this._remove.Click += Remove_Click;

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
				// a new panel should be added, which is the editting panel
				Label panelLabel = new Label();
				panelLabel.Text = "Folders";
				panelLabel.Left = 7;
				panelLabel.Top = 2;

				_editPanel.Controls.Add(panelLabel);
				_editPanel.Controls.Add(CreateFoldersPanel(_fileSync));
				_editPanel.Top = this.Top + this.Height;

				this.Controls.Add(_editPanel);
				this.Height += addHeight;
				_isEditting = true;
			}
			else
			{
				this.Controls.Remove(_editPanel);
				this.Height -= addHeight;

				_isEditting = false;
				_editPanel = new Panel();
			}
			UpdateView(0, this);
		}
		private Panel CreateFoldersPanel(FileSync sf, string location = "Example: C:\\MyFolder")
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
				txt.GotFocus += HidePlaceholderText;
				txt.LostFocus += ShowPlaceholderText;
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
							txt.ForeColor = System.Drawing.Color.Black;
						}
					}
				};

				delete.Image = Properties.Resources.delete;
				delete.ForeColor = System.Drawing.Color.Red;
				delete.Width = 36;
				delete.Click += (sender, e) =>
				{
					bool find = false;
					if (container.Controls.Count > 2)
					{

						for (int i = 0; i < container.Controls.Count; i++)
						{

							if (find)
								container.Controls[i].Top -= 52;
							if (panel == container.Controls[i])
								find = true;
						}
						container.Controls.Remove(panel);
					}
					else
					{
						txt.Text = "";
						ShowPlaceholderText(txt, null);
					}
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

		private void Remove_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void HidePlaceholderText(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "Example: C:\\MyFolder")
				((TextBox)sender).Text = "";

			((TextBox)sender).ForeColor = System.Drawing.Color.Black;
		}

		private void ShowPlaceholderText(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
			{
				((TextBox)sender).Text = "Example: C:\\MyFolder";
				((TextBox)sender).ForeColor = System.Drawing.Color.DarkGray;
			}
		}

		public void UpdateText()
		{
			this._name.Text = _fileSync.Name;
			this._lastSync.Text = _fileSync.LastSync;
		}
	}
}
