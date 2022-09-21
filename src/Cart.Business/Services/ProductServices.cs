using Cart.Business.interfaces.Notifications;
using Cart.Business.Interfaces;
using Cart.Business.Interfaces.Services;
using Cart.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Services
{
    public class ProductServices : BaseService, IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository ProductRepository, INotifier Notifier) : base(Notifier)
        {
            _productRepository = ProductRepository;
        }

        public Task Add(Product produtc)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task update(Product produtc)
        {
            throw new NotImplementedException();
        }

        public Task updateAddress(Product produtc)
        {
            throw new NotImplementedException();
        }
    }
}
