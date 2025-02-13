using MBook_Rk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MBook_Rk
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Отключаем создание стандартных таблиц Identity
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();

            // Переопределение таблицы пользователей
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).HasColumnName("login").HasMaxLength(50);
                entity.Property(e => e.PasswordHash).HasColumnName("pass");
                entity.Property(u => u.NormalizedUserName).HasColumnName("NormalizedUserName").IsRequired(false);
                entity.Ignore(e => e.Email); // Отключаем свойства, которые не используются
                entity.Ignore(e => e.NormalizedEmail);
                entity.Ignore(e => e.EmailConfirmed);
                entity.Ignore(e => e.SecurityStamp);
                entity.Ignore(e => e.ConcurrencyStamp);
                entity.Ignore(e => e.PhoneNumber);
                entity.Ignore(e => e.PhoneNumberConfirmed);
                entity.Ignore(e => e.TwoFactorEnabled);
                entity.Ignore(e => e.LockoutEnd);
                entity.Ignore(e => e.LockoutEnabled);
                entity.Ignore(e => e.AccessFailedCount);
            });

            // Переопределение таблицы ролей
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable("roles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(256);
                entity.Property(r => r.NormalizedName).HasColumnName("NormalizedName").IsRequired(false);
                entity.Ignore(e => e.ConcurrencyStamp);
            });

            // Переопределение таблицы связи между пользователями и ролями
            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("user_roles");
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);
            });

            // Добавляем связь между пользователями и ролями
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            builder.Entity<ApplicationRole>()
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId);
        }
    }
}