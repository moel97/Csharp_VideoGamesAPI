using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VideoGameApi.Models;

namespace VideoGameApi.Data
{
    public class VideoGameDBContext(DbContextOptions<VideoGameDBContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = new List<string> { "Nintendo" , "Nintendo2", "Nintendo3" } },
                new VideoGame { id = 2, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = new List<string> { "Sony Interactive Entertainment" , "Nintendo" , "" } },
                new VideoGame { id = 3, Title = "Red Dead Redemption 2", Platform = "PlayStation 4, Xbox One, PC", Developer = "Rockstar Games", Publisher = new List<string> { " Rockstar Games" , "Sony Interactive Entertainment" } }
            );
        }
    }
}
