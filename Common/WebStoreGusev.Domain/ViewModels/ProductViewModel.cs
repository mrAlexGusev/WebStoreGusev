using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.ViewModels
{
    public class ProductViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Url картинки товара.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Цена товара.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Бренд товара.
        /// </summary>
        public string Brand { get; set; }
    }
}
