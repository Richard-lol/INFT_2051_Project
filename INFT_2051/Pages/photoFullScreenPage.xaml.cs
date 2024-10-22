using INFT_2051.Models;
using INFT_2051.ViewModels;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace INFT_2051.Pages
{
    public partial class photoFullScreenPage : ContentPage
    {
        CarViewModel viewModel;
        public string ImageFilePath { get; set; }
        public photoFullScreenPage(String carViewModel)
        {
            InitializeComponent();

            //viewModel = new CarViewModel();
            //BindingContext = viewModel;
            ImageFilePath = carViewModel;
            BindingContext = this;

        }
        private async void Settings_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Options", "Cancel", null, "Add to Album", "Remove from Album", "Delete Photo");
            Debug.WriteLine("Action: " + action);
            if (action == "Delete Photo")
            {
                var carModel = BindingContext as CarModel;
                viewModel.DeleteCar(carModel);
            }
        }


    }
}