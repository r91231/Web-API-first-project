using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;
namespace Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
