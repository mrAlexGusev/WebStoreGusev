using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Models;

namespace WebStoreGusev.Infrastructure.Services
{
    public class InMemoryEmployeeService : IEmployeesServices
    {
        private readonly List<EmployeeViewModel> employees;

        public InMemoryEmployeeService()
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

        public void AddNew(EmployeeViewModel model)
        {
            model.Id = employees.Max(e => e.Id) + 1;
            employees.Add(model);
        }

        public void Commit()
        {
            
        }

        public void Delete(int id)
        {
            EmployeeViewModel employee = GetById(id);

            if (employee is null) return;

            employees.Remove(employee);
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return employees;
        }

        public EmployeeViewModel GetById(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }
    }
}
