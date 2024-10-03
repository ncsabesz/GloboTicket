namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesWithEvents;

public class CategoryEventListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CategoryEventDto>? Events { get; set; }
}