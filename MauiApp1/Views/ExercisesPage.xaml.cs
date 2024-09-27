using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ExercisesPage : ContentPage
{
	public ExercisesPage(ExerciseViewModel exerciseViewModel)
	{
		InitializeComponent();
        BindingContext = exerciseViewModel;

    }

    private void btnEditExercise_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditExercisePage));
    }

    private void btnAddExercise_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddExercisePage));
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}