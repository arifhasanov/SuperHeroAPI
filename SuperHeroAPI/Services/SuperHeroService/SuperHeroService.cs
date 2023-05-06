using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private List<SuperHero> superHeroes = new List<SuperHero>();
    private ISuperHeroesRepo? _superHeroesRepoMSQL;
    private ISuperHeroesRepo? _superHeroesRepoPSQL;

    public SuperHeroService(IServiceProvider serviceProvider)
    {
        _superHeroesRepoMSQL = serviceProvider.GetNamed<ISuperHeroesRepo>("RepoMSQL");
        _superHeroesRepoPSQL = serviceProvider.GetNamed<ISuperHeroesRepo>("RepoPSQL");
    }
    public async Task<IEnumerable<SuperHero>> GetAllHeroes(string database)
    {
        if (database == "MSQL")
        {
            return await _superHeroesRepoMSQL!.GetAllHeroes();
        }
        else
        {
            return await _superHeroesRepoPSQL!.GetAllHeroes();
        }
    }

    public async Task<SuperHero> GetHero(string database, int id)
    {
        if (database == "MSQL")
        {
            return await _superHeroesRepoMSQL!.GetHero(id);
        }
        else
        {
            return await _superHeroesRepoPSQL!.GetHero(id);
        }
    }

    public async Task<int> AddHero(string database, SuperHero hero)
    {
        if (database == "MSQL")
        {
            return await _superHeroesRepoMSQL!.AddHero(hero);
        }
        else
        {
            return await _superHeroesRepoPSQL!.AddHero(hero);
        }
    }

    public async Task<int> UpdateHero(string database, SuperHero request)
    {
        if (database == "MSQL")
        {
            return await _superHeroesRepoMSQL!.UpdateHero(request);
        }
        else
        {
            return await _superHeroesRepoPSQL!.UpdateHero(request);
        }
    }

    public async Task<int> DeleteHero(string database, int id)
    {
        if (database == "MSQL")
        {
            return await _superHeroesRepoMSQL!.DeleteHero(id);
        }
        else
        {
            return await _superHeroesRepoPSQL!.DeleteHero(id);
        }
    }
}
