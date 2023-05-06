using System.Net.WebSockets;

namespace SuperHeroAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;

    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    [HttpGet("{database}")]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes(string database)
    {
        var result = await _superHeroService.GetAllHeroes(database);
        if (result == null)
        {
            return NotFound("Sorry this hero does not exist");
        }
        return Ok(result);
    }

    [HttpGet("{database}/{id}")]
    public async Task<ActionResult<SuperHero>> GetSingleHero(string database, int id)
    {
        var result = await _superHeroService.GetHero(database, id);
        if (result == null)
        {
            return NotFound("Sorry this hero does not exist");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddHero(string database, SuperHero hero)
    {
        var result = await _superHeroService.AddHero(database, hero);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<int>> UpdateHero(string database, SuperHero request)
    {
        var result = await _superHeroService.UpdateHero(database, request);
        if (result == 0)
        {
            return NotFound("Sorry this hero does not exist");
        }
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<int>> DeleteHero(string database, int id)
    {
        var result = await _superHeroService.DeleteHero(database, id);
        if (result == 0)
        {
            return NotFound("Sorry this hero does not exist");
        }
        return Ok(result);
    }
}