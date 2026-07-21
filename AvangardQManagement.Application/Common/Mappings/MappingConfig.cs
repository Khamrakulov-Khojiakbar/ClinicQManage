using AvangardQManagement.Application.DataTransferObject.TicketsDTO;
using AvangardQManagement.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Application.Common.Mappings;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Ticket, TicketDto>()
            .Map(dest => dest.RoomName, src => src.Room != null ? src.Room.RoomNumber.ToString() : string.Empty)
            .Map(dest => dest.ReceptionName, src => src.Reception != null ? src.Reception.ReceptionName : string.Empty)
            .Map(dest => dest.UserName, src => src.User != null ? $"{src.User.Name} {src.User.LastName}".Trim() : null)
            .Map(dest => dest.Status, src => src.Status.ToString());

        
    }
}
