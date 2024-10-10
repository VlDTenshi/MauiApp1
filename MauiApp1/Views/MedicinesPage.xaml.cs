#if ANDROID
using AndroidX.Lifecycle;
#endif
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class MedicinesPage : ContentPage
{
    private readonly MedicineViewModel _medicineViewModel;
	public MedicinesPage(MedicineViewModel medicineViewModel)
	{
		InitializeComponent();
        BindingContext = medicineViewModel;
        _medicineViewModel = medicineViewModel;
     
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_medicineViewModel.Medicines == null || !_medicineViewModel.Medicines.Any()) // Загрузка, если список пустой
        {
            _medicineViewModel.LoadMedicinesCommand.Execute(null);
        }
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}