namespace MDT.Lib.Models;

public class WarrantModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string ReleasedBy { get; set; }
    public string Reason { get; set; }
    public CitizenModel Citizen { get; set; }
}