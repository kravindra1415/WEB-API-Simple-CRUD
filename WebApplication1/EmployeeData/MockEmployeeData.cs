using WebApplication1.Models;

namespace WebApplication1.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> _employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee One"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee two"
            },new Employee()
            {
                Id=Guid.NewGuid(),
                Name="Employee three"
            },
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);

        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetByid(Guid id)
        {
            return _employees.SingleOrDefault(x => x.Id == id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp = GetByid(employee.Id);
            emp.Name = employee.Name;
            return emp;
        }
    }
}
