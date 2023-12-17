using MauiDnd.Models;

namespace MauiDnd.Views.ShowWiki;

public partial class ShowFeat : ContentPage
{
	public Feat Feat { get; set; }
	public ShowFeat(Feat feat)
	{
		InitializeComponent();
		Feat = feat;
        BindingContext = Feat;
    }
}