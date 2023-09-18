using Apricode.App.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apricode.App.Infrastructure.Data
{
    public partial class ApricodeContext : DbContext
    {
        public ApricodeContext()
        {
        }

        public ApricodeContext(DbContextOptions<ApricodeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<GameDeveloper> GameDevelopers { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.DeveloperNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.Developer)
                    .HasConstraintName("games_developer_fkey");
            });

            modelBuilder.Entity<GameDeveloper>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.GameNavigation)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.Game)
                    .HasConstraintName("genres_game_fkey");
            });
        }
        
    }
}
