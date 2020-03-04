using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5995.Models
{
    public class ProductDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options): base (options)
        {
            Database.EnsureCreated();
        }
    }
}
