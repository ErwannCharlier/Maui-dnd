using MauiDnd.Models;

namespace MauiDnd.Views.ShowWiki;

public partial class ShowArmor : ContentPage
{
    public Armor Armor { get; set; }
	public ShowArmor(Armor armor)
	{
		InitializeComponent();
        Armor = armor;
        BindingContext = Armor;
    }
}