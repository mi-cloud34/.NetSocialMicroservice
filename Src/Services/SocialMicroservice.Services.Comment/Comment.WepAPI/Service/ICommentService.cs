
using Comment.WepAPI.Model;
using Comment.WepAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comment.WepAPI.Service
{
    public interface ICommentService
    {
        Task<Response<List<Comments>>> GetAll();

        Task<Response<Comments>> GetById(int id);

        Task<Response<NoContent>> Save(Comments comment);

        Task<Response<NoContent>> Update(Comments comment);

        Task<Response<NoContent>> Delete(int id);

        Task<Response<Comments>> GetByCommentUserId(int userId);
    }
}