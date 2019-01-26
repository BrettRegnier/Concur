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
		private static string dir = "./FileSyncs";

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
					string id = elm.Element("ID").Value;
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
				elm.Add(new XElement("LastSync"), fs.LastSync);

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
			foreach (FileSyncer fileSyncer in fileSyncers)
			{
				fileSyncer.Sync();
			}
		}

		public void RegisterSync(FileSyncer fs)
		{
			fileSyncers.Add(fs);
			SaveFileSyncs();
		}

		public void Delete(string id)
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
	}
}
