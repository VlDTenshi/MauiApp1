
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddContactPage : ContentPage
{
    private readonly AddContactViewModel _addContactViewModel;
    public AddContactPage(AddContactViewModel addContactViewModel)
    {
        InitializeComponent();
        BindingContext = addContactViewModel;
        _addContactViewModel = addContactViewModel;
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        //Shell.Current.GoToAsync($"//{nameof(MedicinesPage)}");
    }
}