using AutoMapper;
using Cart.App.DTO;
using Cart.Business.interfaces;
using Cart.Business.interfaces.Notifications;
using Cart.Business.interfaces.Services;
using Cart.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cart.App.Controllers
{
    [Route("api/Suppliers")]
    public class SupplierController : MainController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierServices _supplierServices;  
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository SupplierRepository,
            IMapper Mapper, 
            INotifier Notifier,
            ISupplierServices SupplierServices) : base(Notifier)
        {
            _supplierRepository = SupplierRepository;
            _supplierServices = SupplierServices;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetAll()
        {
            return CustomResult(_mapper.Map<IEnumerable<SupplierDTO>>(await _supplierRepository.GetAll()));
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierDTO>> GetById(Guid Id)
        {
            var supplier = await GetSupplierProductsAddressById(Id);

            if(supplier == null) return NotFound();

            return CustomResult(supplier);
        }


        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> Add(SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid) return CustomResult(ModelState);

            await _supplierServices.Add(_mapper.Map<Supplier>(supplierDTO)); 
            
            return CustomResult(supplierDTO);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierDTO>> Update(Guid id, SupplierDTO supplierDTO)
        {
            if (id != supplierDTO.id)
            {
                Notify("Id do fornecedor não é igual ao id do parametro");
                return CustomResult();
            }

            if (!ModelState.IsValid) return CustomResult(ModelState);

            await _supplierServices.update(_mapper.Map<Supplier>(supplierDTO));

            return CustomResult(supplierDTO);    
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var supplier = GetSupplierAddressByid(id);
            if (supplier == null) return NotFound();

            await _supplierServices.Delete(id);

            return CustomResult();
        }


        private async Task<SupplierDTO> GetSupplierProductsAddressById(Guid Id)
        {
            return _mapper.Map<SupplierDTO>(await _supplierRepository.GetSupplierProductsAddress(Id));
        }

        private async Task<SupplierDTO> GetSupplierAddressByid(Guid Id)
        {
            return _mapper.Map<SupplierDTO>(await _supplierRepository.GetSupplierAddress(Id));
        }


    }
}
