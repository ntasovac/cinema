using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities;

public class Hall
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int TotalSeats { get; set; }
    public List<Seat>? FreeSeats { get; set; }
    public List<Seat>? ReservedSeats { get; set; }
}
