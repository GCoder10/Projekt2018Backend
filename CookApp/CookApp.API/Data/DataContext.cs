using CookApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CookApp.API.Data
{
    public class DataContext: DbContext
    {
            public DataContext(DbContextOptions<DataContext> options): base(options) {}

            public DbSet<Recipe> recipes { get; set; }
    }
}