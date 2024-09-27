using MauiApp1.Models;
using Contact = MauiApp1.Models.Contact;

namespace MauiApp1.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

	public string ContactId
	{
		set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));

			if(contact != null)
			{ 
				contactCntrl.Name = contact.Name;
                contactCntrl.Address = contact.Address;
                contactCntrl.Email = contact.Email;
                contactCntrl.Phone = contact.Phone;
            }
		}
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        
        contact.Name = contactCntrl.Name;
		contact.Address = contactCntrl.Address;
		contact.Email = contactCntrl.Email;
		contact.Phone = contactCntrl.Phone;

		ContactRepository.UpdateContact(contact.ContactId, contact);

		Shell.Current.GoToAsync("..");
    }

    private void contactCntrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}