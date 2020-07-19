
namespace WebStoreGusev.Domain
{
    /// <summary>
    /// Класс для фильтрации товаров.
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Категория, к которой принадлежит продукт.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Бренд протукта (если имеется).
        /// </summary>
        public int? BrandId { get; set; }
    }
}
