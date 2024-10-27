using INFT_2051.ViewModels;
using INFT_2051.Models;

namespace INFT_2051.Pages;

public partial class GaragePage : ContentPage
{
    CarViewModel viewModel;

    public GaragePage()
	{
		InitializeComponent();

        viewModel = new CarViewModel();
        
        BindingContext = viewModel;
    }
    //Upload photo
    private async void garageButtonClicked(object sender, EventArgs e)
    {
     
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();

            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                UploadImageButton.Source = ImageSource.FromStream(() => stream);
            }
        }
    }



}