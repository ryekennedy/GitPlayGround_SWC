using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    public class Row
    {
        public int[] RowArray;


        public void CreateRowArray(int lengthOfArray)
        {
           int[] _rowArray = new int[lengthOfArray];
            RowArray = _rowArray;
        }
    }
}
