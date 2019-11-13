using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePCL;
using System.IO;
using TShirtApp;

namespace T_ShirtApp
{
    public partial class App : Application
    {
        static TShirtDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TShirtOrderPage());
        }

        public static TShirtDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TShirtDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TShirtSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
