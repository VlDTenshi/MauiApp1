using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomeNavigationPage), typeof(HomeNavigationPage));

            Routing.RegisterRoute(nameof(GreetingPage), typeof(GreetingPage));

            Routing.RegisterRoute(nameof(InformationPage), typeof(InformationPage));

            Routing.RegisterRoute(nameof(MedicinesPage), typeof(MedicinesPage));
            Routing.RegisterRoute(nameof(EditMedicinePage), typeof(EditMedicinePage));
            Routing.RegisterRoute(nameof(AddMedicinePage), typeof(AddMedicinePage));

            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            

            Routing.RegisterRoute(nameof(HospitalsPage), typeof(HospitalsPage));
            Routing.RegisterRoute(nameof(AddHospitalPage), typeof(AddHospitalPage));
            Routing.RegisterRoute(nameof(EditHospitalPage), typeof(EditHospitalPage));

            Routing.RegisterRoute(nameof(ExercisesPage), typeof(ExercisesPage));
            Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
            Routing.RegisterRoute(nameof(EditExercisePage), typeof(EditExercisePage));
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Launcher.OpenAsync("https://www.youtube.com/@vladimirvld2020");
        }

        private void SignOutMenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
