using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Models;

namespace WebStoreGusev.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {        
        private readonly IEmployeesServices employeesServices;

        public EmployeeController(IEmployeesServices employeesServices)
        {
            this.employeesServices = employeesServices;
        }

        // /users/all
        [Route("all")]
        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(employeesServices.GetAll());
        }

        // /users/{id}
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return View(employeesServices.GetById(id));
        }
    }
}
