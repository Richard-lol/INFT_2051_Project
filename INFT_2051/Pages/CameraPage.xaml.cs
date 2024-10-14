using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CameraPage : ContentPage
{
    CarViewModel viewModel;

    public CameraPage()
	{
        BindingContext = viewModel = new CarViewModel();
        InitializeComponent();
	}
    private void CarTagPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CarTagPage());
    }
    private async void PhotoButtonClicked(object sender, EventArgs e)
    {
        
        if (MediaPicker.Default.IsCaptureSupported)
        {
          
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
    
                var stream = await photo.OpenReadAsync();
                PhotoCapture.Source = ImageSource.FromStream(() => stream);
            }
        }    

    }
    private async void UploadButtonClicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync();

        if (photo != null)
        {
            
            var stream = await photo.OpenReadAsync();
            PhotoCapture.Source = ImageSource.FromStream(() => stream);
        }
        
    }

}