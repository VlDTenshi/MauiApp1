using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ExercisesPage : ContentPage
{
    private bool isLongPress = false;
    private Exercise selectedExercise;
    private readonly TimeSpan longPressDuration = TimeSpan.FromMilliseconds(300);
    public ExercisesPage(ExerciseViewModel exerciseViewModel)
    {
        InitializeComponent();
        BindingContext = exerciseViewModel;

    }

    //private void btnAddExercise_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync(nameof(AddExercisePage));
    //}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var exercise = ((VisualElement)sender).BindingContext as Exercise;

        if (exercise == null)
            return;

        selectedExercise = exercise;

        Device.StartTimer(longPressDuration, () =>
        {
            isLongPress = true;
            ShowDeleteConfirmation();
            return false;
        });

        await Task.Delay(200);


        if (!isLongPress)
        {

            await Shell.Current.GoToAsync(nameof(ExerciseDetailsPage), true, new Dictionary<string, object>
        {
            {"Exercise", exercise }
        });

        }
        else
        {
            isLongPress = false;
        }
    }
    private async void ShowDeleteConfirmation()
    {
        if (selectedExercise == null) return;

        bool confirm = await Shell.Current.DisplayAlert("Удалить?", $"Вы действительно хотите удалить '{selectedExercise.Name}'?", "Да", "Нет");

        if (confirm)
        {
            // Вызовите метод удаления упражнения
            await (Application.Current.MainPage.BindingContext as ExerciseViewModel).RemoveExerciseAsync(selectedExercise);
            selectedExercise = null; // Сбросить выбранное упражнение
        }
    }
}