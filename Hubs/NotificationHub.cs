using Microsoft.AspNetCore.SignalR;

namespace GoalTracker.Hubs;

public class NotificationHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("RecieveMessage", user, message);
    }
    
}