namespace MauiApp1.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage() //(LoginPageViewViewModel loginPageViewModel) -version 2
    {
		InitializeComponent();
        //this.BindingContext = loginPageViewModel; -version 2
    }
    //protected override async void OnAppearing() -version 1
    //{
    //    base.OnAppearing();
    //    // var loggedin = true;
    //    // if (loggedin)
    //    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    //}

    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync($"//{nameof(GreetingPage)}");
    //}

    //private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    //{
    //    await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
    //}
}