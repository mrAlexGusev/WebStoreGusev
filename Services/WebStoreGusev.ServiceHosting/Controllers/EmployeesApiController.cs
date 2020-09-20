using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Domain;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.ViewModels;

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
        public void Add([FromBody] EmployeeViewModel model) =>
            services.Add(model);

        [HttpDelete("{id}")]
        public void Delete(int id) => services.Delete(id);
        
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] EmployeeViewModel model) => services.Edit(id, model);

        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetAll() => services.GetAll();

        [HttpGet("{id}")]
        public EmployeeViewModel GetById(int id) => services.GetById(id);
       
        [NonAction]
        public void SaveChanges() => services.SaveChanges();
    }
}
