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

            viewModel = new CarViewModel();
      
            carModel = model;
            this.BindingContext = carModel;
        }
        
        //Load "Model" dropdown based on "Make" drop down choice
        private async void CarMakeChosen(object sender, EventArgs e)
        {
            var selectedMake = CharacterClassPicker.SelectedItem?.ToString();
            if (selectedMake!=null)
            {
                
                System.Diagnostics.Debug.WriteLine("Make selected: " + selectedMake);

                //Parse selected car make and load car models (names) from API
                await NameDetails.LoadCarNames(selectedMake);

                //Update the dropdown with the loaded models (names)
                CarModelPicker.ItemsSource = NameDetails.Names;
                
            }
        }

    private void CollectionButton_Clicked(object sender, EventArgs e)
        {
            //Bind data to car model
            carModel.Make = CharacterClassPicker.SelectedItem?.ToString();
            carModel.Name = CarModelPicker.SelectedItem?.ToString();
            carModel.Location = LocationEntry.Text;
            carModel.AlbumName = AlbumPicker.SelectedItem?.ToString();


            //Save the car using the ViewModel
            viewModel.SaveCar(carModel);

            //Navigate to collection page 
            Navigation.PushAsync(new CollectionPage());
        }
    }
}