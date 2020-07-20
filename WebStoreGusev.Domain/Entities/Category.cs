using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreGusev.Domain.Entities.Base;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities
{
    /// <summary>
    /// Категория товара.
    /// </summary>
    [Table("Categories")]
    public class Category : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Родительская секция (при наличии).
        /// </summary>
        public int? ParentId { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
    }
}
