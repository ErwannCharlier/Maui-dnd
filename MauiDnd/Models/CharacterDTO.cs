using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace MauiDnd.Models

{
    public class CharacterDTO
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int HP { get; set; }
        public int Lvl { get; set; }
        public double Money { get; set; }

        public static CharacterDTO CharacterToDTO(Character c)
        {
            return new CharacterDTO()
            {
                Name = c.Name,
                Race = c.Race,
                HP = c.HP,
                Lvl = c.Lvl,
                Money = c.Money
            };
        }





    }
}