namespace Domain;

public class Ticket
{
    public int id { get; set; }
    public int screening_id { get; set; }
    public string customer_name { get; set; }
    public string seat_number { get; set; }
    public DateTime purchase_time { get; set; }
    public Decimal price { get; set; }
    public string payment_method { get; set; }
}
