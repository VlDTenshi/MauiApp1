using CommunityToolkit.Mvvm.ComponentModel;
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
                // Ask user to choose between picking a photo or taking a new one
                string action = await Shell.Current.DisplayActionSheet("Choose Image Source", "Cancel", null, "Take Photo", "Pick from Gallery");

                FileResult result = null;

                if (action == "Take Photo")
                {
                    // Check if camera is available
                    if (MediaPicker.IsCaptureSupported)
                    {
                        // Capture a new photo using the device's camera
                        result = await MediaPicker.CapturePhotoAsync();
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Camera is not supported on this device.", "OK");
                        return;
                    }
                }
                else if (action == "Pick from Gallery")
                {
                    // Pick a photo from the gallery
                    result = await MediaPicker.PickPhotoAsync();
                }

                // If the user picked or captured a photo
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    var imagePath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);

                    // Save the file to the app's data directory
                    using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    // Set the ImagePath property to the saved image's path
                    ImagePath = imagePath;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Unable to select or capture image: {ex.Message}", "OK");
            }
        }
    }
}
