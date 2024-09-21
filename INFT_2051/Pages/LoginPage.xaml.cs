namespace INFT_2051.Pages;

public partial class LoginPage : ContentPage
{
	private static string EMAIL_KEY = "email_key", PASSWORD_KEY = "password_key", REMEMBER_ME_KEY = "remember_key";

	public static string Token = null;
	public LoginPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        EmailEntry.Text = Preferences.Default.Get<string>(EMAIL_KEY, "");
        PasswordEntry.Text = Preferences.Default.Get<string>(PASSWORD_KEY, "");
        RememberMeCheckbox.IsChecked = Preferences.Default.Get<bool>(REMEMBER_ME_KEY, false);
    }

	private void LoginButton_Clicked(object sender, EventArgs e)
	{
		if (RememberMeCheckbox.IsChecked)
		{
            Preferences.Set(EMAIL_KEY, EmailEntry.Text);
            Preferences.Set(PASSWORD_KEY, PasswordEntry.Text);
            Preferences.Set(REMEMBER_ME_KEY, true);
        }
		else
		{
            Preferences.Default.Remove(EMAIL_KEY);
            Preferences.Default.Remove(PASSWORD_KEY);
            Preferences.Default.Remove(REMEMBER_ME_KEY);
        }

		Token = "justafaketoken";

		Navigation.PopModalAsync();
	}
}