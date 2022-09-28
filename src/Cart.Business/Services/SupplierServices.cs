using Cart.Business.interfaces;
using Cart.Business.interfaces.Notifications;
using Cart.Business.interfaces.Services;
using Cart.Business.Models;
using Cart.Business.Services;
using Cart.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Data.Services
{
    public class SupplierServices : BaseService, ISupplierServices
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierServices(ISupplierRepository SupplierRepository, INotifier Notifier) : base(Notifier)
        {
            _supplierRepository = SupplierRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!RunValidation(new SupplierValidation(), supplier)) return;

            if (!RunValidation(new AddressValidation(), supplier.Address)) return;

            if (_supplierRepository.Filter(f => f.Document == supplier.Document).Result.Any())
            {
                Notify("ja existe um fornecedor com esse documento");
                return;
            }

            await _supplierRepository.Add(supplier);    

            return;
        }

        public async Task Delete(Guid id)
        {
            if(_supplierRepository.GetSupplierProductsAddress(id).Result.Products.Any())
            {
                Notify("Fornecedor possui produtos cadastrados");
                return;
            }

            await _supplierRepository.DeleteById(id);
        }

        public async Task Update(Supplier supplier)
        {
            if (!RunValidation(new SupplierValidation(), supplier)) return;

            if(_supplierRepository.Filter(f=>f.Document == supplier.Document && f.Id != supplier.Id).Result.Any())
            {
                Notify("ja existe um fornecedor com esse documento");
                return;
            }

            await _supplierRepository.Update(supplier);
        }

        public Task UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}
