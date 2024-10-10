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
    [QueryProperty(nameof(Hospital), "Hospital")]
    public partial class EditHospitalViewModel : ObservableObject
    {
        private readonly HospitalService _hospitalService;

        [ObservableProperty]
        private Hospital hospital;
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
        public ICommand DeleteHospitalCommand { get; }

        public EditHospitalViewModel(HospitalService hospitalService)
        {
            _hospitalService = hospitalService;
            //_medicineService.MedicinesChanged += OnMedicineChanged;
            SaveHospitalCommand = new AsyncRelayCommand(SaveHospitalAsync);
            PickImageCommand = new AsyncRelayCommand(PickImageAsync);
            DeleteHospitalCommand = new AsyncRelayCommand(DeleteHospitalAsync);
        }
        partial void OnHospitalChanged(Hospital value)
        {
            if (value != null)
            {
                Name = value.Name;
                Description = value.Description;
                Address = value.Address;    
                ImagePath = value.ImagePath;
            }
        }
        private async Task SaveHospitalAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and description", "Ok");
                return;
            }

            Hospital.Name = Name;
            Hospital.Description = Description;
            Hospital.Address = Address;
            Hospital.ImagePath = ImagePath;

            await _hospitalService.SaveHospitalAsync(Hospital);

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
        private async Task DeleteHospitalAsync()
        {
            // Подтверждение удаления
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this medicine?", "Yes", "No");
            if (confirm)
            {

                // Удаление объекта Medicine
                await _hospitalService.DeleteHospitalAsync(Hospital);

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
