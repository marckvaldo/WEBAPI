using Cart.Business.interfaces.Notifications;
using Cart.Business.Interfaces;
using Cart.Business.Interfaces.Services;
using Cart.Business.Models;
using Cart.Business.Validations;
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

        public async Task Add(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;    

            if (_productRepository.Filter(p=>p.Name == product.Name).Result.Any())
            {
                Notify("Ja existe produto cadastrado com esse titulo");
                return;
            }

            product.DateCreate = DateTime.Now.Date;
            await _productRepository.Add(product);
            return;
        }

        public async Task Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                Notify("Id não pode ser vazio!");
                return;
            }

            await _productRepository.DeleteById(id);
            return;
        }

        public async Task Update(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;

            if(_productRepository.Filter(p=>p.Name == product.Name && p.Id != product.Id).Result.Any())
            {
                Notify("Ja existe outro produto com essa descrição");
                return;
            }

            await _productRepository.Update(product);
            return;
        }

        public async Task AddImageProduct(Product productImage)
        {
            var produto = await _productRepository.GetById(productImage.Id);
            produto.Image = productImage.Image;
            await _productRepository.Update(produto);
            return;
        }
    }
}
