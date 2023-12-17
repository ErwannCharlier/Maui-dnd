using MauiDnd.Models;

namespace MauiDnd.Views.ShowWiki;

public partial class ShowClass : ContentPage
{
	public Class Class { get; set; }
	public ShowClass(Class _class)
	{
		InitializeComponent();
        Class = _class;
        BindingContext = Class;
    }
}