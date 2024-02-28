namespace MDT.Lib.Models;

public class RecordModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string OfficerName { get; set; }
    public CitizenModel Citizen { get; set; }
    public int? YearsInJail { get; set; }
}