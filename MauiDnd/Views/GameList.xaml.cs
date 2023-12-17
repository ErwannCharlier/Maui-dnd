namespace MauiDnd.Views;
using MauiDnd.Models;
using MauiDnd.ViewModel;
using MauiDnd.Views.GameView;

public partial class GameList : ContentPage
{
    public GameList()
    {
        InitializeComponent();
        LoadGamesAsync();
    }

    private async Task LoadGamesAsync()
    {
        DndClient dndClient = DndClient.Client();
        List<Models.Game> games = await dndClient.GetGamesAsync();

        gamesCollectionView.ItemsSource = games.Select(GameViewModel.GameToVM).ToList();
    }
    private async void AddGame_Clicked(object sender, EventArgs e)
    {
        DndClient client = DndClient.Client();
        await client.PostGameAsync();
        await Navigation.PushAsync(new GameList());
    }


    private void DeleteGame_Tapped(object sender, EventArgs e)
    {
        //todo
    }

    private async Task<Character> DisplayCharacterSelectionDialog()
    {
        DndClient client = DndClient.Client();
        List<Character> characters = await client.GetCharactersOfUserAsync();
        List<CharacterVM> characterVMs = characters.Select(CharacterVM.CharacterToVM).ToList();

        List<string> characterNames = characterVMs.Select(c => c.IdText).ToList();

        string selectedCharacterName = await DisplayActionSheet("Sélectionnez un personnage", "Annuler", null, characterNames.ToArray());

        CharacterVM selectedCharacter = characterVMs.FirstOrDefault(c => c.IdText == selectedCharacterName);

        return selectedCharacter.Character;
    }

    private async void Play_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var gameVM = button?.BindingContext as GameViewModel;
        Character selectedCharacter = await DisplayCharacterSelectionDialog();
        if (selectedCharacter != null && gameVM != null)
        {
            await Navigation.PushAsync(new ViewGame(gameVM.Game, selectedCharacter));
            
        }

    }

}