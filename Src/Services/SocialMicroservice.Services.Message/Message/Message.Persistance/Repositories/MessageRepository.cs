
using Core.Persistance.Repositories;
using Message.Application.Services.Repositories;
using Message.Domain;
using Message.Persistance.Contexts;

namespace Message.Persistance.Repositories;

public class MessageRepository : EfRepositoryBase<Messagess, BaseDbContext>, IMessageRepository
{
    public MessageRepository(BaseDbContext context) : base(context)
    {
    }
}