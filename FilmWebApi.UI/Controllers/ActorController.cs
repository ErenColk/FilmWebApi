using AutoMapper;
using FilmWebApi.BLL.DTO.ActorDTO;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.Core.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorController(IActorService actorService,IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetListActor()
        {

            var value = _mapper.Map<List<ResultActorDTO>>(_actorService.TGetAll());
            return Ok(value);
        
           
        }



    }
}
