
using MauiDnd.Models;
using MauiDnd.ViewModel;
using MauiDnd.Views.CrurdCharacter;
using MauiDnd.Views.ShowWiki;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MauiDnd.Views;
public partial class Recherche : ContentPage
{

    private Entry searchEntry;
    private int choice; // Ajout d'un champ pour stocker le choix

    public Recherche() // Constructeur par défaut
    {
        InitializeComponent();
    }

    public Recherche(int choice) // Constructeur avec choix
    {
        this.choice = choice;
        InitializeComponent();
        AddSearchBar();
        LoadSearch(choice);
    }

    private void AddSearchBar()
    {
        searchEntry = new Entry
        {
            Placeholder = "Rechercher par nom",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        searchEntry.TextChanged += OnSearchEntryTextChanged;

    }


   

    private void OnSearchEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Filtrer la liste en fonction du terme de recherche
        string searchTerm = e.NewTextValue.ToLower(); // Convertir en minuscules pour une recherche insensible à la casse

        switch (choice)
        {
            case 0:
                LoadArmorAsync(searchTerm);
                break;
            case 1:
                LoadWeaponAsync(searchTerm);
                break;
            case 2:
                LoadClassAsync(searchTerm);
                break;
            case 3:
                LoadSpellAsync(searchTerm);
                break;
            case 4:
                LoadFeatAsync(searchTerm);
                break;
            case 5:
                LoadMonsterAsync(searchTerm);
                break;
        }
    }

    
    public void LoadSearch(int choice)
	{
		switch (choice)
		{
			case 0:
                LoadArmorAsync("");
                break;
			case 1:
                LoadWeaponAsync("");
				break;
			case 2:
                LoadClassAsync("");
                break;
			case 3:
                LoadSpellAsync("");
                break;
			case 4:
                LoadFeatAsync("");
                break;
			case 5:
                LoadMonsterAsync("");
                break;
		}
	}
    

    public async void LoadWeaponAsync(string searchTerm)
    {
        DndClient dndClient = DndClient.Client();
        List<Weapon> weapons = await dndClient.GetWeaponAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            // Filtrer la liste en fonction du terme de recherche
            weapons = weapons.Where(w => w.Name.ToLower().Contains(searchTerm)).ToList();
        }

        collectionView.ItemsSource = weapons;
    }

    private async Task LoadArmorAsync(string searchTerm)
    {
        DndClient dndClient = DndClient.Client();
        List<Armor> armors = await dndClient.GetArmorAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            // Filtrer la liste en fonction du terme de recherche
            armors = armors.Where(w => w.Name.ToLower().Contains(searchTerm)).ToList();
        }

        collectionView.ItemsSource = armors;
    }


    public async void LoadSpellAsync(string searchTerm)
    {
        DndClient dndClient = DndClient.Client();
        List<Spell> spells = await dndClient.GetSpellAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            // Filtrer la liste en fonction du terme de recherche
            spells = spells.Where(w => w.Name.ToLower().Contains(searchTerm)).ToList();
        }

        collectionView.ItemsSource = spells;

    }


    public async void LoadClassAsync(string searchTerm)
    {
        DndClient dndClient = DndClient.Client();
        List<Class> classes = await dndClient.GetClassAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            // Filtrer la liste en fonction du terme de recherche
            classes = classes.Where(w => w.Name.ToLower().Contains(searchTerm)).ToList();
        }

        collectionView.ItemsSource = classes;

    }

    public async void LoadMonsterAsync(string searchTerm)
    {
        DndClient dndClient = DndClient.Client();
        List<Monster> monsters = await dndClient.GetMonsterAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            // Filtrer la liste en fonction du terme de recherche
            monsters = monsters.Where(w => w.Name.ToLower().Contains(searchTerm)).ToList();
        }

        collectionView.ItemsSource = monsters;

    }

    public async void LoadFeatAsync(string searchTerm)
    {
        DndClient dndClient = DndClient.Client();
        List<Feat> feats = await dndClient.GetFeatAsync();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            // Filtrer la liste en fonction du terme de recherche
            feats = feats.Where(w => w.Name.ToLower().Contains(searchTerm)).ToList();
        }

        collectionView.ItemsSource = feats;

    }

    private void OnCollectionViewScrolled(object sender, EventArgs e)
    {
    }

    private void ShowMore_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedItem = button?.BindingContext;

        if (selectedItem != null)
        {
            switch (selectedItem)
            {
                case Armor armor:
                    Navigation.PushAsync(new ShowArmor(armor)); 
                    break;
                case Weapon weapon:
                    Navigation.PushAsync(new ShowWeapon(weapon));
                    break;
                case Class characterClass:
                    Navigation.PushAsync(new ShowClass(characterClass));
                    break;
                case Spell spell:
                    Navigation.PushAsync(new ShowSpell(spell));
                    break;
                case Feat feat:
                    Navigation.PushAsync(new ShowFeat(feat));
                    break;
                case Monster monster:
                    Navigation.PushAsync(new ShowMonster(monster));
                    break;
            }
        }
    }




}