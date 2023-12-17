namespace MauiDnd.Views.CrurdCharacter;

public partial class AddCharacter : ContentPage
{
	public AddCharacter()
	{
		InitializeComponent();
	}
    private async void GenerateRandomCharacter(object sender, EventArgs e)
    {
		DndClient dndClient = DndClient.Client();
		await dndClient.PostRandomCharacter();
        await Navigation.PushAsync(new Personnage());

    }

    private async void CreateCharacter(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCharacter());

    }
}