using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Data;
using FlooringProgram.Models.Responses;
using FlooringProgram.Models.StatusCodes;

namespace FlooringProgram.BLL
{
    public class ProductManager
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> LoadProductList()
        {
            return _productRepository.LoadAll();
        }

        public AddOrderResponse AddProduct(Order order)
        {
            var response = new AddOrderResponse();
            response.Order = order;

            if (!_productRepository.IsAllowableProduct(order.Product.ProductType))
            {
                response.Success = false;
                response.Status = AddOrderStatus.InvalidProductType;

                return response;
            }

            response.Success = true;
            response.Status = AddOrderStatus.Ok;

            return response;
        }

        public void AssignProductValues(Order order)
        {
            var product = _productRepository.GetByProduct(order.Product.ProductType);

            order.Product.CostPersquareFoot = product.CostPersquareFoot;
            order.Product.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

        }
    }
}
