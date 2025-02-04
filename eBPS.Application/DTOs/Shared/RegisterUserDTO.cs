using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.DTOs.Shared
{
    public class RegisterUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<int> RoleIds { get; set; }
        public List<int> OrgIds { get; set; }
    }

}
