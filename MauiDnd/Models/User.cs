using System.Text;

using System.Security.Cryptography;


namespace MauiDnd.Models

{
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string HashPassword { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Character>? Characters { get; set; }

        public User()
        {
            Characters = new HashSet<Character>();
        }
    }
}
