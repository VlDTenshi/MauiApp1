using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(GreetingPage), typeof(GreetingPage));
            Routing.RegisterRoute(nameof(InformationPage), typeof(InformationPage));
            Routing.RegisterRoute(nameof(MedicinesPage), typeof(MedicinesPage));
            Routing.RegisterRoute(nameof(EditMedicinePage), typeof(EditMedicinePage));
            Routing.RegisterRoute(nameof(AddMedicinePage), typeof(AddMedicinePage));
            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(HospitalsPage), typeof(HospitalsPage));
            Routing.RegisterRoute(nameof(ExercisesPage), typeof(ExercisesPage));
        }
    }
}
