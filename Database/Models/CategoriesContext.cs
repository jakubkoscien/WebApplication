using Microsoft.EntityFrameworkCore;
using CustomAPI.Models;

namespace Database.Models
{
    public class CategoriesContext : DbContext
    {
        public CategoriesContext(DbContextOptions<CategoriesContext> options): base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
    }
}
