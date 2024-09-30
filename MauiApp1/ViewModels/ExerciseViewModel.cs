using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
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

        //Commands
        public Command GetExercisesCommand { get; }
        public Command AddExerciseCommand { get; }
        public Command EditExerciseCommand { get; }
        public Command<Exercise> RemoveExerciseCommand {get;}

        //Service
        private readonly ExerciseService exerciseService;

        [ObservableProperty]
        private string exerciseName;
        [ObservableProperty]
        private string exerciseDescription;
        [ObservableProperty]
        private string exerciseRepetition;

        //Property for chosen exercise from the list
        //[ObservableProperty]
        //Exercise selectedExercise;

        public ExerciseViewModel(ExerciseService exerciseService)
        {
            Title = "Exercise Page";
            this.exerciseService = exerciseService; // instead of using this initialization --> new ExerciseService();

            GetExercisesCommand = new Command(async () => await GetExercisesAsync());
            AddExerciseCommand = new Command(async () => await AddExerciseAsync());
            //EditExerciseCommand = new Command<Exercise>(async (exercise) => await EditExerciseAsync(exercise));
            RemoveExerciseCommand = new Command<Exercise>(async (exercise) => await RemoveExerciseAsync(exercise));
        }

        
        public async Task GetExercisesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                //Getting exercise list from ExerciseService
                var exercises = await exerciseService.GetExercise();

                //Clear the current list
                if (Exercises.Count != 0)
                    Exercises.Clear();

                //Add an exercise to Collection for display on UI
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

      
        public async Task AddExerciseAsync()
        {
            if(string.IsNullOrEmpty(ExerciseName) || string.IsNullOrEmpty(ExerciseDescription))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and description", "Ok");
                return;
            }
            try
            {
                var newExercise = new Exercise
                {
                    Name = ExerciseName,
                    Description = ExerciseDescription,
                    Repetition = ExerciseRepetition,
                };

                Exercises.Add(newExercise);
                await exerciseService.AddExercise(newExercise);

                ExerciseName = string.Empty;
                ExerciseDescription = string.Empty;
                ExerciseRepetition = string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to add exercise: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

        
        public async Task RemoveExerciseAsync(Exercise exercise)
        {
            try
            {
                if (exercise != null && Exercises.Contains(exercise))
                {
                    Exercises.Remove(exercise);
                    await exerciseService.RemoveExercise(exercise);
                }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine($"Unable to remove exercise: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

        
        //public async Task EditExerciseAsync(Exercise exercise)
        //{
        //    if (exercise != null)
        //    {
        //        await Shell.Current.GoToAsync($"{nameof(EditExercisePage)}", new Dictionary<string, object>
        //        {
        //            {"Exercise", exercise }
        //        });
        //    }
        //    else
        //    {
        //        await Shell.Current.DisplayAlert("Error", "Please select an exercise to edit", "Ok");
        //    }
        //}
    }
}
