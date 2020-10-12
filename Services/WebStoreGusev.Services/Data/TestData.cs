using System.Collections.Generic;
using WebStoreGusev.Domain.Models;

namespace WebStoreGusev.Services.Data
{
    /// <summary>
    /// Класс тестовых данных.
    /// </summary>
    public class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Программист"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Петр",
                LastName = "Петров",
                Patronymic = "Петрович",
                Age = 35,
                Position = "Менеджер"
            },
            new Employee
            {
                Id = 3,
                FirstName = "Роман",
                LastName = "Романов",
                Patronymic = "Романович",
                Age = 28,
                Position = "Электрик"
            },
            new Employee
            {
                Id = 4,
                FirstName = "Олег",
                LastName = "Олегов",
                Patronymic = "Олегович",
                Age = 31,
                Position = "Сантехник"
            },
            new Employee
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
}
