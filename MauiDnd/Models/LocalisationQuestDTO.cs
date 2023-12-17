using System.ComponentModel.DataAnnotations.Schema;

namespace MauiDnd.Models

{
    public class LocalisationQuestDTO
    {
        public int Xp { get; set; }
        public int Money { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsClaimed { get; set; } = false;
        public static LocalisationQuestDTO LocalisationQuestToDTO(LocalisationQuest lq)
        {
            return new LocalisationQuestDTO
            {
                Xp = lq.Xp,
                Money = lq.Money,
                Description = lq.Description,
                IsCompleted = lq.IsCompleted,
                IsClaimed = lq.IsClaimed
            };

        }

    }


}
