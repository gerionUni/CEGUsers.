using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMTShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MMTShopController : ControllerBase
    {
       
        private readonly MMTShopContext _context;

        public MMTShopController(MMTShopContext context) => _context = context;

        //GET all categories
        [HttpGet]
        public ActionResult<IEnumerable<MMTProductCategory>> GetCategories()
        {
            var result = _context.ProductCategory;
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        //GET products by category
        [HttpGet("{categoryName}/GetProductByCategoryId")]
        public ActionResult<List<MMTProduct>> GetProductByCategoryId(string categoryName)
        {
             
            var result = _context.Products.Where(x => x.Category.Name == categoryName).ToList();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        //GET featured products
        [HttpGet("{featured}/GetFeaturedProducts")]
        public ActionResult<List<MMTProduct>> GetFeaturedProducts(bool featured)
        {
             
            var result = _context.Products.Where(x => x.Featured == featured).ToList();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        //POST a new product
        [HttpPost]
        public ActionResult<MMTProduct> PostProducts(int SKU, string name, string description, double price, 
            bool featured, string categoryName)
        {
            MMTProduct product = new MMTProduct()
            {
                SKU = SKU,
                Name = name,
                Description = description,
                Price = price,
                Featured = featured,
                Category = _context.ProductCategory.Find(categoryName)
            };
            _context.Products.Add(product);
            _context.SaveChanges();
          
            return CreatedAtAction("GetProductByCategoryId",categoryName);
        }

        //DELETE a product
        [HttpDelete("{id}")]
        public ActionResult<MMTProduct> DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }


    }
}
