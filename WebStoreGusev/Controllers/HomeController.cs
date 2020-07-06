using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Models;

namespace WebStoreGusev.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeViewModel> employees;

        public HomeController()
        {
            employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Patronymic = "Иванович",
                    Age = 22,
                    Position = "Программист"
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    Patronymic = "Петрович",
                    Age = 35,
                    Position = "Менеджер"
                },
                new EmployeeViewModel
                {
                    Id = 3,
                    FirstName = "Роман",
                    LastName = "Романов",
                    Patronymic = "Романович",
                    Age = 28,
                    Position = "Электрик"
                },
                new EmployeeViewModel
                {
                    Id = 4,
                    FirstName = "Олег",
                    LastName = "Олегов",
                    Patronymic = "Олегович",
                    Age = 31,
                    Position = "Сантехник"
                },
                new EmployeeViewModel
                {
                    Id = 5,
                    FirstName = "Алексей",
                    LastName = "Алексеев",
                    Patronymic = "Алексеевич",
                    Age = 19,
                    Position = "Охранник"
                }
            };
        }

        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            return View(employees.FirstOrDefault(x => x.Id == id));
        }
    }
}
