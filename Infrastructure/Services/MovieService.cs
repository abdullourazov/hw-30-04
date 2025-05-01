using System.Data;
using System.Security.Cryptography;
using Domain;
using Npgsql;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    List<Movie> movies = new List<Movie>();
    string connectionString = "Server=localhost; Database=theatre; Port=5432; User Id=postgres; Password=35709120";

    public List<Movie> GetAllMovies()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from movies";
            var command = new NpgsqlCommand(cmd, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        id = reader.GetInt32(0),
                        title = reader.GetString(1),
                        director = reader.GetString(2),
                        year = reader.GetInt32(3),
                        duration = reader.GetInt32(4),
                        genre = reader.GetString(5),
                        description = reader.GetString(6)
                    });
                }
            }
            return movies;
        }
    }

    public Movie GetMovieById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from movies where id = @id";
            using (var command = new NpgsqlCommand(cmd, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        return new Movie
                        {
                            id = reader.GetInt32(0),
                            title = reader.GetString(1),
                            director = reader.GetString(2),
                            year = reader.GetInt32(3),
                            duration = reader.GetInt32(4),
                            genre = reader.GetString(5),
                            description = reader.GetString(6)
                        };
                    }
                }
            }
        }
        return null;
    }


    public Movie UpdateMovie(Movie movie)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = @"Update movies
            set title = @title
            director = @director,
            year = @year,
            duration = @duration,
            genre = @genre,
            description = @description
            where id = @id
            ";

            using (var command = new NpgsqlCommand(cmd, connection))
            {
                command.Parameters.AddWithValue("@title", movie.title);
                command.Parameters.AddWithValue("@director", movie.director);
                command.Parameters.AddWithValue("@year", movie.year);
                command.Parameters.AddWithValue("@duration", movie.duration);
                command.Parameters.AddWithValue("@genre", movie.genre);
                command.Parameters.AddWithValue("@description", movie.description);
                command.Parameters.AddWithValue("@id", movie.id);
                int result = command.ExecuteNonQuery();
                return result > 0 ? movie : null;
            }
        }
    }

    public Movie DeleteMovie(int id)
    {
        var movie = GetMovieById(id);
        if (movie == null)
            return null;
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "Delete from movies where id = @id";
            using (var command = new NpgsqlCommand())
            {
                command.Parameters.AddWithValue("@id", id);
                int result = command.ExecuteNonQuery();
                return result > 0 ? movie : null;
            }
        }
    }

    public Movie AddMovie(Movie movie)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = @"INSERT INTO movies (title, director, year, duration, genre, description)
                    VALUES (@title, @director, @year, @duration, @genre, @description)";
            using (var command = new NpgsqlCommand(cmd, connection))
            {
                command.Parameters.AddWithValue("@title", movie.title);
                command.Parameters.AddWithValue("@director", movie.director);
                command.Parameters.AddWithValue("@year", movie.year);
                command.Parameters.AddWithValue("@duration", movie.duration);
                command.Parameters.AddWithValue("@genre", movie.genre);
                command.Parameters.AddWithValue("@description", movie.description);

                command.ExecuteNonQuery();
            }
        }
        return movie;
    }

// task1
    public List<Movie> GetMoviesByGenre(string genre)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from movies where genre = '@genre'";
            using (var command = new NpgsqlCommand(cmd, connection))
            {
                command.Parameters.AddWithValue("@genre, genre");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            id = reader.GetInt32(0),
                            title = reader.GetString(1),
                            director = reader.GetString(2),
                            year = reader.GetInt32(3),
                            duration = reader.GetInt32(4),
                            genre = reader.GetString(5),
                            description = reader.GetString(6)
                        });
                    }
                }
            }
        }
        return movies;
    }
    // task2
    public List<string> GetAllDirectors(string genre)
    {
        var directors = new List<string>();
        using var connection = new NpgsqlConnection(connectionString);
        var cmd = "select distinct director from movies;";
        {
            connection.Open();
            using var command = new NpgsqlCommand(cmd, connection);
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    directors.Add(reader.GetString(0));
                }
                return directors;
            }
        }

    }
//task4
    public List<Movie> GetAllMovieSortedByYear()
    {
        var years = new List<Movie>();
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var cmd = "select * from movies where year = @year  order by year desc";
            using (var command = new NpgsqlCommand(cmd, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Movie movie = new Movie
                        {
                            id = reader.GetInt32(0),
                            title = reader.GetString(1),
                            director = reader.GetString(2),
                            year = reader.GetInt32(3),
                            duration = reader.GetInt32(4),
                            genre = reader.GetString(5),
                            description = reader.GetString(6)
                        };
                        movies.Add(movie);
                    }
                }
            }
        }
        return movies;
    }
    



}






