using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        //Attribute automatically generate a code for property IsBusy 
        //will be notifying about changing IsNotBusy
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        //Property IsNotBusy depends on IsBusy
        public bool IsNotBusy => !IsBusy;
        //partial void OnIsBusyChanged(bool oldValue, bool newValue)
        //{
        //    // Уведомляем о том, что свойство IsNotBusy изменилось
        //    OnPropertyChanged(nameof(IsNotBusy));
        //}
    }
}
