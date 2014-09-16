using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public static class OrderCostCalculation
    {
        
        public static void CalculateMaterialCost(Order order)
        {
            order.OrderCost.MaterialCost = order.Area * order.Product.CostPersquareFoot;
            
        }

        public static void CalculateLaborCost(Order order)
        {
            order.OrderCost.LaborCost = order.Area * order.Product.LaborCostPerSquareFoot;
           
        }

        public static void CalculateTaxCost(Order order)
        {
            order.OrderCost.Tax = (order.OrderCost.MaterialCost + order.OrderCost.LaborCost)* (order.StateTax.TaxRate/100);

        }

        public static void CalculateOrderTotal(Order order)
        {
            order.OrderCost.Total = order.OrderCost.Tax +order.OrderCost.MaterialCost + order.OrderCost.LaborCost;

        }



    }
}
