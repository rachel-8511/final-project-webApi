using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
           
                List<Category> categories = await _categoryService.getCategories();
                List<CategoryDTO> categoryDto = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);

                if (categoryDto != null)
                  return Ok(categoryDto);
                    
               return NoContent();
                

        }



    }
}
