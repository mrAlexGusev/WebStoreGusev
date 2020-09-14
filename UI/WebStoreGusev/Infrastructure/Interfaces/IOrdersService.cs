using System.Collections.Generic;
using WebStoreGusev.Domain.Entities.Orders;
using WebStoreGusev.ViewModels;
using WebStoreGusev.ViewModels.Orders;

namespace WebStoreGusev.Infrastructure.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Получение списка заказов пользователя.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        /// <returns></returns>
        IEnumerable<Order> GetUserOrders(string userName);

        /// <summary>
        /// Получение заказа по ID.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns></returns>
        Order GetOrderById(int id);

        /// <summary>
        /// Создание заказа из корзины.
        /// </summary>
        /// <param name="orderModel"></param>
        /// <param name="transformCart"></param>
        /// <param name="userName"> Имя пользователя. </param>
        /// <returns></returns>
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);
    }
}
