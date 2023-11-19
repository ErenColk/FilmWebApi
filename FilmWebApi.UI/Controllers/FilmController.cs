using AutoMapper;
using FilmWebApi.BLL.DTO.FilmDTO;
using FilmWebApi.BLL.Helper;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.BLL.Validations.ActorValidation;
using FilmWebApi.BLL.Validations.FilmValidation;
using FilmWebApi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IActorService _actorService;

        public FilmController(IFilmService filmService, IMapper mapper, ICategoryService categoryService, IActorService actorService)
        {
            _filmService = filmService;
            _mapper = mapper;
            _categoryService = categoryService;
            _actorService = actorService;
        }

        [HttpGet("GetListFilm")]
        public IActionResult GetListFilm()
        {

            if (_filmService.TGetAll().Count > 0)
            {
                var films = _mapper.Map<List<ResultFilmDTO>>(_filmService.TGetAll());
                return Ok(films);
            }
            else
            {
                return NotFound("Film listesi bulunamadı!");
            }

        }

        [HttpGet("GetListInclude")]
        public IActionResult GetListFilmInclude()
        {
            var films = _mapper.Map<List<ResultFilmWithCategoryActorDTO>>(_filmService.TGetFilmInclude());

            if (films.Count > 0)
            {

                return Ok(films);

            }
            else
            { return NotFound("Film listesi bulunamadı"); }

        }

        [HttpPost("AddFilm")]
        public IActionResult AddFilm(CreateFilmDTO createFilmDTO)
        {
            CreateFilmValidation validationRules = new CreateFilmValidation();

            var valid = validationRules.Validate(createFilmDTO);

            if (valid.IsValid)
            {
                Film film = _mapper.Map<Film>(createFilmDTO);
                _filmService.TAdd(film);

                return Ok(film);
            }
            else
            {
                return BadRequest(Message.ErrorMessages(valid));
            }

        }

        [HttpPost("AddFilmWithActorCategory")]
        public IActionResult AddFilmWithActorCategory(CreateFilmActorCategoryDTO filmWithCategoryActor)
        {
            CreateFilmWithActorCategoryValid validationRules = new CreateFilmWithActorCategoryValid();
            var valid = validationRules.Validate(filmWithCategoryActor);

            if (valid.IsValid)
            {
                Film film = _mapper.Map<Film>(filmWithCategoryActor);

                if (_categoryService.TGetById(filmWithCategoryActor.CategoryId) != null)
                    film.Categorys.Add(_categoryService.TGetById(filmWithCategoryActor.CategoryId));
                else
                    return NotFound("Verdiğiniz Id'e ait kategori bulunamadı!");

                if (_actorService.TGetById(filmWithCategoryActor.ActorId) != null)
                    film.Actors.Add(_actorService.TGetById(filmWithCategoryActor.ActorId));
                else
                    return NotFound("Verdiğiniz Id'e ait actor bulunamadı!");

                _filmService.TAdd(film);
                return Ok(film);
            }
            else
            {
                return BadRequest(Message.ErrorMessages(valid));
            }
        }


        [HttpPut("UpdateFilm")]
        public IActionResult UpdateFilm(int id, UpdateFilmDTO updateFilm)
        {
            UpdateFilmValidation validationRules = new UpdateFilmValidation();
            var valid = validationRules.Validate(updateFilm);
            Film film = _filmService.TGetById(id);

            if (film != null)
            {
                if (valid.IsValid)
                {
                    _mapper.Map(updateFilm,film);
                    _filmService.TUpdate(film);
                    return Ok(film);
                }
                else
                    return BadRequest(Message.ErrorMessages(valid));

            }
            else
            {
                return NotFound("Idye ait film bulunamadı");

            }
        }

        [HttpDelete("FilmDelete")]

        public IActionResult DeleteFilm(int id)
        {
      
            if (id <= 0)
                return BadRequest("Id '0' dan küçük olamaz");
            else if (_filmService.TGetById(id) == null)
                return NotFound("Bu id'ye ait film bulunamadı!");
            else
                _filmService.TDelete(id);
            return Ok("Silme işlemi başarılı");

        }
    }
}
