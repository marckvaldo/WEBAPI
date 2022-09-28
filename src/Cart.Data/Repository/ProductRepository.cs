using Cart.Business.Interfaces;
using Cart.Business.Models;
using Cart.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Cart.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CartDbContext context) : base(context)
        {

        }

        public async Task<Product> GetProductSupplierById(Guid id)
        {
            return await _Db.Products.AsNoTracking()
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsSuppliers()
        {
            return await _Db.Products.AsNoTracking()
                .Include(s => s.Supplier)
                .OrderBy(p=>p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySuppliers(Guid supplierId)
        {
            return await Filter(p => p.SupplierId == supplierId);
        }

    }
}
