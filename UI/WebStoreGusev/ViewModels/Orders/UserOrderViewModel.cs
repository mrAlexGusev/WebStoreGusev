namespace WebStoreGusev.ViewModels.Orders
{
    public class UserOrderViewModel
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Итоговая сумма.
        /// </summary>
        public decimal TotalSum { get; set; }
    }
}
