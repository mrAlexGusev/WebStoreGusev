using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreGusev.Domain.Entities.Base;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities
{
    /// <summary>
    /// Бренд товара.
    /// </summary>
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
