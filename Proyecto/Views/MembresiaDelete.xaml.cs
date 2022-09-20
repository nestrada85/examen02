using Proyecto.Models;
using Newtonsoft.Json;
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
    public partial class MembresiaDelete : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/tipoMembresia";
        public MembresiaDelete()
        {
            InitializeComponent();
        }

        private async Task borrarMembresiaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url = url + "/" + idForm.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    tipo_membresia contenido = JsonConvert.DeserializeObject<tipo_membresia>(content);

                    resultado.Text = "Membresia Borrada";
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                idForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            borrarMembresiaAsync();
        }
    }
}