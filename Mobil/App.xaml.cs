using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobil.Data;
using System.IO;

namespace Mobil
{
    public partial class App : Application
    {
        static GymListDatabase database;
        public static GymListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   GymListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GymList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }
    }
}
