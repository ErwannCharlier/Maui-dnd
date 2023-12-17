using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models

{
    public class InGameMonster
    {
        public int Id { get; set; }
        public int Hp { get; set; }

        [ForeignKey("Monster")]
        public int MonsterId { get; set; }

        public Monster? Monster { get; set; }
        public SpawnPoint? SpawnPoint { get; set; }

    }
}
