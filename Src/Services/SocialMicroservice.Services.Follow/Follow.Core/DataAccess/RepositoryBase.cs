using Follow.Core.Extension;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Linq.Expressions;

namespace Follow.Core.DataAccess
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
        // where TContext : IDbConnection, new()
    {


        // protected IEntity Entity => (typeof(TEntity) as IEntity)!;

        private readonly IConfiguration _configuration;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected IDbConnection connection => new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        protected IEntity Entity => new TEntity();


        public async void Add(TEntity entity)
        {

            connection.Execute($"INSERT INTO {Entity.GetDatabaseTableName()} ({Entity.GetInsertColumns()}) VALUES ({Entity.GetInsertValues()})", entity);

        }

        public void Delete(int id)
        {
            connection.Execute($"delete from {nameof(TEntity)} where id=@Id", new { Id = id });


        }

        public TEntity Get(int id)
        {
            var result = connection.Query($"select*from {nameof(TEntity)} where id=@Id", new { Id = id });
            return result.SingleOrDefault();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            var result = connection.Query($"select*from {nameof(TEntity)} where {filter}=@{filter}",filter);
            return result.SingleOrDefault();
        }

        public IList<TEntity> GetList()
        {
            var result = connection.Query<TEntity>($"select * from {nameof(TEntity)}");
            return result.ToList();


        }

        public void Update(TEntity entity)
        {
            connection.Execute($@"
            UPDATE FROM {Entity.GetDatabaseTableName()} 
            SET
            {Entity.GetUpdateColumnsValues()}
            WHERE Id = @Id", entity);
        }
    }

}
