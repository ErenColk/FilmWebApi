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
using System;
using System.Text;

namespace FilmWebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public ActorController(IActorService actorService, IMapper mapper, IFilmService filmService)
        {
            _actorService = actorService;
            _mapper = mapper;
            _filmService = filmService;
        }



        [HttpGet("GetListActor")]
        public IActionResult GetListActor()
        {
            var actor = _mapper.Map<List<ResultActorDTO>>(_actorService.TGetAll());

            if (actor.Count <= 0)
            {
                return NotFound("İstediğiniz Liste Bulunamadı...");
            }

            return Ok(actor);
        }


        [HttpGet("GetListActorWithFilms")]
        public IActionResult GetListActorWithFilms()
        {

            List<ResultActorWithFilmDTO> actor = _mapper.Map<List<ResultActorWithFilmDTO>>(_actorService.TGetActorInclude());

            if (actor.Count <= 0)
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


            if (valid.IsValid)
            {
                actor.Films.Add(_filmService.TGetById(createActorDTO.FilmId));
                _actorService.TAdd(actor);
                return Ok(actor);
            }
            else
            {
                return BadRequest(Message.ErrorMessages(valid));
            }


        }

        [HttpPut("UpdateActor")]
        public IActionResult UpdateActor(int id, UpdateActorDTO updateActorDTO)
        {
            Actor actor = _actorService.TGetByActor(id);

            if (actor != null)
            {
                if ( id != updateActorDTO.Id)
                    return BadRequest("Id Degerini Degiştiremezsiniz");

                if (actor.Films.FirstOrDefault(x => x.Id == updateActorDTO.FilmId) != null)
                    return BadRequest("Aktörün böyle bir filmi zaten mevcut!");


                UpdateActorValidation validationRules = new UpdateActorValidation();
                ValidationResult valid = validationRules.Validate(updateActorDTO);
                if (valid.IsValid)
                {
                    _mapper.Map(updateActorDTO, actor);
                    actor.Films.Add(_filmService.TGetById(updateActorDTO.FilmId));
                    if (_actorService.TUpdate(actor))
                        return Ok(actor);

                    return BadRequest(Message.ErrorMessages(valid));
                }
            }

            return NotFound("Güncellenecek Aktör bulunamadı!");
        }




        [HttpPut("MovieUpdateInActor")]
        public IActionResult Update(int id, UpdateMovieInActorDTO movieUpdateDto)
        {
            Actor actor = _actorService.TGetByActor(id);
            if (actor != null)
            {
                if (movieUpdateDto.NewFilmId > 0 && movieUpdateDto.OldFilmId > 0)
                {
                    actor.Films.Remove(_filmService.TGetById(movieUpdateDto.OldFilmId));
                    actor.Films.Add(_filmService.TGetById(movieUpdateDto.NewFilmId));
                    _actorService.TUpdate(actor);
                    return Ok(actor);
                }
                else
                    return BadRequest("Id ler 0'dan büyük olmalı...");

            }
            return NotFound("Id'ye ait aktör bulunamadı!");
        }


        [HttpDelete("DeleteActor")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id '0' dan küçük olamaz");
            else if (_actorService.TGetById(id) == null)
                return NotFound("Bu id'ye ait aktör bulunamadı!");
            else
                _actorService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpDelete("DeleteTheActorsMovie")]
        public IActionResult DeleteMovie(int id, DeleteActorMovieDTO deleteMovie)
        {

            if (id <= 0)
                return BadRequest("Id '0' dan küçük olamaz");
            else if (_actorService.TGetById(id) == null)
                return NotFound("Bu id'ye ait aktör bulunamadı!");
            else
            {
                Actor actor = _actorService.TGetByActor(id);
                actor.Films.Remove(_filmService.TGetById(deleteMovie.DeleteFilmId));
                _actorService.TUpdate(actor);
                return Ok("Silme işlemi başarılı");
            }

        }

    }
}
