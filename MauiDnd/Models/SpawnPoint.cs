using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models

{
    public class SpawnPoint : Localisation
    {
        
        public bool IsActive { get; set; }

        [ForeignKey("InGameMonster")]
        public int InGameMonsterId { get; set; }
        public InGameMonster? InGameMonster { get; set; }

        public SpawnPoint()
        {
            
        }


    }
}
