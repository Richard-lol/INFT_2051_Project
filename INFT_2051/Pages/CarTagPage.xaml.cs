using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CarTagPage : ContentPage
{
    CarViewModel viewModel;
    public CarTagPage()
	{
		InitializeComponent();

        BindingContext = viewModel = new CarViewModel();
    }
}