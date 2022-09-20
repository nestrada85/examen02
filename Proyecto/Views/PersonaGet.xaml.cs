using Newtonsoft.Json;
using Proyecto.Models;
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
    public partial class PersonaGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/persona";
        public PersonaGet()
        {
            InitializeComponent();
            getPersona();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getPersona();
        }

        private async Task getPersona()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<persona> contenido = JsonConvert.DeserializeObject<List<persona>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "idMembresia: " + contenido[i].id_membresia + " Nombre: " + contenido[i].nombre_persona + " Correo: " + contenido[i].correo_electronico + " IdTipoMembresia: " + contenido[i].id_tipo_membresia + "\n" + "\n" ;

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