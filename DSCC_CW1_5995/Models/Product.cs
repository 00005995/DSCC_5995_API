using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5995.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
    }
}
