namespace MDT.Lib.Models;

public class FineModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Date { get; set; }
    public string OfficerName { get; set; }
    public CitizenModel Citizen { get; set; }
}