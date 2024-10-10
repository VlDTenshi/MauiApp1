using CommunityToolkit.Maui;
using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "medicines.db3");
            string contactPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db3");
            string exercisePath = Path.Combine(FileSystem.AppDataDirectory, "exercises.db3");
            string hospitalPath = Path.Combine(FileSystem.AppDataDirectory, "hospitals.db3");

            builder.Services.AddSingleton<LoadingPage>();

            builder.Services.AddSingleton<ContactService>(g => ActivatorUtilities.CreateInstance<ContactService>(g, contactPath));
            builder.Services.AddSingleton<ExerciseService>(f=> ActivatorUtilities.CreateInstance<ExerciseService>(f, exercisePath));
            builder.Services.AddSingleton<MedicineService>(s => ActivatorUtilities.CreateInstance<MedicineService>(s, dbPath));
            builder.Services.AddSingleton<HospitalService>(e => ActivatorUtilities.CreateInstance<HospitalService>(e, contactPath));

            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<ExercisesPage>();
            builder.Services.AddTransient<AddExercisePage>();
            builder.Services.AddTransient<EditExercisePage>();

            builder.Services.AddTransient<ContactsPage>();
            builder.Services.AddTransient<AddContactPage>();
            builder.Services.AddTransient<EditContactPage>();

            builder.Services.AddTransient<MedicinesPage>();
            builder.Services.AddTransient<AddMedicinePage>();
            builder.Services.AddTransient<EditMedicinePage>();

            builder.Services.AddTransient<HospitalsPage>();
            builder.Services.AddTransient<AddHospitalPage>();
            builder.Services.AddTransient<EditHospitalPage>();

            builder.Services.AddTransient<MedicineViewModel>();
            builder.Services.AddTransient<AddMedicineViewModel>();
            builder.Services.AddTransient<EditMedicineViewModel>();

            builder.Services.AddTransient<HospitalViewModel>();
            builder.Services.AddTransient<AddHospitalViewModel>();
            builder.Services.AddTransient<EditHospitalViewModel>();

            builder.Services.AddTransient<ExerciseViewModel>();
            builder.Services.AddTransient<AddExerciseViewModel>();
            builder.Services.AddTransient<EditExerciseViewModel>();

            builder.Services.AddTransient<ContactViewModel>();
            builder.Services.AddTransient<AddContactViewModel>();
            builder.Services.AddTransient<EditContactViewModel>();







            //builder.Services.AddSingleton<LoginPage>();

            //builder.Services.AddSingleton<LoginPageViewModel>();

            //builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            //builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            //builder.Services.AddSingleton<IMap>(Map.Default);



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
