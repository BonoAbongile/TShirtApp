using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        private async void apiBtn_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var url = "http://10.0.2.2:5001/products";

            var product = new TShirtItem
            {
                Name = "xamarin",
                Color = "Purple"
        };
           

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


            try
            {
                var response = await client.PostAsync(url, content);
            }
            catch(Exception ex)
            {
                await DisplayAlert("Expection", ex.Message, "Ok");
            }
        }
    }
}