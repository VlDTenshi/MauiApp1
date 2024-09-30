using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ExerciseDetailsPage : ContentPage
{
	public ExerciseDetailsPage(ExerciseDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as ExerciseDetailsViewModel;

        if (viewModel != null && viewModel.Exercise != null)
        {
            // ����� ����� ���������� �������� ��� ��������������, ���� ����������.
            // ��������, �� ������ ������� ����� ������ ��� ����� �������� � ������ ��� ��������������.
            await Shell.Current.GoToAsync(nameof(EditExercisePage), new Dictionary<string, object>
            {
                {"Exercise", viewModel.Exercise }
            });
        }
    }
}