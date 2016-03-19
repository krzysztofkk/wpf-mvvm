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
		private readonly RelayCommand _readFileCommand;
		private ListPersistenceModule _listPersistenceModule;

		public ObservableCollection<Person> PeopleCollection { get; set; }

		public SelectedItem SelectedItem { get; set; }

		public MainWindowViewModel()
		{
			_addEmptyElementCommand = new RelayCommand(AddEmptyElementExecute, CanAddEmptyElement);
			_saveToFileCommand = new RelayCommand(SaveToFileExecute, CanSaveToFile);
			_readFileCommand = new RelayCommand(ReadFileExecute, CanReadFile);
			PeopleCollection = new ObservableCollection<Person>();
			_listPersistenceModule = new ListPersistenceModule(PeopleCollection);
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
		public ICommand ReadFileCommand => _readFileCommand;

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
			_listPersistenceModule.SaveToJson();
		}

		private bool CanSaveToFile()
		{
			return true;
		}

		private void ReadFileExecute()
		{
			PeopleCollection = _listPersistenceModule.ReadFile();
			OnPropertyChanged("SelectedItem");
		}

		private bool CanReadFile()
		{
			return true;
		}

	}
}
