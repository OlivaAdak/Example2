using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.Models
{
    public class Grocery
    {
        [Key]
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public DateTime BestBefore { get; set; }
        public int Price { get; set; }
    }
}
