using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddExercisePage : ContentPage
{
	public AddExercisePage()
	{
		InitializeComponent();
		BindingContext = new AddExerciseViewModel(new ExerciseService());

    }
}