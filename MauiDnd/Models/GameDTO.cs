namespace MauiDnd.Models

{
    public class GameDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public List<LocalisationPlayer> LocalisationPlayers { get; set; }

        public static GameDTO GameToDTO(Game g)
        {
            return new GameDTO()
            {
                Id = g.Id,
                StartDate = g.StartDate,
                LocalisationPlayers = g.LocalisationPlayers,
            };
        }


    }
}
