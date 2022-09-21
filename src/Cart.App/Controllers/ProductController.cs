using AutoMapper;
using Cart.App.DTO;
using Cart.Business.interfaces.Notifications;
using Cart.Business.Interfaces;
using Cart.Business.Interfaces.Services;
using Cart.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cart.App.Controllers
{
    [Route("api/Produtcs")]
    public class ProductController : MainController
    {
        private readonly IProductServices _productServices;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;   
        public ProductController(IProductServices ProductServices, 
            IProductRepository ProductRepository, 
            IMapper Mapper, 
            INotifier notifier) : base(notifier)
        {
            _productServices = ProductServices;
            _productRepository = ProductRepository;
            _mapper = Mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            return CustomResult(_mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsSuppliers()));
        }

        [HttpGet("{id:guid}")]

        public async Task<ActionResult<ProductDTO>> GetById(Guid id)
        {
            var product = await GetProdutById(id);

            if(product == null) return NotFound();

            return CustomResult(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Add(ProductDTO productDTO)
        {
            if (!ModelState.IsValid) CustomResult(ModelState);

            var imagemName = Guid.NewGuid() + "_" + productDTO.Image;

            if (!UploadFile(productDTO.ImageUpload, imagemName)) return CustomResult();

            productDTO.Image = imagemName;  
            await _productServices.Add(_mapper.Map<Product>(productDTO));

            return CustomResult(productDTO);  
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductDTO>> Delete(Guid id)
        {
            var product = GetProdutById(id);
            
            if (product == null) return NotFound();

            await _productServices.Delete(id);

            return CustomResult(product);
        }


        private async Task<ProductDTO> GetProdutById(Guid id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductSupplierById(id));
        }

        private bool UploadFile(string file, string imageName)
        {
            var ImageDataByteArray = Convert.FromBase64String(file); //convert to bytes

            if(string.IsNullOrEmpty(file) || string.IsNullOrEmpty(imageName))
            {
                //ModelState.AddModelError(string.Empty, "Forneça uma imagem para este produto!");
                Notify("Forneça uma imagem para este produto!");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imageName); // monta o path 
            
            if(System.IO.File.Exists(filePath))
            {
                //ModelState.AddModelError(string.Empty, "Ja existe um arquivo com este nome");
                Notify("Ja existe um arquivo com este nome");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, ImageDataByteArray); //build o file
            return true;
        }
    }
}
