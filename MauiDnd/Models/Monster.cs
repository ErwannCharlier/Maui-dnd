namespace MauiDnd.Models

{
    public class Monster
    { 
        public int Id { get; set; }
        public string? Desc { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public int Armor_class { get; set; }
        public int Hit_points { get; set; }
        public string? Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public string Languages { get; set; }
        public double Challenge_rating { get; set; }
        public int XP { get; set; }
        public string Image{ get; set; }
        public int Hp { get; set; }

        public Monster() { }
    }
}
