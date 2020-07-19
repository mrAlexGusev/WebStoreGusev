using System.Collections.Generic;
using WebStoreGusev.Domain;
using WebStoreGusev.Domain.Entities;

namespace WebStoreGusev.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса продуктов.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Получение категорий товаров.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategories();

        /// <summary>
        /// Получение брендов товаров.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetBrands();

        /// <summary>
        /// Получение товаров.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}
