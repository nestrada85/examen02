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
    public partial class PersonaPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/persona";
        public PersonaPost()
        {
            InitializeComponent();
        }

        private async Task crearPersonaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                persona x = new persona()
                {
                    nombre_persona = nombreForm.Text,
                    correo_electronico = correoForm.Text,
                    id_tipo_membresia = idMembresiaForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    persona contenido = JsonConvert.DeserializeObject<persona>(content);
                    resultado.Text = "Persona Creada: id = " + contenido.id_membresia + " de nombre = " + contenido.nombre_persona + " con Correo = " + contenido.correo_electronico + " y con Id Tipo de Membresia = " + contenido.id_tipo_membresia;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreForm.Text = "";
                correoForm.Text = "";
                idMembresiaForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearPersonaAsync();
        }
    }
}