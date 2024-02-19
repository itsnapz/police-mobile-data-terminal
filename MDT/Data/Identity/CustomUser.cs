using MDT.Lib.Enums;
using Microsoft.AspNetCore.Identity;

namespace MDT.Data.Identity;

public class CustomUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Enums.Ranks Rank { get; set; }
    public string CallSign { get; set; }
}