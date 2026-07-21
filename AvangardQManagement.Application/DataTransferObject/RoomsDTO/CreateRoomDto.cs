using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Application.DataTransferObject.RoomsDTO;

public record CreateRoomDto
    (
        int RoomNumber, string RoomName
    );
