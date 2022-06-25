using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private readonly ApplicationDbContext _context;

        public SqlEmployeeData(ApplicationDbContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = employee.Id;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetByid(Guid id)
        {
            var emp = _context.Employees.Find(id);
            return emp;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp = _context.Employees.Find(employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                _context.Employees.Update(emp);
                _context.SaveChanges();
            }

            return employee;
        }
    }
}
