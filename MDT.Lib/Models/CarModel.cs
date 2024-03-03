namespace MDT.Lib.Models;

public class CarModel
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    
    public Guid CitizenId { get; set; }
    public CitizenModel? CitizenData { get; set; }
}