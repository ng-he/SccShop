using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Account() { }

        public Account(string Id, string Username, string Email, string Password, string Role) {
            this.Id = Id;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role;
        }

        public Account(string Username, string Email, string Password, string Role)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role;
        }
    }
}