
using Follow.DataAcess.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Follow.Core.DataAccess;
using Follow.Entities;
namespace Follow.DataAcess.Concrete
{
    public class DpFollowDal : RepositoryBase<Follows>, IFollowDal
    {

        public DpFollowDal(IConfiguration configuration) : base(configuration) { }

    }
}
