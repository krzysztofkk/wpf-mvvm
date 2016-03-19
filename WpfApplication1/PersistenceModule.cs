using System.Collections.ObjectModel;
using System.Linq;
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
		}


	}
}