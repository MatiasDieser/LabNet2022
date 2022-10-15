using Lab.TP7.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Lab.TP8.EF.Entities;
using Lab.TP8.Services;

namespace Lab.TP7.MVC.Controllers
{

    public class ApiController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public ApiController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
       
        [HttpGet]
        public async Task<ActionResult> Index()
        {
			
            using(var httpClient = new HttpClient(_clientHandler))
            {
                using(var response = await httpClient.GetAsync("https://catfact.ninja/fact?max_length=130"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var catFacts = JsonConvert.DeserializeObject(apiResponse);
                    return View(catFacts);
                }                
            }
		}
        [HttpGet]
        public async Task<ActionResult> ListOfFacts()
        {

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://catfact.ninja/facts?max_length=300&limit=15"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var catFacts = JsonConvert.DeserializeObject(apiResponse);
                    return View(catFacts);
                }
            }
        }
        [HttpGet]
        public async Task<ActionResult> Razas()
        {

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://catfact.ninja/breeds?limit=5"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var catFacts = JsonConvert.DeserializeObject(apiResponse);
                    return View(catFacts);
                }
            }
        }
        ShippersService _service = new ShippersService();
        public async Task<IActionResult> PruebaShippers()
        {
            IEnumerable<Shippers> shippers = await _service.GetAll();
            return (IActionResult)View("PruebaShippers", shippers);
        }
    }
}