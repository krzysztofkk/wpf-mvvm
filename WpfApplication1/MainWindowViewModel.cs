using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private Person _person;
		private string _selectedItem = "test";
		private readonly RelayCommand _submitDataCommand;

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

		public string SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				OnPropertyChanged("SelectedItem");
			}
		}

		public MainWindowViewModel()
		{
			PeopleCollection = new ObservableCollection<Person>();
			_person = new Person("Adam", "Kowalski", "Klonowa 1", "600-600-600");
			PeopleCollection.Add(_person);
			_submitDataCommand = new RelayCommand(SubmitDataExecute, CanSubmitData);
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

		public ICommand SubmitDataCommand
		{
			get
			{
				return _submitDataCommand;
			}
		}

		private void SubmitDataExecute()
		{
			if (RequiredFieldsNotEmpty(_person))
			{
				//MessageBox.Show(string.Format("Saved data.\nFirst Name: {0}\nLast Name: {1}!\nAdress: {2}\nPhone Number: {3}", _person.FirstName, _person.LastName, _person.Adress, _person.PhoneNumber), "Success!");
				SavePerson(_person);
			}
			else
			{
				MessageBox.Show("Please fill in all of the fields.", "Error!");
			}
		}

		private void SavePerson(Person _person)
		{
			PeopleCollection.Add(_person);
			OnPropertyChanged("SelectedItem");
		}

		private bool CanSubmitData()
		{
			return true;
		}

		private bool RequiredFieldsNotEmpty(Person _person)
		{
			return FirstName != null && LastName != null;
		}

	}
}
