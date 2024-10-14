using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages
{
    public partial class CarTagPage : ContentPage
    {
        CarViewModel viewModel;
        CarModel carModel;

        public CarTagPage()
        {
            InitializeComponent();

            // Initialize the CarViewModel
            viewModel = new CarViewModel();

            // Initialize a new CarModel object
            carModel = new CarModel();

            // Set the BindingContext of the page to the CarModel
            this.BindingContext = carModel;
        }

        private void CollectionButton_Clicked(object sender, EventArgs e)
        {
            // Ensure data is bound from the UI correctly into carModel
            carModel.Make = CharacterClassPicker.SelectedItem?.ToString();
            carModel.Location = LocationEntry.Text;
            carModel.AlbumName = AlbumPicker.SelectedItem?.ToString();

            // Save the car using the ViewModel
            viewModel.SaveCar(carModel);

            // Navigate to the collection page after saving
            Navigation.PushAsync(new CollectionPage());
        }
    }
}