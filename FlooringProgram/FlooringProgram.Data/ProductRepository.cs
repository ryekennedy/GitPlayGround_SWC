using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
   
       public class ProductRepository
    {
        private const string FileName = "ProductList.txt";
        private const string HeaderRow = "ProductType, CostPerSquareFoot, LaborCostPerSquareFoot";

        static public List<Product> LoadAll()
        {
            var ProductList = File.ReadAllLines(FileName);
            var productInfo = new List<Product>();

            // start at position 1, because we don't want the header row
            for (int i = 1; i < ProductList.Length; i++)
            {
                // split the csv, this returns a string array of each column value
                var columns = ProductList[i].Split(',');

                // need a contact object to put the data in
                var newProduct = new Product();

                // read the data into the objects one column at a time, enums are ints, but we need to cast (int)
                newProduct.ProductType = columns[(int) ProductColumns.ProductType];
                newProduct.CostPersquareFoot = decimal.Parse(columns[(int)ProductColumns.CostPerSquareFoot]);
                newProduct.LaborCostPerSquareFoot = decimal.Parse(columns[(int)ProductColumns.LaborCostPerSquareFoot]);

                productInfo.Add(newProduct);
            }

            return productInfo;
        }
    }
}
