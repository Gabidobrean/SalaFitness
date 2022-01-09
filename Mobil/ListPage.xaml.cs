using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobil.Models;

namespace Mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (AbonamenteList)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveGymListAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (AbonamenteList)BindingContext;
            await App.Database.DeleteGymListAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GymPage((AbonamenteList)this.BindingContext)
            {
                BindingContext = new Antrenori()
            });

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var gym = (AbonamenteList)BindingContext;

            listView.ItemsSource = (System.Collections.IEnumerable)await App.Database.GetGymListAsync(gym.ID);
        }
    }
}