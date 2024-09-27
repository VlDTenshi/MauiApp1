namespace MauiApp1.Views;

public partial class HomeNavigationPage : ContentPage
{
	public HomeNavigationPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MedicinesPage));
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HospitalsPage));
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ExercisesPage));
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ContactsPage));
    }
}