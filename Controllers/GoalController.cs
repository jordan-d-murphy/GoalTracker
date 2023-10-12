using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace GoalTracker.Controllers;

public class GoalController : Controller
{
    // GET: /Goal/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /Goal/Welcome/
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}