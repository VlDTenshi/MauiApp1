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
    public partial class ContactViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        [ObservableProperty]
        private ObservableCollection<ContactU> contacts; /*{ get; set; } = new ObservableCollection<Medicine>();*/

        public ContactViewModel(ContactService contactService)
        {
            _contactService = contactService;
            _contactService.ContactsChanged += OnContactsChanged;
            LoadContactsCommand = new AsyncRelayCommand(LoadContactsAsync);
            AddNewContactCommand = new AsyncRelayCommand(OnAddNewContactAsync);
            DeleteContactCommand = new AsyncRelayCommand<ContactU>(DeleteContactAsync);

        }

        public ICommand LoadContactsCommand { get; }
        public ICommand AddNewContactCommand { get; }
        public ICommand DeleteContactCommand { get; }

        private async void OnContactsChanged()
        {
            // Перезагрузите данные, когда изменения произошли
            await LoadContactsAsync();
        }
        private async Task LoadContactsAsync()
        {
            var contactsList = await _contactService.GetContactsAsync();
            Contacts = new ObservableCollection<ContactU>(contactsList);
        }

        private async Task OnAddNewContactAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage));
        }

        [RelayCommand]
        private async Task GoToEditContactAsync(ContactU contact)
        {
            var navigationParams = new Dictionary<string, object> { { "ContactU", contact } };
            await Shell.Current.GoToAsync(nameof(EditContactPage), navigationParams);
        }
        private async Task DeleteContactAsync(ContactU contact)
        {
            if (contact == null) return;

            bool confirm = await Shell.Current.DisplayAlert("Confirm", "Are you sure you want to delete this contact?", "Yes", "No");
            if (confirm)
            {
                Contacts.Remove(contact);  // Удаляем контакт из списка
                await _contactService.DeleteContactAsync(contact);  // Удаляем контакт из базы данных

                // Сообщаем об изменениях данных, чтобы обновить UI
                OnPropertyChanged(nameof(Contacts));
            }
        }
    }
}
