namespace SuperHeroAPI.Repositories;

public interface ISuperHeroesRepo
{
    Task<IEnumerable<SuperHero>> GetAllHeroes();
    Task<SuperHero> GetHero(int id);
    Task<int> AddHero(SuperHero hero);
    Task<int> UpdateHero(SuperHero hero);
    Task<int> DeleteHero(int id);
}
