using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.TestMode
{
    public class MockStateTaxRepository : ITaxRepository
    {

        public List<StateTax> LoadAll()
        {
            return new List<StateTax>()
            {
                new StateTax() {StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 7.50M},
                new StateTax() {StateAbbreviation = "PA", StateName = "Pennsylvania", TaxRate = 8.00M},
                new StateTax() {StateAbbreviation = "MI", StateName = "Michigan", TaxRate = 6.00M},
            };
        }

        public StateTax GetByState(string abbreviation)
        {
            if(abbreviation == "OH")
                return new StateTax() { StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 7.50M };
            if (abbreviation == "PA")
                return new StateTax() {StateAbbreviation = "PA", StateName = "Pennsylvania", TaxRate = 8.00M};
            if (abbreviation == "MI")
                return new StateTax() {StateAbbreviation = "MI", StateName = "Michigan", TaxRate = 6.00M};
            return null;

        }

        public bool IsAllowableState(string abbreviation)
        {
            if (abbreviation == "OH" || abbreviation == "PA" || abbreviation == "MI")
                return true;

            return false;
        }
    }
}
