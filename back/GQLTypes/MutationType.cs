using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.GQLTypes
{
    public class MutationType
    {
        public async Task<Product> SaveProductAsync([Service] AppDbContext context, Product newProduct)
        {
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();
            return newProduct;
        }
        public async Task<Product> UpdateProductAsync([Service] AppDbContext context, Product updateProduct)
        {
            context.Products.Update(updateProduct);
            await context.SaveChangesAsync();
            return updateProduct;
        }
        public async Task<string> DeleteProductAsync([Service] AppDbContext context, int id)
        {
            var toDelete = await context.Products.FindAsync(id);
            
            if(toDelete == null)
                return "Invalid operation.";

            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
            return "Successfuly deleted product.";
        }
    }
}
