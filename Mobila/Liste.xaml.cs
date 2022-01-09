using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobila.Models;

namespace Mobila
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Liste : ContentPage
    {
        public Liste()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (Antrenor)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveAntrenorAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Antrenor)BindingContext;
            await App.Database.DeleteAntrenorAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new PaginaClient((Antrenor)this.BindingContext)
            {
                BindingContext = new Client()
            });

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Antrenor)BindingContext;

            listView.ItemsSource = (System.Collections.IEnumerable)await App.Database.GetAntrenorAsync(shopl.ID);
        }

    }
}