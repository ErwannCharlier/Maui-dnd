using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models

{
    public abstract class Localisation
    {
        public int X { get;set; }
        public int Y { get;set; }
        public int Id { get;set; }
        [ForeignKey("Game")]
        public int GameId { get;set; }
        public Game Game { get;set; }
        
        //public ICollection<Quest> Quests { get; set; } Je comprend pas ce que ca fait la ?

        public Localisation()
        {
          
        }

    }
}
