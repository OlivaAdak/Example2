using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.Models
{
    public class GroceryDBContext:DbContext
    {
        public GroceryDBContext(DbContextOptions<GroceryDBContext> options):base(options)
        {

        }
        public DbSet<Grocery> Groceries { get; set; }
    }
}
