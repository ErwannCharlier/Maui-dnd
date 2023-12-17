using MauiDnd.Models;

namespace MauiDnd.Views.ShowWiki;

public partial class ShowWeapon : ContentPage
{
    public Weapon Weapon { get; set; }
    public ShowWeapon(Weapon weapon)
    {
        InitializeComponent();
        Weapon = weapon;
        BindingContext = Weapon;
    }
}