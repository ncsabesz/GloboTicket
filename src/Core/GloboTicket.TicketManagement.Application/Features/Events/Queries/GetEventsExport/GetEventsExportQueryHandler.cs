using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;
    private readonly ICsvExporter _csvExporter;

    public GetEventsExportQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, ICsvExporter csvExporter)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
        _csvExporter = csvExporter;
    }

    public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
    {
        var allEvents = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x=>x.Date));

        var fileDate = _csvExporter.ExportEventsToCsv(allEvents);

        var eventExportFileDto = new EventExportFileVm()
        {
            ContentType = "text/csv",
            Data = fileDate,
            EventExportFileName = $"{Guid.NewGuid()}.csv"
        };

        return eventExportFileDto;
    }
}