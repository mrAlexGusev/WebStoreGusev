using System.Collections.Generic;
using WebStoreGusev.Domain.Entities;

namespace WebStoreGusev.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса продуктов.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Получение списка категорий товаров.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategories();

        /// <summary>
        /// Получение списка брендов товаров.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetBrands();

        /// <summary>
        /// Получение списка товаров.
        /// </summary>
        /// <param name="filter"> Фильтр товаров. </param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(ProductFilter filter);

        /// <summary>
        /// Получение товара по id.
        /// </summary>
        /// <param name="id"> ID </param>
        /// <returns></returns>
        Product GetProductById(int id);
    }
}
