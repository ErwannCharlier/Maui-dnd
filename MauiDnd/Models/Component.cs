namespace MauiDnd.Models
{
    public class Component
    {
        public int Id { get; set; }
        public bool Material { get; set; }
        public string Raw { get; set; }
        public bool Somatic { get; set; }
        public bool Verbal { get; set; }

        public Component() { }
    }
}
