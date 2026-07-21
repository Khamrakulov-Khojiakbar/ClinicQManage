using AvangardQManagement.Application.DataTransferObject.TicketsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Application.Common.Interfaces;

public interface IQueueNotificationService
{
    Task NotifyTicketStatusChangedAsync(TicketDto ticket, CancellationToken cancellationToken);
    Task NotifyQueueUpdatedAsync(TicketDto ticket, CancellationToken cancellationToken);
}
