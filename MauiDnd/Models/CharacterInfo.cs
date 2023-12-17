namespace MauiDnd.Models

{
    public class CharacterInfo
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public Class Class { get; set; }
        public int HP { get; set; }
        public int Lvl { get; set; }

        public static CharacterInfo CharacterInfoToDTO(Character character)
        {
            return new CharacterInfo { Name = character.Name, Race = character.Race, Class = character.Class, HP = character.HP, Lvl = character.Lvl };
        }
    }
}
