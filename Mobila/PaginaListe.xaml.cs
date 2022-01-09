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
    public partial class PaginaListe : ContentPage
    {
        public PaginaListe()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetAntrenorsAsync();
        }

        async void OnAntrenorAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Liste
            {
                BindingContext = new Antrenor()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Liste
                {
                    BindingContext = e.SelectedItem as Antrenor
                });
            }

        }

    }
}