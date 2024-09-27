using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class MedicinesPage : ContentPage
{
	public MedicinesPage()
	{
		InitializeComponent();
        BindingContext = new MedicineViewModel();
        //List<string> medicines = new List<string>() { 
        //    "Aspirin",
        //    "Ampril",
        //    "Analgin",
        //    "Vizin"
        //};
        //listMedicines.ItemsSource = medicines; 
    }

    private void btnEditMedicine_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditMedicinePage));
    }

    private void btnAddMedicine_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddMedicinePage));
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}