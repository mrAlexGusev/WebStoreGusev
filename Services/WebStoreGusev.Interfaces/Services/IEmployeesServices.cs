using System.Collections.Generic;
using WebStoreGusev.ViewModels;

namespace WebStoreGusev.Infrastructure.Interfaces
{
    public interface IEmployeesServices
    {
        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeViewModel> GetAll();

        /// <summary>
        /// Получение сотрудника по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeViewModel GetById(int id);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
        /// <param name="model"></param>
        void Add(EmployeeViewModel model);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Изменить данные сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="model"></param>
        void Edit(int id, EmployeeViewModel model);
    }
}
