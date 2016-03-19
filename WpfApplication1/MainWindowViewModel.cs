using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private Person _person;
		private readonly RelayCommand _addEmptyElementCommand;
		private readonly RelayCommand _saveToFileCommand;

		public ObservableCollection<Person> PeopleCollection { get; set; }

		public Person SelectedItem { get; set; }

		public MainWindowViewModel()
		{
			_addEmptyElementCommand = new RelayCommand(AddEmptyElementExecute, CanAddEmptyElement);
			_saveToFileCommand = new RelayCommand(SaveToFileExecute, CanSaveToFile);
			PeopleCollection = new ObservableCollection<Person>();
			AddEmptyElementExecute();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public ICommand AddEmptyElementCommand => _addEmptyElementCommand;
		public ICommand SaveToFileCommand => _saveToFileCommand;

		private void AddEmptyElementExecute()
		{
			_person = new Person("EMPTY");
			AddPerson(_person);
			//MessageBox.Show("New EMPTY element added to the list!", "List Updated");
			OnPropertyChanged("SelectedItem");
		}

		private void AddPerson(Person person)
		{
			PeopleCollection.Add(person);
		}

		private bool CanAddEmptyElement()
		{
			return true;
		}

		private void SaveToFileExecute()
		{
			var persistenceModule = new ListPersistenceModule(PeopleCollection);
			persistenceModule.SaveToJson();
		}

		private bool CanSaveToFile()
		{
			return true;
		}

	}
}
