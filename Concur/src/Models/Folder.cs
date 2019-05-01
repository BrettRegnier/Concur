﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur
{
	public class Folder
	{
		string path;
		string name;
		DirectoryInfo info;
		List<FileInfo> files;
		List<Folder> folders;

		public Folder(string pth)
		{
			DirectoryInfo d = new DirectoryInfo(pth);

			path = pth;
			name = d.Name;
			info = d;

			files = new List<FileInfo>();
			folders = new List<Folder>();
		}

		public Folder(DirectoryInfo d)
		{
			path = d.FullName;
			name = d.Name;
			info = d;

			files = new List<FileInfo>();
			folders = new List<Folder>();
		}

		public string Name { get { return name; } }
		public string Path { get { return path; } }

		public List<FileInfo> Files()
		{
			if (files.Count == 0)
			{
				FileInfo[] fils = info.GetFiles();
				foreach (FileInfo f in fils)
					files.Add(f);
			}

			return files;
		}

		public List<Folder> Folders()
		{
			if (folders.Count == 0)
			{
				DirectoryInfo[] fold = info.GetDirectories();
				foreach (DirectoryInfo dir in fold)
					folders.Add(new Folder(dir));
			}

			return folders;
		}

		public bool CheckPathExists()
		{
			bool exists = false;

			// gets the root first.
			string[] subDir = path.Split('\\');
			string curPath = subDir[0];
			if (Directory.Exists(curPath))
			{
				exists = true;
				for (int i = 1; i < subDir.Length; i++)
				{
					curPath += "\\" + subDir[i];
					if (!Directory.Exists(curPath))
					{
						exists = false;
						break;
					}
				}
			}
			else
			{
				throw new Exception("The Drive " + curPath + "\\ does is not detected");
			}

			return exists;
		}

		public void CreateSubPath()
		{
			string[] subDir = path.Split('\\');
			string curPath = subDir[0];
			for (int i = 1; i < subDir.Length; i++)
			{
				curPath += "\\" + subDir[i];
				Directory.CreateDirectory(curPath);
			}
		}
	}
}