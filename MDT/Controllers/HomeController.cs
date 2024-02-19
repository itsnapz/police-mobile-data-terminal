using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MDT.Models;
using MDT.Services;
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
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}