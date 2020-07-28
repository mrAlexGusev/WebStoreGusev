using System.ComponentModel.DataAnnotations;

namespace WebStoreGusev.Models
{
    public class RegisterUserViewModel
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required, MaxLength(256)]
        public string UserName { get; set; }
        
        /// <summary>
        /// E-Mail пользователя.
        /// </summary>
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        
        /// <summary>
        /// Подтверждение пароля пользователя.
        /// </summary>
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
