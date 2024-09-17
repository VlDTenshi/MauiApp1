namespace MauiApp1.Views;

public partial class AddMedicinePage : ContentPage
{
	public AddMedicinePage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
		//Shell.Current.GoToAsync($"//{nameof(MedicinesPage)}");
    }
}