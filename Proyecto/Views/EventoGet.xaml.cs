using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto.Models;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/evento";
        public EventoGet()
        {
            InitializeComponent();
            getEvento();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getEvento();
        }

        private async Task getEvento()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<evento> contenido = JsonConvert.DeserializeObject<List<evento>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idEvento: " + contenido[i].id_evento + " Nombre: " + contenido[i].nombre_evento + " fecha: " + contenido[i].fecha + " IdTipoEvento: " + contenido[i].id_tipo_evento + "\n" + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Evento";
                }




            }
        }
    }
}