using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MDT.Models;
using MDT.Services;
using Microsoft.AspNetCore.Authorization;
using SQLitePCL;

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
    
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Citizens()
    {
        return View();
    }

    [Authorize]
    public IActionResult Cars()
    {
        return View();
    }

    [Authorize]
    public IActionResult Records()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}