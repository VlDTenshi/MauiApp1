namespace MauiApp1.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // var loggedin = true;
        // if (loggedin)
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(GreetingPage)}");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
    }
}