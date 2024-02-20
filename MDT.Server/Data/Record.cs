namespace MDT.Server.Data;

public class Record
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Guid OfficerId { get; set; }
    public Citizen Citizen { get; set; }
    public int? Fine { get; set; }
    public int? YearsInJail { get; set; }
}