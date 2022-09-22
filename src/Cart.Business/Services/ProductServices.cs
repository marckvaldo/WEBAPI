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

        public async Task Add(Product produtc)
        {

            if (_productRepository.Filter(p=>p.Name == produtc.Name).Result.Any())
            {
                Notify("Ja existe produto cadastrado com esse titulo");
                return;
            }

            await _productRepository.Add(produtc);
            return;
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
