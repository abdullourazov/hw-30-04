namespace Domain;

public class Screening
{
    public int id { get; set; }
    public int  movie_id { get; set; }
    public int theater_id { get; set; }
    public DateTime  screening_time { get; set; }
    public Decimal ticket_price { get; set; }
    public string screening_room { get; set; }
    public int available_seats { get; set; }
}
