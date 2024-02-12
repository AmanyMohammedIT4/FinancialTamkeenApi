using FinancialTamkeenApi.Model;
using FinancialTamkeenApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTamkeenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //Get all products
        [HttpGet]
        [Route("get_all_product")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        //Get products by id
        [HttpGet]
        [Route("get_product_by_Id")]
        public IActionResult GetProductsById(int Id)
        {
            var products = _productService.GetProductById(Id);
            return Ok(products);
        }
        //Add new product
        [HttpPost]
        [Route("add_new_product")]
        public IActionResult AddNewProducts(ProductModel product, string name, string pass)
        {
            
            if(!ModelState.IsValid)return BadRequest(product);

            var products = _productService.Create(product,name,pass);
            return Ok(products);
        }
        //Update product
        [HttpPut]
        [Route("Update_product")]
        public IActionResult UpdateProduct(ProductModel product)
        {
            if (!ModelState.IsValid) return BadRequest(product);

             _productService.Update(product);
            return Ok();
        }

    }
}
