using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CameraPage : ContentPage
{
  

    public CameraPage()
	{
    
        InitializeComponent();
	}
    private void CarTagPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CarTagPage());
    }
    private async void PhotoButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // Check if the device supports taking photos
            if (MediaPicker.Default.IsCaptureSupported)
            {
                // Capture a photo using the camera
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // Save the captured photo to a temporary file
                    var stream = await photo.OpenReadAsync();
                    PhotoCapture.Source = ImageSource.FromStream(() => stream);
                }
            }
            else
            {
                await DisplayAlert("Camera Unavailable", "The device does not support taking photos.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that might occur
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

}