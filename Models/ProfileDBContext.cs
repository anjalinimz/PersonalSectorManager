using Microsoft.EntityFrameworkCore;

namespace PersonalSectorManager.Models
{
    public class ProfileDBContext : DbContext
    {

        public ProfileDBContext(DbContextOptions<ProfileDBContext> options) : base(options)
        {
        }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSector> UserSectors { get; set; }
    }
}

