namespace GloboTicket.TicketManagement.Application.Exception;
public class BadRequestExceptionException : System.Exception
{
    public BadRequestExceptionException(string message) : base(message) { }
}