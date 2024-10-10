using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class EditHospitalPage : ContentPage
{
    private readonly EditHospitalViewModel _edithospitalViewModel;
    public EditHospitalPage(EditHospitalViewModel edithospitalViewModel)
    {
        InitializeComponent();
        BindingContext = edithospitalViewModel;
        _edithospitalViewModel = edithospitalViewModel;
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}