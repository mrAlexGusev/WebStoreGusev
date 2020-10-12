using System.Collections.Generic;
using WebStoreGusev.Domain.Models;

namespace WebStoreGusev.Interfaces.Services
{
    public interface IEmployeesServices
    {
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();

        /// <summary>
        /// Получение сотрудника по ID.
        /// </summary>
        /// <param name="id">ID сотрудника.</param>
        /// <returns></returns>
        Employee GetById(int id);

        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        void Add(Employee employee);

        /// <summary>
        /// Изменить данные сотрудника.
        /// </summary>
        /// <param name="id">ID сотрудника.</param>
        /// <param name="employee">Сотрудник.</param>
        void Edit(int id, Employee employee);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">ID сотрудника.</param>
        bool Delete(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        void SaveChanges();
    }
}
