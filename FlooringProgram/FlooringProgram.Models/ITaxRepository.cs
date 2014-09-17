using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public interface ITaxRepository
    {
        List<StateTax> LoadAll();
        StateTax GetByState(string abbreviation);
        bool IsAllowableState(string abbreviation);
        
    }
}
