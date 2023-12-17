namespace MauiDnd.Models;

public class Armor : iStuff
{
    public int? Cost { get; set; }
    public string? Type { get; set; }
    public int AC { get; set; }
    public bool? DexBonus { get; set; }
    public int? MaxDexMod { get; set; }
    public bool? StealthDisadvantage { get; set; }
    public Armor() { }

}
