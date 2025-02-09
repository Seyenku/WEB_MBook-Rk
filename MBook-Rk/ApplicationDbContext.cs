using MBook_Rk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MBook_Rk
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Переопределение таблицы пользователей
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).HasColumnName("login").HasMaxLength(50);
                entity.Property(e => e.PasswordHash).HasColumnName("pass");
                entity.Property(e => e.Role);
                entity.Property(e => e.NormalizedUserName).HasColumnName("NormalizedUserName").HasMaxLength(256);
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(256);
                entity.Property(e => e.NormalizedEmail).HasColumnName("NormalizedEmail").HasMaxLength(256);
                entity.Property(e => e.EmailConfirmed).HasColumnName("EmailConfirmed");
                entity.Property(e => e.SecurityStamp).HasColumnName("SecurityStamp");
                entity.Property(e => e.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
                entity.Property(e => e.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
                entity.Property(e => e.LockoutEnd).HasColumnName("LockoutEnd");
                entity.Property(e => e.LockoutEnabled).HasColumnName("LockoutEnabled");
                entity.Property(e => e.AccessFailedCount).HasColumnName("AccessFailedCount");
            });

            // Переопределение таблицы ролей
            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable("roles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(256);
                entity.Property(e => e.NormalizedName).HasColumnName("normalized_name").HasMaxLength(256);
                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            });

            // Настройка таблиц для дополнительных сущностей Identity
            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ClaimType);
                entity.Property(e => e.ClaimValue);
            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
                entity.Property(e => e.ProviderDisplayName);
                entity.Property(e => e.UserId).IsRequired();
            });

            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
                entity.Property(e => e.Value);
            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoleId).IsRequired();
                entity.Property(e => e.ClaimType);
                entity.Property(e => e.ClaimValue);
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.RoleId).IsRequired();
            });
        }
    }
}