namespace MDT.Server.Data;

public class Citizen
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Postal { get; set; }
    public string? Image { get; set; } = "https://wallpapers.com/images/hd/basic-default-pfp-pxi77qv5o0zuz8j3.jpg";
}