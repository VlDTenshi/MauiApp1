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
    public partial class EditExerciseViewModel : BaseViewModel
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

        private readonly ExerciseService exerciseService;

        public EditExerciseViewModel(ExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;

            // Команда для сохранения изменений
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

        // Сохранение изменений и обновление данных
        public async Task SaveExerciseAsync()
        {
            if (string.IsNullOrEmpty(ExerciseName) || string.IsNullOrEmpty(ExerciseDescription))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and description", "Ok");
                return;
            }

            var updatedExercise = new Exercise
            {
                Name = ExerciseName,
                Description = ExerciseDescription,
                Repetition = ExerciseRepetition
            };

            // Обновление данных в JSON-файле
            await exerciseService.UpdateExercise(updatedExercise);

            // Возврат на страницу с деталями
            await Shell.Current.GoToAsync("..");
        }
    }
}
