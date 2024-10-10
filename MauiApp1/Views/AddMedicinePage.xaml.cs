using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddMedicinePage : ContentPage
{
	private readonly AddMedicineViewModel _addMedicineViewModel;
	public AddMedicinePage(AddMedicineViewModel addMedicineViewModel)
	{
		InitializeComponent();
		BindingContext = addMedicineViewModel;
		_addMedicineViewModel = addMedicineViewModel;
	}

	private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
		//Shell.Current.GoToAsync($"//{nameof(MedicinesPage)}");
    }
}