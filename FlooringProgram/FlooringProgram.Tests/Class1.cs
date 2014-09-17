using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data.TestMode;
using FlooringProgram.Models;
using FlooringProgram.Models.StatusCodes;
using NUnit.Framework;

namespace FlooringProgram.Tests
{
    [TestFixture]
    public class OrderBllTests
    {
        [Test]
        public void AddOrderWithInvalidState()
        {
            TaxManager om = new TaxManager(new MockStateTaxRepository());
            Order order = new Order();
            order.StateTax.StateAbbreviation = "NY";
            var response = om.AddState(order);

            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(AddOrderStatus.InvalidTaxRate, response.Status);
        }

        [Test]
        public void AddOrderWithValidState()
        {
            TaxManager om = new TaxManager(new MockStateTaxRepository());
            Order order = new Order();
            order.StateTax.StateAbbreviation = "OH";
            var response = om.AddState(order);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(AddOrderStatus.Ok, response.Status);
        }

        [Test]
        public void AddProductWithInvalidProductType()
        {
            ProductManager om = new ProductManager(new MockProductRepository());
            Order order = new Order();
            order.Product.ProductType = "Ivory";
            var response = om.AddProduct(order);

            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(AddOrderStatus.InvalidProductType, response.Status);
        }

        [Test]
        public void AddProductWithValidProductType()
        {
            ProductManager om = new ProductManager(new MockProductRepository());
            Order order = new Order();
            order.Product.ProductType = "Wood";
            var response = om.AddProduct(order);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(AddOrderStatus.Ok, response.Status);
        }

        [Test]
        public void CheckCalculation()
        {
            TaxManager tm = new TaxManager(new MockStateTaxRepository());
            ProductManager om = new ProductManager(new MockProductRepository());
            Order order = new Order();
            order.Product.ProductType = "Wood";
            order.StateTax.StateAbbreviation = "OH";
            order.Area = 100;
            om.AssignProductValues(order);
            tm.AssignStateValues(order);
            OrderCostCalculation.Execute(order);

            Assert.AreEqual(1000.00M, order.OrderCost.MaterialCost);
            Assert.AreEqual(1400.00M, order.OrderCost.LaborCost);
            Assert.AreEqual(180.00M, order.OrderCost.Tax);
            Assert.AreEqual(2580.00M, order.OrderCost.Total);
            
        }

    }
}
