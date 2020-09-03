using System.ComponentModel.DataAnnotations.Schema;
using WebStoreGusev.Domain.Entities.Base;
using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.Domain.Entities
{
    /// <summary>
    /// Продукт.
    /// </summary>
    [Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Категория, к которой принадлежит продукт.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Бренд протукта (если имеется).
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Ссылка на картинку продукта.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Цена продукта.
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
