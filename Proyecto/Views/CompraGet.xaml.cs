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
    public partial class CompraGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/compra";
        public CompraGet()
        {
            InitializeComponent();
            getCompra();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getCompra();
        }

        private async Task getCompra()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<compra> contenido = JsonConvert.DeserializeObject<List<compra>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idCompra: " + contenido[i].id_compra + " id Membresia: " + contenido[i].id_membresia + " Id Ticket: " + contenido[i].id_ticket + " Fecha Compra: " + contenido[i].fecha_compra + "\n" + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Compras";
                }




            }
        }
    }
}