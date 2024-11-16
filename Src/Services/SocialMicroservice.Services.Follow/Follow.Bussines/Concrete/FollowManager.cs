using Follow.Core.Utilities.Results;
using Follow.Entities;
using Follow.Bussines.Abstract;
using Follow.DataAcess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Social.Shared.Messages;
using MassTransit.Transports;

namespace Follow.Bussines.Concrete
{
    public class FollowManager : IFollowService
    {
        IFollowDal _followDal;
         private readonly ISendEndpointProvider _sendEndpointProvider;
        
        public FollowManager(IFollowDal followDal,ISendEndpointProvider sendEndpointProvider)
        {
            _followDal = followDal;
           _sendEndpointProvider = sendEndpointProvider;
        }
        public async Task<IResult> Add(Follows follow)
        {
          
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:send-email-user-queu"));


            sendEndpoint.Send(new FollowRequestCommand
            {
                FollowerName = follow.UserName,
                FollowedLastName = follow.UserLastName,
                FollowedEmail = follow.UserMail
            });
            _followDal.Add(follow);
            return new SuccessResult("Takipçi eklendi");
        }

        public IResult Delete(int id)
        {
            _followDal.Delete(id);
            return new SuccessResult("Takipçi silindi");
        }

        public IDataResult<Follows> GetById(int id)
        {
            return new SuccessDataResult<Follows>(_followDal.Get(i => i.Id == id), "idye göre getirilme işlemi başarılı");
        }

        public IDataResult<List<Follows>> GetList()
        {
            return new SuccessDataResult<List<Follows>>(_followDal.GetList().ToList());
        }

        public IResult Update(Follows follow)
        {
            _followDal.Update(follow);
            return new SuccessResult("Takipçi güncellendi");
        }

       
    }
}
