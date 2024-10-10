using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class EditMedicinePage : ContentPage
{
	private readonly EditMedicineViewModel _editmedicineViewModel;
	public EditMedicinePage(EditMedicineViewModel editmedicineViewModel)
	{
		InitializeComponent();
		BindingContext = editmedicineViewModel;
		_editmedicineViewModel = editmedicineViewModel;
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}