using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace WpfApplication1
{
	class ListPersistenceModule
	{
		private readonly ObservableCollection<Person> _peopleCollection;
		private string _peopleCollectionSerialized;
		private readonly string _path = @"T:\file2.json";

		public ListPersistenceModule(ObservableCollection<Person> peopleCollection)
		{
			_peopleCollection = peopleCollection;
		}

		public ListPersistenceModule(ObservableCollection<Person> peopleCollection, string path)
		{
			_peopleCollection = peopleCollection;
			_path = path;
		}

		public void CreateFile()
		{
			System.IO.File.Create(_path);
		}

		public void Serialize()
		{
			_peopleCollectionSerialized = JsonConvert.SerializeObject(_peopleCollection.ToArray(), Formatting.Indented);
		}

		public void SaveToFile()
		{
			System.IO.File.WriteAllText(_path, _peopleCollectionSerialized);
			MessageBox.Show(string.Format("Succesfully saved list to text file {0}", _path), "List saved!");
		}

		public void SaveToJson()
		{
			string json = JsonConvert.SerializeObject(_peopleCollection, Formatting.Indented);
			File.WriteAllText(_path, json);
			MessageBox.Show(string.Format("Succesfully saved list to JSON file {0}", _path), "List saved!");
		}


	}
}