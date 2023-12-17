using MauiDnd.Models;

namespace MauiDnd.Views.ShowWiki;

public partial class ShowSpell : ContentPage
{
	public Spell Spell { get; set; }
	public ShowSpell(Spell spell)
	{
		InitializeComponent();
		Spell = spell;
        BindingContext = Spell;
    }
}