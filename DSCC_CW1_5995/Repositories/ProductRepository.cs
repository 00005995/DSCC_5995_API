using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCC_CW1_5995.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_CW1_5995.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(product);

            _dbContext.SaveChanges();
        }

        public Product GetProduct(int Id)
        {
            var prod = _dbContext.Products.Find(Id);
            _dbContext.Entry(prod).Reference(s => s.Category).Load();
            return prod;
        }

        public IQueryable<Product> GetProducts()
        {
            return _dbContext.Products.Include(s => s.Category).AsQueryable();
        }

        public void Update(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
