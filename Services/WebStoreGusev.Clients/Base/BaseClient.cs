using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebStoreGusev.Clients.Base
{
    /// <summary>
    /// Базовый клиент.
    /// </summary>
    public abstract class BaseClient
    {
        protected readonly string serviceAddress;

        /// <summary>
        /// Http клиент для связи.
        /// </summary>
        protected readonly HttpClient client;

        protected BaseClient(IConfiguration configuration, 
            string ServiceAddress)
        {
            serviceAddress = ServiceAddress;

            // Создаем экземпляр клиента
            client = new HttpClient
            {
                // Базовый адрес, на котором будут хостится сервисы
                BaseAddress = new Uri(configuration["WebApiURL"]),

                // Устанавливаем хедер, который будет говорить серверу,
                // чтобы он отправлял данные в формате json.
                DefaultRequestHeaders =
                {
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("application/json")
                    }
                }
            };
        }
    }
}
