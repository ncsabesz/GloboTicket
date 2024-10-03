using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistance;

public interface IOrderRepository : IAsyncRepository<Order>
{
    // public Guid EventId { get; set; }
    // public string Name { get; set; }
    // public DateTime Date { get; set; }
    // public string ImageUrl { get; set; }
}
