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
    public partial class CompraPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/compra";
        public CompraPost()
        {
            InitializeComponent();
        }

        private async Task crearCompraAsync()
        {
            using (var httpClient = new HttpClient())
            {

                compra x = new compra()
                {
                    id_membresia = idMembresiaForm.Text,
                    id_ticket = idTicketForm.Text,
                    fecha_compra = fechaCompraForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    compra contenido = JsonConvert.DeserializeObject<compra>(content);
                    resultado.Text = "Compora Creada: id = " + contenido.id_compra + " con id Membresia = " + contenido.id_membresia + " id Tichet = " + contenido.id_ticket + " con Fecha = " + contenido.fecha_compra;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                idMembresiaForm.Text = "";
                idTicketForm.Text = "";
                fechaCompraForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearCompraAsync();
        }
    }
}