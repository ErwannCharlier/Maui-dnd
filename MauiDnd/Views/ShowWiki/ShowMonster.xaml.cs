using MauiDnd.Models;

namespace MauiDnd.Views.ShowWiki;

public partial class ShowMonster : ContentPage
{
	public Monster Monster { get; set; }
	public ShowMonster(Monster monster)
	{
		InitializeComponent();
		Monster = monster;
        BindingContext = Monster;
    }
}