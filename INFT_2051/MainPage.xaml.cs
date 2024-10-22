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

        MakeDetails.LoadCarMakes();
    }

    private void CameraButton_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new CameraPage());
       
    }
    private void CollectionButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectionPage());
    }
    private void GarageButton_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new GaragePage());

    }
    private void Settings_Clicked(object sender, EventArgs e)
    {
         Navigation.PushAsync(new SettingsFlyoutPage());
    }

}

