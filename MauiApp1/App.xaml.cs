using MauiApp1.DbContext;
using MauiApp1.Views;

namespace MauiApp1
{
    public partial class App : Application
    {
        public static HospitalDBContext HospitalDatabase { get; private set; }
        public static ContactDBContext ContactDatabase { get; private set; }
        public static ExercisesDBContext ExercisesDatabase { get; private set; }
        public static ApplicationDbContext Database { get; private set; }
        //public static UserInfo UserInfo;
        public App()
        {
            InitializeComponent();
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "medicine.db3");
            var hospitalPath = Path.Combine(FileSystem.AppDataDirectory, "hospital.db3");
            var contactPath = Path.Combine(FileSystem.AppDataDirectory, "contact.db3");
            var exercisePath = Path.Combine(FileSystem.AppDataDirectory, "exercise.db3");

            Database = new ApplicationDbContext(dbPath);
            HospitalDatabase = new HospitalDBContext(hospitalPath);
            ContactDatabase = new ContactDBContext(contactPath);
            ExercisesDatabase = new ExercisesDBContext(exercisePath);
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
