using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Data.TestMode;

namespace FlooringProgram.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager CreateInstance()
        {
            // test or production mode?  Check app.config

            // if test
            //return new OrderManager(new MockOrderRepository());
            // if production
            return new OrderManager(new OrderRepository());  // Dependency Injection
        }
    }
}
