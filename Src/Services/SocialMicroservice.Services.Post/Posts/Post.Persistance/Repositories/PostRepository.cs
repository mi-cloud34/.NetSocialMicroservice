using Core.Persistance.Repositories;
using Post.Application.Services.Repositories;
using Post.Domain.Entities;
using Post.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Persistance.Repositories
{
    public class PostRepository : EfRepositoryBase<Postss, PostDbContext>, IPostRepository
    {
        public PostRepository(PostDbContext context) : base(context)
        {

        }
    }
}
