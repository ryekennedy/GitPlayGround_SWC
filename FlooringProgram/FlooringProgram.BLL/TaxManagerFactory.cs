using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Data.TestMode;

namespace FlooringProgram.BLL
{
    public class TaxManagerFactory
    {
        public static TaxManager CreateInstance()
        {
            
            return new TaxManager(new MockStateTaxRepository());  // Dependency Injection
        }
    }
}
