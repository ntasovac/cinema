using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities;

public class Reservation
{
    public int GuestId { get; set; }
    public MovieScreening? MovieScreening { get; set; }
    public int TotalPrice { get; set; }
    // lista rezervisanih sedista

}
