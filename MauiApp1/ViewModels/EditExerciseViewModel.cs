﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    [QueryProperty(nameof(Exercise), "Exercise")]
    public partial class EditExerciseViewModel : ObservableObject
    {

        private readonly ExerciseService _exerciseService;

        [ObservableProperty]
        private Exercise exercise;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private string repetition;
        [ObservableProperty]
        private string imagePath;

        public ICommand SaveExerciseCommand { get; }
        public ICommand PickImageCommand { get; }
        public ICommand DeleteExerciseCommand { get; }

        public EditExerciseViewModel(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
            SaveExerciseCommand = new AsyncRelayCommand(SaveExerciseAsync);
            PickImageCommand = new AsyncRelayCommand(PickImageAsync);
            DeleteExerciseCommand = new AsyncRelayCommand(DeleteExerciseAsync);
        }
        partial void OnExerciseChanged(Exercise value)
        {
            if (value != null)
            {
                Name = value.Name;
                Description = value.Description;
                repetition = value.Repetition;
                ImagePath = value.ImagePath;
            }
        }
        private async Task SaveExerciseAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and description", "Ok");
                return;
            }

            Exercise.Name = Name;
            Exercise.Description = Description;
            Exercise.Repetition = Repetition;
            Exercise.ImagePath = ImagePath;

            await _exerciseService.SaveExerciseAsync(Exercise);

            await Shell.Current.GoToAsync("..");
        }

        private async Task PickImageAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    var imagePath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    ImagePath = imagePath;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to pick image: {ex.Message}", "OK");
            }
        }
        private async Task DeleteExerciseAsync()
        {
            // Подтверждение удаления
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this medicine?", "Yes", "No");
            if (confirm)
            {

                // Удаление объекта Medicine
                await _exerciseService.DeleteExerciseAsync(Exercise);

                // Переход обратно к списку медикаментов
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                return;
            }
        }
    }
}
