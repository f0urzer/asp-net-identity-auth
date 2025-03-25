using Microsoft.AspNetCore.Identity;

namespace Auth.API.Entities
{
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        
        public UserDetail? UserDetail { get; set; }
    }
}
