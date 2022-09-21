using Cart.Business.interfaces;
using Cart.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Interfaces
{
    public interface IProductRepository: IRepository<Product>   
    {
        public Task<Product> GetProductSupplierById(Guid id);

        public Task<IEnumerable<Product>> GetProductsSuppliers();

        public Task<IEnumerable<Product>> GetProductsBySuppliers(Guid supplierId);
    }
}
