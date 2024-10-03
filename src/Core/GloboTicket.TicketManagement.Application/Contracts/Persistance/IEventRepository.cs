using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistance;

public interface IEventRepository : IAsyncRepository<Event>
{
    public Task<bool> IsEventNameAndDateUnique(string? name, DateTime date);
}
