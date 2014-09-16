using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class TaxManager
    {
        private ITaxRepository _taxRepository;

        public TaxManager(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }


        public object ValidateState(Order newOrder)
        {


            foreach (var state in _taxRepository.LoadAll().Where(s => s.StateAbbreviation == newOrder.StateTax.StateAbbreviation))
            {
                newOrder.StateTax.StateName = state.StateName;
                newOrder.StateTax.TaxRate = state.TaxRate;
            }

        }

    }
}
