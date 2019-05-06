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
		public enum ButtonType
		{
			Edit = 0,
			Delete = 1
		}

		FileSync _fileSync;

		// This might be a custom class. dunno yet...
		Panel _editPanel = new Panel();

		Label _lblName = new Label();
		Label _lblLastSync = new Label();
		Label _lblNextSync = new Label();
		Label _lblSave = new Label();
		ProgressBar _pbSave = new ProgressBar();
		Button _btnEdit = new Button();
		Button _btnRemove = new Button();

		bool _isEditting = false;

		public SyncView(FileSync syncfile)
		{
			_fileSync = syncfile;
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			System.Drawing.Font font = new System.Drawing.Font("Microsoft Sans Serif", 14);
			System.Drawing.Color color = System.Drawing.Color.White;

			// _lblName
			this._lblName.AutoSize = true;
			this._lblName.Location = new System.Drawing.Point(6, 6);
			this._lblName.Name = "lblName";
			this._lblName.TabIndex = 0;
			this._lblName.Text = _fileSync.Name;
			this._lblName.Font = font;
			this._lblName.ForeColor = color;

			// _lblLastSync
			this._lblLastSync.AutoSize = true;
			this._lblLastSync.Location = new System.Drawing.Point(131, 6);
			this._lblLastSync.Name = "lblLastSync";
			this._lblLastSync.TabIndex = 0;
			this._lblLastSync.Text = _fileSync.LastSync;
			this._lblLastSync.Font = font;
			this._lblLastSync.ForeColor = color;

			// _lblNextSync
			this._lblNextSync.AutoSize = true;
			this._lblNextSync.Location = new System.Drawing.Point(377, 6);
			this._lblNextSync.Name = "lblNextSync";
			this._lblNextSync.TabIndex = 0;
			this._lblNextSync.Text = _fileSync.NextSync;
			this._lblNextSync.Font = font;
			this._lblNextSync.ForeColor = color;

			// _lblSave
			this._lblSave.AutoSize = true;
			this._lblSave.Location = new System.Drawing.Point(642, 6);
			this._lblSave.Name = "lblProgress";
			this._lblSave.TabIndex = 0;
			this._lblSave.Text = "Sync Progress";
			this._lblSave.Font = font;
			this._lblSave.ForeColor = color;

			// _pbSave
			this._pbSave.Location = new System.Drawing.Point(780, 9);
			this._pbSave.Name = "pbSave";
			this._pbSave.Size = new System.Drawing.Size(138, 23);
			this._pbSave.TabIndex = 4;

			// _btnEdit
			this._btnEdit.Location = new System.Drawing.Point(924, 9);
			this._btnEdit.Name = "_edit";
			this._btnEdit.Size = new System.Drawing.Size(29, 23);
			this._btnEdit.TabIndex = 0;
			this._btnEdit.Text = "";
			this._btnEdit.Image = Properties.Resources.edit;
			this._btnEdit.UseVisualStyleBackColor = true;
			this._btnEdit.Click += Edit_Click;

			// _btnRemove
			this._btnRemove.Location = new System.Drawing.Point(959, 9);
			this._btnRemove.Name = "_remove";
			this._btnRemove.Size = new System.Drawing.Size(29, 23);
			this._btnRemove.TabIndex = 0;
			this._btnRemove.Text = "";
			this._btnRemove.Image = Properties.Resources.delete;
			this._btnRemove.UseVisualStyleBackColor = true;
			this._btnRemove.Click += Remove_Click;

			this.BorderStyle = BorderStyle.FixedSingle;
			this.Left = -1;
			this.Width = 1002;
			this.Height = 41;

			this.Controls.Add(this._lblName);
			this.Controls.Add(this._lblLastSync);
			this.Controls.Add(this._lblNextSync);
			this.Controls.Add(this._lblSave);
			this.Controls.Add(this._pbSave);
			this.Controls.Add(this._btnEdit);
			this.Controls.Add(this._btnRemove);

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			int addHeight = 202;
			if (!_isEditting)
			{
				this._editPanel.Size = new System.Drawing.Size(1001, 200);
				this._editPanel.Location = new System.Drawing.Point(0, 43);
				this._editPanel.BorderStyle = BorderStyle.FixedSingle;

				// a new panel should be added, which is the editting panel
				CreateFoldersPanel(_fileSync);

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
		private void CreateFoldersPanel(FileSync sf, string location = "Example: C:\\MyFolder")
		{
			System.Drawing.Font font = new System.Drawing.Font("Microsoft Sans Serif", 14);
			System.Drawing.Color color = System.Drawing.Color.White;

			Label foldersLabel = new Label();
			foldersLabel.Text = "Folders";
			foldersLabel.Location = new System.Drawing.Point(3, 0);
			foldersLabel.ForeColor = color;
			foldersLabel.Font = font;

			_editPanel.Controls.Add(foldersLabel);

			Panel container = new Panel();
			container.Location = new System.Drawing.Point(7, 26);
			container.Size = new System.Drawing.Size(322, 170);
			container.BackColor = System.Drawing.Color.Blue;
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


			_editPanel.Controls.Add(foldersLabel);
			_editPanel.Controls.Add(container);
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
			this._lblName.Text = _fileSync.Name;
			this._lblLastSync.Text = _fileSync.LastSync;
		}
	}
}
