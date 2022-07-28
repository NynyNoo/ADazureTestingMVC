using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleADApp.Models;

namespace SimpleADApp.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize("ProjectManager-only")]
    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles = "HR")]
    public IActionResult HR()
    {
        return View();
    }
    [Authorize(Roles = "PManager")]
    public IActionResult PM()
    {
        return View();
    }
    [Authorize(Roles = "PManager,HR")]
    public IActionResult PMHR()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}