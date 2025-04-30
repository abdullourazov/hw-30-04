using Domain;
using Npgsql;

namespace Infrastructure.Services;

public class ScreeningService : IScreeningService
{
    private readonly string connectionString = "Server=localhost;Database=theatre;Port=5432;User Id=postgres;Password=35709120";

    public List<Screening> GetAllScreenings()
    {
         return new List<Screening>();
    }

    public Screening GetScreeningById(int id)
    {
        return null;
    }

    public Screening AddScreening(Screening screening)
    {
        return null;
    }

    public Screening UpdateScreening(Screening screening)
    {
        return null;
    }

    public Screening DeleteScreening(int id)
    {
        return null;
    }
}
