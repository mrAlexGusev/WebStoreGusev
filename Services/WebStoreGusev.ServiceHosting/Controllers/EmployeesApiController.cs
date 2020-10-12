using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Domain;
using WebStoreGusev.Domain.Models;
using WebStoreGusev.Interfaces.Services;

namespace WebStoreGusev.ServiceHosting.Controllers
{
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesServices
    {
        private readonly IEmployeesServices services;

        public EmployeesApiController(IEmployeesServices services)
        {
            this.services = services;
        }

        [HttpPost]
        public void Add([FromBody] Employee employee) =>
            services.Add(employee);

        [HttpDelete("{id}")]
        public bool Delete(int id) => services.Delete(id);
        
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Employee employee) => services.Edit(id, employee);

        [HttpGet]
        public IEnumerable<Employee> GetAll() => services.GetAll();

        [HttpGet("{id}")]
        public Employee GetById(int id) => services.GetById(id);
       
        [NonAction]
        public void SaveChanges() => services.SaveChanges();
    }
}
