using INFT_2051.ViewModels;
using INFT_2051.Models;


namespace INFT_2051.Pages
{
    public partial class CollectionPage : ContentPage
    {
        CarViewModel viewModel;

        public CollectionPage()
        {
            InitializeComponent();

            // Initialize the CarViewModel and set the BindingContext
            viewModel = new CarViewModel();
            BindingContext = viewModel;

            // Load the saved cars into the collection view or list
            LoadCars();
        }

        private void LoadCars()
        {
            // Get the list of saved cars from the ViewModel
            var cars = viewModel.Cars;

            // Bind the list to the CollectionView or ListView
            CarsListView.ItemsSource = cars;  // Assuming CarsListView is your list control
        }
    }
}

