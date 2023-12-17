using MauiDnd.Models;
using MauiDnd.ViewModel;


namespace MauiDnd.Views.CrurdCharacter;

public partial class Inventory : ContentPage
{
	public int CharacterId { get; set; }
    public List<InventoryBox> InventoryBoxs { get; set; }
    public List<InventoryBox> EquippedItems { get; set; } 
    public InventoryBox EquippedArmor { get; set; }
    public InventoryBox EquippedWeapon { get; set; }
	public List<InventoryBox> UnequippedItems { get; set; } 

    public Inventory(int characterId)
	{
		InitializeComponent();
		CharacterId = characterId;
		LoadInventory();

    }
    public async void EquippedItemTapped(object sender, EventArgs e)
    {

        var tappedImage = sender as Image;
        if (tappedImage != null)
        {
            var tappedInventoryBox = tappedImage.BindingContext as InventoryBox;

            if (tappedInventoryBox != null)
            {
                tappedInventoryBox.IsEquiped = false;
                await DndClient.Client().UpdateInventoryBoxAsync(tappedInventoryBox);
                await LoadInventory();
            }
        }
    }

    public void EquippedWeaponTapped(object sender, EventArgs e)
    {

    }
    public void EquippedArmorTapped(object sender, EventArgs e)
    {

    }


    public async void UnEquippedItemTapped(object sender, EventArgs e)
    {
        var tappedImage = sender as Image;
        if (tappedImage != null)
        {
            var tappedInventoryBox = tappedImage.BindingContext as InventoryBox;

            if (tappedInventoryBox != null)
            {
                DndClient dndClient = DndClient.Client();
                //check si il faut dé équipé un item
                if (tappedInventoryBox.IStuffType == "Armor" && EquippedArmor is not null)
                {
                    EquippedArmor.IsEquiped = false;
                    await dndClient.UpdateInventoryBoxAsync(EquippedArmor);
                    EquippedArmor = null;
                }

                if (tappedInventoryBox.IStuffType == "Weapon" && EquippedWeapon is not null)
                {
                    EquippedWeapon.IsEquiped = false;
                    await dndClient.UpdateInventoryBoxAsync(EquippedWeapon);
                    EquippedWeapon = null;
                }

                //équipé le nouvel item

                tappedInventoryBox.IsEquiped = true;
                await dndClient.UpdateInventoryBoxAsync(tappedInventoryBox);
                await LoadInventory();
            }
        }
    }
    public async Task LoadInventory()
	{
        try
        {
            DndClient dndClient = DndClient.Client();
            InventoryBoxs = await dndClient.GetInventoryAsync(CharacterId);
            EquippedWeapon = InventoryBoxs.FirstOrDefault(box => box.IStuffType == "Weapon" && box.IsEquiped == true);
            EquippedArmor = InventoryBoxs.FirstOrDefault(box => box.IStuffType == "Armor" && box.IsEquiped == true);

            UnequippedItems = InventoryBoxs.Where(b => !b.IsEquiped).ToList();
            UnequippedCollectionView.ItemsSource = UnequippedItems;             

            EquippedWeaponImage.Source = EquippedWeapon.ImagePath;
            EquippedArmorImage.Source = EquippedArmor.ImagePath;  
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}