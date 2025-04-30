using Domain;
using Npgsql;

namespace Infrastructure.Services;

public class TicketService : ITicketService
{
    private readonly string connectionString = "Server=localhost;Database=theatre;Port=5432;User Id=postgres;Password=35709120";

    public List<Ticket> GetAllTickets()
    {
        return new List<Ticket>();
    }

    public Ticket GetTicketById(int id)
    {
        return null;
    }

    public Ticket AddTicket(Ticket ticket)
    {
        return null;
    }

    public Ticket UpdateTicket(Ticket ticket)
    {
        return null;
    }

    public Ticket DeleteTicket(int id)
    {
        return null;
    }
}
