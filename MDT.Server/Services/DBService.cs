using System.Collections;
using Mapster;
using MDT.Lib.Models;
using MDT.Server.Data;

namespace MDT.Server.Services;

public class DBService
{
    private readonly ApplicationDbContext _db;

    public DBService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<IEnumerable<CitizenModel>> GetCitizens()
    {
        var citizens = _db.Citizens.ProjectToType<CitizenModel>();

        return Task.FromResult<IEnumerable<CitizenModel>>(citizens);
    }

    public Task<IEnumerable<CarModel>> GetCars()
    {
        var cars = _db.Cars.ProjectToType<CarModel>();

        return Task.FromResult<IEnumerable<CarModel>>(cars);
    }

    public Task<IEnumerable<RecordModel>> GetRecords()
    {
        var records = _db.Records.ProjectToType<RecordModel>();

        return Task.FromResult<IEnumerable<RecordModel>>(records);
    }

    public Task<IEnumerable<FineModel>> GetFines()
    {
        var fines = _db.Fines.ProjectToType<FineModel>();

        return Task.FromResult<IEnumerable<FineModel>>(fines);
    }
}