using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

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

        #region Методы реализации запросов

        protected T Get<T>(string url) where T : new() => GetAsync<T>(url).Result;

        protected async Task<T> GetAsync<T>(string url,
            CancellationToken token = default) where T : new()
        {
            var response = await client.GetAsync(url, token);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>(token);
            }

            return new T();
        }

        protected HttpResponseMessage Post<T>(string url, T item) =>
            PostAsync(url, item).Result;

        protected async Task<HttpResponseMessage> PostAsync<T>(string url,
            T item, CancellationToken token = default)
        {
            var response = await client.PostAsJsonAsync(url, item, token);
            return response.EnsureSuccessStatusCode();
        }

        protected HttpResponseMessage Put<T>(string url, T item) =>
           PutAsync(url, item).Result;

        protected async Task<HttpResponseMessage> PutAsync<T>(string url,
            T item, CancellationToken token = default)
        {
            var response = await client.PutAsJsonAsync(url, item, token);
            return response.EnsureSuccessStatusCode();
        }

        protected HttpResponseMessage Delete(string url) =>
           DeleteAsync(url).Result;

        protected async Task<HttpResponseMessage> DeleteAsync(string url,
            CancellationToken token = default) =>
                await client.DeleteAsync(url, token);

        #endregion
    }
}
