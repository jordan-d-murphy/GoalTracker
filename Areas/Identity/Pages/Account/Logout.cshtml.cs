// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GoalTracker.Areas.Identity.Data;
using GoalTracker.RabbitMQ;
using Newtonsoft.Json;
using GoalTracker.Models;
using GoalTracker.Enums;

namespace GoalTracker.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<LogoutModel> _logger;

        private readonly IMessageProducer _messagePublisher;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, IMessageProducer messagePublisher, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _messagePublisher = messagePublisher;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            
            var user = _userManager.GetUserAsync(User).Result;

            if (user is not null)
            {
                // send online status indication
                _messagePublisher.SendOnlinePresence(new OnlinePresence(user, OnlinePresenceStatus.OFFLINE));
                user.OnlinePresenceIndicator = null;
                await _userManager.UpdateAsync(user);
            }

            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
