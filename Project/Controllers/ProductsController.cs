
using AutoMapper;
using DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        IProductService _productService;
        IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<ActionResult<ProductDTO>> get([FromQuery]float? minPrice,[FromQuery]float? maxPrice, [FromQuery] int[]? CategoriesId, [FromQuery]string? search)
        {
           
                
                List<Product> products = await _productService.getProducts(minPrice, maxPrice, CategoriesId, search);
                List<ProductDTO> productsDTO = _mapper.Map<List<Product>, List<ProductDTO>>(products);
                if (productsDTO != null)
                    return Ok(productsDTO);

                return NoContent();

           

        }




    }
}
