namespace Auth.API.Entities
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ProfilePictureUrl { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public bool? Gender { get; set; }

        public User User { get; set; } = null!;
    }
}
