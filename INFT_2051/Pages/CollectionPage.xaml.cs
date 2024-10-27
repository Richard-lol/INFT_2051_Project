using INFT_2051.ViewModels;
using INFT_2051.Models;
using System.Diagnostics;


namespace INFT_2051.Pages
{
    public partial class CollectionPage : ContentPage
    {
        CarViewModel viewModel;

        public CollectionPage()
        {
            InitializeComponent();

            viewModel = new CarViewModel();

            BindingContext = viewModel;
        }
        //Refresh the cars collection to ensure deleted items are not shown once they are deleted
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApplyFilters();  
        }
        //Navigate to the Fullscreen Image Page
        private void OnImageTapped(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;
            var carViewModel = imageButton?.CommandParameter as CarModel;
            Navigation.PushAsync(new photoFullScreenPage(carViewModel));
        }
        //Navigate to main page
        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

    }

}

