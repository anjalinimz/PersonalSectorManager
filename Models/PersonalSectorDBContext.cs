using System;
using Microsoft.EntityFrameworkCore;

namespace PersonalSectorManager.Models
{
    public class PersonalSectorDBContext : DbContext
    {
        public PersonalSectorDBContext(DbContextOptions<PersonalSectorDBContext> options) : base(options)
        {
        }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

