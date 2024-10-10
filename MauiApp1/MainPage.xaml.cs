using MauiApp1.Views;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        //private async void SignUp_Clicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync(nameof(SignInPage));
        //}

        //private async void SignIn_Clicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync(nameof(SignUpPage));
        //}

        private async void Without_log_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(HomeNavigationPage));
        }
    }

}
