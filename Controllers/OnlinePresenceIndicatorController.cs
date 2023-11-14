using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoalTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.SignalR;
using GoalTracker.Hubs;
using GoalTracker.Utils;
using GoalTracker.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Enums;

namespace GoalTracker.Controllers;

[Authorize(Roles = "ConfirmedAccount")]
public class OnlinePresenceIndicatorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly IMessageProducer _messagePublisher;


    public OnlinePresenceIndicatorController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager,
            IMessageProducer messagePublisher)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _messagePublisher = messagePublisher;
    }

     public IActionResult Index()
    {
       return Ok("Test response");
    }


   

    [AllowAnonymous]
    public async void PollActiveUsers()
    {

        System.Diagnostics.Debug.WriteLine("Hit OnlinePresenceIndicatorController::PollActiveUsers()");

        var users = await _userManager.Users.Where(u => u.OnlinePresenceIndicator != null).ToListAsync();
        foreach (var user in users)
        {

            var msgLoggedIn = $" \n\nsecond middleware, {user.Email}, your OnlinePresenceIndicator says you were last active at {user.OnlinePresenceIndicator}!\n\n ";
            System.Diagnostics.Debug.WriteLine(msgLoggedIn);

            var utcOPI = user.OnlinePresenceIndicator?.ToUniversalTime();

            if (DateTime.UtcNow < utcOPI?.AddMinutes(1))
            {
                var msg1Min = "OnlinePresenceIndicator says you were active within the last min";
                System.Diagnostics.Debug.WriteLine(msg1Min);
                _messagePublisher.SendOnlinePresence(new OnlinePresence(user, OnlinePresenceStatus.ONLINE));

            }
            else
            {
                var msg1Min = "OnlinePresenceIndicator says you were NOT active within the last min";
                System.Diagnostics.Debug.WriteLine(msg1Min);
                _messagePublisher.SendOnlinePresence(new OnlinePresence(user, OnlinePresenceStatus.OFFLINE));
            }

        }
    }



}
