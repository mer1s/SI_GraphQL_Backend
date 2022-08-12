using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.GQLTypes
{
    public class QueryType
    {
        public async Task<List<Product>> GetProductsAsync([Service] AppDbContext context)
        {
            return await context.Products.ToListAsync();
        }
    }
}
