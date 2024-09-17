namespace MauiApp1.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		List<Contact> contacts = new List<Contact>()
		{
			new Contact {Name="Doctor", Email="Doctor@gmail.com"},
			new Contact {Name="Sos", Email="Sos@gmail.com"},
			new Contact {Name="Nurse", Email="Nurse@gmail.com"},
		};

		//List<string> contacts = new List<string>() {
		//	"Doctor",
		//	"Sos",
		//	"Nurse",
		//};
		listContacts.ItemsSource = contacts;
	}

	public class Contact
	{
		public string Name { get; set; }
		public string Email { get; set; }
	}
		private void btnEditContact_Clicked(object sender, EventArgs e)
		{

		}

		private void btnAddContact_Clicked(object sender, EventArgs e)
		{

		}


		private void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//logic

			DisplayAlert("Ok", "Ok", "Ok");

			
		}
	

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}