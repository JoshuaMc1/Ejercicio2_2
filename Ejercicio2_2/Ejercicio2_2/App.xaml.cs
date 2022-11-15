using Ejercicio2_2.Controlador;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2
{
    public partial class App : Application
    {
        static CFirma database;

        public static CFirma Database
        {
            get
            {
                if (database == null)
                {
                    database = new CFirma(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbDatos.db3"));
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
