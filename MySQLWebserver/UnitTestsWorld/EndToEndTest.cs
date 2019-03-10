using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WorldWebServer.Models;
using Xunit;

namespace UnitTestsWorld
{
    class EndToEndTest
    {
        const string LOCALHOST = "http://localhost:5000";
        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(LOCALHOST);
            var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
            return httpClient;
        }
        private bool SameCity(City c1, City c2)
        {
            //this will return true or false based on operation below;
            return c1.ID == c2.ID && c1.Name == c2.Name && c1.CountryCode == c2.CountryCode && c1.District == c2.District && c1.Population == c2.Population;
        }
        [Fact]
        public async void GetAllCountriesTest()
        {
            var httpClient = GetHttpClient();
            var response = await httpClient.GetAsync("api/country");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
