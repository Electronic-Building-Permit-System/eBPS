using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Domain.Entities
{
    public class UserOrganizations
    {
        public int UserId {  get; set; }
        public int OrganizationId {  get; set; }
        public int RoleId {  get; set; }
        public bool IsActive {  get; set; }
        public DateTime JoinedDate {  get; set; }
    }
}
