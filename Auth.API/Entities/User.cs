using Microsoft.AspNetCore.Identity;

namespace Auth.API.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Gender { get; set; }

        public int CreatedBy { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<LoginHistory>? LoginHistories { get; set; }
    }
}
