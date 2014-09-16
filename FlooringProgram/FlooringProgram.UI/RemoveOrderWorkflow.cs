using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.UI
{
    class RemoveOrderWorkflow
    {
        DisplayOrdersWorkflow display = new DisplayOrdersWorkflow();
        OrderRepository orderrepo = new OrderRepository();
        OrderSaveToFile save = new OrderSaveToFile();
        public void Execute()
        {
            Console.WriteLine("Remove an Order");
            Console.WriteLine("What date was the order placed?(MMDDYYYY): ");
            var orderDate = Console.ReadLine();
            Console.ReadLine();
            if (File.Exists("Orders_" + orderDate + ".txt") == true)
            {
                var allOrders = orderrepo.LoadAll(orderDate);
                display.DisplayOrdersByDate(orderDate);

                Console.WriteLine("Choose an order number: ");
                var orderNumberChoice = Console.ReadLine();

                var selectedOrder = allOrders.RemoveAll(o => o.OrderNumber == int.Parse(orderNumberChoice));

                save.SaveListToFile(allOrders);

                


            }
            
        }
    }
    
}
