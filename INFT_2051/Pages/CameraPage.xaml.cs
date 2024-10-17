using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CameraPage : ContentPage
{
    CarViewModel viewModel;
    private CarModel carModel;

    public CameraPage()
	{
        carModel = new CarModel();
        InitializeComponent();
	}
    private void CarTagPage_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new CarTagPage());
        Navigation.PushAsync(new CarTagPage(carModel));
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
                carModel.ImageFilePath = photo.FullPath;
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
            carModel.ImageFilePath = photo.FullPath;
        }
        
    }

}