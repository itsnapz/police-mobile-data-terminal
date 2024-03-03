namespace MDT.Server.Data;

public class Car
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    
    public Guid CitizenId { get; set; }
    public Citizen Citizen { get; set; }
}