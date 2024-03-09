using DevoraLime.Application.Services.Interfaces;
using DevoraLime.Domain.DomainObjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevoraLime.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        private readonly IArenaService _arenaService;

        public ArenaController(IArenaService arenaService) 
        {
            _arenaService = arenaService;
        }

        [HttpPost]
        public ActionResult<Guid> CreateArena(int numberOfHeroes)
        {
            Arena arena = _arenaService.GetNewArena(numberOfHeroes);
            Guid arenaId = _arenaService.Create(arena);
            return Ok(arenaId);
        }

    }
}
