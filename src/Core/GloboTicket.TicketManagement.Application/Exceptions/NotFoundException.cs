namespace GloboTicket.TicketManagement.Application.Exception;

public class NotFoundExceptionException : System.Exception
{
    public NotFoundExceptionException(string name, object key) : base($"{name} ({key}) is not found")
    {
    }
}