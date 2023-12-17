using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models
{
    public class Character
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int ClassId { get; set; }
        public virtual Class? Class { get; set; }
        public int HP { get; set; }
        public int Lvl { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Wisdom { get; set; }
        public double Money { get; set; }
        public virtual ICollection<Skill> CharacterSkills { get; set; }
        public virtual List<InventoryBox> Inventory { get; set; } 
        public virtual List<GameHistory> GameHistories { get; set; }   
        public Character() {
            this.Inventory = new List<InventoryBox>();
            this.GameHistories = new List<GameHistory>();
            this.CharacterSkills = new List<Skill>();
        }


    }
}
