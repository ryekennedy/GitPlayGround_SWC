using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.StatusCodes;

namespace FlooringProgram.Models.Responses
{
    public class AddOrderResponse : Response
    {
        public Order Order { get; set; }
        public AddOrderStatus Status { get; set; }
    }
    
}
