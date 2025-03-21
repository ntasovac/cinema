using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.DTOs
{
    public class UserDTO
    {
        public string? Email { get; set; } 
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public UserType Type { get; set; }
    }
}
