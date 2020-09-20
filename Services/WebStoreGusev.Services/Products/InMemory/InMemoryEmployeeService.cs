using System;
using System.Collections.Generic;
using System.Linq;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.ViewModels;

namespace WebStoreGusev.Infrastructure.Services.InMemory
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

        public void Add(EmployeeViewModel model)
        {
            if(model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (employees.Contains(model))
            {
                return;
            }

            model.Id = employees.Count == 0 ? 1 : employees.Max(e => e.Id) + 1;
            employees.Add(model);
        }

        public void SaveChanges() { }

        public void Delete(int id)
        {
            EmployeeViewModel employee = GetById(id);

            if (employee is null) return;

            employees.Remove(employee);
        }

        public IEnumerable<EmployeeViewModel> GetAll() => employees;

        public EmployeeViewModel GetById(int id) =>
            employees.FirstOrDefault(x => x.Id == id);

        public void Edit(int id, EmployeeViewModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (employees.Contains(model))
            {
                return;
            }

            var dbEmployee = GetById(id);
            if(dbEmployee is null)
            {
                return;
            }

            dbEmployee.FirstName = model.FirstName;
            dbEmployee.LastName = model.LastName;
            dbEmployee.Patronymic = model.Patronymic;
            dbEmployee.Age = model.Age;
            dbEmployee.Position = model.Position;
        }
    }
}
