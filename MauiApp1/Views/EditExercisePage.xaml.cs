using MauiApp1.Models;

namespace MauiApp1.Views;

[QueryProperty(nameof(Exercise), "Exercise")]
public partial class EditExercisePage : ContentPage
{
	public Exercise Exercise { get; set; }
	public EditExercisePage()
	{
		InitializeComponent();
	}
}