
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
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

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

        public AddContactViewModel(ContactService contactService)
        {
            _contactService = contactService;
            SaveContactCommand = new AsyncRelayCommand(SaveContactAsync);
            //PickImageCommand = new AsyncRelayCommand(PickImageAsync);
        }

        private async Task SaveContactAsync()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter a valid name and description", "OK");
                return;
            }

            var newContact = new ContactU
            {
                Name = Name,
                Address = Address,
                Email = Email,
                Phone = Phone
            };

            await _contactService.SaveContactAsync(newContact);

            // Переход назад к странице с перечнем медикаментов
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
    }
}
