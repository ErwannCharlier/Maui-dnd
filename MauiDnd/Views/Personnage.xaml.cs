namespace MauiDnd.Views;
using MauiDnd.Models;
using MauiDnd.ViewModel;
using MauiDnd.Views.CrurdCharacter;
using Newtonsoft;
using Newtonsoft.Json;

public partial class Personnage : ContentPage
{
    public Personnage()
    {
        InitializeComponent();
        LoadCharactersAsync();

    }

    private async Task LoadCharactersAsync()
    {
        DndClient dndClient = DndClient.Client();
        List<Character> characters = await dndClient.GetCharactersOfUserAsync();
        // Vérifiez si la liste de personnages n'est pas nulle avant de l'affecter à la source de la CollectionView
        if (characters != null)
        {
            personnagesCollectionView.ItemsSource = characters.Select(CharacterVM.CharacterToVM).ToList(); 
        }
        else
        {
            // Gérez le cas où la liste de personnages est nulle
            throw new NotImplementedException();
        }
    }    

    private async void CroixLabel_Tapped(object sender, EventArgs e)
    {
        DndClient dndClient = DndClient.Client();

        Label croixLabel = (Label)sender;

        // Obtenez l'objet CharacterVM du paramètre de commande
        var characterVM = croixLabel.BindingContext as CharacterVM;

        if (characterVM != null)
        {
            await dndClient.DeleteCharacter(characterVM.Character.Id);
            await LoadCharactersAsync();
        }

    }

    private void Modifier_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var characterVM = button?.BindingContext as CharacterVM;

        if (characterVM != null)
        {
            Navigation.PushAsync(new EditCharacter(characterVM.Character));

        }

    }
    private void OnCollectionViewScrolled(object sender, EventArgs e)
    {
    }    
    private async void AddCharacter_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCharacter());

    }


}

