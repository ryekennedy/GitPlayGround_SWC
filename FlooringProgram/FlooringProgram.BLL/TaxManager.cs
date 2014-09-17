using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Responses;
using FlooringProgram.Models.StatusCodes;

namespace FlooringProgram.BLL
{
    public class TaxManager
    {
        private ITaxRepository _taxRepository;

        public TaxManager(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }


        public AddOrderResponse AddState(Order order)
        {
            var response = new AddOrderResponse();
            response.Order = order;

            if (!_taxRepository.IsAllowableState(order.StateTax.StateAbbreviation))
            {
                response.Success = false;
                response.Status = AddOrderStatus.InvalidTaxRate;

                return response;
            }

            response.Success = true;
            response.Status = AddOrderStatus.Ok;

            return response;
        }

        public void AssignStateValues(Order order)
        {
            var stateTax =_taxRepository.GetByState(order.StateTax.StateAbbreviation);

            order.StateTax.StateName = stateTax.StateName;
            order.StateTax.TaxRate = stateTax.TaxRate;

        }

    }
}
