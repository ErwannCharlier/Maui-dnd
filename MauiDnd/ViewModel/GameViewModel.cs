using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiDnd.Models;
namespace MauiDnd.ViewModel
{
    public class GameViewModel
    {
        public string PlayersText { get; set; }
        public string MonsterText { get; set; }
        public Game Game { get; set; }

        public static GameViewModel GameToVM(Game g)
        {
            return new GameViewModel
            {
                PlayersText = $"Players: {g.LocalisationPlayers.Count}",
                MonsterText = $"Monsters: {g.SpawnPoints.Where(s=>s.IsActive == true).Count()}",
                Game = g
                
            };
        }
    }
}
