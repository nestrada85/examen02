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
    public partial class TipoEventoDelete : ContentPage
    {
        private string url = "https://desfrlopez.me/nestrada2/api/tipoEvento";
        public TipoEventoDelete()
        {
            InitializeComponent();
        }

        private async Task borrarTipoEventoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url = url + "/" + idForm.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    tipo_evento contenido = JsonConvert.DeserializeObject<tipo_evento>(content);

                    resultado.Text = "Evento Borrada";
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
            borrarTipoEventoAsync();
        }
    }
}