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
    public partial class TicketPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/ticket";
        public TicketPost()
        {
            InitializeComponent();
        }

        private async Task crearTicketAsync()
        {
            using (var httpClient = new HttpClient())
            {

                ticket x = new ticket()
                {
                    numero_silla = sillaForm.Text,
                    fila = filaForm.Text,
                    precio = precioForm.Text,
                    id_evento = idEventoForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ticket contenido = JsonConvert.DeserializeObject<ticket>(content);
                    resultado.Text = "Ticket Creada = " + contenido.id_ticket + " numero de silla = " + contenido.numero_silla + " en la fila = " + contenido.fila + " y con Id de evento = " + contenido.id_evento;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                sillaForm.Text = "";
                filaForm.Text = "";
                precioForm.Text = "";
                idEventoForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearTicketAsync();
        }
    }
}