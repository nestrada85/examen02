using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoPut : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/evento";
        public EventoPut()
        {
            InitializeComponent();
        }

        private async Task actualizarEventoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                evento x = new evento()
                {
                    id_evento = int.Parse(idForm.Text),
                    nombre_evento = nombreForm.Text,
                    fecha = fechaForm.Text,
                    id_tipo_evento = idEventoForm.Text,
                };
                url = url + "/" + x.id_evento; // mandamos de parametro de url del id a modificar
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
                nombreForm.Text = "";
                fechaForm.Text = "";
                idEventoForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarEventoAsync();
        }

        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}