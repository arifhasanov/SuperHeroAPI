namespace SuperHeroAPI.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<IEnumerable<SuperHero>> GetAllHeroes(string database);
    Task<SuperHero> GetHero(string database, int id);
    Task<int> AddHero (string database, SuperHero hero);
    Task<int> UpdateHero (string database, SuperHero hero);
    Task<int> DeleteHero (string database, int id);
}
