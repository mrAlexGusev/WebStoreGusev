using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGusev.Clients.Base;
using WebStoreGusev.Domain;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.ViewModels;

namespace WebStoreGusev.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesServices
    {
        public EmployeesClient(IConfiguration configuration)
            : base(configuration, WebAPI.Employees) { }

        public IEnumerable<EmployeeViewModel> GetAll() =>
            Get<List<EmployeeViewModel>>(serviceAddress);

        public EmployeeViewModel GetById(int id) =>
            Get<EmployeeViewModel>($"{serviceAddress}/{id}");

        public void Add(EmployeeViewModel model) =>
            Post(serviceAddress, model);

        public void Edit(int id, EmployeeViewModel model) =>
            Put($"{serviceAddress}/{id}", model);


        public bool Delete(int id) => 
            Delete($"{serviceAddress}/{id}").IsSuccessStatusCode;
        
        public void SaveChanges() { }
       
    }
}
