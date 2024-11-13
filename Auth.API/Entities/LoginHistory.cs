namespace Auth.API.Entities
{
    public class LoginHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime LoginDate { get; set; } = DateTime.UtcNow;
        public string IpAddress { get; set; } = null!;
    }
}