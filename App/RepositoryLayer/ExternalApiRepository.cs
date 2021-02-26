using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace RepositoryLayer
{
    public class ExternalApiRepository<T> : IRepository<Nobel>
    {
        readonly HttpClient _httpClient;

        public ExternalApiRepository()
        {
            _httpClient = new HttpClient();
        }

        public Nobel GetAll()
        {
            _httpClient.BaseAddress= new Uri("http://api.nobelprize.org/v1/");

            var response = _httpClient.GetAsync("prize.json?");

            response.Wait();

            var contentStream = response.Result.Content.ReadAsStreamAsync();

            contentStream.Wait();
            

            var a =  JsonSerializer.DeserializeAsync<Nobel>(contentStream.Result, new JsonSerializerOptions { IgnoreNullValues = true , PropertyNameCaseInsensitive = true});
            return a.Result;
        }

        public Nobel GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
