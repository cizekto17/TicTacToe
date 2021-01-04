using System;
using System.IO;
using TicTacToe.Dabase;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class App : Application
    {

        static Dabase1 database;

        public static Dabase1 Database
        {
            get
            {
                if (database == null)
                {
                    database = new Dabase1(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TicTacToe.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

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
