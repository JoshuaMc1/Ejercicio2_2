using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            txtListaFirmas.ItemsSource = await App.Database.ObtenerDatos();
            base.OnAppearing();
        }
    }
}