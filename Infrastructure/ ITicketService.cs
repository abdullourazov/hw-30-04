using Domain;

namespace Infrastructure;

public interface ITicketService
{
    List<Ticket> GetAllTickets();
    Ticket GetTicketById(int id);
    Ticket AddTicket(Ticket ticket);
    Ticket UpdateTicket(Ticket ticket);
    Ticket DeleteTicket(int id);
}
