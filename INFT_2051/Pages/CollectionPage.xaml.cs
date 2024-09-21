using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CollectionPage : ContentPage
{
	CarViewModel viewModel;
	public CollectionPage()
	{
		BindingContext = viewModel = new CarViewModel();

		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Cars");
    }
}