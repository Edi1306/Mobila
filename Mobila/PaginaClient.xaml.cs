using Mobila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobila
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaClient : ContentPage
    {
        Antrenor A;
        public PaginaClient(Antrenor alista)
        {
            InitializeComponent();
            A = alista;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var client = (Client)BindingContext;
            await App.Database.SaveClientAsync(client);
            listView.ItemsSource = await App.Database.GetClientsAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var client = (Client)BindingContext;
            await App.Database.DeleteClientAsync(client);
            listView.ItemsSource = await App.Database.GetClientsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Client c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Client;
                var lp = new ListaClient()
                {
                    AntrenorID = A.ID,
                    ClientID = c.ID
                };
                await App.Database.SaveListaClientAsync(lp);
                c.ListaClienti = new List<ListaClient> { lp };

                await Navigation.PopAsync();
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetClientsAsync();
        }
    }
}