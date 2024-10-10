using MauiApp1.Models;
using ContactU = MauiApp1.Models.ContactU;
using System.Collections.ObjectModel;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ContactsPage : ContentPage
{
    private readonly ContactViewModel _contactViewModel;
	public ContactsPage(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        BindingContext = contactViewModel;
        _contactViewModel = contactViewModel;

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_contactViewModel.Contacts == null || !_contactViewModel.Contacts.Any()) // Загрузка, если список пустой
        {
            _contactViewModel.LoadContactsCommand.Execute(null);
        }


    }



		

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    //private void Delete_Clicked(object sender, EventArgs e)
    //{
    //    var menuItem = sender as MenuItem;
    //    var contact = menuItem.CommandParameter as Contact;
    //    ContactRepository.DeleteContact(contact.ContactId);

    //    LoadContacts();
    //}

    

    //private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    //{
    //    var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
    //    listContacts.ItemsSource = contacts;
    //}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}