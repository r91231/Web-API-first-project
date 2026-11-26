using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Repositories;

namespace Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductsDb>> GetProducts(string? name,string? desc, int?[] categoriesId, int? minPrice, int? maxPrice, int position, int skip)
        {
            return await _productRepository.GetProducts(name, desc,categoriesId, minPrice, maxPrice, position, skip);
        }
        public async Task<ProductsDb> GetProduct(int id)
        {
            return await _productRepository.GetProduct(id);
        }
    }
}
