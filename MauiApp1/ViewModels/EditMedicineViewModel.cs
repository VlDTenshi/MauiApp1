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
    [QueryProperty(nameof(Medicine), "Medicine")]
    public partial class EditMedicineViewModel : ObservableObject
    {
        private readonly MedicineService _medicineService;

        [ObservableProperty]
        private Medicine medicine;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private string imagePath;

        public ICommand SaveMedicineCommand { get; }
        public ICommand PickImageCommand { get; }
        public ICommand DeleteMedicineCommand { get; }

        public EditMedicineViewModel(MedicineService medicineService)
        {
            _medicineService = medicineService;
            //_medicineService.MedicinesChanged += OnMedicineChanged;
            SaveMedicineCommand = new AsyncRelayCommand(SaveMedicineAsync);
            PickImageCommand = new AsyncRelayCommand(PickImageAsync);
            DeleteMedicineCommand = new AsyncRelayCommand(DeleteMedicineAsync);
        }
        partial void OnMedicineChanged(Medicine value)
        {
            if (value != null)
            {
                Name = value.Name;
                Description = value.Description;
                ImagePath = value.ImagePath;
            }
        }
        private async Task SaveMedicineAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and description", "Ok");
                return;
            }

            Medicine.Name = Name;
            Medicine.Description = Description;
            Medicine.ImagePath = ImagePath;

            await _medicineService.SaveMedicineAsync(Medicine);

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
        private async Task DeleteMedicineAsync()
        {
            // Подтверждение удаления
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this medicine?", "Yes", "No");
            if (confirm)
            {

                // Удаление объекта Medicine
                await _medicineService.DeleteMedicineAsync(Medicine);

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
