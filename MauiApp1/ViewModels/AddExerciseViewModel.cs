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
    public partial class AddExerciseViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string exerciseName;

        [ObservableProperty]
        private string exerciseDescription;

        [ObservableProperty]
        private string exerciseRepetition;

        public Command SaveCommand { get; }

        private readonly ExerciseService exerciseService;

        public AddExerciseViewModel(ExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
            SaveCommand = new Command(async () => await SaveExerciseAsync());
        }

        public async Task SaveExerciseAsync()
        {
            if (string.IsNullOrEmpty(ExerciseName) || string.IsNullOrEmpty(ExerciseDescription))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and description", "Ok");
                return;
            }

            var nextId = exerciseService.GetId();

            // Создаем новое упражнение
            var newExercise = new Exercise
            {
                Id= nextId,
                Name = ExerciseName,
                Description = ExerciseDescription,
                Repetition = ExerciseRepetition
            };

            // Добавляем упражнение в JSON и в список
            await exerciseService.AddExercise(newExercise);

            // Возвращаемся на страницу со списком упражнений после сохранения
            await Shell.Current.GoToAsync("..");
        }
    }
}
