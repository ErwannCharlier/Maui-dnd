using System.Xml.Linq;

namespace MauiDnd.Models

{
    public class InventoryBox
    {
        public bool IsEquiped { get; set; }
        public int Id { get; set; }
        public iStuff? IStuff { get; set; }
        public string IStuffType { get; set; }

        public string ImagePath => $"a{IStuff.Id}.jpeg";


        public InventoryBox() { }

    }
}
