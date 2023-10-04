using cookie_stand_api.Model;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Data
{
    public class CookieSalmonDbContext : DbContext
    {
        public CookieSalmonDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HourlySales>().HasKey(

                hourlySales => new
                {
                    hourlySales.ID,
                    hourlySales.CookieStandID
                });
        }

        public DbSet<CookieStand> CookieStands { get; set; }

        public DbSet<HourlySales> HourlySales { get; set; }
    }
}
