namespace MauiApp1.Views;

public partial class EditMedicinePage : ContentPage
{
	public EditMedicinePage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}