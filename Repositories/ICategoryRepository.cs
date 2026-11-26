using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
