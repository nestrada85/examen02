using Proyecto.Models;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoEventoPut : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/tipoEvento";
        public TipoEventoPut()
        {
            InitializeComponent();
        }

        private async Task actualizarTipoEventoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                tipo_evento x = new tipo_evento()
                {
                    id_tipo_evento = int.Parse(idForm.Text),
                    descripcion = descripcionForm.Text
                };
                url = url + "/" + x.id_tipo_evento; // mandamos de parametro de url del id a modificar
                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actulizacion Exitosa";
                }
                else
                {
                    resultado.Text = "Actulizacion Fallida";
                }

                idForm.Text = "";
                descripcionForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarTipoEventoAsync();
        }

        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}