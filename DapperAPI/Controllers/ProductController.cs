using DapperAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GETALL();
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GETByID(id);
        }
        [HttpPost]
        public void Post([FromBody]Product prod)
        {
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product prod)
        {
            prod.ProductID = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
