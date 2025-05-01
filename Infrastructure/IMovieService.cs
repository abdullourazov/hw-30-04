using Domain;

namespace Infrastructure;

public interface IMovieService
{
    List<Movie> GetAllMovies();
    Movie GetMovieById(int id);
    Movie AddMovie(Movie movie);
    Movie UpdateMovie(Movie movie);
    Movie DeleteMovie(int id);
    List<Movie> GetMoviesByGenre(string genre);
    List<string> GetAllDirectors(string genre);
    List<Movie> GetAllMovieSortedByYear();

}
