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
    public partial class TipoEventoMenu : ContentPage
    {
        public TipoEventoMenu()
        {
            InitializeComponent();
        }

        private async void getTipoEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoEventoGet());
        }
        private async void postTipoEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoEventoPost());
        }
        private async void putTipoEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoEventoPut());
        }
        private async void delTipoEvento(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoEventoDelete());
        }
    }
}