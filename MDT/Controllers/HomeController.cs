using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MDT.Models;
using MDT.Services;
using Microsoft.AspNetCore.Authorization;

namespace MDT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MDTService _mdt;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _mdt = new();
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
    public IActionResult Cars()
    {
        var cars = _mdt.GetCars().GetAwaiter().GetResult().ToList();
        
        return View(cars);
    }

    [Authorize]
    public IActionResult Records()
    {
        var records = _mdt.GetRecords().GetAwaiter().GetResult().ToList();
        
        return View(records);
    }

    [Authorize]
    public IActionResult Fines()
    {
        var fines = _mdt.GetFines().GetAwaiter().GetResult().ToList();
        
        return View(fines);
    }

    [Authorize]
    public IActionResult Warrants()
    {
        var warrants = _mdt.GetWarrants().GetAwaiter().GetResult().ToList();
        
        return View(warrants);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}