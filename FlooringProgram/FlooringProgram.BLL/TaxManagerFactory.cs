using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;

namespace FlooringProgram.BLL
{
    public class TaxManagerFactory
    {
        public static TaxManager CreateInstance()
        {
            
            return new TaxManager(new StateTaxRepository());  // Dependency Injection
        }
    }
}
