using Core.Persistance.Repositories;
using Message.Domain;


namespace Message.Application.Services.Repositories;

public interface IMessageRepository : IAsyncRepository<Messagess>, IRepository<Messagess>
{
}