using WebApplication1.Models;

namespace WebApplication1.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetAll();

        Employee GetByid(Guid id);

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
