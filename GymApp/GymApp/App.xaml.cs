using System;
using Xamarin.Forms;
using GymApp.Models;

namespace GymApp
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("gym.db3");
        internal static OneRepMaxRepository ORMRepo { get; private set; }
        internal static ExerciseRepository ExerciseRepo { get; private set; }

        public App()
        {
            InitializeComponent();
            ORMRepo = new OneRepMaxRepository(dbPath);
            ExerciseRepo = new ExerciseRepository(dbPath);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
