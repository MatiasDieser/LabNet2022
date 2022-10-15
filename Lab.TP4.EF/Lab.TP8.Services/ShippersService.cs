using Lab.TP8.EF.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP8.Services
{
    public class ShippersService
    {
        string url = "https://localhost:44331/api/Shippers";
        public async Task<IEnumerable<Shippers>> GetAll()
        {           
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var shippers = JsonConvert.DeserializeObject<List<Shippers>>(apiResponse);
            return shippers;
        }
        public async Task<IEnumerable<Shippers>> GetByID(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url+$"/{id}");
            var apiResponse = await response.Content.ReadAsStringAsync();
            var shippers = JsonConvert.DeserializeObject<List<Shippers>>(apiResponse);
            return shippers;
        }
    }
}
