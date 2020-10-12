using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebStoreGusev.Domain.ViewModels;
using WebStoreGusev.Interfaces.Services;
using WebStoreGusev.Services.Mapping;
using WebStoreGusev.ViewModels;

namespace WebStoreGusev.Controllers
{
    /// <summary>
    /// Тестовый контроллер. Работа с сотрудниками.
    /// </summary>
    //[Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {        
        private readonly IEmployeesServices employeesServices;

        public EmployeeController(IEmployeesServices employeesServices) => 
            this.employeesServices = employeesServices;

        // /users/all
        [Route("all")]
        [AllowAnonymous]
        public IActionResult Index() => 
            View(employeesServices.GetAll()
                .Select(e => e.ToView()));

        // /users/{id}
        //[Route("{id}")]
        /// <summary>
        /// Информация о сотруднике.
        /// </summary>
        /// <param name="id"> ID сотрудника. </param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var employee = employeesServices.GetById(id);
            if (employee is null) { return NotFound(); }

            return View(employee.ToView());
        }

        [Authorize(Roles = "Admins")]
        [HttpGet]
        public IActionResult Create() => View(new EmployeeViewModel());

        [Authorize(Roles = "Admins"), ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (model is null) { throw new ArgumentNullException(nameof(model)); }

            if (!ModelState.IsValid) { return View(model); }

            employeesServices.Add(model.FromView());
            employeesServices.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Добавление или редактирование сотрудника. GET-запрос.
        /// </summary>
        /// <param name="id"> ID сотрудника. </param>
        /// <returns></returns>
        // /users/edit/{id}
        [Route("edit/{id?}"), Authorize(Roles = "Admins")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) { return View(new EmployeeViewModel()); }

            var employee = employeesServices.GetById(id.Value);
            if (employee == null) { return NotFound(); }

            return View(employee.ToView());
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

            if (model is null) { throw new ArgumentNullException(nameof(model)); }

            if (!ModelState.IsValid) { return View(model); }

            var id = model.Id;

            if (id == 0)
            {
                employeesServices.Add(model.FromView());
            }
            else
            {
                employeesServices.Edit(id, model.FromView());
            }
            
            // станет актуальным после подключения БД
            employeesServices.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //-----------------------------
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
            if (id <= 0) return BadRequest();

            var employee = employeesServices.GetById(id);
            if (employee is null) { return NotFound(); }

            return View(employee.ToView());
        }

        [Authorize(Roles = "Admins")]
        public IActionResult DeleteConfirmed(int id)
        {
            employeesServices.Delete(id);
            employeesServices.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
