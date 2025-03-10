using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities;

public class MovieScreening
{
    public int MovieId { get; set; }
    public int HallNumber { get; set; }
    public DateTime Start {  get; set; }
    public int Price { get; set; }
}
