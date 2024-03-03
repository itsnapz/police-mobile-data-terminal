namespace MDT.Lib.Models;

public class RecordModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string OfficerName { get; set; }
    public int? YearsInJail { get; set; }
    
    public Guid CitizenId { get; set; }
    public CitizenModel? CitizenData { get; set; }
}