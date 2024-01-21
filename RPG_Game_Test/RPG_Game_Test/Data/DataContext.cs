using Microsoft.EntityFrameworkCore;
using RPG_Game_Test.Models;

namespace RPG_Game_Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters => Set<Character>();
    }
}
