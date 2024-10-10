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
    public partial class HospitalViewModel : ObservableObject
    {
        private readonly HospitalService _hospitalService;

        [ObservableProperty]
        private ObservableCollection<Hospital> hospitals;

        public HospitalViewModel(HospitalService hospitalService) 
        {
            _hospitalService = hospitalService;
            _hospitalService.HospitalsChanged += OnHospitalsChanged;
            LoadHospitalsCommand = new AsyncRelayCommand(LoadHospitalsAsync);
            AddNewHospitalCommand = new AsyncRelayCommand(OnAddNewHospitalAsync);
        }
        public ICommand LoadHospitalsCommand { get; }
        public ICommand AddNewHospitalCommand { get; }

        private async void OnHospitalsChanged()
        {
            // Перезагрузите данные, когда изменения произошли
            await LoadHospitalsAsync();
        }

        private async Task LoadHospitalsAsync()
        {
            var hospitalsList = await _hospitalService.GetHospitalsAsync();
            Hospitals = new ObservableCollection<Hospital>(hospitalsList);
        }

        private async Task OnAddNewHospitalAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddHospitalPage));
        }

        [RelayCommand]
        private async Task GoToEditHospitalAsync(Hospital hospital)
        {
            var navigationParams = new Dictionary<string, object> { { "Hospital",hospital } };
            await Shell.Current.GoToAsync(nameof(EditHospitalPage), navigationParams);
        }
    }

}
