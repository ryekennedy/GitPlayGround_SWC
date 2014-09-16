using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        //private ITaxRepository _taxRepository;

        // Dependency
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetOrdersFor(string date)
        {
            return _orderRepository.LoadAll(date);
        }

        public void Add(Order order)
        {
            // check if the tax rate is good
            // check if the product is good
            // do the calculations

            _orderRepository.Add(order);
        }





 
    }
}
