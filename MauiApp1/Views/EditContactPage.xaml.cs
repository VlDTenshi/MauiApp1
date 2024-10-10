
using MauiApp1.ViewModels;


namespace MauiApp1.Views;

public partial class EditContactPage : ContentPage
{
    private readonly EditContactViewModel _editcontactViewModel;
    public EditContactPage(EditContactViewModel editcontactViewModel)
    {
        InitializeComponent();
        BindingContext = editcontactViewModel;
        _editcontactViewModel = editcontactViewModel;
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}