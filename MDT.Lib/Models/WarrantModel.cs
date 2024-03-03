namespace MDT.Lib.Models;

public class WarrantModel
{
    public Guid Id { get; set; }
    public string Date { get; set; }
    public string ReleasedBy { get; set; }
    public string Reason { get; set; }
    
    public Guid CitizenId { get; set; }
    public CitizenModel? CitizenData { get; set; }
}