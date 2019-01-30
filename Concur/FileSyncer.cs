﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Concur
{
	public class FileSyncer
	{
		static int count;
		static int lastID;
		Folder source;
		Folder destination;
		private int signature;
		public int ID { get; private set; }
		public string LastSync { get; private set; }

		public FileSyncer(int id, string src, string des, string lastSync = "")
		{
			InitSyncer(id, src, des, lastSync);
		}

		public FileSyncer(string src, string des, string lastSync = "")
		{
			int id = lastID + 1;
			InitSyncer(id, src, des, lastSync);
		}

		private void InitSyncer(int id, string src, string des, string lastSync = "")
		{
			count = System.Convert.ToInt32(id);
			ID = id;
			lastID = id;
			source = new Folder(src);
			destination = new Folder(des);

			if (lastSync == "")
				LastSync = "Never";
			else
				LastSync = lastSync;

			CalculateSignature();
		}

		private void CalculateSignature()
		{
			long result = 0;
			for (int i = 0; i < source.Path.Length; i++)
			{
				result += System.Convert.ToInt32(source.Path[i]);
			}
			for (int i = 0; i < destination.Path.Length; i++)
			{
				result += System.Convert.ToInt32(GetHashCode());
			}
			signature = (int)(result % int.MaxValue);
		}

		// return false for failure, return true for success
		private bool Sync(Folder src, Folder dest)
		{
			try
			{

				if (!src.CheckPathExists()) src.CreateSubPath();
				if (!dest.CheckPathExists()) dest.CreateSubPath();

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
								if (System.IO.File.GetLastWriteTime(sf.FullName) > System.IO.File.GetLastWriteTime(df.FullName))
								{

									// the source is newer than the destination
									srcToSync.Add(sf);
									fndFile = true;
									break;
								}
								else if (System.IO.File.GetLastWriteTime(sf.FullName) < System.IO.File.GetLastWriteTime(df.FullName))
								{
									// the destination is newer than the source
									destToSync.Add(df);
									fndFile = true;
									break;
								}
								// other wise don't bother trying to write overtop
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

						// Since the file doesn't exist in the source then the destination must be newer
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
			}
			catch (System.Exception ex)
			{
				bool b = true;
			}
			return false;
		}

		public bool Sync()
		{
			bool result = Sync(source, destination);
			if (result) LastSync = System.DateTime.UtcNow.ToString();
			return result;
		}

		public Folder Source()
		{
			return source;
		}

		public void Source(string pth)
		{
			source = new Folder(pth);
		}

		public void Source(Folder fold)
		{
			source = fold;
		}

		public Folder Destination()
		{
			return destination;
		}

		public void Destination(string pth)
		{
			destination = new Folder(pth);
		}

		public void Destination(Folder fold)
		{
			destination = fold;
		}

		public int Signature()
		{
			return signature;
		}
	}
}
