using Follow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Follow.Core.Utilities.Results;
using System.Text;
using System.Threading.Tasks;
namespace Follow.Bussines.Abstract
{
    public interface IFollowService
    {
        IDataResult<List<Follows>> GetList();
        IDataResult<Follows> GetById(int id);
        Task<IResult>  Add(Follows follow);
        IResult Update(Follows follow);
        IResult Delete(int id);

    }
}
