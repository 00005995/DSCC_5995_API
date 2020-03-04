using DSCC_CW1_5995.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5995.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProduct(int Id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
