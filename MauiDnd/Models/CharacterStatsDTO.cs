namespace MauiDnd.Models

{
    public class CharacterStatsDTO
    {
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Wisdom { get; set; }

        public static CharacterStatsDTO CharacterToDTOStats(Character c)
        {
            return new CharacterStatsDTO()
            {
                Strenght = c.Strenght,
                Dexterity = c.Dexterity,
                Constitution = c.Constitution,
                Intelligence = c.Intelligence,
                Charisma = c.Charisma,
                Wisdom = c.Wisdom


            };
        }





    }
}