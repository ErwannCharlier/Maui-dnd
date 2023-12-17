namespace MauiDnd.Models

{
    public class Skill
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string RelatedTo { get; set; }

        public Skill()
        {

        }


    }
}
