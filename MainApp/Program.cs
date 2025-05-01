using Infrastructure.Services;
using Domain;
using Infrastructure;


var movieService = new MovieService();
var theaterService = new TheaterService();
var screeningService = new ScreeningService();
var ticketService = new TicketService();

while (true)
{
    System.Console.WriteLine("Cinema Management");
    System.Console.WriteLine("1. Show all movies");
    System.Console.WriteLine("2. Add movie");
    System.Console.WriteLine("3. Show movies by genre");
    System.Console.WriteLine("4. Show all directors");
    System.Console.WriteLine("5. Show all screenings");
    System.Console.WriteLine("6. Show all movies sorted by year");
    System.Console.WriteLine("6. Show all screening firstFive");
    System.Console.WriteLine("7. Exit");
    System.Console.Write("Select option: ");
    string option = System.Console.ReadLine();

    if (option == "1")
    {
        var movies = movieService.GetAllMovies();
        foreach (var item in movies)
        {
            System.Console.WriteLine($"{item.id}. {item.title} ({item.year})");
        }
    }
    else if (option == "2")
    {
        System.Console.Write("Title: ");
        var title = System.Console.ReadLine();
        System.Console.Write("Director: ");
        var director = System.Console.ReadLine();
        System.Console.Write("Year: ");
        var year = int.Parse(System.Console.ReadLine());
        System.Console.Write("Duration: ");
        var duration = int.Parse(System.Console.ReadLine());
        System.Console.Write("Genre: ");
        var genre = System.Console.ReadLine();
        System.Console.Write("Description: ");
        var description = System.Console.ReadLine();

        var movie = new Movie
        {
            title = title,
            director = director,
            year = year,
            duration = duration,
            genre = genre,
            description = description
        };

        movieService.AddMovie(movie);
        System.Console.WriteLine("Movie added.");
    }

    else if (option == "3")
    {
        System.Console.Write("Enter genre: ");
        string genre = System.Console.ReadLine();

        var moviesByGenre = movieService.GetMoviesByGenre(genre);
        if (moviesByGenre.Count == 0)
        {
            System.Console.WriteLine("No movies found for this genre.");
        }
        else
        {
            foreach (var m in moviesByGenre)
            {
                System.Console.WriteLine($"{m.id}. {m.title} ({m.year}) - {m.genre}");
            }
        }
    }

    else if (option == "4")
    {
        System.Console.Write("Enter genre: ");
        var genre = System.Console.ReadLine();
        var directors = movieService.GetAllDirectors(genre);
        System.Console.WriteLine("Directors");
        foreach (var d in directors)
        {
            System.Console.WriteLine(d);
        }
    }
    else if (option == "5")
    {
        var screenings = screeningService.GetAllScreeningsSortedByTime();
        System.Console.WriteLine("All Screenings Sorted by Time");
        foreach (var item in screenings)
        {
            System.Console.WriteLine($"Screening ID: {item.id}, Movie ID: {item.movie_id}, Theater ID: {item.theater_id}, Time: {item.screening_time}");
        }
    }
    else if (option == "6")
    {
        var sortedMovies = movieService.GetAllMovieSortedByYear();
        
        System.Console.WriteLine("Movies sorted by year (descending):");
        foreach (var item in sortedMovies)
        {
            System.Console.WriteLine($"{item.id}. {item.title} - {item.year}");
        }
    }
    else if (option == "")
{
    var firstFive = screeningService.GetAllScreenings();
    System.Console.WriteLine("First 5 Screenings:");
    foreach (var item in firstFive)
    {
        System.Console.WriteLine($"Screening ID: {item.id}, Movie ID: {item.movie_id}, Theater ID: {item.theater_id}, Time: {item.screening_time}");
    }
}
    else if (option == "8")
    {
        break;
    }
    else
    {
        System.Console.WriteLine("Nevernyy variant.");
    }

}
