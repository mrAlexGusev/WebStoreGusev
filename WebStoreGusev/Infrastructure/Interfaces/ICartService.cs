using WebStoreGusev.Models;

namespace WebStoreGusev.Infrastructure.Interfaces
{
    public interface ICartService
    {
        /// <summary>
        /// Уменьшить количество.
        /// </summary>
        /// <param name="id"> Id продукта. </param>
        void DecrementFromCart(int id);

        /// <summary>
        /// Удалить из корзины.
        /// </summary>
        /// <param name="id"> Id продукта. </param>
        void RemoveFromCart(int id);

        /// <summary>
        /// Удалить всё.
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// Добавить в корзину.
        /// </summary>
        /// <param name="id"> Id продукта. </param>
        void AddToCart(int id);

        CartViewModel TransformCart();
    }
}
