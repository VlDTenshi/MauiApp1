using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    [QueryProperty(nameof(Exercise), "Exercise")]
    public partial class ExerciseDetailsViewModel : BaseViewModel
    {

        [ObservableProperty]
        private Exercise exercise;

        [ObservableProperty]
        private string exerciseName;

        [ObservableProperty]
        private string exerciseDescription;

        [ObservableProperty]
        private string exerciseRepetition;
        public Command EditExerciseCommand { get; }
        public ExerciseDetailsViewModel(ExerciseService exerciseService) 
        {
            EditExerciseCommand = new Command(async () => await EditExerciseAsync());           
        }             
        private async Task EditExerciseAsync()
        {
            if (Exercise != null)
            {
                await Shell.Current.GoToAsync($"{nameof(EditExercisePage)}", new Dictionary<string, object>
                {
                    { "Exercise", Exercise }
                });
            }
        }
    }
}
