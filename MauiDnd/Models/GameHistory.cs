using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models

{
    public class GameHistory
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int NbKilss { get; set; }
        public DateTime JoinDate { get; set; }

        [ForeignKey("Character")]
        public int CharacterID { get; set; }
        public Character? Character { get; set; }
        public int CharacterHp { get; set; } //On ne peut pas simplement utilisé les pv dans l'objet character car il peut etre dans plusieurs games
        public List<LocalisationQuest> LocalisationQuests { get; set; }
        public GameHistory()
        {
            LocalisationQuests = new List<LocalisationQuest>();
        }

    }

    
}
