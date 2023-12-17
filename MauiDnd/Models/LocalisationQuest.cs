using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models

{
    public class LocalisationQuest : Localisation
    {
        public int Xp { get; set; }
        public int Money { get; set; }
        public iStuff IStuff { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsClaimed { get; set; } = false;
        [ForeignKey("InGameMonster")]
        public int InGameMonsterId { get; set; }
        public InGameMonster InGameMonster { get; set; }

        public LocalisationQuest()
        {

        }
    }
}
