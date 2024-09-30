using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    [QueryProperty(nameof(Exercise), "Exercise")]
    public partial class ExerciseDetailsViewModel : BaseViewModel
    {
        
        [ObservableProperty]
        private Exercise exercise;

        [ObservableProperty]
        private string exerciseName;

        [ObservableProperty]
        private string exerciseDescription;

        [ObservableProperty]
        private string exerciseRepetition;

        public Command SaveCommand { get; }
        public ExerciseDetailsViewModel() 
        {
            SaveCommand = new Command(async () => await SaveExerciseAsync());
        }       
        partial void OnExerciseChanged(Exercise value)
        {
            if (value != null)
            {
                
                ExerciseName = value.Name;
                ExerciseDescription = value.Description;
                ExerciseRepetition = value.Repetition;
            }
        }
        public async Task SaveExerciseAsync()
        {
            var exerciseToUpdate = new Exercise
            {
                Name = ExerciseName,
                Description = ExerciseDescription,
                Repetition = ExerciseRepetition
            };

            // Здесь вы можете вызвать метод обновления из вашего ExerciseService
            var exerciseService = new ExerciseService();
            await exerciseService.UpdateExercise(exerciseToUpdate);

            // После сохранения изменений, вернуться на предыдущую страницу
            await Shell.Current.GoToAsync("..");
        }
    }
}
