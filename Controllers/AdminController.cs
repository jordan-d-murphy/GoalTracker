using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoalTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoalTracker.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AdminController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
}
