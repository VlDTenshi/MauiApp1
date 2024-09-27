using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class ExerciseViewModel : BaseViewModel
    {
        public ObservableCollection<Exercise> Exercises { get; } = new();

        public Command GetExercisesCommand { get; }
        ExerciseService exerciseService;
        public ExerciseViewModel(ExerciseService exerciseService)
        {
            Title = "Exercise Page";
            this.exerciseService = exerciseService; // instead of using this initializatio --> new ExerciseService();
            GetExercisesCommand = new Command(async () => await GetExercisesAsync());
        }

        async Task GetExercisesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                var exercises = await exerciseService.GetExercise();

                if (Exercises.Count != 0)
                    Exercises.Clear();
                foreach (var exercise in exercises)
                    Exercises.Add(exercise);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get exercises: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
