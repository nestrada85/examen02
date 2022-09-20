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
    public partial class ServiceEspecial : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/alumno2";
        public ServiceEspecial()
        {
            InitializeComponent();
            getServicio();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getServicio();
        }

        private async Task getServicio()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<servicio> contenido = JsonConvert.DeserializeObject<List<servicio>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idMembresia: " + contenido[i].id_membresia + "\n" + " Nombre: " + contenido[i].nombre_persona + "\n" + " TipoMem: " + contenido[i].Tipo_Membresia + "\n" +  " FechaCompra: " + contenido[i].fecha_compra + "\n" + " idTicket: " + contenido[i].id_ticket + "\n" + " Nsilla: " + contenido[i].Numero_silla + "\n" + " Fila: " + contenido[i].fila + "\n" + " Precio: " + contenido[i].precio + "\n" + " Nevento: " + contenido[i].nombre_evento + "\n" + " Fevento: " + contenido[i].fecha + "\n" + " Tevento: " + contenido[i].Tipo_Evento + "\n" + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Servicio";
                }




            }
        }
    }
}