using System.Collections;
using MDT.Lib.Endpoints;
using MDT.Lib.Models;
using MDT.Server.Data;
using MDT.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace MDT.Server.Controllers;

[ApiController]
public class ApiController : Controller
{
    private readonly DBService _db;
    public ApiController(DBService db)
    {
        _db = db;
    }
    
    [HttpGet(Endpoints.GET_USERS)]
    public IEnumerable<CitizenModel> GetCitizens()
    {
        return _db.GetCitizens().Result;
    }

    [HttpGet(Endpoints.GET_CARS)]
    public IEnumerable<CarModel> GetCars()
    {
        return _db.GetCars().Result;
    }

    [HttpGet(Endpoints.GET_RECORDS)]
    public IEnumerable<RecordModel> GetRecords()
    {
        return _db.GetRecords().Result;
    }

    [HttpGet(Endpoints.GET_FINES)]
    public IEnumerable<FineModel> GetFines()
    {
        return _db.GetFines().Result;
    }
}