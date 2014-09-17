using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.TestMode
{
    public class MockProductRepository : IProductRepository
    {
        public List<Product> LoadAll()
        {
            return new List<Product>()
            {
                new Product() {ProductType = "Wood", CostPersquareFoot = 10.00M, LaborCostPerSquareFoot = 14.00M},
                new Product() {ProductType = "Tile", CostPersquareFoot = 8.00M, LaborCostPerSquareFoot = 10.00M},
                new Product() {ProductType = "Marble", CostPersquareFoot = 22.50M, LaborCostPerSquareFoot = 30.25M}
            };
        }

        public Product GetByProduct(string productType)
        {
            if(productType == "Wood")
                return new Product() {ProductType = "Wood", CostPersquareFoot = 10.00M, LaborCostPerSquareFoot = 14.00M};
            if (productType == "Tile")
            {
                return new Product() {ProductType = "Tile", CostPersquareFoot = 8.00M, LaborCostPerSquareFoot = 10.00M};
            }
            if (productType == "Marble")
                return new Product()
                {
                    ProductType = "Marble",
                    CostPersquareFoot = 22.50M,
                    LaborCostPerSquareFoot = 30.25M
                };

            return null;
        }

        public bool IsAllowableProduct(string productType)
        {
            if (productType == "Wood" || productType == "Tile" || productType == "Marble")
                return true;

             return false;
        }
    }
}
