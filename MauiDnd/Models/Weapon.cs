namespace MauiDnd.Models

{
    public class Weapon : iStuff
    {

        public string Cost { get; set; }
        public string Damage { get; set; }
        public string Weight { get; set; }
        public List<Propertie> Properties { get; set; }

        public Weapon() 
        {
            Properties = new List<Propertie>();
        }

    }
}
