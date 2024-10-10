#if ANDROID
using AndroidX.Lifecycle;
#endif
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class MedicinesPage : ContentPage
{
    //Instance of Service for working medicine data
    private readonly MedicineViewModel _medicineViewModel;

    //constructor for the page, accepting an instance of MedicineViewModel
	public MedicinesPage(MedicineViewModel medicineViewModel)
	{
		InitializeComponent(); // Initialize the page components ( create UI elements )
        BindingContext = medicineViewModel;// Set the binding context (ViewModel) for the page
        _medicineViewModel = medicineViewModel;// Store a reference to the passed VieModel instance
     
    }

    // Method called when the page appears
    protected override void OnAppearing()
    {
        base.OnAppearing();// Call the base method to perform standard logic

        //Check if the list of medicines is empty
        if (_medicineViewModel.Medicines == null || !_medicineViewModel.Medicines.Any()) // Загрузка, если список пустой
        {
            // Exxecute the command to load the list of medicines
            _medicineViewModel.LoadMedicinesCommand.Execute(null);
        }
    }

    //Method handling the back button click
    private async void backButton_Clicked(object sender, EventArgs e)
    {
        //Navigate back to the previous page in the navigation history
        await Shell.Current.GoToAsync("..");
    }

}