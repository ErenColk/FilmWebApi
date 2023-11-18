using AutoMapper;
using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.BLL.DTO.FilmDTO;
using FilmWebApi.BLL.Helper;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.BLL.Validations.ActorValidation;
using FilmWebApi.Core.Entities;
using FilmWebApi.Core.IRepositories;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FilmWebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetListActor()
        {
            var actor = _mapper.Map<List<ResultActorDTO>>(_actorService.TGetAll());

            if (actor == null)
            {
                return NotFound("İstediğiniz Liste Bulunamadı...");
            }

            return Ok(actor);
        }


        [HttpGet("GetListActorWithFilms")]
        public IActionResult GetListActorWithFilms()
        {

            List<ResultActorWithFilmDTO> actor = _mapper.Map<List<ResultActorWithFilmDTO>>(_actorService.TGetActorInclude());

            if(actor == null)
            {
                return NotFound("İstediğiniz Liste Bulunamadı...");
            }

            return Ok(_actorService.TGetActorFilmAndCategory(actor));
        }


        [HttpPost]
        public IActionResult AddActor(CreateActorDTO createActorDTO)
        {
            Actor actor = _mapper.Map<Actor>(createActorDTO);

            CreateActorValidation validationRules = new CreateActorValidation();

            ValidationResult valid = validationRules.Validate(createActorDTO);
            

            if(valid.IsValid)
            {
                return Ok(createActorDTO);
            }
            else
            {           
                return BadRequest(Message.ErrorMessages(valid));          
            }
        }
    }
}
