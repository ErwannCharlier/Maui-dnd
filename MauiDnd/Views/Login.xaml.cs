namespace MauiDnd.Views;
using Microsoft.Maui.Controls;


public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private void OnValidateButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}