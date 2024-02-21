namespace MDT.Server.Data;

public class Warrant
{
    public Guid Id { get; set; }
    public Citizen Citizen { get; set; }
    public DateTime Date { get; set; }
    public string ReleasedBy { get; set; }
    public string Reason { get; set; }
}