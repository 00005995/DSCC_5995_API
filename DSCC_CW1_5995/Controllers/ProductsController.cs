using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DSCC_CW1_5995.Models;
using DSCC_CW1_5995.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_CW1_5995.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProduct(id);
            return new OkObjectResult(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            using (var scope = new TransactionScope())
            {
                _productRepository.Create(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.Update(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return new OkResult();
        }
    }
}
