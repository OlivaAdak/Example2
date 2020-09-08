using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAPI.Models
{
    public class GroceryClient
    {
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public DateTime BestBefore { get; set; }
        public int Price { get; set; }
    }
}
