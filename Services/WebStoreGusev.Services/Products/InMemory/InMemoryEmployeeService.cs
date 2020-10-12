using System;
using System.Collections.Generic;
using System.Linq;
using WebStoreGusev.Domain.Models;
using WebStoreGusev.Interfaces.Services;
using WebStoreGusev.Services.Data;

namespace WebStoreGusev.Services.Products.InMemory
{ 
    public class InMemoryEmployeeService : IEmployeesServices
    {
        private readonly List<Employee> employees;

        public InMemoryEmployeeService()
        {
            employees = TestData.Employees;
        }

        public IEnumerable<Employee> GetAll() => employees;

        public Employee GetById(int id) =>
            employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee empl)
        {
            if(empl is null) { throw new ArgumentNullException(nameof(empl)); }
            
            if (employees.Contains(empl)) { return; }
            
            empl.Id = employees.Count == 0 ? 1 : employees.Max(e => e.Id) + 1;
            employees.Add(empl);
        }

        public void Edit(int id, Employee empl)
        {
            if (empl is null) { throw new ArgumentNullException(nameof(empl)); }
           
            if (employees.Contains(empl)) { return; }
            
            var dbEmployee = GetById(id);
            if (dbEmployee is null) { return; }
                        
            dbEmployee.FirstName = empl.FirstName;
            dbEmployee.LastName = empl.LastName;
            dbEmployee.Patronymic = empl.Patronymic;
            dbEmployee.Age = empl.Age;
            dbEmployee.Position = empl.Position;
        }

        public bool Delete(int id)
        {
            var dbEmployee = GetById(id);
            if (dbEmployee is null) { return false; }

            return employees.Remove(dbEmployee);
        }

        public void SaveChanges() { }
    }
}
