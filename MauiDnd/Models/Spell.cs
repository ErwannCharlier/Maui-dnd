namespace MauiDnd.Models

{
    public class Spell
    {
        public int Id { get; set; }
        public string CastingTime { get; set; }
        public List<Class> Classes { get; set; }
        public Component Components { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public bool Ritual { get; set; }
        public string School { get; set; }
        public List<Tag> Tags { get; set; }
        public string Type { get; set; }

        public Spell() 
        {
            Classes = new List<Class>();
            Tags = new List<Tag>();
        }
    }
}
