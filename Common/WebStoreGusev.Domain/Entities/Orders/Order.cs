using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebStoreGusev.Domain.Entities.Base;
using WebStoreGusev.Domain.Entities.Identity;

namespace WebStoreGusev.Domain.Entities.Orders
{
    public class Order : NamedEntity
    {
        // внешний ключ в БД
        [Required]
        public virtual User User { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }
        
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
