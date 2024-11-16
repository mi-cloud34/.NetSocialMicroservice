

using Core.Persistance.Repositories;
using Post.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Services.Repositories
{
    public interface IPostRepository : IAsyncRepository<Postss>, IRepository<Postss>
    {
    }
}
