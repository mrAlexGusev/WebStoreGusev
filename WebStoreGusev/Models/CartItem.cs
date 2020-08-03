using System;
using System.Threading.Tasks;

namespace WebStoreGusev.Models
{
    public class CartItem
    {
        /// <summary>
        /// Id товара.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Quantity { get; set; }
    }
}
