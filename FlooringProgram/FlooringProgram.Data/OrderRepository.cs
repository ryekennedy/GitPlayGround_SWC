using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {
        private string FileName = "Orders_06012013.txt";
        private const string HeaderRow = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";
       
        public List<Order> LoadAll(string fileDate)
        {
            FileName = "Orders_" + fileDate + ".txt";
            var allOrders = File.ReadAllLines(FileName);
            var orders = new List<Order>();

            // start at position 1, because we don't want the header row
            for (int i = 1; i < allOrders.Length; i++)
            {
                // split the csv, this returns a string array of each column value
                var columns = allOrders[i].Split(',');

                // need a contact object to put the data in
                var newOrder = new Order();

                // read the data into the objects one column at a time, enums are ints, but we need to cast (int)
                newOrder.OrderNumber = int.Parse(columns[(int)OrderColumns.OrderNumber]);
                newOrder.CustomerName = columns[(int)OrderColumns.CustomerName];
                newOrder.StateTax.StateAbbreviation = columns[(int)OrderColumns.State];
                newOrder.StateTax.TaxRate = decimal.Parse(columns[(int)OrderColumns.TaxRate]);
                newOrder.Product.ProductType = columns[(int)OrderColumns.ProductType];
                newOrder.Area= decimal.Parse(columns[(int)OrderColumns.Area]);

                newOrder.Product.CostPersquareFoot= decimal.Parse(columns[(int)OrderColumns.CostPerSquareFoot]);
                newOrder.Product.LaborCostPerSquareFoot = decimal.Parse(columns[(int) OrderColumns.LaborCost]);
                newOrder.OrderCost.MaterialCost = decimal.Parse(columns[(int)OrderColumns.MaterialCost]);
                newOrder.OrderCost.LaborCost = decimal.Parse(columns[(int)OrderColumns.LaborCost]);

                newOrder.OrderCost.Tax = decimal.Parse(columns[(int)OrderColumns.Tax]);
                newOrder.OrderCost.Total = decimal.Parse(columns[(int)OrderColumns.Total]);

                orders.Add(newOrder);


            }
            return orders;

        }

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
