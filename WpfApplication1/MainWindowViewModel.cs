using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private Person _person;
		private readonly RelayCommand _addEmptyElementCommand;

		public string FirstName
		{
			get { return _person.FirstName; }
			set
			{
				_person.FirstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		public string LastName
		{
			get { return _person.LastName; }
			set
			{
				_person.LastName = value;
				OnPropertyChanged("LastName");
			}
		}

		public string Adress
		{
			get { return _person.Adress; }
			set
			{
				_person.Adress = value;
				OnPropertyChanged("Adress");
			}
		}

		public string PhoneNumber
		{
			get { return _person.PhoneNumber; }
			set
			{
				_person.PhoneNumber = value;
				OnPropertyChanged("PhoneNumber");
			}
		}

		public ObservableCollection<Person> PeopleCollection { get; set; }

		public SelectedItem SelectedItem { get; set; }

		public MainWindowViewModel()
		{
			_addEmptyElementCommand = new RelayCommand(AddEmptyElementExecute, CanAddEmptyElement);
			PeopleCollection = new ObservableCollection<Person>();
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

		private void AddEmptyElementExecute()
		{
			_person = new Person("EMPTY");
			AddPerson(_person);
			//MessageBox.Show("New EMPTY element added to the list!", "List Updated");
		}

		private void AddPerson(Person person)
		{
			PeopleCollection.Add(person);
		}

		private bool CanAddEmptyElement()
		{
			return true;
		}

	}
}
