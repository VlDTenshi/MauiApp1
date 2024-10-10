using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class HospitalsPage : ContentPage
{
    private readonly HospitalViewModel _hospitalViewModel;
    public HospitalsPage(HospitalViewModel hospitalViewModel)
	{
		InitializeComponent();
        BindingContext = hospitalViewModel;
        _hospitalViewModel = hospitalViewModel;
	}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_hospitalViewModel.Hospitals == null || !_hospitalViewModel.Hospitals.Any()) // Загрузка, если список пустой
        {
            _hospitalViewModel.LoadHospitalsCommand.Execute(null);
        }
    }

    //private void btnEditHospital_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync(nameof(EditHospitalPage));
    //}

    //private void btnAddHospital_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync(nameof(AddHospitalPage));
    //}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}