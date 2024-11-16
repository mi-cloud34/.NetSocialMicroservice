using MediatR;
using Message.Application.Features.Messages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Features.Messages.Queries.GetListUserId
{
    public class GetListUserId:IRequest<MessageDto>
    {
    }
}
