﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleMaker triangle = new TriangleMaker();
            triangle.MakeTriangle();
            Console.ReadLine();
        }
        
    }
}
