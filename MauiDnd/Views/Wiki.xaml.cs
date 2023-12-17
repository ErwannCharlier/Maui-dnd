namespace MauiDnd.Views;
using MauiDnd.Models;
using MauiDnd.ViewModel;

public partial class Wiki : ContentPage
{
	public Wiki()
	{
		InitializeComponent();
   
	}

    private void RechercheClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.CommandParameter is string choice)
        {
            Navigation.PushAsync(new Recherche(int.Parse(choice)));
        }
    }




}