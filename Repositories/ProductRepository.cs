using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        StoreDBContext _context;

        public ProductRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductsDb>> GetProducts(string? name, string? desc, int?[] categoriesId, int? minPrice, int? maxPrice, int position, int skip)
        {
            var query = _context.ProductsDbs.Where(product =>
            (name ==null || product.ProductName.Contains(name))
            && (desc == null || product.Description.Contains(desc))
            && (categoriesId.Length==0 ||  categoriesId.Contains(product.CategoryId))
            && (minPrice == null || product.Price>=minPrice)
            && (maxPrice == null || product.Price<=maxPrice))
            .OrderBy(product => product.Price);

            IEnumerable<ProductsDb> products = await query.ToListAsync();
            return products;
        }
        public async Task<ProductsDb> GetProduct(int id)
        {
            ProductsDb product = _context.ProductsDbs.Where(p => p.Id == id).FirstOrDefault();
            return product;
        }
    }
}
