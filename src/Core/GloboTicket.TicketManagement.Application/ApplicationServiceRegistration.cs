using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        try
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
        catch (ReflectionTypeLoadException ex)
        {
            foreach (var loaderException in ex.LoaderExceptions)
            {
                Console.WriteLine(loaderException.Message);
            }
        }

        return service;
    }
}