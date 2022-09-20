using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompraMenu : ContentPage
    {
        public CompraMenu()
        {
            InitializeComponent();
        }
        private async void getCompra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraGet());
        }

        private async void postCompra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraPost());
        }

        private async void putCompra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraPut());
        }

        private async void delCompra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompraDelete());
        }
    }
}