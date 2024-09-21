using INFT_2051.ViewModels;
using INFT_2051.Models;

namespace INFT_2051.Pages;

public partial class CarTagPage : ContentPage
{
    CarViewModel viewModel;
    public CarTagPage()
	{
		InitializeComponent();

        BindingContext = viewModel = new CarViewModel();

        

    }
    private void CollectionButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectionPage());
    }
}