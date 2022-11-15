using Ejercicio2_2.Modelo;
using Ejercicio2_2.Vista;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista());
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                Message("Advertencia", "Debe ingresar el nombre");
                return;
            }
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                Message("Advertencia", "Debe ingresar la descripcion");
                return;
            }
            if (signatureView.IsBlank)
            {
                Message("Advertencia", "Debe ingresar su firma");
                return;
            }
            int responce = await GuardarFirma();
            if (responce > 0)
            {
                Message("Satisfactorio", "Los datos se han guardado exitosamente");
                ClearFields();
            } else Message("Advertencia", "A ocurrido un error al guardar los datos");
        }

        private async Task<int> GuardarFirma()
        {
            try
            {
                Stream bitmap = await signatureView.GetImageStreamAsync(SignatureImageFormat.Png);
                var memoryStream = (MemoryStream)bitmap;
                byte[] data = memoryStream.ToArray();

                var Storagepath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/E2";

                if (!Directory.Exists(Path.Combine(Storagepath, "ACH")))
                {
                    Directory.CreateDirectory(Path.Combine(Storagepath, "ACH"));
                }
                string path = System.IO.Path.Combine(Storagepath.ToString(), "firma-" + DateTime.Now.ToString("hh:mm:ss") + ".png");
                System.IO.File.WriteAllBytes(path, data);

                var datos = new MFirma
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text,
                    firma = path
                };
                return await App.Database.GuardarDatos(datos);

            } catch(Exception ex) {
                return 0;
            }
        }

        public async void Message(string title, string message)
        {
            await DisplayAlert(title, message, "Ok");
        }

        public void ClearFields()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            signatureView.Clear();
        }
    }
}
