using Domain;

namespace Infrastructure;

public interface IScreeningService
{
    List<Screening> GetAllScreenings();
    Screening GetScreeningById(int id);
    Screening AddScreening(Screening screening);
    Screening UpdateScreening(Screening screening);
    Screening DeleteScreening(int id);
}
