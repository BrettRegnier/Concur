using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Concur
{
	public class FileSyncer
	{
		static int _count;
		static int _prevID;
		List<Folder> _folders = new List<Folder>();

		private int _signature;
		private int _syncTime;

		public int ID { get; private set; }
		public string LastSync { get; private set; }

		public FileSyncer(int id, string[] folders, int syncTime = 600000, string lastSync = "")
		{
			InitSyncer(id, folders, syncTime, lastSync);
		}

		public FileSyncer(string[] folders, int syncTime = 600000, string lastSync = "")
		{
			int id = _prevID + 1;
			InitSyncer(id, folders, syncTime, lastSync);
		}

		private void InitSyncer(int id, string[] folders, int syncTime = 600000, string lastSync = "")
		{
			_count = System.Convert.ToInt32(id);
			ID = id;
			_prevID = id;

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
					foreach (FileInfo sf in folders[i].Files())
					{
						bool isNewest = false;
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
					foreach(Folder fold in folders[i].Folders())
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
			bool result = Sync();
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
