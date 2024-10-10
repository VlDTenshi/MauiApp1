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
using System.Windows.Input;


namespace MauiApp1.ViewModels
{
    public partial class ExerciseViewModel : ObservableObject
    {
        private readonly ExerciseService _exerciseService;

        [ObservableProperty]
        private ObservableCollection<Exercise> exercises; /*{ get; set; } = new ObservableCollection<Medicine>();*/

        public ExerciseViewModel(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
            _exerciseService.ExercisesChanged += OnExercisesChanged;
            LoadExercisesCommand = new AsyncRelayCommand(LoadExercisesAsync);
            AddNewExerciseCommand = new AsyncRelayCommand(OnAddNewExerciseAsync);
            DeleteExerciseCommand = new AsyncRelayCommand<Exercise>(DeleteExerciseAsync);

        }

        public ICommand LoadExercisesCommand { get; }
        public ICommand AddNewExerciseCommand { get; }
        public ICommand DeleteExerciseCommand { get; }

        private async void OnExercisesChanged()
        {
            // Перезагрузите данные, когда изменения произошли
            await LoadExercisesAsync();
        }
        private async Task LoadExercisesAsync()
        {
            var exercisesList = await _exerciseService.GetExercisesAsync();
            Exercises = new ObservableCollection<Exercise>(exercisesList);
        }

        private async Task OnAddNewExerciseAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddExercisePage));
        }

        [RelayCommand]
        private async Task GoToEditExerciseAsync(Exercise exercise)
        {
            var navigationParams = new Dictionary<string, object> { { "Exercise", exercise } };
            await Shell.Current.GoToAsync(nameof(EditExercisePage), navigationParams);
        }
        private async Task DeleteExerciseAsync(Exercise exercise)
        {
            if (exercise == null) return;

            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this contact?", "Yes", "No");
            if (confirm)
            {
                Exercises.Remove(exercise);  // Удаляем контакт из списка
                await _exerciseService.DeleteExerciseAsync(exercise);  // Удаляем контакт из базы данных

                // Сообщаем об изменениях данных, чтобы обновить UI
                OnPropertyChanged(nameof(Contacts));
            }
        }
    }
}
