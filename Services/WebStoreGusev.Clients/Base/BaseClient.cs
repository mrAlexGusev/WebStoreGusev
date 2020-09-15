using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebStoreGusev.Clients.Base
{
    public abstract class BaseClient
    {
        protected readonly string serviceAddress;
        protected readonly HttpClient client;

        protected BaseClient(IConfiguration configuration, 
            string ServiceAddress)
        {
            serviceAddress = ServiceAddress;
            client = new HttpClient
            {
                BaseAddress = new Uri(configuration["WebApiURL"]),
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
