namespace MauiDnd.Models

{
    public class Game
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public List<SpawnPoint> SpawnPoints { get; set; }
        public List<LocalisationPlayer> LocalisationPlayers { get; set; }
        public List<LocalisationQuest> LocalisationQuests { get; set; }

        public Game()
        {
            SpawnPoints = new List<SpawnPoint>();   
            LocalisationPlayers = new List<LocalisationPlayer>();
            LocalisationQuests = new List<LocalisationQuest>();
        }

    }
}
