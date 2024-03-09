using DevoraLime.Application.Services.Interfaces;
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
            Guid arenaId = _arenaService.Create(numberOfHeroes);
            return Ok(arenaId);
        }

    }
}
