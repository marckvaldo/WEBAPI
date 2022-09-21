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
    public class AddresRepository : Repository<Address>
    {
        public AddresRepository(CartDbContext context):base(context)
        {

        }

        public async Task<Address> GetAddressBySupplier(Guid SupplierID)
        {
            return await _Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.SupplierId == SupplierID);
        }
    }
}
