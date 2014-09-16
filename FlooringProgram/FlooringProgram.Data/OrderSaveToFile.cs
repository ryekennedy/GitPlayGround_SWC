using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class OrderSaveToFile
    {
        OrderRepository repo = new OrderRepository();

        private string orderDate = "";
        private string FileName = "";

        private const string HeaderRow = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

        public void Execute(Order newOrder)
        {
            if (CheckOrderFileExistAlready(newOrder))
            {
                AddOrderNumber(newOrder);
            }
            else
            {
                List<Order> orderList = new List<Order>();
                newOrder.OrderNumber = 1;
                orderList.Add(newOrder);
                SaveListToFile(orderList);
            }
        }

        

        public bool CheckOrderFileExistAlready(Order newOrder)
        {
            orderDate = newOrder.OrderDate;
            FileName = "Orders_" + orderDate + ".txt";
            return File.Exists(FileName);

        }




        public void AddOrderNumber(Order newOrder)
        {
            var allOrders = repo.LoadAll(newOrder.OrderDate);
            newOrder.OrderNumber = allOrders.Max(o => o.OrderNumber) + 1;

            allOrders.Add(newOrder);
            orderDate = newOrder.OrderDate;
            FileName = "Orders_" + orderDate + ".txt";
            SaveListToFile(allOrders);

        }

        public void SaveListToFile(List<Order> orderList)
        {
            using (StreamWriter writer = File.CreateText(FileName))
            {
                writer.WriteLine(HeaderRow);
                foreach (var order in orderList)
                {
                    var informationToSave = order.OrderNumber + "," + order.CustomerName + "," +
                                            order.StateTax.StateAbbreviation + "," + order.StateTax.TaxRate + "," +
                                            order.Product.ProductType + "," +
                                            order.Area + "," + order.Product.CostPersquareFoot + "," +
                                            order.Product.LaborCostPerSquareFoot + "," + order.OrderCost.MaterialCost +
                                            "," +
                                            order.OrderCost.LaborCost + "," + order.OrderCost.Tax + "," +
                                            order.OrderCost.Total;

                    writer.WriteLine(informationToSave);
                }
            }

        }
    }
}
