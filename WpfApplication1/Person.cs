namespace WpfApplication1
{
	class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Adress { get; set; }
		public string PhoneNumber { get; set; }

		public Person(){}

		public Person(string firstName)
		{
			FirstName = firstName;
		}

		public Person(string firstName, string lastName, string adress, string phoneNumber)
		{
			FirstName = firstName;
			LastName = lastName;
			Adress = adress;
			PhoneNumber = phoneNumber;
		}
	}
}

