using MauiApp1.Views;

namespace MauiApp1
{
    public partial class App : Application
    {
        //public static UserInfo UserInfo;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override async void OnStart()
        {
            base.OnStart();

            MainPage = new NavigationPage(new LoadingPage());

            await Task.Delay(5000);

            MainPage = new AppShell();
        }
    }
}
