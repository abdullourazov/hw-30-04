using Domain;

namespace Infrastructure.Services;

public class TheaterService : ITheaterService
{
    string connectionString = "Server=localhost; Database=theatre; Port=5432; User Id=postgres; Password=35709120";

    public List<Theater> GetAllTheaters() { return new List<Theater>(); }

    public Theater GetTheaterById(int id) { return null; }

    public Theater AddTheater(Theater theater) { return null; }

    public Theater UpdateTheater(Theater theater) { return null; }

    public Theater DeleteTheater(int id) { return null; }
}
