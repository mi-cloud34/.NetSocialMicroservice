using Comment.WepAPI.Model;
using Comment.WepAPI.Response;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.WepAPI.Service
{
    public class CommentService : ICommentService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public CommentService(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from comment where id=@Id", new { Id = id });

            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Comment not found", 404);
        }

        public async Task<Response<List<Comments>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Comments>("Select * from Comments");

            return Response<List<Comments>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Comments>> GetByCommentUserId(int userId)
        {
            var discounts = await _dbConnection.QueryAsync<Comments>("select * from comment where userid=@UserId and code=@Code", new { UserId = userId });

            var hasDiscount = discounts.FirstOrDefault();

            if (hasDiscount == null)
            {
                return Response<Comments>.Fail("Comment not found", 404);
            }

            return Response<Comments>.Success(hasDiscount, 200);
        }

        public async Task<Response<Comments>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Comments>("select * from comment where id=@Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
            {
                return Response<Comments>.Fail("Comment not found", 404);
            }

            return Response<Comments>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Comments comment)
        {
            var saveStatus = await _dbConnection.ExecuteAsync("INSERT INTO comment (userid,rate,code) VALUES(@UserId,@Rate,@Code)", comment);

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("an error occurred while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Comments comment)
        {
            var status = await _dbConnection.ExecuteAsync("update comment set userid=@UserId, comment=@Comment, where id=@Id", new { comment.Id, comment.UserUd, comment.Comment });

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Commnet not found", 404);
        }
    }
}