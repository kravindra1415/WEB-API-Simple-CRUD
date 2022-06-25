using Microsoft.AspNetCore.Mvc;
using WebApplication1.EmployeeData;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeData _data;

        public EmployeeController(IEmployeeData data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_data.GetAll());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetById(Guid id)
        {
            var emp = _data.GetByid(id);

            if (emp != null)
            {
                return Ok(emp);
            }

            return NotFound($"Employee with id: {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Add(Employee employee)
        {
            _data.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(Guid id)
        {
            var emp = _data.GetByid(id);

            if (emp != null)
            {
                _data.DeleteEmployee(emp);
                return Ok();
            }
            return NotFound($"Employee with id: {id} not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult Update(Guid id, Employee employee)
        {
            var emp = _data.GetByid(id);

            if (emp != null)
            {
                employee.Id = emp.Id;
                _data.UpdateEmployee(employee);

            }
            return Ok(employee);
        }
    }
}
