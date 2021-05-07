using Login_App_NetCore.DataAccess;
using Login_App_NetCore.Model;
using Login_App_NetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login_App_NetCore.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {

        private ProductsService productsService = new ProductsService();

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get() {
            var products = productsService.GetAllProducts().Select(s => new Products {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                UnitPrice = s.UnitPrice,
                UnitsInStock = s.UnitsInStock
            }).ToList();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                var product = productsService.GetProductById(id);
                return Ok(product);
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductsModel newProduct) {
            try {
                productsService.CreateNewProduct(newProduct);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] decimal newPrice) {
            try {
                productsService.UpdateProductPriceById(id,newPrice);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                productsService.DeleteProductById(id);
                return Ok();
            }catch(Exception e) {
                return ThrowInternalServerError(e);
            }
        }

        #region

        private IActionResult ThrowInternalServerError(Exception e) {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }

        #endregion

    }
}
