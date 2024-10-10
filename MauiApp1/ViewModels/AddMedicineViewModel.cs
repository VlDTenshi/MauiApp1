using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class AddMedicineViewModel : ObservableObject
    {
        private readonly MedicineService _medicineService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string imagePath;

        public ICommand SaveMedicineCommand { get; }
        public ICommand PickImageCommand { get; }

        public AddMedicineViewModel(MedicineService medicineService)
        {
            _medicineService = medicineService;
            SaveMedicineCommand = new AsyncRelayCommand(SaveMedicineAsync);
            PickImageCommand = new AsyncRelayCommand(PickImageAsync);
        }

        private async Task SaveMedicineAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter a valid name and description", "OK");
                return;
            }

            var newMedicine = new Medicine
            {
                Name = Name,
                Description = Description,
                ImagePath = ImagePath
            };

            await _medicineService.SaveMedicineAsync(newMedicine);

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
