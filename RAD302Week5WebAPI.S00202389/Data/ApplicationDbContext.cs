using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationGames.Models;

namespace WebApplicationGames.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = S00202389-Game-DB";
            optionsBuilder.UseSqlServer(myconnectionstring);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameScore> GameScores { get; set; }

    }
}
