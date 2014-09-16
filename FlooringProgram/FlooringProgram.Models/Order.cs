using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Order
    {
        public int OrderNumber{ get; set; }
        public string CustomerName { get; set; }
        public StateTax StateTax { get; set; }
        public Product Product { get; set; }
        public decimal Area { get; set; }
        public string OrderDate { get; set; }
        public OrderCost OrderCost { get; set; }

        public Order()
        {
            StateTax = new StateTax();
            Product = new Product();
            OrderCost = new OrderCost();

        }
    }

    
}
