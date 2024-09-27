using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace MauiApp1.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;

        readonly ILoginRepository loginRepository = new LoginService();

        [RelayCommand]
        public async void Login()
        {
            if(!string.IsNullOrEmpty(UserName)&& !string.IsNullOrWhiteSpace(Password))
            {
                UserInfo userInfo = await loginRepository.Login(UserName, Password);

                if (Preferences.ContainsKey(nameof(App.UserInfo)))
                {
                    Preferences.Remove(nameof(App.UserInfo));
                }

                string userDetails = JsonConvert.SerializeObject(userInfo);
                Preferences.Set(nameof(App.UserInfo), userDetails);
                App.UserInfo = userInfo;

                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
        }
    }
}
