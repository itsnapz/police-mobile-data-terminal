namespace MDT.Server.Data;

public class Record
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string OfficerName { get; set; }
    public Citizen Citizen { get; set; }
    public int? YearsInJail { get; set; }
}