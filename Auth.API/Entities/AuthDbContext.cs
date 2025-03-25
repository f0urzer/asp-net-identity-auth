using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Entities
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable("asp_net_users");

                entity.Property(u => u.Id).HasMaxLength(36);
                entity.Property(u => u.UserName).HasMaxLength(50);
                entity.Property(u => u.NormalizedUserName).HasMaxLength(50);
                entity.Property(u => u.Email).HasMaxLength(100).IsRequired();
                entity.Property(u => u.NormalizedEmail).HasMaxLength(100);
                entity.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
                entity.Property(u => u.SecurityStamp).HasMaxLength(256);
                entity.Property(u => u.ConcurrencyStamp).IsConcurrencyToken().HasMaxLength(36);
                entity.Property(u => u.PhoneNumber).HasMaxLength(15);
                
                entity.HasOne(u => u.UserDetail)
                      .WithOne(u => u.User)
                      .HasForeignKey<UserDetail>(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            builder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("asp_net_user_details");

                entity.Property(u => u.UserId).HasMaxLength(36);
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.ProfilePictureUrl).HasMaxLength(2048);
                entity.Property(u => u.BirthDate).HasColumnType("date");
            });

            builder.HasDefaultSchema("asp_net_identity");

            builder.UseSnakeCase();
        }
    }
}
