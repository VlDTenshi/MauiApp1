
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
    [QueryProperty(nameof(ContactU), "ContactU")]
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        [ObservableProperty]
        private ContactU contactU;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string address;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string phone;
        //[ObservableProperty]
        //private string imagePath;

        public ICommand SaveContactCommand { get; }
        //public ICommand PickImageCommand { get; }
        public ICommand DeleteContactCommand { get; }

        public EditContactViewModel(ContactService contactService)
        {
            _contactService = contactService;
            SaveContactCommand = new AsyncRelayCommand(SaveContactAsync);
            //PickImageCommand = new AsyncRelayCommand(PickImageAsync);
            DeleteContactCommand = new AsyncRelayCommand(DeleteContactAsync);
        }
        public void OnContactChanged (ContactU value)
        {
            if (value != null)
            {
                Name = value.Name;
                Address = value.Address;
                Email = value.Email;
                Phone = value.Phone;
            }
        }
        private async Task SaveContactAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter valid name and phone", "Ok");
                return;
            }

            ContactU.Name = Name;
            ContactU.Address = Address;
            ContactU.Email = Email;
            ContactU.Phone = Phone;

            await _contactService.SaveContactAsync(ContactU);

            await Shell.Current.GoToAsync("..");
        }

        //private async Task PickImageAsync()
        //{
        //    try
        //    {
        //        var result = await MediaPicker.PickPhotoAsync();
        //        if (result != null)
        //        {
        //            var stream = await result.OpenReadAsync();
        //            var imagePath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);

        //            using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
        //            {
        //                await stream.CopyToAsync(fileStream);
        //            }

        //            ImagePath = imagePath;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await Shell.Current.DisplayAlert("Error", $"Unable to pick image: {ex.Message}", "OK");
        //    }
        //}
        private async Task DeleteContactAsync()
        {
            // Подтверждение удаления
            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this contact?", "Yes", "No");
            if (confirm)
            {

                // Удаление объекта Medicine
                await _contactService.DeleteContactAsync(ContactU);

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
