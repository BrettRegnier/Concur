﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Concur
{
	//TODO name should be something that is chosen by the user
	public class Folder
	{
		string _path;
		string _name = "Not implemented";
		DirectoryInfo _directoryInfo;
		List<File> _files;
		List<Folder> _subfolders;

		public Folder(string pth)
		{
			DirectoryInfo d = new DirectoryInfo(pth);
			Initialize(d);
		}

		public Folder(DirectoryInfo d)
		{
			Initialize(d);
		}

		private void Initialize(DirectoryInfo d)
		{
			_path = d.FullName;
			_directoryInfo = d;

			_files = new List<File>();
			_subfolders = new List<Folder>();
		}

		public string Name { get { return _name; } }
		public string Path { get { return _path; } }
		public DirectoryInfo Info { get { return _directoryInfo; } }

		public List<File> Files()
		{
			if (_files.Count == 0)
			{
				FileInfo[] fils = _directoryInfo.GetFiles();
				foreach (FileInfo f in fils)
					_files.Add(new File(f));
			}

			return _files;
		}

		public List<Folder> SubFolders()
		{
			if (_subfolders.Count == 0)
			{
				DirectoryInfo[] fold = _directoryInfo.GetDirectories();
				foreach (DirectoryInfo dir in fold)
					_subfolders.Add(new Folder(dir));
			}

			return _subfolders;
		}

		public bool CheckPathExists()
		{
			bool exists = false;

			// gets the root first.
			string[] subDir = _path.Split('\\');
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
			string[] subDir = _path.Split('\\');
			string curPath = subDir[0];
			for (int i = 1; i < subDir.Length; i++)
			{
				curPath += "\\" + subDir[i];
				Directory.CreateDirectory(curPath);
			}
		}

		public void UpdateFolder(string name, string path)
		{
			_name = name;
			UpdateFolder(path);
		}

		public void UpdateFolder(string path)
		{
			DirectoryInfo d = new DirectoryInfo(path);
			Initialize(d);
		}

		public void UpdateName(string name)
		{
			_name = name;
		}

		public XElement ToXML()
		{
			// TODO
			throw new NotImplementedException();
		}
	}
}
