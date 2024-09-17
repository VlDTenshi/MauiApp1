namespace MauiApp1.Views;

public class InformationPage : ContentPage
{
	public InformationPage()
	{
		var button = new Button { Text = "Go Back"};
        button.Clicked += Button_Clicked;
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				},
				button
			}
		};
	}

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}