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
    public partial class CompraPut : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/compra";
        public CompraPut()
        {
            InitializeComponent();
        }

        private async Task actualizarPersonaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                compra x = new compra()
                {
                    id_compra = int.Parse(idForm.Text),
                    id_membresia = idMembresiaForm.Text,
                    id_ticket = idTicketForm.Text,
                    fecha_compra = fechaCompraForm.Text
                };
                url = url + "/" + x.id_compra; // mandamos de parametro de url del id a modificar
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
                idMembresiaForm.Text = "";
                idTicketForm.Text = "";
                fechaCompraForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarPersonaAsync();
        }

        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}