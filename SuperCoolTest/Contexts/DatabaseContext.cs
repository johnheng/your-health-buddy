using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourHealthBuddy.Contexts
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Models.Food> Foods { get; set; }
    public DbSet<Models.Meal> Meals { get; set; }
  }
}
