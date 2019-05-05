using System;
using System.Collections.Generic;
using System.Drawing;
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
		Label _lblProgress = new Label();
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
			Font font = new Font("Microsoft Sans Serif", 16);


			// _name
			this._lblName.AutoSize = true;
			this._lblName.Location = new System.Drawing.Point(6, 5);
			this._lblName.Name = "lblName";
			this._lblName.TabIndex = 0;
			this._lblName.Text = _fileSync.Name;
			this._lblName.Font = font;

			// _lastsync
			this._lblLastSync.AutoSize = true;
			this._lblLastSync.Location = new System.Drawing.Point(180, 5);
			this._lblLastSync.Name = "lblLastSync";
			this._lblLastSync.TabIndex = 0;
			this._lblLastSync.Text = _fileSync.LastSync;
			this._lblLastSync.Font = font;

			// Progress bar and label goes here.
			// _lastsync
			this._lblProgress.AutoSize = true;
			this._lblProgress.Location = new System.Drawing.Point(517, 5);
			this._lblProgress.Name = "lblProgress";
			this._lblProgress.TabIndex = 0;
			this._lblProgress.Text = "Progress";
			this._lblProgress.Font = font;

			//edit
			this._btnEdit.Location = new System.Drawing.Point(924, 9);
			this._btnEdit.Name = "_edit";
			this._btnEdit.Size = new System.Drawing.Size(29, 23);
			this._btnEdit.TabIndex = 0;
			this._btnEdit.Text = "";
			this._btnEdit.Image = Properties.Resources.edit;
			this._btnEdit.UseVisualStyleBackColor = true;
			this._btnEdit.Click += Edit_Click;

			//remove
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
			this.Width = 1001;
			this.Height = 41;

			this.Controls.Add(this._lblName);
			this.Controls.Add(this._lblLastSync);
			this.Controls.Add(this._btnEdit);
			this.Controls.Add(this._btnRemove);

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			int addHeight = 171;
			if (!_isEditting)
			{
				// a new panel should be added, which is the editting panel
				CreateFoldersPanel(_fileSync);
				_editPanel.Top = 38;

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
			Label foldersLabel = new Label();
			foldersLabel.Text = "Folders";
			foldersLabel.Left = 7;
			foldersLabel.Top = 2;

			_editPanel.Controls.Add(foldersLabel);

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
