﻿namespace eBPS.Domain.Entities.Shared
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
        public int LastLoginOrgId { get; set; }
        public int LastLoginRoleId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

}
