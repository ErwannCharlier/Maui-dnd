namespace MauiDnd.Models

{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }

        public virtual ICollection<Character>? Characters { get; set; }
        public static UserDTO UserInfoToDTO(User user)
        {
            return new UserDTO { Id = user.Id, Pseudo = user.Pseudo, Characters = user.Characters };
        }
    }

}
