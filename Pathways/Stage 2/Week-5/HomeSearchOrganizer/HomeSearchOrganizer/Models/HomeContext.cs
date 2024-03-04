using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HomeSearchOrganizer.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options)
            : base(options)
        {
        }

        public DbSet<Home> Home { get; set; } = null!;
    }
}
