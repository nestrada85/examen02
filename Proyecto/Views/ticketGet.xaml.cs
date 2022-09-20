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
    public partial class ticketGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/ticket";
        public ticketGet()
        {
            InitializeComponent();
            getTicket();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getTicket();
        }

        private async Task getTicket()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<ticket> contenido = JsonConvert.DeserializeObject<List<ticket>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idTicket: " + contenido[i].id_ticket + " Numero de silla: " + contenido[i].numero_silla + " Fila: " + contenido[i].fila + "Valor de entrada: " + contenido[i].precio + "Id del Evento: " + contenido[i].id_evento + "\n" + "\n" ;

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Tickets";
                }




            }
        }
    }
}