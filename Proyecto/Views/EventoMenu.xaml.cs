using System;
using Proyecto.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoMenu : ContentPage
    {
        public EventoMenu()
        {
            InitializeComponent();
        }

        private async void getEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventoGet());
        }

        private async void postEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventoPost());
        }

        private async void putEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventoPut());
        }

        private async void deleteEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventoDelente());
        }
    }
}