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
    public partial class TicketMenu : ContentPage
    {
        public TicketMenu()
        {
            InitializeComponent();
        }

        private async void getTicket(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ticketGet());
        }

        private async void postTicket(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketPost());
        }

        private async void putTicket(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketPut());
        }

        private async void delTicket(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketDelete());
        }
    }
}