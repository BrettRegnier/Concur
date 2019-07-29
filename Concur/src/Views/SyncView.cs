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
		int minHeight = 41;
		int maxHeight = 343;
		int expectedHeight = 0;

		System.Threading.ThreadStart accordionStart;
		System.Threading.Thread editThread;

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

			_editPanel.Visible = false;
			this.Controls.Add(_editPanel);
			Panel.CheckForIllegalCrossThreadCalls = false;

			accordionStart = new System.Threading.ThreadStart(Accordion);
			editThread = new System.Threading.Thread(accordionStart);
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			if (!_isEditting)
			{

				// a new panel should be added, which is the editting panel
				CreateEditPanel(_fileSync);
				_editPanel.Visible = true;

				_isEditting = true;
				expectedHeight = maxHeight;
			}
			else
			{
				_isEditting = false;
				expectedHeight = minHeight;
			}

			// I think a new thread has to be made after the thread is terminated...?
			if (!editThread.IsAlive)
			{
				editThread.Start();
				editThread = new System.Threading.Thread(accordionStart);
			}
			
		}
		private void CreateEditPanel(FileSync fs, string location = "Example: C:\\MyFolder")
		{
			// TODO split this into its own class.
			// magic numberrrrs
			this._editPanel.Size = new System.Drawing.Size(1000, 300);
			this._editPanel.Location = new System.Drawing.Point(0, 41);
			this._editPanel.BorderStyle = BorderStyle.FixedSingle;

			System.Drawing.Font font = new System.Drawing.Font("Miriam CLM", 14);
			System.Drawing.Color color = System.Drawing.Color.White;

			Label foldersLabel = new Label();
			foldersLabel.Text = "Folders";
			foldersLabel.Location = new System.Drawing.Point(5, 5);
			foldersLabel.ForeColor = color;
			foldersLabel.Font = font;

			Panel foldersPanel = new Panel();
			foldersPanel.Location = new System.Drawing.Point(foldersLabel.Left + 2, foldersLabel.Top + 26);
			foldersPanel.Size = new System.Drawing.Size(484, _editPanel.Height - 40);
			foldersPanel.BorderStyle = BorderStyle.FixedSingle;
			foldersPanel.AutoScroll = true;


			Label treeLabel = new Label();
			TreeView tree = new TreeView();

			foreach (Folder folder in fs.Folders())
			{
				string prevName = folder.Name;
				string prevPath = folder.Path;
				bool nameChanged = false;
				bool pathChanged = false;

				Panel panel = new Panel();
				TextBox name = new TextBox();
				TextBox path = new TextBox();
				Button browse = new Button();
				Button accept = new Button();
				Button delete = new Button();

				name.Text = folder.Name;
				name.Width = 200;
				name.Height = 13;
				name.BorderStyle = BorderStyle.None;
				name.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
				name.ForeColor = color;
				name.MouseEnter += (sender, e) =>
				{
					System.Drawing.Rectangle border = new System.Drawing.Rectangle();
					border.X = name.Left - 1;
					border.Y = name.Top - 1;
					border.Width = name.Width + 2;
					border.Height = name.Height + 2;

					System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
					System.Drawing.Graphics graphics = panel.CreateGraphics();
					graphics.DrawRectangle(pen, border);
					pen.Dispose();
					graphics.Dispose();
				};
				name.MouseLeave += (sender, e) => { panel.Invalidate(); };
				name.TextChanged += (sender, e) =>
				{
					nameChanged = false;
					if (name.Text != prevName) nameChanged = true;
					EnableAccept();
				};

				path.Text = folder.Path;
				path.GotFocus += HidePlaceholderText;
				path.LostFocus += ShowPlaceholderText;
				path.Width = 320;
				path.Height = 36;
				path.Font = new System.Drawing.Font("Miriam CLM", 10);
				path.TextChanged += (sender, e) =>
				{
					pathChanged = false;
					if (path.Text != "Example: C:\\MyFolder" && path.Text != prevPath)
						pathChanged = true;
					EnableAccept();
				};

				browse.Text = "...";
				browse.ForeColor = System.Drawing.Color.White;
				browse.Width = 36;
				browse.UseVisualStyleBackColor = true;
				browse.FlatStyle = FlatStyle.Flat;
				browse.FlatAppearance.BorderSize = 1;
				browse.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
				browse.Click += (sender, e) =>
				{
					using (var fbd = new FolderBrowserDialog())
					{
						DialogResult r = fbd.ShowDialog();
						if (r == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
						{
							path.Text = fbd.SelectedPath;
							path.ForeColor = System.Drawing.Color.Black;
						}
					}
				};

				void EnableAccept()
				{
					if (nameChanged || pathChanged) accept.Enabled = true;
					else accept.Enabled = false;
				}

				accept.Image = Properties.Resources.accept;
				accept.Width = 36;
				accept.UseVisualStyleBackColor = true;
				accept.FlatStyle = FlatStyle.Flat;
				accept.FlatAppearance.BorderSize = 1;
				accept.Enabled = false;
				accept.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
				accept.Click += (sender, e) =>
				{
					DialogResult confirm = MessageBox.Show("Are you sure you want to make these changes?", "Confirm Change", MessageBoxButtons.YesNoCancel);
					if (confirm == DialogResult.Yes)
					{
						if (nameChanged)
						{
							prevName = name.Text;
							folder.UpdateName(name.Text);
							nameChanged = false;
						}
						if (pathChanged)
						{
							prevPath = path.Text;
							folder.UpdateFolder(path.Text);
							pathChanged = false;

							//Update the tree structure
							ListDirectory(tree, fs);
						}

						accept.Enabled = false;
					}
					else if (confirm == DialogResult.No)
					{
						name.Text = prevName;
						path.Text = prevPath;
					}
				};

				delete.Image = Properties.Resources.delete;
				delete.Width = 36;
				delete.UseVisualStyleBackColor = true;
				delete.FlatStyle = FlatStyle.Flat;
				delete.FlatAppearance.BorderSize = 1;
				delete.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
				delete.Click += (sender, e) =>
				{
					DialogResult confirm = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Deletion", MessageBoxButtons.YesNo);
					if (confirm == DialogResult.Yes)
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
							path.Text = "";
							ShowPlaceholderText(path, null);
						}

						fs.RemoveFolder(name.Text);
						ListDirectory(tree, fs);
					}
				};


				name.Left = 3;
				name.Top = 2;

				path.Left = 10;
				path.Top = 20;

				browse.Left = path.Right + 10;
				browse.Top = path.Top;

				accept.Left = browse.Right + 5;
				accept.Top = browse.Top;

				delete.Left = accept.Right + 5;
				delete.Top = accept.Top;

				panel.Controls.Add(name);
				panel.Controls.Add(path);
				panel.Controls.Add(browse);
				panel.Controls.Add(accept);
				panel.Controls.Add(delete);

				panel.Width = 464;
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

			treeLabel.Text = "Files Structure";
			treeLabel.Left = foldersPanel.Left + foldersPanel.Width + 10;
			treeLabel.Top = foldersLabel.Top;
			treeLabel.Font = font;
			treeLabel.ForeColor = color;

			// _tree view
			tree.Left = treeLabel.Left + 5;
			tree.Top = foldersPanel.Top;
			tree.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
			tree.Width = foldersPanel.Width;
			tree.Height = foldersPanel.Height;
			tree.CheckBoxes = true;
			tree.Font = font;
			tree.ForeColor = color;

			bool isCascading = false;
			tree.AfterCheck += (sender, e) =>
			{
				if (!isCascading)
				{
					isCascading = true;
					Cascade(e.Node);
					CascadeSimilar(e.Node);
					isCascading = false;
				}
			};

			void Cascade(TreeNode node)
			{
				foreach (TreeNode child in node.Nodes)
				{
					child.Checked = node.Checked;
					Cascade(child);
					CascadeSimilar(child);
				}
			}

			void CascadeSimilar(TreeNode target)
			{
				// Depth first search
				Stack<TreeNode> stack = new Stack<TreeNode>();

				TreeNode node = new TreeNode();
				for (int i = 0; i < tree.Nodes.Count; i++)
					stack.Push(tree.Nodes[i]);
				while (stack.Count > 0)
				{
					node = stack.Pop();
					if (node.Text == target.Text)
						node.Checked = target.Checked;

					for (int i = 0; i < node.Nodes.Count; i++)
					{
						if (node.Nodes[i].Text == target.Text)
							node.Nodes[i].Checked = target.Checked;

						stack.Push(node.Nodes[i]);
					}
				}
			}

			ListDirectory(tree, fs);

			_editPanel.Controls.Add(foldersLabel);
			_editPanel.Controls.Add(foldersPanel);

			_editPanel.Controls.Add(treeLabel);
			_editPanel.Controls.Add(tree);
		}

		private void Accordion()
		{
			int updateVal = 20;
			bool updatingUI = true;

			long tickCount = 0;
			while (updatingUI)
			{
				if (Environment.TickCount >= tickCount + 15)
				{
					tickCount = Environment.TickCount;

					if (_isEditting)
					{
						if (this.Height + updateVal <= expectedHeight)
							this.Height += updateVal;
						else
						{
							this.Height = expectedHeight;
							updatingUI = false;
						}
					}
					else
					{
						if (this.Height - updateVal >= expectedHeight)
							this.Height -= updateVal;
						else
						{
							this.Height = expectedHeight;
							_editPanel = new Panel();
							updatingUI = false;
						}
					}
				}
				UpdateView(ButtonType.Edit, this);
			}
			this.Invalidate();
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

		private void ListDirectory(TreeView tree, FileSync fs)
		{
			tree.Nodes.Clear();

			foreach (Folder folder in fs.Folders())
			{
				tree.Nodes.Add(CreateDirectoryNode(folder.Info));
			}
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
