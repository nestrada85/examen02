using Proyecto.Views;
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
    public partial class MembresiaMenu : ContentPage
    {
        public MembresiaMenu()
        {
            InitializeComponent();
        }

        private async void getMem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetMembresia());
        }

        private async void postMem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostMembresia());
        }

        private async void putMem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PutMembresia());
        }

        private async void delMem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembresiaDelete());
        }
    }
}