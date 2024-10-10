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
    public partial class MedicineViewModel : ObservableObject
    {
        private readonly MedicineService _medicineService;

        [ObservableProperty]
        private ObservableCollection<Medicine> medicines; /*{ get; set; } = new ObservableCollection<Medicine>();*/

        public MedicineViewModel(MedicineService medicineService)
        {
            _medicineService = medicineService;
            _medicineService.MedicinesChanged += OnMedicinesChanged;
            LoadMedicinesCommand = new AsyncRelayCommand(LoadMedicinesAsync);
            AddNewMedicineCommand = new AsyncRelayCommand(OnAddNewMedicineAsync);
            
        }

        public ICommand LoadMedicinesCommand { get; }
        public ICommand AddNewMedicineCommand { get; }

        private async void OnMedicinesChanged()
        {
            // Перезагрузите данные, когда изменения произошли
            await LoadMedicinesAsync();
        }
        private async Task LoadMedicinesAsync()
        {
            var medicinesList = await _medicineService.GetMedicinesAsync();
            Medicines = new ObservableCollection<Medicine>(medicinesList);
        }

        private async Task OnAddNewMedicineAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddMedicinePage));
        }

        [RelayCommand]
        private async Task GoToEditMedicineAsync(Medicine medicine)
        {
            var navigationParams = new Dictionary<string, object> { { "Medicine", medicine } };
            await Shell.Current.GoToAsync(nameof(EditMedicinePage), navigationParams);
        }
    }
}
