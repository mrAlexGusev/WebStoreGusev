using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGusev.Domain.Entities.Base;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities
{
    /// <summary>
    /// Категория товара.
    /// </summary>
    public class Category : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Родительская секция (при наличии).
        /// </summary>
        public int? ParentId { get; set; }

        public int Order { get; set; }
    }
}
