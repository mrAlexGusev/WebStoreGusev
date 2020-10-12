using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebStoreGusev.Domain.ViewModels
{
    /// <summary>
    /// Модель представления информации о сотруднике.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// ID.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Имя является обязательным")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength:100, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2х и не более 100 символов.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Фамилия является обязательным")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Возраст является обязательным")]
        [Display(Name = "Возраст")]
        [Range(18, 75, ErrorMessage = "Возраст в интервале от 18 до 75")]
        public int Age { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Должность является обязательным")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
