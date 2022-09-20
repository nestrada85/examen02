using Proyecto.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proyecto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void membresia(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembresiaMenu());
        }

        private async void persona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaMenu());
        }

        private async void tipoEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoEventoMenu());
        }
        private async void evento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventoMenu());
        }
        private async void ticket(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketMenu());
        }
        private async void compra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraMenu());
        }

        private async void serviceEspecial(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiceEspecial());
        }
    }
}
