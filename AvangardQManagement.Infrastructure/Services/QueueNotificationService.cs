using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Application.DataTransferObject.TicketsDTO;
using AvangardQManagement.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Services;

public class QueueNotificationService : IQueueNotificationService
{
    private readonly IHubContext<QueueHub> _hubContext;

    public QueueNotificationService(IHubContext<QueueHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyQueueUpdatedAsync(TicketDto ticket, CancellationToken cancellationToken)
    {
        await _hubContext.Clients
            .Group($"Room_{ticket.RoomId}")
            .SendAsync("TicketStatusChanged", ticket, cancellationToken);
    }

    public async Task NotifyTicketStatusChangedAsync(TicketDto ticket, CancellationToken cancellationToken)
    {
        await _hubContext.Clients
            .Group("MainScreen")
            .SendAsync("QueueUpdated", ticket, cancellationToken);
    }
}
