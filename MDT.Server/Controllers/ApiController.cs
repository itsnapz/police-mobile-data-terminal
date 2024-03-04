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
    
    [HttpGet(Endpoints.GET_CITIZENS)]
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

    [HttpGet(Endpoints.GET_WARRANTS)]
    public IEnumerable<WarrantModel> GetWarrants()
    {
        return _db.GetWarrants().Result;
    }

    [HttpGet(Endpoints.GET_CITIZEN)]
    public CitizenModel GetCitizenById(Guid id)
    {
        return _db.GetCitizenById(id).Result;
    }

    [HttpGet(Endpoints.GET_CAR)]
    public CarModel GetCarById(Guid id)
    {
        return _db.GetCarById(id).Result;
    }

    [HttpGet(Endpoints.GET_RECORD)]
    public RecordModel GetRecordById(Guid id)
    {
        return _db.GetRecordById(id).Result;
    }

    [HttpGet(Endpoints.GET_FINE)]
    public FineModel GetFineById(Guid id)
    {
        return _db.GetFineById(id).Result;
    }

    [HttpGet(Endpoints.GET_WARRANT)]
    public WarrantModel GetWarrantById(Guid id)
    {
        return _db.GetWarrantById(id).Result;
    }

    [HttpGet(Endpoints.GET_OWNED_CARS)]
    public IEnumerable<CarModel> GetOwnedCars(Guid id)
    {
        return _db.GetOwnedCars(id).Result;
    }

    [HttpGet(Endpoints.GET_OWNED_RECORDS)]
    public IEnumerable<RecordModel> GetOwnedRecords(Guid id)
    {
        return _db.GetOwnedRecords(id).Result;
    }

    [HttpGet(Endpoints.GET_OWNED_FINES)]
    public IEnumerable<FineModel> GetOwnedFines(Guid id)
    {
        return _db.GetOwnedFines(id).Result;
    }

    [HttpGet(Endpoints.GET_OWNED_WARRANTS)]
    public IEnumerable<WarrantModel> GetOwnedWarrants(Guid id)
    {
        return _db.GetOwnedWarrants(id).Result;
    }

    [HttpPost(Endpoints.CREATE_WARRANT)]
    public IActionResult CreateWarrant([FromBody] WarrantModel warrant)
    {
        if (warrant == null)
        {
            return BadRequest();
        }
        
        _db.CreateWarrant(warrant); 
        return Ok();
    }

    [HttpPost(Endpoints.CREATE_RECORD)]
    public IActionResult CreateRecord([FromBody] RecordModel record)
    {
        if (record == null)
        {
            return BadRequest();
        }
        
        _db.CreateRecord(record);
        return Ok();
    }

    [HttpPost(Endpoints.CREATE_FINE)]
    public IActionResult CreateFine([FromBody] FineModel fine)
    {
        if (fine == null)
        {
            return BadRequest();
        }
        
        _db.CreateFine(fine);
        return Ok();
    }

    [HttpPost(Endpoints.CREATE_CAR)]
    public IActionResult CreateCar([FromBody] CarModel car)
    {
        if (car == null)
        {
            return BadRequest();
        }
        
        _db.CreateCar(car);
        return Ok();
    }

    [HttpDelete(Endpoints.DELETE_WARRANT)]
    public IActionResult DeleteWarrant(Guid id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        
        _db.DeleteWarrant(id);
        return Ok();
    }

    [HttpDelete(Endpoints.DELETE_RECORD)]
    public IActionResult DeleteRecord(Guid id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        
        _db.DeleteRecord(id);
        return Ok();
    }

    [HttpDelete(Endpoints.DELETE_FINE)]
    public IActionResult DeleteFine(Guid id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        
        _db.DeleteFine(id);
        return Ok();
    }

    [HttpDelete(Endpoints.DELETE_CAR)]
    public IActionResult DeleteCar(Guid id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        
        _db.DeleteCar(id);
        return Ok();
    }

    [HttpPost(Endpoints.EDIT_WARRANT)]
    public IActionResult EditWarrant([FromBody] WarrantModel warrant)
    {
        if (warrant == null)
        {
            return BadRequest();
        }
        
        _db.EditWarrant(warrant);
        return Ok();
    }

    [HttpPost(Endpoints.EDIT_RECORD)]
    public IActionResult EditRecord([FromBody] RecordModel record)
    {
        if (record == null)
        {
            return BadRequest();
        }
        
        _db.EditRecord(record);
        return Ok();
    }

    [HttpPost(Endpoints.EDIT_FINE)]
    public IActionResult EditFine([FromBody] FineModel fine)
    {
        if (fine == null)
        {
            return BadRequest();
        }
        
        _db.EditFine(fine);
        return Ok();
    }

    [HttpPost(Endpoints.EDIT_CAR)]
    public IActionResult EditCar([FromBody] CarModel car)
    {
        if (car == null)
        {
            return BadRequest();
        }
        
        _db.EditCar(car);
        return Ok();
    }
}