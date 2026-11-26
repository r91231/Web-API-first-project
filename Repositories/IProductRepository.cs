using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductsDb>> GetProducts(string? name, string? desc, int?[] categoriesId, int? minPrice, int? maxPrice, int position, int skip);
        Task<ProductsDb> GetProduct(int id);
    }
}
