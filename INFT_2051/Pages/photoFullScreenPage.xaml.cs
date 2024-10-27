using INFT_2051.Models;
using INFT_2051.ViewModels;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace INFT_2051.Pages
{
    public partial class photoFullScreenPage : ContentPage
    {

        public CarModel Car { get; set; }
        public photoFullScreenPage(CarModel carViewModel)
        {
            InitializeComponent();

            Car = carViewModel;
            BindingContext = Car;

        }
        //Settings meatball 
        private async void Settings_Clicked(object sender, EventArgs e)
        {
            //Handle choices
            string action = await DisplayActionSheet("Options", "Cancel", null, "Delete Photo");
            Debug.WriteLine("Action: " + action);
            //If delete photo is chosen, delete the car from the database
            if (action == "Delete Photo")
            {
                CarViewModel.Current.DeleteCar(Car);
                await Navigation.PopAsync();

            }
        }


    }
}