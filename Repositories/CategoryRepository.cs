using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        StoreDBContext _context;
        public CategoryRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
