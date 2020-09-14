using System.ComponentModel.DataAnnotations;

namespace WebStoreGusev.ViewModels.Identity
{
    public class RegisterUserViewModel
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required, MaxLength(256)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        
        /// <summary>
        /// E-Mail пользователя.
        /// </summary>
        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "Почтовый адрес")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [Required, DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        /// <summary>
        /// Подтверждение пароля пользователя.
        /// </summary>
        [DataType(DataType.Password), Compare(nameof(Password))]
        [Required, Display(Name = "Подтвердите ввод пароля")]
        public string ConfirmPassword { get; set; }
    }
}
