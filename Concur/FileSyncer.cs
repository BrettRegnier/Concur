using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Concur
{
	public class FileSyncer
	{
		static int count;
		Folder source;
		Folder destination;
		public string ID { get; private set; }
		public string LastSync { get; private set; }

		public FileSyncer()
		{
			count++;
			ID = (00000 + count).ToString();
			source = null;
			destination = null;
			LastSync = "Never";
		}

		public FileSyncer(string id, string src, string des, string lastSync = "")
		{
			ID = id;
			source = new Folder(src);
			destination = new Folder(des);

			if (lastSync == "")
				LastSync = "Never";
			else
				LastSync = lastSync;
		}

		// return false for failure, return true for success
		private bool Sync(Folder src, Folder dest)
		{
			if (!Directory.Exists(dest.Path))
			{
				Directory.CreateDirectory(dest.Path);
			}
			// TODO check which file is newer and then replace between the two based on file age
			if (src != null && dest != null)
			{
				List<FileInfo> srcToSync = new List<FileInfo>();
				List<FileInfo> destToSync = new List<FileInfo>();
				// Check all source files against destination files
				foreach (FileInfo sf in src.Files())
				{
					bool fndFile = false;
					foreach (FileInfo df in dest.Files())
					{
						if (sf.Name == df.Name)
						{
							if (System.IO.File.GetLastWriteTime(sf.FullName) >= System.IO.File.GetLastWriteTime(df.FullName))
							{

								// the source is newer than the destination
								srcToSync.Add(sf);
								fndFile = true;
								break;
							}
							else
							{
								// the destination is new than the source
								destToSync.Add(df);
								fndFile = true;
								break;
							}
						}
					}

					if (fndFile == false)
					{
						srcToSync.Add(sf);
					}
				}

				// Check if all source files exist in destination
				foreach (FileInfo df in dest.Files())
				{
					bool fndFile = false;
					foreach (FileInfo sf in src.Files())
					{
						if (sf.Name == df.Name)
						{
							fndFile = true;
							break;
						}
					}

					if (fndFile == false)
					{
						destToSync.Add(df);
					}
				}

				foreach (FileInfo sf in srcToSync)
				{
					System.IO.File.Copy(sf.FullName, dest.Path + "\\" + sf.Name, true);
				}
				foreach (FileInfo df in destToSync)
				{
					System.IO.File.Copy(df.FullName, src.Path + "\\" + df.Name, true);
				}

				bool success = true;
				foreach (Folder fold in src.Folders())
				{
					success = Sync(new Folder(fold.Path), new Folder(dest.Path + "\\" + fold.Name));
				}
				foreach (Folder fold in dest.Folders())
				{
					success = Sync(new Folder(fold.Path), new Folder(src.Path + "\\" + fold.Name));
				}

				return success;
			}
			return false;
		}

		public bool Sync()
		{
			return Sync(source, destination);
		}

		public Folder Source()
		{
			return source;
		}

		public void Source(string pth)
		{
			source = new Folder(pth);
		}

		public Folder Destination()
		{
			return destination;
		}

		public void Destination(string pth)
		{
			destination = new Folder(pth);
		}
	}
}
