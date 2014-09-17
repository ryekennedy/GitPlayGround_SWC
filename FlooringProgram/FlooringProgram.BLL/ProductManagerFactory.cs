using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Data.TestMode;

namespace FlooringProgram.BLL
{
    public class ProductManagerFactory
    {
        public static ProductManager CreateInstance()
        {
            // test or production mode?  Check app.config

            // if test
            return new ProductManager(new MockProductRepository());
            // if production
            //return new ProductManager(new ProductRepository());  // Dependency Injection

        }
    }
}
