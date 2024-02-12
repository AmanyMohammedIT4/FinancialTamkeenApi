using FinancialTamkeenApi.Model;

namespace FinancialTamkeenApi.Services.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<Users> GetAllProducts();
        Users GetProductById(int id);
        Users Authenticate(Users emp);
        Users Create(Users emp, string password, string confirm);
        void Update(Users emp);
    }
}
