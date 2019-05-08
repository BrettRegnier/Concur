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
		public delegate void UpdateList(ButtonType type, SyncView sender);
		public event UpdateList UpdateView;

		// Enum for delegates
		public enum ButtonType
		{
			Edit = 0,
			Delete = 1
		}

		FileSync _fileSync;

		Label _lblName = new Label();
		Label _lblLastSync = new Label();
		Label _lblNextSync = new Label();
		Label _lblSave = new Label();
		ProgressBar _pbSave = new ProgressBar();
		Button _btnEdit = new Button();
		Button _btnRemove = new Button();

		// This might be a custom class. dunno yet...
		Panel _editPanel = new Panel();

		bool _isEditting = false;

		public FileSync FileSync { get { return _fileSync; } }

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

			this.Paint += (sender, e) =>
			{ 
				// Left, Top, Right, Bottom
				ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
					System.Drawing.Color.Transparent, 0, ButtonBorderStyle.Solid,
					System.Drawing.Color.Transparent, 0, ButtonBorderStyle.Solid,
					System.Drawing.Color.Transparent, 0, ButtonBorderStyle.Solid,
					System.Drawing.Color.LightGray, 1, ButtonBorderStyle.Solid);
			};
			this.Left = 0;
			this.Width = 999;
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
			int addHeight = 302;
			if (!_isEditting)
			{

				// a new panel should be added, which is the editting panel
				CreateEditPanel(_fileSync);

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
			UpdateView(ButtonType.Edit, this);
		}
		private void CreateEditPanel(FileSync sf, string location = "Example: C:\\MyFolder")
		{
			// magic numberrrrs
			this._editPanel.Size = new System.Drawing.Size(1001, 300);
			this._editPanel.Location = new System.Drawing.Point(0, 41);
			this._editPanel.BorderStyle = BorderStyle.FixedSingle;

			System.Drawing.Font font = new System.Drawing.Font("Microsoft Sans Serif", 14);
			System.Drawing.Color color = System.Drawing.Color.White;

			Label foldersLabel = new Label();
			foldersLabel.Text = "Folders";
			foldersLabel.Location = new System.Drawing.Point(5, 5);
			foldersLabel.ForeColor = color;
			foldersLabel.Font = font;

			Panel foldersPanel = new Panel();
			foldersPanel.Location = new System.Drawing.Point(foldersLabel.Left + 2, foldersLabel.Top + 26);
			foldersPanel.Size = new System.Drawing.Size(322, _editPanel.Height - 40);
			//container.BackColor = System.Drawing.Color.Blue;
			foldersPanel.BorderStyle = BorderStyle.FixedSingle;
			foldersPanel.AutoScroll = true;

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
				browse.UseVisualStyleBackColor = true;
				browse.Click += (sender, e) =>
				{
					using (var fbd = new FolderBrowserDialog())
					{
						DialogResult r = fbd.ShowDialog();
						if (r == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
						{
							txt.Text = fbd.SelectedPath;
							txt.ForeColor = System.Drawing.Color.Black;
							// TODO update the file sync with the new folder
							//sf = new FileSync() 
						}
					}
				};

				delete.Image = Properties.Resources.delete;
				delete.ForeColor = System.Drawing.Color.Red;
				delete.Width = 36;
				delete.UseVisualStyleBackColor = true;
				delete.Click += (sender, e) =>
				{
					bool find = false;
					if (foldersPanel.Controls.Count > 2)
					{

						for (int i = 0; i < foldersPanel.Controls.Count; i++)
						{

							if (find)
								foldersPanel.Controls[i].Top -= 52;
							if (panel == foldersPanel.Controls[i])
								find = true;
						}
						foldersPanel.Controls.Remove(panel);
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
				panel.Top = foldersPanel.Controls.Count * 52;

				foldersPanel.Controls.Add(panel);
			}

			// TODO add buttons for the tree structure. <--
			// TODO when a folder is changed reload the file structure
			// TODO when a file is checked I should check for files in the other ones to be checked??
			// TODO there needs to be a way of checking them "out" so they are considered when syncing.
			// TODO should be able to load in the files based on what I already have in a file sync


			Label treeLabel = new Label();
			treeLabel.Text = "Files Structure";
			treeLabel.Left = foldersPanel.Left + foldersPanel.Width + 10;
			treeLabel.Top = foldersLabel.Top;
			treeLabel.Font = font;
			treeLabel.ForeColor = color;

			// _tree view
			TreeView tree = new TreeView();
			tree.Left = treeLabel.Left + 5;
			tree.Top = foldersPanel.Top;
			tree.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
			tree.Width = foldersPanel.Width;
			tree.Height = foldersPanel.Height;

			_editPanel.Controls.Add(foldersLabel);
			_editPanel.Controls.Add(foldersPanel);

			_editPanel.Controls.Add(treeLabel);
			_editPanel.Controls.Add(tree);
		}

		private void Remove_Click(object sender, EventArgs e)
		{
			UpdateView(ButtonType.Delete, this);
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

		private void ListDirectory(TreeView tree, string path)
		{
			tree.Nodes.Clear();
			System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);

			tree.Nodes.Add(CreateDirectoryNode(root));
		}

		private TreeNode CreateDirectoryNode(System.IO.DirectoryInfo di)
		{
			var directoryNode = new TreeNode(di.Name);
			foreach (var directory in di.GetDirectories())
				directoryNode.Nodes.Add(CreateDirectoryNode(directory));

			foreach (var file in di.GetFiles())
				directoryNode.Nodes.Add(new TreeNode(file.Name));

			return directoryNode;
		}

		public void UpdateText()
		{
			this._lblName.Text = _fileSync.Name;
			this._lblLastSync.Text = _fileSync.LastSync;
		}
	}
}
