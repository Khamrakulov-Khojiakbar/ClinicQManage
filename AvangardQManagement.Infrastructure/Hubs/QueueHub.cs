using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AvangardQManagement.Infrastructure.Hubs;


public class QueueHub : Hub
{
    public async Task JoinRoomGroup(int roomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"Room_{roomId}");
    }

    public async Task JoinMainScreenGroup()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "MainScreen");
    }
}