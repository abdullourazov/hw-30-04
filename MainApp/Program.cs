using Infrastructure.Services;
using Domain;


var movieService = new MovieService();
var theaterService = new TheaterService();
var screeningService = new ScreeningService();
var ticketService = new TicketService();

while (true)
{
    System.Console.WriteLine("\n--- Cinema Management ---");
    System.Console.WriteLine("1. Show all movies");
    System.Console.WriteLine("2. Add movie");
    System.Console.WriteLine("3. Exit");
    System.Console.Write("Select option: ");
    string option = System.Console.ReadLine();

    if (option == "1")
    {
        var movies = movieService.GetAllMovies();
        foreach (var m in movies)
        {
            System.Console.WriteLine($"{m.id}. {m.title} ({m.year})");
        }
    }
    else if (option == "2")
    {
        Console.Write("Title: ");
        var title = System.Console.ReadLine();
        Console.Write("Director: ");
        var director = System.Console.ReadLine();
        Console.Write("Year: ");
        var year = int.Parse(System.Console.ReadLine());
        Console.Write("Duration: ");
        var duration = int.Parse(System.Console.ReadLine());
        Console.Write("Genre: ");
        var genre = System.Console.ReadLine();
        Console.Write("Description: ");
        var description = System.Console.ReadLine();

        var movie = new Movie
        {
            title = title,
            director = director,
            year = year,
            duration = duration,
            genge = genre,
            description = description
        };

        movieService.AddMovie(movie);
        System.Console.WriteLine("Movie added.");
    }
    else if (option == "3")
    {
        break;
    }
    else
    {
        System.Console.WriteLine("Invalid option.");
    }
}
