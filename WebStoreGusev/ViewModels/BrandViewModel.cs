using WebStoreGusev.Domain.Entities.Base.Interfaces;

namespace WebStoreGusev.ViewModels
{
    /// <summary>
    /// Модель представления брендов товаров.
    /// </summary>
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Количество товаров бренда.
        /// </summary>
        public int ProductsCount { get; set; }
    }
}
