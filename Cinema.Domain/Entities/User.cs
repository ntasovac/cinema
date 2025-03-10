using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string? Email {  get; set; } // jel name treba id ili su useri jedinstveni preko email-a
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly BirthDate { get; set; }
    public UserType Type { get; set; }
}
