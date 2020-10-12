using WebStoreGusev.Domain.Models;
using WebStoreGusev.Domain.ViewModels;

namespace WebStoreGusev.Services.Mapping
{
    public static class EmployeeMapping
    {
        public static Employee FromView(this EmployeeViewModel e) => new Employee
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Patronymic = e.Patronymic,
            Age = e.Age,
            Position = e.Position
        };

        public static EmployeeViewModel ToView(this Employee e) => new EmployeeViewModel
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Patronymic = e.Patronymic,
            Age = e.Age,
            Position = e.Position
        };
    }
}
