using Proyecto.Models;
using Newtonsoft.Json;
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
    public partial class PostMembresia : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/tipoMembresia";
        public PostMembresia()
        {
            InitializeComponent();
        }

        private async Task crearMembresiaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                tipo_membresia x = new tipo_membresia()
                {
                    descripcion = descripcionForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tipo_membresia contenido = JsonConvert.DeserializeObject<tipo_membresia>(content);
                    resultado.Text = "Membresia Creada: id = " + contenido.id_tipo_membresia + " con Descripción = " + contenido.descripcion;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                descripcionForm.Text = "";
               

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearMembresiaAsync();
        }
    }
}