namespace MauiDnd.Views.CrurdCharacter;
using MauiDnd.Models;

public partial class CreateCharacter : ContentPage
{
    public Character Character { get; set; }

    public CreateCharacter()
	{
        Random r = new Random();
        DndClient client = DndClient.Client();

        InitializeComponent();
        Character = new Character
        {
            UserId = client.UserId,
            Name = "",
            Race = "",
            HP = 2000,
            Lvl = 0,
            Strenght = r.Next(1, 20),
            Charisma = r.Next(1, 20),
            Dexterity = r.Next(1, 20),
            Constitution = r.Next(1, 20),
            Intelligence = r.Next(1, 20),
            Wisdom = r.Next(1, 20),
            Money = 0,
            Id = 0
        };
        BindingContext = this;
        PopulateClassPickerAsync();
    }

    private async Task PopulateClassPickerAsync()
    {
        List<Class> classes = await GetClasses();
        foreach (Class c in classes)
        {
            ClassPicker.Items.Add(c.Name);
        }
    }
    private async void SaveChanges_Clicked(object sender, EventArgs e)
    {
        Character.ClassId = Character.Class.Id;
        Character.Class = null;
        DndClient dndClient = DndClient.Client();

        await dndClient.PostCharacterAsync(Character);
        await DisplayAlert("Success", "Changes saved successfully", "OK");
        await Navigation.PushAsync(new Personnage());
    }
    private async Task<List<Class>> GetClasses()
    {
        DndClient dndClient = DndClient.Client();
        return await dndClient.GetClassAsync();
    }
    private async void Inventory_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MauiDnd.Views.CrurdCharacter.Inventory(Character.Id));

    }
    private async void ClassPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedClassName = (string)ClassPicker.SelectedItem;
        if (selectedClassName != null)
        {
            DndClient dndClient = DndClient.Client();
            Class newClass = await dndClient.GetClassByNameAsync(selectedClassName);
            if (newClass != null)
            {
                Character.Class = newClass;
                Character.ClassId = newClass.Id;
            }
        }
    }
}
