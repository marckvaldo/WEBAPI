using Cart.Business.interfaces;
using Cart.Business.Models;
using Cart.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Data.Repository
{
    public class SupplierRepository: Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(CartDbContext context):base(context)
        {

        }

        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await _Db.Suppliers.AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> GetSupplierProductsAddress(Guid id)
        {
            return await _Db.Suppliers.AsNoTracking()
                .Include(p => p.Products)
                .Include(a => a.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
