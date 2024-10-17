using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages
{
    public partial class CarTagPage : ContentPage
    {
        CarViewModel viewModel;
        CarModel carModel;

        public CarTagPage(CarModel model)
        {
            InitializeComponent();

            // Initialize the CarViewModel
            viewModel = new CarViewModel();

            // Initialize a new CarModel object
            //carModel = new CarModel();
            carModel = model;

            // Set the BindingContext of the page to the CarModel
            this.BindingContext = carModel;
        }
        //private void CarMakeChosen(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    System.Diagnostics.Debug.WriteLine(picker.SelectedItem);

        //    if (picker.SelectedItem != null)
        //    {
        //        var selectedModel = picker.SelectedItem?.ToString();
        //        System.Diagnostics.Debug.WriteLine(selectedModel);
        //        NameDetails.LoadCarNames(selectedModel);
        //    }
        //}

        private async void CarMakeChosen(object sender, EventArgs e)
        {
            var selectedMake = CharacterClassPicker.SelectedItem?.ToString();
            if (selectedMake!=null)
            {
                System.Diagnostics.Debug.WriteLine("Make selected: " + selectedMake);

                // Load car names asynchronously
                await NameDetails.LoadCarNames(selectedMake);

                // Update the picker with the loaded names
                CarModelPicker.ItemsSource = NameDetails.Names;
                CarModelPicker.SelectedItem = null;
            }
        }


private void CollectionButton_Clicked(object sender, EventArgs e)
        {
            // Ensure data is bound from the UI correctly into carModel
            carModel.Make = CharacterClassPicker.SelectedItem?.ToString();
            carModel.Location = LocationEntry.Text;
            carModel.AlbumName = AlbumPicker.SelectedItem?.ToString();
            carModel.Name = CarModelPicker.SelectedItem?.ToString();

            // Save the car using the ViewModel
            viewModel.SaveCar(carModel);

            // Navigate to the collection page after saving
            Navigation.PushAsync(new CollectionPage());
        }
    }
}