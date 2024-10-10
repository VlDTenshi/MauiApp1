using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public partial class AddHospitalViewModel:ObservableObject
    {

        private readonly HospitalService _hospitalService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string imagePath;

        public ICommand SaveHospitalCommand { get; }
        public ICommand PickImageCommand { get; }

        public AddHospitalViewModel(HospitalService hospitalService)
        {
            _hospitalService = hospitalService;
            SaveHospitalCommand = new AsyncRelayCommand(SaveHospitalAsync);
            PickImageCommand = new AsyncRelayCommand(PickImageAsync);
        }

        private async Task SaveHospitalAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter a valid name and description", "OK");
                return;
            }

            var newHospital = new Hospital
            {
                Name = Name,
                Description = Description,
                Address = Address,
                ImagePath = ImagePath
            };

            await _hospitalService.SaveHospitalAsync(newHospital);

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
