using System;
using FlooringProgram.Models;
using FlooringProgram.BLL;
using FlooringProgram.Models.Responses;

namespace FlooringProgram.UI
{
    public class AddAnOrderWorkflow
    {
        public  void Execute()
        {
            //load product repository
            var orderManager = OrderManagerFactory.CreateInstance();
            var taxManager = TaxManagerFactory.CreateInstance();
            var productManager = ProductManagerFactory.CreateInstance();

            Console.Clear();
            Console.WriteLine("---------Add an Order--------");

            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Today.Date.ToString("MMddyyyy");

            Console.WriteLine("Enter Customer Name: " );
            newOrder.CustomerName = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter State Abbreviation: ");

                newOrder.StateTax.StateAbbreviation = Console.ReadLine();

                taxManager.AddState(newOrder);

                Console.WriteLine(taxManager.AddState(newOrder).Status);

            } while (!taxManager.AddState(newOrder).Success);

            taxManager.AssignStateValues(newOrder);

            
            Console.WriteLine("List of Product Options:");

            var productList = productManager.LoadProductList();
            foreach (var product in productList)
            {
                Console.WriteLine(product.ProductType);
            }

            do
            {
                Console.WriteLine("Enter Product Type: ");

                newOrder.Product.ProductType = Console.ReadLine();

                productManager.AddProduct(newOrder);

                Console.WriteLine(productManager.AddProduct(newOrder).Status);

            } while (!productManager.AddProduct(newOrder).Success);

            productManager.AssignProductValues(newOrder);
            
            Console.WriteLine("Enter Order Area: ");
            newOrder.Area = decimal.Parse(Console.ReadLine());
            
            OrderCostCalculation.CalculateMaterialCost(newOrder);
            OrderCostCalculation.CalculateLaborCost(newOrder);
            OrderCostCalculation.CalculateTaxCost(newOrder);
            OrderCostCalculation.CalculateOrderTotal(newOrder);

            var displayOrdersWorkflow = new DisplayOrdersWorkflow();

            displayOrdersWorkflow.PrintOrder(newOrder);

            Console.WriteLine("Would you like to save this order (Y or N)?");
            var answer = Console.ReadLine();
            if (answer == "Y")
            {
                orderManager.AddOrder(newOrder);
            }


            

            Console.ReadLine();
        }
    }
}
