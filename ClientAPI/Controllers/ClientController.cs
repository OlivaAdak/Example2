using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        Uri baseAddress = new Uri("https://localhost:44369/api");
        HttpClient client;

        public ClientController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        // GET: api/<ClientController>
        [HttpGet("GetDetails")]
        //[Route("GetDetails")]
        public IActionResult GetDetails()
        {
            List<GroceryClient> ls = new List<GroceryClient>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Grocery/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<GroceryClient>>(data);
            }
            return Ok(ls);
            
        }

        // GET api/<ClientController>/5
        [HttpGet("GetDetails/{id}")]
        //[Route("GetDetail")]
        public IActionResult GetDetails(int id)
        {
            GroceryClient obj = new GroceryClient();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Grocery/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<GroceryClient>(data);
            }

            return Ok(obj);
        }

        [HttpPost]
        public ActionResult Create(GroceryClient cl)
        {
            string data = JsonConvert.SerializeObject(cl);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Grocery/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return Ok(cl);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Edit(int id,GroceryClient goc)
        {
            string data = JsonConvert.SerializeObject(goc);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Grocery/" + id, content).Result;
            if (response.IsSuccessStatusCode)
                return Ok(goc);
            return BadRequest();
        }


        // DELETE api/<ClientController>/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Grocery/" + id).Result;
            if (response.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
    }
}
