using AutoMapper;
using FilmWebApi.BLL.DTO.CategoryDTO;
using FilmWebApi.BLL.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListCategory()
        {
          var categorys =  _mapper.Map<List<ResultCategoryDTO>>(_categoryService.TGetAll());

            if(categorys.Count <= 0) 
            {
                return NotFound("İstediğiniz Liste Bulunamadı...");
            
            }

            return Ok(categorys);
        
        }

        [HttpGet("CategoryWithMovieList")]
        public IActionResult GetCategoryWithMovie() 
        { 
            var categorys = _mapper.Map<List<ResultCategoryWithFilmsDTO>>(_categoryService.GetCategoriesInclude());

            if (categorys.Count <= 0)
            {
                return NotFound("İstediğiniz Liste Bulunamadı...");

            }
            return Ok(categorys);

        }


        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDTO createCategoryDTO) 
        {


            return Ok();
        }

    }
}
