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
    public partial class PersonaPut : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/persona";
        public PersonaPut()
        {
            InitializeComponent();
        }

        private async Task actualizarPersonaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                persona x = new persona()
                {
                    id_membresia = int.Parse(idForm.Text),
                    nombre_persona = nombreForm.Text,
                    correo_electronico = correoForm.Text,
                    id_tipo_membresia = idMembresiaForm.Text
                };
                url = url + "/" + x.id_membresia; // mandamos de parametro de url del id a modificar
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
                nombreForm.Text = "";
                correoForm.Text = "";
                idMembresiaForm.Text = "";


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