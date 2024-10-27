using INFT_2051.Models;
using INFT_2051.Pages;

namespace INFT_2051;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        if (LoginPage.Token == null)
        {
            Dispatcher.Dispatch(async () =>
                await Navigation.PushModalAsync(new LoginPage(), false)
            );
        }
        //Load car makes from API
        MakeDetails.LoadCarMakes();
    }
    //Navigate to Camera page
    private void CameraButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CameraPage());
    }
    //Navigate to collection page
    private void CollectionButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectionPage());
    }
    //Navigate to garage page
    private void GarageButton_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new GaragePage());

    }
    //Settings meatball
    private void Settings_Clicked(object sender, EventArgs e)
    {
         Navigation.PushAsync(new SettingsFlyoutPage());
    }

    private async void wallpaperButtonClicked(object sender, EventArgs e)
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

