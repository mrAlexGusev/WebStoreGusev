using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.ViewModels;

namespace WebStoreGusev.Controllers
{
    /// <summary>
    /// Тестовый контроллер. Работа с сотрудниками.
    /// </summary>
    [Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {        
        private readonly IEmployeesServices employeesServices;

        public EmployeeController(IEmployeesServices employeesServices)
        {
            this.employeesServices = employeesServices;
        }

        // /users/all
        [Route("all")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //return Content("Hello from home controller");
            return View(employeesServices.GetAll());
        }

        // /users/{id}
        /// <summary>
        /// Информация о сотруднике.
        /// </summary>
        /// <param name="id"> ID сотрудника. </param>
        /// <returns></returns>
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var employee = employeesServices.GetById(id);

            if (ReferenceEquals(employee, null)) return NotFound();

            return View(employee);
        }

        /// <summary>
        /// Добавление или редактирование сотрудника. GET-запрос.
        /// </summary>
        /// <param name="id"> ID сотрудника. </param>
        /// <returns></returns>
        // /users/edit/{id}
        [Route("edit/{id?}")]
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return View(new EmployeeViewModel());

            var model = employeesServices.GetById(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }

        /// <summary>
        /// Добавление или редактирование сотрудника. POST-запрос.
        /// </summary>
        /// <param name="id"> ID сотрудника. </param>
        /// <returns></returns>
        // /users/edit/{id}
        [Route("edit/{id?}")]
        [HttpPost]
        [Authorize(Roles = "Admins")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            #region Реализация собственной валидации

            if (model.Age < 18 || model.Age > 100)
            {
                ModelState.AddModelError("Age", "Ошибка возраста!");
            }

            #endregion

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // если есть Id, то редактируем модель
            if (model.Id > 0)
            {
                var dbItem = employeesServices.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();

                dbItem.FirstName = model.FirstName;
                dbItem.LastName = model.LastName;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Age = model.Age;
                dbItem.Position = model.Position;
            }
            // иначе добавляем модель в список
            else
            {
                employeesServices.Add(model);
            }

            // станет актуальным после подключения БД
            employeesServices.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удаление сотрудника.
        /// </summary>
        /// <param name="id"> ID сотрудника. </param>
        /// <returns></returns>
        // /users/delete/{id}
        [Route("delete/{id}")]
        [Authorize(Roles = "Admins")]
        public IActionResult Delete(int id)
        {
            employeesServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
