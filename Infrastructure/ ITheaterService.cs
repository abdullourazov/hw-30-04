 using Domain;

namespace Infrastructure.Services;

public interface ITheaterService
{
    List<Theater> GetAllTheaters();            
    Theater GetTheaterById(int id);
    Theater AddTheater(Theater theater);
    Theater UpdateTheater(Theater theater);
    Theater DeleteTheater(int id);
}
