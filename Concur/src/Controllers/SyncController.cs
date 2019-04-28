using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Concur
{
	// This will need parallelization on the sync function
	// TODO add task queue
	// TODO refactor code to be cleaner and change global variable names.
	[Serializable]
	class SyncController
	{
		List<FileSync> _syncers;
		static string _dir = "./syncs.xml";
		bool _syncing = false;
		bool _continueTask = true;
		bool _waitingForConfirm = false;

		// TODO use this timer instead since this is the manager after all.
		Timer _timer = new Timer();

		public SyncController()
		{
			_syncers = new List<FileSync>();
		}

		// TODO add sync time into the load and save functions
		public static SyncController LoadFileSyncs()
		{
			// TODO error checking for a messed up xml file
			// TODO if ignore and move on.
			SyncController sm = new SyncController();
			if (System.IO.File.Exists(_dir))
			{
				XElement saves = XElement.Load(_dir);

				FileSync sf;
				foreach (XElement elm in saves.Elements())
				{
					int id = Convert.ToInt32(elm.Element("ID").Value);
					string name = elm.Element("Name").Value;
					string lastSync = elm.Element("LastSync").Value;

					List<string> folders = new List<string>();
					foreach (XElement folder in elm.Element("Folders").Elements())
					{
						folders.Add(folder.Value);
					}

					sf = new FileSync(id, name, folders.ToArray(), lastSync);
					sm.RegisterSync(sf);
				}
			}

			return sm;
		}

		public void SaveFileSyncs()
		{
			XElement saves = new XElement("Manager");

			foreach (FileSync fs in _syncers)
			{
				XElement xmlfs = new XElement("FileSyncs");
				saves.Add(xmlfs);

				xmlfs.Add(new XElement("ID", fs.ID));
				xmlfs.Add(new XElement("Name", fs.Name));
				xmlfs.Add(new XElement("LastSync", fs.LastSync));

				XElement xmlFolders = new XElement("Folders");
				int i = 0;
				foreach (Folder folder in fs.Folders())
					xmlFolders.Add(new XElement("f" + i.ToString(), folder.Path));
				xmlfs.Add(xmlFolders);
			}
			saves.Save(_dir);
		}

		public void UnloadAllFileSync()
		{
			for (int i = _syncers.Count - 1; i >= 0; i--)
				_syncers[i] = null;

			_syncers = new List<FileSync>();
		}

		public void SyncAll()
		{
			if (_syncing == false)
			{
				_syncing = true;
				this._syncers = LoadFileSyncs()._syncers;
				(new Task(new Action(ParallelSync))).Start();

			}
		}

		private void ParallelSync()
		{
			foreach (FileSync fileSyncer in _syncers)
			{
				fileSyncer.Sync();
			}

			_waitingForConfirm = true;
			while (!_continueTask)
			{ }
			SaveFileSyncs();
			UnloadAllFileSync();
			_continueTask = false;
			_syncing = false;
			_waitingForConfirm = false;
		}

		public void RegisterSync(FileSync fs)
		{
			// Check duplicates before adding
			if (CheckForDuplicate(fs))
			{
				_syncers.Add(fs);
				SaveFileSyncs();
			}
			else
			{
				throw new Exception("Error. Duplicate synchronization found");
			}

		}

		// True == no duplicate, false == duplicate
		private bool CheckForDuplicate(FileSync fs)
		{
			foreach (FileSync tmp in _syncers)
			{
				if (tmp.Signature() == fs.Signature())
					return false;
			}
			return true;
		}

		public void Delete(int id)
		{
			for (int i = 0; i < _syncers.Count; i++)
				if (_syncers[i].ID == id)
					_syncers.RemoveAt(i);

			SaveFileSyncs();
		}

		public List<FileSync> Syncers()
		{
			return _syncers;
		}

		public FileSync GetSyncer(int id)
		{
			for (int i = 0; i < _syncers.Count; i++)
				if (_syncers[i].ID == id)
					return _syncers[i];

			return null;
		}

		public void ContinueTask()
		{
			_continueTask = true;
		}

		public bool WaitingForConfirm()
		{
			return _waitingForConfirm;
		}
	}
}
