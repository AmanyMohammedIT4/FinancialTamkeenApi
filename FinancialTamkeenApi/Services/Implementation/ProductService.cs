using FinancialTamkeenApi.Data;
using FinancialTamkeenApi.Model;
using FinancialTamkeenApi.Services.Interface;

namespace FinancialTamkeenApi.Services.Implementation
{
    public class ProductService : IProductService

    {
        private readonly FinancialDbContext _context;
        private IEmployeeService _employeeService;

        public ProductService(FinancialDbContext context)
        {
            _context = context;
        }

        public ProductModel Create(ProductModel product)
        {
            try
            {
                

                    if (_context.Products.Any(x => x.Name == product.Name))
                        throw new ApplicationException("The product " + product.Name + " is arleady exists");
                    if (product != null)
                    {
                        _context.Products.Add(product);
                        _context.SaveChanges();
                    }

              
                return product;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            var product =_context.Products.Where(x=>x.ProductId == id).FirstOrDefault();
            return product;
        }

        public void Update(ProductModel product)
        {
            try
            {
                if (_context.Products.Any(x => x.ProductId == product.ProductId))
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ApplicationException("Id does not match");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

            //var products = _context.Products.Where(x=>x.ProductId == product.ProductId).SingleOrDefault();
            //if (products == null) throw new ApplicationException("The product is not exists");
            
            //_context.Products.Update(products);
            //_context.SaveChanges();
        }
    }
}
