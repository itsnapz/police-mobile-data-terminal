using System.Diagnostics;
using MDT.Data.Identity;
using MDT.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using MDT.Models;
using MDT.Server.Data.Migrations;
using MDT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace MDT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MDTService _mdt;
    private UserManager<CustomUser> _user;

    public HomeController(ILogger<HomeController> logger, UserManager<CustomUser> user)
    {
        _logger = logger;
        _mdt = new();
        _user = user;
    }
    
    public IActionResult Home()
    {
        return View();
    }

    [Authorize]
    public IActionResult Citizens()
    {
        var citizens = _mdt.GetCitizens().GetAwaiter().GetResult().ToList();
        
        return View(citizens);
    }

    [Authorize]
    public IActionResult CitizenDetail(Guid citizenId)
    {
        var citizen = _mdt.GetCitizen(citizenId).GetAwaiter().GetResult();
        citizen.Records = _mdt.GetOwnedRecords(citizenId).GetAwaiter().GetResult().ToList();
        citizen.Fines = _mdt.GetOwnedFines(citizenId).GetAwaiter().GetResult().ToList();
        citizen.Warrants = _mdt.GetOwnedWarrants(citizenId).GetAwaiter().GetResult().ToList();
        citizen.Cars = _mdt.GetOwnedCars(citizenId).GetAwaiter().GetResult().ToList();

        return View(citizen);
    }

    [Authorize]
    public IActionResult Cars()
    {
        var cars = _mdt.GetCars().GetAwaiter().GetResult().ToList();
        foreach (var car in cars)
        {
            car.CitizenData = _mdt.GetCitizen(car.CitizenId).GetAwaiter().GetResult();
        }
        
        return View(cars);
    }
    
    [Authorize]
    public IActionResult CarDetail(Guid carId)
    {
        var car = _mdt.GetCar(carId).GetAwaiter().GetResult();
        car.CitizenData = _mdt.GetCitizen(car.CitizenId).GetAwaiter().GetResult();

        return View(car);
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult CarNew(Guid citizenId)
    {
        Response.Cookies.Append("visited", citizenId.ToString());
        return View(new CarModel());
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CarNew(CarModel car)
    {
        car.Id = Guid.NewGuid();

        Guid id = new(Request.Cookies["visited"]);

        car.CitizenId = id;

        await _mdt.CreateCar(car);
        
        return RedirectToAction("Cars");
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CarDelete(Guid carId)
    {
        await _mdt.DeleteCar(carId);
        
        return RedirectToAction("Cars");
    }

    [Authorize]
    public IActionResult Records()
    {
        var records = _mdt.GetRecords().GetAwaiter().GetResult().ToList();
        foreach (var record in records)
        {
            record.CitizenData = _mdt.GetCitizen(record.CitizenId).GetAwaiter().GetResult();
        }
        
        return View(records);
    }

    [Authorize]
    public IActionResult RecordDetail(Guid recordId)
    {
        var record = _mdt.GetRecord(recordId).GetAwaiter().GetResult();
        record.CitizenData = _mdt.GetCitizen(record.CitizenId).GetAwaiter().GetResult();

        return View(record);
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult RecordNew(Guid citizenId)
    {
        Response.Cookies.Append("visited", citizenId.ToString());
        return View(new RecordModel());
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> RecordNew(RecordModel record)
    {
        record.Id = Guid.NewGuid();
        record.Date = DateTime.Now.ToShortDateString();

        var user =  await _user.GetUserAsync(User);
        record.OfficerName = $"{user.Name} {user.Surname}";

        Guid id = new(Request.Cookies["visited"]);

        record.CitizenId = id;

        await _mdt.CreateRecord(record);
        
        return RedirectToAction("Records");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult RecordDelete(Guid carId)
    {
        _mdt.DeleteRecord(carId);
        
        return RedirectToAction("Records");
    }

    [Authorize]
    public IActionResult Fines()
    {
        var fines = _mdt.GetFines().GetAwaiter().GetResult().ToList();
        foreach (var fine in fines)
        {
            fine.CitizenData = _mdt.GetCitizen(fine.CitizenId).GetAwaiter().GetResult();
        }
        
        return View(fines);
    }

    [Authorize]
    public IActionResult FineDetail(Guid fineId)
    {
        var fine = _mdt.GetFine(fineId).GetAwaiter().GetResult();
        fine.CitizenData = _mdt.GetCitizen(fine.CitizenId).GetAwaiter().GetResult();

        return View(fine);
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult FineNew(Guid citizenId)
    {
        Response.Cookies.Append("visited", citizenId.ToString());
        return View(new FineModel());
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> FineNew(FineModel fine)
    {
        fine.Id = Guid.NewGuid();
        fine.Date = DateTime.Now.ToShortDateString();

        var user =  await _user.GetUserAsync(User);
        fine.OfficerName = $"{user.Name} {user.Surname}";

        Guid id = new(Request.Cookies["visited"]);

        fine.CitizenId = id;

        await _mdt.CreateFine(fine);
        
        return RedirectToAction("Fines");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult FineDelete(Guid fineId)
    {
        _mdt.DeleteFine(fineId);
        
        return RedirectToAction("Fines");
    }

    [Authorize]
    public IActionResult Warrants()
    {
        var warrants = _mdt.GetWarrants().GetAwaiter().GetResult().ToList();
        foreach (var warrant in warrants)
        {
            warrant.CitizenData = _mdt.GetCitizen(warrant.CitizenId).GetAwaiter().GetResult();
        }
        
        return View(warrants);
    }

    [Authorize]
    public IActionResult WarrantDetail(Guid warrantId)
    {
        var warrant = _mdt.GetWarrant(warrantId).GetAwaiter().GetResult();
        warrant.CitizenData = _mdt.GetCitizen(warrant.CitizenId).GetAwaiter().GetResult();

        return View(warrant);
    }

    [Authorize]
    [HttpGet]
    public IActionResult WarrantNew(Guid citizenId)
    {
        Response.Cookies.Append("visited", citizenId.ToString());
        return View(new WarrantModel());
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> WarrantNew(WarrantModel warrant)
    {
        warrant.Id = Guid.NewGuid();
        warrant.Date = DateTime.Now.ToShortDateString();

        var user =  await _user.GetUserAsync(User);
        warrant.ReleasedBy = $"{user.Name} {user.Surname}";

        Guid id = new(Request.Cookies["visited"]);
        var citizen = _mdt.GetCitizen(id).GetAwaiter().GetResult();

        warrant.CitizenId = id;
        
        await _mdt.CreateWarrant(warrant);
        
        return RedirectToAction("Warrants");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult WarrantDelete(Guid warrantId)
    {
        _mdt.DeleteWarrant(warrantId);
        
        return RedirectToAction("Warrants");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}