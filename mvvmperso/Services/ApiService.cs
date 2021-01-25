using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using mvvmperso.Core;
using mvvmperso.Models;

namespace mvvmperso.Services
{
    public class ApiService : IApiService
    {
        private static readonly string articlesUrl = "https://www.lemonde.fr/rss/une.xml";
        private readonly HttpClient httpClient = new();
        public ApiService()
        {
        }

        public async Task<Response<List<Article>>> GetArticles()
        {
            var response = await GetResponse(articlesUrl);
            if (!response.IsSuccess)
            {
                return new Response<List<Article>>(response.Error);
            }
            else
            {
                var xDocument = XDocument.Parse(response.Data);
                var items = xDocument.Root.Descendants("item").ToList();
                var articles = items.Select((item) => new Article
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    PubDate = item.Element("pubDate").Value
                }).ToList();
                return new Response<List<Article>>(articles);
            }
        }

        public async Task<Response<string>> GetResponse(string url)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return new Response<string>(result);
            }
            catch (HttpRequestException error)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", error.Message);
                return new Response<string>(error);
            }
        }
    }
}
