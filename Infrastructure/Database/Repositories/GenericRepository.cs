using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Infrastructure.Database.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IConfiguration _config;
    private readonly ApplicationContext _context;

    public GenericRepository(IConfiguration config, ApplicationContext context)
    {
        _config = config;
         _context = context;
    }
    public async Task<T> Create(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
       return entity;
    }

    public async Task<T> Get(string query)
    {
        using (var db = new MySqlConnection(_config.GetConnectionString("ICOConnection")))
        {
            var g = await db.QueryFirstOrDefaultAsync<T>(query);
            return g;
        }
        
    }

    public async Task<IEnumerable<T>> GetAll(string query)
    {
        using (var db = new MySqlConnection(_config.GetConnectionString("ICOConnection")))
        {
            var g = await db.QueryAsync<T>(query);
            return g;
        }
    }

    public async Task<IEnumerable<T>> GetAllByExpression(string query)
    {
        using (var db = new MySqlConnection(_config.GetConnectionString("ICOConnection")))
        {
            var g = await db.QueryAsync<T>(query);
            return g;
        }
    }

    public async Task<T> Update(T entity)
    {
         _context.Set<T>().Update(entity);
         return entity;
    }
    public async void SaveDbChanges()
    {
        await _context.SaveChangesAsync();
    }
}
