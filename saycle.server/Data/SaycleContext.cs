using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using saycle.server.Models;

namespace saycle.server.Data
{
    public class SaycleContext : IdentityDbContext<User, Role, Guid>
    {
        public SaycleContext(DbContextOptions<SaycleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // Composite key of UserLanguage
            modelBuilder.Entity<UserLanguage>()
                .HasKey(ul => new { ul.UserId, ul.LanguageId });
            // Composite key of Favorite
            modelBuilder.Entity<Favorite>()
                .HasKey(ul => new { ul.UserId, ul.StoryId });
        }

        public DbSet<Bookmark> Bookmark { get; set; }

        public DbSet<Cycle> Cycles { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<IdentityUserRole<Guid>> UserRoles { get; set; }

        public DbSet<IdentityUserClaim<Guid>> UserClaims { get; set; }
    }
}
