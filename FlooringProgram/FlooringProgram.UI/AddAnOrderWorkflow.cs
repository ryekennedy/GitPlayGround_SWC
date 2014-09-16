using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;
using FlooringProgram.BLL;

namespace FlooringProgram.UI
{
    public class AddAnOrderWorkflow
    {
        public  void Execute()
        {
            //load product repository
            var orderManager = OrderManagerFactory.CreateInstance();
            var taxManager = TaxManagerFactory.CreateInstance();

            Console.Clear();
            Console.WriteLine("---------Add an Order--------");

            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Today.Date.ToString("MMddyyyy");

            Console.WriteLine("Enter Customer Name: " );
            newOrder.CustomerName = Console.ReadLine();
            


            bool validState = false;
            while (!validState)
            {

                Console.WriteLine("Enter State Abbreviation: ");
                newOrder.StateTax.StateAbbreviation = Console.ReadLine();

                var taxInfo = taxManager.ValidateState(newOrder);

                if(taxInfo == null)
                    Console.WriteLine("That is not a valid state");
                else
                {
                    validState = true;
                }
            }



            Console.WriteLine("List of Product Options:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductType);
            }

            
            Console.WriteLine("Enter Product Type: ");
            newOrder.Product.ProductType = Console.ReadLine();

            foreach(var product in products.Where(p => p.ProductType == newOrder.Product.ProductType))
            {
                newOrder.Product.CostPersquareFoot = product.CostPersquareFoot;
                newOrder.Product.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            }
            
                
            
            Console.WriteLine("Enter Order Area: ");
            newOrder.Area = decimal.Parse(Console.ReadLine());

            
            OrderCostCalculation.CalculateMaterialCost(newOrder);
            OrderCostCalculation.CalculateLaborCost(newOrder);
            OrderCostCalculation.CalculateTaxCost(newOrder);
            OrderCostCalculation.CalculateOrderTotal(newOrder);

            DisplayOrdersWorkflow displayOrdersWorkflow = new DisplayOrdersWorkflow();

            displayOrdersWorkflow.PrintOrder(newOrder);

            Console.WriteLine("Would you like to save this order (Y or N)?");
            var answer = Console.ReadLine();
            if (answer == "Y")
            {
                OrderSaveToFile orderSaveToFile = new OrderSaveToFile();
                orderSaveToFile.Execute(newOrder);
            }
                



            Console.ReadLine();
        }
    }
}
