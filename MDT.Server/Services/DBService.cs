using MDT.Server.Data;

namespace MDT.Server.Services;

public class DBService
{
    private readonly ApplicationDbContext _db;

    public DBService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    
}