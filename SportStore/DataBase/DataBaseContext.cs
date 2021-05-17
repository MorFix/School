using Microsoft.EntityFrameworkCore;
using SportStore.Models;

namespace SportStore.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Shirt> Shirts { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }        
    }
}
