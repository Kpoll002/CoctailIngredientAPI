using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoctailsIngredient.Constant;
using CoctailsIngredient.Models;


namespace CoctailsIngredient.Client
{
    public class CoctailClient

    {
        private static string _apikey;
        private static string _host;
        private HttpClient _Client;
        private static string _address;
        public CoctailClient()
        {

            _apikey = Constat.apikey;
            _host = Constat.apihost;
            _address = Constat.address;
            _Client = new HttpClient();
            _Client.BaseAddress = new Uri(_address);
        }

        public async Task<SearchByIngredient> GetSearchByIngredientAsync(string ingredient)
        {


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/filter.php?i={ingredient}"),
                Headers =
                {
                { "X-RapidAPI-Key", $"{_apikey}" },
                { "X-RapidAPI-Host", $"{_host}" },
                },
            };
            using (var response = await _Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SearchByIngredient>(content);
                return result;
            }
        }
        public async Task<SearchByName> GetSearchByNameAsync(string NameOfCoctail)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/search.php?i={NameOfCoctail}"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{_apikey}" },
                    { "X-RapidAPI-Host", $"{_host}" },
                }
            };

            using (var response = await _Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SearchByName>(body);
                return result;
            }
        }
        public async Task<RandomCoctail> GetRandomCoctailsAsync()
        {
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/random.php"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{_apikey}" },
                    { "X-RapidAPI-Host", $"{_host}" },
                }
            };
            using (var response = await _Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var result = JsonConvert.DeserializeObject<RandomCoctail>(body);
                return result;
            }
        }
        public async Task<ListOfPopularCoctails> GetListOfPopularCoctailsAsync()
        {
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/popular.php"),
                Headers =
                {
                     { "X-RapidAPI-Key", $"{_apikey}" },
                     { "X-RapidAPI-Host", $"{_host}"  },
                }

            };
            using (var response = await _Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ListOfPopularCoctails>(body);
                return result;
            }

        }
        public async Task<ListOfIngredients> GetListOfIngredientsAsync()
        {
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_address}/list.php?i=list"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{_apikey}" },
                    { "X-RapidAPI-Host", $"{_host}" },
                }

            };
            using (var response = await _Client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ListOfIngredients>(body);
                return result;
            }
        }

    }

}
