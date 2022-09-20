using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Models;
using Newtonsoft.Json;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/evento";
        public EventoPost()
        {
            InitializeComponent();
        }

        private async Task crearEventoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                evento x = new evento()
                {
                    nombre_evento = nombreForm.Text,
                    fecha = fechaForm.Text,
                    id_tipo_evento = idEventoForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    evento contenido = JsonConvert.DeserializeObject<evento>(content);
                    resultado.Text = "Evento Creado: id = " + contenido.id_evento + " de nombre = " + contenido.nombre_evento + " con fecha = " + contenido.fecha + " y con Id Tipo de Evento = " + contenido.id_tipo_evento;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreForm.Text = "";
                fechaForm.Text = "";
                idEventoForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearEventoAsync();
        }
    }
}