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
    public partial class TicketPut : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/ticket";
        public TicketPut()
        {
            InitializeComponent();
        }

        private async Task actualizarTicktAsync()
        {
            using (var httpClient = new HttpClient())
            {

                ticket x = new ticket()
                {
                    id_ticket = int.Parse(idForm.Text),
                    numero_silla = sillaForm.Text,
                    fila = filaForm.Text,
                    precio = precioForm.Text,
                    id_evento = idEventoForm.Text
                };
                url = url + "/" + x.id_ticket; // mandamos de parametro de url del id a modificar
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
                sillaForm.Text = "";
                filaForm.Text = "";
                precioForm.Text = "";
                idEventoForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarTicktAsync();
        }

        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}