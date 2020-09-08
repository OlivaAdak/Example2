using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        readonly GroceryDBContext _con;
        public GroceryController(GroceryDBContext con)
        {
            _con = con;
        }
        // GET: api/<GroceryController>
        [HttpGet]
        public IEnumerable<Grocery> Get()
        {
            return _con.Groceries.ToList();
        }

        // GET api/<GroceryController>/5
        [HttpGet("{id}")]
        public Grocery Get(int id)
        {
            Grocery x = _con.Groceries.Where(c => c.ItemId==id).FirstOrDefault();
            return x;
            
        }

        // POST api/<GroceryController>
        [HttpPost]
        public void Post([FromBody] Grocery g)
        {
            _con.Groceries.Add(g);
            _con.SaveChanges();

        }

        // PUT api/<GroceryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Grocery g)
        {
            Grocery obj = _con.Groceries.Where(x => x.ItemId == id).FirstOrDefault();
            if(obj!=null)
            {
                obj.ItemName = g.ItemName;
                obj.BestBefore = g.BestBefore;
                obj.Price = g.Price;
                _con.SaveChanges();
            }
        }

        // DELETE api/<GroceryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _con.Groceries.Remove(_con.Groceries.Where(x => x.ItemId == id).FirstOrDefault());
            _con.SaveChanges();
        }
    }
}
