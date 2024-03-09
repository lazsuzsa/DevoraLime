using DevoraLime.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevoraLime.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IBattleService _battleService;
        private readonly IArenaService _arenaService;

        public BattleController(IBattleService battleService, IArenaService arenaService)
        {
            _battleService = battleService;
            _arenaService = arenaService;
        }

        [HttpPost("performBattle")]
        public ActionResult<string> PerformBattle(Guid arenaId)
        {
            var arena = _arenaService.Get(arenaId);
            if(arena == null)
            {
                return BadRequest($"Arena doesn't exist: {arenaId}");
            }
            string history = _battleService.PerformBattle(arena);
            return Ok(history);
        }
    }
}

