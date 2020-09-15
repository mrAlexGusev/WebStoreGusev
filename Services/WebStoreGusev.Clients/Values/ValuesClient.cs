using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebStoreGusev.Clients.Base;
using WebStoreGusev.Interfaces.Api;

namespace WebStoreGusev.Clients.Values
{
    public class ValuesClient : BaseClient, IValueServices
    {
        public ValuesClient(IConfiguration configuration) : base(configuration, "api/values")
        {

        }

        public HttpStatusCode Delete(int id)
        {
            var response = client.DeleteAsync($"{serviceAddress}/delete/{id}").Result;
            return response.StatusCode;
        }

        public IEnumerable<string> Get()
        {
            var response = client.GetAsync(serviceAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<string>>().Result;
            }

            return Enumerable.Empty<string>();
        }

        public string Get(int id)
        {
            var response = client.GetAsync($"{serviceAddress}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<string>().Result;
            }

            return string.Empty;
        }

        public Uri Post(string value)
        {
            var response = client.PostAsJsonAsync($"{serviceAddress}/post", value).Result;
            return response.EnsureSuccessStatusCode().Headers.Location;
        }

        public HttpStatusCode Update(int id, string value)
        {
            var response = client.PutAsJsonAsync($"{serviceAddress}/put/{id}", value).Result;
            return response.EnsureSuccessStatusCode().StatusCode;
        }
    }
}
