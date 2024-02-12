using FinancialTamkeenApi.Data;
using FinancialTamkeenApi.Model;
using FinancialTamkeenApi.Services.Interface;

namespace FinancialTamkeenApi.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FinancialDbContext _context;

        public EmployeeService(FinancialDbContext context)
        {
            _context = context;
        }
        public Users Authenticate(Users emp)
        {
            if (!_context.Employees.Any(x => x.Id == emp.Id))
                throw new ApplicationException("The employee does not exist");
            if(!_context.Employees.Any(x => x.Password == emp.Password))
                throw new ArgumentException("The Password does not match");

            if (emp == null) return null;
            return emp;
        }

        public Users Create(Users emp, string password, string confirm)
        {
            if (!_context.Employees.Any(x => x.Id == emp.Id))
                throw new ApplicationException("The employee does not exist");
            if (!password.Equals(confirm))
                throw new ArgumentException("The Password does not match");
            if (emp != null)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
            }

            return emp;
        }

        public IEnumerable<Users> GetAllProducts()
        {
            return _context.Employees.ToList();
        }

        public Users GetProductById(int id)
        {
            var emp = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return emp;
        }

        public void Update(Users emp)
        {
            if (_context.Employees.Any(x => x.Id == emp.Id))
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
            }
            else
            {
                throw new ApplicationException("Id does not match");
            }
        }
    }
}
