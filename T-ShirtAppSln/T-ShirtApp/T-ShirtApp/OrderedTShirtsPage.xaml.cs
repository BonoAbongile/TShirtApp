using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_ShirtApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class OrderedTShirtsPage : ContentPage
{
        public List<TShirtItem> OrderedTShirts { get; set; }


    public OrderedTShirtsPage()
    {
        InitializeComponent();
    }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            OrderedTShirts = await App.Database.GetItemsAsync();

            BindingContext = this;
        }
          
        private async void viewItem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TShirtOrderPage
                {
                    BindingContext = e.SelectedItem as TShirtItem
                });
            }

        }

        private async void addItem_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new TShirtOrderPage
                {
                    BindingContext = new TShirtItem()
                });
        }
    }
}