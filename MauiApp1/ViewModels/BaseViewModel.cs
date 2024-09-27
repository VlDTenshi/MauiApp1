using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        //[AlsoNotifyChangeFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
        partial void OnIsBusyChanged(bool oldValue, bool newValue)
        {
            // Уведомляем о том, что свойство IsNotBusy изменилось
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }
}
