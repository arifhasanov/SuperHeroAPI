using Npgsql;
namespace SuperHeroAPI.Repositories;

public class SuperHeroesRepoPSQL : ISuperHeroesRepo
{
    private IEnumerable<SuperHero> superHeroes = new List<SuperHero>();
    private string _connectionStringPSQL;

    public SuperHeroesRepoPSQL(string connectionStringPSQL)
    {
        _connectionStringPSQL = connectionStringPSQL;
    }

    public async Task<IEnumerable<SuperHero>> GetAllHeroes()
    {
        var sql = "select * from superheroes";
        using IDbConnection cn = new NpgsqlConnection(_connectionStringPSQL);
        return await cn.QueryAsync<SuperHero>(sql);
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var sql = "select * from superheroes where id = :id";
        var p = new { ID = id };
        using IDbConnection cn = new NpgsqlConnection(_connectionStringPSQL);
        return await cn.QueryFirstOrDefaultAsync<SuperHero>(sql, p);
    }

    public async Task<int> AddHero(SuperHero hero)
    {
        var sql = "insert into superheroes (name, firstname, lastname, place) values (:name, :firstname, :lastname, :place) returning id";
        using IDbConnection cn = new NpgsqlConnection(_connectionStringPSQL);
        return await cn.QueryFirstOrDefaultAsync<int>(sql, hero);
    }

    public async Task<int> UpdateHero(SuperHero request)
    {
        var sql = "update superheroes set name=:name, firstname=:firstname, lastname=:lastname, place=:place where id = :id returning id";
        using IDbConnection cn = new NpgsqlConnection(_connectionStringPSQL);
        return await cn.QueryFirstOrDefaultAsync<int>(sql, request);
    }

    public async Task<int> DeleteHero(int id)
    {
        var sql = "delete from superheroes where id = :id returning id";
        var p = new { Id = id };
        using IDbConnection cn = new NpgsqlConnection(_connectionStringPSQL);
        return await cn.QueryFirstOrDefaultAsync<int>(sql, p);
    }
}
