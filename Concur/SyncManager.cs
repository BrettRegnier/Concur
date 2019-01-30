using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Concur
{
	// This will need parallelization on the sync function
	// TODO add task queue
	[Serializable]
	class SyncManager
	{
		[XmlIgnore]
		private List<FileSyncer> fileSyncers;
		[XmlIgnore]
		private static string dir = "./FileSyncs.xml";
		[XmlIgnore]
		bool syncing = false;
		[XmlIgnore]
		bool continueTask = true;
		[XmlIgnore]
		bool waitingForConfirm = false;

		private XElement SyncSaves;

		public SyncManager()
		{
			fileSyncers = new List<FileSyncer>();
		}

		public static SyncManager LoadFileSyncs()
		{
			SyncManager sm = new SyncManager();
			if (System.IO.File.Exists(dir))
			{
				sm.SyncSaves = XElement.Load(dir);

				FileSyncer fs;
				foreach (XElement elm in sm.SyncSaves.Elements())
				{
					int id = Convert.ToInt32(elm.Element("ID").Value);
					string src = elm.Element("Source").Value;
					string dest = elm.Element("Destination").Value;
					string lastSync = elm.Element("LastSync").Value;
					fs = new FileSyncer(id, src, dest, lastSync);
					sm.RegisterSync(fs);
				}
			}

			return sm;
		}

		public void SaveFileSyncs()
		{
			SyncSaves = new XElement("Manager");
			
			foreach (FileSyncer fs in fileSyncers)
			{
				XElement elm = new XElement("FileSyncs");
				SyncSaves.Add(elm);

				elm.Add(new XElement("ID", fs.ID));
				elm.Add(new XElement("Source", fs.Source().Path));
				elm.Add(new XElement("Destination", fs.Destination().Path));
				elm.Add(new XElement("LastSync", fs.LastSync));

			}
			SyncSaves.Save(dir);
		}

		public void UnloadAllFileSync()
		{
			for (int i = fileSyncers.Count - 1; i >= 0; i--)
				fileSyncers[i] = null;

			fileSyncers = new List<FileSyncer>();
		}

		public void SyncAll()
		{
			if (syncing == false)
			{
				syncing = true;
				this.fileSyncers = LoadFileSyncs().fileSyncers;
				(new Task(new Action(ParallelSync))).Start();

			}
		}

		private void ParallelSync()
		{
			foreach (FileSyncer fileSyncer in fileSyncers)
			{
				fileSyncer.Sync();
			}

			waitingForConfirm = true;
			while (!continueTask)
			{ }
			SaveFileSyncs();
			UnloadAllFileSync();
			continueTask = false;
			syncing = false;
			waitingForConfirm = false;
		}

		public void UpdateSync(FileSyncer fs)
		{
			foreach (FileSyncer tmp in fileSyncers)
			{
				if (tmp.Signature() == fs.Signature())
				{
					tmp.Source(fs.Source());
					tmp.Destination(fs.Destination());
				}
			}
		}

		public void RegisterSync(FileSyncer fs)
		{
			// Check duplicates before adding
			if (CheckForDuplicate(fs))
			{
				fileSyncers.Add(fs);
				SaveFileSyncs();
			}
			else
			{
				throw new Exception("Error. Duplicate synchronization found");
			}

		}

		// True == no duplicate, false == duplicate
		private bool CheckForDuplicate(FileSyncer fs)
		{
			foreach (FileSyncer tmp in fileSyncers)
			{
				if (tmp.Signature() == fs.Signature())
					return false;
			}
			return true;
		}

		public void Delete(int id)
		{
			for (int i = 0; i < fileSyncers.Count; i++)
				if (fileSyncers[i].ID == id)
					fileSyncers.RemoveAt(i);

			SaveFileSyncs();
		}

		public List<FileSyncer> FileSyncers()
		{
			return fileSyncers;
		}

		public FileSyncer GetSyncer(int id)
		{
			for (int i = 0; i < fileSyncers.Count; i++)
				if (fileSyncers[i].ID == id)
					return fileSyncers[i];

			return null;
		}

		public void ContinueTask()
		{
			continueTask = true;
		}

		public bool WaitingForConfirm()
		{
			return waitingForConfirm;
		}
	}
}
