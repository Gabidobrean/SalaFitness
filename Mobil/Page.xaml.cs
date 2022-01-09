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
    public partial class GymPage : ContentPage
    {
        AbonamenteList rl;
        public GymPage(AbonamenteList rlist)
        {
            InitializeComponent();
            rl = rlist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var Gym = (Antrenori)BindingContext;
            await App.Database.SaveGymAsync(Gym);
            listView.ItemsSource = await App.Database.GetGymsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var Gym = (Antrenori)BindingContext;
            await App.Database.DeleteGymAsync(Gym);
            listView.ItemsSource = await App.Database.GetGymsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetGymsAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Antrenori p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Antrenori;
                var lp = new Cursuri()
                {
                    ID = rl.ID,
                    Denumire = p.ID.ToString()
                };
                await App.Database.SaveListGymAsync(lp);
                p.AntrenoriList = new List<Cursuri> { lp };

                await Navigation.PopAsync();
            }
        }
    }
}