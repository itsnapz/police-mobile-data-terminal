namespace MDT.Server.Data;

public class Warrant
{
    public Guid Id { get; set; }
    public string Date { get; set; }
    public string ReleasedBy { get; set; }
    public string Reason { get; set; }
    public Citizen Citizen { get; set; }
}