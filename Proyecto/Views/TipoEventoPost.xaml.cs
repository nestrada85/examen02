using Proyecto.Models;
using Newtonsoft.Json;
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
    public partial class TipoEventoPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/tipoEvento";
        public TipoEventoPost()
        {
            InitializeComponent();
        }

        private async Task crearTipoEventoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                tipo_evento x = new tipo_evento()
                {
                    descripcion = descripcionForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tipo_evento contenido = JsonConvert.DeserializeObject<tipo_evento>(content);
                    resultado.Text = "Tipo de Evento Creada: id = " + contenido.id_tipo_evento + " con Descripción = " + contenido.descripcion;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                descripcionForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearTipoEventoAsync();
        }
    }
}