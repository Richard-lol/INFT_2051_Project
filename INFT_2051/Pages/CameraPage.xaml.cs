using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CameraPage : ContentPage
{
    CharacterViewModel viewModel;

    public CameraPage()
	{
        BindingContext = viewModel = new CharacterViewModel();
        InitializeComponent();
	}

}