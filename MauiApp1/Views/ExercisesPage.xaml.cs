using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ExercisesPage : ContentPage
{
    
    private readonly ExerciseViewModel _exerciseViewModel;
    public ExercisesPage(ExerciseViewModel exerciseViewModel)
    {
        InitializeComponent();
        BindingContext = exerciseViewModel;
        _exerciseViewModel = exerciseViewModel;

    }

    //private void btnAddExercise_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync(nameof(AddExercisePage));
    //}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_exerciseViewModel.Exercises == null || !_exerciseViewModel.Exercises.Any()) // Загрузка, если список пустой
        {
            _exerciseViewModel.LoadExercisesCommand.Execute(null);
        }
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    //private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    //{
    //    var exercise = ((VisualElement)sender).BindingContext as Exercise;

    //    if (exercise == null)
    //        return;

    //    selectedExercise = exercise;

    //    await Shell.Current.GoToAsync(nameof(ExerciseDetailsPage), true, new Dictionary<string, object>
    //    {
    //        {"Exercise", exercise }
    //    });
    //}
}