using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Models;

public class Reception
{
    public int Id { get; set; }
    public string ReceptionName { get; set; } = string.Empty;
    public decimal? Price { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

}
