﻿using CommunityToolkit.Maui;
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

            builder.Services.AddSingleton<LoadingPage>();

            builder.Services.AddSingleton<ExerciseService>();

            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<ExercisesPage>();
            
            builder.Services.AddTransient<ExerciseViewModel>();

            builder.Services.AddTransient<ExerciseDetailsViewModel>();

            builder.Services.AddTransient<ExerciseDetailsPage>();

            //builder.Services.AddSingleton<LoginPage>();

            //builder.Services.AddSingleton<LoginPageViewModel>();

            //builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            //builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            //builder.Services.AddSingleton<IMap>(Map.Default);

            //builder.Services.AddSingleton<MedicinesPage>();
            //builder.Services.AddSingleton<HospitalsPage>();
            //builder.Services.AddSingleton<ContactsPage>();
            //builder.Services.AddSingleton<ExercisesPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
