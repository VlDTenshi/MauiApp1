
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddExercisePage : ContentPage
{
    private readonly  AddExerciseViewModel _viewModel;

    public AddExercisePage(AddExerciseViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
      
    }
    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
        
    }
}
