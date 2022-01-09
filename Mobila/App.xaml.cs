using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobila.Data;
using System.IO;

namespace Mobila
{
    public partial class App : Application
    {
        static ListaAntrenori database;

        public static ListaAntrenori Database
        {
            get
            {
                if (database == null)
                {
                    database = new ListaAntrenori(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ListaAntrenori.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PaginaListe());

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
