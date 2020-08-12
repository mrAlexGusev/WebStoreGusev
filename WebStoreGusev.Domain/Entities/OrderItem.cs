using WebStoreGusev.Domain.Entities.Base;

namespace WebStoreGusev.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // сгенерирует внешний ключ в БД
        public virtual Order Order { get; set; }

        // сгенерирует внешний ключ в БД
        public virtual Product Product { get; set; }
    }
}
