using MauiDnd.Models;

namespace MauiDnd.Views.GameView;

public partial class ViewGame : ContentPage
{
    public Game Game { get; set; }
    public Character Character { get; set; }    
    public LocalisationPlayer LocalisationPlayer { get; set; }  
    public List<SpawnPoint> SpawnPoints { get; set; }
    public ViewGame(Game game,Character character)
	{
		InitializeComponent();
        Game = game;
        Character = character;
        InitGrid();
    }

    private async void OnInvisibleButtonClicked(object sender, EventArgs e)
    {
        //modif la position du joueur pour le mettre a coté du monstre
        DndClient client = DndClient.Client();

        if (sender is ImageButton button)
        {
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            await client.SetLocationOfPlayerAsync(Game.Id, Character.Id, row - 1 , column -  1) ;
            ClearGrid();
            await InitGrid();
            SpawnPoint sp = SpawnPoints.Where(sp => sp.X == row && sp.Y == column && sp.GameId == Game.Id).FirstOrDefault();

            DndClient dndClient = DndClient.Client();
            Monster monster = await client.GetMonster(sp.InGameMonster.MonsterId);
            if (!sp.IsActive || sp.InGameMonster.Hp == 0)
            {
                await DisplayAlert("error", "Le monstre est déja mort", "error");
                return;
            }
            var InventoryBoxs = await dndClient.GetInventoryAsync(Character.Id);
            if(InventoryBoxs == null)
            {
                await DisplayAlert("error", "impossible d'attaquer sans stuff équipé", "error");
                return;
            }
            var inventoryWeapon = InventoryBoxs.FirstOrDefault(box => box.IStuffType == "Weapon" && box.IsEquiped == true);
            if (inventoryWeapon == null)
            {
                await DisplayAlert("error", "impossible d'attaquer sans arme équipé", "error");
                return;
            }

            var weapon = await dndClient.GetWeaponAsync(inventoryWeapon.Id);
            var inventoryArmor = InventoryBoxs.FirstOrDefault(box => box.IStuffType == "Armor" && box.IsEquiped == true);

            if (inventoryArmor == null)
            {
                await DisplayAlert("error", "impossible d'attaquer sans armure équipée", "error");
                return;
            }
            var armor = await dndClient.GetArmorAsync(inventoryArmor.Id);
            await Navigation.PushAsync(new FightView(Character, Game, monster, sp,inventoryWeapon,weapon,inventoryArmor,armor));


        }
    }
    private void ClearGrid()
    {
        try
        {
            invisibleButtonsGrid.Children.Clear();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
    private async Task InitGrid()
    {
        try { 
            SpawnPoints = Game.SpawnPoints.Where(s => s.IsActive == true).ToList();
            //Set monster on map
            foreach (SpawnPoint spawnPoint in SpawnPoints) {
                var button = new ImageButton
                {
                    Source = "monster.png"
                };

                Grid.SetRow(button, spawnPoint.X);
                Grid.SetColumn(button, spawnPoint.Y);

                button.Clicked += OnInvisibleButtonClicked;

                invisibleButtonsGrid.Children.Add(button);
            }
            //set player on map

            DndClient client = DndClient.Client();
            LocalisationPlayer = Game.LocalisationPlayers.FirstOrDefault(lp => lp.Character.Id == Character.Id);
            if (LocalisationPlayer == null)
            {
                await client.PostCharacterToGame(Character.Id, Game.Id);
            }
            LocalisationPlayer = await client.GetLocalisationPlayer(Character.Id, Game.Id);
            var playerButton = new ImageButton
            {
                Source = "amogus.png"
            };

            Grid.SetRow(playerButton, LocalisationPlayer.X );
            Grid.SetColumn(playerButton, LocalisationPlayer.Y);

            playerButton.Clicked += OnInvisibleButtonClicked;

            invisibleButtonsGrid.Children.Add(playerButton);
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
    }


}