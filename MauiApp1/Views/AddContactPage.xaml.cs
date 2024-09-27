using MauiApp1.Models;

namespace MauiApp1.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void contactCntrl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactCntrl.Name,
            Address = contactCntrl.Address,
            Email = contactCntrl.Email,
            Phone = contactCntrl.Phone,
        });
    }

    private void contactCntrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCntrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}