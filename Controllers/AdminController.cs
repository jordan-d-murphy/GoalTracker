using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoalTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace GoalTracker.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public AdminController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public IActionResult Index(string? adminVMMessage, string? adminVMMessageType)
    {
        var users = _userManager.Users.Select(u => new ApplicationUserViewModel
        {
            User = u,
            UserRoles = _userManager.GetRolesAsync(u).Result.ToList()
        }).ToList();

        var roles = _roleManager.Roles.OrderBy(r => r.Name).ToList();

        var avm = new AdminViewModel
        {
            AllUsers = users,
            AllRoles = roles,
            AdminVMMessage = adminVMMessage,
            AdminVMMessageType = adminVMMessageType
        };

        return View(avm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Role")] AdminCreate create)
    {

        if (!String.IsNullOrEmpty(create.Role))
        {
            var roleExists = await _roleManager.RoleExistsAsync(create.Role);
            if (!roleExists)
            {
                var result = await _roleManager.CreateAsync(new ApplicationRole() { Name = create.Role });
                if (result.Succeeded)
                {
                    // await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("Index", new { adminVMMessage = $"Role {create.Role} created.", adminVMMessageType = "success" });
                }
            }
        }

        return RedirectToAction("Index", new { adminVMMessage = $"Unable to create role {create.Role}.", adminVMMessageType = "warning" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Assign([Bind("Role,UserId")] AdminAssign assign)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == assign.UserId);
        if (user == null)
        {
            return NotFound();
        }

        if (!String.IsNullOrEmpty(assign.Role))
        {
            var roleExists = await _roleManager.RoleExistsAsync(assign.Role);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new ApplicationRole() { Name = assign.Role });
            }

            var result = await _userManager.AddToRoleAsync(user, assign.Role);
            if (result.Succeeded)
            {
                // await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", new { adminVMMessage = $"Role {assign.Role} assigned to User {user.Email}.", adminVMMessageType = "success" });
            }
        }

        return RedirectToAction("Index", new { adminVMMessage = $"Unable to assign role {assign.Role} to User {user.Email}.", adminVMMessageType = "warning" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Unassign([Bind("Role,UserId")] AdminUnassign unassign)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == unassign.UserId);

        if (user == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, unassign.Role);
            if (result.Succeeded)
            {
                // await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", new { adminVMMessage = $"Role {unassign.Role} unassigned from User {user.Email}.", adminVMMessageType = "success" });
            }
        }

        return RedirectToAction("Index", new { adminVMMessage = $"Unable to unassign role {unassign.Role} from User {user.Email}.", adminVMMessageType = "warning" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete([Bind("Role")] AdminDelete delete)
    {

        if (!String.IsNullOrEmpty(delete.Role))
        {
            var roleExists = await _roleManager.RoleExistsAsync(delete.Role);
            if (roleExists)
            {
                var role = await _roleManager.FindByNameAsync(delete.Role);
                if (role is not null && role.Name != "Admin" && @role.Name != "ConfirmedAccount")
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        // await _signInManager.RefreshSignInAsync(user);
                        return RedirectToAction("Index", new { adminVMMessage = $"Role {delete.Role} deleted.", adminVMMessageType = "success" });
                    }
                }
            }
        }

        return RedirectToAction("Index", new { adminVMMessage = $"Unable to delete role {delete.Role}.", adminVMMessageType = "warning" });
    }


}
