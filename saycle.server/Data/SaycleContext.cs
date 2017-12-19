using System.Linq;
using Microsoft.EntityFrameworkCore;
using saycle.server.Models;

namespace saycle.server.Data
{
    public class SaycleContext : DbContext
    {
        public SaycleContext(DbContextOptions<SaycleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // Composite key of UserLanguage
            modelBuilder.Entity<UserLanguage>()
                .HasKey(ul => new { ul.UserID, ul.LanguageID });
            // Composite key of Favorite
            modelBuilder.Entity<Favorite>()
                .HasKey(ul => new { ul.UserID, ul.StoryID });
        }

        public DbSet<Bookmark> Bookmark { get; set; }

        public DbSet<Cycle> Cycles { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Visit> Visits { get; set; }
    }
}
