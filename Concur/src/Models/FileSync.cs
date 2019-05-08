using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Concur
{
	public class FileSync
	{
		static int _count;
		static int _prevID;
		List<Folder> _folders = new List<Folder>();

		private int _signature;
		private int _syncTime;
		private string _name;

		// After a folder(s) has been added/removed
		private bool _updating;

		public int ID { get; private set; }
		// TODO last sync should get an int timestamp and convert it into a custom string
		public string LastSync { get; private set; } // make a time formatter...
		public string NextSync
		{
			get
			{
				// TODO
				// return the last sync plus the interval.
				return "Not implemented";
			}
		}
		public string Name { get { return _name; } set { _name = value; } }

		public FileSync(int id, string name, string[] folders, string lastSync = "", int syncTime = 600000)
		{
			InitSyncer(id, name, folders, lastSync, syncTime);
		}

		public FileSync(string name, string[] folders, string lastSync = "", int syncTime = 600000)
		{
			int id = _prevID + 1;
			InitSyncer(id, name, folders, lastSync, syncTime);
		}

		private void InitSyncer(int id, string name, string[] folders, string lastSync = "", int syncTime = 600000)
		{
			_count = System.Convert.ToInt32(id);
			ID = id;
			_prevID = id;

			Name = name;

			for (int i = 0; i < folders.Length; i++)
				_folders.Add(new Folder(folders[i]));

			if (lastSync == "")
				LastSync = "Never";
			else
				LastSync = lastSync;

			_updating = false;
			CalculateSignature();
		}

		private void CalculateSignature()
		{
			if (_updating == false)
			{
				long result = 0;
				foreach (Folder fold in _folders)
					for (int i = 0; i < fold.Path.Length; i++)
						result += System.Convert.ToInt32(fold.Path[i]);
				_signature = (int)(result % int.MaxValue);
			}
		}

		// return false for failure, return true for success
		private bool Sync(List<Folder> folders)
		{
			// TODO Check if the files are included?
			try
			{
				bool success = true;
				if (folders.Count < 2)
					return false;

				// Associated list of files that are the newest overall and will be synced to the other folders.
				List<List<File>> files = new List<List<File>>();

				// Could probably take off the last one since at the point all files should have been checked.
				for (int i = 0; i < folders.Count; i++)
				{
					if (!folders[i].CheckPathExists()) folders[i].CreateSubPath();
					files.Add(new List<File>());
					foreach (File sfile in folders[i].Files())
					{
						bool isNewest = true;
						for (int j = 0; j < folders.Count; j++)
						{
							if (i == j) continue;
							if (!folders[j].CheckPathExists()) folders[j].CreateSubPath();

							foreach (File dfile in folders[j].Files())
							{
								if (sfile.Name == dfile.Name)
								{
									isNewest = System.IO.File.GetLastWriteTime(sfile.FullName) > System.IO.File.GetLastWriteTime(dfile.FullName);
								}
							}
						}

						if (isNewest) files[i].Add(sfile);
					}
				}

				for (int i = 0; i < files.Count; i++)
				{
					foreach (File file in files[i])
					{
						for (int j = 0; j < folders.Count; j++)
						{
							if (i == j) continue;
							System.IO.File.Copy(file.FullName, folders[j].Path + "\\" + file.Name, true);
						}
					}
				}

				// Recursively sync each folder
				for (int i = 0; i < folders.Count; i++)
				{
					List<Folder> newFolders = new List<Folder>();
					foreach (Folder fold in folders[i].SubFolders())
					{
						for (int j = 0; j < folders.Count; j++)
						{
							if (i == j)
								newFolders.Add(new Folder(fold.Path));
							else
								newFolders.Add(new Folder(folders[j].Path + "\\" + fold.Name));
						}
					}
					success = Sync(newFolders);
				}

				return success;

			}
			catch (System.Exception ex)
			{
				bool b = true;
			}
			return false;
		}

		public bool Sync()
		{
			bool result = Sync(_folders);
			if (result) LastSync = System.DateTime.UtcNow.ToString();
			return result;
		}

		public Folder GetFolder(string name)
		{
			foreach (Folder folder in _folders)
				if (folder.Name == name)
					return folder;

			throw new System.Exception("Folder " + name + " not found");
		}

		public bool FolderExists(string name)
		{
			bool exists = false;
			foreach (Folder folder in _folders)
				exists |= folder.Name == name;

			return exists;
		}

		public List<Folder> Folders()
		{
			return _folders;
		}

		public void Folders(string[] folders)
		{
			_folders = new List<Folder>();
			AddFolders(folders);
		}

		public void AddFolders(string[] folders)
		{
			_updating = true;
			foreach (string str in folders)
				AddFolder(str);
			_updating = false;

			// After adding all the new folders in, recalculate the signature.
			CalculateSignature();
		}

		public void AddFolder(string folder)
		{
			if (!FolderExists(folder))
				_folders.Add(new Folder(folder));
			else
				throw new System.Exception("Folder already exists in this sync");

			// if this is a singular add folder then calcuate will happen
			CalculateSignature();
		}

		public void RemoveFolders(string[] foldernames)
		{
			_updating = true;
			foreach (string name in foldernames)
				RemoveFolder(name);
			_updating = false;

			// after removing all specified folders, recalculate the signature.
			CalculateSignature();
		}

		public void RemoveFolder(string name)
		{
			foreach (Folder folder in _folders)
				if (folder.Name == name)
					_folders.Remove(folder);

			// if this is a singular remove folder then calcuate will happen
			CalculateSignature();
		}

		public void UpdateFolder(string oldname, string newname, string newpath)
		{
			Folder folder = GetFolder(oldname);
			folder.UpdateFolder(newname, newpath);
		}

		public void UpdateFolder(string name, string newpath)
		{
			Folder folder = GetFolder(name);
			folder.UpdateFolder(newpath);
		}

		public int Signature()
		{
			return _signature;
		}
	}
}
