using AutoMapper;
using FilmWebApi.BLL.DTO.CategoryDTO;
using FilmWebApi.BLL.Helper;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.BLL.Validations.CategoryValidation;
using FilmWebApi.Core.Entities;
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
        private readonly IFilmService _filmService;

        public CategoryController(ICategoryService categoryService, IMapper mapper,IFilmService filmService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _filmService = filmService;
        }

        [HttpGet]
        public IActionResult GetListCategory()
        {
            var categorys = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.TGetAll());

            if (categorys.Count <= 0)
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


        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CreateCategoryDTO createCategoryDTO)
        {
            CreateCategoryValidation validationRules = new CreateCategoryValidation();

            var valid = validationRules.Validate(createCategoryDTO);

            if (valid.IsValid)
            {
                Category category = _mapper.Map<Category>(createCategoryDTO);
                _categoryService.TAdd(category);
                return Ok(category);

            }
            else
            {
                return BadRequest(Message.ErrorMessages(valid));
            }
        }


        [HttpPut]
        public IActionResult UpdateCategory(int id ,UpdateCategoryDTO updateCategoryDTO) 
        {
            UpdateCategoryValidation validationRules = new UpdateCategoryValidation();

            var valid = validationRules.Validate(updateCategoryDTO);

            Category category = _categoryService.TGetById(id);

            if (category != null)
            {
                if ( id == updateCategoryDTO.Id)
                {
                    if (valid.IsValid)
                    {
                        _mapper.Map(updateCategoryDTO,category);
                        if(category.Films.FirstOrDefault(x=> x.Id == updateCategoryDTO.Id) != null)
                        category.Films.Add(_filmService.TGetById(updateCategoryDTO.FilmId));
                        else
                            return BadRequest("Verdiğiniz filme kategori zaten eklenmiş");
                        _categoryService.TUpdate(category);
                        return Ok(category);
                    }
                    else
                        return BadRequest(Message.ErrorMessages(valid));

                }
                else
                    return BadRequest("Id degerini aynı giriniz!");

            }
            else
                return NotFound("Bu ıdye ait category bulunmamakta");
            
        }


        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {
            if (id <= 0)
                return BadRequest("Id '0' dan küçük olamaz");
            else if (_categoryService.TGetById(id) == null)
                return NotFound("Bu id'ye ait aktör bulunamadı!");
            else
                _categoryService.TDelete(id);
            return Ok("Silme işlemi başarılı");



        }

    }
}
