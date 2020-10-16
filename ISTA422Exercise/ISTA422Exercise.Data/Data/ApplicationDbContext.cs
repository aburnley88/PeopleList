using Microsoft.EntityFrameworkCore;
using ISTA422Exercise.Data.Data.Models;

namespace ISTA422Exercise.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
