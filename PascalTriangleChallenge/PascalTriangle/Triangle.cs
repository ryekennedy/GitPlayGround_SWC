using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Triangle
    {
        public List<Row> rows { get; set; }  //have to add get;set to make the instance of rows in constructor

        public Triangle()
        {
            rows = new List<Row>();
        }
    }
}
