using MauiDnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDnd.ViewModel
{
    public class CharacterVM
    {
        public string FirstText { get; set; }
        public string LastText { get; set; }
        public string IdText { get; set; }
        public Character Character { get; set; }

        public static CharacterVM CharacterToVM(Character c)
        {
            return new CharacterVM
            {
                FirstText = $"{c.Name} - {c.Class.Name}",
                LastText = $"{c.Race} - Niveau : {c.Lvl}",
                IdText = $"{c.Id} - {c.Name}",
                Character = c
            };
        }

    }
}
