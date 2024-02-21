namespace MDT.Server.Data;

public class Fine
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public DateTime Date { get; set; }
    public Citizen Citizen { get; set; }
}