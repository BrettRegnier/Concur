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
	class SyncManager
	{
		List<SyncFile> _syncers;
		static string _dir = "./syncs.xml";
		bool _syncing = false;
		bool _continueTask = true;
		bool _waitingForConfirm = false;

		// TODO use this timer instead since this is the manager after all.
		Timer _timer = new Timer();

		XElement _saves;

		public SyncManager()
		{
			_syncers = new List<SyncFile>();
		}

		public static SyncManager LoadFileSyncs()
		{
			SyncManager sm = new SyncManager();
			if (System.IO.File.Exists(_dir))
			{
				sm._saves = XElement.Load(_dir);

				SyncFile fs;
				foreach (XElement elm in sm._saves.Elements())
				{
					int id = Convert.ToInt32(elm.Element("ID").Value);
					string lastSync = elm.Element("LastSync").Value;
					//fs = new FileSyncer(id, src, dest, lastSync);
					//sm.RegisterSync(fs);
				}
			}

			return sm;
		}

		public void SaveFileSyncs()
		{
			_saves = new XElement("Manager");

			foreach (SyncFile fs in _syncers)
			{
				XElement xmlfs = new XElement("FileSyncs");
				_saves.Add(xmlfs);

				xmlfs.Add(new XElement("ID", fs.ID));

				XElement xmlFolders = new XElement("Folders");
				int i = 0;
				foreach (Folder folder in fs.Folders())
					xmlFolders.Add(new XElement("f" + i.ToString(), folder.Path));
				xmlfs.Add(xmlFolders);

				xmlfs.Add(new XElement("LastSync", fs.LastSync));

			}
			_saves.Save(_dir);
		}

		public void UnloadAllFileSync()
		{
			for (int i = _syncers.Count - 1; i >= 0; i--)
				_syncers[i] = null;

			_syncers = new List<SyncFile>();
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
			foreach (SyncFile fileSyncer in _syncers)
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

		public void RegisterSync(SyncFile fs)
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
		private bool CheckForDuplicate(SyncFile fs)
		{
			foreach (SyncFile tmp in _syncers)
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

		public List<SyncFile> Syncers()
		{
			return _syncers;
		}

		public SyncFile GetSyncer(int id)
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
