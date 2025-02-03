using PetStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorHybridApp.Services
{
    public class ProductService
    {
        private readonly ProductContext _context;
        public ProductService(ProductContext context)
        {
            _context = context;
        }
        public async Task<List<ProductEntity>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task AddProductAsync(ProductEntity product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            //look into soft delete so you can ask them if the are sure about removing the item 
        }
    }
}
