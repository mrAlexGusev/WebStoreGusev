using System;
using System.Collections.ObjectModel;
using WebStoreGusev.Domain.Entities.Base;

namespace WebStoreGusev.Domain.Entities
{
    public class Order : NamedEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        // внешний ключ в БД
        public virtual User User { get; set; }

        public virtual Collection<OrderItem> OrderItems { get; set; }
    }
}
