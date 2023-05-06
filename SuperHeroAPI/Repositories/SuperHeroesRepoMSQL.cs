using Azure.Core;

namespace SuperHeroAPI.Repositories;

public class SuperHeroesRepoMSQL : ISuperHeroesRepo
{
    private IEnumerable<SuperHero> superHeroes = new List<SuperHero>();
    private string _connectionStringMSQL;

    public SuperHeroesRepoMSQL(string connectionStringMSQL)
    {
        _connectionStringMSQL = connectionStringMSQL;
    }

    public async Task<IEnumerable<SuperHero>> GetAllHeroes()
    {
        var sql = "SELECT * FROM SUPERHEROES";
        using IDbConnection cn = new SqlConnection(_connectionStringMSQL);
        return await cn.QueryAsync<SuperHero>(sql);
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var sql = "SELECT * FROM SUPERHEROES WHERE ID = @ID";
        var p = new { ID = id };
        using IDbConnection cn = new SqlConnection(_connectionStringMSQL);
        return await cn.QueryFirstOrDefaultAsync<SuperHero>(sql, p);
    }

    public async Task<int> AddHero(SuperHero hero)
    {
        var sql = "INSERT INTO SUPERHEROES (NAME, FIRSTNAME, LASTNAME, PLACE) VALUES (@Name, @FirstName, @LastName, @Place) SELECT @@Identity";
        using IDbConnection cn = new SqlConnection(_connectionStringMSQL);
        return await cn.QueryFirstOrDefaultAsync<int>(sql, hero);
    }

    public async Task<int> UpdateHero(SuperHero request)
    {
        var sql = "UPDATE SUPERHEROES SET NAME=@Name, FIRSTNAME=@FirstName, LASTNAME=@LastName, PLACE=@Place WHERE ID = @Id SELECT @@RowCount";
        using IDbConnection cn = new SqlConnection(_connectionStringMSQL);
        return await cn.QueryFirstOrDefaultAsync<int>(sql, request);
    }

    public async Task<int> DeleteHero(int id)
    {
        var sql = "DELETE FROM SUPERHEROES WHERE ID = @Id SELECT @@RowCount";
        var p = new { Id = id };
        using IDbConnection cn = new SqlConnection(_connectionStringMSQL);
        return await cn.QueryFirstOrDefaultAsync<int>(sql, p);
    }
}
