using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebStoreGusev.Clients.Base;
using WebStoreGusev.Domain;
using WebStoreGusev.Domain.Models;
using WebStoreGusev.Interfaces.Services;

namespace WebStoreGusev.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesServices
    {
        public EmployeesClient(IConfiguration configuration)
            : base(configuration, WebAPI.Employees) { }

        public IEnumerable<Employee> GetAll() =>
            Get<List<Employee>>(serviceAddress);

        public Employee GetById(int id) =>
            Get<Employee>($"{serviceAddress}/{id}");

        public void Add(Employee employee) =>
            Post(serviceAddress, employee);

        public void Edit(int id, Employee employee) =>
            Put($"{serviceAddress}/{id}", employee);


        public bool Delete(int id) => 
            Delete($"{serviceAddress}/{id}").IsSuccessStatusCode;
        
        public void SaveChanges() { }
       
    }
}
