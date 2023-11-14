using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Data;
using GoalTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GoalTracker.Areas.Identity.Data;

namespace GoalTracker.Controllers
{
    [Authorize(Roles = "ConfirmedAccount")]
    public class TeamController : Controller
    {
        private readonly GoalTrackerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<ApplicationRole> _roleManager;


        public TeamController(GoalTrackerContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Team
        public async Task<IActionResult> Index(string? teamVMMessage, string? teamVMMessageType)
        {
            if (_userManager.Users != null && _context.Team != null)
            {
                var teams = await _context.Team.Include(t => t.Parent).Include(t => t.CreatedBy).ToListAsync();
                var users = await _userManager.Users.ToListAsync();
                // var roles = await _roleManager.Roles.ToListAsync();               

                var userSelectList = new List<SelectListItem> { };

                foreach (var u in users)
                {
                    userSelectList.Add(new SelectListItem { Value = u.Id.ToString(), Text = u.Email });
                }

                foreach (var team in teams)
                {
                    var roleExists = await _roleManager.RoleExistsAsync(team.Id.ToString());
                    if (roleExists)
                    {
                        team.TeamMembers = new List<ApplicationUser>();
                        foreach (var user in users) 
                        {
                            if (_userManager.GetRolesAsync(user).Result.ToList().Contains(team.Id.ToString())) 
                            {
                                team.TeamMembers.Add(user);
                            }
                        }

                    }
                }

                var teamViewModel = new TeamViewModel
                {
                    Teams = teams,
                    AllUsers = userSelectList,
                    TeamVMMessage = teamVMMessage,
                    TeamVMMessageType = teamVMMessageType
                };

                return View(teamViewModel);
            }
            return View();

        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Team team)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                if (ModelState.IsValid)
                {
                    team.Id = Guid.NewGuid();
                    team.CreatedBy = user;
                    team.CreatedDate = DateTime.Now;
                    _context.Add(team);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Title,Description,CreatedDate,StartedDate,TargetDate,CompletedDate,Completed,Favorited,Category,Icon,Color")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Team == null)
            {
                return Problem("Entity set 'GoalTrackerContext.Team'  is null.");
            }
            var team = await _context.Team.FindAsync(id);
            if (team != null)
            {
                _context.Team.Remove(team);
                await _context.SaveChangesAsync();

                if (!String.IsNullOrEmpty(team.Id.ToString()))
                {
                    var roleExists = await _roleManager.RoleExistsAsync(team.Id.ToString());
                    if (roleExists)
                    {
                        var role = await _roleManager.FindByNameAsync(team.Id.ToString());
                        if (role is not null && role.Name != "Admin" && @role.Name != "ConfirmedAccount")
                        {
                            var result = await _roleManager.DeleteAsync(role);
                            if (result.Succeeded)
                            {
                                // await _signInManager.RefreshSignInAsync(user);
                                return RedirectToAction("Index", new { teamVMMessage = $"Role {team.Id.ToString()} deleted.", teamVMMessageType = "success" });
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Index", new { teamVMMessage = $"Unable to delete role {team!.Id.ToString()}.", teamVMMessageType = "warning" });

            // await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(Guid id)
        {
            return (_context.Team?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeamMember([Bind("AddUser,AddTeam")] TeamViewModel assign)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == assign!.AddUser!.Id);
            if (user == null)
            {
                return NotFound();
            }

            if (assign.AddTeam is not null)
            {
                var roleExists = await _roleManager.RoleExistsAsync(assign.AddTeam.Id.ToString());
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new ApplicationRole() { Name = assign.AddTeam.Id.ToString(), Description = assign.AddTeam.Title });
                }

                var result = await _userManager.AddToRoleAsync(user, assign.AddTeam.Id.ToString());
                if (result.Succeeded)
                {
                    // await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("Index", new { teamVMMessage = $"Role {assign.AddTeam.Title} assigned to User {user.Email}.", teamVMMessageType = "success" });
                }
            }

            return RedirectToAction("Index", new { teamVMMessage = $"Unable to assign role {assign!.AddTeam!.Title} to User {user.Email}.", teamVMMessageType = "warning" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveTeamMember([Bind("RemoveUser,RemoveTeam,AllUsers")] TeamViewModel unassign)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == unassign!.RemoveUser!.Id);

            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, unassign!.RemoveTeam!.Id.ToString());
                if (result.Succeeded)
                {
                    // await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("Index", new { teamVMMessage = $"Role {unassign!.RemoveTeam.Title} unassigned from User {user.Email}.", teamVMMessageType = "success" });
                }
            }

            return RedirectToAction("Index", new { teamVMMessage = $"Unable to unassign role {unassign!.RemoveTeam!.Id} from User {user.Email}.", teamVMMessageType = "warning" });
        }
        
    }
}
