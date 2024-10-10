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

        if (_contactViewModel.Contacts == null || !_contactViewModel.Contacts.Any()) 
        {
            _contactViewModel.LoadContactsCommand.Execute(null);
        }


    }




    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}