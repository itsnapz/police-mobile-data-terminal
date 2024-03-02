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
        
        return View(cars);
    }
    
    [Authorize]
    public IActionResult CarDetail(Guid carId)
    {
        var car = _mdt.GetCar(carId).GetAwaiter().GetResult();

        return View(car);
    }

    [Authorize]
    public IActionResult Records()
    {
        var records = _mdt.GetRecords().GetAwaiter().GetResult().ToList();
        
        return View(records);
    }

    [Authorize]
    public IActionResult RecordDetail(Guid recordId)
    {
        var record = _mdt.GetRecord(recordId).GetAwaiter().GetResult();

        return View(record);
    }

    [Authorize]
    public IActionResult Fines()
    {
        var fines = _mdt.GetFines().GetAwaiter().GetResult().ToList();
        
        return View(fines);
    }

    [Authorize]
    public IActionResult FineDetail(Guid fineId)
    {
        var fine = _mdt.GetFine(fineId).GetAwaiter().GetResult();

        return View(fine);
    }

    [Authorize]
    public IActionResult Warrants()
    {
        var warrants = _mdt.GetWarrants().GetAwaiter().GetResult().ToList();
        
        return View(warrants);
    }

    [Authorize]
    public IActionResult WarrantDetail(Guid warrantId)
    {
        var warrant = _mdt.GetWarrant(warrantId).GetAwaiter().GetResult();

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

        warrant.Citizen = citizen;
        
        await _mdt.CreateWarrant(warrant);
        
        return RedirectToAction("Warrants");
    }

    [Authorize]
    [HttpGet]
    public IActionResult RecordNew(Guid citizenId)
    {
        return View(new RecordModel()
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now.ToShortDateString(),
            Citizen =
            {
                Id = citizenId
            }
        });
    }

    [Authorize]
    [HttpPost]
    public IActionResult RecordNew(RecordModel record)
    {
        _mdt.CreateRecord(record);

        return RedirectToAction("Records");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}