using MauiDnd.Models;
using System;
using System.Text.RegularExpressions;

namespace MauiDnd.Views;

public partial class FightView : ContentPage
{
	public Character Character { get; set; }
    public Game Game { get; set; }
    public Monster Monster { get; set; }    
    //pv du monstre
    public SpawnPoint SpawnPoint { get; set; }
	public InventoryBox InventoryWeapon { get; set; }
    public Weapon Weapon { get; set; }
	public InventoryBox InventoryArmor { get; set; }
    public Armor Armor { get; set; }


    public FightView(Character character, Game game, Monster monster, SpawnPoint spawnPoint, InventoryBox inventoryWeapon, Weapon weapon, InventoryBox inventoryArmor, Armor armor)
	{
		InitializeComponent();
        Character = character;
        Game = game;
        Monster = monster;
        SpawnPoint = spawnPoint;
        InventoryWeapon = inventoryWeapon;
        Weapon = weapon;
        InventoryArmor = inventoryArmor;
        Armor = armor;
        Init();
    }

	public void Init()
	{

        MonsterImage.Source = ImageSource.FromUri(new Uri(Monster.Image));
        MonsterImage.Source = Monster.Image != "https://www.dnd5eapi.coundefined" ? ImageSource.FromUri(new Uri(Monster.Image)) : "monstre3.jpg";
        SwordButton.Source = InventoryWeapon.ImagePath; 

        ArmorButton.Source = InventoryArmor.ImagePath;
        int? pv = SpawnPoint.InGameMonster.Hp;
        MonsterNameLabel.Text = "pv:" + pv.ToString();
        

    }   

    private async void OnPlayButtonClicked(object sender, EventArgs e)
    {
        DndClient dndClient = DndClient.Client();
        //lancer les dés
        int dice = await dndClient.GetDice10();
        //calculer les dégats a envoyer (résultat dé + dégats de l'arme)
        int damage = dice;
        string regexPattern = @"(\d+d\d+)";
        Regex regex = new Regex(regexPattern);
        if(InventoryWeapon != null && Weapon.Damage != null) 
        { 
            //cherche quel dé et combien de fois il faut le lancé
            Match match = regex.Match(Weapon.Damage);
            if (match.Success)
            {
                int nbDice = int.Parse(Weapon.Damage[0].ToString());
                int diceType = int.Parse(Weapon.Damage[2].ToString());
                Random random = new Random();
                for (int i = 0; i < nbDice; i++)
                {
                    //ne call pas l'api pour que ce soit plus rapide
                    damage += random.Next(1, diceType);
                }

            }
        }
        //envoyer les dégats et en recevoir
        HttpResponseMessage message = await dndClient.Fight(Game.Id, Character.Id, SpawnPoint.InGameMonsterId, -damage);

        if(message.IsSuccessStatusCode)
        {
            await DisplayAlert("Succes", $"Envoie {damage} degats","succes");
            //check si le monstre est mort


            SpawnPoint = await dndClient.GetSpawnPointAsync(SpawnPoint.Id);

            int? pv = SpawnPoint.InGameMonster.Hp;
            MonsterNameLabel.Text = "pv:" + pv.ToString();
            if (SpawnPoint.InGameMonster.Hp == 0)
            {
                await DisplayAlert("Succes", $"Monstre mort + 1 niveau", "succes");
                await dndClient.IncrementLevel(Character.Id);
                await Navigation.PopAsync();

            }

        }

        if(message.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            await DisplayAlert("error",message.Content.ToString(),"error");
        }

    }
}