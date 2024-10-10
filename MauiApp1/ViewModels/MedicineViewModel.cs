using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    // ViewModel for managing medicine-related data and commands
    public partial class MedicineViewModel : ObservableObject
    {
        // Instance of MedicineService to handle data operations
        private readonly MedicineService _medicineService;

        // Observable property to hold the list of medicines
        [ObservableProperty]
        private ObservableCollection<Medicine> medicines; /*{ get; set; } = new ObservableCollection<Medicine>();*/

        // Constructor that takes a MedicineService instance as a parameter
        public MedicineViewModel(MedicineService medicineService)
        {
            _medicineService = medicineService; // Store the MedicineService instance
            _medicineService.MedicinesChanged += OnMedicinesChanged; // Subscribe to MedicinesChanged event

            // Initialize commands for loading and adding medicines
            LoadMedicinesCommand = new AsyncRelayCommand(LoadMedicinesAsync);
            AddNewMedicineCommand = new AsyncRelayCommand(OnAddNewMedicineAsync);
            
        }

        // Command to load medicines
        public ICommand LoadMedicinesCommand { get; }

        // Command to add a new medicine
        public ICommand AddNewMedicineCommand { get; }

        // Event handler that reloads data when the medicines change
        private async void OnMedicinesChanged()
        {
            // Reload data when changes occur
            await LoadMedicinesAsync();
        }

        // Asynchronously loads the list of medicines from the service
        private async Task LoadMedicinesAsync()
        {
            // Retrieve the list of medicines from the service
            var medicinesList = await _medicineService.GetMedicinesAsync();

            // Update the ObservableCollection with the new list of medicines
            Medicines = new ObservableCollection<Medicine>(medicinesList);
        }

        // Asynchronously navigates to the AddMedicinePage
        private async Task OnAddNewMedicineAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddMedicinePage)); // Navigate to the Add Medicine page
        }

        // Command to navigate to the EditMedicinePage for editing a specific medicine
        [RelayCommand]
        private async Task GoToEditMedicineAsync(Medicine medicine)
        {
            // Create navigation parameters with the selected medicine
            var navigationParams = new Dictionary<string, object> { { "Medicine", medicine } };

            // Navigate to the EditMedicinePage with the parameters
            await Shell.Current.GoToAsync(nameof(EditMedicinePage), navigationParams);
        }
    }
}
