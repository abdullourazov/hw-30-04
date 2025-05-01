using Domain;
using Npgsql;

namespace Infrastructure.Services;

public class ScreeningService : IScreeningService
{
    private readonly string connectionString = "Server=localhost;Database=theatre;Port=5432;User Id=postgres;Password=35709120";
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

//task3
    public List<Screening> GetAllScreeningsSortedByTime()
    {
        var screenings = new List<Screening>();
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var cmd = "select * from screenings where screening_time > now()";
        using var command = new NpgsqlCommand(cmd, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var screening = new Screening
            {
                id = reader.GetInt32(0),
                movie_id = reader.GetInt32(1),
                theater_id = reader.GetInt32(2),
                screening_time = reader.GetDateTime(3)
            };
            screenings.Add(screening);
        }
        return screenings;
    }

//task5
    public List<Screening> GetAllScreenings()
    {
        var screenings = new List<Screening>();
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from screenings order by screening_time limit 5";
            using (var command = new NpgsqlCommand(cmd, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        screenings.Add(new Screening
                        {
                            id = reader.GetInt32(0),
                            movie_id = reader.GetInt32(1),
                            theater_id = reader.GetInt32(2),
                            screening_time = reader.GetDateTime(3)
                        });
                    }
                }
            }
        }
        return screenings;
    }


}
