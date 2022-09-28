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
        public async Task<ActionResult<IEnumerable<ProductViewDTO>>> GetAll()
        {
            return CustomResult(_mapper.Map<IEnumerable<ProductViewDTO>>(await _productRepository.GetProductsSuppliers()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewDTO>> GetById(Guid id)
        {
            var product = await GetProdutById(id);

            if(product == null) return NotFound();

            return CustomResult(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewDTO>> Add(ProductInputDTO productDTO)
        {
            if (!ModelState.IsValid) return CustomResult(ModelState);

            var imagemName = Guid.NewGuid() + "_" + productDTO.Image;

            if (!UploadFile(productDTO.ImageUpload, imagemName)) return CustomResult();

            productDTO.Image = imagemName;  
            await _productServices.Add(_mapper.Map<Product>(productDTO));

            return CustomResult(productDTO);  
        }

        [HttpPost("AddImageProduct")]
        public async Task<ActionResult> AddImageProduct(ImageProductDTO imageProductDTO)
        {
            if (ModelState.IsValid) return CustomResult(ModelState);

            var imageName = Guid.NewGuid() + "_" + imageProductDTO.Image.FileName;

            if (!await UploadFileIFormeFile(imageProductDTO.Image, imageName)) return CustomResult(ModelState);

            await _productServices.AddImageProduct(_mapper.Map<Product>(imageProductDTO));

            return CustomResult(imageProductDTO);
           
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductViewDTO>> Update(Guid id, ProductInputDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                Notify("Id do parametro não é igual ao id do bad request");
                return CustomResult();
            }

            var productModel = await GetProdutById(id);
            productDTO.Image = productDTO.Id.ToString() + "_" + productDTO.Image;

            if (!string.IsNullOrEmpty(productModel.Image))
                productDTO.Image = productModel.Image;
                

            if (!ModelState.IsValid) return CustomResult(ModelState);

            if (productDTO.ImageUpload != null)
            {              
                if (!await DeleteImage(productDTO.Image))
                {
                    Notify("Erro ao exluir image");
                    return CustomResult();
                }
                if (!UploadFile(productDTO.ImageUpload, productDTO.Image)) return CustomResult(ModelState);
            }

            productDTO.DateCreate = productModel.DateCreate;
            await _productServices.Update(_mapper.Map<Product>(productDTO));
            return CustomResult(productDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewDTO>> Delete(Guid id)
        {
            var product = GetProdutById(id);
            
            if (product == null) return NotFound();

            await _productServices.Delete(id);

            return CustomResult(product);
        }


        /* privates */
        private async Task<ProductViewDTO> GetProdutById(Guid id)
        {
            return _mapper.Map<ProductViewDTO>(await _productRepository.GetProductSupplierById(id));
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

        private async Task<bool> DeleteImage(string imageName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imageName);

            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

            return true;
        }

        private async Task<bool> UploadFileIFormeFile(IFormFile file, string imageName)
        {
           
            if (file == null || string.IsNullOrEmpty(imageName))
            {
                //ModelState.AddModelError(string.Empty, "Forneça uma imagem para este produto!");
                Notify("Forneça uma imagem para este produto!");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imageName+file.FileName); // monta o path 

            if (System.IO.File.Exists(filePath))
            {
                //ModelState.AddModelError(string.Empty, "Ja existe um arquivo com este nome");
                Notify("Ja existe um arquivo com este nome");
                return false;
            }

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream); 
            }

            return true;
        }
    }
}
