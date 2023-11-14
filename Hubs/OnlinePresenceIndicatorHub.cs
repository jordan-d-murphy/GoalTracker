using Microsoft.AspNetCore.SignalR;

namespace GoalTracker.Hubs;

public class OnlinePresenceIndicatorHub : Hub
{
    public async Task SendOnlinePresence(string user, string status)
    {
        await Clients.All.SendAsync("SendOnlinePresence", user, status);
    }

    
}