using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;


public partial class EditExercisePage : ContentPage
{
	private readonly EditExerciseViewModel _viewModel;
	public EditExercisePage(EditExerciseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel= viewModel;
	}
    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}