using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreGusev.Domain.Entities.Base;

namespace WebStoreGusev.Domain.Entities.Orders
{
    public class OrderItem : BaseEntity
    {
        // сгенерирует внешний ключ в БД
        [Required]
        public virtual Order Order { get; set; }

        // сгенерирует внешний ключ в БД
        [Required]
        public virtual Product Product { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }       
    }
}
