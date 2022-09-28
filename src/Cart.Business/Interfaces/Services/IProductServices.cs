using Cart.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Interfaces.Services
{
    public interface IProductServices
    {
        Task Add(Product product);
        Task Delete(Guid id);
        Task Update(Product product);

        Task AddImageProduct(Product product);  
    }
}
