using Cart.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.interfaces.Services
{
    public interface ISupplierServices: IDisposable
    {
        Task Add(Supplier supplier);
        Task Delete(Guid id);
        Task update(Supplier supplier);
        Task updateAddress(Address address);    
    }
}
