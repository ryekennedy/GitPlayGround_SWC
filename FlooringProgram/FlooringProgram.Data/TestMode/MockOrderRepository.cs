using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.TestMode
{
    public class MockOrderRepository : IOrderRepository
    {
        public List<Order> LoadAll(string fileDate)
        {
            return new List<Order>()
            {
                new Order() { OrderNumber = 1, CustomerName = "Eric", Area=100M, OrderCost = new OrderCost {LaborCost = 10M, MaterialCost = 20M}}
            };
        }

        public void AddOrderToRepository(Order order)
        {
            return;
        }
    }
}
