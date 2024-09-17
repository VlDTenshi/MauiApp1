namespace MauiApp1.Views;

public partial class ExercisesPage : ContentPage
{
	public ExercisesPage()
	{
		InitializeComponent();
	}

    private void btnEditExercise_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditExercisePage));
    }

    private void btnAddExercise_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddExercisePage));
    }
}