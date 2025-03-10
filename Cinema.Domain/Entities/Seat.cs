using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities;

public class Seat
{
    public int Row {  get; set; }
    public int Number {  get; set; }
    public SeatType Type { get; set; }
    public int HallId { get; set; }
}
