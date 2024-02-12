using FinancialTamkeenApi.Model;

namespace FinancialTamkeenApi.Services.Interface
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        ProductModel Create(ProductModel product);
        void Update(ProductModel product);
    }
}
