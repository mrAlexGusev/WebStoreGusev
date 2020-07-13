using System.ComponentModel.DataAnnotations;

namespace WebStoreGusev.Models
{
    /// <summary>
    /// Модель представления информации о сотруднике.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2х и не более 100 символов.")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
