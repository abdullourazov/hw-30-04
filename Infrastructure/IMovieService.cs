using Domain;

namespace Infrastructure;

public interface IMovieService
{
    List<Movie> GetAllMovies();
    Movie GetMovieById(int id);
    Movie AddMovie(Movie movie);
    Movie UpdateMovie(Movie movie);
    Movie DeleteMovie(int id);

}
