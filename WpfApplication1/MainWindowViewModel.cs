using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApplication1
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private Person _person;
		private string _selectedItem = "test";

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

		public ObservableCollection<Person> PeopleCollection { get; set; } = new ObservableCollection<Person>();

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

		public event PropertyChangedEventHandler PropertyChanged;


		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public MainWindowViewModel()
		{
			_person = new Person("Adam", "Kowalski", "Klonowa 1", "600-600-600");
			PeopleCollection.Add(_person);
		}

		public ICommand SubmitData
		{
			get
			{
				return new RelayCommand(SubmitDataExecute, CanSubmitDataExcute);
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

		private bool CanSubmitDataExcute()
		{
			return true;
		}

		private bool RequiredFieldsNotEmpty(Person _person)
		{
			return FirstName != null && LastName != null;
		}

	}
}
