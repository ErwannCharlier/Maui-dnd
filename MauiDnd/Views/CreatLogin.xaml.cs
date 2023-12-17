namespace MauiDnd.Views;

public partial class CreatLogin : ContentPage
{
	public CreatLogin()
	{
		InitializeComponent();
	}
    private void ValidationClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }

}