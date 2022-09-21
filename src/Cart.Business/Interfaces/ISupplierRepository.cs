using Cart.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        public Task<Supplier> GetSupplierAddress(Guid id);

        public Task<Supplier> GetSupplierProductsAddress(Guid id);
    }
}
