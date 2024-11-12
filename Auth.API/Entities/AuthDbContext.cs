using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Entities
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable("asp_net_users");

                entity.Property(u => u.UserName).HasMaxLength(50);
                entity.Property(u => u.NormalizedUserName).HasMaxLength(50);
                entity.Property(u => u.Email).HasMaxLength(100).IsRequired();
                entity.Property(u => u.NormalizedEmail).HasMaxLength(100);
                entity.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
                entity.Property(u => u.SecurityStamp).HasMaxLength(256);
                entity.Property(u => u.ConcurrencyStamp).IsConcurrencyToken().HasMaxLength(36);
                entity.Property(u => u.PhoneNumber).HasMaxLength(15);
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.ProfilePictureUrl).HasMaxLength(2048);
                entity.Property(u => u.BirthDate).HasColumnType("date");
                entity.Property(u => u.CreatedDate).IsRequired();

                entity.HasMany(u => u.LoginHistories)
                      .WithOne()
                      .HasForeignKey(l => l.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            builder.Entity<LoginHistory>(entity =>
            {
                entity.ToTable("asp_net_login_logs");

                entity.Property(l => l.IpAddress)
                      .HasMaxLength(45)
                      .IsRequired();

                entity.Property(l => l.LoginDate)
                      .IsRequired();
            });
            
            builder.HasDefaultSchema("asp_net_identity");

            builder.UseSnakeCase();
        }
    }
}
