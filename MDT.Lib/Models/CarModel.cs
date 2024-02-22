namespace MDT.Lib.Models;

public class CarModel
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public CitizenModel Citizen { get; set; }
}