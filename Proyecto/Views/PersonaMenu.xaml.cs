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
    public partial class PersonaMenu : ContentPage
    {
        public PersonaMenu()
        {
            InitializeComponent();
        }

        private async void getPersona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaGet());
        }

        private async void postPersona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaPost());
        }

        private async void putPersona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaPut());
        }

        private async void delPersona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaDelete());
        }
    }
}