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

		public int ID { get; private set; }
		public string LastSync { get; private set; }
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

			CalculateSignature();
		}

		private void CalculateSignature()
		{
			long result = 0;
			foreach (Folder fold in _folders)
				for (int i = 0; i < fold.Path.Length; i++)
					result += System.Convert.ToInt32(fold.Path[i]);
			_signature = (int)(result % int.MaxValue);
		}

		// return false for failure, return true for success
		private bool Sync(List<Folder> folders)
		{
			try
			{
				bool success = true;
				if (folders.Count < 2)
					return false;

				// Associated list of files that are the newest overall and will be synced to the other folders.
				List<List<FileInfo>> files = new List<List<FileInfo>>();

				// Could probably take off the last one since at the point all files should have been checked.
				for (int i = 0; i < folders.Count; i++)
				{
					if (!folders[i].CheckPathExists()) folders[i].CreateSubPath();
					files.Add(new List<FileInfo>());
					foreach (FileInfo sf in folders[i].Files())
					{
						bool isNewest = true;
						for (int j = 0; j < folders.Count; j++)
						{
							if (i == j) continue;
							if (!folders[j].CheckPathExists()) folders[j].CreateSubPath();

							foreach (FileInfo df in folders[j].Files())
							{
								if (sf.Name == df.Name)
								{
									isNewest = System.IO.File.GetLastWriteTime(sf.FullName) > System.IO.File.GetLastWriteTime(df.FullName);
								}
							}
						}

						if (isNewest) files[i].Add(sf);
					}
				}

				for (int i = 0; i < files.Count; i++)
				{
					foreach (FileInfo file in files[i])
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
					foreach (Folder fold in folders[i].Folders())
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

		public List<Folder> Folders()
		{
			return _folders;
		}

		public void Folders(string[] folders)
		{
			foreach (string str in folders)
			{
				_folders.Add(new Folder(str));
			}
		}

		public int Signature()
		{
			return _signature;
		}
	}
}
