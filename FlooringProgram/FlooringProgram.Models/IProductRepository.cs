﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public interface IProductRepository
    {
        List<Product> LoadAll();
        Product GetByProduct(string productType);
        bool IsAllowableProduct(string productType);
    }
}
