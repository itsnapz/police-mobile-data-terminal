namespace MDT.Server.Data;

public class Fine
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Date { get; set; }
    public string OfficerName { get; set; }
    
    public Guid CitizenId { get; set; }
    public Citizen Citizen { get; set; }
}