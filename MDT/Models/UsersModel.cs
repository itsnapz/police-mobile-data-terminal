namespace MDT.Models;

public class UsersModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
}