using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace NoteApp
{
    public partial class App : Application
    {
        private static SQLiteHelper db;
        public static SQLiteHelper Database 
        {
            get 
            {
                if (db == null) 
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AllReminders.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage =  new NavigationPage( new MainPage());
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
