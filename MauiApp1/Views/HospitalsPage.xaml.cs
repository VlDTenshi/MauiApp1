namespace MauiApp1.Views;

public partial class HospitalsPage : ContentPage
{
	public HospitalsPage()
	{
		InitializeComponent();
	}

    private void btnEditHospital_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditHospitalPage));
    }

    private void btnAddHospital_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddHospitalPage));
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}