using Newtonsoft.Json;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetMembresia : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/tipoMembresia";
        public GetMembresia()
        {
            InitializeComponent();
            getMembresia();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getMembresia();
        }

        private async Task getMembresia()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<tipo_membresia> contenido = JsonConvert.DeserializeObject<List<tipo_membresia>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idTipoMembresia: " + contenido[i].id_tipo_membresia + " descripcion: " + contenido[i].descripcion + "\n" + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Membresias";
                }




            }
        }
    }
}