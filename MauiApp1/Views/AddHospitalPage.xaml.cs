using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddHospitalPage : ContentPage
{
    private readonly AddHospitalViewModel _addHospitalViewModel;
    public AddHospitalPage(AddHospitalViewModel addHospitalViewModel)
    {
        InitializeComponent();
        BindingContext = addHospitalViewModel;
        _addHospitalViewModel = addHospitalViewModel;
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        //Shell.Current.GoToAsync($"//{nameof(MedicinesPage)}");
    }
}