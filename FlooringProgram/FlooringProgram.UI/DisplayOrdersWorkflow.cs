using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.UI
{
    public class DisplayOrdersWorkflow
    {
        public  void Execute()
        {
            
            
           Console.WriteLine("Display Orders");
            
            //Get user date input to display
            string displayDate = "";
            Console.WriteLine("Enter a date to load orders from: (MMDDYYYY 06012013");
            displayDate = Console.ReadLine();
            
            DisplayOrdersByDate(displayDate);
        }

        public void DisplayOrdersByDate(string displayDate)
        {
            var orderManager = OrderManagerFactory.CreateInstance();


            var orders = orderManager.GetOrdersFor(displayDate);

            Console.Clear();
            Console.WriteLine("------------Orders for {0}--------", displayDate);

            foreach (var order in orders)
            {
                PrintOrder(order);
            }


            Console.ReadLine();
        }

        public void PrintOrder(Order order)
        {
            Console.WriteLine("Order Number: {0}, Customer Name {1}, State {2}, Product Type {3}, Area {4}, Order Total: {5}",
                order.OrderNumber, order.CustomerName, order.StateTax.StateAbbreviation, order.Product.ProductType, order.Area,
                order.OrderCost.Total);
        }
    }
}
