using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DarazmontioneringApp.MVVM.Services
{

    public class DarazApiService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<string> GetOrdersAsync(string accessToken)
        {
            string url = $"https://api.daraz.pk/rest/orders/get?access_token={accessToken}";
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }

}
