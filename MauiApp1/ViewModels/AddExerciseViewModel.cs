﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public partial class AddExerciseViewModel : ObservableObject
    {
        private readonly ExerciseService _exerciseService;

        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private string imagePath;
        [ObservableProperty]
        private string repetition;


        public ICommand SaveExerciseCommand { get; }
        public ICommand PickImageCommand { get; }

        public AddExerciseViewModel(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
            SaveExerciseCommand = new AsyncRelayCommand(SaveExerciseAsync);
            PickImageCommand = new AsyncRelayCommand(PickImageAsync);
        }

        private async Task SaveExerciseAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter a valid name and description", "OK");
                return;
            }

            var newExercise = new Exercise
            {
                Name = Name,
                Description = Description,
                Repetition = Repetition,
                ImagePath = ImagePath
            };

            await _exerciseService.SaveExerciseAsync(newExercise);

            // Переход назад к странице с перечнем медикаментов
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
    }
}
