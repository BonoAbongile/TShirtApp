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
public partial class TShirtOrderPage : ContentPage
{
    public TShirtOrderPage()
    {
        InitializeComponent();
    }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tShirtItem = new TShirtItem();

            BindingContext = tShirtItem;
        }


        private async void saveBtn_Clicked(object sender, EventArgs e)
        {
            var tshirtItem = (TShirtItem)BindingContext;
            await App.Database.SaveItemAsync(tshirtItem);

            await Navigation.PushAsync(new OrderedTShirtsPage());
           // await Navigation.PopAsync();

        }

        private async void deleteBtn_Clicked(object sender, EventArgs e)
        {
            var tshirtItem = (TShirtItem)BindingContext;
            await App.Database.DeleteItemAsync(tshirtItem);
            await Navigation.PushAsync(new OrderedTShirtsPage());

           // await Navigation.PopAsync();
            // await App.Database.SaveItemAsync(tshirtItem);
        }
    }
}